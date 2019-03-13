Imports System.Data.SqlClient
Imports System.Security.Cryptography

Partial Class DealerRegisterAgent
	Inherits System.Web.UI.Page
	Private msNEWAgentID As String
	Private Const MT_MSG = "Your AgentID: <AgentID> is Successfully Registered! ID: HpNo. PW: <Password>, SMS Gateway: 91960600 Web: www.itopz.sg Hotline: 31515331"


	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		If Session("DEALER_ID") = "" Then
			Response.Redirect("~/Dealer/Login.aspx")
		End If

		Me.lblErrorMsg.Text = ""


	End Sub
	Private Function InsertMT(ByVal sMSISDN As String, ByVal sMsg As String, Optional ByVal sAgentId As String = "") As Boolean

		Dim sSQL As String = ""
		Dim oCmd As SqlCommand = Nothing
		Dim sLocalMTID As String
		Dim oConn As New SqlConnection
		Dim sRobin As String = "1"

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


	Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click

		Dim sAgentID As String = ""
		Dim sMsg As String = MT_MSG
		Dim sPassword As String
		sPassword = GeneratePassword("8")

		If Me.txtName.Text = "" Then
			Me.lblErrorMsg.Text = "Invalid Name!"
		ElseIf Me.txtHPno.Text = "" Or Me.txtHPno.Text.Length <> 10 Then
			Me.lblErrorMsg.Text = "Invalid Mobile Number!"
		ElseIf CheckMSISDN(Me.txtHPno.Text, sAgentID) Then
			Me.lblErrorMsg.Text = "Handphone already exits! Used By AgentID: " & sAgentID
		Else
			msNEWAgentID = GetNewAgentID()
			sMsg = sMsg.Replace("<AgentID>", msNEWAgentID).Replace("<Password>", sPassword)

			If InsertNewAgent(msNEWAgentID, txtName.Text, Me.txtHPno.Text) Then
				If InsertAgentBalance(msNEWAgentID) Then
					If InsertAgentProduct(msNEWAgentID) Then
						If InsertAgentProductRebate(msNEWAgentID, Session("DEALER_ID")) Then
							VerifyPrecentage(Session("DEALER_ID"), msNEWAgentID)
							If InsertMT(Me.txtHPno.Text, sMsg, msNEWAgentID) Then
								Me.btnSubmit.Enabled = False
								Me.lblErrorMsg.Text = "Added Successfully! New AgentId : " & msNEWAgentID.ToString
								InsertAgentMSISDN(msNEWAgentID, Me.txtHPno.Text, sPassword)
							End If
						End If
					End If
				End If
			End If

		End If

	End Sub




	Private Function InsertNewAgent(ByVal sNewAgentId As String, ByVal sName As String, ByVal sHPno As String) As Boolean

		Dim oConn As New SqlConnection
		Dim oCmd As New SqlCommand
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""

		InsertNewAgent = False

		Try
			sSQL = "INSERT INTO AgentInfo (AgentID, Name, HPNo, ParentAgentID, Agentlvl) VALUES (@AgentId,@Name,@HPNo,@ParentAgentID,@Agentlvl)"

			oConn = New SqlConnection()
			oConn.ConnectionString =
			ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

			oCmd = New SqlCommand
			oCmd.CommandText = sSQL
			oCmd.Connection = oConn
			oCmd.Connection.Open()

			oCmd.Parameters.Clear()
			oCmd.Parameters.Add(New SqlParameter("@AgentID", sNewAgentId))
			oCmd.Parameters.Add(New SqlParameter("@Name", sName))
			oCmd.Parameters.Add(New SqlParameter("@HPNo", sHPno))
			Try
				oCmd.Parameters.Add(New SqlParameter("@Agentlvl", Session("AGENT_AGENTLVL") + Session("DEALER_ID") + "|"))
			Catch ex As Exception
				oCmd.Parameters.Add(New SqlParameter("@Agentlvl", ""))
			End Try

			oCmd.Parameters.Add(New SqlParameter("@ParentAgentID", Session("DEALER_ID")))

			oCmd.ExecuteNonQuery()
			InsertNewAgent = True


		Catch ex As Exception
			InsertNewAgent = False
			lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message & ex.StackTrace
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


	Private Function InsertAgentBalance(ByVal sNewAgentId As String) As Boolean

		Dim oConn As New SqlConnection
		Dim oCmd As New SqlCommand
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""

		InsertAgentBalance = False

		Try
			sSQL = "INSERT INTO AgentBalance (AgentID,M5,M18,M28) VALUES (@AgentId,0,0,0)"

			oConn = New SqlConnection()
			oConn.ConnectionString =
			ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

			oCmd = New SqlCommand
			oCmd.CommandText = sSQL
			oCmd.Connection = oConn
			oCmd.Connection.Open()

			oCmd.Parameters.Clear()
			oCmd.Parameters.Add(New SqlParameter("@AgentID", sNewAgentId))

			oCmd.ExecuteNonQuery()
			InsertAgentBalance = True


		Catch ex As Exception
			InsertAgentBalance = False
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

	Private Function InsertAgentMSISDN(ByVal sNewAgentId As String, ByVal sMSISDN As String, ByVal sPassword As String) As Boolean

		Dim oConn As New SqlConnection
		Dim oCmd As New SqlCommand
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""
		Dim iReplyMT As Integer = 0



		'If Me.chkReplyMT.Checked = True Then
		iReplyMT = 1
		'End If

		InsertAgentMSISDN = False

		Try
			sSQL = "INSERT INTO AgentMSISDN (AgentID, MSISDN,ReplyFlag,Password) VALUES (@AgentId, @MSISDN,@ReplyFlag,@Password)"

			oConn = New SqlConnection()
			oConn.ConnectionString =
						ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

			oCmd = New SqlCommand
			oCmd.CommandText = sSQL
			oCmd.Connection = oConn
			oCmd.Connection.Open()

			oCmd.Parameters.Clear()
			oCmd.Parameters.Add(New SqlParameter("@AgentID", sNewAgentId))
			oCmd.Parameters.Add(New SqlParameter("@MSISDN", sMSISDN))
			oCmd.Parameters.Add(New SqlParameter("@ReplyFlag", iReplyMT))
			oCmd.Parameters.Add(New SqlParameter("@Password", ComputeSha256Hash(sPassword)))

			oCmd.ExecuteNonQuery()
			InsertAgentMSISDN = True


		Catch ex As Exception
			InsertAgentMSISDN = False
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
	Private Shared Function ComputeSha256Hash(ByVal rawData As String) As String
		Using sha256Hash As SHA256 = SHA256.Create()
			Dim bytes As Byte() = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData))
			Dim builder As StringBuilder = New StringBuilder()

			For i As Integer = 0 To bytes.Length - 1
				builder.Append(bytes(i).ToString("x2"))
			Next

			Return builder.ToString()
		End Using
	End Function

	Private Function InsertAgentProduct(ByVal sNewAgentId As String) As Boolean

		Dim oConn As New SqlConnection
		Dim oConn1 As New SqlConnection
		Dim oCmd As New SqlCommand
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""
		Dim sSQLSelect As String = ""
		Dim oCmdSelect As New SqlCommand
		Dim oDRSelect As SqlDataReader
		Dim sDiscount As String = "0.00"

		InsertAgentProduct = False

		Try

			oConn = New SqlConnection()
			oConn.ConnectionString = ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString
			oConn.Open()

			oConn1 = New SqlConnection()
			oConn1.ConnectionString = ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString
			oConn1.Open()

			sSQLSelect = "SELECT ProductID,Discount FROM ProductInfo WHERE STATUS='ACTIVE'"
			oCmdSelect = New SqlCommand
			oCmdSelect.CommandText = sSQLSelect
			oCmdSelect.Connection = oConn
			oCmdSelect.Parameters.Clear()
			'oCmdSelect.Parameters.Add(New SqlParameter("@LocalMOID", sLocalMOID))
			oDRSelect = oCmdSelect.ExecuteReader

			While oDRSelect.Read

				sSQL = "INSERT INTO AgentProduct (AgentID,ProductID,Discount) VALUES (@AgentId,@ProductID,@Discount)"
				oCmd = New SqlCommand
				oCmd.Connection = oConn1
				oCmd.CommandText = sSQL
				oCmd.Parameters.Clear()
				oCmd.Parameters.Add(New SqlParameter("@AgentID", sNewAgentId))
				oCmd.Parameters.Add(New SqlParameter("@ProductID", oDRSelect.Item("ProductID")))
				oCmd.Parameters.Add(New SqlParameter("@Discount", sDiscount))
				oCmd.ExecuteNonQuery()
				oCmd = Nothing

			End While
			oCmdSelect = Nothing
			oConn1.Close()
			oConn.Close()

			InsertAgentProduct = True


		Catch ex As Exception
			InsertAgentProduct = False
			lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message & ex.StackTrace
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


	Private Function GetNewAgentID() As String

		Dim oConn As New SqlConnection
		Dim oCmd As New SqlCommand
		Dim oDR As SqlDataReader
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""
		GetNewAgentID = "1"

		Try
			sSQL = "SELECT top 1 AgentId+1 as AgentId FROM AgentInfo ORDER By AgentId Desc"

			oConn = New SqlConnection()
			oConn.ConnectionString =
			ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

			oCmd = New SqlCommand
			oCmd.CommandText = sSQL
			oCmd.Connection = oConn
			oCmd.Connection.Open()
			oCmd.Parameters.Clear()

			oDR = oCmd.ExecuteReader

			If oDR.HasRows Then
				oDR.Read()
				GetNewAgentID = oDR.Item("AgentId")
			End If

		Catch ex As Exception
			GetNewAgentID = 1
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

	Private Function CheckMSISDN(ByVal sMSISDN As String, Optional ByRef sAgentID As String = "") As Boolean

		Dim oConn As New SqlConnection
		Dim oCmd As New SqlCommand
		Dim oDR As SqlDataReader
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""
		CheckMSISDN = False

		Try
			sSQL = "SELECT AgentID,MSISDN FROM AgentMSISDN " &
						 "WHERE MSISDN=@MSISDN"

			oConn = New SqlConnection()
			oConn.ConnectionString =
			ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

			oCmd = New SqlCommand
			oCmd.CommandText = sSQL
			oCmd.Connection = oConn
			oCmd.Connection.Open()

			oCmd.Parameters.Clear()
			oCmd.Parameters.Add(New SqlParameter("@MSISDN", sMSISDN))
			oDR = oCmd.ExecuteReader

			If (oDR.Read) Then
				sAgentID = oDR.Item("AgentID")
				CheckMSISDN = True
			End If

			oDR.Close()

		Catch ex As Exception
			CheckMSISDN = False
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

	Private Function VerifyPrecentage(ByVal sDealerID As String, ByVal sAgentID As String) As Boolean

		Dim oConn As New SqlConnection
		Dim oCmd As New SqlCommand
		Dim oDR As SqlDataReader
		Dim sSQL As String = ""
		VerifyPrecentage = False

		Try
			sSQL = "VerifyPrecentage"
			oConn = New SqlConnection()
			oConn.ConnectionString = ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString
			oCmd = New SqlCommand
			oCmd.CommandText = sSQL
			oCmd.CommandType = Data.CommandType.StoredProcedure
			oCmd.Connection = oConn
			oCmd.Connection.Open()
			oCmd.Parameters.Clear()
			oCmd.Parameters.AddWithValue("@DealerID", sDealerID)
			oCmd.Parameters.AddWithValue("@AgentID", sAgentID)
			oDR = oCmd.ExecuteReader()
			VerifyPrecentage = True
			oDR.Close()
			oDR = Nothing

		Catch ex As Exception
			VerifyPrecentage = False
			'Response.Write(ex.Message & ex.StackTrace)
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



	Private Function InsertAgentProductRebate(ByVal sNewAgentId As String, ByVal sDealerID As String) As Boolean

		Dim oConn As New SqlConnection
		Dim oConn1 As New SqlConnection
		Dim oCmd As New SqlCommand
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""
		Dim sSQLSelect As String = ""
		Dim oCmdSelect As New SqlCommand
		Dim oDRSelect As SqlDataReader

		InsertAgentProductRebate = False

		Try

			oConn = New SqlConnection()
			oConn.ConnectionString = ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString
			oConn.Open()

			oConn1 = New SqlConnection()
			oConn1.ConnectionString = ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString
			oConn1.Open()

			sSQLSelect = "SELECT RebateID,ProductID,Denomination,Rebate FROM AgentProductRebate Where AgentID = @DealerID"
			oCmdSelect = New SqlCommand
			oCmdSelect.CommandText = sSQLSelect
			oCmdSelect.Connection = oConn
			oCmdSelect.Parameters.Clear()
			oCmdSelect.Parameters.Add(New SqlParameter("@DealerID", sDealerID))
			oDRSelect = oCmdSelect.ExecuteReader

			While oDRSelect.Read

				sSQL = "INSERT INTO AgentProductRebate (AgentID,RebateID,ProductID,Denomination,Rebate) VALUES (@AgentID,@RebateID,@ProductID,@Denomination,@Rebate)"
				oCmd = New SqlCommand
				oCmd.Connection = oConn1
				oCmd.CommandText = sSQL
				oCmd.Parameters.Clear()
				oCmd.Parameters.Add(New SqlParameter("@AgentID", sNewAgentId))
				oCmd.Parameters.Add(New SqlParameter("@RebateID", oDRSelect.Item("RebateID")))
				oCmd.Parameters.Add(New SqlParameter("@ProductID", oDRSelect.Item("ProductID")))
				oCmd.Parameters.Add(New SqlParameter("@Denomination", oDRSelect.Item("Denomination")))
				oCmd.Parameters.Add(New SqlParameter("@Rebate", oDRSelect.Item("Rebate")))
				oCmd.ExecuteNonQuery()
				oCmd = Nothing

			End While
			oCmdSelect = Nothing
			oConn1.Close()
			oConn.Close()

			InsertAgentProductRebate = True


		Catch ex As Exception
			InsertAgentProductRebate = False
			lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message & ex.StackTrace
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
	Private Function GeneratePassword(ByVal iNumChars As Integer) As String
		'This function is used to generate a random PASSWORD that can be
		'emailed to the user.
		Const strDefault = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ01234567890"
		Const strFirstChar = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
		Dim iCount As Integer
		Dim strReturn As String
		Dim iNumber As Integer
		Dim iLength As Integer


		Randomize()


		'Generate first character of PASSWORD which has to be a letter
		iLength = Len(strFirstChar)
		iNumber = Int((iLength * Rnd()) + 1)
		strReturn = Mid(strFirstChar, iNumber, 1)


		'Generate the next n characters of the PASSWORD
		iLength = Len(strDefault)
		For iCount = 1 To iNumChars - 1
			iNumber = Int((iLength * Rnd()) + 1)
			strReturn += Mid(strDefault, iNumber, 1)
		Next


		Return strReturn


	End Function
End Class
