Imports System.Data.SqlClient
Imports System.Globalization

Partial Class UpkeepTxAdd
    Inherits System.Web.UI.Page
    Private msNewUpkeepID As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("AGENT_ID") = "" Then
            'Response.Redirect("~/Master/Login.aspx")
        End If
        If IsPostBack = False Then
            txtOpeningDate.Text= Date.Now.ToString("dd/MM/yyyy")
           'LoadUpkeedByID()
        End If
    End Sub
     
    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If Session("AGENT_ID") = "" Then
            'Response.Redirect("~/Master/Login.aspx")
        End If
        Dim sAgentID As String = ""
        

For Each item as Control  in Page.Controls
      
            if TypeOf item is Textbox Then
                    If(CType(item, TextBox).Text ="" )Then
                    CType(item, TextBox).Text ="0"
                    end if

             End if
    next

         UpdateUpkeep() 
     
        UpdatePhoneUpkeepStarhub()
         UpdatePhoneUpkeepM1()
         UpdatePhoneUpkeepSingtel()
        'If GetPreviousCurrent() Then

        ' If InsertNewUpkeep(Me.txtStarhub.Text, Me.txtM1.Text, Me.txtM2.Text, Me.txtSing1.Text, Me.txtSing2.Text, Me.txtSing3.Text) Then
        '    Me.btnSubmit.Enabled = False
        '    Me.lblErrorMsg.Text = "Added Successfully!"
        'End If
        'End If


    End Sub

	Private Function GetPreviousCurrent() As Boolean
        Dim oConn As New SqlConnection
        Dim oCmd As New SqlCommand
        Dim bIsValid As Boolean = True
        Dim sSQL As String = ""

        GetPreviousCurrent = False

        Try
            sSQL = "SELECT StarhubCurrent, M1Current, M2Current, SingtelP1Current, SingtelP2Current, SingtelP3Current FROM Upkeep WHERE"
        Catch ex As Exception

        End Try
    End Function
    'Private Function InsertNewUpkeep(byval status As String) As Boolean

    '    Dim oConn As New SqlConnection
    '    Dim oCmd As New SqlCommand
    '    Dim bIsValid As Boolean = True
    '    Dim sSQL As String = ""

    '    InsertNewUpkeep = False

    '    Try
    '        sSQL = "INSERT INTO Upkeep            (StarhubOpening            ,M1Opening            ,M5Opening            ,M18Opening            ,M28Opening            ,OpeningDate            ,StarhubCurrent            ,M1Current            ,M5Current            ,M18Current            ,M28Current            ,SingtelCurrent            ,ClosingDate            ,Status            ,Singtel5Opening            ,Singtel8Opening            ,Singtel10Opening            ,Singtel15Opening            ,Singtel18Opening            ,Singtel20Opening            ,Singtel22Opening            ,Singtel28Opening            ,Singtel30Opening            ,Singtel50Opening            ,Singtel5Current            ,Singtel8Current            ,Singtel10Current            ,Singtel15Current            ,Singtel18Current            ,Singtel20Current            ,Singtel22Current            ,Singtel28Current            ,Singtel30Current            ,Singtel50Current)      VALUES 	 (@StarhubOpening            ,@M1Opening            ,@M5Opening            ,@M18Opening            ,@M28Opening            ,@OpeningDate            ,@StarhubCurrent            ,@M1Current            ,@M5Current            ,@M18Current            ,@M28Current            ,@SingtelCurrent            ,@ClosingDate            ,@Status            ,@Singtel5Opening            ,@Singtel8Opening            ,@Singtel10Opening            ,@Singtel15Opening            ,@Singtel18Opening            ,@Singtel20Opening            ,@Singtel22Opening            ,@Singtel28Opening            ,@Singtel30Opening            ,@Singtel50Opening            ,@Singtel5Current            ,@Singtel8Current            ,@Singtel10Current            ,@Singtel15Current            ,@Singtel18Current            ,@Singtel20Current            ,@Singtel22Current            ,@Singtel28Current            ,@Singtel30Current            ,@Singtel50Current)"

    '        oConn = New SqlConnection()
    '        oConn.ConnectionString =
    '        ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

    '        oCmd = New SqlCommand
    '        oCmd.CommandText = sSQL
    '        oCmd.Connection = oConn
    '        oCmd.Connection.Open()

    '        oCmd.Parameters.Clear()
    '       		oCmd.Parameters.Add(New SqlParameter("@StarhubOpening", txtStarhubc.Text))
    '       oCmd.Parameters.Add(New SqlParameter("@M1Opening", txtM1c.Text))
    '       oCmd.Parameters.Add(New SqlParameter("@M5Opening", txtM5c.Text))
    '       oCmd.Parameters.Add(New SqlParameter("@M18Opening", txtM18c.Text))
    '       oCmd.Parameters.Add(New SqlParameter("@M28Opening", txtM28c.Text))
    '       oCmd.Parameters.Add(New SqlParameter("@OpeningDate", Date.ParseExact(txtCurrentDate.Text, "dd/MM/yyyy", 
    '        System.Globalization.DateTimeFormatInfo.InvariantInfo)))
    '       oCmd.Parameters.Add(New SqlParameter("@StarhubCurrent", txtStarhubc.Text))
    '       oCmd.Parameters.Add(New SqlParameter("@M1Current", txtM1c.Text))
    '       oCmd.Parameters.Add(New SqlParameter("@M5Current", txtm5c.Text))
    '       oCmd.Parameters.Add(New SqlParameter("@M18Current", txtm18c.Text))
    '       oCmd.Parameters.Add(New SqlParameter("@M28Current", txtm28c.Text))
    '       oCmd.Parameters.Add(New SqlParameter("@SingtelCurrent", 0))
            
    '       oCmd.Parameters.Add(New SqlParameter("@ClosingDate", Date.ParseExact(txtCurrentDate.Text, "dd/MM/yyyy", 
    '        System.Globalization.DateTimeFormatInfo.InvariantInfo)))
    '       oCmd.Parameters.Add(New SqlParameter("@Status", status))
    '       oCmd.Parameters.Add(New SqlParameter("@Singtel5Opening", txtSingtel50c.Text))
    '       oCmd.Parameters.Add(New SqlParameter("@Singtel8Opening", txtsingtel8c.Text))
    '       oCmd.Parameters.Add(New SqlParameter("@Singtel10Opening", txtSingtel10c.Text))
    '       oCmd.Parameters.Add(New SqlParameter("@Singtel15Opening", txtSingtel15c.Text))
    '       oCmd.Parameters.Add(New SqlParameter("@Singtel18Opening", txtSingtel18c.Text))
    '       oCmd.Parameters.Add(New SqlParameter("@Singtel20Opening", txtSingtel20c.Text))
    '       oCmd.Parameters.Add(New SqlParameter("@Singtel22Opening", txtSingtel22c.Text))
    '       oCmd.Parameters.Add(New SqlParameter("@Singtel28Opening", txtSingtel28c.Text))
    '       oCmd.Parameters.Add(New SqlParameter("@Singtel30Opening", txtSingtel30c.Text))
    '       oCmd.Parameters.Add(New SqlParameter("@Singtel50Opening", txtSingtel50c.Text))
    '       oCmd.Parameters.Add(New SqlParameter("@Singtel5Current", txtSingtel5c.Text))
    '       oCmd.Parameters.Add(New SqlParameter("@Singtel8Current", txtSingtel8c.Text))
    '       oCmd.Parameters.Add(New SqlParameter("@Singtel10Current", txtSingtel10c.Text))
    '       oCmd.Parameters.Add(New SqlParameter("@Singtel15Current", txtSingtel15c.Text))
    '       oCmd.Parameters.Add(New SqlParameter("@Singtel18Current", txtSingtel18c.Text))
    '       oCmd.Parameters.Add(New SqlParameter("@Singtel20Current", txtSingtel20c.Text))
    '       oCmd.Parameters.Add(New SqlParameter("@Singtel22Current", txtSingtel22c.Text))
    '       oCmd.Parameters.Add(New SqlParameter("@Singtel28Current", txtSingtel28c.Text))
    '       oCmd.Parameters.Add(New SqlParameter("@Singtel30Current", txtSingtel30c.Text))
    '       oCmd.Parameters.Add(New SqlParameter("@Singtel50Current", txtSingtel50c.Text))

    '         'dim UpKeepID As Integer= Request.QueryString("upkeepid")
    '         '   oCmd.Parameters.Add(New SqlParameter("@UpkeepID", UpKeepID))

    '        oCmd.ExecuteNonQuery()
    '        InsertNewUpkeep = True


    '    Catch ex As Exception
    '        InsertNewUpkeep = False
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
    Private Function UpdateUpkeep() As Boolean

        Dim oConn As New SqlConnection
        Dim oCmd As New SqlCommand
        Dim bIsValid As Boolean = True
        Dim sSQL As String = ""

        UpdateUpkeep = False

        Try
            sSQL = "INSERT INTO UpkeepTx            (Starhub            ,Starhub_No            ,M1            ,M5            ,M18            ,M28            ,M1_No            ,Singtel5,Singtel10,Singtel20,Singtel50,Singtel16,Singtel15,Singtel28,Singtel300,Singtel180,Singtel888,Singtel102,Singtel1015,Singtel118,Singtel1315,Singtel119,Singtel2504,Singtel120 ,TotalAmount            ,Singtel_No            ,UpkeepTX_Date            ,UpkeepTX_Update)      VALUES            (@Starhub            ,@Starhub_No            ,@M1            ,@M5            ,@M18            ,@M28            ,@M1_No            ,@Singtel5,@Singtel10,@Singtel20,@Singtel50,@Singtel16,@Singtel15,@Singtel28,@Singtel300,@Singtel180,@Singtel888,@Singtel102,@Singtel1015,@Singtel118,@Singtel1315,@Singtel119,@Singtel2504,@Singtel120,@TotalAmount            ,@Singtel_No            ,@UpkeepTX_Date            ,@UpkeepTX_Update)"

            oConn = New SqlConnection()
            oConn.ConnectionString =
            ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

            oCmd = New SqlCommand
            oCmd.CommandText = sSQL
            oCmd.Connection = oConn
            oCmd.Connection.Open()

            oCmd.Parameters.Clear()
            oCmd.Parameters.Add(New SqlParameter("@Starhub",txtStarhubO.Text))
      oCmd.Parameters.Add(New SqlParameter("@Starhub_No",txtStarhub_No.Text))
      oCmd.Parameters.Add(New SqlParameter("@M1",txtM1O.Text))
      oCmd.Parameters.Add(New SqlParameter("@M5",txtM5O.Text))
      oCmd.Parameters.Add(New SqlParameter("@M18",txtM18O.Text))
      oCmd.Parameters.Add(New SqlParameter("@M28",txtM28O.Text))
      oCmd.Parameters.Add(New SqlParameter("@M1_No",txtM1_No.Text))
     oCmd.Parameters.Add(New SqlParameter("@Singtel5",txtSingtel5.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel10",txtSingtel10.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel20",txtSingtel20.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel50",txtSingtel50.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel16",txtSingtel16.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel15",txtSingtel15.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel28",txtSingtel28.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel300",txtSingtel300.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel180",txtSingtel180.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel888",txtSingtel888.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel102",txtSingtel102.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel1015",txtSingtel1015.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel118",txtSingtel118.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel1315",txtSingtel1315.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel119",txtSingtel119.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel2504",txtSingtel2504.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel120",txtSingtel120.Text))
      oCmd.Parameters.Add(New SqlParameter("@TotalAmount",CalculateTotal()))
      oCmd.Parameters.Add(New SqlParameter("@Singtel_No",txtSingtel_No.Text))
                 oCmd.Parameters.Add(New SqlParameter("@UpkeepTX_Date", Date.ParseExact(txtOpeningDate.Text, "dd/MM/yyyy", 
            System.Globalization.DateTimeFormatInfo.InvariantInfo)))
    
      oCmd.Parameters.Add(New SqlParameter("@UpkeepTX_Update",DateTime.Now))
          

            oCmd.ExecuteNonQuery()
            UpdateUpkeep = True
            lblErrorMsg.Text="Record Added"

        Catch ex As Exception
            UpdateUpkeep = False
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
     Private Function UpdatePhoneUpkeepStarhub() As Boolean

        Dim oConn As New SqlConnection
        Dim oCmd As New SqlCommand
        Dim bIsValid As Boolean = True
        Dim sSQL As String = ""

        UpdatePhoneUpkeepStarhub = False
        If(txtStarhub_No.Text.Length>3) Then

      
        Try
            sSQL = "UPDATE UpkeepPhone    SET Starhub = Starhub+@Starhub       ,M1 = M1+@M1       ,M5 = M5+@M5       ,M18 = M18+@M18       ,M28 = M28+@M28       ,Singtel5=Singtel5+@Singtel5,Singtel10=Singtel10+@Singtel10,Singtel20=Singtel20+@Singtel20,Singtel50=Singtel50+@Singtel50,Singtel16=Singtel16+@Singtel16,Singtel15=Singtel15+@Singtel15,Singtel28=Singtel28+@Singtel28,Singtel300=Singtel300+@Singtel300,Singtel180=Singtel180+@Singtel180,Singtel888=Singtel888+@Singtel888,Singtel102=Singtel102+@Singtel102,Singtel1015=Singtel1015+@Singtel1015,Singtel118=Singtel118+@Singtel118,Singtel1315=Singtel1315+@Singtel1315,Singtel119=Singtel119+@Singtel119,Singtel2504=Singtel2504+@Singtel2504,Singtel120=Singtel120+@Singtel120 ,Carrier = @Carrier  WHERE  Phone_Number = @Phone_Number"

            oConn = New SqlConnection()
            oConn.ConnectionString =
            ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

            oCmd = New SqlCommand
            oCmd.CommandText = sSQL
            oCmd.Connection = oConn
            oCmd.Connection.Open()

            oCmd.Parameters.Clear()
            oCmd.Parameters.Add(New SqlParameter("@Starhub",txtStarhubO.Text))
      oCmd.Parameters.Add(New SqlParameter("@M1",txtM1O.Text))
      oCmd.Parameters.Add(New SqlParameter("@M5",txtM5O.Text))
      oCmd.Parameters.Add(New SqlParameter("@M18",txtM18O.Text))
      oCmd.Parameters.Add(New SqlParameter("@M28",txtM28O.Text))
     oCmd.Parameters.Add(New SqlParameter("@Singtel5",txtSingtel5.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel10",txtSingtel10.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel20",txtSingtel20.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel50",txtSingtel50.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel16",txtSingtel16.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel15",txtSingtel15.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel28",txtSingtel28.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel300",txtSingtel300.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel180",txtSingtel180.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel888",txtSingtel888.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel102",txtSingtel102.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel1015",txtSingtel1015.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel118",txtSingtel118.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel1315",txtSingtel1315.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel119",txtSingtel119.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel2504",txtSingtel2504.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel120",txtSingtel120.Text))
                 oCmd.Parameters.Add(New SqlParameter("@Carrier","Starhub"))
                  oCmd.Parameters.Add(New SqlParameter("@Phone_Number",txtStarhub_No.Text))
            oCmd.ExecuteNonQuery()
            UpdatePhoneUpkeepStarhub = True
            lblErrorMsg.Text="Record Added"

        Catch ex As Exception
            UpdatePhoneUpkeepStarhub = False
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
              End If
    End Function
       Private Function UpdatePhoneUpkeepM1() As Boolean

        Dim oConn As New SqlConnection
        Dim oCmd As New SqlCommand
        Dim bIsValid As Boolean = True
        Dim sSQL As String = ""

        UpdatePhoneUpkeepM1 = False
        If(txtM1_No.Text.Length>3) Then

      
        Try
             sSQL = "UPDATE UpkeepPhone    SET Starhub = Starhub+@Starhub       ,M1 = M1+@M1       ,M5 = M5+@M5       ,M18 = M18+@M18       ,M28 = M28+@M28       ,Singtel5=Singtel5+@Singtel5,Singtel10=Singtel10+@Singtel10,Singtel20=Singtel20+@Singtel20,Singtel50=Singtel50+@Singtel50,Singtel16=Singtel16+@Singtel16,Singtel15=Singtel15+@Singtel15,Singtel28=Singtel28+@Singtel28,Singtel300=Singtel300+@Singtel300,Singtel180=Singtel180+@Singtel180,Singtel888=Singtel888+@Singtel888,Singtel102=Singtel102+@Singtel102,Singtel1015=Singtel1015+@Singtel1015,Singtel118=Singtel118+@Singtel118,Singtel1315=Singtel1315+@Singtel1315,Singtel119=Singtel119+@Singtel119,Singtel2504=Singtel2504+@Singtel2504,Singtel120=Singtel120+@Singtel120 ,Carrier = @Carrier  WHERE  Phone_Number = @Phone_Number"

            oConn = New SqlConnection()
            oConn.ConnectionString =
            ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

            oCmd = New SqlCommand
            oCmd.CommandText = sSQL
            oCmd.Connection = oConn
            oCmd.Connection.Open()

            oCmd.Parameters.Clear()
            oCmd.Parameters.Add(New SqlParameter("@Starhub",txtStarhubO.Text))
      oCmd.Parameters.Add(New SqlParameter("@M1",txtM1O.Text))
      oCmd.Parameters.Add(New SqlParameter("@M5",txtM5O.Text))
      oCmd.Parameters.Add(New SqlParameter("@M18",txtM18O.Text))
      oCmd.Parameters.Add(New SqlParameter("@M28",txtM28O.Text))
      oCmd.Parameters.Add(New SqlParameter("@Singtel5",txtSingtel5.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel10",txtSingtel10.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel20",txtSingtel20.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel50",txtSingtel50.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel16",txtSingtel16.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel15",txtSingtel15.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel28",txtSingtel28.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel300",txtSingtel300.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel180",txtSingtel180.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel888",txtSingtel888.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel102",txtSingtel102.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel1015",txtSingtel1015.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel118",txtSingtel118.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel1315",txtSingtel1315.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel119",txtSingtel119.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel2504",txtSingtel2504.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel120",txtSingtel120.Text))
                 oCmd.Parameters.Add(New SqlParameter("@Carrier","M1"))
                  oCmd.Parameters.Add(New SqlParameter("@Phone_Number",txtM1_No.Text))
            oCmd.ExecuteNonQuery()
            UpdatePhoneUpkeepM1 = True
            lblErrorMsg.Text="Record Added"

        Catch ex As Exception
            UpdatePhoneUpkeepM1 = False
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
              End If
    End Function

     Private Function UpdatePhoneUpkeepSingtel() As Boolean

        Dim oConn As New SqlConnection
        Dim oCmd As New SqlCommand
        Dim bIsValid As Boolean = True
        Dim sSQL As String = ""

        UpdatePhoneUpkeepSingtel = False
        If(txtSingtel_No.Text.Length>3) Then

      
        Try
             sSQL = "UPDATE UpkeepPhone    SET Starhub = Starhub+@Starhub       ,M1 = M1+@M1       ,M5 = M5+@M5       ,M18 = M18+@M18       ,M28 = M28+@M28       ,Singtel5=Singtel5+@Singtel5,Singtel10=Singtel10+@Singtel10,Singtel20=Singtel20+@Singtel20,Singtel50=Singtel50+@Singtel50,Singtel16=Singtel16+@Singtel16,Singtel15=Singtel15+@Singtel15,Singtel28=Singtel28+@Singtel28,Singtel300=Singtel300+@Singtel300,Singtel180=Singtel180+@Singtel180,Singtel888=Singtel888+@Singtel888,Singtel102=Singtel102+@Singtel102,Singtel1015=Singtel1015+@Singtel1015,Singtel118=Singtel118+@Singtel118,Singtel1315=Singtel1315+@Singtel1315,Singtel119=Singtel119+@Singtel119,Singtel2504=Singtel2504+@Singtel2504,Singtel120=Singtel120+@Singtel120 ,Carrier = @Carrier  WHERE  Phone_Number = @Phone_Number"

            oConn = New SqlConnection()
            oConn.ConnectionString =
            ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

            oCmd = New SqlCommand
            oCmd.CommandText = sSQL
            oCmd.Connection = oConn
            oCmd.Connection.Open()

            oCmd.Parameters.Clear()
            oCmd.Parameters.Add(New SqlParameter("@Starhub",txtStarhubO.Text))
      oCmd.Parameters.Add(New SqlParameter("@M1",txtM1O.Text))
      oCmd.Parameters.Add(New SqlParameter("@M5",txtM5O.Text))
      oCmd.Parameters.Add(New SqlParameter("@M18",txtM18O.Text))
      oCmd.Parameters.Add(New SqlParameter("@M28",txtM28O.Text))
     oCmd.Parameters.Add(New SqlParameter("@Singtel5",txtSingtel5.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel10",txtSingtel10.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel20",txtSingtel20.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel50",txtSingtel50.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel16",txtSingtel16.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel15",txtSingtel15.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel28",txtSingtel28.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel300",txtSingtel300.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel180",txtSingtel180.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel888",txtSingtel888.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel102",txtSingtel102.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel1015",txtSingtel1015.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel118",txtSingtel118.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel1315",txtSingtel1315.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel119",txtSingtel119.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel2504",txtSingtel2504.Text))
                oCmd.Parameters.Add(New SqlParameter("@Singtel120",txtSingtel120.Text))
                 oCmd.Parameters.Add(New SqlParameter("@Carrier","Singtel"))
                  oCmd.Parameters.Add(New SqlParameter("@Phone_Number",txtSingtel_No.Text))
            oCmd.ExecuteNonQuery()
            UpdatePhoneUpkeepSingtel = True
            lblErrorMsg.Text="Record Added"

        Catch ex As Exception
            UpdatePhoneUpkeepSingtel = False
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
              End If
    End Function
    Private Function CalculateTotal()As Double
        Dim total As Double=0
        total += txtStarhubO.Text
        total += txtM1O.Text
        total += (txtM5O.Text*5.0)
      total += (txtM18O.Text*18.0)
        total += (txtM28o.Text*28.0)
     			total += (txtSingtel5.Text*5.0)
                total += (txtSingtel10.Text*10.0)
                total += (txtSingtel20.Text*20.0)
                total += (txtSingtel50.Text*50.0)
                total += (txtSingtel16.Text*16.0)
                total += (txtSingtel15.Text*15.0)
                total += (txtSingtel28.Text*28.0)
                total += (txtSingtel300.Text*300.0)
                total += (txtSingtel180.Text*180.0)
                total += (txtSingtel888.Text*888.0)
                total += (txtSingtel102.Text*102.0)
                total += (txtSingtel1015.Text*1015.0)
                total += (txtSingtel118.Text*118.0)
                total += (txtSingtel1315.Text*1315.0)
                total += (txtSingtel119.Text*119.0)
                total += (txtSingtel2504.Text*2504.0)
                total += (txtSingtel120.Text*120.0)
        Return total
    End Function
End Class