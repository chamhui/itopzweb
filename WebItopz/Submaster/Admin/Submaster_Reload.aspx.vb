Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager

Partial Class Submaster_Reload
	Inherits System.Web.UI.Page

	Private Const STATUS_ACTIVE = "ACTIVE"
	Private msMaxRobinDiGi As Integer = 1
	Private msMaxRobinCelcom As Integer = 1
	Private msMaxRobinMaxis As Integer = 1



	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Response.Redirect("~/submaster/submaster_login.aspx")
		If Session("AGENT_ID") = "" Then
			Response.Redirect("~/submaster/submaster_login.aspx")
		End If

		Me.lblErrorMsg.Text = ""
		Me.lblReloadMSISDN.Text = ""
		Me.lblReloadAmount.Text = ""
		Me.lblReloadTelco.Text = ""
		getMaxPostRobin()

	End Sub

	Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click

		If Me.txtAgentMSISDN.Text = "" Or Me.txtAgentMSISDN.Text.Length <> 10 Then
			Me.lblErrorMsg.Text = "Invalid Agent HP No!"
		ElseIf Me.txtPassword.Text = "" Or Me.txtPassword.Text.Length < 1 Then
			Me.lblErrorMsg.Text = "Invalid Password!"
		ElseIf Me.txtReloadMSISDN.Text = "" Or Me.txtReloadMSISDN.Text.Length <> 10 Then
			Me.lblErrorMsg.Text = "Invalid Reload Number!"
		ElseIf Me.txtReloadAmount.Text = "" Or Not IsNumeric(Me.txtReloadAmount.Text) Or InStr(Me.txtReloadAmount.Text, ".") > 0 Then
			Me.lblErrorMsg.Text = "Invalid Reload Amount!"
		ElseIf Me.txtReloadAmount.Text < 2 Or Me.txtReloadAmount.Text > 100 Then
			Me.lblErrorMsg.Text = "Invalid Reload Amount! (RM2-RM100)"
		Else
			Me.btnSubmit.Visible = False
			Me.txtAgentMSISDN.Enabled = False
			Me.txtPassword.Enabled = False
			Me.txtReloadMSISDN.Enabled = False
			Me.txtReloadAmount.Enabled = False
			Me.btnConfirm.Visible = True
			Me.btnEdit.Visible = True
			Me.lblReloadMSISDN.Text = txtReloadMSISDN.Text & ""
			Me.lblReloadAmount.Text = "RM" & txtReloadAmount.Text
			Me.lblReloadTelco.Text = Me.DDLTelco.SelectedValue
			Me.DDLTelco.Enabled = False
		End If

	End Sub


	Private Function InsertIntoTxIn(ByVal sMSISDN As String, ByVal sMOMsg As String, ByVal sMOTS As String) As Boolean

		Dim sSQL As String = ""
		Dim oCmd As SqlCommand = Nothing
		Dim oConn As New SqlConnection(ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString)
		Dim aMOMsg() As String
		Dim sAgentPin As String = ""
		Dim sReloadAmount As Integer
		Dim sReloadMSISDN As String = ""
		Dim sReloadTelco As String = ""
		Dim sReloadType As String = "AIR"
		Dim bValid As Boolean = True
		Dim sAgentId As String = ""
		Dim sErrorCode As String = ""
		Dim sStatus As String = "INVALID"
		Dim sLocalMOID As String = Format(Now, "yyyyMMddHHmmss") & Now.Millisecond.ToString.PadLeft(3, "0")
		Dim iNewBalance As Integer
		Dim iRobin As Integer

		Try
			oConn.Open()
			oCmd = oConn.CreateCommand
			oCmd.Connection = oConn

			aMOMsg = Split(Replace(Replace(Replace(sMOMsg, "  ", " "), ".", ""), "   ", " "), " ")


			If UBound(aMOMsg) = 2 Then
				sAgentPin = aMOMsg(0)
				sReloadAmount = Replace(Replace(Replace(Replace(aMOMsg(1).ToUpper, "M", ""), "C", ""), "D", ""), "N", "")
				sReloadMSISDN = aMOMsg(2)
				sReloadTelco = Me.DDLTelco.SelectedValue  'GetPrefix("6" & sReloadMSISDN)
				If aMOMsg(1).Length > 2 Then
					If aMOMsg(1).ToUpper.Substring(0, 2) = "CN" Then
						sReloadType = "NETWORK"
					End If
				End If

				If Not IsNumeric(sReloadAmount) Then bValid = False
				If Not IsNumeric(sReloadMSISDN) Then bValid = False
				If sReloadMSISDN.Length <> "10" Then bValid = False
				If sReloadTelco = "" Then bValid = False
			Else
				bValid = False
			End If

			If bValid Then
				If sReloadTelco = "MAXIS" Then
					If sReloadAmount >= 2 And sReloadAmount <= 100 Then
					Else
						bValid = False
						sErrorCode = "Invalid_ReloadAmunt"
					End If
				ElseIf sReloadTelco = "DIGI" Then
					If sReloadAmount >= 5 And sReloadAmount <= 100 Then
					Else
						bValid = False
						sErrorCode = "Invalid_ReloadAmunt"
					End If
				ElseIf sReloadTelco = "CELCOM" Then
					If sReloadType = "NETWORK" Then
						If sReloadAmount >= 3 And sReloadAmount <= 200 Then
						Else
							bValid = False
							sErrorCode = "Invalid_ReloadAmunt(RM3-RM200)"
						End If
					Else
						If sReloadAmount >= 3 And sReloadAmount <= 100 Then
						Else
							bValid = False
							sErrorCode = "Invalid_ReloadAmunt(RM3-RM100)"
						End If
					End If

				Else
					bValid = False
					sErrorCode = "Invalid_ReloadTelco"
				End If
			End If

			sAgentId = getAgentID(sAgentPin, sMSISDN, oConn)

			If sAgentId = "" Then
				bValid = False
				sErrorCode = "Invalid_AgentPinOrMSISDNOrInactiveStatus"
			End If

			If CheckLastReloadTS(sReloadMSISDN, sReloadAmount, sReloadTelco, oConn) Then
				bValid = False
				sErrorCode = "Duplication Reload Submitted"
			End If

			If bValid Then
				If deductBalance(sAgentId, sReloadAmount, sReloadTelco, iNewBalance, oConn) Then
					InsertTxReload(sLocalMOID, sAgentId, sReloadMSISDN, sReloadAmount, sReloadTelco, iNewBalance, oConn)
					sStatus = "PENDING"
				Else
					sErrorCode = "Insufficient_Balance"
				End If
			End If

			iRobin = getPostRobin(sReloadTelco)

			sSQL = "INSERT INTO TxIn (LocalMOID, MSISDN, AgentID, MessageIn, MessageTS, ReloadMSISDN, ReloadAmount, ReloadTelco,ReloadType, Robin, Status, ErrorCode) " &
										"VALUES (@LocalMOID, @MSISDN, @AgentID, @MessageIn, @MessageTS, @ReloadMSISDN, @ReloadAmount, @ReloadTelco, @ReloadType, @Robin,@Status, @ErrorCode) "

			oCmd.CommandText = sSQL
			With oCmd.Parameters
				.Clear()
				.AddWithValue("@LocalMOID", sLocalMOID)
				.AddWithValue("@MSISDN", sMSISDN)
				.AddWithValue("@AgentID", sAgentId)
				.AddWithValue("@MessageIn", sMOMsg)
				.AddWithValue("@MessageTS", sMOTS)
				.AddWithValue("@ReloadMSISDN", sReloadMSISDN)
				.AddWithValue("@ReloadAmount", sReloadAmount)
				.AddWithValue("@ReloadTelco", sReloadTelco)
				.AddWithValue("@ReloadType", sReloadType)
				.AddWithValue("@Robin", iRobin)
				.AddWithValue("@Status", sStatus)
				.AddWithValue("@ErrorCode", sErrorCode)
			End With
			oCmd.ExecuteNonQuery()

			If sErrorCode <> "" Then
				Me.lblErrorMsg.Text = sErrorCode
				Me.txtAgentMSISDN.Enabled = True
				Me.txtPassword.Enabled = True
				Me.txtReloadMSISDN.Enabled = True
				Me.txtReloadAmount.Enabled = True
				Me.btnConfirm.Visible = False
				Me.btnEdit.Visible = False
				Me.btnSubmit.Visible = True
				Me.DDLTelco.Enabled = True
			Else
				Me.txtReloadAmount.Text = ""
				Me.txtReloadMSISDN.Text = ""
			End If

			If bValid Then
				Me.lblErrorMsg.Text = "Reloading..."
			End If

		Catch ex As Exception
			Response.Write("InsertIntoTxIn [" & ex.Message & "]" & ex.StackTrace)
		Finally
			If (Not oCmd Is Nothing) Then
				oCmd.Dispose()
				oCmd = Nothing
			End If

		End Try

	End Function

	Private Function getAgentID(ByVal sPIN As String, ByVal sMSISDN As String, ByVal oConn As SqlConnection) As String

		Dim sSQL As String = ""
		' Dim oConn As New SqlConnection(gsDBConnString)
		Dim oCmd As New SqlCommand
		Dim oDR As SqlDataReader = Nothing
		Dim sAgentID As String = ""

		Try

			'oConn.Open()
			oCmd = oConn.CreateCommand
			oCmd.Connection = oConn
			sSQL = "SELECT AgentID FROM AgentMSISDN WHERE MSISDN=@MSISDN and STATUS=@STATUS and PASSWORD=@PIN "

			oCmd.CommandText = sSQL
			With oCmd.Parameters
				.Clear()
				.AddWithValue("@STATUS", STATUS_ACTIVE)
				.AddWithValue("@MSISDN", sMSISDN)
				.AddWithValue("@PIN", sPIN)
			End With
			oDR = oCmd.ExecuteReader

			If oDR.HasRows Then
				oDR.Read()
				sAgentID = oDR.Item("AgentID")
			End If
			oDR.Close()
			'oConn.Close()

			getAgentID = sAgentID

		Catch ex As Exception
			getAgentID = ""
			Response.Write("deductBalance [" & ex.Message & "]")
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
		End Try

	End Function


	Private Function deductBalance(ByVal sAgentId As String, ByVal sReloadAmount As Integer, ByVal sReloadTelco As String, ByRef iNewBalance As Decimal, ByVal oConn As SqlConnection) As Boolean

		Dim sSQL As String = ""
		Dim sSQLUpdate As String = ""
		Dim oCmd As New SqlCommand
		Dim oCmdUpdate As New SqlCommand
		Dim oDR As SqlDataReader = Nothing
		Dim iBalance As Decimal
		Dim iDiscount As Decimal
		Dim oConnUpdate As New SqlConnection(ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString)

		deductBalance = True

		Try
			'oConn.Open()
			oCmd = oConn.CreateCommand
			oCmd.Connection = oConn
			If sReloadTelco = "MAXIS" Then
				'sSQL = "SELECT MAXISBalance as Balance FROM AgentBALANCE WHERE AgentID=@AgentID and MAXISBalance>=@ReloadAmount "
				sSQL = "SELECT  a.DiscountMaxis  as Discount, b.Balance as Balance FROM AgentInfo a, AgentBalance b WHERE a.AgentID=@AgentID and a.AgentID = b.AgentID and b.balance>=@ReloadAmount "
			ElseIf sReloadTelco = "DIGI" Then
				'sSQL = "SELECT DIGIBalance as Balance FROM AgentBALANCE WHERE AgentID=@AgentID and DIGIBalance>=@ReloadAmount "
				sSQL = "SELECT  a.DiscountDiGi  as Discount, b.Balance as Balance FROM AgentInfo a, AgentBalance b WHERE a.AgentID=@AgentID and a.AgentID = b.AgentID and b.balance>=@ReloadAmount "
			ElseIf sReloadTelco = "CELCOM" Then
				'sSQL = "SELECT CelcomBalance as Balance FROM AgentBALANCE WHERE AgentID=@AgentID and CelcomBalance>=@ReloadAmount "
				sSQL = "SELECT  a.DiscountCelcom  as Discount, b.Balance as Balance FROM AgentInfo a, AgentBalance b WHERE a.AgentID=@AgentID and a.AgentID = b.AgentID  and b.balance>=@ReloadAmount "
			End If


			oCmd.CommandText = sSQL
			With oCmd.Parameters
				.Clear()
				.AddWithValue("@AgentID", sAgentId)
				.AddWithValue("@ReloadAmount", sReloadAmount)
			End With
			oDR = oCmd.ExecuteReader

			If oDR.HasRows Then
				oDR.Read()
				iDiscount = oDR.Item("Discount")
				iBalance = oDR.Item("Balance")

				iNewBalance = iBalance - (sReloadAmount - (sReloadAmount * (iDiscount / 100)))


				sSQLUpdate = "UPDATE AgentBALANCE SET  Balance=@NewBalance WHERE AgentID=@AgentID"
				'If sReloadTelco = "MAXIS" Then
				'    sSQLUpdate = "UPDATE AgentBALANCE SET MaxisBalance=@NewBalance WHERE AgentID=@AgentID"
				'ElseIf sReloadTelco = "DIGI" Then
				'    sSQLUpdate = "UPDATE AgentBALANCE SET DiGiBalance=@NewBalance WHERE AgentID=@AgentID"
				'ElseIf sReloadTelco = "CELCOM" Then
				'    sSQLUpdate = "UPDATE AgentBALANCE SET CelcomBalance=@NewBalance WHERE AgentID=@AgentID"
				'End If
				oConnUpdate.Open()
				oCmdUpdate = oConnUpdate.CreateCommand
				oCmdUpdate.Connection = oConnUpdate
				oCmdUpdate.CommandText = sSQLUpdate
				With oCmdUpdate.Parameters
					.Clear()
					.AddWithValue("@AgentID", sAgentId)
					.AddWithValue("@NewBalance", iNewBalance)
				End With
				oCmdUpdate.ExecuteNonQuery()
				oConnUpdate.Close()
			Else
				deductBalance = False
			End If

			'oConn.Close()


		Catch ex As Exception
			deductBalance = False
			Response.Write("deductBalance [" & ex.Message & "]")
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
		End Try

	End Function

	'Private Function deductBalance(ByVal sAgentId As String, ByVal sReloadAmount As Integer, ByVal sReloadTelco As String, ByRef iNewBalance As Integer, ByVal oConn As SqlConnection) As Boolean

	'    Dim sSQL As String = ""
	'    Dim sSQLUpdate As String = ""
	'    Dim oCmd As New SqlCommand
	'    Dim oCmdUpdate As New SqlCommand
	'    Dim oDR As SqlDataReader
	'    Dim iBalance As Integer
	'    'Dim oConn As New SqlConnection(gsDBConnString)
	'    Dim oConnUpdate As New SqlConnection(ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString)

	'    deductBalance = True

	'    Try
	'        'oConn.Open()
	'        oCmd = oConn.CreateCommand
	'        oCmd.Connection = oConn
	'        If sReloadTelco = "MAXIS" Then
	'            sSQL = "SELECT MAXISBalance as Balance FROM AgentBALANCE WHERE AgentID=@AgentID and MAXISBalance>=@ReloadAmount "
	'        ElseIf sReloadTelco = "DIGI" Then
	'            sSQL = "SELECT DIGIBalance as Balance FROM AgentBALANCE WHERE AgentID=@AgentID and DIGIBalance>=@ReloadAmount "
	'        ElseIf sReloadTelco = "CELCOM" Then
	'            sSQL = "SELECT CelcomBalance as Balance FROM AgentBALANCE WHERE AgentID=@AgentID and CelcomBalance>=@ReloadAmount "
	'        End If


	'        oCmd.CommandText = sSQL
	'        With oCmd.Parameters
	'            .Clear()
	'            .AddWithValue("@AgentID", sAgentId)
	'            .AddWithValue("@ReloadAmount", sReloadAmount)
	'        End With
	'        oDR = oCmd.ExecuteReader

	'        If oDR.HasRows Then
	'            oDR.Read()
	'            iBalance = oDR.Item("Balance")
	'            iNewBalance = iBalance - sReloadAmount
	'            If sReloadTelco = "MAXIS" Then
	'                sSQLUpdate = "UPDATE AgentBALANCE SET MaxisBalance=@NewBalance WHERE AgentID=@AgentID"
	'            ElseIf sReloadTelco = "DIGI" Then
	'                sSQLUpdate = "UPDATE AgentBALANCE SET DiGiBalance=@NewBalance WHERE AgentID=@AgentID"
	'            ElseIf sReloadTelco = "CELCOM" Then
	'                sSQLUpdate = "UPDATE AgentBALANCE SET CelcomBalance=@NewBalance WHERE AgentID=@AgentID"
	'            End If
	'            oConnUpdate.Open()
	'            oCmdUpdate = oConnUpdate.CreateCommand
	'            oCmdUpdate.Connection = oConnUpdate
	'            oCmdUpdate.CommandText = sSQLUpdate
	'            With oCmdUpdate.Parameters
	'                .Clear()
	'                .AddWithValue("@AgentID", sAgentId)
	'                .AddWithValue("@NewBalance", iNewBalance)
	'            End With
	'            oCmdUpdate.ExecuteNonQuery()
	'            oConnUpdate.Close()
	'        Else
	'            deductBalance = False
	'        End If

	'        'oConn.Close()


	'    Catch ex As Exception
	'        deductBalance = False
	'        Response.Write("deductBalance [" & ex.Message & "]")
	'    Finally
	'        If (Not oCmd Is Nothing) Then
	'            oCmd.Dispose()
	'            oCmd = Nothing
	'        End If
	'        If (Not oDR Is Nothing) Then
	'            If (Not oDR.IsClosed) Then
	'                oDR.Close()
	'            End If
	'            oDR = Nothing
	'        End If
	'    End Try

	'End Function

	Private Function InsertTxReload(ByVal sLocalMOID As String, ByVal sAgentId As String, ByVal sReloadMSISDN As String, ByVal sReloadAmount As Integer, ByVal sReloadTelco As String, ByVal iNewBalance As Integer, ByVal oConn As SqlConnection) As Boolean

		Dim sSQL As String = ""
		Dim oCmd As SqlCommand = Nothing
		' Dim oConn As New SqlConnection(gsDBConnString)

		InsertTxReload = True

		Try
			'oConn.Open()
			oCmd = oConn.CreateCommand
			oCmd.Connection = oConn

			sSQL = "INSERT INTO TxReload (LocalMOID, AgentId, ReloadMSISDN, ReloadAmount, ReloadTelco, BalanceAfterReload) " &
										"VALUES (@LocalMOID, @AgentId, @ReloadMSISDN, @ReloadAmount, @ReloadTelco, @BalanceAfterReload) "

			oCmd.CommandText = sSQL
			With oCmd.Parameters
				.Clear()
				.AddWithValue("@LocalMOID", sLocalMOID)
				.AddWithValue("@AgentID", sAgentId)
				.AddWithValue("@ReloadMSISDN", sReloadMSISDN)
				.AddWithValue("@ReloadTelco", sReloadTelco)
				.AddWithValue("@ReloadAmount", sReloadAmount)
				.AddWithValue("@BalanceAfterReload", iNewBalance)
			End With
			oCmd.ExecuteNonQuery()
			'oConn.Close()

		Catch ex As Exception
			InsertTxReload = False
			Response.Write("InsertTxReload [" & ex.Message & "]")
		Finally
			If (Not oCmd Is Nothing) Then
				oCmd.Dispose()
				oCmd = Nothing
			End If
			'If (Not oConn Is Nothing) Then
			'    If oConn.State = ConnectionState.Open Then
			'        oConn.Close()
			'    End If
			'    oConn.Dispose()
			'    oConn = Nothing
			'End If
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

	Private Function CheckLastReloadTS(ByVal sReloadMSISDN As String, ByVal sReloadAmount As String, ByVal sReloadTelco As String, ByVal oConn As SqlConnection) As Boolean

		Dim sSQL As String = ""
		Dim oCmd As New SqlCommand
		Dim oDR As SqlDataReader = Nothing
		Dim sAgentID As String = ""
		CheckLastReloadTS = False

		Try
			oCmd = oConn.CreateCommand
			oCmd.Connection = oConn
			If sReloadTelco = "MAXIS" Then
				sSQL = "SELECT LocalMOID FROM TxIn WHERE ReloadMSISDN=@ReloadMSISDN and ReloadAmount=@ReloadAmount and datediff(n,CreatedTS,getdate()) < 5 and (STATUS='SUCCESS' or Status='PENDING') "
			ElseIf sReloadTelco = "DIGI" Then
				sSQL = "SELECT LocalMOID FROM TxIn WHERE ReloadMSISDN=@ReloadMSISDN and ReloadAmount=@ReloadAmount and datediff(n,CreatedTS,getdate()) < 30 and (STATUS='SUCCESS' or Status='PENDING') "
			ElseIf sReloadTelco = "CELCOM" Then
				sSQL = "SELECT LocalMOID FROM TxIn WHERE ReloadMSISDN=@ReloadMSISDN and ReloadAmount=@ReloadAmount and datediff(n,CreatedTS,getdate()) < 5 and (STATUS='SUCCESS' or Status='PENDING') "
			End If


			oCmd.CommandText = sSQL
			With oCmd.Parameters
				.Clear()
				.AddWithValue("@ReloadMSISDN", sReloadMSISDN)
				.AddWithValue("@ReloadAmount", sReloadAmount)
			End With
			oDR = oCmd.ExecuteReader

			If oDR.HasRows Then
				CheckLastReloadTS = True
			End If
			oDR.Close()

		Catch ex As Exception
			CheckLastReloadTS = False
			Response.Write("CheckLastReloadTS [" & ex.Message & "]")
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
		End Try

	End Function

	Private Function getMaxPostRobin() As Boolean

		Dim sSQL As String = ""
		Dim oConn As New SqlConnection(ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString)
		Dim oCmd As New SqlCommand
		Dim oDR As SqlDataReader = Nothing
		getMaxPostRobin = True

		Try
			oConn.Open()
			oCmd = oConn.CreateCommand
			oCmd.Connection = oConn
			sSQL = "SELECT Telco, MaxRobin FROM PostRobin"

			oCmd.CommandText = sSQL
			With oCmd.Parameters
				.Clear()
			End With
			oDR = oCmd.ExecuteReader
			While oDR.Read
				If (oDR.Item("Telco")).ToString.ToUpper = "MAXIS" Then
					msMaxRobinMaxis = (oDR.Item("MaxRobin"))
				End If
				If (oDR.Item("Telco")).ToString.ToUpper = "CELCOM" Then
					msMaxRobinCelcom = (oDR.Item("MaxRobin"))
				End If
				If (oDR.Item("Telco")).ToString.ToUpper = "DIGI" Then
					msMaxRobinDiGi = (oDR.Item("MaxRobin"))
				End If
			End While
			oDR.Close()
			oConn.Close()

		Catch ex As Exception
			getMaxPostRobin = False
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
			'If (Not oConn Is Nothing) Then
			'    If oConn.State = ConnectionState.Open Then
			'        oConn.Close()
			'    End If
			'    oConn.Dispose()
			'    oConn = Nothing
			'End If
		End Try

	End Function

	Private Function getPostRobin(ByVal sReloadTelco As String) As Integer

		Dim sSQL As String = ""
		Dim oConn As New SqlConnection(ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString)
		Dim oCmd As New SqlCommand
		Dim oDR As SqlDataReader = Nothing

		Try
			oConn.Open()
			oCmd = oConn.CreateCommand
			oCmd.Connection = oConn
			sSQL = "SELECT (Robin+1) as Robin FROM TxIn WHERE ReloadTelco=@ReloadTelco order by localMoId desc "

			oCmd.CommandText = sSQL
			With oCmd.Parameters
				.Clear()
				.AddWithValue("@ReloadTelco", sReloadTelco)
			End With
			oDR = oCmd.ExecuteReader

			If oDR.HasRows Then
				oDR.Read()
				getPostRobin = (oDR.Item("Robin"))
			End If
			oDR.Close()
			oConn.Close()

			If sReloadTelco = "MAXIS" Then
				If getPostRobin > msMaxRobinMaxis Then
					getPostRobin = 1
				End If
			ElseIf sReloadTelco = "CELCOM" Then
				If getPostRobin > msMaxRobinCelcom Then
					getPostRobin = 1
				End If
			ElseIf sReloadTelco = "DIGI" Then
				If getPostRobin > msMaxRobinDiGi Then
					getPostRobin = 1
				End If
			End If



		Catch ex As Exception
			Response.Write("getPostRobin [" & ex.Message & "]")
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
			'If (Not oConn Is Nothing) Then
			'    If oConn.State = ConnectionState.Open Then
			'        oConn.Close()
			'    End If
			'    oConn.Dispose()
			'    oConn = Nothing
			'End If
		End Try

	End Function

	Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
		Dim sMsg As String
		sMsg = txtPassword.Text & " " & txtReloadAmount.Text & " " & txtReloadMSISDN.Text
		InsertIntoTxIn("6" & txtAgentMSISDN.Text, sMsg, Format(Now(), "yyyyMMddHHmmss"))

		Me.btnConfirm.Enabled = False

	End Sub

	Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click

		Me.txtAgentMSISDN.Enabled = True
		Me.txtPassword.Enabled = True
		Me.txtReloadMSISDN.Enabled = True
		Me.txtReloadAmount.Enabled = True
		Me.btnConfirm.Visible = False
		Me.btnEdit.Visible = False
		Me.btnSubmit.Visible = True
		Me.DDLTelco.Enabled = True
		Me.btnConfirm.Enabled = True
	End Sub
End Class
