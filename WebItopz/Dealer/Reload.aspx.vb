Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration.ConfigurationManager
Imports System.Threading.Thread

Partial Class Reload
    Inherits System.Web.UI.Page

    Private Const STATUS_ACTIVE = "ACTIVE"
    'Private msMaxRobinDiGi As Integer = 1
    'Private msMaxRobinCelcom As Integer = 1
    'Private msMaxRobinMaxis As Integer = 1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("DEALER_ID") = "" Then
            Server.Transfer("~/login.aspx")
        End If

        Me.lblErrorMsg.Text = ""
        Me.lblReloadMSISDN.Text = ""
        Me.lblReloadAmount.Text = ""
        Me.lblReloadTelco.Text = ""

        If Not Page.IsPostBack Then
            getNote("SINGTEL")
            getNote("SINGTEL")
        End If

    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click

        Me.btnEdit.Text = "Edit"
        If Me.txtReloadMSISDN.Text = "" Or Me.txtReloadMSISDN.Text.Length <> 8 Then
            Me.lblErrorMsg.Text = "Invalid Mobile Number!"
        Else
            Me.btnSubmit.Visible = False
            Me.txtReloadMSISDN.Enabled = False
            Me.DDLReloadAmount.Enabled = False
            Me.btnConfirm.Visible = True
            Me.btnEdit.Visible = True
            Me.lblReloadMSISDN.Text = txtReloadMSISDN.Text & ""
            Me.lblReloadAmount.Text = "SGD" & DDLReloadAmount.Text
            Me.lblReloadTelco.Text = Me.DDLTelco.SelectedValue
            Me.DDLTelco.Enabled = False
        End If



    End Sub


    Private Function InsertIntoTxIn(ByVal sMSISDN As String, ByVal sMOMsg As String, ByVal sMOTS As String) As Boolean

        Dim sSQL As String = ""
        Dim oCmd As SqlCommand = Nothing
        Dim oConn As New SqlConnection(ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString)
        Dim aMOMsg() As String
        Dim sAgentPin As String = ""
        Dim sReloadAmount As Integer
        Dim sReloadMSISDN As String = ""
        Dim sReloadTelco As String = ""
        Dim sReloadType As String = "WEB"
        Dim bValid As Boolean = True
        Dim sAgentId As String = ""
        Dim sErrorCode As String = ""
        Dim sStatus As String = "INVALID"
        Dim sLocalMOID As String = Format(Now, "yyyyMMddHHmmss") & Now.Millisecond.ToString.PadLeft(3, "0")
        Dim iNewBalance As Decimal
        Dim iRobin As Integer
        Dim dCommission As Decimal = 0
        Dim sProductID As String = ""

        Try
            oConn.Open()
            oCmd = oConn.CreateCommand
            oCmd.Connection = oConn

            aMOMsg = sMOMsg.Split(" ")


            If UBound(aMOMsg) = 1 Then
                sReloadAmount = aMOMsg(1)
                sReloadMSISDN = aMOMsg(0)
                sReloadTelco = Me.DDLTelco.SelectedValue  'GetPrefix("6" & sReloadMSISDN)
                If Not IsNumeric(sReloadAmount) Then bValid = False
                If Not IsNumeric(sReloadMSISDN) Then bValid = False
                If sReloadMSISDN.Length <> "8" Then bValid = False
                If sReloadTelco = "" Then bValid = False
            Else
                bValid = False
            End If

            sAgentId = Session("DEALER_ID") 'getAgentID(sAgentPin, sMSISDN, oConn)

            If sAgentId = "" Then
                bValid = False
                sErrorCode = "Invalid_AgentPinOrMSISDNOrInactiveStatus"
            End If

            'Response.Write(sReloadMSISDN & "<BR>")
            'Response.Write(sReloadAmount & "<BR>")
            'Response.Write(sReloadTelco & "<BR>")

            If CheckLastReloadTS(sReloadMSISDN, sReloadAmount, sReloadTelco, oConn) Then
                bValid = False
                sErrorCode = "Duplication Reload Submitted"
            End If

            sProductID = getProductID(sReloadTelco)

            If bValid Then
                If deductBalance(sAgentId, sReloadAmount, sReloadTelco, sProductID, iNewBalance, oConn) Then
                    InsertTxReload(sLocalMOID, sAgentId, sReloadMSISDN, sReloadAmount, sReloadTelco, iNewBalance, oConn)
                    sStatus = "PENDING"
                Else
                    sErrorCode = "Insufficient_Balance"
                End If
            End If

            iRobin = getPostRobin(sReloadTelco)
            dCommission = getCommission(sAgentId, sReloadTelco, sReloadAmount, sProductID, oConn)

            sSQL = "INSERT INTO TxIn (LocalMOID, MSISDN, AgentID, MessageIn, MessageTS, ReloadMSISDN, ReloadAmount, ReloadTelco,ReloadType, Robin, Status, ErrorCode,Commission) " & _
                    "VALUES (@LocalMOID, @MSISDN, @AgentID, @MessageIn, @MessageTS, @ReloadMSISDN, @ReloadAmount, @ReloadTelco, @ReloadType, @Robin,@Status, @ErrorCode,@Commission) "

            oCmd.CommandText = sSQL
            With oCmd.Parameters
                .Clear()
                .AddWithValue("@LocalMOID", sLocalMOID)
                .AddWithValue("@MSISDN", sMSISDN)
                .AddWithValue("@AgentID", sAgentId)
                .AddWithValue("@MessageIn", sMOMsg)
                .AddWithValue("@MessageTS", sMOTS)
                .AddWithValue("@ReloadMSISDN", sReloadMSISDN)
                .AddWithValue("@ReloadAmount", sReloadAmount)
                .AddWithValue("@ReloadTelco", sReloadTelco)
                .AddWithValue("@ReloadType", sReloadType)
                .AddWithValue("@Robin", iRobin)
                .AddWithValue("@Status", sStatus)
                .AddWithValue("@ErrorCode", sErrorCode)
                .AddWithValue("@Commission", dCommission)
            End With
            oCmd.ExecuteNonQuery()

            If sErrorCode <> "" Then
                Me.lblErrorMsg.Text = sErrorCode
                Me.txtReloadMSISDN.Enabled = True
                Me.DDLReloadAmount.Enabled = True
                Me.btnConfirm.Visible = False
                Me.btnConfirm.Enabled = True
                Me.btnEdit.Visible = False
                Me.btnSubmit.Visible = True
                Me.DDLTelco.Enabled = True
            Else
                'Me.DDLReloadAmount.Text = ""
                Me.txtReloadMSISDN.Text = ""
            End If

            If bValid Then
                Me.lblErrorMsg.Text = "Press NEW to Continue"
            End If

        Catch ex As Exception
            Response.Write("InsertIntoTxIn [" & ex.Message & "]" & ex.StackTrace)
        Finally
            If (Not oCmd Is Nothing) Then
                oCmd.Dispose()
                oCmd = Nothing
            End If
        
        End Try

    End Function

    Private Function getAgentID(ByVal sMSISDN As String, ByVal oConn As SqlConnection) As String

        Dim sSQL As String = ""
        ' Dim oConn As New SqlConnection(gsDBConnString)
        Dim oCmd As New SqlCommand
        Dim oDR As SqlDataReader = Nothing
        Dim sAgentID As String = ""

        Try

            'oConn.Open()
            oCmd = oConn.CreateCommand
            oCmd.Connection = oConn
            sSQL = "SELECT AgentID FROM AgentMSISDN WHERE MSISDN=@MSISDN and STATUS=@STATUS and PASSWORD=@PIN "

            oCmd.CommandText = sSQL
            With oCmd.Parameters
                .Clear()
                .AddWithValue("@STATUS", STATUS_ACTIVE)
                .AddWithValue("@MSISDN", sMSISDN)
            End With
            oDR = oCmd.ExecuteReader

            If oDR.HasRows Then
                oDR.Read()
                sAgentID = oDR.Item("AgentID")
            End If
            oDR.Close()
            'oConn.Close()

            getAgentID = sAgentID

        Catch ex As Exception
            getAgentID = ""
            Response.Write("deductBalance [" & ex.Message & "]")
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

    Private Function deductBalance(ByVal sAgentId As String, ByVal sReloadAmount As Integer, ByVal sReloadTelco As String, ByVal sProductID As String, ByRef iNewBalance As Decimal, ByVal oConn As SqlConnection) As Boolean

        Dim sSQL As String = ""
        Dim sSQLUpdate As String = ""
        Dim oCmd As New SqlCommand
        Dim oCmdUpdate As New SqlCommand
        Dim oDR As SqlDataReader = Nothing
        Dim iBalance As Decimal
        Dim iDiscount As Decimal
        'Dim oConn As New SqlConnection(gsDBConnString)
        Dim oConnUpdate As New SqlConnection(ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString)

        deductBalance = True

        Try
            'oConn.Open()
            oCmd = oConn.CreateCommand
            oCmd.Connection = oConn
            sSQL = "SELECT     dbo.AgentBalance.Balance, dbo.AgentProduct.Discount " & _
                   "FROM         dbo.AgentBalance INNER JOIN " & _
                   "dbo.AgentProduct ON dbo.AgentBalance.AgentID = dbo.AgentProduct.AgentID " & _
                   "WHERE     (dbo.AgentProduct.AgentID = @AgentID) AND (dbo.AgentProduct.ProductID = @ProductID) and dbo.AgentBalance.Balance>=@ReloadAmount "
            'sSQL = "SELECT Discount, b.Balance as Balance FROM AgentInfo a, AgentBalance b WHERE a.AgentID=@AgentID and a.AgentID = b.AgentID and b.balance>=@ReloadAmount "


            oCmd.CommandText = sSQL
            With oCmd.Parameters
                .Clear()
                .AddWithValue("@AgentID", sAgentId)
                .AddWithValue("@ReloadAmount", sReloadAmount)
                .AddWithValue("@ProductID", sProductID)
            End With
            oDR = oCmd.ExecuteReader

            If oDR.HasRows Then
                oDR.Read()
                iDiscount = oDR.Item("Discount")
                iBalance = oDR.Item("Balance")

                iNewBalance = iBalance - (sReloadAmount - (sReloadAmount * (iDiscount / 100)))

                'goLog.DebugLog("iDiscount", iDiscount)
                'goLog.DebugLog("iBalance", iBalance)
                'goLog.DebugLog("sReloadAmount", sReloadAmount)
                'goLog.DebugLog("iNewBalance", iNewBalance)

                sSQLUpdate = "UPDATE AgentBALANCE SET  Balance=@NewBalance WHERE AgentID=@AgentID"

                oConnUpdate.Open()
                oCmdUpdate = oConnUpdate.CreateCommand
                oCmdUpdate.Connection = oConnUpdate
                oCmdUpdate.CommandText = sSQLUpdate
                With oCmdUpdate.Parameters
                    .Clear()
                    .AddWithValue("@AgentID", sAgentId)
                    .AddWithValue("@NewBalance", iNewBalance)
                End With
                oCmdUpdate.ExecuteNonQuery()
                oConnUpdate.Close()
            Else
                deductBalance = False
            End If

        Catch ex As Exception
            deductBalance = False
            'goLog.ErrorLog(ProcessorId & "~deductBalance", ex.Message & ex.StackTrace)
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


    'Private Function deductBalance(ByVal sAgentId As String, ByVal sReloadAmount As Integer, ByVal sReloadTelco As String, ByRef iNewBalance As Decimal, ByVal oConn As SqlConnection) As Boolean

    '    Dim sSQL As String = ""
    '    Dim sSQLUpdate As String = ""
    '    Dim oCmd As New SqlCommand
    '    Dim oCmdUpdate As New SqlCommand
    '    Dim oDR As SqlDataReader = Nothing
    '    Dim iBalance As Decimal
    '    Dim iDiscount As Decimal 
    '    Dim oConnUpdate As New SqlConnection(ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString)

    '    deductBalance = True

    '    Try
    '        'oConn.Open()
    '        oCmd = oConn.CreateCommand
    '        oCmd.Connection = oConn
    '        'If sReloadTelco = "MAXIS" Then
    '        '    'sSQL = "SELECT MAXISBalance as Balance FROM AgentBALANCE WHERE AgentID=@AgentID and MAXISBalance>=@ReloadAmount "
    '        '    sSQL = "SELECT  a.DiscountMaxis  as Discount, b.Balance as Balance FROM AgentInfo a, AgentBalance b WHERE a.AgentID=@AgentID and a.AgentID = b.AgentID and b.balance>=@ReloadAmount "
    '        'ElseIf sReloadTelco = "DIGI" Then
    '        '    'sSQL = "SELECT DIGIBalance as Balance FROM AgentBALANCE WHERE AgentID=@AgentID and DIGIBalance>=@ReloadAmount "
    '        '    sSQL = "SELECT  a.DiscountDiGi  as Discount, b.Balance as Balance FROM AgentInfo a, AgentBalance b WHERE a.AgentID=@AgentID and a.AgentID = b.AgentID and b.balance>=@ReloadAmount "
    '        'ElseIf sReloadTelco = "CELCOM" Then
    '        '    'sSQL = "SELECT CelcomBalance as Balance FROM AgentBALANCE WHERE AgentID=@AgentID and CelcomBalance>=@ReloadAmount "
    '        '    sSQL = "SELECT  a.DiscountCelcom  as Discount, b.Balance as Balance FROM AgentInfo a, AgentBalance b WHERE a.AgentID=@AgentID and a.AgentID = b.AgentID  and b.balance>=@ReloadAmount "
    '        'End If
    '        If sReloadTelco = "MAXIS" Then
    '            sSQL = "SELECT  a.DiscountMaxis  as Discount, b.Balance as Balance FROM AgentInfo a, AgentBalance b WHERE a.AgentID=@AgentID and a.AgentID = b.AgentID and b.balance>=@ReloadAmount "
    '        ElseIf sReloadTelco = "DIGI" Then
    '            sSQL = "SELECT  a.DiscountDiGi  as Discount, b.Balance as Balance FROM AgentInfo a, AgentBalance b WHERE a.AgentID=@AgentID and a.AgentID = b.AgentID and b.balance>=@ReloadAmount "
    '        ElseIf sReloadTelco = "CELCOM" Then
    '            sSQL = "SELECT  a.DiscountCelcom  as Discount, b.Balance as Balance FROM AgentInfo a, AgentBalance b WHERE a.AgentID=@AgentID and a.AgentID = b.AgentID  and b.balance>=@ReloadAmount "
    '        ElseIf sReloadTelco = "UMOBILE" Then
    '            sSQL = "SELECT  a.DiscountUmobile  as Discount, b.Balance as Balance FROM AgentInfo a, AgentBalance b WHERE a.AgentID=@AgentID and a.AgentID = b.AgentID  and b.balance>=@ReloadAmount "
    '        ElseIf sReloadTelco = "MAXISPIN" Then
    '            sSQL = "SELECT  a.DiscountMaxisPin  as Discount, b.Balance as Balance FROM AgentInfo a, AgentBalance b WHERE a.AgentID=@AgentID and a.AgentID = b.AgentID  and b.balance>=@ReloadAmount "
    '        ElseIf sReloadTelco = "DIGIPIN" Then
    '            sSQL = "SELECT  a.DiscountDiGiPin  as Discount, b.Balance as Balance FROM AgentInfo a, AgentBalance b WHERE a.AgentID=@AgentID and a.AgentID = b.AgentID  and b.balance>=@ReloadAmount "
    '        ElseIf sReloadTelco = "CELCOMPIN" Then
    '            sSQL = "SELECT  a.DiscountCelcomPin  as Discount, b.Balance as Balance FROM AgentInfo a, AgentBalance b WHERE a.AgentID=@AgentID and a.AgentID = b.AgentID  and b.balance>=@ReloadAmount "
    '        ElseIf sReloadTelco = "ITALKPIN" Then
    '            sSQL = "SELECT  a.DiscountITALKPin  as Discount, b.Balance as Balance FROM AgentInfo a, AgentBalance b WHERE a.AgentID=@AgentID and a.AgentID = b.AgentID  and b.balance>=@ReloadAmount "
    '        ElseIf sReloadTelco = "UMOBILEPIN" Then
    '            sSQL = "SELECT  a.DiscountUMobilePin  as Discount, b.Balance as Balance FROM AgentInfo a, AgentBalance b WHERE a.AgentID=@AgentID and a.AgentID = b.AgentID  and b.balance>=@ReloadAmount "
    '        ElseIf sReloadTelco = "XOXPIN" Then
    '            sSQL = "SELECT  a.DiscountXOXPin  as Discount, b.Balance as Balance FROM AgentInfo a, AgentBalance b WHERE a.AgentID=@AgentID and a.AgentID = b.AgentID  and b.balance>=@ReloadAmount "
    '        ElseIf sReloadTelco = "TUNETALKPIN" Then
    '            sSQL = "SELECT  a.DiscountTUNETALKPin  as Discount, b.Balance as Balance FROM AgentInfo a, AgentBalance b WHERE a.AgentID=@AgentID and a.AgentID = b.AgentID  and b.balance>=@ReloadAmount "
    '        ElseIf sReloadTelco = "INDOPIN" Then
    '            sSQL = "SELECT  a.DiscountINDOPin  as Discount, b.Balance as Balance FROM AgentInfo a, AgentBalance b WHERE a.AgentID=@AgentID and a.AgentID = b.AgentID  and b.balance>=@ReloadAmount "
    '        End If

    '        oCmd.CommandText = sSQL
    '        With oCmd.Parameters
    '            .Clear()
    '            .AddWithValue("@AgentID", sAgentId)
    '            .AddWithValue("@ReloadAmount", sReloadAmount)
    '        End With
    '        oDR = oCmd.ExecuteReader

    '        If oDR.HasRows Then
    '            oDR.Read()
    '            iDiscount = oDR.Item("Discount")
    '            iBalance = oDR.Item("Balance")

    '            iNewBalance = iBalance - (sReloadAmount - (sReloadAmount * (iDiscount / 100)))


    '            sSQLUpdate = "UPDATE AgentBALANCE SET  Balance=@NewBalance WHERE AgentID=@AgentID"
    '            'If sReloadTelco = "MAXIS" Then
    '            '    sSQLUpdate = "UPDATE AgentBALANCE SET MaxisBalance=@NewBalance WHERE AgentID=@AgentID"
    '            'ElseIf sReloadTelco = "DIGI" Then
    '            '    sSQLUpdate = "UPDATE AgentBALANCE SET DiGiBalance=@NewBalance WHERE AgentID=@AgentID"
    '            'ElseIf sReloadTelco = "CELCOM" Then
    '            '    sSQLUpdate = "UPDATE AgentBALANCE SET CelcomBalance=@NewBalance WHERE AgentID=@AgentID"
    '            'End If
    '            oConnUpdate.Open()
    '            oCmdUpdate = oConnUpdate.CreateCommand
    '            oCmdUpdate.Connection = oConnUpdate
    '            oCmdUpdate.CommandText = sSQLUpdate
    '            With oCmdUpdate.Parameters
    '                .Clear()
    '                .AddWithValue("@AgentID", sAgentId)
    '                .AddWithValue("@NewBalance", iNewBalance)
    '            End With
    '            oCmdUpdate.ExecuteNonQuery()
    '            oConnUpdate.Close()
    '        Else
    '            deductBalance = False
    '        End If

    '        'oConn.Close()


    '    Catch ex As Exception
    '        deductBalance = False
    '        Response.Write("deductBalance [" & ex.Message & "]")
    '    Finally
    '        If (Not oCmd Is Nothing) Then
    '            oCmd.Dispose()
    '            oCmd = Nothing
    '        End If
    '        If (Not oDR Is Nothing) Then
    '            If (Not oDR.IsClosed) Then
    '                oDR.Close()
    '            End If
    '            oDR = Nothing
    '        End If
    '    End Try

    'End Function

  

    Private Function InsertTxReload(ByVal sLocalMOID As String, ByVal sAgentId As String, ByVal sReloadMSISDN As String, ByVal sReloadAmount As Integer, ByVal sReloadTelco As String, ByVal iNewBalance As Decimal, ByVal oConn As SqlConnection) As Boolean

        Dim sSQL As String = ""
        Dim oCmd As SqlCommand = Nothing
        ' Dim oConn As New SqlConnection(gsDBConnString)

        InsertTxReload = True

        Try
            'oConn.Open()
            oCmd = oConn.CreateCommand
            oCmd.Connection = oConn

            sSQL = "INSERT INTO TxReload (LocalMOID, AgentId, ReloadMSISDN, ReloadAmount, ReloadTelco, BalanceAfterReload) " & _
                    "VALUES (@LocalMOID, @AgentId, @ReloadMSISDN, @ReloadAmount, @ReloadTelco, @BalanceAfterReload) "

            oCmd.CommandText = sSQL
            With oCmd.Parameters
                .Clear()
                .AddWithValue("@LocalMOID", sLocalMOID)
                .AddWithValue("@AgentID", sAgentId)
                .AddWithValue("@ReloadMSISDN", sReloadMSISDN)
                .AddWithValue("@ReloadTelco", sReloadTelco)
                .AddWithValue("@ReloadAmount", sReloadAmount)
                .AddWithValue("@BalanceAfterReload", iNewBalance)
            End With
            oCmd.ExecuteNonQuery()
            'oConn.Close()

        Catch ex As Exception
            InsertTxReload = False
            Response.Write("InsertTxReload [" & ex.Message & "]")
        Finally
            If (Not oCmd Is Nothing) Then
                oCmd.Dispose()
                oCmd = Nothing
            End If
            'If (Not oConn Is Nothing) Then
            '    If oConn.State = ConnectionState.Open Then
            '        oConn.Close()
            '    End If
            '    oConn.Dispose()
            '    oConn = Nothing
            'End If
        End Try

    End Function


    Private Function GetPrefix(ByVal sMSISDN As String) As String
        Dim sPrefix As String
        Dim i As Integer = 0
        Dim sTemp() As String
        Dim gaSpecialPrefixLength() As String


        sPrefix = sMSISDN.Substring(0, AppSettings.Item("MinimumTelcoPrefixLength")) 'Left(sMSISDN, giMinimumTelcoPrefixLen)


        gaSpecialPrefixLength = AppSettings.Item("SpecialTelcoPrefixAndLength").Split("|")

        For i = 0 To (gaSpecialPrefixLength.Length - 1)
            sTemp = gaSpecialPrefixLength(i).Split(":")

            If (sPrefix = sTemp(0)) Then
                If (sTemp.Length >= 2) Then
                    sPrefix = sMSISDN.Substring(0, sTemp(1)) 'Left(sMSISDN, sTemp(1))

                End If

                Exit For
            End If
        Next
        sPrefix = AppSettings.Item("PrefixName_" & sPrefix) & ""

        Return sPrefix
    End Function


    Private Function getCommission(ByVal sAgentID As String, ByVal sReloadTelco As String, ByVal sReloadAmount As String, ByVal sProductID As String, ByVal oConn As SqlConnection) As Decimal

        Dim sSQL As String = ""
        Dim sSQLDealer As String = ""
        Dim oCmd As New SqlCommand
        Dim oDR As SqlDataReader = Nothing
        Dim dDiscountDealer As Decimal = 0
        Dim dDiscountAgent As Decimal = 0

        Try

            sSQL = "SELECT Discount as DiscountAgent FROM AgentProduct WHERE AgentID=@AgentID and ProductID=@ProductID"
            sSQLDealer = "SELECT Discount as DiscountDealer FROM AgentProduct where ProductID=@ProductID and agentID=(SELECT ParentAgentID FROM AgentInfo where agentid=@AgentID)"


            oCmd = oConn.CreateCommand
            oCmd.Connection = oConn
            oCmd.CommandText = sSQLDealer
            With oCmd.Parameters
                .Clear()
                .AddWithValue("@AgentID", sAgentID)
                .AddWithValue("@ProductID", sProductID)
            End With
            oDR = oCmd.ExecuteReader
            If oDR.HasRows Then
                oDR.Read()
                dDiscountDealer = oDR.Item("DiscountDealer")
            End If
            oDR.Close()
            oCmd = Nothing


            If dDiscountDealer > 0 Then
                oCmd = oConn.CreateCommand
                oCmd.Connection = oConn
                oCmd.CommandText = sSQL
                With oCmd.Parameters
                    .Clear()
                    .AddWithValue("@AgentID", sAgentID)
                    .AddWithValue("@ProductID", sProductID)
                End With
                oDR = oCmd.ExecuteReader
                If oDR.HasRows Then
                    oDR.Read()
                    dDiscountAgent = oDR.Item("DiscountAgent")
                End If
                oDR.Close()
                oCmd = Nothing
                getCommission = sReloadAmount * ((dDiscountDealer - dDiscountAgent) / 100)

            End If
            'oConn.Close()

        Catch ex As Exception
            getCommission = 0
            'goLog.ErrorLog(ProcessorId & "~getCommission", ex.Message)
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

    Private Function CheckLastReloadTS(ByVal sReloadMSISDN As String, ByVal sReloadAmount As String, ByVal sReloadTelco As String, ByVal oConn As SqlConnection) As Boolean

        Dim sSQL As String = ""
        Dim oCmd As New SqlCommand
        Dim oDR As SqlDataReader = Nothing
        Dim sAgentID As String = ""

        CheckLastReloadTS = False

        Try
            oCmd = oConn.CreateCommand
            oCmd.Connection = oConn
            sSQL = "SELECT LocalMOID FROM TxIn WHERE ReloadTelco NOT LIKE '%PIN' and ReloadMSISDN=@ReloadMSISDN and ReloadAmount=@ReloadAmount and datediff(s,CreatedTS,getdate()) < '30'  and (STATUS='SUCCESS' or STATUS='PENDING') "

            If sSQL <> "" Then
                oCmd.CommandText = sSQL
                With oCmd.Parameters
                    .Clear()
                    .AddWithValue("@ReloadMSISDN", sReloadMSISDN)
                    .AddWithValue("@ReloadAmount", sReloadAmount)
                End With
                oDR = oCmd.ExecuteReader

                If oDR.HasRows Then
                    CheckLastReloadTS = True
                End If
                oDR.Close()
            End If

        Catch ex As Exception
            CheckLastReloadTS = False
            'goLog.ErrorLog(ProcessorId & "~CheckLastReloadTS", ex.Message & ex.StackTrace)
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


    Private Function getPostRobin(ByVal sReloadTelco As String) As String

        Dim sSQL As String = ""
        Dim oConn As New SqlConnection(ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString)
        Dim oCmd As New SqlCommand
        Dim oDR As SqlDataReader = Nothing
        getPostRobin = 1

        Try
            oConn.Open()
            oCmd = oConn.CreateCommand
            oCmd.Connection = oConn
            sSQL = "SELECT (Robin+1) as Robin FROM TxIn WHERE ReloadTelco=@ReloadTelco order by localMoId desc "

            oCmd.CommandText = sSQL
            With oCmd.Parameters
                .Clear()
                .AddWithValue("@ReloadTelco", sReloadTelco)
            End With
            oDR = oCmd.ExecuteReader

            If oDR.Read() Then
                getPostRobin = (oDR.Item("Robin"))
            End If
            oDR.Close()
            oConn.Close()

            If getPostRobin > getMaxPostRobin(sReloadTelco) Then
                getPostRobin = 1
            End If

            ' goLog.InfoLog("sReloadTelco", sReloadTelco)
            ' goLog.InfoLog("getPostRobin", getPostRobin)


        Catch ex As Exception
            ' goLog.ErrorLog(ProcessorId & "~getProcessorSetting", ex.Message)
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

    Private Function getMaxPostRobin(ByVal sTelco As String) As String

        Dim sSQL As String = ""
        Dim oConn As New SqlConnection(ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString)
        Dim oCmd As New SqlCommand
        Dim oDR As SqlDataReader = Nothing
        getMaxPostRobin = 1

        Try
            oConn.Open()
            oCmd = oConn.CreateCommand
            oCmd.Connection = oConn
            sSQL = "SELECT MaxRobin FROM PostRobin WHERE Telco=@Telco"

            oCmd.CommandText = sSQL
            With oCmd.Parameters
                .Clear()
                .AddWithValue("@Telco", sTelco)
            End With
            oDR = oCmd.ExecuteReader
            If oDR.Read Then
                getMaxPostRobin = (oDR.Item("MaxRobin"))
            End If
            oDR.Close()
            oConn.Close()


        Catch ex As Exception
            getMaxPostRobin = 1
            'goLog.ErrorLog(ProcessorId & "~getMaxPostRobin", ex.Message)
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
 
    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        Dim sMsg As String
        sMsg = txtReloadMSISDN.Text & " " & Me.DDLReloadAmount.Text
        Me.btnConfirm.Enabled = False
        Me.btnEdit.Text = "New"
        InsertIntoTxIn(Session("DEALER_MSISDN"), sMsg, Format(Now(), "yyyyMMddHHmmss"))
        'Response.Write(Session("DEALER_MSISDN") & "---" & sMsg)
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        Me.txtReloadMSISDN.Enabled = True
        Me.DDLReloadAmount.Enabled = True
        Me.btnConfirm.Visible = False
        Me.btnEdit.Visible = False
        Me.btnSubmit.Visible = True
        Me.DDLTelco.Enabled = True
        Me.btnConfirm.Enabled = True
    End Sub

    Protected Sub DDLTelco_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        DDLReloadAmount.Items.Clear()
        getNote(DDLTelco.SelectedValue)
    End Sub
    Protected Sub DDLTelco2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        DDLReloadAmount2.Items.Clear()
        getNote(DDLTelco2.SelectedValue)
    End Sub


    Private Function getNote(ByVal sTelco As String) As String

        Dim sSQL As String = ""
        Dim oConn As New SqlConnection(ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString)
        Dim oCmd As New SqlCommand
        Dim oDR As SqlDataReader = Nothing
        getNote = 1

        Try
            oConn.Open()
            oCmd = oConn.CreateCommand
            oCmd.Connection = oConn
            sSQL = "SELECT Note FROM ProductInfo WHERE Telco=@Telco"

            oCmd.CommandText = sSQL
            With oCmd.Parameters
                .Clear()
                .AddWithValue("@Telco", sTelco)
            End With
            oDR = oCmd.ExecuteReader
            If oDR.Read Then
                getNote = (oDR.Item("Note"))
            End If
            oDR.Close()
            oConn.Close()


            Dim aNote() As String
            Dim i As Integer = 0

            aNote = getNote.Split(",")

            For i = 0 To UBound(aNote)
                Me.DDLReloadAmount.Items.Add(aNote(i))
            Next

        Catch ex As Exception
            getNote = 1
            'goLog.ErrorLog(ProcessorId & "~getMaxPostRobin", ex.Message)
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


    Private Function getProductID(ByVal sTelco As String) As String

        Dim sSQL As String = ""
        Dim oConn As New SqlConnection(ConfigurationManager.ConnectionStrings("RichTechConnectionString").ConnectionString)
        Dim oCmd As New SqlCommand
        Dim oDR As SqlDataReader = Nothing
        getProductID = 0

        Try
            oConn.Open()
            oCmd = oConn.CreateCommand
            oCmd.Connection = oConn
            sSQL = "SELECT ProductID FROM ProductInfo WHERE Telco=@Telco"

            oCmd.CommandText = sSQL
            With oCmd.Parameters
                .Clear()
                .AddWithValue("@Telco", sTelco)
            End With
            oDR = oCmd.ExecuteReader
            If oDR.Read Then
                getProductID = (oDR.Item("ProductID"))
            End If
            oDR.Close()
            oConn.Close()

 
        Catch ex As Exception
            getProductID = 0
            'goLog.ErrorLog(ProcessorId & "~getMaxPostRobin", ex.Message)
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

End Class
