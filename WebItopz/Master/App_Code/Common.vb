Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace CommonItop
	Public Class Common

		Private Const STATUS_SUCCESS = "SUCCESS"
		Private Const STATUS_REFUNDED = "REFUNDED"
		Private Const MT_MSG = "Your account been credited: SGD<Amount>. Remarks:<Remarks>. DateTime:<DateTime>."
		Private Const MT_MSG2 = "Success! <ReloadTelco> Top up: <Remarks> <Amount> (Successful!) Your BAL: SGD<Balance>"


		Public Function Redo(ByVal sLocalMOID As String) As Boolean

			Dim oConn As New SqlConnection
			Dim oCmd As New SqlCommand
			Dim bIsValid As Boolean = True
			Dim sSQL As String = ""

			Try
				Redo = False
				If DeductSIMBalance(sLocalMOID) Then
					sSQL = "UPDATE TxIn SET retry = 0, Status='PENDING', SIMBalanceDeducted='NO', DNReceivedID='' " & _
											 "WHERE LocalMOID=@LocalMOID "
				Else
					sSQL = "UPDATE TxIn SET retry = 0, Status='PENDING', DNReceivedID=''  " & _
											 "WHERE LocalMOID=@LocalMOID "
				End If


				oConn = New SqlConnection()
				oConn.ConnectionString = _
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
		Public Function ResentMT(ByVal smID As String) As Boolean

			Dim oConn As New SqlConnection
			Dim oCmd As New SqlCommand
			Dim bIsValid As Boolean = True
			Dim sSQL As String = ""

			Try
				ResentMT = False
				sSQL = "UPDATE TxOut SET Retry='0', Robin='1' " & _
										"WHERE ID=@ID "

				oConn = New SqlConnection()
				oConn.ConnectionString = _
						ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

				oCmd = New SqlCommand
				oCmd.CommandText = sSQL
				oCmd.Connection = oConn
				oCmd.Connection.Open()

				oCmd.Parameters.Clear()
				oCmd.Parameters.Add(New SqlParameter("@ID", smID))
				oCmd.ExecuteNonQuery()

				ResentMT = True

			Catch ex As Exception
				ResentMT = False
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
		Public Function Retry(ByVal sID As String) As Boolean

			Dim oConn As New SqlConnection
			Dim oCmd As New SqlCommand
			Dim bIsValid As Boolean = True
			Dim sSQL As String = ""

			Try
				Retry = False
				sSQL = "UPDATE TxActivation SET Status='PENDING' " & _
										"WHERE ID=@ID "

				oConn = New SqlConnection()
				oConn.ConnectionString = _
						ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

				oCmd = New SqlCommand
				oCmd.CommandText = sSQL
				oCmd.Connection = oConn
				oCmd.Connection.Open()

				oCmd.Parameters.Clear()
				oCmd.Parameters.Add(New SqlParameter("@ID", sID))
				oCmd.ExecuteNonQuery()

				Retry = True

			Catch ex As Exception
				Retry = False
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
		Public Function DeleteMT(ByVal sID As String) As Boolean

			Dim oConn As New SqlConnection
			Dim oCmd As New SqlCommand
			Dim bIsValid As Boolean = True
			Dim sSQL As String = ""

			Try
				DeleteMT = False
				sSQL = "DELETE FROM TxOut " & _
										" WHERE ID=@ID"

				oConn = New SqlConnection()
				oConn.ConnectionString = _
						ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

				oCmd = New SqlCommand
				oCmd.CommandText = sSQL
				oCmd.Connection = oConn
				oCmd.Connection.Open()

				oCmd.Parameters.Clear()
				oCmd.Parameters.Add(New SqlParameter("@ID", sID))
				oCmd.ExecuteNonQuery()

				DeleteMT = True

			Catch ex As Exception
				DeleteMT = False
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
		Public Function Resendpin(ByVal sSerialNumber As String, ByVal sMSISDN As String) As Boolean

			Dim oConn As New SqlConnection
			Dim oCmd As New SqlCommand
			Dim bIsValid As Boolean = True
			Dim sSQL As String = ""

			Try

				Resendpin = False
				sSQL = "UPDATE TxOut SET retry = '0', Status= 'PENDING', MSISDN= @MSISDN " & _
									 "WHERE MessageOut LIKE '%' + @SerialNumber + '%' "


				oConn = New SqlConnection()
				oConn.ConnectionString = _
						ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

				oCmd = New SqlCommand
				oCmd.CommandText = sSQL
				oCmd.Connection = oConn
				oCmd.Connection.Open()

				oCmd.Parameters.Clear()
				oCmd.Parameters.Add(New SqlParameter("@SerialNumber", sSerialNumber))
				oCmd.Parameters.Add(New SqlParameter("@MSISDN", sMSISDN))
				oCmd.ExecuteNonQuery()

				Resendpin = True

			Catch ex As Exception
				Resendpin = False
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
				sSQL = "UPDATE TxIn SET Status='REFUNDED'  " & _
									 "WHERE LocalMOID=@LocalMOID "

				oConn = New SqlConnection()
				oConn.ConnectionString = _
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
				sSQL = "UPDATE TxIn SET Status='CANCELLED'  " & _
									 "WHERE LocalMOID=@LocalMOID "

				oConn = New SqlConnection()
				oConn.ConnectionString = _
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
				sSQL = "UPDATE TxIn SET Status='SUCCESS', DNReceivedID= 'OK' , LastUpdatedTS = @Now  " & _
									 "WHERE LocalMOID=@LocalMOID "

				oConn = New SqlConnection()
				oConn.ConnectionString = _
						ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

				oCmd = New SqlCommand
				oCmd.CommandText = sSQL
				oCmd.Connection = oConn
				oCmd.Connection.Open()
				oCmd.Parameters.Clear()
				oCmd.Parameters.Add(New SqlParameter("@LocalMOID", sLocalMOID))
				oCmd.Parameters.Add(New SqlParameter("@Now", Now()))
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
				oConn.ConnectionString = _
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

				sSQL = "SELECT dbo.TxIn.MSISDN, dbo.TxIn.AgentID, dbo.TxIn.ReloadMSISDN, dbo.TxIn.ReloadAmount, dbo.TxIn.ReloadTelco, dbo.AgentProduct.Discount " & _
										"FROM dbo.AgentProduct INNER JOIN " & _
										"dbo.TxIn ON dbo.AgentProduct.AgentID = dbo.TxIn.AgentID INNER JOIN " & _
										"dbo.ProductInfo ON dbo.TxIn.ReloadTelco = dbo.ProductInfo.Telco AND dbo.AgentProduct.ProductID = dbo.ProductInfo.ProductID " & _
										"WHERE  (dbo.TxIn.LocalMOID = @LocalMOID)"

				oConn = New SqlConnection()
				oConn.ConnectionString = _
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


					'***********Rebate************************
					Dim aRebate As Decimal = 0
					aRebate = getAgentRebate(sAgentId, GetRebateID(sReloadAmount, getProductID(sReloadTelco, oConn)), oConn)
					If aRebate > 0 Then sDiscount = sDiscount + aRebate
					'****************************************

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
		Public Function SuccessToAgent(ByVal sLocalMOID As String) As Boolean

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
			Dim sBalance As Decimal

			Dim sMT_MSG As String = MT_MSG2
			Dim sSQLUpdate As String = ""
			Dim sMSISDN As String

			Try
				'sSQL = "SELECT * FROM TxIn WHERE LocalMOID=@LocalMOID"
				'sSQL = "SELECT t.MSISDN, t.AgentId,t.ReloadMSISDN,t.ReloadAmount,t.ReloadTelco,i.DiscountMaxis as DisMaxis, i.DiscountDiGi as DisDiGi, i.DiscountCelcom as DisCelcom  FROM TxIn t, AgentInfo i WHERE t.LocalMOID=@LocalMOID and t.agentid=i.agentid"

				sSQL = "SELECT dbo.TxIn.MSISDN, dbo.TxIn.AgentID, dbo.TxIn.ReloadMSISDN, dbo.TxIn.ReloadAmount, dbo.TxIn.ReloadTelco, dbo.AgentProduct.Discount, dbo.AgentBalance.Balance " & _
										"FROM dbo.AgentProduct INNER JOIN " & _
										"dbo.TxIn ON dbo.AgentProduct.AgentID = dbo.TxIn.AgentID INNER JOIN " & _
										"dbo.ProductInfo ON dbo.TxIn.ReloadTelco = dbo.ProductInfo.Telco AND dbo.AgentProduct.ProductID = dbo.ProductInfo.ProductID INNER JOIN " & _
										"dbo.AgentBalance ON dbo.TxIn.AgentID = dbo.AgentBalance.AgentID " & _
										"WHERE  (dbo.TxIn.LocalMOID = @LocalMOID)"

				oConn = New SqlConnection()
				oConn.ConnectionString = _
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
					sBalance = oDR.Item("Balance")
					oDR.Close()


					'Private Const MT_MSG = "Your account been credited: [<Amount>] New balace: <NewBalance>. Remarks: <Remarks> DateTime:<DateTime>."
					sMT_MSG = sMT_MSG.Replace("<Amount>", sReloadAmount)
					sMT_MSG = sMT_MSG.Replace("<Remarks>", "" + sReloadMSISDN + "")
					sMT_MSG = sMT_MSG.Replace("<DateTime>", Now())
					sMT_MSG = sMT_MSG.Replace("<ReloadTelco>", sReloadTelco)
					sMT_MSG = sMT_MSG.Replace("<Balance>", sBalance)
					InsertMT(sMSISDN, sMT_MSG, sAgentId)

				End If

				SuccessToAgent = True
				' oDR.Close()

			Catch ex As Exception
				SuccessToAgent = False
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

		Private Function InsertMT(ByVal sMSISDN As String, ByVal sMsg As String, Optional ByVal sAgentId As String = "") As Boolean

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




		Private Function Expend(ByVal sValue As String, ByVal sdelimiter As String) As String

			Dim sStart As String = Nothing
			Dim sEnd As String = Nothing
			Dim aValue() As String
			Dim i As Integer = 0
			Dim sFinalvalue As String = Nothing
			Expend = Nothing

			Try
				aValue = sValue.Split(sdelimiter)
				If UBound(aValue) = 1 Then
					sStart = aValue(0)
					sEnd = aValue(1)

					For i = sStart To sEnd
						If sFinalvalue = Nothing Then
							sFinalvalue = i
						Else
							sFinalvalue = sFinalvalue & "," & i
						End If
					Next

					Expend = sFinalvalue
				End If
				Return Expend
			Catch ex As Exception
				'MsgBox(ex.Message & "  " & ex.StackTrace)
				Return Nothing
			End Try

		End Function

		Private Function GetRebateID(ByVal sValue As String, ByVal sProductID As String) As String

			Dim i As Integer = 0
			Dim sSQL As String = ""
			Dim oConn As New SqlConnection(ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString)
			'Dim oConn As New SqlConnection(gsDBConnString)
			Dim oCmd As New SqlCommand
			Dim oDR As SqlDataReader = Nothing
			Dim sRebateID As String = ""
			Dim sDenomination As String = ""
			Dim aDenomination() As String = Nothing

			GetRebateID = Nothing

			Try
				oConn.Open()
				oCmd = oConn.CreateCommand
				oCmd.Connection = oConn

				sSQL = "SELECT RebateID,Denomination FROM ProductRebate WHERE ProductID=@ProductID"

				oCmd.CommandText = sSQL
				With oCmd.Parameters
					.Clear()
					.AddWithValue("@ProductID", sProductID)
				End With
				oDR = oCmd.ExecuteReader

				While oDR.Read
					sDenomination = oDR.Item("Denomination")

					If sDenomination.Contains("-") Then
						sDenomination = Expend(sDenomination, "-")
						aDenomination = sDenomination.Split(",")
						For i = 0 To UBound(aDenomination)
							If aDenomination(i) = sValue Then
								sRebateID = oDR.Item("RebateID")
								Exit For
							End If
						Next
					Else
						If sDenomination = sValue Then
							sRebateID = oDR.Item("RebateID")
						End If
					End If

					If sRebateID <> "" Then
						Exit While
					End If

				End While
				oDR.Close()

				Return sRebateID

			Catch ex As Exception
				'MsgBox(ex.Message & "  " & ex.StackTrace)
				Return Nothing
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


		Private Function getAgentRebate(ByVal sAgentId As String, ByVal sRebateID As String, ByVal oConn As SqlConnection) As Decimal

			Dim sSQL As String = ""
			Dim oCmd As New SqlCommand
			Dim oDR As SqlDataReader = Nothing
			Dim sBalance As Decimal = 0

			Try
				getAgentRebate = 0
				'oConn.Open()
				oCmd = oConn.CreateCommand
				oCmd.Connection = oConn

				sSQL = "SELECT Rebate FROM AgentProductRebate WHERE AgentID=@AgentID and RebateID=@RebateID"
				oCmd.CommandText = sSQL
				With oCmd.Parameters
					.Clear()
					.AddWithValue("@AgentID", sAgentId)
					.AddWithValue("@RebateID", sRebateID)
				End With
				oDR = oCmd.ExecuteReader
				If oDR.HasRows Then
					oDR.Read()
					getAgentRebate = oDR.Item("Rebate")
				End If
				oDR.Close()
				'oConn.Close()
			Catch ex As Exception
				getAgentRebate = 0
				'goLog.ErrorLog(ProcessorId & "~getAgentRebate", ex.Message)
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
			End Try

		End Function

		Private Function getProductID(ByVal sTelco As String, ByVal oConn As SqlConnection) As String

			Dim sSQL As String = ""
			Dim oCmd As New SqlCommand
			Dim oDR As SqlDataReader = Nothing
			Dim sBalance As Decimal = 0

			Try
				getProductID = ""
				'oConn.Open()
				oCmd = oConn.CreateCommand
				oCmd.Connection = oConn

				sSQL = "SELECT ProductID FROM ProductInfo WHERE Telco=@Telco"
				oCmd.CommandText = sSQL
				With oCmd.Parameters
					.Clear()
					.AddWithValue("@Telco", sTelco)
				End With
				oDR = oCmd.ExecuteReader
				If oDR.HasRows Then
					oDR.Read()
					getProductID = oDR.Item("ProductID")
				End If
				oDR.Close()
				'oConn.Close()
			Catch ex As Exception
				getProductID = ""
				'goLog.ErrorLog(ProcessorId & "~getProductID", ex.Message)
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
			End Try

		End Function
	End Class

End Namespace
