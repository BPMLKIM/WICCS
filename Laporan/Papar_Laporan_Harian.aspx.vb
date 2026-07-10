Imports System
Imports System.Data
Imports System.Collections
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Partial Class Laporan_Papar_Laporan_Harian
    Inherits System.Web.UI.Page

    Protected Sub redisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Select Case Request("id")
            Case Is = 3
                Response.Write("<script language=javascript>window.open('crReportDisplayImport.aspx?id=" & Request("id") & "&RptH=" & Request("RptH") & "&Tarikh1=" & txtTarikh1.Text & "&Tarikh2=" & txtTarikh2.Text & "&type=H');</script>")
            Case Is = 64
                Response.Write("<script language=javascript>window.open('crReportDisplayImport.aspx?id=" & Request("id") & "&RptH=" & Request("RptH") & "&Tarikh1=" & txtTarikh1.Text & "&Tarikh2=" & txtTarikh2.Text & "&type=H');</script>")
            Case Is = 40
                Response.Write("<script language=javascript>window.open('crReportDisplayImport.aspx?id=" & Request("id") & "&RptH=" & Request("RptH") & "&Tarikh1=" & txtTarikh1.Text & "&Tarikh2=" & txtTarikh2.Text & "&type=H');</script>")
            Case Else
                Response.Write("<script language=javascript>window.open('crReportDisplayCaj.aspx?id=" & Request("id") & "&Rpt1=" & Request("Rpt1") & "&Tarikh1=" & txtTarikh1.Text & "&Tarikh2=" & txtTarikh2.Text & "');</script>")
        End Select
    End Sub

    Protected Sub returnmenu_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Write("<script language=javascript>location.href='Laporan.aspx';</script>")
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Request("id") >= 53 And Request("id") <= 56 Then
            lblTarikh1.Text = "Dari Bulan :"
            lblTarikh2.Text = "Hingga Bulan :"
            dtButton1.Attributes.Add("onclick", "javascript:popUpCalendar(this,txtTarikh1,'mm/yyyy');return false;")
            dtButton2.Attributes.Add("onclick", "javascript:popUpCalendar(this,txtTarikh2,'mm/yyyy');return false;")
        ElseIf Request("id") >= 58 And Request("id") <= 61 Then
            lblTarikh1.Text = "Dari Tahun :"
            lblTarikh2.Text = "Hingga Tahun :"
            dtButton1.Attributes.Add("onclick", "javascript:popUpCalendar(this,txtTarikh1,'yyyy');return false;")
            dtButton2.Attributes.Add("onclick", "javascript:popUpCalendar(this,txtTarikh2,'yyyy');return false;")
        Else
            dtButton1.Attributes.Add("onclick", "javascript:popUpCalendar(this,txtTarikh1,'dd/mm/yyyy');return false;")
            dtButton2.Attributes.Add("onclick", "javascript:popUpCalendar(this,txtTarikh2,'dd/mm/yyyy');return false;")
        End If
        txtTarikh1.ReadOnly = True
        txtTarikh2.ReadOnly = True
    End Sub

End Class