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
    Protected strJenisUrusan As String
    Protected namaJenisUrusan As String
    Protected strKodKenderaan As String
    Protected pintuMasuk As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        opClass = New SQLOperation()
        opClass.dbConnection()
        Dim SQLReader As System.Data.SqlClient.SqlDataReader


        If Not Page.IsPostBack Then

            Dim strSQL As String = " SELECT Pendaftaran_Pintu.Nombor_barcode,Pendaftaran_Pintu.Pintu_Masuk,Pendaftaran_Pintu.Kod_jenis_urusan,Pendaftaran_Pintu.Kod_Jenis_Kenderaan,AGEN_PENGANGKUTAN.Nama_Agen_Pengangkutan,AGEN_PENGANGKUTAN.Kod_Agen_Pengangkutan,Pendaftaran_Pintu.No_Kenderaan,jenis_pengangkutan.nama_pengangkutan,jenis_urusan.nama_urusan " _
            & "FROM Pendaftaran_Pintu inner join AGEN_PENGANGKUTAN on Pendaftaran_Pintu.Kod_Agen_Pengangkutan = AGEN_PENGANGKUTAN.Kod_Agen_Pengangkutan inner join sistem_q on Pendaftaran_Pintu.Nombor_barcode = sistem_q.no_barcode inner join jenis_pengangkutan on Pendaftaran_Pintu.kod_jenis_kenderaan = jenis_pengangkutan.kod_pengangkutan inner join jenis_urusan on Pendaftaran_Pintu.kod_jenis_urusan = jenis_urusan.kod_urusan" _
            & " WHERE (sistem_q.status<>'Pintu Keluar Utara') and (sistem_q.status<>'Pintu Keluar Selatan') and (Pendaftaran_Pintu.Nombor_Barcode = '" & Trim(Request("strBarcode")) & "' or Pendaftaran_Pintu.No_Kenderaan = '" & Trim(Request("strBarcode")) & "')"
            SQLReader = opClass.DataReader(strSQL)

            If SQLReader.HasRows Then

                SQLReader.Read()

                Agen.Text = SQLReader("Nama_Agen_Pengangkutan")
                searchKodAgen.Text = SQLReader("Kod_Agen_Pengangkutan")
                nokenderaan.Text = SQLReader("No_Kenderaan")
                cara_pengangkutan.Text = SQLReader("nama_pengangkutan")
                JenisUrusan.Text = SQLReader("nama_urusan")
                pintu_masuk.Text = SQLReader("Pintu_Masuk")
                strBarcode.Text = SQLReader("Nombor_barcode")

            End If

            SQLReader.Close()
            SQLReader = Nothing

            searchKodAgen.Attributes.Add("onKeyPress", "return keyToUpperCase(this, event);")
            searchKodAgen.Attributes.Add("onBlur", "showFilteredAgen();")
            nokenderaan.Attributes.Add("onKeyPress", "return keyToUpperCase(this, event);")

        End If

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        opClass.dbConnection_Close()
    End Sub

End Class
