Imports System.Data.SqlClient

Partial Class Submaster_ProductInfo
	Inherits System.Web.UI.Page

	Private Const STATUS_ACTIVE = "ACTIVE"

	Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
		Me.lblErrorGrid.Text = ""
	End Sub


	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Response.Redirect("~/submaster/submaster_login.aspx")
		If Session("AGENT_ID") = "" Then
			Response.Redirect("~/submaster/submaster_login.aspx")
		End If
		'Me.lblErrorMsg.Text = ""
		'Me.lblBalance.Text = ""
		Me.lblErrorMsg.Text = ""
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

	Private Function GetProductID() As String

		Dim oConn As New SqlConnection
		Dim oCmd As New SqlCommand
		Dim oDR As SqlDataReader
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""

		Try
			sSQL = "SELECT top 1 ProductID FROM ProductInfo " &
									 "WHERE Status=@Status Order by ProductID desc"

			oConn = New SqlConnection()
			oConn.ConnectionString =
						ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

			oCmd = New SqlCommand
			oCmd.CommandText = sSQL
			oCmd.Connection = oConn
			oCmd.Connection.Open()

			oCmd.Parameters.Clear()
			oCmd.Parameters.Add(New SqlParameter("@Status", STATUS_ACTIVE))
			oDR = oCmd.ExecuteReader

			If (oDR.Read) Then
				GetProductID = oDR.Item("ProductID")
			Else
				GetProductID = ""
			End If

			oDR.Close()


		Catch ex As Exception
			GetProductID = ""
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

	Private Function GetDiscount(ByVal sProductID As String) As String

		Dim oConn As New SqlConnection
		Dim oCmd As New SqlCommand
		Dim oDR As SqlDataReader
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""

		Try
			sSQL = "SELECT Top 1 Discount FROM ProductInfo " &
									 "WHERE Status=@Status and ProductID=@ProductID     "

			oConn = New SqlConnection()
			oConn.ConnectionString =
						ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

			oCmd = New SqlCommand
			oCmd.CommandText = sSQL
			oCmd.Connection = oConn
			oCmd.Connection.Open()

			oCmd.Parameters.Clear()
			oCmd.Parameters.Add(New SqlParameter("@Status", STATUS_ACTIVE))
			oCmd.Parameters.Add(New SqlParameter("@ProductID", sProductID))
			oDR = oCmd.ExecuteReader

			If (oDR.Read) Then
				GetDiscount = oDR.Item("Discount")
			Else
				GetDiscount = ""
			End If

			oDR.Close()


		Catch ex As Exception
			GetDiscount = ""
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

	Protected Sub btnAddTelco_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddTelco.Click
		If Me.txtTelco.Text = "" Then
			Me.lblErrorMsg.Text = "Invalid Telco!"
		ElseIf Me.txtKeyword.Text = "" Then
			Me.lblErrorMsg.Text = "Invalid Keyword!"
		ElseIf Not IsNumeric(Me.txtDiscount.Text) Then
			Me.lblErrorMsg.Text = "Invalid Discount!"
		ElseIf Not IsNumeric(Me.txtCost.Text) Then
			Me.lblErrorMsg.Text = "Invalid Cost!"
		Else
			If CheckKeyword(txtKeyword.Text) Then
				Me.lblErrorMsg.Text = "Keyword already exits!"
			ElseIf AddProduct(txtTelco.Text, txtKeyword.Text, txtDiscount.Text, txtCost.Text) Then
				Call InsertAgentProduct(GetProductID, txtDiscount.Text)
				Me.lblErrorMsg.Text = "Added Successfully!"
			Else
				Me.lblErrorMsg.Text = "Fail to add!"
			End If
		End If
		Me.GridView1.DataBind()

		'End If
	End Sub


	Private Function AddProduct(ByVal sTelco As String, ByVal sKeyword As String, ByVal sDiscount As String, ByVal sCost As String) As Boolean

		Dim oConn As New SqlConnection
		Dim oCmd As New SqlCommand
		'Dim oDR As SqlDataReader
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""

		AddProduct = False

		Try
			sSQL = "INSERT INTO ProductInfo (Telco,Keyword,Discount,Cost,Note) VALUES (@Telco,@Keyword,@Discount,@Cost,@Note)"

			oConn = New SqlConnection()
			oConn.ConnectionString =
						ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

			oCmd = New SqlCommand
			oCmd.CommandText = sSQL
			oCmd.Connection = oConn
			oCmd.Connection.Open()

			oCmd.Parameters.Clear()
			oCmd.Parameters.Add(New SqlParameter("@Telco", sTelco))
			oCmd.Parameters.Add(New SqlParameter("@Keyword", sKeyword))
			oCmd.Parameters.Add(New SqlParameter("@Discount", sDiscount))
			oCmd.Parameters.Add(New SqlParameter("@Cost", sCost))
			oCmd.Parameters.Add(New SqlParameter("@Note", ""))

			oCmd.ExecuteNonQuery()
			AddProduct = True


		Catch ex As Exception
			AddProduct = False
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

	Private Function CheckKeyword(ByVal sKeyword As String, Optional ByVal sProductID As String = "") As Boolean

		Dim oConn As New SqlConnection
		Dim oCmd As New SqlCommand
		Dim oDR As SqlDataReader
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""
		CheckKeyword = False

		Try

			If sProductID <> "" Then
				sSQL = "SELECT Keyword FROM ProductInfo " &
										 "WHERE Keyword=@Keyword and ProductID<>@ProductID"
			Else
				sSQL = "SELECT Keyword FROM ProductInfo " &
											 "WHERE Keyword=@Keyword"
			End If

			oConn = New SqlConnection()
			oConn.ConnectionString =
						ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

			oCmd = New SqlCommand
			oCmd.CommandText = sSQL
			oCmd.Connection = oConn
			oCmd.Connection.Open()

			oCmd.Parameters.Clear()
			oCmd.Parameters.Add(New SqlParameter("@Keyword", sKeyword))
			oCmd.Parameters.Add(New SqlParameter("@ProductID", sProductID))
			oDR = oCmd.ExecuteReader
			If (oDR.Read) Then
				CheckKeyword = True
			End If

			oDR.Close()

		Catch ex As Exception
			CheckKeyword = False
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


	Private Function InsertAgentProduct(ByVal sProductID As String, ByVal sDiscount As String) As Boolean

		Dim oConn As New SqlConnection
		Dim oConn1 As New SqlConnection
		Dim oCmd As New SqlCommand
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""
		Dim sSQLSelect As String = ""
		Dim oCmdSelect As New SqlCommand
		Dim oDRSelect As SqlDataReader

		InsertAgentProduct = False

		Try

			oConn = New SqlConnection()
			oConn.ConnectionString = ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString
			oConn.Open()

			oConn1 = New SqlConnection()
			oConn1.ConnectionString = ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString
			oConn1.Open()

			sSQLSelect = "SELECT AgentID, ParentAgentID FROM AgentInfo"
			oCmdSelect = New SqlCommand
			oCmdSelect.CommandText = sSQLSelect
			oCmdSelect.Connection = oConn
			oCmdSelect.Parameters.Clear()
			oDRSelect = oCmdSelect.ExecuteReader

			Dim i As Integer = 0
			Dim i2 As Integer = 0
			Dim i3 As Integer = 0

			While oDRSelect.Read()

				If oDRSelect.Item("ParentAgentID") <> 0 Then
					sSQL = "INSERT INTO AgentProduct (AgentID,ProductID,Discount) VALUES (@AgentId,@ProductID,@Discount)"
					oCmd = New SqlCommand
					oCmd.Connection = oConn1
					oCmd.CommandText = sSQL
					oCmd.Parameters.Clear()
					oCmd.Parameters.Add(New SqlParameter("@AgentID", oDRSelect.Item("AgentID")))
					oCmd.Parameters.Add(New SqlParameter("@ProductID", sProductID))
					oCmd.Parameters.Add(New SqlParameter("@Discount", 0))
					oCmd.ExecuteNonQuery()
					oCmd = Nothing
					i2 += 1
				Else
					sSQL = "INSERT INTO AgentProduct (AgentID,ProductID,Discount) VALUES (@AgentId,@ProductID,@Discount)"
					oCmd = New SqlCommand
					oCmd.Connection = oConn1
					oCmd.CommandText = sSQL
					oCmd.Parameters.Clear()
					oCmd.Parameters.Add(New SqlParameter("@AgentID", oDRSelect.Item("AgentID")))
					oCmd.Parameters.Add(New SqlParameter("@ProductID", sProductID))
					oCmd.Parameters.Add(New SqlParameter("@Discount", sDiscount))
					oCmd.ExecuteNonQuery()
					oCmd = Nothing
					i3 += 1
				End If

				i += 1
			End While

			oCmdSelect = Nothing
			oConn1.Close()
			oConn.Close()

			InsertAgentProduct = True


		Catch ex As Exception
			InsertAgentProduct = False
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


	Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating

		Dim lblProductID As Label = GridView1.Rows(e.RowIndex).FindControl("lblProductID")
		Dim tKeyword As TextBox = GridView1.Rows(e.RowIndex).FindControl("tKeyword")
		Dim tDiscount As TextBox = GridView1.Rows(e.RowIndex).FindControl("tDiscount")

		Dim sProductID As String = lblProductID.Text
		Dim sKeyword As String = tKeyword.Text.Trim.ToUpper
		Dim sDiscount As String = tDiscount.Text.Trim


		If sKeyword = "" Then
			Me.lblErrorGrid.Text = "Invalid Keyword!"
		ElseIf sDiscount = "" Then
			Me.lblErrorGrid.Text = "Invalid Discount!"
		ElseIf Not IsNumeric(sDiscount) Then
			Me.lblErrorGrid.Text = "Invalid Discount! ie:1"
		Else
			If CheckKeyword(sKeyword, sProductID) Then
				Me.lblErrorGrid.Text = "Keyword already exits!"
			ElseIf UpdateProduct(sProductID, sKeyword, sDiscount) Then
				If GetDiscount(sProductID) <> sDiscount Then
					Call UpdateAgentProduct(sProductID, sDiscount)
				End If
				Me.lblErrorGrid.Text = "UpdateProduct Successfully!"
			Else
				Me.lblErrorGrid.Text = "Fail to UpdateProduct!"
			End If
		End If
		Me.GridView1.DataBind()


	End Sub

	Private Function UpdateProduct(ByVal sProductID As String, ByVal sKeyword As String, ByVal sDiscount As String) As Boolean

		Dim oConn As New SqlConnection
		Dim oCmd As New SqlCommand
		'Dim oDR As SqlDataReader
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""

		UpdateProduct = False

		Try
			sSQL = "UPDATE ProductInfo SET Keyword=@Keyword,Discount=@Discount WHERE ProductID=@ProductID"

			oConn = New SqlConnection()
			oConn.ConnectionString =
						ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

			oCmd = New SqlCommand
			oCmd.CommandText = sSQL
			oCmd.Connection = oConn
			oCmd.Connection.Open()

			oCmd.Parameters.Clear()
			oCmd.Parameters.Add(New SqlParameter("@Keyword", sKeyword))
			oCmd.Parameters.Add(New SqlParameter("@Discount", sDiscount))
			oCmd.Parameters.Add(New SqlParameter("@ProductID", sProductID))

			oCmd.ExecuteNonQuery()
			UpdateProduct = True


		Catch ex As Exception
			UpdateProduct = False
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

	Private Function UpdateAgentProduct(ByVal sProductID As String, ByVal sDiscount As String) As Boolean

		Dim oConn As New SqlConnection
		Dim oConn1 As New SqlConnection

		Dim oCmd As New SqlCommand
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""
		Dim sSQLSelect As String = ""
		Dim oCmdSelect As New SqlCommand
		Dim oDRSelect As SqlDataReader

		UpdateAgentProduct = False

		Try

			oConn = New SqlConnection()
			oConn.ConnectionString = ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString
			oConn.Open()

			oConn1 = New SqlConnection()
			oConn1.ConnectionString = ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString
			oConn1.Open()


			sSQLSelect = "SELECT a.AgentID,  b.Discount, b.ProductID FROM AgentInfo AS a INNER JOIN AgentProduct AS b ON a.AgentID = b.AgentID  WHERE a.ParentAgentID = '0' AND b.ProductID = '" & sProductID & "'"
			oCmdSelect = New SqlCommand
			oCmdSelect.CommandText = sSQLSelect
			oCmdSelect.Connection = oConn
			oCmdSelect.Parameters.Clear()
			oDRSelect = oCmdSelect.ExecuteReader

			While oDRSelect.Read

				If oDRSelect.Item("Discount") <> sDiscount Then
					sSQL = "UPDATE AgentProduct SET Discount=@Discount WHERE ProductID=@ProductID and AgentID=@AgentID"
					oCmd = New SqlCommand
					oCmd.Connection = oConn1
					oCmd.CommandText = sSQL
					oCmd.Parameters.Clear()
					oCmd.Parameters.Add(New SqlParameter("@AgentID", oDRSelect.Item("AgentID")))
					oCmd.Parameters.Add(New SqlParameter("@ProductID", sProductID))
					oCmd.Parameters.Add(New SqlParameter("@Discount", sDiscount))
					oCmd.ExecuteNonQuery()
					oCmd = Nothing
				End If

			End While
			oCmdSelect = Nothing
			oConn1.Close()
			oConn.Close()

			UpdateAgentProduct = True


		Catch ex As Exception
			UpdateAgentProduct = False
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
