Imports System
Imports System.Data
Imports System.Data.SQLClient
Imports System.Configuration
Imports System.IO
Imports System.Text
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class sistemq
    Inherits System.Web.UI.Page
    'Public connectionstring As String = "Data Source=bkhsvr1;Initial Catalog=W-ICCS;User ID=sa"
    'Public connectionstring As String = "Data Source=quest2003;Initial Catalog=W-ICCS;User ID=sa;Password=quest2k"
    Dim connectionstring As String = System.Configuration.ConfigurationManager.ConnectionStrings("W-ICCS_Conn").ToString()
    Protected opClass As SQLOperation
    Protected hakAkses As String
    Protected display As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Session.LCID = 2057
            datefrom.Text = (Left(Trim(Date.Now()), 10))
            dateto.Text = (Left(Trim(Date.Now()), 10))
            range.Checked = True
            range.Visible = False
        End If

    End Sub
 
    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        If (DropDownList1.SelectedIndex <> 0) Then
            If DropDownList1.SelectedItem.Value = "Import" Then
                DataGrid1.Visible = True
            ElseIf DropDownList1.SelectedItem.Value = "Eksport" Then
                DataGrid1.Visible = True
            ElseIf DropDownList1.SelectedItem.Value = "Transit" Then
                DataGrid1.Visible = True
            ElseIf DropDownList1.SelectedItem.Value = "Barangan Bukan Ikan" Then
                DataGrid1.Visible = True
            ElseIf DropDownList1.SelectedItem.Value = "Semua" Then
                DataGrid1.Visible = True
            End If
            Label1.Text = DropDownList1.SelectedItem.Value
        End If
    End Sub

    Sub DataGrid1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid1.PageIndexChanged
        DataGrid1.CurrentPageIndex = e.NewPageIndex
        datagridvalue()
    End Sub

    Protected Sub query_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles query.Click
        DataGrid1.CurrentPageIndex = False
        datagridvalue()
        GridView1.Visible = False
        DataGrid1.Visible = True
    End Sub

  

    Function datagridvalue()

        'Dim aDate As String
        'Dim adate2 As String

        Session.LCID = 2057

        Dim splitout = Split(Request("datefrom"), "/")
        Dim splitout1 = Split(Request("dateto"), "/")

        'aDate = Left(Right(Request("datefrom"), 7), 2) & "/" & Left(Request("datefrom"), 2) & "/" & Right(Request("datefrom"), 4)
        'adate2 = Left(Right(Request("dateto"), 7), 2) & "/" & Left(Request("dateto"), 2) & "/" & Right(Request("dateto"), 4)

        If Label1.Text = "Import" And range.Checked = True Then
            Dim myconn As New SqlConnection(connectionstring)
            'Dim sql As String = "SELECT sistem_q.No_Barcode , sistem_q.Tarikh , sistem_q.No_Kenderaan , sistem_q.Bil_SKPI , pendaftaran_pintu.jenis_barangan, sistem_q.Pegawai , sistem_q.Status FROM SISTEM_Q inner join pendaftaran_pintu on sistem_q.no_barcode=pendaftaran_pintu.nombor_barcode where pendaftaran_pintu.tarikh_masa_masuk between ('" & splitout(2) & "-" & splitout(1) & "-" & splitout(0) & "') and ('" & splitout1(2) & "-" & splitout1(1) & "-" & splitout1(0) & "" & " 23:59:59" & "') and pendaftaran_pintu.kod_jenis_urusan in ('001','002','016') ORDER BY Tarikh asc"
            Dim sql As String = "SELECT ROW_NUMBER() OVER(ORDER BY Pendaftaran_pintu.tarikh_masa_masuk), PENDAFTARAN_PINTU.Nombor_Barcode, PENDAFTARAN_PINTU.Tarikh_Masa_Masuk, PENDAFTARAN_PINTU.No_Kenderaan, ISNULL(SISTEM_Q.Bil_SKPI, 0) AS Bil_SKPI, ISNULL(SISTEM_Q.Bil_SKPE, 0) AS Bil_SKPE, PENDAFTARAN_PINTU.Jenis_Barangan, PENDAFTARAN_PINTU.EntryMasuk_By, SISTEM_Q.Pegawai, SISTEM_Q.Status FROM  PENDAFTARAN_PINTU LEFT OUTER JOIN SISTEM_Q ON PENDAFTARAN_PINTU.Nombor_Barcode = SISTEM_Q.No_Barcode where kod_jenis_urusan in ('001','002','016') and PENDAFTARAN_PINTU.Tarikh_Masa_Masuk between ('" & splitout(2) & "-" & splitout(1) & "-" & splitout(0) & "') and ('" & splitout1(2) & "-" & splitout1(1) & "-" & splitout1(0) & "" & " 23:59:59" & "')"
            Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
            'myconn.Open()
            Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
            Dim ds As New DataSet()
            myAdapter.Fill(ds)
            DataGrid1.DataSource = ds
            DataGrid1.DataBind()
            Label2.Visible = True
            Label2.Text = "Senarai Import :"
            'myconn.Close()


        ElseIf Label1.Text = "Import" Then
            Dim myconn As New SqlConnection(connectionstring)
            'Dim sql As String = "SELECT sistem_q.No_Barcode , sistem_q.Tarikh , sistem_q.No_Kenderaan , sistem_q.Bil_SKPI , pendaftaran_pintu.jenis_barangan, sistem_q.Pegawai , sistem_q.Status FROM SISTEM_Q left outer join pendaftaran_pintu on sistem_q.no_barcode=pendaftaran_pintu.nombor_barcode where pendaftaran_pintu.kod_jenis_urusan in ('001','002','016') ORDER BY Tarikh asc "
            Dim sql As String = "SELECT PENDAFTARAN_PINTU.Nombor_Barcode, PENDAFTARAN_PINTU.Tarikh_Masa_Masuk, PENDAFTARAN_PINTU.No_Kenderaan, ISNULL(SISTEM_Q.Bil_SKPI, 0) AS Bil_SKPI, ISNULL(SISTEM_Q.Bil_SKPE, 0) AS Bil_SKPE, PENDAFTARAN_PINTU.Jenis_Barangan, PENDAFTARAN_PINTU.EntryMasuk_By, SISTEM_Q.Pegawai, SISTEM_Q.Status FROM  PENDAFTARAN_PINTU LEFT OUTER JOIN SISTEM_Q ON PENDAFTARAN_PINTU.Nombor_Barcode = SISTEM_Q.No_Barcode where pendaftaran_pintu.kod_jenis_urusan in ('001','002','016') ORDER BY pendaftaran_pintu.Tarikh_masa_masuk asc "
            Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
            'myconn.Open()
            Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
            Dim ds As New DataSet()
            myAdapter.Fill(ds)
            DataGrid1.DataSource = ds
            DataGrid1.DataBind()
            Label2.Visible = True
            Label2.Text = "Senarai Import :"
            'myconn.Close()


        ElseIf Label1.Text = "Eksport" And range.Checked = True Then
            Dim myconn As New SqlConnection(connectionstring)
            'Dim sql As String = "SELECT sistem_q.No_Barcode , sistem_q.Tarikh , sistem_q.No_Kenderaan , sistem_q.Bil_SKPE , pendaftaran_pintu.jenis_barangan, sistem_q.Pegawai , sistem_q.Status FROM SISTEM_Q left outer join pendaftaran_pintu on sistem_q.no_barcode=pendaftaran_pintu.nombor_barcode where sistem_q.tarikh between ('" & splitout(2) & "-" & splitout(1) & "-" & splitout(0) & "') and ('" & splitout1(2) & "-" & splitout1(1) & "-" & splitout1(0) & "" & " 23:59:59" & "') and pendaftaran_pintu.kod_jenis_urusan in ('003','018') ORDER BY Tarikh asc"
            Dim sql As String = "SELECT PENDAFTARAN_PINTU.Nombor_Barcode, PENDAFTARAN_PINTU.Tarikh_Masa_Masuk, PENDAFTARAN_PINTU.No_Kenderaan, ISNULL(SISTEM_Q.Bil_SKPI, 0) AS Bil_SKPI, ISNULL(SISTEM_Q.Bil_SKPE, 0) AS Bil_SKPE, PENDAFTARAN_PINTU.Jenis_Barangan, PENDAFTARAN_PINTU.EntryMasuk_By, SISTEM_Q.Pegawai, SISTEM_Q.Status FROM  PENDAFTARAN_PINTU LEFT OUTER JOIN SISTEM_Q ON PENDAFTARAN_PINTU.Nombor_Barcode = SISTEM_Q.No_Barcode where pendaftaran_pintu.kod_jenis_urusan in ('003','018') and PENDAFTARAN_PINTU.Tarikh_Masa_Masuk between ('" & splitout(2) & "-" & splitout(1) & "-" & splitout(0) & "') and ('" & splitout1(2) & "-" & splitout1(1) & "-" & splitout1(0) & "" & " 23:59:59" & "') ORDER BY pendaftaran_pintu.Tarikh_masa_masuk asc "
            Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
            'myconn.Open()
            Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
            Dim ds As New DataSet()
            myAdapter.Fill(ds)
            DataGrid1.DataSource = ds
            DataGrid1.DataBind()
            Label2.Visible = True
            Label2.Text = "Senarai Eksport :"
            'myconn.Close()


        ElseIf Label1.Text = "Eksport" Then
            Dim myconn As New SqlConnection(connectionstring)
            'Dim sql As String = "SELECT sistem_q.No_Barcode , sistem_q.Tarikh , sistem_q.No_Kenderaan , sistem_q.Bil_SKPE , pendaftaran_pintu.jenis_barangan, sistem_q.Pegawai , sistem_q.Status FROM SISTEM_Q left outer join pendaftaran_pintu on sistem_q.no_barcode=pendaftaran_pintu.nombor_barcode where pendaftaran_pintu.kod_jenis_urusan in ('003','018') ORDER BY Tarikh asc "
            Dim sql As String = "SELECT PENDAFTARAN_PINTU.Nombor_Barcode, PENDAFTARAN_PINTU.Tarikh_Masa_Masuk, PENDAFTARAN_PINTU.No_Kenderaan, ISNULL(SISTEM_Q.Bil_SKPI, 0) AS Bil_SKPI, ISNULL(SISTEM_Q.Bil_SKPE, 0) AS Bil_SKPE, PENDAFTARAN_PINTU.Jenis_Barangan, PENDAFTARAN_PINTU.EntryMasuk_By, SISTEM_Q.Pegawai, SISTEM_Q.Status FROM  PENDAFTARAN_PINTU LEFT OUTER JOIN SISTEM_Q ON PENDAFTARAN_PINTU.Nombor_Barcode = SISTEM_Q.No_Barcode where pendaftaran_pintu.kod_jenis_urusan in ('003','018') ORDER BY pendaftaran_pintu.Tarikh_masa_masuk asc "
            Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
            'myconn.Open()
            Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
            Dim ds As New DataSet()
            myAdapter.Fill(ds)
            DataGrid1.DataSource = ds
            DataGrid1.DataBind()
            Label2.Visible = True
            Label2.Text = "Senarai Eksport :"
            'myconn.Close()


        ElseIf Label1.Text = "Transit" And range.Checked = True Then
            Dim myconn As New SqlConnection(connectionstring)
            'Dim sql As String = "SELECT sistem_q.No_Barcode , sistem_q.Tarikh ,sistem_q.No_Kenderaan , sistem_q.Bil_SKPI , sistem_q.Bil_SKPE , pendaftaran_pintu.jenis_barangan, sistem_q.Pegawai , sistem_q.Status FROM SISTEM_Q left outer join pendaftaran_pintu on sistem_q.no_barcode=pendaftaran_pintu.nombor_barcode where sistem_q.tarikh between ('" & splitout(2) & "-" & splitout(1) & "-" & splitout(0) & "') and ('" & splitout1(2) & "-" & splitout1(1) & "-" & splitout1(0) & "" & " 23:59:59" & "') and pendaftaran_pintu.kod_jenis_urusan in ('004','005','006','010','011','012','013','014','015') ORDER BY Tarikh asc "
            Dim sql As String = "SELECT PENDAFTARAN_PINTU.Nombor_Barcode, PENDAFTARAN_PINTU.Tarikh_Masa_Masuk, PENDAFTARAN_PINTU.No_Kenderaan, ISNULL(SISTEM_Q.Bil_SKPI, 0) AS Bil_SKPI, ISNULL(SISTEM_Q.Bil_SKPE, 0) AS Bil_SKPE, PENDAFTARAN_PINTU.Jenis_Barangan, PENDAFTARAN_PINTU.EntryMasuk_By, SISTEM_Q.Pegawai, SISTEM_Q.Status FROM  PENDAFTARAN_PINTU LEFT OUTER JOIN SISTEM_Q ON PENDAFTARAN_PINTU.Nombor_Barcode = SISTEM_Q.No_Barcode where pendaftaran_pintu.kod_jenis_urusan in ('004','005','006','010','011','012','013','014','015') and PENDAFTARAN_PINTU.Tarikh_Masa_Masuk between ('" & splitout(2) & "-" & splitout(1) & "-" & splitout(0) & "') and ('" & splitout1(2) & "-" & splitout1(1) & "-" & splitout1(0) & "" & " 23:59:59" & "') ORDER BY pendaftaran_pintu.Tarikh_masa_masuk asc "
            Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
            'myconn.Open()
            Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
            Dim ds As New DataSet()
            myAdapter.Fill(ds)
            DataGrid1.DataSource = ds
            DataGrid1.DataBind()
            Label2.Visible = True
            Label2.Text = "Senarai Transit :"
            'myconn.Close()

        ElseIf Label1.Text = "Transit" Then
            Dim myconn As New SqlConnection(connectionstring)
            'Dim sql As String = "select sistem_q.No_Barcode , sistem_q.Tarikh , sistem_q.No_Kenderaan , sistem_q.Bil_SKPI , sistem_q.Bil_SKPE , pendaftaran_pintu.jenis_barangan, sistem_q.Pegawai , sistem_q.Status FROM SISTEM_Q inner JOIN PENDAFTARAN_PINTU ON SISTEM_Q.No_Barcode = PENDAFTARAN_PINTU.Nombor_Barcode where pendaftaran_pintu.kod_jenis_urusan in ('004','005','006','010','011','012','013','014','015') ORDER BY sistem_q.Tarikh asc "
            Dim sql As String = "SELECT PENDAFTARAN_PINTU.Nombor_Barcode, PENDAFTARAN_PINTU.Tarikh_Masa_Masuk, PENDAFTARAN_PINTU.No_Kenderaan, ISNULL(SISTEM_Q.Bil_SKPI, 0) AS Bil_SKPI, ISNULL(SISTEM_Q.Bil_SKPE, 0) AS Bil_SKPE, PENDAFTARAN_PINTU.Jenis_Barangan, PENDAFTARAN_PINTU.EntryMasuk_By, SISTEM_Q.Pegawai, SISTEM_Q.Status FROM  PENDAFTARAN_PINTU LEFT OUTER JOIN SISTEM_Q ON PENDAFTARAN_PINTU.Nombor_Barcode = SISTEM_Q.No_Barcode where pendaftaran_pintu.kod_jenis_urusan in ('004','005','006','010','011','012','013','014','015') ORDER BY pendaftaran_pintu.Tarikh_masa_masuk asc "
            Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
            'myconn.Open()
            Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
            Dim ds As New DataSet()
            myAdapter.Fill(ds)
            DataGrid1.DataSource = ds
            DataGrid1.DataBind()
            Label2.Visible = True
            Label2.Text = "Senarai Transit :"
            'myconn.Close()


        ElseIf Label1.Text = "Barangan Bukan Ikan" And range.Checked = True Then
            Dim myconn As New SqlConnection(connectionstring)
            'Dim sql As String = "SELECT sistem_q.No_Barcode , sistem_q.Tarikh , sistem_q.No_Kenderaan , sistem_q.Bil_SKPI , sistem_q.Bil_SKPE , pendaftaran_pintu.jenis_barangan, sistem_q.Pegawai , sistem_q.Status FROM SISTEM_Q left outer join pendaftaran_pintu on sistem_q.no_barcode=pendaftaran_pintu.nombor_barcode where pendaftaran_pintu.kod_jenis_urusan in ('007','008','009','017','019','020') and sistem_q.tarikh between ('" & splitout(2) & "-" & splitout(1) & "-" & splitout(0) & "') and ('" & splitout1(2) & "-" & splitout1(1) & "-" & splitout1(0) & "" & " 23:59:59" & "') ORDER BY pendaftaran_pintu.Tarikh_masa_masuk asc "
            Dim sql As String = "SELECT PENDAFTARAN_PINTU.Nombor_Barcode, PENDAFTARAN_PINTU.Tarikh_Masa_Masuk, PENDAFTARAN_PINTU.No_Kenderaan, ISNULL(SISTEM_Q.Bil_SKPI, 0) AS Bil_SKPI, ISNULL(SISTEM_Q.Bil_SKPE, 0) AS Bil_SKPE, PENDAFTARAN_PINTU.Jenis_Barangan, PENDAFTARAN_PINTU.EntryMasuk_By, SISTEM_Q.Pegawai, SISTEM_Q.Status FROM  PENDAFTARAN_PINTU LEFT OUTER JOIN SISTEM_Q ON PENDAFTARAN_PINTU.Nombor_Barcode = SISTEM_Q.No_Barcode where pendaftaran_pintu.kod_jenis_urusan in ('007','008','009','017','019','020') and PENDAFTARAN_PINTU.Tarikh_Masa_Masuk between ('" & splitout(2) & "-" & splitout(1) & "-" & splitout(0) & "') and ('" & splitout1(2) & "-" & splitout1(1) & "-" & splitout1(0) & "" & " 23:59:59" & "') ORDER BY pendaftaran_pintu.Tarikh_masa_masuk asc "
            Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
            'myconn.Open()
            Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
            Dim ds As New DataSet()
            myAdapter.Fill(ds)
            DataGrid1.DataSource = ds
            DataGrid1.DataBind()
            Label2.Visible = True
            Label2.Text = "Senarai Barangan Bukan Ikan :"
            'myconn.Close()


        ElseIf Label1.Text = "Barangan Bukan Ikan" Then
            Dim myconn As New SqlConnection(connectionstring)
            'Dim sql As String = "select sistem_q.No_Barcode , sistem_q.Tarikh , sistem_q.No_Kenderaan , sistem_q.Bil_SKPI , sistem_q.Bil_SKPE , pendaftaran_pintu.jenis_barangan, sistem_q.Pegawai , sistem_q.Status FROM SISTEM_Q inner JOIN PENDAFTARAN_PINTU ON SISTEM_Q.No_Barcode = PENDAFTARAN_PINTU.Nombor_Barcode where pendaftaran_pintu.kod_jenis_urusan in ('007','008','009','016','017','018','019','020') ORDER BY pendaftaran_pintu.Tarikh_masa_masuk asc "
            Dim sql As String = "SELECT PENDAFTARAN_PINTU.Nombor_Barcode, PENDAFTARAN_PINTU.Tarikh_Masa_Masuk, PENDAFTARAN_PINTU.No_Kenderaan, ISNULL(SISTEM_Q.Bil_SKPI, 0) AS Bil_SKPI, ISNULL(SISTEM_Q.Bil_SKPE, 0) AS Bil_SKPE, PENDAFTARAN_PINTU.Jenis_Barangan, PENDAFTARAN_PINTU.EntryMasuk_By, SISTEM_Q.Pegawai, SISTEM_Q.Status FROM  PENDAFTARAN_PINTU LEFT OUTER JOIN SISTEM_Q ON PENDAFTARAN_PINTU.Nombor_Barcode = SISTEM_Q.No_Barcode where pendaftaran_pintu.kod_jenis_urusan in ('007','008','009','017','019','020')  ORDER BY pendaftaran_pintu.Tarikh_masa_masuk asc "
            Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
            'myconn.Open()
            Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
            Dim ds As New DataSet()
            myAdapter.Fill(ds)
            DataGrid1.DataSource = ds
            DataGrid1.DataBind()
            Label2.Visible = True
            Label2.Text = "Senarai Barangan Bukan Ikan :"
            'myconn.Close()


        ElseIf Label1.Text = "Semua" And range.Checked = True Then
            Dim myconn As New SqlConnection(connectionstring)
            'Dim sql As String = "SELECT sistem_q.No_Barcode , sistem_q.Tarikh , sistem_q.No_Kenderaan , sistem_q.Bil_SKPI , pendaftaran_pintu.jenis_barangan, sistem_q.Pegawai , sistem_q.Status FROM SISTEM_Q inner join pendaftaran_pintu on sistem_q.no_barcode=pendaftaran_pintu.nombor_barcode where pendaftaran_pintu.kod_jenis_urusan in ('001','002','003','004','005','006','007','008','009','010','011','012','013','014','015','016','017','018','019','020') and pendaftaran_pintu.tarikh_masa_masuk between ('" & splitout(2) & "-" & splitout(1) & "-" & splitout(0) & "') and ('" & splitout1(2) & "-" & splitout1(1) & "-" & splitout1(0) & "" & " 23:59:59" & "') ORDER BY Tarikh asc"
            Dim sql As String = "SELECT PENDAFTARAN_PINTU.Nombor_Barcode, PENDAFTARAN_PINTU.Tarikh_Masa_Masuk, PENDAFTARAN_PINTU.No_Kenderaan, ISNULL(SISTEM_Q.Bil_SKPI, 0) AS Bil_SKPI, ISNULL(SISTEM_Q.Bil_SKPE, 0) AS Bil_SKPE, PENDAFTARAN_PINTU.Jenis_Barangan, PENDAFTARAN_PINTU.EntryMasuk_By, SISTEM_Q.Pegawai, SISTEM_Q.Status FROM  PENDAFTARAN_PINTU LEFT OUTER JOIN SISTEM_Q ON PENDAFTARAN_PINTU.Nombor_Barcode = SISTEM_Q.No_Barcode where PENDAFTARAN_PINTU.Tarikh_Masa_Masuk between ('" & splitout(2) & "-" & splitout(1) & "-" & splitout(0) & "') and ('" & splitout1(2) & "-" & splitout1(1) & "-" & splitout1(0) & "" & " 23:59:59" & "') ORDER BY pendaftaran_pintu.Tarikh_masa_masuk asc "
            Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
            'myconn.Open()
            Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
            Dim ds As New DataSet()
            myAdapter.Fill(ds)
            DataGrid1.DataSource = ds
            DataGrid1.DataBind()
            Label2.Visible = True
            Label2.Text = "Senarai Semua :"
            'myconn.Close()


        ElseIf Label1.Text = "Semua" Then
            Dim myconn As New SqlConnection(connectionstring)
            'Dim sql As String = "SELECT sistem_q.No_Barcode , sistem_q.Tarikh , sistem_q.No_Kenderaan , sistem_q.Bil_SKPI , pendaftaran_pintu.jenis_barangan, sistem_q.Pegawai , sistem_q.Status FROM SISTEM_Q inner join pendaftaran_pintu on sistem_q.no_barcode=pendaftaran_pintu.nombor_barcode ORDER BY Tarikh asc"
            Dim sql As String = "SELECT PENDAFTARAN_PINTU.Nombor_Barcode, PENDAFTARAN_PINTU.Tarikh_Masa_Masuk, PENDAFTARAN_PINTU.No_Kenderaan, ISNULL(SISTEM_Q.Bil_SKPI, 0) AS Bil_SKPI, ISNULL(SISTEM_Q.Bil_SKPE, 0) AS Bil_SKPE, PENDAFTARAN_PINTU.Jenis_Barangan, PENDAFTARAN_PINTU.EntryMasuk_By, SISTEM_Q.Pegawai, SISTEM_Q.Status FROM  PENDAFTARAN_PINTU LEFT OUTER JOIN SISTEM_Q ON PENDAFTARAN_PINTU.Nombor_Barcode = SISTEM_Q.No_Barcode ORDER BY pendaftaran_pintu.Tarikh_masa_masuk asc "
            Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
            'myconn.Open()
            Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
            Dim ds As New DataSet()
            myAdapter.Fill(ds)
            DataGrid1.DataSource = ds
            DataGrid1.DataBind()
            Label2.Visible = True
            Label2.Text = "Senarai Semua :"
            'myconn.Close()

        End If
    End Function

    Protected Sub reset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles reset.Click
        Server.Transfer("sistemq.aspx")
    End Sub
End Class