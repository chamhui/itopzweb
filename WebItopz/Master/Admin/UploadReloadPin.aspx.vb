
Imports System.IO
Imports System.Data.SqlClient

Partial Class Admin_UploadReloadPin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("AGENT_ID") = "" Then
            Response.Redirect("~/Master/Login.aspx")
        End If

        Dim sAction As Object
        Dim sFileName As String

        Me.btnActive.Visible = False
        Me.btnDelete.Visible = False


        If FolderExists(ConfigurationManager.AppSettings("UploadPath")) = False Then
            CreateFolder(ConfigurationManager.AppSettings("UploadPath"))
        End If

        If Not Page.IsPostBack Then
            'Response.Write("1" & Session("EXTRACT"))
            sAction = (Request("act") & "").Trim.ToUpper
            sFileName = (Request("FileName") & "").Trim
            Select Case sAction
                Case "EXTRACT"
                    'If Session("EXTRACT") = "" Then
                    ExtractData(sFileName)
                    'End If
                    'Session("EXTRACT") = "DONE"
                Case Else
                    'Session("EXTRACT") = ""
            End Select
        End If

        Me.lblMsg.Text = ""
        Me.lblMsgError.Text = ""
 
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

    Protected Sub GridView2_PreRender(ByVal sender As Object, ByVal e As System.EventArgs)
        If (GridView2.Rows.Count > 0) Then
            GridView2.UseAccessibleHeader = True
            GridView2.HeaderRow.TableSection = TableRowSection.TableHeader
            If (GridView2.BottomPagerRow IsNot Nothing) Then

                GridView2.BottomPagerRow.TableSection = TableRowSection.TableFooter
                GridView2.BottomPagerRow.Cells(0).Attributes.Add("align", "left")
                'GridView2.FooterRow.TableSection = TableRowSection.TableFooter
            End If
        End If


    End Sub

    Public Function FolderExists(ByVal FolderPath As String) As Boolean

        Dim f As New IO.DirectoryInfo(FolderPath)
        Return f.Exists

    End Function

    Public Sub CreateFolder(ByVal FolderPath As String)
        Directory.CreateDirectory(FolderPath)
    End Sub


    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        If MyFile.HasFile Then 
            UploadFile()
            MyFile.Dispose()
        End If

    End Sub

    Private Sub UploadFile()
        Dim sPostedFile As String
        Dim sTInStrRev As String
        Dim sUploadFileName As String
        Dim sUploadFilePath As String

        sPostedFile = MyFile.PostedFile.FileName
        sTInStrRev = InStrRev(sPostedFile, "\", Len(sPostedFile))
        sUploadFileName = Mid(sPostedFile, sTInStrRev + 1)
        sUploadFilePath = ConfigurationManager.AppSettings("UploadPath") & sUploadFileName

        MyFile.PostedFile.SaveAs(sUploadFilePath)
        If MyFile.PostedFile.ContentLength = 0 Then
            span1.InnerHtml = "error"
        Else
            'Dim fsBZ2Archive As FileStream
            Dim fsOutput As String
            Dim sOutputFilename As String

            sOutputFilename = Path.GetFileNameWithoutExtension(sPostedFile)
            If Right(sUploadFileName, 3) = "txt" Then
                fsOutput = sOutputFilename + ".txt"
            Else
                Dim sFileNameExtension As String
                sFileNameExtension = Right(sUploadFileName, 3)
                fsOutput = sOutputFilename + "." + sFileNameExtension
            End If

            ' Response.Write(fsOutput)

            span1.InnerHtml = "done : " & sUploadFileName

            If Right(sUploadFileName, 3) = "txt" Then
                Server.Transfer("./UploadReloadPin.aspx?act=extract&FileName=" & fsOutput)
            End If

        End If
        MyFile = Nothing

    End Sub


    Private Function ExtractData(ByVal sFileName As String) As Boolean

        Dim sSQL As String = ""
        Dim oConn As New SqlConnection
        Dim oCmd As New SqlCommand
        Dim sReadContents As String = ""
        Dim iCount As Integer = 0
        Dim iCountService As Integer = 0
        Dim oSR As StreamReader = Nothing

        Dim sReloadTelco As String = ""
        Dim sProcessorID As String = ""
        Dim sSerialNumber As String = ""
        Dim sReloadPin As String = ""
        Dim sAmount As String = ""
        Dim sTextDelimiter As Char = ControlChars.Tab
        Dim SplitOut() As String
        Dim sBatchID As String = ""
        Dim sCreatedTS As String = Now() ' Format(Now(), "yyyyMMddHHmmss")

        Try

            ExtractData = False

            sSQL = "INSERT INTO ReloadPin(ReloadTelco, ProcessorID, SerialNumber, ReloadPin, Amount, BatchId, CreatedTS) " & _
                    "values(@ReloadTelco, @ProcessorID, @SerialNumber, @ReloadPin, @Amount, @BatchId, @CreatedTS)"

            oConn = New SqlConnection()
            oConn.ConnectionString = ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString
            oCmd = New SqlCommand
            oCmd.CommandText = sSQL
            oCmd.Connection = oConn
            oCmd.Connection.Open()
            With oCmd.Parameters
                .Clear()
                .Add("@ReloadTelco", Data.SqlDbType.VarChar, 50)
                .Add("@ProcessorID", Data.SqlDbType.VarChar, 50)
                .Add("@SerialNumber", Data.SqlDbType.VarChar, 50)
                .Add("@ReloadPin", Data.SqlDbType.VarChar, 20)
                .Add("@Amount", Data.SqlDbType.VarChar, 20)
                .Add("@BatchId", Data.SqlDbType.VarChar, 20)
                .Add("@CreatedTS", Data.SqlDbType.DateTime)
            End With
            oCmd.Prepare()

            oSR = File.OpenText(ConfigurationManager.AppSettings("UploadPath") & Request.QueryString("FileName"))

            sBatchID = getBatchID(oConn)

            While oSR.Peek() <> -1

                sReadContents = oSR.ReadLine()
                SplitOut = Split(sReadContents, sTextDelimiter)
                Me.lblMsg.Text = UBound(SplitOut).ToString

                If UBound(SplitOut) = 4 Then

                    Me.lblMsgError.Text = "Success Uploaded File"

                    sReloadTelco = SplitOut(0).ToString.Trim
                    sProcessorID = SplitOut(1).ToString.Trim
                    sSerialNumber = SplitOut(2).ToString.Trim
                    sReloadPin = SplitOut(3).ToString.Trim
                    sAmount = SplitOut(4).ToString.Trim

                    With oCmd
                        .Parameters("@ReloadTelco").Value = sReloadTelco
                        .Parameters("@ProcessorID").Value = sProcessorID
                        .Parameters("@SerialNumber").Value = sSerialNumber
                        .Parameters("@ReloadPin").Value = sReloadPin
                        .Parameters("@Amount").Value = sAmount
                        .Parameters("@BatchId").Value = sBatchID
                        .Parameters("@CreatedTS").Value = sCreatedTS
                    End With
                    oCmd.ExecuteNonQuery()
                    iCount = iCount + 1
                Else
                    Me.lblMsgError.Text = "Error Uploaded File"
                End If

            End While

            Me.lblMsg.Text = "Total " & iCount.ToString & " Record(s) Inserted."

        Catch ex As Exception
            lblMsg.Text = ex.Message
            lblMsg.Visible = True
            Response.Write("Error: " & ex.Message & vbCrLf & "Trace: " & ex.StackTrace & vbCrLf & "SQL: " & sSQL)
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
            oSR.Close()
            Dim sNewFileName As String
            sNewFileName = "ReloadPIN_" & Format(Now, "yyyyMMddHHmmss") & ".txt"
            File.Move(ConfigurationManager.AppSettings("UploadPath") & sFileName, ConfigurationManager.AppSettings("UploadPath") & sNewFileName)
            Dim fInfo As FileInfo
            fInfo = New FileInfo(ConfigurationManager.AppSettings("UploadPath") & sFileName)
            fInfo.Delete()
        End Try
    End Function



    Private Function getBatchID(ByVal oConn As SqlConnection) As String

        Dim sSQL As String = ""
        ' Dim oConn As New SqlConnection(gsDBConnString)
        Dim oCmd As New SqlCommand
        Dim oDR As SqlDataReader = Nothing
        Dim sAgentID As String = ""

        Try
            getBatchID = 1
            'oConn.Open()

            oCmd = oConn.CreateCommand
            oCmd.Connection = oConn
            sSQL = "SELECT Top 1 BatchId+1 as BatchId FROM ReloadPin Order By BatchId DESC"
            oCmd.CommandText = sSQL
            With oCmd.Parameters
                .Clear()
 
            End With
            oDR = oCmd.ExecuteReader

            If oDR.Read() Then
                getBatchID = oDR.Item("BatchId")
            End If
            oDR.Close()
            'oConn.Close()

            getBatchID = getBatchID
        Catch ex As Exception
            getBatchID = ""
            Response.Write("getBatchID [" & ex.Message & "]")
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

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

        Dim sBatchId = GridView1.SelectedRow.Cells(1).Text
        Dim sReloadTelco = GridView1.SelectedRow.Cells(2).Text
        Dim sProcessorId = GridView1.SelectedRow.Cells(3).Text
        Dim sAmount = GridView1.SelectedRow.Cells(4).Text


        Session("sBatchId") = sBatchId
        Session("sReloadTelco") = sReloadTelco
        Session("sProcessorId") = sProcessorId
        Session("sAmount") = sAmount

        If sBatchId <> "" Then
            Me.btnActive.Visible = True
            Me.btnDelete.Visible = True
        Else
            Me.btnActive.Visible = False
            Me.btnDelete.Visible = False
        End If

    End Sub


    Private Function UpdateBatchStatus(ByVal sBatchStatus As String) As Boolean

        Dim sSQL As String = ""
        Dim oConn As New SqlConnection
        Dim oCmd As New SqlCommand
        Dim oDR As SqlDataReader = Nothing
        Dim sAgentID As String = ""

        Try
            UpdateBatchStatus = False

            sSQL = "UPDATE RELOADPIN SET BatchStatus=@sBatchStatus WHERE BatchId=@sBatchId AND ReloadTelco=@sReloadTelco AND ProcessorID=@sProcessorID AND Amount=@sAmount"
            oConn = New SqlConnection()
            oConn.ConnectionString = ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString
            oCmd = New SqlCommand
            oCmd.CommandText = sSQL
            oCmd.Connection = oConn
            oCmd.Connection.Open()

            With oCmd.Parameters
                .Clear()
                .AddWithValue("@sBatchStatus", sBatchStatus)
                .AddWithValue("@sBatchId", Session("sBatchId"))
                .AddWithValue("@sReloadTelco", Session("sReloadTelco"))
                .AddWithValue("@sProcessorID", Session("sProcessorId"))
                .AddWithValue("@sAmount", Session("sAmount"))
            End With
            oCmd.ExecuteNonQuery()
            oConn.Close()

            UpdateBatchStatus = True
        Catch ex As Exception
            UpdateBatchStatus = False
            Response.Write("UpdateBatchStatus [" & ex.Message & "]")
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
                If oConn.State = Data.ConnectionState.Open Then
                    oConn.Close()
                End If
                oConn.Dispose()
                oConn = Nothing
            End If
        End Try

    End Function

    Protected Sub btnActive_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnActive.Click
        UpdateBatchStatus("ACTIVE")
        Me.GridView1.DataBind()
        Me.GridView2.DataBind()
    End Sub


    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        UpdateBatchStatus("DELETE")
        Me.GridView1.DataBind()
        Me.GridView2.DataBind()
    End Sub
End Class
