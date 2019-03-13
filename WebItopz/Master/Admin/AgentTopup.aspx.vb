Imports System.Data.Sqlclient

Partial Class Topup
    Inherits System.Web.UI.Page

    Private Const STATUS_ACTIVE = "ACTIVE"
    Dim sAgentMSISDN As String = ""
    'Private Const MT_MSG = "Your account been credited: D:[<DiGi>] M:[<Maxis>] C:[<Celcom>]. New balace: <NewBalance>. DateTime:<DateTime>."
    Private Const MT_MSG = "Your account been credited: SGD<Amount> New <NewBalance> (<Remarks>). DateTime:<DateTime>."


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("AGENT_ID") = "" Then
            Response.Redirect("~/Master/Login.aspx")
        End If
        Me.lblErrorMsg.Text = ""
    End Sub


    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click

        Dim sAgentName As String = ""
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
        Else
            sAgentName = GetAgentName(DDLAgentID.SelectedValue, sAgentMSISDN)
			sAgentBalance = getAgentBalance(DDLAgentID.SelectedValue)
			If (sAgentBalance.Replace("Balance: SGD", "") = "") Then
				sAgBalance = 0
			Else
				sAgBalance = sAgentBalance.Replace("Balance: SGD", "")
			End If

			Session("TopUpMSISDN") = sAgentMSISDN
            sFinalBalance = Me.txtMaxisAmount.Text + sAgBalance

            If (sFinalBalance < 0) Then
                Me.lblErrorMsg.Text = "ERROR! Deduction Exceed Current Bal : $" & sAgBalance
            ElseIf sAgentName <> "" Then
                Me.lblName.Text = sAgentName & " " & sFinalBalance
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


    Private Function GetAgentName(ByVal sAgentId As String, ByRef sAgentMSISDN As String) As String

        Dim oConn As New SqlConnection
        Dim oCmd As New SqlCommand
        Dim oDR As SqlDataReader
        Dim bIsValid As Boolean = True
        Dim sSQL As String = ""

        Try
            sSQL = "SELECT Name, HPNo FROM AgentInfo " & _
                   "WHERE AgentId=@AgentId and Status=@Status "

            oConn = New SqlConnection()
            oConn.ConnectionString = _
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
        'If ProcessTopup(Me.txtAgentId.Text, Me.txtMaxisAmount.Text, Me.txtDiGiAmount.Text, Me.txtCelcomAmount.Text) Then
        'If LogAgentTopupTx(Me.txtAgentId.Text, Me.txtMaxisAmount.Text, Me.txtDiGiAmount.Text, Me.txtCelcomAmount.Text, Me.txtBankIn.Text, Me.txtRemarks.Text) Then

        If ProcessTopup(Me.DDLAgentID.SelectedValue, Me.txtMaxisAmount.Text) Then
            If LogAgentTopupTx(Me.DDLAgentID.SelectedValue, Me.txtMaxisAmount.Text, "0", Me.txtRemarks.Text) Then
                Me.lblErrorMsg.Text = "Topup success"
                Me.btnConfirm.Visible = False
                Me.btnCancel.Visible = False
                Me.btnSubmit.Visible = True
                Me.txtMaxisAmount.Enabled = True
                'Me.txtCelcomAmount.Enabled = True
                'Me.txtDiGiAmount.Enabled = True
                'Me.txtBankIn.Enabled = True
                Me.DDLAgentID.Enabled = True

                sMTMSG = MT_MSG.Replace("<Amount>", txtMaxisAmount.Text)
                'sMTMSG = sMTMSG.Replace("<DiGi>", txtDiGiAmount.Text)
                'sMTMSG = sMTMSG.Replace("<Celcom>", txtCelcomAmount.Text)
                sMTMSG = sMTMSG.Replace("<NewBalance>", getAgentBalance(DDLAgentID.SelectedValue))
                sMTMSG = sMTMSG.Replace("<DateTime>", Now())
		sMTMSG = sMTMSG.Replace("<Remarks>", txtRemarks.Text)

                InsertMT(Session("TopUpMSISDN"), sMTMSG)
                Session("TopUpMSISDN") = ""
            End If
        Else

        End If

    End Sub


    Private Function ProcessTopup(ByVal sAgentId As String, ByVal sMaxisReloadAmount As String) As Boolean

        Dim oConn As New SqlConnection
        Dim oCmd As New SqlCommand
        Dim bIsValid As Boolean = True
        Dim sSQL As String = ""

        ProcessTopup = False

        Try
            'If sTelco.ToUpper = "MAXIS" Then
            'sSQL = "UPDATE AgentBalance SET MaxisBalance=MaxisBalance+@MaxisReloadAmount,DiGiBalance=DiGiBalance+@DiGiReloadAmount,CelcomBalance=CelcomBalance+@CelcomReloadAmount  WHERE AgentId=@AgentId "
            sSQL = "UPDATE AgentBalance SET Balance=Balance+@MaxisReloadAmount WHERE AgentId=@AgentId "
            'ElseIf sTelco.ToUpper = "DIGI" Then
            'sSQL = "UPDATE AgentBalance SET DiGiBalance=DiGiBalance+@ReloadAmount WHERE AgentId=@AgentId "
            'ElseIf sTelco.ToUpper = "CELCOM" Then
            'sSQL = "UPDATE AgentBalance SET CelcomBalance=CelcomBalance+@ReloadAmount WHERE AgentId=@AgentId "
            'End If

            oConn = New SqlConnection()
            oConn.ConnectionString = _
            ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

            oCmd = New SqlCommand
            oCmd.CommandText = sSQL
            oCmd.Connection = oConn
            oCmd.Connection.Open()

            oCmd.Parameters.Clear()
            oCmd.Parameters.Add(New SqlParameter("@AgentId", sAgentId))
            oCmd.Parameters.Add(New SqlParameter("@MaxisReloadAmount", sMaxisReloadAmount))
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


    Private Function LogAgentTopupTx(ByVal sAgentId As String, ByVal sMaxisAmount As String, ByVal sBankIn As String, ByVal sRemarks As String) As Boolean

        Dim oConn As New SqlConnection
        Dim oCmd As New SqlCommand
        Dim bIsValid As Boolean = True
        Dim sSQL As String = ""

        LogAgentTopupTx = False

        Try
            sSQL = "INSERT INTO AgentTopupTx (AgentId, Amount, BankIn, Remarks, Status) VALUES (@AgentId, @MaxisAmount, @BankIn, @Remarks, @Status)"


            oConn = New SqlConnection()
            oConn.ConnectionString = _
            ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

            oCmd = New SqlCommand
            oCmd.CommandText = sSQL
            oCmd.Connection = oConn
            oCmd.Connection.Open()

            oCmd.Parameters.Clear()
            oCmd.Parameters.Add(New SqlParameter("@AgentId", sAgentId))
            oCmd.Parameters.Add(New SqlParameter("@MaxisAmount", sMaxisAmount))
            'oCmd.Parameters.Add(New SqlParameter("@DiGiAmount", sDiGiAmount))
            'oCmd.Parameters.Add(New SqlParameter("@CelcomAmount", sCelcomAmount))
            oCmd.Parameters.Add(New SqlParameter("@BankIn", sBankIn))
            oCmd.Parameters.Add(New SqlParameter("@Remarks", sRemarks))
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
            oConn.ConnectionString = _
            ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

            oCmd = New SqlCommand
            oCmd.CommandText = sSQL
            oCmd.Connection = oConn
            oCmd.Connection.Open()

            sSQL = "INSERT INTO TxOut (LocalMTID, LocalMOID, MSISDN, AgentID, MessageOut, Telco, Robin, Status) " & _
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
                .AddWithValue("@Robin", "1")
                .AddWithValue("@Status", "PENDING")
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
            oConn.ConnectionString = _
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

            getAgentBalance = "Balance: SGD" & sMaxisBalance & ""

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
