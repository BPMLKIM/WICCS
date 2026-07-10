
Partial Class View_Import_pengisyitiharan_p
    Inherits System.Web.UI.Page
#Region "Variables Declaration Area"
    Protected opClass As SQLOperation
    'Protected strKodKenderaan As String
    Protected strJenisUrusan As String
    Protected strStatus As String
    Public nnamaJenisUrusan As String
    Protected OnlineSendBy As String
    Public jsReader As System.Data.SqlClient.SqlDataReader
#End Region

    
  
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session.Item("username") Is Nothing Then
            Dim popupScript As String = "<script language='javascript'>" & _
                                             "alert('Sistem Error!!! Sessi Anda Telah Tamat Atau Tidak Sah!!!');" & _
                                             "parent.location.href='../index.aspx';" & _
                                             "</script>"
            Response.Write(popupScript)
        End If


        opClass = New SQLOperation()
        opClass.dbConnection()
        opClass.Load_CajIkan()

        strJenisUrusan = JenisUrusan.SelectedValue

        Dim strBarcode As String = Request.QueryString("Barcode")
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
            rujukan.Text = Request("barcode")

            'Query TMP_PENDAFTARAN PINTU
            sqlText = "SELECT PENDAFTARAN_PINTU.No_Kenderaan, AGEN_PENGANGKUTAN.Nama_Agen_Pengangkutan, PENDAFTARAN_PINTU.Kod_Jenis_Urusan, " & _
                      "epermit_user_maintenance.nama_driver,PENDAFTARAN_PINTU.[Nombor_Barcode] FROM  PENDAFTARAN_PINTU INNER JOIN " & _
                      "epermit_user_maintenance ON PENDAFTARAN_PINTU.Nombor_Barcode = epermit_user_maintenance.No_Barcode " & _
                      "INNER JOIN AGEN_PENGANGKUTAN ON PENDAFTARAN_PINTU.Kod_Agen_Pengangkutan = AGEN_PENGANGKUTAN.Kod_Agen_Pengangkutan " & _
                      "WHERE PENDAFTARAN_PINTU.[Nombor_Barcode]='" & rujukan.Text & "'"
            'Response.Write(sqlText)

            Dim sqlRead As System.Data.SqlClient.SqlDataReader
            sqlRead = opClass.DataReader(sqlText)
            If sqlRead.HasRows Then
                sqlRead.Read()
                noKenderaan.Text = sqlRead.GetValue(0)
                strJenisUrusan = sqlRead.GetValue(2)
                NamaAgen.Text = sqlRead.GetValue(1)
                NamaPemandu.Text = sqlRead.GetValue(3)
                Barcodes.Text = sqlRead.GetValue(4)
            End If
            sqlRead.Close()
            sqlRead = Nothing

            'Query PENGISYITIHARAN_I
            Dim strVal As String = ""

            sqlText = "SELECT RTRIM(PENGISYTIHARAN_I.Kod_Pengimport) + '|' + RTRIM(PENGIMPORT.No_Lesen) + '|' + " & _
                      "case when DAY(LESEN.Tarikh_Tamat) <10 then '0'+ cast(DAY(LESEN.Tarikh_Tamat) as varchar(10)) else cast(DAY(LESEN.Tarikh_Tamat) as varchar(10)) end " & _
                      "+ '/'+ case when MONTH(LESEN.Tarikh_Tamat) < 10 then '0'+cast(month(lesen.tarikh_tamat) as varchar(1)) else cast(month(lesen.tarikh_tamat) as varchar(2)) end " & _
                      "+ '/' + CAST(YEAR(LESEN.Tarikh_Tamat) as nvarchar(4)) " & _
                      "+ '`' + PENGIMPORT.Nama_Syarikat_Import + '`' + PENGISYTIHARAN_I.Sumber_Bekalan + '`' + PENGISYTIHARAN_I.Kod_PPI + '`' + PENGISYTIHARAN_I.Kod_Pengeksport " & _
                      "+ '`' + PENGEKSPORT_THAILAND.Nama_Pengeksport +'`'+ PENGISYTIHARAN_I.Nama_PemanduPindahan+ '`'+ PENGISYTIHARAN_I.No_KenderaanPindahan + '~'" & _
                      " AS data, PENGISYTIHARAN_I.STATUS, PENGISYTIHARAN_I.KOD_URUSAN,PENGISYTIHARAN_I.ONLINESEND_BY " & _
                      "FROM PENGISYTIHARAN_I INNER JOIN " & _
                      "PENGIMPORT ON PENGISYTIHARAN_I.Kod_Pengimport = PENGIMPORT.Kod_Pengimport INNER JOIN " & _
                      "LESEN ON PENGIMPORT.No_Lesen = LESEN.No_Lesen INNER JOIN " & _
                      "PENGEKSPORT_THAILAND ON PENGISYTIHARAN_I.Kod_Pengeksport = PENGEKSPORT_THAILAND.Kod_Pengeksport " & _
                      "Where   PENGISYTIHARAN_I.NO_BARCODE ='" & rujukan.Text & "'"

            'Response.Write(sqlText)
            sqlRead = opClass.DataReader(sqlText)
            If sqlRead.HasRows Then
                Do While sqlRead.Read()
                    strVal = strVal & sqlRead.GetValue(0)
                    strStatus = sqlRead.GetValue(1)
                    strJenisUrusan = sqlRead.GetValue(2)
                    OnlineSendBy = sqlRead.GetValue(3)
                    OnlineSend_By.Value = OnlineSendBy
                    'Response.Write(strStatus)
                Loop
            End If
            sqlRead.Close()
            sqlRead = Nothing
            arrayVal.Value = strVal
            status.Value = strStatus
            'Response.Write("Status=" & status.Value)

            If status.Value = "" Then
                Barcodes.Text = opClass.GenerateBarcode()
            End If

            'Query TMP_PENDAFTARAN PINTU
            sqlText = "SELECT TMP_PENDAFTARAN_PINTU.No_Kenderaan, TMP_PENDAFTARAN_PINTU.Kod_Agen_Pengangkutan, TMP_PENDAFTARAN_PINTU.Kod_Jenis_Urusan, TMP_PENDAFTARAN_PINTU.NamaPemandu " & _
                      ",AGEN_PENGANGKUTAN.NAMA_AGEN_PENGANGKUTAN FROM TMP_PENDAFTARAN_PINTU INNER JOIN AGEN_PENGANGKUTAN ON AGEN_PENGANGKUTAN.Kod_Agen_Pengangkutan=TMP_PENDAFTARAN_PINTU.Kod_Agen_Pengangkutan WHERE TMP_PENDAFTARAN_PINTU.Nombor_Barcode='" & Request("barcode") & "'"
            'Response.Write(sqlText)
            sqlRead = opClass.DataReader(sqlText)

            If sqlRead.HasRows Then
                sqlRead.Read()
                noKenderaan.Text = sqlRead.GetValue(0)
                strJenisUrusan = sqlRead.GetValue(2)
                If IsDBNull(sqlRead.GetValue(4)) = False Then
                    NamaAgen.Text = sqlRead.GetValue(4)
                    'NamaPemandu.Text = sqlRead.GetValue(3)
                End If
            End If
            sqlRead.Close()
            sqlRead = Nothing

            'Query ITEM_ISYTIHAR_I
            strVal = ""
            sqlText = "SELECT     PENGISYTIHARAN_I.Kod_Pengimport + '`' + JENIS_IKAN.Kod_BKH + '`' + JENIS_IKAN.Nama_BKH + '`' + ITEM_ISYTIHAR_I.Kod_Ikan + '`' + ITEM_ISYTIHAR_I.Destinasi_Pasar " & _
                      "+ '`' + CAST(ITEM_ISYTIHAR_I.PetiKecil AS varchar(20)) + '`' + CAST(ITEM_ISYTIHAR_I.KuantitiKecil AS varchar(20)) " & _
                      "+ '`' + CAST(ITEM_ISYTIHAR_I.PetiBesar AS varchar(20)) + '`' + CAST(ITEM_ISYTIHAR_I.KuantitiBesar AS varchar(20)) " & _
                      "+ '`' + CAST(ITEM_ISYTIHAR_I.Pek AS varchar(20)) + '`' + CAST(ITEM_ISYTIHAR_I.Ekor AS varchar(20)) " & _
                      "+ '`' + CAST(ITEM_ISYTIHAR_I.Nilai AS varchar(20)) + '`' + DESTINASI_PASAR.Nama_Pasar + '~' AS Data " & _
                      "FROM ITEM_ISYTIHAR_I INNER JOIN " & _
                      "PENGISYTIHARAN_I ON ITEM_ISYTIHAR_I.No_SKPI = PENGISYTIHARAN_I.No_SKPI " & _
                      "INNER JOIN JENIS_IKAN ON ITEM_ISYTIHAR_I.Kod_Ikan = JENIS_IKAN.Kod_Ikan " & _
                      "INNER JOIN DESTINASI_PASAR ON ITEM_ISYTIHAR_I.Destinasi_Pasar = DESTINASI_PASAR.Kod_Pasar " & _
                      "WHERE (ITEM_ISYTIHAR_I.Nombor_Barcode = '" & Request("barcode") & "')"
            'Response.Write("<p>" & sqlText)
            sqlRead = opClass.DataReader(sqlText)
            If sqlRead.HasRows Then
                Do While sqlRead.Read()
                    strVal = strVal & sqlRead.GetValue(0)
                Loop
            End If
            sqlRead.Close()
            sqlRead = Nothing
            arrayFishVal.Value = strVal

            'NamaAgen.Text = Session("namaAgen")

        End If 'End If PostBack 

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
        'If strKodKenderaan <> "" Then
        ' cara_pengangkutan.ClearSelection()
        ' cara_pengangkutan.Items.FindByValue(strKodKenderaan).Selected = True
        'End If
    End Sub

    Protected Sub JenisUrusan_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles JenisUrusan.PreRender
        If strJenisUrusan <> "" Then
            JenisUrusan.ClearSelection()
            JenisUrusan.Items.FindByValue(strJenisUrusan).Selected = True
        End If
    End Sub

    Protected Sub SIMPAN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Simpan.Click

        If Simpan.Page.IsPostBack Then


            Dim currentInvois As String
            Dim sqlText As String
            If NamaPemandu.Text <> "" And arrayVal.Value <> "" And arrayFishVal.Value <> "" And Barcodes.Text <> "" Then

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
                                               "alert('Maklumat Pengisytiharan Ikan Bagi \nPengimport Berikut Tidak Lengkap :\n" & strMy & "')" & _
                                               "</script>"

                    Response.Write(popupScript)
                Else

                    'Delete Temporary Data
                    sqlText = "delete from ITEM_ISYTIHAR_I where [Nombor_Barcode]='" & rujukan.Text & "'"
                    opClass.InsertData(sqlText)

                    sqlText = "delete from PENGISYTIHARAN_I where [No_Barcode]='" & rujukan.Text & "'"
                    opClass.InsertData(sqlText)

                    'Get Transaction ID (No_Daftar) for pengisytiharan
                    Dim no_daftar As Integer
                    no_daftar = opClass.Set_NoDaftar(Barcodes.Text)

                    'Generating eSKPI No. for each Importer and saved it in arrayList for reference
                    opClass.Generate_eSKPI(arrayVal.Value, Barcodes.Text, KompleksPPI.SelectedItem.Value, arrayFishVal.Value)

                    'Sorting Fish Item
                    opClass.SortFishItem(arrayFishVal.Value)

                    'Inserting Fish Item Declaration Into ITEM_ISYITIHAR_I
                    opClass.ProsesFish_Item(arrayFishVal.Value, Barcodes.Text, JenisUrusan.SelectedItem.Value)

                    'Inserting Importer Information Into Pengisytiharan_I            
                    opClass.Proses_Pengisytiharan(arrayVal.Value, Barcodes.Text, no_daftar, noKenderaan.Text, JenisUrusan.SelectedItem.Value, NamaPemandu.Text, cara_pengangkutan.SelectedItem.Value, Bekalan.SelectedItem.Value, KompleksPPI.SelectedItem.Value, OnlineSend_By.Value)


                    If (opClass.ErrorSignal = False) Then

                        'Commit All Processing For Item_Isytihar_I and Pengisytiharan_I
                        Dim idx As Integer

                        For idx = 0 To opClass.transactionProcess.Count - 1
                            opClass.InsertData(opClass.transactionProcess(idx).ToString())
                        Next

                        'Inserting System Que Information
                        Dim nama_pegawai As String = ""
                        Dim status As String = ""
                        sqlText = "INSERT INTO [W-ICCS].[dbo].[SISTEM_Q]([No_Barcode]," & _
                                                "[Jenis], [No_Kenderaan], [Bil_SKPI]," & _
                                                "[Pegawai], [Status])" & _
                                                "VALUES('" & Barcodes.Text & "','IMPORT','" & noKenderaan.Text & "'," & opClass.eSKPIArray.Count() & ",'" & nama_pegawai & "','" & status & "')"
                        opClass.InsertData(sqlText)

                        'Inserting E-Permit Data
                        sqlText = "insert into epermit_user_maintenance(no_barcode,nama_driver,staff_id)values" & _
                                  "('" & Barcodes.Text & "','" & NamaPemandu.Text & "','" & nama_pegawai & "')"
                        opClass.InsertData(sqlText)


                        sqlText = "SELECT * FROM NO_INVOIS WHERE No_Barcode = '" & Barcodes.Text & "' order by bil_invois"
                        Dim rdr1 As System.Data.SqlClient.SqlDataReader
                        rdr1 = opClass.DataReader(sqlText)
                        If (rdr1.HasRows = False) Then
                            rdr1.Close()
                            rdr1 = Nothing
                            sqlText = "insert into tblnoinvois(no_barcode)values('" & Barcodes.Text & "');select SCOPE_IDENTITY()"
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

                        sqlText = "insert into no_siri_epermit(no_invois,no_barcode)values('" & currentInvois & "','" & Barcodes.Text & "');select SCOPE_IDENTITY()"
                        'opClass.InsertData(sqlText)
                        Dim rstEpermitSiri As String = opClass.SingleFieldResults(sqlText)

                        sqlText = "update no_siri_epermit set serial='" & rstEpermitSiri & "' where bil_siri='" & rstEpermitSiri & "'"
                        opClass.InsertData(sqlText)

                        'Update TMP_PENDAFTARAN_PINTU
                        sqlText = "update TMP_PENDAFTARAN_PINTU set Registered_Barcode='" & Barcodes.Text & "', DeclarationStatus='Y' where [Nombor_Barcode]='" & rujukan.Text & "'"
                        opClass.InsertData(sqlText)


                        Dim popupScript As String = "<script language='javascript'>" & _
                                                    "alert('Maklumat Telah Selamat Disimpan!!!');" & _
                                                    "</script>"
                        Simpan.Enabled = False
                        Button5.Enabled = True

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
