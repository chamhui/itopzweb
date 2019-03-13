
Partial Class Submaster_Report
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Not User.Identity.IsAuthenticated Then
			'Server.Transfer("~/login.aspx")
		Else
		End If



	End Sub
End Class
