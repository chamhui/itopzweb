Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports System.Data
Imports System.Data.OleDb
Imports System
Imports System.Security.Cryptography
Public Class encryptpassword
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		resetpassword()
	End Sub

	Private Sub resetpassword()

		Dim sSQL As String = ""
		Dim oConn As New SqlConnection(ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString)
		Dim oCmd As New SqlCommand
		Dim oDR As SqlDataReader = Nothing
		Dim sAgentID As String
		Dim sName As String = ""
		'isValidLogin = False
		Dim lagent As New List(Of Agent)

		Try
			'Response.Write(sLogin)
			'Response.Write(sPassword)
			oConn.Open()
			oCmd = oConn.CreateCommand
			oCmd.Connection = oConn
			sSQL = "SELECT * from AgentMSISDN where len(Password)<50"
			oCmd.CommandText = sSQL

			oDR = oCmd.ExecuteReader
			While oDR.Read
				Dim tempa As New Agent
				tempa.ID = oDR.Item("ID")
				tempa.Password = oDR.Item("Password")
				lagent.Add(tempa)
			End While


		Catch ex As Exception
			'isValidLogin = False
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

		For Each tagent As Agent In lagent
			oConn = New SqlConnection(ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString)
			sSQL = "UPDATE AgentMSISDN SET Password = @PASSWORD WHERE ID = @ID;"


			oConn.Open()
			oCmd = New SqlCommand
			oCmd.CommandText = sSQL
			oCmd.Connection = oConn


			oCmd.Parameters.Clear()
			oCmd.Parameters.Add(New SqlParameter("@ID", tagent.ID))
			oCmd.Parameters.Add(New SqlParameter("@PASSWORD", ComputeSha256Hash(tagent.Password)))
			oCmd.ExecuteNonQuery()
			oCmd.Connection.Close()

		Next


	End Sub
	Private Shared Function ComputeSha256Hash(ByVal rawData As String) As String
		Using sha256Hash As SHA256 = SHA256.Create()
			Dim bytes As Byte() = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData))
			Dim builder As StringBuilder = New StringBuilder()

			For i As Integer = 0 To bytes.Length - 1
				builder.Append(bytes(i).ToString("x2"))
			Next

			Return builder.ToString()
		End Using
	End Function

	Public Class Agent
		Private _password As String
		Private _ID As Integer

		Public Property ID() As Integer
			Get
				Return _ID
			End Get
			Set(ByVal value As Integer)
				_ID = value
			End Set
		End Property


		Public Property Password() As String
			Get
				Return _password
			End Get
			Set(ByVal value As String)
				_password = value
			End Set
		End Property
	End Class
End Class