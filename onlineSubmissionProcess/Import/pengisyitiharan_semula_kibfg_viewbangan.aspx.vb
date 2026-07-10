
Partial Class Import_pengisyitiharan_semula_kibfg_view
    Inherits System.Web.UI.Page
#Region "Variables Declaration Area"
    Protected opClass As SQLOperation
    'Protected strKodKenderaan As String
    Protected strJenisUrusan As String
    Protected namaJenisUrusan As String = ""
    Protected strKodKenderaan As String = ""
    Protected strStatus As String
    Protected OnlineSendBy As String
    Public jsReader As System.Data.SqlClient.SqlDataReader

#End Region



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5))

        Try
            If Session("username").ToString() Is Nothing Then

                Session.Clear()
                Dim popupScript As String = "<script language='javascript'>" & _
                "alert('Sessi penggunaan anda telah tamat !!!');parent.location.href='../../index.aspx';" & _
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



        opClass = New SQLOperation()
        opClass.dbConnection()

        opClass.Load_CajIkan_KIBFG()
        opClass.Load_CajIkanSyarikat()
        strJenisUrusan = JenisUrusan.SelectedValue


        'Dim strBarcode As String = Request.QueryString("Barcode")
        Dim sqlText As String = ""

        If Not Page.IsPostBack Then

            strJenisUrusan = Request("urusan")
            sqlText = "select " & _
                      "case when datepart(MM,getdate())<10 then '0'+ cast(datepart(MM,getdate()) as varchar(2)) " & _
                      "else cast(datepart(MM,getdate()) as varchar(2))" & _
                      "end +'/'+ case when datepart(DD,getdate())<10 then '0'+ cast(datepart(DD,getdate()) as varchar(2)) " & _
                      "else cast(datepart(DD,getdate()) as varchar(2))" & _
                      "end +'/'+ cast(datepart(YYYY,getdate()) as varchar(5))"

            serverDate.Value = opClass.SingleFieldResults(sqlText)
            Barcodes.Text = Request("barcode")

            Dim sqlRead As System.Data.SqlClient.SqlDataReader

            'Query TMP_PENDAFTARAN PINTU
            sqlText = "SELECT PENDAFTARAN_PINTU.No_Kenderaan, AGEN_PENGANGKUTAN.Nama_Agen_Pengangkutan, PENDAFTARAN_PINTU.Kod_Jenis_Urusan, " & _
                      "PENDAFTARAN_PINTU.[Tmp_Barcode],Pendaftaran_Pintu.Caj_Masuk,PENGISYTIHARAN_I_KIBFG.Cara_Pengangkutan,JENIS_URUSAN.NAMA_URUSAN FROM  PENDAFTARAN_PINTU " & _
                      "INNER JOIN JENIS_URUSAN ON Pendaftaran_Pintu.Kod_Jenis_Urusan = JENIS_URUSAN.Kod_Urusan " & _
                      "INNER JOIN AGEN_PENGANGKUTAN ON PENDAFTARAN_PINTU.Kod_Agen_Pengangkutan = AGEN_PENGANGKUTAN.Kod_Agen_Pengangkutan " & _
                      "INNER JOIN PENGISYTIHARAN_I_KIBFG ON PENGISYTIHARAN_I_KIBFG.No_barcode = Pendaftaran_Pintu.Nombor_Barcode " & _
                      "WHERE PENDAFTARAN_PINTU.[Nombor_Barcode]='" & Barcodes.Text & "'"
            'Response.Write(sqlText)

            sqlRead = opClass.DataReader(sqlText)
            If sqlRead.HasRows Then
                sqlRead.Read()
                noKenderaan.Text = sqlRead.GetValue(0)
                strJenisUrusan = sqlRead.GetValue(2)
                JenisUrusanLama.Value = sqlRead.GetValue(6)
                NamaAgen.Text = sqlRead.GetValue(1)
                'NamaPemandu.Text = sqlRead.GetValue(3)
                rujukan.Text = sqlRead.GetValue(3)
                CajMasuk.Value = sqlRead.GetValue(4)
                strKodKenderaan = sqlRead.GetValue(5)
            End If
            sqlRead.Close()
            sqlRead = Nothing


            'Query PENGISYITIHARAN_I
            Dim strVal As String = ""

            sqlText = "SELECT DISTINCT RTRIM(PENGISYTIHARAN_I_KIBFG.Kod_Pengimport) + '|' + RTRIM(PENGIMPORT.No_Lesen) + '|' + " & _
                      "case when DAY(LESEN.Tarikh_Tamat) <10 then '0'+ cast(DAY(LESEN.Tarikh_Tamat) as varchar(10)) else cast(DAY(LESEN.Tarikh_Tamat) as varchar(10)) end " & _
                      "+ '/'+ case when MONTH(LESEN.Tarikh_Tamat) < 10 then '0'+cast(month(lesen.tarikh_tamat) as varchar(1)) else cast(month(lesen.tarikh_tamat) as varchar(2)) end " & _
                      "+ '/' + CAST(YEAR(LESEN.Tarikh_Tamat) as nvarchar(4)) " & _
                      "+ '`' + PENGIMPORT.Nama_Syarikat_Import + '`' + PENGISYTIHARAN_I_KIBFG.Sumber_Bekalan + '`' + PENGISYTIHARAN_I_KIBFG.Kod_PPI + '`' + PENGISYTIHARAN_I_KIBFG.Kod_Pengeksport " & _
                      "+ '`' + PENGEKSPORT_THAILAND.Nama_Pengeksport + '`'+ PENGISYTIHARAN_I_KIBFG.Status +'~'" & _
                      " AS data, PENGISYTIHARAN_I_KIBFG.STATUS, PENGISYTIHARAN_I_KIBFG.KOD_URUSAN,JENIS_URUSAN.NAMA_URUSAN,PENGISYTIHARAN_I_KIBFG.ONLINESEND_BY, PENGISYTIHARAN_I_KIBFG.Nama_Pemandu, PENGISYTIHARAN_I_KIBFG.KOD_PENGIMPORT,PENGISYTIHARAN_I_KIBFG.PETI_BIRU_KECIL,PENGISYTIHARAN_I_KIBFG.PETI_BIRU_BESAR " & _
                      "FROM PENGISYTIHARAN_I_KIBFG INNER JOIN " & _
                      "PENGIMPORT ON PENGISYTIHARAN_I_KIBFG.Kod_Pengimport = PENGIMPORT.Kod_Pengimport INNER JOIN " & _
                      "LESEN ON PENGIMPORT.No_Lesen = LESEN.No_Lesen INNER JOIN " & _
                      "PENGEKSPORT_THAILAND ON PENGISYTIHARAN_I_KIBFG.Kod_Pengeksport = PENGEKSPORT_THAILAND.Kod_Pengeksport INNER JOIN " & _
                      "JENIS_URUSAN ON JENIS_URUSAN.KOD_URUSAN=PENGISYTIHARAN_I_KIBFG.KOD_URUSAN " & _
                      "Where  PENGISYTIHARAN_I_KIBFG.NO_BARCODE ='" & Barcodes.Text & "'"
            'EDIT BY ZURAINI


            'Response.Write(sqlText)
            'Response.End()
            Dim currimporter = ""
            sqlRead = opClass.DataReader(sqlText)
            If sqlRead.HasRows Then
                Do While sqlRead.Read()
                    If sqlRead.GetValue(6) <> currimporter Then
                        strVal = strVal & sqlRead.GetValue(0)
                        strStatus = sqlRead.GetValue(1)
                        strJenisUrusan = sqlRead.GetValue(2)
                        namaJenisUrusan = sqlRead.GetValue(3)
                        OnlineSendBy = sqlRead.GetValue(4)
                        OnlineSend_By.Value = OnlineSendBy
                        NamaPemandu.Text = sqlRead.GetValue(5)
                        currimporter = sqlRead.GetValue(6)
                        PetiBiruKecil.Text = sqlRead.GetValue(7)
                        PetiBiruBesar.Text = sqlRead.GetValue(8)
                        'Response.Write(strStatus)
                    End If
                Loop
            End If
            sqlRead.Close()
            sqlRead = Nothing
            arrayVal.Value = strVal
            status.Value = strStatus


            If status.Value = "" Then
                rujukan.Text = opClass.GenerateBarcode()
            End If



            'Query ITEM_ISYTIHAR_I_KIBFG

            strVal = ""
            'sqlText = "SELECT PENGISYTIHARAN_I_KIBFG.Kod_Pengimport + '`' + JENIS_IKAN.Kod_BKH + '`' + JENIS_IKAN.Nama_BKH + '`' + ITEM_ISYTIHAR_I.Kod_Ikan + '`' + ITEM_ISYTIHAR_I.Destinasi_Pasar " & _
            '          "+ '`' + CAST(ITEM_ISYTIHAR_I.PetiKecil AS varchar(20)) + '`' + CAST(ITEM_ISYTIHAR_I.KuantitiKecil AS varchar(20)) " & _
            '          "+ '`' + CAST(ITEM_ISYTIHAR_I.PetiBesar AS varchar(20)) + '`' + CAST(ITEM_ISYTIHAR_I.KuantitiBesar AS varchar(20)) " & _
            '          "+ '`' + CAST(ITEM_ISYTIHAR_I.Pek AS varchar(20)) + '`' + CAST(ITEM_ISYTIHAR_I.Ekor AS varchar(20)) " & _
            '          "+ '`' + CAST(ITEM_ISYTIHAR_I.Nilai AS varchar(20)) + '`' + DESTINASI_PASAR.Nama_Pasar + '`' + CAST(ISNULL(ALL_KADAR_CAJ.Kadar_Peti_Kecil,0) as varchar(20)) + '`' + Cast(ISNULL(ALL_KADAR_CAJ.Kadar_Peti_Besar,0) as Varchar(20)) + '`' + Cast(ISNULL(ALL_KADAR_CAJ.Kadar_Ekor,0) as Varchar(20)) + '`' + Cast(ISNULL(ALL_KADAR_CAJ.Kadar_Kuantiti,0) as varchar(20)) + '`' + Cast(ISNULL(ITEM_ISYTIHAR_I.Caj_Ikan_ID,0) as varchar(20)) +'`'+ Cast(ISNULL(ITEM_ISYTIHAR_I.Caj,0) as varchar(100)) + '~' AS Data " & _
            '          "FROM ITEM_ISYTIHAR_I_KIBFG INNER JOIN " & _
            '          "PENGISYTIHARAN_I_KIBFG ON ITEM_ISYTIHAR_I.No_SKPI = PENGISYTIHARAN_I_KIBFG.No_SKPI " & _
            '          "INNER JOIN JENIS_IKAN ON ITEM_ISYTIHAR_I.Kod_Ikan = JENIS_IKAN.Kod_Ikan " & _
            '          "INNER JOIN DESTINASI_PASAR ON ITEM_ISYTIHAR_I.Destinasi_Pasar = DESTINASI_PASAR.Kod_Pasar " & _
            '          "LEFT OUTER JOIN ALL_KADAR_CAJ ON ALL_KADAR_CAJ.ID = ITEM_ISYTIHAR_I.Caj_Ikan_ID " & _
            '          "WHERE (ITEM_ISYTIHAR_I.Nombor_Barcode = '" & Barcodes.Text & "')"
            ''Response.Write("<p>" & sqlText)
            'sqlRead = opClass.DataReader(sqlText)
            'If sqlRead.HasRows Then
            '    Do While sqlRead.Read()
            '        strVal = strVal & sqlRead.GetValue(0)
            '    Loop
            'End If
            'sqlRead.Close()
            'sqlRead = Nothing
            ''Response.Write(strVal)
            'arrayFishVal.Value = strVal
            ''TextBox1.Text = strVal

            'NamaAgen.Text = Session("namaAgen")
            'strJenisUrusan = Request("urusan")

        Else
            namaJenisUrusan = JenisUrusan.SelectedItem.Text
        End If 'End If PostBack


        ' added by zue

        Dim myHost As String
        Dim host As System.Net.IPHostEntry
        host = System.Net.Dns.GetHostEntry(Request.ServerVariables.Item("REMOTE_addr"))
        myHost = host.HostName

        Dim SQLReader As System.Data.SqlClient.SqlDataReader

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

        If PetiBiruKecil.Text = "" Then
            PetiBiruKecil.Text = "0"
        End If
        If PetiBiruBesar.Text = "" Then
            PetiBiruBesar.Text = "0"
        End If


        ' end coded


        ' Attach Javascript Operation To WebControls
        'txtNilai.Attributes.Add("onBlur", "calculateJumlah();")
        'txtPetiKecil.Attributes.Add("onBlur", "calculateTxtQtyKecil();calculateJumlah();")
        'txtKuantitiKecil.Attributes.Add("onBlur", "calculateJumlah();")
        'txtPetiBesar.Attributes.Add("onBlur", "calculateTxtQtyBesar();calculateJumlah();")
        'txtKuantitiBesar.Attributes.Add("onBlur", "calculateJumlah();")
        ''JenisUrusan.Attributes.Add("onChange", "verifyUrusan();")
        'Kod_BKH.Attributes.Add("onKeyPress", "return keyToUpperCase(this, event);")
        'Kod_BKH.Attributes.Add("onBlur", "showFilteredIkan();")
        searchKodImporter.Attributes.Add("onKeyPress", "return keyToUpperCase(this, event);")
        searchKodImporter.Attributes.Add("onBlur", "showFilteredImporter();")
        searchKodExporter.Attributes.Add("onKeyPress", "return keyToUpperCase(this, event);")
        searchKodExporter.Attributes.Add("onBlur", "showFilteredExporter();")

    End Sub

    Protected Sub cara_pengangkutan_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles cara_pengangkutan.PreRender
        If strKodKenderaan <> "" Then
            cara_pengangkutan.ClearSelection()
            cara_pengangkutan.Items.FindByValue(strKodKenderaan).Selected = True
        End If
    End Sub

    Protected Sub JenisUrusan_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles JenisUrusan.PreRender
        If strJenisUrusan <> "" Then
            JenisUrusan.ClearSelection()
            JenisUrusan.Items.FindByValue(strJenisUrusan).Selected = True
        End If
    End Sub

    Protected Sub SIMPAN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Simpan.Click

        'If Simpan.Page.IsPostBack Then
        If sender.id = "Simpan" Then

            'Response.Write("importer" & arrayVal.Value)
            'Response.Write("<br>fish item" & arrayFishVal.Value)
            'Response.End()
            Dim currentInvois As String
            Dim sqlText As String = ""
            ' If NamaPemandu.Text <> "" And arrayVal.Value <> "" And arrayFishVal.Value <> "" And Barcodes.Text <> "" Then
            If NamaPemandu.Text <> "" And arrayVal.Value <> "" And Barcodes.Text <> "" Then

                'verifying fish item declared by each importer whether exists or not
                '    If (opClass.VerifyItemIsytihar(arrayVal.Value, arrayFishVal.Value) = True) Then
                If (opClass.VerifyItemIsytiharKIBFG(arrayVal.Value) = True) Then
                    Dim m As Integer = 0
                    Dim strMy As String = ""
                    For m = 0 To opClass.ImporterErr.Count() - 1
                        Dim strKodImp As Object = opClass.ImporterErr(m).ToString()
                        Dim idxImp As Integer = opClass.vIsytiharImporter.IndexOf(strKodImp)
                        Dim strNameImp As String = opClass.vIsytiharImporterName(idxImp)
                        strMy = strMy & "\n - " & strNameImp
                    Next

                    Dim popupScript As String = "<script language='javascript'>" & _
                                               "alert('Maklumat Pengisytiharan Ikan Bagi \nPengimport Berikut Tidak Lengkap :\n" & strMy & "')" & _
                                               "</script>"

                    Response.Write(popupScript)
                Else

                    'Move all skpi yg dibatalkan ke ITEM_ISYTIHAR_I_KIBFG_BATAL
                    'sqlText = "INSERT INTO ITEM_ISYTIHAR_I_KIBFG_BATAL " & _
                    '          "SELECT ITEM_ISYTIHAR_I_KIBFG.Nombor_Barcode, ITEM_ISYTIHAR_I_KIBFG.No_SKPI, ITEM_ISYTIHAR_I_KIBFG.Bil_Item, ITEM_ISYTIHAR_I_KIBFG.Kod_Ikan, " & _
                    '          "ITEM_ISYTIHAR_I_KIBFG.Destinasi_Pasar, ITEM_ISYTIHAR_I_KIBFG.PetiKecil, ITEM_ISYTIHAR_I_KIBFG.KuantitiKecil, ITEM_ISYTIHAR_I_KIBFG.PetiBesar, " & _
                    '          "ITEM_ISYTIHAR_I_KIBFG.KuantitiBesar, ITEM_ISYTIHAR_I_KIBFG.Pek, ITEM_ISYTIHAR_I_KIBFG.Ekor, ITEM_ISYTIHAR_I_KIBFG.Nilai, ITEM_ISYTIHAR_I_KIBFG.Caj, " & _
                    '          "ITEM_ISYTIHAR_I_KIBFG.Site_Code, ITEM_ISYTIHAR_I_KIBFG.Caj_Ikan_Id " & _
                    '          "FROM ITEM_ISYTIHAR_I_KIBFG INNER JOIN " & _
                    '          "PENGISYTIHARAN_I_KIBFG ON ITEM_ISYTIHAR_I_KIBFG.No_SKPI = PENGISYTIHARAN_I_KIBFG.No_SKPI " & _
                    '                    "WHERE (PENGISYTIHARAN_I_KIBFG.No_Barcode = '" & Barcodes.Text & "')"
                    '' tutup kejap         "WHERE (PENGISYTIHARAN_I_KIBFG.No_Barcode = '" & Barcodes.Text & "') AND (PENGISYTIHARAN_I_KIBFG.Status = 'B')"
                    'opClass.InsertData(sqlText)

                    'Response.Write("ITEM_ISYTIHAR_I_KIBFG_BATAL= " & sqlText)


                    'Move all skpi yg dibatalkan ke PENGISYTIHARAN_I_KIBFG_BATAL
                    sqlText = "INSERT INTO PENGISYTIHARAN_I_KIBFG_BATAL " & _
                              "SELECT     No_Barcode, No_SKPI, Reference_no, No_Daftar, No_Kenderaan, Cara_Pengangkutan, Kod_Pengimport, Kod_Pengeksport, Tarikh_Isytihar, " & _
                              "Masa_Isytihar, Kod_PPI, TotalPetiKecil, TotalKuantitiKecil, TotalPetiBesar, TotalKuantitiBesar, TotalPek, TotalEkor, TotalNilai, TotalCajIkan, " & _
                              "Sumber_Bekalan, 'B', Nama_Pegawai, Transaction_Date, Nama_PemanduPindahan, No_KenderaanPindahan, Site_Code, OnlineSend_By," & _
                              "Kod_Urusan, Kod_CajIkan_ID, Nama_Pemandu FROM PENGISYTIHARAN_I_KIBFG " & _
                              "WHERE (No_Barcode = '" & Barcodes.Text & "')"
                    ' tutup kejap          "WHERE (No_Barcode = '" & Barcodes.Text & "') AND (Status = 'B')"
                    opClass.InsertData(sqlText)

                    'Response.Write("PENGISYTIHARAN_I_KIBFG_BATAL= " & sqlText)

                    'Delete Temporary ITEM_ISYTIHAR_I_KIBFG
                    'sqlText = "delete ITEM_ISYTIHAR_I_KIBFG from ITEM_ISYTIHAR_I_KIBFG " & _
                    '          "inner join PENGISYTIHARAN_I_KIBFG on ITEM_ISYTIHAR_I_KIBFG.no_skpi = PENGISYTIHARAN_I_KIBFG.no_skpi " & _
                    '          "where PENGISYTIHARAN_I_KIBFG.no_barcode='" & Barcodes.Text & "'"
                    ''tutup kejap "where PENGISYTIHARAN_I_KIBFG.no_barcode='" & Barcodes.Text & "' and PENGISYTIHARAN_I_KIBFG.status='B' "
                    ' opClass.InsertData(sqlText)

                    'If (opClass.ErrorSignal = True) Then
                    '    Response.Write("Error: " & sqlText)
                    'End If

                    'Delete PENGISYTIHARAN_I_KIBFG
                    '   sqlText = "delete from PENGISYTIHARAN_I_KIBFG where [No_Barcode]='" & Barcodes.Text & "' AND Status = 'B'"
                    sqlText = "delete from PENGISYTIHARAN_I_KIBFG where [No_Barcode]='" & Barcodes.Text & "'"
                    opClass.InsertData(sqlText)

                    'If (opClass.ErrorSignal = True) Then
                    ' Response.Write("Error:" & sqlText)
                    'End If


                    'If (opClass.ErrorSignal = True) Then
                    '    Response.Write("Error: line 330" & sqlText)
                    'End If

                    'Added by khamsiah on 1 september 2007
                    'To delete ITEM_ISYTIHAR_I_KIBFG when user click save button twice
                    'sqlText = "delete  from ITEM_ISYTIHAR_I_KIBFG where nombor_barcode='" + Barcodes.Text + "'" & _
                    '          " and no_skpi not in (select no_skpi from PENGISYTIHARAN_I_KIBFG where no_barcode='" + Barcodes.Text + "' )"
                    'opClass.InsertData(sqlText)

                    'If (opClass.ErrorSignal = True) Then
                    '    Response.Write("Error: line 340" & sqlText)
                    'End If

                    'Get Transaction ID (No_Daftar) for pengisytiharan
                    Dim no_daftar As Integer
                    no_daftar = opClass.Set_NoDaftar(Barcodes.Text)
                    'response.write(arrayVal.value)
                    'response.end()

                    'Generating eSKPI No. for each Importer and saved it in arrayList for reference
                    'opClass.Generate_eSKPI_Semula_KIBFG(arrayVal.Value, Barcodes.Text, KompleksPPI.SelectedItem.Value, arrayFishVal.Value)
                    'Generate_eSKPI_Semula(arrayVal.Value, Barcodes.Text, KompleksPPI.SelectedItem.Value, arrayFishVal.Value)

                    'Sorting Fish Item
                    'opClass.SortFishItem_kibfg(arrayFishVal.Value)

                    'Inserting Fish Item Declaration Into ITEM_ISYITIHAR_I
                    ' opClass.ProsesFish_Item_kibfg(arrayFishVal.Value, Barcodes.Text, JenisUrusan.SelectedItem.Value)

                    'Inserting Importer Information Into PENGISYTIHARAN_I_KIBFG
                    '                    opClass.Proses_Pengisytiharan_kibfg(arrayVal.Value, Barcodes.Text, no_daftar, noKenderaan.Text, JenisUrusan.SelectedItem.Value, NamaPemandu.Text, cara_pengangkutan.SelectedItem.Value, Bekalan.SelectedItem.Value, KompleksPPI.SelectedItem.Value, PetiBiruKecil.Text, PetiBiruBesar.Text, OnlineSend_By.Value)
                    opClass.Proses_Pengisytiharan_kibfg(arrayVal.Value, Barcodes.Text, no_daftar, noKenderaan.Text, JenisUrusan.SelectedItem.Value, NamaPemandu.Text, cara_pengangkutan.SelectedItem.Value, Bekalan.SelectedItem.Value, KompleksPPI.SelectedItem.Value, PetiBiruKecil.Text, PetiBiruBesar.Text, Nothing)

                    If (opClass.ErrorSignal = False) Then

                        'Commit All Processing For ITEM_ISYTIHAR_I_KIBFG and Pengisytiharan_I
                        Dim idx As Integer

                        For idx = 0 To opClass.transactionProcess.Count - 1
                            opClass.InsertData(opClass.transactionProcess(idx).ToString())
                            'Response.Write(opClass.transactionProcess(idx).ToString())
                        Next

                        'Dim iderror As Integer


                        'If (opClass.ErrorSignal = True) Then
                        '    For iderror = 0 To opClass.ErrorList.Count - 1
                        '        Response.Write("Berikut ialah error yang telah dikesan = " & opClass.ErrorList(iderror).ToString())
                        '    Next
                        'End If


                        'Inserting System Que Information
                        Dim nama_pegawai As String = ""
                        Dim status As String = ""

                        'sqlText = "INSERT INTO [W-ICCS].[dbo].[SISTEM_Q]([No_Barcode]," & _
                        '                        "[Jenis], [No_Kenderaan], [Bil_SKPI]," & _
                        '                        "[Pegawai], [Status])" & _
                        '                        "VALUES('" & Barcodes.Text & "','IMPORT','" & noKenderaan.Text & "'," & opClass.eSKPIArray.Count() & ",'" & nama_pegawai & "','" & status & "')"

                        ' edit by zuraini

                        Dim countforskpi As Integer
                        Dim SQLReader As System.Data.SqlClient.SqlDataReader

                        Dim sqlBorang As String = "SELECT count(*) as countforskpi From PENGISYTIHARAN_I_KIBFG " _
                        & " where status='A' and No_barcode = '" & Barcodes.Text & "'"
                        SQLReader = opClass.DataReader(sqlBorang)

                        If SQLReader.HasRows Then

                            SQLReader.Read()
                            countforskpi = (SQLReader("countforskpi"))

                        End If

                        SQLReader.Close()
                        SQLReader = Nothing


                        sqlText = "UPDATE SISTEM_Q Set status='Isytihar Semula',Bil_SKPI='" & countforskpi & "',pegawai='" & Session("namaPegawai") & "' WHERE No_Barcode = '" & Trim(Barcodes.Text) & "'"
                        'end coded

                        opClass.InsertData(sqlText)

                        'Inserting E-Permit Data
                        Dim namapemandus As String = NamaPemandu.Text
                        sqlText = "insert into epermit_user_maintenance(no_barcode,nama_driver,staff_id)values" & _
                                  "('" & Barcodes.Text & "','" & namapemandus.Replace("'", "''") & "','" & nama_pegawai & "')"
                        opClass.InsertData(sqlText)


                        sqlText = "SELECT * FROM NO_INVOIS WHERE No_Barcode = '" & Barcodes.Text & "' order by bil_invois"
                        Dim rdr1 As System.Data.SqlClient.SqlDataReader
                        rdr1 = opClass.DataReader(sqlText)
                        If (rdr1.HasRows = False) Then
                            rdr1.Close()
                            rdr1 = Nothing
                            sqlText = "insert into tblnoinvois(no_barcode)values('" & rujukan.Text & "');select SCOPE_IDENTITY()"
                            Dim rstInvois As System.Int32 = opClass.Identity(sqlText)
                            sqlText = " insert into no_invois(bil_invois,no_invois,no_barcode)values(" & rstInvois & ",'" & opClass.FormatNumber(rstInvois.ToString()) & "','" & Barcodes.Text & "')"
                            opClass.InsertData(sqlText)
                            currentInvois = opClass.FormatNumber(rstInvois)
                        Else
                            rdr1.Read()
                            currentInvois = rdr1.GetString(1)
                            rdr1.Close()
                            rdr1 = Nothing
                        End If

                        Invois_Id.Value = currentInvois

                        sqlText = "insert into no_siri_epermit_KIBFG(no_invois,no_barcode)values('" & currentInvois & "','" & Barcodes.Text & "');select SCOPE_IDENTITY()"
                        'opClass.InsertData(sqlText)
                        Dim rstEpermitSiri As String = opClass.SingleFieldResults(sqlText)

                        sqlText = "update no_siri_epermit_KIBFG set serial='" & rstEpermitSiri & "' where bil_siri='" & rstEpermitSiri & "'"
                        opClass.InsertData(sqlText)

                        'Update TMP_PENDAFTARAN_PINTU
                        sqlText = "update TMP_PENDAFTARAN_PINTU set Registered_Barcode='" & Barcodes.Text & "', DeclarationStatus='Y' where [Nombor_Barcode]='" & rujukan.Text & "'"
                        opClass.InsertData(sqlText)

                        sqlText = "update pendaftaran_pintu set kod_jenis_urusan='" & JenisUrusan.SelectedItem.Value & "' where nombor_barcode='" & Barcodes.Text & "'"
                        opClass.InsertData(sqlText)


                        Dim popupScript As String = ""
                        If (opClass.ErrorSignal = False) Then
                            popupScript = "<script language='javascript'>" & _
                                                        "alert('Maklumat Telah Selamat Disimpan!!!');" & _
                                                        "</script>"
                            Simpan.Enabled = False
                            Button1.Disabled = False
                            Button5.Disabled = False
                            Button10.Disabled = False

                        ElseIf (opClass.ErrorSignal = True) Then
                            popupScript = "<script language='javascript'>" & _
                                                        "alert('Sistem Error!!!');" & _
                                                        "</script>"
                        End If

                        Response.Write(popupScript)


                    End If

                End If 'End If Verifying Each Fish Item Declared By Importer

            Else
                Dim strMsg As String = ""
                If NamaPemandu.Text = "" Then strMsg = "-Maklumat Pemandu Diperlukan.\n"
                If arrayVal.Value = "" Then strMsg = strMsg & "-Maklumat Pengimport Diperlukan.\n"
                If arrayFishVal.Value = "" Then strMsg = strMsg & "-Maklumat Barangan Ikan Diperlukan.\n"
                If Barcodes.Text = "" Then strMsg = strMsg & "-Maklumat No. Barcode Diperlukan.\n"

                Response.Write("<script>alert('Maklumat Berikut Diperlukan :-\n\n" & strMsg & "');</script>")

            End If
        End If

    End Sub







    Protected Sub Keluar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Keluar.Click
        Response.Redirect("../../Pintu_Masuk/verifikasi_pintumasuk.aspx")
    End Sub



End Class
