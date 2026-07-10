Imports System
Imports System.Globalization
Imports System.Globalization.CultureInfo
Partial Class Pintu_Masuk_Pintu_Masuk_Selatan
    Inherits System.Web.UI.Page
    Public dbConn As System.Data.SqlClient.SqlConnection
    Public opClass As SQLOperation
    Public format As New System.Globalization.CultureInfo("ms-MY", True)
    Public expectedFormat As String = "dd/MM/YYYY HH:mm:ss"
    Protected strJenisUrusan As String
    Public jsReader As System.Data.SqlClient.SqlDataReader

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
        'Button1.Attributes.Add("onClick", "self.location.href='pintu_masuk_Eksport.aspx';")
        searchKodAgen.Attributes.Add("onKeyPress", "return keyToUpperCase(this, event);")
        searchKodAgen.Attributes.Add("onBlur", "showFilteredAgen();")
        Kenderaan.Attributes.Add("onChange", "reloadCaj();")
        noKenderaan.Attributes.Add("onKeyPress", "return keyToUpperCase(this, event);")

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

    End Sub

    'Protected Sub TextBox1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Agen.Load
    ' Agen.Attributes.Add("onClick", "window.open('/w-iccs/Pintu_Masuk/Senarai_Agen.aspx','SECURITY','scrollbars=yes,status=1,toolbar=no,personalbar=no,menubar=no,locationbar=no,resizable=no,width=380, height=420,top=100,left=70')")
    'End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        If Button2.Page.IsPostBack Then

            If Kenderaan.SelectedValue = "" Then
                signalResponse.Text = "Sila Pilih Jenis Kenderaan Terlebih Dahulu!!!"
            Else

                Dim sqlText As String = ""
                Dim barcode As String
                Dim opStatus As Boolean = False
                Dim noSiriCajResit As String
                Dim arrayKenderaan As String()
                Dim tempString As String = ""
                Dim jenisKenderaan As String = ""
                Dim namaKenderaan As String = ""
                Dim cajMasuk As Double = 0

                barcode = opClass.GenerateBarcode()

                barcoded.Text = barcode
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Spliting Value Kenderaan Utk Dptkan Nama, Kod Kenderaan & Caj Masuk     '
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''    
                If Kenderaan.Text <> "" Then
                    tempString = Kenderaan.Text
                    arrayKenderaan = tempString.Split("|")
                    jenisKenderaan = arrayKenderaan(0)
                    namaKenderaan = arrayKenderaan(1)
                    cajMasuk = arrayKenderaan(2)
                End If

                If barcode.Length > 0 Then


                    sqlText = "INSERT INTO [W-ICCS].[dbo].[NO_SIRI_CAJ_MASUK]([barcode],pintu) VALUES('" & barcode & "','Eksport');select SCOPE_IDENTITY()"

                    noSiriCajResit = opClass.InsertAutoNumber(sqlText)
                    sqlText = "select count(*) as data from NO_SIRI_CAJ_MASUK where id<=" & noSiriCajResit & " and " & _
                            "(datepart(d,trans_date)=datepart(d,getdate())" & _
                            "and datepart(m,trans_date)=datepart(m,getdate())" & _
                            "and datepart(yy,trans_date)=datepart(yy,getdate())) and pintu='Eksport'"
                    Dim ndaftar As String = opClass.SingleFieldResults(sqlText)
                    Dim dt As String
                    Dim myUrusan As String = JenisUrusan.Text
                    Dim jenisBarangan As String = Nothing
                    Select Case myUrusan
                        Case "016", "018"
                            jenisBarangan = "Ikan & Bukan Ikan"
                        Case "017"
                            jenisBarangan = Nothing
                        Case Else
                            jenisBarangan = "Ikan"
                    End Select

                    sqlText = "INSERT INTO [W-ICCS].[dbo].[Pendaftaran_Pintu]" & _
                       "([Nombor_Barcode]" & _
                       ",[Nombor_Siri]" & _
                       ",[No_Kenderaan]" & _
                       ",[Kod_Jenis_Kenderaan]" & _
                       ",[Kod_Agen_Pengangkutan]" & _
                       ",[Pintu_Masuk]" & _
                       ",[Kod_Jenis_Urusan],[Caj_Masuk],[Site_Code],[Nombor_Daftar],[Tmp_Barcode],[Jenis_Barangan],[EntryMasuk_By])" & _
                    "VALUES(" & _
                       "'" & barcode & "'" & _
                       ",'" & noSiriCajResit & "'" & _
                       ",'" & noKenderaan.Text & "'" & _
                       ",'" & jenisKenderaan.Trim & "'" & _
                       ",'" & kodAgen.Value & "'" & _
                       ",'Eksport'" & _
                       ",'" & JenisUrusan.Text & "'" & _
                       "," & cajMasuk & ",'" & System.Configuration.ConfigurationManager.AppSettings("site_code") & "','" & ndaftar & "','" & NoRujukan.Text & "','" & jenisBarangan & "','" & Session("username") & "')"


                    'Response.Write(sqlText)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Masukkan Data Pintu Masuk Ke Dalam Table Pendaftaran_Pintu              '
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    opClass.InsertData(sqlText)


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Masukkan Status Pengisytiharan             '
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    opClass.UpdateFrontEndStatus(NoRujukan.Text, barcode, "Pintu Masuk")

                    'insert dalam system Q
                    Dim sqlText1 As String = "INSERT INTO [W-ICCS].[dbo].[SISTEM_Q]([No_Barcode]," & _
                                            "[Jenis], [No_Kenderaan], [Bil_SKPI]," & _
                                            "[Pegawai], [Status],[Site_Code])" & _
                                            "VALUES('" & barcode & "','EKSPORT','" & noKenderaan.Text & "','','" & Session("namaPegawai") & "','Pintu Masuk Eksport','055')"
                    opClass.InsertData(sqlText1)

                    'end coded

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Dptkan Jumlah Kenderaan Semasa Yang Masuk di Pintu Masuk
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'sqlText = "select count(*) from pendaftaran_pintu where pintu_masuk ='Eksport' " & _
                    '          "and(" & _
                    '          "DatePart(DD, tarikh_masa_masuk) = DatePart(DD, getdate())" & _
                    '          "and datepart(MM,tarikh_masa_masuk)=datepart(MM,getdate())" & _
                    '          "and datepart(YYYY,tarikh_masa_masuk)=datepart(YYYY,getdate())" & _
                    '          ")"
                    daftar.Text = ndaftar 'opClass.SingleFieldResults(sqlText)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Dapatkan Data Tarikh & Masa Masuk                                       '
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    sqlText = "select tarikh_masa_masuk from pendaftaran_pintu where nombor_barcode='" & barcode & "'"
                    dt = opClass.SingleFieldResults(sqlText)


                    Button2.Enabled = False
                    Panel1.Visible = False
                    Panel2.Visible = True
                    Tarikh.Text = dt
                    '.Format(
                    'DateTime.Parse(dt, format, DateTimeStyles.NoCurrentDateDefault)
                    nSiri.Text = noSiriCajResit
                    'Barcodes.Text = barcode
                    'LinearBarcode1.DataToEncode = barcode
                    Image1.ImageUrl = "../IDAutomationStreamingLinear.aspx?barcode=" & barcode & "&X=&CODE_TYPE=39&ROTATE=&Bar_Height=&Left_Margin=&Top_Margin=&Check_Char=&Check_Char_Text=&Show_Text=&IR=&BearerBarVertical=&BearerBarHorizontal=&WhiteBarIncrease=&CharacterGrouping=&CaptionAbove=&CaptionBelow="

                    'Image1.ImageUrl = "IDAutomationStreamingLinear.aspx?barcode=" & barcode
                    Label1.Text = kodAgen.Value
                    Label2.Text = namaKenderaan
                    Label4.Text = JenisUrusan.SelectedItem.Text
                    Label5.Text = noKenderaan.Text
                    Label6.Text = cajMasuk.ToString("RM#,##0.00;(RM#,##0.00);Zero")

                End If
            End If
        End If

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        opClass.dbConnection_Close()
    End Sub

    Protected Sub PeriksaRujukan_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        If PeriksaRujukan.Page.IsPostBack Then

            signalResponse.Text = ""
            Agen.Text = ""
            kodAgen.Value = ""
            noKenderaan.Text = ""
            strJenisUrusan = ""


            Dim sqlText As String = "SELECT TMP_PENDAFTARAN_PINTU.[Nombor_Barcode], TMP_PENDAFTARAN_PINTU.[No_Kenderaan], TMP_PENDAFTARAN_PINTU.[Kod_Agen_Pengangkutan], " & _
                                    "TMP_PENDAFTARAN_PINTU.[Kod_Jenis_Urusan], TMP_PENDAFTARAN_PINTU.[Tarikh_Masa_Masuk], TMP_PENDAFTARAN_PINTU.[Site_Code]," & _
                                    "TMP_PENDAFTARAN_PINTU.[NamaPemandu], TMP_PENDAFTARAN_PINTU.[DeclarationStatus], TMP_PENDAFTARAN_PINTU.[Registered_Barcode],AGEN_PENGANGKUTAN.NAMA_AGEN_PENGANGKUTAN, " & _
                                    "PENGISYTIHARAN_E.STATUS FROM [W-ICCS].[dbo].[TMP_PENDAFTARAN_PINTU] " & _
                                    "INNER JOIN AGEN_PENGANGKUTAN ON AGEN_PENGANGKUTAN.[Kod_Agen_Pengangkutan]=TMP_PENDAFTARAN_PINTU.[Kod_Agen_Pengangkutan] " & _
                                    "INNER JOIN PENGISYTIHARAN_E ON PENGISYTIHARAN_E.[No_Barcode]=TMP_PENDAFTARAN_PINTU.[Nombor_Barcode] " & _
                                    "WHERE TMP_PENDAFTARAN_PINTU.[Nombor_Barcode] = '" & NoRujukan.Text & "' and TMP_PENDAFTARAN_PINTU.[DeclarationStatus]='N' " & _
                                    "AND TMP_PENDAFTARAN_PINTU.[Kod_Jenis_Urusan] IN('003', '017', '018','020', '019')"
            ' signalResponse.Text = sqlText
            Dim SqlReader As System.Data.SqlClient.SqlDataReader = opClass.DataReader(sqlText)

            If SqlReader.HasRows Then
                SqlReader.Read()
                If SqlReader.GetValue(10).ToString().Trim() = "S3" Then
                    Agen.Text = SqlReader.GetValue(9)
                    searchKodAgen.Text = SqlReader.GetValue(2)
                    kodAgen.Value = SqlReader.GetValue(2)
                    noKenderaan.Text = SqlReader.GetValue(1)
                    strJenisUrusan = SqlReader.GetValue(3)
                ElseIf SqlReader.GetValue(10).ToString().Trim() = "S1" Then
                    signalResponse.Text = "Pengisytiharan Ikan Bagi No. Rujukan Ini Masih Belum Selesai di Pihak Agen!!!"
                ElseIf SqlReader.GetValue(10).ToString().Trim() = "A" Or SqlReader.GetValue(10) = "B" Then
                    signalResponse.Text = "No. Rujukan Ini Tidak Boleh Digunakan Kerana Ianya Sudah  Diproses!!!"
                End If
                SqlReader.Close()
                SqlReader = Nothing

            Else
                signalResponse.Text = "No. Rujukan Ini Tidak Wujud atau Tidak Boleh Digunakan Kerana Ianya Sudah Diproses!!!"
                SqlReader.Close()
                SqlReader = Nothing
            End If

        End If

    End Sub

    Protected Sub JenisUrusan_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles JenisUrusan.PreRender
        If strJenisUrusan <> "" Then
            JenisUrusan.ClearSelection()
            JenisUrusan.Items.FindByValue(strJenisUrusan).Selected = True
        End If
    End Sub

End Class
