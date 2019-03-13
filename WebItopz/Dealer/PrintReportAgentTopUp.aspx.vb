
Partial Class DealerPrintReportAgentTopup
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Me.txtDateFrom.Text = Format(Now(), "yyyyMMdd").ToString
        Me.txtDateTo.Text = Format(Now(), "yyyyMMdd").ToString
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not User.Identity.IsAuthenticated Then
            'Server.Transfer("~/login.aspx")
        Else
        End If
        If Session("DEALER_ID") = "" Then
            Response.Redirect("~/Dealer/Login.aspx")
        End If
    End Sub

End Class
