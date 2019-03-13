Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager

Partial Class Retailer_Login
    Inherits System.Web.UI.Page

    Const STATUS_ACTIVE As String = "ACTIVE"
    Dim isBanIP As Boolean = False

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim aIP() As String
        Dim i As Integer = 0

        'Application("LOGIN_FAIL_IPADDRESS") = ""

        Me.lblError.Visible = False

        If Application("LOGIN_FAIL_IPADDRESS") <> "" Then
            aIP = Application("LOGIN_FAIL_IPADDRESS").ToString.Split(":")
            For i = 0 To UBound(aIP)
                If aIP(i) = Request.ServerVariables("REMOTE_HOST") Then
                    isBanIP = True
                    Exit For
                End If
            Next
        End If

        If Session("LOGIN_FAIL_COUNT") > 3 Or isBanIP Then
            Me.LoginButton.Enabled = False
            Me.lblError.Text = "Excess Max number retry"
            Me.lblError.Visible = True
        End If

    End Sub

    Protected Sub LoginButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginButton.Click

        If Session("LOGIN_FAIL_COUNT") > 3 Or isBanIP Then
            Me.LoginButton.Enabled = False
            Me.lblError.Text = "Excess Max number retry"
            Me.lblError.Visible = True
        Else
            If Me.txtMISISN.Text.Length <> 8 Then
                Me.lblError.Text = "Invalid Login ID, min 8 number"
                Me.lblError.Visible = True
            ElseIf Me.txtPassword.Text.Length < 7 Then
                Me.lblError.Text = "Invalid Login Password, min 8 character"
                Me.lblError.Visible = True
            Else
                If isValidLogin("65" & txtMISISN.Text, txtPassword.Text) Then
                    If Request.ServerVariables("HTTP_REFERER").ToUpper.Contains("LOGIN") Then
                        Response.Redirect("~/Agent/Agent_Search.aspx")
                    Else
                        Response.Redirect(Request.ServerVariables("HTTP_REFERER"))
                    End If
                Else
                    Me.lblError.Text = "Login and password not match!"
                    Me.lblError.Visible = True
                End If
            End If
        End If

    End Sub

    Private Function isValidLogin(ByVal sLogin As String, ByVal sPassword As String) As Boolean

        Dim sSQL As String = ""
        Dim oConn As New SqlConnection(ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString)
        Dim oCmd As New SqlCommand
        Dim oDR As SqlDataReader = Nothing
        Dim sAgentID As String
        Dim sName As String = ""
        isValidLogin = False

        Try
            'Response.Write(sLogin)
            'Response.Write(sPassword)
            oConn.Open()
            oCmd = oConn.CreateCommand
            oCmd.Connection = oConn
            sSQL = "SELECT am.AgentID, ai.Name, ai.Retailer FROM AgentMSISDN am , AgentInfo ai WHERE am.agentid=ai.agentid AND am.MSISDN=@MSISDN AND am.PASSWORD=@PASSWORD AND am.STATUS=@STATUS AND ai.Retailer=@RETAILER "
            oCmd.CommandText = sSQL

            With oCmd.Parameters
                .Clear()
                .AddWithValue("@MSISDN", sLogin)
                .AddWithValue("@PASSWORD", sPassword)
                .AddWithValue("@STATUS", STATUS_ACTIVE)
                .AddWithValue("@RETAILER", "yes")
            End With
            oDR = oCmd.ExecuteReader
            If oDR.Read Then
                sAgentID = oDR.Item("AgentID")
                sName = oDR.Item("Name")
                Session("AGENT_ID") = sAgentID
                Session("AGENT_NAME") = sName
                Session("AGENT_MSISDN") = sLogin
                Session("AGENT_RETAILER") = "yes"
                isValidLogin = True
            Else
                Session("LOGIN_FAIL_COUNT") = Session("LOGIN_FAIL_COUNT") + 1
            End If

            If Session("LOGIN_FAIL_COUNT") = 5 Then
                Application("LOGIN_FAIL_IPADDRESS") = Application("LOGIN_FAIL_IPADDRESS") & ":" & Request.ServerVariables("REMOTE_HOST")
            End If

            oConn.Close()

        Catch ex As Exception
            isValidLogin = False
            Response.Write("getMaxPostRobinq [" & ex.Message & "]" & ex.StackTrace)
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

    End Function


End Class
