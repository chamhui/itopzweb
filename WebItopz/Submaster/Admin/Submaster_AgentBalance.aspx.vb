
Partial Class Submaster_Admin_AgentBalance
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Session("AGENT_ID") = "" Then
			Response.Redirect("~/submaster/submaster_login.aspx")
		End If

		Dim sSQL As String

		lblErrorMSISDN.Text = ""

		'sSQL = "SELECT b.AgentID, i.Name, i.HPNo, b.MaxisBalance, b.CelcomBalance, b.DiGiBalance FROM AgentBalance b, AgentInfo i WHERE i.agentid=b.agentid "
		sSQL = "SELECT b.AgentID, i.Name, i.HPNo, b.Balance, b.M5, b.M18, b.M28 FROM AgentBalance b, AgentInfo i WHERE i.agentid=b.agentid "

		If Me.txtMSISDN.Text <> "" Then
			sSQL = sSQL & " and i.HPNo= '65" & Right(txtMSISDN.Text.Trim, 8) & "'"
		Else
			lblErrorMSISDN.Text = "*"
		End If

		sSQL = sSQL & " and i.Agentlvl like '" & Session("AGENT_AGENTLVL") & Session("AGENT_ID") & "|' "

		sSQL = sSQL & " ORDER BY CONVERT(INT,b.AgentID)"

		'Response.Write(sSQL)
		Me.SqlDataSource1.SelectCommand = sSQL


		Me.SqlDataSource2.SelectCommand = "SELECT SUM(Balance) AS TotalBalance,SUM(M5) AS M5,SUM(M18) AS M18, SUM(M28) AS M28  FROM AgentBalance WHERE (AgentID IN (SELECT AgentID FROM AgentInfo AS AgentInfo_1 WHERE (Agentlvl like '" & Session("AGENT_AGENTLVL") & Session("AGENT_ID") & "|%')))"
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
	End Sub
End Class
