
Imports System.Data.SqlClient

Partial Class Submaster_Admin_AgentMSISDN
	Inherits System.Web.UI.Page

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

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Session("AGENT_ID") = "" Then
			Response.Redirect("~/submaster/submaster_login.aspx")
		End If
		SqlDataSource2.SelectCommand = "SELECT (convert(varchar(10),AgentID) +' '+Name) as Name,  [AgentID] FROM [AgentInfo] WHERE (Agentlvl like '" & Session("AGENT_AGENTLVL") & Session("AGENT_ID") & "|%') or AgentID=" & Session("AGENT_ID")
		Me.lblErrorMsg.Text = ""
	End Sub
	'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	'    If Session("AGENT_ID") = "" Then
	'        Response.Redirect("~/Master/Login.aspx")
	'    End If
	'End Sub

	Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
		If Me.txtAgentId1.Text = "" Then
			Me.lblErrorMsg.Text = "Invalid AgentId!"
		ElseIf Me.txtMSISDN.Text = "" Or Me.txtMSISDN.Text.Length <> 8 Or Not IsNumeric(Me.txtMSISDN.Text) Then
			Me.lblErrorMsg.Text = "Invalid MSISDN!"
		Else
			If CheckMSISDN("65" & txtMSISDN.Text) Then
				Me.lblErrorMsg.Text = "MSISDN already exits"
			Else
				If AddMSISDN(txtAgentId1.Text, "65" & txtMSISDN.Text) Then
					Me.lblErrorMsg.Text = "Added Successfully"
				Else
					Me.lblErrorMsg.Text = "Fail to add."
				End If
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
			oConn.ConnectionString =
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

	Private Function CheckMSISDN(ByVal sMSISDN As String) As Boolean

		Dim oConn As New SqlConnection
		Dim oCmd As New SqlCommand
		Dim oDR As SqlDataReader
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""
		CheckMSISDN = False

		Try
			sSQL = "SELECT MSISDN FROM AgentMSISDN " &
									 "WHERE MSISDN=@MSISDN"

			oConn = New SqlConnection()
			oConn.ConnectionString =
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
