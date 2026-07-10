
Partial Class Export_pengisyitiharan
    Inherits System.Web.UI.Page
#Region "Variables Declaration Area"
    Protected opClass As SQLOperationE
    'Protected strKodKenderaan As String
    Protected strJenisUrusan As String
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

        Dim strBarcode As String = Request.QueryString("Barcode")
        Dim sqlText As String = ""


        sqlText = "select " & _
                  "case when datepart(MM,getdate())<10 then '0'+ cast(datepart(MM,getdate()) as varchar(2)) " & _
                  "else cast(datepart(MM,getdate()) as varchar(2))" & _
                  "end +'/'+ case when datepart(DD,getdate())<10 then '0'+ cast(datepart(DD,getdate()) as varchar(2)) " & _
                  "else cast(datepart(DD,getdate()) as varchar(2))" & _
                  "end +'/'+ cast(datepart(YYYY,getdate()) as varchar(5))"

        serverDate.Value = opClass.SingleFieldResults(sqlText)

        Dim SQLReader As System.Data.SqlClient.SqlDataReader
        sqlText = "SELECT     Pendaftaran_Pintu.No_Kenderaan, Pendaftaran_Pintu.Kod_Jenis_Kenderaan, Pendaftaran_Pintu.Kod_Agen_Pengangkutan, " & _
                  "Pendaftaran_Pintu.Kod_Jenis_Urusan, JENIS_URUSAN.Nama_Urusan, AGEN_PENGANGKUTAN.Nama_Agen_Pengangkutan" & _
                  " FROM  Pendaftaran_Pintu INNER JOIN" & _
                  " JENIS_URUSAN ON Pendaftaran_Pintu.Kod_Jenis_Urusan = JENIS_URUSAN.Kod_Urusan INNER JOIN" & _
                  " AGEN_PENGANGKUTAN ON Pendaftaran_Pintu.Kod_Agen_Pengangkutan = AGEN_PENGANGKUTAN.Kod_Agen_Pengangkutan" & _
                  " WHERE     (Pendaftaran_Pintu.Nombor_Barcode = '" & strBarcode & "')"
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

            JenisUrusanLama.Value = SQLReader.GetString(4)
            'strKodKenderaan = SQLReader.GetString(1)

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





        'If Page.IsPostBack Then

        '    Dim popupScript As String = "<script language='javascript'>" & _
        '                                "showHint(document.all.arrayVal.value," & _
        '                                "'Load_ImporterInfo.aspx');" & _
        '                                "refreshTableGridIkan();alert('Maklumat Telah Selamat Disimpan!!!');" & _
        '                                "</script>"

        '    ClientScript.RegisterStartupScript(sender.GetType, popupScript, )




        'End If



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

        Dim currentInvois As String
        If Simpan.Page.IsPostBack Then

            If arrayVal.Value <> "" And arrayFishVal.Value <> "" Then
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
                                               "alert('Maklumat Pengisytiharan Ikan Bagi \n Pengeksport Berikut Tidak Lengkap :\n" & strMy & "')" & _
                                               "</script>"

                    Response.Write(popupScript)
                Else

                    'Get Transaction ID (No_Daftar) for pengisytiharan
                    Dim no_daftar As Integer
                    no_daftar = opClass.Set_NoDaftar(Barcodes.Text)

                    'Sorting Fish Item
                    opClass.SortFishItem(arrayFishVal.Value)

                    'Generating eSKPI No. for each Importer and saved it in arrayList for reference
                    opClass.Generate_eSKPE(arrayVal.Value, Barcodes.Text, KompleksPPI.SelectedItem.Value, arrayFishVal.Value)

                    'Inserting Fish Item Declaration Into ITEM_ISYITIHAR_I
                    opClass.ProsesFish_Item(arrayFishVal.Value, Barcodes.Text, JenisUrusan.SelectedItem.Value)

                    'Inserting Importer Information Into Pengisytiharan_I
                    opClass.Proses_Pengisytiharan(arrayVal.Value, Barcodes.Text, no_daftar, noKenderaan.Text, JenisUrusan.SelectedItem.Value, cara_pengangkutan.SelectedItem.Value, Bekalan.SelectedItem.Value, KompleksPPI.SelectedItem.Value, Nothing)


                    If (opClass.ErrorSignalE = False) Then

                        'Commit All Processing For Item_Isytihar_E and Pengisytiharan_E
                        Dim idx As Integer

                        For idx = 0 To opClass.transactionProcessE.Count - 1
                            opClass.InsertData(opClass.transactionProcessE(idx).ToString())
                        Next

                        'Inserting System Que Information
                        Dim nama_pegawai As String = ""
                        Dim status As String = ""
                        'Dim sqlText As String = "INSERT INTO [W-ICCS].[dbo].[SISTEM_Q]([No_Barcode]," & _
                        '                        "[Jenis], [No_Kenderaan], [Bil_SKPI]," & _
                        '                        "[Pegawai], [Status],[Site_Code])" & _
                        '                        "VALUES('" & Barcodes.Text & "','EKSPORT','" & noKenderaan.Text & "'," & opClass.eSKPEArray.Count() & ",'" & nama_pegawai & "','" & status & "','001')"

                        Dim sqlText = "UPDATE SISTEM_Q Set status='Isytihar',Bil_SKPI='" & opClass.eSKPEArray.Count() & "',pegawai='" & Session("namaPegawai") & "' WHERE No_Barcode = '" & Trim(Barcodes.Text) & "'"
                        opClass.InsertData(sqlText)

                        sqlText = "SELECT no_invois FROM NO_INVOIS_EKSPORT WHERE No_Barcode = '" & Barcodes.Text & "' order by bil_invois"
                        Dim rdr1 As System.Data.SqlClient.SqlDataReader
                        rdr1 = opClass.DataReader(sqlText)
                        If (rdr1.HasRows = False) Then
                            rdr1.Close()
                            rdr1 = Nothing
                            sqlText = "insert into NO_INVOIS_EKSPORT(no_barcode)values('" & Barcodes.Text & "');select SCOPE_IDENTITY()"
                            Dim rstInvois As String = opClass.SingleFieldResults(sqlText)
                            sqlText = "update no_invois_eksport set no_invois ='" & rstInvois.PadLeft(7, "0") & "' where bil_invois=" & rstInvois
                            opClass.InsertData(sqlText)
                            currentInvois = rstInvois.PadLeft(7, "0")
                        Else
                            rdr1.Read()
                            currentInvois = rdr1.GetString(0)
                            rdr1.Close()
                            rdr1 = Nothing
                        End If

                        Invois_Id.Value = currentInvois

                        sqlText = "update pendaftaran_pintu set kod_jenis_urusan='" & JenisUrusan.SelectedValue & "' where nombor_barcode='" & Barcodes.Text & "'"
                        opClass.InsertData(sqlText)

                        Simpan.Enabled = False
                        Button10.Disabled = False
                        Button9.Disabled = False
                        Button1.Disabled = False

                        Dim popupScript As String = "<script language='javascript'>" & _
                                                    "alert('Maklumat Telah Selamat Disimpan!!!');" & _
                                                    "</script>"


                        Response.Write(popupScript)


                    End If
                End If 'End If Verifying Each Fish Item Declared By Exporter
            Else
                Dim strMsg As String = ""
                If arrayVal.Value = "" Then strMsg = strMsg & "-Maklumat Pengeksport Diperlukan.\n"
                If arrayFishVal.Value = "" Then strMsg = strMsg & "-Maklumat Barangan Ikan Diperlukan.\n"

                Response.Write("<script>alert('Maklumat Berikut Diperlukan :-\n\n" & strMsg & "');</script>")


            End If
        End If

    End Sub


    

    Protected Sub Keluar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Keluar.Click
        Response.Redirect("../pintu_masuk/verifikasi_PintuMasuk.aspx")
    End Sub
End Class
