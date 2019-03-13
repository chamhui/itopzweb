Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports System.Data
Imports System.Data.OleDb
Imports System

Partial Class Upkeep2
    Inherits System.Web.UI.Page

    'Dim sqlCon As SqlConnection = New SqlConnection("Data Source=WIN8; Initial Catalog=SMSReloadSG;Integrated Security=True;")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        formupkeep.Style.Add("display", "none")

        'If Session("AGENT_ID") = "" Then
        '    Response.Redirect("~/Master/Login.aspx")
        'End If
        txtID.ReadOnly = True
        txtSO.ReadOnly = True
        txtM1O.ReadOnly = True
        txtM5O.ReadOnly = True
        txtM18O.ReadOnly = True
        txtM28O.ReadOnly = True
        txtSingO.ReadOnly = True
        txtOD.ReadOnly = True

        FillGridView()

        btnCloseDate.Enabled = False
        'btnSave.Enabled = False
        btnUpdate.Enabled = False


    End Sub

    Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtSO.Text = String.Empty
        txtM1O.Text = String.Empty
        txtM5O.Text = String.Empty
        txtM18O.Text = String.Empty
        txtM28O.Text = String.Empty
        txtSingO.Text = String.Empty
        txtOD.Text = String.Empty
        txtSC.Text = String.Empty
        txtM1C.Text = String.Empty
        txtM5C.Text = String.Empty
        txtM18C.Text = String.Empty
        txtM28C.Text = String.Empty
        txtSingC.Text = String.Empty
        txtCD.Text = String.Empty


    End Sub

    'Protected Sub btnSave_Click(sender As Object, e As System.EventArgs) Handles btnSave.Click


    '    If InsertNewUpkeep(txtSC.Text, Me.txtM1C.Text, Me.txtM5C.Text, Me.txtM18C.Text, Me.txtM28C.Text, Me.txtSingC.Text, Me.txtCD.Text) Then
    '        Me.btnSave.Enabled = True
    '        Me.lblErrorMsg.Text = "Added Successfully! "
    '    End If
    '    'Dim oConn As New SqlConnection
    '    'Dim oCmd As New SqlCommand
    '    'Dim bIsValid As Boolean = True
    '    'Dim sSQL As String = ""

    '    'btnSave = Nothing

    '    'Try
    '    '    sSQL = "INSERT INTO Upkeep(StarhubCurrent,M1Current,M5Current ,M18Current ,M28Current ,SingtelCurrent,ClosingDate) VALUES(@StarhubCurrent,@M1Current,@M5Current,@M18Current,@M28Current,@SingtelCurrent,@ClosingDate)"

    '    '    oConn = New SqlConnection()
    '    '    oConn.ConnectionString =
    '    '    ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

    '    '    oCmd = New SqlCommand
    '    '    oCmd.CommandText = sSQL
    '    '    oCmd.Connection = oConn
    '    '    oCmd.Connection.Open()

    '    '    oCmd.Parameters.Clear()
    '    '    oCmd.Parameters.Add(New SqlParameter("@AgentID", sNewAgentId))
    '    '    oCmd.Parameters.Add(New SqlParameter("@Name", sName))
    '    '    oCmd.Parameters.Add(New SqlParameter("@HPNo", sHPno))

    '    '    oCmd.ExecuteNonQuery()
    '    '    InsertNewAgent = True


    '    'Catch ex As Exception
    '    '    InsertNewAgent = False
    '    '    lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message & ex.StackTrace
    '    'Finally
    '    '    If (Not oCmd Is Nothing) Then
    '    '        oCmd.Dispose()
    '    '        oCmd = Nothing
    '    '    End If
    '    '    If Not oConn Is Nothing Then
    '    '        If oConn.State = Data.ConnectionState.Open Then
    '    '            oConn.Close()
    '    '        End If
    '    '        oConn.Dispose()
    '    '        oConn = Nothing
    '    '    End If
    '    'End Try

    '    'Dim strsc As String = Request.Form("txtSC")
    '    'Dim strm1c As String = Request.Form("txtM1C")
    '    'Dim strm5c As String = Request.Form("txtM5C")
    '    'Dim strm18c As String = Request.Form("txtM18C")
    '    'Dim strm28c As String = Request.Form("txtM28C")
    '    'Dim strsingc As String = Request.Form("txtSingC")
    '    'Dim strCD As String = Request.Form("txtCD")

    '    'Dim objconnection As OleDbConnection = Nothing
    '    'Dim objcmd As OleDbCommand = Nothing
    '    'Dim strconnection As String, strSQL As String

    '    ''connection string
    '    'strconnection = "Data Source=WIN8;Initial Catalog=SMSReloadSG;Integrated Security=True"
    '    'objconnection = New OleDbConnection(strconnection)
    '    'objconnection.ConnectionString = strconnection
    '    'objconnection.Open()

    '    'strSQL = "INSERT INTO Upkeep(StarhubCurrent,M1Current,M5Current ,M18Current ,M28Current ,SingtelCurrent,ClosingDate) VALUES(?,?,?,?,?,?,?)"
    '    'objcmd = New OleDbCommand(strSQL, objconnection)
    '    'objcmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("@StarhubCurrent", strsc))
    '    'objcmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("@M1Current", strsc))
    '    'objcmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("@M5Current", strsc))
    '    'objcmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("@M18Current", strsc))
    '    'objcmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("@M28Current", strsc))
    '    'objcmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("@SingtelCurrent", strsc))
    '    'objcmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ClosingDate", strsc))
    '    'objcmd.ExecuteNonQuery()

    '    ''close connection 
    '    'objconnection.Close()
    '    'Response.Write("Entered Successfully")

    '    'Dim oConn As New SqlConnection
    '    'Dim oCmd As New SqlCommand
    '    ''Dim oDR As SqlDataReader
    '    'Dim bIsValid As Boolean = True
    '    'Dim sSQL As String = ""

    '    'Try
    '    '    oConn = New SqlConnection()
    '    '    oConn.ConnectionString =
    '    '    ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString


    '    '    oCmd = New SqlCommand
    '    '    sSQL = ("UpkeepCreateOrUpdate")
    '    '    oCmd.CommandText = sSQL
    '    '    oCmd.CommandType = CommandType.StoredProcedure
    '    '    oCmd.Connection = oConn
    '    '    oCmd.Connection.Open()


    '    '    oCmd.Parameters.Clear()
    '    '    oCmd.Parameters.AddWithValue("@StarhubOpening", txtSO.Text.Trim())
    '    '    oCmd.Parameters.AddWithValue("@M1Opening", txtM1O.Text.Trim())
    '    '    oCmd.Parameters.AddWithValue("@M5Opening", txtM5O.Text.Trim())
    '    '    oCmd.Parameters.AddWithValue("@M18Opening", txtM18O.Text.Trim())
    '    '    oCmd.Parameters.AddWithValue("@M28Opening", txtM28O.Text.Trim())
    '    '    oCmd.Parameters.AddWithValue("@DateOpening", txtOD.Text.Trim())
    '    '    oCmd.Parameters.AddWithValue("@StarhubCurrent", txtSC.Text.Trim())
    '    '    oCmd.Parameters.AddWithValue("@M1Current", txtM1C.Text.Trim())
    '    '    oCmd.Parameters.AddWithValue("@M5Current", txtM5C.Text.Trim())
    '    '    oCmd.Parameters.AddWithValue("@M18Current", txtM18C.Text.Trim())
    '    '    oCmd.Parameters.AddWithValue("@M28Current", txtM28C.Text.Trim())
    '    '    oCmd.Parameters.AddWithValue("@ClosingDate", txtCD.Text.Trim())

    '    '    oCmd.ExecuteNonQuery()
    '    '    sqlCon.Close()
    '    '    Clear()

    '    'Catch ex As Exception
    '    'Finally
    '    '    If (Not oCmd Is Nothing) Then
    '    '        oCmd.Dispose()
    '    '        oCmd = Nothing
    '    '    End If
    '    '    If Not oConn Is Nothing Then
    '    '        If oConn.State = Data.ConnectionState.Open Then
    '    '            oConn.Close()
    '    '        End If
    '    '        oConn.Dispose()
    '    '        oConn = Nothing
    '    '    End If
    '    'End Try


    'End Sub

    Private Function InsertNewUpkeep(ByVal sStarhubCurrent As String, ByVal sM1Current As String, ByVal sM5Current As String, ByVal sM18Current As String, ByVal sM28Current As String, ByVal sSingtelCurrent As String, ByVal sClosingDate As String) As Boolean
        Dim oConn As New SqlConnection
        Dim oCmd As New SqlCommand
        Dim bIsValid As Boolean = True
        Dim sSQL As String = ""

        InsertNewUpkeep = True

        Try
            sSQL = "INSERT INTO Upkeep(StarhubCurrent,M1Current,M5Current ,M18Current ,M28Current ,SingtelCurrent,ClosingDate) VALUES(@StarhubCurrent,@M1Current,@M5Current,@M18Current,@M28Current,@SingtelCurrent,@ClosingDate)"

            oConn = New SqlConnection()
            oConn.ConnectionString =
            ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

            oCmd = New SqlCommand
            oCmd.CommandText = sSQL
            oCmd.Connection = oConn
            oCmd.Connection.Open()

            oCmd.Parameters.Clear()
            oCmd.Parameters.Add(New SqlParameter("@StarhubCurrent", sStarhubCurrent))
            oCmd.Parameters.Add(New SqlParameter("@M1Current", sM1Current))
            oCmd.Parameters.Add(New SqlParameter("@M5Current", sM5Current))
            oCmd.Parameters.Add(New SqlParameter("@M18Current", sM18Current))
            oCmd.Parameters.Add(New SqlParameter("@M28Current", sM28Current))
            oCmd.Parameters.Add(New SqlParameter("@SingtelCurrent", sSingtelCurrent))
            oCmd.Parameters.Add(New SqlParameter("@ClosingDate", sClosingDate))


            oCmd.ExecuteNonQuery()
            InsertNewUpkeep = True
            Dim upid As String = hfUpkeepID.Value

            If (upid = "") Then
                lblErrorMsg.Text = "Saved Successfully"
            Else
                lblErrorMsg.Text = "Updated Successfully"

            End If


        Catch ex As Exception
            InsertNewUpkeep = False
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

    Private Function FillGridView()
        Dim oConn As New SqlConnection
        Dim oCmd As New SqlCommand
        Dim bIsValid As Boolean = True
        Dim sSQL As String = ""
        Dim dtbl As DataTable
        Dim sqlDa As SqlDataAdapter

        FillGridView = False

        Try
            sSQL = "SELECT * FROM Upkeep"

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
            gvUpkeep.DataSource = dtbl
            gvUpkeep.DataBind()

            gvUpkeep.PagerSettings.Mode = PagerButtons.NextPreviousFirstLast






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

    Protected Sub lnk_onClick(sender As Object, e As EventArgs)
        formupkeep.Style.Add("display", "block")
        gridupkeep.Style.Add("display", "none")


        txtSO.ReadOnly = False
        txtM1O.ReadOnly = False
        txtM5O.ReadOnly = False
        txtM18O.ReadOnly = False
        txtM28O.ReadOnly = False
        txtSingO.ReadOnly = False
        txtOD.ReadOnly = False

        Dim UpkeepID As Integer = Convert.ToInt32(CType(sender, LinkButton).CommandArgument)
        Dim oConn As New SqlConnection
        Dim oCmd As New SqlCommand
        Dim bIsValid As Boolean = True
        Dim sSQL As String = ""
        Dim dtbl As DataTable
        Dim sqlDa As SqlDataAdapter


        Try
            sSQL = "SELECT * FROM Upkeep WHERE (UpkeepID = @UpkeepID)"

            oConn = New SqlConnection()
            oConn.ConnectionString = ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

            oCmd = New SqlCommand
            oCmd.CommandText = sSQL
            oCmd.Connection = oConn
            oCmd.Connection.Open()

            'oCmd.Parameters.Clear()
            'dtbl = New DataTable
            'gvUpkeep.DataSource = dtbl
            'gvUpkeep.DataBind()

            sqlDa = New SqlDataAdapter(sSQL, oConn)
            sqlDa.SelectCommand.Parameters.Add(New SqlParameter("@UpkeepID", UpkeepID))
            'oCmd.Parameters.Add(New SqlParameter("@UpkeepID", UpkeepID))
            'oCmd.ExecuteNonQuery()
            dtbl = New DataTable
            sqlDa.Fill(dtbl)
            gvUpkeep.DataSource = dtbl
            gvUpkeep.DataBind()
            hfUpkeepID.Value = UpkeepID.ToString()


            txtID.Text = dtbl.Rows(0)("UpkeepID").ToString
            txtSO.Text = dtbl.Rows(0)("StarhubOpening").ToString
            txtM1O.Text = dtbl.Rows(0)("M1Opening").ToString
            txtM5O.Text = dtbl.Rows(0)("M5Opening").ToString
            txtM18O.Text = dtbl.Rows(0)("M18Opening").ToString
            txtM28O.Text = dtbl.Rows(0)("M28Opening").ToString
            txtSingO.Text = dtbl.Rows(0)("SingtelOpening").ToString
            txtOD.Text = dtbl.Rows(0)("OpeningDate").ToString.Substring(0,10)
            txtSC.Text = dtbl.Rows(0)("StarhubCurrent").ToString
            txtM1C.Text = dtbl.Rows(0)("M1Current").ToString
            txtM5C.Text = dtbl.Rows(0)("M5Current").ToString
            txtM18C.Text = dtbl.Rows(0)("M18Current").ToString
            txtM28C.Text = dtbl.Rows(0)("M28Current").ToString
            txtSingC.Text = dtbl.Rows(0)("SingtelCurrent").ToString
            txtCD.Text = dtbl.Rows(0)("ClosingDate").ToString.Substring(0,10)

            btnCloseDate.Enabled = True
            btnUpdate.Enabled = True




        Catch ex As Exception
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

    End Sub


    Protected Sub btnCloseDate_Click(sender As Object, e As EventArgs) Handles btnCloseDate.Click
        If CloseDate(Me.txtID.Text, Me.txtSC.Text, Me.txtM1C.Text, Me.txtM5C.Text, Me.txtM18C.Text, Me.txtM28C.Text, Me.txtSingC.Text, Me.txtCD.Text) Then
            If CurToOpen(Me.txtSC.Text, Me.txtM1C.Text, Me.txtM5C.Text, Me.txtM18C.Text, Me.txtM28C.Text, Me.txtSingC.Text, Me.txtCD.Text) Then
                Me.lblErrorMsg.Text = "Date Closed Successfully! "
                gvUpkeep.DataBind()
                Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)

            End If
        End If

    End Sub
    Private Function CloseDate(ByRef sUpkeepID As String, ByRef sStarhubCurrent As String, ByRef sM1Current As String, ByRef sM5Current As String, ByRef sM18Current As String, ByRef sM28Current As String, ByRef sSingtelCurrent As String, ByRef sClosingDate As String) As Boolean
        Dim oConn As New SqlConnection
        Dim oCmd As New SqlCommand
        Dim bIsValid As Boolean = True
        Dim sSQL As String = ""
        Dim sSQL2 As String = ""

        Dim stat = "closed"

        Try
            sSQL = "UPDATE Upkeep Set StarhubCurrent = @StarhubCurrent ,M1Current = @M1Current, M5Current = @M5Current, M18Current = @M18Current, M28Current = @M28Current, SingtelCurrent = @SingtelCurrent, ClosingDate = @curDate , Status = @status WHERE (UpkeepID = @UpkeepID)"

            oConn = New SqlConnection()
            oConn.ConnectionString =
            ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

            oCmd = New SqlCommand
            oCmd.CommandText = sSQL
            oCmd.Connection = oConn
            oCmd.Connection.Open()
            hfUpkeepID.Value = sUpkeepID.ToString()


            oCmd.Parameters.Clear()
            oCmd.Parameters.Add(New SqlParameter("@UpkeepID", sUpkeepID))

            oCmd.Parameters.Add(New SqlParameter("@StarhubCurrent", sStarhubCurrent))
            oCmd.Parameters.Add(New SqlParameter("@M1Current", sM1Current))
            oCmd.Parameters.Add(New SqlParameter("@M5Current", sM5Current))
            oCmd.Parameters.Add(New SqlParameter("@M18Current", sM18Current))
            oCmd.Parameters.Add(New SqlParameter("@M28Current", sM28Current))
            oCmd.Parameters.Add(New SqlParameter("@SingtelCurrent", sSingtelCurrent))
            oCmd.Parameters.Add(New SqlParameter("@curDate", sClosingDate))
            oCmd.Parameters.Add(New SqlParameter("@status", stat))


            oCmd.ExecuteNonQuery()

            oCmd.Parameters.Clear()

            Dim upid As String = hfUpkeepID.Value

            If (upid = "") Then
                lblErrorMsg.Text = "Saved Successfully"
            Else
                lblErrorMsg.Text = "Updated Successfully"

            End If
            Return True

        Catch ex As Exception
            lblErrorMsg.Text = "Error Occurred. Please contact administrator." & ex.Message & ex.StackTrace
            Return False
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
    Private Function CurToOpen(ByVal sStarhubCurrent As String, ByVal sM1Current As String, ByVal sM5Current As String, ByVal sM18Current As String, ByVal sM28Current As String, ByVal sSingtelCurrent As String, ByVal sClosingDate As String) As Boolean
        Dim oConn As New SqlConnection
        Dim oCmd As New SqlCommand
        Dim bIsValid As Boolean = True
        Dim sSQL As String = ""

        CurToOpen = False
        Dim stat = "open"



        Try
            sSQL = "INSERT INTO Upkeep(StarhubOpening,M1Opening,M5Opening ,M18Opening ,M28Opening ,SingtelOpening,OpeningDate,StarhubCurrent,M1Current,M5Current ,M18Current,M28Current ,SingtelCurrent, Status) VALUES (@StarhubCurrent,@M1Current,@M5Current,@M18Current,@M28Current,@SingtelCurrent,@ClosingDate,@StarhubCurrent,@M1Current,@M5Current,@M18Current,@M28Current,@SingtelCurrent,@Status)"

            oConn = New SqlConnection()
            oConn.ConnectionString =
            ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

            oCmd = New SqlCommand
            oCmd.CommandText = sSQL
            oCmd.Connection = oConn
            oCmd.Connection.Open()

            oCmd.Parameters.Clear()
            oCmd.Parameters.Add(New SqlParameter("@StarhubCurrent", sStarhubCurrent))
            oCmd.Parameters.Add(New SqlParameter("@M1Current", sM1Current))
            oCmd.Parameters.Add(New SqlParameter("@M5Current", sM5Current))
            oCmd.Parameters.Add(New SqlParameter("@M18Current", sM18Current))
            oCmd.Parameters.Add(New SqlParameter("@M28Current", sM28Current))
            oCmd.Parameters.Add(New SqlParameter("@SingtelCurrent", sSingtelCurrent))
            oCmd.Parameters.Add(New SqlParameter("@ClosingDate", sClosingDate))
            oCmd.Parameters.Add(New SqlParameter("@Status", stat))



            oCmd.ExecuteNonQuery()
            CurToOpen = True
            Dim upid As String = hfUpkeepID.Value

            If (upid = "") Then
                CurToOpen = False
                lblErrorMsg.Text = "Saved Successfully"
            Else
                lblErrorMsg.Text = "Updated Successfully"

            End If


        Catch ex As Exception
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

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
       
 Dim OpenDate As Date = Date.ParseExact(txtOD.Text, "dd/MM/yyyy", 
            System.Globalization.DateTimeFormatInfo.InvariantInfo)
         Dim ClosedDate As Date = Date.ParseExact(txtCD.Text, "dd/MM/yyyy", 
            System.Globalization.DateTimeFormatInfo.InvariantInfo)
        If UpdateUpkeep(txtID.Text, txtSO.Text, Me.txtM1O.Text, Me.txtM5O.Text, Me.txtM18O.Text, Me.txtM28O.Text, Me.txtSingO.Text,OpenDate , txtSC.Text, Me.txtM1C.Text, Me.txtM5C.Text, Me.txtM18C.Text, Me.txtM28C.Text, Me.txtSingC.Text, ClosedDate) Then
            Me.lblErrorMsg.Text = "Updated Successfully! "
            gvUpkeep.DataBind()
            Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)

        End If

    End Sub
    Private Function UpdateUpkeep(ByRef sUpkeepID As String, ByRef sStarhubOpening As String, ByRef sM1Opening As String, ByRef sM5Opening As String, ByRef sM18Opening As String, ByRef sM28Opening As String, ByRef sSingtelOpening As String, ByRef sOpeningDate As Date, ByRef sStarhubCurrent As String, ByRef sM1Current As String, ByRef sM5Current As String, ByRef sM18Current As String, ByRef sM28Current As String, ByRef sSingtelCurrent As String, ByRef sClosingDate As Date) As Boolean


        Dim oConn As New SqlConnection
        Dim oCmd As New SqlCommand
        'Dim oDR As SqlDataReader
        Dim bIsValid As Boolean = True
        Dim sSQL As String = ""

        UpdateUpkeep = False
        Try
            sSQL = "UPDATE Upkeep SET StarhubOpening = @StarhubOpening,M1Opening = @M1Opening,M5Opening = @M5Opening,M18Opening = @M18Opening, M28Opening = @M28Opening ,SingtelOpening = @SingtelOpening ,OpeningDate = @OpeningDate, StarhubCurrent = @StarhubCurrent ,M1Current = @M1Current, M5Current = @M5Current, M18Current = @M18Current, M28Current = @M28Current, SingtelCurrent = @SingtelCurrent, ClosingDate = @ClosingDate WHERE (UpkeepID = @UpkeepID)"

            oConn = New SqlConnection()
            oConn.ConnectionString =
            ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

            oCmd = New SqlCommand
            oCmd.CommandText = sSQL
            oCmd.Connection = oConn
            oCmd.Connection.Open()

            oCmd.Parameters.Clear()
            oCmd.Parameters.Add(New SqlParameter("@UpkeepID", sUpkeepID))

            oCmd.Parameters.Add(New SqlParameter("@StarhubOpening", sStarhubOpening))
            oCmd.Parameters.Add(New SqlParameter("@M1Opening", sM1Opening))
            oCmd.Parameters.Add(New SqlParameter("@M5Opening", sM5Opening))
            oCmd.Parameters.Add(New SqlParameter("@M18Opening", sM18Opening))
            oCmd.Parameters.Add(New SqlParameter("@M28Opening", sM28Opening))
            oCmd.Parameters.Add(New SqlParameter("@SingtelOpening", sSingtelOpening))
            oCmd.Parameters.Add(New SqlParameter("@OpeningDate", sOpeningDate))
            oCmd.Parameters.Add(New SqlParameter("@StarhubCurrent", sStarhubCurrent))
            oCmd.Parameters.Add(New SqlParameter("@M1Current", sM1Current))
            oCmd.Parameters.Add(New SqlParameter("@M5Current", sM5Current))
            oCmd.Parameters.Add(New SqlParameter("@M18Current", sM18Current))
            oCmd.Parameters.Add(New SqlParameter("@M28Current", sM28Current))
            oCmd.Parameters.Add(New SqlParameter("@SingtelCurrent", sSingtelCurrent))
            oCmd.Parameters.Add(New SqlParameter("@ClosingDate", sClosingDate))


            oCmd.ExecuteNonQuery()
            UpdateUpkeep = True


        Catch ex As Exception
            UpdateUpkeep = False
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

End Class