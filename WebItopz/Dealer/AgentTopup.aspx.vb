Imports System.Data.SqlClient
Imports WebItopz.CommonItopDealer

Partial Class DealerTopup
    Inherits System.Web.UI.Page


    Private Const STATUS_ACTIVE = "ACTIVE"
    Private Const STATUS_PENDING As String = "PENDING"
    Dim sAgentMSISDN As String = ""
    'Private Const MT_MSG = "Your account been credited: D:[<DiGi>] M:[<Maxis>] C:[<Celcom>]. New balace: <NewBalance>. DateTime:<DateTime>."
    Private Const MT_MSG = "Your account been credited: $<Amount> New <NewBalance>. DateTime:<DateTime>."
    'Private Const MT_MSG2 = "Your have successfully transfered  $<Amount> to ID: <AgentID> HP: <MSISDN> Your new <NewBalance>. DateTime:<DateTime>."



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("DEALER_ID") = "" Then
            Response.Redirect("~/Dealer/Login.aspx")
        End If
        Me.lblErrorMsg.Text = ""

        Me.lblMyBalance.Text = getAgentBalance(Session("DEALER_ID"))
    End Sub


    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click

        Dim sAgentName As String = ""
        Dim iBalance As Decimal = getAgentBalance(Session("DEALER_ID"))
        Dim sAgentBalance As String = ""
        Dim sAgBalance As Decimal = 0
        Dim sFinalBalance As Decimal = 0

        'If Me.txtAgentId.Text = "" Or Not IsNumeric(Me.txtAgentId.Text) Then
        '    Me.lblErrorMsg.Text = "empty agent id or invalid agent id"
        'Else
        If Me.txtMaxisAmount.Text = "" Or Not IsNumeric(Me.txtMaxisAmount.Text) Then
            Me.lblErrorMsg.Text = "empty amount or invalid amount" ' (Maxis)"
            'ElseIf Me.txtDiGiAmount.Text = "" Or Not IsNumeric(Me.txtDiGiAmount.Text) Then
            '    Me.lblErrorMsg.Text = "empty amount or invalid amount (DiGi)"
            'ElseIf Me.txtCelcomAmount.Text = "" Or Not IsNumeric(Me.txtCelcomAmount.Text) Then
            '    Me.lblErrorMsg.Text = "empty amount or invalid amount (Celcom)"
            'ElseIf Me.txtBankIn.Text = "" Or Not IsNumeric(Me.txtBankIn.Text) Then
            '    Me.lblErrorMsg.Text = "empty amount or invalid amount (Bank In)"
        ElseIf CheckAgentUnderDealer(Me.DDLAgentID.SelectedValue, Session("DEALER_ID")) = False Then
            Me.lblErrorMsg.Text = "Agent not under you."
        ElseIf CInt(iBalance) < CInt(Me.txtMaxisAmount.Text) Then
            Me.lblErrorMsg.Text = "Your account insufficient balance. (" & iBalance.ToString & ")"
            'ElseIf Me.txtMaxisAmount.Text Like "%-%" Then
            'getAgentBalance(Me.DDLAgentID.SelectedValue) < CInt(Me.txtMaxisAmount.Text) Then
            'Me.lblErrorMsg.Text = "ERROR! Agent balance Insufficient (" & getAgentBalance(Me.DDLAgentID.SelectedValue).ToString & ")"
        Else
            sAgentName = GetAgentName(DDLAgentID.SelectedValue, sAgentMSISDN)
            sAgentBalance = getAgentBalance(DDLAgentID.SelectedValue)
            sAgBalance = sAgentBalance.Replace("Balance: SGD", "")
            Session("TopUpMSISDN") = sAgentMSISDN
            sFinalBalance = Me.txtMaxisAmount.Text + sAgBalance

            If (sFinalBalance < 0) Then
                Me.lblErrorMsg.Text = "ERROR! Deduction Exceed Current Bal : $" & sAgBalance
            ElseIf sAgentName <> "" Then
                Me.lblName.Text = sAgentName & " " & sAgentMSISDN
                Me.btnConfirm.Visible = True
                Me.btnCancel.Visible = True
                Me.btnSubmit.Visible = False
                Me.txtMaxisAmount.Enabled = False
                'Me.txtDiGiAmount.Enabled = False
                'Me.txtCelcomAmount.Enabled = False
                'Me.txtBankIn.Enabled = False
                Me.DDLAgentID.Enabled = False
            Else
                Me.lblErrorMsg.Text = "invalid agent id!"
            End If


        End If


    End Sub

    Private Function CheckAgentUnderDealer(ByVal sAgentID As String, ByVal sParentAgentID As String) As Boolean

        Dim oConn As New SqlConnection
        Dim oCmd As New SqlCommand
        Dim oDR As SqlDataReader
        Dim bIsValid As Boolean = True
        Dim sSQL As String = ""
        CheckAgentUnderDealer = False

        Try
            sSQL = "SELECT AgentID FROM AgentInfo " &
                   "WHERE AgentID=@AgentID and ParentAgentID=@ParentAgentID "

            oConn = New SqlConnection()
            oConn.ConnectionString =
            ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

            oCmd = New SqlCommand
            oCmd.CommandText = sSQL
            oCmd.Connection = oConn
            oCmd.Connection.Open()

            oCmd.Parameters.Clear()
            oCmd.Parameters.Add(New SqlParameter("@AgentID", sAgentID))
            oCmd.Parameters.Add(New SqlParameter("@ParentAgentID", sParentAgentID))
            oDR = oCmd.ExecuteReader

            If (oDR.Read) Then
                CheckAgentUnderDealer = True
            End If

            oDR.Close()

        Catch ex As Exception
            CheckAgentUnderDealer = False
            lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message
        Finally
            If (Not oCmd Is Nothing) Then
                oCmd.Dispose()
                oCmd = Nothing
            End If
            If Not oConn Is Nothing Then
                If oConn.State = Data.ConnectionState.Open Then
                    oConn.Close()
                End If
                oConn.Dispose()
                oConn = Nothing
            End If
        End Try
    End Function


    Private Function GetAgentName(ByVal sAgentId As String, ByRef sAgentMSISDN As String) As String

        Dim oConn As New SqlConnection
        Dim oCmd As New SqlCommand
        Dim oDR As SqlDataReader
        Dim bIsValid As Boolean = True
        Dim sSQL As String = ""

        Try
            sSQL = "SELECT Name, HPNo FROM AgentInfo " &
                   "WHERE AgentId=@AgentId and Status=@Status "

            oConn = New SqlConnection()
            oConn.ConnectionString =
            ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

            oCmd = New SqlCommand
            oCmd.CommandText = sSQL
            oCmd.Connection = oConn
            oCmd.Connection.Open()

            oCmd.Parameters.Clear()
            oCmd.Parameters.Add(New SqlParameter("@AgentId", sAgentId))
            oCmd.Parameters.Add(New SqlParameter("@Status", STATUS_ACTIVE))
            oDR = oCmd.ExecuteReader

            If (oDR.Read) Then
                GetAgentName = oDR.Item("Name")
                sAgentMSISDN = oDR.Item("HPNo")
            Else
                GetAgentName = ""
            End If

            oDR.Close()


        Catch ex As Exception
            GetAgentName = ""
            lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message
        Finally
            If (Not oCmd Is Nothing) Then
                oCmd.Dispose()
                oCmd = Nothing
            End If
            If Not oConn Is Nothing Then
                If oConn.State = Data.ConnectionState.Open Then
                    oConn.Close()
                End If
                oConn.Dispose()
                oConn = Nothing
            End If
        End Try
    End Function

    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click

        Dim sMTMSG As String = ""
        Dim sMTMSG2 As String = ""
        Dim sCom As New Common

        If ProcessTopup(Me.DDLAgentID.SelectedValue, Me.txtMaxisAmount.Text) Then
            Call ProcessTopup(Session("DEALER_ID"), "-" & txtMaxisAmount.Text)
            Call LogAgentTopupTx(Session("DEALER_ID"), "-" & txtMaxisAmount.Text, "0", "Transfer to agentid " & DDLAgentID.SelectedValue & " via Web", "TRANSFERRED")
            If LogAgentTopupTx(Me.DDLAgentID.SelectedValue, Me.txtMaxisAmount.Text, "0", "Receive from agentid " & Session("DEALER_ID") & " via web. " & txtRemarks.Text, "RECEIVED") Then
                Me.lblErrorMsg.Text = "Topup $" & txtMaxisAmount.Text & " to AgentID: " & DDLAgentID.SelectedValue & " Success!"
                Me.btnConfirm.Visible = False
                Me.btnCancel.Visible = False
                Me.btnSubmit.Visible = True
                Me.txtMaxisAmount.Enabled = True
                'Me.txtBankIn.Enabled = True
                Me.DDLAgentID.Enabled = True
                sMTMSG = MT_MSG.Replace("<Amount>", txtMaxisAmount.Text)
                sMTMSG = sMTMSG.Replace("<NewBalance>", "Balance:(" & getAgentBalance(DDLAgentID.SelectedValue) & ")")
                sMTMSG = sMTMSG.Replace("<DateTime>", Now())
                sCom.InsertMT(Session("TopUpMSISDN"), sMTMSG, (DDLAgentID.SelectedValue))
                Session("TopUpMSISDN") = ""
                'sMTMSG2 = MT_MSG2.Replace("<Amount>", txtMaxisAmount.Text)
                'sMTMSG2 = sMTMSG2.Replace("<NewBalance>", "Balance:(" & Session("DEALER_ID") & ")")
                'sMTMSG2 = sMTMSG2.Replace("<MSISDN>". Session("TopUpMSISDN") 
                'sMTMSG2 = sMTMSG2.Replace("<DateTime>", Now())
                'sCom.InsertMT(Session("TopUpMSISDN"), sMTMSG2, Session("DEALER_ID"))
                'Session("TopUpMSISDN") = ""

            End If
            Me.lblMyBalance.Text = getAgentBalance(Session("DEALER_ID"))

        Else
        End If

        'Dim sMTMSG As String = ""
        ''If ProcessTopup(Me.txtAgentId.Text, Me.txtMaxisAmount.Text, Me.txtDiGiAmount.Text, Me.txtCelcomAmount.Text) Then
        ''If LogAgentTopupTx(Me.txtAgentId.Text, Me.txtMaxisAmount.Text, Me.txtDiGiAmount.Text, Me.txtCelcomAmount.Text, Me.txtBankIn.Text, Me.txtRemarks.Text) Then
        'If ProcessTopup(Me.DDLAgentID.SelectedValue, Me.txtMaxisAmount.Text) Then
        '    If LogAgentTopupTx(Me.DDLAgentID.SelectedValue, Me.txtMaxisAmount.Text, "0", Me.txtRemarks.Text) Then
        '        Me.lblErrorMsg.Text = "Topup success"
        '        Me.btnConfirm.Visible = False
        '        Me.btnCancel.Visible = False
        '        Me.btnSubmit.Visible = True
        '        Me.txtMaxisAmount.Enabled = True
        '        'Me.txtCelcomAmount.Enabled = True
        '        'Me.txtDiGiAmount.Enabled = True
        '        'Me.txtBankIn.Enabled = True
        '        Me.DDLAgentID.Enabled = True

        '        sMTMSG = MT_MSG.Replace("<Amount>", txtMaxisAmount.Text)
        '        'sMTMSG = sMTMSG.Replace("<DiGi>", txtDiGiAmount.Text)
        '        'sMTMSG = sMTMSG.Replace("<Celcom>", txtCelcomAmount.Text)
        '        sMTMSG = sMTMSG.Replace("<NewBalance>", getAgentBalance(DDLAgentID.SelectedValue))
        '        sMTMSG = sMTMSG.Replace("<DateTime>", Now())

        '        InsertMT(Session("TopUpMSISDN"), sMTMSG)
        '        Session("TopUpMSISDN") = ""
        '    End If
        'Else

        'End If

    End Sub


    Private Function ProcessTopup(ByVal sAgentId As String, ByVal sTopUpAmount As String) As Boolean

        Dim oConn As New SqlConnection
        Dim oCmd As New SqlCommand
        Dim bIsValid As Boolean = True
        Dim sSQL As String = ""

        ProcessTopup = False

        Try
            'If sTelco.ToUpper = "MAXIS" Then
            'sSQL = "UPDATE AgentBalance SET MaxisBalance=MaxisBalance+@MaxisReloadAmount,DiGiBalance=DiGiBalance+@DiGiReloadAmount,CelcomBalance=CelcomBalance+@CelcomReloadAmount  WHERE AgentId=@AgentId "
            sSQL = "UPDATE AgentBalance SET Balance=Balance+@TopUpAmount WHERE AgentId=@AgentId "
            'ElseIf sTelco.ToUpper = "DIGI" Then
            'sSQL = "UPDATE AgentBalance SET DiGiBalance=DiGiBalance+@ReloadAmount WHERE AgentId=@AgentId "
            'ElseIf sTelco.ToUpper = "CELCOM" Then
            'sSQL = "UPDATE AgentBalance SET CelcomBalance=CelcomBalance+@ReloadAmount WHERE AgentId=@AgentId "
            'End If

            oConn = New SqlConnection()
            oConn.ConnectionString =
            ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

            oCmd = New SqlCommand
            oCmd.CommandText = sSQL
            oCmd.Connection = oConn
            oCmd.Connection.Open()

            oCmd.Parameters.Clear()
            oCmd.Parameters.Add(New SqlParameter("@AgentId", sAgentId))
            oCmd.Parameters.Add(New SqlParameter("@TopUpAmount", sTopUpAmount))
            'oCmd.Parameters.Add(New SqlParameter("@DiGiReloadAmount", sDiGiReloadAmount))
            'oCmd.Parameters.Add(New SqlParameter("@CelcomReloadAmount", sCelcomReloadAmount))

            oCmd.ExecuteNonQuery()

            ProcessTopup = True

        Catch ex As Exception
            ProcessTopup = False
            lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message
        Finally
            If (Not oCmd Is Nothing) Then
                oCmd.Dispose()
                oCmd = Nothing
            End If
            If Not oConn Is Nothing Then
                If oConn.State = Data.ConnectionState.Open Then
                    oConn.Close()
                End If
                oConn.Dispose()
                oConn = Nothing
            End If
        End Try
    End Function



    Private Function LogAgentTopupTx(ByVal sAgentId As String, ByVal sAmount As String, ByVal sBankIn As String, ByVal sRemarks As String, ByVal sType As String) As Boolean

        Dim oConn As New SqlConnection
        Dim oCmd As New SqlCommand
        Dim bIsValid As Boolean = True
        Dim sSQL As String = ""

        LogAgentTopupTx = False

        Try
            sSQL = "INSERT INTO AgentTopupTx (AgentId, Amount, BankIn, Remarks, Type, Status) VALUES (@AgentId, @Amount, @BankIn, @Remarks, @Type,@Status)"

            oConn = New SqlConnection()
            oConn.ConnectionString =
            ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

            oCmd = New SqlCommand
            oCmd.CommandText = sSQL
            oCmd.Connection = oConn
            oCmd.Connection.Open()

            oCmd.Parameters.Clear()
            oCmd.Parameters.Add(New SqlParameter("@AgentId", sAgentId))
            oCmd.Parameters.Add(New SqlParameter("@Amount", sAmount))
            oCmd.Parameters.Add(New SqlParameter("@BankIn", sBankIn))
            oCmd.Parameters.Add(New SqlParameter("@Remarks", sRemarks))
            oCmd.Parameters.Add(New SqlParameter("@Type", sType))
            oCmd.Parameters.Add(New SqlParameter("@Status", "SUCCESS"))

            oCmd.ExecuteNonQuery()
            LogAgentTopupTx = True


        Catch ex As Exception
            LogAgentTopupTx = False
            lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message
        Finally
            If (Not oCmd Is Nothing) Then
                oCmd.Dispose()
                oCmd = Nothing
            End If
            If Not oConn Is Nothing Then
                If oConn.State = Data.ConnectionState.Open Then
                    oConn.Close()
                End If
                oConn.Dispose()
                oConn = Nothing
            End If
        End Try
    End Function

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.btnConfirm.Visible = False
        Me.btnCancel.Visible = False
        Me.btnSubmit.Visible = True
        Me.txtMaxisAmount.Text = "0"
        'Me.txtDiGiAmount.Text = "0"
        'Me.txtCelcomAmount.Text = "0"
        'Me.txtAgentId.Text = ""
        Me.txtMaxisAmount.Enabled = True
        'Me.txtDiGiAmount.Enabled = True
        'Me.txtCelcomAmount.Enabled = True
        'Me.txtBankIn.Enabled = True
        Me.DDLAgentID.Enabled = True
        Me.lblName.Text = ""
    End Sub

    Private Function InsertMT(ByVal sMSISDN As String, ByVal sMsg As String, Optional ByVal sAgentId As String = "") As Boolean

        Dim sSQL As String = ""
        Dim oCmd As SqlCommand = Nothing
        Dim sLocalMTID As String
        Dim oConn As New SqlConnection

        InsertMT = True

        Try
            sLocalMTID = Format(Now, "yyyyMMddHHmmss") & Now.Millisecond.ToString.PadLeft(3, "0")

            oConn = New SqlConnection()
            oConn.ConnectionString =
            ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

            oCmd = New SqlCommand
            oCmd.CommandText = sSQL
            oCmd.Connection = oConn
            oCmd.Connection.Open()

            sSQL = "INSERT INTO TxOut (LocalMTID, LocalMOID, MSISDN, AgentID, MessageOut, Telco, Robin, Status) " &
                    "VALUES (@LocalMTID, @LocalMOID, @MSISDN, @AgentID, @MessageOut, @Telco, @Robin, @Status) "

            oCmd.CommandText = sSQL
            With oCmd.Parameters
                .Clear()
                .AddWithValue("@LocalMTID", sLocalMTID)
                .AddWithValue("@LocalMOID", "")
                .AddWithValue("@MSISDN", sMSISDN)
                .AddWithValue("@AgentID", sAgentId)
                .AddWithValue("@MessageOut", sMsg)
                .AddWithValue("@Telco", "")
                .AddWithValue("@Robin", "11")
                .AddWithValue("@Status", STATUS_PENDING)
            End With
            oCmd.ExecuteNonQuery()

        Catch ex As Exception
            InsertMT = False
            lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message
        Finally
            If (Not oCmd Is Nothing) Then
                oCmd.Dispose()
                oCmd = Nothing
            End If
            If Not oConn Is Nothing Then
                If oConn.State = Data.ConnectionState.Open Then
                    oConn.Close()
                End If
                oConn.Dispose()
                oConn = Nothing
            End If
        End Try

    End Function


    Private Function getAgentBalance(ByVal sAgentId As String) As String

        Dim sSQL As String = ""
        Dim oCmd As New SqlCommand
        Dim oDR As SqlDataReader = Nothing
        Dim sMaxisBalance As String = "0"
        Dim sDiGiBalance As String = "0"
        Dim sCelcomBalance As String = "0"
        Dim oConn As New SqlConnection

        Try
            getAgentBalance = "[]"

            oConn = New SqlConnection()
            oConn.ConnectionString =
            ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

            oCmd = New SqlCommand
            oCmd.CommandText = sSQL
            oCmd.Connection = oConn
            oCmd.Connection.Open()

            sSQL = "SELECT Balance FROM AgentBalance WHERE AgentId=@AgentId "

            oCmd.CommandText = sSQL
            With oCmd.Parameters
                .Clear()
                .AddWithValue("@AgentId", sAgentId)
            End With
            oDR = oCmd.ExecuteReader

            If oDR.HasRows Then
                oDR.Read()
                sMaxisBalance = (oDR.Item("Balance"))
                'sDiGiBalance = (oDR.Item("DiGiBalance"))
                'sCelcomBalance = (oDR.Item("CelcomBalance"))
            End If
            oDR.Close()

            getAgentBalance = sMaxisBalance

        Catch ex As Exception
            getAgentBalance = "Error getting balance."
            lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message
        Finally
            If (Not oCmd Is Nothing) Then
                oCmd.Dispose()
                oCmd = Nothing
            End If
            If (Not oDR Is Nothing) Then
                If (Not oDR.IsClosed) Then
                    oDR.Close()
                End If
                oDR = Nothing
            End If
            If Not oConn Is Nothing Then
                If oConn.State = Data.ConnectionState.Open Then
                    oConn.Close()
                End If
                oConn.Dispose()
                oConn = Nothing
            End If
        End Try

    End Function

End Class
