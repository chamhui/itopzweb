Imports System.Data.SqlClient
Imports Microsoft.AspNet.Identity

Public Class SiteMaster
    Inherits MasterPage
    Private Const AntiXsrfTokenKey As String = "__AntiXsrfToken"
    Private Const AntiXsrfUserNameKey As String = "__AntiXsrfUserName"
    Private _antiXsrfTokenValue As String

    Protected Sub Page_Init(sender As Object, e As EventArgs)
        ' The code below helps to protect against XSRF attacks
        Dim requestCookie = Request.Cookies(AntiXsrfTokenKey)
        Dim requestCookieGuidValue As Guid
        If requestCookie IsNot Nothing AndAlso Guid.TryParse(requestCookie.Value, requestCookieGuidValue) Then
            ' Use the Anti-XSRF token from the cookie
            _antiXsrfTokenValue = requestCookie.Value
            Page.ViewStateUserKey = _antiXsrfTokenValue
        Else
            ' Generate a new Anti-XSRF token and save to the cookie
            _antiXsrfTokenValue = Guid.NewGuid().ToString("N")
            Page.ViewStateUserKey = _antiXsrfTokenValue

            Dim responseCookie = New HttpCookie(AntiXsrfTokenKey) With {
                 .HttpOnly = True,
                 .Value = _antiXsrfTokenValue
            }
            If FormsAuthentication.RequireSSL AndAlso Request.IsSecureConnection Then
                responseCookie.Secure = True
            End If
            Response.Cookies.[Set](responseCookie)
        End If

        AddHandler Page.PreLoad, AddressOf master_Page_PreLoad
    End Sub

    Protected Sub master_Page_PreLoad(sender As Object, e As EventArgs)
        If Not IsPostBack Then
            ' Set Anti-XSRF token
            ViewState(AntiXsrfTokenKey) = Page.ViewStateUserKey
            ViewState(AntiXsrfUserNameKey) = If(Context.User.Identity.Name, [String].Empty)
        Else
            ' Validate the Anti-XSRF token
            If DirectCast(ViewState(AntiXsrfTokenKey), String) <> _antiXsrfTokenValue OrElse DirectCast(ViewState(AntiXsrfUserNameKey), String) <> (If(Context.User.Identity.Name, [String].Empty)) Then
                Throw New InvalidOperationException("Validation of Anti-XSRF token failed.")
            End If
        End If
    End Sub
    Function List_Childnodes(Current_Node As SiteMapNode) As String
        Dim sb As New StringBuilder

        ' What nodes are children of the function parameter?
        If (Current_Node.HasChildNodes) Then
            Dim childNodesEnumerator As IEnumerator = Current_Node.ChildNodes.GetEnumerator()

            sb.Append(vbTab & "<ul class='nav child_menu'>")
            While (childNodesEnumerator.MoveNext())
                ' Prints the Title of each node.System Setting
                Dim node As SiteMapNode = CType(childNodesEnumerator.Current, SiteMapNode)
                sb.Append(vbTab & "<li>")
                sb.Append("<a href=""" & Page.ResolveClientUrl(node.Url) & """>")
                sb.Append(childNodesEnumerator.Current.ToString())
                sb.Append("</a>")
                ' this is how the recursion captures all child nodes                
                sb.Append(List_Childnodes(node))
                sb.Append("</li>" & vbCrLf)

            End While
            Dim session_admin As String = System.Web.HttpContext.Current.Session("AGENT_NAME")
			If Session("AGENT_NAME") = "SuperAdmin" Then
				sb.Append(vbTab & "<li>")
				sb.Append("<a href='/Master/Admin/AdminChangePassword.aspx'>Admin Change Password</a>")
				sb.Append("</li>" & vbCrLf)
			End If
			sb.Append("</ul>" & vbCrLf)
        End If

        Return sb.ToString
    End Function

    Public strSitemap As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Label1.Text = Format(Now(), "yyyy")

        Dim sb As New StringBuilder
        ' Examine the RootNode, and navigate the SiteMap relative to it.

        ' What nodes are children of the RootNode?
        Dim url As String = Request.Url.ToString()
        If InStr(url, "/Master/") > 0 Then
            lblSystemName.Text = "iTopz WEB Portal"
            SiteMapDataSource1.SiteMapProvider = "MasterSiteMapProvider"
        ElseIf InStr(url.ToLower, "/submaster/") > 0 Then
            lblSystemName.Text = "iTopz Submaster Portal"
            SiteMapDataSource1.SiteMapProvider = "SubmasterSiteMapProvider"
        ElseIf InStr(url, "/Dealer/") > 0 Then
            lblSystemName.Text = "iTopz Dealer Portal"
            SiteMapDataSource1.SiteMapProvider = "DealerSiteMapProvider"
        ElseIf InStr(url, "/Agent/") > 0 Then
            lblSystemName.Text = "iTopz Agent Portal"
            SiteMapDataSource1.SiteMapProvider = "AgentSiteMapProvider"
            Try
                If Session("AGENT_RETAILER") = "yes" Then
                    lblSystemName.Text = "iTopz Retailer Portal"
                    SiteMapDataSource1.SiteMapProvider = "RetailerSiteMapProvider"
                End If
            Catch ex As Exception

            End Try

        End If

        If Session("AGENT_NAME") <> "" Then
            Me.lblname.Text = Session("AGENT_ID") & "-" & Session("AGENT_NAME")
        ElseIf Session("DEALER_NAME") <> "" Then
            Me.lblname.Text = Session("DEALER_ID") & "-" & Session("DEALER_NAME")
        ElseIf Session("SUBMASTER_NAME") <> "" Then
            Me.lblname.Text = Session("SUBMASTER_ID") & "-" & Session("SUBMASTER_NAME")
        Else
            Me.lblname.Text = "Guest"
        End If

        isValidLogin(Session("AGENT_ID"))
        'sb.Append("<li><a>" & url & "</a></li>")
        'SiteMapDataSource1.SiteMapProvider = "MasterSiteMapProvider"

        If (SiteMapDataSource1.Provider.RootNode.HasChildNodes) Then
            Dim rootNodesChildrenEnumerator As IEnumerator = SiteMapDataSource1.Provider.RootNode.ChildNodes.GetEnumerator()
            Dim node As SiteMapNode
            While (rootNodesChildrenEnumerator.MoveNext())
                node = CType(rootNodesChildrenEnumerator.Current, SiteMapNode)
                If node.Url IsNot Nothing Then
                    If (node.HasChildNodes) Then
                        sb.Append("<li><a>" & rootNodesChildrenEnumerator.Current.ToString() & "<span class='fa fa-chevron-down'></span></a>" & vbCrLf)
                    Else
                        sb.Append("<li><a href=""" & Page.ResolveClientUrl(node.Url) & """>" & rootNodesChildrenEnumerator.Current.ToString() & "</a>" & vbCrLf)
                    End If
                    'sb.Append("<li><a href=""" & Page.ResolveClientUrl(node.Url) & """>" & rootNodesChildrenEnumerator.Current.ToString() & "</a>" & vbCrLf)
                Else
                    sb.Append("<li>" & rootNodesChildrenEnumerator.Current.ToString() & vbCrLf)
                End If

                sb.Append(vbTab & List_Childnodes(CType(rootNodesChildrenEnumerator.Current, SiteMapNode)))
                sb.Append("</li>")
            End While
        End If

        strSitemap = sb.ToString
        ltrSiteMap.Text = strSitemap
    End Sub

    Private Sub isValidLogin(ByVal sLogin As String)

        Dim sSQL As String = ""
        Dim oConn As New SqlConnection(ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString)
        Dim oCmd As New SqlCommand
        Dim oDR As SqlDataReader = Nothing
        Dim sAgentID As String
        Dim sName As String = ""
        sAgentID = Session("AGENT_ID")

        Try
            'Response.Write(sLogin)
            'Response.Write(sPassword)
            oConn.Open()
            oCmd = oConn.CreateCommand
            oCmd.Connection = oConn
            sSQL = "SELECT am.AgentID, ai.Name, ab.Balance FROM AgentMSISDN am , AgentInfo ai, AgentBalance ab WHERE am.agentid=ai.agentid AND am.agentid=@AgentID AND am.agentid=ab.agentid"
            oCmd.CommandText = sSQL

            With oCmd.Parameters
                .Clear()
                .AddWithValue("@AgentID", sAgentID)

            End With
            oDR = oCmd.ExecuteReader
            If oDR.Read Then
                lblbalance.Text = "$ " + oDR.Item("Balance").ToString()
            Else
                Session("LOGIN_FAIL_COUNT") = Session("LOGIN_FAIL_COUNT") + 1
            End If

            oConn.Close()

        Catch ex As Exception

            'Response.Write("getMaxPostRobinq [" & ex.Message & "]" & ex.StackTrace)
        Finally
            If (Not oCmd Is Nothing) Then
                oCmd.Dispose()
                oCmd = Nothing
            End If
            If (Not oDR Is Nothing) Then
                If (Not oDR.IsClosed) Then
                    oDR.Close()
                End If
                oDR = Nothing
            End If
            If (Not oConn Is Nothing) Then
                If oConn.State = ConnectionState.Open Then
                    oConn.Close()
                End If
                oConn.Dispose()
                oConn = Nothing
            End If
        End Try

    End Sub
    Protected Sub Unnamed_LoggingOut(sender As Object, e As LoginCancelEventArgs)
        Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie)
    End Sub

End Class