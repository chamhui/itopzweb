Imports System.IO
Imports System.Web.UI
Partial Class ReportSalesByDenoSummary
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Session("AGENT_ID") = "" Then
			Response.Redirect("~/Master/Login.aspx")
		Else
		End If
	End Sub

	Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init


		Me.DDLMonth.SelectedValue = Format(Now(), "MM")

		Me.DDLYear.Items.Add(Format(Now(), "yyyy") - 1)
		Me.DDLYear.Items.Add(Format(Now(), "yyyy"))
		Me.DDLYear.Items.Add(Format(Now(), "yyyy") + 1)
		Me.DDLYear.Items.Add(Format(Now(), "yyyy") + 2)

		Me.DDLYear.SelectedValue = Format(Now(), "yyyy")



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
	Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
	End Sub
	Protected Sub GridView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs)
		If (GridView1.Rows.Count > 0) Then
			GridView1.UseAccessibleHeader = True
			GridView1.HeaderRow.TableSection = TableRowSection.TableHeader
			If (GridView1.BottomPagerRow IsNot Nothing) Then

				GridView1.BottomPagerRow.TableSection = TableRowSection.TableFooter
				GridView1.BottomPagerRow.Cells(0).Attributes.Add("align", "left")
				'GridView1.FooterRow.TableSection = TableRowSection.TableFooter
			End If
		End If


	End Sub

	Protected Sub GridView2_PreRender(ByVal sender As Object, ByVal e As System.EventArgs)
		If (GridView2.Rows.Count > 0) Then
			GridView2.UseAccessibleHeader = True
			GridView2.HeaderRow.TableSection = TableRowSection.TableHeader
			If (GridView2.BottomPagerRow IsNot Nothing) Then

				GridView2.BottomPagerRow.TableSection = TableRowSection.TableFooter
				GridView2.BottomPagerRow.Cells(0).Attributes.Add("align", "left")
				'GridView2.FooterRow.TableSection = TableRowSection.TableFooter
			End If
		End If


	End Sub
End Class
