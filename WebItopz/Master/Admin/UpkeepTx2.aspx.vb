Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports System.Data
Imports System.Data.OleDb
Imports System
Public Class UpkeepTx2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'btnUpdate.Enabled = False
        'If Session("AGENT_ID") = "" Then
        '    Response.Redirect("~/Master/Login.aspx")
        'End If

        FillGridView()

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

    Public Function FillGridView()
        Dim oConn As New SqlConnection
        Dim oCmd As New SqlCommand
        Dim bIsValid As Boolean = True
        Dim sSQL As String = ""
        Dim dtbl As DataTable
        Dim sqlDa As SqlDataAdapter

        FillGridView = False

        Try
            sSQL = "SELECT * FROM UpkeepTx"

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
            rptrUpkeepTx.DataSource = dtbl
            rptrUpkeepTx.DataBind()







            oCmd.ExecuteNonQuery()
            FillGridView = True


        Catch ex As Exception
            FillGridView = False
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

    'Protected Sub lnk_onClick(sender As Object, e As EventArgs)

    '    btnSave.Enabled = False
    '    Dim UpkeepTxID As Integer = Convert.ToInt32(CType(sender, LinkButton).CommandArgument)
    '    Dim oConn As New SqlConnection
    '    Dim oCmd As New SqlCommand
    '    Dim bIsValid As Boolean = True
    '    Dim sSQL As String = ""
    '    Dim dtbl As DataTable
    '    Dim sqlDa As SqlDataAdapter


    '    Try
    '        sSQL = "SELECT * FROM UpkeepTx WHERE (UpkeepTx_ID = @UpkeepTx_ID)"

    '        oConn = New SqlConnection()
    '        oConn.ConnectionString = ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

    '        oCmd = New SqlCommand
    '        oCmd.CommandText = sSQL
    '        oCmd.Connection = oConn
    '        oCmd.Connection.Open()

    '        'oCmd.Parameters.Clear()
    '        'dtbl = New DataTable
    '        'gvUpkeep.DataSource = dtbl
    '        'gvUpkeep.DataBind()

    '        sqlDa = New SqlDataAdapter(sSQL, oConn)
    '        sqlDa.SelectCommand.Parameters.Add(New SqlParameter("@UpkeepTx_ID", UpkeepTxID))
    '        'oCmd.Parameters.Add(New SqlParameter("@UpkeepID", UpkeepID))
    '        'oCmd.ExecuteNonQuery()
    '        dtbl = New DataTable
    '        sqlDa.Fill(dtbl)
    '        gvUpkeep.DataSource = dtbl
    '        gvUpkeep.DataBind()
    '        hfUpkeeptxID.Value = UpkeepTxID.ToString()


    '        txtTID.Text = dtbl.Rows(0)("UpkeepTx_ID").ToString
    '        txtTS.Text = dtbl.Rows(0)("Starhub").ToString
    '        txtTM1.Text = dtbl.Rows(0)("M1").ToString
    '        txtTM5.Text = dtbl.Rows(0)("M5").ToString
    '        txtTM18.Text = dtbl.Rows(0)("M18").ToString
    '        txtTM28.Text = dtbl.Rows(0)("M28").ToString
    '        txtTSing.Text = dtbl.Rows(0)("Singtel").ToString
    '        txtTd.Text = dtbl.Rows(0)("UpkeepTX_Date").ToString


    '        btnUpdate.Enabled = True




    '    Catch ex As Exception
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

    'End Sub

    'Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

    '    'If UpdateUpkeepTx(txtTID.Text, txtTS.Text, Me.txtTM1.Text, Me.txtTM5.Text, Me.txtTM18.Text, Me.txtTM28.Text, Me.txtTSing.Text, Me.txtTd.Text) Then

    '    'If UpdateTx(txtTID.Text, txtTS.Text, Me.txtTM1.Text, Me.txtTM5.Text, Me.txtTM18.Text, Me.txtTM28.Text, Me.txtTSing.Text, Me.txtTd.Text) Then
    '    '    If UpdateTxUAdd(txtTd.Text) Then
    '    If UpdateTxUSub(txtTID.Text) Then
    '        Me.lblErrorMsg.Text = "Updated Successfully! "
    '        gvUpkeep.DataBind()
    '        Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)
    '    End If
    '    '    End If
    '    'End If
    'End Sub
    'Public Function UpdateUpkeepTx(ByRef sUpkeeptxID As String, ByRef sTStarhub As String, ByRef sTM1 As String, ByRef sTM5 As String, ByRef sTM18 As String, ByRef sTM28 As String, ByRef sTSingtel As String, ByRef sTTxDate As String) As Boolean


    '    Dim oConn As New SqlConnection
    '    Dim oCmd As New SqlCommand
    '    'Dim oDR As SqlDataReader
    '    Dim bIsValid As Boolean = True
    '    Dim sSQL As String = ""
    '    Dim sSQL2 As String = ""
    '    Dim sSQL3 As String = ""


    '    Dim total As Integer
    '    Dim a As Integer = Convert.ToInt32(txtTS.Text)
    '    Dim b As Integer = Convert.ToInt32(txtTM1.Text)
    '    Dim c As Integer = Convert.ToInt32(txtTM5.Text)
    '    Dim d As Integer = Convert.ToInt32(txtTM18.Text)
    '    Dim g As Integer = Convert.ToInt32(txtTM28.Text)
    '    Dim f As Integer = Convert.ToInt32(txtTSing.Text)
    '    total = a + b + c + d + g + f

    '    UpdateUpkeepTx = False
    '    Try
    '        'sSQL2 = "UPDATE Upkeep SET StarhubCurrent  = StarhubCurrent - @Starhub1 ,M1Current = M1Current - @M11,M5Current = M1Current - @M51 ,M18Current = M18Current - @M181 ,M28Current = M28Current - @M281 ,SingtelCurrent = SingtelCurrent - @Singtel1 WHERE(@UpkeepTxDate > OpeningDate AND YEAR(ClosingDate)=1900) OR (@UpkeepTxDate BETWEEN OpeningDate AND ClosingDate); UPDATE Upkeep SET StarhubCurrent  = StarhubCurrent + @Starhub1 ,M1Current = M1Current + @M11,M5Current = M1Current + @M51 ,M18Current = M18Current + @M181 ,M28Current = M28Current + @M281 ,SingtelCurrent = SingtelCurrent + @Singtel1 WHERE(@UpkeepTxDate > OpeningDate AND YEAR(ClosingDate)=1900) OR (@UpkeepTxDate BETWEEN OpeningDate AND ClosingDate);"
    '        sSQL3 = "UPDATE Upkeep SET StarhubCurrent  = StarhubCurrent + @Starhub2 ,M1Current = M1Current + @M12,M5Current = M1Current + @M52 ,M18Current = M18Current + @M182 ,M28Current = M28Current + @M282 ,SingtelCurrent = SingtelCurrent + @Singtel2 WHERE(@UpkeepTxDate > OpeningDate AND YEAR(ClosingDate)=1900) OR (@UpkeepTxDate BETWEEN OpeningDate AND ClosingDate)"
    '        sSQL = "UPDATE UpkeepTx SET Starhub = @Starhub,M1 = @M1, M5 = @M5, M18 = @M18, M28 = @M28 ,Singtel= @Singtel,TotalAmount = @TotalAmount, UpkeepTX_Date = @UpkeepTxDate, UpkeepTX_Update = @UpkeepTxUpdate WHERE (UpkeepTx_ID = @UpkeepTx_ID)"
    '        oConn = New SqlConnection()
    '        oConn.ConnectionString =
    '        ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

    '        oCmd = New SqlCommand
    '        oCmd.CommandText = sSQL3
    '        'oCmd.CommandText = sSQL3
    '        'oCmd.CommandText = sSQL
    '        oCmd.Connection = oConn
    '        oCmd.Connection.Open()

    '        oCmd.Parameters.Clear()


    '        'oCmd.Parameters.Add(New SqlParameter("@Starhub1", a))
    '        'oCmd.Parameters.Add(New SqlParameter("@M11", b))
    '        'oCmd.Parameters.Add(New SqlParameter("@M51", c))
    '        'oCmd.Parameters.Add(New SqlParameter("@M181", d))
    '        'oCmd.Parameters.Add(New SqlParameter("@M281", g))
    '        'oCmd.Parameters.Add(New SqlParameter("@Singtel1", f))

    '        oCmd.Parameters.Add(New SqlParameter("@Starhub2", a))
    '        oCmd.Parameters.Add(New SqlParameter("@M12", b))
    '        oCmd.Parameters.Add(New SqlParameter("@M52", c))
    '        oCmd.Parameters.Add(New SqlParameter("@M182", d))
    '        oCmd.Parameters.Add(New SqlParameter("@M282", g))
    '        oCmd.Parameters.Add(New SqlParameter("@Singtel2", f))


    '        oCmd.Parameters.Add(New SqlParameter("@UpkeepTx_ID", sUpkeeptxID))

    '        oCmd.Parameters.Add(New SqlParameter("@Starhub", sTStarhub))
    '        oCmd.Parameters.Add(New SqlParameter("@M1", sTM1))
    '        oCmd.Parameters.Add(New SqlParameter("@M5", sTM5))
    '        oCmd.Parameters.Add(New SqlParameter("@M18", sTM18))
    '        oCmd.Parameters.Add(New SqlParameter("@M28", sTM28))
    '        oCmd.Parameters.Add(New SqlParameter("@Singtel", sTSingtel))
    '        oCmd.Parameters.Add(New SqlParameter("@UpkeepTxDate", sTTxDate))
    '        oCmd.Parameters.Add(New SqlParameter("@UpkeepTxUpdate", Now()))
    '        oCmd.Parameters.Add(New SqlParameter("@TotalAmount", total))


    '        oCmd.ExecuteNonQuery()
    '        UpdateUpkeepTx = True

    '    Catch ex As Exception
    '        UpdateUpkeepTx = False
    '        lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message
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

    'Public Function UpdateTx(ByRef sUpkeeptxID As String, ByRef sTStarhub As String, ByRef sTM1 As String, ByRef sTM5 As String, ByRef sTM18 As String, ByRef sTM28 As String, ByRef sTSingtel As String, ByRef sTTxDate As String) As Boolean
    '    Dim oConn As New SqlConnection
    '    Dim oCmd As New SqlCommand
    '    'Dim oDR As SqlDataReader
    '    Dim bIsValid As Boolean = True
    '    Dim sSQL As String = ""



    '    Dim total As Integer
    '    Dim a As Integer = Convert.ToInt32(txtTS.Text)
    '    Dim b As Integer = Convert.ToInt32(txtTM1.Text)
    '    Dim c As Integer = Convert.ToInt32(txtTM5.Text)
    '    Dim d As Integer = Convert.ToInt32(txtTM18.Text)
    '    Dim g As Integer = Convert.ToInt32(txtTM28.Text)
    '    Dim f As Integer = Convert.ToInt32(txtTSing.Text)
    '    total = a + b + c + d + g + f

    '    UpdateTx = False
    '    Try
    '        sSQL = "UPDATE UpkeepTx SET Starhub = @Starhub,M1 = @M1, M5 = @M5, M18 = @M18, M28 = @M28 ,Singtel= @Singtel,TotalAmount = @TotalAmount, UpkeepTX_Date = @UpkeepTxDate, UpkeepTX_Update = @UpkeepTxUpdate WHERE (UpkeepTx_ID = @UpkeepTx_ID)"
    '        oConn = New SqlConnection()
    '        oConn.ConnectionString =
    '        ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

    '        oCmd = New SqlCommand
    '        oCmd.CommandText = sSQL

    '        oCmd.Connection = oConn
    '        oCmd.Connection.Open()

    '        oCmd.Parameters.Clear()


    '        'oCmd.Parameters.Add(New SqlParameter("@Starhub1", a))
    '        'oCmd.Parameters.Add(New SqlParameter("@M11", b))
    '        'oCmd.Parameters.Add(New SqlParameter("@M51", c))
    '        'oCmd.Parameters.Add(New SqlParameter("@M181", d))
    '        'oCmd.Parameters.Add(New SqlParameter("@M281", g))
    '        'oCmd.Parameters.Add(New SqlParameter("@Singtel1", f))

    '        'oCmd.Parameters.Add(New SqlParameter("@Starhub2", a))
    '        'oCmd.Parameters.Add(New SqlParameter("@M12", b))
    '        'oCmd.Parameters.Add(New SqlParameter("@M52", c))
    '        'oCmd.Parameters.Add(New SqlParameter("@M182", d))
    '        'oCmd.Parameters.Add(New SqlParameter("@M282", g))
    '        'oCmd.Parameters.Add(New SqlParameter("@Singtel2", f))


    '        oCmd.Parameters.Add(New SqlParameter("@UpkeepTx_ID", sUpkeeptxID))

    '        oCmd.Parameters.Add(New SqlParameter("@Starhub", sTStarhub))
    '        oCmd.Parameters.Add(New SqlParameter("@M1", sTM1))
    '        oCmd.Parameters.Add(New SqlParameter("@M5", sTM5))
    '        oCmd.Parameters.Add(New SqlParameter("@M18", sTM18))
    '        oCmd.Parameters.Add(New SqlParameter("@M28", sTM28))
    '        oCmd.Parameters.Add(New SqlParameter("@Singtel", sTSingtel))
    '        oCmd.Parameters.Add(New SqlParameter("@UpkeepTxDate", sTTxDate))
    '        oCmd.Parameters.Add(New SqlParameter("@UpkeepTxUpdate", Now()))
    '        oCmd.Parameters.Add(New SqlParameter("@TotalAmount", total))


    '        oCmd.ExecuteNonQuery()
    '        UpdateTx = True

    '    Catch ex As Exception
    '        UpdateTx = False
    '        lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message
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

    'Public Function UpdateTxUAdd(ByRef sTTxDate As String) As Boolean
    '    Dim oConn As New SqlConnection
    '    Dim oCmd As New SqlCommand
    '    'Dim oDR As SqlDataReader
    '    Dim bIsValid As Boolean = True
    '    Dim sSQL As String = ""



    '    Dim total As Integer
    '    Dim a As Integer = Convert.ToInt32(txtTS.Text)
    '    Dim b As Integer = Convert.ToInt32(txtTM1.Text)
    '    Dim c As Integer = Convert.ToInt32(txtTM5.Text)
    '    Dim d As Integer = Convert.ToInt32(txtTM18.Text)
    '    Dim g As Integer = Convert.ToInt32(txtTM28.Text)
    '    Dim f As Integer = Convert.ToInt32(txtTSing.Text)
    '    total = a + b + c + d + g + f

    '    UpdateTxUAdd = False
    '    Try
    '        sSQL = "UPDATE Upkeep SET StarhubCurrent  = StarhubCurrent + @Starhub2 ,M1Current = M1Current + @M12 ,M5Current = M5Current + @M52 ,M18Current = M18Current + @M182 ,M28Current = M28Current + @M282 ,SingtelCurrent = SingtelCurrent + @Singtel2 WHERE(@UpkeepTxDate > OpeningDate AND YEAR(ClosingDate)=1900) OR (@UpkeepTxDate BETWEEN OpeningDate AND ClosingDate)"
    '        oConn = New SqlConnection()
    '        oConn.ConnectionString =
    '        ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

    '        oCmd = New SqlCommand
    '        oCmd.CommandText = sSQL

    '        oCmd.Connection = oConn
    '        oCmd.Connection.Open()

    '        oCmd.Parameters.Clear()


    '        'oCmd.Parameters.Add(New SqlParameter("@Starhub1", a))
    '        'oCmd.Parameters.Add(New SqlParameter("@M11", b))
    '        'oCmd.Parameters.Add(New SqlParameter("@M51", c))
    '        'oCmd.Parameters.Add(New SqlParameter("@M181", d))
    '        'oCmd.Parameters.Add(New SqlParameter("@M281", g))
    '        'oCmd.Parameters.Add(New SqlParameter("@Singtel1", f))

    '        oCmd.Parameters.Add(New SqlParameter("@Starhub2", a))
    '        oCmd.Parameters.Add(New SqlParameter("@M12", b))
    '        oCmd.Parameters.Add(New SqlParameter("@M52", c))
    '        oCmd.Parameters.Add(New SqlParameter("@M182", d))
    '        oCmd.Parameters.Add(New SqlParameter("@M282", g))
    '        oCmd.Parameters.Add(New SqlParameter("@Singtel2", f))
    '        oCmd.Parameters.Add(New SqlParameter("@UpkeepTxDate", sTTxDate))


    '        'oCmd.Parameters.Add(New SqlParameter("@UpkeepTx_ID", sUpkeeptxID))

    '        'oCmd.Parameters.Add(New SqlParameter("@Starhub", sTStarhub))
    '        'oCmd.Parameters.Add(New SqlParameter("@M1", sTM1))
    '        'oCmd.Parameters.Add(New SqlParameter("@M5", sTM5))
    '        'oCmd.Parameters.Add(New SqlParameter("@M18", sTM18))
    '        'oCmd.Parameters.Add(New SqlParameter("@M28", sTM28))
    '        'oCmd.Parameters.Add(New SqlParameter("@Singtel", sTSingtel))
    '        'oCmd.Parameters.Add(New SqlParameter("@UpkeepTxDate", sTTxDate))
    '        'oCmd.Parameters.Add(New SqlParameter("@UpkeepTxUpdate", Now()))
    '        'oCmd.Parameters.Add(New SqlParameter("@TotalAmount", total))


    '        oCmd.ExecuteNonQuery()
    '        UpdateTxUAdd = True

    '    Catch ex As Exception
    '        UpdateTxUAdd = False
    '        lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message
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

    'Public Function UpdateTxUSub(ByRef UpkeepTxID As String) As Boolean
    '    Dim oConn As New SqlConnection
    '    Dim oCmd As New SqlCommand
    '    'Dim oDR As SqlDataReader
    '    Dim bIsValid As Boolean = True
    '    Dim sSQL As String = ""
    '    Dim dtbl As DataTable
    '    Dim sqlDa As SqlDataAdapter

    '    UpdateTxUSub = False
    '    Try
    '        sSQL = "UPDATE Upkeep SET StarhubCurrent  = StarhubCurrent - @Starhub2 ,M1Current = M1Current - @M12 ,M5Current = M5Current - @M52 ,M18Current = M18Current - @M182 ,M28Current = M28Current - @M282 ,SingtelCurrent = SingtelCurrent - @Singtel2 WHERE(@UpkeepTxDate > OpeningDate AND YEAR(ClosingDate)=1900) OR (@UpkeepTxDate BETWEEN OpeningDate AND ClosingDate)"
    '        oConn = New SqlConnection()
    '        oConn.ConnectionString =
    '        ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

    '        oCmd = New SqlCommand
    '        oCmd.CommandText = sSQL

    '        oCmd.Connection = oConn
    '        oCmd.Connection.Open()

    '        oCmd.Parameters.Clear()



    '        Dim aa As Integer = dtbl.Rows(0)("Starhub").ToString
    '        Dim bb As Integer = dtbl.Rows(0)("M1").ToString
    '        Dim cc As Integer = dtbl.Rows(0)("M5").ToString
    '        Dim dd As Integer = dtbl.Rows(0)("M18").ToString
    '        Dim ee As Integer = dtbl.Rows(0)("M28").ToString
    '        Dim ff As Integer = dtbl.Rows(0)("Singtel").ToString
    '        Dim gg As Integer = dtbl.Rows(0)("UpkeepTX_Date").ToString



    '        oCmd.Parameters.Add(New SqlParameter("@Starhub2", aa))
    '        oCmd.Parameters.Add(New SqlParameter("@M12", bb))
    '        oCmd.Parameters.Add(New SqlParameter("@M52", cc))
    '        oCmd.Parameters.Add(New SqlParameter("@M182", dd))
    '        oCmd.Parameters.Add(New SqlParameter("@M282", ee))
    '        oCmd.Parameters.Add(New SqlParameter("@Singtel2", ff))
    '        oCmd.Parameters.Add(New SqlParameter("@UpkeepTxDate", gg))




    '        oCmd.ExecuteNonQuery()
    '        UpdateTxUSub = True

    '    Catch ex As Exception
    '        UpdateTxUSub = False
    '        lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message
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
End Class