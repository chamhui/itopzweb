
Partial Class Dealer_AgentBalance
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("DEALER_ID") = "" Then
            Response.Redirect("~/Dealer/Login.aspx")
        End If

    End Sub
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Dim sSQL As String

        lblErrorMSISDN.Text = ""

		'sSQL = "SELECT b.AgentID, i.Name, i.HPNo, b.MaxisBalance, b.CelcomBalance, b.DiGiBalance FROM AgentBalance b, AgentInfo i WHERE i.agentid=b.agentid "
		sSQL = "SELECT b.AgentID, i.Name, i.HPNo, b.Balance, b.M5, b.M18, b.M28 FROM AgentBalance b, AgentInfo i WHERE i.agentid=b.agentid and b.AgentID IN (SELECT AgentID FROM AgentInfo AS AgentInfo_1 WHERE (ParentAgentID = @AgentID))"

		If Me.txtMSISDN.Text <> "" And (Me.txtMSISDN.Text.Length = 8) Then
            sSQL = sSQL & " and i.HPNo= '65" & Right(txtMSISDN.Text.Trim, 8) & "' "
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
End Class
