Imports System.Data.SqlClient
Imports System.Data

Partial Class Dealer_ReportCommission
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("DEALER_ID") = "" Then
            Server.Transfer("~/Dealer/login.aspx")
        End If

        If Not Me.IsPostBack Then
            ' Preloading 
            Me.DDLMonth.SelectedValue = Format(Now(), "MM")
            For i As Integer = -3 To 10
                Me.DDLYear.Items.Add(Format(Now(), "yyyy") + i)
            Next i
            Me.DDLYear.SelectedValue = Format(Now(), "yyyy")

            ' Binding Data
            Me.lblTotal.Text = Me.BindGrid(0)
            Me.lblWeek1.Text = Me.BindGrid(1)
            Me.lblWeek2.Text = Me.BindGrid(2)
            Me.lblWeek3.Text = Me.BindGrid(3)
            Me.lblWeek4.Text = Me.BindGrid(4)
            Me.lblWeek5.Text = Me.BindGrid(5)

        End If
    End Sub



    Private Function BindGrid(ByVal week As Integer) As String

        Dim sSQL As String = ""
        Dim oConn As New SqlConnection(ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString)
        Dim oCmd As New SqlCommand
        Dim oDR As SqlDataReader = Nothing
        Dim dayFrom As Integer = 1
        Dim dayTo As Integer = 7

        If week.Equals(2) Then
            dayFrom = 8
            dayTo = 14
        ElseIf week.Equals(3) Then
            dayFrom = 15
            dayTo = 21
        ElseIf week.Equals(4) Then
            dayFrom = 22
            dayTo = 28
        ElseIf week.Equals(5) Then
            dayFrom = 29
            dayTo = 31
        End If


        Dim Amount As String = "0"

        Try
            oConn.Open()
            oCmd = oConn.CreateCommand
            oCmd.Connection = oConn

            If week.Equals(0) Then

                sSQL = "SELECT SUM(a.Commission) AS Amount FROM [TxIn] AS a INNER JOIN [AgentInfo] AS b ON a.AgentID = b.AgentID WHERE b.ParentAgentID = @PARENTAGENTID AND a.status = 'SUCCESS' AND (MONTH(CreatedTS) = @MONTH) AND (YEAR(CreatedTS) = @YEAR) GROUP BY b.ParentAgentID "

                oCmd.CommandText = sSQL

                With oCmd.Parameters
                    .Clear()
                    .AddWithValue("@PARENTAGENTID", Session("DEALER_ID"))
                    .AddWithValue("@MONTH", Me.DDLMonth.SelectedValue)
                    .AddWithValue("@YEAR", Me.DDLYear.SelectedValue)
                End With

            Else

                sSQL = "SELECT SUM(a.Commission) AS Amount  FROM [TxIn] AS a INNER JOIN [AgentInfo] AS b   ON a.AgentID = b.AgentID   WHERE b.ParentAgentID = @PARENTAGENTID AND a.status = 'SUCCESS' AND (MONTH(CreatedTS) = @MONTH) AND (YEAR(CreatedTS) = @YEAR) AND (DAY(CreatedTS) Between '" & dayFrom & "' and '" & dayTo & "')  GROUP BY b.ParentAgentID "

                oCmd.CommandText = sSQL

                With oCmd.Parameters
                    .Clear()
                    .AddWithValue("@PARENTAGENTID", Session("DEALER_ID"))
                    .AddWithValue("@MONTH", Me.DDLMonth.SelectedValue)
                    .AddWithValue("@YEAR", Me.DDLYear.SelectedValue)
                End With

            End If

            oDR = oCmd.ExecuteReader
            If oDR.Read Then
                Amount = oDR.Item("Amount")
            End If


            oConn.Close()

        Catch ex As Exception
            lblError.Text = "ERROR: " & ex.Message
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

        Return Amount
    End Function

	Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
		Me.lblTotal.Text = Me.BindGrid(0)
		Me.lblWeek1.Text = Me.BindGrid(1)
		Me.lblWeek2.Text = Me.BindGrid(2)
		Me.lblWeek3.Text = Me.BindGrid(3)
		Me.lblWeek4.Text = Me.BindGrid(4)
		Me.lblWeek5.Text = Me.BindGrid(5)
	End Sub


End Class
