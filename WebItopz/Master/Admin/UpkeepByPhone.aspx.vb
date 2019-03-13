Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports System.Data
Imports System.Data.OleDb
Imports System
Public Class UpkeepByPhone
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'btnUpdate.Enabled = False
        'If Session("AGENT_ID") = "" Then
        '    Response.Redirect("~/Master/Login.aspx")
        'End If

        FillGridViewSingtel()
          FillGridViewM1()
          FillGridViewStarhub()

    End Sub

    'Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
    '    txtTS.Text = String.Empty
    '    txtTM1.Text = String.Empty
    '    txtTM5.Text = String.Empty
    '    txtTM18.Text = String.Empty
    '    txtTM28.Text = String.Empty
    '    txtTSing.Text = String.Empty
    '    txtTd.Text = String.Empty
    'End Sub

    'Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
    '    If InsertNewTxUpkeep(Me.txtTS.Text, Me.txtTM1.Text, Me.txtTM5.Text, Me.txtTM18.Text, Me.txtTM28.Text, Me.txtTSing.Text, Me.txtTd.Text) Then
    '        Me.lblErrorMsg.Text = "Added Successfully! "
    '        gvUpkeep.DataBind()
    '        Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)

    '    End If

    'End Sub
    'Public Function InsertNewTxUpkeep(ByVal sTStarhub As String, ByVal sTM1 As String, ByVal sTM5 As String, ByVal sTM18 As String, ByVal sTM28 As String, ByVal sTSingtel As String, ByVal sTTxDate As String) As Boolean
    '    Dim oConn As New SqlConnection
    '    Dim oCmd As New SqlCommand
    '    Dim bIsValid As Boolean = True
    '    Dim sSQL As String = ""

    '    InsertNewTxUpkeep = False

    '    Dim total As Integer

    '    Dim a As Integer = Convert.ToInt32(txtTS.Text)
    '    Dim b As Integer = Convert.ToInt32(txtTM1.Text)
    '    Dim c As Integer = Convert.ToInt32(txtTM5.Text)
    '    Dim d As Integer = Convert.ToInt32(txtTM18.Text)
    '    Dim g As Integer = Convert.ToInt32(txtTM28.Text)
    '    Dim f As Integer = Convert.ToInt32(txtTSing.Text)
    '    total = a + b + c + d + g + f


    '    Try
    '        sSQL = "INSERT INTO UpkeepTx(Starhub,M1,M5,M18,M28,Singtel,TotalAmount,UpkeepTX_Date) VALUES(@Starhub,@M1,@M5,@M18,@M28,@Singtel,@TotalAmount,@UpkeepTX_Date)"

    '        oConn = New SqlConnection()
    '        oConn.ConnectionString =
    '        ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

    '        oCmd = New SqlCommand
    '        oCmd.CommandText = sSQL
    '        oCmd.Connection = oConn
    '        oCmd.Connection.Open()

    '        oCmd.Parameters.Clear()
    '        oCmd.Parameters.Add(New SqlParameter("@Starhub", sTStarhub))
    '        oCmd.Parameters.Add(New SqlParameter("@M1", sTM1))
    '        oCmd.Parameters.Add(New SqlParameter("@M5", sTM5))
    '        oCmd.Parameters.Add(New SqlParameter("@M18", sTM18))
    '        oCmd.Parameters.Add(New SqlParameter("@M28", sTM28))
    '        oCmd.Parameters.Add(New SqlParameter("@Singtel", sTSingtel))
    '        oCmd.Parameters.Add(New SqlParameter("@TotalAmount", total))
    '        oCmd.Parameters.Add(New SqlParameter("@UpkeepTX_Date", sTTxDate))


    '        oCmd.ExecuteNonQuery()
    '        InsertNewTxUpkeep = True
    '        Dim upid As String = hfUpkeeptxID.Value

    '        If (upid = "") Then
    '            lblErrorMsg.Text = "Saved Successfully"

    '        End If


    '    Catch ex As Exception
    '        InsertNewTxUpkeep = False
    '        lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message & ex.StackTrace
    '    Finally
    '        If (Not oCmd Is Nothing) Then
    '            oCmd.Dispose()
    '            oCmd = Nothing
    '        End If
    '        If Not oConn Is Nothing Then
    '            If oConn.State = Data.ConnectionState.Open Then
    '                oConn.Close()
    '            End If
    '            oConn.Dispose()
    '            oConn = Nothing
    '        End If
    '    End Try

    'End Function

    Public Function FillGridViewSingtel()
        Dim oConn As New SqlConnection
        Dim oCmd As New SqlCommand
        Dim bIsValid As Boolean = True
        Dim sSQL As String = ""
        Dim dtbl As DataTable
        Dim sqlDa As SqlDataAdapter

        FillGridViewSingtel = False

        Try
            sSQL = "SELECT * FROM UpkeepPhone where Carrier='Singtel'"

            oConn = New SqlConnection()
            oConn.ConnectionString =
            ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

            oCmd = New SqlCommand
            oCmd.CommandText = sSQL
            oCmd.Connection = oConn
            oCmd.Connection.Open()

            'oCmd.Parameters.Clear()
            'dtbl = New DataTable
            'gvUpkeep.DataSource = dtbl
            'gvUpkeep.DataBind()

            sqlDa = New SqlDataAdapter(sSQL, oConn)
            dtbl = New DataTable
            sqlDa.Fill(dtbl)
            dtbl.Columns.Add("SingtelTotal",GetType(double))
            For Each row As  DataRow In dtbl.Rows
                row("SingtelTotal") = (row("Singtel5")*5)+(row("Singtel10")*10)+(row("Singtel20")*20)+(row("Singtel50")*50)+(row("Singtel16")*15)+(row("Singtel15")*15)+(row("Singtel28")*28)+(row("Singtel300")*30)+(row("Singtel180")*18)+(row("Singtel888")*8)+(row("Singtel102")*7)+(row("Singtel1015")*10)+(row("Singtel118")*10)+(row("Singtel1315")*13)+(row("Singtel119")*20)+(row("Singtel2504")*25)+(row("Singtel120")*30)
            Next
            rptrUpkeepSingtel.DataSource = dtbl
            rptrUpkeepSingtel.DataBind()







            oCmd.ExecuteNonQuery()
            FillGridViewSingtel = True


        Catch ex As Exception
            FillGridViewSingtel = False
            lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message & ex.StackTrace
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

      Public Function FillGridViewStarhub()
        Dim oConn As New SqlConnection
        Dim oCmd As New SqlCommand
        Dim bIsValid As Boolean = True
        Dim sSQL As String = ""
        Dim dtbl As DataTable
        Dim sqlDa As SqlDataAdapter

        FillGridViewStarhub = False

        Try
            sSQL = "SELECT * FROM UpkeepPhone where Carrier='Starhub'"

            oConn = New SqlConnection()
            oConn.ConnectionString =
            ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

            oCmd = New SqlCommand
            oCmd.CommandText = sSQL
            oCmd.Connection = oConn
            oCmd.Connection.Open()

            'oCmd.Parameters.Clear()
            'dtbl = New DataTable
            'gvUpkeep.DataSource = dtbl
            'gvUpkeep.DataBind()

            sqlDa = New SqlDataAdapter(sSQL, oConn)
            dtbl = New DataTable
            sqlDa.Fill(dtbl)
            rptrUpkeepstarhub.DataSource = dtbl
            rptrUpkeepstarhub.DataBind()







            oCmd.ExecuteNonQuery()
            FillGridViewStarhub = True


        Catch ex As Exception
            FillGridViewStarhub = False
            lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message & ex.StackTrace
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

   Public Function FillGridViewM1()
        Dim oConn As New SqlConnection
        Dim oCmd As New SqlCommand
        Dim bIsValid As Boolean = True
        Dim sSQL As String = ""
        Dim dtbl As DataTable
        Dim sqlDa As SqlDataAdapter

        FillGridViewM1 = False

        Try
            sSQL = "SELECT * FROM UpkeepPhone where Carrier='M1'"

            oConn = New SqlConnection()
            oConn.ConnectionString =
            ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

            oCmd = New SqlCommand
            oCmd.CommandText = sSQL
            oCmd.Connection = oConn
            oCmd.Connection.Open()

            'oCmd.Parameters.Clear()
            'dtbl = New DataTable
            'gvUpkeep.DataSource = dtbl
            'gvUpkeep.DataBind()

            sqlDa = New SqlDataAdapter(sSQL, oConn)
            dtbl = New DataTable
            sqlDa.Fill(dtbl)
            dtbl.Columns.Add("M1Total",GetType(double))
            For Each row As  DataRow In dtbl.Rows
                row("M1Total") = row("M1")+(row("M5")*5)+(row("M18")*18)+(row("M28")*28)
            Next
            rptrUpkeepm1.DataSource = dtbl
            rptrUpkeepm1.DataBind()







            oCmd.ExecuteNonQuery()
            FillGridViewM1 = True


        Catch ex As Exception
            FillGridViewM1 = False
            lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message & ex.StackTrace
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