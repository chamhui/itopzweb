
Partial Class Agent_AgentInfo
	Inherits System.Web.UI.Page


	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("AGENT_ID") = "" Then
            Response.Redirect("~/Agent/Agent_Login.aspx")
        End If
        Try
            If Session("AGENT_RETAILER") = "yes" Then
                Me.lblTitle.Text = "Retailer Information"
                Me.lblTitle2.Text = "Retailer Information"
            End If
        Catch ex As Exception

        End Try
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
End Class
