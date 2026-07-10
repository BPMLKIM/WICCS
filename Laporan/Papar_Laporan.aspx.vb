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

Partial Class Laporan_Papar_Laporan
    Inherits System.Web.UI.Page

    Protected Sub redisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Request("id") < 19 Then
            If rblPilihan.SelectedIndex = 0 Then
                Response.Write("<script language=javascript>window.open('crReportDisplayImport.aspx?id=" & Request("id") & "&RptH=" & Request("RptH") & "&Tarikh1=" & txtTarikh1.Text & "&Tarikh2=" & txtTarikh2.Text & "&type=H');</script>")
            ElseIf rblPilihan.SelectedIndex = 1 Then
                Response.Write("<script language=javascript>window.open('crReportDisplayImport.aspx?id=" & Request("id") & "&RptB=" & Request("RptB") & "&Bulan=" & CInt(txtBulan.Text) & "&Tahun=" & txtTahun.Text & "&type=B');</script>")
            ElseIf rblPilihan.SelectedIndex = 2 Then
                Response.Write("<script language=javascript>window.open('crReportDisplayImport.aspx?id=" & Request("id") & "&RptT=" & Request("RptT") & "&Tahun=" & txtTahun1.Text & "&type=T');</script>")
            End If
        ElseIf Request("id") = 28 Then
            If rblPilihan.SelectedIndex = 0 Then
                Response.Write("<script language=javascript>window.open('crReportDisplayEksport.aspx?id=" & Request("id") & "&Rpt=" & Request("RptH") & "&Tarikh1=" & txtTarikh1.Text & "&Tarikh2=" & txtTarikh2.Text & "&type=H&Spesis=" & DropDownListSpesis.SelectedItem.Text & "');</script>")
            ElseIf rblPilihan.SelectedIndex = 1 Then
                Response.Write("<script language=javascript>window.open('crReportDisplayEksport.aspx?id=" & Request("id") & "&Rpt=" & Request("RptB") & "&Bulan=" & CInt(txtBulan.Text) & "&Tahun=" & txtTahun.Text & "&type=B&Spesis=" & DropDownListSpesis.SelectedItem.Text & "');</script>")
            ElseIf rblPilihan.SelectedIndex = 2 Then
                Response.Write("<script language=javascript>window.open('crReportDisplayEksport.aspx?id=" & Request("id") & "&Rpt=" & Request("RptT") & "&Tahun=" & txtTahun1.Text & "&type=T&Spesis=" & DropDownListSpesis.SelectedItem.Text & "');</script>")
            End If
        ElseIf Request("id") > 19 And Request("id") < 33 Then
            If rblPilihan.SelectedIndex = 0 Then
                Response.Write("<script language=javascript>window.open('crReportDisplayEksport.aspx?id=" & Request("id") & "&Rpt=" & Request("RptH") & "&Tarikh1=" & txtTarikh1.Text & "&Tarikh2=" & txtTarikh2.Text & "&type=H');</script>")
            ElseIf rblPilihan.SelectedIndex = 1 Then
                Response.Write("<script language=javascript>window.open('crReportDisplayEksport.aspx?id=" & Request("id") & "&Rpt=" & Request("RptB") & "&Bulan=" & CInt(txtBulan.Text) & "&Tahun=" & txtTahun.Text & "&type=B');</script>")
            ElseIf rblPilihan.SelectedIndex = 2 Then
                Response.Write("<script language=javascript>window.open('crReportDisplayEksport.aspx?id=" & Request("id") & "&Rpt=" & Request("RptT") & "&Tahun=" & txtTahun1.Text & "&type=T');</script>")
            End If
        End If
    End Sub

    Protected Sub returnmenu_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Write("<script language=javascript>location.href='Laporan.aspx';</script>")
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        PanelHarian.Visible = True
        PanelBulanan.Visible = False
        PanelTahunan.Visible = False
        If Request("id") = 28 Then
            PanelSpesis.Visible = True
            showSpesis()
        Else
            PanelSpesis.Visible = False
        End If
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dtButton1.Attributes.Add("onclick", "javascript:popUpCalendar(this,txtTarikh1,'dd/mm/yyyy');return false;")
        dtButton2.Attributes.Add("onclick", "javascript:popUpCalendar(this,txtTarikh2,'dd/mm/yyyy');return false;")
        dtButton3.Attributes.Add("onclick", "javascript:popUpCalendar(this,txtBulan,'mm');return false;")
        dtButton4.Attributes.Add("onclick", "javascript:popUpCalendar(this,txtTahun,'yyyy');return false;")
        dtButton5.Attributes.Add("onclick", "javascript:popUpCalendar(this,txtTahun1,'yyyy');return false;")
        txtTarikh1.ReadOnly = True
        txtTarikh2.ReadOnly = True
        txtBulan.ReadOnly = True
        txtTahun.ReadOnly = True
        txtTahun1.ReadOnly = True

    End Sub

    Public Sub pilihanReload(ByVal sender As Object, ByVal e As EventArgs)
        If Request("id") = 28 Then
            PanelSpesis.Visible = True
        Else
            PanelSpesis.Visible = False
        End If

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

    Private Sub showSpesis()

        Dim connString As String
        connString = System.Configuration.ConfigurationManager.ConnectionStrings("W-ICCS_Conn").ToString()
        Dim Rdr As System.Data.SqlClient.SqlDataReader = Nothing
        Dim conn As New SqlClient.SqlConnection(connString)

        Dim strSql As String = "SELECT Nama_BKH FROM JENIS_IKAN ORDER BY Nama_BKH"
        Dim cmd As New SqlClient.SqlCommand(strSql, conn)
        conn.Open()
        Rdr = cmd.ExecuteReader()

        Dim item1 As ListItem
        DropDownListSpesis.Items.Clear()
        While Rdr.Read
            item1 = New ListItem()
            item1.Text = Rdr.Item("Nama_BKH")
            DropDownListSpesis.Items.Add(item1)
        End While
        DropDownListSpesis.Items.Insert(0, "Semua")
    End Sub
End Class


