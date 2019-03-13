Imports System.Data.SqlClient
Imports WebItopz.CommonItop
Partial Class Submaster_Admin_CustomerList
	Inherits System.Web.UI.Page
	Private Const STATUS_ACTIVE = "ACTIVE"
	Private Const MT_MSG = "Welcome! Your AgentID: <AgentID> is Successfully Registered! SMS Gateway: 91960600 Web: www.eloadsg.com ID: HpNo. PW: 12345678 Hotline: 3151 8909"

	Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
		Me.lblErrorGrid.Text = ""
	End Sub


	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Response.Redirect("~/submaster/submaster_login.aspx")
		If Session("AGENT_ID") = "" Then
			Response.Redirect("~/submaster/submaster_login.aspx")
		End If
	End Sub

	Private Function UpdateAgentInfo(ByVal sHPNo As String, ByVal sAgentID As String) As Boolean

		Dim oConn As New SqlConnection
		Dim oCmd As New SqlCommand
		'Dim oDR As SqlDataReader
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""

		UpdateAgentInfo = False

		Try
			sSQL = "UPDATE AgentInfo SET HPNo=@HPNo WHERE AgentID=@AgentID Update AgentMSISDN Set MSISDN = @HPNo Where (AgentID = @AgentID)"

			oConn = New SqlConnection()
			oConn.ConnectionString =
						ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

			oCmd = New SqlCommand
			oCmd.CommandText = sSQL
			oCmd.Connection = oConn
			oCmd.Connection.Open()

			oCmd.Parameters.Clear()
			oCmd.Parameters.Add(New SqlParameter("@HPNo", sHPNo))
			oCmd.Parameters.Add(New SqlParameter("@AgentID", sAgentID))

			oCmd.ExecuteNonQuery()
			UpdateAgentInfo = True


		Catch ex As Exception
			UpdateAgentInfo = False
			lblErrorGrid.Text = "Error Occurred. Please contact administrator." & ex.Message
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
	Private Function GetAgentID() As String

		Dim oConn As New SqlConnection
		Dim oCmd As New SqlCommand
		Dim oDR As SqlDataReader
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""

		Try
			sSQL = "SELECT top 1 AgentID FROM AgentInfo " &
									 "WHERE Status=@Status Order by AgentID desc"

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
				GetAgentID = oDR.Item("AgentID")
			Else
				GetAgentID = ""
			End If

			oDR.Close()


		Catch ex As Exception
			GetAgentID = ""
			lblErrorGrid.Text = "Error Occurred. Please contact administrator." & ex.Message
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

	Private Function GetHPNo(ByVal sAgentID As String) As String

		Dim oConn As New SqlConnection
		Dim oCmd As New SqlCommand
		Dim oDR As SqlDataReader
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""

		Try
			sSQL = "SELECT HPNo FROM AgentInfo " &
									 "WHERE Status=@Status and AgentID=@AgentID     "

			oConn = New SqlConnection()
			oConn.ConnectionString =
						ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

			oCmd = New SqlCommand
			oCmd.CommandText = sSQL
			oCmd.Connection = oConn
			oCmd.Connection.Open()

			oCmd.Parameters.Clear()
			oCmd.Parameters.Add(New SqlParameter("@Status", STATUS_ACTIVE))
			oCmd.Parameters.Add(New SqlParameter("@AgentID", sAgentID))
			oDR = oCmd.ExecuteReader

			If (oDR.Read) Then
				GetHPNo = oDR.Item("HPNo")
			Else
				GetHPNo = ""
			End If

			oDR.Close()


		Catch ex As Exception
			GetHPNo = ""
			lblErrorGrid.Text = "Error Occurred. Please contact administrator." & ex.Message
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


	Private Function CheckHPNo(ByVal sHPNo As String, Optional ByVal sAgentID As String = "") As Boolean

		Dim oConn As New SqlConnection
		Dim oCmd As New SqlCommand
		Dim oDR As SqlDataReader
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""
		CheckHPNo = False

		Try

			If sAgentID <> "" Then
				sSQL = "SELECT HPNo FROM AgentInfo " &
										 "WHERE HPNo=@HPNo and AgentID<>@AgentID"
			Else
				sSQL = "SELECT HPNo FROM AgentInfo " &
											 "WHERE HPNo=@HPNo"
			End If

			oConn = New SqlConnection()
			oConn.ConnectionString =
						ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

			oCmd = New SqlCommand
			oCmd.CommandText = sSQL
			oCmd.Connection = oConn
			oCmd.Connection.Open()

			oCmd.Parameters.Clear()
			oCmd.Parameters.Add(New SqlParameter("@HPNo", sHPNo))
			oCmd.Parameters.Add(New SqlParameter("@AgentID", sAgentID))
			oDR = oCmd.ExecuteReader
			If (oDR.Read) Then
				CheckHPNo = True
			End If

			oDR.Close()

		Catch ex As Exception
			CheckHPNo = False
			lblErrorGrid.Text = "Error Occurred. Please contact administrator." & ex.Message
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


	Private Function InsertMT(ByVal sMSISDN As String, ByVal sMsg As String, Optional ByVal sAgentId As String = "") As Boolean

		Dim sSQL As String = ""
		Dim oCmd As SqlCommand = Nothing
		Dim sLocalMTID As String
		Dim oConn As New SqlConnection
		Dim sRobin As String = "1"

		InsertMT = True

		Try
			sLocalMTID = Format(Now, "yyyyMMddHHmmss") & Now.Millisecond.ToString.PadLeft(3, "0")

			oConn = New SqlConnection()
			oConn.ConnectionString =
						ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

			oCmd = New SqlCommand
			oCmd.CommandText = sSQL
			oCmd.Connection = oConn
			oCmd.Connection.Open()

			sSQL = "INSERT INTO TxOut (LocalMTID, LocalMOID, MSISDN, AgentID, MessageOut, Telco, Robin, Status) " &
										"VALUES (@LocalMTID, @LocalMOID, @MSISDN, @AgentID, @MessageOut, @Telco, @Robin, @Status) "

			oCmd.CommandText = sSQL
			With oCmd.Parameters
				.Clear()
				.AddWithValue("@LocalMTID", sLocalMTID)
				.AddWithValue("@LocalMOID", "")
				.AddWithValue("@MSISDN", sMSISDN)
				.AddWithValue("@AgentID", sAgentId)
				.AddWithValue("@MessageOut", sMsg)
				.AddWithValue("@Telco", "")
				.AddWithValue("@Robin", sRobin)
				.AddWithValue("@Status", "PENDING")
			End With
			oCmd.ExecuteNonQuery()

		Catch ex As Exception
			InsertMT = False
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



	Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating

		Dim lblAgentID As Label = GridView1.Rows(e.RowIndex).FindControl("lblAgentID")
		Dim tHPNo As TextBox = GridView1.Rows(e.RowIndex).FindControl("tHPNo")


		Dim sAgentID As String = lblAgentID.Text
		Dim sHPNo As String = tHPNo.Text.Trim.ToUpper
		Dim oCommon As New Common
		Dim sMSISDN As String = tHPNo.Text
		Dim sMsg As String = MT_MSG

		sMsg = sMsg.Replace("<AgentID>", sAgentID)
		sMsg = sMsg.Replace("<HPNo>", sHPNo)
		sMsg = sMsg.Replace("<DateTime>", Now())

		If sHPNo = "" Then
			Me.lblErrorGrid.Text = "Invalid HPNo!"
		ElseIf Not IsNumeric(sHPNo) Then
			Me.lblErrorGrid.Text = "Invalid HP Number only"
		Else
			If CheckHPNo(sHPNo, sAgentID) Then
				Me.lblErrorGrid.Text = "HPNO already exits!"
			ElseIf UpdateAgentInfo(sHPNo, sAgentID) Then
				If GetHPNo(sAgentID) <> sHPNo Then
				ElseIf InsertMT(sMSISDN, sMsg, sAgentID) Then
				End If
				Me.lblErrorGrid.Text = "Update Agent Successfully!"
			Else
				Me.lblErrorGrid.Text = "Fail to Update Agent!"
			End If
		End If
		Me.GridView1.DataBind()



	End Sub

End Class
