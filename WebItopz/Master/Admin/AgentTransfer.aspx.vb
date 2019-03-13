Imports System.Data.SqlClient

Partial Class Transfer
	Inherits System.Web.UI.Page

	Private Const STATUS_ACTIVE = "ACTIVE"
	Dim sAgentMSISDN As String = ""
	'Private Const MT_MSG = "Your account been credited: D:[<DiGi>] M:[<Maxis>] C:[<Celcom>]. New balace: <NewBalance>. DateTime:<DateTime>."
	Private Const MT_MSG = "Your account been credited: SGD<Amount> New <NewBalance> (<Remarks>). DateTime:<DateTime>."


	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Session("AGENT_ID") = "" Then
			Response.Redirect("~/Master/Login.aspx")
		End If
		Me.lblErrorMsg.Text = ""
	End Sub


	Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click

		Dim sAgentName As String = ""
		Dim sAgentBalance As String = ""
		Dim sAgBalance As Decimal = 0
		Dim sFinalBalance As Decimal = 0
		Dim oConn As New SqlConnection
		oConn = New SqlConnection()
		oConn.ConnectionString =
						ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString
		Dim sAgentId As String = Session("AGENT_ID")
		Dim sTopupAmount As Double
		sTopupAmount = Convert.ToDouble(txtMaxisAmount.Text)
		Dim sBalanceMsg As String = ""
		Dim sTopupAgentID As String = DDLAgentID.SelectedValue
		Dim sMTMsg As String = ""
		'If Me.txtAgentId.Text = "" Or Not IsNumeric(Me.txtAgentId.Text) Then
		'    Me.lblErrorMsg.Text = "empty agent id or invalid agent id"
		'Else
		If Me.txtMaxisAmount.Text = "" Or Not IsNumeric(Me.txtMaxisAmount.Text) Then
			Me.lblErrorMsg.Text = "empty amount or invalid amount" ' (Maxis)"
			'ElseIf Me.txtDiGiAmount.Text = "" Or Not IsNumeric(Me.txtDiGiAmount.Text) Then
			'    Me.lblErrorMsg.Text = "empty amount or invalid amount (DiGi)"
			'ElseIf Me.txtCelcomAmount.Text = "" Or Not IsNumeric(Me.txtCelcomAmount.Text) Then
			'    Me.lblErrorMsg.Text = "empty amount or invalid amount (Celcom)"
			'ElseIf Me.txtBankIn.Text = "" Or Not IsNumeric(Me.txtBankIn.Text) Then
			'    Me.lblErrorMsg.Text = "empty amount or invalid amount (Bank In)"
		Else
			'sAgentName = GetAgentName(DDLAgentID.SelectedValue, sAgentMSISDN)
			'sAgentBalance = getAgentBalance(DDLAgentID.SelectedValue)
			'If (sAgentBalance.Replace("Balance: SGD", "") = "") Then
			'	sAgBalance = 0
			'Else
			'	sAgBalance = sAgentBalance.Replace("Balance: SGD", "")
			'End If

			'Session("TopUpMSISDN") = sAgentMSISDN
			'sFinalBalance = Me.txtMaxisAmount.Text + sAgBalance

			'If (sFinalBalance < 0) Then
			'	Me.lblErrorMsg.Text = "ERROR! Deduction Exceed Current Bal : $" & sAgBalance
			'ElseIf sAgentName <> "" Then
			'	Me.lblName.Text = sAgentName & " " & sFinalBalance
			'	Me.btnConfirm.Visible = True
			'	Me.btnCancel.Visible = True
			'	Me.btnSubmit.Visible = False
			'	Me.txtMaxisAmount.Enabled = False
			'	'Me.txtDiGiAmount.Enabled = False
			'	'Me.txtCelcomAmount.Enabled = False
			'	'Me.txtBankIn.Enabled = False
			'	Me.DDLAgentID.Enabled = False
			'Else
			'	Me.lblErrorMsg.Text = "invalid agent id!"
			'End If
			If getAgentBalance(sAgentId, sTopupAmount, sBalanceMsg, oConn) Then
				If ProcessTT(sAgentId, sTopupAgentID, sTopupAmount, oConn) Then
					'sMTMsg = getBalance(sMSISDN, oConn)
					'sMTMsg = "Transfer Successful Amount:" & sTopupAmount & " to " & sTopupAgentMSISDN.Substring(2, sTopupAgentMSISDN.Length - 2) & "! Your " & sMTMsg
					'InsertMT(sMSISDN, sMTMsg, oConn)
					'sMTMsg = getBalance(sTopupAgentMSISDN, oConn)
					'sMTMsg = "Received Transfer Amount:" & sTopupAmount & " from " & sMSISDN.Substring(2, sMSISDN.Length - 2) & "! Your " & sMTMsg
					'InsertMT(sTopupAgentMSISDN, sMTMsg, oConn)
					lblErrorMsg.Text = "Balance Transferred"
				Else
					lblErrorMsg.Text = "Transfer fail. try again later."
				End If
			Else
				lblErrorMsg.Text = "You have insufficient balance to do Transfer." & sBalanceMsg
			End If

		End If


	End Sub

	Private Function getBalance(ByVal sMSISDN As String, ByVal oConn As SqlConnection) As String

		Dim sSQL As String = ""
		' Dim oConn As New SqlConnection(gsDBConnString)
		Dim oCmd As New SqlCommand
		Dim oCmdSales As New SqlCommand
		Dim oDR As SqlDataReader = Nothing
		Dim oDRSales As SqlDataReader = Nothing
		Dim sAgentID As String = ""
		Dim Balance As String = ""
		Dim M5 As String = ""
		Dim M18 As String = ""
		Dim M28 As String = ""
		Dim sTodaySales As String = ""
		Dim sBalance As String = ""

		Try
			'oConn.Open()
			oCmd = oConn.CreateCommand
			oCmd.Connection = oConn

			sSQL = "SELECT B.AgentId as AgentId, b.Balance AS Balance, b.M5 As M5, b.M18 As M18, b.M28 As M28  "
			sSQL = sSQL & "FROM AgentMSISDN AS m INNER JOIN "
			sSQL = sSQL & "AgentBalance AS b ON m.AgentID = b.AgentID "
			sSQL = sSQL & "WHERE (m.Status = @STATUS) AND (m.MSISDN = @MSISDN) "

			oCmd.CommandText = sSQL
			With oCmd.Parameters
				.Clear()
				.AddWithValue("@STATUS", STATUS_ACTIVE)
				.AddWithValue("@MSISDN", sMSISDN)
			End With
			oDR = oCmd.ExecuteReader

			If oDR.HasRows Then
				oDR.Read()
				sAgentID = oDR.Item("AgentId")
				Balance = oDR.Item("Balance")
				M5 = oDR.Item("M5")
				M18 = oDR.Item("M18")
				M28 = oDR.Item("M28")
			End If
			oDR.Close()

			oCmdSales = oConn.CreateCommand
			oCmdSales.Connection = oConn
			sSQL = "SELECT ReloadTelco, SUM(ReloadAmount) AS Sales "
			sSQL = sSQL & "FROM TxIn  "
			sSQL = sSQL & "WHERE (CONVERT(char(10), CreatedTS, 111) = CONVERT(char(10), GETDATE(), 111)) AND (Status = 'SUCCESS') AND (AgentID = @AgentId) "
			sSQL = sSQL & "GROUP BY ReloadTelco"
			oCmdSales.CommandText = sSQL
			With oCmdSales.Parameters
				.Clear()
				.AddWithValue("@AgentID", sAgentID)
			End With
			oDRSales = oCmdSales.ExecuteReader

			While oDRSales.Read()
				sTodaySales = sTodaySales & oDRSales.Item("ReloadTelco") & ": " & oDRSales.Item("Sales") & "."

				'If oDRSales.Item("ReloadTelco").ToString.ToUpper = "SINGTEL" Then
				'    SingTelSales = oDRSales.Item("Sales") & ""
				'ElseIf oDRSales.Item("ReloadTelco").ToString.ToUpper = "M1" Then
				'    M1Sales = oDRSales.Item("Sales") & ""
				'End If

			End While

			oDRSales.Close()

			If sTodaySales = "" Then sTodaySales = "-"
			'oConn.Close()
			sBalance = "AgentID:" & sAgentID.Trim & ". Today Sales: " & sTodaySales & ".  Balance: " & Balance & "."
			sBalance &= " Balance(M5): " & M5 & "." & " Balance(M18): " & M18 & "." & " Balance(M28): " & M28 & "."
			getBalance = sBalance
		Catch ex As Exception
			getBalance = ""
			'goLog.ErrorLog(ProcessorId & "~getBalance", ex.Message)
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
			If (Not oCmdSales Is Nothing) Then
				oCmdSales.Dispose()
				oCmdSales = Nothing
			End If
			If (Not oDRSales Is Nothing) Then
				If (Not oDRSales.IsClosed) Then
					oDRSales.Close()
				End If
				oDRSales = Nothing
			End If
		End Try

	End Function

	Private Function getAgentBalance(ByVal sAgentId As String, ByVal sTopupAmount As Decimal, ByRef sBalanceMsg As String, ByVal oConn As SqlConnection) As Boolean

		Dim sSQL As String = ""
		Dim oCmd As New SqlCommand
		Dim oDR As SqlDataReader = Nothing
		Dim sBalance As Decimal = 0

		Try
			getAgentBalance = False
			oConn.Open()
			oCmd = oConn.CreateCommand
			oCmd.Connection = oConn

			sSQL = "SELECT Balance FROM AgentBalance WHERE AgentID=@AgentID "
			oCmd.CommandText = sSQL
			With oCmd.Parameters
				.Clear()
				.AddWithValue("@AgentID", sAgentId)
			End With
			oDR = oCmd.ExecuteReader
			If oDR.HasRows Then
				oDR.Read()
				sBalance = oDR.Item("Balance")

				If sBalance >= sTopupAmount Then
					getAgentBalance = True
				Else
					sBalanceMsg = " (" & sBalance & ") "    '"M:(" & sMaxisBal & ") " & "D:(" & sDiGiBal & ") " & "C:(" & sCelcomBal & ")"
				End If

			End If
			oDR.Close()
			oConn.Close()


		Catch ex As Exception
			getAgentBalance = False
			'goLog.ErrorLog(ProcessorId & "~getAgentBalance", ex.Message)
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
	Private Function ProcessTT(ByVal sAgentId As String, ByVal sTopupAgentId As String, ByVal sTopupAmount As String, ByVal oConn As SqlConnection) As Boolean

		Dim sSQL As String = ""
		Dim sSQLUpdate As String = ""
		Dim oCmd As New SqlCommand
		Dim oCmdUpdate As New SqlCommand
		Dim oDR As SqlDataReader = Nothing
		'Dim oConn As New SqlConnection(gsDBConnString)

		ProcessTT = False

		Dim oCmdDeductBal As New SqlCommand
		Dim oCmdAddBal As New SqlCommand
		Dim oCmdInsertTTSent As New SqlCommand
		Dim oCmdInsertTTReceived As New SqlCommand

		Dim oTrans As SqlTransaction = Nothing

		Try
			oConn.Open()

			sSQL = "UPDATE AgentBALANCE SET Balance=Balance-@sTopupAmount  WHERE AgentID=@AgentID"
			oCmdDeductBal = New SqlCommand(sSQL, oConn)
			With oCmdDeductBal.Parameters
				.Clear()
				.AddWithValue("@AgentID", sAgentId)
				.AddWithValue("@sTopupAmount", sTopupAmount)
			End With

			sSQL = "UPDATE AgentBALANCE SET Balance=Balance+@sTopupAmount WHERE AgentID=@AgentID"
			oCmdAddBal = New SqlCommand(sSQL, oConn)
			With oCmdAddBal.Parameters
				.Clear()
				.AddWithValue("@AgentID", sTopupAgentId)
				.AddWithValue("@sTopupAmount", sTopupAmount)
			End With


			sSQL = "INSERT INTO AgentTopupTx (AgentID,Amount,Remarks, Type) VALUES (@AgentID,@Amount,@Remarks,@Type)  "
			oCmdInsertTTSent = New SqlCommand(sSQL, oConn)
			With oCmdInsertTTSent.Parameters
				.Clear()
				.AddWithValue("@AgentID", sAgentId)
				.AddWithValue("@Amount", "-" & sTopupAmount)
				.AddWithValue("@Remarks", "To AgentID " & sTopupAgentId)
				.AddWithValue("@Type", "TRANSFERRED")
			End With

			sSQL = "INSERT INTO AgentTopupTx (AgentID,Amount,Remarks,Type) VALUES (@AgentID,@Amount,@Remarks,@Type)  "
			oCmdInsertTTReceived = New SqlCommand(sSQL, oConn)
			With oCmdInsertTTReceived.Parameters
				.Clear()
				.AddWithValue("@AgentID", sTopupAgentId)
				.AddWithValue("@Amount", sTopupAmount)
				.AddWithValue("@Remarks", "From AgentID " & sAgentId)
				.AddWithValue("@Type", "RECEIVED")
			End With


			oTrans = oConn.BeginTransaction()

			oCmdAddBal.Transaction = oTrans
			oCmdDeductBal.Transaction = oTrans
			oCmdInsertTTSent.Transaction = oTrans
			oCmdInsertTTReceived.Transaction = oTrans

			oCmdDeductBal.ExecuteNonQuery()
			oCmdDeductBal = Nothing
			oCmdAddBal.ExecuteNonQuery()
			oCmdAddBal = Nothing
			oCmdInsertTTSent.ExecuteNonQuery()
			oCmdInsertTTSent = Nothing
			oCmdInsertTTReceived.ExecuteNonQuery()
			oCmdInsertTTReceived = Nothing

			oTrans.Commit()

			oConn.Close()

			ProcessTT = True

		Catch ex As Exception
			If Not IsNothing(oTrans) Then
				oTrans.Rollback()
			End If
			ProcessTT = False
			'goLog.ErrorLog(ProcessorId & "~ProcessTT", ex.Message & vbNewLine & ex.StackTrace)
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
	Private Function GetAgentName(ByVal sAgentId As String, ByRef sAgentMSISDN As String) As String

		Dim oConn As New SqlConnection
		Dim oCmd As New SqlCommand
		Dim oDR As SqlDataReader
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""

		Try
			sSQL = "SELECT Name, HPNo FROM AgentInfo " &
									 "WHERE AgentId=@AgentId and Status=@Status "

			oConn = New SqlConnection()
			oConn.ConnectionString =
						ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

			oCmd = New SqlCommand
			oCmd.CommandText = sSQL
			oCmd.Connection = oConn
			oCmd.Connection.Open()

			oCmd.Parameters.Clear()
			oCmd.Parameters.Add(New SqlParameter("@AgentId", sAgentId))
			oCmd.Parameters.Add(New SqlParameter("@Status", STATUS_ACTIVE))
			oDR = oCmd.ExecuteReader

			If (oDR.Read) Then
				GetAgentName = oDR.Item("Name")
				sAgentMSISDN = oDR.Item("HPNo")
			Else
				GetAgentName = ""
			End If

			oDR.Close()


		Catch ex As Exception
			GetAgentName = ""
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

	Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click

		Dim sMTMSG As String = ""
		'If ProcessTopup(Me.txtAgentId.Text, Me.txtMaxisAmount.Text, Me.txtDiGiAmount.Text, Me.txtCelcomAmount.Text) Then
		'If LogAgentTopupTx(Me.txtAgentId.Text, Me.txtMaxisAmount.Text, Me.txtDiGiAmount.Text, Me.txtCelcomAmount.Text, Me.txtBankIn.Text, Me.txtRemarks.Text) Then

		If ProcessTopup(Me.DDLAgentID.SelectedValue, Me.txtMaxisAmount.Text) Then
			If LogAgentTopupTx(Me.DDLAgentID.SelectedValue, Me.txtMaxisAmount.Text, "0", Me.txtRemarks.Text) Then
				Me.lblErrorMsg.Text = "Topup success"
				Me.btnConfirm.Visible = False
				Me.btnCancel.Visible = False
				Me.btnSubmit.Visible = True
				Me.txtMaxisAmount.Enabled = True
				'Me.txtCelcomAmount.Enabled = True
				'Me.txtDiGiAmount.Enabled = True
				'Me.txtBankIn.Enabled = True
				Me.DDLAgentID.Enabled = True

				sMTMSG = MT_MSG.Replace("<Amount>", txtMaxisAmount.Text)
				'sMTMSG = sMTMSG.Replace("<DiGi>", txtDiGiAmount.Text)
				'sMTMSG = sMTMSG.Replace("<Celcom>", txtCelcomAmount.Text)
				sMTMSG = sMTMSG.Replace("<NewBalance>", getAgentBalance(DDLAgentID.SelectedValue))
				sMTMSG = sMTMSG.Replace("<DateTime>", Now())
				sMTMSG = sMTMSG.Replace("<Remarks>", txtRemarks.Text)

				InsertMT(Session("TopUpMSISDN"), sMTMSG)
				Session("TopUpMSISDN") = ""
			End If
		Else

		End If

	End Sub


	Private Function ProcessTopup(ByVal sAgentId As String, ByVal sMaxisReloadAmount As String) As Boolean

		Dim oConn As New SqlConnection
		Dim oCmd As New SqlCommand
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""

		ProcessTopup = False

		Try
			'If sTelco.ToUpper = "MAXIS" Then
			'sSQL = "UPDATE AgentBalance SET MaxisBalance=MaxisBalance+@MaxisReloadAmount,DiGiBalance=DiGiBalance+@DiGiReloadAmount,CelcomBalance=CelcomBalance+@CelcomReloadAmount  WHERE AgentId=@AgentId "
			sSQL = "UPDATE AgentBalance SET Balance=Balance+@MaxisReloadAmount WHERE AgentId=@AgentId "
			'ElseIf sTelco.ToUpper = "DIGI" Then
			'sSQL = "UPDATE AgentBalance SET DiGiBalance=DiGiBalance+@ReloadAmount WHERE AgentId=@AgentId "
			'ElseIf sTelco.ToUpper = "CELCOM" Then
			'sSQL = "UPDATE AgentBalance SET CelcomBalance=CelcomBalance+@ReloadAmount WHERE AgentId=@AgentId "
			'End If

			oConn = New SqlConnection()
			oConn.ConnectionString =
						ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

			oCmd = New SqlCommand
			oCmd.CommandText = sSQL
			oCmd.Connection = oConn
			oCmd.Connection.Open()

			oCmd.Parameters.Clear()
			oCmd.Parameters.Add(New SqlParameter("@AgentId", sAgentId))
			oCmd.Parameters.Add(New SqlParameter("@MaxisReloadAmount", sMaxisReloadAmount))
			'oCmd.Parameters.Add(New SqlParameter("@DiGiReloadAmount", sDiGiReloadAmount))
			'oCmd.Parameters.Add(New SqlParameter("@CelcomReloadAmount", sCelcomReloadAmount))

			oCmd.ExecuteNonQuery()

			ProcessTopup = True

		Catch ex As Exception
			ProcessTopup = False
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


	Private Function LogAgentTopupTx(ByVal sAgentId As String, ByVal sMaxisAmount As String, ByVal sBankIn As String, ByVal sRemarks As String) As Boolean

		Dim oConn As New SqlConnection
		Dim oCmd As New SqlCommand
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""

		LogAgentTopupTx = False

		Try
			sSQL = "INSERT INTO AgentTopupTx (AgentId, Amount, BankIn, Remarks, Status) VALUES (@AgentId, @MaxisAmount, @BankIn, @Remarks, @Status)"


			oConn = New SqlConnection()
			oConn.ConnectionString =
						ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

			oCmd = New SqlCommand
			oCmd.CommandText = sSQL
			oCmd.Connection = oConn
			oCmd.Connection.Open()

			oCmd.Parameters.Clear()
			oCmd.Parameters.Add(New SqlParameter("@AgentId", sAgentId))
			oCmd.Parameters.Add(New SqlParameter("@MaxisAmount", sMaxisAmount))
			'oCmd.Parameters.Add(New SqlParameter("@DiGiAmount", sDiGiAmount))
			'oCmd.Parameters.Add(New SqlParameter("@CelcomAmount", sCelcomAmount))
			oCmd.Parameters.Add(New SqlParameter("@BankIn", sBankIn))
			oCmd.Parameters.Add(New SqlParameter("@Remarks", sRemarks))
			oCmd.Parameters.Add(New SqlParameter("@Status", "SUCCESS"))

			oCmd.ExecuteNonQuery()
			LogAgentTopupTx = True


		Catch ex As Exception
			LogAgentTopupTx = False
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

	Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
		Me.btnConfirm.Visible = False
		Me.btnCancel.Visible = False
		Me.btnSubmit.Visible = True
		Me.txtMaxisAmount.Text = "0"
		'Me.txtDiGiAmount.Text = "0"
		'Me.txtCelcomAmount.Text = "0"
		'Me.txtAgentId.Text = ""
		Me.txtMaxisAmount.Enabled = True
		'Me.txtDiGiAmount.Enabled = True
		'Me.txtCelcomAmount.Enabled = True
		'Me.txtBankIn.Enabled = True
		Me.DDLAgentID.Enabled = True
		Me.lblName.Text = ""
	End Sub

	Private Function InsertMT(ByVal sMSISDN As String, ByVal sMsg As String, Optional ByVal sAgentId As String = "") As Boolean

		Dim sSQL As String = ""
		Dim oCmd As SqlCommand = Nothing
		Dim sLocalMTID As String
		Dim oConn As New SqlConnection

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
				.AddWithValue("@Robin", "1")
				.AddWithValue("@Status", "PENDING")
			End With
			oCmd.ExecuteNonQuery()

		Catch ex As Exception
			InsertMT = False
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


	Private Function getAgentBalance(ByVal sAgentId As String) As String

		Dim sSQL As String = ""
		Dim oCmd As New SqlCommand
		Dim oDR As SqlDataReader = Nothing
		Dim sMaxisBalance As String = "0"
		Dim sDiGiBalance As String = "0"
		Dim sCelcomBalance As String = "0"
		Dim oConn As New SqlConnection

		Try
			getAgentBalance = "[]"

			oConn = New SqlConnection()
			oConn.ConnectionString =
						ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

			oCmd = New SqlCommand
			oCmd.CommandText = sSQL
			oCmd.Connection = oConn
			oCmd.Connection.Open()

			sSQL = "SELECT Balance FROM AgentBalance WHERE AgentId=@AgentId "

			oCmd.CommandText = sSQL
			With oCmd.Parameters
				.Clear()
				.AddWithValue("@AgentId", sAgentId)
			End With
			oDR = oCmd.ExecuteReader

			If oDR.HasRows Then
				oDR.Read()
				sMaxisBalance = (oDR.Item("Balance"))
				'sDiGiBalance = (oDR.Item("DiGiBalance"))
				'sCelcomBalance = (oDR.Item("CelcomBalance"))
			End If
			oDR.Close()

			getAgentBalance = "Balance: SGD" & sMaxisBalance & ""

		Catch ex As Exception
			getAgentBalance = "Error getting balance."
			lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message
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
