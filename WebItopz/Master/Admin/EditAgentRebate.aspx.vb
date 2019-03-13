Imports System.Data.SqlClient

Partial Class EditAgentRebate
	Inherits System.Web.UI.Page

	Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete

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
    'Private Function UpdateAgentProductRebate(ByVal sRebateID As String, ByVal sDenomination As String, ByVal sRebate As String) As Boolean

    '    Dim oConn As New SqlConnection
    '    Dim oConn1 As New SqlConnection
    '    Dim oCmd As New SqlCommand
    '    Dim bIsValid As Boolean = True
    '    Dim sSQL As String = ""
    '    Dim sSQLSelect As String = ""
    '    Dim oCmdSelect As New SqlCommand
    '    Dim oDRSelect As SqlDataReader

    '    UpdateAgentProductRebate = False

    '    Try

    '        oConn = New SqlConnection()
    '        oConn.ConnectionString = ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString
    '        oConn.Open()

    '        oConn1 = New SqlConnection()
    '        oConn1.ConnectionString = ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString
    '        oConn1.Open()

    '        sSQLSelect = "SELECT ID, Rebate FROM AgentProductRebate WHERE RebateID=@RebateID and (AgentID in (SELECT AgentID from AgentInfo where (ParentAgentID=@AgentID))"
    '        oCmdSelect = New SqlCommand
    '        oCmdSelect.CommandText = sSQLSelect
    '        oCmdSelect.Connection = oConn
    '        oCmdSelect.Parameters.Clear()
    '        oCmdSelect.Parameters.Add(New SqlParameter("@RebateID", sRebateID))
    '        oCmdSelect.Parameters.Add(New SqlParameter("@AgentID", oDRSelect.Item("AgentID")))

    '        oDRSelect = oCmdSelect.ExecuteReader

    '        While oDRSelect.Read

    '            If oDRSelect.Item("Rebate") > sRebate Then
    '                sSQL = "UPDATE AgentProductRebate SET Rebate=@Rebate WHERE ID=@ID"
    '                oCmd = New SqlCommand
    '                oCmd.Connection = oConn1
    '                oCmd.CommandText = sSQL
    '                oCmd.Parameters.Clear()
    '                oCmd.Parameters.Add(New SqlParameter("@Denomination", sDenomination))
    '                oCmd.Parameters.Add(New SqlParameter("@Rebate", sRebate))
    '                oCmd.Parameters.Add(New SqlParameter("@ID", oDRSelect.Item("ID")))
    '                oCmd.ExecuteNonQuery()
    '                oCmd = Nothing
    '            ElseIf sRebate > oDRSelect.Item("Rebate") Then
    '                sSQL = "UPDATE AgentProductRebate SET Rebate=@Rebate WHERE ID=@ID AND AgentID in (SELECT agentID from AGENTINFO)"
    '                oCmd = New SqlCommand
    '                oCmd.Connection = oConn1
    '                oCmd.CommandText = sSQL
    '                oCmd.Parameters.Clear()
    '                oCmd.Parameters.Add(New SqlParameter("@Denomination", sDenomination))
    '                oCmd.Parameters.Add(New SqlParameter("@Rebate", sRebate))
    '                oCmd.Parameters.Add(New SqlParameter("@ID", oDRSelect.Item("ID")))
    '                oCmd.ExecuteNonQuery()
    '                oCmd = Nothing
    '            End If

    '            sSQL = "UPDATE AgentProductRebate SET Denomination=@Denomination WHERE ID=@ID"
    '            oCmd = New SqlCommand
    '            oCmd.Connection = oConn1
    '            oCmd.CommandText = sSQL
    '            oCmd.Parameters.Clear()
    '            oCmd.Parameters.Add(New SqlParameter("@Denomination", sDenomination))
    '            oCmd.Parameters.Add(New SqlParameter("@ID", oDRSelect.Item("ID")))
    '            oCmd.ExecuteNonQuery()
    '            oCmd = Nothing


    '        End While
    '        oCmdSelect = Nothing
    '        oConn1.Close()
    '        oConn.Close()

    '        UpdateAgentProductRebate = True


    '    Catch ex As Exception
    '        UpdateAgentProductRebate = False
    '        lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message & ex.StackTrace
    '    Finally
    '        If (Not oCmd Is Nothing) Then
    '            oCmd.Dispose()
    '            oCmd = Nothing
    '        End If
    '        If Not oConn Is Nothing Then
    '            If oConn.State = Data.ConnectionState.Open Then
    '                oConn.Close()
    '            End If
    '            oConn.Dispose()
    '            oConn = Nothing
    '        End If
    '        If Not oConn1 Is Nothing Then
    '            If oConn1.State = Data.ConnectionState.Open Then
    '                oConn1.Close()
    '            End If
    '            oConn1.Dispose()
    '            oConn1 = Nothing
    '        End If
    '    End Try
    'End Function


End Class
