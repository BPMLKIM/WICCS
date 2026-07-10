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

Partial Class laporan1
    Inherits System.Web.UI.Page

    Protected Sub redisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles redisplay.Click

        If rblPilihan.SelectedIndex = 0 Then
            Response.Write("<script language=javascript>window.open('crlaporan3.aspx?id=" & Request("rblPilihan") & "&RptH=" & Request("RptH") & "&Tarikh1=" & txtTarikh1.Text & "&Tarikh2=" & txtTarikh1.Text & "&type=H');</script>")
        ElseIf rblPilihan.SelectedIndex = 1 Then
            Response.Write("<script language=javascript>window.open('crlaporan3.aspx?id=" & Request("rblPilihan") & "&RptB=" & Request("RptB") & "&Bulan1=" & txtBulan1.Text & "&Bulan2=" & txtBulan2.Text & "&type=B');</script>")
        ElseIf rblPilihan.SelectedIndex = 2 Then
            Response.Write("<script language=javascript>window.open('crlaporan3.aspx?id=" & Request("rblPilihan") & "&RptT=" & Request("RptT") & "&Tahun1=" & txtTahun1.Text & "&Tahun2=" & txtTahun1.Text & "&type=T');</script>")
        End If

    End Sub

    Protected Sub returnmenu_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Write("<script language=javascript>location.href='Laporan.aspx';</script>")
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        PanelHarian.Visible = True
        PanelBulanan.Visible = False
        PanelTahunan.Visible = False

    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dtButton1.Attributes.Add("onclick", "javascript:popUpCalendar(this,txtTarikh1,'dd/mm/yyyy');return false;")
        dtButton3.Attributes.Add("onclick", "javascript:popUpCalendar(this,txtBulan1,'mm/yyyy');return false;")
        dtButton4.Attributes.Add("onclick", "javascript:popUpCalendar(this,txtBulan2,'mm/yyyy');return false;")
        dtButton5.Attributes.Add("onclick", "javascript:popUpCalendar(this,txtTahun1,'yyyy');return false;")
        'dtButton6.Attributes.Add("onclick", "javascript:popUpCalendar(this,txtTahun2,'yyyy');return false;")
        txtTarikh1.ReadOnly = True
        txtBulan1.ReadOnly = True
        txtTahun1.ReadOnly = True
        Session.LCID = 2057

        If rblPilihan.SelectedIndex = 0 Then
            PanelHarian.Visible = True
            PanelBulanan.Visible = False
            PanelTahunan.Visible = False
        ElseIf rblPilihan.SelectedIndex = 1 Then
            PanelHarian.Visible = False
            PanelBulanan.Visible = True
            PanelTahunan.Visible = False
        ElseIf rblPilihan.SelectedIndex = 2 Then
            PanelHarian.Visible = False
            PanelBulanan.Visible = False
            PanelTahunan.Visible = True
        End If

    End Sub

    Public Sub pilihanReload(ByVal sender As Object, ByVal e As EventArgs)
        If rblPilihan.SelectedIndex = 0 Then
            PanelHarian.Visible = True
            PanelBulanan.Visible = False
            PanelTahunan.Visible = False
        ElseIf rblPilihan.SelectedIndex = 1 Then
            PanelHarian.Visible = False
            PanelBulanan.Visible = True
            PanelTahunan.Visible = False
        ElseIf rblPilihan.SelectedIndex = 2 Then
            PanelHarian.Visible = False
            PanelBulanan.Visible = False
            PanelTahunan.Visible = True
        End If
    End Sub
End Class
