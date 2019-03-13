Imports System.Data.SqlClient

Partial Class TdID
	Inherits System.Web.UI.Page

	Private Const STATUS_ACTIVE = "ACTIVE"

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Session("AGENT_ID") = "" Then
			Response.Redirect("~/Master/Login.aspx")
		End If

		Me.lblErrorMsg.Text = ""
		Me.lblBalance.Text = ""
		Me.lblErrorSIM.Text = ""
	End Sub


	Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click

		Dim sSIMCardId As String = ""
		Dim sBalance As String = ""

		If Me.txtSIMCardId.Text = "" Or Not IsNumeric(Me.txtSIMCardId.Text) Then
			Me.lblErrorMsg.Text = "empty agent id or invalid agent id!"
		ElseIf Me.txtAmount.Text = "" Or Not IsNumeric(Me.txtAmount.Text) Then
			Me.lblErrorMsg.Text = "empty amount or invalid amount!"
		Else
			sSIMCardId = GetSIMCardID(Me.txtSIMCardId.Text, sBalance)

			If sSIMCardId <> "" Then
				Me.lblBalance.Text = sBalance
				Me.btnConfirm.Visible = True
				Me.btnCancel.Visible = True
				Me.btnSubmit.Visible = False
				Me.txtAmount.Enabled = False
				Me.txtSIMCardId.Enabled = False
			Else
				Me.lblErrorMsg.Text = "invalid agent id!"
			End If


		End If


	End Sub


	Private Function GetSIMCardID(ByVal sSIMCardId As String, ByRef sBalance As String) As String

		Dim oConn As New SqlConnection
		Dim oCmd As New SqlCommand
		Dim oDR As SqlDataReader
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""

		Try
			sSQL = "SELECT SIMCardId, Balance FROM SIMCard " &
									 "WHERE SIMCardId=@SIMCardId and Status=@Status "

			oConn = New SqlConnection()
			oConn.ConnectionString =
						ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

			oCmd = New SqlCommand
			oCmd.CommandText = sSQL
			oCmd.Connection = oConn
			oCmd.Connection.Open()

			oCmd.Parameters.Clear()
			oCmd.Parameters.Add(New SqlParameter("@SIMCardId", sSIMCardId))
			oCmd.Parameters.Add(New SqlParameter("@Status", STATUS_ACTIVE))
			oDR = oCmd.ExecuteReader

			If (oDR.Read) Then
				GetSIMCardID = oDR.Item("SIMCardId")
				sBalance = oDR.Item("Balance")
			Else
				GetSIMCardID = ""
			End If

			oDR.Close()


		Catch ex As Exception
			GetSIMCardID = ""
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

		If ProcessTopup(Me.txtSIMCardId.Text, Me.txtAmount.Text) Then
		Else
			If LogAgentTopupTx(Me.txtSIMCardId.Text, Me.txtAmount.Text) Then
				Me.lblErrorMsg.Text = "Topup success!"
				Me.btnConfirm.Visible = False
				Me.btnCancel.Visible = False
				Me.btnSubmit.Visible = True
				Me.txtAmount.Enabled = True
				Me.txtSIMCardId.Enabled = True

			End If
		End If

	End Sub


	Private Function ProcessTopup(ByVal sSimCardId As String, ByVal sReloadAmount As String) As Boolean

		Dim oConn As New SqlConnection
		Dim oCmd As New SqlCommand
		'Dim oDR As SqlDataReader
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""

		ProcessTopup = False

		Try

			sSQL = "UPDATE SimCard SET Balance=Balance+@ReloadAmount WHERE SimCardId=@SimCardId "


			oConn = New SqlConnection()
			oConn.ConnectionString =
						ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

			oCmd = New SqlCommand
			oCmd.CommandText = sSQL
			oCmd.Connection = oConn
			oCmd.Connection.Open()

			oCmd.Parameters.Clear()
			oCmd.Parameters.Add(New SqlParameter("@SimCardId", sSimCardId))
			oCmd.Parameters.Add(New SqlParameter("@ReloadAmount", sReloadAmount))

			oCmd.ExecuteNonQuery()

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


	Private Function LogAgentTopupTx(ByVal sSimCardId As String, ByVal sAmount As String) As Boolean

		Dim oConn As New SqlConnection
		Dim oCmd As New SqlCommand
		'Dim oDR As SqlDataReader
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""

		LogAgentTopupTx = False

		Try
			sSQL = "INSERT INTO SIMCardTopupTx (SimCardId,Amount) VALUES (@SimCardId,@Amount)"


			oConn = New SqlConnection()
			oConn.ConnectionString =
						ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

			oCmd = New SqlCommand
			oCmd.CommandText = sSQL
			oCmd.Connection = oConn
			oCmd.Connection.Open()

			oCmd.Parameters.Clear()
			oCmd.Parameters.Add(New SqlParameter("@SimCardId", sSimCardId))
			oCmd.Parameters.Add(New SqlParameter("@Amount", sAmount))

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
		Me.txtAmount.Enabled = True
		Me.txtSIMCardId.Enabled = True
		Me.txtAmount.Text = ""
		Me.txtSIMCardId.Text = ""
	End Sub

	Protected Sub btnAddTelco_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddTelco.Click
		If Me.txtSIMMSISDN.Text = "" Or Me.txtSIMMSISDN.Text.Length <> 8 Or Not IsNumeric(Me.txtSIMMSISDN.Text) Then
			Me.lblErrorSIM.Text = "Invalid SIM MSISDN!"
		Else
			If CheckMSISDN(txtSIMMSISDN.Text) Then
				Me.lblErrorSIM.Text = "SIM MSISDN already exits!"
			Else
				If AddSIMMSISDN(txtSIMMSISDN.Text, Me.DDLTelco.SelectedValue) Then
					Me.lblErrorSIM.Text = "Added Successfully!"
				Else
					Me.lblErrorSIM.Text = "Fail to add!"
				End If
			End If
			Me.GridView1.DataBind()

		End If
	End Sub


	Private Function AddSIMMSISDN(ByVal sSIMMSISDN As String, ByVal sTelco As String) As Boolean

		Dim oConn As New SqlConnection
		Dim oCmd As New SqlCommand
		'Dim oDR As SqlDataReader
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""

		AddSIMMSISDN = False

		Try
			sSQL = "INSERT INTO SIMCard (SimCardID,Telco,Balance,Status) VALUES (@SimCardID,@Telco,'0','ACTIVE')"

			oConn = New SqlConnection()
			oConn.ConnectionString =
						ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

			oCmd = New SqlCommand
			oCmd.CommandText = sSQL
			oCmd.Connection = oConn
			oCmd.Connection.Open()

			oCmd.Parameters.Clear()
			oCmd.Parameters.Add(New SqlParameter("@SimCardID", sSIMMSISDN))
			oCmd.Parameters.Add(New SqlParameter("@Telco", sTelco))

			oCmd.ExecuteNonQuery()
			AddSIMMSISDN = True


		Catch ex As Exception
			AddSIMMSISDN = False
			lblErrorSIM.Text = "Error Occurred. Please contact administrator." & ex.Message
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

	Private Function CheckMSISDN(ByVal sSIMCardID As String) As Boolean

		Dim oConn As New SqlConnection
		Dim oCmd As New SqlCommand
		Dim oDR As SqlDataReader
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""
		CheckMSISDN = False

		Try
			sSQL = "SELECT SIMCardID FROM SIMCard " &
									 "WHERE SIMCardID=@sSIMCardID"

			oConn = New SqlConnection()
			oConn.ConnectionString =
						ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

			oCmd = New SqlCommand
			oCmd.CommandText = sSQL
			oCmd.Connection = oConn
			oCmd.Connection.Open()

			oCmd.Parameters.Clear()
			oCmd.Parameters.Add(New SqlParameter("@sSIMCardID", sSIMCardID))
			oDR = oCmd.ExecuteReader
			If (oDR.Read) Then
				CheckMSISDN = True
			End If

			oDR.Close()

		Catch ex As Exception
			CheckMSISDN = False
			lblErrorSIM.Text = "Error Occurred. Please contact administrator." & ex.Message
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

End Class
