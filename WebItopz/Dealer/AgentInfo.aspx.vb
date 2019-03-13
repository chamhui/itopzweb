Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports WebItopz.CommonItopDealer

Partial Class Dealer_AgentInfo
	Inherits System.Web.UI.Page
	Private Const STATUS_ACTIVE = "ACTIVE"
	Private Const MT_MSG = "Your AgentID: <AgentID> is Successfully Registered! ID: HpNo. PW: <Password>, SMS Gateway: 91960600 Web: www.itopz.sg Hotline: 31515331"


	Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
		Me.lblErrorGrid.Text = ""
	End Sub

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Session("DEALER_ID") = "" Then
			Response.Redirect("~/Dealer/Login.aspx")
		End If
	End Sub

	Private Function UpdateAgentInfo(ByVal sHPNo As String, ByVal sAgentID As String, ByVal sPassword As String) As Boolean

		Dim oConn As New SqlConnection
		Dim oCmd As New SqlCommand
		'Dim oDR As SqlDataReader
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""

		UpdateAgentInfo = False

		Try
			sSQL = "UPDATE AgentInfo SET HPNo=@HPNo, LastModifiedBy=@ParentAgentID, LastModifiedDate=@date WHERE AgentID=@AgentID Update AgentMSISDN Set Password = @Password, MSISDN = @HPNo Where (AgentID = @AgentID)"

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
			oCmd.Parameters.Add(New SqlParameter("@date", Now()))
			oCmd.Parameters.Add(New SqlParameter("@ParentAgentID", Session("DEALER_ID")))
			oCmd.Parameters.Add(New SqlParameter("@Password", ComputeSha256Hash(sPassword)))
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
	Private Function GeneratePassword(ByVal iNumChars As Integer) As String
		'This function is used to generate a random PASSWORD that can be
		'emailed to the user.
		Const strDefault = "1234567890"
		Const strFirstChar = "1234567890"
		Dim iCount As Integer
		Dim strReturn As String
		Dim iNumber As Integer
		Dim iLength As Integer


		Randomize()


		'Generate first character of PASSWORD which has to be a letter
		iLength = Len(strFirstChar)
		iNumber = Int((iLength * Rnd()) + 1)
		strReturn = Mid(strFirstChar, iNumber, 1)


		'Generate the next n characters of the PASSWORD
		iLength = Len(strDefault)
		For iCount = 1 To iNumChars - 1
			iNumber = Int((iLength * Rnd()) + 1)
			strReturn += Mid(strDefault, iNumber, 1)
		Next


		Return strReturn


	End Function


	Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating

		Dim lblAgentID As Label = GridView1.Rows(e.RowIndex).FindControl("lblAgentID")
		Dim tHPNo As TextBox = GridView1.Rows(e.RowIndex).FindControl("tHPNo")


		Dim sAgentID As String = lblAgentID.Text
		Dim sHPNo As String = tHPNo.Text.Trim.ToUpper
		Dim oCommon As New Common
		Dim sMSISDN As String = tHPNo.Text
		Dim sMsg As String = MT_MSG
		Dim sPassword As String

		sPassword = GeneratePassword("8")
		sMsg = sMsg.Replace("<AgentID>", sAgentID)
		sMsg = sMsg.Replace("<HPNo>", sHPNo)
		sMsg = sMsg.Replace("<DateTime>", Now())
		sMsg = sMsg.Replace("<Password>", sPassword)

		If sHPNo = "" Then
			Me.lblErrorGrid.Text = "Invalid HPNo!"
		ElseIf Not IsNumeric(sHPNo) Then
			Me.lblErrorGrid.Text = "Invalid HP, Number only"
		Else
			If CheckHPNo(sHPNo, sAgentID) Then
				Me.lblErrorGrid.Text = "HPNO already exits!"
			ElseIf UpdateAgentInfo(sHPNo, sAgentID, sPassword) Then
				If GetHPNo(sAgentID) <> sHPNo Then
				ElseIf InsertMT(sMSISDN, sMsg, sAgentID) Then
				End If
				Me.lblErrorGrid.Text = "UpdateAgent Successfully!"
			Else
				Me.lblErrorGrid.Text = "Fail to UpdateProduct!"
			End If
		End If
		Me.GridView1.DataBind()



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
End Class

