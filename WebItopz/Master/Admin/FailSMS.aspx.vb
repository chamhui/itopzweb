Imports System.Data.SqlClient
Imports WebItopz.CommonItop
Partial Class Admin_FailSMS
    Inherits System.Web.UI.Page
    Private Const STATUS_SUCCESS = "SUCCESS"
    Private Const STATUS_REFUNDED = "REFUNDED"
    Private Const MT_MSG = "Your account been credited: [<Amount>]. Remarks: <Remarks>. DateTime:<DateTime>."

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim bWorking As Boolean = False
        Dim oCommon As New Common

        If Session("AGENT_ID") = "" Then
            Response.Redirect("~/Master/Login.aspx")
        End If

        Me.lblErrorMsg.Text = ""

        Dim sID As String = ""

        sID = Request.QueryString("id")

        If sID <> "" Then
            If Session("sID") = "" Then
                Session("sID") = sID
                bWorking = True
            Else
                If Session("sID") <> sID Then
                    Session("sID") = sID
                    bWorking = True
                End If
            End If

            If bWorking Then
                If Request("action").ToUpper = "ResentMT" Then
                    If oCommon.ResentMT(sID) Then
                        Me.lblErrorMsg.Text = "Redoing"
                    Else
                        ' Me.lblErrorMsg.Text = "Redoing Error!!!"
                    End If

                End If
                End If
            End If


    End Sub

    'Private Function Redo(ByVal sLocalMOID As String) As Boolean

    '    Dim oConn As New SqlConnection
    '    Dim oCmd As New SqlCommand
    '    Dim bIsValid As Boolean = True
    '    Dim sSQL As String = ""

    '    Try
    '        Redo = False
    '        If DeductSIMBalance(sLocalMOID) Then
    '            sSQL = "UPDATE TxIn SET retry = 0, Status='PENDING', SIMBalanceDeducted='NO' " & _
    '                   "WHERE LocalMOID=@LocalMOID "
    '        Else
    '            sSQL = "UPDATE TxIn SET retry = 0, Status='PENDING'  " & _
    '                   "WHERE LocalMOID=@LocalMOID "
    '        End If


    '        oConn = New SqlConnection()
    '        oConn.ConnectionString = _
    '        ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

    '        oCmd = New SqlCommand
    '        oCmd.CommandText = sSQL
    '        oCmd.Connection = oConn
    '        oCmd.Connection.Open()

    '        oCmd.Parameters.Clear()
    '        oCmd.Parameters.Add(New SqlParameter("@LocalMOID", sLocalMOID))
    '        oCmd.ExecuteNonQuery()

    '        Redo = True

    '    Catch ex As Exception
    '        Redo = False
    '        lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message
    '    Finally
    '        If (Not oCmd Is Nothing) Then
    '            oCmd.Dispose()
    '            oCmd = Nothing
    '        End If
    '        If Not oConn Is Nothing Then
    '            If oConn.State = Data.ConnectionState.Open Then
    '                oConn.Close()
    '            End If
    '            oConn.Dispose()
    '            oConn = Nothing
    '        End If
    '    End Try
    'End Function

    'Private Function Refund(ByVal sLocalMOID As String) As Boolean

    '    Dim oConn As New SqlConnection
    '    Dim oCmd As New SqlCommand
    '    Dim bIsValid As Boolean = True
    '    Dim sSQL As String = ""

    '    Try
    '        Refund = False
    '        sSQL = "UPDATE TxIn SET Status='REFUNDED'  " & _
    '               "WHERE LocalMOID=@LocalMOID "

    '        oConn = New SqlConnection()
    '        oConn.ConnectionString = _
    '        ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

    '        oCmd = New SqlCommand
    '        oCmd.CommandText = sSQL
    '        oCmd.Connection = oConn
    '        oCmd.Connection.Open()
    '        oCmd.Parameters.Clear()
    '        oCmd.Parameters.Add(New SqlParameter("@LocalMOID", sLocalMOID))
    '        oCmd.ExecuteNonQuery()

    '        Refund = True

    '    Catch ex As Exception
    '        Refund = False
    '        lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message
    '    Finally
    '        If (Not oCmd Is Nothing) Then
    '            oCmd.Dispose()
    '            oCmd = Nothing
    '        End If
    '        If Not oConn Is Nothing Then
    '            If oConn.State = Data.ConnectionState.Open Then
    '                oConn.Close()
    '            End If
    '            oConn.Dispose()
    '            oConn = Nothing
    '        End If
    '    End Try
    'End Function

    'Private Function Cancel(ByVal sLocalMOID As String) As Boolean

    '    Dim oConn As New SqlConnection
    '    Dim oCmd As New SqlCommand
    '    Dim bIsValid As Boolean = True
    '    Dim sSQL As String = ""

    '    Try
    '        Cancel = False
    '        sSQL = "UPDATE TxIn SET Status='CANCELLED'  " & _
    '               "WHERE LocalMOID=@LocalMOID "

    '        oConn = New SqlConnection()
    '        oConn.ConnectionString = _
    '        ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

    '        oCmd = New SqlCommand
    '        oCmd.CommandText = sSQL
    '        oCmd.Connection = oConn
    '        oCmd.Connection.Open()
    '        oCmd.Parameters.Clear()
    '        oCmd.Parameters.Add(New SqlParameter("@LocalMOID", sLocalMOID))
    '        oCmd.ExecuteNonQuery()

    '        Cancel = True

    '    Catch ex As Exception
    '        Cancel = False
    '        lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message
    '    Finally
    '        If (Not oCmd Is Nothing) Then
    '            oCmd.Dispose()
    '            oCmd = Nothing
    '        End If
    '        If Not oConn Is Nothing Then
    '            If oConn.State = Data.ConnectionState.Open Then
    '                oConn.Close()
    '            End If
    '            oConn.Dispose()
    '            oConn = Nothing
    '        End If
    '    End Try
    'End Function

    'Private Function Success(ByVal sLocalMOID As String) As Boolean

    '    Dim oConn As New SqlConnection
    '    Dim oCmd As New SqlCommand
    '    Dim bIsValid As Boolean = True
    '    Dim sSQL As String = ""

    '    Try
    '        Success = False
    '        sSQL = "UPDATE TxIn SET Status='SUCCESS', DNReceivedID='0'  " & _
    '               "WHERE LocalMOID=@LocalMOID "

    '        oConn = New SqlConnection()
    '        oConn.ConnectionString = _
    '        ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

    '        oCmd = New SqlCommand
    '        oCmd.CommandText = sSQL
    '        oCmd.Connection = oConn
    '        oCmd.Connection.Open()
    '        oCmd.Parameters.Clear()
    '        oCmd.Parameters.Add(New SqlParameter("@LocalMOID", sLocalMOID))
    '        oCmd.ExecuteNonQuery()

    '        Success = True

    '    Catch ex As Exception
    '        Success = False
    '        lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message
    '    Finally
    '        If (Not oCmd Is Nothing) Then
    '            oCmd.Dispose()
    '            oCmd = Nothing
    '        End If
    '        If Not oConn Is Nothing Then
    '            If oConn.State = Data.ConnectionState.Open Then
    '                oConn.Close()
    '            End If
    '            oConn.Dispose()
    '            oConn = Nothing
    '        End If
    '    End Try
    'End Function

    'Private Function RefundToAgent(ByVal sLocalMOID As String) As Boolean

    '    Dim oConn As New SqlConnection
    '    Dim oCmd As New SqlCommand
    '    Dim oCmdUpdate As New SqlCommand
    '    Dim bIsValid As Boolean = True
    '    Dim sSQL As String = ""
    '    Dim oDR As SqlDataReader

    '    Dim sAgentId As String
    '    Dim sReloadMSISDN As String
    '    Dim sReloadAmount As Decimal
    '    Dim sReloadTelco As String


    '    Dim sDisSingTel As Decimal 
    '    Dim sDisM1 As Decimal
    '    Dim sNewReloadAmount As Decimal

    '    Dim sMT_MSG As String = MT_MSG
    '    Dim sSQLUpdate As String = ""
    '    Dim sMSISDN As String

    '    Try
    '        'sSQL = "SELECT * FROM TxIn WHERE LocalMOID=@LocalMOID"

    '        sSQL = "SELECT t.MSISDN, t.AgentId,t.ReloadMSISDN,t.ReloadAmount,t.ReloadTelco,i.DiscountSingTel as DisSingTel, i.DiscountM1 as DisM1  FROM TxIn t, AgentInfo i WHERE t.LocalMOID=@LocalMOID and t.agentid=i.agentid"

    '        oConn = New SqlConnection()
    '        oConn.ConnectionString = _
    '        ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

    '        oCmd = New SqlCommand
    '        oCmd.CommandText = sSQL
    '        oCmd.Connection = oConn
    '        oCmd.Connection.Open()

    '        oCmd.Parameters.Clear()
    '        oCmd.Parameters.Add(New SqlParameter("@LocalMOID", sLocalMOID))
    '        oDR = oCmd.ExecuteReader

    '        If oDR.Read Then
    '            sMSISDN = oDR.Item("MSISDN")
    '            sAgentId = oDR.Item("AgentId")
    '            sReloadMSISDN = oDR.Item("ReloadMSISDN")
    '            sReloadAmount = oDR.Item("ReloadAmount")
    '            sReloadTelco = oDR.Item("ReloadTelco")
    '            sDisSingTel = oDR.Item("DisSingTel")
    '            sDisM1 = oDR.Item("DisM1")
    '            oDR.Close()

    '            If sReloadTelco = "SINGTEL" Then
    '                sNewReloadAmount = sReloadAmount - (sReloadAmount * sDisSingTel / 100)
    '                sSQL = "UPDATE AgentBalance SET Balance=Balance+@Amount WHERE AgentId=@AgentId "
    '            ElseIf sReloadTelco = "M1" Then
    '                sNewReloadAmount = sReloadAmount - (sReloadAmount * sDisM1 / 100)
    '                sSQL = "UPDATE AgentBalance SET Balance=Balance+@Amount WHERE AgentId=@AgentId "
    '              End If

    '            oCmdUpdate = New SqlCommand
    '            oCmdUpdate.CommandText = sSQL
    '            oCmdUpdate.Connection = oConn
    '            oCmdUpdate.Parameters.Clear()
    '            oCmdUpdate.Parameters.Add(New SqlParameter("@Amount", sNewReloadAmount))
    '            oCmdUpdate.Parameters.Add(New SqlParameter("@AgentId", sAgentId))
    '            oCmdUpdate.ExecuteNonQuery()
    '            oCmdUpdate = Nothing

    '            sSQLUpdate = "INSERT INTO AgentTopupTx (AgentID,Amount,Remarks,STATUS,Type) VALUES (@sAgentId,@sNewReloadAmount,@sRemarks,@sStatus,@sType)"
    '            oCmdUpdate = New SqlCommand
    '            oCmdUpdate.CommandText = sSQLUpdate
    '            oCmdUpdate.Connection = oConn
    '            With oCmdUpdate.Parameters
    '                .Clear()
    '                .AddWithValue("@sAgentId", sAgentId)
    '                .AddWithValue("@sNewReloadAmount", sNewReloadAmount)
    '                .AddWithValue("@sRemarks", sReloadMSISDN)
    '                .AddWithValue("@sStatus", STATUS_SUCCESS)
    '                .AddWithValue("@sType", STATUS_REFUNDED)
    '            End With
    '            oCmdUpdate.ExecuteNonQuery()
    '            oCmdUpdate = Nothing


    '            'Private Const MT_MSG = "Your account been credited: [<Amount>] New balace: <NewBalance>. Remarks: <Remarks> DateTime:<DateTime>."
    '            sMT_MSG = sMT_MSG.Replace("<Amount>", sNewReloadAmount)
    '            sMT_MSG = sMT_MSG.Replace("<Remarks>", "Refund to (" + sReloadMSISDN + ")")
    '            sMT_MSG = sMT_MSG.Replace("<DateTime>", Now())
    '            InsertMT(sMSISDN, sMT_MSG, sAgentId)

    '        End If

    '        RefundToAgent = True
    '        ' oDR.Close()

    '    Catch ex As Exception
    '        RefundToAgent = False
    '        Response.Write(ex.Message & "  " & ex.StackTrace)
    '        lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message
    '    Finally
    '        If (Not oCmd Is Nothing) Then
    '            oCmd.Dispose()
    '            oCmd = Nothing
    '        End If
    '        If Not oConn Is Nothing Then
    '            If oConn.State = Data.ConnectionState.Open Then
    '                oConn.Close()
    '            End If
    '            oConn.Dispose()
    '            oConn = Nothing
    '        End If
    '    End Try
    'End Function


    'Private Function DeductSIMBalance(ByVal sLocalMOID As String) As Boolean

    '    Dim oConn As New SqlConnection
    '    Dim oCmd As New SqlCommand
    '    Dim oDR As SqlDataReader
    '    Dim bIsValid As Boolean = True
    '    Dim sSQL As String = ""

    '    Try
    '        DeductSIMBalance = False
    '        sSQL = "SELECT DNReceivedID FROM TxIn WHERE (DNReceivedID<>'' and DNReceivedID<>'0') AND LocalMOID=@LocalMOID "

    '        oConn = New SqlConnection()
    '        oConn.ConnectionString = _
    '        ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

    '        oCmd = New SqlCommand
    '        oCmd.CommandText = sSQL
    '        oCmd.Connection = oConn
    '        oCmd.Connection.Open()

    '        oCmd.Parameters.Clear()
    '        oCmd.Parameters.Add(New SqlParameter("@LocalMOID", sLocalMOID))
    '        oDR = oCmd.ExecuteReader
    '        If oDR.HasRows Then
    '            DeductSIMBalance = True
    '        End If

    '    Catch ex As Exception
    '        DeductSIMBalance = False
    '        lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message
    '    Finally
    '        If (Not oCmd Is Nothing) Then
    '            oCmd.Dispose()
    '            oCmd = Nothing
    '        End If
    '        If Not oConn Is Nothing Then
    '            If oConn.State = Data.ConnectionState.Open Then
    '                oConn.Close()
    '            End If
    '            oConn.Dispose()
    '            oConn = Nothing
    '        End If
    '    End Try
    'End Function

    'Private Function InsertMT(ByVal sMSISDN As String, ByVal sMsg As String, Optional ByVal sAgentId As String = "") As Boolean

    '    Dim sSQL As String = ""
    '    Dim oCmd As SqlCommand = Nothing
    '    Dim sLocalMTID As String
    '    Dim oConn As New SqlConnection

    '    InsertMT = True

    '    Try
    '        sLocalMTID = Format(Now, "yyyyMMddHHmmss") & Now.Millisecond.ToString.PadLeft(3, "0")

    '        oConn = New SqlConnection()
    '        oConn.ConnectionString = _
    '        ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

    '        oCmd = New SqlCommand
    '        oCmd.CommandText = sSQL
    '        oCmd.Connection = oConn
    '        oCmd.Connection.Open()

    '        sSQL = "INSERT INTO TxOut (LocalMTID, LocalMOID, MSISDN, AgentID, MessageOut, Telco, Robin, Status) " & _
    '                "VALUES (@LocalMTID, @LocalMOID, @MSISDN, @AgentID, @MessageOut, @Telco, @Robin, @Status) "

    '        oCmd.CommandText = sSQL
    '        With oCmd.Parameters
    '            .Clear()
    '            .AddWithValue("@LocalMTID", sLocalMTID)
    '            .AddWithValue("@LocalMOID", "")
    '            .AddWithValue("@MSISDN", sMSISDN)
    '            .AddWithValue("@AgentID", sAgentId)
    '            .AddWithValue("@MessageOut", sMsg)
    '            .AddWithValue("@Telco", "")
    '            .AddWithValue("@Robin", "1")
    '            .AddWithValue("@Status", "PENDING")
    '        End With
    '        oCmd.ExecuteNonQuery()

    '    Catch ex As Exception
    '        InsertMT = False
    '        lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message
    '    Finally
    '        If (Not oCmd Is Nothing) Then
    '            oCmd.Dispose()
    '            oCmd = Nothing
    '        End If
    '        If Not oConn Is Nothing Then
    '            If oConn.State = Data.ConnectionState.Open Then
    '                oConn.Close()
    '            End If
    '            oConn.Dispose()
    '            oConn = Nothing
    '        End If
    '    End Try

    'End Function

End Class
