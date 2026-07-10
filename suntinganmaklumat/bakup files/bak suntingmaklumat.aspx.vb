Imports System
Imports System.Data
Imports System.Data.SQLClient
Imports System.Configuration
Imports System.IO
Imports System.Text

Partial Class suntingmaklumat
    Inherits System.Web.UI.Page

    Dim tbTextBox9 As HtmlInputText
    Dim tbTextBox10 As HtmlInputText
    Dim tbTextBox4 As HtmlInputText
    Public connectionstring As String = "Data Source=QUEST2;Initial Catalog=W-ICCS;User ID=sa;Password=quest2k"

    Public Sub Page_Load(ByVal Src As Object, ByVal E As EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            TextBox9.Attributes.Add("onBlur", "calculate1();")
            TextBox4.Attributes.Add("onBlur", "calculate1();")

            TextBox9.Attributes.Add("onKeyPress", "return maskKeyPress(event);")
            TextBox4.Attributes.Add("onKeyPress", "return maskKeyPress(event);")

            TextBox9.Attributes.Add("onKeyUp", "return validateInt1();")
            TextBox4.Attributes.Add("onKeyUp", "return validateInt1();")
        End If
    End Sub

    ' data view in dropdownlist 1 

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        If (DropDownList1.SelectedIndex <> 0) Then
            If DropDownList1.SelectedItem.Value = "01" Then
                show_agen()
                Label15.Visible = True
                Label15.Text = "Senarai Pilihan :"
                add.Visible = True
            ElseIf DropDownList1.SelectedItem.Value = "02.1" Then
                show_bentuk_ikan()
                Label15.Visible = True
                Label15.Text = "Senarai Pilihan :"
            ElseIf DropDownList1.SelectedItem.Value = "02" Then
                show_bentuk_ikan_new()
                Label15.Visible = True
                Label15.Text = "Senarai Pilihan :"
                add.Visible = False
            ElseIf DropDownList1.SelectedItem.Value = "02.2" Then
                show_bentuk_ikan_2()
                Label15.Visible = True
                Label15.Text = "Senarai Pilihan :"
            ElseIf DropDownList1.SelectedItem.Value = "02.3" Then
                show_bentuk_ikan_3()
                Label15.Visible = True
                Label15.Text = "Senarai Pilihan :"
            ElseIf DropDownList1.SelectedItem.Value = "02.4" Then
                show_bentuk_ikan_4()
                Label15.Visible = True
                Label15.Text = "Senarai Pilihan :"
            ElseIf DropDownList1.SelectedItem.Value = "02.5" Then
                show_bentuk_ikan_5()
                Label15.Visible = True
                Label15.Text = "Senarai Pilihan :"
            ElseIf DropDownList1.SelectedItem.Value = "03" Then
                show_Caj_Perkhidmatan()
                Label15.Visible = True
                Label15.Text = "Senarai Pilihan :"
                add.Visible = True
            ElseIf DropDownList1.SelectedItem.Value = "04" Then
                show_cara_pengangkutan()
                Label15.Visible = True
                Label15.Text = "Senarai Pilihan :"
                add.Visible = True
            ElseIf DropDownList1.SelectedItem.Value = "05" Then
                show_destinasi_pasar()
                Label15.Visible = True
                Label15.Text = "Senarai Pilihan :"
                add.Visible = True
            ElseIf DropDownList1.SelectedItem.Value = "06" Then
                show_gred()
                Label15.Visible = True
                Label15.Text = "Senarai Pilihan :"
                add.Visible = True
            ElseIf DropDownList1.SelectedItem.Value = "07" Then
                show_caj_ikan()
                datagridvalue()
                Label15.Visible = True
                Label15.Text = "Senarai Pilihan :"
                add.Visible = True
            ElseIf DropDownList1.SelectedItem.Value = "08" Then
                show_jenis()
                Label15.Visible = True
                Label15.Text = "Senarai Pilihan :"
                add.Visible = True
            ElseIf DropDownList1.SelectedItem.Value = "09" Then
                show_jenis_ikan()
                Label15.Visible = True
                Label15.Text = "Senarai Pilihan :"
                add.Visible = True
            ElseIf DropDownList1.SelectedItem.Value = "010" Then
                show_jenis_pengangkutan()
                Label15.Visible = True
                Label15.Text = "Senarai Pilihan :"
                add.Visible = True
            ElseIf DropDownList1.SelectedItem.Value = "011" Then
                show_jenis_urusan()
                Label15.Visible = True
                Label15.Text = "Senarai Pilihan :"
                add.Visible = True
            ElseIf DropDownList1.SelectedItem.Value = "012" Then
                show_kategori()
                Label15.Visible = True
                Label15.Text = "Senarai Pilihan :"
                add.Visible = True
            ElseIf DropDownList1.SelectedItem.Value = "013" Then
                show_kumpulan()
                Label15.Visible = True
                Label15.Text = "Senarai Pilihan :"
                add.Visible = True
            ElseIf DropDownList1.SelectedItem.Value = "014" Then
                show_lesen()
                Label15.Visible = True
                Label15.Text = "Senarai Pilihan :"
                add.Visible = True
            ElseIf DropDownList1.SelectedItem.Value = "015" Then
                show_negara()
                Label15.Visible = True
                Label15.Text = "Senarai Pilihan :"
                add.Visible = True
            ElseIf DropDownList1.SelectedItem.Value = "016" Then
                show_negeri()
                Label15.Visible = True
                Label15.Text = "Senarai Pilihan :"
                add.Visible = True
            ElseIf DropDownList1.SelectedItem.Value = "017" Then
                show_pengeksport_malaysia()
                Label15.Visible = True
                Label15.Text = "Senarai Pilihan :"
                add.Visible = True
            ElseIf DropDownList1.SelectedItem.Value = "018" Then
                show_pengimport_malaysia()
                Label15.Visible = True
                Label15.Text = "Senarai Pilihan :"
                add.Visible = True
            ElseIf DropDownList1.SelectedItem.Value = "019" Then
                show_pengeksport_thai()
                Label15.Visible = True
                Label15.Text = "Senarai Pilihan :"
                add.Visible = True
            ElseIf DropDownList1.SelectedItem.Value = "020" Then
                show_pengimport_thai()
                Label15.Visible = True
                Label15.Text = "Senarai Pilihan :"
                add.Visible = True
            ElseIf DropDownList1.SelectedItem.Value = "021" Then
                show_komplex()
                Label15.Visible = True
                Label15.Text = "Senarai Pilihan :"
                add.Visible = True
            ElseIf DropDownList1.SelectedItem.Value = "022.1" Then
                show_spesis1()
                Label15.Visible = True
                Label15.Text = "Senarai Pilihan :"
                add.Visible = True
            ElseIf DropDownList1.SelectedItem.Value = "022.2" Then
                show_spesis2()
                Label15.Visible = True
                Label15.Text = "Senarai Pilihan :"
                add.Visible = True
            ElseIf DropDownList1.SelectedItem.Value = "022.3" Then
                show_spesis3()
                Label15.Visible = True
                Label15.Text = "Senarai Pilihan :"
                add.Visible = True
            ElseIf DropDownList1.SelectedItem.Value = "022.4" Then
                show_spesis4()
                Label15.Visible = True
                Label15.Text = "Senarai Pilihan :"
                add.Visible = True
            ElseIf DropDownList1.SelectedItem.Value = "022.5" Then
                show_spesis5()
                Label15.Visible = True
                Label15.Text = "Senarai Pilihan :"
                add.Visible = True
            ElseIf DropDownList1.SelectedItem.Value = "022.6" Then
                show_spesis6()
                Label15.Visible = True
                Label15.Text = "Senarai Pilihan :"
                add.Visible = True
            ElseIf DropDownList1.SelectedItem.Value = "022.7" Then
                show_spesis7()
                Label15.Visible = True
                Label15.Text = "Senarai Pilihan :"
                add.Visible = True
            ElseIf DropDownList1.SelectedItem.Value = "022.8" Then
                show_spesis8()
                Label15.Visible = True
                Label15.Text = "Senarai Pilihan :"
                add.Visible = True
            ElseIf DropDownList1.SelectedItem.Value = "023" Then
                show_epermit()
                Label15.Visible = True
                Label15.Text = "Senarai Pilihan :"
                add.Visible = True
            Else
                Label2.Visible = True
                Label2.Text = "-- NO DATA --"
                Label15.Visible = False
                Label15.Text = "Senarai Pilihan :"

            End If
            DropDownList1.Enabled = False
            cancel.Visible = True
            'add.Visible = True

        End If
    End Sub

    Dim nak As String

    ' dropdownlist 2 view

    Protected Sub DropDownList2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList2.SelectedIndexChanged
        Label6.Text = DropDownList2.SelectedItem.Value
        nak = Label6.Text
        If DropDownList2.SelectedIndex <> 0 Then
            TextBox1.ReadOnly = False
            If Label7.Text = "01" Then
                view_agent(nak)
            ElseIf Label7.Text = "02.1" Or datadetail.Text = "02.1" Then
                view_bentuk_ikan_1(nak)
            ElseIf Label7.Text = "02.2" Or datadetail.Text = "02.2" Then
                view_bentuk_ikan_2(nak)
            ElseIf Label7.Text = "02.3" Or datadetail.Text = "02.3" Then
                view_bentuk_ikan_3(nak)
            ElseIf Label7.Text = "02.4" Or datadetail.Text = "02.4" Then
                view_bentuk_ikan_4(nak)
            ElseIf Label7.Text = "02.5" Or datadetail.Text = "02.5" Then
                view_bentuk_ikan_5(nak)
            ElseIf Label7.Text = "03" Then
                view_caj_perkhidmatan(nak)
            ElseIf Label7.Text = "04" Then
                view_cara_pengangkutan(nak)
            ElseIf Label7.Text = "05" Then
                view_destinasi_pasar(nak)
            ElseIf Label7.Text = "06" Then
                view_gred_saiz(nak)
            ElseIf Label7.Text = "07" Then
                view_caj_ikan(nak)
            ElseIf Label7.Text = "08" Then
                view_jenis(nak)
            ElseIf Label7.Text = "09" Then
                view_jenis_ikan(nak)
            ElseIf Label7.Text = "010" Then
                view_jenis_pengangkutan(nak)
            ElseIf Label7.Text = "011" Then
                view_jenis_urusan(nak)
            ElseIf Label7.Text = "012" Then
                view_kategori(nak)
            ElseIf Label7.Text = "013" Then
                view_kumpulan(nak)
            ElseIf Label7.Text = "014" Then
                view_lesen(nak)
            ElseIf Label7.Text = "015" Then
                view_negara(nak)
            ElseIf Label7.Text = "016" Then
                view_negeri(nak)
            ElseIf Label7.Text = "017" Then
                view_pengeksport_malaysia(nak)
            ElseIf Label7.Text = "018" Then
                view_pengimport_malaysia(nak)
            ElseIf Label7.Text = "019" Then
                view_pengeksport_thai(nak)
            ElseIf Label7.Text = "020" Then
                view_pengimport_thai(nak)
            ElseIf Label7.Text = "021" Then
                view_komplex(nak)
            ElseIf Label7.Text = "022.1" Then
                view_spesis1(nak)
            ElseIf Label7.Text = "022.2" Then
                view_spesis2(nak)
            ElseIf Label7.Text = "022.3" Then
                view_spesis3(nak)
            ElseIf Label7.Text = "022.4" Then
                view_spesis4(nak)
            ElseIf Label7.Text = "022.5" Then
                view_spesis5(nak)
            ElseIf Label7.Text = "022.6" Then
                view_spesis6(nak)
            ElseIf Label7.Text = "022.7" Then
                view_spesis7(nak)
            ElseIf Label7.Text = "022.8" Then
                view_spesis8(nak)
            ElseIf Label7.Text = "023" Then
                view_epermit(nak)
            Else
            End If
            End If
    End Sub

    Protected Sub list5_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles list5.SelectedIndexChanged
        Label6.Text = DropDownList1.SelectedItem.Value
        nak = Label6.Text
        If list4.SelectedIndex <> 0 Then
            TextBox1.ReadOnly = False
            If list5.SelectedItem.Value = "02.1" Then
                view_bentuk_ikan_detail()
                add.Visible = True
            ElseIf list5.SelectedItem.Value = "02.2" Then
                view_bentuk_ikan_detail_2()
                add.Visible = True
            ElseIf list5.SelectedItem.Value = "02.3" Then
                view_bentuk_ikan_detail_3()
                add.Visible = True
            ElseIf list5.SelectedItem.Value = "02.4" Then
                view_bentuk_ikan_detail_4()
                add.Visible = True
            ElseIf list5.SelectedItem.Value = "02.5" Then
                view_bentuk_ikan_detail_5()
                add.Visible = True
            Else
            End If
        End If
    End Sub

    Function view_bentuk_ikan_detail()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = False
        TextBox3.Enabled = False
        TextBox4.Visible = False
        TextBox4.Enabled = False
        TextBox5.Visible = False
        TextBox5.Enabled = False
        Label1.Visible = True
        Label1.Text = "Kod Bentuk ikan :"
        Label2.Visible = True
        Label2.Text = "Nama Bentuk ikan :"
        Label3.Visible = False
        Label3.Text = "Alamat Agen :"
        Label4.Visible = False
        Label4.Text = "Deposit Semasa :"
        Label5.Visible = False
        Label5.Text = "Transaksi Semasa :"

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_bentuk_ikan_1, nama_bentuk_ikan_1 FROM bentuk_ikan_1 where kod_bentuk_ikan_1 <>'00000'ORDER BY nama_bentuk_ikan_1", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("nama_bentuk_ikan_1")
            item2.Value = SqlRdr.Item("kod_bentuk_ikan_1")
            DropDownList2.Items.Add(item2)
            '   label8.Text = DropDownList2.Items(item2)
            DropDownList2.Visible = True
            list5.Enabled = False
        End While
        DropDownList2.Items.Insert(0, "-- Select Kategori Ikan Basah --")
        Label7.Text = DropDownList1.SelectedItem.Value
        datadetail.Text = list5.SelectedItem.Value

    End Function

    Function view_bentuk_ikan_detail_2()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = False
        TextBox3.Enabled = False
        TextBox4.Visible = False
        TextBox4.Enabled = False
        TextBox5.Visible = False
        TextBox5.Enabled = False
        Label1.Visible = True
        Label1.Text = "Kod Bentuk ikan :"
        Label2.Visible = True
        Label2.Text = "Nama Bentuk ikan :"
        Label3.Visible = False
        Label3.Text = "Alamat Agen :"
        Label4.Visible = False
        Label4.Text = "Deposit Semasa :"
        Label5.Visible = False
        Label5.Text = "Transaksi Semasa :"

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_bentuk_ikan_2, nama_bentuk_ikan_2 FROM bentuk_ikan_2 where kod_bentuk_ikan_2 <>'00000'ORDER BY nama_bentuk_ikan_2", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("nama_bentuk_ikan_2")
            item2.Value = SqlRdr.Item("kod_bentuk_ikan_2")
            DropDownList2.Items.Add(item2)
            '   label8.Text = DropDownList2.Items(item2)
            DropDownList2.Visible = True
            list5.Enabled = False
        End While
        DropDownList2.Items.Insert(0, "-- Select Kategori Ikan Sejuk Beku --")
        Label7.Text = DropDownList1.SelectedItem.Value
        datadetail.Text = list5.SelectedItem.Value

    End Function

    Function view_bentuk_ikan_detail_3()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = False
        TextBox3.Enabled = False
        TextBox4.Visible = False
        TextBox4.Enabled = False
        TextBox5.Visible = False
        TextBox5.Enabled = False
        Label1.Visible = True
        Label1.Text = "Kod Bentuk ikan :"
        Label2.Visible = True
        Label2.Text = "Nama Bentuk ikan :"
        Label3.Visible = False
        Label3.Text = "Alamat Agen :"
        Label4.Visible = False
        Label4.Text = "Deposit Semasa :"
        Label5.Visible = False
        Label5.Text = "Transaksi Semasa :"

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_bentuk_ikan_3, nama_bentuk_ikan_3 FROM bentuk_ikan_3 where kod_bentuk_ikan_3 <>'00000'ORDER BY nama_bentuk_ikan_3", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("nama_bentuk_ikan_3")
            item2.Value = SqlRdr.Item("kod_bentuk_ikan_3")
            DropDownList2.Items.Add(item2)
            '   label8.Text = DropDownList2.Items(item2)
            DropDownList2.Visible = True
            list5.Enabled = False
        End While
        DropDownList2.Items.Insert(0, "-- Select Kategori Ikan Hidup --")
        Label7.Text = DropDownList1.SelectedItem.Value
        datadetail.Text = list5.SelectedItem.Value

    End Function

    Function view_bentuk_ikan_detail_4()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = False
        TextBox3.Enabled = False
        TextBox4.Visible = False
        TextBox4.Enabled = False
        TextBox5.Visible = False
        TextBox5.Enabled = False
        Label1.Visible = True
        Label1.Text = "Kod Bentuk ikan :"
        Label2.Visible = True
        Label2.Text = "Nama Bentuk ikan :"
        Label3.Visible = False
        Label3.Text = "Alamat Agen :"
        Label4.Visible = False
        Label4.Text = "Deposit Semasa :"
        Label5.Visible = False
        Label5.Text = "Transaksi Semasa :"

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_bentuk_ikan_4, nama_bentuk_ikan_4 FROM bentuk_ikan_4 where kod_bentuk_ikan_4 <>'00000'ORDER BY nama_bentuk_ikan_4", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("nama_bentuk_ikan_4")
            item2.Value = SqlRdr.Item("kod_bentuk_ikan_4")
            DropDownList2.Items.Add(item2)
            '   label8.Text = DropDownList2.Items(item2)
            DropDownList2.Visible = True
            list5.Enabled = False
        End While
        DropDownList2.Items.Insert(0, "-- Select Kategori Proses/Produk Perikanan --")
        Label7.Text = DropDownList1.SelectedItem.Value
        datadetail.Text = list5.SelectedItem.Value

    End Function

    Function view_bentuk_ikan_detail_5()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = False
        TextBox3.Enabled = False
        TextBox4.Visible = False
        TextBox4.Enabled = False
        TextBox5.Visible = False
        TextBox5.Enabled = False
        Label1.Visible = True
        Label1.Text = "Kod Bentuk ikan :"
        Label2.Visible = True
        Label2.Text = "Nama Bentuk ikan :"
        Label3.Visible = False
        Label3.Text = "Alamat Agen :"
        Label4.Visible = False
        Label4.Text = "Deposit Semasa :"
        Label5.Visible = False
        Label5.Text = "Transaksi Semasa :"

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_bentuk_ikan_5, nama_bentuk_ikan_5 FROM bentuk_ikan_5 where kod_bentuk_ikan_5 <>'00000'ORDER BY nama_bentuk_ikan_5", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("nama_bentuk_ikan_5")
            item2.Value = SqlRdr.Item("kod_bentuk_ikan_5")
            DropDownList2.Items.Add(item2)
            '   label8.Text = DropDownList2.Items(item2)
            DropDownList2.Visible = True
            list5.Enabled = False
        End While
        DropDownList2.Items.Insert(0, "-- Select Kategori Produk Perikanan Yang Lain --")
        Label7.Text = DropDownList1.SelectedItem.Value
        datadetail.Text = list5.SelectedItem.Value

    End Function

    ' data view in dropdownlist 2

    Function show_agen()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = True
        TextBox3.Enabled = True
        TextBox4.Visible = True
        TextBox4.Enabled = False
        TextBox5.Visible = True
        TextBox5.Enabled = False
        Label1.Visible = True
        Label1.Text = "Kod Agen :"
        Label2.Visible = True
        Label2.Text = "Nama Agen :"
        Label3.Visible = True
        Label3.Text = "Alamat Agen :"
        Label4.Visible = True
        Label4.Text = "Deposit Semasa :"
        Label5.Visible = True
        Label5.Text = "Transaksi Semasa :"

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_agen_pengangkutan, nama_agen_pengangkutan FROM agen_pengangkutan where kod_agen_pengangkutan <>'00000'ORDER BY nama_agen_pengangkutan", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("nama_agen_pengangkutan")
            item2.Value = SqlRdr.Item("kod_agen_pengangkutan")
            DropDownList2.Items.Add(item2)
            DropDownList2.Visible = True
        End While
        DropDownList2.Items.Insert(0, "-- Select Agen Pengangkutan --")
        Label7.Text = DropDownList1.SelectedItem.Value
    End Function

    Function show_bentuk_ikan_new()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = False
        TextBox3.Enabled = False
        TextBox4.Visible = False
        TextBox4.Enabled = False
        TextBox5.Visible = False
        TextBox5.Enabled = False
        Label1.Visible = True
        Label1.Text = "Kod Bentuk ikan :"
        Label2.Visible = True
        Label2.Text = "Nama Bentuk ikan :"
        Label3.Visible = False
        Label3.Text = "Alamat Agen :"
        Label4.Visible = False
        Label4.Text = "Deposit Semasa :"
        Label5.Visible = False
        Label5.Text = "Transaksi Semasa :"
        list5.Visible = True
        Label7.Text = DropDownList1.SelectedItem.Value
        datadetail.Text = list5.SelectedItem.Value

    End Function

    Function show_bentuk_ikan()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = False
        TextBox3.Enabled = False
        TextBox4.Visible = False
        TextBox4.Enabled = False
        TextBox5.Visible = False
        TextBox5.Enabled = False
        Label1.Visible = True
        Label1.Text = "Kod Bentuk ikan :"
        Label2.Visible = True
        Label2.Text = "Nama Bentuk ikan :"
        Label3.Visible = False
        Label3.Text = "Alamat Agen :"
        Label4.Visible = False
        Label4.Text = "Deposit Semasa :"
        Label5.Visible = False
        Label5.Text = "Transaksi Semasa :"

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_bentuk_ikan_1, nama_bentuk_ikan_1 FROM bentuk_ikan_1 where kod_bentuk_ikan_1 <>'00000'ORDER BY nama_bentuk_ikan_1", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("nama_bentuk_ikan_1")
            item2.Value = SqlRdr.Item("kod_bentuk_ikan_1")
            DropDownList2.Items.Add(item2)
            '   label8.Text = DropDownList2.Items(item2)
            DropDownList2.Visible = True
        End While
        DropDownList2.Items.Insert(0, "-- Select Kategori Ikan Basah --")
        Label7.Text = DropDownList1.SelectedItem.Value
        Label8.Text = DropDownList2.SelectedItem.Value

    End Function

    Function show_bentuk_ikan_2()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = False
        TextBox3.Enabled = False
        TextBox4.Visible = False
        TextBox4.Enabled = False
        TextBox5.Visible = False
        TextBox5.Enabled = False
        Label1.Visible = True
        Label1.Text = "Kod Bentuk ikan :"
        Label2.Visible = True
        Label2.Text = "Nama Bentuk ikan :"
        Label3.Visible = False
        Label3.Text = "Alamat Agen :"
        Label4.Visible = False
        Label4.Text = "Deposit Semasa :"
        Label5.Visible = False
        Label5.Text = "Transaksi Semasa :"

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_bentuk_ikan_2, nama_bentuk_ikan_2 FROM bentuk_ikan_2 where kod_bentuk_ikan_2 <>'00000'ORDER BY nama_bentuk_ikan_2", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("nama_bentuk_ikan_2")
            item2.Value = SqlRdr.Item("kod_bentuk_ikan_2")
            DropDownList2.Items.Add(item2)
            '   label8.Text = DropDownList2.Items(item2)
            DropDownList2.Visible = True
        End While
        DropDownList2.Items.Insert(0, "-- Select Kategori Ikan Sejuk Beku --")
        Label7.Text = DropDownList1.SelectedItem.Value
        Label8.Text = DropDownList2.SelectedItem.Value

    End Function

    Function show_bentuk_ikan_3()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = False
        TextBox3.Enabled = False
        TextBox4.Visible = False
        TextBox4.Enabled = False
        TextBox5.Visible = False
        TextBox5.Enabled = False
        Label1.Visible = True
        Label1.Text = "Kod Bentuk ikan :"
        Label2.Visible = True
        Label2.Text = "Nama Bentuk ikan :"
        Label3.Visible = False
        Label3.Text = "Alamat Agen :"
        Label4.Visible = False
        Label4.Text = "Deposit Semasa :"
        Label5.Visible = False
        Label5.Text = "Transaksi Semasa :"

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_bentuk_ikan_3, nama_bentuk_ikan_3 FROM bentuk_ikan_3 where kod_bentuk_ikan_3 <>'00000'ORDER BY nama_bentuk_ikan_3", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("nama_bentuk_ikan_3")
            item2.Value = SqlRdr.Item("kod_bentuk_ikan_3")
            DropDownList2.Items.Add(item2)
            '   label8.Text = DropDownList2.Items(item2)
            DropDownList2.Visible = True
        End While
        DropDownList2.Items.Insert(0, "-- Select Kategori Ikan Hidup --")
        Label7.Text = DropDownList1.SelectedItem.Value
        Label8.Text = DropDownList2.SelectedItem.Value

    End Function

    Function show_bentuk_ikan_4()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = False
        TextBox3.Enabled = False
        TextBox4.Visible = False
        TextBox4.Enabled = False
        TextBox5.Visible = False
        TextBox5.Enabled = False
        Label1.Visible = True
        Label1.Text = "Kod Bentuk ikan :"
        Label2.Visible = True
        Label2.Text = "Nama Bentuk ikan :"
        Label3.Visible = False
        Label3.Text = "Alamat Agen :"
        Label4.Visible = False
        Label4.Text = "Deposit Semasa :"
        Label5.Visible = False
        Label5.Text = "Transaksi Semasa :"

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_bentuk_ikan_4, nama_bentuk_ikan_4 FROM bentuk_ikan_4 where kod_bentuk_ikan_4 <>'00000'ORDER BY nama_bentuk_ikan_4", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("nama_bentuk_ikan_4")
            item2.Value = SqlRdr.Item("kod_bentuk_ikan_4")
            DropDownList2.Items.Add(item2)
            '   label8.Text = DropDownList2.Items(item2)
            DropDownList2.Visible = True
        End While
        DropDownList2.Items.Insert(0, "-- Select Kategori Proses/Produk Perikanan --")
        Label7.Text = DropDownList1.SelectedItem.Value
        Label8.Text = DropDownList2.SelectedItem.Value

    End Function

    Function show_bentuk_ikan_5()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = False
        TextBox3.Enabled = False
        TextBox4.Visible = False
        TextBox4.Enabled = False
        TextBox5.Visible = False
        TextBox5.Enabled = False
        Label1.Visible = True
        Label1.Text = "Kod Bentuk ikan :"
        Label2.Visible = True
        Label2.Text = "Nama Bentuk ikan :"
        Label3.Visible = False
        Label3.Text = "Alamat Agen :"
        Label4.Visible = False
        Label4.Text = "Deposit Semasa :"
        Label5.Visible = False
        Label5.Text = "Transaksi Semasa :"

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_bentuk_ikan_5, nama_bentuk_ikan_5 FROM bentuk_ikan_5 where kod_bentuk_ikan_5 <>'00000'ORDER BY nama_bentuk_ikan_5", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("nama_bentuk_ikan_5")
            item2.Value = SqlRdr.Item("kod_bentuk_ikan_5")
            DropDownList2.Items.Add(item2)
            '   label8.Text = DropDownList2.Items(item2)
            DropDownList2.Visible = True
        End While
        DropDownList2.Items.Insert(0, "-- Select Kategori Produk Perikanan Yang Lain --")
        Label7.Text = DropDownList1.SelectedItem.Value
        Label8.Text = DropDownList2.SelectedItem.Value

    End Function

    Function show_Caj_Perkhidmatan()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = True
        TextBox3.Enabled = True
        TextBox4.Visible = True
        TextBox4.Enabled = True
        TextBox5.Visible = True
        TextBox5.Enabled = True
        Label1.Visible = True
        Label1.Text = "Kod Caj :"
        Label2.Visible = True
        Label2.Text = "Nama Caj :"
        Label3.Visible = True
        Label3.Text = "Kadar Caj :"
        Label4.Visible = True
        Label4.Text = "Cara Pembayaran :"
        Label5.Visible = True
        Label5.Text = "Dicaj Oleh :"

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_caj, nama_caj FROM caj_perkhidmatan where kod_caj <>'00000'ORDER BY nama_caj", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("nama_caj")
            item2.Value = SqlRdr.Item("kod_caj")
            DropDownList2.Items.Add(item2)
            '   label8.Text = DropDownList2.Items(item2)
            DropDownList2.Visible = True
        End While
        DropDownList2.Items.Insert(0, "-- Select Kategori Caj_Perkhidmatan --")
        Label7.Text = DropDownList1.SelectedItem.Value
        Label8.Text = DropDownList2.SelectedItem.Value

    End Function

    Function show_cara_pengangkutan()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = False
        TextBox3.Enabled = False
        TextBox4.Visible = False
        TextBox4.Enabled = False
        TextBox5.Visible = False
        TextBox5.Enabled = False
        Label1.Visible = True
        Label1.Text = "Kod Cara Pengangkutan :"
        Label2.Visible = True
        Label2.Text = "Nama Cara Pengangkutan :"
        Label3.Visible = False
        Label3.Text = "Kadar Caj :"
        Label4.Visible = False
        Label4.Text = "Cara Pembayaran :"
        Label5.Visible = False
        Label5.Text = "Dicaj Oleh :"

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_cara_pengangkutan, nama_cara_pengangkutan FROM cara_pengangkutan where kod_cara_pengangkutan <>'00000'ORDER BY nama_cara_pengangkutan", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("nama_cara_pengangkutan")
            item2.Value = SqlRdr.Item("kod_cara_pengangkutan")
            DropDownList2.Items.Add(item2)
            '   label8.Text = DropDownList2.Items(item2)
            DropDownList2.Visible = True
        End While
        DropDownList2.Items.Insert(0, "-- Select Kategori cara Pengangkutan --")
        Label7.Text = DropDownList1.SelectedItem.Value
        Label8.Text = DropDownList2.SelectedItem.Value

    End Function

    Function show_destinasi_pasar()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = False
        TextBox3.Enabled = False
        TextBox4.Visible = False
        TextBox4.Enabled = False
        TextBox5.Visible = False
        TextBox5.Enabled = False
        Label1.Visible = True
        Label1.Text = "Kod Pasar :"
        Label2.Visible = True
        Label2.Text = "Nama Pasar :"
        Label3.Visible = False
        Label3.Text = "Kadar Caj :"
        Label4.Visible = False
        Label4.Text = "Cara Pembayaran :"
        Label5.Visible = False
        Label5.Text = "Dicaj Oleh :"

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_pasar, nama_pasar FROM destinasi_pasar where kod_pasar <>'00000'ORDER BY nama_pasar", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("nama_pasar")
            item2.Value = SqlRdr.Item("kod_pasar")
            DropDownList2.Items.Add(item2)
            '   label8.Text = DropDownList2.Items(item2)
            DropDownList2.Visible = True
        End While
        DropDownList2.Items.Insert(0, "-- Select Kategori Destinasi Pasar --")
        Label7.Text = DropDownList1.SelectedItem.Value
        Label8.Text = DropDownList2.SelectedItem.Value

    End Function

    Function show_gred()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = False
        TextBox3.Enabled = False
        TextBox4.Visible = False
        TextBox4.Enabled = False
        TextBox5.Visible = False
        TextBox5.Enabled = False
        Label1.Visible = True
        Label1.Text = "Kod Gred saiz :"
        Label2.Visible = True
        Label2.Text = "Nama Gred saiz :"
        Label3.Visible = False
        Label3.Text = "Kadar Caj :"
        Label4.Visible = False
        Label4.Text = "Cara Pembayaran :"
        Label5.Visible = False
        Label5.Text = "Dicaj Oleh :"

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_Gredsaiz, nama_Gredsaiz FROM gred_saiz where kod_Gredsaiz <>'00000'ORDER BY nama_Gredsaiz", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("nama_Gredsaiz")
            item2.Value = SqlRdr.Item("kod_Gredsaiz")
            DropDownList2.Items.Add(item2)
            '   label8.Text = DropDownList2.Items(item2)
            DropDownList2.Visible = True
        End While
        DropDownList2.Items.Insert(0, "-- Select Kategori Gred / Saiz --")
        Label7.Text = DropDownList1.SelectedItem.Value
        Label8.Text = DropDownList2.SelectedItem.Value

    End Function

    Function show_caj_ikan()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = True
        TextBox3.Enabled = True
        TextBox4.Visible = True
        TextBox4.Enabled = True
        TextBox5.Visible = True
        TextBox5.Enabled = True
        TextBox9.Visible = True
        TextBox9.Enabled = True
        TextBox10.Visible = True
        TextBox10.Enabled = True
        Label1.Visible = True
        Label1.Text = "Id:"
        Label2.Visible = True
        Label2.Text = "Kategori Ikan :"
        Label3.Visible = True
        Label3.Text = "jenis Urusan :"
        Label4.Visible = True
        Label4.Text = "Kadar Peti Kecil:"
        Label5.Visible = True
        Label5.Text = "Kadar Peti Besar :"
        Label9.Visible = True
        Label9.Text = "Kadar Ekor:"
        Label10.Visible = True
        Label10.Text = "Kadar_kuantiti :"

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT id, kategori_ikan FROM ikan_caj where id <>'00000'ORDER BY id", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("id")
            item2.Value = SqlRdr.Item("id")
            DropDownList2.Items.Add(item2)
            '   label8.Text = DropDownList2.Items(item2)
            DropDownList2.Visible = True
        End While
        DropDownList2.Items.Insert(0, "-- Select Kategori Caj Ikan --")
        Label7.Text = DropDownList1.SelectedItem.Value
        Label8.Text = DropDownList2.SelectedItem.Value

    End Function

    Function show_jenis()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = False
        TextBox3.Enabled = False
        TextBox4.Visible = False
        TextBox4.Enabled = False
        TextBox5.Visible = False
        TextBox5.Enabled = False
        TextBox9.Visible = False
        TextBox9.Enabled = False
        TextBox10.Visible = False
        TextBox10.Enabled = False
        Label1.Visible = True
        Label1.Text = "Kod Barangan:"
        Label2.Visible = True
        Label2.Text = "Nama Barangan :"
        Label3.Visible = False
        Label3.Text = "jenis Urusan :"
        Label4.Visible = False
        Label4.Text = "Kadar Peti Kecil:"
        Label5.Visible = False
        Label5.Text = "Kadar Peti Besar :"
        Label9.Visible = False
        Label9.Text = "Kadar Ekor:"
        Label10.Visible = False
        Label10.Text = "Kadar_kuantiti :"

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_barangan, nama_barangan FROM jenis_barangan where kod_barangan <>'00000'ORDER BY nama_barangan", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("nama_barangan")
            item2.Value = SqlRdr.Item("kod_barangan")
            DropDownList2.Items.Add(item2)
            '   label8.Text = DropDownList2.Items(item2)
            DropDownList2.Visible = True
        End While
        DropDownList2.Items.Insert(0, "-- Select Kategori jenis Barangan --")
        Label7.Text = DropDownList1.SelectedItem.Value
        Label8.Text = DropDownList2.SelectedItem.Value

    End Function

    Function show_jenis_ikan()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = True
        TextBox3.Enabled = True
        TextBox4.Visible = True
        TextBox4.Enabled = True
        TextBox5.Visible = False
        TextBox5.Enabled = False
        TextBox9.Visible = False
        TextBox9.Enabled = False
        TextBox10.Visible = False
        TextBox10.Enabled = False
        Label1.Visible = True
        Label1.Text = "Kod BKH:"
        Label2.Visible = True
        Label2.Text = "Kod Ikan :"
        Label3.Visible = True
        Label3.Text = "Nama BKH :"
        Label4.Visible = True
        Label4.Text = "Harga BKH:"
        Label5.Visible = False
        Label5.Text = "Kod Kategori Ikan :"
        Label9.Visible = False
        Label9.Text = "Kod Kumpulan:"
        Label10.Visible = False
        Label10.Text = "Kod Spesis :"
      

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_ikan, nama_bkh FROM jenis_ikan where kod_ikan <>'00000'ORDER BY nama_bkh", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("nama_bkh")
            item2.Value = SqlRdr.Item("kod_ikan")
            DropDownList2.Items.Add(item2)
            '   label8.Text = DropDownList2.Items(item2)
            DropDownList2.Visible = True
        End While
        DropDownList2.Items.Insert(0, "-- Select jenis Ikan --")
        Label7.Text = DropDownList1.SelectedItem.Value
        Label8.Text = DropDownList2.SelectedItem.Value

    End Function

    Function show_jenis_pengangkutan()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = True
        TextBox3.Enabled = True
        TextBox4.Visible = False
        TextBox4.Enabled = False
        TextBox5.Visible = False
        TextBox5.Enabled = False
        TextBox9.Visible = False
        TextBox9.Enabled = False
        TextBox10.Visible = False
        TextBox10.Enabled = False
        Label1.Visible = True
        Label1.Text = "Kod Pengangkutan:"
        Label2.Visible = True
        Label2.Text = "Nama Pengangkutan :"
        Label3.Visible = True
        Label3.Text = "Caj pengangkutan :"
        Label4.Visible = False
        Label4.Text = "Harga BKH:"
        Label5.Visible = False
        Label5.Text = "Kod Kategori Ikan :"
        Label9.Visible = False
        Label9.Text = "Kod Kumpulan:"
        Label10.Visible = False
        Label10.Text = "Kod Spesis :"


        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT Kod_Pengangkutan, nama_Pengangkutan FROM jenis_pengangkutan where Kod_Pengangkutan <>'00000'ORDER BY nama_Pengangkutan", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("nama_Pengangkutan")
            item2.Value = SqlRdr.Item("Kod_Pengangkutan")
            DropDownList2.Items.Add(item2)
            '   label8.Text = DropDownList2.Items(item2)
            DropDownList2.Visible = True
        End While
        DropDownList2.Items.Insert(0, "-- Select Kategori jenis Pengangkutan --")
        Label7.Text = DropDownList1.SelectedItem.Value
        Label8.Text = DropDownList2.SelectedItem.Value

    End Function

    Function show_jenis_urusan()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = True
        TextBox3.Enabled = True
        TextBox4.Visible = False
        TextBox4.Enabled = False
        TextBox5.Visible = False
        TextBox5.Enabled = False
        TextBox9.Visible = False
        TextBox9.Enabled = False
        TextBox10.Visible = False
        TextBox10.Enabled = False
        Label1.Visible = True
        Label1.Text = "Kod Urusan:"
        Label2.Visible = True
        Label2.Text = "Nama Urusan :"
        Label3.Visible = True
        Label3.Text = "Borang :"
        Label4.Visible = False
        Label4.Text = "Harga BKH:"
        Label5.Visible = False
        Label5.Text = "Kod Kategori Ikan :"
        Label9.Visible = False
        Label9.Text = "Kod Kumpulan:"
        Label10.Visible = False
        Label10.Text = "Kod Spesis :"


        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT Kod_urusan, nama_urusan FROM jenis_urusan where Kod_urusan <>'00000'ORDER BY nama_urusan", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("nama_urusan")
            item2.Value = SqlRdr.Item("Kod_urusan")
            DropDownList2.Items.Add(item2)
            '   label8.Text = DropDownList2.Items(item2)
            DropDownList2.Visible = True
        End While
        DropDownList2.Items.Insert(0, "-- Select Kategori jenis Urusan --")
        Label7.Text = DropDownList1.SelectedItem.Value
        Label8.Text = DropDownList2.SelectedItem.Value

    End Function

    Function show_kategori()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = False
        TextBox3.Enabled = False
        TextBox4.Visible = False
        TextBox4.Enabled = False
        TextBox5.Visible = False
        TextBox5.Enabled = False
        TextBox9.Visible = False
        TextBox9.Enabled = False
        TextBox10.Visible = False
        TextBox10.Enabled = False
        Label1.Visible = True
        Label1.Text = "Kod Kategori Ikan:"
        Label2.Visible = True
        Label2.Text = "Nama Kategori Ikan :"
        Label3.Visible = False
        Label3.Text = "Borang :"
        Label4.Visible = False
        Label4.Text = "Harga BKH:"
        Label5.Visible = False
        Label5.Text = "Kod Kategori Ikan :"
        Label9.Visible = False
        Label9.Text = "Kod Kumpulan:"
        Label10.Visible = False
        Label10.Text = "Kod Spesis :"


        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT Kod_Kategori_Ikan, nama_Kategori_Ikan FROM kategori_ikan where Kod_Kategori_Ikan <>'00000'ORDER BY nama_Kategori_Ikan", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("nama_Kategori_Ikan")
            item2.Value = SqlRdr.Item("Kod_Kategori_Ikan")
            DropDownList2.Items.Add(item2)
            '   label8.Text = DropDownList2.Items(item2)
            DropDownList2.Visible = True
        End While
        DropDownList2.Items.Insert(0, "-- Select Kategori Ikan --")
        Label7.Text = DropDownList1.SelectedItem.Value
        Label8.Text = DropDownList2.SelectedItem.Value

    End Function

    Function show_kumpulan()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = False
        TextBox3.Enabled = False
        TextBox4.Visible = False
        TextBox4.Enabled = False
        TextBox5.Visible = False
        TextBox5.Enabled = False
        TextBox9.Visible = False
        TextBox9.Enabled = False
        TextBox10.Visible = False
        TextBox10.Enabled = False
        Label1.Visible = True
        Label1.Text = "Kod Kumpulan Ikan:"
        Label2.Visible = True
        Label2.Text = "Nama Kumpulan Ikan :"
        Label3.Visible = False
        Label3.Text = "Borang :"
        Label4.Visible = False
        Label4.Text = "Harga BKH:"
        Label5.Visible = False
        Label5.Text = "Kod Kategori Ikan :"
        Label9.Visible = False
        Label9.Text = "Kod Kumpulan:"
        Label10.Visible = False
        Label10.Text = "Kod Spesis :"


        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT Kod_kumpulan_Ikan, nama_kumpulan_Ikan FROM kumpulan_ikan where Kod_kumpulan_Ikan <>'00000'ORDER BY nama_kumpulan_Ikan", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("nama_kumpulan_Ikan")
            item2.Value = SqlRdr.Item("Kod_kumpulan_Ikan")
            DropDownList2.Items.Add(item2)
            '   label8.Text = DropDownList2.Items(item2)
            DropDownList2.Visible = True
        End While
        DropDownList2.Items.Insert(0, "-- Select Kumpulan Ikan --")
        Label7.Text = DropDownList1.SelectedItem.Value
        Label8.Text = DropDownList2.SelectedItem.Value

    End Function

    Function show_lesen()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = True
        TextBox3.Enabled = True
        TextBox4.Visible = True
        TextBox4.Enabled = True
        TextBox5.Visible = True
        TextBox5.Enabled = True
        TextBox7.Visible = True
        TextBox7.Enabled = True
        TextBox8.Visible = True
        TextBox8.Enabled = True
        calender1.Visible = True
        calender2.Visible = True
        Label1.Visible = True
        Label1.Text = "No lesen:"
        Label2.Visible = True
        Label2.Text = "Tarikh Tamat:"
        Label3.Visible = True
        Label3.Text = "Tarikh disah :"
        Label4.Visible = True
        Label4.Text = "Kawasan:"
        Label5.Visible = True
        Label5.Text = "Siri Lesen:"
        Label9.Visible = False
        Label9.Text = "Kod Kumpulan:"
        Label10.Visible = False
        Label10.Text = "Kod Spesis :"


        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT No_lesen, siri_lesen FROM lesen where no_lesen <>'00000'ORDER BY siri_lesen", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("no_lesen")
            item2.Value = SqlRdr.Item("siri_lesen")
            DropDownList2.Items.Add(item2)
            '   label8.Text = DropDownList2.Items(item2)
            DropDownList2.Visible = True
        End While
        DropDownList2.Items.Insert(0, "-- Select lesen --")
        Label7.Text = DropDownList1.SelectedItem.Value
        Label8.Text = DropDownList2.SelectedItem.Value

    End Function

    Function show_negara()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = False
        TextBox3.Enabled = False
        TextBox4.Visible = False
        TextBox4.Enabled = False
        TextBox5.Visible = False
        TextBox5.Enabled = False
        TextBox9.Visible = False
        TextBox9.Enabled = False
        TextBox10.Visible = False
        TextBox10.Enabled = False
        Label1.Visible = True
        Label1.Text = "Kod Negara:"
        Label2.Visible = True
        Label2.Text = "Nama Negara :"
        Label3.Visible = False
        Label3.Text = "Borang :"
        Label4.Visible = False
        Label4.Text = "Harga BKH:"
        Label5.Visible = False
        Label5.Text = "Kod Kategori Ikan :"
        Label9.Visible = False
        Label9.Text = "Kod Kumpulan:"
        Label10.Visible = False
        Label10.Text = "Kod Spesis :"


        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT Kod_negara, nama_negara FROM negara where Kod_negara <>'00000'ORDER BY nama_negara", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("nama_negara")
            item2.Value = SqlRdr.Item("Kod_negara")
            DropDownList2.Items.Add(item2)
            '   label8.Text = DropDownList2.Items(item2)
            DropDownList2.Visible = True
        End While
        DropDownList2.Items.Insert(0, "-- Select Negara--")
        Label7.Text = DropDownList1.SelectedItem.Value
        Label8.Text = DropDownList2.SelectedItem.Value

    End Function

    Function show_negeri()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = False
        TextBox3.Enabled = False
        TextBox4.Visible = False
        TextBox4.Enabled = False
        TextBox5.Visible = False
        TextBox5.Enabled = False
        TextBox9.Visible = False
        TextBox9.Enabled = False
        TextBox10.Visible = False
        TextBox10.Enabled = False
        Label1.Visible = True
        Label1.Text = "Kod Negeri:"
        Label2.Visible = True
        Label2.Text = "Nama Negeri :"
        Label3.Visible = False
        Label3.Text = "Borang :"
        Label4.Visible = False
        Label4.Text = "Harga BKH:"
        Label5.Visible = False
        Label5.Text = "Kod Kategori Ikan :"
        Label9.Visible = False
        Label9.Text = "Kod Kumpulan:"
        Label10.Visible = False
        Label10.Text = "Kod Spesis :"


        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT Kod_Negeri, nama_Negeri FROM negeri where Kod_Negeri <>'00000'ORDER BY nama_Negeri", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("nama_Negeri")
            item2.Value = SqlRdr.Item("Kod_Negeri")
            DropDownList2.Items.Add(item2)
            '   label8.Text = DropDownList2.Items(item2)
            DropDownList2.Visible = True
        End While
        DropDownList2.Items.Insert(0, "-- Select Negeri--")
        Label7.Text = DropDownList1.SelectedItem.Value
        Label8.Text = DropDownList2.SelectedItem.Value

    End Function

    Function show_pengeksport_malaysia()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = True
        TextBox3.Enabled = True
        TextBox4.Visible = True
        TextBox4.Enabled = True
        TextBox5.Visible = True
        TextBox5.Enabled = True
        TextBox9.Visible = False
        TextBox9.Enabled = False
        TextBox10.Visible = False
        TextBox10.Enabled = False
        calender3.Visible = True
        Label1.Visible = True
        Label1.Text = "Kod Pengeksport:"
        Label2.Visible = True
        Label2.Text = "Nama Syarikat :"
        Label3.Visible = True
        Label3.Text = "Alamat Syarikat :"
        Label4.Visible = True
        Label4.Text = "No lesen:"
        Label5.Visible = True
        Label5.Text = "Tarikh Dimasukkan :"
        Label9.Visible = False
        Label9.Text = "Kod Kumpulan:"
        Label10.Visible = False
        Label10.Text = "Kod Spesis :"


        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT Kod_pengeksport, nama_syarikat_eksport FROM pengeksport where Kod_pengeksport <>'00000'ORDER BY nama_syarikat_eksport", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("nama_syarikat_eksport")
            item2.Value = SqlRdr.Item("Kod_pengeksport")
            DropDownList2.Items.Add(item2)
            '   label8.Text = DropDownList2.Items(item2)
            DropDownList2.Visible = True
        End While
        DropDownList2.Items.Insert(0, "-- Select Pengeksport Malaysia--")
        Label7.Text = DropDownList1.SelectedItem.Value
        Label8.Text = DropDownList2.SelectedItem.Value

    End Function

    Function show_pengimport_malaysia()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = True
        TextBox3.Enabled = True
        TextBox4.Visible = True
        TextBox4.Enabled = True
        TextBox5.Visible = True
        TextBox5.Enabled = True
        TextBox9.Visible = True
        TextBox9.Enabled = True
        TextBox10.Visible = True
        TextBox11.Visible = True
        TextBox10.Enabled = True
        TextBox11.Enabled = True
        Label1.Visible = True
        Label1.Text = "Kod pengimport:"
        Label2.Visible = True
        Label2.Text = "Nama Syarikat  :"
        Label3.Visible = True
        Label3.Text = "Alamat Syarikat :"
        Label4.Visible = True
        Label4.Text = "No lesen:"
        Label5.Visible = True
        Label5.Text = "Alamat Menyurat:"
        Label9.Visible = True
        Label9.Text = "Nama Pemilik:"
        Label10.Visible = True
        Label10.Text = "No KP :"
        Label11.Visible = True
        Label11.Text = "No Tel :"


        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT Kod_pengimport, nama_syarikat_import FROM pengimport where Kod_pengimport <>'00000'ORDER BY nama_syarikat_import", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("nama_syarikat_import")
            item2.Value = SqlRdr.Item("Kod_pengimport")
            DropDownList2.Items.Add(item2)
            '   label8.Text = DropDownList2.Items(item2)
            DropDownList2.Visible = True
        End While
        DropDownList2.Items.Insert(0, "-- Select Pengimport Malaysia--")
        Label7.Text = DropDownList1.SelectedItem.Value
        Label8.Text = DropDownList2.SelectedItem.Value

    End Function
    Function show_pengeksport_thai()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = True
        TextBox3.Enabled = True
        TextBox4.Visible = False
        TextBox4.Enabled = False
        TextBox5.Visible = False
        TextBox5.Enabled = False
        TextBox9.Visible = False
        TextBox9.Enabled = False
        TextBox10.Visible = False
        TextBox11.Visible = False
        TextBox10.Enabled = False
        TextBox11.Enabled = False
        Label1.Visible = True
        Label1.Text = "Kod pengeksport:"
        Label2.Visible = True
        Label2.Text = "Nama Syarikat  :"
        Label3.Visible = True
        Label3.Text = "Alamat Syarikat :"
        Label4.Visible = False
        Label4.Text = "No lesen:"
        Label5.Visible = False
        Label5.Text = "Alamat Menyurat:"
        Label9.Visible = False
        Label9.Text = "Nama Pemilik:"
        Label10.Visible = False
        Label10.Text = "No KP :"
        Label11.Visible = False
        Label11.Text = "No Tel :"


        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT Kod_pengeksport, nama_pengeksport FROM pengeksport_thailand where Kod_pengeksport <>'00000'ORDER BY nama_pengeksport", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("nama_pengeksport")
            item2.Value = SqlRdr.Item("Kod_pengeksport")
            DropDownList2.Items.Add(item2)
            '   label8.Text = DropDownList2.Items(item2)
            DropDownList2.Visible = True
        End While
        DropDownList2.Items.Insert(0, "-- Select pengeksport Thailand --")
        Label7.Text = DropDownList1.SelectedItem.Value
        Label8.Text = DropDownList2.SelectedItem.Value

    End Function

    Function show_pengimport_thai()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = True
        TextBox3.Enabled = True
        TextBox4.Visible = False
        TextBox4.Enabled = False
        TextBox5.Visible = False
        TextBox5.Enabled = False
        TextBox9.Visible = False
        TextBox9.Enabled = False
        TextBox10.Visible = False
        TextBox11.Visible = False
        TextBox10.Enabled = False
        TextBox11.Enabled = False
        Label1.Visible = True
        Label1.Text = "Kod Pengimport:"
        Label2.Visible = True
        Label2.Text = "Nama Syarikat  :"
        Label3.Visible = True
        Label3.Text = "Alamat Syarikat :"
        Label4.Visible = False
        Label4.Text = "No lesen:"
        Label5.Visible = False
        Label5.Text = "Alamat Menyurat:"
        Label9.Visible = False
        Label9.Text = "Nama Pemilik:"
        Label10.Visible = False
        Label10.Text = "No KP :"
        Label11.Visible = False
        Label11.Text = "No Tel :"


        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT Kod_Pengimport, nama_Pengimport FROM Pengimport_thailand where Kod_Pengimport <>'00000'ORDER BY nama_Pengimport", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("nama_Pengimport")
            item2.Value = SqlRdr.Item("Kod_Pengimport")
            DropDownList2.Items.Add(item2)
            '   label8.Text = DropDownList2.Items(item2)
            DropDownList2.Visible = True
        End While
        DropDownList2.Items.Insert(0, "-- Select Pengimport Thailand --")
        Label7.Text = DropDownList1.SelectedItem.Value
        Label8.Text = DropDownList2.SelectedItem.Value

    End Function

    Function show_komplex()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = True
        TextBox3.Enabled = True
        TextBox4.Visible = False
        TextBox4.Enabled = False
        TextBox5.Visible = False
        TextBox5.Enabled = False
        TextBox9.Visible = False
        TextBox9.Enabled = False
        TextBox10.Visible = False
        TextBox11.Visible = False
        TextBox10.Enabled = False
        TextBox11.Enabled = False
        Label1.Visible = True
        Label1.Text = "Kod PPI:"
        Label2.Visible = True
        Label2.Text = "Nama PPI  :"
        Label3.Visible = True
        Label3.Text = "Alamat PPI :"
        Label4.Visible = False
        Label4.Text = "No lesen:"
        Label5.Visible = False
        Label5.Text = "Alamat Menyurat:"
        Label9.Visible = False
        Label9.Text = "Nama Pemilik:"
        Label10.Visible = False
        Label10.Text = "No KP :"
        Label11.Visible = False
        Label11.Text = "No Tel :"


        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT Kod_PPI, nama_PPI FROM pusatkomplek where Kod_PPI <>'00000'ORDER BY nama_PPI", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("nama_PPI")
            item2.Value = SqlRdr.Item("Kod_PPI")
            DropDownList2.Items.Add(item2)
            '   label8.Text = DropDownList2.Items(item2)
            DropDownList2.Visible = True
        End While
        DropDownList2.Items.Insert(0, "-- Select Pusat komplex --")
        Label7.Text = DropDownList1.SelectedItem.Value
        Label8.Text = DropDownList2.SelectedItem.Value

    End Function

    Function show_spesis1()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = False
        TextBox3.Enabled = False
        Label1.Visible = True
        Label1.Text = "Kod Spesis Ikan :"
        Label2.Visible = True
        Label2.Text = "Nama Spesis Ikan :"



        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT Kod_spesis_ikan_1, nama_spesis_ikan_1 FROM spesis_ikan_1 where Kod_spesis_ikan_1 <>'00000'ORDER BY nama_spesis_ikan_1", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("nama_spesis_ikan_1")
            item2.Value = SqlRdr.Item("Kod_spesis_ikan_1")
            DropDownList2.Items.Add(item2)
            '   label8.Text = DropDownList2.Items(item2)
            DropDownList2.Visible = True
        End While
        DropDownList2.Items.Insert(0, "-- Select Spesis Ikan --")
        Label7.Text = DropDownList1.SelectedItem.Value
        Label8.Text = DropDownList2.SelectedItem.Value

    End Function
    Function show_spesis2()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = False
        TextBox3.Enabled = False
        Label1.Visible = True
        Label1.Text = "Kod Spesis Ikan :"
        Label2.Visible = True
        Label2.Text = "Nama Spesis Ikan :"



        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT Kod_spesis_ikan_2, nama_spesis_ikan_2 FROM spesis_ikan_2 where Kod_spesis_ikan_2 <>'00000'ORDER BY nama_spesis_ikan_2", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("nama_spesis_ikan_2")
            item2.Value = SqlRdr.Item("Kod_spesis_ikan_2")
            DropDownList2.Items.Add(item2)
            '   label8.Text = DropDownList2.Items(item2)
            DropDownList2.Visible = True
        End While
        DropDownList2.Items.Insert(0, "-- Select Spesis Udang --")
        Label7.Text = DropDownList1.SelectedItem.Value
        Label8.Text = DropDownList2.SelectedItem.Value

    End Function

    Function show_spesis3()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = False
        TextBox3.Enabled = False
        Label1.Visible = True
        Label1.Text = "Kod Spesis Ikan :"
        Label2.Visible = True
        Label2.Text = "Nama Spesis Ikan :"



        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT Kod_spesis_ikan_3, nama_spesis_ikan_3 FROM spesis_ikan_3 where Kod_spesis_ikan_3 <>'00000'ORDER BY nama_spesis_ikan_3", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("nama_spesis_ikan_3")
            item2.Value = SqlRdr.Item("Kod_spesis_ikan_3")
            DropDownList2.Items.Add(item2)
            '   label8.Text = DropDownList2.Items(item2)
            DropDownList2.Visible = True
        End While
        DropDownList2.Items.Insert(0, "-- Select Spesis Ketam --")
        Label7.Text = DropDownList1.SelectedItem.Value
        Label8.Text = DropDownList2.SelectedItem.Value

    End Function

    Function show_spesis4()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = False
        TextBox3.Enabled = False
        Label1.Visible = True
        Label1.Text = "Kod Spesis Ikan :"
        Label2.Visible = True
        Label2.Text = "Nama Spesis Ikan :"



        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT Kod_spesis_ikan_4, nama_spesis_ikan_4 FROM spesis_ikan_4 where Kod_spesis_ikan_4 <>'00000'ORDER BY nama_spesis_ikan_4", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("nama_spesis_ikan_4")
            item2.Value = SqlRdr.Item("Kod_spesis_ikan_4")
            DropDownList2.Items.Add(item2)
            '   label8.Text = DropDownList2.Items(item2)
            DropDownList2.Visible = True
        End While
        DropDownList2.Items.Insert(0, "-- Select Spesis Sotong --")
        Label7.Text = DropDownList1.SelectedItem.Value
        Label8.Text = DropDownList2.SelectedItem.Value

    End Function

    Function show_spesis5()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = False
        TextBox3.Enabled = False
        Label1.Visible = True
        Label1.Text = "Kod Spesis Ikan :"
        Label2.Visible = True
        Label2.Text = "Nama Spesis Ikan :"



        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT Kod_spesis_ikan_5, nama_spesis_ikan_5 FROM spesis_ikan_5 where Kod_spesis_ikan_5 <>'00000'ORDER BY nama_spesis_ikan_5", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("nama_spesis_ikan_5")
            item2.Value = SqlRdr.Item("Kod_spesis_ikan_5")
            DropDownList2.Items.Add(item2)
            '   label8.Text = DropDownList2.Items(item2)
            DropDownList2.Visible = True
        End While
        DropDownList2.Items.Insert(0, "-- Select Spesis Kerangan --")
        Label7.Text = DropDownList1.SelectedItem.Value
        Label8.Text = DropDownList2.SelectedItem.Value

    End Function

    Function show_spesis6()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = False
        TextBox3.Enabled = False
        Label1.Visible = True
        Label1.Text = "Kod Spesis Ikan :"
        Label2.Visible = True
        Label2.Text = "Nama Spesis Ikan :"



        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT Kod_spesis_ikan_6, nama_spesis_ikan_6 FROM spesis_ikan_6 where Kod_spesis_ikan_6 <>'00000'ORDER BY nama_spesis_ikan_6", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("nama_spesis_ikan_6")
            item2.Value = SqlRdr.Item("Kod_spesis_ikan_6")
            DropDownList2.Items.Add(item2)
            '   label8.Text = DropDownList2.Items(item2)
            DropDownList2.Visible = True
        End While
        DropDownList2.Items.Insert(0, "-- Select Spesis Bivals --")
        Label7.Text = DropDownList1.SelectedItem.Value
        Label8.Text = DropDownList2.SelectedItem.Value

    End Function

    Function show_spesis7()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = False
        TextBox3.Enabled = False
        Label1.Visible = True
        Label1.Text = "Kod Spesis Ikan :"
        Label2.Visible = True
        Label2.Text = "Nama Spesis Ikan :"



        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT Kod_spesis_ikan_7, nama_spesis_ikan_7 FROM spesis_ikan_7 where Kod_spesis_ikan_7 <>'00000'ORDER BY nama_spesis_ikan_7", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("nama_spesis_ikan_7")
            item2.Value = SqlRdr.Item("Kod_spesis_ikan_7")
            DropDownList2.Items.Add(item2)
            '   label8.Text = DropDownList2.Items(item2)
            DropDownList2.Visible = True
        End While
        DropDownList2.Items.Insert(0, "-- Select Spesis Hidupan Akuatik --")
        Label7.Text = DropDownList1.SelectedItem.Value
        Label8.Text = DropDownList2.SelectedItem.Value

    End Function

    Function show_spesis8()

        TextBox1.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = True
        TextBox2.Enabled = True
        TextBox3.Visible = False
        TextBox3.Enabled = False
        Label1.Visible = True
        Label1.Text = "Kod Spesis Ikan :"
        Label2.Visible = True
        Label2.Text = "Nama Spesis Ikan :"



        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT Kod_spesis_ikan_8, nama_spesis_ikan_8 FROM spesis_ikan_8 where Kod_spesis_ikan_8 <>'00000'ORDER BY nama_spesis_ikan_8", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("nama_spesis_ikan_8")
            item2.Value = SqlRdr.Item("Kod_spesis_ikan_8")
            DropDownList2.Items.Add(item2)
            '   label8.Text = DropDownList2.Items(item2)
            DropDownList2.Visible = True
        End While
        DropDownList2.Items.Insert(0, "-- Select Spesis Lain - Lain --")
        Label7.Text = DropDownList1.SelectedItem.Value
        Label8.Text = DropDownList2.SelectedItem.Value

    End Function

    Function show_epermit()

        DropDownList3.Visible = True
        TextBox6.Enabled = True
        TextBox6.Visible = True
        TextBox7.Enabled = True
        TextBox7.Visible = True
        TextBox8.Enabled = True
        TextBox8.Visible = True
        TextBox12.Enabled = True
        TextBox12.Visible = True
        TextBox14.Enabled = True
        TextBox14.Visible = True
        TextBox15.Enabled = True
        TextBox15.Visible = True
        Label1.Visible = True
        Label1.Text = "E-permit serial no:"
        Label2.Visible = True
        Label2.Text = "Kod E-permit :"
        Label3.Visible = True
        Label3.Text = "E-permit description :"
        Label4.Visible = True
        Label4.Text = "E-permit Cost :"
        Label5.Visible = True
        Label5.Text = "E-permit Status :"
        Label9.Visible = True
        Label9.Text = "E-permit edate :"
        Label10.Visible = True
        Label10.Text = "E-permit userid :"

        calender4.Visible = True

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT epermit_serial_no, epermit_code FROM epermit_maintenance where epermit_code <>'00000'ORDER BY epermit_serial_no", myconn)
        Dim item2 As ListItem
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        While SqlRdr.Read
            item2 = New ListItem()
            item2.Text = SqlRdr.Item("epermit_code")
            item2.Value = SqlRdr.Item("epermit_serial_no")
            DropDownList2.Items.Add(item2)
            '   label8.Text = DropDownList2.Items(item2)
            DropDownList2.Visible = True
        End While

        DropDownList2.Items.Insert(0, "-- Select E-Permit --")
        Label7.Text = DropDownList1.SelectedItem.Value
        Label8.Text = DropDownList2.SelectedItem.Value

    End Function

    ' data view in textbox

    Function view_agent(ByVal result As String)
        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_agen_pengangkutan, nama_agen_pengangkutan, alamat_agen_pengangkutan, deposit_semasa, transaksi_semasa FROM agen_pengangkutan where kod_agen_pengangkutan='" & result & "' ", myconn)
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If SqlRdr.Read Then
            TextBox1.Text = SqlRdr.Item("kod_agen_pengangkutan").Trim & ("")
            TextBox2.Text = SqlRdr.Item("nama_agen_pengangkutan").Trim & ("")
            TextBox3.Text = SqlRdr.Item("alamat_agen_pengangkutan").Trim & ("")
            TextBox4.Text = SqlRdr.Item("deposit_semasa")
            TextBox5.Text = SqlRdr.Item("transaksi_semasa")
            TextBox10.Text = SqlRdr.Item("deposit_semasa")
            TextBox6.Text = SqlRdr.Item("kod_agen_pengangkutan").Trim & ("")
            TextBox1.Enabled = False
            add_deposit.Visible = True
            add_deposit.Enabled = True
            add.Visible = True
            add.Enabled = True
            save.Enabled = True
            delete.Enabled = True
            save.Visible = True
            delete.Visible = True
            cancel.Enabled = True
            cancel.Visible = True
            view.Enabled = True
            view.Visible = True
        End If
    End Function

    Function view_bentuk_ikan_1(ByVal result As String)
        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_bentuk_ikan_1, nama_bentuk_ikan_1 FROM bentuk_ikan_1 where kod_bentuk_ikan_1='" & result & "' ", myconn)
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If SqlRdr.Read Then
            TextBox1.Text = SqlRdr.Item("kod_bentuk_ikan_1").Trim & ("")
            TextBox2.Text = SqlRdr.Item("nama_bentuk_ikan_1").Trim & ("")
            TextBox1.Enabled = False
            add.Visible = True
            add.Enabled = True
            save.Enabled = True
            delete.Enabled = True
            save.Visible = True
            delete.Visible = True
            cancel.Enabled = True
            cancel.Visible = True
            view.Enabled = True
            view.Visible = True
        End If
    End Function

    Function view_bentuk_ikan_2(ByVal result As String)
        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_bentuk_ikan_2, nama_bentuk_ikan_2 FROM bentuk_ikan_2 where kod_bentuk_ikan_2='" & result & "' ", myconn)
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If SqlRdr.Read Then
            TextBox1.Text = SqlRdr.Item("kod_bentuk_ikan_2").Trim & ("")
            TextBox2.Text = SqlRdr.Item("nama_bentuk_ikan_2").Trim & ("")
            TextBox1.Enabled = False
            add.Visible = True
            add.Enabled = True
            save.Enabled = True
            delete.Enabled = True
            save.Visible = True
            delete.Visible = True
            cancel.Enabled = True
            cancel.Visible = True
            view.Enabled = True
            view.Visible = True
        End If
    End Function

    Function view_bentuk_ikan_3(ByVal result As String)
        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_bentuk_ikan_3, nama_bentuk_ikan_3 FROM bentuk_ikan_3 where kod_bentuk_ikan_3='" & result & "' ", myconn)
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If SqlRdr.Read Then
            TextBox1.Text = SqlRdr.Item("kod_bentuk_ikan_3").Trim & ("")
            TextBox2.Text = SqlRdr.Item("nama_bentuk_ikan_3").Trim & ("")
            TextBox1.Enabled = False
            add.Visible = True
            add.Enabled = True
            save.Enabled = True
            delete.Enabled = True
            save.Visible = True
            delete.Visible = True
            cancel.Enabled = True
            cancel.Visible = True
            view.Enabled = True
            view.Visible = True
        End If
    End Function

    Function view_bentuk_ikan_4(ByVal result As String)
        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_bentuk_ikan_4, nama_bentuk_ikan_4 FROM bentuk_ikan_4 where kod_bentuk_ikan_4='" & result & "' ", myconn)
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If SqlRdr.Read Then
            TextBox1.Text = SqlRdr.Item("kod_bentuk_ikan_4").Trim & ("")
            TextBox2.Text = SqlRdr.Item("nama_bentuk_ikan_4").Trim & ("")
            TextBox1.Enabled = False
            add.Visible = True
            add.Enabled = True
            save.Enabled = True
            delete.Enabled = True
            save.Visible = True
            delete.Visible = True
            cancel.Enabled = True
            cancel.Visible = True
            view.Enabled = True
            view.Visible = True
        End If
    End Function

    Function view_bentuk_ikan_5(ByVal result As String)
        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_bentuk_ikan_5, nama_bentuk_ikan_5 FROM bentuk_ikan_5 where kod_bentuk_ikan_5='" & result & "' ", myconn)
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If SqlRdr.Read Then
            TextBox1.Text = SqlRdr.Item("kod_bentuk_ikan_5").Trim & ("")
            TextBox2.Text = SqlRdr.Item("nama_bentuk_ikan_5").Trim & ("")
            TextBox1.Enabled = False
            add.Visible = True
            add.Enabled = True
            save.Enabled = True
            delete.Enabled = True
            save.Visible = True
            delete.Visible = True
            cancel.Enabled = True
            cancel.Visible = True
            view.Enabled = True
            view.Visible = True
        End If
    End Function

    Function view_caj_perkhidmatan(ByVal result As String)
        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_caj, nama_caj, kadar_caj, cara_pembayaran, dicaj_oleh FROM caj_perkhidmatan where kod_caj='" & result & "' ", myconn)
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If SqlRdr.Read Then
            TextBox1.Text = SqlRdr.Item("kod_caj").Trim & ("")
            TextBox2.Text = SqlRdr.Item("nama_caj").Trim & ("")
            TextBox3.Text = SqlRdr.Item("kadar_caj")
            TextBox4.Text = SqlRdr.Item("cara_pembayaran")
            TextBox5.Text = SqlRdr.Item("dicaj_oleh").Trim & ("")
            add.Visible = True
            add.Enabled = True
            save.Enabled = True
            delete.Enabled = True
            save.Visible = True
            delete.Visible = True
            cancel.Enabled = True
            cancel.Visible = True
            view.Enabled = True
            view.Visible = True
        End If
    End Function

    Function view_cara_pengangkutan(ByVal result As String)
        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_cara_pengangkutan, nama_cara_pengangkutan FROM cara_pengangkutan where kod_cara_pengangkutan='" & result & "' ", myconn)
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If SqlRdr.Read Then
            TextBox1.Text = SqlRdr.Item("kod_cara_pengangkutan").Trim & ("")
            TextBox2.Text = SqlRdr.Item("nama_cara_pengangkutan").Trim & ("")
            'TextBox4.Enabled = False
            add.Visible = True
            add.Enabled = True
            save.Enabled = True
            delete.Enabled = True
            save.Visible = True
            delete.Visible = True
            cancel.Enabled = True
            cancel.Visible = True
            view.Enabled = True
            view.Visible = True
        End If
    End Function

    Function view_destinasi_pasar(ByVal result As String)
        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_pasar, nama_pasar FROM destinasi_pasar where kod_pasar='" & result & "' ", myconn)
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If SqlRdr.Read Then
            TextBox1.Text = SqlRdr.Item("kod_pasar").Trim & ("")
            TextBox2.Text = SqlRdr.Item("nama_pasar").Trim & ("")
            'TextBox4.Enabled = False
            add.Visible = True
            add.Enabled = True
            save.Enabled = True
            delete.Enabled = True
            save.Visible = True
            delete.Visible = True
            cancel.Enabled = True
            cancel.Visible = True
            view.Enabled = True
            view.Visible = True
        End If
    End Function

    Function view_gred_saiz(ByVal result As String)
        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_Gredsaiz, nama_Gredsaiz FROM Gred_saiz where kod_Gredsaiz='" & result & "' ", myconn)
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If SqlRdr.Read Then
            TextBox1.Text = SqlRdr.Item("kod_Gredsaiz").Trim & ("")
            TextBox2.Text = SqlRdr.Item("nama_Gredsaiz").Trim & ("")
            add.Visible = True
            add.Enabled = True
            save.Enabled = True
            delete.Enabled = True
            save.Visible = True
            delete.Visible = True
            cancel.Enabled = True
            cancel.Visible = True
            view.Enabled = True
            view.Visible = True
        End If
    End Function

    Function view_caj_ikan(ByVal result As String)

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT id, kategori_ikan, jenis_urusan, kadar_peti_kecil, kadar_peti_besar, kadar_ekor, kadar_kuantiti FROM ikan_caj where id = '" & result & "' ", myconn)
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If SqlRdr.Read Then
            TextBox1.Text = SqlRdr.Item("id")
            TextBox2.Text = SqlRdr.Item("kategori_ikan")
            TextBox3.Text = SqlRdr.Item("jenis_urusan")
            TextBox4.Text = CInt(SqlRdr.Item("kadar_peti_kecil"))
            TextBox5.Text = CInt(SqlRdr.Item("kadar_peti_besar"))
            TextBox9.Text = CInt(SqlRdr.Item("kadar_ekor"))
            TextBox10.Text = CInt(SqlRdr.Item("kadar_kuantiti"))
            'TextBox4.Enabled = False
            add.Visible = True
            add.Enabled = True
            save.Enabled = True
            delete.Enabled = True
            save.Visible = True
            delete.Visible = True
            cancel.Enabled = True
            cancel.Visible = True
            'view.Enabled = True
            'view.Visible = True
        End If
    End Function


    Function view_jenis(ByVal result As String)
        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_barangan, nama_barangan FROM jenis_barangan where kod_barangan = '" & result & "' ", myconn)
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If SqlRdr.Read Then
            TextBox1.Text = SqlRdr.Item("kod_barangan").Trim & ("")
            TextBox2.Text = SqlRdr.Item("nama_barangan").Trim & ("")
            '  TextBox3.Text = SqlRdr.Item("jenis_urusan")
            ' TextBox4.Text = SqlRdr.Item("kadar_peti_kecil")
            ' TextBox5.Text = SqlRdr.Item("kadar_peti_besar")
            ' TextBox9.Text = SqlRdr.Item("kadar_ekor")
            ' TextBox10.Text = SqlRdr.Item("kadar_kuantiti")
            ' TextBox4.Enabled = False
            add.Visible = True
            add.Enabled = True
            save.Enabled = True
            delete.Enabled = True
            save.Visible = True
            delete.Visible = True
            cancel.Enabled = True
            cancel.Visible = True
            view.Enabled = True
            view.Visible = True
        End If
    End Function

    Function view_jenis_ikan(ByVal result As String)
        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_bkh, kod_ikan, nama_bkh, harga_bkh FROM jenis_ikan where kod_ikan= '" & result & "' ", myconn)
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If SqlRdr.Read Then
            TextBox1.Text = SqlRdr.Item("kod_bkh").Trim & ("")
            TextBox2.Text = SqlRdr.Item("kod_ikan").Trim & ("")
            TextBox3.Text = SqlRdr.Item("nama_bkh").Trim & ("")
            TextBox4.Text = SqlRdr.Item("harga_bkh") '.Trim & ("")
            'TextBox5.Text = SqlRdr.Item("kadar_peti_besar")
            'TextBox9.Text = SqlRdr.Item("kadar_ekor")
            'TextBox10.Text = SqlRdr.Item("kadar_kuantiti")
            'TextBox11.Text = SqlRdr.Item("kadar_ekor")
            'TextBox12.Text = SqlRdr.Item("kadar_kuantiti")
            ' TextBox4.Enabled = False
            add.Visible = True
            add.Enabled = True
            save.Enabled = True
            delete.Enabled = True
            save.Visible = True
            delete.Visible = True
            cancel.Enabled = True
            cancel.Visible = True
            view.Enabled = True
            view.Visible = True
        End If
    End Function

    Function view_jenis_pengangkutan(ByVal result As String)
        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_pengangkutan, nama_pengangkutan, caj_pengangkutan from jenis_pengangkutan where kod_pengangkutan= '" & result & "' ", myconn)
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If SqlRdr.Read Then
            TextBox1.Text = SqlRdr.Item("kod_pengangkutan").Trim & ("")
            TextBox2.Text = SqlRdr.Item("nama_pengangkutan").Trim & ("")
            TextBox3.Text = SqlRdr.Item("caj_pengangkutan") '.Trim & ("")
            ' TextBox3.Text = SqlRdr.Item("nama_bkh").Trim & ("")
            'TextBox4.Text = SqlRdr.Item("harga_bkh") '.Trim & ("")
            'TextBox5.Text = SqlRdr.Item("kadar_peti_besar")
            'TextBox9.Text = SqlRdr.Item("kadar_ekor")
            'TextBox10.Text = SqlRdr.Item("kadar_kuantiti")
            'TextBox11.Text = SqlRdr.Item("kadar_ekor")
            'TextBox12.Text = SqlRdr.Item("kadar_kuantiti")
            ' TextBox4.Enabled = False
            add.Visible = True
            add.Enabled = True
            save.Enabled = True
            delete.Enabled = True
            save.Visible = True
            delete.Visible = True
            cancel.Enabled = True
            cancel.Visible = True
            view.Enabled = True
            view.Visible = True
        End If
    End Function

    Function view_jenis_urusan(ByVal result As String)
        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_urusan, nama_urusan, borang from jenis_urusan where kod_urusan= '" & result & "' ", myconn)
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If SqlRdr.Read Then
            TextBox1.Text = SqlRdr.Item("kod_urusan").Trim & ("")
            TextBox2.Text = SqlRdr.Item("nama_urusan").Trim & ("")
            TextBox3.Text = SqlRdr.Item("borang") '.Trim & ("")
            ' TextBox3.Text = SqlRdr.Item("nama_bkh").Trim & ("")
            'TextBox4.Text = SqlRdr.Item("harga_bkh") '.Trim & ("")
            'TextBox5.Text = SqlRdr.Item("kadar_peti_besar")
            'TextBox9.Text = SqlRdr.Item("kadar_ekor")
            'TextBox10.Text = SqlRdr.Item("kadar_kuantiti")
            'TextBox11.Text = SqlRdr.Item("kadar_ekor")
            'TextBox12.Text = SqlRdr.Item("kadar_kuantiti")
            ' TextBox4.Enabled = False
            add.Visible = True
            add.Enabled = True
            save.Enabled = True
            delete.Enabled = True
            save.Visible = True
            delete.Visible = True
            cancel.Enabled = True
            cancel.Visible = True
            view.Enabled = True
            view.Visible = True
        End If
    End Function

    Function view_kategori(ByVal result As String)
        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_kategori_ikan, nama_kategori_ikan from kategori_ikan where kod_kategori_ikan= '" & result & "' ", myconn)
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If SqlRdr.Read Then
            TextBox1.Text = SqlRdr.Item("kod_kategori_ikan").Trim & ("")
            TextBox2.Text = SqlRdr.Item("nama_kategori_ikan").Trim & ("")
            ' TextBox3.Text = SqlRdr.Item("borang") '.Trim & ("")
            ' TextBox3.Text = SqlRdr.Item("nama_bkh").Trim & ("")
            'TextBox4.Text = SqlRdr.Item("harga_bkh") '.Trim & ("")
            'TextBox5.Text = SqlRdr.Item("kadar_peti_besar")
            'TextBox9.Text = SqlRdr.Item("kadar_ekor")
            'TextBox10.Text = SqlRdr.Item("kadar_kuantiti")
            'TextBox11.Text = SqlRdr.Item("kadar_ekor")
            'TextBox12.Text = SqlRdr.Item("kadar_kuantiti")
            ' TextBox4.Enabled = False
            add.Visible = True
            add.Enabled = True
            save.Enabled = True
            delete.Enabled = True
            save.Visible = True
            delete.Visible = True
            cancel.Enabled = True
            cancel.Visible = True
            view.Enabled = True
            view.Visible = True
        End If
    End Function

    Function view_kumpulan(ByVal result As String)
        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_kumpulan_ikan, nama_kumpulan_ikan from kumpulan_ikan where kod_kumpulan_ikan= '" & result & "' ", myconn)
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If SqlRdr.Read Then
            TextBox1.Text = SqlRdr.Item("kod_kumpulan_ikan").Trim & ("")
            TextBox2.Text = SqlRdr.Item("nama_kumpulan_ikan").Trim & ("")
            ' TextBox3.Text = SqlRdr.Item("borang") '.Trim & ("")
            ' TextBox3.Text = SqlRdr.Item("nama_bkh").Trim & ("")
            'TextBox4.Text = SqlRdr.Item("harga_bkh") '.Trim & ("")
            'TextBox5.Text = SqlRdr.Item("kadar_peti_besar")
            'TextBox9.Text = SqlRdr.Item("kadar_ekor")
            'TextBox10.Text = SqlRdr.Item("kadar_kuantiti")
            'TextBox11.Text = SqlRdr.Item("kadar_ekor")
            'TextBox12.Text = SqlRdr.Item("kadar_kuantiti")
            ' TextBox4.Enabled = False
            add.Visible = True
            add.Enabled = True
            save.Enabled = True
            delete.Enabled = True
            save.Visible = True
            delete.Visible = True
            cancel.Enabled = True
            cancel.Visible = True
            view.Enabled = True
            view.Visible = True
        End If
    End Function

    Function view_lesen(ByVal result As String)
        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT No_Lesen AS Expr1, Tarikh_Tamat AS Expr2, Tarikh_Disah AS Expr3, Kawasan AS Expr4, Siri_Lesen AS Expr5 from lesen where Siri_Lesen= '" & result & "' ", myconn)
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If SqlRdr.Read Then
            TextBox1.Text = SqlRdr.Item("Expr1") '.Trim & ("")
            TextBox2.Text = SqlRdr.Item("Expr2") '.Trim & ("")
            TextBox3.Text = SqlRdr.Item("Expr3") '.Trim & ("")
            TextBox4.Text = SqlRdr.Item("Expr4") '.Trim & ("")
            TextBox5.Text = SqlRdr.Item("Expr5") '.Trim & ("")
            TextBox7.Text = SqlRdr.Item("Expr2") '.Trim & ("")
            TextBox8.Text = SqlRdr.Item("Expr3") '.Trim & ("")
            ' TextBox5.Text = SqlRdr.Item("Expr1")
            'TextBox9.Text = SqlRdr.Item("kadar_ekor")
            'TextBox10.Text = SqlRdr.Item("kadar_kuantiti")
            'TextBox11.Text = SqlRdr.Item("kadar_ekor")
            'TextBox12.Text = SqlRdr.Item("kadar_kuantiti")
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            TextBox4.Enabled = False
            TextBox7.Enabled = True
            TextBox8.Enabled = True
            add.Visible = True
            add.Enabled = True
            save.Enabled = True
            delete.Enabled = True
            save.Visible = True
            delete.Visible = True
            cancel.Enabled = True
            cancel.Visible = True
            view.Enabled = True
            view.Visible = True
        End If
    End Function

    Function view_negara(ByVal result As String)
        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_negara AS Expr1, nama_negara AS Expr2 from negara where kod_negara= '" & result & "' ", myconn)
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If SqlRdr.Read Then
            TextBox1.Text = SqlRdr.Item("Expr1").Trim & ("")
            TextBox2.Text = SqlRdr.Item("Expr2").Trim & ("")
            ' TextBox3.Text = SqlRdr.Item("Expr3") '.Trim & ("")
            'TextBox4.Text = SqlRdr.Item("Expr4") '.Trim & ("")
            'TextBox5.Text = SqlRdr.Item("Expr5") '.Trim & ("")
            'TextBox7.Text = SqlRdr.Item("Expr2") '.Trim & ("")
            'TextBox8.Text = SqlRdr.Item("Expr3") '.Trim & ("")
            ' TextBox5.Text = SqlRdr.Item("Expr1")
            'TextBox9.Text = SqlRdr.Item("kadar_ekor")
            'TextBox10.Text = SqlRdr.Item("kadar_kuantiti")
            'TextBox11.Text = SqlRdr.Item("kadar_ekor")
            'TextBox12.Text = SqlRdr.Item("kadar_kuantiti")
            TextBox1.Enabled = False
            ' TextBox3.Enabled = False
            ' TextBox4.Enabled = False
            ' TextBox7.Enabled = False
            ' TextBox8.Enabled = False
            add.Visible = True
            add.Enabled = True
            save.Enabled = True
            delete.Enabled = True
            save.Visible = True
            delete.Visible = True
            cancel.Enabled = True
            cancel.Visible = True
            view.Enabled = True
            view.Visible = True
        End If
    End Function

    Function view_negeri(ByVal result As String)
        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_negeri AS Expr1, nama_negeri AS Expr2 from negeri where kod_negeri= '" & result & "' ", myconn)
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If SqlRdr.Read Then
            TextBox1.Text = SqlRdr.Item("Expr1").Trim & ("")
            TextBox2.Text = SqlRdr.Item("Expr2").Trim & ("")
            ' TextBox3.Text = SqlRdr.Item("Expr3") '.Trim & ("")
            'TextBox4.Text = SqlRdr.Item("Expr4") '.Trim & ("")
            'TextBox5.Text = SqlRdr.Item("Expr5") '.Trim & ("")
            'TextBox7.Text = SqlRdr.Item("Expr2") '.Trim & ("")
            'TextBox8.Text = SqlRdr.Item("Expr3") '.Trim & ("")
            ' TextBox5.Text = SqlRdr.Item("Expr1")
            'TextBox9.Text = SqlRdr.Item("kadar_ekor")
            'TextBox10.Text = SqlRdr.Item("kadar_kuantiti")
            'TextBox11.Text = SqlRdr.Item("kadar_ekor")
            'TextBox12.Text = SqlRdr.Item("kadar_kuantiti")
            TextBox1.Enabled = False
            ' TextBox3.Enabled = False
            ' TextBox4.Enabled = False
            ' TextBox7.Enabled = False
            ' TextBox8.Enabled = False
            add.Visible = True
            add.Enabled = True
            save.Enabled = True
            delete.Enabled = True
            save.Visible = True
            delete.Visible = True
            cancel.Enabled = True
            cancel.Visible = True
            view.Enabled = True
            view.Visible = True
        End If
    End Function

    Function view_pengeksport_malaysia(ByVal result As String)
        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_pengeksport AS Expr1, nama_syarikat_eksport AS Expr2, alamat_syarikat_eksport AS Expr3, no_lesen AS Expr4, tarikh_dimasukkan AS Expr5 from pengeksport where kod_pengeksport= '" & result & "' ", myconn)
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If SqlRdr.Read Then
            TextBox1.Text = SqlRdr.Item("Expr1").Trim & ("")
            TextBox2.Text = SqlRdr.Item("Expr2").Trim & ("")
            TextBox3.Text = SqlRdr.Item("Expr3").Trim & ("")
            TextBox4.Text = SqlRdr.Item("Expr4").Trim & ("")
            TextBox5.Text = SqlRdr.Item("Expr5") '.Trim & ("")

            TextBox1.Enabled = False
            add.Visible = True
            add.Enabled = True
            save.Enabled = True
            delete.Enabled = True
            save.Visible = True
            delete.Visible = True
            cancel.Enabled = True
            cancel.Visible = True
            view.Enabled = True
            view.Visible = True
        End If
    End Function

    Function view_pengimport_malaysia(ByVal result As String)
        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_pengimport AS Expr1, nama_syarikat_import AS Expr2, alamat_syarikat_import AS Expr3, no_lesen AS Expr4, alamat_menyurat AS Expr5, nama_pemilik AS Expr6, no_kp AS Expr7, no_tel AS Expr8 from pengimport where kod_pengimport= '" & result & "' ", myconn)
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If SqlRdr.Read Then
            TextBox1.Text = SqlRdr.Item("Expr1").Trim & ("")
            TextBox2.Text = SqlRdr.Item("Expr2").Trim & ("")
            TextBox3.Text = SqlRdr.Item("Expr3").Trim & ("")
            TextBox4.Text = SqlRdr.Item("Expr4").Trim & ("")
            TextBox5.Text = SqlRdr.Item("Expr5") '.Trim & ("")
            'TextBox7.Text = SqlRdr.Item("Expr2") '.Trim & ("")
            'TextBox8.Text = SqlRdr.Item("Expr3") '.Trim & ("")
            ' TextBox5.Text = SqlRdr.Item("Expr1")
            TextBox9.Text = SqlRdr.Item("Expr6").Trim & ("")
            TextBox10.Text = SqlRdr.Item("Expr7").Trim & ("")
            TextBox11.Text = SqlRdr.Item("Expr8").Trim & ("")
            'TextBox12.Text = SqlRdr.Item("kadar_kuantiti")
            'TextBox1.Enabled = False
            'TextBox5.Enabled = False
            ' TextBox3.Enabled = False
            ' TextBox4.Enabled = False
            ' TextBox7.Enabled = False
            ' TextBox8.Enabled = False
            add.Visible = True
            add.Enabled = True
            save.Enabled = True
            delete.Enabled = True
            save.Visible = True
            delete.Visible = True
            cancel.Enabled = True
            cancel.Visible = True
            view.Enabled = True
            view.Visible = True
        End If
    End Function

    Function view_pengeksport_thai(ByVal result As String)
        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_pengeksport AS Expr1, nama_pengeksport AS Expr2, alamat_pengeksport AS Expr3 from pengeksport_thailand where kod_pengeksport= '" & result & "' ", myconn)
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If SqlRdr.Read Then
            TextBox1.Text = SqlRdr.Item("Expr1").Trim & ("")
            TextBox2.Text = SqlRdr.Item("Expr2").Trim & ("")
            TextBox3.Text = SqlRdr.Item("Expr3").Trim & ("")
            'TextBox4.Text = SqlRdr.Item("Expr4").Trim & ("")
            'TextBox5.Text = SqlRdr.Item("Expr5") '.Trim & ("")
            'TextBox7.Text = SqlRdr.Item("Expr2") '.Trim & ("")
            'TextBox8.Text = SqlRdr.Item("Expr3") '.Trim & ("")
            ' TextBox5.Text = SqlRdr.Item("Expr1")
            'TextBox9.Text = SqlRdr.Item("Expr6").Trim & ("")
            'TextBox10.Text = SqlRdr.Item("Expr7").Trim & ("")
            'TextBox11.Text = SqlRdr.Item("Expr8").Trim & ("")
            'TextBox12.Text = SqlRdr.Item("kadar_kuantiti")
            TextBox1.Enabled = False
            'TextBox5.Enabled = False
            ' TextBox3.Enabled = False
            ' TextBox4.Enabled = False
            ' TextBox7.Enabled = False
            ' TextBox8.Enabled = False
            add.Visible = True
            add.Enabled = True
            save.Enabled = True
            delete.Enabled = True
            save.Visible = True
            delete.Visible = True
            cancel.Enabled = True
            cancel.Visible = True
            view.Enabled = True
            view.Visible = True
        End If
    End Function

    Function view_pengimport_thai(ByVal result As String)
        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_pengimport AS Expr1, nama_pengimport AS Expr2, alamat_pengimport AS Expr3 from pengimport_thailand where kod_pengimport= '" & result & "' ", myconn)
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If SqlRdr.Read Then
            TextBox1.Text = SqlRdr.Item("Expr1").Trim & ("")
            TextBox2.Text = SqlRdr.Item("Expr2").Trim & ("")
            TextBox3.Text = SqlRdr.Item("Expr3").Trim & ("")
            'TextBox4.Text = SqlRdr.Item("Expr4").Trim & ("")
            'TextBox5.Text = SqlRdr.Item("Expr5") '.Trim & ("")
            'TextBox7.Text = SqlRdr.Item("Expr2") '.Trim & ("")
            'TextBox8.Text = SqlRdr.Item("Expr3") '.Trim & ("")
            ' TextBox5.Text = SqlRdr.Item("Expr1")
            'TextBox9.Text = SqlRdr.Item("Expr6").Trim & ("")
            'TextBox10.Text = SqlRdr.Item("Expr7").Trim & ("")
            'TextBox11.Text = SqlRdr.Item("Expr8").Trim & ("")
            'TextBox12.Text = SqlRdr.Item("kadar_kuantiti")
            TextBox1.Enabled = False
            'TextBox5.Enabled = False
            ' TextBox3.Enabled = False
            ' TextBox4.Enabled = False
            ' TextBox7.Enabled = False
            ' TextBox8.Enabled = False
            add.Visible = True
            add.Enabled = True
            save.Enabled = True
            delete.Enabled = True
            save.Visible = True
            delete.Visible = True
            cancel.Enabled = True
            cancel.Visible = True
            view.Enabled = True
            view.Visible = True
        End If
    End Function

    Function view_komplex(ByVal result As String)
        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_ppi AS Expr1, nama_ppi AS Expr2, alamat_ppi AS Expr3 from pusatkomplek where kod_ppi= '" & result & "' ", myconn)
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If SqlRdr.Read Then
            TextBox1.Text = SqlRdr.Item("Expr1").Trim & ("")
            TextBox2.Text = SqlRdr.Item("Expr2").Trim & ("")
            TextBox3.Text = SqlRdr.Item("Expr3").Trim & ("")
            TextBox1.Enabled = False
            add.Visible = True
            add.Enabled = True
            save.Enabled = True
            delete.Enabled = True
            save.Visible = True
            delete.Visible = True
            cancel.Enabled = True
            cancel.Visible = True
            view.Enabled = True
            view.Visible = True
        End If
    End Function

    Function view_spesis1(ByVal result As String)
        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_spesis_ikan_1 AS Expr1, nama_spesis_ikan_1 AS Expr2 from spesis_ikan_1 where kod_spesis_ikan_1= '" & result & "' ", myconn)
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If SqlRdr.Read Then
            TextBox1.Text = SqlRdr.Item("Expr1").Trim & ("")
            TextBox2.Text = SqlRdr.Item("Expr2").Trim & ("")
            TextBox1.Enabled = False
            add.Visible = True
            add.Enabled = True
            save.Enabled = True
            delete.Enabled = True
            save.Visible = True
            delete.Visible = True
            cancel.Enabled = True
            cancel.Visible = True
            view.Enabled = True
            view.Visible = True
        End If
    End Function

    Function view_spesis2(ByVal result As String)
        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_spesis_ikan_2 AS Expr1, nama_spesis_ikan_2 AS Expr2 from spesis_ikan_2 where kod_spesis_ikan_2= '" & result & "' ", myconn)
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If SqlRdr.Read Then
            TextBox1.Text = SqlRdr.Item("Expr1").Trim & ("")
            TextBox2.Text = SqlRdr.Item("Expr2").Trim & ("")
            TextBox1.Enabled = False
            add.Visible = True
            add.Enabled = True
            save.Enabled = True
            delete.Enabled = True
            save.Visible = True
            delete.Visible = True
            cancel.Enabled = True
            cancel.Visible = True
            view.Enabled = True
            view.Visible = True
        End If
    End Function

    Function view_spesis3(ByVal result As String)
        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_spesis_ikan_3 AS Expr1, nama_spesis_ikan_3 AS Expr2 from spesis_ikan_3 where kod_spesis_ikan_3= '" & result & "' ", myconn)
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If SqlRdr.Read Then
            TextBox1.Text = SqlRdr.Item("Expr1").Trim & ("")
            TextBox2.Text = SqlRdr.Item("Expr2").Trim & ("")
            TextBox1.Enabled = False
            add.Visible = True
            add.Enabled = True
            save.Enabled = True
            delete.Enabled = True
            save.Visible = True
            delete.Visible = True
            cancel.Enabled = True
            cancel.Visible = True
            view.Enabled = True
            view.Visible = True
        End If
    End Function

    Function view_spesis4(ByVal result As String)
        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_spesis_ikan_4 AS Expr1, nama_spesis_ikan_4 AS Expr2 from spesis_ikan_4 where kod_spesis_ikan_4= '" & result & "' ", myconn)
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If SqlRdr.Read Then
            TextBox1.Text = SqlRdr.Item("Expr1").Trim & ("")
            TextBox2.Text = SqlRdr.Item("Expr2").Trim & ("")
            TextBox1.Enabled = False
            add.Visible = True
            add.Enabled = True
            save.Enabled = True
            delete.Enabled = True
            save.Visible = True
            delete.Visible = True
            cancel.Enabled = True
            cancel.Visible = True
            view.Enabled = True
            view.Visible = True
        End If
    End Function

    Function view_spesis5(ByVal result As String)
        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_spesis_ikan_5 AS Expr1, nama_spesis_ikan_5 AS Expr2 from spesis_ikan_5 where kod_spesis_ikan_5= '" & result & "' ", myconn)
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If SqlRdr.Read Then
            TextBox1.Text = SqlRdr.Item("Expr1").Trim & ("")
            TextBox2.Text = SqlRdr.Item("Expr2").Trim & ("")
            TextBox1.Enabled = False
            add.Visible = True
            add.Enabled = True
            save.Enabled = True
            delete.Enabled = True
            save.Visible = True
            delete.Visible = True
            cancel.Enabled = True
            cancel.Visible = True
            view.Enabled = True
            view.Visible = True
        End If
    End Function

    Function view_spesis6(ByVal result As String)
        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_spesis_ikan_6 AS Expr1, nama_spesis_ikan_6 AS Expr2 from spesis_ikan_6 where kod_spesis_ikan_6= '" & result & "' ", myconn)
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If SqlRdr.Read Then
            TextBox1.Text = SqlRdr.Item("Expr1").Trim & ("")
            TextBox2.Text = SqlRdr.Item("Expr2").Trim & ("")
            TextBox1.Enabled = False
            add.Visible = True
            add.Enabled = True
            save.Enabled = True
            delete.Enabled = True
            save.Visible = True
            delete.Visible = True
            cancel.Enabled = True
            cancel.Visible = True
            view.Enabled = True
            view.Visible = True
        End If
    End Function

    Function view_spesis7(ByVal result As String)
        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_spesis_ikan_7 AS Expr1, nama_spesis_ikan_7 AS Expr2 from spesis_ikan_7 where kod_spesis_ikan_7= '" & result & "' ", myconn)
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If SqlRdr.Read Then
            TextBox1.Text = SqlRdr.Item("Expr1").Trim & ("")
            TextBox2.Text = SqlRdr.Item("Expr2").Trim & ("")
            TextBox1.Enabled = False
            add.Visible = True
            add.Enabled = True
            save.Enabled = True
            delete.Enabled = True
            save.Visible = True
            delete.Visible = True
            cancel.Enabled = True
            cancel.Visible = True
            view.Enabled = True
            view.Visible = True
        End If
    End Function

    Function view_spesis8(ByVal result As String)
        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT kod_spesis_ikan_8 AS Expr1, nama_spesis_ikan_8 AS Expr2 from spesis_ikan_8 where kod_spesis_ikan_8= '" & result & "' ", myconn)
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If SqlRdr.Read Then
            TextBox1.Text = SqlRdr.Item("Expr1").Trim & ("")
            TextBox2.Text = SqlRdr.Item("Expr2").Trim & ("")
            TextBox1.Enabled = False
            add.Visible = True
            add.Enabled = True
            save.Enabled = True
            delete.Enabled = True
            save.Visible = True
            delete.Visible = True
            cancel.Enabled = True
            cancel.Visible = True
            view.Enabled = True
            view.Visible = True
        End If
    End Function

    Function view_epermit(ByVal result As String)
        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("SELECT epermit_serial_no, epermit_code, epermit_desc, epermit_cost, status , edate , userid from epermit_maintenance where epermit_serial_no= '" & result & "' ", myconn)
        Dim SqlRdr As SqlDataReader
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If SqlRdr.Read Then
            TextBox6.Text = SqlRdr.Item("epermit_serial_no")
            TextBox7.Text = SqlRdr.Item("epermit_code").Trim & ("")
            TextBox8.Text = SqlRdr.Item("epermit_desc").Trim & ("")
            TextBox12.Text = SqlRdr.Item("epermit_cost")
            DropDownList3.Text = SqlRdr.Item("status")
            TextBox14.Text = SqlRdr.Item("edate")
            TextBox15.Text = SqlRdr.Item("userid")
            TextBox6.Enabled = False
            add.Visible = True
            add.Enabled = True
            save.Enabled = True
            delete.Enabled = True
            save.Visible = True
            delete.Visible = True
            cancel.Enabled = True
            cancel.Visible = True
            view.Enabled = True
            view.Visible = True

        End If
    End Function

    ' save function

    Protected Sub save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles save.Click
        saved()
    End Sub

    Function saved()
      
        If Label7.Text = "01" Then
            save_agen()
        ElseIf datadetail.Text = "02.1" Or Label7.Text = "02.1" Then
            save_bentuk_ikan_1()
        ElseIf datadetail.Text = "02.2" Or Label7.Text = "02.2" Then
            save_bentuk_ikan_2()
        ElseIf datadetail.Text = "02.3" Or Label7.Text = "02.3" Then
            save_bentuk_ikan_3()
        ElseIf datadetail.Text = "02.4" Or Label7.Text = "02.4" Then
            save_bentuk_ikan_4()
        ElseIf datadetail.Text = "02.5" Or Label7.Text = "02.5" Then
            save_bentuk_ikan_5()
        ElseIf Label7.Text = "03" Then
            save_caj_perkhidmatan()
        ElseIf Label7.Text = "04" Then
            save_cara_pengangkutan()
        ElseIf Label7.Text = "05" Then
            save_destinasi_pasar()
        ElseIf Label7.Text = "06" Then
            save_gred_saiz()
        ElseIf Label7.Text = "07" Then
            save_caj_ikan()
        ElseIf Label7.Text = "08" Then
            save_jenis()
        ElseIf Label7.Text = "09" Then
            save_jenis_ikan()
        ElseIf Label7.Text = "010" Then
            save_jenis_pengangkutan()
        ElseIf Label7.Text = "011" Then
            save_jenis_urusan()
        ElseIf Label7.Text = "012" Then
            save_kategori()
        ElseIf Label7.Text = "013" Then
            save_kumpulan()
        ElseIf Label7.Text = "014" Then
            save_lesen()
        ElseIf Label7.Text = "015" Then
            save_negara()
        ElseIf Label7.Text = "016" Then
            save_negeri()
        ElseIf Label7.Text = "017" Then
            save_pengeksport()
        ElseIf Label7.Text = "018" Then
            save_pengimport_malaysia()
        ElseIf Label7.Text = "019" Then
            save_pengeksport_thai()
        ElseIf Label7.Text = "020" Then
            save_pengimport_thai()
        ElseIf Label7.Text = "021" Then
            save_komplex()
        ElseIf Label7.Text = "022.1" Then
            save_spesis1()
        ElseIf Label7.Text = "022.2" Then
            save_spesis2()
        ElseIf Label7.Text = "022.3" Then
            save_spesis3()
        ElseIf Label7.Text = "022.4" Then
            save_spesis4()
        ElseIf Label7.Text = "022.5" Then
            save_spesis5()
        ElseIf Label7.Text = "022.6" Then
            save_spesis6()
        ElseIf Label7.Text = "022.7" Then
            save_spesis7()
        ElseIf Label7.Text = "022.8" Then
            save_spesis8()
        ElseIf Label7.Text = "023" Then
            save_epermit()
        End If

    End Function

    Function save_agen()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from agen_pengangkutan where kod_agen_pengangkutan='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "UPDATE agen_pengangkutan set nama_agen_pengangkutan = '" & TextBox2.Text & "', alamat_agen_pengangkutan = '" & TextBox3.Text & "' where kod_agen_pengangkutan='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(Str, myconn)
        Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()

        If statusflag > 0 Then
            Response.Write("<script> alert('successfully updated');history.back();</script>")
        Else
            Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
        End If

        myconn.Close()

    End Function

    Function save_bentuk_ikan_1()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from bentuk_ikan_1 where kod_bentuk_ikan_1='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "UPDATE bentuk_ikan_1 set nama_bentuk_ikan_1 = '" & TextBox2.Text & "' where kod_bentuk_ikan_1='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('successfully updated');history.back();</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function save_bentuk_ikan_2()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from bentuk_ikan_2 where kod_bentuk_ikan_2='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "UPDATE bentuk_ikan_2 set nama_bentuk_ikan_2 = '" & TextBox2.Text & "' where kod_bentuk_ikan_2='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('successfully updated');history.back();</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function save_bentuk_ikan_3()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from bentuk_ikan_3 where kod_bentuk_ikan_3='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "UPDATE bentuk_ikan_3 set nama_bentuk_ikan_3 = '" & TextBox2.Text & "' where kod_bentuk_ikan_3='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('successfully updated');history.back();</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function save_bentuk_ikan_4()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from bentuk_ikan_4 where kod_bentuk_ikan_4='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "UPDATE bentuk_ikan_4 set nama_bentuk_ikan_4 = '" & TextBox2.Text & "' where kod_bentuk_ikan_4='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('successfully updated');history.back();</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function save_bentuk_ikan_5()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from bentuk_ikan_5 where kod_bentuk_ikan_5='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "UPDATE bentuk_ikan_5 set nama_bentuk_ikan_5 = '" & TextBox2.Text & "' where kod_bentuk_ikan_5 ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('successfully updated');history.back();</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function save_caj_perkhidmatan()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from caj_perkhidmatan where kod_caj ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "UPDATE caj_perkhidmatan set nama_caj = '" & TextBox2.Text & "', kadar_caj = '" & TextBox3.Text & "', dicaj_oleh = '" & TextBox5.Text & "' where kod_caj ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('successfully updated');history.back();</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function save_cara_pengangkutan()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from cara_pengangkutan where kod_cara_pengangkutan ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "UPDATE cara_pengangkutan set kod_cara_pengangkutan = '" & TextBox1.Text & "', nama_cara_pengangkutan = '" & TextBox2.Text & "' where kod_cara_pengangkutan ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('successfully updated');history.back();</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function save_destinasi_pasar()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from destinasi_pasar where kod_pasar ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "UPDATE destinasi_pasar set kod_pasar = '" & TextBox1.Text & "', nama_pasar = '" & TextBox2.Text & "' where kod_pasar ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('successfully updated');history.back();</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function save_gred_saiz()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from Gred_saiz where kod_Gredsaiz ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "UPDATE Gred_saiz set kod_Gredsaiz = '" & TextBox1.Text & "', nama_Gredsaiz = '" & TextBox2.Text & "' where kod_Gredsaiz ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('successfully updated');history.back();</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function save_caj_ikan()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from ikan_caj where id ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "UPDATE ikan_caj set kategori_ikan = '" & TextBox2.Text & "', jenis_urusan = '" & TextBox3.Text & "', kadar_peti_kecil = " & TextBox4.Text & ", kadar_peti_besar = " & TextBox5.Text & ", kadar_ekor = " & TextBox9.Text & ", kadar_kuantiti = " & TextBox10.Text & " where id ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('successfully updated');history.back();</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function save_jenis()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from jenis_barangan where kod_barangan ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "UPDATE jenis_barangan set kod_barangan = '" & TextBox1.Text & "', nama_barangan = '" & TextBox2.Text & "' where kod_barangan ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('successfully updated');history.back();</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function save_jenis_ikan()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from jenis_ikan where kod_bkh ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "UPDATE jenis_ikan set kod_bkh = '" & TextBox1.Text & "', kod_ikan = '" & TextBox2.Text & "', nama_bkh = '" & TextBox3.Text & "', harga_bkh = '" & TextBox4.Text & "' where kod_bkh ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('successfully updated');history.back();</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function save_jenis_pengangkutan()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from jenis_pengangkutan where kod_pengangkutan ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "UPDATE jenis_pengangkutan set kod_pengangkutan = '" & TextBox1.Text & "', nama_pengangkutan = '" & TextBox2.Text & "', caj_pengangkutan = '" & TextBox3.Text & "' where kod_pengangkutan ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('successfully updated');history.back();</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function save_jenis_urusan()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from jenis_urusan where kod_urusan ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "UPDATE jenis_urusan set kod_urusan = '" & TextBox1.Text & "', nama_urusan = '" & TextBox2.Text & "', borang = '" & TextBox3.Text & "' where kod_urusan ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('successfully updated');history.back();</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function save_kategori()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from kategori_ikan where kod_kategori_ikan ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "UPDATE kategori_ikan set kod_kategori_ikan = '" & TextBox1.Text & "', nama_kategori_ikan = '" & TextBox2.Text & "' where kod_kategori_ikan ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('successfully updated');history.back();</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function save_kumpulan()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from kumpulan_ikan where kod_kumpulan_ikan ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "UPDATE kumpulan_ikan set kod_kumpulan_ikan = '" & TextBox1.Text & "', nama_kumpulan_ikan = '" & TextBox2.Text & "' where kod_kumpulan_ikan ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('successfully updated');history.back();</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function save_lesen()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from lesen where no_lesen ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "UPDATE lesen set no_lesen = '" & TextBox1.Text & "', tarikh_tamat = '" & TextBox7.Text & "', tarikh_disah = '" & TextBox8.Text & "', kawasan = '" & TextBox4.Text & "', siri_lesen = '" & TextBox5.Text & "' where no_lesen ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('successfully updated');history.back();</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function save_negara()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from negara where kod_negara ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "UPDATE negara set kod_negara = '" & TextBox1.Text & "', nama_negara = '" & TextBox2.Text & "' where kod_negara ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('successfully updated');history.back();</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function
    Function save_negeri()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from negeri where kod_negeri ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "UPDATE negeri set kod_negeri = '" & TextBox1.Text & "', nama_negeri = '" & TextBox2.Text & "' where kod_negeri ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('successfully updated');history.back();</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function save_pengeksport()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from pengeksport where kod_pengeksport ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "UPDATE pengeksport set kod_pengeksport = '" & TextBox1.Text & "', nama_syarikat_eksport = '" & TextBox2.Text & "', alamat_syarikat_eksport = '" & TextBox3.Text & "', no_lesen = '" & TextBox4.Text & "', tarikh_dimasukkan = '" & TextBox5.Text & "' where kod_pengeksport ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('successfully updated');history.back();</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function
    Function save_pengimport_malaysia()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from pengimport where kod_pengimport ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "UPDATE pengimport set kod_pengimport = '" & TextBox1.Text & "', nama_syarikat_import = '" & TextBox2.Text & "', alamat_syarikat_import = '" & TextBox3.Text & "', no_lesen = '" & TextBox4.Text & "', alamat_menyurat = '" & TextBox5.Text & "', nama_pemilik = '" & TextBox6.Text & "', no_kp = '" & TextBox7.Text & "', no_tel = '" & TextBox8.Text & "' where kod_pengimport ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('successfully updated');history.back();</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function save_pengeksport_thai()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from pengeksport_thailand where kod_pengeksport ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "UPDATE pengeksport_thailand set kod_pengeksport = '" & TextBox1.Text & "', nama_pengeksport = '" & TextBox2.Text & "', alamat_pengeksport = '" & TextBox3.Text & "' where kod_pengeksport ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('successfully updated');history.back();</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function save_pengimport_thai()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from pengimport_thailand where kod_pengimport ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "UPDATE pengimport_thailand set kod_pengimport = '" & TextBox1.Text & "', nama_pengimport = '" & TextBox2.Text & "', alamat_pengimport = '" & TextBox3.Text & "' where kod_pengimport ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('successfully updated');history.back();</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function save_komplex()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from pusatkomplek where kod_ppi ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "UPDATE pusatkomplek set kod_ppi = '" & TextBox1.Text & "', nama_ppi = '" & TextBox2.Text & "', alamat_ppi = '" & TextBox3.Text & "' where kod_ppi ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('successfully updated');history.back();</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function save_spesis1()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from spesis_ikan_1 where kod_spesis_ikan_1 ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "UPDATE spesis_ikan_1 set kod_spesis_ikan_1 = '" & TextBox1.Text & "', nama_spesis_ikan_1 = '" & TextBox2.Text & "' where kod_spesis_ikan_1 ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('successfully updated');history.back();</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function save_spesis2()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from spesis_ikan_2 where kod_spesis_ikan_2 ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "UPDATE spesis_ikan_2 set kod_spesis_ikan_2 = '" & TextBox1.Text & "', nama_spesis_ikan_2 = '" & TextBox2.Text & "' where kod_spesis_ikan_2 ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('successfully updated');history.back();</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function save_spesis3()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from spesis_ikan_3 where kod_spesis_ikan_3 ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "UPDATE spesis_ikan_3 set kod_spesis_ikan_3 = '" & TextBox1.Text & "', nama_spesis_ikan_3 = '" & TextBox2.Text & "' where kod_spesis_ikan_3 ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('successfully updated');history.back();</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function save_spesis4()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from spesis_ikan_4 where kod_spesis_ikan_4 ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "UPDATE spesis_ikan_4 set kod_spesis_ikan_4 = '" & TextBox1.Text & "', nama_spesis_ikan_4 = '" & TextBox2.Text & "' where kod_spesis_ikan_4 ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('successfully updated');history.back();</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function save_spesis5()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from spesis_ikan_5 where kod_spesis_ikan_5 ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "UPDATE spesis_ikan_5 set kod_spesis_ikan_5 = '" & TextBox1.Text & "', nama_spesis_ikan_5 = '" & TextBox2.Text & "' where kod_spesis_ikan_5 ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('successfully updated');history.back();</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function save_spesis6()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from spesis_ikan_6 where kod_spesis_ikan_6 ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "UPDATE spesis_ikan_6 set kod_spesis_ikan_6 = '" & TextBox1.Text & "', nama_spesis_ikan_6 = '" & TextBox2.Text & "' where kod_spesis_ikan_6 ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('successfully updated');history.back();</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function save_spesis7()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from spesis_ikan_7 where kod_spesis_ikan_7 ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "UPDATE spesis_ikan_7 set kod_spesis_ikan_7 = '" & TextBox1.Text & "', nama_spesis_ikan_7 = '" & TextBox2.Text & "' where kod_spesis_ikan_7 ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('successfully updated');history.back();</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function save_spesis8()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from spesis_ikan_8 where kod_spesis_ikan_8 ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "UPDATE spesis_ikan_8 set kod_spesis_ikan_8 = '" & TextBox1.Text & "', nama_spesis_ikan_8 = '" & TextBox2.Text & "' where kod_spesis_ikan_8 ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('successfully updated');history.back();</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function save_epermit()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from epermit_maintenance where epermit_serial_no ='" & TextBox6.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "UPDATE epermit_maintenance set epermit_serial_no = '" & TextBox6.Text & "', epermit_code = '" & TextBox7.Text & "', epermit_desc = '" & TextBox8.Text & "', epermit_cost = '" & TextBox12.Text & "', status = '" & DropDownList3.Text & "', edate = '" & TextBox14.Text & "', userid = '" & TextBox15.Text & "' where epermit_serial_no ='" & TextBox6.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('successfully updated');history.back();</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Protected Sub add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles add.Click
        addbaru()
    End Sub

    Function addbaru()

        Dim i As Integer
        Dim tboxes() As String = New String() {}
        For i = 0 To 3
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox3.Text = ""
            TextBox7.Text = ""
            TextBox8.Text = ""
            TextBox12.Text = ""
            TextBox14.Text = ""
            TextBox15.Text = ""
            DropDownList3.Text = "0"

        Next i

        If Label7.Text = "01" Then
            datagridvalue()
            TextBox1.Visible = False
            add.Visible = False
            TextBox2.Visible = False
            view.Visible = False
            add_deposit.Visible = False
            TextBox3.Visible = False
            TextBox6.Visible = True
            TextBox7.Visible = True
            TextBox8.Visible = True
            Label4.Visible = False
            Label5.Visible = False
            TextBox4.Visible = False
            TextBox5.Visible = False
            save1.Enabled = False
            saveadd.Visible = True
            save.Visible = False
            delete.Visible = False
            DropDownList2.Enabled = False
        ElseIf datadetail.Text = "02.1" Or Label7.Text = "02.1" Then
            datagridvalue()
            TextBox1.Visible = False
            add.Visible = False
            TextBox2.Visible = False
            view.Visible = False
            add_deposit.Visible = False
            TextBox3.Visible = False
            TextBox6.Visible = True
            TextBox7.Visible = True
            Label4.Visible = False
            Label5.Visible = False
            TextBox4.Visible = False
            TextBox5.Visible = False
            save1.Enabled = False
            saveadd.Visible = True
            save.Visible = False
            delete.Visible = False
            DropDownList2.Enabled = False
        ElseIf datadetail.Text = "02.2" Or Label7.Text = "02.2" Then
            datagridvalue()
            TextBox1.Visible = False
            add.Visible = False
            TextBox2.Visible = False
            view.Visible = False
            add_deposit.Visible = False
            TextBox3.Visible = False
            TextBox6.Visible = True
            TextBox7.Visible = True
            Label4.Visible = False
            Label5.Visible = False
            TextBox4.Visible = False
            TextBox5.Visible = False
            save1.Enabled = False
            saveadd.Visible = True
            save.Visible = False
            delete.Visible = False
            DropDownList2.Enabled = False
        ElseIf datadetail.Text = "02.3" Or Label7.Text = "02.3" Then
            datagridvalue()
            TextBox1.Visible = False
            add.Visible = False
            TextBox2.Visible = False
            view.Visible = False
            add_deposit.Visible = False
            TextBox3.Visible = False
            TextBox6.Visible = True
            TextBox7.Visible = True
            Label4.Visible = False
            Label5.Visible = False
            TextBox4.Visible = False
            TextBox5.Visible = False
            save1.Enabled = False
            saveadd.Visible = True
            save.Visible = False
            delete.Visible = False
            DropDownList2.Enabled = False
        ElseIf datadetail.Text = "02.4" Or Label7.Text = "02.4" Then
            datagridvalue()
            TextBox1.Visible = False
            add.Visible = False
            TextBox2.Visible = False
            view.Visible = False
            add_deposit.Visible = False
            TextBox3.Visible = False
            TextBox6.Visible = True
            TextBox7.Visible = True
            Label4.Visible = False
            Label5.Visible = False
            TextBox4.Visible = False
            TextBox5.Visible = False
            save1.Enabled = False
            saveadd.Visible = True
            save.Visible = False
            delete.Visible = False
            DropDownList2.Enabled = False
        ElseIf datadetail.Text = "02.5" Or Label7.Text = "02.5" Then
            datagridvalue()
            TextBox1.Visible = False
            add.Visible = False
            TextBox2.Visible = False
            view.Visible = False
            add_deposit.Visible = False
            TextBox3.Visible = False
            TextBox6.Visible = True
            TextBox7.Visible = True
            Label4.Visible = False
            Label5.Visible = False
            TextBox4.Visible = False
            TextBox5.Visible = False
            save1.Enabled = False
            saveadd.Visible = True
            save.Visible = False
            delete.Visible = False
            DropDownList2.Enabled = False
        ElseIf Label7.Text = "03" Then
            datagridvalue()
            TextBox1.Visible = False
            add.Visible = False
            TextBox2.Visible = False
            view.Visible = False
            add_deposit.Visible = False
            TextBox3.Visible = True
            TextBox6.Visible = True
            TextBox7.Visible = True
            TextBox4.Visible = True
            TextBox5.Visible = True
            save1.Enabled = False
            saveadd.Visible = True
            save.Visible = False
            delete.Visible = False
            DropDownList2.Enabled = False
        ElseIf Label7.Text = "04" Then
            datagridvalue()
            TextBox1.Visible = False
            add.Visible = False
            TextBox2.Visible = False
            view.Visible = False
            add_deposit.Visible = False
            TextBox1.Visible = False
            TextBox2.Visible = False
            TextBox3.Visible = False
            TextBox6.Visible = True
            TextBox7.Visible = True
            TextBox4.Visible = False
            TextBox5.Visible = False
            save1.Enabled = False
            saveadd.Visible = True
            save.Visible = False
            delete.Visible = False
            DropDownList2.Enabled = False
        ElseIf Label7.Text = "05" Then
            datagridvalue()
            TextBox1.Visible = False
            add.Visible = False
            TextBox2.Visible = False
            view.Visible = False
            add_deposit.Visible = False
            TextBox1.Visible = False
            TextBox2.Visible = False
            TextBox3.Visible = False
            TextBox6.Visible = True
            TextBox7.Visible = True
            TextBox4.Visible = False
            TextBox5.Visible = False
            save1.Enabled = False
            saveadd.Visible = True
            save.Visible = False
            delete.Visible = False
            DropDownList2.Enabled = False
        ElseIf Label7.Text = "06" Then
            datagridvalue()
            TextBox1.Visible = False
            add.Visible = False
            TextBox2.Visible = False
            view.Visible = False
            add_deposit.Visible = False
            TextBox1.Visible = False
            TextBox2.Visible = False
            TextBox3.Visible = False
            TextBox6.Visible = True
            TextBox7.Visible = True
            TextBox4.Visible = False
            TextBox5.Visible = False
            TextBox9.Visible = False
            TextBox10.Visible = False
            save1.Enabled = False
            saveadd.Visible = True
            save.Visible = False
            delete.Visible = False
            DropDownList2.Enabled = False
        ElseIf Label7.Text = "07" Then
            datagridvalue()
            add.Visible = False
            view.Visible = False
            add_deposit.Visible = False
            TextBox1.Visible = False
            TextBox1.Enabled = False
            TextBox2.Visible = False
            TextBox3.Visible = False
            TextBox4.Visible = False
            TextBox5.Visible = False
            TextBox6.Visible = False
            Label1.Visible = False
            TextBox6.Enabled = False
            TextBox7.Visible = True
            TextBox8.Visible = True
            TextBox9.Visible = False
            TextBox10.Visible = False
            TextBox11.Visible = False
            TextBox12.Visible = True
            TextBox13.Visible = True
            TextBox14.Visible = True
            TextBox15.Visible = True
            TextBox16.Visible = False
            save1.Enabled = False
            saveadd.Visible = True
            save.Visible = False
            delete.Visible = False
            DropDownList2.Enabled = False
        ElseIf Label7.Text = "08" Then
            datagridvalue()
            add.Visible = False
            view.Visible = False
            add_deposit.Visible = False
            TextBox1.Visible = False
            TextBox2.Visible = False
            TextBox3.Visible = False
            TextBox4.Visible = False
            TextBox5.Visible = False
            TextBox6.Visible = True
            TextBox7.Visible = True
            TextBox8.Visible = False
            TextBox9.Visible = False
            TextBox10.Visible = False
            TextBox11.Visible = False
            TextBox12.Visible = False
            TextBox13.Visible = False
            TextBox14.Visible = False
            TextBox15.Visible = False
            TextBox16.Visible = False
            save1.Enabled = False
            saveadd.Visible = True
            save.Visible = False
            delete.Visible = False
            DropDownList2.Enabled = False
        ElseIf Label7.Text = "09" Then
            datagridvalue()
            add.Visible = False
            view.Visible = False
            add_deposit.Visible = False
            TextBox1.Visible = False
            TextBox2.Visible = False
            TextBox3.Visible = False
            TextBox4.Visible = False
            TextBox5.Visible = False
            TextBox6.Visible = True
            TextBox7.Visible = True
            TextBox8.Visible = True
            TextBox9.Visible = False
            TextBox10.Visible = False
            TextBox11.Visible = False
            TextBox12.Visible = True
            TextBox13.Visible = False
            TextBox14.Visible = False
            TextBox15.Visible = False
            TextBox16.Visible = False
            save1.Enabled = False
            saveadd.Visible = True
            save.Visible = False
            delete.Visible = False
            DropDownList2.Enabled = False
        ElseIf Label7.Text = "010" Then
            datagridvalue()
            add.Visible = False
            view.Visible = False
            add_deposit.Visible = False
            TextBox1.Visible = False
            TextBox2.Visible = False
            TextBox3.Visible = False
            TextBox4.Visible = False
            TextBox5.Visible = False
            TextBox6.Visible = True
            TextBox7.Visible = True
            TextBox8.Visible = True
            TextBox9.Visible = False
            TextBox10.Visible = False
            TextBox11.Visible = False
            TextBox12.Visible = False
            TextBox13.Visible = False
            TextBox14.Visible = False
            TextBox15.Visible = False
            TextBox16.Visible = False
            save1.Enabled = False
            saveadd.Visible = True
            save.Visible = False
            delete.Visible = False
            DropDownList2.Enabled = False
        ElseIf Label7.Text = "011" Then
            datagridvalue()
            add.Visible = False
            view.Visible = False
            add_deposit.Visible = False
            TextBox1.Visible = False
            TextBox2.Visible = False
            TextBox3.Visible = False
            TextBox4.Visible = False
            TextBox5.Visible = False
            TextBox6.Visible = True
            TextBox7.Visible = True
            TextBox8.Visible = True
            TextBox9.Visible = False
            TextBox10.Visible = False
            TextBox11.Visible = False
            TextBox12.Visible = False
            TextBox13.Visible = False
            TextBox14.Visible = False
            TextBox15.Visible = False
            TextBox16.Visible = False
            save1.Enabled = False
            saveadd.Visible = True
            save.Visible = False
            delete.Visible = False
            DropDownList2.Enabled = False
        ElseIf Label7.Text = "012" Then
            datagridvalue()
            add.Visible = False
            view.Visible = False
            add_deposit.Visible = False
            TextBox1.Visible = False
            TextBox2.Visible = False
            TextBox3.Visible = False
            TextBox4.Visible = False
            TextBox5.Visible = False
            TextBox6.Visible = True
            TextBox7.Visible = True
            TextBox8.Visible = False
            TextBox9.Visible = False
            TextBox10.Visible = False
            TextBox11.Visible = False
            TextBox12.Visible = False
            TextBox13.Visible = False
            TextBox14.Visible = False
            TextBox15.Visible = False
            TextBox16.Visible = False
            save1.Enabled = False
            saveadd.Visible = True
            save.Visible = False
            delete.Visible = False
            DropDownList2.Enabled = False
        ElseIf Label7.Text = "013" Then
            datagridvalue()
            add.Visible = False
            view.Visible = False
            add_deposit.Visible = False
            TextBox1.Visible = False
            TextBox2.Visible = False
            TextBox3.Visible = False
            TextBox4.Visible = False
            TextBox5.Visible = False
            TextBox6.Visible = True
            TextBox7.Visible = True
            TextBox8.Visible = False
            TextBox9.Visible = False
            TextBox10.Visible = False
            TextBox11.Visible = False
            TextBox12.Visible = False
            TextBox13.Visible = False
            TextBox14.Visible = False
            TextBox15.Visible = False
            TextBox16.Visible = False
            save1.Enabled = False
            saveadd.Visible = True
            save.Visible = False
            delete.Visible = False
            DropDownList2.Enabled = False
        ElseIf Label7.Text = "014" Then
            datagridvalue()
            add.Visible = False
            view.Visible = False
            add_deposit.Visible = False
            calender1.Visible = True
            calender2.Visible = True
            TextBox1.Visible = False
            TextBox2.Visible = False
            TextBox3.Visible = False
            TextBox4.Visible = False
            TextBox5.Visible = False
            TextBox6.Visible = True
            TextBox7.Visible = True
            TextBox8.Visible = True
            TextBox9.Visible = False
            TextBox10.Visible = False
            TextBox11.Visible = False
            TextBox12.Visible = True
            TextBox13.Visible = True
            TextBox14.Visible = False
            TextBox15.Visible = False
            TextBox16.Visible = False
            save1.Enabled = False
            saveadd.Visible = True
            save.Visible = False
            delete.Visible = False
            DropDownList2.Enabled = False
        ElseIf Label7.Text = "015" Then
            datagridvalue()
            add.Visible = False
            view.Visible = False
            add_deposit.Visible = False
            TextBox1.Visible = False
            TextBox2.Visible = False
            TextBox3.Visible = False
            TextBox4.Visible = False
            TextBox5.Visible = False
            TextBox6.Visible = True
            TextBox7.Visible = True
            TextBox8.Visible = False
            TextBox9.Visible = False
            TextBox10.Visible = False
            TextBox11.Visible = False
            TextBox12.Visible = False
            TextBox13.Visible = False
            TextBox14.Visible = False
            TextBox15.Visible = False
            TextBox16.Visible = False
            save1.Enabled = False
            saveadd.Visible = True
            save.Visible = False
            delete.Visible = False
            DropDownList2.Enabled = False
        ElseIf Label7.Text = "016" Then
            datagridvalue()
            add.Visible = False
            view.Visible = False
            add_deposit.Visible = False
            TextBox1.Visible = False
            TextBox2.Visible = False
            TextBox3.Visible = False
            TextBox4.Visible = False
            TextBox5.Visible = False
            TextBox6.Visible = True
            TextBox7.Visible = True
            TextBox8.Visible = False
            TextBox9.Visible = False
            TextBox10.Visible = False
            TextBox11.Visible = False
            TextBox12.Visible = False
            TextBox13.Visible = False
            TextBox14.Visible = False
            TextBox15.Visible = False
            TextBox16.Visible = False
            save1.Enabled = False
            saveadd.Visible = True
            save.Visible = False
            delete.Visible = False
            DropDownList2.Enabled = False
        ElseIf Label7.Text = "017" Then
            datagridvalue()
            add.Visible = False
            view.Visible = False
            add_deposit.Visible = False
            calender3.Visible = True
            TextBox1.Visible = False
            TextBox2.Visible = False
            TextBox3.Visible = False
            TextBox4.Visible = False
            TextBox5.Visible = True
            TextBox5.Enabled = True
            TextBox6.Visible = True
            TextBox7.Visible = True
            TextBox8.Visible = True
            TextBox9.Visible = False
            TextBox10.Visible = False
            TextBox11.Visible = False
            TextBox12.Visible = True
            TextBox13.Visible = False
            TextBox14.Visible = False
            TextBox15.Visible = False
            TextBox16.Visible = False
            save1.Enabled = False
            saveadd.Visible = True
            save.Visible = False
            delete.Visible = False
            DropDownList2.Enabled = False
        ElseIf Label7.Text = "018" Then
            datagridvalue()
            add.Visible = False
            view.Visible = False
            add_deposit.Visible = False
            TextBox1.Visible = False
            TextBox2.Visible = False
            TextBox3.Visible = False
            TextBox4.Visible = False
            TextBox5.Visible = False
            TextBox6.Visible = True
            TextBox7.Visible = True
            TextBox8.Visible = True
            TextBox9.Visible = False
            TextBox10.Visible = False
            TextBox11.Visible = False
            TextBox12.Visible = True
            TextBox13.Visible = True
            TextBox14.Visible = True
            TextBox15.Visible = True
            TextBox16.Visible = True
            save1.Enabled = False
            saveadd.Visible = True
            save.Visible = False
            delete.Visible = False
            DropDownList2.Enabled = False
        ElseIf Label7.Text = "019" Then
            datagridvalue()
            add.Visible = False
            view.Visible = False
            add_deposit.Visible = False
            TextBox1.Visible = False
            TextBox2.Visible = False
            TextBox3.Visible = False
            TextBox4.Visible = False
            TextBox5.Visible = False
            TextBox6.Visible = True
            TextBox7.Visible = True
            TextBox8.Visible = True
            TextBox9.Visible = False
            TextBox10.Visible = False
            TextBox11.Visible = False
            TextBox12.Visible = False
            TextBox13.Visible = False
            TextBox14.Visible = False
            TextBox15.Visible = False
            TextBox16.Visible = False
            save1.Enabled = False
            saveadd.Visible = True
            save.Visible = False
            delete.Visible = False
            DropDownList2.Enabled = False
        ElseIf Label7.Text = "020" Then
            datagridvalue()
            add.Visible = False
            view.Visible = False
            add_deposit.Visible = False
            TextBox1.Visible = False
            TextBox2.Visible = False
            TextBox3.Visible = False
            TextBox4.Visible = False
            TextBox5.Visible = False
            TextBox6.Visible = True
            TextBox7.Visible = True
            TextBox8.Visible = True
            TextBox9.Visible = False
            TextBox10.Visible = False
            TextBox11.Visible = False
            TextBox12.Visible = False
            TextBox13.Visible = False
            TextBox14.Visible = False
            TextBox15.Visible = False
            TextBox16.Visible = False
            save1.Enabled = False
            saveadd.Visible = True
            save.Visible = False
            delete.Visible = False
            DropDownList2.Enabled = False
        ElseIf Label7.Text = "021" Then
            datagridvalue()
            add.Visible = False
            view.Visible = False
            add_deposit.Visible = False
            TextBox1.Visible = False
            TextBox2.Visible = False
            TextBox3.Visible = False
            TextBox4.Visible = False
            TextBox5.Visible = False
            TextBox6.Visible = True
            TextBox7.Visible = True
            TextBox8.Visible = True
            TextBox9.Visible = False
            TextBox10.Visible = False
            TextBox11.Visible = False
            TextBox12.Visible = False
            TextBox13.Visible = False
            TextBox14.Visible = False
            TextBox15.Visible = False
            TextBox16.Visible = False
            save1.Enabled = False
            saveadd.Visible = True
            save.Visible = False
            delete.Visible = False
            DropDownList2.Enabled = False
        ElseIf Label7.Text = "022.1" Then
            datagridvalue()
            add.Visible = False
            view.Visible = False
            add_deposit.Visible = False
            TextBox1.Visible = False
            TextBox2.Visible = False
            TextBox3.Visible = False
            TextBox4.Visible = False
            TextBox5.Visible = False
            TextBox6.Visible = True
            TextBox7.Visible = True
            TextBox8.Visible = False
            TextBox9.Visible = False
            TextBox10.Visible = False
            TextBox11.Visible = False
            TextBox12.Visible = False
            TextBox13.Visible = False
            TextBox14.Visible = False
            TextBox15.Visible = False
            TextBox16.Visible = False
            save1.Enabled = False
            saveadd.Visible = True
            save.Visible = False
            delete.Visible = False
            DropDownList2.Enabled = False
        ElseIf Label7.Text = "022.2" Then
            datagridvalue()
            add.Visible = False
            view.Visible = False
            add_deposit.Visible = False
            TextBox1.Visible = False
            TextBox2.Visible = False
            TextBox3.Visible = False
            TextBox4.Visible = False
            TextBox5.Visible = False
            TextBox6.Visible = True
            TextBox7.Visible = True
            TextBox8.Visible = False
            TextBox9.Visible = False
            TextBox10.Visible = False
            TextBox11.Visible = False
            TextBox12.Visible = False
            TextBox13.Visible = False
            TextBox14.Visible = False
            TextBox15.Visible = False
            TextBox16.Visible = False
            save1.Enabled = False
            saveadd.Visible = True
            save.Visible = False
            delete.Visible = False
            DropDownList2.Enabled = False
        ElseIf Label7.Text = "022.3" Then
            datagridvalue()
            add.Visible = False
            view.Visible = False
            add_deposit.Visible = False
            TextBox1.Visible = False
            TextBox2.Visible = False
            TextBox3.Visible = False
            TextBox4.Visible = False
            TextBox5.Visible = False
            TextBox6.Visible = True
            TextBox7.Visible = True
            TextBox8.Visible = False
            TextBox9.Visible = False
            TextBox10.Visible = False
            TextBox11.Visible = False
            TextBox12.Visible = False
            TextBox13.Visible = False
            TextBox14.Visible = False
            TextBox15.Visible = False
            TextBox16.Visible = False
            save1.Enabled = False
            saveadd.Visible = True
            save.Visible = False
            delete.Visible = False
            DropDownList2.Enabled = False
        ElseIf Label7.Text = "022.4" Then
            datagridvalue()
            add.Visible = False
            view.Visible = False
            add_deposit.Visible = False
            TextBox1.Visible = False
            TextBox2.Visible = False
            TextBox3.Visible = False
            TextBox4.Visible = False
            TextBox5.Visible = False
            TextBox6.Visible = True
            TextBox7.Visible = True
            TextBox8.Visible = False
            TextBox9.Visible = False
            TextBox10.Visible = False
            TextBox11.Visible = False
            TextBox12.Visible = False
            TextBox13.Visible = False
            TextBox14.Visible = False
            TextBox15.Visible = False
            TextBox16.Visible = False
            save1.Enabled = False
            saveadd.Visible = True
            save.Visible = False
            delete.Visible = False
            DropDownList2.Enabled = False
        ElseIf Label7.Text = "022.5" Then
            datagridvalue()
            add.Visible = False
            view.Visible = False
            add_deposit.Visible = False
            TextBox1.Visible = False
            TextBox2.Visible = False
            TextBox3.Visible = False
            TextBox4.Visible = False
            TextBox5.Visible = False
            TextBox6.Visible = True
            TextBox7.Visible = True
            TextBox8.Visible = False
            TextBox9.Visible = False
            TextBox10.Visible = False
            TextBox11.Visible = False
            TextBox12.Visible = False
            TextBox13.Visible = False
            TextBox14.Visible = False
            TextBox15.Visible = False
            TextBox16.Visible = False
            save1.Enabled = False
            saveadd.Visible = True
            save.Visible = False
            delete.Visible = False
            DropDownList2.Enabled = False
        ElseIf Label7.Text = "022.6" Then
            datagridvalue()
            add.Visible = False
            view.Visible = False
            add_deposit.Visible = False
            TextBox1.Visible = False
            TextBox2.Visible = False
            TextBox3.Visible = False
            TextBox4.Visible = False
            TextBox5.Visible = False
            TextBox6.Visible = True
            TextBox7.Visible = True
            TextBox8.Visible = False
            TextBox9.Visible = False
            TextBox10.Visible = False
            TextBox11.Visible = False
            TextBox12.Visible = False
            TextBox13.Visible = False
            TextBox14.Visible = False
            TextBox15.Visible = False
            TextBox16.Visible = False
            save1.Enabled = False
            saveadd.Visible = True
            save.Visible = False
            delete.Visible = False
            DropDownList2.Enabled = False
        ElseIf Label7.Text = "022.7" Then
            datagridvalue()
            add.Visible = False
            view.Visible = False
            add_deposit.Visible = False
            TextBox1.Visible = False
            TextBox2.Visible = False
            TextBox3.Visible = False
            TextBox4.Visible = False
            TextBox5.Visible = False
            TextBox6.Visible = True
            TextBox7.Visible = True
            TextBox8.Visible = False
            TextBox9.Visible = False
            TextBox10.Visible = False
            TextBox11.Visible = False
            TextBox12.Visible = False
            TextBox13.Visible = False
            TextBox14.Visible = False
            TextBox15.Visible = False
            TextBox16.Visible = False
            save1.Enabled = False
            saveadd.Visible = True
            save.Visible = False
            delete.Visible = False
            DropDownList2.Enabled = False
        ElseIf Label7.Text = "022.8" Then
            datagridvalue()
            add.Visible = False
            view.Visible = False
            add_deposit.Visible = False
            TextBox1.Visible = False
            TextBox2.Visible = False
            TextBox3.Visible = False
            TextBox4.Visible = False
            TextBox5.Visible = False
            TextBox6.Visible = True
            TextBox7.Visible = True
            TextBox8.Visible = False
            TextBox9.Visible = False
            TextBox10.Visible = False
            TextBox11.Visible = False
            TextBox12.Visible = False
            TextBox13.Visible = False
            TextBox14.Visible = False
            TextBox15.Visible = False
            TextBox16.Visible = False
            save1.Enabled = False
            saveadd.Visible = True
            save.Visible = False
            delete.Visible = False
            DropDownList2.Enabled = False
        ElseIf Label7.Text = "023" Then
            datagridvalue()
            add.Visible = False
            view.Visible = False
            add_deposit.Visible = False
            calender4.Visible = True
            TextBox1.Visible = False
            TextBox2.Visible = False
            TextBox3.Visible = False
            TextBox4.Visible = False
            TextBox5.Visible = False
            TextBox6.Visible = True
            TextBox6.Enabled = True
            TextBox7.Visible = True
            TextBox8.Visible = True
            TextBox9.Visible = False
            TextBox10.Visible = False
            TextBox11.Visible = False
            TextBox12.Visible = True
            TextBox13.Visible = False
            TextBox14.Visible = True
            TextBox15.Visible = True
            TextBox16.Visible = False
            save1.Enabled = False
            saveadd.Visible = True
            save.Visible = False
            delete.Visible = False
            DropDownList2.Enabled = False
            DropDownList3.Visible = True
        End If
    End Function

    Protected Sub saveadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles saveadd.Click

        If Label7.Text = "01" Then
            save_add_agen_pengangkutan()
        ElseIf datadetail.Text = "02.1" Or Label7.Text = "02.1" Then
            save_add_bentuk_ikan_1()
        ElseIf datadetail.Text = "02.2" Or Label7.Text = "02.2" Then
            save_add_bentuk_ikan_2()
        ElseIf datadetail.Text = "02.3" Or Label7.Text = "02.3" Then
            save_add_bentuk_ikan_3()
        ElseIf datadetail.Text = "02.4" Or Label7.Text = "02.4" Then
            save_add_bentuk_ikan_4()
        ElseIf datadetail.Text = "02.5" Or Label7.Text = "02.5" Then
            save_add_bentuk_ikan_5()
        ElseIf Label7.Text = "03" Then
            save_add_caj_perkhidmatan()
        ElseIf Label7.Text = "04" Then
            save_add_cara_pengangkutan()
        ElseIf Label7.Text = "05" Then
            save_add_destinasi_pasar()
        ElseIf Label7.Text = "06" Then
            save_add_gred_saiz()
        ElseIf Label7.Text = "07" Then
            save_add_caj_ikan()
        ElseIf Label7.Text = "08" Then
            save_add_jenis()
        ElseIf Label7.Text = "09" Then
            save_add_jenis_ikan()
        ElseIf Label7.Text = "010" Then
            save_add_jenis_pengangkutan()
        ElseIf Label7.Text = "011" Then
            save_add_jenis_urusan()
        ElseIf Label7.Text = "012" Then
            save_add_kategori()
        ElseIf Label7.Text = "013" Then
            save_add_kumpulan()
        ElseIf Label7.Text = "014" Then
            save_add_lesen()
        ElseIf Label7.Text = "015" Then
            save_add_negara()
        ElseIf Label7.Text = "016" Then
            save_add_negeri()
        ElseIf Label7.Text = "017" Then
            save_add_pengeksport()
        ElseIf Label7.Text = "018" Then
            save_add_pengimport_malaysia()
        ElseIf Label7.Text = "019" Then
            save_add_pengeksport_thai()
        ElseIf Label7.Text = "020" Then
            save_add_pengimport_thai()
        ElseIf Label7.Text = "021" Then
            save_add_komplex()
        ElseIf Label7.Text = "022.1" Then
            save_add_spesis1()
        ElseIf Label7.Text = "022.2" Then
            save_add_spesis2()
        ElseIf Label7.Text = "022.3" Then
            save_add_spesis3()
        ElseIf Label7.Text = "022.4" Then
            save_add_spesis4()
        ElseIf Label7.Text = "022.5" Then
            save_add_spesis5()
        ElseIf Label7.Text = "022.6" Then
            save_add_spesis6()
        ElseIf Label7.Text = "022.7" Then
            save_add_spesis7()
        ElseIf Label7.Text = "022.8" Then
            save_add_spesis8()
        ElseIf Label7.Text = "023" Then
            save_add_epermit()
        End If

    End Sub

    Function save_add_agen_pengangkutan()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from agen_pengangkutan where kod_agen_pengangkutan='" & TextBox6.Text & "'", myconn)
        Dim SqlRdr As SqlDataReader
        Dim str As String
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        Dim myconn1 As New SqlConnection(connectionstring)
        myconn1.Open()

        If SqlRdr.HasRows Then
            Response.Write("<script> alert('kod agen telah wujud');history.back();</script>")

        Else

            str = "INSERT INTO AGEN_PENGANGKUTAN(Kod_Agen_Pengangkutan, Nama_Agen_Pengangkutan, Alamat_Agen_Pengangkutan, Deposit_Semasa, Transaksi_Semasa, rowguid)" _
            & "VALUES('" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','0','0','{00000000-0000-0000-0000-000000000000}')"

            Dim mycmd1 As New SqlCommand(str, myconn1)
            Dim rekodUpdate As Integer = mycmd1.ExecuteNonQuery()

            Response.Write("<script> alert('successfully add');history.back();</script>")

        End If

        myconn1.Close()
        myconn.Close()


    End Function

    Function save_add_bentuk_ikan_1()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from bentuk_ikan_1 where kod_bentuk_ikan_1='" & TextBox6.Text & "'", myconn)
        Dim SqlRdr As SqlDataReader
        Dim str As String
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        Dim myconn1 As New SqlConnection(connectionstring)
        myconn1.Open()

        If SqlRdr.HasRows Then
            Response.Write("<script> alert('kod bentuk ikan telah wujud');history.back();</script>")

        Else

            str = "INSERT INTO bentuk_ikan_1(Kod_Bentuk_Ikan_1, Nama_Bentuk_Ikan_1, rowguid)" _
            & "VALUES('" & TextBox6.Text & "','" & TextBox7.Text & "','{00000000-0000-0000-0000-000000000000}')"

            Dim mycmd1 As New SqlCommand(str, myconn1)
            Dim rekodUpdate As Integer = mycmd1.ExecuteNonQuery()

            Response.Write("<script> alert('successfully add');history.back();</script>")

        End If

        myconn1.Close()
        myconn.Close()


    End Function

    Function save_add_bentuk_ikan_2()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from bentuk_ikan_2 where kod_bentuk_ikan_2='" & TextBox6.Text & "'", myconn)
        Dim SqlRdr As SqlDataReader
        Dim str As String
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        Dim myconn1 As New SqlConnection(connectionstring)
        myconn1.Open()

        If SqlRdr.HasRows Then
            Response.Write("<script> alert('kod bentuk ikan telah wujud');history.back();</script>")

        Else

            str = "INSERT INTO bentuk_ikan_2(Kod_Bentuk_Ikan_2, Nama_Bentuk_Ikan_2, rowguid)" _
           & "VALUES('" & TextBox6.Text & "','" & TextBox7.Text & "','{00000000-0000-0000-0000-000000000000}')"

            Dim mycmd1 As New SqlCommand(str, myconn1)
            Dim rekodUpdate As Integer = mycmd1.ExecuteNonQuery()

            Response.Write("<script> alert('successfully add');history.back();</script>")

        End If

        myconn1.Close()
        myconn.Close()


    End Function

    Function save_add_bentuk_ikan_3()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from bentuk_ikan_3 where kod_bentuk_ikan_3='" & TextBox6.Text & "'", myconn)
        Dim SqlRdr As SqlDataReader
        Dim str As String
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        Dim myconn1 As New SqlConnection(connectionstring)
        myconn1.Open()

        If SqlRdr.HasRows Then
            Response.Write("<script> alert('kod bentuk ikan telah wujud');history.back();</script>")

        Else

            str = "INSERT INTO bentuk_ikan_3(Kod_Bentuk_Ikan_3, Nama_Bentuk_Ikan_3, rowguid)" _
             & "VALUES('" & TextBox6.Text & "','" & TextBox7.Text & "','{00000000-0000-0000-0000-000000000000}')"

            Dim mycmd1 As New SqlCommand(str, myconn1)
            Dim rekodUpdate As Integer = mycmd1.ExecuteNonQuery()

            Response.Write("<script> alert('successfully add');history.back();</script>")

        End If

        myconn1.Close()
        myconn.Close()


    End Function

    Function save_add_bentuk_ikan_4()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from bentuk_ikan_4 where kod_bentuk_ikan_4='" & TextBox6.Text & "'", myconn)
        Dim SqlRdr As SqlDataReader
        Dim str As String
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        Dim myconn1 As New SqlConnection(connectionstring)
        myconn1.Open()

        If SqlRdr.HasRows Then
            Response.Write("<script> alert('kod bentuk ikan telah wujud');history.back();</script>")

        Else

            str = "INSERT INTO bentuk_ikan_4(Kod_Bentuk_Ikan_4, Nama_Bentuk_Ikan_4, rowguid)" _
          & "VALUES('" & TextBox6.Text & "','" & TextBox7.Text & "','{00000000-0000-0000-0000-000000000000}')"

            Dim mycmd1 As New SqlCommand(str, myconn1)
            Dim rekodUpdate As Integer = mycmd1.ExecuteNonQuery()

            Response.Write("<script> alert('successfully add');history.back();</script>")

        End If

        myconn1.Close()
        myconn.Close()


    End Function

    Function save_add_bentuk_ikan_5()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from bentuk_ikan_5 where kod_bentuk_ikan_5='" & TextBox6.Text & "'", myconn)
        Dim SqlRdr As SqlDataReader
        Dim str As String
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        Dim myconn1 As New SqlConnection(connectionstring)
        myconn1.Open()

        If SqlRdr.HasRows Then
            Response.Write("<script> alert('kod bentuk ikan telah wujud');history.back();</script>")

        Else

            str = "INSERT INTO bentuk_ikan_5(Kod_Bentuk_Ikan_5, Nama_Bentuk_Ikan_5, rowguid)" _
           & "VALUES('" & TextBox6.Text & "','" & TextBox7.Text & "','{00000000-0000-0000-0000-000000000000}')"

            Dim mycmd1 As New SqlCommand(str, myconn1)
            Dim rekodUpdate As Integer = mycmd1.ExecuteNonQuery()

            Response.Write("<script> alert('successfully add');history.back();</script>")

        End If

        myconn1.Close()
        myconn.Close()


    End Function

    Function save_add_caj_perkhidmatan()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from caj_perkhidmatan where kod_caj ='" & TextBox6.Text & "'", myconn)
        Dim SqlRdr As SqlDataReader
        Dim str As String
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        Dim myconn1 As New SqlConnection(connectionstring)
        myconn1.Open()

        If SqlRdr.HasRows Then
            Response.Write("<script> alert('kod caj perkhidmatan telah wujud');history.back();</script>")

        Else

            str = "INSERT INTO caj_perkhidmatan(Kod_caj, Nama_caj, kadar_caj, cara_pembayaran, dicaj_oleh, rowguid)" _
            & "VALUES('" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','{00000000-0000-0000-0000-000000000000}')"

            Dim mycmd1 As New SqlCommand(str, myconn1)
            Dim rekodUpdate As Integer = mycmd1.ExecuteNonQuery()

            Response.Write("<script> alert('successfully add');history.back();</script>")

        End If

        myconn1.Close()
        myconn.Close()


    End Function

    Function save_add_cara_pengangkutan()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from cara_pengangkutan where kod_cara_pengangkutan='" & TextBox6.Text & "'", myconn)
        Dim SqlRdr As SqlDataReader
        Dim str As String
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        Dim myconn1 As New SqlConnection(connectionstring)
        myconn1.Open()

        If SqlRdr.HasRows Then
            Response.Write("<script> alert('kod cara pengangkutan telah wujud');history.back();</script>")

        Else

            str = "INSERT INTO cara_pengangkutan(kod_cara_pengangkutan , nama_cara_pengangkutan, rowguid )" _
            & "VALUES('" & TextBox6.Text & "','" & TextBox7.Text & "','{00000000-0000-0000-0000-000000000000}')"

            Dim mycmd1 As New SqlCommand(str, myconn1)
            Dim rekodUpdate As Integer = mycmd1.ExecuteNonQuery()

            Response.Write("<script> alert('successfully add');history.back();</script>")
        End If

        myconn1.Close()
        myconn.Close()


    End Function

    Function save_add_destinasi_pasar()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from destinasi_pasar where kod_pasar='" & TextBox6.Text & "'", myconn)
        Dim SqlRdr As SqlDataReader
        Dim str As String
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        Dim myconn1 As New SqlConnection(connectionstring)
        myconn1.Open()

        If SqlRdr.HasRows Then
            Response.Write("<script> alert('kod destinasi pasar telah wujud');history.back();</script>")

        Else

            str = "INSERT INTO destinasi_pasar(kod_pasar, nama_pasar, rowguid)" _
            & "VALUES('" & TextBox6.Text & "','" & TextBox7.Text & "','{00000000-0000-0000-0000-000000000000}')"

            Dim mycmd1 As New SqlCommand(str, myconn1)
            Dim rekodUpdate As Integer = mycmd1.ExecuteNonQuery()

            Response.Write("<script> alert('successfully add');history.back();</script>")

        End If

        myconn1.Close()
        myconn.Close()


    End Function

    Function save_add_gred_saiz()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from Gred_saiz where kod_Gredsaiz='" & TextBox6.Text & "'", myconn)
        Dim SqlRdr As SqlDataReader
        Dim str As String
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        Dim myconn1 As New SqlConnection(connectionstring)
        myconn1.Open()

        If SqlRdr.HasRows Then
            Response.Write("<script> alert('kod gred / saiz telah wujud');history.back();</script>")

        Else

            str = "INSERT INTO Gred_saiz(kod_Gredsaiz, nama_Gredsaiz ,rowguid)" _
            & "VALUES('" & TextBox6.Text & "','" & TextBox7.Text & "','{00000000-0000-0000-0000-000000000000}')"

            Dim mycmd1 As New SqlCommand(str, myconn1)
            Dim rekodUpdate As Integer = mycmd1.ExecuteNonQuery()

            Response.Write("<script> alert('successfully add');history.back();</script>")

        End If

        myconn1.Close()
        myconn.Close()


    End Function

    Function save_add_caj_ikan()

        Dim str As String
        Dim myconn1 As New SqlConnection(connectionstring)
        myconn1.Open()

        str = "INSERT INTO ikan_caj(kategori_ikan, jenis_urusan, kadar_peti_kecil, kadar_peti_besar, kadar_ekor, kadar_kuantiti)" _
        & "VALUES('" & TextBox7.Text & "','" & TextBox8.Text & "'," & TextBox12.Text & "," & TextBox13.Text & "," & TextBox14.Text & "," & TextBox15.Text & ")"

        Dim mycmd1 As New SqlCommand(str, myconn1)
        Dim rekodUpdate As Integer = mycmd1.ExecuteNonQuery()

        Response.Write("<script> alert('successfully add');history.back();</script>")

        myconn1.Close()

    End Function

    Function save_add_jenis()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from jenis_barangan where kod_barangan='" & TextBox6.Text & "'", myconn)
        Dim SqlRdr As SqlDataReader
        Dim str As String
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        Dim myconn1 As New SqlConnection(connectionstring)
        myconn1.Open()

        If SqlRdr.HasRows Then
            Response.Write("<script> alert('kod jenis telah wujud');history.back();</script>")

        Else

            str = "INSERT INTO jenis_barangan(kod_barangan, nama_barangan, rowguid)" _
            & "VALUES('" & TextBox6.Text & "','" & TextBox7.Text & "','{00000000-0000-0000-0000-000000000000}')"

            Dim mycmd1 As New SqlCommand(str, myconn1)
            Dim rekodUpdate As Integer = mycmd1.ExecuteNonQuery()

            Response.Write("<script> alert('successfully add');history.back();</script>")

        End If

        myconn1.Close()
        myconn.Close()


    End Function

    Function save_add_jenis_ikan()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from jenis_ikan where kod_bkh='" & TextBox6.Text & "'", myconn)
        Dim SqlRdr As SqlDataReader
        Dim str As String
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        Dim myconn1 As New SqlConnection(connectionstring)
        myconn1.Open()

        If SqlRdr.HasRows Then
            Response.Write("<script> alert('kod jenis ikan telah wujud');history.back();</script>")

        Else

            str = "INSERT INTO jenis_ikan (kod_bkh, kod_ikan, nama_bkh, harga_bkh, rowguid)" _
            & "VALUES('" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','" & TextBox12.Text & "','{00000000-0000-0000-0000-000000000000}')"

            Dim mycmd1 As New SqlCommand(str, myconn1)
            Dim rekodUpdate As Integer = mycmd1.ExecuteNonQuery()

            Response.Write("<script> alert('successfully add');history.back();</script>")

        End If

        myconn1.Close()
        myconn.Close()


    End Function

    Function save_add_jenis_pengangkutan()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from jenis_pengangkutan where kod_pengangkutan ='" & TextBox6.Text & "'", myconn)
        Dim SqlRdr As SqlDataReader
        Dim str As String
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        Dim myconn1 As New SqlConnection(connectionstring)
        myconn1.Open()

        If SqlRdr.HasRows Then
            Response.Write("<script> alert('kod jenis pengangkutan telah wujud');history.back();</script>")

        Else

            str = "INSERT INTO jenis_pengangkutan (kod_pengangkutan , nama_pengangkutan , caj_pengangkutan , rowguid)" _
            & "VALUES('" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','{00000000-0000-0000-0000-000000000000}')"

            Dim mycmd1 As New SqlCommand(str, myconn1)
            Dim rekodUpdate As Integer = mycmd1.ExecuteNonQuery()

            Response.Write("<script> alert('successfully add');history.back();</script>")

        End If

        myconn1.Close()
        myconn.Close()


    End Function

    Function save_add_jenis_urusan()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from jenis_urusan where kod_urusan='" & TextBox6.Text & "'", myconn)
        Dim SqlRdr As SqlDataReader
        Dim str As String
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        Dim myconn1 As New SqlConnection(connectionstring)
        myconn1.Open()

        If SqlRdr.HasRows Then
            Response.Write("<script> alert('kod jenis urusan telah wujud');history.back();</script>")

        Else

            str = "INSERT INTO jenis_urusan(kod_urusan , nama_urusan , borang)" _
            & "VALUES('" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "')"

            Dim mycmd1 As New SqlCommand(str, myconn1)
            Dim rekodUpdate As Integer = mycmd1.ExecuteNonQuery()

            Response.Write("<script> alert('successfully add');history.back();</script>")

        End If

        myconn1.Close()
        myconn.Close()


    End Function

    Function save_add_kategori()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from kategori_ikan where kod_kategori_ikan='" & TextBox6.Text & "'", myconn)
        Dim SqlRdr As SqlDataReader
        Dim str As String
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        Dim myconn1 As New SqlConnection(connectionstring)
        myconn1.Open()

        If SqlRdr.HasRows Then
            Response.Write("<script> alert('kod kategori telah wujud');history.back();</script>")

        Else

            str = "INSERT INTO kategori_ikan(kod_kategori_ikan  , nama_kategori_ikan  , rowguid)" _
            & "VALUES('" & TextBox6.Text & "','" & TextBox7.Text & "','{00000000-0000-0000-0000-000000000000}')"

            Dim mycmd1 As New SqlCommand(str, myconn1)
            Dim rekodUpdate As Integer = mycmd1.ExecuteNonQuery()

            Response.Write("<script> alert('successfully add');history.back();</script>")

        End If

        myconn1.Close()
        myconn.Close()


    End Function

    Function save_add_kumpulan()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from kumpulan_ikan where kod_kumpulan_ikan ='" & TextBox6.Text & "'", myconn)
        Dim SqlRdr As SqlDataReader
        Dim str As String
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        Dim myconn1 As New SqlConnection(connectionstring)
        myconn1.Open()

        If SqlRdr.HasRows Then
            Response.Write("<script> alert('kod kumpulan telah wujud');history.back();</script>")

        Else

            str = "INSERT INTO kumpulan_ikan(kod_kumpulan_ikan , nama_kumpulan_ikan , rowguid)" _
            & "VALUES('" & TextBox6.Text & "','" & TextBox7.Text & "','{00000000-0000-0000-0000-000000000000}')"

            Dim mycmd1 As New SqlCommand(str, myconn1)
            Dim rekodUpdate As Integer = mycmd1.ExecuteNonQuery()

            Response.Write("<script> alert('successfully add');history.back();</script>")

        End If

        myconn1.Close()
        myconn.Close()


    End Function

    Function save_add_lesen()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from lesen where no_lesen='" & TextBox6.Text & "'", myconn)
        Dim SqlRdr As SqlDataReader
        Dim str As String
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        Dim myconn1 As New SqlConnection(connectionstring)
        myconn1.Open()

        If SqlRdr.HasRows Then
            Response.Write("<script> alert('kod lesen telah wujud');history.back();</script>")

        Else

            str = "INSERT INTO lesen(no_lesen , tarikh_tamat , tarikh_disah , kawasan , siri_lesen , rowguid)" _
            & "VALUES('" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','" & TextBox12.Text & "','" & TextBox13.Text & "','{00000000-0000-0000-0000-000000000000}')"

            Dim mycmd1 As New SqlCommand(str, myconn1)
            Dim rekodUpdate As Integer = mycmd1.ExecuteNonQuery()

            Response.Write("<script> alert('successfully add');history.back();</script>")

        End If

        myconn1.Close()
        myconn.Close()


    End Function

    Function save_add_negara()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from negara where kod_negara='" & TextBox6.Text & "'", myconn)
        Dim SqlRdr As SqlDataReader
        Dim str As String
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        Dim myconn1 As New SqlConnection(connectionstring)
        myconn1.Open()

        If SqlRdr.HasRows Then
            Response.Write("<script> alert('kod negara telah wujud');history.back();</script>")

        Else

            str = "INSERT INTO negara(kod_negara , Nama_negara, rowguid)" _
            & "VALUES('" & TextBox6.Text & "','" & TextBox7.Text & "','{00000000-0000-0000-0000-000000000000}')"

            Dim mycmd1 As New SqlCommand(str, myconn1)
            Dim rekodUpdate As Integer = mycmd1.ExecuteNonQuery()

            Response.Write("<script> alert('successfully add');history.back();</script>")

        End If

        myconn1.Close()
        myconn.Close()


    End Function

    Function save_add_negeri()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from negeri where kod_negeri='" & TextBox6.Text & "'", myconn)
        Dim SqlRdr As SqlDataReader
        Dim str As String
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        Dim myconn1 As New SqlConnection(connectionstring)
        myconn1.Open()

        If SqlRdr.HasRows Then
            Response.Write("<script> alert('kod negeri telah wujud');history.back();</script>")

        Else

            str = "INSERT INTO negeri(kod_negeri , nama_negeri , rowguid)" _
            & "VALUES('" & TextBox6.Text & "','" & TextBox7.Text & "','{00000000-0000-0000-0000-000000000000}')"

            Dim mycmd1 As New SqlCommand(str, myconn1)
            Dim rekodUpdate As Integer = mycmd1.ExecuteNonQuery()

            Response.Write("<script> alert('successfully add');history.back();</script>")

        End If

        myconn1.Close()
        myconn.Close()


    End Function

    Function save_add_pengeksport()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from pengeksport where kod_pengeksport='" & TextBox6.Text & "'", myconn)
        Dim SqlRdr As SqlDataReader
        Dim str As String
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        Dim myconn1 As New SqlConnection(connectionstring)
        myconn1.Open()

        If SqlRdr.HasRows Then
            Response.Write("<script> alert('kod pengeksport malaysia telah wujud');history.back();</script>")

        Else

            str = "INSERT INTO pengeksport(kod_pengeksport,nama_syarikat_eksport, alamat_syarikat_eksport, no_lesen, tarikh_dimasukkan, rowguid)" _
            & "VALUES('" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','" & TextBox12.Text & "','" & TextBox5.Text & "','{00000000-0000-0000-0000-000000000000}')"

            Dim mycmd1 As New SqlCommand(str, myconn1)
            Dim rekodUpdate As Integer = mycmd1.ExecuteNonQuery()

            Response.Write("<script> alert('successfully add');history.back();</script>")

        End If

        myconn1.Close()
        myconn.Close()


    End Function

    Function save_add_pengimport_malaysia()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from pengimport where kod_pengimport='" & TextBox6.Text & "'", myconn)
        Dim SqlRdr As SqlDataReader
        Dim str As String
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        Dim myconn1 As New SqlConnection(connectionstring)
        myconn1.Open()

        If SqlRdr.HasRows Then
            Response.Write("<script> alert('kod pengimport malaysia telah wujud');history.back();</script>")

        Else

            str = "INSERT INTO pengimport(kod_pengimport , nama_syarikat_import ,alamat_syarikat_import ,no_lesen ,alamat_menyurat ,nama_pemilik ,no_kp ,no_tel , rowguid)" _
            & "VALUES('" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','" & TextBox12.Text & "','" & TextBox13.Text & "','" & TextBox14.Text & "','" & TextBox15.Text & "','" & TextBox16.Text & "',''{00000000-0000-0000-0000-000000000000})"

            Dim mycmd1 As New SqlCommand(str, myconn1)
            Dim rekodUpdate As Integer = mycmd1.ExecuteNonQuery()

            Response.Write("<script> alert('successfully add');history.back();</script>")

        End If

        myconn1.Close()
        myconn.Close()


    End Function

    Function save_add_pengeksport_thai()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from pengeksport_thailand where kod_pengeksport='" & TextBox6.Text & "'", myconn)
        Dim SqlRdr As SqlDataReader
        Dim str As String
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        Dim myconn1 As New SqlConnection(connectionstring)
        myconn1.Open()

        If SqlRdr.HasRows Then
            Response.Write("<script> alert('kod pengeksport thailand telah wujud');history.back();</script>")

        Else

            str = "INSERT INTO pengeksport_thailand(kod_pengeksport , nama_pengeksport , alamat_pengeksport , rowguid)" _
            & "VALUES('" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','{00000000-0000-0000-0000-000000000000}')"

            Dim mycmd1 As New SqlCommand(str, myconn1)
            Dim rekodUpdate As Integer = mycmd1.ExecuteNonQuery()

            Response.Write("<script> alert('successfully add');history.back();</script>")

        End If

        myconn1.Close()
        myconn.Close()


    End Function

    Function save_add_pengimport_thai()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from pengimport_thailand where kod_pengimport='" & TextBox6.Text & "'", myconn)
        Dim SqlRdr As SqlDataReader
        Dim str As String
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        Dim myconn1 As New SqlConnection(connectionstring)
        myconn1.Open()

        If SqlRdr.HasRows Then
            Response.Write("<script> alert('kod pengimport malaysia telah wujud');history.back();</script>")

        Else

            str = "INSERT INTO pengimport_thailand(kod_pengimport , nama_pengimport , alamat_pengimport , rowguid)" _
            & "VALUES('" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','{00000000-0000-0000-0000-000000000000}')"

            Dim mycmd1 As New SqlCommand(str, myconn1)
            Dim rekodUpdate As Integer = mycmd1.ExecuteNonQuery()

            Response.Write("<script> alert('successfully add');history.back();</script>")

        End If

        myconn1.Close()
        myconn.Close()


    End Function

    Function save_add_komplex()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from pusatkomplek where kod_ppi='" & TextBox6.Text & "'", myconn)
        Dim SqlRdr As SqlDataReader
        Dim str As String
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        Dim myconn1 As New SqlConnection(connectionstring)
        myconn1.Open()

        If SqlRdr.HasRows Then
            Response.Write("<script> alert('kod komplex telah wujud');history.back();</script>")

        Else

            str = "INSERT INTO pusatkomplek(kod_ppi , nama_ppi , alamat_ppi , rowguid)" _
            & "VALUES('" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','{00000000-0000-0000-0000-000000000000}')"

            Dim mycmd1 As New SqlCommand(str, myconn1)
            Dim rekodUpdate As Integer = mycmd1.ExecuteNonQuery()

            Response.Write("<script> alert('successfully add');history.back();</script>")

        End If

        myconn1.Close()
        myconn.Close()


    End Function

    Function save_add_spesis1()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from spesis_ikan_1 where kod_spesis_ikan_1 ='" & TextBox6.Text & "'", myconn)
        Dim SqlRdr As SqlDataReader
        Dim str As String
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        Dim myconn1 As New SqlConnection(connectionstring)
        myconn1.Open()

        If SqlRdr.HasRows Then
            Response.Write("<script> alert('kod spesis telah wujud');history.back();</script>")

        Else

            str = "INSERT INTO spesis_ikan_1(kod_spesis_ikan_1 , nama_spesis_ikan_1 ,rowguid)" _
            & "VALUES('" & TextBox6.Text & "','" & TextBox7.Text & "','{00000000-0000-0000-0000-000000000000}')"

            Dim mycmd1 As New SqlCommand(str, myconn1)
            Dim rekodUpdate As Integer = mycmd1.ExecuteNonQuery()

            Response.Write("<script> alert('successfully add');history.back();</script>")

        End If

        myconn1.Close()
        myconn.Close()


    End Function

    Function save_add_spesis2()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from spesis_ikan_2 where kod_spesis_ikan_2 ='" & TextBox6.Text & "'", myconn)
        Dim SqlRdr As SqlDataReader
        Dim str As String
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        Dim myconn1 As New SqlConnection(connectionstring)
        myconn1.Open()

        If SqlRdr.HasRows Then
            Response.Write("<script> alert('kod spesis telah wujud');history.back();</script>")

        Else

            str = "INSERT INTO spesis_ikan_2(kod_spesis_ikan_2 , nama_spesis_ikan_2 ,rowguid)" _
            & "VALUES('" & TextBox6.Text & "','" & TextBox7.Text & "','{00000000-0000-0000-0000-000000000000}')"

            Dim mycmd1 As New SqlCommand(str, myconn1)
            Dim rekodUpdate As Integer = mycmd1.ExecuteNonQuery()

            Response.Write("<script> alert('successfully add');history.back();</script>")

        End If

        myconn1.Close()
        myconn.Close()


    End Function

    Function save_add_spesis3()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from spesis_ikan_3 where kod_spesis_ikan_3 ='" & TextBox6.Text & "'", myconn)
        Dim SqlRdr As SqlDataReader
        Dim str As String
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        Dim myconn1 As New SqlConnection(connectionstring)
        myconn1.Open()

        If SqlRdr.HasRows Then
            Response.Write("<script> alert('kod spesis telah wujud');history.back();</script>")

        Else

            str = "INSERT INTO spesis_ikan_3(kod_spesis_ikan_3 , nama_spesis_ikan_3 ,rowguid)" _
            & "VALUES('" & TextBox6.Text & "','" & TextBox7.Text & "','{00000000-0000-0000-0000-000000000000}')"

            Dim mycmd1 As New SqlCommand(str, myconn1)
            Dim rekodUpdate As Integer = mycmd1.ExecuteNonQuery()

            Response.Write("<script> alert('successfully add');history.back();</script>")

        End If

        myconn1.Close()
        myconn.Close()


    End Function

    Function save_add_spesis4()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from spesis_ikan_4 where kod_spesis_ikan_4 ='" & TextBox6.Text & "'", myconn)
        Dim SqlRdr As SqlDataReader
        Dim str As String
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        Dim myconn1 As New SqlConnection(connectionstring)
        myconn1.Open()

        If SqlRdr.HasRows Then
            Response.Write("<script> alert('kod spesis telah wujud');history.back();</script>")

        Else

            str = "INSERT INTO spesis_ikan_4(kod_spesis_ikan_4 , nama_spesis_ikan_4 ,rowguid)" _
            & "VALUES('" & TextBox6.Text & "','" & TextBox7.Text & "','{00000000-0000-0000-0000-000000000000}')"

            Dim mycmd1 As New SqlCommand(str, myconn1)
            Dim rekodUpdate As Integer = mycmd1.ExecuteNonQuery()

            Response.Write("<script> alert('successfully add');history.back();</script>")

        End If

        myconn1.Close()
        myconn.Close()


    End Function

    Function save_add_spesis5()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from spesis_ikan_5 where kod_spesis_ikan_5 ='" & TextBox6.Text & "'", myconn)
        Dim SqlRdr As SqlDataReader
        Dim str As String
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        Dim myconn1 As New SqlConnection(connectionstring)
        myconn1.Open()

        If SqlRdr.HasRows Then
            Response.Write("<script> alert('kod spesis telah wujud');history.back();</script>")

        Else

            str = "INSERT INTO spesis_ikan_5(kod_spesis_ikan_5 , nama_spesis_ikan_5 ,rowguid)" _
            & "VALUES('" & TextBox6.Text & "','" & TextBox7.Text & "','{00000000-0000-0000-0000-000000000000}')"

            Dim mycmd1 As New SqlCommand(str, myconn1)
            Dim rekodUpdate As Integer = mycmd1.ExecuteNonQuery()

            Response.Write("<script> alert('successfully add');history.back();</script>")

        End If

        myconn1.Close()
        myconn.Close()


    End Function

    Function save_add_spesis6()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from spesis_ikan_6 where kod_spesis_ikan_6 ='" & TextBox6.Text & "'", myconn)
        Dim SqlRdr As SqlDataReader
        Dim str As String
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        Dim myconn1 As New SqlConnection(connectionstring)
        myconn1.Open()

        If SqlRdr.HasRows Then
            Response.Write("<script> alert('kod spesis telah wujud');history.back();</script>")

        Else

            str = "INSERT INTO spesis_ikan_6(kod_spesis_ikan_6 , nama_spesis_ikan_6 ,rowguid)" _
            & "VALUES('" & TextBox6.Text & "','" & TextBox7.Text & "','{00000000-0000-0000-0000-000000000000}')"

            Dim mycmd1 As New SqlCommand(str, myconn1)
            Dim rekodUpdate As Integer = mycmd1.ExecuteNonQuery()

            Response.Write("<script> alert('successfully add');history.back();</script>")

        End If

        myconn1.Close()
        myconn.Close()


    End Function

    Function save_add_spesis7()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from spesis_ikan_7 where kod_spesis_ikan_7 ='" & TextBox6.Text & "'", myconn)
        Dim SqlRdr As SqlDataReader
        Dim str As String
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        Dim myconn1 As New SqlConnection(connectionstring)
        myconn1.Open()

        If SqlRdr.HasRows Then
            Response.Write("<script> alert('kod spesis telah wujud');history.back();</script>")

        Else

            str = "INSERT INTO spesis_ikan_7(kod_spesis_ikan_7 , nama_spesis_ikan_7 ,rowguid)" _
            & "VALUES('" & TextBox6.Text & "','" & TextBox7.Text & "','{00000000-0000-0000-0000-000000000000}')"

            Dim mycmd1 As New SqlCommand(str, myconn1)
            Dim rekodUpdate As Integer = mycmd1.ExecuteNonQuery()

            Response.Write("<script> alert('successfully add');history.back();</script>")

        End If

        myconn1.Close()
        myconn.Close()


    End Function

    Function save_add_spesis8()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from spesis_ikan_8 where kod_spesis_ikan_8 ='" & TextBox6.Text & "'", myconn)
        Dim SqlRdr As SqlDataReader
        Dim str As String
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        Dim myconn1 As New SqlConnection(connectionstring)
        myconn1.Open()

        If SqlRdr.HasRows Then
            Response.Write("<script> alert('kod spesis telah wujud');history.back();</script>")

        Else

            str = "INSERT INTO spesis_ikan_8(kod_spesis_ikan_8 , nama_spesis_ikan_8 ,rowguid)" _
            & "VALUES('" & TextBox6.Text & "','" & TextBox7.Text & "','{00000000-0000-0000-0000-000000000000}')"

            Dim mycmd1 As New SqlCommand(str, myconn1)
            Dim rekodUpdate As Integer = mycmd1.ExecuteNonQuery()

            Response.Write("<script> alert('successfully add');history.back();</script>")

        End If

        myconn1.Close()
        myconn.Close()


    End Function

    Function save_add_epermit()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from epermit_maintenance where epermit_serial_no ='" & TextBox6.Text & "'", myconn)
        Dim SqlRdr As SqlDataReader
        Dim str As String
        myconn.Open()
        SqlRdr = mycmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        Dim myconn1 As New SqlConnection(connectionstring)
        myconn1.Open()

        If SqlRdr.HasRows Then
            Response.Write("<script> alert('kod e-permit telah wujud');history.back();</script>")

        Else

            str = "INSERT INTO epermit_maintenance(epermit_serial_no, epermit_code, epermit_desc, epermit_cost, status, edate, userid)" _
            & "VALUES('" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','" & TextBox12.Text & "','" & DropDownList3.Text & "','" & TextBox14.Text & "','" & TextBox15.Text & "')"

            Dim mycmd1 As New SqlCommand(str, myconn1)
            Dim rekodUpdate As Integer = mycmd1.ExecuteNonQuery()

            Response.Write("<script> alert('successfully add');history.back();</script>")

        End If

        myconn1.Close()
        myconn.Close()


    End Function


    Protected Sub cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cancel.Click

        'Response.Write("<script>history.back();</script>")
        'Response.Write("<script>window.refresh();</script>")

        Server.Transfer("suntingmaklumat.aspx")

    End Sub

    Protected Sub save1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles save1.Click

        If Label7.Text = "01" Then
            save_current_deposit()
        End If

    End Sub

    Function save_current_deposit()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from agen_pengangkutan where kod_agen_pengangkutan ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "UPDATE agen_pengangkutan set deposit_semasa = '" & TextBox10.Text & "' where kod_agen_pengangkutan ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('successfully updated');history.back();</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()
        save1.Visible = False

    End Function

    Protected Sub add_deposit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles add_deposit.Click

        If Label7.Text = "01" Then
            deposit1()
        End If

    End Sub

    Function deposit1()

        add_deposit.Visible = False
        DropDownList2.Enabled = False
        Label9.Visible = True
        Label9.Text = "Add Deposit Semasa :"
        Label10.Visible = True
        Label10.Text = "Value of New Deposit Semasa:"
        TextBox10.Visible = True
        TextBox10.Enabled = True
        save1.Visible = True
        save.Visible = False
        TextBox1.Enabled = False
        TextBox1.Enabled = False
        TextBox9.Visible = True
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        Label1.Visible = True
        Label2.Visible = True
        Label3.Visible = True
        add.Visible = False
        add.Enabled = False
        delete.Enabled = False
        delete.Visible = False
        cancel.Visible = False
        back2.Visible = True
        view.Enabled = False
        view.Visible = False

    End Function

    Protected Sub delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles delete.Click

        If Label7.Text = "01" Then
            delete_agen()
        ElseIf datadetail.Text = "02.1" Or Label7.Text = "02.1" Then
            delete_bentuk_ikan_1()
        ElseIf datadetail.Text = "02.2" Or Label7.Text = "02.2" Then
            delete_bentuk_ikan_2()
        ElseIf datadetail.Text = "02.3" Or Label7.Text = "02.3" Then
            delete_bentuk_ikan_3()
        ElseIf datadetail.Text = "02.4" Or Label7.Text = "02.4" Then
            delete_bentuk_ikan_4()
        ElseIf datadetail.Text = "02.5" Or Label7.Text = "02.5" Then
            delete_bentuk_ikan_5()
        ElseIf Label7.Text = "03" Then
            delete_caj_perkhidmatan()
        ElseIf Label7.Text = "04" Then
            delete_cara_pengangkutan()
        ElseIf Label7.Text = "05" Then
            delete_destinasi_pasar()
        ElseIf Label7.Text = "06" Then
            delete_gred_saiz()
        ElseIf Label7.Text = "07" Then
            delete_caj_ikan()
        ElseIf Label7.Text = "08" Then
            delete_jenis()
        ElseIf Label7.Text = "09" Then
            delete_jenis_ikan()
        ElseIf Label7.Text = "010" Then
            delete_jenis_pengangkutan()
        ElseIf Label7.Text = "011" Then
            delete_jenis_urusan()
        ElseIf Label7.Text = "012" Then
            delete_kategori()
        ElseIf Label7.Text = "013" Then
            delete_kumpulan()
        ElseIf Label7.Text = "014" Then
            delete_lesen()
        ElseIf Label7.Text = "015" Then
            delete_negara()
        ElseIf Label7.Text = "016" Then
            delete_negeri()
        ElseIf Label7.Text = "017" Then
            delete_pengeksport()
        ElseIf Label7.Text = "018" Then
            delete_pengimport_malaysia()
        ElseIf Label7.Text = "019" Then
            delete_pengeksport_thai()
        ElseIf Label7.Text = "020" Then
            delete_pengimport_thai()
        ElseIf Label7.Text = "021" Then
            delete_komplex()
        ElseIf Label7.Text = "022.1" Then
            delete_spesis1()
        ElseIf Label7.Text = "022.2" Then
            delete_spesis2()
        ElseIf Label7.Text = "022.3" Then
            delete_spesis3()
        ElseIf Label7.Text = "022.4" Then
            delete_spesis4()
        ElseIf Label7.Text = "022.5" Then
            delete_spesis5()
        ElseIf Label7.Text = "022.6" Then
            delete_spesis6()
        ElseIf Label7.Text = "022.7" Then
            delete_spesis7()
        ElseIf Label7.Text = "022.8" Then
            delete_spesis8()
        ElseIf Label7.Text = "023" Then
            delete_epermit()
        End If

    End Sub

        Function delete_agen()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from agen_pengangkutan where kod_agen_pengangkutan ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "DELETE FROM AGEN_PENGANGKUTAN where kod_agen_pengangkutan ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)
        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('Delete successfull ');location.href='suntingmaklumat.aspx';</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function delete_bentuk_ikan_1()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from bentuk_ikan_1 where kod_bentuk_ikan_1='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "DELETE FROM bentuk_ikan_1 where kod_bentuk_ikan_1='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('Delete successfull ');location.href='suntingmaklumat.aspx';</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function delete_bentuk_ikan_2()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from bentuk_ikan_2 where kod_bentuk_ikan_2='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "DELETE FROM bentuk_ikan_2 where kod_bentuk_ikan_2='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('Delete successfull ');location.href='suntingmaklumat.aspx';</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function delete_bentuk_ikan_3()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from bentuk_ikan_3 where kod_bentuk_ikan_3='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "DELETE FROM bentuk_ikan_3 where kod_bentuk_ikan_3='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('Delete successfull ');location.href='suntingmaklumat.aspx';</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function delete_bentuk_ikan_4()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from bentuk_ikan_4 where kod_bentuk_ikan_4='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "DELETE FROM bentuk_ikan_4 where kod_bentuk_ikan_4='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('Delete successfull ');location.href='suntingmaklumat.aspx';</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function delete_bentuk_ikan_5()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from bentuk_ikan_5 where kod_bentuk_ikan_5='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "DELETE FROM bentuk_ikan_5 where kod_bentuk_ikan_5 ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('Delete successfull ');location.href='suntingmaklumat.aspx';</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function delete_caj_perkhidmatan()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from caj_perkhidmatan where kod_caj ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "DELETE FROM caj_perkhidmatan where kod_caj ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('Delete successfull ');location.href='suntingmaklumat.aspx';</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function delete_cara_pengangkutan()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from cara_pengangkutan where kod_cara_pengangkutan ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "DELETE FROM cara_pengangkutan where kod_cara_pengangkutan ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('Delete successfull ');location.href='suntingmaklumat.aspx';</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function delete_destinasi_pasar()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from destinasi_pasar where kod_pasar ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "DELETE FROM destinasi_pasar where kod_pasar ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('Delete successfull ');location.href='suntingmaklumat.aspx';</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function delete_gred_saiz()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from Gred_saiz where kod_Gredsaiz ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "DELETE FROM Gred_saiz where kod_Gredsaiz ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('Delete successfull ');location.href='suntingmaklumat.aspx';</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function delete_caj_ikan()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from ikan_caj where id ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "DELETE FROM ikan_caj where id ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('Delete successfull ');location.href='suntingmaklumat.aspx';</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function delete_jenis()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from jenis_barangan where kod_barangan ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "DELETE FROM jenis_barangan where kod_barangan ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('Delete successfull ');location.href='suntingmaklumat.aspx';</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function delete_jenis_ikan()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from jenis_ikan where kod_bkh ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "DELETE FROM jenis_ikan where kod_bkh ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('Delete successfull ');location.href='suntingmaklumat.aspx';</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function delete_jenis_pengangkutan()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from jenis_pengangkutan where kod_pengangkutan ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "DELETE FROM jenis_pengangkutan where kod_pengangkutan ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('Delete successfull ');location.href='suntingmaklumat.aspx';</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function delete_jenis_urusan()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from jenis_urusan where kod_urusan ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "DELETE FROM jenis_urusan where kod_urusan ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('Delete successfull ');location.href='suntingmaklumat.aspx';</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function delete_kategori()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from kategori_ikan where kod_kategori_ikan ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "DELETE FROM kategori_ikan where kod_kategori_ikan ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('Delete successfull ');location.href='suntingmaklumat.aspx';</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function delete_kumpulan()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from kumpulan_ikan where kod_kumpulan_ikan ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "DELETE FROM kumpulan_ikan where kod_kumpulan_ikan ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('Delete successfull ');location.href='suntingmaklumat.aspx';</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function delete_lesen()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from lesen where no_lesen ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "DELETE FROM lesen where no_lesen ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('Delete successfull ');location.href='suntingmaklumat.aspx';</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function delete_negara()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from negara where kod_negara ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "DELETE FROM negara where kod_negara ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('Delete successfull ');location.href='suntingmaklumat.aspx';</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function
    Function delete_negeri()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from negeri where kod_negeri ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "DELETE FROM negeri where kod_negeri ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('Delete successfull ');location.href='suntingmaklumat.aspx';</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function delete_pengeksport()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from pengeksport where kod_pengeksport ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "DELETE FROM pengeksport where kod_pengeksport ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('Delete successfull ');location.href='suntingmaklumat.aspx';</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function
    Function delete_pengimport_malaysia()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from pengimport where kod_pengimport ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "DELETE FROM pengimport where kod_pengimport ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('Delete successfull ');location.href='suntingmaklumat.aspx';</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function delete_pengeksport_thai()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from pengeksport_thailand where kod_pengeksport ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "DELETE FROM pengeksport_thailand where kod_pengeksport ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('Delete successfull ');location.href='suntingmaklumat.aspx';</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function delete_pengimport_thai()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from pengimport_thailand where kod_pengimport ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "DELETE FROM pengimport_thailand where kod_pengimport ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('Delete successfull ');location.href='suntingmaklumat.aspx';</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function delete_komplex()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from pusatkomplek where kod_ppi ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "DELETE FROM pusatkomplek where kod_ppi ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('Delete successfull ');location.href='suntingmaklumat.aspx';</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function delete_spesis1()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from spesis_ikan_1 where kod_spesis_ikan_1 ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "DELETE FROM spesis_ikan_1 where kod_spesis_ikan_1 ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('Delete successfull ');location.href='suntingmaklumat.aspx';</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function delete_spesis2()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from spesis_ikan_2 where kod_spesis_ikan_2 ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "DELETE FROM spesis_ikan_2 where kod_spesis_ikan_2 ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('Delete successfull ');location.href='suntingmaklumat.aspx';</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function delete_spesis3()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from spesis_ikan_3 where kod_spesis_ikan_3 ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "DELETE FROM spesis_ikan_3 where kod_spesis_ikan_3 ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('Delete successfull ');location.href='suntingmaklumat.aspx';</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function delete_spesis4()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from spesis_ikan_4 where kod_spesis_ikan_4 ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "DELETE FROM spesis_ikan_4 where kod_spesis_ikan_4 ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('Delete successfull ');location.href='suntingmaklumat.aspx';</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function delete_spesis5()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from spesis_ikan_5 where kod_spesis_ikan_5 ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "DELETE FROM spesis_ikan_5 where kod_spesis_ikan_5 ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('Delete successfull ');location.href='suntingmaklumat.aspx';</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function delete_spesis6()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from spesis_ikan_6 where kod_spesis_ikan_6 ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "DELETE FROM spesis_ikan_6 where kod_spesis_ikan_6 ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('Delete successfull ');location.href='suntingmaklumat.aspx';</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function delete_spesis7()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from spesis_ikan_7 where kod_spesis_ikan_7 ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "DELETE FROM spesis_ikan_7 where kod_spesis_ikan_7 ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('Delete successfull ');location.href='suntingmaklumat.aspx';</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function delete_spesis8()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from spesis_ikan_8 where kod_spesis_ikan_8 ='" & TextBox1.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "DELETE FROM spesis_ikan_8 where kod_spesis_ikan_8 ='" & TextBox1.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('Delete successfull ');location.href='suntingmaklumat.aspx';</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Function delete_epermit()

        Dim myconn As New SqlConnection(connectionstring)
        Dim mycmd As New SqlCommand("select * from epermit_maintenance where epermit_serial_no ='" & TextBox6.Text & "'", myconn)
        Dim str As String
        myconn.Open()

        str = "DELETE FROM epermit_maintenance where epermit_serial_no ='" & TextBox6.Text & "'"

        Dim mySqlCmd As New SqlCommand(str, myconn)

        Try
            Dim statusflag As Integer = mySqlCmd.ExecuteNonQuery()
            myconn.Close()

            If statusflag > 0 Then
                Response.Write("<script> alert('Delete successfull ');location.href='suntingmaklumat.aspx';</script>")
            Else
                Response.Write("<script> alert('Record Saved Operation Failed!!!');history.back();</script>")
            End If

        Catch ex As Exception
            Response.Write(ex.Message())

        End Try

        myconn.Close()

    End Function

    Sub GridView1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles GridView1.PageIndexChanged
        GridView1.CurrentPageIndex = e.NewPageIndex
        datagridvalue()
    End Sub

    Protected Sub view_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles view.Click

        ' datagrid 

        datagridvalue()

        TextBox9.Enabled = False
        TextBox10.Enabled = False
        TextBox11.Enabled = False
        TextBox9.Enabled = False
        TextBox10.Enabled = False
        TextBox11.Enabled = False
        DropDownList3.Enabled = False
        DropDownList1.Enabled = False
        DropDownList2.Enabled = False
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        add_deposit.Enabled = False
        add.Enabled = False
        save.Enabled = False
        save1.Visible = False
        delete.Enabled = False
        view.Enabled = False
        cancel.Visible = False
        back2.Visible = True
        GridView1.Enabled = True

    End Sub

    Function datagridvalue()

        If Label7.Text = "01" Then
            GridView1.Visible = True
            Label13.Visible = True
            Label13.Text = "TABLE AGEN PENGANGKUTAN"
            datagrid_agen()
        ElseIf datadetail.Text = "02.1" Or Label7.Text = "02.1" Then
            GridView1.Visible = True
            Label13.Visible = True
            Label13.Text = "TABLE BENTUK IKAN 1"
            datagrid_bentuk_ikan_1()
        ElseIf datadetail.Text = "02.2" Or Label7.Text = "02.2" Then
            GridView1.Visible = True
            Label13.Visible = True
            Label13.Text = "TABLE BENTUK IKAN 2"
            datagrid_bentuk_ikan_2()
        ElseIf datadetail.Text = "02.3" Or Label7.Text = "02.3" Then
            GridView1.Visible = True
            Label13.Visible = True
            Label13.Text = "TABLE BENTUK IKAN 3"
            datagrid_bentuk_ikan_3()
        ElseIf datadetail.Text = "02.4" Or Label7.Text = "02.4" Then
            GridView1.Visible = True
            Label13.Visible = True
            Label13.Text = "TABLE BENTUK IKAN 4"
            datagrid_bentuk_ikan_4()
        ElseIf datadetail.Text = "02.5" Or Label7.Text = "02.5" Then
            GridView1.Visible = True
            Label13.Visible = True
            Label13.Text = "TABLE BENTUK IKAN 5"
            datagrid_bentuk_ikan_5()
        ElseIf Label7.Text = "03" Then
            GridView1.Visible = True
            Label13.Visible = True
            Label13.Text = "TABLE CAJ PERKHIDMATAN"
            datagrid_caj_perkhidmatan()
        ElseIf Label7.Text = "04" Then
            GridView1.Visible = True
            Label13.Visible = True
            Label13.Text = "TABLE CARA PENGANGKUTAN"
            datagrid_cara_pengangkutan()
        ElseIf Label7.Text = "05" Then
            GridView1.Visible = True
            Label13.Visible = True
            Label13.Text = "TABLE DESTINASI PASAR"
            datagrid_destinasi_pasar()
        ElseIf Label7.Text = "06" Then
            GridView1.Visible = True
            Label13.Visible = True
            Label13.Text = "TABLE GRED / SAIZ"
            datagrid_gred_saiz()
        ElseIf Label7.Text = "07" Then
            GridView1.Visible = True
            Label13.Visible = True
            Label13.Text = "TABLE CAJ IKAN"
            datagrid_caj_ikan()
        ElseIf Label7.Text = "08" Then
            GridView1.Visible = True
            Label13.Visible = True
            Label13.Text = "TABLE JENIS"
            datagrid_jenis()
        ElseIf Label7.Text = "09" Then
            GridView1.Visible = True
            Label13.Visible = True
            Label13.Text = "TABLE JENIS IKAN"
            datagrid_jenis_ikan()
        ElseIf Label7.Text = "010" Then
            GridView1.Visible = True
            Label13.Visible = True
            Label13.Text = "TABLE JENIS PENGANGKUTAN"
            datagrid_jenis_pengangkutan()
        ElseIf Label7.Text = "011" Then
            GridView1.Visible = True
            Label13.Visible = True
            Label13.Text = "TABLE JENIS URUSAN"
            datagrid_jenis_urusan()
        ElseIf Label7.Text = "012" Then
            GridView1.Visible = True
            Label13.Visible = True
            Label13.Text = "TABLE KATEGORI"
            datagrid_kategori()
        ElseIf Label7.Text = "013" Then
            GridView1.Visible = True
            Label13.Visible = True
            Label13.Text = "TABLE KUMPULAN"
            datagrid_kumpulan()
        ElseIf Label7.Text = "014" Then
            GridView1.Visible = True
            Label13.Visible = True
            Label13.Text = "TABLE LESEN"
            datagrid_lesen()
        ElseIf Label7.Text = "015" Then
            GridView1.Visible = True
            Label13.Visible = True
            Label13.Text = "TABLE NEGARA"
            datagrid_negara()
        ElseIf Label7.Text = "016" Then
            GridView1.Visible = True
            Label13.Visible = True
            Label13.Text = "TABLE NEGERI"
            datagrid_negeri()
        ElseIf Label7.Text = "017" Then
            GridView1.Visible = True
            Label13.Visible = True
            Label13.Text = "TABLE PENGEKSPORT MALAYSIA"
            datagrid_pengeksport()
        ElseIf Label7.Text = "018" Then
            GridView1.Visible = True
            Label13.Visible = True
            Label13.Text = "TABLE PENGIMPORT MALAYSIA"
            datagrid_pengimport_malaysia()
        ElseIf Label7.Text = "019" Then
            GridView1.Visible = True
            Label13.Visible = True
            Label13.Text = "TABLE PENGEKSPORT THAILAND"
            datagrid_pengeksport_thai()
        ElseIf Label7.Text = "020" Then
            GridView1.Visible = True
            Label13.Visible = True
            Label13.Text = "TABLE PENGIMPORT THAILAND"
            datagrid_pengimport_thai()
        ElseIf Label7.Text = "021" Then
            GridView1.Visible = True
            Label13.Visible = True
            Label13.Text = "TABLE KOMPLEX"
            datagrid_komplex()
        ElseIf Label7.Text = "022.1" Then
            GridView1.Visible = True
            Label13.Visible = True
            Label13.Text = "TABLE SPESIS 1"
            datagrid_spesis1()
        ElseIf Label7.Text = "022.2" Then
            GridView1.Visible = True
            Label13.Visible = True
            Label13.Text = "TABLE SPESIS 2"
            datagrid_spesis2()
        ElseIf Label7.Text = "022.3" Then
            GridView1.Visible = True
            Label13.Visible = True
            Label13.Text = "TABLE SPESIS 3"
            datagrid_spesis3()
        ElseIf Label7.Text = "022.4" Then
            GridView1.Visible = True
            Label13.Visible = True
            Label13.Text = "TABLE SPESIS 4"
            datagrid_spesis4()
        ElseIf Label7.Text = "022.5" Then
            GridView1.Visible = True
            Label13.Visible = True
            Label13.Text = "TABLE SPESIS 5"
            datagrid_spesis5()
        ElseIf Label7.Text = "022.6" Then
            GridView1.Visible = True
            Label13.Visible = True
            Label13.Text = "TABLE SPESIS 6"
            datagrid_spesis6()
        ElseIf Label7.Text = "022.7" Then
            GridView1.Visible = True
            Label13.Visible = True
            Label13.Text = "TABLE SPESIS 7"
            datagrid_spesis7()
        ElseIf Label7.Text = "022.8" Then
            GridView1.Visible = True
            Label13.Visible = True
            Label13.Text = "TABLE SPESIS 8"
            datagrid_spesis8()
        ElseIf Label7.Text = "023" Then
            GridView1.Visible = True
            Label13.Visible = True
            Label13.Text = "TABLE E-PERMIT"
            datagrid_epermit()
        Else
        End If
    End Function

    Function datagrid_agen()
        Dim myconn As New SqlConnection(connectionstring)
        Dim sql As String = "SELECT KOD_AGEN_PENGANGKUTAN,NAMA_AGEN_PENGANGKUTAN,ALAMAT_AGEN_PENGANGKUTAN, deposit_semasa, transaksi_semasa from  AGEN_PENGANGKUTAN where kod_agen_pengangkutan <>'' ORDER BY NAMA_AGEN_PENGANGKUTAN "
        Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
        Dim ds As New DataSet()
        myAdapter.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        myconn.Close()
        'Label7.Text = ""
        'Label7.Text = sql
    End Function

    Function datagrid_bentuk_ikan_1()
        Dim myconn As New SqlConnection(connectionstring)
        Dim sql As String = "SELECT kod_bentuk_ikan_1, nama_bentuk_ikan_1 FROM bentuk_ikan_1 where kod_bentuk_ikan_1 <>'00000'ORDER BY nama_bentuk_ikan_1"
        Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
        Dim ds As New DataSet()
        myAdapter.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        myconn.Close()
        'Label7.Text = ""
        'Label7.Text = sql
    End Function

    Function datagrid_bentuk_ikan_2()
        Dim myconn As New SqlConnection(connectionstring)
        Dim sql As String = "SELECT kod_bentuk_ikan_2, nama_bentuk_ikan_2 FROM bentuk_ikan_2 where kod_bentuk_ikan_2 <>'00000'ORDER BY nama_bentuk_ikan_2"
        Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
        Dim ds As New DataSet()
        myAdapter.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        myconn.Close()
        'Label7.Text = ""
        'Label7.Text = sql
    End Function

    Function datagrid_bentuk_ikan_3()
        Dim myconn As New SqlConnection(connectionstring)
        Dim sql As String = "SELECT kod_bentuk_ikan_3, nama_bentuk_ikan_3 FROM bentuk_ikan_3 where kod_bentuk_ikan_3 <>'00000'ORDER BY nama_bentuk_ikan_3"
        Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
        Dim ds As New DataSet()
        myAdapter.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        myconn.Close()
        'Label7.Text = ""
        'Label7.Text = sql
    End Function

    Function datagrid_bentuk_ikan_4()
        Dim myconn As New SqlConnection(connectionstring)
        Dim sql As String = "SELECT kod_bentuk_ikan_4, nama_bentuk_ikan_4 FROM bentuk_ikan_4 where kod_bentuk_ikan_4 <>'00000'ORDER BY nama_bentuk_ikan_4"
        Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
        Dim ds As New DataSet()
        myAdapter.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        myconn.Close()
        'Label7.Text = ""
        'Label7.Text = sql
    End Function

    Function datagrid_bentuk_ikan_5()
        Dim myconn As New SqlConnection(connectionstring)
        Dim sql As String = "SELECT kod_bentuk_ikan_5, nama_bentuk_ikan_5 FROM bentuk_ikan_5 where kod_bentuk_ikan_5 <>'00000'ORDER BY nama_bentuk_ikan_5"
        Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
        Dim ds As New DataSet()
        myAdapter.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        myconn.Close()
        'Label7.Text = ""
        'Label7.Text = sql
    End Function

    Function datagrid_caj_perkhidmatan()
        Dim myconn As New SqlConnection(connectionstring)
        Dim sql As String = "SELECT kod_caj, nama_caj, kadar_caj, cara_pembayaran, dicaj_oleh FROM caj_perkhidmatan where kod_caj <>'00000'ORDER BY nama_caj"
        Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
        Dim ds As New DataSet()
        myAdapter.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        myconn.Close()
        'Label7.Text = ""
        'Label7.Text = sql
    End Function

    Function datagrid_cara_pengangkutan()
        Dim myconn As New SqlConnection(connectionstring)
        Dim sql As String = "SELECT kod_cara_pengangkutan, nama_cara_pengangkutan FROM cara_pengangkutan where kod_cara_pengangkutan <>'00000'ORDER BY nama_cara_pengangkutan"
        Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
        Dim ds As New DataSet()
        myAdapter.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        myconn.Close()
        'Label7.Text = ""
        'Label7.Text = sql
    End Function

    Function datagrid_destinasi_pasar()
        Dim myconn As New SqlConnection(connectionstring)
        Dim sql As String = "SELECT kod_pasar, nama_pasar FROM destinasi_pasar where kod_pasar <>'00000'ORDER BY nama_pasar"
        Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
        Dim ds As New DataSet()
        myAdapter.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        myconn.Close()
        'Label7.Text = ""
        'Label7.Text = sql
    End Function

    Function datagrid_gred_saiz()
        Dim myconn As New SqlConnection(connectionstring)
        Dim sql As String = "SELECT kod_Gredsaiz, nama_Gredsaiz FROM gred_saiz where kod_Gredsaiz <>'00000'ORDER BY nama_Gredsaiz"
        Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
        Dim ds As New DataSet()
        myAdapter.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        myconn.Close()
        'Label7.Text = ""
        'Label7.Text = sql
    End Function

    Function datagrid_caj_ikan()
        Dim myconn As New SqlConnection(connectionstring)
        Dim sql As String = "SELECT IKAN_CAJ.ID, IKAN_CAJ.Kategori_Ikan, KATEGORI_IKAN.Nama_Kategori_Ikan, IKAN_CAJ.Jenis_Urusan, JENIS_URUSAN.Nama_Urusan, IKAN_CAJ.Kadar_Peti_Kecil, IKAN_CAJ.Kadar_Peti_Besar, IKAN_CAJ.Kadar_Ekor, IKAN_CAJ.Kadar_Kuantiti FROM IKAN_CAJ INNER JOIN KATEGORI_IKAN ON IKAN_CAJ.Kategori_Ikan = KATEGORI_IKAN.Kod_Kategori_Ikan INNER JOIN JENIS_URUSAN ON IKAN_CAJ.Jenis_Urusan = JENIS_URUSAN.Kod_Urusan where id <>'00000'ORDER BY id asc"
        'Dim sql As String = "SELECT id, kategori_ikan.ikan_caj, jenis_urusan.ikan_caj, kadar_peti_kecil.ikan_caj, kadar_peti_besar.ikan_caj,kadar_ekor.ikan_caj, kadar_kuantiti.ikan_caj, nama_urusan.jenis_urusan outer join jenis_urusan on ikan_caj.jenis_urusan = jenis_urusan.kod_urusan FROM ikan_caj where id <>'00000'ORDER BY kategori_ikan"
        Dim Cmd As New SqlClient.SqlCommand(Sql, myconn)
        myconn.Open()
        Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
        Dim ds As New DataSet()
        myAdapter.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        myconn.Close()
        'Label7.Text = ""
        'Label7.Text = sql
    End Function

    Function datagrid_jenis()
        Dim myconn As New SqlConnection(connectionstring)
        Dim sql As String = "SELECT kod_barangan, nama_barangan FROM jenis_barangan where kod_barangan <>'00000'ORDER BY nama_barangan"
        Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
        Dim ds As New DataSet()
        myAdapter.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        myconn.Close()
        'Label7.Text = ""
        'Label7.Text = sql
    End Function

    Function datagrid_jenis_ikan()
        Dim myconn As New SqlConnection(connectionstring)
        Dim sql As String = "SELECT kod_ikan, nama_bkh FROM jenis_ikan where kod_ikan <>'00000'ORDER BY nama_bkh"
        Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
        Dim ds As New DataSet()
        myAdapter.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        myconn.Close()
        'Label7.Text = ""
        'Label7.Text = sql
    End Function

    Function datagrid_jenis_pengangkutan()
        Dim myconn As New SqlConnection(connectionstring)
        Dim sql As String = "SELECT Kod_Pengangkutan, nama_Pengangkutan FROM jenis_pengangkutan where Kod_Pengangkutan <>'00000'ORDER BY nama_Pengangkutan"
        Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
        Dim ds As New DataSet()
        myAdapter.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        myconn.Close()
        'Label7.Text = ""
        'Label7.Text = sql
    End Function '

    Function datagrid_jenis_urusan()
        Dim myconn As New SqlConnection(connectionstring)
        Dim sql As String = "SELECT Kod_urusan, nama_urusan FROM jenis_urusan where Kod_urusan <>'00000'ORDER BY nama_urusan"
        Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
        Dim ds As New DataSet()
        myAdapter.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        myconn.Close()
        'Label7.Text = ""
        'Label7.Text = sql
    End Function

    Function datagrid_kategori()
        Dim myconn As New SqlConnection(connectionstring)
        Dim sql As String = "SELECT Kod_Kategori_Ikan, nama_Kategori_Ikan FROM kategori_ikan where Kod_Kategori_Ikan <>'00000'ORDER BY nama_Kategori_Ikan"
        Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
        Dim ds As New DataSet()
        myAdapter.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        myconn.Close()
        'Label7.Text = ""
        'Label7.Text = sql
    End Function

    Function datagrid_kumpulan()
        Dim myconn As New SqlConnection(connectionstring)
        Dim sql As String = "SELECT Kod_kumpulan_Ikan, nama_kumpulan_Ikan FROM kumpulan_ikan where Kod_kumpulan_Ikan <>'00000'ORDER BY nama_kumpulan_Ikan"
        Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
        Dim ds As New DataSet()
        myAdapter.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        myconn.Close()
        'Label7.Text = ""
        'Label7.Text = sql
    End Function

    Function datagrid_lesen()
        Dim myconn As New SqlConnection(connectionstring)
        Dim sql As String = "SELECT No_lesen, tarikh_tamat, tarikh_disah, kawasan,siri_lesen FROM lesen where no_lesen <>'00000'ORDER BY siri_lesen"
        Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
        Dim ds As New DataSet()
        myAdapter.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        myconn.Close()
        'Label7.Text = ""
        'Label7.Text = sql
    End Function

    Function datagrid_negara()
        Dim myconn As New SqlConnection(connectionstring)
        Dim sql As String = "SELECT Kod_negara, nama_negara FROM negara where Kod_negara <>'00000'ORDER BY nama_negara"
        Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
        Dim ds As New DataSet()
        myAdapter.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        myconn.Close()
        'Label7.Text = ""
        'Label7.Text = sql
    End Function

    Function datagrid_negeri()
        Dim myconn As New SqlConnection(connectionstring)
        Dim sql As String = "SELECT Kod_Negeri, nama_Negeri FROM negeri where Kod_Negeri <>'00000'ORDER BY nama_Negeri"
        Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
        Dim ds As New DataSet()
        myAdapter.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        myconn.Close()
        'Label7.Text = ""
        'Label7.Text = sql
    End Function

    Function datagrid_pengeksport()
        Dim myconn As New SqlConnection(connectionstring)
        Dim sql As String = "SELECT Kod_pengeksport, nama_syarikat_eksport, alamat_syarikat_eksport, no_lesen, tarikh_dimasukkan FROM pengeksport where Kod_pengeksport <>'00000'ORDER BY nama_syarikat_eksport"
        Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
        Dim ds As New DataSet()
        myAdapter.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        myconn.Close()
        'Label7.Text = ""
        'Label7.Text = sql
    End Function

    Function datagrid_pengimport_malaysia()
        Dim myconn As New SqlConnection(connectionstring)
        Dim sql As String = "SELECT Kod_pengimport, nama_syarikat_import, alamat_syarikat_import, no_lesen, nama_pemilik FROM pengimport where Kod_pengimport <>'00000'ORDER BY nama_syarikat_import"
        Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
        Dim ds As New DataSet()
        myAdapter.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        myconn.Close()
        'Label7.Text = ""
        'Label7.Text = sql
    End Function

    Function datagrid_pengeksport_thai()
        Dim myconn As New SqlConnection(connectionstring)
        Dim sql As String = "SELECT Kod_pengeksport, nama_pengeksport, alamat_pengeksport FROM pengeksport_thailand where Kod_pengeksport <>'00000'ORDER BY nama_pengeksport"
        Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
        Dim ds As New DataSet()
        myAdapter.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        myconn.Close()
        'Label7.Text = ""
        'Label7.Text = sql
    End Function

    Function datagrid_pengimport_thai()
        Dim myconn As New SqlConnection(connectionstring)
        Dim sql As String = "SELECT Kod_Pengimport, nama_Pengimport, alamat_pengimport FROM Pengimport_thailand where Kod_Pengimport <>'00000'ORDER BY nama_Pengimport"
        Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
        Dim ds As New DataSet()
        myAdapter.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        myconn.Close()
        'Label7.Text = ""
        'Label7.Text = sql
    End Function

    Function datagrid_komplex()
        Dim myconn As New SqlConnection(connectionstring)
        Dim sql As String = "SELECT Kod_PPI, nama_PPI FROM pusatkomplek where Kod_PPI <>'00000'ORDER BY nama_PPI"
        Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
        Dim ds As New DataSet()
        myAdapter.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        myconn.Close()
        'Label7.Text = ""
        'Label7.Text = sql
    End Function

    Function datagrid_spesis1()
        Dim myconn As New SqlConnection(connectionstring)
        Dim sql As String = "SELECT Kod_spesis_ikan_1, nama_spesis_ikan_1 FROM spesis_ikan_1 where Kod_spesis_ikan_1 <>'00000'ORDER BY nama_spesis_ikan_1"
        Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
        Dim ds As New DataSet()
        myAdapter.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        myconn.Close()
        'Label7.Text = ""
        'Label7.Text = sql
    End Function

    Function datagrid_spesis2()
        Dim myconn As New SqlConnection(connectionstring)
        Dim sql As String = "SELECT Kod_spesis_ikan_2, nama_spesis_ikan_2 FROM spesis_ikan_2 where Kod_spesis_ikan_2 <>'00000'ORDER BY nama_spesis_ikan_2"
        Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
        Dim ds As New DataSet()
        myAdapter.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        myconn.Close()
        'Label7.Text = ""
        'Label7.Text = sql
    End Function

    Function datagrid_spesis3()
        Dim myconn As New SqlConnection(connectionstring)
        Dim sql As String = "SELECT Kod_spesis_ikan_3, nama_spesis_ikan_3 FROM spesis_ikan_3 where Kod_spesis_ikan_3 <>'00000'ORDER BY nama_spesis_ikan_3"
        Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
        Dim ds As New DataSet()
        myAdapter.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        myconn.Close()
        'Label7.Text = ""
        'Label7.Text = sql
    End Function

    Function datagrid_spesis4()
        Dim myconn As New SqlConnection(connectionstring)
        Dim sql As String = "SELECT Kod_spesis_ikan_4, nama_spesis_ikan_4 FROM spesis_ikan_4 where Kod_spesis_ikan_4 <>'00000'ORDER BY nama_spesis_ikan_4"
        Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
        Dim ds As New DataSet()
        myAdapter.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        myconn.Close()
        'Label7.Text = ""
        'Label7.Text = sql
    End Function

    Function datagrid_spesis5()
        Dim myconn As New SqlConnection(connectionstring)
        Dim sql As String = "SELECT Kod_spesis_ikan_5, nama_spesis_ikan_5 FROM spesis_ikan_5 where Kod_spesis_ikan_5 <>'00000'ORDER BY nama_spesis_ikan_5"
        Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
        Dim ds As New DataSet()
        myAdapter.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        myconn.Close()
        'Label7.Text = ""
        'Label7.Text = sql
    End Function

    Function datagrid_spesis6()
        Dim myconn As New SqlConnection(connectionstring)
        Dim sql As String = "SELECT Kod_spesis_ikan_6, nama_spesis_ikan_6 FROM spesis_ikan_6 where Kod_spesis_ikan_6 <>'00000'ORDER BY nama_spesis_ikan_6"
        Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
        Dim ds As New DataSet()
        myAdapter.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        myconn.Close()
        'Label7.Text = ""
        'Label7.Text = sql
    End Function

    Function datagrid_spesis7()
        Dim myconn As New SqlConnection(connectionstring)
        Dim sql As String = "SELECT Kod_spesis_ikan_7, nama_spesis_ikan_7 FROM spesis_ikan_7 where Kod_spesis_ikan_7 <>'00000'ORDER BY nama_spesis_ikan_7"
        Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
        Dim ds As New DataSet()
        myAdapter.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        myconn.Close()
        'Label7.Text = ""
        'Label7.Text = sql
    End Function

    Function datagrid_spesis8()
        Dim myconn As New SqlConnection(connectionstring)
        Dim sql As String = "SELECT Kod_spesis_ikan_8, nama_spesis_ikan_8 FROM spesis_ikan_8 where Kod_spesis_ikan_8 <>'00000'ORDER BY nama_spesis_ikan_8"
        Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
        Dim ds As New DataSet()
        myAdapter.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        myconn.Close()
        'Label7.Text = ""
        'Label7.Text = sql
    End Function

    Function datagrid_epermit()
        Dim myconn As New SqlConnection(connectionstring)
        Dim sql As String = "SELECT epermit_code, epermit_desc, epermit_cost, edate FROM epermit_maintenance where epermit_code <>'00000'ORDER BY epermit_desc"
        Dim Cmd As New SqlClient.SqlCommand(sql, myconn)
        myconn.Open()
        Dim myAdapter As New SqlClient.SqlDataAdapter(Cmd)
        Dim ds As New DataSet()
        myAdapter.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        myconn.Close()
        'Label7.Text = ""
        'Label7.Text = sql
    End Function

    Protected Sub back2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles back2.Click
        If Label7.Text = "018" Then
            TextBox9.Enabled = True
            TextBox10.Enabled = True
            TextBox11.Enabled = True
            TextBox9.Enabled = True
            TextBox10.Enabled = True
            TextBox11.Enabled = True
            TextBox4.Enabled = True
            TextBox5.Enabled = True
            Label13.Visible = False
            GridView1.Visible = False
            GridView1.Enabled = False
            DropDownList2.Enabled = True
            ' TextBox1.Enabled = True
            TextBox2.Enabled = True
            TextBox3.Enabled = True
            add_deposit.Enabled = True
            DropDownList3.Enabled = True
            add.Enabled = True
            save.Enabled = True
            delete.Enabled = True
            view.Enabled = True
            cancel.Visible = True
            back2.Visible = False
            view.Enabled = True
            add.Visible = True
            save.Visible = True
            delete.Visible = True
            view.Visible = True
        ElseIf Label7.Text = "01" Then
            saveadd.Visible = False
            Label13.Visible = False
            GridView1.Visible = False
            GridView1.Enabled = False
            DropDownList2.Enabled = True
            ' TextBox1.Enabled = True
            TextBox2.Enabled = True
            TextBox3.Enabled = True
            add_deposit.Enabled = True
            DropDownList3.Enabled = True
            add.Enabled = True
            save.Enabled = True
            delete.Enabled = True
            view.Enabled = True
            cancel.Visible = True
            back2.Visible = False
            view.Enabled = True
            TextBox10.Visible = False
            TextBox9.Visible = False
            Label10.Visible = False
            Label9.Visible = False
            add_deposit.Visible = True
            add.Visible = True
            save.Visible = True
            delete.Visible = True
            view.Visible = True
        Else
            Label13.Visible = False
            GridView1.Visible = False
            GridView1.Enabled = False
            DropDownList2.Enabled = True
            ' TextBox1.Enabled = True
            TextBox2.Enabled = True
            TextBox3.Enabled = True
            add_deposit.Enabled = True
            DropDownList3.Enabled = True
            add.Enabled = True
            save.Enabled = True
            delete.Enabled = True
            view.Enabled = True
            cancel.Visible = True
            back2.Visible = False
            view.Enabled = True
            TextBox10.Visible = False
            TextBox9.Visible = False
            Label10.Visible = False
            Label9.Visible = False
            add.Visible = True
            save.Visible = True
            delete.Visible = True
            view.Visible = True
        End If
    End Sub
End Class


