
Partial Class PrintReports
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("AGENT_ID") = "" Then
            Response.Redirect("~/Master/Login.aspx")
        End If
    End Sub

    Protected Sub btnPrintReportAgentSales_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintReportAgentSales.Click

        Response.Write("<script>window.open('PrintReportAgentSales.aspx','_newAgentSales', 'width=800,height=600,toolbar=yes,menubar=yes,scrollbars=yes' );</script>")

    End Sub
 
    Protected Sub btnPrintReportAgentTopUp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintReportAgentTopUp.Click

        Response.Write("<script>window.open('PrintReportAgentTopup.aspx','_newAgentTopup', 'width=800,height=600,toolbar=yes,menubar=yes,scrollbars=yes' );</script>")

    End Sub

    Protected Sub btnPrintReportAgentSalesAll_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintReportAgentSalesAll.Click
        Response.Write("<script>window.open('PrintReportAgentSalesAll.aspx','_newAgentSalesAll', 'width=800,height=600,toolbar=yes,menubar=yes,scrollbars=yes' );</script>")
    End Sub

    Protected Sub btnPrintReportAgentTopUpAll_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintReportAgentTopUpAll.Click
        Response.Write("<script>window.open('PrintReportAgentTopupAll.aspx','_newAgentTopupAll', 'width=800,height=600,toolbar=yes,menubar=yes,scrollbars=yes' );</script>")
    End Sub
    Protected Sub btnSimCardBalance_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSimCardBalance.Click
        'Response.Write("<script>window.open('PrintReportSimCardBalance.aspx','_PrintReportSimCardBalance', 'width=800,height=600,toolbar=yes,menubar=yes,scrollbars=yes' );</script>")
        Response.Redirect("UpkeepByPhone.aspx")
    End Sub
End Class
