Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace CommonItopDealer
    Public Class Common

        Private Const STATUS_SUCCESS = "SUCCESS"
        Private Const STATUS_REFUNDED = "REFUNDED"
        Private Const MT_MSG = "Your account been credited: SGD<Amount>. Remarks:<Remarks>. DateTime:<DateTime>."

        Public Function Redo(ByVal sLocalMOID As String) As Boolean

            Dim oConn As New SqlConnection
            Dim oCmd As New SqlCommand
            Dim bIsValid As Boolean = True
            Dim sSQL As String = ""

            Try
                Redo = False
                If DeductSIMBalance(sLocalMOID) Then
                    sSQL = "UPDATE TxIn SET retry = 0, Status='PENDING', SIMBalanceDeducted='NO', DNReceivedID='' " &
                       "WHERE LocalMOID=@LocalMOID "
                Else
                    sSQL = "UPDATE TxIn SET retry = 0, Status='PENDING', DNReceivedID=''  " &
                       "WHERE LocalMOID=@LocalMOID "
                End If


                oConn = New SqlConnection()
                oConn.ConnectionString =
            ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

                oCmd = New SqlCommand
                oCmd.CommandText = sSQL
                oCmd.Connection = oConn
                oCmd.Connection.Open()

                oCmd.Parameters.Clear()
                oCmd.Parameters.Add(New SqlParameter("@LocalMOID", sLocalMOID))
                oCmd.ExecuteNonQuery()

                Redo = True

            Catch ex As Exception
                Redo = False
                'lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message
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

        Public Function Refund(ByVal sLocalMOID As String) As Boolean

            Dim oConn As New SqlConnection
            Dim oCmd As New SqlCommand
            Dim bIsValid As Boolean = True
            Dim sSQL As String = ""

            Try
                Refund = False
                sSQL = "UPDATE TxIn SET Status='REFUNDED'  " &
                   "WHERE LocalMOID=@LocalMOID "

                oConn = New SqlConnection()
                oConn.ConnectionString =
            ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

                oCmd = New SqlCommand
                oCmd.CommandText = sSQL
                oCmd.Connection = oConn
                oCmd.Connection.Open()
                oCmd.Parameters.Clear()
                oCmd.Parameters.Add(New SqlParameter("@LocalMOID", sLocalMOID))
                oCmd.ExecuteNonQuery()

                Refund = True

            Catch ex As Exception
                Refund = False
                'lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message
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

        Public Function Cancel(ByVal sLocalMOID As String) As Boolean

            Dim oConn As New SqlConnection
            Dim oCmd As New SqlCommand
            Dim bIsValid As Boolean = True
            Dim sSQL As String = ""

            Try
                Cancel = False
                sSQL = "UPDATE TxIn SET Status='CANCELLED'  " &
                   "WHERE LocalMOID=@LocalMOID "

                oConn = New SqlConnection()
                oConn.ConnectionString =
            ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

                oCmd = New SqlCommand
                oCmd.CommandText = sSQL
                oCmd.Connection = oConn
                oCmd.Connection.Open()
                oCmd.Parameters.Clear()
                oCmd.Parameters.Add(New SqlParameter("@LocalMOID", sLocalMOID))
                oCmd.ExecuteNonQuery()

                Cancel = True

            Catch ex As Exception
                Cancel = False
                'lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message
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


        Public Function Success(ByVal sLocalMOID As String) As Boolean

            Dim oConn As New SqlConnection
            Dim oCmd As New SqlCommand
            Dim bIsValid As Boolean = True
            Dim sSQL As String = ""

            Try
                Success = False
                sSQL = "UPDATE TxIn SET Status='SUCCESS', DNReceivedID='0'  " &
                   "WHERE LocalMOID=@LocalMOID "

                oConn = New SqlConnection()
                oConn.ConnectionString =
            ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

                oCmd = New SqlCommand
                oCmd.CommandText = sSQL
                oCmd.Connection = oConn
                oCmd.Connection.Open()
                oCmd.Parameters.Clear()
                oCmd.Parameters.Add(New SqlParameter("@LocalMOID", sLocalMOID))
                oCmd.ExecuteNonQuery()

                Success = True

            Catch ex As Exception
                Success = False
                'lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message
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

        Public Function DeductSIMBalance(ByVal sLocalMOID As String) As Boolean

            Dim oConn As New SqlConnection
            Dim oCmd As New SqlCommand
            Dim oDR As SqlDataReader
            Dim bIsValid As Boolean = True
            Dim sSQL As String = ""

            Try
                DeductSIMBalance = False
                sSQL = "SELECT DNReceivedID FROM TxIn WHERE (DNReceivedID<>'' and DNReceivedID<>'0') AND LocalMOID=@LocalMOID "

                oConn = New SqlConnection()
                oConn.ConnectionString =
            ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

                oCmd = New SqlCommand
                oCmd.CommandText = sSQL
                oCmd.Connection = oConn
                oCmd.Connection.Open()

                oCmd.Parameters.Clear()
                oCmd.Parameters.Add(New SqlParameter("@LocalMOID", sLocalMOID))
                oDR = oCmd.ExecuteReader
                If oDR.HasRows Then
                    DeductSIMBalance = True
                End If

            Catch ex As Exception
                DeductSIMBalance = False
                'lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message
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

        Public Function RefundToAgent(ByVal sLocalMOID As String) As Boolean

            Dim oConn As New SqlConnection
            Dim oCmd As New SqlCommand
            Dim oCmdUpdate As New SqlCommand
            Dim bIsValid As Boolean = True
            Dim sSQL As String = ""
            Dim oDR As SqlDataReader

            Dim sAgentId As String
            Dim sReloadMSISDN As String
            Dim sReloadAmount As Decimal
            Dim sReloadTelco As String


            Dim sDiscount As Decimal
            Dim sNewReloadAmount As Decimal

            Dim sMT_MSG As String = MT_MSG
            Dim sSQLUpdate As String = ""
            Dim sMSISDN As String

            Try
                'sSQL = "SELECT * FROM TxIn WHERE LocalMOID=@LocalMOID"
                'sSQL = "SELECT t.MSISDN, t.AgentId,t.ReloadMSISDN,t.ReloadAmount,t.ReloadTelco,i.DiscountMaxis as DisMaxis, i.DiscountDiGi as DisDiGi, i.DiscountCelcom as DisCelcom  FROM TxIn t, AgentInfo i WHERE t.LocalMOID=@LocalMOID and t.agentid=i.agentid"

                sSQL = "SELECT dbo.TxIn.MSISDN, dbo.TxIn.AgentID, dbo.TxIn.ReloadMSISDN, dbo.TxIn.ReloadAmount, dbo.TxIn.ReloadTelco, dbo.AgentProduct.Discount " &
                    "FROM dbo.AgentProduct INNER JOIN " &
                    "dbo.TxIn ON dbo.AgentProduct.AgentID = dbo.TxIn.AgentID INNER JOIN " &
                    "dbo.ProductInfo ON dbo.TxIn.ReloadTelco = dbo.ProductInfo.Telco AND dbo.AgentProduct.ProductID = dbo.ProductInfo.ProductID " &
                    "WHERE  (dbo.TxIn.LocalMOID = @LocalMOID)"

                oConn = New SqlConnection()
                oConn.ConnectionString =
            ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

                oCmd = New SqlCommand
                oCmd.CommandText = sSQL
                oCmd.Connection = oConn
                oCmd.Connection.Open()

                oCmd.Parameters.Clear()
                oCmd.Parameters.Add(New SqlParameter("@LocalMOID", sLocalMOID))
                oDR = oCmd.ExecuteReader

                If oDR.Read Then
                    sMSISDN = oDR.Item("MSISDN")
                    sAgentId = oDR.Item("AgentId")
                    sReloadMSISDN = oDR.Item("ReloadMSISDN")
                    sReloadAmount = oDR.Item("ReloadAmount")
                    sReloadTelco = oDR.Item("ReloadTelco")
                    sDiscount = oDR.Item("Discount")
                    oDR.Close()

                    sNewReloadAmount = sReloadAmount - (sReloadAmount * sDiscount / 100)
                    sSQL = "UPDATE AgentBalance SET Balance=Balance+@Amount WHERE AgentId=@AgentId "

                    oCmdUpdate = New SqlCommand
                    oCmdUpdate.CommandText = sSQL
                    oCmdUpdate.Connection = oConn
                    oCmdUpdate.Parameters.Clear()
                    oCmdUpdate.Parameters.Add(New SqlParameter("@Amount", sNewReloadAmount))
                    oCmdUpdate.Parameters.Add(New SqlParameter("@AgentId", sAgentId))
                    oCmdUpdate.ExecuteNonQuery()
                    oCmdUpdate = Nothing

                    sSQLUpdate = "INSERT INTO AgentTopupTx (AgentID,Amount,Remarks,STATUS,Type) VALUES (@sAgentId,@sNewReloadAmount,@sRemarks,@sStatus,@sType)"
                    oCmdUpdate = New SqlCommand
                    oCmdUpdate.CommandText = sSQLUpdate
                    oCmdUpdate.Connection = oConn
                    With oCmdUpdate.Parameters
                        .Clear()
                        .AddWithValue("@sAgentId", sAgentId)
                        .AddWithValue("@sNewReloadAmount", sNewReloadAmount)
                        .AddWithValue("@sRemarks", sReloadMSISDN)
                        .AddWithValue("@sStatus", STATUS_SUCCESS)
                        .AddWithValue("@sType", STATUS_REFUNDED)
                    End With
                    oCmdUpdate.ExecuteNonQuery()
                    oCmdUpdate = Nothing

                    'Private Const MT_MSG = "Your account been credited: [<Amount>] New balace: <NewBalance>. Remarks: <Remarks> DateTime:<DateTime>."
                    sMT_MSG = sMT_MSG.Replace("<Amount>", sNewReloadAmount)
                    sMT_MSG = sMT_MSG.Replace("<Remarks>", "Refund to (" + sReloadMSISDN + ")")
                    sMT_MSG = sMT_MSG.Replace("<DateTime>", Now())
                    InsertMT(sMSISDN, sMT_MSG, sAgentId)

                End If

                RefundToAgent = True
                ' oDR.Close()

            Catch ex As Exception
                RefundToAgent = False
                'Response.Write(ex.Message & "  " & ex.StackTrace)
                'lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message
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


        Public Function InsertMT(ByVal sMSISDN As String, ByVal sMsg As String, Optional ByVal sAgentId As String = "") As Boolean

            Dim sSQL As String = ""
            Dim oCmd As SqlCommand = Nothing
            Dim sLocalMTID As String
            Dim oConn As New SqlConnection
            Dim sRobin As String = "1"

            InsertMT = True

            Try
                sLocalMTID = Format(Now, "yyyyMMddHHmmss") & Now.Millisecond.ToString.PadLeft(3, "0")

                sRobin = getMORobin(sMSISDN)

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
                    .AddWithValue("@Robin", sRobin)
                    .AddWithValue("@Status", "PENDING")
                End With
                oCmd.ExecuteNonQuery()

            Catch ex As Exception
                InsertMT = False
                'lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message
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

        Private Function getMORobin(ByVal sMSISDN As String) As String

            Dim sSQL As String = ""
            Dim oConn As New SqlConnection(ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString)
            Dim oCmd As New SqlCommand
            Dim oDR As SqlDataReader = Nothing
            getMORobin = 1

            Try
                oConn.Open()
                oCmd = oConn.CreateCommand
                oCmd.Connection = oConn
                sSQL = "SELECT TOP 1 ProcessorID FROM TxIn WHERE MSISDN=@MSISDN ORDER by createdts desc"
                oCmd.CommandText = sSQL

                With oCmd.Parameters
                    .Clear()
                    .AddWithValue("@MSISDN", sMSISDN)
                End With
                oDR = oCmd.ExecuteReader
                If oDR.Read Then
                    getMORobin = oDR.Item("ProcessorID").ToString.Replace("MOP", "")
                End If
                oConn.Close()

            Catch ex As Exception
                'Response.Write("getRobin [" & ex.Message & "]" & ex.StackTrace)
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
                If (Not oConn Is Nothing) Then
                    If oConn.State = ConnectionState.Open Then
                        oConn.Close()
                    End If
                    oConn.Dispose()
                    oConn = Nothing
                End If
            End Try

        End Function

        Public Function VerifyChild(ByVal sDealerID As String, ByVal sAgentID As String) As Boolean

            Dim oConn As New SqlConnection
            Dim oCmd As New SqlCommand
            Dim oDR As SqlDataReader
            Dim sSQL As String = ""
            VerifyChild = False

            Try

                oConn = New SqlConnection()
                oConn.ConnectionString =
            ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

                oCmd = New SqlCommand
                oCmd.CommandText = sSQL
                oCmd.Connection = oConn
                oCmd.Connection.Open()

                sSQL = "SELECT AgentID FROM AgentInfo WHERE AgentId=@AgentId and ParentAgentID=@DealerID "

                oCmd.CommandText = sSQL
                With oCmd.Parameters
                    .Clear()
                    .AddWithValue("@AgentId", sAgentID)
                    .AddWithValue("@DealerID", sDealerID)
                End With
                oDR = oCmd.ExecuteReader

                If oDR.Read Then
                    VerifyChild = True
                End If
                oDR.Close()

            Catch ex As Exception
                VerifyChild = False
                'Response.Write(ex.Message & ex.StackTrace)
                'lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message
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


    End Class
End Namespace
