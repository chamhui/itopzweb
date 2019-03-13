
Imports System.IO

Partial Class ReportAgentSalesSummary
	Inherits System.Web.UI.Page
	Dim total5 As Decimal = 0
	Dim total1 As Decimal = 0
	Dim total2 As Decimal = 0
	Dim c5 As Decimal = 0
	Dim c1 As Decimal = 0
	Dim c2 As Decimal = 0
	Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
		Me.txtDateFrom.Text = Format(Now(), "yyyyMMdd")
		Me.txtDateTo.Text = Format(Now(), "yyyyMMdd")
	End Sub

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Session("AGENT_ID") = "" Then
			Response.Redirect("~/Master/Login.aspx")
		End If
	End Sub

	Protected Sub GridView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs)
		'If (GridView1.Rows.Count > 0) Then
		'	GridView1.UseAccessibleHeader = True
		'	GridView1.HeaderRow.TableSection = TableRowSection.TableHeader
		'	If (GridView1.BottomPagerRow IsNot Nothing) Then

		'		GridView1.BottomPagerRow.TableSection = TableRowSection.TableFooter
		'		GridView1.BottomPagerRow.Cells(0).Attributes.Add("align", "left")
		'		'GridView1.FooterRow.TableSection = TableRowSection.TableFooter
		'	End If
		'End If
	End Sub
	Protected Sub GridView5_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)

		If e.Row.RowType = DataControlRowType.DataRow Then
			Dim lblqy As Label = DirectCast(e.Row.FindControl("lblqty"), Label)
			Dim qty As Decimal = Decimal.Parse(lblqy.Text)
			total5 = total5 + qty

			Dim lblc As Label = DirectCast(e.Row.FindControl("lblCommission"), Label)
			Dim c As Decimal = Decimal.Parse(lblc.Text)
			c5 = c5 + c
		End If
		If e.Row.RowType = DataControlRowType.Footer Then
			Dim lblTotalqty As Label = DirectCast(e.Row.FindControl("lblTotalqty"), Label)
			lblTotalqty.Text = total5.ToString()
			Dim lblTotalComission As Label = DirectCast(e.Row.FindControl("lblTotalComission"), Label)
			lblTotalComission.Text = c5.ToString()
		End If
	End Sub
	Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)

		If e.Row.RowType = DataControlRowType.DataRow Then
			Dim lblqy As Label = DirectCast(e.Row.FindControl("lblqty"), Label)
			Dim qty As Decimal = Decimal.Parse(lblqy.Text)
			total1 = total1 + qty

			Dim lblc As Label = DirectCast(e.Row.FindControl("lblCommission"), Label)
			Dim c As Decimal = Decimal.Parse(lblc.Text)
			c1 = c1 + c
		End If
		If e.Row.RowType = DataControlRowType.Footer Then
			Dim lblTotalqty As Label = DirectCast(e.Row.FindControl("lblTotalqty"), Label)
			lblTotalqty.Text = total1.ToString()
			Dim lblTotalComission As Label = DirectCast(e.Row.FindControl("lblTotalComission"), Label)
			lblTotalComission.Text = c1.ToString()
		End If
	End Sub
	Protected Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)

		If e.Row.RowType = DataControlRowType.DataRow Then
			Dim lblqy As Label = DirectCast(e.Row.FindControl("lblqty"), Label)
			Dim qty As Decimal = Decimal.Parse(lblqy.Text)
			total2 = total2 + qty

			Dim lblc As Label = DirectCast(e.Row.FindControl("lblCommission"), Label)
			Dim c As Decimal = Decimal.Parse(lblc.Text)
			c2 = c2 + c
		End If
		If e.Row.RowType = DataControlRowType.Footer Then
			Dim lblTotalqty As Label = DirectCast(e.Row.FindControl("lblTotalqty"), Label)
			lblTotalqty.Text = total2.ToString()
			Dim lblTotalComission As Label = DirectCast(e.Row.FindControl("lblTotalComission"), Label)
			lblTotalComission.Text = c2.ToString()
		End If
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
End Class
