
Partial Class Submaster_PrintReportProfit
	Inherits System.Web.UI.Page


	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		Me.lblDate.Text = "Date: " & Format(Now(), "yyyy-MM-dd hh:mm:ss tt")
		If Not User.Identity.IsAuthenticated Then
			'Server.Transfer("~/login.aspx")
		Else
		End If
		If Session("AGENT_ID") = "" Then
			Response.Redirect("~/submaster/submaster_login.aspx")
		End If
	End Sub


End Class
