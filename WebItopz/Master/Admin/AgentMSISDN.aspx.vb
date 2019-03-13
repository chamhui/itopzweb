
Imports System.Data.SqlClient
Imports System.Security.Cryptography

Partial Class Admin_AgentMSISDN
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
		Encrypt()

	End Sub

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Session("AGENT_ID") = "" Then
			Response.Redirect("~/Master/Login.aspx")
		End If

		Me.lblErrorMsg.Text = ""

		'Me.GridView1.DataBind()
		'If Session("SUPERADMIN") is false
		If (Session("SUPERADMIN") Is Nothing) Then
			If GridView1.Columns.Count > 0 Then
				'assuming your date-column is the 4.'
				GridView1.Columns(1).Visible = False
			Else
				GridView1.HeaderRow.Cells(1).Visible = True
				For Each gvr As GridViewRow In GridView1.Rows
					gvr.Cells(1).Visible = False
				Next
			End If
		End If
		Encrypt()
	End Sub
	Private Sub Encrypt()
		Dim sSQL As String = ""
		Dim oConn As New SqlConnection(ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString)
		Dim oCmd As New SqlCommand
		Dim oDR As SqlDataReader = Nothing
		Dim sAgentID As String
		Dim sName As String = ""
		'isValidLogin = False
		Dim lagent As New List(Of Agent)

		Try
			'Response.Write(sLogin)
			'Response.Write(sPassword)
			oConn.Open()
			oCmd = oConn.CreateCommand
			oCmd.Connection = oConn
			sSQL = "SELECT * from AgentMSISDN where len(Password)<50"
			oCmd.CommandText = sSQL

			oDR = oCmd.ExecuteReader
			While oDR.Read
				Dim tempa As New Agent
				tempa.ID = oDR.Item("ID")
				tempa.Password = oDR.Item("Password")
				lagent.Add(tempa)
			End While


		Catch ex As Exception
			'isValidLogin = False
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

		For Each tagent As Agent In lagent
			oConn = New SqlConnection(ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString)
			sSQL = "UPDATE AgentMSISDN SET Password = @PASSWORD WHERE ID = @ID;"


			oConn.Open()
			oCmd = New SqlCommand
			oCmd.CommandText = sSQL
			oCmd.Connection = oConn


			oCmd.Parameters.Clear()
			oCmd.Parameters.Add(New SqlParameter("@ID", tagent.ID))
			oCmd.Parameters.Add(New SqlParameter("@PASSWORD", ComputeSha256Hash(tagent.Password)))
			oCmd.ExecuteNonQuery()
			oCmd.Connection.Close()

		Next



	End Sub
	Private Shared Function ComputeSha256Hash(ByVal rawData As String) As String
		Using sha256Hash As SHA256 = SHA256.Create()
			Dim bytes As Byte() = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData))
			Dim builder As StringBuilder = New StringBuilder()

			For i As Integer = 0 To bytes.Length - 1
				builder.Append(bytes(i).ToString("x2"))
			Next

			Return builder.ToString()
		End Using
	End Function
	Public Class Agent
		Private _password As String
		Private _ID As Integer

		Public Property ID() As Integer
			Get
				Return _ID
			End Get
			Set(ByVal value As Integer)
				_ID = value
			End Set
		End Property


		Public Property Password() As String
			Get
				Return _password
			End Get
			Set(ByVal value As String)
				_password = value
			End Set
		End Property
	End Class
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
			sSQL = "INSERT INTO AgentMSISDN (AgentId,MSISDN,ReplyFlag,Password,Status) VALUES (@AgentId,@MSISDN,@ReplyFlag,'ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f','ACTIVE')"

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
