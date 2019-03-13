Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports System.Data
Imports System.Data.OleDb
Imports System
Imports System.Security.Cryptography

Public Class AdminChangePassword
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("AGENT_ID") = "" Then
            Response.Redirect("~/Master/Login.aspx")
        End If
        Dim sessionId As String = System.Web.HttpContext.Current.Session("AGENT_MSISDN")

    End Sub

    Private Function ValidPassword(ByVal sPassword As String) As Boolean

        Dim sSQL As String = ""
        Dim oConn As New SqlConnection(ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString)
        Dim oCmd As New SqlCommand
        Dim oDR As SqlDataReader = Nothing
        'Dim sAgentID As String
        'Dim sName As String = ""
        ValidPassword = False

        Try
            'Response.Write(sLogin)
            'Response.Write(sPassword)
            oConn.Open()
            oCmd = oConn.CreateCommand
            oCmd.Connection = oConn
            sSQL = "SELECT * FROM SuperAdmin WHERE MSISDN=@MSISDN AND PASSWORD=@PASSWORD"
            oCmd.CommandText = sSQL

            With oCmd.Parameters
                .Clear()
                .AddWithValue("@MSISDN", System.Web.HttpContext.Current.Session("AGENT_MSISDN"))
                .AddWithValue("@PASSWORD", base64Encode(sPassword))
            End With
            oDR = oCmd.ExecuteReader
            If oDR.Read Then
                ValidPassword = True
            End If
            oConn.Close()

        Catch ex As Exception
            ValidPassword = False
            Response.Write("getMaxPostRobinq [" & ex.Message & "]" & ex.StackTrace)
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

    End Function





    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If ValidPassword(password.Text) Then
            If Not new_password.Text = Nothing And Not confirm_password.Text = Nothing Then

                If new_password.Text.Length < 8 Then
                    lblErrorMsg.Text = "Invalid New Password, min 8 character"
                ElseIf confirm_password.Text.Length < 8 Then
                    lblErrorMsg.Text = "Confirm Password, min 8 character"
                ElseIf Not new_password.Text = confirm_password.Text Then
                    lblErrorMsg.Text = "Password Confirm Not Match"
                Else
                    ChangePassword(new_password.Text)
                End If
            Else
                lblErrorMsg.Text = "New or Confirm Password Not Insert"
            End If
        ElseIf password.Text.Length < 8 Then
            lblErrorMsg.Text = "Invalid Login Password, min 8 character"
        Else
            lblErrorMsg.Text = "Wrong Password"
        End If
    End Sub

    Private Function ChangePassword(ByVal new_password As String) As Boolean
        Dim oConn As New SqlConnection
        Dim oCmd As New SqlCommand
        Dim bIsValid As Boolean = True
        Dim sSQL As String = ""

        ChangePassword = False

        Try
            sSQL = "UPDATE SuperAdmin SET Password = @PASSWORD WHERE MSISDN = @SUPER_ADMIN_SESSION;"

            oConn = New SqlConnection()
            oConn.ConnectionString =
            ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString

            oCmd = New SqlCommand
            oCmd.CommandText = sSQL
            oCmd.Connection = oConn
            oCmd.Connection.Open()

            oCmd.Parameters.Clear()
            oCmd.Parameters.Add(New SqlParameter("@SUPER_ADMIN_SESSION", System.Web.HttpContext.Current.Session("AGENT_MSISDN")))
            oCmd.Parameters.Add(New SqlParameter("@PASSWORD", base64Encode(new_password)))
            oCmd.ExecuteNonQuery()
            ChangePassword = True
            lblSuccessMsg.Text = "Password Change Success"
            lblErrorMsg.Visible = False


        Catch ex As Exception
            ChangePassword = False
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

    Public Function base64Encode(sData As String) As String
        Try
            Dim encData_byte As Byte() = New Byte(sData.Length - 1) {}

            encData_byte = System.Text.Encoding.UTF8.GetBytes(sData)

            Dim encodedData As String = Convert.ToBase64String(encData_byte)


            Return encodedData
        Catch ex As Exception
            Throw New Exception("Error in base64Encode" + ex.Message)
        End Try
    End Function

    Public Function base64Decode(sData As String) As String

        Dim encoder As New System.Text.UTF8Encoding()

        Dim utf8Decode As System.Text.Decoder = encoder.GetDecoder()

        Dim todecode_byte As Byte() = Convert.FromBase64String(sData)

        Dim charCount As Integer = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length)

        Dim decoded_char As Char() = New Char(charCount - 1) {}

        utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0)

        Dim result As String = New [String](decoded_char)

        Return result

    End Function
End Class