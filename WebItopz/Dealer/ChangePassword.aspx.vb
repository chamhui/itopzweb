
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration.ConfigurationManager
Imports System.Security.Cryptography

Partial Class ChangePassword
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		If Session("DEALER_ID") = "" Then
			Server.Transfer("~/Dealer/login.aspx")
		End If
		Me.lblError.Visible = False
	End Sub


	Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click


		If Me.txtPassword.Text.ToString.Length < 7 Then
			Me.lblError.Text = "Password Min. 8 Character!"
		ElseIf Me.txtPasswordNew.Text.ToString.Length < 7 Then
			Me.lblError.Text = "New Password Min. 8 Character!"
		ElseIf Me.txtPasswordNew.Text <> Me.txtPasswordNew2.Text Then
			Me.lblError.Text = "New Password not much!"
		Else
			If UpdatePassowrd(txtPasswordNew.Text) Then
				Me.lblError.Text = "Update Success!"
			Else
				Me.lblError.Text = "Update Error! Retry Later"
			End If
		End If

		Me.lblError.Visible = True

	End Sub



	Private Function UpdatePassowrd(ByVal sNewPassword As String) As Boolean

		Dim sSQL As String = ""
		Dim oConn As New SqlConnection(ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString)
		Dim oCmd As New SqlCommand

		UpdatePassowrd = True

		Try
			oConn.Open()
			oCmd = oConn.CreateCommand
			oCmd.Connection = oConn
			sSQL = "UPDATE AGENTMSISDN SET PASSWORD=@NEWPASSWORD WHERE MSISDN=@MSISDN"

			oCmd.CommandText = sSQL
			With oCmd.Parameters
				.Clear()
				.AddWithValue("@NEWPASSWORD", ComputeSha256Hash(sNewPassword))
				.AddWithValue("@MSISDN", Session("DEALER_MSISDN"))
			End With
			oCmd.ExecuteNonQuery()
			oConn.Close()

		Catch ex As Exception
			UpdatePassowrd = False
			Response.Write("UpdatePassowrd [" & ex.Message & "]" & ex.StackTrace)
		Finally
			If (Not oCmd Is Nothing) Then
				oCmd.Dispose()
				oCmd = Nothing
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
