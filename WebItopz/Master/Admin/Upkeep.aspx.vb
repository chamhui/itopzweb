Imports System.Data.SqlClient
Imports System.Globalization

Partial Class Upkeep
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
        Dim UpKeepID As Integer = 0
        UpKeepID = Request.QueryString("upkeepid")

        Try
            sSQL = "SELECT * from Upkeep where upkeepid =" + UpKeepID.ToString()

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
                dim OpeningDate As DateTime  = oDR.Item("OpeningDate")
                txtOpeningDate.Text= OpeningDate.ToString("dd/MM/yyyy")
                txtStarhubO.Text = oDR.Item("StarhubOpening")
                txtM1O.Text = oDR.Item("M1Opening")
                txtM5O.Text = oDR.Item("M5Opening")
                txtM18O.Text = oDR.Item("M18Opening")
                txtM28O.Text = oDR.Item("M28Opening")
                txtSingtel5o.Text = oDR.Item("Singtel5Opening")
                txtSingtel8o.Text = oDR.Item("Singtel8Opening")
                txtSingtel10o.Text = oDR.Item("Singtel10Opening")
                txtSingtel15o.Text = oDR.Item("Singtel15Opening")
                txtSingtel18o.Text = oDR.Item("Singtel18Opening")
                txtSingtel20o.Text = oDR.Item("Singtel20Opening")
                txtSingtel22o.Text = oDR.Item("Singtel22Opening")
                txtSingtel28o.Text = oDR.Item("Singtel28Opening")
                txtSingtel30o.Text = oDR.Item("Singtel30Opening")
                txtSingtel50o.Text = oDR.Item("Singtel50Opening")

                dim CurrentDate As DateTime  = oDR.Item("ClosingDate")
                If(oDR.Item("ClosingDate")=oDR.Item("OpeningDate")) Then
                     txtCurrentDate.Text= ""
                Else
                     txtCurrentDate.Text= CurrentDate.ToString("dd/MM/yyyy")
                End If
               
                txtStarhubc.Text = oDR.Item("StarhubCurrent")
                txtM1c.Text = oDR.Item("M1Current")
                txtM5c.Text = oDR.Item("M5Current")
                txtM18c.Text = oDR.Item("M18Current")
                txtM28c.Text = oDR.Item("M28Current")
                txtSingtel5c.Text = oDR.Item("Singtel5Current")
                txtSingtel8c.Text = oDR.Item("Singtel8Current")
                txtSingtel10c.Text = oDR.Item("Singtel10Current")
                txtSingtel15c.Text = oDR.Item("Singtel15Current")
                txtSingtel18c.Text = oDR.Item("Singtel18Current")
                txtSingtel20c.Text = oDR.Item("Singtel20Current")
                txtSingtel22c.Text = oDR.Item("Singtel22Current")
                txtSingtel28c.Text = oDR.Item("Singtel28Current")
                txtSingtel30c.Text = oDR.Item("Singtel30Current")
                txtSingtel50c.Text = oDR.Item("Singtel50Current")

                lblstatus.Text= oDR.Item("Status")
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
      Protected Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
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

         UpdateUpkeep("Close") 
        InsertNewUpkeep("Open")
        
    End sub
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

         UpdateUpkeep(lblstatus.Text) 
        
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
    Private Function InsertNewUpkeep(byval status As String) As Boolean

        Dim oConn As New SqlConnection
        Dim oCmd As New SqlCommand
        Dim bIsValid As Boolean = True
        Dim sSQL As String = ""

        InsertNewUpkeep = False

        Try
            sSQL = "INSERT INTO Upkeep            (StarhubOpening            ,M1Opening            ,M5Opening            ,M18Opening            ,M28Opening            ,OpeningDate            ,StarhubCurrent            ,M1Current            ,M5Current            ,M18Current            ,M28Current            ,SingtelCurrent            ,ClosingDate            ,Status            ,Singtel5Opening            ,Singtel8Opening            ,Singtel10Opening            ,Singtel15Opening            ,Singtel18Opening            ,Singtel20Opening            ,Singtel22Opening            ,Singtel28Opening            ,Singtel30Opening            ,Singtel50Opening            ,Singtel5Current            ,Singtel8Current            ,Singtel10Current            ,Singtel15Current            ,Singtel18Current            ,Singtel20Current            ,Singtel22Current            ,Singtel28Current            ,Singtel30Current            ,Singtel50Current)      VALUES 	 (@StarhubOpening            ,@M1Opening            ,@M5Opening            ,@M18Opening            ,@M28Opening            ,@OpeningDate            ,@StarhubCurrent            ,@M1Current            ,@M5Current            ,@M18Current            ,@M28Current            ,@SingtelCurrent            ,@ClosingDate            ,@Status            ,@Singtel5Opening            ,@Singtel8Opening            ,@Singtel10Opening            ,@Singtel15Opening            ,@Singtel18Opening            ,@Singtel20Opening            ,@Singtel22Opening            ,@Singtel28Opening            ,@Singtel30Opening            ,@Singtel50Opening            ,@Singtel5Current            ,@Singtel8Current            ,@Singtel10Current            ,@Singtel15Current            ,@Singtel18Current            ,@Singtel20Current            ,@Singtel22Current            ,@Singtel28Current            ,@Singtel30Current            ,@Singtel50Current)"

            oConn = New SqlConnection()
            oConn.ConnectionString =
            ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

            oCmd = New SqlCommand
            oCmd.CommandText = sSQL
            oCmd.Connection = oConn
            oCmd.Connection.Open()

            oCmd.Parameters.Clear()
           		oCmd.Parameters.Add(New SqlParameter("@StarhubOpening", txtStarhubc.Text))
           oCmd.Parameters.Add(New SqlParameter("@M1Opening", txtM1c.Text))
           oCmd.Parameters.Add(New SqlParameter("@M5Opening", txtM5c.Text))
           oCmd.Parameters.Add(New SqlParameter("@M18Opening", txtM18c.Text))
           oCmd.Parameters.Add(New SqlParameter("@M28Opening", txtM28c.Text))
           oCmd.Parameters.Add(New SqlParameter("@OpeningDate", Date.ParseExact(txtCurrentDate.Text, "dd/MM/yyyy", 
            System.Globalization.DateTimeFormatInfo.InvariantInfo)))
           oCmd.Parameters.Add(New SqlParameter("@StarhubCurrent", txtStarhubc.Text))
           oCmd.Parameters.Add(New SqlParameter("@M1Current", txtM1c.Text))
           oCmd.Parameters.Add(New SqlParameter("@M5Current", txtm5c.Text))
           oCmd.Parameters.Add(New SqlParameter("@M18Current", txtm18c.Text))
           oCmd.Parameters.Add(New SqlParameter("@M28Current", txtm28c.Text))
           oCmd.Parameters.Add(New SqlParameter("@SingtelCurrent", 0))
            
           oCmd.Parameters.Add(New SqlParameter("@ClosingDate", Date.ParseExact(txtCurrentDate.Text, "dd/MM/yyyy", 
            System.Globalization.DateTimeFormatInfo.InvariantInfo)))
           oCmd.Parameters.Add(New SqlParameter("@Status", status))
           oCmd.Parameters.Add(New SqlParameter("@Singtel5Opening", txtSingtel50c.Text))
           oCmd.Parameters.Add(New SqlParameter("@Singtel8Opening", txtsingtel8c.Text))
           oCmd.Parameters.Add(New SqlParameter("@Singtel10Opening", txtSingtel10c.Text))
           oCmd.Parameters.Add(New SqlParameter("@Singtel15Opening", txtSingtel15c.Text))
           oCmd.Parameters.Add(New SqlParameter("@Singtel18Opening", txtSingtel18c.Text))
           oCmd.Parameters.Add(New SqlParameter("@Singtel20Opening", txtSingtel20c.Text))
           oCmd.Parameters.Add(New SqlParameter("@Singtel22Opening", txtSingtel22c.Text))
           oCmd.Parameters.Add(New SqlParameter("@Singtel28Opening", txtSingtel28c.Text))
           oCmd.Parameters.Add(New SqlParameter("@Singtel30Opening", txtSingtel30c.Text))
           oCmd.Parameters.Add(New SqlParameter("@Singtel50Opening", txtSingtel50c.Text))
           oCmd.Parameters.Add(New SqlParameter("@Singtel5Current", txtSingtel5c.Text))
           oCmd.Parameters.Add(New SqlParameter("@Singtel8Current", txtSingtel8c.Text))
           oCmd.Parameters.Add(New SqlParameter("@Singtel10Current", txtSingtel10c.Text))
           oCmd.Parameters.Add(New SqlParameter("@Singtel15Current", txtSingtel15c.Text))
           oCmd.Parameters.Add(New SqlParameter("@Singtel18Current", txtSingtel18c.Text))
           oCmd.Parameters.Add(New SqlParameter("@Singtel20Current", txtSingtel20c.Text))
           oCmd.Parameters.Add(New SqlParameter("@Singtel22Current", txtSingtel22c.Text))
           oCmd.Parameters.Add(New SqlParameter("@Singtel28Current", txtSingtel28c.Text))
           oCmd.Parameters.Add(New SqlParameter("@Singtel30Current", txtSingtel30c.Text))
           oCmd.Parameters.Add(New SqlParameter("@Singtel50Current", txtSingtel50c.Text))

             'dim UpKeepID As Integer= Request.QueryString("upkeepid")
             '   oCmd.Parameters.Add(New SqlParameter("@UpkeepID", UpKeepID))

            oCmd.ExecuteNonQuery()
            InsertNewUpkeep = True


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
    Private Function UpdateUpkeep(byval status As string) As Boolean

        Dim oConn As New SqlConnection
        Dim oCmd As New SqlCommand
        Dim bIsValid As Boolean = True
        Dim sSQL As String = ""

        UpdateUpkeep = False

        Try
            sSQL = "UPDATE Upkeep    SET StarhubOpening = @StarhubOpening       ,M1Opening = @M1Opening       ,M5Opening = @M5Opening       ,M18Opening = @M18Opening       ,M28Opening = @M28Opening       ,OpeningDate = @OpeningDate       ,StarhubCurrent = @StarhubCurrent       ,M1Current = @M1Current       ,M5Current = @M5Current       ,M18Current = @M18Current       ,M28Current = @M28Current       ,SingtelCurrent = @SingtelCurrent       ,ClosingDate = @ClosingDate       ,Status = @Status       ,Singtel5Opening = @Singtel5Opening       ,Singtel8Opening = @Singtel8Opening       ,Singtel10Opening = @Singtel10Opening       ,Singtel15Opening = @Singtel15Opening       ,Singtel18Opening = @Singtel18Opening       ,Singtel20Opening = @Singtel20Opening       ,Singtel22Opening = @Singtel22Opening       ,Singtel28Opening = @Singtel28Opening       ,Singtel30Opening = @Singtel30Opening       ,Singtel50Opening = @Singtel50Opening       ,Singtel5Current = @Singtel5Current       ,Singtel8Current = @Singtel8Current       ,Singtel10Current = @Singtel10Current       ,Singtel15Current = @Singtel15Current       ,Singtel18Current = @Singtel18Current       ,Singtel20Current = @Singtel20Current       ,Singtel22Current = @Singtel22Current       ,Singtel28Current = @Singtel28Current       ,Singtel30Current = @Singtel30Current       ,Singtel50Current = @Singtel50Current  WHERE UpkeepID=@UpkeepID"

            oConn = New SqlConnection()
            oConn.ConnectionString =
            ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

            oCmd = New SqlCommand
            oCmd.CommandText = sSQL
            oCmd.Connection = oConn
            oCmd.Connection.Open()

            oCmd.Parameters.Clear()
           		oCmd.Parameters.Add(New SqlParameter("@StarhubOpening", txtStarhubO.Text))
           oCmd.Parameters.Add(New SqlParameter("@M1Opening", txtM1O.Text))
           oCmd.Parameters.Add(New SqlParameter("@M5Opening", txtM5O.Text))
           oCmd.Parameters.Add(New SqlParameter("@M18Opening", txtM18O.Text))
           oCmd.Parameters.Add(New SqlParameter("@M28Opening", txtM28O.Text))
           oCmd.Parameters.Add(New SqlParameter("@OpeningDate", Date.ParseExact(txtOpeningDate.Text, "dd/MM/yyyy", 
            System.Globalization.DateTimeFormatInfo.InvariantInfo)))
           oCmd.Parameters.Add(New SqlParameter("@StarhubCurrent", txtStarhubc.Text))
           oCmd.Parameters.Add(New SqlParameter("@M1Current", txtM1c.Text))
           oCmd.Parameters.Add(New SqlParameter("@M5Current", txtm5c.Text))
           oCmd.Parameters.Add(New SqlParameter("@M18Current", txtm18c.Text))
           oCmd.Parameters.Add(New SqlParameter("@M28Current", txtm28c.Text))
           oCmd.Parameters.Add(New SqlParameter("@SingtelCurrent", 0))
            If(status.ToUpper="OPEN")Then
                 oCmd.Parameters.Add(New SqlParameter("@ClosingDate", Date.ParseExact(txtOpeningDate.Text, "dd/MM/yyyy", 
            System.Globalization.DateTimeFormatInfo.InvariantInfo)))
            Else
                   oCmd.Parameters.Add(New SqlParameter("@ClosingDate", Date.ParseExact(txtCurrentDate.Text, "dd/MM/yyyy", 
            System.Globalization.DateTimeFormatInfo.InvariantInfo)))
            End If
          
           oCmd.Parameters.Add(New SqlParameter("@Status", status))
           oCmd.Parameters.Add(New SqlParameter("@Singtel5Opening", txtSingtel50o.Text))
           oCmd.Parameters.Add(New SqlParameter("@Singtel8Opening", txtsingtel8o.Text))
           oCmd.Parameters.Add(New SqlParameter("@Singtel10Opening", txtSingtel10o.Text))
           oCmd.Parameters.Add(New SqlParameter("@Singtel15Opening", txtSingtel15o.Text))
           oCmd.Parameters.Add(New SqlParameter("@Singtel18Opening", txtSingtel18o.Text))
           oCmd.Parameters.Add(New SqlParameter("@Singtel20Opening", txtSingtel20o.Text))
           oCmd.Parameters.Add(New SqlParameter("@Singtel22Opening", txtSingtel22o.Text))
           oCmd.Parameters.Add(New SqlParameter("@Singtel28Opening", txtSingtel28o.Text))
           oCmd.Parameters.Add(New SqlParameter("@Singtel30Opening", txtSingtel30o.Text))
           oCmd.Parameters.Add(New SqlParameter("@Singtel50Opening", txtSingtel50o.Text))
           oCmd.Parameters.Add(New SqlParameter("@Singtel5Current", txtSingtel5c.Text))
           oCmd.Parameters.Add(New SqlParameter("@Singtel8Current", txtSingtel8c.Text))
           oCmd.Parameters.Add(New SqlParameter("@Singtel10Current", txtSingtel10c.Text))
           oCmd.Parameters.Add(New SqlParameter("@Singtel15Current", txtSingtel15c.Text))
           oCmd.Parameters.Add(New SqlParameter("@Singtel18Current", txtSingtel18c.Text))
           oCmd.Parameters.Add(New SqlParameter("@Singtel20Current", txtSingtel20c.Text))
           oCmd.Parameters.Add(New SqlParameter("@Singtel22Current", txtSingtel22c.Text))
           oCmd.Parameters.Add(New SqlParameter("@Singtel28Current", txtSingtel28c.Text))
           oCmd.Parameters.Add(New SqlParameter("@Singtel30Current", txtSingtel30c.Text))
           oCmd.Parameters.Add(New SqlParameter("@Singtel50Current", txtSingtel50c.Text))

             dim UpKeepID As Integer= Request.QueryString("upkeepid")
                oCmd.Parameters.Add(New SqlParameter("@UpkeepID", UpKeepID))

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
End Class