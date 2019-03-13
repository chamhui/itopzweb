Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager
Imports System.Security.Cryptography

Partial Class Login
	Inherits System.Web.UI.Page

	Const STATUS_ACTIVE As String = "ACTIVE"
	Dim isBanIP As Boolean = False

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		Dim aIP() As String
		Dim i As Integer = 0

		'Application("LOGIN_FAIL_IPADDRESS") = ""

		Me.lblError.Visible = False

		If Application("LOGIN_FAIL_IPADDRESS") <> "" Then
			aIP = Application("LOGIN_FAIL_IPADDRESS").ToString.Split(":")
			For i = 0 To UBound(aIP)
				If aIP(i) = Request.ServerVariables("REMOTE_HOST") Then
					isBanIP = True
					Exit For
				End If
			Next
		End If

		If Session("LOGIN_FAIL_COUNT") > 3 Or isBanIP Then
			Me.LoginButton.Enabled = False
			Me.lblError.Text = "Excess Max number retry"
			Me.lblError.Visible = True
		End If

	End Sub

	Protected Sub LoginButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginButton.Click

		If Session("LOGIN_FAIL_COUNT") > 3 Or isBanIP Then
			Me.LoginButton.Enabled = False
			Me.lblError.Text = "Excess Max number retry"
			Me.lblError.Visible = True
		Else
			If Me.txtMISISN.Text.Length < 8 Then
				Me.lblError.Text = "Invalid Login ID, min 8 number"
				Me.lblError.Visible = True
			ElseIf Me.txtPassword.Text.Length < 7 Then
				Me.lblError.Text = "Invalid Login Password, min 8 character"
				Me.lblError.Visible = True
			Else
				If isValidSuperAdminLogin("65" & txtMISISN.Text, txtPassword.Text) Then
					If Request.ServerVariables("HTTP_REFERER").ToUpper.Contains("LOGIN") Then
						Response.Redirect("~/Master/Search.aspx")
					Else
						Response.Redirect("~/Master/Search.aspx")
						'Response.Redirect(Request.ServerVariables("HTTP_REFERER"))
					End If
				ElseIf isValidLogin("65" & txtMISISN.Text, txtPassword.Text) Then
					If Request.ServerVariables("HTTP_REFERER").ToUpper.Contains("LOGIN") Then
						Response.Redirect("~/Master/Search.aspx")
					Else
						Response.Redirect("~/Master/Search.aspx")
						'Response.Redirect(Request.ServerVariables("HTTP_REFERER"))
					End If
				Else
					Me.lblError.Text = "Login and password not match!"
					Me.lblError.Visible = True
				End If
			End If
		End If

	End Sub

	Private Function isValidLogin(ByVal sLogin As String, ByVal sPassword As String) As Boolean

		Dim sSQL As String = ""
		Dim oConn As New SqlConnection(ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString)
		Dim oCmd As New SqlCommand
		Dim oDR As SqlDataReader = Nothing
		Dim sAgentID As String
		Dim sName As String = ""
		isValidLogin = False

		Try
			'Response.Write(sLogin)
			'Response.Write(sPassword)
			oConn.Open()
			oCmd = oConn.CreateCommand
			oCmd.Connection = oConn
			sSQL = "SELECT am.AgentID, ai.Name FROM AgentMSISDN am , AgentInfo ai WHERE am.agentid=ai.agentid AND am.MSISDN=@MSISDN AND am.PASSWORD=@PASSWORD AND am.STATUS=@STATUS and ai.ParentAgentID=0 and ai.agentid=1"
			oCmd.CommandText = sSQL

			With oCmd.Parameters
				.Clear()
				.AddWithValue("@MSISDN", sLogin)
				.AddWithValue("@PASSWORD", ComputeSha256Hash(sPassword))
				.AddWithValue("@STATUS", STATUS_ACTIVE)
			End With
			oDR = oCmd.ExecuteReader
			If oDR.Read Then
				sAgentID = oDR.Item("AgentID")
				sName = oDR.Item("Name")
				Session("AGENT_ID") = sAgentID
				Session("AGENT_NAME") = sName
				Session("AGENT_MSISDN") = sLogin
				isValidLogin = True
			Else
				Session("LOGIN_FAIL_COUNT") = Session("LOGIN_FAIL_COUNT") + 1
			End If

			If Session("LOGIN_FAIL_COUNT") = 5 Then
				Application("LOGIN_FAIL_IPADDRESS") = Application("LOGIN_FAIL_IPADDRESS") & ":" & Request.ServerVariables("REMOTE_HOST")
			End If

			oConn.Close()

		Catch ex As Exception
			isValidLogin = False
			Response.Write("getMaxPostRobinq [" & ex.Message & "]" & ex.StackTrace)
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

	Private Function isValidSuperAdminLogin(ByVal sLogin As String, ByVal sPassword As String) As Boolean

		Dim sSQL As String = ""
		Dim oConn As New SqlConnection(ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString)
		Dim oCmd As New SqlCommand
		Dim oDR As SqlDataReader = Nothing
		'Dim sAgentID As String
		'Dim sName As String = ""
		isValidSuperAdminLogin = False

		Try
			'Response.Write(sLogin)
			'Response.Write(sPassword)
			oConn.Open()
			oCmd = oConn.CreateCommand
			oCmd.Connection = oConn
			sSQL = "SELECT * FROM SuperAdmin WHERE MSISDN=@MSISDN AND PASSWORD=@PASSWORD"
			oCmd.CommandText = sSQL

			With oCmd.Parameters
				.Clear()
				.AddWithValue("@MSISDN", sLogin)
				.AddWithValue("@PASSWORD", base64Encode(sPassword))
			End With
			oDR = oCmd.ExecuteReader
			If oDR.Read Then
				'sAgentID = oDR.Item("AgentID")
				'sName = oDR.Item("Name")
				Session("SUPERADMIN") = True
				Session("AGENT_ID") = "1"
				Session("AGENT_NAME") = "SuperAdmin"
				Session("AGENT_MSISDN") = sLogin
				isValidSuperAdminLogin = True
			End If



			oConn.Close()

		Catch ex As Exception
			isValidSuperAdminLogin = False
			'Response.Write("getMaxPostRobinq [" & ex.Message & "]" & ex.StackTrace)
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

	Public Function base64Encode(sData As String) As String
		Try
			Dim encData_byte As Byte() = New Byte(sData.Length - 1) {}

			encData_byte = System.Text.Encoding.UTF8.GetBytes(sData)

			Dim encodedData As String = Convert.ToBase64String(encData_byte)


			Return encodedData
		Catch ex As Exception
			Throw New Exception("Error in base64Encode" + ex.Message)
		End Try
	End Function

	Public Function base64Decode(sData As String) As String

		Dim encoder As New System.Text.UTF8Encoding()

		Dim utf8Decode As System.Text.Decoder = encoder.GetDecoder()

		Dim todecode_byte As Byte() = Convert.FromBase64String(sData)

		Dim charCount As Integer = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length)

		Dim decoded_char As Char() = New Char(charCount - 1) {}

		utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0)

		Dim result As String = New [String](decoded_char)

		Return result

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
End Class
