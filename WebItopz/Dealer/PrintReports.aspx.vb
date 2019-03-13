
Partial Class DealerPrintReports
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not User.Identity.IsAuthenticated Then
            'Server.Transfer("~/login.aspx")
        Else
        End If
        If Session("DEALER_ID") = "" Then
            Response.Redirect("~/Dealer/Login.aspx")
        End If
    End Sub

    Protected Sub btnPrintReportAgentSales_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintReportAgentSales.Click

        Response.Write("<script>window.open('PrintReportAgentSales.aspx','_newAgentSales', 'width=800,height=600,toolbar=yes,menubar=yes,scrollbars=yes' );</script>")

    End Sub

    Protected Sub btnPrintReportAgentTopUp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintReportAgentTopUp.Click

        Response.Write("<script>window.open('PrintReportAgentTopup.aspx','_newAgentTopup', 'width=800,height=600,toolbar=yes,menubar=yes,scrollbars=yes' );</script>")

    End Sub


End Class
