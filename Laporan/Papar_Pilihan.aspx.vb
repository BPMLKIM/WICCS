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

Partial Class Papar_Pilihan
    Inherits System.Web.UI.Page

    Protected Sub redisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Response.Write(Request("id"))
        If Request("id") < 12 Then
            If rblPilihan.SelectedIndex = 0 Then
                Response.Write("<script language=javascript>window.open('crReportDisplayImport.aspx?id=" & Request("id") & "&RptH=" & Request("RptH") & "&Tarikh1=" & txtTarikh1.Text & "&Tarikh2=" & txtTarikh1.Text & "&type=H');</script>")
            ElseIf rblPilihan.SelectedIndex = 1 Then
                Response.Write("<script language=javascript>window.open('crReportDisplayImport.aspx?id=" & Request("id") & "&RptB=" & Request("RptB") & "&Bulan1=" & txtBulan1.Text & "&Bulan2=" & txtBulan1.Text & "&type=B');</script>")
            ElseIf rblPilihan.SelectedIndex = 2 Then
                Response.Write("<script language=javascript>window.open('crReportDisplayImport.aspx?id=" & Request("id") & "&RptT=" & Request("RptT") & "&Tahun1=" & txtTahun1.Text & "&Tahun2=" & txtTahun1.Text & "&type=T');</script>")
            End If
        ElseIf Request("id") = 12 Then
            If rblPilihan.SelectedIndex = 0 Then
                Response.Write("<script language=javascript>window.open('crReportDisplayImport.aspx?id=" & Request("id") & "&RptH=" & Request("RptH") & "&Tarikh1=" & txtTarikh1.Text & "&Tarikh2=" & txtTarikh1.Text & "&type=H&Spesis=" & DropDownListSpesis.SelectedItem.Text & "');</script>")
            ElseIf rblPilihan.SelectedIndex = 1 Then
                Response.Write("<script language=javascript>window.open('crReportDisplayImport.aspx?id=" & Request("id") & "&RptB=" & Request("RptB") & "&Bulan1=" & txtBulan1.Text & "&Bulan2=" & txtBulan1.Text & "&type=B&Spesis=" & DropDownListSpesis.SelectedItem.Text & "');</script>")
            ElseIf rblPilihan.SelectedIndex = 2 Then
                Response.Write("<script language=javascript>window.open('crReportDisplayImport.aspx?id=" & Request("id") & "&RptT=" & Request("RptT") & "&Tahun1=" & txtTahun1.Text & "&Tahun2=" & txtTahun1.Text & "&type=T&Spesis=" & DropDownListSpesis.SelectedItem.Text & "');</script>")
            End If
        ElseIf Request("id") < 18 Then
            If rblPilihan.SelectedIndex = 0 Then
                Response.Write("<script language=javascript>window.open('crReportDisplayImport.aspx?id=" & Request("id") & "&RptH=" & Request("RptH") & "&Tarikh1=" & txtTarikh1.Text & "&Tarikh2=" & txtTarikh1.Text & "&type=H');</script>")
            ElseIf rblPilihan.SelectedIndex = 1 Then
                Response.Write("<script language=javascript>window.open('crReportDisplayImport.aspx?id=" & Request("id") & "&RptB=" & Request("RptB") & "&Bulan1=" & txtBulan1.Text & "&Bulan2=" & txtBulan1.Text & "&type=B');</script>")
            ElseIf rblPilihan.SelectedIndex = 2 Then
                Response.Write("<script language=javascript>window.open('crReportDisplayImport.aspx?id=" & Request("id") & "&RptT=" & Request("RptT") & "&Tahun1=" & txtTahun1.Text & "&Tahun2=" & txtTahun1.Text & "&type=T');</script>")
            End If
        ElseIf Request("id") = 18 Then
            If rblPilihan.SelectedIndex = 0 Then
                Response.Write("<script language=javascript>window.open('crReportDisplayImport.aspx?id=" & Request("id") & "&RptH=" & Request("RptH") & "&Tarikh1=" & txtTarikh1.Text & "&Tarikh2=" & txtTarikh1.Text & "&type=H&Pasar=" & DropDownListPasar.SelectedItem.Text & "');</script>")
            ElseIf rblPilihan.SelectedIndex = 1 Then
                Response.Write("<script language=javascript>window.open('crReportDisplayImport.aspx?id=" & Request("id") & "&RptB=" & Request("RptB") & "&Bulan1=" & txtBulan1.Text & "&Bulan2=" & txtBulan1.Text & "&type=B&Pasar=" & DropDownListPasar.SelectedItem.Text & "');</script>")
            ElseIf rblPilihan.SelectedIndex = 2 Then
                Response.Write("<script language=javascript>window.open('crReportDisplayImport.aspx?id=" & Request("id") & "&RptT=" & Request("RptT") & "&Tahun1=" & txtTahun1.Text & "&Tahun2=" & txtTahun1.Text & "&type=T&Pasar=" & DropDownListPasar.SelectedItem.Text & "');</script>")
            End If
        ElseIf Request("id") < 28 Then
            If rblPilihan.SelectedIndex = 0 Then
                Response.Write("<script language=javascript>window.open('crReportDisplayEksport.aspx?id=" & Request("id") & "&RptH=" & Request("RptH") & "&Tarikh1=" & txtTarikh1.Text & "&Tarikh2=" & txtTarikh1.Text & "&type=H');</script>")
            ElseIf rblPilihan.SelectedIndex = 1 Then
                Response.Write("<script language=javascript>window.open('crReportDisplayEksport.aspx?id=" & Request("id") & "&RptB=" & Request("RptB") & "&Bulan1=" & txtBulan1.Text & "&Bulan2=" & txtBulan1.Text & "&type=B');</script>")
            ElseIf rblPilihan.SelectedIndex = 2 Then
                Response.Write("<script language=javascript>window.open('crReportDisplayEksport.aspx?id=" & Request("id") & "&RptT=" & Request("RptT") & "&Tahun1=" & txtTahun1.Text & "&Tahun2=" & txtTahun1.Text & "&type=T');</script>")
            End If
        ElseIf Request("id") = 28 Then
            If rblPilihan.SelectedIndex = 0 Then
                Response.Write("<script language=javascript>window.open('crReportDisplayEksport.aspx?id=" & Request("id") & "&RptH=" & Request("RptH") & "&Tarikh1=" & txtTarikh1.Text & "&Tarikh2=" & txtTarikh1.Text & "&type=H&Spesis=" & DropDownListSpesis.SelectedItem.Text & "');</script>")
            ElseIf rblPilihan.SelectedIndex = 1 Then
                Response.Write("<script language=javascript>window.open('crReportDisplayEksport.aspx?id=" & Request("id") & "&RptB=" & Request("RptB") & "&Bulan1=" & txtBulan1.Text & "&Bulan2=" & txtBulan1.Text & "&type=B&Spesis=" & DropDownListSpesis.SelectedItem.Text & "');</script>")
            ElseIf rblPilihan.SelectedIndex = 2 Then
                Response.Write("<script language=javascript>window.open('crReportDisplayEksport.aspx?id=" & Request("id") & "&RptT=" & Request("RptT") & "&Tahun1=" & txtTahun1.Text & "&Tahun2=" & txtTahun1.Text & "&type=T&Spesis=" & DropDownListSpesis.SelectedItem.Text & "');</script>")
            End If
        ElseIf Request("id") < 33 Then
            If rblPilihan.SelectedIndex = 0 Then
                Response.Write("<script language=javascript>window.open('crReportDisplayEksport.aspx?id=" & Request("id") & "&RptH=" & Request("RptH") & "&Tarikh1=" & txtTarikh1.Text & "&Tarikh2=" & txtTarikh1.Text & "&type=H');</script>")
            ElseIf rblPilihan.SelectedIndex = 1 Then
                Response.Write("<script language=javascript>window.open('crReportDisplayEksport.aspx?id=" & Request("id") & "&RptB=" & Request("RptB") & "&Bulan1=" & txtBulan1.Text & "&Bulan2=" & txtBulan1.Text & "&type=B');</script>")
            ElseIf rblPilihan.SelectedIndex = 2 Then
                Response.Write("<script language=javascript>window.open('crReportDisplayEksport.aspx?id=" & Request("id") & "&RptT=" & Request("RptT") & "&Tahun1=" & txtTahun1.Text & "&Tahun2=" & txtTahun1.Text & "&type=T');</script>")
            End If
        ElseIf Request("id") < 46 Then
            If rblPilihan.SelectedIndex = 0 Then
                Response.Write("<script language=javascript>window.open('crReportDisplayImport.aspx?id=" & Request("id") & "&RptH=" & Request("RptH") & "&Tarikh1=" & txtTarikh1.Text & "&Tarikh2=" & txtTarikh1.Text & "&type=H');</script>")
            ElseIf rblPilihan.SelectedIndex = 1 Then
                Response.Write("<script language=javascript>window.open('crReportDisplayImport.aspx?id=" & Request("id") & "&RptB=" & Request("RptB") & "&Bulan1=" & txtBulan1.Text & "&Bulan2=" & txtBulan1.Text & "&type=B');</script>")
            ElseIf rblPilihan.SelectedIndex = 2 Then
                Response.Write("<script language=javascript>window.open('crReportDisplayImport.aspx?id=" & Request("id") & "&RptT=" & Request("RptT") & "&Tahun1=" & txtTahun1.Text & "&Tahun2=" & txtTahun1.Text & "&type=T');</script>")
            End If
            'ElseIf Request("id") < 53 Then
        ElseIf Request("id") < 56 Then
            If Request("id") = 50 Or Request("id") = 51 Or Request("id") = 54 Then
                If rblPilihan.SelectedIndex = 0 Then
                    Response.Write("<script language=javascript>window.open('crReportDisplayCaj.aspx?id=" & Request("id") & "&RptH=" & Request("RptH") & "&Tarikh1=" & txtTarikh1.Text & "&Tarikh2=" & txtTarikh1.Text & "&type=H&Agen=" & DropDownListAgen.SelectedItem.Text & "');</script>")
                ElseIf rblPilihan.SelectedIndex = 1 Then
                    Response.Write("<script language=javascript>window.open('crReportDisplayCaj.aspx?id=" & Request("id") & "&RptB=" & Request("RptB") & "&Bulan1=" & txtBulan1.Text & "&Bulan2=" & txtBulan1.Text & "&type=B&Agen=" & DropDownListAgen.SelectedItem.Text & "');</script>")
                ElseIf rblPilihan.SelectedIndex = 2 Then
                    Response.Write("<script language=javascript>window.open('crReportDisplayCaj.aspx?id=" & Request("id") & "&RptT=" & Request("RptT") & "&Tahun1=" & txtTahun1.Text & "&Tahun2=" & txtTahun1.Text & "&type=T&Agen=" & DropDownListAgen.SelectedItem.Text & "');</script>")
                End If
            Else
                If rblPilihan.SelectedIndex = 0 Then
                    Response.Write("<script language=javascript>window.open('crReportDisplayCaj.aspx?id=" & Request("id") & "&RptH=" & Request("RptH") & "&Tarikh1=" & txtTarikh1.Text & "&Tarikh2=" & txtTarikh1.Text & "&type=H');</script>")
                ElseIf rblPilihan.SelectedIndex = 1 Then
                    Response.Write("<script language=javascript>window.open('crReportDisplayCaj.aspx?id=" & Request("id") & "&RptB=" & Request("RptB") & "&Bulan1=" & txtBulan1.Text & "&Bulan2=" & txtBulan1.Text & "&type=B');</script>")
                ElseIf rblPilihan.SelectedIndex = 2 Then
                    Response.Write("<script language=javascript>window.open('crReportDisplayCaj.aspx?id=" & Request("id") & "&RptT=" & Request("RptT") & "&Tahun1=" & txtTahun1.Text & "&Tahun2=" & txtTahun1.Text & "&type=T');</script>")
                End If
            End If
            ElseIf Request("id") < 71 Then
                If rblPilihan.SelectedIndex = 0 Then
                    Response.Write("<script language=javascript>window.open('crReportDisplayImport.aspx?id=" & Request("id") & "&RptH=" & Request("RptH") & "&Tarikh1=" & txtTarikh1.Text & "&Tarikh2=" & txtTarikh1.Text & "&type=H');</script>")
                ElseIf rblPilihan.SelectedIndex = 1 Then
                    Response.Write("<script language=javascript>window.open('crReportDisplayImport.aspx?id=" & Request("id") & "&RptB=" & Request("RptB") & "&Bulan1=" & txtBulan1.Text & "&Bulan2=" & txtBulan1.Text & "&type=B');</script>")
                ElseIf rblPilihan.SelectedIndex = 2 Then
                    Response.Write("<script language=javascript>window.open('crReportDisplayImport.aspx?id=" & Request("id") & "&RptT=" & Request("RptT") & "&Tahun1=" & txtTahun1.Text & "&Tahun2=" & txtTahun1.Text & "&type=T');</script>")
            End If
        ElseIf Request("id") = 501 Then 'edited by kmz for caj eksport
            If rblPilihan.SelectedIndex = 0 Then
                Response.Write("<script language=javascript>window.open('crReportDisplayCaj.aspx?id=" & Request("id") & "&RptH=" & Request("RptH") & "&Tarikh1=" & txtTarikh1.Text & "&Tarikh2=" & txtTarikh1.Text & "&type=H&Agen=" & DropDownListAgen.SelectedItem.Text & "');</script>")
            ElseIf rblPilihan.SelectedIndex = 1 Then
                Response.Write("<script language=javascript>window.open('crReportDisplayCaj.aspx?id=" & Request("id") & "&RptB=" & Request("RptB") & "&Bulan1=" & txtBulan1.Text & "&Bulan2=" & txtBulan1.Text & "&type=B&Agen=" & DropDownListAgen.SelectedItem.Text & "');</script>")
            ElseIf rblPilihan.SelectedIndex = 2 Then
                Response.Write("<script language=javascript>window.open('crReportDisplayCaj.aspx?id=" & Request("id") & "&RptT=" & Request("RptT") & "&Tahun1=" & txtTahun1.Text & "&Tahun2=" & txtTahun1.Text & "&type=T&Agen=" & DropDownListAgen.SelectedItem.Text & "');</script>")
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
        If Request("id") = 12 Or Request("id") = 28 Then
            PanelSpesis.Visible = True
            showSpesis()
        Else
            PanelSpesis.Visible = False
        End If
        If Request("id") = 18 Then
            PanelPasar.Visible = True
            showPasar()
        Else
            PanelPasar.Visible = False
        End If
        If Request("id") = 50 Or Request("id") = 51 Or Request("id") = 54 Or Request("id") = 55 Or Request("id") = 501 Then
            PanelAgen.Visible = True
            showAgen()
        Else
            PanelAgen.Visible = False
        End If
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dtButton1.Attributes.Add("onclick", "javascript:popUpCalendar(this,txtTarikh1,'dd/mm/yyyy');return false;")
        dtButton3.Attributes.Add("onclick", "javascript:popUpCalendar(this,txtBulan1,'mm/yyyy');return false;")
        'dtButton4.Attributes.Add("onclick", "javascript:popUpCalendar(this,txtBulan2,'mm/yyyy');return false;")
        dtButton5.Attributes.Add("onclick", "javascript:popUpCalendar(this,txtTahun1,'yyyy');return false;")
        'dtButton6.Attributes.Add("onclick", "javascript:popUpCalendar(this,txtTahun2,'yyyy');return false;")
        txtTarikh1.ReadOnly = True
        txtBulan1.ReadOnly = True
        'txtBulan2.ReadOnly = True
        txtTahun1.ReadOnly = True
        'txtTahun2.ReadOnly = True

        Session.LCID = 2057
        'txtTarikh1.Text = (Left(Trim(Date.Now()), 10))
        'txtBulan1.Text = (Left(Right(Trim(Date.Now()), 16), 7))
        'txtBulan2.Text = (Left(Right(Trim(Date.Now()), 16), 7))
        'txtTahun1.Text = (Left(Right(Trim(Date.Now()), 13), 5))
        'txtTahun2.Text = (Left(Right(Trim(Date.Now()), 13), 5))

    End Sub

    Public Sub pilihanReload(ByVal sender As Object, ByVal e As EventArgs)
        If Request("id") = 12 Or Request("id") = 28 Then
            PanelSpesis.Visible = True
        Else
            PanelSpesis.Visible = False
        End If
        If Request("id") = 18 Then
            PanelPasar.Visible = True
            showPasar()
        Else
            PanelPasar.Visible = False
        End If
        If Request("id") = 50 Or Request("id") = 51 Or Request("id") = 54 Or Request("id") = 501 Then
            PanelAgen.Visible = True
            showAgen()
        Else
            PanelAgen.Visible = False
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

    Private Sub showPasar()

        Dim connString As String
        connString = System.Configuration.ConfigurationManager.ConnectionStrings("W-ICCS_Conn").ToString()
        Dim Rdr As System.Data.SqlClient.SqlDataReader = Nothing
        Dim conn As New SqlClient.SqlConnection(connString)

        Dim strSql As String = "SELECT Nama_Pasar FROM Destinasi_Pasar ORDER BY Nama_Pasar"
        Dim cmd As New SqlClient.SqlCommand(strSql, conn)
        conn.Open()
        Rdr = cmd.ExecuteReader()

        Dim item1 As ListItem
        DropDownListPasar.Items.Clear()
        While Rdr.Read
            item1 = New ListItem()
            item1.Text = Rdr.Item("Nama_Pasar")
            DropDownListPasar.Items.Add(item1)
        End While
        DropDownListPasar.Items.Insert(0, "Semua")
    End Sub

    Private Sub showAgen()

        Dim connString As String
        connString = System.Configuration.ConfigurationManager.ConnectionStrings("W-ICCS_Conn").ToString()
        Dim Rdr As System.Data.SqlClient.SqlDataReader = Nothing
        Dim conn As New SqlClient.SqlConnection(connString)

        Dim strSql As String = "SELECT Nama_Agen_Pengangkutan FROM Agen_Pengangkutan ORDER BY Nama_Agen_Pengangkutan"
        Dim cmd As New SqlClient.SqlCommand(strSql, conn)
        conn.Open()
        Rdr = cmd.ExecuteReader()

        Dim item1 As ListItem
        DropDownListAgen.Items.Clear()
        While Rdr.Read
            item1 = New ListItem()
            item1.Text = Rdr.Item("Nama_Agen_Pengangkutan")
            DropDownListAgen.Items.Add(item1)
        End While
        DropDownListAgen.Items.Insert(0, "Semua")
    End Sub

End Class
