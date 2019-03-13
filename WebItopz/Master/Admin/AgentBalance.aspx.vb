
Imports System.IO

Partial Class Admin_AgentBalance
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Session("AGENT_ID") = "" Then
			Response.Redirect("~/Master/Login.aspx")
		End If

		Dim sSQL As String

		lblErrorMSISDN.Text = ""

		'sSQL = "SELECT b.AgentID, i.Name, i.HPNo, b.MaxisBalance, b.CelcomBalance, b.DiGiBalance FROM AgentBalance b, AgentInfo i WHERE i.agentid=b.agentid "
		sSQL = "SELECT b.AgentID, i.Name, i.HPNo, b.Balance, b.M5, b.M18, b.M28  FROM AgentBalance b, AgentInfo i WHERE i.agentid=b.agentid "

		If Me.txtMSISDN.Text <> "" Then
			sSQL = sSQL & " and i.HPNo= '65" & Right(txtMSISDN.Text.Trim, 8) & "'"
		Else
			lblErrorMSISDN.Text = "*"
		End If
		sSQL = sSQL & " ORDER BY CONVERT(INT,b.AgentID)"

		'Response.Write(sSQL)
		Me.SqlDataSource1.SelectCommand = sSQL
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

	Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
		Me.GridView1.DataBind()
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
