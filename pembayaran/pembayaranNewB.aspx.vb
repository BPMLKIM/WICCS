Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Windows.Forms


Partial Class pembayaran_pembayaranNewB
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
    Dim byrIkan As String = ""
    Dim byrBorang As String = ""
    Public filetransfer As String = ""

#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        opClass = New SQLOperation()
        opClass.dbConnection()

        Dim cajBorang1 As String = ""
        Dim cajEpermit As String = ""

        Dim tabletitle As String = ""
        Dim tabletitle1 As String = ""
        Dim tabletitle2 As String = ""

        Dim textfield As String = ""
        Dim title As String = ""

        Dim dataVal1 As String = ""

        If Trim(Request("urusan")) = "I" Then

            'import table
            tabletitle = "ITEM_ISYTIHAR_I"
            tabletitle1 = "PENGISYTIHARAN_I"
            tabletitle2 = "PEMERIKSAAN_IMPORT"
            textfield = "No_SKPI"
            title = "import"

        Else
            'eksport table
            tabletitle = "ITEM_ISYTIHAR_E"
            textfield = "No_SKPE"
            title = "eksport"
            tabletitle1 = "PENGISYTIHARAN_E"
            tabletitle2 = "PEMERIKSAAN_EKSPORT"

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

        txtCek.Attributes.Add("onKeyPress", "return keyToUpperCase(this, event);")
        txtRujukan.Text = Trim(Request("strBarcode"))
        lblnokenderaan.Text = Trim(Request("no_kenderaan"))
        Kod_Agen.Value = Trim(Request("Kod_Agen"))
        Urusan.Value = Trim(Request("urusan"))
        Kod_Jenis_Urusan.Value = Trim(Request("Kod_Jenis_Urusan"))

        ' end coded

        'view label for type of charge

        Label1.Text = "Pembayaran Caj Borang SKPI - PNK SRI MUARA"
        ' Label1.Text = "Pembayaran Caj Borang SKPI/SKPE - LKIM"

        ' untuk view file untuk cetak resit

        If Trim(Urusan.Value) = "I" Then

            filetransfer = "cetakResit1B.aspx"

        ElseIf Trim(Urusan.Value) = "E" Then

            filetransfer = "cetakResit1E1.aspx"

        End If


        'End If

        'SQLReader.Close()
        'SQLReader = Nothing

        'end coded

        'checking for print status

        'Dim sqlText1 As String = ""

        'If Trim(Urusan.Value) = "I" Then
        '    sqlText1 = "SELECT print_status from no_siri_resit_nekad where No_barcode = '" & Trim(Request("strBarcode")) & "'"
        'Else
        '    sqlText1 = "SELECT print_status from no_siri_resit_nekad_eksport where No_barcode = '" & Trim(Request("strBarcode")) & "'"
        'End If

        'SQLReader = opClass.DataReader(sqlText1)

        'SQLReader.Read()

        'If Not SQLReader.HasRows Then
        '    print_status.Value = "N"
        'Else
        '    print_status.Value = "Y"
        'End If

        'SQLReader.Close()
        'SQLReader = Nothing

        ' end coded

        '********* to view information for Caj Borang SKPI ****************************
        Dim countforskpi As Integer = 0


        Dim sqlBorang As String = "SELECT count(*) as countforskpi From " & Trim(tabletitle1) & " " _
       & " where status='A' and No_barcode = '" & Trim(Request("strBarcode")) & "'"
        SQLReader = opClass.DataReader(sqlBorang)

        If SQLReader.HasRows Then

            SQLReader.Read()
            countforskpi = (SQLReader("countforskpi"))

        End If

        SQLReader.Close()
        SQLReader = Nothing

        'shah edit for caj gst dan pelarasan
        Dim chargeBorang As Decimal
        Dim viewborang As String = ""
        Dim gst As Decimal = 0
        Dim gst1 As Decimal = 0
        Dim cajboranggst As Decimal = 0

        Dim pelarasangst As String
        Dim panjanggst As String
        Dim jumpelarasangst As Decimal
        Dim descpelarasangst As String = "0.00"
        Dim jumcajslpspelarasangst As Decimal

        Dim rstBorang As String = "SELECT Borang FROM JENIS_URUSAN where Kod_Urusan='" & Trim(Request("Kod_Jenis_Urusan")) & "'"
        SQLReader = opClass.DataReader(rstBorang)


        If SQLReader.HasRows Then

            SQLReader.Read()
            chargeBorang = ((countforskpi) * Trim(SQLReader("Borang")))
            gst1 = chargeBorang * 0.0
            gst = Math.Round(gst1, 2)
            cajboranggst = chargeBorang + gst

            '--pelarasan gst
            pelarasangst = cajboranggst

            '--check berapa bil no lepas decimal
            Dim decimalSeparatorPosition As Integer = pelarasangst.IndexOf("."c)
            Dim afterDecimalSeparator As Integer = 0

            If decimalSeparatorPosition > -1 Then
                afterDecimalSeparator = pelarasangst.Substring(decimalSeparatorPosition + 1).Length
            End If
            '--end of check berapa bil no lepas decimal

            If afterDecimalSeparator > 1 Then
                panjanggst = pelarasangst.Length - 1
                pelarasangst = pelarasangst.Substring(panjanggst, 1)
                If pelarasangst = 1 Then
                    jumpelarasangst = 0.01
                    descpelarasangst = "-0.01"
                    jumcajslpspelarasangst = cajboranggst - jumpelarasangst
                ElseIf pelarasangst = 2 Then
                    jumpelarasangst = 0.02
                    descpelarasangst = "-0.02"
                    jumcajslpspelarasangst = cajboranggst - jumpelarasangst
                ElseIf pelarasangst = 3 Then
                    jumpelarasangst = 0.02
                    descpelarasangst = "+0.02"
                    jumcajslpspelarasangst = cajboranggst + jumpelarasangst
                ElseIf pelarasangst = 4 Then
                    jumpelarasangst = 0.01
                    descpelarasangst = "+0.01"
                    jumcajslpspelarasangst = cajboranggst + jumpelarasangst
                ElseIf pelarasangst = 5 Then
                    jumpelarasangst = 0.0
                    descpelarasangst = "0.00"
                    jumcajslpspelarasangst = cajboranggst + jumpelarasangst
                ElseIf pelarasangst = 6 Then
                    jumpelarasangst = 0.01
                    descpelarasangst = "-0.01"
                    jumcajslpspelarasangst = cajboranggst - jumpelarasangst
                ElseIf pelarasangst = 7 Then
                    jumpelarasangst = 0.02
                    descpelarasangst = "-0.02"
                    jumcajslpspelarasangst = cajboranggst - jumpelarasangst
                ElseIf pelarasangst = 8 Then
                    jumpelarasangst = 0.02
                    descpelarasangst = "+0.02"
                    jumcajslpspelarasangst = cajboranggst + jumpelarasangst
                ElseIf pelarasangst = 9 Then
                    jumpelarasangst = 0.01
                    descpelarasangst = "+0.01"
                    jumcajslpspelarasangst = cajboranggst + jumpelarasangst

                End If

            Else
                jumpelarasangst = 0.0
                descpelarasangst = "0.00"
                jumcajslpspelarasangst = cajboranggst - jumpelarasangst
            End If

        End If

        SQLReader.Close()
        SQLReader = Nothing

        'viewborang = "Caj Pengisytiharan (Borang SKPI) - CFC" & "`" & CDec(chargeBorang) & "`" & "CFC" & "`" & "PENGISYTIHARAN" & "~"
        'viewborang = "Caj Pengisytiharan (Borang SKPI) - PNK SRI MUARA" & "`" & CDec(chargeBorang) & "`" & "PNK SRI MUARA" & "`" & "PENGISYTIHARAN" & "~"
        viewborang = "Caj Pengisytiharan (Borang SKPI) - PNK SRI MUARA" & "`" & CDec(chargeBorang) & "`" & CDec(gst) & "`" & CDec(cajboranggst) & "`" & (descpelarasangst) & "`" & CDec(jumcajslpspelarasangst) & "`" & "PNK SRI MUARA" & "`" & "PENGISYTIHARAN" & "~"
        'end of shah edit for caj gst dan pelarasan

        Dim viewborangpermit As String = ""

        dataVal1 = viewborang
        arrayVal.Value = dataVal1

        'checking for payment

        Dim sqlBorang1 As String = ""
        If Trim(Urusan.Value) = "I" Then
            sqlBorang1 = "select no_barcode from pembayaran_caj_SKPI where No_barcode = '" & Trim(Request("strBarcode")) & "'"
        Else
            sqlBorang1 = "select no_barcode from pembayaran_caj_SKPE where No_barcode = '" & Trim(Request("strBarcode")) & "'"
        End If

        SQLReader = opClass.DataReader(sqlBorang1)

        If Not SQLReader.HasRows Then

            lblStatusPembayaran.Text = "Belum Jelas"
            cmdResit.Disabled = True
            Button7.Disabled = True

        Else

            If Request("cara_pembayaran") = "CEK/TUNAI" Then

                id_tunai.Attributes.Add("style", "DISPLAY:Block")
                id_cek.Attributes.Add("style", "DISPLAY:Block")
                itemTunai.Text = CDec(Trim(Request("itemTunai")))
                itemCek.Text = CDec(Trim(Request("itemCek")))

            End If

            lblStatusPembayaran.Text = "Jelas"
            cmdBayar.Enabled = False
            cmdResit.Disabled = False
            Button7.Disabled = False
            itemCek.ReadOnly = True
            itemTunai.ReadOnly = True
            txtCek.ReadOnly = True
            Button3.Disabled = False

        End If

        ' end coded

        SQLReader.Close()
        SQLReader = Nothing

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

    Protected Sub BAYAR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBayar.Click

        opClass = New SQLOperation()
        opClass.dbConnection()
        opClass1 = New SQLOperation()
        opClass1.dbConnection()

        If Trim(sender.Id) = "cmdBayar" Then

            ' checking selection for cara pembayaran

            If Trim(cara_pembayaran.SelectedValue) = "0" Then

                Response.Write("<script language = javascript>alert('Sila pilih cara untuk pembayaran.');self.location.href='pembayaranNewB.aspx?Kod_Agen=" & Trim(Kod_Agen.Value) & "&no_kenderaan= " & Trim(lblnokenderaan.Text) & "&urusan=" & Trim(Urusan.Value) & "&Kod_Jenis_Urusan=" & Trim(Kod_Jenis_Urusan.Value) & "&strBarcode=" & Trim(txtRujukan.Text) & "';</script>")
                Response.End()

            End If

            ' end coded

            Dim strValue = arrayVal.Value
            Dim i As Integer
            Dim rowArray = strValue.Split("~")

            ' view invois number from table
            Dim no_invois As String
            Dim intInvois As String

            If Trim(Urusan.Value) = "I" Then
                intInvois = "select no_invois from no_invois where no_barcode='" & Trim(txtRujukan.Text) & "'"
            Else
                intInvois = "select no_invois from no_invois_eksport where no_barcode='" & Trim(txtRujukan.Text) & "'"
            End If

            SQLReader = opClass.DataReader(intInvois)

            SQLReader.Read()

            no_invois = SQLReader("no_invois")

            SQLReader.Close()
            SQLReader = Nothing


            ' to insert the data into the specific table

            Dim ikanvalue As Boolean = False
            Dim bil_item As Integer
            Dim no_cek As String = ""
            Dim arrBayarCol() As String = rowArray(i).ToString().Split("`")


            If Trim(Urusan.Value) = "I" Then
                Dim intbil As String = "select bil_item from item_caj where no_barcode='" & Trim(txtRujukan.Text) & "' order by bil_item desc"
                SQLReader = opClass.DataReader(intbil)
            Else
                Dim intbil As String = "select bil_item from item_caj_eksport where no_barcode='" & Trim(txtRujukan.Text) & "' order by bil_item desc"
                SQLReader = opClass.DataReader(intbil)
            End If



            SQLReader.Read()
            If SQLReader.HasRows Then
                bil_item = SQLReader("bil_item") + 1
            Else
                bil_item = 1
            End If

            ' checking for total overall

            If Trim(cara_pembayaran.SelectedValue) = "CEK/TUNAI" Then

                If txtCek.Text = "" Or itemTunai.Text = "" Or itemCek.Text = "" Then

                    Response.Write("<script language = javascript>alert('Sila masukkan data untuk nilai tunai, nilai cek dan juga nombor cek terlebih dahulu.');self.location.href='pembayaranNewB.aspx?Kod_Agen=" & Trim(Kod_Agen.Value) & "&no_kenderaan= " & Trim(lblnokenderaan.Text) & "&urusan=" & Trim(Urusan.Value) & "&Kod_Jenis_Urusan=" & Trim(Kod_Jenis_Urusan.Value) & "&strBarcode=" & Trim(txtRujukan.Text) & "';</script>")
                    Response.End()

                End If


                If (CDec(itemTunai.Text) + CDec(itemCek.Text) <> CDec(arrBayarCol(5))) Then

                    Response.Write("<script language = javascript>alert('Jumlah tunai dan cek adalah tidak sama. Sila semak.');self.location.href='pembayaranNewB.aspx?Kod_Agen=" & Trim(Kod_Agen.Value) & "&no_kenderaan= " & Trim(lblnokenderaan.Text) & "&urusan=" & Trim(Urusan.Value) & "&Kod_Jenis_Urusan=" & Trim(Kod_Jenis_Urusan.Value) & "&strBarcode=" & Trim(txtRujukan.Text) & "';</script>")
                    Response.End()

                End If

            End If

            ' end coded

            Dim sqlText1 As String = ""
            Dim sqlText2 As String = ""


            If Trim(cara_pembayaran.SelectedValue) = "CEK" Or Trim(cara_pembayaran.SelectedValue) = "TUNAI" Then

                If Trim(cara_pembayaran.SelectedValue) = "CEK" Then

                    no_cek = txtCek.Text

                ElseIf Trim(cara_pembayaran.SelectedValue) = "TUNAI" Then

                    no_cek = "Tiada"

                End If





                'edited by shah for gst
                If Trim(Urusan.Value) = "I" Then

                    sqlText1 = "INSERT INTO [W-ICCS].[dbo].[ITEM_CAJ]" _
                    & " ([No_Barcode], [Bil_Item], [Kod_Service_Caj], [Nilai_Caj],[Gst],[Nilai_Caj_Gst],[Pelarasan_Gst],[Nilai_Caj_Pelarasan_Gst],[Cara_Pembayaran],[No_Cek],[Dicaj_Oleh],[Tempat_Isytihar],[Nama_Pegawai],[No_Pegawai],site_code)" _
                    & " VALUES('" & Trim(txtRujukan.Text) & "','" & bil_item & "','" & arrBayarCol(0) & "','" & CDec(arrBayarCol(1)) & "','" & CDec(arrBayarCol(2)) & "','" & CDec(arrBayarCol(3)) & "','" & CDec(arrBayarCol(4)) & "','" & CDec(arrBayarCol(5)) & "','" & Trim(cara_pembayaran.SelectedValue) & "','" & no_cek & "','" & arrBayarCol(6) & "','" & arrBayarCol(7) & "','" & Session("namaPegawai") & "','" & Session("id_pegawai") & "','" & Right(Trim(txtRujukan.Text), 3) & "')"

                Else

                    sqlText1 = "INSERT INTO [W-ICCS].[dbo].[ITEM_CAJ_EKSPORT]" _
                    & " ([No_Barcode], [Bil_Item], [Kod_Service_Caj], [Nilai_Caj],[Gst],[Nilai_Caj_Gst],[Pelarasan_Gst],[Nilai_Caj_Pelarasan_Gst],[Cara_Pembayaran],[No_Cek],[Dicaj_Oleh],[Tempat_Isytihar],[Nama_Pegawai],[No_Pegawai],site_code)" _
                    & " VALUES('" & Trim(txtRujukan.Text) & "','" & bil_item & "','" & arrBayarCol(0) & "','" & CDec(arrBayarCol(1)) & "','" & CDec(arrBayarCol(2)) & "','" & CDec(arrBayarCol(3)) & "','" & CDec(arrBayarCol(4)) & "','" & CDec(arrBayarCol(5)) & "','" & Trim(cara_pembayaran.SelectedValue) & "','" & no_cek & "','" & arrBayarCol(6) & "','" & arrBayarCol(7) & "','" & Session("namaPegawai") & "','" & Session("id_pegawai") & "','" & Right(Trim(txtRujukan.Text), 3) & "')"

                End If


                opClass1.InsertData(sqlText1)


            ElseIf Trim(cara_pembayaran.SelectedValue) = "CEK/TUNAI" Then

                If Trim(Urusan.Value) = "I" Then

                    'sqlText1 = "INSERT INTO [W-ICCS].[dbo].[ITEM_CAJ]" _
                    '& " ([No_Barcode], [Bil_Item], [Kod_Service_Caj], [Nilai_Caj],[Cara_Pembayaran],[No_Cek],[Dicaj_Oleh],[Tempat_Isytihar],[Nama_Pegawai],[No_Pegawai],site_code)" _
                    '& " VALUES('" & Trim(txtRujukan.Text) & "','" & bil_item & "','" & arrBayarCol(0) & "','" & CDec(itemCek.Text) & "','CEK','" & txtCek.Text & "','" & arrBayarCol(2) & "','" & arrBayarCol(3) & "','" & Session("namaPegawai") & "','" & Session("id_pegawai") & "','" & Right(Trim(txtRujukan.Text), 3) & "')"

                    sqlText1 = "INSERT INTO [W-ICCS].[dbo].[ITEM_CAJ]" _
                    & " ([No_Barcode], [Bil_Item], [Kod_Service_Caj], [Nilai_Caj], [Gst],[Nilai_Caj_Gst],[Pelarasan_Gst],[Nilai_Caj_Pelarasan_Gst],[Cara_Pembayaran],[No_Cek],[Dicaj_Oleh],[Tempat_Isytihar],[Nama_Pegawai],[No_Pegawai],site_code)" _
                    & " VALUES('" & Trim(txtRujukan.Text) & "','" & bil_item & "','" & arrBayarCol(0) & "','" & CDec(arrBayarCol(1)) & "','" & CDec(arrBayarCol(2)) & "','" & CDec(arrBayarCol(3)) & "','" & CDec(arrBayarCol(4)) & "','" & CDec(itemCek.Text) & "','CEK','" & txtCek.Text & "','" & arrBayarCol(6) & "','" & arrBayarCol(7) & "','" & Session("namaPegawai") & "','" & Session("id_pegawai") & "','" & Right(Trim(txtRujukan.Text), 3) & "')"

                Else

                    'sqlText1 = "INSERT INTO [W-ICCS].[dbo].[ITEM_CAJ_EKSPORT]" _
                    '& " ([No_Barcode], [Bil_Item], [Kod_Service_Caj], [Nilai_Caj],[Cara_Pembayaran],[No_Cek],[Dicaj_Oleh],[Tempat_Isytihar],[Nama_Pegawai],[No_Pegawai],site_code)" _
                    '& " VALUES('" & Trim(txtRujukan.Text) & "','" & bil_item & "','" & arrBayarCol(0) & "','" & CDec(itemCek.Text) & "','CEK','" & txtCek.Text & "','" & arrBayarCol(2) & "','" & arrBayarCol(3) & "','" & Session("namaPegawai") & "','" & Session("id_pegawai") & "','" & Right(Trim(txtRujukan.Text), 3) & "')"

                    sqlText1 = "INSERT INTO [W-ICCS].[dbo].[ITEM_CAJ_EKSPORT]" _
                   & " ([No_Barcode], [Bil_Item], [Kod_Service_Caj], [Nilai_Caj], [Gst],[Nilai_Caj_Gst],[Pelarasan_Gst],[Nilai_Caj_Pelarasan_Gst],[Cara_Pembayaran],[No_Cek],[Dicaj_Oleh],[Tempat_Isytihar],[Nama_Pegawai],[No_Pegawai],site_code)" _
                   & " VALUES('" & Trim(txtRujukan.Text) & "','" & bil_item & "','" & arrBayarCol(0) & "','" & CDec(arrBayarCol(1)) & "','" & CDec(arrBayarCol(2)) & "','" & CDec(arrBayarCol(3)) & "','" & CDec(arrBayarCol(4)) & "','" & CDec(itemCek.Text) & "','CEK','" & txtCek.Text & "','" & arrBayarCol(6) & "','" & arrBayarCol(7) & "','" & Session("namaPegawai") & "','" & Session("id_pegawai") & "','" & Right(Trim(txtRujukan.Text), 3) & "')"

                End If

                opClass1.InsertData(sqlText1)

                bil_item = bil_item + 1


                If Trim(Urusan.Value) = "I" Then

                    'sqlText2 = "INSERT INTO [W-ICCS].[dbo].[ITEM_CAJ]" _
                    '& " ([No_Barcode], [Bil_Item], [Kod_Service_Caj], [Nilai_Caj],[Cara_Pembayaran],[No_Cek],[Dicaj_Oleh],[Tempat_Isytihar],[Nama_Pegawai],[No_Pegawai],site_code)" _
                    '& " VALUES('" & Trim(txtRujukan.Text) & "','" & bil_item & "','" & arrBayarCol(0) & "','" & CDec(itemTunai.Text) & "','TUNAI','Tiada','" & arrBayarCol(2) & "','" & arrBayarCol(3) & "','" & Session("namaPegawai") & "','" & Session("id_pegawai") & "','" & Right(Trim(txtRujukan.Text), 3) & "')"

                    sqlText2 = "INSERT INTO [W-ICCS].[dbo].[ITEM_CAJ]" _
                    & " ([No_Barcode], [Bil_Item], [Kod_Service_Caj], [Nilai_Caj], [Gst],[Nilai_Caj_Gst],[Pelarasan_Gst],[Nilai_Caj_Pelarasan_Gst],[Cara_Pembayaran],[No_Cek],[Dicaj_Oleh],[Tempat_Isytihar],[Nama_Pegawai],[No_Pegawai],site_code)" _
                    & " VALUES('" & Trim(txtRujukan.Text) & "','" & bil_item & "','" & arrBayarCol(0) & "','" & CDec(arrBayarCol(1)) & "','" & CDec(arrBayarCol(2)) & "','" & CDec(arrBayarCol(3)) & "','" & CDec(arrBayarCol(4)) & "','" & CDec(itemTunai.Text) & "','TUNAI','Tiada','" & arrBayarCol(6) & "','" & arrBayarCol(7) & "','" & Session("namaPegawai") & "','" & Session("id_pegawai") & "','" & Right(Trim(txtRujukan.Text), 3) & "')"


                Else

                    'sqlText2 = "INSERT INTO [W-ICCS].[dbo].[ITEM_CAJ_EKSPORT]" _
                    '& " ([No_Barcode], [Bil_Item], [Kod_Service_Caj], [Nilai_Caj],[Cara_Pembayaran],[No_Cek],[Dicaj_Oleh],[Tempat_Isytihar],[Nama_Pegawai],[No_Pegawai],site_code)" _
                    '& " VALUES('" & Trim(txtRujukan.Text) & "','" & bil_item & "','" & arrBayarCol(0) & "','" & CDec(itemTunai.Text) & "','TUNAI','Tiada','" & arrBayarCol(2) & "','" & arrBayarCol(3) & "','" & Session("namaPegawai") & "','" & Session("id_pegawai") & "','" & Right(Trim(txtRujukan.Text), 3) & "')"

                    sqlText2 = "INSERT INTO [W-ICCS].[dbo].[ITEM_CAJ_EKSPORT]" _
                    & " ([No_Barcode], [Bil_Item], [Kod_Service_Caj], [Nilai_Caj], [Gst],[Nilai_Caj_Gst],[Pelarasan_Gst],[Nilai_Caj_Pelarasan_Gst],[Cara_Pembayaran],[No_Cek],[Dicaj_Oleh],[Tempat_Isytihar],[Nama_Pegawai],[No_Pegawai],site_code)" _
                    & " VALUES('" & Trim(txtRujukan.Text) & "','" & bil_item & "','" & arrBayarCol(0) & "','" & CDec(arrBayarCol(1)) & "','" & CDec(arrBayarCol(2)) & "','" & CDec(arrBayarCol(3)) & "','" & CDec(arrBayarCol(4)) & "','" & CDec(itemTunai.Text) & "','TUNAI','Tiada','" & arrBayarCol(6) & "','" & arrBayarCol(7) & "','" & Session("namaPegawai") & "','" & Session("id_pegawai") & "','" & Right(Trim(txtRujukan.Text), 3) & "')"


                End If
                'end of edited by shah for gst
                opClass1.InsertData(sqlText2)

            End If

            Dim strBayar1 As String


            If Trim(Urusan.Value) = "I" Then

                strBayar1 = "insert into pembayaran_caj_SKPI(no_barcode,no_invois,siri_module,kod_agen,print_status,site_code) " _
                & "values('" & Trim(txtRujukan.Text) & "','" & Trim(no_invois) & "','individual_receipt','" & Trim(Kod_Agen.Value) & "','0','" & Right(Trim(txtRujukan.Text), 3) & "')"
            Else

                strBayar1 = "insert into pembayaran_caj_SKPE(no_barcode,no_invois,siri_module,kod_agen,print_status,site_code) " _
                & "values('" & Trim(txtRujukan.Text) & "','" & Trim(no_invois) & "','individual_receipt','" & Trim(Kod_Agen.Value) & "','0','" & Right(Trim(txtRujukan.Text), 3) & "')"

            End If

            opClass1.InsertData(strBayar1)


            'for export update Sistem Q as Bayar

            If Trim(Urusan.Value) = "E" Then

                Dim updateq = "update sistem_q set status='Bayar' where no_barcode='" & Trim(txtRujukan.Text) & "'"
                opClass1.InsertData(updateq)

            End If
            ' end coded

            ' insert for status transaction

            Dim sqlupdate As String = "INSERT INTO IsyProgressStatus_Front([no_rujukan],[no_barcode], [proses], [dateEnter], [entryBy])" & _
            "VALUES('','" & Trim(txtRujukan.Text) & "','PEMBAYARAN CAJ BORANG SKPI',getdate(),'" & Session("username") & "')"
            opClass1.InsertData(sqlupdate)

            ' end coded

            Response.Write("<script language = javascript>alert('Maklumat pembayaran untuk caj SKPI/SKPE telah disimpan.');self.location.href='pembayaranNewB.aspx?no_cek=" & no_cek & "&itemTunai=" & itemTunai.Text & "&itemCek=" & itemCek.Text & "&cara_pembayaran=" & Trim(cara_pembayaran.SelectedValue) & "&Kod_Agen=" & Trim(Kod_Agen.Value) & "&no_kenderaan= " & Trim(lblnokenderaan.Text) & "&urusan=" & Trim(Urusan.Value) & "&Kod_Jenis_Urusan=" & Trim(Kod_Jenis_Urusan.Value) & "&strBarcode=" & Trim(txtRujukan.Text) & "';</script>")
            Response.End()

        End If


        opClass.dbConnection_Close()
        opClass1.dbConnection_Close()


    End Sub


    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        opClass.dbConnection_Close()
    End Sub

End Class
