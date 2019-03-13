Imports System.Data.SqlClient

Partial Class Submaster_EditMenuID
	Inherits System.Web.UI.Page


	Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
		Response.Redirect("~/submaster/submaster_login.aspx")
		If Session("AGENT_ID") = "" Then
			Response.Redirect("~/submaster/submaster_login.aspx")
		End If

		If Request("ProductID") <> "" Then
			Session("ProductID") = Request("ProductID")
			'Response.Write(Session("ProductID"))
		End If

		'Me.lblErrorMsg.Text = ""

	End Sub
	Protected Sub btnAddMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddMenu.Click
		If Me.txtDenomination.Text = "" Then
			Me.lblErrorMsg.Text = "Invalid Denomination!"
		ElseIf Me.txtMenuID.Text = "" Then
			Me.lblErrorMsg.Text = "Empty Menu ID!"
		ElseIf Not IsNumeric(Me.txtMenuID.Text) Then
			Me.lblErrorMsg.Text = "Invalid Menu ID! "
		Else
			If CheckDenomination(Session("ProductID"), txtDenomination.Text) Then
				Me.lblErrorMsg.Text = "Denomination already exits!"
			ElseIf AddMenu(Session("ProductID"), txtDenomination.Text, txtMenuID.Text) Then
				Me.lblErrorMsg.Text = "Added Successfully!"
			Else
				Me.lblErrorMsg.Text = "Fail to add!"
			End If
		End If
		Me.GridView1.DataBind()
	End Sub

	Private Function AddMenu(ByVal sProductID As String, ByVal sDenomination As String, ByVal sMenuID As String) As Boolean

		Dim oConn As New SqlConnection
		Dim oCmd As New SqlCommand
		'Dim oDR As SqlDataReader
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""

		AddMenu = False

		Try
			sSQL = "INSERT INTO NPNMenu (ProductID,Denomination,MenuID) VALUES (@ProductID,@Denomination,@MenuID)"

			oConn = New SqlConnection()
			oConn.ConnectionString =
						ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

			oCmd = New SqlCommand
			oCmd.CommandText = sSQL
			oCmd.Connection = oConn
			oCmd.Connection.Open()

			oCmd.Parameters.Clear()
			oCmd.Parameters.Add(New SqlParameter("@ProductID", sProductID))
			oCmd.Parameters.Add(New SqlParameter("@Denomination", sDenomination))
			oCmd.Parameters.Add(New SqlParameter("@Rebate", sMenuID))

			oCmd.ExecuteNonQuery()
			AddMenu = True


		Catch ex As Exception
			AddMenu = False
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

	Private Function CheckDenomination(ByVal sProductID As String, ByVal sDenomination As String, Optional ByVal sMenuID As String = "") As Boolean

		Dim oConn As New SqlConnection
		Dim oCmd As New SqlCommand
		Dim oDR As SqlDataReader
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""
		CheckDenomination = False

		Try
			If sMenuID <> "" Then
				sSQL = "SELECT [Denomination] FROM [NPNMenu] " &
											 "WHERE [Denomination]=@Denomination and ProductID=@ProductID and MenuID<>@MenuID"
			Else
				sSQL = "SELECT [Denomination] FROM [NPNMenu] " &
											 "WHERE [Denomination]=@Denomination and ProductID=@ProductID"
			End If

			oConn = New SqlConnection()
			oConn.ConnectionString =
						ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

			oCmd = New SqlCommand
			oCmd.CommandText = sSQL
			oCmd.Connection = oConn
			oCmd.Connection.Open()

			oCmd.Parameters.Clear()
			oCmd.Parameters.Add(New SqlParameter("@Denomination", sDenomination))
			oCmd.Parameters.Add(New SqlParameter("@ProductID", sProductID))
			oCmd.Parameters.Add(New SqlParameter("@MenuID", sMenuID))
			oDR = oCmd.ExecuteReader
			If (oDR.Read) Then
				CheckDenomination = True
			End If

			oDR.Close()

		Catch ex As Exception
			CheckDenomination = False
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

	Private Function GetRebateID() As String

		Dim oConn As New SqlConnection
		Dim oCmd As New SqlCommand
		Dim oDR As SqlDataReader
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""

		Try
			sSQL = "SELECT TOP 1 RebateID FROM ProductRebate " &
									 "Order by RebateID desc"

			oConn = New SqlConnection()
			oConn.ConnectionString =
						ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

			oCmd = New SqlCommand
			oCmd.CommandText = sSQL
			oCmd.Connection = oConn
			oCmd.Connection.Open()

			oCmd.Parameters.Clear()
			oDR = oCmd.ExecuteReader

			If (oDR.Read) Then
				GetRebateID = oDR.Item("RebateID")
			Else
				GetRebateID = ""
			End If

			oDR.Close()


		Catch ex As Exception
			GetRebateID = ""
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

	Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting

		Dim row As Label = GridView1.Rows(e.RowIndex).FindControl("lblRebateID")
		RemoveRebate(row.Text)

	End Sub


	Private Sub RemoveRebate(ByVal sRebateID As String)

		Dim oConn As New SqlConnection
		Dim oCmd As New SqlCommand
		' Dim oDR As SqlDataReader
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""

		Try
			sSQL = "DELETE FROM AgentProductRebate " &
									 "WHERE RebateID=@RebateID"
			oConn = New SqlConnection()
			oConn.ConnectionString =
						ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

			oCmd = New SqlCommand
			oCmd.CommandText = sSQL
			oCmd.Connection = oConn
			oCmd.Connection.Open()

			oCmd.Parameters.Clear()
			oCmd.Parameters.Add(New SqlParameter("@RebateID", sRebateID))
			oCmd.ExecuteNonQuery()

		Catch ex As Exception
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

	End Sub

	Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating

		'Dim lblMenuID As Label = GridView1.Rows(e.RowIndex).FindControl("lblMenuID")
		Dim tDenomination As TextBox = GridView1.Rows(e.RowIndex).FindControl("txtDenomination")
		Dim tMenuID As TextBox = GridView1.Rows(e.RowIndex).FindControl("txtMenuID")

		'Dim sMenuID As String = lblMenuID.Text
		Dim sDenomination As String = tDenomination.Text.Trim
		Dim sMenuID As String = tMenuID.Text.Trim

		'Response.Write(sDenomination.Text)
		If sDenomination = "" Then
			Me.lblErrorMsg.Text = "Invalid Denomination!"
		ElseIf sMenuID = "" Then
			Me.lblErrorMsg.Text = "Empty Menu ID!"
		ElseIf Not IsNumeric(sMenuID) Then
			Me.lblErrorMsg.Text = "Invalid Menu ID! "
		Else
			If UpdateMenuID(sDenomination, sMenuID) Then
				Me.lblErrorMsg.Text = "Update Successfully!"
			Else
				Me.lblErrorMsg.Text = "Update fail!"
			End If
			'Updating(lblRebateID.Text, sDenomination, sRebate)
		End If




	End Sub

	Private Function UpdateMenuID(ByVal sDenomination As String, ByVal sMenuID As String) As Boolean

		Dim oConn As New SqlConnection
		Dim oCmd As New SqlCommand
		'Dim oDR As SqlDataReader
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""

		UpdateMenuID = False

		Try
			sSQL = "UPDATE NPNMenu SET Denomination=@Denomination,MenuID=@MenuID WHERE MenuID=@MenuID"

			oConn = New SqlConnection()
			oConn.ConnectionString =
						ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

			oCmd = New SqlCommand
			oCmd.CommandText = sSQL
			oCmd.Connection = oConn
			oCmd.Connection.Open()

			oCmd.Parameters.Clear()
			oCmd.Parameters.Add(New SqlParameter("@Denomination", sDenomination))
			oCmd.Parameters.Add(New SqlParameter("@MenuID", sMenuID))

			oCmd.ExecuteNonQuery()
			UpdateMenuID = True


		Catch ex As Exception
			UpdateMenuID = False
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




	Private Function UpdateDealerDownlineProductRebate(ByVal sProductID As String, ByVal sDenomination As String, ByVal sRebate As String, ByVal sParentAgentID As String) As Boolean

		Dim oConn As New SqlConnection
		Dim oConn1 As New SqlConnection
		Dim oCmd As New SqlCommand
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""
		Dim sSQLSelect As String = ""
		Dim oCmdSelect As New SqlCommand
		Dim oDRSelect As SqlDataReader

		UpdateDealerDownlineProductRebate = False

		Try

			oConn = New SqlConnection()
			oConn.ConnectionString = ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString
			oConn.Open()

			oConn1 = New SqlConnection()
			oConn1.ConnectionString = ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString
			oConn1.Open()

			sSQLSelect = "SELECT ID, Rebate FROM AgentProductRebate WHERE Productid = @ProductID AND Denomination=@Denomination AND AgentID in (SELECT agentID from AGENTINFO WHERE ParentAgentID=@ParentAgentID)"
			oCmdSelect = New SqlCommand
			oCmdSelect.CommandText = sSQLSelect
			oCmdSelect.Connection = oConn
			oCmdSelect.Parameters.Clear()
			oCmdSelect.Parameters.Add(New SqlParameter("@ParentAgentID", sParentAgentID))
			oCmdSelect.Parameters.Add(New SqlParameter("@Denomination", sDenomination))
			oCmdSelect.Parameters.Add(New SqlParameter("@ProductID", sProductID))
			oDRSelect = oCmdSelect.ExecuteReader

			While oDRSelect.Read

				If oDRSelect.Item("Rebate") > sRebate Then
					sSQL = "UPDATE AgentProductRebate SET Rebate=@Rebate WHERE ID=@ID"
					oCmd = New SqlCommand
					oCmd.Connection = oConn1
					oCmd.CommandText = sSQL
					oCmd.Parameters.Clear()
					oCmd.Parameters.Add(New SqlParameter("@Denomination", sDenomination))
					oCmd.Parameters.Add(New SqlParameter("@Rebate", sRebate))
					oCmd.Parameters.Add(New SqlParameter("@ID", oDRSelect.Item("ID")))
					oCmd.ExecuteNonQuery()
					oCmd = Nothing
				ElseIf sRebate > oDRSelect.Item("Rebate") Then
					sSQL = "UPDATE AgentProductRebate SET Rebate=@Rebate WHERE ID=@ID AND AgentID in (SELECT agentID from AGENTINFO)"
					oCmd = New SqlCommand
					oCmd.Connection = oConn1
					oCmd.CommandText = sSQL
					oCmd.Parameters.Clear()
					oCmd.Parameters.Add(New SqlParameter("@Rebate", sRebate))
					oCmd.Parameters.Add(New SqlParameter("@ID", oDRSelect.Item("ID")))
					oCmd.ExecuteNonQuery()
					oCmd = Nothing
				End If

				sSQL = "UPDATE AgentProductRebate SET Rebate=@Rebate WHERE ID=@ID"
				oCmd = New SqlCommand
				oCmd.Connection = oConn1
				oCmd.CommandText = sSQL
				oCmd.Parameters.Clear()
				oCmd.Parameters.Add(New SqlParameter("@Rebate", sRebate))
				oCmd.Parameters.Add(New SqlParameter("@ID", oDRSelect.Item("ID")))
				oCmd.ExecuteNonQuery()
				oCmd = Nothing

			End While
			oCmdSelect = Nothing
			oConn1.Close()
			oConn.Close()

			UpdateDealerDownlineProductRebate = True


		Catch ex As Exception
			UpdateDealerDownlineProductRebate = False
			lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message & ex.StackTrace
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
			If Not oConn1 Is Nothing Then
				If oConn1.State = Data.ConnectionState.Open Then
					oConn1.Close()
				End If
				oConn1.Dispose()
				oConn1 = Nothing
			End If
		End Try
	End Function

End Class
