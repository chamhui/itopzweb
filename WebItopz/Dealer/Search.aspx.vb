
Partial Class DealerSearch
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Session("DEALER_ID") = "" Then
            Response.Redirect("~/Dealer/Login.aspx")
        End If

        Dim sSQL As String

        'Me.lblErrorMsg.Text = ""
        'Me.lblErrorReloadMSISDN.Text = ""
        'Me.lblErrorAgentMSISDN.Text = ""
        'Me.lblErrorDate.Text = ""

        sSQL = "SELECT [LocalMOID], [MSISDN], [AgentID], [Commission], [MessageIn], [Status], [ReloadTelco], [ReloadAmount], [ReloadMSISDN], [MessageTS], [ErrorCode], [CreatedTS], [LastUpdatedTS], [DNReceivedId] FROM [TxIn] WHERE "

        If Me.txtReloadMSISDN.Text <> "" And (Me.txtReloadMSISDN.Text.Length = 8) Then
            sSQL = sSQL & " ReloadMSISDN= '" & Right(txtReloadMSISDN.Text.Trim, 8) & "' AND "
        Else
            'lblErrorReloadMSISDN.Text = "*"
        End If
        If Me.txtAgentMSISDN.Text <> "" And (Me.txtAgentMSISDN.Text.Length = 8) Then
            sSQL = sSQL & " MSISDN= '65" & Right(txtAgentMSISDN.Text, 8) & "' AND "
        Else
            'Me.lblErrorAgentMSISDN.Text = "*"
        End If

        sSQL = sSQL & " AgentID in (SELECT AgentID FROM AgentInfo WHERE ParentAgentID ='" & Session("DEALER_ID") & "') AND "

        If Me.txtDate.Text <> "" And Me.txtDate.Text.Length = 8 Then
            sSQL = sSQL & " left(MessageTS,8) = '" & txtDate.Text & "'"
        Else
            'Me.lblErrorDate.Text = "*"
        End If

        If Right(sSQL.Trim, 3).ToUpper = "AND" Then
            sSQL = Mid(sSQL, 1, sSQL.Length - 4)
        End If

        sSQL = sSQL & " order by messageTS desc"
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

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Me.txtDate.Text = Format(Now(), "yyyyMMdd")

        'Page.Header.InnerHtml = "<META HTTP-EQUIV=REFRESH CONTENT=60>"
        Page.Title = "Search"
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Me.GridView1.DataBind()
    End Sub
End Class
