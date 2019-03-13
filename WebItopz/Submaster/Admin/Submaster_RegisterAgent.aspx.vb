Imports System.Data.SqlClient


Partial Class Submaster_Admin_RegisterAgent
	Inherits System.Web.UI.Page
	Private msNEWAgentID As String


	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Session("AGENT_ID") = "" Then
			Response.Redirect("~/submaster/submaster_login.aspx")
		End If
	End Sub


	Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click

		If Session("AGENT_ID") = "" Then
			Response.Redirect("~/Master/Login.aspx")
		End If

		Dim sAgentID As String = ""

		If Me.txtName.Text = "" Then
			Me.lblErrorMsg.Text = "Invalid Name!"
		ElseIf Me.txtHPno.Text = "" Or Me.txtHPno.Text.Length <> 10 Then
			Me.lblErrorMsg.Text = "Invalid Handphone!"
		ElseIf CheckMSISDN(Me.txtHPno.Text, sAgentID) Then
			Me.lblErrorMsg.Text = "Handphone already exits! Used By AgentID: " & sAgentID
		Else
			msNEWAgentID = GetNewAgentID()

			If InsertNewAgent(msNEWAgentID, txtName.Text, Me.txtHPno.Text) Then
				If InsertAgentBalance(msNEWAgentID) Then
					If InsertAgentProduct(msNEWAgentID) Then
						If InsertAgentProductRebate(msNEWAgentID) Then
							Me.btnSubmit.Enabled = False
							Me.lblErrorMsg.Text = "Added Successfully! New AgentId : " & msNEWAgentID.ToString
							InsertAgentMSISDN(msNEWAgentID, Me.txtHPno.Text)
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
			sSQL = "INSERT INTO AgentInfo (AgentID, Name, HPNo, Agentlvl,ParentAgentID ) VALUES (@AgentId,@Name, @HPNo, @Agentlvl,@ParentAgentID )"

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
			oCmd.Parameters.Add(New SqlParameter("@Agentlvl", Session("AGENT_AGENTLVL") & Session("AGENT_ID") & "|"))
			oCmd.Parameters.Add(New SqlParameter("@ParentAgentID", Session("AGENT_ID")))
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

	Private Function InsertAgentMSISDN(ByVal sNewAgentId As String, ByVal sMSISDN As String) As Boolean

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
			sSQL = "INSERT INTO AgentMSISDN (AgentID, MSISDN,ReplyFlag) VALUES (@AgentId, @MSISDN,@ReplyFlag)"

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

	Private Function InsertAgentProduct(ByVal sNewAgentId As String) As Boolean

		Dim oConn As New SqlConnection
		Dim oConn1 As New SqlConnection
		Dim oCmd As New SqlCommand
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""
		Dim sSQLSelect As String = ""
		Dim oCmdSelect As New SqlCommand
		Dim oDRSelect As SqlDataReader

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
				oCmd.Parameters.Add(New SqlParameter("@Discount", oDRSelect.Item("Discount")))
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


	Private Function InsertAgentProductRebate(ByVal sNewAgentId As String) As Boolean

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

			sSQLSelect = "SELECT RebateID,ProductID,Denomination,Rebate FROM ProductRebate"
			oCmdSelect = New SqlCommand
			oCmdSelect.CommandText = sSQLSelect
			oCmdSelect.Connection = oConn
			oCmdSelect.Parameters.Clear()
			'oCmdSelect.Parameters.Add(New SqlParameter("@LocalMOID", sLocalMOID))
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

End Class
