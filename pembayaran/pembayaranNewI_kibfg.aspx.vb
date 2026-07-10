Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Class pembayaran_pembayaranNewI_kibfg
    Inherits System.Web.UI.Page


#Region "Variables Declaration"

    Protected opClass As SQLOperation
    Protected opClass1 As SQLOperation
    Protected opClass2 As SQLOperation

    Dim SQLReader As System.Data.SqlClient.SqlDataReader
    Dim SQLReader1 As System.Data.SqlClient.SqlDataReader
    Dim SQLReader2 As System.Data.SqlClient.SqlDataReader
    Dim DepositSemasa As Decimal
    Dim total_caj_kredit As Decimal
    Dim total_caj_agen As Decimal
    Dim stmt As String = ""
    Dim NoSiriResit As String = ""
    Dim Baki_Semasa As Decimal
    Dim DepositSkrg As Decimal
    Dim byrIkan As String = ""
    Dim byrBorang As String = ""
    Public filetransfer As String = ""
    Public transaksi_semasa As Decimal

#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        opClass = New SQLOperation()
        opClass.dbConnection()

        Dim cajBorang1 As String = ""
        Dim cajEpermit As String = ""

        Dim tabletitle As String = ""
        Dim tabletitle1 As String = ""

        Dim textfield As String = ""
        Dim title As String = ""

        'import table
        tabletitle = "ITEM_ISYTIHAR_I"
        tabletitle1 = "PENGISYTIHARAN_I"
        textfield = "No_SKPI"
        title = "import"

        '---shah tambah

        Dim tabletitle_kibfg As String = ""
        Dim tabletitle1_kibfg As String = ""
        tabletitle_kibfg = "ITEM_ISYTIHAR_I_KIBFG"
        tabletitle1_kibfg = "PENGISYTIHARAN_I_KIBFG"

        '----------

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

        ' view information

        'Response.Write("<br>StartReport 1 =" & Now())

        txtCek.Attributes.Add("onKeyPress", "return keyToUpperCase(this, event);")

        txtRujukan.Text = Trim(Request("strBarcode"))
        lblnokenderaan.Text = Trim(Request("no_kenderaan"))
        Kod_Agen.Value = Trim(Request("Kod_Agen"))
        Urusan.Value = Trim(Request("urusan"))
        selectpay.Value = Trim(Request("selectpay"))
        Kod_Jenis_Urusan.Value = Trim(Request("Kod_Jenis_Urusan"))

        Dim rstKodagen As String = "select deposit_semasa,transaksi_semasa from AGEN_PENGANGKUTAN " _
        & " where kod_agen_pengangkutan ='" & Trim(Kod_Agen.Value) & "'"
        SQLReader = opClass.DataReader(rstKodagen)

        If SQLReader.HasRows Then
            SQLReader.Read()
            DepositSkrg = Trim(SQLReader("deposit_semasa"))
            transaksi_semasa = Trim(SQLReader("transaksi_semasa"))
        End If

        SQLReader.Close()
        SQLReader = Nothing

        ' end coded

        ' untuk cek deposit semasa & jumlah yang ada dengan agen

        Dim myRstQue2 = "select p.kod_agen_pengangkutan as kod_agen" _
        & " from pendaftaran_pintu p inner join sistem_q a on p.nombor_barcode=a.no_barcode" _
        & " WHERE p.kod_agen_pengangkutan = '" & Trim(Kod_Agen.Value) & "'" _
        & " and (DAY(a.Tarikh) = day(getdate())) AND (MONTH(a.Tarikh) = month(getdate())) AND (YEAR(a.Tarikh) = year(getdate())) and " _
        & " ((a.status like '%Pintu Keluar%') OR (a.status='Pelepasan') or (a.status='Bayar'))"
        SQLReader = opClass.DataReader(myRstQue2)

        SQLReader.Read()

        If SQLReader.HasRows Then

            total_caj_kredit = CDec(DepositSkrg) - CDec(transaksi_semasa)

        Else

            total_caj_kredit = DepositSkrg

            Dim updateU1 As String = "Update AGEN_PENGANGKUTAN set transaksi_semasa ='0' where Kod_Agen_Pengangkutan='" & Trim(Kod_Agen.Value) & "'"
            opClass.InsertData(updateU1)

        End If

        SQLReader.Close()
        SQLReader = Nothing

        If Trim(Request("cara_pembayaran")) = "CEK/TUNAI" Or Trim(Request("cara_pembayaran")) = "CEK" Then

            lbldepositagen.Text = FormatNumber(CDec(total_caj_kredit))

        Else

            lbldepositagen.Text = FormatNumber(CDec(total_caj_kredit))

        End If

        ' end coded

        'view label for type of charge

        Label1.Text = "LKIM Pembayaran Caj Ikan(Dengan Rebat KIBFG)"
        filetransfer = "cetakResit_kibfg.aspx"

        'Response.Write("<br>EndReport 1 =" & Now())


        'end coded


        'checking for print status
        'Dim sqlText1 As String = "SELECT print_status from no_siri_resit_lkim where No_barcode = '" & Trim(Request("strBarcode")) & "'"
        'SQLReader = opClass.DataReader(sqlText1)

        'SQLReader.Read()

        'If Not SQLReader.HasRows Then
        'print_status.Value = "N"
        'Else
        'print_status.Value = "Y"
        'End If

        'SQLReader.Close()
        'SQLReader = Nothing

        ' end coded


        '********* to view information for Caj Perkhidmatan Ikan *********

        Dim viewborangikan As String = ""

        Dim sqlIkan As String = "SELECT sum(TotalCajIkan) as TotalCajIkan From " & Trim(tabletitle1) & " " _
        & " where No_barcode = '" & Trim(Request("strBarcode")) & "' and status='A'"
        SQLReader = opClass.DataReader(sqlIkan)


        Dim countforskpi As Integer = 0
        Dim cajIkan1 As String = ""
        Dim jumlahcajikan As Decimal

        If SQLReader.HasRows Then

            SQLReader.Read()
            jumlahcajikan = CDec(SQLReader("TotalCajIkan"))

        End If

        SQLReader.Close()
        SQLReader = Nothing


        viewborangikan = "Caj Perkhidmatan Ikan" & "`" & (jumlahcajikan) & "`" & "LKIM" & "`" & "PENGISYTIHARAN" & "~"

        '********* end count jumlah ikan and borang ********* 


      


        '----ubah sini shah
        '********* to view information for Caj Perkhidmatan Ikan Kotak Insulasi*********shah tambah

        Dim viewborangikan_kibfg As String = ""
        Dim jumlahcajikan_kibfg As Decimal
        Dim jumlahkurangcajikan_kibfg As Decimal
        Dim jumlahcajikan_sebenar As Decimal


        'Dim sqlIkans As String = "SELECT TotalCajIkan From " & Trim(tabletitle1_kibfg) & " " _
        '        & " where No_barcode = '" & Trim(Request("strBarcode")) & "' and status='A'"
        'SQLReader = opClass.DataReader(sqlIkans)

        'If SQLReader.HasRows Then
        Dim sqlIkan2 As String = "SELECT sum(TotalCajIkan) as TotalCajIkana From " & Trim(tabletitle1) & " " _
                & " where No_barcode = '" & Trim(Request("strBarcode")) & "' and status='A'"
        SQLReader = opClass.DataReader(sqlIkan2)
        Dim totalcajikan As Decimal
        If SQLReader.HasRows Then

            SQLReader.Read()
            totalcajikan = CDec(SQLReader("TotalCajIkana"))

        End If



        SQLReader.Close()
        SQLReader = Nothing

        Dim sqlIkan1 As String = "SELECT sum(TotalCajIkan) as TotalCajIkan, sum(TotalKurangCajIkan) as TotalKurangCajIkan From " & Trim(tabletitle1_kibfg) & " " _
        & " where No_barcode = '" & Trim(Request("strBarcode")) & "' and status='A'"
        SQLReader = opClass.DataReader(sqlIkan1)

       

        Dim countforskpi_kibfg As Integer = 0
        Dim cajIkan1_kibfg As String = ""


        If SQLReader.HasRows Then
            SQLReader.Read()

            jumlahcajikan_kibfg = CDec(SQLReader("TotalCajIkan"))
            jumlahkurangcajikan_kibfg = CDec(SQLReader("TotalKurangCajIkan"))
            jumlahcajikan_sebenar = totalcajikan - CDec(SQLReader("TotalKurangCajIkan"))
            '----ubah sini shah
        End If

        SQLReader.Close()
        SQLReader = Nothing
        
        'Else

        'jumlahcajikan_kibfg = 0.0

        'End If
        'SQLReader.Close()
        'SQLReader = Nothing

        viewborangikan_kibfg = "Caj Perkhidmatan Ikan(Kotak Insulasi)" & "`" & (jumlahcajikan_kibfg) & "`" & (jumlahkurangcajikan_kibfg) & "`" & (jumlahcajikan_sebenar) & "`" & "LKIM" & "`" & "PENGISYTIHARAN" & "~"

        '********* end count jumlah ikan and borang ********* 
        '----ubah sini shah




        '********* Checking for Item Caj ***************************

        arrayVal.Value = viewborangikan
        arrayVal1.Value = viewborangikan_kibfg '--shah tambah

        Dim sqlBorang1 As String = "select no_barcode from pembayaran_caj_ikan where No_barcode = '" & Trim(Request("strBarcode")) & "'"
        SQLReader = opClass.DataReader(sqlBorang1)

        If Not SQLReader.HasRows Then

            lblStatusPembayaran.Text = "Belum Jelas"
            cmdResit.Disabled = True
            Button7.Disabled = True

        Else

            itemCek.ReadOnly = True
            itemTunai.ReadOnly = True
            txtCek.ReadOnly = True

            lblStatusPembayaran.Text = "Jelas"
            cmdBayar.Enabled = False
            cmdResit.Disabled = False
            Button7.Disabled = False
            strbuttonL.Enabled = False
            Button3.Disabled = False

        End If

        ' end coded

        SQLReader.Close()
        SQLReader = Nothing


        If Request("cara_pembayaran") = "CEK/TUNAI" Then

            id_tunai.Attributes.Add("style", "DISPLAY:Block")
            id_cek.Attributes.Add("style", "DISPLAY:Block")
            itemTunai.Text = CDec(Trim(Request("itemTunai")))
            itemCek.Text = CDec(Trim(Request("itemCek")))

        End If


        Dim myHost As String
        Dim host As System.Net.IPHostEntry
        host = System.Net.Dns.GetHostEntry(Request.ServerVariables.Item("REMOTE_addr"))
        myHost = host.HostName

        Dim sqlprint As String = "select printer_name from printername where computer_name='" & Trim(myHost) & "'"
        SQLReader = opClass.DataReader(sqlprint)

        If SQLReader.HasRows Then

            SQLReader.Read()

            printer_name.Value = SQLReader("printer_name")

        Else
            printer_name.Value = Replace(printer_name.Value, "/", "\")

        End If

        SQLReader.Close()
        SQLReader = Nothing

        '********* ended program coded ****************************

    End Sub

    Protected Sub cara_pembayaran_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles cara_pembayaran.PreRender
        If Request("cara_pembayaran") <> "" Then
            cara_pembayaran.ClearSelection()
            cara_pembayaran.Items.FindByValue(Request("cara_pembayaran")).Selected = True
        End If
    End Sub

    Protected Sub BAYAR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBayar.Click, strbuttonL.Click

        opClass = New SQLOperation()
        opClass.dbConnection()
        opClass1 = New SQLOperation()
        opClass1.dbConnection()

        Dim no_cek As String = ""
        Dim cara_bayar As Boolean = False
        Dim strValue = arrayVal.Value
        'Dim strValue = arrayVal2.Value
        Dim txtKredit As Decimal

        Dim i As Integer
        Dim rowArray = strValue.Split("~")
        Dim arrBayarCol() As String = rowArray(i).ToString().Split("`")

        '---shah tambah'
        Dim strValue1 = arrayVal1.Value
        Dim rowArray1 = strValue1.Split("~")
        Dim arrBayarCol1() As String = rowArray1(i).ToString().Split("`")



        '----ubah sini shah
        '---------------

        Dim rstKodagen As String = "select p.Nombor_Siri,p.kod_agen_pengangkutan as kod_agen,a.nama_agen_pengangkutan as nama_agen,a.deposit_semasa as deposit_semasa,a.transaksi_semasa as transaksi_semasa" _
                & " from pendaftaran_pintu p inner join agen_pengangkutan a on p.kod_agen_pengangkutan=a.kod_agen_pengangkutan" _
                & " where p.nombor_barcode='" & Trim(txtRujukan.Text) & "'"
        SQLReader = opClass.DataReader(rstKodagen)

        If SQLReader.HasRows Then

            SQLReader.Read()
            NoSiriResit = Trim(SQLReader("Nombor_Siri"))
            DepositSemasa = Trim(SQLReader("deposit_semasa"))
            transaksi_semasa = Trim(SQLReader("transaksi_semasa"))

        End If

        SQLReader.Close()
        SQLReader = Nothing

        If Trim(sender.Id) = "cmdBayar" Or Trim(sender.Id) = "strbuttonL" Then

            ' untuk cek deposit semasa yang untuk yang ada agen dan pembayaran cek

            '' checking selection for cara pembayaran

            If Trim(cara_pembayaran.SelectedValue) = "0" Then

                Response.Write("<script language = javascript>alert('Sila pilih cara untuk pembayaran.');self.location.href='pembayaranNewI_kibfg.aspx?Kod_Agen=" & Trim(Kod_Agen.Value) & "&no_kenderaan= " & Trim(lblnokenderaan.Text) & "&urusan=" & Trim(Urusan.Value) & "&Kod_Jenis_Urusan=" & Trim(Kod_Jenis_Urusan.Value) & "&strBarcode=" & Trim(txtRujukan.Text) & "';</script>")
                Response.End()

            End If


            If (Trim(cara_pembayaran.SelectedValue) = "CEK" Or Trim(cara_pembayaran.SelectedValue) = "CEK/TUNAI") Or Trim(sender.Id) = "strbuttonL" Then

                ' untuk cek deposit semasa,transaksi semasa & jumlah yang ada dengan agen

                Dim cekSystemQ As String = "Select pendaftaran_pintu.Kod_Agen_Pengangkutan from SISTEM_Q Inner join " _
                    & " pendaftaran_pintu ON SISTEM_Q.No_Barcode= pendaftaran_pintu.Nombor_Barcode " _
                    & " where (sistem_q.status like '%Pintu Keluar%' OR sistem_q.status='Pelepasan' or sistem_q.status='Bayar') and pendaftaran_pintu.Kod_Agen_Pengangkutan = '" & Kod_Agen.Value & "' and " _
                    & " (DAY(SISTEM_Q.Tarikh) = day(getdate())) AND (MONTH(SISTEM_Q.Tarikh) = month(getdate())) AND " _
                    & " (YEAR(SISTEM_Q.Tarikh) = year(getdate()))"
                SQLReader = opClass.DataReader(cekSystemQ)

                SQLReader.Read()

                If SQLReader.HasRows Then

                    If Trim(cara_pembayaran.SelectedValue) = "CEK" Then

                        total_caj_kredit = CDec(transaksi_semasa) + CDec(arrBayarCol(1)) - CDec(arrBayarCol1(2))
                        'total_caj_kredit = CDec(transaksi_semasa) + CDec(arrBayarCol1(3))

                    ElseIf Trim(cara_pembayaran.SelectedValue) = "CEK/TUNAI" Then

                        total_caj_kredit = CDec(transaksi_semasa) + CDec(itemCek.Text) - CDec(arrBayarCol1(2))

                    End If
                    


                Else

                    If Trim(cara_pembayaran.SelectedValue) = "CEK" Then

                        total_caj_kredit = CDec(arrBayarCol(1)) - CDec(arrBayarCol1(2))
                        'total_caj_kredit = CDec(arrBayarCol1(3))

                    ElseIf Trim(cara_pembayaran.SelectedValue) = "CEK/TUNAI" Then

                        total_caj_kredit = CDec(itemCek.Text) - CDec(arrBayarCol1(2))

                    End If


                End If

                SQLReader.Close()
                SQLReader = Nothing

                If Trim(cara_pembayaran.SelectedValue) = "CEK/TUNAI" Then

                    If txtCek.Text = "" Or itemTunai.Text = "" Or itemCek.Text = "" Then

                        Response.Write("<script language = javascript>alert('Sila masukkan data untuk nilai tunai, nilai cek dan juga nombor cek terlebih dahulu.');self.location.href='pembayaranNewI_kibfg.aspx?Kod_Agen=" & Trim(Kod_Agen.Value) & "&no_kenderaan= " & Trim(lblnokenderaan.Text) & "&urusan=" & Trim(Urusan.Value) & "&Kod_Jenis_Urusan=" & Trim(Kod_Jenis_Urusan.Value) & "&strBarcode=" & Trim(txtRujukan.Text) & "';</script>")
                        Response.End()

                    End If

                    If (CDec(itemTunai.Text) + CDec(itemCek.Text) <> CDec(arrBayarCol(1))) Then

                        'If (CDec(itemTunai.Text) + CDec(itemCek.Text) <> CDec(arrBayarCol1(3))) Then
                        Response.Write("<script language = javascript>alert('Jumlah tunai dan cek adalah tidak sama. Sila semak.');self.location.href='pembayaranNewI_kibfg.aspx?Kod_Agen=" & Trim(Kod_Agen.Value) & "&no_kenderaan= " & Trim(lblnokenderaan.Text) & "&urusan=" & Trim(Urusan.Value) & "&Kod_Jenis_Urusan=" & Trim(Kod_Jenis_Urusan.Value) & "&strBarcode=" & Trim(txtRujukan.Text) & "';</script>")
                        Response.End()

                    End If

                End If


                If (CDec(DepositSemasa) < total_caj_kredit) Or CDec(total_caj_kredit) = "0" Then

                    stmt = "Baki deposit semasa anda untuk pembayaran CEK ialah RM " & FormatNumber((lbldepositagen.Text)) & ".Nilai ini tidak mencukupi untuk menjelaskan pembayaran CEK anda !.Anda dikehendaki menjelaskan pembayaran CEK anda dengan CEK dan TUNAI sahaja !"
                    Response.Write("<script languange=javascript>alert( '" & stmt & "');self.location.href='pembayaranNewI_kibfg.aspx?no_cek=" & no_cek & "&itemTunai=" & itemTunai.Text & "&itemCek=" & itemCek.Text & "&cara_pembayaran=" & Trim(Request("cara_pembayaran")) & "&Kod_Agen=" & Trim(Kod_Agen.Value) & "&no_kenderaan= " & Trim(lblnokenderaan.Text) & "&urusan=" & Trim(Urusan.Value) & "&Kod_Jenis_Urusan=" & Trim(Kod_Jenis_Urusan.Value) & "&strBarcode=" & Trim(txtRujukan.Text) & "'</script>")
                    Response.End()

                Else

                    Dim updateU As String = "Update AGEN_PENGANGKUTAN set transaksi_semasa = '" & Trim(CDec(total_caj_kredit)) & "' WHERE Kod_Agen_Pengangkutan = '" & Trim(Kod_Agen.Value) & "'"
                    opClass1.InsertData(updateU)
                    '  end coded

                    'DepositSemasa = (Trim(CDec(DepositSemasa)) - CDec(total_caj_kredit))
                    'tolak nilai rebat sahaja bukan nilai sebenar harga
                    DepositSemasa = (Trim(CDec(DepositSemasa)) - CDec(total_caj_kredit))

                End If

            End If

        End If

        If Trim(sender.Id) = "cmdBayar" Then


            ' view invois number from table
            Dim no_invois As Integer

            Dim intInvois As String = "select no_invois from no_invois where no_barcode='" & Trim(txtRujukan.Text) & "'"
            SQLReader = opClass.DataReader(intInvois)

            SQLReader.Read()
            no_invois = SQLReader("no_invois")

            SQLReader.Close()
            SQLReader = Nothing


            If Trim(cara_pembayaran.SelectedValue) = "CEK" Or Trim(cara_pembayaran.SelectedValue) = "CEK/TUNAI" Then

                If Trim(cara_pembayaran.SelectedValue) = "CEK" Then

                    'txtKredit = arrBayarCol(1)
                    txtKredit = arrBayarCol1(3)

                ElseIf Trim(cara_pembayaran.SelectedValue) = "CEK/TUNAI" Then

                    txtKredit = itemCek.Text

                End If

                cara_bayar = True

            End If

            '   end coded
            '   to insert the data into the specific table

            Dim ikanvalue As Boolean = False
            Dim bil_item As Integer
            Dim transaksi_semasa As Decimal = 0
            Dim totalTransaksiSemasa As Decimal
            Dim txtTotalCajTunai As Decimal = 0
            Dim txtTotalCajKredit As Decimal = 0

            Call SaveSistemQ()

            Dim intbil As String = "select bil_item from item_caj where no_barcode='" & Trim(txtRujukan.Text) & "' order by bil_item desc"
            SQLReader = opClass.DataReader(intbil)

            If SQLReader.HasRows Then
                SQLReader.Read()
                bil_item = SQLReader("bil_item") + 1
            Else
                bil_item = 1
            End If

            SQLReader.Close()
            SQLReader = Nothing

            If Trim(cara_pembayaran.SelectedValue) = "CEK" Or Trim(cara_pembayaran.SelectedValue) = "TUNAI" Then

                If Trim(cara_pembayaran.SelectedValue) = "CEK" Then

                    no_cek = txtCek.Text

                ElseIf Trim(cara_pembayaran.SelectedValue) = "TUNAI" Then

                    no_cek = "Tiada"

                End If


                Dim sqlText1 As String = "INSERT INTO [W-ICCS].[dbo].[ITEM_CAJ]" _
                & " ([No_Barcode], [Bil_Item], [Kod_Service_Caj], [Nilai_Caj],[Cara_Pembayaran],[No_Cek],[Dicaj_Oleh],[Tempat_Isytihar],[Nama_Pegawai],[No_Pegawai],site_code)" _
                & " VALUES('" & Trim(txtRujukan.Text) & "','" & bil_item & "','" & arrBayarCol(0) & "','" & CDec(arrBayarCol(1)) & "','" & Trim(cara_pembayaran.SelectedValue) & "','" & no_cek & "','" & arrBayarCol(2) & "','" & arrBayarCol(3) & "','" & Session("namaPegawai") & "','" & Session("id_pegawai") & "','" & Right(Trim(txtRujukan.Text), 3) & "')"
                opClass1.InsertData(sqlText1)

                '---shah tambah
                '----ubah sini shah
                Dim sqlTextkibfg1 As String = "INSERT INTO [W-ICCS].[dbo].[ITEM_CAJ_KIBFG]" _
                & " ([No_Barcode], [Bil_Item], [Kod_Service_Caj], [Nilai_Caj],[Cara_Pembayaran],[No_Cek],[Dicaj_Oleh],[Tempat_Isytihar],[Nama_Pegawai],[No_Pegawai],site_code,cara_bayar,nilai_caj_kurang, nilai_caj_sebenar)" _
                & " VALUES('" & Trim(txtRujukan.Text) & "','" & bil_item & "','" & arrBayarCol1(0) & "','" & CDec(arrBayarCol1(1)) & "','" & Trim(cara_pembayaran.SelectedValue) & "','" & no_cek & "','" & arrBayarCol1(4) & "','" & arrBayarCol1(5) & "','" & Session("namaPegawai") & "','" & Session("id_pegawai") & "','" & Right(Trim(txtRujukan.Text), 3) & "','CEK ATAU TUNAI','" & CDec(arrBayarCol1(2)) & "','" & arrBayarCol1(3) & "')"
                opClass1.InsertData(sqlTextkibfg1)
                '-----------------


            ElseIf Trim(cara_pembayaran.SelectedValue) = "CEK/TUNAI" Then

                no_cek = txtCek.Text

                'bil_item = bil_item + 1

                Dim sqlText1 As String = "INSERT INTO [W-ICCS].[dbo].[ITEM_CAJ]" _
                & " ([No_Barcode], [Bil_Item], [Kod_Service_Caj], [Nilai_Caj],[Cara_Pembayaran],[No_Cek],[Dicaj_Oleh],[Tempat_Isytihar],[Nama_Pegawai],[No_Pegawai],site_code)" _
                & " VALUES('" & Trim(txtRujukan.Text) & "','" & bil_item & "','" & arrBayarCol(0) & "','" & CDec(itemCek.Text) & "','CEK','" & txtCek.Text & "','" & arrBayarCol(2) & "','" & arrBayarCol(3) & "','" & Session("namaPegawai") & "','" & Session("id_pegawai") & "','" & Right(Trim(txtRujukan.Text), 3) & "')"
                opClass1.InsertData(sqlText1)

                '---shah tambah
                '----ubah sini shah
                Dim sqlTextkibfg1 As String = "INSERT INTO [W-ICCS].[dbo].[ITEM_CAJ_KIBFG]" _
                & " ([No_Barcode], [Bil_Item], [Kod_Service_Caj], [Nilai_Caj],[Cara_Pembayaran],[No_Cek],[Dicaj_Oleh],[Tempat_Isytihar],[Nama_Pegawai],[No_Pegawai],site_code,cara_bayar,nilai_caj_kurang,nilai_caj_sebenar)" _
                & " VALUES('" & Trim(txtRujukan.Text) & "','" & bil_item & "','" & arrBayarCol1(0) & "','" & CDec(arrBayarCol1(1)) & "','" & Trim(cara_pembayaran.SelectedValue) & "','" & no_cek & "','" & arrBayarCol1(4) & "','" & arrBayarCol1(5) & "','" & Session("namaPegawai") & "','" & Session("id_pegawai") & "','" & Right(Trim(txtRujukan.Text), 3) & "','CEK/TUNAI','" & CDec(arrBayarCol1(2)) & "','" & arrBayarCol1(3) & "')"
                opClass1.InsertData(sqlTextkibfg1)
                '-----------------

                bil_item = bil_item + 1

                Dim sqlText2 As String = "INSERT INTO [W-ICCS].[dbo].[ITEM_CAJ]" _
                & " ([No_Barcode], [Bil_Item], [Kod_Service_Caj], [Nilai_Caj],[Cara_Pembayaran],[No_Cek],[Dicaj_Oleh],[Tempat_Isytihar],[Nama_Pegawai],[No_Pegawai],site_code)" _
                & " VALUES('" & Trim(txtRujukan.Text) & "','" & bil_item & "','" & arrBayarCol(0) & "','" & CDec(itemTunai.Text) & "','TUNAI','Tiada','" & arrBayarCol(2) & "','" & arrBayarCol(3) & "','" & Session("namaPegawai") & "','" & Session("id_pegawai") & "','" & Right(Trim(txtRujukan.Text), 3) & "')"
                opClass1.InsertData(sqlText2)


            End If

            Dim strBayar2 = "insert into pembayaran_caj_Ikan(no_barcode,no_invois,siri_module,kod_agen,print_status,site_code) " _
            & "values('" & Trim(txtRujukan.Text) & "','" & Trim(no_invois) & "','individual_receipt','" & Trim(Kod_Agen.Value) & "','0','" & Right(Trim(txtRujukan.Text), 3) & "')"
            opClass1.InsertData(strBayar2)

            totalTransaksiSemasa = totalTransaksiSemasa + CDec(arrBayarCol(1))

            If cara_bayar = True Then

                'Baki_Semasa = CDec(DepositSemasa) - CDec(txtKredit)

                Dim rstLogCek As String = "Select * FROM LOG_TRANSAKSI_DEPOSIT WHERE  No_Barcode = '" & Trim(txtRujukan.Text) & "'"
                SQLReader = opClass.DataReader(rstLogCek)

                ' Simpan Log Transaksi Deposit Bank Yang Menggunakan CEK

                If Not SQLReader.HasRows Then

                    Dim rstLogCekIn1 As String = "Insert Into LOG_TRANSAKSI_DEPOSIT (No_Barcode,No_Siri,Kod_Agen_Pengangkutan," _
                    & "Deposit_Semasa,Transaksi_Deposit,Baki_Semasa,Nama_pegawai," _
                    & "No_Pegawai,site_code) Values ('" & Trim(txtRujukan.Text) & "','" & Trim(NoSiriResit) & "','" & Trim(Kod_Agen.Value) & "','" & Trim(CDec(Replace(lbldepositagen.Text, ",", ""))) & "'," _
                    & "'" & Trim(CDec(txtKredit)) & "','" & Trim(CDec(DepositSemasa)) & "','" & Session("namaPegawai") & "','" & Session("id_pegawai") & "','" & Right(Trim(txtRujukan.Text), 3) & "')"
                    opClass1.InsertData(rstLogCekIn1)

                End If

                SQLReader.Close()
                SQLReader = Nothing

            End If

            ' total caj tunai untuk perkidmatan ikan dan caj borang

            Dim rstCaj As String = "Select sum(nilai_caj) as tunaicaj FROM Item_caj WHERE Cara_Pembayaran='TUNAI' and kod_service_caj='Caj Perkhidmatan Ikan' and No_Barcode = '" & Trim(txtRujukan.Text) & "'"
            SQLReader = opClass.DataReader(rstCaj)

            If SQLReader.HasRows Then
                SQLReader.Read()

                If (SQLReader.IsDBNull(0)) Then
                    txtTotalCajTunai = "0.0"

                Else
                    txtTotalCajTunai = CDec(SQLReader("tunaicaj"))

                End If

            Else

                txtTotalCajTunai = "0.0"

            End If


            SQLReader.Close()
            SQLReader = Nothing

            '  end coded


            '  total caj cek untuk perkidmatan ikan dan caj borang

            Dim rstCaj1 As String = "Select sum(nilai_caj) as cekcaj FROM Item_caj WHERE Cara_Pembayaran='CEK' and kod_service_caj='Caj Perkhidmatan Ikan' and No_Barcode = '" & Trim(txtRujukan.Text) & "'"
            SQLReader = opClass.DataReader(rstCaj1)

            If SQLReader.HasRows Then
                SQLReader.Read()

                If (SQLReader.IsDBNull(0)) Then
                    txtTotalCajKredit = "0.0"

                Else
                    txtTotalCajKredit = CDec(SQLReader("cekcaj"))

                End If

            Else

                txtTotalCajKredit = "0.0"

            End If

            SQLReader.Close()
            SQLReader = Nothing

            totalTransaksiSemasa = CDec(txtTotalCajKredit) + CDec(txtTotalCajTunai)
            '  end coded


            Dim rstPembayaranCaj As String = "Select no_barcode FROM PEMBAYARAN_CAJ WHERE  No_Barcode = '" & Trim(txtRujukan.Text) & "'"
            SQLReader = opClass.DataReader(rstPembayaranCaj)


            If Not SQLReader.HasRows Then

                Dim rstPembayaranCaj1 As String = "Insert Into PEMBAYARAN_CAJ (No_Barcode,No_Siri,No_Kenderaan," _
                & "Jumlah_Caj_Tunai,Jumlah_Caj_Kredit,No_Cek,Jumlah_Caj,Kod_Agen_Pengangkutan," _
                & "No_Pegawai,Nama_Pegawai,Status,site_code) Values ('" & Trim(txtRujukan.Text) & "','" & Trim(NoSiriResit) & "','" & Trim(lblnokenderaan.Text) & "'," _
                & "'" & Trim(CDec(txtTotalCajTunai)) & "','" & Trim(CDec(txtTotalCajKredit)) & "','" & Trim(no_cek) & "','" & Trim(CDec(totalTransaksiSemasa)) & "','" & Trim(Kod_Agen.Value) & "'," _
                & "'" & Session("id_pegawai") & "','" & Session("namaPegawai") & "','JELAS','" & Right(Trim(txtRujukan.Text), 3) & "')"
                opClass1.InsertData(rstPembayaranCaj1)

            End If


            SQLReader.Close()
            SQLReader = Nothing

            ' insert for status transaction

            Dim sqlupdate As String = "INSERT INTO IsyProgressStatus_Front([no_rujukan],[no_barcode], [proses], [dateEnter], [entryBy])" & _
            "VALUES('','" & Trim(txtRujukan.Text) & "','PEMBAYARAN CAJ IKAN',getdate(),'" & Session("username") & "')"
            opClass1.InsertData(sqlupdate)

            ' end coded

            Response.Write("<script language = javascript>alert('Maklumat pembayaran untuk caj telah disimpan.');self.location.href='pembayaranNewI_kibfg.aspx?no_cek=" & no_cek & "&itemTunai=" & itemTunai.Text & "&itemCek=" & itemCek.Text & "&cara_pembayaran=" & Trim(cara_pembayaran.SelectedValue) & "&Kod_Agen=" & Trim(Kod_Agen.Value) & "&no_kenderaan= " & Trim(lblnokenderaan.Text) & "&urusan=" & Trim(Urusan.Value) & "&Kod_Jenis_Urusan=" & Trim(Kod_Jenis_Urusan.Value) & "&strBarcode=" & Trim(txtRujukan.Text) & "';</script>")
            Response.End()

        End If


        If Trim(sender.Id) = "strbuttonL" Then


            'If CDec(arrBayarCol(1)) > DepositSemasa Then

            ' stmt = "Baki deposit semasa anda untuk pembayaran CEK ialah RM " & FormatNumber((DepositSemasa)) & ".Nilai ini tidak mencukupi untuk menjelaskan pembayaran CEK anda !.Anda dikehendaki menjelaskan pembayaran CEK anda dengan CEK dan TUNAI sahaja !"
            ' Response.Write("<script languange=javascript>alert( '" & stmt & "');self.location.href='pembayaranNewI.aspx?no_cek=" & no_cek & "&itemTunai=" & itemTunai.Text & "&itemCek=" & itemCek.Text & "&cara_pembayaran=" & Trim(Request("cara_pembayaran")) & "&Kod_Agen=" & Trim(Kod_Agen.Value) & "&no_kenderaan= " & Trim(lblnokenderaan.Text) & "&urusan=" & Trim(Urusan.Value) & "&Kod_Jenis_Urusan=" & Trim(Kod_Jenis_Urusan.Value) & "&strBarcode=" & Trim(txtRujukan.Text) & "'</script>")
            'Response.End()

            ' Else


            Dim rstLogCekIn1 As String = "Insert Into LOG_TRANSAKSI_DEPOSIT (No_Barcode,Kod_Agen_Pengangkutan," _
            & "Deposit_Semasa,Transaksi_Deposit,Baki_Semasa,Nama_pegawai," _
            & "No_Pegawai,site_code) Values ('" & Trim(txtRujukan.Text) & "','" & Trim(Kod_Agen.Value) & "','" & Trim(CDec(Replace(lbldepositagen.Text, ",", ""))) & "'," _
            & "'" & Trim(CDec(arrBayarCol(1))) & "','" & Trim(CDec(DepositSemasa)) & "','" & Session("namaPegawai") & "','" & Session("id_pegawai") & "','" & Right(Trim(txtRujukan.Text), 3) & "')"
            opClass1.InsertData(rstLogCekIn1)

            Dim myRstQue1 = "UPDATE SISTEM_Q Set status='Pelepasan',pegawai='" & Session("namaPegawai") & "' WHERE No_Barcode = '" & Trim(txtRujukan.Text) & "'"
            opClass1.InsertData(myRstQue1)

            Response.Write("<script language = javascript>alert('Status pelepasan telah diberikan kepada barcode tersebut.');self.location.href='verifikasi_bayar.aspx?type=ikan';</script>")
            Response.End()

        End If

        'End If

        opClass.dbConnection_Close()
        opClass1.dbConnection_Close()


    End Sub


    Private Sub SaveSistemQ()

        opClass = New SQLOperation()
        opClass.dbConnection()
        opClass1 = New SQLOperation()
        opClass1.dbConnection()
        Dim status As String = ""


        Dim myRstQue = "SELECT no_barcode FROM SISTEM_Q WHERE No_Barcode = '" & Trim(txtRujukan.Text) & "'"

        SQLReader = opClass.DataReader(myRstQue)

        If Not SQLReader.HasRows Then

            SQLReader.Close()
            SQLReader = Nothing
            Response.Write("<script language=javascript>alert('Sistem-Q tidak dapat mengemaskini status Pembayaran kerana maklumat belum wujud !');self.location.href='verifikasi_bayar.aspx';</script>")
            Response.End()

        Else

            Dim myRstQue1 = "UPDATE SISTEM_Q Set status='Bayar',pegawai='" & Session("namaPegawai") & "' WHERE No_Barcode = '" & Trim(txtRujukan.Text) & "'"
            opClass1.InsertData(myRstQue1)

        End If

        SQLReader.Close()
        SQLReader = Nothing

        'opClass.dbConnection_Close()
        'opClass1.dbConnection_Close()

    End Sub


    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        opClass.dbConnection_Close()
    End Sub

End Class
