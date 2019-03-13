Imports System.Data.SqlClient

Partial Class Agent_EditAgentDiscount
	Inherits System.Web.UI.Page

	Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete

		If Session("AGENT_ID") = "" Then
			Response.Redirect("~/Agent/Agent_Login.aspx")
		End If

	End Sub




	Protected Sub GridView1_RowUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdatedEventArgs) Handles GridView1.RowUpdated
		If VerifyPrecentageRebate(Session("AGENT_ID"), Session("UPDATE_AGENTID"), Session("UPDATE_RebateID")) Then
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
