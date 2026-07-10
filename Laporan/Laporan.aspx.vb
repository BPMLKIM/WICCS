Imports System
Imports System.Data
Imports System.Data.SQLClient
Imports System.Configuration
Imports System.IO
Imports System.Text

Partial Class Laporan_Laporan
    Inherits System.Web.UI.Page
#Region "Variables Declaration"
    Protected opClass As SQLOperation
    Protected opClass1 As SQLOperation
    Protected opClass2 As SQLOperation
    Public SQLReader As System.Data.SqlClient.SqlDataReader
    Public j As Integer
    Public sqluser As String
    Public sqlText As String
    Public group_id As Integer
    Public SQLReader1 As System.Data.SqlClient.SqlDataReader
    Public SQLReader2 As System.Data.SqlClient.SqlDataReader

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        opClass = New SQLOperation()
        opClass.dbConnection()

        Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5))

        Try
            If Session("username").ToString() Is Nothing Then

                Session.Clear()
                Dim popupScript As String = "<script language='javascript'>" & _
                "alert('Sessi penggunaan anda telah tamat !!!');parent.location.href='../index.aspx';" & _
                "</script>"
                Response.Write(popupScript)
                Response.End()

            End If
        Catch ex As Exception
            Dim popupScript As String = "<script language='javascript'>" & _
            "alert('Sessi penggunaan anda telah tamat !!!');parent.location.href='../index.aspx';" & _
            "</script>"
            Response.Write(popupScript)
            Response.End()

        End Try
    End Sub


End Class