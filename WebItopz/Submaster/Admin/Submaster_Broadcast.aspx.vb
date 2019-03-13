
Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager
Imports system.Data


Partial Class Submaster_Admin_Broadcast

	Inherits System.Web.UI.Page
	Private Const STATUS_PENDING As String = "PENDING"

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		Response.Redirect("~/submaster/submaster_login.aspx")
		If Session("AGENT_ID") = "" Then
			Response.Redirect("~/submaster/submaster_login.aspx")
		End If


		Me.lblErrorMsg.Text = ""

		If Page.IsPostBack Then



			If Me.txtMsg.Text.Length >= 1 And Me.txtMsg.Text.Length <= 150 Then
			Else
				Me.lblErrorMsg.Text = "Msg or nothing..Max 150 Character. Now have " & Me.txtMsg.Text.Length.ToString
				Exit Sub
			End If

			If Me.txtMSISDN.Text <> "" Then

				If Me.txtMSISDN.Text.Length = 8 And IsNumeric(Me.txtMSISDN.Text) Then

					If InsertMT("65" & txtMSISDN.Text, Me.txtMsg.Text) Then
						Me.lblErrorMsg.Text = "Msg sent to " & txtMSISDN.Text
						Me.txtMSISDN.Text = ""
						Me.txtMsg.Text = ""
					Else
						Me.lblErrorMsg.Text = "Msg sending Error.."
					End If

				Else
					Me.lblErrorMsg.Text = "Invalid MSISDN!"
				End If
			Else
				If SendGroupMT(Me.DDLGroup.Text) Then
					Me.lblErrorMsg.Text = "Msg sent to all agent " & DDLGroup.Text
					Me.txtMsg.Text = ""
				Else
					Me.lblErrorMsg.Text = "Msg sending Error.."
				End If
			End If


		End If
	End Sub

	Private Function InsertMT(ByVal sMSISDN As String, ByVal sMsg As String, Optional ByVal sAgentId As String = "", Optional ByVal iCount As String = "") As Boolean

		Dim sSQL As String = ""
		Dim oCmd As SqlCommand = Nothing
		Dim oConn As New SqlConnection(ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString)
		Dim sLocalMTID As String = Format(Now, "yyyyMMddHHmmss") & Now.Millisecond.ToString.PadLeft(3, "0") & iCount

		InsertMT = True

		Try
			oConn.Open()
			oCmd = oConn.CreateCommand
			oCmd.Connection = oConn

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
				.AddWithValue("@Telco", GetPrefix(sMSISDN))
				.AddWithValue("@Robin", "1")
				.AddWithValue("@Status", STATUS_PENDING)
			End With
			oCmd.ExecuteNonQuery()
			'oConn.Close()

		Catch ex As Exception
			InsertMT = False
			Response.Write(ex.Message)
		Finally
			If (Not oCmd Is Nothing) Then
				oCmd.Dispose()
				oCmd = Nothing
			End If
			If (Not oConn Is Nothing) Then
				If oConn.State = ConnectionState.Open Then
					oConn.Close()
				End If
				oConn.Dispose()
				oConn = Nothing
			End If
		End Try

	End Function


	Private Function SendGroupMT(ByVal sGroup As String) As Boolean

		Dim oConn As New SqlConnection
		Dim oCmd As New SqlCommand
		Dim oCmdUpdate As New SqlCommand
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""
		Dim oDR As SqlDataReader
		Dim iCount As Integer = 0


		Try
			SendGroupMT = False
			If sGroup = "DEALER" Then
				sSQL = "SELECT i.HPNo AS MSISDN, i.AgentID FROM AgentInfo AS i INNER JOIN AgentBalance AS b ON i.AgentID = b.AgentID WHERE (i.Status = 'ACTIVE') AND i.ParentAgentID=0"
			ElseIf sGroup = "AGENT" Then
				sSQL = "SELECT i.HPNo AS MSISDN, i.AgentID FROM AgentInfo AS i INNER JOIN AgentBalance AS b ON i.AgentID = b.AgentID WHERE (i.Status = 'ACTIVE') AND i.ParentAgentID>0"
			Else
				sSQL = "SELECT i.HPNo AS MSISDN, i.AgentID FROM AgentInfo AS i INNER JOIN AgentBalance AS b ON i.AgentID = b.AgentID WHERE (i.Status = 'ACTIVE')"
			End If


			oConn = New SqlConnection()
			oConn.ConnectionString =
						ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

			oCmd = New SqlCommand
			oCmd.CommandText = sSQL
			oCmd.Connection = oConn
			oCmd.Connection.Open()

			oCmd.Parameters.Clear()
			oDR = oCmd.ExecuteReader

			While oDR.Read
				InsertMT(oDR.Item("MSISDN"), Me.txtMsg.Text, oDR.Item("agentid"), iCount)
				iCount = iCount + 1
			End While
			oDR.Close()



			SendGroupMT = True
			' oDR.Close()

		Catch ex As Exception
			SendGroupMT = False
			Response.Write(ex.Message & "  " & ex.StackTrace)
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
	Private Function GetPrefix(ByVal sMSISDN As String) As String
		Dim sPrefix As String
		Dim i As Integer = 0
		Dim sTemp() As String
		Dim gaSpecialPrefixLength() As String


		sPrefix = sMSISDN.Substring(0, AppSettings.Item("MinimumTelcoPrefixLength")) 'Left(sMSISDN, giMinimumTelcoPrefixLen)


		gaSpecialPrefixLength = AppSettings.Item("SpecialTelcoPrefixAndLength").Split("|")

		For i = 0 To (gaSpecialPrefixLength.Length - 1)
			sTemp = gaSpecialPrefixLength(i).Split(":")

			If (sPrefix = sTemp(0)) Then
				If (sTemp.Length >= 2) Then
					sPrefix = sMSISDN.Substring(0, sTemp(1)) 'Left(sMSISDN, sTemp(1))

				End If

				Exit For
			End If
		Next
		sPrefix = AppSettings.Item("PrefixName_" & sPrefix) & ""

		Return sPrefix
	End Function


End Class


