Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports System.Data
Imports System.Data.OleDb
Imports System
Public Class WebForm3
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FillGridView()

    End Sub
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
            rptrUpkeep.DataSource = dtbl
            rptrUpkeep.DataBind()







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
        Response.Redirect("~/Master/Admin/Upkeep2.aspx")
    End Sub
End Class