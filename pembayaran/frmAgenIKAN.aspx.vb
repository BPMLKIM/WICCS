
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class pembayaran_frmAgenIKAN
    Inherits System.Web.UI.Page

#Region "Variables Declaration"
    Protected opClass As SQLOperation
    Protected opClass1 As SQLOperation
    Protected opClass2 As SQLOperation
    Protected opClass3 As SQLOperation
    Dim SQLReader As System.Data.SqlClient.SqlDataReader
    Dim SQLReader1 As System.Data.SqlClient.SqlDataReader
    Dim SQLReader3 As System.Data.SqlClient.SqlDataReader
    Dim SQLReader4 As System.Data.SqlClient.SqlDataReader

    Dim DepositSemasa As Decimal
    Dim total_caj_kredit As Decimal
    Dim total_caj_agen As Decimal
    Dim stmt As String = ""
    Dim NoSiriResit As String = ""
    Public Baki_Semasa As Decimal = 0.0
    Dim DepositSkrg As Decimal
    Dim transaksi_semasa As Decimal

    Dim barcodex As String

    Public printpaper As Boolean

#End Region

    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        opClass = New SQLOperation()
        opClass.dbConnection()

        opClass1 = New SQLOperation()
        opClass1.dbConnection()

        opClass2 = New SQLOperation()
        opClass2.dbConnection()

        opClass3 = New SQLOperation()
        opClass3.dbConnection()

        Session.LCID = 2057

        If Page.IsPostBack Then

            If TextBox2.Text = "" Or kod_agen.Text = "" Then

                Response.Write("<script languange=javascript>alert('Sila masukkan tarikh dan kod agen');self.location.href='frmAgenIKAN.aspx';</script>")
                Response.End()

            End If

            id_nameagen.Attributes.Add("style", "DISPLAY:Block")
            Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5))
            txtCek.Attributes.Add("onKeyPress", "return keyToUpperCase(this, event);")


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

            cmdBayar.Enabled = True

            Dim splitout = Split(TextBox2.Text, "/")

            Dim strKod As String = "select nama_agen_pengangkutan,kod_agen_pengangkutan,deposit_semasa,transaksi_semasa from agen_pengangkutan where " _
            & "kod_agen_pengangkutan='" & Trim(kod_agen.Text) & "' and status='yes'"
            SQLReader = opClass.DataReader(strKod)

            If SQLReader.HasRows Then

                SQLReader.Read()
                depositid.Value = Trim(SQLReader("deposit_semasa"))
                name_agen.Text = SQLReader("nama_agen_pengangkutan")
                DepositSkrg = Trim(SQLReader("deposit_semasa"))
                bayar_semasa.Value = (Trim(CDec(SQLReader("transaksi_semasa"))))
            Else
                name_agen.Text = "Nama Agen tidak terdapat dalam pengkalan data"

            End If

            SQLReader.Close()
            SQLReader = Nothing

            'Dim sqlT = "select sum(transaksi_deposit) as total from LOG_TRANSAKSI_DEPOSIT where " _
            '& " (DAY(Tarikh) = day(getdate())) AND (MONTH(Tarikh) = month(getdate())) AND (YEAR(Tarikh) = year(getdate())) and " _
            '& " kod_agen_pengangkutan = '" & Trim(kod_agen.Text) & "'"
            'SQLReader = opClass.DataReader(sqlT)

            'SQLReader.Read()

            'bayar_semasa.Value = CDec(SQLReader("total"))

            'SQLReader.Close()
            'SQLReader = Nothing


            ' untuk cek deposit semasa & jumlah yang ada dengan agen

            Dim myRstQue2 = "select p.kod_agen_pengangkutan as kod_agen" _
            & " from pendaftaran_pintu p" _
            & " inner join sistem_q a on p.nombor_barcode=a.no_barcode" _
            & " WHERE p.kod_agen_pengangkutan = '" & Trim(kod_agen.Text) & "'" _
            & " and (DAY(a.Tarikh) = day(getdate())) AND (MONTH(a.Tarikh) = month(getdate())) AND (YEAR(a.Tarikh) = year(getdate())) and " _
            & " ((a.status like '%Pintu Keluar%') OR (a.status='Pelepasan') or (a.status='Bayar'))"
            SQLReader = opClass.DataReader(myRstQue2)

            SQLReader.Read()

            If SQLReader.HasRows Then

                total_caj_kredit = CDec(DepositSkrg) - CDec(bayar_semasa.Value)

            Else

                total_caj_kredit = CDec(DepositSkrg)

                Dim updateU1 As String = "Update AGEN_PENGANGKUTAN set transaksi_semasa ='0' where Kod_Agen_Pengangkutan='" & kod_agen.Text & "'"
                opClass1.InsertData(updateU1)

            End If

            SQLReader.Close()
            SQLReader = Nothing

        lbldepositagen.Text = FormatNumber(total_caj_kredit)

            ' info untuk paparkan yang belum bayar lagi

            'Response.Write("<br>StartReport 1 =" & Now())




            '------------------------------------------------------utk asingkan rebat dgn bukan rebat

            Dim strSQL As String = "select no_barcode as no_barcode,no_invois,sum(cajikan) as cajikan " _
                    & "from v_kena_bayar where kod_agen_pengangkutan='" & Trim((kod_agen.Text)) & "' " _
                    & "and day(Tarikh_Masa_Masuk)='" & splitout(0) & "' and month(Tarikh_Masa_Masuk)='" & splitout(1) & "' " _
                    & "and year(Tarikh_Masa_Masuk)='" & splitout(2) & "' and status='A'and data='NP'" _
                    & "group by no_barcode,no_invois"
            SQLReader = opClass.DataReader(strSQL)
            '   Response.Write("<br>endReport 1 =" & Now())

            Dim cajIkan As String = ""

            If SQLReader.HasRows Then

                Dim bil As Integer = 0

                While SQLReader.Read()
                    barcodex = SQLReader("no_barcode")

                    Dim strSQL4 As String = "select no_barcode,no_invois,sum(cajikansebenar) as cajikansebenar,sum(cajikan) as cajikan ,sum(totalkurangcajikan) as totalkurangcajikan " _
                               & "from v_kena_bayar_kibfg where kod_agen_pengangkutan='" & Trim((kod_agen.Text)) & "' " _
                               & "and day(Tarikh_Masa_Masuk)='" & splitout(0) & "' and month(Tarikh_Masa_Masuk)='" & splitout(1) & "' " _
                               & "and year(Tarikh_Masa_Masuk)='" & splitout(2) & "' and status='A'and data='NP' and no_barcode='" & barcodex & "'" _
                               & "group by no_barcode,no_invois"
                    SQLReader4 = opClass3.DataReader(strSQL4)

                    If (SQLReader4.HasRows = False) Then
                        'If bil = 0 Then

                        'cajIkan = SQLReader("no_barcode") & "`" & SQLReader("no_invois") & "`" & (SQLReader("cajikan")) & "~"

                        'Else

                        cajIkan = cajIkan & SQLReader("no_barcode") & "`" & SQLReader("no_invois") & "`" & (SQLReader("cajikan")) & "~"

                        'End If

                        'bil = bil + 1
                       
                    End If
                    SQLReader4.Close()
                    SQLReader4 = Nothing


                End While

                arrayVal.Value = cajIkan

            Else

                arrayVal.Value = ""

            End If

            SQLReader.Close()
            SQLReader = Nothing

            ' end coded

            '-----------------------------------------------------------------------------------------------------koding asal sebelum filter hanya bukan rebat

            '    Dim strSQL As String = "select no_barcode,no_invois,sum(cajikan) as cajikan " _
            '            & "from v_kena_bayar where kod_agen_pengangkutan='" & Trim((kod_agen.Text)) & "' " _
            '            & "and day(Tarikh_Masa_Masuk)='" & splitout(0) & "' and month(Tarikh_Masa_Masuk)='" & splitout(1) & "' " _
            '            & "and year(Tarikh_Masa_Masuk)='" & splitout(2) & "' and status='A'and data='NP'" _
            '            & "group by no_barcode,no_invois"
            '    SQLReader = opClass.DataReader(strSQL)
            '    '   Response.Write("<br>endReport 1 =" & Now())

            'Dim cajIkan As String = ""

            'If SQLReader.HasRows Then

            '    Dim bil As Integer = 0

            '    While SQLReader.Read()

            '            'If bil = 0 Then

            '            'cajIkan = SQLReader("no_barcode") & "`" & SQLReader("no_invois") & "`" & (SQLReader("cajikan")) & "~"

            '            'Else

            '            cajIkan = cajIkan & SQLReader("no_barcode") & "`" & SQLReader("no_invois") & "`" & (SQLReader("cajikan")) & "~"

            '            'End If

            '            'bil = bil + 1

            '        End While

            '        arrayVal.Value = cajIkan

            '    Else

            '        arrayVal.Value = ""

            '    End If

            '    SQLReader.Close()
            '    SQLReader = Nothing

            ' end coded
            '-----------------------------------------------------------------------------------------------------------------------------------
            lblStatusPembayaran.Text = ""

            cmdResit.Disabled = False
            Button7.Disabled = False
            Button3.Disabled = False
            cmdBayar.Enabled = True

            If txtKredit.Text <> "0.00" Then
                cmdBayar.Enabled = False
            End If

            If Request("strVal") <> "" Then
                kod_agen.Enabled = False
            End If



        Else

            TextBox2.Text = (Left(Trim(Date.Now()), 10))


            If Request("strVal") <> "" Then

                TextBox2.Text = Trim(Request("tarikh_send"))

                Dim i As Integer
                Dim labelnull1 As Integer = 0
                Dim rowArray = Request("strVal").Split("~")
                Dim dataVal As String = ""
                Dim barcodenumber As String = ""
                Dim splitout = Split(Request("tarikh_send"), "/")

                For i = 0 To UBound(rowArray) - 1

                    Dim arrBayarCol() As String = rowArray(i).ToString().Split("`")

                    'If labelnull1 = 0 Then

                    'dataVal = Trim(arrBayarCol(0)) & "`" & Trim(arrBayarCol(1)) & "`" & Trim(arrBayarCol(2)) & "`" & Trim(arrBayarCol(3)) & "`" & Trim(arrBayarCol(4)) & "`" & Trim(arrBayarCol(5)) & "`" & Trim(arrBayarCol(6)) & "~"
                    'barcodenumber = Trim(arrBayarCol(4)) & "~"

                    'Else

                    dataVal = dataVal & Trim(arrBayarCol(0)) & "`" & Trim(arrBayarCol(1)) & "`" & Trim(arrBayarCol(2)) & "`" & Trim(arrBayarCol(3)) & "`" & Trim(arrBayarCol(4)) & "`" & Trim(arrBayarCol(5)) & "`" & Trim(arrBayarCol(6)) & "~"
                    barcodenumber = barcodenumber & Trim(arrBayarCol(4)) & "~"

                    'End If

                    'labelnull1 = labelnull1 + 1

                Next

                ' info untuk paparkan yang dah bayar lagi dan untuk print sekali

                arrayValT.Value = dataVal
                listbarcode.Value = barcodenumber
                kod_agen.Enabled = False


                If txtKredit.Text <> "0.00" Then
                    cmdBayar.Enabled = False
                End If

                tolak.Disabled = True
                tambah.Disabled = True
                cmdResit.Disabled = False
                Button7.Disabled = False
                Button3.Disabled = False

                Dim strKod As String = "select kod_agen_pengangkutan,deposit_semasa,transaksi_semasa from agen_pengangkutan where kod_agen_pengangkutan='" & Trim(Request("kod_agen")) & "'"
                SQLReader3 = opClass2.DataReader(strKod)

                If SQLReader3.HasRows Then

                    SQLReader3.Read()
                    DepositSkrg = Trim(SQLReader3("deposit_semasa"))
                    total_caj_kredit = Trim(SQLReader3("transaksi_semasa"))

                End If

                SQLReader3.Close()
                SQLReader3 = Nothing

                lbldepositagen.Text = FormatNumber(CDec(DepositSkrg) - CDec(total_caj_kredit))

                lblStatusPembayaran.Text = "Bayar"
                kod_agen.Text = Trim(Request("kod_agen"))
                TextBox2.Text = Trim(Request("tarikh_send"))


            End If

            ' end coded

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

            printer_name.Value = (Replace(printer_name.Value, "/", "\"))


        End If

        SQLReader.Close()
        SQLReader = Nothing


    End Sub


    Public Sub BAYAR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load, cmdBayar.Click

        opClass = New SQLOperation()
        opClass.dbConnection()
        opClass1 = New SQLOperation()
        opClass1.dbConnection()
        opClass2 = New SQLOperation()
        opClass2.dbConnection()

        Dim splitout = Split(TextBox2.Text, "/")
        Dim cara_bayar As Boolean = False


        If (sender.Id) = "cmdBayar" Then

            If arrayValT.Value <> "" Then

                Dim strValue = arrayValT.Value
                Dim i As Integer
                Dim rowArray = strValue.Split("~")

                ' untuk update dalam transaksi semasa

                Dim arrloop1 As String

                If UBound(rowArray) = 0 Then
                    arrloop1 = 0
                Else
                    arrloop1 = UBound(rowArray) - 1

                End If

                For i = 0 To arrloop1

                    Dim arrBayarCol() As String = rowArray(i).ToString().Split("`")

                    If arrBayarCol(0) = "CEK" Or arrBayarCol(0) = "CEK / TUNAI" Then

                        cara_bayar = True

                    End If

                Next

                'total bayaran yang telah dibuat oleh agen untk hari ini

                If cara_bayar = True Then

                    If (CDec(txtKredit.Text) > CDec(depositid.Value)) Then

                        stmt = "Baki deposit semasa anda untuk pembayaran CEK ialah RM " & FormatNumber((lbldepositagen.Text)) & ".Nilai ini tidak mencukupi untuk menjelaskan pembayaran CEK anda !.Anda dikehendaki menjelaskan pembayaran CEK anda dengan CEK dan TUNAI sahaja !"
                        Response.Write("<script languange=javascript>alert( '" & stmt & "');self.location.href='frmAgenIKAN.aspx';</script>")
                        Response.End()

                    End If

                End If

                ' End Coded

                ' untuk cek samada boleh pakai cek ataupun tidak


                ' to insert the data into the specific table
                Dim arrloop As String
                Dim ikanvalue As Boolean = False
                Dim bil_item As Integer
                Dim transaksi_semasa As Decimal = 0
                Dim totalTransaksiSemasa As Decimal
                Dim txtTotalCajTunai As Decimal = 0
                Dim txtTotalCajKredit As Decimal = 0
                Dim no_cek As String = ""

                If UBound(rowArray) = 0 Then
                    arrloop = 0
                Else
                    arrloop = UBound(rowArray) - 1

                End If

                Baki_Semasa = Trim(CDec(Replace(lbldepositagen.Text, ",", "")))
                transaksi_semasa = CDec(bayar_semasa.Value)

                For i = 0 To arrloop

                    Dim arrBayarCol() As String = rowArray(i).ToString().Split("`")

                    Dim myRstQue1 = "SELECT status FROM SISTEM_Q WHERE DAY(Tarikh) ='" & Trim(splitout(0)) & "' AND MONTH(Tarikh) = '" & Trim(splitout(1)) & "' AND YEAR(Tarikh) = '" & Trim(splitout(2)) & "' AND No_Barcode = '" & Trim(arrBayarCol(4)) & "'"
                    SQLReader = opClass.DataReader(myRstQue1)

                    If Not SQLReader.HasRows Then

                        SQLReader.Close()
                        SQLReader = Nothing

                        Response.Write("<script language=javascript>alert('Sistem-Q tidak dapat mengemaskini status Pembayaran kerana maklumat belum wujud !');self.location.href='verifikasi_bayar.aspx';</script>")
                        Response.End()

                    Else

                        SQLReader.Read()


                        If Trim(SQLReader("status")) = "Periksa" or Trim(SQLReader("status")) = "Pelepasan"  Then

                            Dim myRstQue10 = "UPDATE SISTEM_Q Set status='Bayar',pegawai='" & Session("namaPegawai") & "' WHERE " _
                            & "DAY(Tarikh) = '" & Trim(splitout(0)) & "' AND MONTH(Tarikh) = '" & Trim(splitout(1)) & "' AND YEAR(Tarikh) = '" & Trim(splitout(2)) & "' AND No_Barcode = '" & Trim(arrBayarCol(4)) & "'"
                            opClass2.InsertData(myRstQue10)

                        End If

                        SQLReader.Close()
                        SQLReader = Nothing

                    End If


                    Dim sqlbil As String = "Select bil_item from item_caj where No_Barcode= '" & Trim(arrBayarCol(4)) & "' order by bil_item desc"
                    SQLReader = opClass.DataReader(sqlbil)

                    SQLReader.Read()

                    If SQLReader.HasRows Then

                        bil_item = SQLReader("bil_item") + 1

                    Else
                        bil_item = 1

                    End If


                    SQLReader.Close()
                    SQLReader = Nothing


                    If arrBayarCol(0) = "CEK / TUNAI" Then

                        'bil_item = bil_item + 1

                        If arrBayarCol(2) <> "" Then

                            Dim sqlText1 = "INSERT INTO [W-ICCS].[dbo].[ITEM_CAJ]" _
                            & " ([No_Barcode], [Bil_Item], [Kod_Service_Caj], [Nilai_Caj],[Cara_Pembayaran],[No_Cek],[Dicaj_Oleh],[Tempat_Isytihar],[Nama_Pegawai],[No_Pegawai],site_code)" _
                            & " VALUES('" & Trim(arrBayarCol(4)) & "','" & bil_item & "','Caj Perkhidmatan Ikan'," _
                            & " '" & CDec(arrBayarCol(2)) & "','TUNAI','Tiada'," _
                            & " 'LKIM','PENGISYTIHARAN','" & Session("namaPegawai") & "'," _
                            & " '" & Session("id_pegawai") & "','" & Right(Trim(arrBayarCol(4)), 3) & "')"
                            opClass2.InsertData(sqlText1)

                        End If

                        bil_item = bil_item + 1

                        If arrBayarCol(3) <> "" Then

                            Dim sqlText2 = "INSERT INTO [W-ICCS].[dbo].[ITEM_CAJ]" _
                            & " ([No_Barcode], [Bil_Item], [Kod_Service_Caj], [Nilai_Caj],[Cara_Pembayaran],[No_Cek],[Dicaj_Oleh],[Tempat_Isytihar],[Nama_Pegawai],[No_Pegawai],site_code)" _
                            & " VALUES('" & Trim(arrBayarCol(4)) & "','" & bil_item & "','Caj Perkhidmatan Ikan'," _
                            & " '" & CDec(arrBayarCol(3)) & "','CEK','" & Trim(arrBayarCol(1)) & "'," _
                            & " 'LKIM','PENGISYTIHARAN','" & Session("namaPegawai") & "'," _
                            & " '" & Session("id_pegawai") & "','" & Right(Trim(arrBayarCol(4)), 3) & "')"
                            opClass2.InsertData(sqlText2)


                        End If



                    Else

                        'bil_item = bil_item + 1

                        If arrBayarCol(0) = "CEK" Then
                            no_cek = arrBayarCol(1)
                        Else
                            no_cek = "Tiada"
                        End If

                        Dim sqlText1 = "INSERT INTO [W-ICCS].[dbo].[ITEM_CAJ]" _
                        & " ([No_Barcode], [Bil_Item], [Kod_Service_Caj], [Nilai_Caj],[Cara_Pembayaran],[No_Cek],[Dicaj_Oleh],[Tempat_Isytihar],[Nama_Pegawai],[No_Pegawai],site_code)" _
                        & " VALUES('" & Trim(arrBayarCol(4)) & "','" & bil_item & "','Caj Perkhidmatan Ikan'," _
                        & " '" & CDec(arrBayarCol(6)) & "','" & Trim(arrBayarCol(0)) & "','" & Trim(no_cek) & "'," _
                        & " 'LKIM','PENGISYTIHARAN','" & Session("namaPegawai") & "'," _
                        & " '" & Session("id_pegawai") & "','" & Right(Trim(arrBayarCol(4)), 3) & "')"
                        opClass2.InsertData(sqlText1)

                    End If

                    Dim no_invois As Integer

                    Dim intInvois As String = "select no_invois from no_invois where no_barcode='" & Trim(arrBayarCol(4)) & "'"
                    SQLReader = opClass.DataReader(intInvois)

                    SQLReader.Read()
                    no_invois = SQLReader("no_invois")

                    SQLReader.Close()
                    SQLReader = Nothing


                    Dim sqlcheck1 As String = "Select No_Barcode FROM pembayaran_caj_Ikan WHERE  No_Barcode = '" & Trim(arrBayarCol(4)) & "'"
                    SQLReader = opClass.DataReader(sqlcheck1)

                    SQLReader.Read()

                    If Not SQLReader.HasRows Then

                        Dim strBayar2 = "insert into pembayaran_caj_Ikan(no_barcode,no_invois,siri_module,kod_agen,print_status,site_code) " _
                        & "values('" & Trim(arrBayarCol(4)) & "','" & Trim(no_invois) & "','agent_receipt','" & Trim(kod_agen.Text) & "','0','" & Right(Trim(arrBayarCol(4)), 3) & "')"
                        opClass2.InsertData(strBayar2)

                    End If

                    SQLReader.Close()
                    SQLReader = Nothing


                    If arrBayarCol(0) = "CEK" Or arrBayarCol(0) = "CEK / TUNAI" Then

                        If arrBayarCol(0) = "CEK / TUNAI" Then
                            txtTotalCajKredit = CDec(arrBayarCol(3))
                            txtTotalCajTunai = CDec(arrBayarCol(2))
                        End If

                        If arrBayarCol(0) = "CEK" Then
                            txtTotalCajKredit = CDec(arrBayarCol(6))
                        End If

                        no_cek = arrBayarCol(1)
                        cara_bayar = True

                        Dim rstLogCek As String = "Select No_Barcode FROM LOG_TRANSAKSI_DEPOSIT WHERE No_Barcode = '" & Trim(arrBayarCol(4)) & "'"
                        SQLReader = opClass.DataReader(rstLogCek)


                        ' Simpan Log Transaksi Deposit Bank Yang Menggunakan CEK
                        If Not SQLReader.HasRows Then

                            Dim rstLogCekIn1 As String = "Insert Into LOG_TRANSAKSI_DEPOSIT (No_Barcode,Kod_Agen_Pengangkutan," _
                            & "Deposit_Semasa,Transaksi_Deposit,Baki_Semasa,Nama_pegawai," _
                            & "No_Pegawai,site_code) Values ('" & Trim(arrBayarCol(4)) & "','" & Trim(kod_agen.Text) & "','" & Trim(CDec(Baki_Semasa)) & "'," _
                            & "'" & Trim(CDec(txtTotalCajKredit)) & "','" & Trim(CDec(Baki_Semasa)) - Trim(CDec(txtTotalCajKredit)) & "','" & Session("namaPegawai") & "','" & Session("id_pegawai") & "','" & Right(Trim(arrBayarCol(4)), 3) & "')"
                            opClass2.InsertData(rstLogCekIn1)

                            transaksi_semasa = CDec(transaksi_semasa) + CDec(txtTotalCajKredit)

                            Dim updateU As String = "Update AGEN_PENGANGKUTAN set transaksi_semasa = '" & CDec(transaksi_semasa) & "' " _
                                & " where Kod_Agen_Pengangkutan='" & kod_agen.Text & "'"
                            opClass2.InsertData(updateU)

                            Baki_Semasa = Trim(CDec(Baki_Semasa)) - Trim(CDec(txtTotalCajKredit))

                        End If

                        SQLReader.Close()
                        SQLReader = Nothing



                    Else

                        If arrBayarCol(0) = "TUNAI" Then
                            txtTotalCajTunai = CDec(arrBayarCol(6))
                            txtTotalCajKredit = 0
                        End If

                        no_cek = "Tiada"

                    End If

                    totalTransaksiSemasa = CDec(txtTotalCajKredit) + CDec(txtTotalCajTunai)

                    Dim rstPembayaranCaj As String = "Select No_Barcode FROM PEMBAYARAN_CAJ WHERE  No_Barcode = '" & Trim(arrBayarCol(4)) & "'"
                    SQLReader = opClass.DataReader(rstPembayaranCaj)

                    If Not SQLReader.HasRows Then

                        Dim pintumasuk As String = "select Nombor_Siri,no_kenderaan from pendaftaran_pintu where nombor_barcode='" & Trim(arrBayarCol(4)) & "'"
                        SQLReader1 = opClass1.DataReader(pintumasuk)

                        SQLReader1.Read()

                        Dim rstPembayaranCaj1 As String = "Insert Into PEMBAYARAN_CAJ (No_Barcode,No_Siri,No_Kenderaan," _
                        & "Jumlah_Caj_Tunai,Jumlah_Caj_Kredit,Jumlah_Caj,Kod_Agen_Pengangkutan,No_cek," _
                        & "No_Pegawai,Nama_Pegawai,Status,site_code) Values ('" & Trim(arrBayarCol(4)) & "','" & Trim(SQLReader1("Nombor_Siri")) & "','" & Trim(SQLReader1("no_kenderaan")) & "'," _
                        & "'" & Trim(CDec(txtTotalCajTunai)) & "','" & Trim(CDec(txtTotalCajKredit)) & "','" & Trim(CDec(totalTransaksiSemasa)) & "','" & Trim(kod_agen.Text) & "','" & Trim(no_cek) & "'," _
                        & "'" & Session("id_pegawai") & "','" & Session("namaPegawai") & "','JELAS','" & Right(Trim(arrBayarCol(4)), 3) & "')"
                        opClass2.InsertData(rstPembayaranCaj1)

                        SQLReader1.Close()
                        SQLReader1 = Nothing

                    End If

                    SQLReader.Close()
                    SQLReader = Nothing

                    ' insert for status transaction

                    Dim sqlupdate As String = "INSERT INTO IsyProgressStatus_Front([no_rujukan],[no_barcode], [proses], [dateEnter], [entryBy])" & _
                    "VALUES('','" & Trim(arrBayarCol(4)) & "','PEMBAYARAN CAJ IKAN',getdate(),'" & Session("username") & "')"
                    opClass1.InsertData(sqlupdate)

                    ' end coded

                Next


                Response.Write("<script languange=javascript>alert('Maklumat pembayaran CAJ telah disimpan.');self.location.href='frmAgenIKAN.aspx?strVal=" & Trim(arrayValT.Value) & "&tarikh_send=" & Trim(TextBox2.Text) & "&Kod_Agen= " & Trim(kod_agen.Text) & "';</script>")
                Response.End()

            Else

                Response.Write("<script language = javascript>alert('Tiada pilihan dibuat untuk pembayaran.');self.location.href='frmAgenIKAN.aspx';</script>")
                Response.End()

            End If


        End If

    End Sub


    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        opClass.dbConnection_Close()
        opClass1.dbConnection_Close()
        opClass2.dbConnection_Close()
    End Sub

   
End Class
