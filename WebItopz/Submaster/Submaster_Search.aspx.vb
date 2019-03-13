
Partial Class Submaster_Search
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Session("AGENT_ID") = "" Then
			Response.Redirect("~/Submaster/Submaster_Login.aspx")
		End If

		'Me.lblErrorMsg.Text = ""
		Dim sSQL As String

		'Me.lblErrorMsg.Text = ""
		'Me.lblErrorReloadMSISDN.Text = ""
		'Me.lblErrorAgentMSISDN.Text = ""
		'Me.lblErrorDate.Text = ""
		'Me.lblErrorReloadTelco.Text = ""
		'Me.lblErrorAgentID.Text = ""

		sSQL = "SELECT T.DNReceivedID, T.LocalMOID, T.MSISDN, T.AgentID, (convert(varchar(10),T.AgentID)+': '+ convert(varchar(20),T.MSISDN)) as Agent, T.ReloadType, T.MessageIn, T.Robin, T.Status, T.ReloadTelco, T.ReloadAmount, T.ReloadMSISDN, T.MessageTS, T.ErrorCode, T.CreatedTS, T.LastUpdatedTS, I.ParentAgentID as PID FROM TxIn AS T INNER JOIN AgentInfo AS I ON T.AgentID = I.AgentID WHERE "

		sSQL = sSQL & "Agentlvl ='" & Session("AGENT_AGENTLVL") & "' AND "

		If Me.txtReloadMSISDN.Text <> "" And (Me.txtReloadMSISDN.Text.Length = 8) Or (Me.txtReloadMSISDN.Text.Length = 11) Then
			sSQL = sSQL & " ReloadMSISDN= '" & (txtReloadMSISDN.Text) & "' AND "
		Else
			'lblErrorReloadMSISDN.Text = "*"
		End If
		If Me.txtAgentMSISDN.Text <> "" And (Me.txtAgentMSISDN.Text.Length = 8) Then
			sSQL = sSQL & " MSISDN= '65" & Right(txtAgentMSISDN.Text, 8) & "' AND "
		Else
			'Me.lblErrorAgentMSISDN.Text = "*"
		End If
		If Me.txtAgentID.Text <> "" Then
			sSQL = sSQL & " T.AgentID= '" & (txtAgentID.Text) & "' AND "
		Else
			'Me.lblErrorAgentID.Text = "*"
		End If
		If Me.txtReloadTelco.Text <> "" Then
			sSQL = sSQL & " ReloadTelco= '" & (txtReloadTelco.Text) & "' AND "
		Else
			'Me.lblErrorReloadTelco.Text = "*"
		End If
		If Me.DDLReloadType.SelectedValue <> "" Then
			sSQL = sSQL & " ReloadType= '" & (Me.DDLReloadType.SelectedValue) & "' AND "
		Else
			'Me.lblErrorReloadType.Text = "*"
		End If
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
		Me.txtDate.Text = Format(Today(), "yyyyMMdd")

		'Page.Header.InnerHtml = "CC"
		Page.Title = "Search"
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

	Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
		Me.GridView1.DataBind()
		'GridView1.HeaderRow.TableSection = New TableRowSection.TableHeader
	End Sub

	Protected Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
		Dim grid As GridView
		grid = DirectCast(sender, GridView)

		'If (e.Row.RowIndex = 0) Then
		'e.Row.RowType = DataControlRowType.Header
		'End If

		If (e.Row.RowIndex = grid.Rows.Count - 1) Then
		End If
	End Sub
End Class
