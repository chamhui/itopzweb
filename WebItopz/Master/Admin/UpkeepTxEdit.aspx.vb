Imports System.Data.SqlClient
Imports System.Globalization

Partial Class UpkeepTxEdit
    Inherits System.Web.UI.Page
    Private msNewUpkeepID As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("AGENT_ID") = "" Then
            'Response.Redirect("~/Master/Login.aspx")
        End If
        If IsPostBack = False Then
            LoadUpkeedByID()
        End If
    End Sub
    Private Sub LoadUpkeedByID()
        Dim oConn As New SqlConnection
        Dim oCmd As New SqlCommand
        Dim oDR As SqlDataReader
        Dim bIsValid As Boolean = True
        Dim sSQL As String = ""
        Dim UpkeepTx_ID As Integer = 0
        UpkeepTx_ID = Request.QueryString("UpkeepTx_ID")

        Try
            sSQL = "SELECT * from UpkeepTx where UpkeepTx_ID =" + UpkeepTx_ID.ToString()

            oConn = New SqlConnection()
            oConn.ConnectionString = _
            ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

            oCmd = New SqlCommand
            oCmd.CommandText = sSQL
            oCmd.Connection = oConn
            oCmd.Connection.Open()
            oCmd.Parameters.Clear()

            oDR = oCmd.ExecuteReader

            If oDR.HasRows Then
                oDR.Read()
                dim OpeningDate As DateTime  = oDR.Item("UpkeepTX_Date")
                txtOpeningDate.Text= OpeningDate.ToString("dd/MM/yyyy")
                txtStarhubO.Text = oDR.Item("Starhub")
                txtM1O.Text = oDR.Item("M1")
                txtM5O.Text = oDR.Item("M5")
                txtM18O.Text = oDR.Item("M18")
                txtM28O.Text = oDR.Item("M28")
                txtSingtel5.Text = oDR.Item("Singtel5")
                txtSingtel10.Text = oDR.Item("Singtel10")
                txtSingtel20.Text = oDR.Item("Singtel20")
                txtSingtel50.Text = oDR.Item("Singtel50")
                txtSingtel16.Text = oDR.Item("Singtel16")
                txtSingtel15.Text = oDR.Item("Singtel15")
                txtSingtel28.Text = oDR.Item("Singtel28")
                txtSingtel300.Text = oDR.Item("Singtel300")
                txtSingtel180.Text = oDR.Item("Singtel180")
                txtSingtel888.Text = oDR.Item("Singtel888")
                txtSingtel102.Text = oDR.Item("Singtel102")
                txtSingtel1015.Text = oDR.Item("Singtel1015")
                txtSingtel118.Text = oDR.Item("Singtel118")
                txtSingtel1315.Text = oDR.Item("Singtel1315")
                txtSingtel119.Text = oDR.Item("Singtel119")
                txtSingtel2504.Text = oDR.Item("Singtel2504")
                txtSingtel120.Text = oDR.Item("Singtel120")
                txtStarhub_No.Text = oDR.Item("Starhub_No")
                   txtM1_No.Text = oDR.Item("M1_No")
                 txtSingtel_No.Text = oDR.Item("Singtel_No")
                'dim CurrentDate As DateTime  = oDR.Item("ClosingDate")
              
                'txtSingtel10o = oDR.Item("M28Opening")
            End If

        Catch ex As Exception

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
        MinusPrevious()
         UpdateUpkeep("") 
         UpdatePhone()
        'If GetPreviousCurrent() Then

        ' If InsertNewUpkeep(Me.txtStarhub.Text, Me.txtM1.Text, Me.txtM2.Text, Me.txtSing1.Text, Me.txtSing2.Text, Me.txtSing3.Text) Then
        '    Me.btnSubmit.Enabled = False
        '    Me.lblErrorMsg.Text = "Added Successfully!"
        'End If
        'End If


    End Sub
    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Session("AGENT_ID") = "" Then
            'Response.Redirect("~/Master/Login.aspx")
        End If
        Dim sAgentID As String = ""
        
        Dim oConn As New SqlConnection
        Dim oCmd As New SqlCommand
        Dim bIsValid As Boolean = True
        Dim sSQL As String = ""

        

        Try
            sSQL = "DELETE FROM UpkeepTx  WHERE UpkeepTx_ID = @UpkeepTx_ID"

            oConn = New SqlConnection()
            oConn.ConnectionString =
            ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

            oCmd = New SqlCommand
            oCmd.CommandText = sSQL
            oCmd.Connection = oConn
            oCmd.Connection.Open()

            oCmd.Parameters.Clear()
        
             dim UpkeepTx_ID As Integer= Request.QueryString("UpkeepTx_ID")
                oCmd.Parameters.Add(New SqlParameter("@UpkeepTx_ID", UpkeepTx_ID))

            oCmd.ExecuteNonQuery()
           Response.Redirect("UpkeepTx2.aspx")

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
    'Private Function GetPreviousCurrent() As Boolean
    '    Dim oConn As New SqlConnection
    '    Dim oCmd As New SqlCommand
    '    Dim bIsValid As Boolean = True
    '    Dim sSQL As String = ""

    '    GetPreviousCurrent = False

    '    Try
    '        sSQL = "SELECT StarhubCurrent, M1Current, M2Current, SingtelP1Current, SingtelP2Current, SingtelP3Current FROM Upkeep WHERE"
    '    Catch ex As Exception

    '    End Try
    'End Function
  
    Private Function UpdateUpkeep(byval status As string) As Boolean

        Dim oConn As New SqlConnection
        Dim oCmd As New SqlCommand
        Dim bIsValid As Boolean = True
        Dim sSQL As String = ""

        UpdateUpkeep = False

        Try
            sSQL = "UPDATE UpkeepTx    SET Starhub = @Starhub       ,Starhub_No = @Starhub_No       ,M1 = @M1       ,M5 = @M5       ,M18 = @M18       ,M28 = @M28       ,M1_No = @M1_No       				,Singtel5=@Singtel5                 ,Singtel10=@Singtel10                 ,Singtel20=@Singtel20                 ,Singtel50=@Singtel50                 ,Singtel16=@Singtel16                 ,Singtel15=@Singtel15                 ,Singtel28=@Singtel28                 ,Singtel300=@Singtel300                 ,Singtel180=@Singtel180                 ,Singtel888=@Singtel888                 ,Singtel102=@Singtel102                 ,Singtel1015=@Singtel1015                 ,Singtel118=@Singtel118                 ,Singtel1315=@Singtel1315                 ,Singtel119=@Singtel119                 ,Singtel2504=@Singtel2504                 ,Singtel120=@Singtel120   ,TotalAmount = @TotalAmount       ,Singtel_No = @Singtel_No       ,UpkeepTX_Date = @UpkeepTX_Date       ,UpkeepTX_Update = @UpkeepTX_Update  WHERE UpkeepTx_ID = @UpkeepTx_ID"

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
             dim UpkeepTx_ID As Integer= Request.QueryString("UpkeepTx_ID")
                oCmd.Parameters.Add(New SqlParameter("@UpkeepTx_ID", UpkeepTx_ID))

            oCmd.ExecuteNonQuery()
            UpdateUpkeep = True
             lblErrorMsg.Text="Record Updated"

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
        Private Function UpdatePhone() As Boolean

          Dim oConn As New SqlConnection
        Dim oCmd As New SqlCommand
        Dim oDR As SqlDataReader
        Dim bIsValid As Boolean = True
        Dim sSQL As String = ""
        Dim UpkeepTx_ID As Integer = 0
        UpkeepTx_ID = Request.QueryString("UpkeepTx_ID")
        Dim starhub As Double
        dim M1O as double 
dim M5O as double 
dim M18O as double 
dim M28O as double 
dim Singtel5 as double
 dim Singtel10 as double   
 dim Singtel20 as double   
 dim Singtel50 as double   
 dim Singtel16 as double   
 dim Singtel15 as double   
 dim Singtel28 as double    
 dim Singtel300 as double    
 dim Singtel180 as double    
 dim Singtel888 as double    
dim Singtel102 as double    
dim Singtel1015 as double    
dim Singtel118 as double    
dim Singtel1315 as double    
dim Singtel119 as double    
dim Singtel2504 as double    
dim Singtel120 as double
     Dim   Starhub_No as string=""
        Dim           M1_No  as string=""
           Dim      Singtel_No  as string=""
        Try
            sSQL = "SELECT * from UpkeepTx where UpkeepTx_ID =" + UpkeepTx_ID.ToString()

            oConn = New SqlConnection()
            oConn.ConnectionString = _
            ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

            oCmd = New SqlCommand
            oCmd.CommandText = sSQL
            oCmd.Connection = oConn
            oCmd.Connection.Open()
            oCmd.Parameters.Clear()

            oDR = oCmd.ExecuteReader

            If oDR.HasRows Then
                oDR.Read()
                dim OpeningDate As DateTime  = oDR.Item("UpkeepTX_Date")
                'txtOpeningDate.Text= OpeningDate.ToString("dd/MM/yyyy")
                starhub = oDR.Item("Starhub")
                M1O = oDR.Item("M1")
                M5O = oDR.Item("M5")
                M18O = oDR.Item("M18")
                M28O = oDR.Item("M28")
                Singtel5 = oDR.Item("Singtel5")
                Singtel10 = oDR.Item("Singtel10")
                Singtel20 = oDR.Item("Singtel20")
                Singtel50 = oDR.Item("Singtel50")
                Singtel16 = oDR.Item("Singtel16")
                Singtel15 = oDR.Item("Singtel15")
                Singtel28 = oDR.Item("Singtel28")
                Singtel300 = oDR.Item("Singtel300")
                Singtel180 = oDR.Item("Singtel180")
                Singtel888 = oDR.Item("Singtel888")
                Singtel102 = oDR.Item("Singtel102")
                Singtel1015 = oDR.Item("Singtel1015")
                Singtel118 = oDR.Item("Singtel118")
                Singtel1315 = oDR.Item("Singtel1315")
                Singtel119 = oDR.Item("Singtel119")
                Singtel2504 = oDR.Item("Singtel2504")
                Singtel120 = oDR.Item("Singtel120")
                Starhub_No = oDR.Item("Starhub_No")
                   M1_No = oDR.Item("M1_No")
                 Singtel_No = oDR.Item("Singtel_No")
                'dim CurrentDate As DateTime  = oDR.Item("ClosingDate")
              
                'txtSingtel10o = oDR.Item("M28Opening")
            End If
            UpdatePhoneUpkeepStarhub( Starhub, M1O,  M5O,  M18O,  M28O,  Singtel5   ,  Singtel10   ,  Singtel20   ,  Singtel50   ,  Singtel16   ,  Singtel15   ,  Singtel28   ,  Singtel300   ,  Singtel180   ,  Singtel888   ,  Singtel102   ,  Singtel1015   ,  Singtel118   ,  Singtel1315   ,  Singtel119   ,  Singtel2504   ,  Singtel120    ,  Starhub_No) 
 UpdatePhoneUpkeepM1( Starhub, M1O,  M5O,  M18O,  M28O,  Singtel5   ,  Singtel10   ,  Singtel20   ,  Singtel50   ,  Singtel16   ,  Singtel15   ,  Singtel28   ,  Singtel300   ,  Singtel180   ,  Singtel888   ,  Singtel102   ,  Singtel1015   ,  Singtel118   ,  Singtel1315   ,  Singtel119   ,  Singtel2504   ,  Singtel120    ,  M1_No) 
 UpdatePhoneUpkeepSingtel( Starhub, M1O,  M5O,  M18O,  M28O,  Singtel5   ,  Singtel10   ,  Singtel20   ,  Singtel50   ,  Singtel16   ,  Singtel15   ,  Singtel28   ,  Singtel300   ,  Singtel180   ,  Singtel888   ,  Singtel102   ,  Singtel1015   ,  Singtel118   ,  Singtel1315   ,  Singtel119   ,  Singtel2504   ,  Singtel120    ,  Singtel_No) 

        Catch ex As Exception

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
     Private Function MinusPrevious() As Boolean

          Dim oConn As New SqlConnection
        Dim oCmd As New SqlCommand
        Dim oDR As SqlDataReader
        Dim bIsValid As Boolean = True
        Dim sSQL As String = ""
        Dim UpkeepTx_ID As Integer = 0
        UpkeepTx_ID = Request.QueryString("UpkeepTx_ID")
        Dim starhub As Double=0
        dim M1O as Double = 0 
dim M5O as Double = 0 
dim M18O as Double = 0 
dim M28O as Double = 0 
dim Singtel5 as Double = 0
 dim Singtel10 as Double = 0   
 dim Singtel20 as Double = 0   
 dim Singtel50 as Double = 0   
 dim Singtel16 as Double = 0   
 dim Singtel15 as Double = 0   
 dim Singtel28 as Double = 0    
 dim Singtel300 as Double = 0    
 dim Singtel180 as Double = 0    
 dim Singtel888 as Double = 0    
dim Singtel102 as Double = 0    
dim Singtel1015 as Double = 0    
dim Singtel118 as Double = 0    
dim Singtel1315 as Double = 0    
dim Singtel119 as Double = 0    
dim Singtel2504 as Double = 0    
dim Singtel120 as Double = 0
     Dim   Starhub_No as string=""
        Dim           M1_No  as string=""
           Dim      Singtel_No  as string=""
        Try
            sSQL = "SELECT * from UpkeepTx where UpkeepTx_ID =" + UpkeepTx_ID.ToString()

            oConn = New SqlConnection()
            oConn.ConnectionString = _
            ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

            oCmd = New SqlCommand
            oCmd.CommandText = sSQL
            oCmd.Connection = oConn
            oCmd.Connection.Open()
            oCmd.Parameters.Clear()

            oDR = oCmd.ExecuteReader

            If oDR.HasRows Then
                oDR.Read()
                dim OpeningDate As DateTime  = oDR.Item("UpkeepTX_Date")
                'txtOpeningDate.Text= OpeningDate.ToString("dd/MM/yyyy")
                starhub =0- oDR.Item("Starhub")
                M1O = 0 - oDR.Item("M1")
                M5O = 0 - oDR.Item("M5")
                M18O = 0 - oDR.Item("M18")
                M28O = 0 - oDR.Item("M28")
                Singtel5 = 0 - oDR.Item("Singtel5")
                Singtel10 = 0 - oDR.Item("Singtel10")
                Singtel20 = 0 - oDR.Item("Singtel20")
                Singtel50 = 0 - oDR.Item("Singtel50")
                Singtel16 = 0 - oDR.Item("Singtel16")
                Singtel15 = 0 - oDR.Item("Singtel15")
                Singtel28 = 0 - oDR.Item("Singtel28")
                Singtel300 = 0 - oDR.Item("Singtel300")
                Singtel180 = 0 - oDR.Item("Singtel180")
                Singtel888 = 0 - oDR.Item("Singtel888")
                Singtel102 = 0 - oDR.Item("Singtel102")
                Singtel1015 = 0 - oDR.Item("Singtel1015")
                Singtel118 = 0 - oDR.Item("Singtel118")
                Singtel1315 = 0 - oDR.Item("Singtel1315")
                Singtel119 = 0 - oDR.Item("Singtel119")
                Singtel2504 = 0 - oDR.Item("Singtel2504")
                Singtel120 = 0 - oDR.Item("Singtel120")
                Starhub_No = oDR.Item("Starhub_No")
                   M1_No = oDR.Item("M1_No")
                 Singtel_No = oDR.Item("Singtel_No")
                'dim CurrentDate As DateTime  = oDR.Item("ClosingDate")
              
                'txtSingtel10o = oDR.Item("M28Opening")
            End If
            UpdatePhoneUpkeepStarhub( Starhub, 0,  0,  0,  0,  0   ,  0   ,  0   ,  0   ,  0   ,  0   ,  0   ,  0   ,  0   ,  0   ,  0   ,  0   ,  0   ,  0   ,  0   ,  0   ,  0    ,  Starhub_No) 
 UpdatePhoneUpkeepM1( 0, M1O,  M5O,  M18O,  M28O,  0   ,  0   ,  0   ,  0   ,  0   ,  0   ,  0   ,  0   ,  0   ,  0   ,  0   ,  0   ,  0   ,  0   ,  0   ,  0   ,  0    ,  M1_No) 
 UpdatePhoneUpkeepSingtel( 0, 0,  0,  0,  0,  Singtel5   ,  Singtel10   ,  Singtel20   ,  Singtel50   ,  Singtel16   ,  Singtel15   ,  Singtel28   ,  Singtel300   ,  Singtel180   ,  Singtel888   ,  Singtel102   ,  Singtel1015   ,  Singtel118   ,  Singtel1315   ,  Singtel119   ,  Singtel2504   ,  Singtel120    ,  Singtel_No) 
 'UpdatePhoneUpkeepSingtel( Starhub, M1O,  M5O,  M18O,  M28O,  Singtel5   ,  Singtel10   ,  Singtel20   ,  Singtel50   ,  Singtel16   ,  Singtel15   ,  Singtel28   ,  Singtel300   ,  Singtel180   ,  Singtel888   ,  Singtel102   ,  Singtel1015   ,  Singtel118   ,  Singtel1315   ,  Singtel119   ,  Singtel2504   ,  Singtel120    ,  Singtel_No) 

        Catch ex As Exception

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
     Private Function UpdatePhoneUpkeepStarhub(Byval Starhub as double,Byval M1O as double, Byval M5O as double, Byval M18O as double, Byval M28O as double, Byval Singtel5 as double   , Byval Singtel10 as double   , Byval Singtel20 as double   , Byval Singtel50 as double   , Byval Singtel16 as double   , Byval Singtel15 as double   , Byval Singtel28 as double   , Byval Singtel300 as double   , Byval Singtel180 as double   , Byval Singtel888 as double   , Byval Singtel102 as double   , Byval Singtel1015 as double   , Byval Singtel118 as double   , Byval Singtel1315 as double   , Byval Singtel119 as double   , Byval Singtel2504 as double   , Byval Singtel120 as double    , Byval Starhub_No as string) As Boolean

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
                   oCmd.Parameters.Add(New SqlParameter("@Starhub",Starhub))
    oCmd.Parameters.Add(New SqlParameter("@M1",M1O))
      oCmd.Parameters.Add(New SqlParameter("@M5",M5O))
      oCmd.Parameters.Add(New SqlParameter("@M18",M18O))
      oCmd.Parameters.Add(New SqlParameter("@M28",M28O))
      oCmd.Parameters.Add(New SqlParameter("@Singtel5",Singtel5))
                oCmd.Parameters.Add(New SqlParameter("@Singtel10",Singtel10))
                oCmd.Parameters.Add(New SqlParameter("@Singtel20",Singtel20))
                oCmd.Parameters.Add(New SqlParameter("@Singtel50",Singtel50))
                oCmd.Parameters.Add(New SqlParameter("@Singtel16",Singtel16))
                oCmd.Parameters.Add(New SqlParameter("@Singtel15",Singtel15))
                oCmd.Parameters.Add(New SqlParameter("@Singtel28",Singtel28))
                oCmd.Parameters.Add(New SqlParameter("@Singtel300",Singtel300))
                oCmd.Parameters.Add(New SqlParameter("@Singtel180",Singtel180))
                oCmd.Parameters.Add(New SqlParameter("@Singtel888",Singtel888))
                oCmd.Parameters.Add(New SqlParameter("@Singtel102",Singtel102))
                oCmd.Parameters.Add(New SqlParameter("@Singtel1015",Singtel1015))
                oCmd.Parameters.Add(New SqlParameter("@Singtel118",Singtel118))
                oCmd.Parameters.Add(New SqlParameter("@Singtel1315",Singtel1315))
                oCmd.Parameters.Add(New SqlParameter("@Singtel119",Singtel119))
                oCmd.Parameters.Add(New SqlParameter("@Singtel2504",Singtel2504))
                oCmd.Parameters.Add(New SqlParameter("@Singtel120",Singtel120))
                 oCmd.Parameters.Add(New SqlParameter("@Carrier","Starhub"))
                  oCmd.Parameters.Add(New SqlParameter("@Phone_Number",Starhub_No))
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
       Private Function UpdatePhoneUpkeepM1(Byval Starhub as double,Byval M1O as double, Byval M5O as double, Byval M18O as double, Byval M28O as double, Byval Singtel5 as double   , Byval Singtel10 as double   , Byval Singtel20 as double   , Byval Singtel50 as double   , Byval Singtel16 as double   , Byval Singtel15 as double   , Byval Singtel28 as double   , Byval Singtel300 as double   , Byval Singtel180 as double   , Byval Singtel888 as double   , Byval Singtel102 as double   , Byval Singtel1015 as double   , Byval Singtel118 as double   , Byval Singtel1315 as double   , Byval Singtel119 as double   , Byval Singtel2504 as double   , Byval Singtel120 as double, ByVal M1_No As String ) As Boolean

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
            oCmd.Parameters.Add(New SqlParameter("@Starhub",Starhub))
    oCmd.Parameters.Add(New SqlParameter("@M1",M1O))
      oCmd.Parameters.Add(New SqlParameter("@M5",M5O))
      oCmd.Parameters.Add(New SqlParameter("@M18",M18O))
      oCmd.Parameters.Add(New SqlParameter("@M28",M28O))
      oCmd.Parameters.Add(New SqlParameter("@Singtel5",Singtel5))
                oCmd.Parameters.Add(New SqlParameter("@Singtel10",Singtel10))
                oCmd.Parameters.Add(New SqlParameter("@Singtel20",Singtel20))
                oCmd.Parameters.Add(New SqlParameter("@Singtel50",Singtel50))
                oCmd.Parameters.Add(New SqlParameter("@Singtel16",Singtel16))
                oCmd.Parameters.Add(New SqlParameter("@Singtel15",Singtel15))
                oCmd.Parameters.Add(New SqlParameter("@Singtel28",Singtel28))
                oCmd.Parameters.Add(New SqlParameter("@Singtel300",Singtel300))
                oCmd.Parameters.Add(New SqlParameter("@Singtel180",Singtel180))
                oCmd.Parameters.Add(New SqlParameter("@Singtel888",Singtel888))
                oCmd.Parameters.Add(New SqlParameter("@Singtel102",Singtel102))
                oCmd.Parameters.Add(New SqlParameter("@Singtel1015",Singtel1015))
                oCmd.Parameters.Add(New SqlParameter("@Singtel118",Singtel118))
                oCmd.Parameters.Add(New SqlParameter("@Singtel1315",Singtel1315))
                oCmd.Parameters.Add(New SqlParameter("@Singtel119",Singtel119))
                oCmd.Parameters.Add(New SqlParameter("@Singtel2504",Singtel2504))
                oCmd.Parameters.Add(New SqlParameter("@Singtel120",Singtel120))
                 oCmd.Parameters.Add(New SqlParameter("@Carrier","M1"))
                  oCmd.Parameters.Add(New SqlParameter("@Phone_Number",M1_No))
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

     Private Function UpdatePhoneUpkeepSingtel(Byval Starhub as double,Byval M1O as double, Byval M5O as double, Byval M18O as double, Byval M28O as double, Byval Singtel5 as double   , Byval Singtel10 as double   , Byval Singtel20 as double   , Byval Singtel50 as double   , Byval Singtel16 as double   , Byval Singtel15 as double   , Byval Singtel28 as double   , Byval Singtel300 as double   , Byval Singtel180 as double   , Byval Singtel888 as double   , Byval Singtel102 as double   , Byval Singtel1015 as double   , Byval Singtel118 as double   , Byval Singtel1315 as double   , Byval Singtel119 as double   , Byval Singtel2504 as double   , Byval Singtel120 as double    , Byval Singtel_No as string) As Boolean

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
                     oCmd.Parameters.Add(New SqlParameter("@Starhub",Starhub))
    oCmd.Parameters.Add(New SqlParameter("@M1",M1O))
      oCmd.Parameters.Add(New SqlParameter("@M5",M5O))
      oCmd.Parameters.Add(New SqlParameter("@M18",M18O))
      oCmd.Parameters.Add(New SqlParameter("@M28",M28O))
      oCmd.Parameters.Add(New SqlParameter("@Singtel5",Singtel5))
                oCmd.Parameters.Add(New SqlParameter("@Singtel10",Singtel10))
                oCmd.Parameters.Add(New SqlParameter("@Singtel20",Singtel20))
                oCmd.Parameters.Add(New SqlParameter("@Singtel50",Singtel50))
                oCmd.Parameters.Add(New SqlParameter("@Singtel16",Singtel16))
                oCmd.Parameters.Add(New SqlParameter("@Singtel15",Singtel15))
                oCmd.Parameters.Add(New SqlParameter("@Singtel28",Singtel28))
                oCmd.Parameters.Add(New SqlParameter("@Singtel300",Singtel300))
                oCmd.Parameters.Add(New SqlParameter("@Singtel180",Singtel180))
                oCmd.Parameters.Add(New SqlParameter("@Singtel888",Singtel888))
                oCmd.Parameters.Add(New SqlParameter("@Singtel102",Singtel102))
                oCmd.Parameters.Add(New SqlParameter("@Singtel1015",Singtel1015))
                oCmd.Parameters.Add(New SqlParameter("@Singtel118",Singtel118))
                oCmd.Parameters.Add(New SqlParameter("@Singtel1315",Singtel1315))
                oCmd.Parameters.Add(New SqlParameter("@Singtel119",Singtel119))
                oCmd.Parameters.Add(New SqlParameter("@Singtel2504",Singtel2504))
                oCmd.Parameters.Add(New SqlParameter("@Singtel120",Singtel120))
                 oCmd.Parameters.Add(New SqlParameter("@Carrier","Singtel"))
                  oCmd.Parameters.Add(New SqlParameter("@Phone_Number",Singtel_No))
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