Imports System.Data.SqlClient
Imports WebItopz.CommonItop

Partial Class DNDetails1
    Inherits System.Web.UI.Page
    Private Const STATUS_SUCCESS = "SUCCESS"
    Private Const STATUS_REFUNDED = "REFUNDED"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim bWorking As Boolean = False
        Dim oCommon As New Common

        If Not User.Identity.IsAuthenticated Then
            'Response.Redirect("~/login.aspx")
        Else
        End If

        Me.lblErrorMsg.Text = ""

        Dim sSerialNumber As String = ""
        Dim sMSISDN As String = ""

        sSerialNumber = Request.QueryString("SerialNumber")
        sMSISDN = Request.QueryString("MSISDN")

        If sSerialNumber <> "" Then
            If Session("sSerialNumber") = "" Then
                Session("sSerialNumber") = sSerialNumber
                bWorking = True
            Else
                If Session("sSerialNumber") <> sSerialNumber Then
                    Session("sSerialNumber") = sSerialNumber
                    bWorking = True
                End If
            End If

            If bWorking Then
                If Request("action").ToUpper = "RESENDPIN" Then
                    If oCommon.Resendpin(sSerialNumber, sMSISDN) Then
                        Me.lblErrorMsg.Text = "Resending PIN"
                    Else
                        Me.lblErrorMsg.Text = "Resending Error!!!"
                    End If
                End If
            End If
        Else

        End If


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
End Class