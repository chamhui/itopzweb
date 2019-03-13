
Imports System.Data.SqlClient

Partial Class Admin_AgentMSISDN
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("DEALER_ID") = "" Then
            Response.Redirect("~/Dealer/Login.aspx")
        End If

        Me.lblErrorMsg.Text = ""
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If Me.txtAgentId1.Text = "" Then
            Me.lblErrorMsg.Text = "Invalid AgentId!"
        ElseIf Me.txtMSISDN.Text = "" Or Me.txtMSISDN.Text.Length <> 8 Or Not IsNumeric(Me.txtMSISDN.Text) Then
            Me.lblErrorMsg.Text = "Invalid MSISDN!"
        Else
            If CheckAgentUnderDealer(txtAgentId1.Text, Session("DEALER_ID")) Then
                If CheckMSISDN("65" & txtMSISDN.Text) Then
                    Me.lblErrorMsg.Text = "MSISDN already exits"
                Else
                    If AddMSISDN(txtAgentId1.Text, "65" & txtMSISDN.Text) Then
                        Me.lblErrorMsg.Text = "Added Successfully"
                    Else
                        Me.lblErrorMsg.Text = "Fail to add."
                    End If
                End If
            Else
                Me.lblErrorMsg.Text = "Agent not under you."
            End If
            Me.GridView1.DataBind()

        End If
    End Sub


    Private Function AddMSISDN(ByVal sAgentId As String, ByVal sMSISDN As String) As Boolean

        Dim oConn As New SqlConnection
        Dim oCmd As New SqlCommand
        Dim oDR As SqlDataReader = Nothing
        Dim bIsValid As Boolean = True
        Dim sSQL As String = ""

        AddMSISDN = False

        Try
            sSQL = "INSERT INTO AgentMSISDN (AgentId,MSISDN,ReplyFlag) VALUES (@AgentId,@MSISDN,@ReplyFlag)"

            oConn = New SqlConnection()
            oConn.ConnectionString = _
            ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

            oCmd = New SqlCommand
            oCmd.CommandText = sSQL
            oCmd.Connection = oConn
            oCmd.Connection.Open()

            oCmd.Parameters.Clear()
            oCmd.Parameters.Add(New SqlParameter("@AgentId", sAgentId))
            oCmd.Parameters.Add(New SqlParameter("@MSISDN", sMSISDN))
            oCmd.Parameters.Add(New SqlParameter("@ReplyFlag", "1"))

            oCmd.ExecuteNonQuery()
            AddMSISDN = True


        Catch ex As Exception
            AddMSISDN = False
            lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message
        Finally
            If (Not oCmd Is Nothing) Then
                oCmd.Dispose()
                oCmd = Nothing
            End If
            If Not oConn Is Nothing Then
                If oConn.State = Data.ConnectionState.Open Then
                    oConn.Close()
                End If
                oConn.Dispose()
                oConn = Nothing
            End If
        End Try
    End Function

    Private Function CheckAgentUnderDealer(ByVal sAgentID As String, ByVal sParentAgentID As String) As Boolean

        Dim oConn As New SqlConnection
        Dim oCmd As New SqlCommand
        Dim oDR As SqlDataReader
        Dim bIsValid As Boolean = True
        Dim sSQL As String = ""
        CheckAgentUnderDealer = False

        Try
            sSQL = "SELECT AgentID FROM AgentInfo " & _
                   "WHERE AgentID=@AgentID and ParentAgentID=@ParentAgentID "

            oConn = New SqlConnection()
            oConn.ConnectionString = _
            ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

            oCmd = New SqlCommand
            oCmd.CommandText = sSQL
            oCmd.Connection = oConn
            oCmd.Connection.Open()

            oCmd.Parameters.Clear()
            oCmd.Parameters.Add(New SqlParameter("@AgentID", sAgentID))
            oCmd.Parameters.Add(New SqlParameter("@ParentAgentID", sParentAgentID))
            oDR = oCmd.ExecuteReader

            If (oDR.Read) Then
                CheckAgentUnderDealer = True
            End If

            oDR.Close()

        Catch ex As Exception
            CheckAgentUnderDealer = False
            lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message
        Finally
            If (Not oCmd Is Nothing) Then
                oCmd.Dispose()
                oCmd = Nothing
            End If
            If Not oConn Is Nothing Then
                If oConn.State = Data.ConnectionState.Open Then
                    oConn.Close()
                End If
                oConn.Dispose()
                oConn = Nothing
            End If
        End Try
    End Function

    Private Function CheckMSISDN(ByVal sMSISDN As String) As Boolean

        Dim oConn As New SqlConnection
        Dim oCmd As New SqlCommand
        Dim oDR As SqlDataReader
        Dim bIsValid As Boolean = True
        Dim sSQL As String = ""
        CheckMSISDN = False

        Try
            sSQL = "SELECT MSISDN FROM AgentMSISDN " & _
                   "WHERE MSISDN=@MSISDN"

            oConn = New SqlConnection()
            oConn.ConnectionString = _
            ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

            oCmd = New SqlCommand
            oCmd.CommandText = sSQL
            oCmd.Connection = oConn
            oCmd.Connection.Open()

            oCmd.Parameters.Clear()
            oCmd.Parameters.Add(New SqlParameter("@MSISDN", sMSISDN))
            oDR = oCmd.ExecuteReader

            If (oDR.Read) Then
                CheckMSISDN = True
            End If

            oDR.Close()

        Catch ex As Exception
            CheckMSISDN = False
            lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message
        Finally
            If (Not oCmd Is Nothing) Then
                oCmd.Dispose()
                oCmd = Nothing
            End If
            If Not oConn Is Nothing Then
                If oConn.State = Data.ConnectionState.Open Then
                    oConn.Close()
                End If
                oConn.Dispose()
                oConn = Nothing
            End If
        End Try
    End Function



    Protected Sub txtAgentId_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAgentId.SelectedIndexChanged

        Me.txtAgentId1.Text = txtAgentId.SelectedValue
    End Sub



End Class
