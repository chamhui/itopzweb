Imports System.Data.SqlClient
Imports WebItopz.CommonItop
Public Class Admin_UpkeepTx
    Inherits System.Web.UI.Page
    Private Const STATUS_SUCCESS = "SUCCESS"
    Private Const STATUS_REFUNDED = "REFUNDED"
    Private Const MT_MSG = "Your account been credited: [<Amount>]. Remarks: <Remarks>. DateTime:<DateTime>."

    Private Const STATUS_ACTIVE = "ACTIVE"
    Dim Conn As New SqlConnection("Initial Catalog=SMSReloadSG;Data Source=WIN8;Integrated Security=SSPI;Connection Timeout=60")
    Dim cmd As New SqlCommand
    'Dim dr As New SqlDataReader


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim bWorking As Boolean = False
        Dim oCommon As New Common



        'If Session("AGENT_ID") = "" Then
        '    Response.Redirect("~/Master/Login.aspx")
        'End If

        Me.lblErrorMsg.Text = ""


        cmd.Connection = Conn

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

        GridView1.DataBind()


    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        Dim total As Integer

        Dim a As Integer = Convert.ToInt32(Starhub.Text)
        Dim b As Integer = Convert.ToInt32(M1.Text)
        Dim c As Integer = Convert.ToInt32(M5.Text)
        Dim d As Integer = Convert.ToInt32(M18.Text)
        Dim g As Integer = Convert.ToInt32(M28.Text)
        Dim f As Integer = Convert.ToInt32(Singtel.Text)


        total = a + b + c + d + g + f
        Conn.Open()
        cmd.CommandText = "insert into UpkeepTx (Starhub,M1,M5,M18,M28,Singtel,TotalAmount,UpkeepTX_Date) values ('" & Starhub.Text & "', '" & M1.Text & "', '" & M5.Text & "', '" & M18.Text & "', '" & M28.Text & "', '" & Singtel.Text & "', '" & total & "', '" & txtpu.Text & "')"
        cmd.ExecuteNonQuery()
        Conn.Close()
        Starhub.Text = ""
        M1.Text = ""
        M5.Text = ""
        M18.Text = ""
        M28.Text = ""
        Singtel.Text = ""

        'TotalAmount(Me.Starhub.Text, Me.M1.Text, Me.M5.Text, Me.M18.Text, Me.M24.Text, Me.Singtel.Text)


    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    'Private Function TotalAmount(ByRef sStarhub As String, ByRef sM1 As String, ByRef sM5 As String, ByRef sM18 As String, ByRef sM28 As String, ByRef sSingtel As String) As Boolean
    '    Conn.Open()

    '    Dim Total As Integer
    '    Dim sSQL As String

    '    Total = sStarhub + sM1 + sM5 + sM18 + sM28 + sSingtel

    '    sSQL = "insert into UpkeepTx (TotalAmount) values (Total)"

    '    cmd.Parameters.Add(New SqlParameter("@totalamount", Total))
    '    cmd.CommandText = sSQL
    '    cmd.ExecuteNonQuery()
    '    Conn.Close()

    '    TotalAmount = True

    'End Function



End Class