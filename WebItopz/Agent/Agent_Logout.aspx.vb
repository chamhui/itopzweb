
Partial Class Agent_Logout
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		Session.Abandon()
        Response.Redirect("Agent_Login.aspx")
    End Sub
End Class
