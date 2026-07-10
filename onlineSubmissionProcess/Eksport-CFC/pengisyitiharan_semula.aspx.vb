
Partial Class Export_pengisyitiharan_semula
    Inherits System.Web.UI.Page
#Region "Variables Declaration Area"
    Protected opClass As SQLOperationE
    Protected strKodKenderaan As String
    Protected strJenisUrusan As String
    Protected strStatus As String
    Protected namaJenisUrusan As String
    Protected OnlineSendBy As String
    Public jsReader As System.Data.SqlClient.SqlDataReader
#End Region



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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

        opClass = New SQLOperationE()
        opClass.dbConnection()
        opClass.Load_CajIkan()
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
            
            sqlText = "SELECT PENDAFTARAN_PINTU.No_Kenderaan, AGEN_PENGANGKUTAN.Nama_Agen_Pengangkutan, PENDAFTARAN_PINTU.Kod_Jenis_Urusan, " & _
                     "PENDAFTARAN_PINTU.[Tmp_Barcode],Pendaftaran_Pintu.Caj_Masuk,PENGISYTIHARAN_E.Cara_Pengangkutan,JENIS_URUSAN.Nama_Urusan FROM  PENDAFTARAN_PINTU " & _
                     "INNER JOIN JENIS_URUSAN ON Pendaftaran_Pintu.Kod_Jenis_Urusan = JENIS_URUSAN.Kod_Urusan " & _
                     "INNER JOIN AGEN_PENGANGKUTAN ON PENDAFTARAN_PINTU.Kod_Agen_Pengangkutan = AGEN_PENGANGKUTAN.Kod_Agen_Pengangkutan " & _
                     "INNER JOIN PENGISYTIHARAN_E ON PENGISYTIHARAN_E.No_barcode = PENDAFTARAN_PINTU.[Nombor_Barcode] " & _
                     "WHERE PENDAFTARAN_PINTU.[Nombor_Barcode]='" & Barcodes.Text & "'"
            Dim sqlRead As System.Data.SqlClient.SqlDataReader
            sqlRead = opClass.DataReader(sqlText)
            If sqlRead.HasRows Then
                sqlRead.Read()
                noKenderaan.Text = sqlRead.GetValue(0)
                strJenisUrusan = sqlRead.GetValue(6)
                NamaAgen.Text = sqlRead.GetValue(1)
                'NamaPemandu.Text = sqlRead.GetValue(5)
                rujukan.Text = sqlRead.GetValue(3)
                'CajMasuk.Value = sqlRead.GetValue(4)
                strKodKenderaan = sqlRead("cara_pengangkutan")
            End If
            sqlRead.Close()
            sqlRead = Nothing


            'Query PENGISYITIHARAN_E
            Dim strVal As String = ""


            ' zue tambah distinct dalam sql dibawah

            sqlText = "SELECT   DISTINCT  PENGISYTIHARAN_E.Kod_Pengeksport + '|' + PENGEKSPORT.No_Lesen + '|' + CASE WHEN DAY(LESEN.Tarikh_Tamat) " & _
                  " < 10 THEN '0' + CAST(DAY(LESEN.Tarikh_Tamat) AS varchar(10)) ELSE CAST(DAY(LESEN.Tarikh_Tamat) AS varchar(10)) " & _
                  " END + '/' + CASE WHEN MONTH(LESEN.Tarikh_Tamat) < 10 THEN '0' + CAST(month(lesen.tarikh_tamat) AS varchar(1)) " & _
                  " ELSE CAST(month(lesen.tarikh_tamat) AS varchar(2)) END + '/' + CAST(YEAR(LESEN.Tarikh_Tamat) AS nvarchar(4)) " & _
                  " + '`' + PENGEKSPORT.Nama_Syarikat_Eksport + '`' + PENGISYTIHARAN_E.Destinasi_Negara + '`' + PENGISYTIHARAN_E.KodPPI + '`' + PENGISYTIHARAN_E.Kod_Pengimport" & _
                  " + '`' + PENGIMPORT_THAILAND.Nama_Pengimport + '`' + PENGISYTIHARAN_E.STATUS + '~' AS data, PENGISYTIHARAN_E.STATUS, PENGISYTIHARAN_E.KOD_URUSAN, JENIS_URUSAN.NAMA_URUSAN, PENGISYTIHARAN_E.ONLINESEND_BY " & _
                  "FROM PENGISYTIHARAN_E " & _
                  "INNER JOIN PENGEKSPORT ON PENGISYTIHARAN_E.Kod_Pengeksport = PENGEKSPORT.Kod_Pengeksport " & _
                  "INNER JOIN LESEN ON PENGEKSPORT.No_Lesen = LESEN.No_Lesen " & _
                  "INNER JOIN PENGIMPORT_THAILAND ON PENGISYTIHARAN_E.Kod_Pengimport = PENGIMPORT_THAILAND.Kod_Pengimport " & _
                  "INNER JOIN JENIS_URUSAN ON JENIS_URUSAN.KOD_URUSAN=PENGISYTIHARAN_E.KOD_URUSAN " & _
                  "WHERE (PENGISYTIHARAN_E.No_Barcode = '" & Barcodes.Text & "')"


            'Response.Write(sqlText)
            sqlRead = opClass.DataReader(sqlText)
            If sqlRead.HasRows Then
                Do While sqlRead.Read()
                    strVal = strVal & sqlRead.GetValue(0)
                    strStatus = sqlRead.GetValue(1)
                    strJenisUrusan = sqlRead.GetValue(2)
                    namaJenisUrusan = sqlRead.GetValue(3)
                    OnlineSendBy = sqlRead.GetValue(4)
                    OnlineSend_By.Value = OnlineSendBy
                    'Response.Write(strStatus)
                Loop
            End If
            sqlRead.Close()
            sqlRead = Nothing
            arrayVal.Value = strVal
            'Response.Write(strVal)
            status.Value = strStatus
            'Response.Write("Status=" & status.Value)

            If status.Value = "" Then
                Barcodes.Text = opClass.GenerateBarcode()
            End If

            'Query TMP_PENDAFTARAN PINTU
            sqlText = "SELECT TMP_PENDAFTARAN_PINTU.No_Kenderaan, TMP_PENDAFTARAN_PINTU.Kod_Agen_Pengangkutan, TMP_PENDAFTARAN_PINTU.Kod_Jenis_Urusan, TMP_PENDAFTARAN_PINTU.NamaPemandu, " & _
                      "AGEN_PENGANGKUTAN.NAMA_AGEN_PENGANGKUTAN FROM TMP_PENDAFTARAN_PINTU INNER JOIN AGEN_PENGANGKUTAN ON AGEN_PENGANGKUTAN.Kod_Agen_Pengangkutan=TMP_PENDAFTARAN_PINTU.Kod_Agen_Pengangkutan WHERE TMP_PENDAFTARAN_PINTU.Nombor_Barcode='" & Barcodes.Text & "'"
            'Response.Write(sqlText)
            sqlRead = opClass.DataReader(sqlText)

            If sqlRead.HasRows Then
                sqlRead.Read()
                noKenderaan.Text = sqlRead.GetValue(0)
                strJenisUrusan = sqlRead.GetValue(2)
                NamaAgen.Text = sqlRead.GetValue(4)
                'NamaPemandu.Text = sqlRead.GetValue(3)
            End If
            sqlRead.Close()
            sqlRead = Nothing


            'Query ITEM_ISYTIHAR_E
            strVal = ""
            sqlText = "SELECT PENGISYTIHARAN_E.Kod_Pengeksport + '`' + JENIS_IKAN.Kod_BKH + '`' + JENIS_IKAN.Nama_BKH + '`' + ITEM_ISYTIHAR_E.Kod_Ikan + '`' + PENGISYTIHARAN_E.Destinasi_Negara " & _
                      "+ '`' + CAST(ITEM_ISYTIHAR_E.PetiKecil AS varchar(20)) + '`' + CAST(ITEM_ISYTIHAR_E.KuantitiKecil AS varchar(20)) " & _
                      "+ '`' + CAST(ITEM_ISYTIHAR_E.PetiBesar AS varchar(20)) + '`' + CAST(ITEM_ISYTIHAR_E.KuantitiBesar AS varchar(20)) " & _
                      "+ '`' + CAST(ITEM_ISYTIHAR_E.Pek AS varchar(20)) + '`' + CAST(ITEM_ISYTIHAR_E.Ekor AS varchar(20)) " & _
                      "+ '`' + CAST(ITEM_ISYTIHAR_E.Nilai AS varchar(20)) + '`' + NEGARA.Nama_Negara + '~' AS Data " & _
                      "FROM ITEM_ISYTIHAR_E " & _
                      "INNER JOIN PENGISYTIHARAN_E ON ITEM_ISYTIHAR_E.No_SKPE = PENGISYTIHARAN_E.No_SKPE " & _
                      "INNER JOIN JENIS_IKAN ON ITEM_ISYTIHAR_E.Kod_Ikan = JENIS_IKAN.Kod_Ikan " & _
                      "INNER JOIN NEGARA ON PENGISYTIHARAN_E.Destinasi_Negara = NEGARA.Kod_Negara " & _
                      "WHERE (ITEM_ISYTIHAR_E.Nombor_Barcode = '" & Barcodes.Text & "')"

            sqlRead = opClass.DataReader(sqlText)
            If sqlRead.HasRows Then
                Do While sqlRead.Read()
                    strVal = strVal & sqlRead.GetValue(0)
                Loop
            End If
            sqlRead.Close()
            sqlRead = Nothing
            arrayFishVal.Value = strVal

            ' NamaAgen.Text = Session("namaAgen")
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


        ' Attach Javascript Operation To WebControls
        txtNilai.Attributes.Add("onBlur", "calculateJumlah();")
        txtPetiKecil.Attributes.Add("onBlur", "calculateTxtQtyKecil();calculateJumlah();")
        txtKuantitiKecil.Attributes.Add("onBlur", "calculateJumlah();")
        txtPetiBesar.Attributes.Add("onBlur", "calculateTxtQtyBesar();calculateJumlah();")
        txtKuantitiBesar.Attributes.Add("onBlur", "calculateJumlah();")
        JenisUrusan.Attributes.Add("onChange", "verifyUrusan();")
        Kod_BKH.Attributes.Add("onKeyPress", "return keyToUpperCase(this, event);")
        Kod_BKH.Attributes.Add("onBlur", "showFilteredIkan();")
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

        ' If Simpan.Page.IsPostBack Then
        If sender.id = "Simpan" Then


            Dim currentInvois As String
            Dim sqlText As String

            If arrayVal.Value <> "" And arrayFishVal.Value <> "" And Barcodes.Text <> "" Then

                'verifying fish item declared by each importer whether exists or not
                If (opClass.VerifyItemIsytihar(arrayVal.Value, arrayFishVal.Value) = True) Then
                    Dim m As Integer = 0
                    Dim strMy As String = ""
                    For m = 0 To opClass.ImporterErr.Count() - 1
                        Dim strKodImp As Object = opClass.ImporterErr(m).ToString()
                        Dim idxImp As Integer = opClass.vIsytiharImporter.IndexOf(strKodImp)
                        Dim strNameImp As String = opClass.vIsytiharImporterName(idxImp)
                        strMy = strMy & "\n - " & strNameImp
                    Next

                    Dim popupScript As String = "<script language='javascript'>" & _
                                               "alert('Maklumat Pengisytiharan Ikan Bagi \nPengeksport Berikut Tidak Lengkap :\n" & strMy & "')" & _
                                               "</script>"

                    Response.Write(popupScript)
                Else

                    'Move all skpi yg dibatalkan ke ITEM_ISYTIHAR_E_BATAL
                    sqlText = "INSERT INTO ITEM_ISYTIHAR_E_BATAL " & _
                              "SELECT ITEM_ISYTIHAR_E.Nombor_Barcode, ITEM_ISYTIHAR_E.No_SKPE, ITEM_ISYTIHAR_E.Bil_Item, ITEM_ISYTIHAR_E.Kod_Ikan, " & _
                              "ITEM_ISYTIHAR_E.Destinasi_Eksport, ITEM_ISYTIHAR_E.PetiKecil, ITEM_ISYTIHAR_E.KuantitiKecil, ITEM_ISYTIHAR_E.PetiBesar, " & _
                              "ITEM_ISYTIHAR_E.KuantitiBesar, ITEM_ISYTIHAR_E.Pek, ITEM_ISYTIHAR_E.Ekor, ITEM_ISYTIHAR_E.Nilai, ITEM_ISYTIHAR_E.Caj, " & _
                              "ITEM_ISYTIHAR_E.Site_Code, ITEM_ISYTIHAR_E.Caj_Ikan_Id " & _
                              "FROM ITEM_ISYTIHAR_E INNER JOIN " & _
                              "PENGISYTIHARAN_E ON ITEM_ISYTIHAR_E.No_SKPE = PENGISYTIHARAN_E.No_SKPE " & _
                              "WHERE (PENGISYTIHARAN_E.No_Barcode = '" & Barcodes.Text & "') AND (PENGISYTIHARAN_E.Status = 'B')"

                    opClass.InsertData(sqlText)
                    If (opClass.ErrorSignalE = True) Then
                        Response.Write("ITEM_ISY_I")
                        Response.End()
                    End If

                    'Response.Write("ITEM_ISYTIHAR_I_BATAL= " & sqlText & "<br>")


                    'Move all skpi yg dibatalkan ke PENGISYTIHARAN_I_BATAL

                    sqlText = "INSERT INTO PENGISYTIHARAN_E_BATAL " & _
                    "SELECT No_Barcode, No_SKPE, Reference_no, No_Daftar, No_Kenderaan, Cara_Pengangkutan, Kod_Pengeksport, Kod_Pengimport, Tarikh_Isytihar, " & _
                    "Masa_Isytihar, KodPPI, TotalPetiKecil, TotalKuantitiKecil, TotalPetiBesar, TotalKuantitiBesar, TotalPek, TotalEkor, TotalNilai, TotalCajIkan, " & _
                    "Destinasi_Negara, status, Nama_Pegawai, Transaction_Date, Nama_PemanduPindahan, No_KenderaanPindahan, Site_Code, OnlineSend_By, Kod_Urusan " & _
                    "FROM PENGISYTIHARAN_E " & _
                    "WHERE (No_Barcode = '" & Barcodes.Text & "') AND (Status = 'B')"
                    opClass.InsertData(sqlText)
                    'Response.Write("PENGISYTIHARAN_E_BATAL= " & sqlText & "<br>")
                    If (opClass.ErrorSignalE = True) Then
                        Response.Write("PENGISY_I")
                        Response.End()
                    End If



                    'Delete Temporary item_isytihar_e
                    sqlText = "delete item_isytihar_e from item_isytihar_e " & _
                              "inner join pengisytiharan_e on item_isytihar_e.no_skpe = pengisytiharan_e.no_skpe " & _
                              "where pengisytiharan_e.no_barcode='" & Barcodes.Text & "' and pengisytiharan_e.status='B' "
                    opClass.InsertData(sqlText)
                    'Response.Write(sqlText)
                    If (opClass.ErrorSignalE = True) Then
                        Response.Write("delete item_isytihar_e")
                        Response.End()
                    End If

                    'Delete PENGISYTIHARAN_E
                    sqlText = "delete from PENGISYTIHARAN_E where [No_Barcode]='" & Barcodes.Text & "' AND Status = 'B'"
                    opClass.InsertData(sqlText)
                    'Response.Write(sqlText)
                    If (opClass.ErrorSignalE = True) Then
                        Response.Write("delete PENGISYTIHARAN_E")
                        Response.End()
                    End If


                    'Get Transaction ID (No_Daftar) for pengisytiharan
                    Dim no_daftar As Integer
                    no_daftar = opClass.Set_NoDaftar(Barcodes.Text)

                    'Generating eSKPI No. for each Importer and saved it in arrayList for reference
                    opClass.Generate_eSKPE_Semula(arrayVal.Value, Barcodes.Text, KompleksPPI.SelectedItem.Value, arrayFishVal.Value)
                    'Response.Write(sqlText)
                    If (opClass.ErrorSignalE = True) Then
                        Response.Write("delete Generate_eSKPE_Semula")
                        Response.End()
                    End If

                    'Sorting Fish Item
                    opClass.SortFishItem(arrayFishVal.Value)

                    'Inserting Fish Item Declaration Into ITEM_ISYITIHAR_E
                    opClass.ProsesFish_Item(arrayFishVal.Value, Barcodes.Text, JenisUrusan.SelectedItem.Value)

                    'Inserting Importer Information Into Pengisytiharan_E
                    opClass.Proses_Pengisytiharan(arrayVal.Value, Barcodes.Text, no_daftar, noKenderaan.Text, JenisUrusan.SelectedItem.Value, cara_pengangkutan.SelectedItem.Value, Bekalan.SelectedItem.Value, KompleksPPI.SelectedItem.Value, OnlineSend_By.Value)

                    If (opClass.ErrorSignalE = False) Then

                        'Commit All Processing For Item_Isytihar_E and Pengisytiharan_E
                        Dim idx As Integer

                        For idx = 0 To opClass.transactionProcessE.Count - 1
                            opClass.InsertData(opClass.transactionProcessE(idx).ToString())
                        Next

                        'Inserting System Que Information
                        Dim nama_pegawai As String = ""
                        Dim status As String = ""
                        'sqlText = "INSERT INTO [W-ICCS].[dbo].[SISTEM_Q]([No_Barcode]," & _
                        '                        "[Jenis], [No_Kenderaan], [Bil_SKPI]," & _
                        '                        "[Pegawai], [Status])" & _
                        '                        "VALUES('" & Barcodes.Text & "','EKSPORT','" & noKenderaan.Text & "'," & opClass.eSKPEArray.Count() & ",'" & nama_pegawai & "','" & status & "')"


                        ' edit by zuraini

                        Dim countforskpi As Integer
                        Dim SQLReader As System.Data.SqlClient.SqlDataReader

                        Dim sqlBorang As String = "SELECT count(*) as countforskpi From PENGISYTIHARAN_E " _
                        & " where status='A' and No_barcode = '" & Barcodes.Text & "'"
                        SQLReader = opClass.DataReader(sqlBorang)

                        If SQLReader.HasRows Then

                            SQLReader.Read()
                            countforskpi = (SQLReader("countforskpi"))

                        End If

                        SQLReader.Close()
                        SQLReader = Nothing

                        sqlText = "UPDATE SISTEM_Q Set status='Isytihar Semula',Bil_SKPE='" & countforskpi & "',pegawai='" & Session("namaPegawai") & "' WHERE No_Barcode = '" & Trim(Barcodes.Text) & "'"
                        opClass.InsertData(sqlText)

                        ' end coded


                        sqlText = "SELECT no_invois FROM NO_INVOIS_EKSPORT WHERE No_Barcode = '" & Barcodes.Text & "' order by bil_invois"
                        Dim rdr1 As System.Data.SqlClient.SqlDataReader
                        rdr1 = opClass.DataReader(sqlText)
                        If (rdr1.HasRows = False) Then
                            rdr1.Close()
                            rdr1 = Nothing
                            sqlText = "insert into NO_INVOIS_EKSPORT(no_barcode)values('" & Barcodes.Text & "');select SCOPE_IDENTITY()"
                            Dim rstInvois As String = opClass.SingleFieldResults(sqlText)
                            sqlText = "update no_invois_eksport set no_invois ='" & rstInvois.PadLeft(7, "0") & "' where bil_invois=" & rstInvois
                            'opClass.InsertData(sqlText)
                            currentInvois = rstInvois.PadLeft(7, "0")
                        Else
                            rdr1.Read()
                            currentInvois = rdr1.GetString(0)
                            rdr1.Close()
                            rdr1 = Nothing
                        End If

                        Invois_Id.Value = currentInvois

                        'Update TMP_PENDAFTARAN_PINTU
                        sqlText = "update TMP_PENDAFTARAN_PINTU set Registered_Barcode='" & Barcodes.Text & "', DeclarationStatus='Y' where [Nombor_Barcode]='" & rujukan.Text & "'"
                        opClass.InsertData(sqlText)

                        sqlText = "update pendaftaran_pintu set kod_jenis_urusan='" & JenisUrusan.SelectedValue & "' where nombor_barcode='" & Barcodes.Text & "'"
                        opClass.InsertData(sqlText)


                        Dim popupScript As String = "<script language='javascript'>" & _
                                                    "alert('Maklumat Telah Selamat Disimpan!!!');" & _
                                                    "</script>"
                        Simpan.Enabled = False
                        Button10.Disabled = False
                        Button8.Disabled = False
                        Button9.Disabled = False



                        Response.Write(popupScript)


                    End If

                End If 'End If Verifying Each Fish Item Declared By Exporter

            Else
                Dim strMsg As String = ""
                If arrayVal.Value = "" Then strMsg = strMsg & "-Maklumat Pengeksport Diperlukan.\n"
                If arrayFishVal.Value = "" Then strMsg = strMsg & "-Maklumat Barangan Ikan Diperlukan.\n"
                If Barcodes.Text = "" Then strMsg = strMsg & "-Maklumat No. Barcode Diperlukan.\n"
                Response.Write("<script>alert('Maklumat Berikut Diperlukan :-\n\n" & strMsg & "');</script>")

            End If
        End If

    End Sub

    

    Protected Sub Keluar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Keluar.Click
        Response.Redirect("../../Pintu_Masuk/verifikasi_PintuMasuk.aspx")
    End Sub

  
End Class
