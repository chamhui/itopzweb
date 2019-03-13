Imports System.Data.SqlClient

Partial Class Submaster_DealerCommission
	Inherits System.Web.UI.Page


	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		'If Not Me.IsPostBack Then


		If (Session("AGENT_ID") = "") And (Session("AGENT_AGENTLVL") = "|1|") Then
			Response.Redirect("~/submaster/submaster_login.aspx")
		End If

		' Preloading 
		'Me.DDLMonth.SelectedValue = Format(Now(), "MM")
		'For i As Integer = -3 To 10
		' Me.DDLYear.Items.Add(Format(Now(), "yyyy") + i)
		'Next i
		'Me.DDLYear.SelectedValue = Format(Now(), "yyyy")


		'End If
	End Sub

	Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init


		Me.DDLMonth.SelectedValue = Format(Now(), "MM")

		For i As Integer = -3 To 10
			Me.DDLYear.Items.Add(Format(Now(), "yyyy") + i)
		Next i
		Me.DDLYear.SelectedValue = Format(Now(), "yyyy")



	End Sub
	Protected Sub btnGenerate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerate.Click

	End Sub
End Class
