
Partial Class Submaster_Home
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Session("AGENT_ID") = "" Then
			Response.Redirect("~/Submaster/Submaster_LoginLogin.aspx")
		End If
	End Sub
End Class
