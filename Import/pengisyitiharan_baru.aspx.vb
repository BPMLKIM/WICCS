Imports System.IO

Partial Class Import_pengisyitiharan_baru
    Inherits System.Web.UI.Page
#Region "Variables Declaration Area"
    Protected opClass As SQLOperation
    'Protected strKodKenderaan As String
    Protected strJenisUrusan As String
    Protected namaJenisUrusan As String
    Public jsReader As System.Data.SqlClient.SqlDataReader
    Public strBarcode As String

#End Region



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5))

        NamaPemandu.Text = Request.QueryString("namapemandu")

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

        opClass = New SQLOperation()
        opClass.dbConnection()

        ''opClass.Load_CajIkan()--shah
        opClass.Load_CajIkan_KIBFG() '--shah
        opClass.Load_CajIkanSyarikat()

        strBarcode = Request.QueryString("Barcode")
        Dim sqlText As String = ""

        sqlText = ""


        sqlText = "select " & _
                  "case when datepart(MM,getdate())<10 then '0'+ cast(datepart(MM,getdate()) as varchar(2)) " & _
                  "else cast(datepart(MM,getdate()) as varchar(2))" & _
                  "end +'/'+ case when datepart(DD,getdate())<10 then '0'+ cast(datepart(DD,getdate()) as varchar(2)) " & _
                  "else cast(datepart(DD,getdate()) as varchar(2))" & _
                  "end +'/'+ cast(datepart(YYYY,getdate()) as varchar(5))"

        serverDate.Value = opClass.SingleFieldResults(sqlText)

        Dim SQLReader As System.Data.SqlClient.SqlDataReader
        sqlText = "SELECT Pendaftaran_Pintu.No_Kenderaan, Pendaftaran_Pintu.Kod_Jenis_Kenderaan, Pendaftaran_Pintu.Kod_Agen_Pengangkutan, " & _
                  "Pendaftaran_Pintu.Kod_Jenis_Urusan, JENIS_URUSAN.Nama_Urusan, AGEN_PENGANGKUTAN.Nama_Agen_Pengangkutan," & _
                  "Pendaftaran_Pintu.Caj_Masuk FROM Pendaftaran_Pintu INNER JOIN " & _
                  "JENIS_URUSAN ON Pendaftaran_Pintu.Kod_Jenis_Urusan = JENIS_URUSAN.Kod_Urusan INNER JOIN " & _
                  "AGEN_PENGANGKUTAN ON Pendaftaran_Pintu.Kod_Agen_Pengangkutan = AGEN_PENGANGKUTAN.Kod_Agen_Pengangkutan " & _
                  "WHERE (Pendaftaran_Pintu.Nombor_Barcode = '" & strBarcode & "')"
        ' Response.Write(sqlText)

        SQLReader = opClass.DataReader(sqlText)

        If SQLReader.HasRows Then

            SQLReader.Read()
            NamaAgen.Text = SQLReader.GetString(5)
            noKenderaan.Text = SQLReader.GetString(0)
            strJenisUrusan = SQLReader.GetString(3)
            If strJenisUrusan = "020" Then
                Dim popupScript As String = "<script language='javascript'>" & _
                                                                       "alert('Jenis Urusan \""Tiada Muatan\"" Tidak DiBenarkan !!!\n\nSila Kemaskini Urusan Di Update Pintu Masuk \nUntuk Meneruskan Transaksi !!!');" & _
                                                                       "location.href='../Pintu_Masuk/verifikasi_PintuMasuk.aspx';</script>"
                Response.Write(popupScript)
                Response.End()
            ElseIf strJenisUrusan = "019" Then
                Dim popupScript As String = "<script language='javascript'>" & _
                                                                       "alert('Jenis Urusan \""Lain-lain\"" Tidak DiBenarkan !!!\n\nSila Kemaskini Urusan Di Update Pintu Masuk \nUntuk Meneruskan Transaksi !!!');" & _
                                                                       "location.href='../Pintu_Masuk/verifikasi_PintuMasuk.aspx';</script>"
                Response.Write(popupScript)
                Response.End()

            End If
            namaJenisUrusan = SQLReader.GetString(4)
            JenisUrusanLama.Value = namaJenisUrusan
            CajMasuk.Value = SQLReader.GetValue(6)

        End If
        SQLReader.Close()
        SQLReader = Nothing

        'NamaPemandu.Text = strKodKenderaan
        'cara_pengangkutan.ClearSelection()
        Barcodes.Text = strBarcode

        'arrayFishVal.Visible = False
        'arrayVal.Visible = False
        'currentImporter.Visible = False

        ' added by zue

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

        ' end coded


        ' Attach Javascript Operation To WebControls

        txtNilai.Attributes.Add("onBlur", "calculateJumlah();")
        txtPetiKecil.Attributes.Add("onBlur", "calculateTxtQtyKecil();calculateJumlah();")
        txtKuantitiKecil.Attributes.Add("onBlur", "calculateJumlah();")
        txtPetiBesar.Attributes.Add("onBlur", "calculateTxtQtyBesar();calculateJumlah();")
        txtKuantitiBesar.Attributes.Add("onBlur", "calculateJumlah();")
        Kod_BKH.Attributes.Add("onKeyPress", "return keyToUpperCase(this, event);")
        Kod_BKH.Attributes.Add("onBlur", "showFilteredIkan();")
        searchKodImporter.Attributes.Add("onKeyPress", "return keyToUpperCase(this, event);")
        searchKodImporter.Attributes.Add("onBlur", "showFilteredImporter();")
        searchKodExporter.Attributes.Add("onKeyPress", "return keyToUpperCase(this, event);")
        searchKodExporter.Attributes.Add("onBlur", "showFilteredExporter();")
        NamaPemandu.Attributes.Add("onKeyPress", "return keyToUpperCase(this, event);")
        'Button5.Attributes.Add("onSubmit", "return pastiKanData();")


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

    Protected Sub Keluar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Keluar.Click
        Response.Redirect("../pintu_masuk/verifikasi_PintuMasuk.aspx")
    End Sub

    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim currentInvois As String

        If Button5.Page.IsPostBack = True Then

            If NamaPemandu.Text <> "" And arrayVal.Value <> "" And arrayFishVal.Value <> "" Then
                strJenisUrusan = JenisUrusan.SelectedValue
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
                                               "alert('Maklumat Pengisytiharan Ikan Bagi \n Pengimport Berikut Tidak Lengkap :\n" & strMy & "')" & _
                                               "</script>"

                    Response.Write(popupScript)
                Else

                    'Response.Write(arrayVal.Value & "<br>")
                    'Response.Write(arrayVal.Value & "<br>")

                    'Added by khamsiah on 1 september 2007
                    'To delete item_isytihar_i when user click save button twice
                    Dim sqltext As String
                    sqltext = "delete  from item_isytihar_i_kibfg where nombor_barcode='" + Barcodes.Text + "'" & _
                              " and no_skpi not in (select no_skpi from pengisytiharan_i_kibfg where no_barcode='" + Barcodes.Text + "' )"
                    opClass.InsertData(sqltext)

                    'Get Transaction ID (No_Daftar) for pengisytiharan
                    Dim no_daftar As Integer
                    no_daftar = opClass.Set_NoDaftar_KIBFG(Barcodes.Text)


                    'Sorting Fish Item
                    opClass.SortFishItem_kibfg(arrayFishVal.Value)


                    'Generating eSKPI No. for each Importer and saved it in arrayList for reference
                    opClass.Generate_eSKPI_kibfg(arrayVal.Value, Barcodes.Text, KompleksPPI.SelectedItem.Value, arrayFishVal.Value)



                    'Inserting Fish Item Declaration Into ITEM_ISYITIHAR_I
                    opClass.ProsesFish_Item_kibfg(arrayFishVal.Value, Barcodes.Text, JenisUrusan.SelectedItem.Value)

                    'Inserting Importer Information Into Pengisytiharan_I
                    opClass.Proses_Pengisytiharan_kibfg(arrayVal.Value, Barcodes.Text, no_daftar, noKenderaan.Text, JenisUrusan.SelectedItem.Value, NamaPemandu.Text, cara_pengangkutan.SelectedItem.Value, Bekalan.SelectedItem.Value, KompleksPPI.SelectedItem.Value, Nothing)

                    'add khamsiah by 1 september 2007
                    Dim iderror As Integer


                    'If (opClass.ErrorSignal = True) Then
                    'For iderror = 0 To opClass.ErrorList.Count - 1
                    'Response.Write("Berikut ialah error yang telah dikesan = " & opClass.ErrorList(iderror).tostring())
                    'Next

                    'response.write("<script language='javascript'>" & _
                    '                                "alert('Sistem Error!!!');" & _
                    '                                "</script>")
                    '
                    'Else

                    'Commit All Processing For Pengisytiharan_I
                    Dim idx As Integer

                    For idx = 0 To opClass.transactionProcess.Count - 1

                        opClass.InsertData(opClass.transactionProcess(idx).ToString())

                    Next

                    'Inserting System Que Information
                    Dim nama_pegawai As String = ""
                    Dim status As String = ""
                    'Dim sqlText As String = "INSERT INTO [W-ICCS].[dbo].[SISTEM_Q]([No_Barcode]," & _
                    '                        "[Jenis], [No_Kenderaan], [Bil_SKPI]," & _
                    '                        "[Pegawai], [Status],[Site_Code])" & _
                    '                        "VALUES('" & Barcodes.Text & "','IMPORT','" & noKenderaan.Text & "'," & opClass.eSKPIArray.Count() & ",'" & nama_pegawai & "','" & status & "','001')"

                    sqltext = "UPDATE SISTEM_Q Set status='Isytihar',Bil_SKPI='" & opClass.eSKPIArray.Count() & "',pegawai='" & Session("namaPegawai") & "' WHERE No_Barcode = '" & Trim(Barcodes.Text) & "'"
                    opClass.InsertData(sqltext)

                    'Inserting E-Permit Data
                    Dim namapemandus As String = NamaPemandu.Text
                    sqltext = "insert into epermit_user_maintenance_KIBFG(no_barcode,nama_driver,staff_id)values" & _
                              "('" & Barcodes.Text & "','" & namapemandus.Replace("'", "''") & "','" & nama_pegawai & "')"
                    opClass.InsertData(sqltext)


                    sqltext = "SELECT * FROM NO_INVOIS WHERE No_Barcode = '" & Barcodes.Text & "' order by bil_invois"
                    Dim rdr1 As System.Data.SqlClient.SqlDataReader
                    rdr1 = opClass.DataReader(sqltext)
                    If (rdr1.HasRows = False) Then
                        rdr1.Close()
                        rdr1 = Nothing
                        sqltext = "insert into tblnoinvois(no_barcode)values('" & Barcodes.Text & "');select SCOPE_IDENTITY()"
                        Dim rstInvois As System.Int32 = opClass.Identity(sqltext)
                        sqltext = " insert into no_invois(bil_invois,no_invois,no_barcode)values(" & rstInvois & ",'" & opClass.FormatNumber(rstInvois.ToString()) & "','" & Barcodes.Text & "')"
                        opClass.InsertData(sqltext)
                        currentInvois = opClass.FormatNumber(rstInvois)
                    Else
                        rdr1.Read()
                        currentInvois = rdr1.GetString(1)
                        rdr1.Close()
                        rdr1 = Nothing
                    End If

                    Invois_Id.Value = currentInvois

                    sqltext = "insert into no_siri_epermit_KIBFG(no_invois,no_barcode)values('" & currentInvois & "','" & Barcodes.Text & "');select SCOPE_IDENTITY()"
                    'opClass.InsertData(sqlText)
                    Dim rstEpermitSiri As String = opClass.SingleFieldResults(sqltext)

                    sqltext = "update no_siri_epermit_KIBFG set serial='" & rstEpermitSiri & "' where bil_siri='" & rstEpermitSiri & "'"
                    opClass.InsertData(sqltext)

                    sqltext = "update pendaftaran_pintu set kod_jenis_urusan='" & JenisUrusan.SelectedItem.Value & "' where nombor_barcode='" & Barcodes.Text & "'"
                    opClass.InsertData(sqltext)

                    Dim popupScript As String = ""
                    'If (opClass.ErrorSignal = False) Then
                    popupScript = "<script language='javascript'>" & _
                                                "alert('Maklumat Telah Selamat Disimpan!!!');" & _
                                                "</script>"
                    Button5.Enabled = False
                    Button1.Disabled = False
                    Button10.Disabled = False
                    Button9.Disabled = False
                    'ElseIf (opClass.ErrorSignal = True) Then
                    'popupScript = "<script language='javascript'>" & _
                    '                            "alert('Sistem Error!!!');" & _
                    '                            "</script>"
                    'End If

                    Response.Write(popupScript)


                    'End If
                End If 'End If Verifying Each Fish Item Declared By Importer

            Else
                Dim strMsg As String = ""
                If NamaPemandu.Text = "" Then strMsg = "-Maklumat Pemandu Diperlukan.\n"
                If arrayVal.Value = "" Then strMsg = strMsg & "-Maklumat Pengimport Diperlukan.\n"
                If arrayFishVal.Value = "" Then strMsg = strMsg & "-Maklumat Barangan Ikan Diperlukan.\n"

                Response.Write("<script>alert('Maklumat Berikut Diperlukan :-\n\n" & strMsg & "');</script>")

            End If
        Else
            'Do Nothing
        End If


    End Sub


    'Protected Sub CETAK_NEW_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CETAK_NEW.Click
    '    Dim myGuid As Guid = Guid.NewGuid()
    '    Dim filename As String = "D:\wwwroot\LIVE_ICCS_AFTER_TUNING\W-ICCS\printJobQueue\" & myGuid.ToString() + ".txt"

    '    Dim sw As StreamWriter = New StreamWriter(filename)
    '    ' Add some text to the file.
    '    Dim str As String = Barcodes.Text & "|" & Invois_Id.Value & "|" & printer_name.Value
    '    sw.Write(str)
    '    sw.Close()

    'End Sub


End Class
