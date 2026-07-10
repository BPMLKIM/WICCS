Imports System
Imports System.Globalization
Imports System.Globalization.CultureInfo

Partial Class Pintu_Masuk_Pintu_Masuk_Utara
    Inherits System.Web.UI.Page
    Public dbConn As System.Data.SqlClient.SqlConnection
    Public opClass As SQLOperation
    Public opClass1 As SQLOperation
    Public format As New System.Globalization.CultureInfo("ms-MY", True)
    Public expectedFormat As String = "dd/MM/YYYY HH:mm:ss"
    Public jsReader As System.Data.SqlClient.SqlDataReader
    Public SQLReader As System.Data.SqlClient.SqlDataReader
    Public j As Integer
    Protected strJenisUrusan As String
    Protected namaJenisUrusan As String
    Protected strKodKenderaan As String
    Protected pintuMasuk As String



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        opClass = New SQLOperation()
        opClass.dbConnection()
        Dim SQLReader As System.Data.SqlClient.SqlDataReader

        If Not Page.IsPostBack Then

            Dim strSQL As String = " SELECT Pendaftaran_Pintu.Nombor_barcode,Pendaftaran_Pintu.Pintu_Masuk,Pendaftaran_Pintu.Kod_jenis_urusan,Pendaftaran_Pintu.Kod_Jenis_Kenderaan,AGEN_PENGANGKUTAN.Nama_Agen_Pengangkutan,AGEN_PENGANGKUTAN.Kod_Agen_Pengangkutan,Pendaftaran_Pintu.No_Kenderaan " _
            & "FROM Pendaftaran_Pintu inner join AGEN_PENGANGKUTAN on Pendaftaran_Pintu.Kod_Agen_Pengangkutan = AGEN_PENGANGKUTAN.Kod_Agen_Pengangkutan inner join sistem_q on Pendaftaran_Pintu.Nombor_barcode = sistem_q.no_barcode  " _
            & " WHERE ((sistem_q.status<>'Pintu Keluar Import') or (sistem_q.status<>'Pintu Keluar Utara')) and ((sistem_q.status<>'Pintu Keluar Eksport') or (sistem_q.status<>'Pintu Keluar Selatan')) and (Pendaftaran_Pintu.Nombor_Barcode = '" & Trim(Request("strBarcode")) & "' or Pendaftaran_Pintu.No_Kenderaan = '" & Trim(Request("strBarcode")) & "')"
            SQLReader = opClass.DataReader(strSQL)

            If SQLReader.HasRows Then

                SQLReader.Read()

                Agen.Text = SQLReader("Nama_Agen_Pengangkutan")
                searchKodAgen.Text = SQLReader("Kod_Agen_Pengangkutan")
                noKenderaan.Text = SQLReader("No_Kenderaan")
                strKodKenderaan = SQLReader("Kod_Jenis_Kenderaan")
                strJenisUrusan = SQLReader("Kod_jenis_urusan")
                pintuMasuk = SQLReader("Pintu_Masuk")
                strBarcode.Text = SQLReader("Nombor_barcode")
                TextBox1.Text = SQLReader("Nombor_barcode")

                If pintuMasuk = "Utara" Then
                    pintuMasuk = "Import"
                ElseIf pintuMasuk = "Selatan" Then
                    pintuMasuk = "Eksport"
                Else
                    pintuMasuk = SQLReader("Pintu_Masuk")
                End If

            End If

            SQLReader.Close()
            SQLReader = Nothing

            searchKodAgen.Attributes.Add("onKeyPress", "return keyToUpperCase(this, event);")
            searchKodAgen.Attributes.Add("onBlur", "showFilteredAgen();")
            noKenderaan.Attributes.Add("onKeyPress", "return keyToUpperCase(this, event);")

        End If
        Image1.ImageUrl = "../IDAutomationStreamingLinear.aspx?barcode=" & strBarcode.Text & "&X=&CODE_TYPE=39&ROTATE=&Bar_Height=&Left_Margin=&Top_Margin=&Check_Char=&Check_Char_Text=&Show_Text=&IR=&BearerBarVertical=&BearerBarHorizontal=&WhiteBarIncrease=&CharacterGrouping=&CaptionAbove=&CaptionBelow="

    End Sub

    Protected Sub TextBox1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Agen.Load
        Agen.Attributes.Add("onClick", "window.open('/w-iccs/Pintu_Masuk/Senarai_Agen.aspx','SECURITY','scrollbars=yes,status=1,toolbar=no,personalbar=no,menubar=no,locationbar=no,resizable=no,width=380, height=420,top=100,left=70')")
    End Sub

    Protected Sub cara_pengangkutan_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles cara_pengangkutan.PreRender
        If strKodKenderaan <> "" Then
            cara_pengangkutan.ClearSelection()
            cara_pengangkutan.Items.FindByValue(strKodKenderaan).Selected = True
        End If
    End Sub

    Protected Sub pintu_masuk_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles pintu_masuk.PreRender
        If pintuMasuk <> "" Then
            pintu_masuk.ClearSelection()
            pintu_masuk.Items.FindByValue(pintuMasuk).Selected = True
        End If
    End Sub

    Protected Sub JenisUrusan_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles JenisUrusan.PreRender
        If strJenisUrusan <> "" Then
            JenisUrusan.ClearSelection()
            JenisUrusan.Items.FindByValue(strJenisUrusan).Selected = True
        End If
    End Sub


    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click

        opClass1 = New SQLOperation()
        opClass1.dbConnection()
        Dim j As Integer

        If (sender.id) = "Button2" Then

            Dim sqlText As String = "select count(*) from PENGISYTIHARAN_E where no_barcode='" & TextBox1.Text & "' and status='A'"
            Dim rcount As Integer = opClass.SingleFieldResults(sqlText)

            If rcount > 0 Then
                Dim popupScript As String = "<script language='javascript'>" & _
                                             "alert('PENGISYTIHARAN telah dibuat sila buat pembatalan dulu sebelum tukar jenis urusan !!!');location.href='verifikasi_pintumasuk.aspx'</script>"

                Response.Write(popupScript)

            Else

                Dim sqlUpdate As String = "Update Pendaftaran_Pintu set No_Kenderaan='" & Trim(noKenderaan.Text) & "'," _
                & "Kod_Jenis_Kenderaan = '" & Trim(cara_pengangkutan.SelectedItem.Value) & "'," _
                & "Kod_Agen_Pengangkutan = '" & Trim(searchKodAgen.Text) & "',pintu_masuk = '" & Trim(pintu_masuk.SelectedItem.Value) & "',Kod_Jenis_Urusan= '" & Trim(JenisUrusan.SelectedItem.Value) & "'" _
                & "where nombor_barcode='" & Trim(strBarcode.Text) & "'"
                opClass1.InsertData(sqlUpdate)

                If Trim(JenisUrusan.SelectedItem.Value) = "003" Or Trim(JenisUrusan.SelectedItem.Value) = "017" Or Trim(JenisUrusan.SelectedItem.Value) = "018" Then
                    Dim sqlUpdate1 As String = "Update PENGISYTIHARAN_E set No_Kenderaan='" & Trim(noKenderaan.Text) & "'" _
                    & ", kod_urusan='" & Trim(JenisUrusan.SelectedItem.Value) & "' where no_barcode='" & Trim(strBarcode.Text) & "'"
                    opClass1.InsertData(sqlUpdate1)
                Else
                    Dim sqlUpdate1 As String = "Update PENGISYTIHARAN_I set No_Kenderaan='" & Trim(noKenderaan.Text) & "'" _
                    & ", kod_urusan='" & Trim(JenisUrusan.SelectedItem.Value) & "' where no_barcode='" & Trim(strBarcode.Text) & "'"
                    opClass1.InsertData(sqlUpdate1)
                End If

                Dim sqlUpdate2 As String = "Update sistem_q set No_Kenderaan='" & Trim(noKenderaan.Text) & "'" _
                & " where no_barcode='" & Trim(strBarcode.Text) & "'"
                opClass1.InsertData(sqlUpdate2)

                Dim sqlUpdate3 As String = "Update LOG_TRANSAKSI_DEPOSIT set Kod_Agen_Pengangkutan='" & Trim(searchKodAgen.Text) & "'" _
                & " where no_barcode='" & Trim(strBarcode.Text) & "'"
                opClass1.InsertData(sqlUpdate3)

                Dim sqlUpdate4 As String = "Update no_siri_resit_lkim set kod_agen='" & Trim(searchKodAgen.Text) & "'" _
                & " where no_barcode='" & Trim(strBarcode.Text) & "'"
                opClass1.InsertData(sqlUpdate4)

                Dim sqlUpdate5 As String = "Update no_siri_resit_nekad set kod_agen='" & Trim(searchKodAgen.Text) & "'" _
                & " where no_barcode='" & Trim(strBarcode.Text) & "'"
                opClass1.InsertData(sqlUpdate5)

                Dim sqlUpdate6 As String = "Update no_siri_resit_nekad_eksport set kod_agen='" & Trim(searchKodAgen.Text) & "'" _
                & " where no_barcode='" & Trim(strBarcode.Text) & "'"
                opClass1.InsertData(sqlUpdate6)

                Dim sqlUpdate7 As String = "Update pembayaran_caj set No_Kenderaan='" & Trim(noKenderaan.Text) & "',Kod_Agen_pengangkutan='" & Trim(searchKodAgen.Text) & "'" _
                & " where no_barcode='" & Trim(strBarcode.Text) & "'"
                opClass1.InsertData(sqlUpdate7)

                Dim sqlUpdate8 As String = "Update pembayaran_caj_ikan set kod_agen='" & Trim(searchKodAgen.Text) & "'" _
                & " where no_barcode='" & Trim(strBarcode.Text) & "'"
                opClass1.InsertData(sqlUpdate8)

                Dim sqlUpdate9 As String = "Update pembayaran_caj_SKPE set kod_agen='" & Trim(searchKodAgen.Text) & "'" _
                & " where no_barcode='" & Trim(strBarcode.Text) & "'"
                opClass1.InsertData(sqlUpdate9)

                Dim sqlUpdate10 As String = "Update pembayaran_caj_SKPI set kod_agen='" & Trim(searchKodAgen.Text) & "'" _
                & " where no_barcode='" & Trim(strBarcode.Text) & "'"
                opClass1.InsertData(sqlUpdate10)

                Dim sqlUpdate11 As String = "delete from item_bukan_ikan where no_barcode='" & strBarcode.Text & "'"
                opClass1.InsertData(sqlUpdate11)

                For j = 0 To CheckBoxList2.Items.Count - 1

                    If CheckBoxList2.Items(j).Selected = True Then

                        sqlText = "INSERT INTO [W-ICCS].[dbo].[item_bukan_ikan] (no_barcode ,kod_barangan)" & _
                        "VALUES('" & strBarcode.Text & "','" & CheckBoxList2.Items(j).Value & "')"
                        opClass.InsertData(sqlText)

                    End If

                    Response.Write("<script language=javascript>alert('Maklumat telah di kemaskinikan');location.href='verifikasi_pintumasuk.aspx'</script>")

                Next
            End If
        End If

    End Sub



    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        opClass.dbConnection_Close()
    End Sub

    'Protected Sub cetak_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cetak.Click

    '  Response.Redirect("print_pintu_masuk.aspx?strBarcode=" & strBarcode.Text & "")


    'End Sub

    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        Server.Transfer("verifikasi_PintuMasuk.aspx")
    End Sub
End Class
