Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class _Default_kibfg2
    Inherits System.Web.UI.Page
    Private crMSsheet1 As ReportDocument
    Private crMSsheet2 As ReportDocument
    Private crMSsheet3 As ReportDocument
    Private crMSsheet4 As ReportDocument
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
                  "PENDAFTARAN_PINTU.Nombor_Barcode, PENDAFTARAN_PINTU.Tarikh_Masa_Masuk, PENGISYTIHARAN_I_kibfg.No_Kenderaan, " & _
                  "PENDAFTARAN_PINTU.Kod_Agen_Pengangkutan, JENIS_URUSAN.Nama_Urusan,PENDAFTARAN_PINTU.Caj_Masuk,PEGAWAI.Nama " & _
                  "FROM PENDAFTARAN_PINTU INNER JOIN " & _
                  "PENGISYTIHARAN_I_kibfg ON PENDAFTARAN_PINTU.Nombor_Barcode = PENGISYTIHARAN_I_kibfg.No_Barcode INNER JOIN " & _
                  "JENIS_URUSAN ON PENDAFTARAN_PINTU.Kod_Jenis_Urusan = JENIS_URUSAN.Kod_Urusan INNER JOIN " & _
                  "PEGAWAI ON PEGAWAI.KATA_PENGGUNA = PENGISYTIHARAN_I_KIBFG.Nama_Pegawai " & _
                  "WHERE PENDAFTARAN_PINTU.Nombor_Barcode = '" & barcodeEntry & "' AND PENGISYTIHARAN_I_KIBFG.Status = 'A'"
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

        sqlText = "select isnull(sum(convert(int,peti_biru_kecil)),0) as PETIKECIL, isnull(sum(convert(int,peti_biru_besar)),0) as PETIBESAR " & _
                  "from pengisytiharan_i_kibfg  " & _
                  "WHERE NO_BARCODE='" & barcodeEntry & "'"

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
                  "FROM v_GetMasterSheetCajBiasa_1_KIBFG WHERE NOMBOR_BARCODE='" & barcodeEntry & "' " & _
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
                  "FROM v_GetMasterSheetCajBiasa_1_kibfg WHERE NOMBOR_BARCODE='" & barcodeEntry & "' " & _
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
        'sqlText = "SELECT DISTINCT KADAR_PETI_KECIL,KADAR_PETI_BESAR " & _
        '          "FROM v_GetMasterSheetCajBiasa_1_kibfg " & _
        '          "WHERE NOMBOR_BARCODE='" & barcodeEntry & "' " & _
        '          "AND CAJ_IKAN_ID<10000 AND KOD_KATEGORI_IKAN IN(1,3)"
        sqlText = "select distinct kadar_peti_kecil,kadar_peti_besar from ikan_caj_kibfg " & _
                "WHERE id='1' "

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
                  "FROM v_GetMasterSheetCajBiasa_1_kibfg " & _
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
                  "FROM v_GetMasterSheetCajBiasa_1_kibfg " & _
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
                  "FROM v_GetMasterSheetCajBiasa_1_kibfg " & _
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
        Dim myConnectionInfo As ConnectionInfo = New ConnectionInfo()
        myConnectionInfo.DatabaseName = System.Configuration.ConfigurationManager.AppSettings("dbname")
        myConnectionInfo.UserID = System.Configuration.ConfigurationManager.AppSettings("userid")
        myConnectionInfo.Password = System.Configuration.ConfigurationManager.AppSettings("dbpassword")
        myConnectionInfo.ServerName = System.Configuration.ConfigurationManager.AppSettings("servername")

        Dim Kira_peti_besar As String = PetiBesarCajBiasaKg.ToString() + " Peti Besar x $" + KdrPetiBesarCajBiasa.ToString()
        Dim Total_peti_besar As Double = PetiBesarCajBiasaKg * KdrPetiBesarCajBiasa

        Dim Kira_peti_kecil As String = PetiKecilCajBiasaKg.ToString() + " Peti Kecil x $" + KdrPetiKecilCajBiasa.ToString()
        Dim Total_peti_kecil As Double = PetiKecilCajBiasaKg * KdrPetiKecilCajBiasa

        Dim Kira_berat As String = KuantitiKg.ToString() + " Berat (Kg) x $" + KdrKuantitiCajBiasa.ToString()
        Dim Total_berat As Double = KuantitiKg * KdrKuantitiCajBiasa

        Dim Kira_ekor As String = Ekor.ToString() + " Ekor x $" + KdrEkorCajBiasa.ToString()
        Dim Total_ekor As Double = Ekor * KdrEkorCajBiasa

        Dim formula = "{pengisytiharan_i_KIBFG.No_Barcode} = '" & barcodeEntry & "'"

        crMSsheet1 = New ReportDocument()
        Dim reportPath As String = Server.MapPath("rpt/crMasterSheetImport_Top_KIBFG.rpt")
        crMSsheet1.Load(reportPath)

        crMSsheet1.DataDefinition.FormulaFields("MS_NoInvois").Text = "'" & invois_id & "'"
        crMSsheet1.DataDefinition.FormulaFields("MS_Salinan").Text = "'SALINAN LKIM'"
        crMSsheet1.DataDefinition.FormulaFields("Caj_Masuk").Text = "'" & CajMasuk & "'"
        crMSsheet1.DataDefinition.FormulaFields("Kira_peti_kecil").Text = "'" & Kira_peti_kecil & "'"
        crMSsheet1.DataDefinition.FormulaFields("Total_peti_kecil").Text = "'" & Total_peti_kecil & "'"
        crMSsheet1.DataDefinition.FormulaFields("Kira_peti_besar").Text = "'" & Kira_peti_besar & "'"
        crMSsheet1.DataDefinition.FormulaFields("Total_peti_besar").Text = "'" & Total_peti_besar & "'"
        'crMSsheet1.DataDefinition.FormulaFields("Kira_berat").Text = "'" & Kira_berat & "'"
        'crMSsheet1.DataDefinition.FormulaFields("Total_berat").Text = "'" & Total_berat & "'"
        'crMSsheet1.DataDefinition.FormulaFields("Kira_ekor").Text = "'" & Kira_ekor & "'"
        'crMSsheet1.DataDefinition.FormulaFields("Total_ekor").Text = "'" & Total_ekor & "'"
        crMSsheet1.DataDefinition.FormulaFields("tarikh_masa").Text = "'" & TarikhMasaMasuk & "'"
        crMSsheet1.DataDefinition.FormulaFields("No_Kenderaan").Text = "'" & NoKenderaan & "'"
        crMSsheet1.DataDefinition.FormulaFields("no_agen_pengangkutan").Text = "'" & NoAgenPengangkutan & "'"
        crMSsheet1.DataDefinition.FormulaFields("urusan").Text = "'" & Urusan & "'"
        crMSsheet1.DataDefinition.FormulaFields("barangan").Text = "'" & Barangan & "'"
        crMSsheet1.DataDefinition.FormulaFields("Kurang_caj").Text = "'" & Kurang_caj & "'"
        crMSsheet1.DataDefinition.FormulaFields("pegawai").Text = "'" & NamaPegawai & "'"
        crMSsheet1.DataDefinition.RecordSelectionFormula = formula
        opClass.SetDBLogonForReport(myConnectionInfo, crMSsheet1)
        opClass.SetDBLogonForSubreports(myConnectionInfo, crMSsheet1)
        CrystalReportViewer1.ReportSource = crMSsheet1

        crMSsheet2 = New ReportDocument()
        'Dim reportPath As String = Server.MapPath("rpt/Salinan-crMasterSheetImport_Top.rpt")
        crMSsheet2.Load(reportPath)

        crMSsheet2.DataDefinition.FormulaFields("MS_NoInvois").Text = "'" & invois_id & "'"
        crMSsheet2.DataDefinition.FormulaFields("MS_Salinan").Text = "'SALINAN AGEN PENGANGKUTAN'"
        crMSsheet2.DataDefinition.FormulaFields("Caj_Masuk").Text = "'" & CajMasuk & "'"
        crMSsheet2.DataDefinition.FormulaFields("Kira_peti_kecil").Text = "'" & Kira_peti_kecil & "'"
        crMSsheet2.DataDefinition.FormulaFields("Total_peti_kecil").Text = "'" & Total_peti_kecil & "'"
        crMSsheet2.DataDefinition.FormulaFields("Kira_peti_besar").Text = "'" & Kira_peti_besar & "'"
        crMSsheet2.DataDefinition.FormulaFields("Total_peti_besar").Text = "'" & Total_peti_besar & "'"
        'crMSsheet2.DataDefinition.FormulaFields("Kira_berat").Text = "'" & Kira_berat & "'"
        'crMSsheet2.DataDefinition.FormulaFields("Total_berat").Text = "'" & Total_berat & "'"
        'crMSsheet2.DataDefinition.FormulaFields("Kira_ekor").Text = "'" & Kira_ekor & "'"
        'crMSsheet2.DataDefinition.FormulaFields("Total_ekor").Text = "'" & Total_ekor & "'"
        crMSsheet2.DataDefinition.FormulaFields("tarikh_masa").Text = "'" & TarikhMasaMasuk & "'"
        crMSsheet2.DataDefinition.FormulaFields("No_Kenderaan").Text = "'" & NoKenderaan & "'"
        crMSsheet2.DataDefinition.FormulaFields("no_agen_pengangkutan").Text = "'" & NoAgenPengangkutan & "'"
        crMSsheet2.DataDefinition.FormulaFields("urusan").Text = "'" & Urusan & "'"
        crMSsheet2.DataDefinition.FormulaFields("barangan").Text = "'" & Barangan & "'"
        crMSsheet2.DataDefinition.FormulaFields("Kurang_caj").Text = "'" & Kurang_caj & "'"
        crMSsheet2.DataDefinition.FormulaFields("pegawai").Text = "'" & NamaPegawai & "'"
        crMSsheet2.DataDefinition.RecordSelectionFormula = formula
        opClass.SetDBLogonForReport(myConnectionInfo, crMSsheet2)
        opClass.SetDBLogonForSubreports(myConnectionInfo, crMSsheet2)
        CrystalReportViewer2.ReportSource = crMSsheet2


        crMSsheet3 = New ReportDocument()
        'Dim reportPath As String = Server.MapPath("rpt/Salinan-crMasterSheetImport_Top.rpt")
        crMSsheet3.Load(reportPath)

        crMSsheet3.DataDefinition.FormulaFields("MS_NoInvois").Text = "'" & invois_id & "'"
        crMSsheet3.DataDefinition.FormulaFields("MS_Salinan").Text = "'SALINAN PERSATUAN NELAYAN NEGERI'"
        crMSsheet3.DataDefinition.FormulaFields("Caj_Masuk").Text = "'" & CajMasuk & "'"
        crMSsheet3.DataDefinition.FormulaFields("Kira_peti_kecil").Text = "'" & Kira_peti_kecil & "'"
        crMSsheet3.DataDefinition.FormulaFields("Total_peti_kecil").Text = "'" & Total_peti_kecil & "'"
        crMSsheet3.DataDefinition.FormulaFields("Kira_peti_besar").Text = "'" & Kira_peti_besar & "'"
        crMSsheet3.DataDefinition.FormulaFields("Total_peti_besar").Text = "'" & Total_peti_besar & "'"
        'crMSsheet3.DataDefinition.FormulaFields("Kira_berat").Text = "'" & Kira_berat & "'"
        'crMSsheet3.DataDefinition.FormulaFields("Total_berat").Text = "'" & Total_berat & "'"
        'crMSsheet3.DataDefinition.FormulaFields("Kira_ekor").Text = "'" & Kira_ekor & "'"
        'crMSsheet3.DataDefinition.FormulaFields("Total_ekor").Text = "'" & Total_ekor & "'"
        crMSsheet3.DataDefinition.FormulaFields("tarikh_masa").Text = "'" & TarikhMasaMasuk & "'"
        crMSsheet3.DataDefinition.FormulaFields("No_Kenderaan").Text = "'" & NoKenderaan & "'"
        crMSsheet3.DataDefinition.FormulaFields("no_agen_pengangkutan").Text = "'" & NoAgenPengangkutan & "'"
        crMSsheet3.DataDefinition.FormulaFields("urusan").Text = "'" & Urusan & "'"
        crMSsheet3.DataDefinition.FormulaFields("barangan").Text = "'" & Barangan & "'"
        crMSsheet3.DataDefinition.FormulaFields("Kurang_caj").Text = "'" & Kurang_caj & "'"
        crMSsheet3.DataDefinition.FormulaFields("pegawai").Text = "'" & NamaPegawai & "'"
        crMSsheet3.DataDefinition.RecordSelectionFormula = formula
        opClass.SetDBLogonForReport(myConnectionInfo, crMSsheet3)
        opClass.SetDBLogonForSubreports(myConnectionInfo, crMSsheet3)
        CrystalReportViewer3.ReportSource = crMSsheet3

        crMSsheet4 = New ReportDocument()
        'Dim reportPath As String = Server.MapPath("rpt/Salinan-crMasterSheetImport_Top.rpt")
        crMSsheet4.Load(reportPath)

        crMSsheet4.DataDefinition.FormulaFields("MS_NoInvois").Text = "'" & invois_id & "'"
        crMSsheet4.DataDefinition.FormulaFields("MS_Salinan").Text = "'SALINAN PENGUATKUASA'"
        crMSsheet4.DataDefinition.FormulaFields("Caj_Masuk").Text = "'" & CajMasuk & "'"
        crMSsheet4.DataDefinition.FormulaFields("Kira_peti_kecil").Text = "'" & Kira_peti_kecil & "'"
        crMSsheet4.DataDefinition.FormulaFields("Total_peti_kecil").Text = "'" & Total_peti_kecil & "'"
        crMSsheet4.DataDefinition.FormulaFields("Kira_peti_besar").Text = "'" & Kira_peti_besar & "'"
        crMSsheet4.DataDefinition.FormulaFields("Total_peti_besar").Text = "'" & Total_peti_besar & "'"
        'crMSsheet4.DataDefinition.FormulaFields("Kira_berat").Text = "'" & Kira_berat & "'"
        'crMSsheet4.DataDefinition.FormulaFields("Total_berat").Text = "'" & Total_berat & "'"
        'crMSsheet4.DataDefinition.FormulaFields("Kira_ekor").Text = "'" & Kira_ekor & "'"
        'crMSsheet4.DataDefinition.FormulaFields("Total_ekor").Text = "'" & Total_ekor & "'"
        crMSsheet4.DataDefinition.FormulaFields("tarikh_masa").Text = "'" & TarikhMasaMasuk & "'"
        crMSsheet4.DataDefinition.FormulaFields("No_Kenderaan").Text = "'" & NoKenderaan & "'"
        crMSsheet4.DataDefinition.FormulaFields("no_agen_pengangkutan").Text = "'" & NoAgenPengangkutan & "'"
        crMSsheet4.DataDefinition.FormulaFields("urusan").Text = "'" & Urusan & "'"
        crMSsheet4.DataDefinition.FormulaFields("barangan").Text = "'" & Barangan & "'"
        crMSsheet4.DataDefinition.FormulaFields("Kurang_caj").Text = "'" & Kurang_caj & "'"
        crMSsheet4.DataDefinition.FormulaFields("pegawai").Text = "'" & NamaPegawai & "'"
        crMSsheet4.DataDefinition.RecordSelectionFormula = formula
        opClass.SetDBLogonForReport(myConnectionInfo, crMSsheet4)
        opClass.SetDBLogonForSubreports(myConnectionInfo, crMSsheet4)
        CrystalReportViewer4.ReportSource = crMSsheet4

        'Response.Write("<br>StartReport 1 =" & Now())
        'opClass.ConfigureCrystalReports_MSheet("rpt/Salinan-crMasterSheetImport_Top.rpt", formula, invois_id, "SALINAN LKIM-BUKIT KAYU HITAM", NoKenderaan, NoAgenPengangkutan, TarikhMasaMasuk, CajMasuk, Urusan, Barangan, PetiBesarCajBiasaKg, PetiKecilCajBiasaKg, KuantitiKg, Ekor, KdrPetiBesarCajBiasa, KdrPetiKecilCajBiasa, KdrKuantitiCajBiasa, KdrEkorCajBiasa, Kurang_caj, NamaPegawai)
        'CrystalReportViewer2.ReportSource = opClass.crMasterSheetImport
        'opClass.crMasterSheetImport.Close()
        'opClass.crMasterSheetImport.Dispose()
        'opClass.crMasterSheetImport.PrintOptions.PrinterName = namaPrinter
        'opClass.crMasterSheetImport.PrintToPrinter(1, False, 0, 0)
        'Response.Write("<br>End Report 1 =" & Now())

        'Response.Write("<br>StartReport 2 =" & Now())
        'opClass.ConfigureCrystalReports_MSheet("rpt/Salinan-crMasterSheetImport_Top.rpt", formula, Request("invois_id"), "SALINAN AGEN PENGANGKUTAN", NoKenderaan, NoAgenPengangkutan, TarikhMasaMasuk, CajMasuk, Urusan, Barangan, PetiBesarCajBiasaKg, PetiKecilCajBiasaKg, KuantitiKg, Ekor, KdrPetiBesarCajBiasa, KdrPetiKecilCajBiasa, KdrKuantitiCajBiasa, KdrEkorCajBiasa, Kurang_caj, NamaPegawai)
        'CrystalReportViewer3.ReportSource = opClass.crMasterSheetImport
        'opClass.crMasterSheetImport.Close()
        'opClass.crMasterSheetImport.Dispose()
        'Response.Write("<br>End Report 2 =" & Now())
        'opClass.crMasterSheetImport.PrintOptions.PrinterName = namaPrinter
        'opClass.crMasterSheetImport.PrintToPrinter(1, False, 0, 0)

        'Response.Write("<br>Start Report 3 =" & Now())
        'opClass.ConfigureCrystalReports_MSheet("rpt/Salinan-crMasterSheetImport_Top.rpt", formula, invois_id, "SALINAN CFC", NoKenderaan, NoAgenPengangkutan, TarikhMasaMasuk, CajMasuk, Urusan, Barangan, PetiBesarCajBiasaKg, PetiKecilCajBiasaKg, KuantitiKg, Ekor, KdrPetiBesarCajBiasa, KdrPetiKecilCajBiasa, KdrKuantitiCajBiasa, KdrEkorCajBiasa, Kurang_caj, NamaPegawai)
        'CrystalReportViewer4.ReportSource = opClass.crMasterSheetImport
        'opClass.crMasterSheetImport.Close()
        'opClass.crMasterSheetImport.Dispose()
        'opClass.crMasterSheetImport.PrintOptions.PrinterName = namaPrinter
        'opClass.crMasterSheetImport.PrintToPrinter(1, False, 0, 0)
        'Response.Write("<br>End Report 3 =" & Now())


        'Response.Write("<br>Start Report 4 =" & Now())
        'opClass.ConfigureCrystalReports_MSheet("rpt/Salinan-crMasterSheetImport_Top.rpt", formula, invois_id, "SALINAN PENGUATKUASA", NoKenderaan, NoAgenPengangkutan, TarikhMasaMasuk, CajMasuk, Urusan, Barangan, PetiBesarCajBiasaKg, PetiKecilCajBiasaKg, KuantitiKg, Ekor, KdrPetiBesarCajBiasa, KdrPetiKecilCajBiasa, KdrKuantitiCajBiasa, KdrEkorCajBiasa, Kurang_caj, NamaPegawai)
        'CrystalReportViewer5.ReportSource = opClass.crMasterSheetImport
        'opClass.crMasterSheetImport.Close()
        'opClass.crMasterSheetImport.Dispose()
        'opClass.crMasterSheetImport.PrintOptions.PrinterName = namaPrinter
        'opClass.crMasterSheetImport.PrintToPrinter(1, False, 0, 0)
        'Response.Write("<br>End Report 4 =" & Now())

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        crMSsheet1.Close()
        crMSsheet1.Dispose()
        crMSsheet2.Close()
        crMSsheet2.Dispose()
        crMSsheet3.Close()
        crMSsheet3.Dispose()
        crMSsheet4.Close()
        crMSsheet4.Dispose()
        GC.SuppressFinalize(True)
        GC.Collect()
    End Sub
End Class
