
Partial Class Submaster_Admin_ReportTotalAgentSales
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Response.Redirect("~/submaster/submaster_login.aspx")
		If Session("AGENT_ID") = "" Then
			Response.Redirect("~/submaster/submaster_login.aspx")
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
