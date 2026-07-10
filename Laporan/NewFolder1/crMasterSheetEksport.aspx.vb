Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class _Default
    Inherits System.Web.UI.Page
    Private crSKPI As ReportDocument
    Protected opClass As SQLOperationE

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        opClass = New SQLOperationE()
        opClass.dbConnection()

        Dim barcodeEntry As String = Request("barcode")
        Dim sqlText As String = ""
        Dim NoKenderaan As String = ""
        Dim NoAgenPengangkutan As String = ""
        Dim Urusan As String = ""
        Dim Barangan As String = ""
        Dim CajMasuk As String = ""
        Dim NamaPegawai As String = ""

        'Response.Write("StarQuery=" & Now())
        'Get Information For Invoice Top Report Information
        sqlText = "SELECT DISTINCT " & _
                  "PENDAFTARAN_PINTU.Nombor_Barcode, PENGISYTIHARAN_E.No_Kenderaan, " & _
                  "PENDAFTARAN_PINTU.Kod_Agen_Pengangkutan, JENIS_URUSAN.Nama_Urusan,PENDAFTARAN_PINTU.Caj_Masuk,PEGAWAI.Nama " & _
                  "FROM PENDAFTARAN_PINTU INNER JOIN " & _
                  "PENGISYTIHARAN_E ON PENDAFTARAN_PINTU.Nombor_Barcode = PENGISYTIHARAN_E.No_Barcode INNER JOIN " & _
                  "JENIS_URUSAN ON PENDAFTARAN_PINTU.Kod_Jenis_Urusan = JENIS_URUSAN.Kod_Urusan INNER JOIN " & _
                  "PEGAWAI ON PEGAWAI.KATA_PENGGUNA = PENGISYTIHARAN_E.Nama_Pegawai " & _
                  "WHERE PENDAFTARAN_PINTU.Nombor_Barcode = '" & barcodeEntry & "' AND PENGISYTIHARAN_E.Status = 'A'"
        'Response.Write(sqlText)
        'Response.End()
        Dim sqlreader As System.Data.SqlClient.SqlDataReader = opClass.DataReader(sqlText)
        If sqlreader.HasRows Then

            sqlreader.Read()
            NoKenderaan = sqlreader.GetValue(1)
            NoAgenPengangkutan = sqlreader.GetValue(2)
            CajMasuk = sqlreader.GetValue(4)
            Urusan = sqlreader.GetValue(3)
            NamaPegawai = sqlreader.GetValue(5)
            If Urusan.Trim() <> "" Then
                Barangan = Urusan.Replace("Eksport ", "")
            End If

        End If
        sqlreader.Close()
        sqlreader = Nothing

        'Get Invois ID
        Dim invois_id As String = ""
        sqlText = " select invois_id from tblnoinvois where no_barcode='" & barcodeEntry & "'"
        sqlreader = opClass.DataReader(sqlText)
        If sqlreader.HasRows Then

            sqlreader.Read()
            invois_id = sqlreader.GetValue(0)

        End If
        sqlreader.Close()
        sqlreader = Nothing

        'Response.Write("<br>EndQuery =" & Now())

        Dim formula As String = "{v_MasterSheetTop_Eksport.Nombor_Barcode} = '" & barcodeEntry & "'"
        'Response.Write(printer_name.Value)
     
        opClass.ConfigureCrystalReports_MSheet("rpt/Salinan-crMasterSheetExport_Top.rpt", formula, Request("invois_id"), "SALINAN LKIM-BUKIT KAYU HITAM", CajMasuk, NoKenderaan, NoAgenPengangkutan, Urusan, Barangan, NamaPegawai)
        CrystalReportViewer2.ReportSource = opClass.crMasterSheetEksport
        'opClass.crMasterSheetImport.PrintOptions.PrinterName = namaPrinter
        'opClass.crMasterSheetImport.PrintToPrinter(1, False, 0, 0)

        'Response.Write("<br>MS1 =" & Now())
        opClass.ConfigureCrystalReports_MSheet("rpt/Salinan-crMasterSheetExport_Top.rpt", formula, Request("invois_id"), "SALINAN AGEN PENGANGKUTAN", CajMasuk, NoKenderaan, NoAgenPengangkutan, Urusan, Barangan, NamaPegawai)
        CrystalReportViewer3.ReportSource = opClass.crMasterSheetEksport
        'opClass.crMasterSheetImport.PrintOptions.PrinterName = namaPrinter
        'opClass.crMasterSheetImport.PrintToPrinter(1, False, 0, 0)
        'Response.Write("<br>MS2 =" & Now())
        opClass.ConfigureCrystalReports_MSheet("rpt/Salinan-crMasterSheetExport_Top.rpt", formula, Request("invois_id"), "SALINAN CFC", CajMasuk, NoKenderaan, NoAgenPengangkutan, Urusan, Barangan, NamaPegawai)
        CrystalReportViewer4.ReportSource = opClass.crMasterSheetEksport
        'opClass.crMasterSheetImport.PrintOptions.PrinterName = namaPrinter
        'opClass.crMasterSheetImport.PrintToPrinter(1, False, 0, 0)
        'Response.Write("<br>MS3 =" & Now())
        ' added by zuraini on 27/06/2007

        opClass.ConfigureCrystalReports_MSheet("rpt/Salinan-crMasterSheetExport_Top.rpt", formula, Request("invois_id"), "SALINAN PENGUATKUASA", CajMasuk, NoKenderaan, NoAgenPengangkutan, Urusan, Barangan, NamaPegawai)
        CrystalReportViewer5.ReportSource = opClass.crMasterSheetEksport
        'opClass.crMasterSheetImport.PrintOptions.PrinterName = namaPrinter
        'opClass.crMasterSheetImport.PrintToPrinter(1, False, 0, 0)
        'Response.Write("<br>MS4 =" & Now())
    End Sub
End Class
