
Partial Class Submaster_Logout
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		Session.Abandon()

		Response.Redirect("~/submaster/submaster_login.aspx")

	End Sub

End Class
