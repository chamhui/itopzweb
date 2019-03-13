
Partial Class Agent_Home
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Not User.Identity.IsAuthenticated Then
			Server.Transfer("~/Agent/Agent_Login.aspx")
		Else
		End If
	End Sub
End Class
