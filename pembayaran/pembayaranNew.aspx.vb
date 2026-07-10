
Partial Class pembayaran_pembayaranNew
    Inherits System.Web.UI.Page


#Region "Variables Declaration"
    Protected opClass As SQLOperation
    Protected opClass1 As SQLOperation
    Dim SQLReader As System.Data.SqlClient.SqlDataReader
    Dim SQLReader1 As System.Data.SqlClient.SqlDataReader
    Dim DepositSemasa As Decimal
    Dim total_caj_kredit As Decimal
    Dim total_caj_agen As Decimal
    Dim stmt As String = ""
    Dim NoSiriResit As String = ""
    Dim Baki_Semasa As Decimal
    Dim DepositSkrg As Decimal

#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        opClass = New SQLOperation()
        opClass.dbConnection()

        opClass1 = New SQLOperation()
        opClass1.dbConnection()

        Dim cajBorang1 As String = ""
        Dim cajEpermit As String = ""

        Dim tabletitle As String = ""
        Dim tabletitle1 As String = ""

        Dim textfield As String = ""
        Dim title As String = ""

        If Trim(Request("urusan")) = "I" Then

            'import table
            tabletitle = "ITEM_ISYTIHAR_I"
            tabletitle1 = "PENGISYTIHARAN_I"
            textfield = "No_SKPI"
            title = "import"

        Else
            'eksport table
            tabletitle = "ITEM_ISYTIHAR_E"
            textfield = "No_SKPE"
            title = "eksport"
            tabletitle1 = "PENGISYTIHARAN_E"

        End If


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
        txtRujukan.Text = Trim(Request("strBarcode"))
        lblnokenderaan.Text = Trim(Request("no_kenderaan"))
        Kod_Agen.Value = Trim(Request("Kod_Agen"))
        Urusan.Value = Trim(Request("urusan"))
        selectpay.Value = Trim(Request("selectpay"))
        Kod_Jenis_Urusan.Value = Trim(Request("Kod_Jenis_Urusan"))


        ' untuk cek deposit semasa yang ada dengan agen

        Dim rstKodagen As String = "select p.Nombor_Siri,p.kod_agen_pengangkutan as kod_agen,a.nama_agen_pengangkutan as nama_agen,a.deposit_semasa as deposit_semasa" _
        & " from pendaftaran_pintu p" _
        & " inner join agen_pengangkutan a on p.kod_agen_pengangkutan=a.kod_agen_pengangkutan" _
        & " where p.nombor_barcode='" & Trim(txtRujukan.Text) & "'"
        SQLReader = opClass.DataReader(rstKodagen)


        If SQLReader.HasRows Then
            SQLReader.Read()
            DepositSkrg = Trim(SQLReader("deposit_semasa"))
        End If

        SQLReader.Close()
        SQLReader = Nothing

        ' end coded

        ' untuk cek jumlah yang ada telah digunakan oleh agen
        Dim cekBayar As String = "Select sum(jumlah_caj_kredit) as total_caj from pembayaran_caj where Kod_Agen_Pengangkutan = '" & Trim(Kod_Agen.Value) & "' and " _
        & "(DAY(Tarikh_Bayar) = day(getdate())) AND (MONTH(Tarikh_Bayar) = month(getdate())) AND (YEAR(Tarikh_Bayar) = year(getdate()))"
        SQLReader = opClass.DataReader(cekBayar)

        If SQLReader.HasRows Then
            SQLReader.Read()
            If (SQLReader.IsDBNull(0)) Then
                total_caj_kredit = "0.0"
            Else
                total_caj_kredit = Trim(SQLReader("total_caj"))
            End If
        End If

        SQLReader.Close()
        SQLReader = Nothing

        lbldepositagen.Text = CDec(DepositSkrg) - CDec(total_caj_kredit)

        ' end coded


        '********* to view information for Caj Perkhidmatan Ikan *********

        Dim viewborangikan As String = ""

        Dim sqlIkan As String = "SELECT sum(TotalCajIkan) as TotalCajIkan From " & Trim(tabletitle1) & " " _
        & " where No_barcode = '" & Trim(Request("strBarcode")) & "'"
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

        viewborangikan = "Caj Perkhidmatan Ikan" & "`" & (jumlahcajikan) & "`" & "LKIM" & "`" & "PENGISYTIHARAAN" & "~"

        '********* end count jumlah ikan and borang *********


        '********* to view information for Caj Borang SKPI ****************************


        Dim sqlBorang As String = "SELECT count(*) as countforskpi From " & Trim(tabletitle1) & " " _
        & " where No_barcode = '" & Trim(Request("strBarcode")) & "'"
        SQLReader = opClass.DataReader(sqlBorang)

        If SQLReader.HasRows Then

            SQLReader.Read()
            countforskpi = (SQLReader("countforskpi"))

        End If

        SQLReader.Close()
        SQLReader = Nothing


        Dim chargeBorang As String = ""
        Dim viewborang As String

        Dim rstBorang As String = "SELECT * FROM JENIS_URUSAN where Kod_Urusan='" & Trim(Request("Kod_Jenis_Urusan")) & "'"
        SQLReader = opClass.DataReader(rstBorang)

        If SQLReader.HasRows Then

            SQLReader.Read()
            'If Trim(Request("Kod_Jenis_Urusan")) = "001" Or "002" Or "004" Or "006" Or "014" Or "015" Then
            chargeBorang = ((countforskpi) * Trim(SQLReader("Borang")))
            '   End If

        End If

        viewborang = "Caj Pengisytiharan (Borang SKPI) - CFC" & "`" & chargeBorang & "`" & "CFC" & "`" & "PENGISYTIHARAAN" & "~"

        SQLReader.Close()
        SQLReader = Nothing

        '********* end count for charge borang *********

        '********* View borang for e-permit  *********

        Dim viewborangpermit As String = ""

        Dim status As String = "select status from epermit_maintenance"
        SQLReader = opClass.DataReader(status)

        If SQLReader.HasRows Then

            SQLReader.Read()

            If SQLReader("status") = "1" Then

                'load from table e-Permit +++ START
                Dim rstPermit As String = "select epermit_desc, epermit_cost from epermit_maintenance"
                SQLReader1 = opClass1.DataReader(rstPermit)

                If SQLReader1.HasRows Then

                    cajEpermit = Trim(rstPermit("epermit_desc")) & "`" & (0) & "`" & "CFC" & "`" & "PENGISYTIHARAAN" & "~"

                End If

                SQLReader1.Close()
                SQLReader1 = Nothing

            End If
        End If

        viewborangpermit = cajEpermit

        SQLReader.Close()
        SQLReader = Nothing

        '********* end count borang epermit *********

        '********* Checking for Item Caj ***************************

        Dim labelnull1 As Integer = 0
        Dim dataVal As String = ""
        Dim dataVal1 As String = ""

        Dim myRstQue = "SELECT * FROM SISTEM_Q WHERE DAY(Tarikh) = day(getdate()) AND MONTH(Tarikh) = month(getdate()) AND YEAR(Tarikh) = year(getdate()) AND No_Barcode = '" & Trim(txtRujukan.Text) & "'"
        SQLReader = opClass.DataReader(myRstQue)

        If SQLReader.HasRows Then

            SQLReader.Read()

            If SQLReader("status") = "Bayar" Then

                dataVal1 = ""
                cmdResit.Disabled = False
                cmdBayar.Enabled = False
                lblStatusPembayaran.Text = "Bayar"
                tolak.Disabled = True
                tambah.Disabled = True

                Dim sqlText As String = "SELECT * from Item_Caj where No_barcode = '" & Trim(Request("strBarcode")) & "'"
                SQLReader1 = opClass1.DataReader(sqlText)

                If SQLReader1.HasRows Then

                    While SQLReader1.Read()

                        If labelnull1 = 0 Then

                            dataVal = Trim(SQLReader1("Cara_Pembayaran")) & "`" & SQLReader1("No_Cek") & "`" & SQLReader1("Kod_Service_Caj") & "`" & SQLReader1("Nilai_Caj") & "`" & SQLReader1("DiCaj_Oleh") & "`" & SQLReader1("Tempat_Isytihar") & "~"

                        Else

                            dataVal = dataVal & Trim(SQLReader1("Cara_Pembayaran")) & "`" & SQLReader1("No_Cek") & "`" & SQLReader1("Kod_Service_Caj") & "`" & SQLReader1("Nilai_Caj") & "`" & SQLReader1("DiCaj_Oleh") & "`" & SQLReader1("Tempat_Isytihar") & "~"

                        End If

                        labelnull1 = labelnull1 + 1

                    End While

                    dataVal1 = ""
                    arrayValT.Value = dataVal
                    arrayVal.Value = ""


                End If

                SQLReader1.Close()
                SQLReader1 = Nothing


            Else


                Dim sqlText As String = "SELECT * from Item_Caj where Tempat_Isytihar='PEMERIKSAAN' AND No_barcode = '" & Trim(Request("strBarcode")) & "'"
                SQLReader1 = opClass1.DataReader(sqlText)

                If SQLReader1.HasRows Then

                    While SQLReader1.Read()

                        If labelnull1 = 0 Then

                            dataVal = Trim(SQLReader1("Kod_Service_Caj")) & "`" & SQLReader1("Nilai_Caj") & "`" & SQLReader1("DiCaj_Oleh") & "`" & SQLReader1("Tempat_Isytihar") & "~"

                        Else

                            dataVal = dataVal & Trim(SQLReader1("Kod_Service_Caj")) & "`" & SQLReader1("Nilai_Caj") & "`" & SQLReader1("DiCaj_Oleh") & "`" & SQLReader1("Tempat_Isytihar") & "~"

                        End If

                        labelnull1 = labelnull1 + 1

                    End While


                End If

                SQLReader1.Close()
                SQLReader1 = Nothing

                dataVal1 = viewborangikan & viewborang & viewborangpermit & dataVal
                lblStatusPembayaran.Text = "Belum Jelas"
                arrayVal.Value = dataVal1

            End If

        End If

        SQLReader.Close()
        SQLReader = Nothing


        '********* ended program coded ****************************

    End Sub

    Protected Sub BAYAR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBayar.Click

        opClass = New SQLOperation()
        opClass.dbConnection()
        opClass1 = New SQLOperation()
        opClass1.dbConnection()


        If Trim(sender.Id) = "cmdBayar" Then

            If arrayValT.Value = "" Then

                Response.Write("<script language = javascript>alert('Tiada pilihan dibuat untuk pembayaran.');self.location.href='pembayaranNew.aspx?selectpay=" & Trim(selectpay.Value) & "&Kod_Agen=" & Trim(Kod_Agen.Value) & "&Kod_Jenis_Urusan=" & Trim(Kod_Jenis_Urusan.Value) & "&no_kenderaan=" & Trim(lblnokenderaan.Text) & "&urusan=" & Trim(Urusan.Value) & "&strBarcode=" & Trim(txtRujukan.Text) & "';</script>")
                Response.End()

            End If

            ' untuk cek deposit semasa yang untuk yang ada agen dan pembayaran cek

            Dim rstKodagen As String = "select p.Nombor_Siri,p.kod_agen_pengangkutan as kod_agen,a.nama_agen_pengangkutan as nama_agen,a.deposit_semasa as deposit_semasa" _
            & " from pendaftaran_pintu p" _
            & " inner join agen_pengangkutan a on p.kod_agen_pengangkutan=a.kod_agen_pengangkutan" _
            & " where p.nombor_barcode='" & Trim(txtRujukan.Text) & "'"
            SQLReader = opClass.DataReader(rstKodagen)


            If SQLReader.HasRows Then
                SQLReader.Read()
                NoSiriResit = Trim(SQLReader("Nombor_Siri"))
                DepositSkrg = Trim(SQLReader("deposit_semasa"))

            End If

            SQLReader.Close()
            SQLReader = Nothing


            ' untuk cek jumlah yang ada telah digunakan oleh agen
            Dim cekBayar As String = "Select sum(jumlah_caj_kredit) as total_caj from pembayaran_caj where Kod_Agen_Pengangkutan = '" & Trim(Kod_Agen.Value) & "' and " _
            & "(DAY(Tarikh_Bayar) = day(getdate())) AND (MONTH(Tarikh_Bayar) = month(getdate())) AND (YEAR(Tarikh_Bayar) = year(getdate()))"
            SQLReader = opClass.DataReader(cekBayar)

            If SQLReader.HasRows Then
                SQLReader.Read()
                If (SQLReader.IsDBNull(0)) Then
                    total_caj_kredit = 0
                Else
                    total_caj_kredit = Trim(SQLReader("total_caj"))
                End If
            End If

            SQLReader.Close()
            SQLReader = Nothing


            ' end coded

            ' deposit semasa yang ada dengan agen 

            DepositSemasa = CDec(DepositSkrg) - CDec(total_caj_kredit)

            ' end coded

            Dim strValue = arrayValT.Value

            Dim i As Integer
            Dim rowArray = strValue.Split("~")

            ' view invois number from table
            Dim no_invois As Integer

            Dim intInvois As String = "select no_invois from no_invois where no_barcode='" & Trim(txtRujukan.Text) & "'"
            SQLReader = opClass.DataReader(intInvois)

            SQLReader.Read()
            no_invois = SQLReader("no_invois")

            SQLReader.Close()
            SQLReader = Nothing


            ' untuk cek samada boleh pakai cek ataupun tidak

            Dim cara_bayar As Boolean = False

            For i = 0 To UBound(rowArray) - 1

                Dim arrBayarCol() As String = rowArray(i).ToString().Split("`")

                If arrBayarCol(4) = "LKIM" Then

                    If arrBayarCol(0) = "CEK" Then

                        If (CDec(DepositSemasa) < CDec(total_caj_agen)) Or (CDec(DepositSemasa) = 0) Or (CDec(txtKredit.Text) > CDec(DepositSemasa)) Then

                            stmt = "Baki deposit semasa anda untuk pembayaran CEK ialah RM " & FormatNumber((DepositSemasa)) & ".Nilai ini tidak mencukupi untuk menjelaskan pembayaran CEK anda !.Anda dikehendaki menjelaskan pembayaran CEK anda dengan CEK dan TUNAI sahaja !"
                            Response.Write("<script languange=javascript>alert( '" & stmt & "');self.location.href='pembayaranNew.aspx?selectpay=" & Trim(selectpay.Value) & "&Kod_Agen=" & Trim(Kod_Agen.Value) & "&Kod_Jenis_Urusan=" & Trim(Kod_Jenis_Urusan.Value) & "&no_kenderaan=" & Trim(lblnokenderaan.Text) & "&urusan=" & Trim(Urusan.Value) & "&strBarcode=" & Trim(txtRujukan.Text) & "'</script>")
                            Response.End()

                        End If

                        cara_bayar = True

                    End If

                End If

            Next

            ' end coded

            ' to insert the data into the specific table

            Dim ikanvalue As Boolean = False
            Dim bil_item As Integer = 1
            Dim transaksi_semasa As Decimal = 0
            Dim totalTransaksiSemasa As Decimal
            Dim txtTotalCajTunai As Decimal = 0
            Dim txtTotalCajKredit As Decimal = 0
            Dim no_cek As String = ""


            'delete table item_caj untuk insert item yang baru

            Dim sqlcaj As String = "Delete FROM ITEM_CAJ WHERE No_Barcode = '" & Trim(txtRujukan.Text) & "'"
            opClass1.InsertData(sqlcaj)

            '  end coded


            If Trim(selectpay.Value) <> "Agen" Then

                For i = 0 To UBound(rowArray) - 1

                    Dim arrBayarCol() As String = rowArray(i).ToString().Split("`")

                    Call SaveSistemQ()

                    Dim sqlText1 As String = "INSERT INTO [W-ICCS].[dbo].[ITEM_CAJ]" _
                    & " ([No_Barcode], [Bil_Item], [Kod_Service_Caj], [Nilai_Caj],[Cara_Pembayaran],[No_Cek],[Dicaj_Oleh],[Tempat_Isytihar],[Nama_Pegawai],[No_Pegawai],site_code)" _
                    & " VALUES('" & Trim(txtRujukan.Text) & "','" & bil_item & "','" & arrBayarCol(2) & "','" & CDec(arrBayarCol(3)) & "','" & arrBayarCol(0) & "','" & arrBayarCol(1) & "','" & arrBayarCol(4) & "','" & arrBayarCol(5) & "','" & Session("namaPegawai") & "','" & Session("id_pegawai") & "','" & Right(Trim(txtRujukan.Text), 3) & "')"
                    opClass1.InsertData(sqlText1)
                    bil_item = bil_item + 1


                    If Trim(arrBayarCol(4)) = "CFC" Then

                        Dim sqlcheck1 As String = "Select * FROM pembayaran_caj_SKPI WHERE  No_Barcode = '" & Trim(txtRujukan.Text) & "'"
                        SQLReader = opClass.DataReader(sqlcheck1)

                        If Not SQLReader.HasRows Then

                            If Trim(arrBayarCol(5)) <> "PEMERIKSAAN" Then

                                Dim strBayar1 = "insert into pembayaran_caj_SKPI(no_barcode,no_invois,siri_module,kod_agen,print_status,site_code) " _
                               & "values('" & Trim(txtRujukan.Text) & "','" & Trim(no_invois) & "','individual_receipt','" & Trim(Kod_Agen.Value) & "','0','" & Right(Trim(txtRujukan.Text), 3) & "')"
                                opClass1.InsertData(strBayar1)

                            End If

                        End If

                        SQLReader.Close()
                        SQLReader = Nothing

                    End If


                    If Trim(arrBayarCol(4)) = "LKIM" Then

                        Dim sqlcheck2 As String = "Select * FROM pembayaran_caj_Ikan WHERE  No_Barcode = '" & Trim(txtRujukan.Text) & "'"
                        SQLReader = opClass.DataReader(sqlcheck2)

                        If Not SQLReader.HasRows Then

                            If Trim(arrBayarCol(5)) <> "PEMERIKSAAN" Then

                                Dim strBayar2 = "insert into pembayaran_caj_Ikan(no_barcode,no_invois,siri_module,kod_agen,print_status,site_code) " _
                                & "values('" & Trim(txtRujukan.Text) & "','" & Trim(no_invois) & "','individual_receipt','" & Trim(Kod_Agen.Value) & "','0','" & Right(Trim(txtRujukan.Text), 3) & "')"
                                opClass1.InsertData(strBayar2)
                                ikanvalue = True

                            End If

                        End If

                        SQLReader.Close()
                        SQLReader = Nothing


                        If ikanvalue = True Then

                            If arrBayarCol(0) = "CEK" Then
                                '  txtTotalCajKredit = CDec(txtTotalCajKredit) + CDec(arrBayarCol(3))
                                ' txtTotalCajTunai = 0
                                no_cek = arrBayarCol(1)

                            Else
                                'txtTotalCajTunai = CDec(txtTotalCajTunai) + CDec(arrBayarCol(3))
                                'txtTotalCajKredit = 0
                                no_cek = "Tiada"

                            End If

                            '    totalTransaksiSemasa = totalTransaksiSemasa + CDec(arrBayarCol(3))

                        End If


                    End If


                    If Trim(arrBayarCol(5)) <> "PEMERIKSAAN" Then

                        If arrBayarCol(0) = "CEK" Then
                            txtTotalCajKredit = CDec(txtTotalCajKredit) + CDec(arrBayarCol(3))
                            txtTotalCajTunai = 0
                            '   no_cek = arrBayarCol(1)

                        Else
                            txtTotalCajTunai = CDec(txtTotalCajTunai) + CDec(arrBayarCol(3))
                            txtTotalCajKredit = 0
                            '  no_cek = "Tiada"

                        End If

                        totalTransaksiSemasa = totalTransaksiSemasa + CDec(arrBayarCol(3))

                    End If


                Next


                If cara_bayar = True Then

                    Baki_Semasa = CDec(DepositSemasa) - CDec(totalTransaksiSemasa)

                    Dim rstLogCek As String = "Select * FROM LOG_TRANSAKSI_DEPOSIT WHERE  No_Barcode = '" & Trim(txtRujukan.Text) & "'"
                    SQLReader = opClass.DataReader(rstLogCek)

                    ' Simpan Log Transaksi Deposit Bank Yang Menggunakan CEK
                    If Not SQLReader.HasRows Then

                        Dim rstLogCekIn1 As String = "Insert Into LOG_TRANSAKSI_DEPOSIT (No_Barcode,No_Siri,Kod_Agen_Pengangkutan," _
                        & "Deposit_Semasa,Transaksi_Deposit,Baki_Semasa,Nama_pegawai," _
                        & "No_Pegawai,site_code) Values ('" & Trim(txtRujukan.Text) & "','" & Trim(NoSiriResit) & "','" & Trim(Kod_Agen.Value) & "','" & Trim(CDec(DepositSemasa)) & "'," _
                        & "'" & Trim(CDec(totalTransaksiSemasa)) & "','" & Trim(CDec(Baki_Semasa)) & "','" & Session("namaPegawai") & "','" & Session("id_pegawai") & "','" & Right(Trim(txtRujukan.Text), 3) & "')"
                        opClass1.InsertData(rstLogCekIn1)

                    End If

                    SQLReader.Close()
                    SQLReader = Nothing

                End If


                If ikanvalue = True Then


                    Dim rstPembayaranCaj As String = "Select * FROM PEMBAYARAN_CAJ WHERE  No_Barcode = '" & Trim(txtRujukan.Text) & "'"
                    SQLReader = opClass.DataReader(rstPembayaranCaj)

                    If Not SQLReader.HasRows Then

                        Dim rstPembayaranCaj1 As String = "Insert Into PEMBAYARAN_CAJ (No_Barcode,No_Siri,No_Kenderaan," _
                        & "Jumlah_Caj_Tunai,Jumlah_Caj_Kredit,Jumlah_Caj,Kod_Agen_Pengangkutan," _
                        & "No_Pegawai,Nama_Pegawai,Status,No_Cek,site_code) Values ('" & Trim(txtRujukan.Text) & "','" & Trim(NoSiriResit) & "','" & Trim(lblnokenderaan.Text) & "'," _
                        & "'" & Trim(CDec(txtTotalCajTunai)) & "','" & Trim(CDec(txtTotalCajKredit)) & "','" & Trim(CDec(totalTransaksiSemasa)) & "','" & Trim(Kod_Agen.Value) & "'," _
                        & "'" & Session("id_pegawai") & "','" & Session("namaPegawai") & "','JELAS','" & Trim(no_cek) & "','" & Right(Trim(txtRujukan.Text), 3) & "')"
                        opClass1.InsertData(rstPembayaranCaj1)

                    End If

                    SQLReader.Close()
                    SQLReader = Nothing


                End If


            Else

                Call SaveSistemQ()
                Response.Write("<script language = javascript>alert('Status pelepasan telah diberikan untuk nombor barcode tersebut. Sila buat pembayaran melalui agen.');self.location.href='verifikasi_bayar.aspx?urusan=" & Trim(Urusan.Value) & "';</script>")
                Response.End()


            End If


            ' insert for status transaction

            Dim sqlupdate As String = "INSERT INTO IsyProgressStatus_Front([no_rujukan],[no_barcode], [proses], [dateEnter], [entryBy])" & _
            "VALUES('','" & Trim(txtRujukan.Text) & "','PEMBAYARAN CAJ IKAN',getdate(),'" & Session("username") & "')"
            opClass1.InsertData(sqlupdate)

            ' end coded


            Response.Write("<script language = javascript>alert('Maklumat pembayaran untuk caj telah disimpan.');self.location.href='pembayaranNew.aspx?Kod_Agen=" & Trim(Kod_Agen.Value) & "&no_kenderaan= " & Trim(lblnokenderaan.Text) & "&urusan=" & Trim(Urusan.Value) & "&strBarcode=" & Trim(txtRujukan.Text) & "';</script>")
            Response.End()

        End If

        opClass.dbConnection_Close()
        opClass1.dbConnection_Close()

    End Sub


    Private Sub SaveSistemQ()

        opClass = New SQLOperation()
        opClass.dbConnection()
        opClass1 = New SQLOperation()
        opClass1.dbConnection()
        Dim status As String = ""

        If Trim(selectpay.Value) = "Agen" Then
            status = "Pelepasan"
        Else
            status = "Bayar"
        End If

        Dim myRstQue = "SELECT * FROM SISTEM_Q WHERE DAY(Tarikh) = day(getdate()) AND MONTH(Tarikh) = month(getdate()) AND YEAR(Tarikh) = year(getdate()) AND No_Barcode = '" & Trim(txtRujukan.Text) & "'"
        SQLReader = opClass.DataReader(myRstQue)

        If Not SQLReader.HasRows Then
            SQLReader.Close()
            SQLReader = Nothing
            Response.Write("<script language=javascript>alert('Sistem-Q tidak dapat mengemaskini status Pembayaran kerana maklumat belum wujud !');self.location.href='verifikasi_bayar.aspx';</script>")
            Response.End()
        Else

            Dim myRstQue1 = "UPDATE SISTEM_Q Set status='" & Trim(status) & "',pegawai='" & Session("namaPegawai") & "' WHERE " _
            & "DAY(Tarikh) = day(getdate()) AND MONTH(Tarikh) = month(getdate()) AND YEAR(Tarikh) = year(getdate()) AND No_Barcode = '" & Trim(txtRujukan.Text) & "'"
            opClass1.InsertData(myRstQue1)

        End If


        SQLReader.Close()
        SQLReader = Nothing

        opClass.dbConnection_Close()
        opClass1.dbConnection_Close()

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        opClass.dbConnection_Close()
        opClass1.dbConnection_Close()
    End Sub


End Class
