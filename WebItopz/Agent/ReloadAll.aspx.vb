Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration.ConfigurationManager
Imports System.Threading.Thread

Partial Class Agent_ReloadAll
	Inherits System.Web.UI.Page

	Private Const STATUS_ACTIVE = "ACTIVE"
	'Private msMaxRobinDiGi As Integer = 1
	'Private msMaxRobinCelcom As Integer = 1
	'Private msMaxRobinMaxis As Integer = 1

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		If Session("AGENT_ID") = "" Then
			Server.Transfer("~/Agent/Agent_Login.aspx")
		End If

		Session("Telco") = Request("Telco")

		If Session("Telco") = "IN" Then
			Me.txtReloadAmount.Visible = True
			Me.DDLReloadAmount.Visible = True
		Else
			Me.txtReloadAmount.Visible = False
			Me.DDLReloadAmount.Visible = True
		End If
		Me.lblErrorMsg.Text = ""
		Me.lblReloadMSISDN.Text = ""
		Me.lblReloadAmount.Text = ""
		Me.lblReloadTelco.Text = ""

		If Not Page.IsPostBack Then
			Dim sNote As String = Nothing
			Dim aNote() As String
			Dim i As Integer
			sNote = getNote(getFirstTelco)
			aNote = sNote.Split(",")
			Me.DDLReloadAmount.Items.Clear()
			For i = 0 To UBound(aNote)
				Me.DDLReloadAmount.Items.Add(aNote(i))
			Next
		End If

	End Sub

	Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click

		Try
			If Me.txtReloadAmount.Text = "" Then
				txtReloadAmount.Text = Me.DDLReloadAmount.SelectedValue
			End If

			Me.btnEdit.Text = "Edit"
			If Me.txtReloadMSISDN.Text = "" Or (Me.txtReloadMSISDN.Text.Length < 8 Or txtReloadMSISDN.Text.Length > 12) Or Not IsNumeric(txtReloadMSISDN.Text) Then
				Me.lblErrorMsg.Text = "Invalid Reload Number! (8-14 digit)"
			ElseIf Session("Telco") = "IN" And Not IsNumeric(txtReloadAmount.Text) Then
				Me.lblErrorMsg.Text = "Invalid Reload Amount! Must be DiGit"
			Else
				If Session("Telco") = "IN" Then
					If Me.txtReloadAmount.Text = "" Then
						Me.lblErrorMsg.Text = "Empty Reload Amount! (50-1000)"
					ElseIf Me.txtReloadAmount.Text < 50 And Me.txtReloadAmount.Text > 1000 Then
						Me.lblErrorMsg.Text = "Invalid Reload Amount! (50-1000)"
					Else
						Me.btnSubmit.Visible = False
						Me.txtReloadMSISDN.Enabled = False
						Me.DDLReloadAmount.Enabled = False
						Me.txtReloadAmount.Enabled = False
						Me.btnConfirm.Visible = True
						Me.btnEdit.Visible = True
						Me.lblReloadMSISDN.Text = txtReloadMSISDN.Text & ""
						If Session("Telco") = "IN" Then
							Me.lblReloadAmount.Text = "$" & Me.txtReloadAmount.Text
						Else
							Me.lblReloadAmount.Text = "$" & DDLReloadAmount.SelectedValue
						End If

						Me.lblReloadTelco.Text = Me.DDLTelco.SelectedValue
						Me.DDLTelco.Enabled = False
					End If
				Else
					Me.btnSubmit.Visible = False
					Me.txtReloadMSISDN.Enabled = False
					Me.DDLReloadAmount.Enabled = False
					Me.txtReloadAmount.Enabled = False
					Me.btnConfirm.Visible = True
					Me.btnEdit.Visible = True
					Me.lblReloadMSISDN.Text = txtReloadMSISDN.Text & ""
					Me.lblReloadAmount.Text = "$" & DDLReloadAmount.SelectedValue
					Me.lblReloadTelco.Text = Me.DDLTelco.SelectedValue
					Me.DDLTelco.Enabled = False
				End If

			End If
		Catch ex As Exception
			Me.lblErrorMsg.Text = ex.Message & ex.StackTrace
		End Try

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
		Dim iNewBalance As Decimal
		Dim iRobin As Integer
		Dim dCommission As Decimal = 0
		Dim sProductID As String = ""
		Dim bAllow As Boolean = True
		Dim sProcessorID As String = "MOP1"
		Dim sRebateID As String = ""
		Dim dRebate As Decimal = 0

		Try
			oConn.Open()
			oCmd = oConn.CreateCommand
			oCmd.Connection = oConn

			aMOMsg = sMOMsg.Split(" ")


			If UBound(aMOMsg) = 1 Then
				sReloadAmount = aMOMsg(1)
				sReloadMSISDN = aMOMsg(0)
				sReloadTelco = Me.DDLTelco.SelectedValue  'GetPrefix("6" & sReloadMSISDN)
				If Not IsNumeric(sReloadAmount) Then bValid = False
				If Not IsNumeric(sReloadMSISDN) Then bValid = False
				If sReloadMSISDN.Length < "8" And sReloadMSISDN.Length > "14" Then
					bValid = False
				End If

				If sReloadTelco = "" Then bValid = False
			Else
				bValid = False
			End If

			sAgentId = Session("AGENT_ID") 'getAgentID(sAgentPin, sMSISDN, oConn)

			If sAgentId = "" Then
				bValid = False
				sErrorCode = "Invalid_AgentPinOrMSISDNOrInactiveStatus"
			End If

			'Response.Write(sReloadMSISDN & "<BR>")
			'Response.Write(sReloadAmount & "<BR>")
			'Response.Write(sReloadTelco & "<BR>")

			If CheckLastReloadTS(sReloadMSISDN, sReloadAmount, sReloadTelco, oConn) Then
				bValid = False
				sErrorCode = "Duplication Reload Submitted"
			End If

			sProductID = getProductID(sReloadTelco)
			sRebateID = GetRebateID(sReloadAmount, sProductID, oConn)
			'Me.lblReloadTelco.Text = "sRebateID=" & sRebateID

			If bValid Then
				Dim aRebate As Decimal = 0 'agent rebate
				If sRebateID <> "" Then
					aRebate = getAgentRebate(sAgentId, sRebateID, oConn)
					'Me.lblReloadMSISDN.Text = "aRebate=" & aRebate.ToString
				End If
				If deductBalance(sAgentId, sReloadAmount, sReloadTelco, sProductID, iNewBalance, aRebate, oConn, bAllow) Then
					InsertTxReload(sLocalMOID, sAgentId, sReloadMSISDN, sReloadAmount, sReloadTelco, iNewBalance, oConn)
					sStatus = "PENDING"
				Else
					If bAllow Then
						sErrorCode = "Insufficient_Balance"
					Else
						sErrorCode = "Product Not Allow"
					End If
				End If
			End If

			iRobin = getPostRobin(sReloadTelco)
			dCommission = getCommission(sAgentId, sReloadTelco, sReloadAmount, sProductID, oConn)
			If sRebateID <> "" Then
				dRebate = getDealerRebate(sAgentId, sReloadAmount, sRebateID, oConn)
				dCommission = dCommission + dRebate
			End If

			sSQL = "INSERT INTO TxIn (LocalMOID, MSISDN, AgentID, MessageIn, MessageTS, ReloadMSISDN, ReloadAmount, ReloadTelco,ReloadType, Robin, Status, ErrorCode,Commission) " &
										"VALUES (@LocalMOID, @MSISDN, @AgentID, @MessageIn, @MessageTS, @ReloadMSISDN, @ReloadAmount, @ReloadTelco, @ReloadType, @Robin,@Status, @ErrorCode,@Commission) "

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
				.AddWithValue("@Commission", dCommission)
			End With
			oCmd.ExecuteNonQuery()

			If sErrorCode <> "" Then
				Me.lblErrorMsg.Text = sErrorCode
				Me.txtReloadMSISDN.Enabled = True
				Me.DDLReloadAmount.Enabled = True
				Me.txtReloadAmount.Enabled = True
				Me.btnConfirm.Visible = False
				Me.btnConfirm.Enabled = True
				Me.btnEdit.Visible = False
				Me.btnSubmit.Visible = True
				Me.DDLTelco.Enabled = True
			Else
				'Me.DDLReloadAmount.Text = ""
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

	Private Function getAgentID(ByVal sMSISDN As String, ByVal oConn As SqlConnection) As String

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

	Private Function deductBalance(ByVal sAgentId As String, ByVal sReloadAmount As Integer, ByVal sReloadTelco As String, ByVal sProductID As String, ByRef iNewBalance As Decimal, ByVal aRebate As Decimal, ByVal oConn As SqlConnection, ByRef bAllow As Boolean) As Boolean

		Dim sSQL As String = ""
		Dim sSQLUpdate As String = ""
		Dim oCmd As New SqlCommand
		Dim oCmdUpdate As New SqlCommand
		Dim oDR As SqlDataReader = Nothing
		Dim iBalance As Decimal
		Dim iDiscount As Decimal
		Dim sStatus As String = ""
		'Dim oConn As New SqlConnection(gsDBConnString)
		Dim oConnUpdate As New SqlConnection(ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString)

		deductBalance = True

		Try
			'oConn.Open()
			oCmd = oConn.CreateCommand
			oCmd.Connection = oConn
			sSQL = "SELECT     dbo.AgentBalance.Balance, dbo.AgentProduct.Discount,dbo.AgentProduct.Status " &
									 "FROM         dbo.AgentBalance INNER JOIN " &
									 "dbo.AgentProduct ON dbo.AgentBalance.AgentID = dbo.AgentProduct.AgentID " &
									 "WHERE     (dbo.AgentProduct.AgentID = @AgentID) AND (dbo.AgentProduct.ProductID = @ProductID) " 'and dbo.AgentBalance.Balance>=@ReloadAmount "
			'sSQL = "SELECT Discount, b.Balance as Balance FROM AgentInfo a, AgentBalance b WHERE a.AgentID=@AgentID and a.AgentID = b.AgentID and b.balance>=@ReloadAmount "


			oCmd.CommandText = sSQL
			With oCmd.Parameters
				.Clear()
				.AddWithValue("@AgentID", sAgentId)
				.AddWithValue("@ReloadAmount", sReloadAmount)
				.AddWithValue("@ProductID", sProductID)
			End With
			oDR = oCmd.ExecuteReader

			If oDR.HasRows Then
				oDR.Read()
				iDiscount = oDR.Item("Discount") + aRebate
				'Me.lblReloadAmount.Text = "iDiscount=" & iDiscount & "sProductID" & sProductID & "aRebate=" & aRebate
				iBalance = oDR.Item("Balance")
				sStatus = oDR.Item("Status").ToString.ToUpper

				If sStatus <> "ACTIVE" Then
					deductBalance = False
					bAllow = False
				Else
					If iBalance >= (sReloadAmount - (sReloadAmount * (iDiscount / 100))) Then


						iNewBalance = iBalance - (sReloadAmount - (sReloadAmount * (iDiscount / 100)))

						'goLog.DebugLog("iDiscount", iDiscount)
						'goLog.DebugLog("iBalance", iBalance)
						'goLog.DebugLog("sReloadAmount", sReloadAmount)
						'goLog.DebugLog("iNewBalance", iNewBalance)

						sSQLUpdate = "UPDATE AgentBALANCE SET  Balance=@NewBalance WHERE AgentID=@AgentID"

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
				End If


			Else
				deductBalance = False
			End If

		Catch ex As Exception
			deductBalance = False
			'goLog.ErrorLog(ProcessorId & "~deductBalance", ex.Message & ex.StackTrace)
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


	'Private Function deductBalance(ByVal sAgentId As String, ByVal sReloadAmount As Integer, ByVal sReloadTelco As String, ByRef iNewBalance As Decimal, ByVal oConn As SqlConnection) As Boolean

	'    Dim sSQL As String = ""
	'    Dim sSQLUpdate As String = ""
	'    Dim oCmd As New SqlCommand
	'    Dim oCmdUpdate As New SqlCommand
	'    Dim oDR As SqlDataReader = Nothing
	'    Dim iBalance As Decimal
	'    Dim iDiscount As Decimal 
	'    Dim oConnUpdate As New SqlConnection(ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString)

	'    deductBalance = True

	'    Try
	'        'oConn.Open()
	'        oCmd = oConn.CreateCommand
	'        oCmd.Connection = oConn
	'        'If sReloadTelco = "MAXIS" Then
	'        '    'sSQL = "SELECT MAXISBalance as Balance FROM AgentBALANCE WHERE AgentID=@AgentID and MAXISBalance>=@ReloadAmount "
	'        '    sSQL = "SELECT  a.DiscountMaxis  as Discount, b.Balance as Balance FROM AgentInfo a, AgentBalance b WHERE a.AgentID=@AgentID and a.AgentID = b.AgentID and b.balance>=@ReloadAmount "
	'        'ElseIf sReloadTelco = "DIGI" Then
	'        '    'sSQL = "SELECT DIGIBalance as Balance FROM AgentBALANCE WHERE AgentID=@AgentID and DIGIBalance>=@ReloadAmount "
	'        '    sSQL = "SELECT  a.DiscountDiGi  as Discount, b.Balance as Balance FROM AgentInfo a, AgentBalance b WHERE a.AgentID=@AgentID and a.AgentID = b.AgentID and b.balance>=@ReloadAmount "
	'        'ElseIf sReloadTelco = "CELCOM" Then
	'        '    'sSQL = "SELECT CelcomBalance as Balance FROM AgentBALANCE WHERE AgentID=@AgentID and CelcomBalance>=@ReloadAmount "
	'        '    sSQL = "SELECT  a.DiscountCelcom  as Discount, b.Balance as Balance FROM AgentInfo a, AgentBalance b WHERE a.AgentID=@AgentID and a.AgentID = b.AgentID  and b.balance>=@ReloadAmount "
	'        'End If
	'        If sReloadTelco = "MAXIS" Then
	'            sSQL = "SELECT  a.DiscountMaxis  as Discount, b.Balance as Balance FROM AgentInfo a, AgentBalance b WHERE a.AgentID=@AgentID and a.AgentID = b.AgentID and b.balance>=@ReloadAmount "
	'        ElseIf sReloadTelco = "DIGI" Then
	'            sSQL = "SELECT  a.DiscountDiGi  as Discount, b.Balance as Balance FROM AgentInfo a, AgentBalance b WHERE a.AgentID=@AgentID and a.AgentID = b.AgentID and b.balance>=@ReloadAmount "
	'        ElseIf sReloadTelco = "CELCOM" Then
	'            sSQL = "SELECT  a.DiscountCelcom  as Discount, b.Balance as Balance FROM AgentInfo a, AgentBalance b WHERE a.AgentID=@AgentID and a.AgentID = b.AgentID  and b.balance>=@ReloadAmount "
	'        ElseIf sReloadTelco = "UMOBILE" Then
	'            sSQL = "SELECT  a.DiscountUmobile  as Discount, b.Balance as Balance FROM AgentInfo a, AgentBalance b WHERE a.AgentID=@AgentID and a.AgentID = b.AgentID  and b.balance>=@ReloadAmount "
	'        ElseIf sReloadTelco = "MAXISPIN" Then
	'            sSQL = "SELECT  a.DiscountMaxisPin  as Discount, b.Balance as Balance FROM AgentInfo a, AgentBalance b WHERE a.AgentID=@AgentID and a.AgentID = b.AgentID  and b.balance>=@ReloadAmount "
	'        ElseIf sReloadTelco = "DIGIPIN" Then
	'            sSQL = "SELECT  a.DiscountDiGiPin  as Discount, b.Balance as Balance FROM AgentInfo a, AgentBalance b WHERE a.AgentID=@AgentID and a.AgentID = b.AgentID  and b.balance>=@ReloadAmount "
	'        ElseIf sReloadTelco = "CELCOMPIN" Then
	'            sSQL = "SELECT  a.DiscountCelcomPin  as Discount, b.Balance as Balance FROM AgentInfo a, AgentBalance b WHERE a.AgentID=@AgentID and a.AgentID = b.AgentID  and b.balance>=@ReloadAmount "
	'        ElseIf sReloadTelco = "ITALKPIN" Then
	'            sSQL = "SELECT  a.DiscountITALKPin  as Discount, b.Balance as Balance FROM AgentInfo a, AgentBalance b WHERE a.AgentID=@AgentID and a.AgentID = b.AgentID  and b.balance>=@ReloadAmount "
	'        ElseIf sReloadTelco = "UMOBILEPIN" Then
	'            sSQL = "SELECT  a.DiscountUMobilePin  as Discount, b.Balance as Balance FROM AgentInfo a, AgentBalance b WHERE a.AgentID=@AgentID and a.AgentID = b.AgentID  and b.balance>=@ReloadAmount "
	'        ElseIf sReloadTelco = "XOXPIN" Then
	'            sSQL = "SELECT  a.DiscountXOXPin  as Discount, b.Balance as Balance FROM AgentInfo a, AgentBalance b WHERE a.AgentID=@AgentID and a.AgentID = b.AgentID  and b.balance>=@ReloadAmount "
	'        ElseIf sReloadTelco = "TUNETALKPIN" Then
	'            sSQL = "SELECT  a.DiscountTUNETALKPin  as Discount, b.Balance as Balance FROM AgentInfo a, AgentBalance b WHERE a.AgentID=@AgentID and a.AgentID = b.AgentID  and b.balance>=@ReloadAmount "
	'        ElseIf sReloadTelco = "INDOPIN" Then
	'            sSQL = "SELECT  a.DiscountINDOPin  as Discount, b.Balance as Balance FROM AgentInfo a, AgentBalance b WHERE a.AgentID=@AgentID and a.AgentID = b.AgentID  and b.balance>=@ReloadAmount "
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
	'            iDiscount = oDR.Item("Discount")
	'            iBalance = oDR.Item("Balance")

	'            iNewBalance = iBalance - (sReloadAmount - (sReloadAmount * (iDiscount / 100)))


	'            sSQLUpdate = "UPDATE AgentBALANCE SET  Balance=@NewBalance WHERE AgentID=@AgentID"
	'            'If sReloadTelco = "MAXIS" Then
	'            '    sSQLUpdate = "UPDATE AgentBALANCE SET MaxisBalance=@NewBalance WHERE AgentID=@AgentID"
	'            'ElseIf sReloadTelco = "DIGI" Then
	'            '    sSQLUpdate = "UPDATE AgentBALANCE SET DiGiBalance=@NewBalance WHERE AgentID=@AgentID"
	'            'ElseIf sReloadTelco = "CELCOM" Then
	'            '    sSQLUpdate = "UPDATE AgentBALANCE SET CelcomBalance=@NewBalance WHERE AgentID=@AgentID"
	'            'End If
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



	Private Function InsertTxReload(ByVal sLocalMOID As String, ByVal sAgentId As String, ByVal sReloadMSISDN As String, ByVal sReloadAmount As Integer, ByVal sReloadTelco As String, ByVal iNewBalance As Decimal, ByVal oConn As SqlConnection) As Boolean

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


	Private Function getCommission(ByVal sAgentID As String, ByVal sReloadTelco As String, ByVal sReloadAmount As String, ByVal sProductID As String, ByVal oConn As SqlConnection) As Decimal

		Dim sSQL As String = ""
		Dim sSQLDealer As String = ""
		Dim oCmd As New SqlCommand
		Dim oDR As SqlDataReader = Nothing
		Dim dDiscountDealer As Decimal = 0
		Dim dDiscountAgent As Decimal = 0

		Try

			sSQL = "SELECT Discount as DiscountAgent FROM AgentProduct WHERE AgentID=@AgentID and ProductID=@ProductID"
			sSQLDealer = "SELECT Discount as DiscountDealer FROM AgentProduct where ProductID=@ProductID and agentID=(SELECT ParentAgentID FROM AgentInfo where agentid=@AgentID)"


			oCmd = oConn.CreateCommand
			oCmd.Connection = oConn
			oCmd.CommandText = sSQLDealer
			With oCmd.Parameters
				.Clear()
				.AddWithValue("@AgentID", sAgentID)
				.AddWithValue("@ProductID", sProductID)
			End With
			oDR = oCmd.ExecuteReader
			If oDR.HasRows Then
				oDR.Read()
				dDiscountDealer = oDR.Item("DiscountDealer")
			End If
			oDR.Close()
			oCmd = Nothing


			If dDiscountDealer > 0 Then
				oCmd = oConn.CreateCommand
				oCmd.Connection = oConn
				oCmd.CommandText = sSQL
				With oCmd.Parameters
					.Clear()
					.AddWithValue("@AgentID", sAgentID)
					.AddWithValue("@ProductID", sProductID)
				End With
				oDR = oCmd.ExecuteReader
				If oDR.HasRows Then
					oDR.Read()
					dDiscountAgent = oDR.Item("DiscountAgent")
				End If
				oDR.Close()
				oCmd = Nothing
				getCommission = sReloadAmount * ((dDiscountDealer - dDiscountAgent) / 100)

			End If
			'oConn.Close()

		Catch ex As Exception
			getCommission = 0
			'goLog.ErrorLog(ProcessorId & "~getCommission", ex.Message)
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

	Private Function CheckLastReloadTS(ByVal sReloadMSISDN As String, ByVal sReloadAmount As String, ByVal sReloadTelco As String, ByVal oConn As SqlConnection) As Boolean

		Dim sSQL As String = ""
		Dim oCmd As New SqlCommand
		Dim oDR As SqlDataReader = Nothing
		Dim sAgentID As String = ""

		CheckLastReloadTS = False

		Try
			oCmd = oConn.CreateCommand
			oCmd.Connection = oConn
			sSQL = "SELECT LocalMOID FROM TxIn WHERE ReloadTelco NOT LIKE '%PIN' and ReloadMSISDN=@ReloadMSISDN and ReloadAmount=@ReloadAmount and datediff(n,CreatedTS,getdate()) < '30'  and (STATUS='SUCCESS' or STATUS='PENDING' or STATUS='COMPLETED') "

			If sSQL <> "" Then
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
			End If

		Catch ex As Exception
			CheckLastReloadTS = False
			'goLog.ErrorLog(ProcessorId & "~CheckLastReloadTS", ex.Message & ex.StackTrace)
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


	Private Function getPostRobin(ByVal sReloadTelco As String) As String

		Dim sSQL As String = ""
		Dim oConn As New SqlConnection(ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString)
		Dim oCmd As New SqlCommand
		Dim oDR As SqlDataReader = Nothing
		getPostRobin = 1

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

			If oDR.Read() Then
				getPostRobin = (oDR.Item("Robin"))
			End If
			oDR.Close()
			oConn.Close()

			If getPostRobin > getMaxPostRobin(sReloadTelco) Then
				getPostRobin = 1
			End If

			' goLog.InfoLog("sReloadTelco", sReloadTelco)
			' goLog.InfoLog("getPostRobin", getPostRobin)


		Catch ex As Exception
			' goLog.ErrorLog(ProcessorId & "~getProcessorSetting", ex.Message)
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

	End Function

	Private Function getMaxPostRobin(ByVal sTelco As String) As String

		Dim sSQL As String = ""
		Dim oConn As New SqlConnection(ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString)
		Dim oCmd As New SqlCommand
		Dim oDR As SqlDataReader = Nothing
		getMaxPostRobin = 1

		Try
			oConn.Open()
			oCmd = oConn.CreateCommand
			oCmd.Connection = oConn
			sSQL = "SELECT MaxRobin FROM PostRobin WHERE Telco=@Telco"

			oCmd.CommandText = sSQL
			With oCmd.Parameters
				.Clear()
				.AddWithValue("@Telco", sTelco)
			End With
			oDR = oCmd.ExecuteReader
			If oDR.Read Then
				getMaxPostRobin = (oDR.Item("MaxRobin"))
			End If
			oDR.Close()
			oConn.Close()


		Catch ex As Exception
			getMaxPostRobin = 1
			'goLog.ErrorLog(ProcessorId & "~getMaxPostRobin", ex.Message)
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

	End Function

	Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
		Dim sMsg As String
		If Session("Telco") = "IN" Then
			sMsg = txtReloadMSISDN.Text & " " & Me.txtReloadAmount.Text
		Else
			sMsg = txtReloadMSISDN.Text & " " & Me.DDLReloadAmount.Text
		End If
		Me.btnConfirm.Enabled = False
		Me.btnEdit.Text = "New"
		InsertIntoTxIn(Session("AGENT_MSISDN"), sMsg, Format(Now(), "yyyyMMddHHmmss"))
		'Response.Write(Session("AGENT_MSISDN") & "---" & sMsg)
	End Sub

	Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click

		Me.txtReloadMSISDN.Enabled = True
		Me.DDLReloadAmount.Enabled = True
		Me.txtReloadAmount.Enabled = True
		Me.btnConfirm.Visible = False
		Me.btnEdit.Visible = False
		Me.btnSubmit.Visible = True
		Me.DDLTelco.Enabled = True
		Me.btnConfirm.Enabled = True
	End Sub

	Protected Sub DDLTelco_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
		DDLReloadAmount.Items.Clear()
		getNote(DDLTelco.SelectedValue)
	End Sub


	Private Function getNote(ByVal sTelco As String) As String

		Dim sSQL As String = ""
		Dim oConn As New SqlConnection(ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString)
		Dim oCmd As New SqlCommand
		Dim oDR As SqlDataReader = Nothing
		getNote = 1

		Try
			oConn.Open()
			oCmd = oConn.CreateCommand
			oCmd.Connection = oConn
			sSQL = "SELECT Note FROM ProductInfo WHERE Telco=@Telco"

			oCmd.CommandText = sSQL
			With oCmd.Parameters
				.Clear()
				.AddWithValue("@Telco", sTelco)
			End With
			oDR = oCmd.ExecuteReader
			If oDR.Read Then
				getNote = (oDR.Item("Note"))
			End If
			oDR.Close()
			oConn.Close()


			Dim aNote() As String
			Dim i As Integer = 0

			aNote = getNote.Split(",")

			For i = 0 To UBound(aNote)
				Me.DDLReloadAmount.Items.Add(aNote(i))
			Next

		Catch ex As Exception
			getNote = 1
			'goLog.ErrorLog(ProcessorId & "~getMaxPostRobin", ex.Message)
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

	End Function


	Private Function getProductID(ByVal sTelco As String) As String

		Dim sSQL As String = ""
		Dim oConn As New SqlConnection(ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString)
		Dim oCmd As New SqlCommand
		Dim oDR As SqlDataReader = Nothing
		getProductID = 0

		Try
			oConn.Open()
			oCmd = oConn.CreateCommand
			oCmd.Connection = oConn
			sSQL = "SELECT ProductID FROM ProductInfo WHERE Telco=@Telco"

			oCmd.CommandText = sSQL
			With oCmd.Parameters
				.Clear()
				.AddWithValue("@Telco", sTelco)
			End With
			oDR = oCmd.ExecuteReader
			If oDR.Read Then
				getProductID = (oDR.Item("ProductID"))
			End If
			oDR.Close()
			oConn.Close()


		Catch ex As Exception
			getProductID = 0
			'goLog.ErrorLog(ProcessorId & "~getMaxPostRobin", ex.Message)
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

	End Function




	Private Function getDealerRebate(ByVal sAgentID As String, ByVal sReloadAmount As String, ByVal sRebateID As String, ByVal oConn As SqlConnection) As Decimal

		Dim sSQL As String = ""
		Dim sSQLDealer As String = ""
		Dim oCmd As New SqlCommand
		Dim oDR As SqlDataReader = Nothing
		Dim dDiscountDealer As Decimal = 0
		Dim dDiscountAgent As Decimal = 0

		Try

			sSQL = "SELECT Rebate as DiscountAgent FROM AgentProductRebate WHERE AgentID=@AgentID and RebateID=@RebateID"
			sSQLDealer = "SELECT Rebate as DiscountDealer FROM AgentProductRebate where RebateID=@RebateID and agentID=(SELECT ParentAgentID FROM AgentInfo where agentid=@AgentID)"


			oCmd = oConn.CreateCommand
			oCmd.Connection = oConn
			oCmd.CommandText = sSQLDealer
			With oCmd.Parameters
				.Clear()
				.AddWithValue("@AgentID", sAgentID)
				.AddWithValue("@RebateID", sRebateID)
			End With
			oDR = oCmd.ExecuteReader
			If oDR.HasRows Then
				oDR.Read()
				dDiscountDealer = oDR.Item("DiscountDealer")
			End If
			oDR.Close()
			oCmd = Nothing


			If dDiscountDealer > 0 Then
				oCmd = oConn.CreateCommand
				oCmd.Connection = oConn
				oCmd.CommandText = sSQL
				With oCmd.Parameters
					.Clear()
					.AddWithValue("@AgentID", sAgentID)
					.AddWithValue("@RebateID", sRebateID)
				End With
				oDR = oCmd.ExecuteReader
				If oDR.HasRows Then
					oDR.Read()
					dDiscountAgent = oDR.Item("DiscountAgent")
				End If
				oDR.Close()
				oCmd = Nothing
				getDealerRebate = sReloadAmount * ((dDiscountDealer - dDiscountAgent) / 100)
			End If
			'oConn.Close()

		Catch ex As Exception
			getDealerRebate = 0
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

	Private Function GetRebateID(ByVal sValue As String, ByVal sProductID As String, ByVal oConn As SqlConnection) As String

		Dim i As Integer = 0
		Dim sSQL As String = ""
		'Dim oConn As New SqlConnection(gsDBConnString)
		Dim oCmd As New SqlCommand
		Dim oDR As SqlDataReader = Nothing
		Dim sRebateID As String = ""
		Dim sDenomination As String = ""
		Dim aDenomination() As String = Nothing

		GetRebateID = Nothing

		Try
			'oConn.Open()
			oCmd = oConn.CreateCommand
			oCmd.Connection = oConn

			sSQL = "SELECT RebateID,Denomination FROM ProductRebate WHERE ProductID=@ProductID"

			oCmd.CommandText = sSQL
			With oCmd.Parameters
				.Clear()
				.AddWithValue("@ProductID", sProductID)
			End With
			oDR = oCmd.ExecuteReader

			While oDR.Read
				sDenomination = oDR.Item("Denomination")

				If sDenomination.Contains("-") Then
					sDenomination = Expend(sDenomination, "-")
					aDenomination = sDenomination.Split(",")
					For i = 0 To UBound(aDenomination)
						If aDenomination(i) = sValue Then
							sRebateID = oDR.Item("RebateID")
							Exit For
						End If
					Next
				Else
					If sDenomination = sValue Then
						sRebateID = oDR.Item("RebateID")
					End If
				End If

				If sRebateID <> "" Then
					Exit While
				End If

			End While
			oDR.Close()

			Return sRebateID

		Catch ex As Exception
			'MsgBox(ex.Message & "  " & ex.StackTrace)
			Return Nothing
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

	Private Function Expend(ByVal sValue As String, ByVal sdelimiter As String) As String

		Dim sStart As String = Nothing
		Dim sEnd As String = Nothing
		Dim aValue() As String
		Dim i As Integer = 0
		Dim sFinalvalue As String = Nothing
		Expend = Nothing

		Try
			aValue = sValue.Split(sdelimiter)
			If UBound(aValue) = 1 Then
				sStart = aValue(0)
				sEnd = aValue(1)

				For i = sStart To sEnd
					If sFinalvalue = Nothing Then
						sFinalvalue = i
					Else
						sFinalvalue = sFinalvalue & "," & i
					End If
				Next

				Expend = sFinalvalue
			End If
			Return Expend
		Catch ex As Exception
			'MsgBox(ex.Message & "  " & ex.StackTrace)
			Return Nothing
		End Try

	End Function

	Private Function getAgentRebate(ByVal sAgentId As String, ByVal sRebateID As String, ByVal oConn As SqlConnection) As Decimal

		Dim sSQL As String = ""
		Dim oCmd As New SqlCommand
		Dim oDR As SqlDataReader = Nothing
		Dim sBalance As Decimal = 0

		Try
			getAgentRebate = 0
			'oConn.Open()
			oCmd = oConn.CreateCommand
			oCmd.Connection = oConn

			sSQL = "SELECT Rebate FROM AgentProductRebate WHERE AgentID=@AgentID and RebateID=@RebateID"
			oCmd.CommandText = sSQL
			With oCmd.Parameters
				.Clear()
				.AddWithValue("@AgentID", sAgentId)
				.AddWithValue("@RebateID", sRebateID)
			End With
			oDR = oCmd.ExecuteReader
			If oDR.HasRows Then
				oDR.Read()
				getAgentRebate = oDR.Item("Rebate")
			End If
			oDR.Close()
			'oConn.Close()
		Catch ex As Exception
			getAgentRebate = 0
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

	Private Function getFirstTelco() As String

		Dim sSQL As String = ""
		Dim oCmd As New SqlCommand
		Dim oDR As SqlDataReader = Nothing
		Dim oConn As New SqlConnection(ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString)
		Dim sBalance As Decimal = 0

		Try
			getFirstTelco = ""
			oConn.Open()
			oCmd = oConn.CreateCommand
			oCmd.Connection = oConn

			sSQL = "SELECT TOP 1 Telco FROM ProductInfo WHERE STATUS=@STATUS and telco like @Telco+'%'"
			oCmd.CommandText = sSQL
			With oCmd.Parameters
				.Clear()
				.AddWithValue("@STATUS", STATUS_ACTIVE)
				.AddWithValue("@Telco", Session("Telco"))
			End With
			oDR = oCmd.ExecuteReader
			If oDR.HasRows Then
				oDR.Read()
				getFirstTelco = oDR.Item("Telco")
			End If
			oDR.Close()
			oConn.Close()
		Catch ex As Exception
			getFirstTelco = ""
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

	End Function

End Class
