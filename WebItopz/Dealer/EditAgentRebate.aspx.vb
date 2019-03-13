Imports System.Data.SqlClient
Imports WebItopz.CommonItopDealer

Partial Class DealerEditAgentRebate
    Inherits System.Web.UI.Page

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete

        Dim oComm As New Common

        If Session("DEALER_ID") = "" Then
            'Response.Redirect("~/Dealer/PleaseLogin.aspx")
        End If


        If oComm.VerifyChild(Session("DEALER_ID"), Request("AgentID")) Then
        Else
            Session.Abandon()
            Response.Redirect("~/Dealer/Login.aspx")
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


    Protected Sub GridView1_RowUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdatedEventArgs) Handles GridView1.RowUpdated
        If VerifyPrecentageRebate(Session("DEALER_ID"), Session("UPDATE_AGENTID"), Session("UPDATE_RebateID")) Then
            'Response.Write("UPDATE DONE SUCCESS")
        Else
            'Response.Write("UPDATE DONE Error")
        End If
        Session("UPDATE_AGENTID") = Nothing
        Session("UPDATE_RebateID") = Nothing
    End Sub

    Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating
        Dim lblAgentID As Label = GridView1.Rows(e.RowIndex).FindControl("lblAgentID")
        Dim lblRebateID As Label = GridView1.Rows(e.RowIndex).FindControl("lblRebateID")
        Session("UPDATE_AGENTID") = lblAgentID.Text
        Session("UPDATE_RebateID") = lblRebateID.Text
    End Sub

    Private Function VerifyPrecentageRebate(ByVal sDealerID As String, ByVal sAgentID As String, ByVal sRebateID As String) As Boolean

        Dim oConn As New SqlConnection
        Dim oCmd As New SqlCommand
        Dim oDR As SqlDataReader
        Dim sSQL As String = ""
        VerifyPrecentageRebate = False

        Try
            sSQL = "VerifyPrecentageRebate"
            oConn = New SqlConnection()
            oConn.ConnectionString = ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString
            oCmd = New SqlCommand
            oCmd.CommandText = sSQL
            oCmd.CommandType = Data.CommandType.StoredProcedure
            oCmd.Connection = oConn
            oCmd.Connection.Open()
            oCmd.Parameters.Clear()
            oCmd.Parameters.AddWithValue("@DealerID", sDealerID)
            oCmd.Parameters.AddWithValue("@AgentID", sAgentID)
            oCmd.Parameters.AddWithValue("@RebateID", sRebateID)
            oDR = oCmd.ExecuteReader()
            VerifyPrecentageRebate = True
            oDR.Close()
            oDR = Nothing

        Catch ex As Exception
            VerifyPrecentageRebate = False
            'Response.Write(ex.Message & ex.StackTrace)
            'lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message
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



End Class
