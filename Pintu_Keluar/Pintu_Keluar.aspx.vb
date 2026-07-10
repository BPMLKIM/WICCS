Imports System
Imports System.Globalization
Imports System.Globalization.CultureInfo
Partial Class Pintu_Keluar
    Inherits System.Web.UI.Page
    Public dbConn As System.Data.SqlClient.SqlConnection
    Public opClass As SQLOperation
    Public opClass1 As SQLOperation
    Public format As New System.Globalization.CultureInfo("ms-MY", True)
    Public expectedFormat As String = "dd/MM/YYYY HH:mm:ss"
    Protected strJenisUrusan As String
    Protected namaJenisUrusan As String
    Protected strKodKenderaan As String




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
        Dim SQLReader As System.Data.SqlClient.SqlDataReader

        strBarcode.Text = Trim(Request("strBarcode"))

        Dim strSQL As String = " SELECT Pendaftaran_Pintu.Kod_jenis_urusan,Pendaftaran_Pintu.Kod_Jenis_Kenderaan,AGEN_PENGANGKUTAN.Nama_Agen_Pengangkutan,AGEN_PENGANGKUTAN.Kod_Agen_Pengangkutan,Pendaftaran_Pintu.No_Kenderaan " _
        & "FROM Pendaftaran_Pintu inner join AGEN_PENGANGKUTAN on Pendaftaran_Pintu.Kod_Agen_Pengangkutan = AGEN_PENGANGKUTAN.Kod_Agen_Pengangkutan " _
        & " WHERE Pendaftaran_Pintu.Nombor_Barcode = '" & Trim(Request("strBarcode")) & "'"
        SQLReader = opClass.DataReader(strSQL)

        If SQLReader.HasRows Then

            SQLReader.Read()

            Agen.Text = SQLReader("Nama_Agen_Pengangkutan")
            kodAgen.Text = SQLReader("Kod_Agen_Pengangkutan")
            noKenderaan.Text = SQLReader("No_Kenderaan")
            strKodKenderaan = SQLReader("Kod_Jenis_Kenderaan")
            strJenisUrusan = SQLReader("Kod_jenis_urusan")

        End If

        SQLReader.Close()
        SQLReader = Nothing

        'Button1.Attributes.Add("onClick", "self.location.href='pintu_masuk_utara.aspx';")
        '    Button3.Enabled = False
        '   Button4.Enabled = False
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


    Protected Sub JenisUrusan_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles JenisUrusan.PreRender
        If strJenisUrusan <> "" Then
            JenisUrusan.ClearSelection()
            JenisUrusan.Items.FindByValue(strJenisUrusan).Selected = True
        End If
    End Sub


    Protected Sub Simpan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Simpan.Click

        If Simpan.Page.IsPostBack Then

            Dim sqlUpdate As String = "Update Pendaftaran_Pintu set Tarikh_Masa_Keluar=getdate()," & _
                                      "Pintu_Keluar = 'Import'," & _
                                      "EntryKeluar_By = '" & Session("username") & "' " & _
                                      "Where Nombor_Barcode='" & Trim(strBarcode.Text) & "'"
            opClass.InsertData(sqlUpdate)

            Dim sqlUpdate1 = "UPDATE SISTEM_Q Set status='Pintu Keluar Import',pegawai='" & Session("namaPegawai") & "' WHERE No_Barcode = '" & Trim(strBarcode.Text) & "'"
            opClass.InsertData(sqlUpdate1)

            Response.Write("<script language=javascript>alert('Maklumat telah di kemaskinikan');self.location.href='verifikasi_PintuKeluar.aspx'</script>")

        End If

    End Sub



    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        opClass.dbConnection_Close()
    End Sub


    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        Response.Redirect("verifikasi_PintuKeluar.aspx")
    End Sub
End Class
