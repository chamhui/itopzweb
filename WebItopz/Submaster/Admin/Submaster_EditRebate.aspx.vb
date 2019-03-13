Imports System.Data.SqlClient

Partial Class Submaster_EditRebate
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
	Protected Sub btnEditRebate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEditRebate.Click

		Dim sDenomination As String = DDLDenomination.SelectedValue
		Dim sParentAgentID As String = DDLParentAgentID.SelectedValue
		Dim sRebate As String = DDLRebate.Text.Trim

		If Me.DDLParentAgentID.SelectedValue = "" Then
			Me.lblErrorMsg2.Text = "Invalid Parent Agent ID!"
		ElseIf Me.DDLDenomination.SelectedValue = "" Then
			Me.lblErrorMsg2.Text = "Invalid Denomination!"
		ElseIf Me.DDLRebate.Text = "" Then
			Me.lblErrorMsg2.Text = "Empty Rebate!"
		ElseIf Not IsNumeric(Me.DDLRebate.Text) Then
			Me.lblErrorMsg2.Text = "Invalid Rebate! "
		ElseIf (Me.DDLRebate.Text) < -30 Or (Me.DDLRebate.Text) > 99 Then
			Me.lblErrorMsg2.Text = "Invalid Rebate Amount (Max 99%)! "
		Else
			If UpdateDealerDownlineProductRebate(Session("ProductID"), sDenomination, sRebate, sParentAgentID) Then
				Me.lblErrorMsg2.Text = "Edited Successfully!"
			Else
				Me.lblErrorMsg2.Text = "Fail to add!"
			End If
		End If
		Me.GridView1.DataBind()
	End Sub
	Protected Sub btnAddRebate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddRebate.Click
		If Me.txtDenomination.Text = "" Then
			Me.lblErrorMsg.Text = "Invalid Denomination!"
		ElseIf Me.txtRebate.Text = "" Then
			Me.lblErrorMsg.Text = "Empty Rebate!"
		ElseIf Not IsNumeric(Me.txtRebate.Text) Then
			Me.lblErrorMsg.Text = "Invalid Rebate! "
		ElseIf (Me.txtRebate.Text) < -30 Or (Me.txtRebate.Text) > 99 Then
			Me.lblErrorMsg.Text = "Invalid Rebate Amount (Max 99%)! "
		Else
			If CheckDenomination(Session("ProductID"), txtDenomination.Text) Then
				Me.lblErrorMsg.Text = "Denomination already exits!"
			ElseIf AddRebate(Session("ProductID"), txtDenomination.Text, txtRebate.Text) Then
				Call InsertAgentProductRebate(Session("ProductID"), GetRebateID, txtDenomination.Text, txtRebate.Text)
				Me.lblErrorMsg.Text = "Added Successfully!"
			Else
				Me.lblErrorMsg.Text = "Fail to add!"
			End If
		End If
		Me.GridView1.DataBind()
	End Sub

	Private Function AddRebate(ByVal sProductID As String, ByVal sDenomination As String, ByVal sRebate As String) As Boolean

		Dim oConn As New SqlConnection
		Dim oCmd As New SqlCommand
		'Dim oDR As SqlDataReader
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""

		AddRebate = False

		Try
			sSQL = "INSERT INTO ProductRebate (ProductID,Denomination,Rebate) VALUES (@ProductID,@Denomination,@Rebate)"

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
			oCmd.Parameters.Add(New SqlParameter("@Rebate", sRebate))

			oCmd.ExecuteNonQuery()
			AddRebate = True


		Catch ex As Exception
			AddRebate = False
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

	Private Function CheckDenomination(ByVal sProductID As String, ByVal sDenomination As String, Optional ByVal sRebateID As String = "") As Boolean

		Dim oConn As New SqlConnection
		Dim oCmd As New SqlCommand
		Dim oDR As SqlDataReader
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""
		CheckDenomination = False

		Try
			If sRebateID <> "" Then
				sSQL = "SELECT [Denomination] FROM [ProductRebate] " &
											 "WHERE [Denomination]=@Denomination and ProductID=@ProductID and RebateID<>@RebateID"
			Else
				sSQL = "SELECT [Denomination] FROM [ProductRebate] " &
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
			oCmd.Parameters.Add(New SqlParameter("@RebateID", sRebateID))
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



	Private Function InsertAgentProductRebate(ByVal sProductID As String, ByVal sRebateID As String, ByVal sDenomination As String, ByVal sRebate As String) As Boolean

		Dim oConn As New SqlConnection
		Dim oConn1 As New SqlConnection
		Dim oCmd As New SqlCommand
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""
		Dim sSQLSelect As String = ""
		Dim oCmdSelect As New SqlCommand
		Dim oDRSelect As SqlDataReader

		InsertAgentProductRebate = False

		Try

			oConn = New SqlConnection()
			oConn.ConnectionString = ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString
			oConn.Open()

			oConn1 = New SqlConnection()
			oConn1.ConnectionString = ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString
			oConn1.Open()

			sSQLSelect = "SELECT AgentID FROM AgentInfo"
			oCmdSelect = New SqlCommand
			oCmdSelect.CommandText = sSQLSelect
			oCmdSelect.Connection = oConn
			oCmdSelect.Parameters.Clear()
			'oCmdSelect.Parameters.Add(New SqlParameter("@LocalMOID", sLocalMOID))
			oDRSelect = oCmdSelect.ExecuteReader

			While oDRSelect.Read

				sSQL = "INSERT INTO AgentProductRebate (AgentID,ProductID,RebateID,Denomination,Rebate) VALUES (@AgentId,@ProductID,@RebateID,@Denomination,@Rebate)"
				oCmd = New SqlCommand
				oCmd.Connection = oConn1
				oCmd.CommandText = sSQL
				oCmd.Parameters.Clear()
				oCmd.Parameters.Add(New SqlParameter("@AgentID", oDRSelect.Item("AgentID")))
				oCmd.Parameters.Add(New SqlParameter("@ProductID", sProductID))
				oCmd.Parameters.Add(New SqlParameter("@RebateID", sRebateID))
				oCmd.Parameters.Add(New SqlParameter("@Denomination", sDenomination))
				oCmd.Parameters.Add(New SqlParameter("@Rebate", sRebate))
				oCmd.ExecuteNonQuery()
				oCmd = Nothing

			End While
			oCmdSelect = Nothing
			oConn1.Close()
			oConn.Close()

			InsertAgentProductRebate = True


		Catch ex As Exception
			InsertAgentProductRebate = False
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

		Dim lblRebateID As Label = GridView1.Rows(e.RowIndex).FindControl("lblRebateID")
		Dim tDenomination As TextBox = GridView1.Rows(e.RowIndex).FindControl("txtDenomination")
		Dim tRebate As TextBox = GridView1.Rows(e.RowIndex).FindControl("txtRebate")

		Dim sRebateID As String = lblRebateID.Text
		Dim sDenomination As String = tDenomination.Text.Trim
		Dim sRebate As String = tRebate.Text.Trim

		'Response.Write(sDenomination.Text)
		If sDenomination = "" Then
			Me.lblErrorMsg.Text = "Invalid Denomination!"
		ElseIf sRebate = "" Then
			Me.lblErrorMsg.Text = "Empty Rebate!"
		ElseIf Not IsNumeric(sRebate) Then
			Me.lblErrorMsg.Text = "Invalid Rebate! "
		ElseIf (sRebate) < -30 Or (sRebate) > 99 Then
			Me.lblErrorMsg.Text = "Invalid Rebate Amount (Max 99%)! "
		Else
			If CheckDenomination(Session("ProductID"), sDenomination, sRebateID) Then
				Me.lblErrorMsg.Text = "Denomination already exits!"
			ElseIf UpdateProductRebate(sRebateID, sDenomination, sRebate) Then
				Call UpdateAgentProductRebate(sRebateID, sDenomination, sRebate)
				Me.lblErrorMsg.Text = "Update Successfully!"
			Else
				Me.lblErrorMsg.Text = "Update fail!"
			End If
			'Updating(lblRebateID.Text, sDenomination, sRebate)
		End If




	End Sub

	Private Function UpdateProductRebate(ByVal sRebateID As String, ByVal sDenomination As String, ByVal sRebate As String) As Boolean

		Dim oConn As New SqlConnection
		Dim oCmd As New SqlCommand
		'Dim oDR As SqlDataReader
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""

		UpdateProductRebate = False

		Try
			sSQL = "UPDATE ProductRebate SET Denomination=@Denomination,Rebate=@Rebate WHERE RebateID=@RebateID"

			oConn = New SqlConnection()
			oConn.ConnectionString =
						ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

			oCmd = New SqlCommand
			oCmd.CommandText = sSQL
			oCmd.Connection = oConn
			oCmd.Connection.Open()

			oCmd.Parameters.Clear()
			oCmd.Parameters.Add(New SqlParameter("@RebateID", sRebateID))
			oCmd.Parameters.Add(New SqlParameter("@Denomination", sDenomination))
			oCmd.Parameters.Add(New SqlParameter("@Rebate", sRebate))

			oCmd.ExecuteNonQuery()
			UpdateProductRebate = True


		Catch ex As Exception
			UpdateProductRebate = False
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




	Private Function UpdateAgentProductRebate(ByVal sRebateID As String, ByVal sDenomination As String, ByVal sRebate As String) As Boolean

		Dim oConn As New SqlConnection
		Dim oConn1 As New SqlConnection
		Dim oCmd As New SqlCommand
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""
		Dim sSQLSelect As String = ""
		Dim oCmdSelect As New SqlCommand
		Dim oDRSelect As SqlDataReader

		UpdateAgentProductRebate = False

		Try

			oConn = New SqlConnection()
			oConn.ConnectionString = ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString
			oConn.Open()

			oConn1 = New SqlConnection()
			oConn1.ConnectionString = ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString
			oConn1.Open()

			sSQLSelect = "SELECT ID, Rebate FROM AgentProductRebate WHERE RebateID=@RebateID"
			oCmdSelect = New SqlCommand
			oCmdSelect.CommandText = sSQLSelect
			oCmdSelect.Connection = oConn
			oCmdSelect.Parameters.Clear()
			oCmdSelect.Parameters.Add(New SqlParameter("@RebateID", sRebateID))
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
					oCmd.Parameters.Add(New SqlParameter("@Denomination", sDenomination))
					oCmd.Parameters.Add(New SqlParameter("@Rebate", sRebate))
					oCmd.Parameters.Add(New SqlParameter("@ID", oDRSelect.Item("ID")))
					oCmd.ExecuteNonQuery()
					oCmd = Nothing
				End If

				sSQL = "UPDATE AgentProductRebate SET Denomination=@Denomination WHERE ID=@ID"
				oCmd = New SqlCommand
				oCmd.Connection = oConn1
				oCmd.CommandText = sSQL
				oCmd.Parameters.Clear()
				oCmd.Parameters.Add(New SqlParameter("@Denomination", sDenomination))
				oCmd.Parameters.Add(New SqlParameter("@ID", oDRSelect.Item("ID")))
				oCmd.ExecuteNonQuery()
				oCmd = Nothing

			End While
			oCmdSelect = Nothing
			oConn1.Close()
			oConn.Close()

			UpdateAgentProductRebate = True


		Catch ex As Exception
			UpdateAgentProductRebate = False
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
