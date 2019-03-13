Imports System.Data.SqlClient
Partial Class Submaster_EditDiscount
	Inherits System.Web.UI.Page

	Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
		'Response.Redirect("~/submaster/submaster_login.aspx")
		If Session("AGENT_ID") = "" Then
			Response.Redirect("~/submaster/submaster_login.aspx")
		End If
	End Sub


	Protected Sub GridView1_RowUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdatedEventArgs) Handles GridView1.RowUpdated
		If VerifyPrecentage(Session("DEALER_ID"), Session("UPDATE_AGENTID")) Then
			'Response.Write("UPDATE DONE SUCCESS")
		Else
			'Response.Write("UPDATE DONE Error")
		End If
		Session("UPDATE_AGENTID") = Nothing
	End Sub

	Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating
		Dim row As Label = GridView1.Rows(e.RowIndex).FindControl("Label1")
		'Response.Write(row.Text)
		Session("UPDATE_AGENTID") = row.Text
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

	Private Function VerifyPrecentage(ByVal sDealerID As String, ByVal sAgentID As String) As Boolean

		Dim oConn As New SqlConnection
		Dim oCmd As New SqlCommand
		Dim oDR As SqlDataReader
		Dim sSQL As String = ""
		VerifyPrecentage = False

		Try
			sSQL = "VerifyPrecentage"
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
			oDR = oCmd.ExecuteReader()
			VerifyPrecentage = True
			oDR.Close()
			oDR = Nothing

		Catch ex As Exception
			VerifyPrecentage = False
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
