Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class _Default
    Inherits System.Web.UI.Page
    Private crSKPI As ReportDocument
    Protected opClass As SQLOperation

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        opClass = New SQLOperation()
        opClass.dbConnection()

        Dim barcodeEntry As String = Request("barcode")
        Dim sqlText As String = ""
        Dim NoKenderaan As String = ""
        Dim NoAgenPengangkutan As String = ""
        Dim TarikhMasaMasuk As String = ""
        Dim Urusan As String = ""
        Dim Barangan As String = ""
        Dim CajMasuk As String = ""
        Dim NamaPegawai As String = ""

        ' Response.Write("StarQuery=" & Now())

        
        'Get Information For Invoice Top Report Information

        sqlText = "SELECT DISTINCT " & _
                  "PENDAFTARAN_PINTU.Nombor_Barcode, PENDAFTARAN_PINTU.Tarikh_Masa_Masuk, PENGISYTIHARAN_I.No_Kenderaan, " & _
                  "PENDAFTARAN_PINTU.Kod_Agen_Pengangkutan, JENIS_URUSAN.Nama_Urusan,PENDAFTARAN_PINTU.Caj_Masuk,PEGAWAI.Nama " & _
                  "FROM PENDAFTARAN_PINTU INNER JOIN " & _
                  "PENGISYTIHARAN_I ON PENDAFTARAN_PINTU.Nombor_Barcode = PENGISYTIHARAN_I.No_Barcode INNER JOIN " & _
                  "JENIS_URUSAN ON PENDAFTARAN_PINTU.Kod_Jenis_Urusan = JENIS_URUSAN.Kod_Urusan INNER JOIN " & _
                  "PEGAWAI ON PEGAWAI.KATA_PENGGUNA = PENGISYTIHARAN_I.Nama_Pegawai " & _
                  "WHERE PENDAFTARAN_PINTU.Nombor_Barcode = '" & barcodeEntry & "' AND PENGISYTIHARAN_I.Status = 'A'"
        'Response.Write(sqlText)
        'Response.End()
        Dim sqlreader As System.Data.SqlClient.SqlDataReader = opClass.DataReader(sqlText)
        If sqlreader.HasRows Then

            sqlreader.Read()
            NoKenderaan = sqlreader.GetValue(2)
            NoAgenPengangkutan = sqlreader.GetValue(3)
            TarikhMasaMasuk = sqlreader.GetValue(1)
            CajMasuk = sqlreader.GetValue(5)
            Urusan = sqlreader.GetValue(4)
            NamaPegawai = sqlreader.GetValue(6)

            If Urusan.Trim() <> "" Then
                Barangan = Urusan.Replace("Import ", "")
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

        'Get Ringkasan Caj Information

        Dim PetiBesarCajBiasaKg As Double = 0
        Dim PetiKecilCajBiasaKg As Double = 0

        sqlText = "SELECT ISNULL(SUM(PETIKECIL),0) AS PETIKECIL, ISNULL(SUM(PETIBESAR),0) AS PETIBESAR " & _
                  "FROM v_GetMasterSheetCajBiasa_1 " & _
                  "WHERE NOMBOR_BARCODE='" & barcodeEntry & "' " & _
                  "AND CAJ_IKAN_ID<10000 AND KOD_KATEGORI_IKAN IN(1,3)"

        sqlreader = opClass.DataReader(sqlText)
        If sqlreader.HasRows Then
            sqlreader.Read()
            PetiBesarCajBiasaKg = sqlreader.GetValue(1)
            PetiKecilCajBiasaKg = sqlreader.GetValue(0)
        End If
        sqlreader.Close()
        sqlreader = Nothing

        Dim KuantitiKg As Double = 0

        sqlText = "SELECT ISNULL(SUM(KUANTITIKECIL),0) + ISNULL(SUM(KUANTITIBESAR),0) AS KUANTITI " & _
                  "FROM v_GetMasterSheetCajBiasa_1 WHERE NOMBOR_BARCODE='" & barcodeEntry & "' " & _
                  "AND CAJ_IKAN_ID<10000 AND KOD_KATEGORI_IKAN NOT IN(1,3) AND KADAR_KUANTITI>0"

        sqlreader = opClass.DataReader(sqlText)
        If sqlreader.HasRows Then
            sqlreader.Read()
            KuantitiKg = sqlreader.GetValue(0)
        End If
        sqlreader.Close()
        sqlreader = Nothing


        Dim Ekor As Double = 0

        sqlText = "SELECT ISNULL(SUM(EKOR),0) AS EKOR " & _
                  "FROM v_GetMasterSheetCajBiasa_1 WHERE NOMBOR_BARCODE='" & barcodeEntry & "' " & _
                  "AND CAJ_IKAN_ID<10000 AND KOD_KATEGORI_IKAN NOT IN(1,3) AND KADAR_EKOR>0"

        sqlreader = opClass.DataReader(sqlText)
        If sqlreader.HasRows Then
            sqlreader.Read()
            Ekor = sqlreader.GetValue(0)
        End If
        sqlreader.Close()
        sqlreader = Nothing


        Dim KdrPetiBesarCajBiasa As Double = 0
        Dim KdrPetiKecilCajBiasa As Double = 0
        sqlText = "SELECT DISTINCT KADAR_PETI_KECIL,KADAR_PETI_BESAR " & _
                  "FROM v_GetMasterSheetCajBiasa_1 " & _
                  "WHERE NOMBOR_BARCODE='" & barcodeEntry & "' " & _
                  "AND CAJ_IKAN_ID<10000 AND KOD_KATEGORI_IKAN IN(1,3)"

        sqlreader = opClass.DataReader(sqlText)
        If sqlreader.HasRows Then
            sqlreader.Read()
            KdrPetiBesarCajBiasa = sqlreader.GetValue(1)
            KdrPetiKecilCajBiasa = sqlreader.GetValue(0)
        End If
        sqlreader.Close()
        sqlreader = Nothing


        Dim KdrKuantitiCajBiasa As Double = 0
        sqlText = "SELECT DISTINCT KADAR_KUANTITI " & _
                  "FROM v_GetMasterSheetCajBiasa_1 " & _
                  "WHERE NOMBOR_BARCODE='" & barcodeEntry & "' " & _
                  "AND CAJ_IKAN_ID<10000 AND KOD_KATEGORI_IKAN NOT IN(1,3) " & _
                  "AND KADAR_KUANTITI>0 "
        sqlreader = opClass.DataReader(sqlText)
        If sqlreader.HasRows Then
            sqlreader.Read()
            KdrKuantitiCajBiasa = sqlreader.GetValue(0)
        End If
        sqlreader.Close()
        sqlreader = Nothing

        Dim KdrEkorCajBiasa As Double = 0
        sqlText = "SELECT DISTINCT KADAR_EKOR " & _
                  "FROM v_GetMasterSheetCajBiasa_1 " & _
                  "WHERE NOMBOR_BARCODE='" & barcodeEntry & "' " & _
                  "AND CAJ_IKAN_ID<10000 AND KOD_KATEGORI_IKAN NOT IN(1,3) " & _
                  "AND KADAR_EKOR>0 "
        sqlreader = opClass.DataReader(sqlText)
        If sqlreader.HasRows Then
            sqlreader.Read()
            KdrEkorCajBiasa = sqlreader.GetValue(0)
        End If
        sqlreader.Close()
        sqlreader = Nothing


        'Verify sama ada rec pengurangan caj atau tidak
        Dim Kurang_caj As Integer = 0
        sqlText = "SELECT nombor_barcode " & _
                  "FROM v_GetMasterSheetCajBiasa_1  " & _
                  "WHERE NOMBOR_BARCODE='" & barcodeEntry & "' " & _
                  "AND CAJ_IKAN_ID>=10000 "
        sqlreader = opClass.DataReader(sqlText)
        If sqlreader.HasRows Then
            Kurang_caj = 1
        End If
        sqlreader.Close()
        sqlreader = Nothing

        'Response.Write("<br>EndQuery =" & Now())

        'Response.End()

        'PetiBesarCajBiasaKg, PetiKecilCajBiasaKg, KuantitiKg, Ekor, KdrPetiBesarCajBiasa, KdrPetiKecilCajBiasa, KdrKuantitiCajBiasa, KdrEkorCajBiasa

        '=====================================================================
        'Ready To Load Report Processing
        '=====================================================================


        Dim formula As String = "{v_MasterSheetTop.Nombor_Barcode} = '" & barcodeEntry & "'"

        'Response.Write("<br>StartReport 1 =" & Now())
        opClass.ConfigureCrystalReports_MSheet("rpt/crMasterSheetImport_Top.rpt", formula, invois_id, "SALINAN LKIM-BUKIT KAYU HITAM", NoKenderaan, NoAgenPengangkutan, TarikhMasaMasuk, CajMasuk, Urusan, Barangan, PetiBesarCajBiasaKg, PetiKecilCajBiasaKg, KuantitiKg, Ekor, KdrPetiBesarCajBiasa, KdrPetiKecilCajBiasa, KdrKuantitiCajBiasa, KdrEkorCajBiasa, Kurang_caj, NamaPegawai)
        CrystalReportViewer2.ReportSource = opClass.crMasterSheetImport
        'opClass.crMasterSheetImport.PrintOptions.PrinterName = namaPrinter
        'opClass.crMasterSheetImport.PrintToPrinter(1, False, 0, 0)
        'Response.Write("<br>End Report 1 =" & Now())

        'Response.Write("<br>StartReport 2 =" & Now())
        opClass.ConfigureCrystalReports_MSheet("rpt/crMasterSheetImport_Top.rpt", formula, Request("invois_id"), "SALINAN AGEN PENGANGKUTAN", NoKenderaan, NoAgenPengangkutan, TarikhMasaMasuk, CajMasuk, Urusan, Barangan, PetiBesarCajBiasaKg, PetiKecilCajBiasaKg, KuantitiKg, Ekor, KdrPetiBesarCajBiasa, KdrPetiKecilCajBiasa, KdrKuantitiCajBiasa, KdrEkorCajBiasa, Kurang_caj, NamaPegawai)
        CrystalReportViewer3.ReportSource = opClass.crMasterSheetImport
        'Response.Write("<br>End Report 2 =" & Now())
        'opClass.crMasterSheetImport.PrintOptions.PrinterName = namaPrinter
        'opClass.crMasterSheetImport.PrintToPrinter(1, False, 0, 0)

        'Response.Write("<br>Start Report 3 =" & Now())
        opClass.ConfigureCrystalReports_MSheet("rpt/crMasterSheetImport_Top.rpt", formula, invois_id, "SALINAN CFC", NoKenderaan, NoAgenPengangkutan, TarikhMasaMasuk, CajMasuk, Urusan, Barangan, PetiBesarCajBiasaKg, PetiKecilCajBiasaKg, KuantitiKg, Ekor, KdrPetiBesarCajBiasa, KdrPetiKecilCajBiasa, KdrKuantitiCajBiasa, KdrEkorCajBiasa, Kurang_caj, NamaPegawai)
        CrystalReportViewer4.ReportSource = opClass.crMasterSheetImport
        'opClass.crMasterSheetImport.PrintOptions.PrinterName = namaPrinter
        'opClass.crMasterSheetImport.PrintToPrinter(1, False, 0, 0)
        'Response.Write("<br>End Report 3 =" & Now())


        'Response.Write("<br>Start Report 4 =" & Now())
        opClass.ConfigureCrystalReports_MSheet("rpt/crMasterSheetImport_Top.rpt", formula, invois_id, "SALINAN PENGUATKUASA", NoKenderaan, NoAgenPengangkutan, TarikhMasaMasuk, CajMasuk, Urusan, Barangan, PetiBesarCajBiasaKg, PetiKecilCajBiasaKg, KuantitiKg, Ekor, KdrPetiBesarCajBiasa, KdrPetiKecilCajBiasa, KdrKuantitiCajBiasa, KdrEkorCajBiasa, Kurang_caj, NamaPegawai)
        CrystalReportViewer5.ReportSource = opClass.crMasterSheetImport
        'opClass.crMasterSheetImport.PrintOptions.PrinterName = namaPrinter
        'opClass.crMasterSheetImport.PrintToPrinter(1, False, 0, 0)
        'Response.Write("<br>End Report 4 =" & Now())



    End Sub
 


End Class
