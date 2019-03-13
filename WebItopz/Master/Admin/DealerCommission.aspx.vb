Imports System.Data.SqlClient
Imports System.IO

Partial Class DealerCommission
	Inherits System.Web.UI.Page


	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		'If Not Me.IsPostBack Then


		If Session("AGENT_ID") = "" Then
			Response.Redirect("~/Master/Login.aspx")
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

	Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click

		GridView1.AllowPaging = False
		GridView1.DataBind()

		ExportExcel("Report", GridView1)


		GridView1.AllowPaging = True
		GridView1.DataBind()

	End Sub

	Public Sub ExportExcel(ByVal filename As String, ByVal gv As GridView)
		Response.ClearContent()
		Response.AddHeader("content-disposition", "attachment; filename=" & filename & ".xls")
		Response.ContentType = "application/vnd.ms-excel"
		Dim sw As New StringWriter()
		Dim htw As New HtmlTextWriter(sw)
		gv.RenderControl(htw)
		Response.Write(sw.ToString())
		Response.[End]()
	End Sub
	Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
	End Sub

End Class
