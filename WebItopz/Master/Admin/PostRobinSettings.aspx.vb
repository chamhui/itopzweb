
Partial Class Admin_PostRobinSettings
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("AGENT_ID") = "" Then
            Response.Redirect("~/Master/Login.aspx")
        End If
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
