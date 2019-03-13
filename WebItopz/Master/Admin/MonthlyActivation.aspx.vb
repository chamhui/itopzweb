
Partial Class Admin_MonthlyActivation
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("AGENT_ID") = "" Then
            Response.Redirect("~/Master/Login.aspx")
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

End Class
