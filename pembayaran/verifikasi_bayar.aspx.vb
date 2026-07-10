
Partial Class pembayaran_verifikasi_bayar
    Inherits System.Web.UI.Page

#Region "Variables Declaration Area"
    Protected opClass As SQLOperation
    Protected opClass1 As SQLOperation
    Protected opClass2 As SQLOperation
    Protected opClass3 As SQLOperation

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Trim(Request("type")) = "ikan" Then

            title.Text = "VERIFIKASI BARCODE UNTUK PEMBAYARAN CAJ IKAN"
            idbarcode.Attributes.Add("style", "DISPLAY:BLOCK")

        ElseIf Trim(Request("type")) = "borang" Then

            title.Text = "VERIFIKASI BARCODE UNTUK PEMBAYARAN CAJ BORANG SKPI/SKPE"
            idbarcode.Attributes.Add("style", "DISPLAY:BLOCK")

        End If

        strBarcode.Focus()

        If Page.IsPostBack Then

            opClass = New SQLOperation()
            opClass.dbConnection()

            Dim SQLReader As System.Data.SqlClient.SqlDataReader

            '---shah add
            'Dim SQLReader1 As System.Data.SqlClient.SqlDataReader
            '---

            Dim tabletitle As String = ""
            Dim textfield As String = ""
            Dim title As String = ""
            Dim tableperiksa As String = ""
            Dim Kod_Agen As String
            Dim no_kenderaan As String
            Dim Kod_Jenis_Urusan As String
            Dim urusan As String = ""
            Dim service_caj As String = ""
            Dim status As String = ""

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


            ' code for bayaran terkumpul

            If Trim(Request("selectpay")) = "Bayar Terkumpul" And Trim(Request("type")) = "borang" Then
                Response.Redirect("frmAgenSKPI.aspx")
            ElseIf Trim(Request("selectpay")) = "Bayar Terkumpul" And Trim(Request("type")) = "ikan" Then
                Response.Redirect("frmAgenIkan.aspx")
            ElseIf Trim(Request("selectpay")) = "Bayar Terkumpul Rebat" And Trim(Request("type")) = "ikan" Then
                Response.Redirect("frmAgenIkan_kibfg.aspx")
            ElseIf Trim(Request("selectpay")) = "Bayar Terkumpul Rebat" And Trim(Request("type")) = "borang" Then
                Response.Write("<script languange=javascript>alert('Bayar Terkumpul Rebat hanya untuk Caj Ikan sahaja!');self.location.href='verifikasi_bayar.aspx?type=" & Request("type") & "';</script>")
                Response.End()
            End If

            ' end coded

            'code for cetak bayar terkumpul

            If Trim(Request("selectpay")) = "Cetak Resit Bayar Terkumpul" And Trim(Request("type")) = "borang" Then
                Response.Redirect("frmAgenSKPIC.aspx")
            ElseIf Trim(Request("selectpay")) = "Cetak Resit Bayar Terkumpul" And Trim(Request("type")) = "ikan" Then
                Response.Redirect("frmAgenIkanC.aspx")
            ElseIf Trim(Request("selectpay")) = "Cetak Resit Bayar Terkumpul Rebat" And Trim(Request("type")) = "ikan" Then
                Response.Redirect("frmAgenIkanC_kibfg.aspx")
            ElseIf Trim(Request("selectpay")) = "Cetak Resit Bayar Terkumpul Rebat" And Trim(Request("type")) = "borang" Then
                Response.Write("<script languange=javascript>alert('Cetak resit Bayar Terkumpul Rebat hanya untuk Caj Ikan sahaja!');self.location.href='verifikasi_bayar.aspx?type=" & Request("type") & "';</script>")
                Response.End()
            End If

        'end coded

        ' for payment individu and agen with the barcode

        If Trim(strBarcode.Text) <> "" And Trim(selectpay.SelectedValue) = "Bayar" Then

            Dim rstBarcode As String = "select p.kod_jenis_urusan,p.no_kenderaan," _
            & " p.kod_agen_pengangkutan,s.status from pendaftaran_pintu p inner join sistem_q s on p.nombor_barcode=s.no_barcode" _
            & " where p.nombor_barcode='" & Trim(strBarcode.Text) & "'"
            SQLReader = opClass.DataReader(rstBarcode)

            SQLReader.Read()

            If Not SQLReader.HasRows Then

                SQLReader.Close()
                SQLReader = Nothing

                Response.Write("<script languange=javascript>alert('Maklumat tidak wujud di dalam pangkalan data pusat!');self.location.href='verifikasi_bayar.aspx?type=" & Request("type") & "';</script>")
                Response.End()

            Else

                Kod_Agen = SQLReader("kod_agen_pengangkutan")
                no_kenderaan = SQLReader("no_kenderaan")
                Kod_Jenis_Urusan = SQLReader("Kod_Jenis_Urusan")
                status = SQLReader("status")

                If Kod_Jenis_Urusan = "003" Or Kod_Jenis_Urusan = "017" Or Kod_Jenis_Urusan = "018" Then

                    'eksport table
                    tabletitle = "PENGISYTIHARAN_E"
                    textfield = "No_SKPE"
                    title = "eksport"
                    tableperiksa = "PEMERIKSAAN_EKSPORT"
                    urusan = "E"
                    service_caj = "Item_Caj_Eksport"

                Else

                    'import table
                    tabletitle = "PENGISYTIHARAN_I"
                    tableperiksa = "PEMERIKSAAN_IMPORT"
                    textfield = "No_SKPI"
                    title = "import"
                    urusan = "I"
                    service_caj = "Item_Caj"

                End If

            End If

            SQLReader.Close()
            SQLReader = Nothing

            Dim rstBayar1 As String = ""

            If Trim(Request("type")) = "borang" Then
                    rstBayar1 = "select no_barcode from " & service_caj & " where no_barcode='" & Trim(strBarcode.Text) & "' and kod_service_caj='Caj Pengisytiharan (Borang SKPI) - PNK SRI MUARA'"                                                              '"
            Else
                rstBayar1 = "select no_barcode from " & service_caj & " where no_barcode='" & Trim(strBarcode.Text) & "' and kod_service_caj='Caj Perkhidmatan Ikan'"
            End If

            SQLReader = opClass.DataReader(rstBayar1)

            If SQLReader.HasRows Then

                SQLReader.Close()
                SQLReader = Nothing

                    Response.Write("<script languange=javascript>alert('Maklumat pembayaran telah wujud');self.location.href='verifikasi_bayar.aspx?type=" & Request("type") & "';</script>")

                    ''utk lepaskan cetak salinan samada caj ikan atau caj borang shah
                    ''Response.Redirect("pembayaranNewI.aspx?type=" & Trim(Request("type")) & "&selectpay=" & Trim(Request("selectpay")) & "&Kod_Agen=" & Trim(Kod_Agen) & "&Kod_Jenis_Urusan=" & Trim(Kod_Jenis_Urusan) & "&no_kenderaan=" & Trim(no_kenderaan) & "&urusan=" & Trim(urusan) & "&strBarcode=" & Trim(strBarcode.Text) & "")
                    Response.End()

            End If

            SQLReader.Close()
            SQLReader = Nothing

            Dim rstIkanCaj As String = "SELECT No_Barcode,status, " & textfield & " FROM " & tabletitle & " WHERE No_Barcode = '" & Trim(strBarcode.Text) & "' and status='B'"
            SQLReader = opClass.DataReader(rstIkanCaj)

            If SQLReader.HasRows Then

                SQLReader.Close()
                SQLReader = Nothing
                Response.Write("<script languange=javascript>alert('Terdapat SKPI yang mempunyai status Tidak Sah. Sila isytihar semula.');self.location.href='verifikasi_bayar.aspx?type=" & Trim(Request("type")) & "';</script>")
                Response.End()

            End If

            SQLReader.Close()
            SQLReader = Nothing




            Dim rstSekatPemeriksaan As String = "SELECT tindakan FROM " & tableperiksa & " WHERE status='1' and No_Barcode = '" & Trim(strBarcode.Text) & "'"
            SQLReader = opClass.DataReader(rstSekatPemeriksaan)

            If Not SQLReader.HasRows Then

                ' caj borang tak perlukan pemeriksaan

                If Trim(Request("selectpay")) = "Bayar" And Trim(Request("type")) = "borang" Then

                    SQLReader.Close()
                    SQLReader = Nothing
                    Response.Redirect("pembayaranNewB.aspx?type=" & Trim(Request("type")) & "&selectpay=" & Trim(Request("selectpay")) & "&Kod_Agen=" & Trim(Kod_Agen) & "&Kod_Jenis_Urusan=" & Trim(Kod_Jenis_Urusan) & "&no_kenderaan=" & Trim(no_kenderaan) & "&urusan=" & Trim(urusan) & "&strBarcode=" & Trim(strBarcode.Text) & "")
                    Response.End()

                Else

                    SQLReader.Close()
                    SQLReader = Nothing
                    Response.Write("<script languange=javascript>alert('Nombor barcode tersebut tidak membuat pemeriksaan lagi!');self.location.href='verifikasi_bayar.aspx?type=" & Request("type") & "';</script>")
                    Response.End()


                End If

            Else

                SQLReader.Read()


                If Trim(SQLReader("Tindakan")) = "Mahkamah" Then
                    SQLReader.Close()
                    SQLReader = Nothing
                    Response.Write("<script languange=javascript>alert('Lori berkenaan tidak dibenarkan untuk membuat pembayaran kerana tindakan mahkamah telah diisytiharkan terhadapnya !');self.location.href='verifikasi_bayar.aspx?type=" & Request("type") & "';</script>")
                    Response.End()
                Else

                    If Trim(Request("type")) = "borang" Then
                        Response.Redirect("pembayaranNewB.aspx?type=" & Trim(Request("type")) & "&selectpay=" & Trim(Request("selectpay")) & "&Kod_Agen=" & Trim(Kod_Agen) & "&Kod_Jenis_Urusan=" & Trim(Kod_Jenis_Urusan) & "&no_kenderaan=" & Trim(no_kenderaan) & "&urusan=" & Trim(urusan) & "&strBarcode=" & Trim(strBarcode.Text) & "")
                        Response.End()
                            'edited by kmz for caj eksport
                            'ElseIf Trim(Request("type")) = "ikan" And urusan = "E" Then

                            '    Response.Write("<script languange=javascript>alert('Pembayaran caj ikan adalah untuk jenis urusan import sahaja.');self.location.href='verifikasi_bayar.aspx?type=" & Request("type") & "';</script>")
                            '    Response.End()

                    ElseIf Trim(Request("type")) = "ikan" And (status = "Pelepasan" Or status = "Pintu Keluar Utara" Or status = "Pintu Keluar Selatan" Or status = "Pintu Keluar Import" Or status = "Pintu Keluar Eksport") Then

                        Response.Write("<script languange=javascript>alert('Status bagi barcode tersebut adalah Pelepasaan / telah keluar dari kompleks.');self.location.href='verifikasi_bayar.aspx?type=" & Request("type") & "';</script>")
                        Response.End()
                    ElseIf Trim(Request("type")) = "ikan" Then

                        '---shah tambah
                        SQLReader.Close()
                        SQLReader = Nothing



                        Dim cekrekod As String = "SELECT * FROM pengisytiharan_i_kibfg WHERE No_Barcode = '" & Trim(strBarcode.Text) & "'"
                        SQLReader = opClass.DataReader(cekrekod)

                        If SQLReader.HasRows Then
                            SQLReader.Close()
                            SQLReader = Nothing

                            Response.Redirect("pembayaranNewI_kibfg.aspx?type=" & Trim(Request("type")) & "&selectpay=" & Trim(Request("selectpay")) & "&Kod_Agen=" & Trim(Kod_Agen) & "&Kod_Jenis_Urusan=" & Trim(Kod_Jenis_Urusan) & "&no_kenderaan=" & Trim(no_kenderaan) & "&urusan=" & Trim(urusan) & "&strBarcode=" & Trim(strBarcode.Text) & "")
                            Response.End()
                        Else
                            SQLReader.Close()
                            SQLReader = Nothing

                            Response.Redirect("pembayaranNewI.aspx?type=" & Trim(Request("type")) & "&selectpay=" & Trim(Request("selectpay")) & "&Kod_Agen=" & Trim(Kod_Agen) & "&Kod_Jenis_Urusan=" & Trim(Kod_Jenis_Urusan) & "&no_kenderaan=" & Trim(no_kenderaan) & "&urusan=" & Trim(urusan) & "&strBarcode=" & Trim(strBarcode.Text) & "")
                            Response.End()
                        End If


                    End If

                    SQLReader.Close()
                    SQLReader = Nothing

                End If

            End If

        End If


        ' end coded for individual




        opClass.dbConnection_Close()

        End If

    End Sub


End Class
