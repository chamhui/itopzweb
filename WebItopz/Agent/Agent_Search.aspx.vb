Imports System.Data.SqlClient
Imports System.IO

Public Class Agent_Search1
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


		If Session("AGENT_ID") = "" Then
			Response.Redirect("~/Agent/Agent_Login.aspx")
		End If
		If (Not IsPostBack) Then
			txtDate.Text = DateTime.Now.ToString("yyyyMMdd")
		End If
		Dim sSQL As String

		'Me.lblErrorMsg.Text = ""
		'Me.lblErrorReloadMSISDN.Text = ""
		'Me.lblErrorAgentMSISDN.Text = ""
		'Me.lblErrorDate.Text = ""

		sSQL = "SELECT [LocalMOID], [MSISDN], [AgentID], [MessageIn], [Status], [ReloadTelco], [ReloadAmount], [ReloadMSISDN], [MessageTS], [ErrorCode], [CreatedTS], [LastUpdatedTS], [DNReceivedId] FROM [TxIn] WHERE "

		If Me.txtReloadMSISDN.Text <> "" And (Me.txtReloadMSISDN.Text.Length = 8) Then
			sSQL = sSQL & " ReloadMSISDN= '" & Right(txtReloadMSISDN.Text.Trim, 8) & "' AND "
		Else
			'lblErrorReloadMSISDN.Text = "*"
		End If
		If Me.txtAgentMSISDN.Text <> "" And (Me.txtAgentMSISDN.Text.Length = 8) Then
			sSQL = sSQL & " MSISDN= '65" & Right(txtAgentMSISDN.Text, 8) & "' AND "
		Else
			'Me.lblErrorAgentMSISDN.Text = "*"
		End If

		sSQL = sSQL & " AgentID  ='" & Session("AGENT_ID") & "'  AND "

		If Me.txtDate.Text <> "" And Me.txtDate.Text.Length = 8 Then
			sSQL = sSQL & " left(MessageTS,8) = '" & txtDate.Text & "'"
		Else
			'Me.lblErrorDate.Text = "*"
		End If

		If Right(sSQL.Trim, 3).ToUpper = "AND" Then
			sSQL = Mid(sSQL, 1, sSQL.Length - 4)
		End If

		sSQL = sSQL & " order by messageTS desc"
		'Response.Write(sSQL)
		Me.SqlDataSource1.SelectCommand = sSQL


	End Sub

	Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
		'Me.txtDate.Text = Format(Now(), "yyyyMMdd")

		'Page.Header.InnerHtml = "<META HTTP-EQUIV=REFRESH CONTENT=60>"
		'Page.Title = "Search"
	End Sub

	Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
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

	Protected Sub btnRefreshDN_Click(sender As Object, e As EventArgs) Handles btnRefreshDN.Click
		Dim oConn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString)
		Dim oCmd As SqlCommand = New SqlCommand
		Dim bIsValid As Boolean = True
		Dim sSQL As String = ""
		Dim dtbl As DataTable = New DataTable
		Dim dtProc As DataTable = New DataTable
		Dim sqlDa As SqlDataAdapter = New SqlDataAdapter
		'oConn.ConnectionString = ConfigurationManager.ConnectionStrings["RichTechConnectionString"].ConnectionString;
		sSQL = "SELECT Id, ReloadMSISDN, ReloadAmount FROM DNReceived where DNStatus='' and cast(CreatedTS as date) =" &
		" cast(getdate() as date)"
		'sSQL = "SELECT  MessageIn,ReloadAmount, robin, ReloadTelco FROM TxIn WHERE CreatedTS > DATEADD(dd, -250, GETDATE()) and CreatedTS<DATEADD(dd, -230, GETDATE()) and status = 'SUCCESS' order by robin";
		oCmd.CommandText = sSQL
		oCmd.Connection = oConn
		oCmd.Connection.Open()
		sqlDa = New SqlDataAdapter(sSQL, oConn)
		sqlDa.Fill(dtbl)
		oCmd.Connection.Close()

		For Each row As DataRow In dtbl.Rows
			Dim TempMsg As String = ""
			Dim temp As DataTable = New DataTable
			Dim sqlTemp As SqlDataAdapter = New SqlDataAdapter
			sSQL = ("SELECT top 1  MOMsg,Id FROM DNMsgs where MOMsg like '%" _
									+ (row("ReloadMSISDN").ToString + "%' and cast(CreatedTS as date) = cast(getdate() as date) and is_checked is null"))
			oCmd.CommandText = sSQL
			oCmd.Connection = oConn
			oCmd.Connection.Open()
			sqlTemp = New SqlDataAdapter(sSQL, oConn)
			sqlTemp.Fill(temp)
			Dim TempID As String = ""
			For Each row2 As DataRow In temp.Rows
				TempMsg = row2("MOMsg").ToString
				TempMsg = ("Singtel TxID:" + After(TempMsg, "TransID:"))
				TempID = row2("Id").ToString
			Next
			oCmd.Connection.Close()
			sSQL = ("Update DNReceived SET DNStatus='" _
									+ (TempMsg + ("' where Id = '" _
									+ (row("Id").ToString + "' "))))
			oCmd.CommandText = sSQL
			oCmd.Connection = oConn
			oCmd.Connection.Open()
			oCmd.ExecuteNonQuery()
			oCmd.Connection.Close()
			sSQL = ("Update DNMsgs SET is_checked='yes' where Id = '" _
									+ (TempID.ToString + "' "))
			oCmd.CommandText = sSQL
			oCmd.Connection = oConn
			oCmd.Connection.Open()
			oCmd.ExecuteNonQuery()
			oCmd.Connection.Close()
		Next
	End Sub

	Private Function After(ByVal value1 As String, ByVal a As String) As String
		Dim posA As Integer = value1.LastIndexOf(a)
		If (posA = -1) Then

			Return ""
		End If

		Dim adjustedPosA As Integer = posA + a.Length
		If (adjustedPosA >= value1.Length) Then


			Return ""
		End If

		Return value1.Substring(adjustedPosA)
	End Function
	Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click

		GridView1.AllowPaging = False
		GridView1.DataBind()

		ExportExcel("Report", GridView1)


		GridView1.AllowPaging = True
		GridView1.DataBind()

	End Sub
	Public Sub ExportExcel(ByVal filename As String, ByVal gv As GridView)
		Response.ClearContent()
		Response.AddHeader("content-disposition", "attachment; filename=" & filename & ".xls")
		Response.ContentType = "application/vnd.ms-excel"
		Dim sw As New StringWriter()
		Dim htw As New HtmlTextWriter(sw)
		gv.RenderControl(htw)
		Response.Write(sw.ToString())
		Response.[End]()
	End Sub

	Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
	End Sub
End Class
