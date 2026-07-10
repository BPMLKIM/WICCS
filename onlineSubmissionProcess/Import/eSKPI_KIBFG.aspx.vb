Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalLibrary

Partial Class _Default
    Inherits System.Web.UI.Page

    Private crSKPI As ReportDocument
    Private masterSheet1 As ReportDocument
    Private masterSheet2 As ReportDocument
    Private masterSheet3 As ReportDocument
    Private masterSheet4 As ReportDocument

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
                  "PENDAFTARAN_PINTU.Nombor_Barcode, PENDAFTARAN_PINTU.Tarikh_Masa_Masuk, PENGISYTIHARAN_I_KIBFG.No_Kenderaan, " & _
                  "PENDAFTARAN_PINTU.Kod_Agen_Pengangkutan, JENIS_URUSAN.Nama_Urusan,PENDAFTARAN_PINTU.Caj_Masuk,PEGAWAI.Nama " & _
                  "FROM PENDAFTARAN_PINTU INNER JOIN " & _
                  "PENGISYTIHARAN_I_KIBFG ON PENDAFTARAN_PINTU.Nombor_Barcode = PENGISYTIHARAN_I_KIBFG.No_Barcode INNER JOIN " & _
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


        'Get Ringkasan Caj Information
        'Dim PetiBesarCajBiasaKg1 As String
        'Dim PetiKecilCajBiasaKg1 As String
        Dim PetiBesarCajBiasaKg As Double = 0
        Dim PetiKecilCajBiasaKg As Double = 0

        'sqlText = "SELECT ISNULL(SUM(PETIKECIL),0) AS PETIKECIL, ISNULL(SUM(PETIBESAR),0) AS PETIBESAR " & _
        '          "FROM v_GetMasterSheetCajBiasa_1_KIBFG " & _
        '          "WHERE NOMBOR_BARCODE='" & barcodeEntry & "' " & _
        '          "AND CAJ_IKAN_ID<10000 AND KOD_KATEGORI_IKAN IN(1,3)"

        sqlText = "select isnull(sum(convert(int,peti_biru_kecil)),0) as PETIKECIL, isnull(sum(convert(int,peti_biru_besar)),0) as PETIBESAR " & _
                  "from pengisytiharan_i_kibfg  " & _
                  "WHERE NO_BARCODE='" & barcodeEntry & "'"
        'sqlText = "select distinct(kod_pengimport),peti_biru_kecil as PETIKECIL, peti_biru_besar as PETIBESAR " & _
        '          "from pengisytiharan_i_kibfg  " & _
        '          "WHERE NO_BARCODE='" & barcodeEntry & "'"

        sqlreader = opClass.DataReader(sqlText)
        If sqlreader.HasRows Then
            sqlreader.Read()
            PetiBesarCajBiasaKg = sqlreader.GetValue(1)
            'PetiBesarCajBiasaKg = PetiBesarCajBiasaKg1
            PetiKecilCajBiasaKg = sqlreader.GetValue(0)
            'PetiKecilCajBiasaKg = PetiKecilCajBiasaKg1
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
                  "FROM v_GetMasterSheetCajBiasa_1_KIBFG WHERE NOMBOR_BARCODE='" & barcodeEntry & "' " & _
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
        '          "FROM v_GetMasterSheetCajBiasa_1_KIBFG " & _
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
                  "FROM v_GetMasterSheetCajBiasa_1_KIBFG " & _
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
                  "FROM v_GetMasterSheetCajBiasa_1_KIBFG " & _
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
                  "FROM v_GetMasterSheetCajBiasa_1_KIBFG  " & _
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


        Dim formula As String = "{PENGISYTIHARAN_I_KIBFG.No_Barcode} = '" & Request("barcode") & "' AND {PENGISYTIHARAN_I_KIBFG.Status} = 'A'"


        If Request("cetak") = "0" Then
            'Response.Write(printer_name.Value)

            'Dim namaPrinter As String = printer_name.Value '"KONICA MINOLTA 7145/IP-432" '
            'Response.Write("<br>StartReport SKPI =" & Now())

            'DropDownList1.DataSource = System.Drawing.Printing.PrinterSettings.InstalledPrinters
            'DropDownList1.DataBind()

            Dim myConnectionInfo As ConnectionInfo = New ConnectionInfo()
            myConnectionInfo.DatabaseName = System.Configuration.ConfigurationManager.AppSettings("dbname")
            myConnectionInfo.UserID = System.Configuration.ConfigurationManager.AppSettings("userid")
            myConnectionInfo.Password = System.Configuration.ConfigurationManager.AppSettings("dbpassword")
            myConnectionInfo.ServerName = System.Configuration.ConfigurationManager.AppSettings("servername")

            crSKPI = New ReportDocument()

            Dim reportPath As String = Server.MapPath("rpt/crSKPI_Kibfg.rpt")

            crSKPI.Load(reportPath)

            Dim selectFormula As String = formula '"{PENGISYTIHARAN_I.No_Barcode} = '" & Request("barcode") & "' AND {PENGISYTIHARAN_I.Status} = 'A'"
            crSKPI.DataDefinition.RecordSelectionFormula = selectFormula
            opClass.SetDBLogonForReport(myConnectionInfo, crSKPI)
            CrystalReportViewer1.ReportSource = crSKPI

            '"Remarks By Nizam"
            'opClass.ConfigureCrystalReportsSKPIPrint("rpt/crSKPI.rpt", formula)
            'CrystalReportViewer1.ReportSource = opClass.crSKPI
            'End Remarks            

            masterSheet1 = New ReportDocument()
            reportPath = Server.MapPath("rpt/crMasterSheetImport_Top_KIBFG.rpt")
            masterSheet1.Load(reportPath)
            'formula = "{v_MasterSheetTop_KIBFG.Nombor_Barcode} = '" & barcodeEntry & "'"
            formula = "{pengisytiharan_i_KIBFG.No_Barcode} = '" & barcodeEntry & "'"

            Dim Kira_peti_besar As String = PetiBesarCajBiasaKg.ToString() + " Peti Besar x $" + KdrPetiBesarCajBiasa.ToString()
            Dim Total_peti_besar As Double = PetiBesarCajBiasaKg * KdrPetiBesarCajBiasa

            Dim Kira_peti_kecil As String = PetiKecilCajBiasaKg.ToString() + " Peti Kecil x $" + KdrPetiKecilCajBiasa.ToString()
            Dim Total_peti_kecil As Double = PetiKecilCajBiasaKg * KdrPetiKecilCajBiasa

            Dim Kira_berat As String = KuantitiKg.ToString() + " Berat (Kg) x $" + KdrKuantitiCajBiasa.ToString()
            Dim Total_berat As Double = KuantitiKg * KdrKuantitiCajBiasa

            Dim Kira_ekor As String = Ekor.ToString() + " Ekor x $" + KdrEkorCajBiasa.ToString()
            Dim Total_ekor As Double = Ekor * KdrEkorCajBiasa


            masterSheet1.DataDefinition.FormulaFields("MS_NoInvois").Text = "'" & Request("invois_id") & "'"
            masterSheet1.DataDefinition.FormulaFields("MS_Salinan").Text = "'SALINAN LKIM'"
            masterSheet1.DataDefinition.FormulaFields("Caj_Masuk").Text = "'" & CajMasuk & "'"
            masterSheet1.DataDefinition.FormulaFields("Kira_peti_kecil").Text = "'" & Kira_peti_kecil & "'"
            masterSheet1.DataDefinition.FormulaFields("Total_peti_kecil").Text = "'" & Total_peti_kecil & "'"
            masterSheet1.DataDefinition.FormulaFields("Kira_peti_besar").Text = "'" & Kira_peti_besar & "'"
            masterSheet1.DataDefinition.FormulaFields("Total_peti_besar").Text = "'" & Total_peti_besar & "'"
            'masterSheet1.DataDefinition.FormulaFields("Kira_berat").Text = "'" & Kira_berat & "'"
            'masterSheet1.DataDefinition.FormulaFields("Total_berat").Text = "'" & Total_berat & "'"
            'masterSheet1.DataDefinition.FormulaFields("Kira_ekor").Text = "'" & Kira_ekor & "'"
            'masterSheet1.DataDefinition.FormulaFields("Total_ekor").Text = "'" & Total_ekor & "'"
            masterSheet1.DataDefinition.FormulaFields("tarikh_masa").Text = "'" & TarikhMasaMasuk & "'"
            masterSheet1.DataDefinition.FormulaFields("No_Kenderaan").Text = "'" & NoKenderaan & "'"
            masterSheet1.DataDefinition.FormulaFields("no_agen_pengangkutan").Text = "'" & NoAgenPengangkutan & "'"
            masterSheet1.DataDefinition.FormulaFields("urusan").Text = "'" & Urusan & "'"
            masterSheet1.DataDefinition.FormulaFields("barangan").Text = "'" & Barangan & "'"
            masterSheet1.DataDefinition.FormulaFields("Kurang_caj").Text = "'" & Kurang_caj & "'"
            masterSheet1.DataDefinition.FormulaFields("pegawai").Text = "'" & NamaPegawai & "'"
            masterSheet1.DataDefinition.RecordSelectionFormula = formula
            opClass.SetDBLogonForReport(myConnectionInfo, masterSheet1)
            opClass.SetDBLogonForSubreports(myConnectionInfo, masterSheet1)
            CrystalReportViewer2.ReportSource = masterSheet1


            'Response.Write("<br>StartReport 1 =" & Now())
            'opClass.ConfigureCrystalReports_MSheet("rpt/crMasterSheetImport_Top.rpt", formula, Request("invois_id"), "SALINAN LKIM-BUKIT KAYU HITAM", NoKenderaan, NoAgenPengangkutan, TarikhMasaMasuk, CajMasuk, Urusan, Barangan, PetiBesarCajBiasaKg, PetiKecilCajBiasaKg, KuantitiKg, Ekor, KdrPetiBesarCajBiasa, KdrPetiKecilCajBiasa, KdrKuantitiCajBiasa, KdrEkorCajBiasa, Kurang_caj, NamaPegawai)
            'CrystalReportViewer2.ReportSource = opClass.crMasterSheetImport
            'opClass.crMasterSheetImport.Close()
            'opClass.crMasterSheetImport.Dispose()
            'opClass.crMasterSheetImport.PrintOptions.PrinterName = namaPrinter
            'opClass.crMasterSheetImport.PrintToPrinter(1, False, 0, 0)
            'Response.Write("<br>End Report 1 =" & Now())


            masterSheet2 = New ReportDocument()
            masterSheet2.Load(reportPath)

            masterSheet2.DataDefinition.FormulaFields("MS_NoInvois").Text = "'" & Request("invois_id") & "'"
            masterSheet2.DataDefinition.FormulaFields("MS_Salinan").Text = "'SALINAN AGEN PENGANGKUTAN'"
            masterSheet2.DataDefinition.FormulaFields("Caj_Masuk").Text = "'" & CajMasuk & "'"
            masterSheet2.DataDefinition.FormulaFields("Kira_peti_kecil").Text = "'" & Kira_peti_kecil & "'"
            masterSheet2.DataDefinition.FormulaFields("Total_peti_kecil").Text = "'" & Total_peti_kecil & "'"
            masterSheet2.DataDefinition.FormulaFields("Kira_peti_besar").Text = "'" & Kira_peti_besar & "'"
            masterSheet2.DataDefinition.FormulaFields("Total_peti_besar").Text = "'" & Total_peti_besar & "'"
            'masterSheet2.DataDefinition.FormulaFields("Kira_berat").Text = "'" & Kira_berat & "'"
            'masterSheet2.DataDefinition.FormulaFields("Total_berat").Text = "'" & Total_berat & "'"
            'masterSheet2.DataDefinition.FormulaFields("Kira_ekor").Text = "'" & Kira_ekor & "'"
            'masterSheet2.DataDefinition.FormulaFields("Total_ekor").Text = "'" & Total_ekor & "'"
            masterSheet2.DataDefinition.FormulaFields("tarikh_masa").Text = "'" & TarikhMasaMasuk & "'"
            masterSheet2.DataDefinition.FormulaFields("No_Kenderaan").Text = "'" & NoKenderaan & "'"
            masterSheet2.DataDefinition.FormulaFields("no_agen_pengangkutan").Text = "'" & NoAgenPengangkutan & "'"
            masterSheet2.DataDefinition.FormulaFields("urusan").Text = "'" & Urusan & "'"
            masterSheet2.DataDefinition.FormulaFields("barangan").Text = "'" & Barangan & "'"
            masterSheet2.DataDefinition.FormulaFields("Kurang_caj").Text = "'" & Kurang_caj & "'"
            masterSheet2.DataDefinition.FormulaFields("pegawai").Text = "'" & NamaPegawai & "'"
            masterSheet2.DataDefinition.RecordSelectionFormula = formula
            opClass.SetDBLogonForReport(myConnectionInfo, masterSheet2)
            opClass.SetDBLogonForSubreports(myConnectionInfo, masterSheet2)
            CrystalReportViewer3.ReportSource = masterSheet2



            masterSheet3 = New ReportDocument()
            masterSheet3.Load(reportPath)

            masterSheet3.DataDefinition.FormulaFields("MS_NoInvois").Text = "'" & Request("invois_id") & "'"
            masterSheet3.DataDefinition.FormulaFields("MS_Salinan").Text = "'SALINAN PERSATUAN NELAYAN NEGERI'"
            masterSheet3.DataDefinition.FormulaFields("Caj_Masuk").Text = "'" & CajMasuk & "'"
            masterSheet3.DataDefinition.FormulaFields("Kira_peti_kecil").Text = "'" & Kira_peti_kecil & "'"
            masterSheet3.DataDefinition.FormulaFields("Total_peti_kecil").Text = "'" & Total_peti_kecil & "'"
            masterSheet3.DataDefinition.FormulaFields("Kira_peti_besar").Text = "'" & Kira_peti_besar & "'"
            masterSheet3.DataDefinition.FormulaFields("Total_peti_besar").Text = "'" & Total_peti_besar & "'"
            'masterSheet3.DataDefinition.FormulaFields("Kira_berat").Text = "'" & Kira_berat & "'"
            'masterSheet3.DataDefinition.FormulaFields("Total_berat").Text = "'" & Total_berat & "'"
            'masterSheet3.DataDefinition.FormulaFields("Kira_ekor").Text = "'" & Kira_ekor & "'"
            'masterSheet3.DataDefinition.FormulaFields("Total_ekor").Text = "'" & Total_ekor & "'"
            masterSheet3.DataDefinition.FormulaFields("tarikh_masa").Text = "'" & TarikhMasaMasuk & "'"
            masterSheet3.DataDefinition.FormulaFields("No_Kenderaan").Text = "'" & NoKenderaan & "'"
            masterSheet3.DataDefinition.FormulaFields("no_agen_pengangkutan").Text = "'" & NoAgenPengangkutan & "'"
            masterSheet3.DataDefinition.FormulaFields("urusan").Text = "'" & Urusan & "'"
            masterSheet3.DataDefinition.FormulaFields("barangan").Text = "'" & Barangan & "'"
            masterSheet3.DataDefinition.FormulaFields("Kurang_caj").Text = "'" & Kurang_caj & "'"
            masterSheet3.DataDefinition.FormulaFields("pegawai").Text = "'" & NamaPegawai & "'"
            masterSheet3.DataDefinition.RecordSelectionFormula = formula
            opClass.SetDBLogonForReport(myConnectionInfo, masterSheet3)
            opClass.SetDBLogonForSubreports(myConnectionInfo, masterSheet3)
            CrystalReportViewer4.ReportSource = masterSheet3

            masterSheet4 = New ReportDocument()
            masterSheet4.Load(reportPath)

            masterSheet4.DataDefinition.FormulaFields("MS_NoInvois").Text = "'" & Request("invois_id") & "'"
            masterSheet4.DataDefinition.FormulaFields("MS_Salinan").Text = "'SALINAN PENGUATKUASA'"
            masterSheet4.DataDefinition.FormulaFields("Caj_Masuk").Text = "'" & CajMasuk & "'"
            masterSheet4.DataDefinition.FormulaFields("Kira_peti_kecil").Text = "'" & Kira_peti_kecil & "'"
            masterSheet4.DataDefinition.FormulaFields("Total_peti_kecil").Text = "'" & Total_peti_kecil & "'"
            masterSheet4.DataDefinition.FormulaFields("Kira_peti_besar").Text = "'" & Kira_peti_besar & "'"
            masterSheet4.DataDefinition.FormulaFields("Total_peti_besar").Text = "'" & Total_peti_besar & "'"
            'masterSheet4.DataDefinition.FormulaFields("Kira_berat").Text = "'" & Kira_berat & "'"
            'masterSheet4.DataDefinition.FormulaFields("Total_berat").Text = "'" & Total_berat & "'"
            'masterSheet4.DataDefinition.FormulaFields("Kira_ekor").Text = "'" & Kira_ekor & "'"
            'masterSheet4.DataDefinition.FormulaFields("Total_ekor").Text = "'" & Total_ekor & "'"
            masterSheet4.DataDefinition.FormulaFields("tarikh_masa").Text = "'" & TarikhMasaMasuk & "'"
            masterSheet4.DataDefinition.FormulaFields("No_Kenderaan").Text = "'" & NoKenderaan & "'"
            masterSheet4.DataDefinition.FormulaFields("no_agen_pengangkutan").Text = "'" & NoAgenPengangkutan & "'"
            masterSheet4.DataDefinition.FormulaFields("urusan").Text = "'" & Urusan & "'"
            masterSheet4.DataDefinition.FormulaFields("barangan").Text = "'" & Barangan & "'"
            masterSheet4.DataDefinition.FormulaFields("Kurang_caj").Text = "'" & Kurang_caj & "'"
            masterSheet4.DataDefinition.FormulaFields("pegawai").Text = "'" & NamaPegawai & "'"
            masterSheet4.DataDefinition.RecordSelectionFormula = formula
            opClass.SetDBLogonForReport(myConnectionInfo, masterSheet4)
            opClass.SetDBLogonForSubreports(myConnectionInfo, masterSheet4)
            CrystalReportViewer5.ReportSource = masterSheet4

            'Response.Write("<br>StartReport 2 =" & Now())
            'opClass.ConfigureCrystalReports_MSheet("rpt/crMasterSheetImport_Top.rpt", formula, Request("invois_id"), "SALINAN AGEN PENGANGKUTAN", NoKenderaan, NoAgenPengangkutan, TarikhMasaMasuk, CajMasuk, Urusan, Barangan, PetiBesarCajBiasaKg, PetiKecilCajBiasaKg, KuantitiKg, Ekor, KdrPetiBesarCajBiasa, KdrPetiKecilCajBiasa, KdrKuantitiCajBiasa, KdrEkorCajBiasa, Kurang_caj, NamaPegawai)
            'CrystalReportViewer3.ReportSource = opClass.crMasterSheetImport
            'opClass.crMasterSheetImport.Close()
            'opClass.crMasterSheetImport.Dispose()
            'Response.Write("<br>End Report 2 =" & Now())
            'opClass.crMasterSheetImport.PrintOptions.PrinterName = namaPrinter
            'opClass.crMasterSheetImport.PrintToPrinter(1, False, 0, 0)

            'Response.Write("<br>Start Report 3 =" & Now())
            'opClass.ConfigureCrystalReports_MSheet("rpt/crMasterSheetImport_Top.rpt", formula, Request("invois_id"), "SALINAN NEKAD", NoKenderaan, NoAgenPengangkutan, TarikhMasaMasuk, CajMasuk, Urusan, Barangan, PetiBesarCajBiasaKg, PetiKecilCajBiasaKg, KuantitiKg, Ekor, KdrPetiBesarCajBiasa, KdrPetiKecilCajBiasa, KdrKuantitiCajBiasa, KdrEkorCajBiasa, Kurang_caj, NamaPegawai)
            'CrystalReportViewer4.ReportSource = opClass.crMasterSheetImport
            'opClass.crMasterSheetImport.Close()
            'opClass.crMasterSheetImport.Dispose()
            'opClass.crMasterSheetImport.PrintOptions.PrinterName = namaPrinter
            'opClass.crMasterSheetImport.PrintToPrinter(1, False, 0, 0)
            'Response.Write("<br>End Report 3 =" & Now())


            'Response.Write("<br>Start Report 4 =" & Now())
            'opClass.ConfigureCrystalReports_MSheet("rpt/crMasterSheetImport_Top.rpt", formula, Request("invois_id"), "SALINAN PENGUATKUASA", NoKenderaan, NoAgenPengangkutan, TarikhMasaMasuk, CajMasuk, Urusan, Barangan, PetiBesarCajBiasaKg, PetiKecilCajBiasaKg, KuantitiKg, Ekor, KdrPetiBesarCajBiasa, KdrPetiKecilCajBiasa, KdrKuantitiCajBiasa, KdrEkorCajBiasa, Kurang_caj, NamaPegawai)
            'CrystalReportViewer5.ReportSource = opClass.crMasterSheetImport
            'opClass.crMasterSheetImport.Close()
            'opClass.crMasterSheetImport.Dispose()
            'opClass.crMasterSheetImport.PrintOptions.PrinterName = namaPrinter
            'opClass.crMasterSheetImport.PrintToPrinter(1, False, 0, 0)
            'Response.Write("<br>End Report 4 =" & Now())

        ElseIf Request("cetak") = "1" Then

            cetak.Value = Request("cetak")
            Dim namaPrinter As String = Request("pname").Replace("/", "\") 'printer_name.Value '"KONICA MINOLTA 7145/IP-432" '
            'Response.Write(printer_name.Value)

            Dim myConnectionInfo As ConnectionInfo = New ConnectionInfo()
            myConnectionInfo.DatabaseName = System.Configuration.ConfigurationManager.AppSettings("dbname")
            myConnectionInfo.UserID = System.Configuration.ConfigurationManager.AppSettings("userid")
            myConnectionInfo.Password = System.Configuration.ConfigurationManager.AppSettings("dbpassword")
            myConnectionInfo.ServerName = System.Configuration.ConfigurationManager.AppSettings("servername")

            crSKPI = New ReportDocument()

            Dim reportPath As String = Server.MapPath("rpt/crSKPI_KIBFG.rpt")

            crSKPI.Load(reportPath)

            Dim selectFormula As String = formula '"{PENGISYTIHARAN_I.No_Barcode} = '" & Request("barcode") & "' AND {PENGISYTIHARAN_I.Status} = 'A'"
            crSKPI.DataDefinition.RecordSelectionFormula = selectFormula
            opClass.SetDBLogonForReport(myConnectionInfo, crSKPI)
            crSKPI.PrintOptions.PrinterName = namaPrinter
            crSKPI.PrintToPrinter(1, False, 0, 0)

           
            
            masterSheet1 = New ReportDocument()
            reportPath = Server.MapPath("rpt/crMasterSheetImport_Top_KIBFG.rpt")
            masterSheet1.Load(reportPath)
            formula = "{pengisytiharan_i_KIBFG.No_Barcode} = '" & barcodeEntry & "'"

            Dim Kira_peti_besar As String = PetiBesarCajBiasaKg.ToString() + " Peti Besar x $" + KdrPetiBesarCajBiasa.ToString()
            Dim Total_peti_besar As Double = PetiBesarCajBiasaKg * KdrPetiBesarCajBiasa

            Dim Kira_peti_kecil As String = PetiKecilCajBiasaKg.ToString() + " Peti Kecil x $" + KdrPetiKecilCajBiasa.ToString()
            Dim Total_peti_kecil As Double = PetiKecilCajBiasaKg * KdrPetiKecilCajBiasa

            Dim Kira_berat As String = KuantitiKg.ToString() + " Berat (Kg) x $" + KdrKuantitiCajBiasa.ToString()
            Dim Total_berat As Double = KuantitiKg * KdrKuantitiCajBiasa

            Dim Kira_ekor As String = Ekor.ToString() + " Ekor x $" + KdrEkorCajBiasa.ToString()
            Dim Total_ekor As Double = Ekor * KdrEkorCajBiasa


            masterSheet1.DataDefinition.FormulaFields("MS_NoInvois").Text = "'" & Request("invois_id") & "'"
            masterSheet1.DataDefinition.FormulaFields("MS_Salinan").Text = "'SALINAN LKIM'"
            masterSheet1.DataDefinition.FormulaFields("Caj_Masuk").Text = "'" & CajMasuk & "'"
            masterSheet1.DataDefinition.FormulaFields("Kira_peti_kecil").Text = "'" & Kira_peti_kecil & "'"
            masterSheet1.DataDefinition.FormulaFields("Total_peti_kecil").Text = "'" & Total_peti_kecil & "'"
            masterSheet1.DataDefinition.FormulaFields("Kira_peti_besar").Text = "'" & Kira_peti_besar & "'"
            masterSheet1.DataDefinition.FormulaFields("Total_peti_besar").Text = "'" & Total_peti_besar & "'"
            'masterSheet1.DataDefinition.FormulaFields("Kira_berat").Text = "'" & Kira_berat & "'"
            'masterSheet1.DataDefinition.FormulaFields("Total_berat").Text = "'" & Total_berat & "'"
            'masterSheet1.DataDefinition.FormulaFields("Kira_ekor").Text = "'" & Kira_ekor & "'"
            'masterSheet1.DataDefinition.FormulaFields("Total_ekor").Text = "'" & Total_ekor & "'"
            masterSheet1.DataDefinition.FormulaFields("tarikh_masa").Text = "'" & TarikhMasaMasuk & "'"
            masterSheet1.DataDefinition.FormulaFields("No_Kenderaan").Text = "'" & NoKenderaan & "'"
            masterSheet1.DataDefinition.FormulaFields("no_agen_pengangkutan").Text = "'" & NoAgenPengangkutan & "'"
            masterSheet1.DataDefinition.FormulaFields("urusan").Text = "'" & Urusan & "'"
            masterSheet1.DataDefinition.FormulaFields("barangan").Text = "'" & Barangan & "'"
            masterSheet1.DataDefinition.FormulaFields("Kurang_caj").Text = "'" & Kurang_caj & "'"
            masterSheet1.DataDefinition.FormulaFields("pegawai").Text = "'" & NamaPegawai & "'"
            masterSheet1.DataDefinition.RecordSelectionFormula = formula
            opClass.SetDBLogonForReport(myConnectionInfo, masterSheet1)
            opClass.SetDBLogonForSubreports(myConnectionInfo, masterSheet1)
            masterSheet1.PrintOptions.PrinterName = namaPrinter
            masterSheet1.PrintToPrinter(1, False, 0, 0)


            ' '' ''Response.Write("<br>StartReport 1 =" & Now())
            'opClass.ConfigureCrystalReports_MSheet("rpt/crMasterSheetImport_Top.rpt", formula, Request("invois_id"), "SALINAN LKIM-BUKIT KAYU HITAM", NoKenderaan, NoAgenPengangkutan, TarikhMasaMasuk, CajMasuk, Urusan, Barangan, PetiBesarCajBiasaKg, PetiKecilCajBiasaKg, KuantitiKg, Ekor, KdrPetiBesarCajBiasa, KdrPetiKecilCajBiasa, KdrKuantitiCajBiasa, KdrEkorCajBiasa, Kurang_caj, NamaPegawai)
            'CrystalReportViewer2.ReportSource = opClass.crMasterSheetImport
            'opClass.crMasterSheetImport.Close()
            'opClass.crMasterSheetImport.Dispose()
            'opClass.crMasterSheetImport.PrintOptions.PrinterName = namaPrinter
            'opClass.crMasterSheetImport.PrintToPrinter(1, False, 0, 0)
            'Response.Write("<br>End Report 1 =" & Now())


            masterSheet2 = New ReportDocument()
            masterSheet2.Load(reportPath)

            masterSheet2.DataDefinition.FormulaFields("MS_NoInvois").Text = "'" & Request("invois_id") & "'"
            masterSheet2.DataDefinition.FormulaFields("MS_Salinan").Text = "'SALINAN AGEN PENGANGKUTAN'"
            masterSheet2.DataDefinition.FormulaFields("Caj_Masuk").Text = "'" & CajMasuk & "'"
            masterSheet2.DataDefinition.FormulaFields("Kira_peti_kecil").Text = "'" & Kira_peti_kecil & "'"
            masterSheet2.DataDefinition.FormulaFields("Total_peti_kecil").Text = "'" & Total_peti_kecil & "'"
            masterSheet2.DataDefinition.FormulaFields("Kira_peti_besar").Text = "'" & Kira_peti_besar & "'"
            masterSheet2.DataDefinition.FormulaFields("Total_peti_besar").Text = "'" & Total_peti_besar & "'"
            'masterSheet2.DataDefinition.FormulaFields("Kira_berat").Text = "'" & Kira_berat & "'"
            'masterSheet2.DataDefinition.FormulaFields("Total_berat").Text = "'" & Total_berat & "'"
            'masterSheet2.DataDefinition.FormulaFields("Kira_ekor").Text = "'" & Kira_ekor & "'"
            'masterSheet2.DataDefinition.FormulaFields("Total_ekor").Text = "'" & Total_ekor & "'"
            masterSheet2.DataDefinition.FormulaFields("tarikh_masa").Text = "'" & TarikhMasaMasuk & "'"
            masterSheet2.DataDefinition.FormulaFields("No_Kenderaan").Text = "'" & NoKenderaan & "'"
            masterSheet2.DataDefinition.FormulaFields("no_agen_pengangkutan").Text = "'" & NoAgenPengangkutan & "'"
            masterSheet2.DataDefinition.FormulaFields("urusan").Text = "'" & Urusan & "'"
            masterSheet2.DataDefinition.FormulaFields("barangan").Text = "'" & Barangan & "'"
            masterSheet2.DataDefinition.FormulaFields("Kurang_caj").Text = "'" & Kurang_caj & "'"
            masterSheet2.DataDefinition.FormulaFields("pegawai").Text = "'" & NamaPegawai & "'"
            masterSheet2.DataDefinition.RecordSelectionFormula = formula
            opClass.SetDBLogonForReport(myConnectionInfo, masterSheet2)
            opClass.SetDBLogonForSubreports(myConnectionInfo, masterSheet2)
            masterSheet2.PrintOptions.PrinterName = namaPrinter
            masterSheet2.PrintToPrinter(1, False, 0, 0)



            masterSheet3 = New ReportDocument()
            masterSheet3.Load(reportPath)

            masterSheet3.DataDefinition.FormulaFields("MS_NoInvois").Text = "'" & Request("invois_id") & "'"
            masterSheet3.DataDefinition.FormulaFields("MS_Salinan").Text = "'SALINAN PERSATUAN NELAYAN NEGERI'"
            masterSheet3.DataDefinition.FormulaFields("Caj_Masuk").Text = "'" & CajMasuk & "'"
            masterSheet3.DataDefinition.FormulaFields("Kira_peti_kecil").Text = "'" & Kira_peti_kecil & "'"
            masterSheet3.DataDefinition.FormulaFields("Total_peti_kecil").Text = "'" & Total_peti_kecil & "'"
            masterSheet3.DataDefinition.FormulaFields("Kira_peti_besar").Text = "'" & Kira_peti_besar & "'"
            masterSheet3.DataDefinition.FormulaFields("Total_peti_besar").Text = "'" & Total_peti_besar & "'"
            'masterSheet3.DataDefinition.FormulaFields("Kira_berat").Text = "'" & Kira_berat & "'"
            'masterSheet3.DataDefinition.FormulaFields("Total_berat").Text = "'" & Total_berat & "'"
            'masterSheet3.DataDefinition.FormulaFields("Kira_ekor").Text = "'" & Kira_ekor & "'"
            'masterSheet3.DataDefinition.FormulaFields("Total_ekor").Text = "'" & Total_ekor & "'"
            masterSheet3.DataDefinition.FormulaFields("tarikh_masa").Text = "'" & TarikhMasaMasuk & "'"
            masterSheet3.DataDefinition.FormulaFields("No_Kenderaan").Text = "'" & NoKenderaan & "'"
            masterSheet3.DataDefinition.FormulaFields("no_agen_pengangkutan").Text = "'" & NoAgenPengangkutan & "'"
            masterSheet3.DataDefinition.FormulaFields("urusan").Text = "'" & Urusan & "'"
            masterSheet3.DataDefinition.FormulaFields("barangan").Text = "'" & Barangan & "'"
            masterSheet3.DataDefinition.FormulaFields("Kurang_caj").Text = "'" & Kurang_caj & "'"
            masterSheet3.DataDefinition.FormulaFields("pegawai").Text = "'" & NamaPegawai & "'"
            masterSheet3.DataDefinition.RecordSelectionFormula = formula
            opClass.SetDBLogonForReport(myConnectionInfo, masterSheet3)
            opClass.SetDBLogonForSubreports(myConnectionInfo, masterSheet3)
            masterSheet3.PrintOptions.PrinterName = namaPrinter
            masterSheet3.PrintToPrinter(1, False, 0, 0)

            masterSheet4 = New ReportDocument()
            masterSheet4.Load(reportPath)

            masterSheet4.DataDefinition.FormulaFields("MS_NoInvois").Text = "'" & Request("invois_id") & "'"
            masterSheet4.DataDefinition.FormulaFields("MS_Salinan").Text = "'SALINAN PENGUATKUASA'"
            masterSheet4.DataDefinition.FormulaFields("Caj_Masuk").Text = "'" & CajMasuk & "'"
            masterSheet4.DataDefinition.FormulaFields("Kira_peti_kecil").Text = "'" & Kira_peti_kecil & "'"
            masterSheet4.DataDefinition.FormulaFields("Total_peti_kecil").Text = "'" & Total_peti_kecil & "'"
            masterSheet4.DataDefinition.FormulaFields("Kira_peti_besar").Text = "'" & Kira_peti_besar & "'"
            masterSheet4.DataDefinition.FormulaFields("Total_peti_besar").Text = "'" & Total_peti_besar & "'"
            'masterSheet4.DataDefinition.FormulaFields("Kira_berat").Text = "'" & Kira_berat & "'"
            'masterSheet4.DataDefinition.FormulaFields("Total_berat").Text = "'" & Total_berat & "'"
            'masterSheet4.DataDefinition.FormulaFields("Kira_ekor").Text = "'" & Kira_ekor & "'"
            'masterSheet4.DataDefinition.FormulaFields("Total_ekor").Text = "'" & Total_ekor & "'"
            masterSheet4.DataDefinition.FormulaFields("tarikh_masa").Text = "'" & TarikhMasaMasuk & "'"
            masterSheet4.DataDefinition.FormulaFields("No_Kenderaan").Text = "'" & NoKenderaan & "'"
            masterSheet4.DataDefinition.FormulaFields("no_agen_pengangkutan").Text = "'" & NoAgenPengangkutan & "'"
            masterSheet4.DataDefinition.FormulaFields("urusan").Text = "'" & Urusan & "'"
            masterSheet4.DataDefinition.FormulaFields("barangan").Text = "'" & Barangan & "'"
            masterSheet4.DataDefinition.FormulaFields("Kurang_caj").Text = "'" & Kurang_caj & "'"
            masterSheet4.DataDefinition.FormulaFields("pegawai").Text = "'" & NamaPegawai & "'"
            masterSheet4.DataDefinition.RecordSelectionFormula = formula
            opClass.SetDBLogonForReport(myConnectionInfo, masterSheet4)
            opClass.SetDBLogonForSubreports(myConnectionInfo, masterSheet4)
            masterSheet4.PrintOptions.PrinterName = namaPrinter
            masterSheet4.PrintToPrinter(1, False, 0, 0)

       

        End If

    End Sub
 


    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        crSKPI.Close()
        crSKPI.Dispose()
        masterSheet1.Close()
        masterSheet1.Dispose()
        masterSheet2.Close()
        masterSheet2.Dispose()
        masterSheet3.Close()
        masterSheet3.Dispose()
        masterSheet4.Close()
        masterSheet4.Dispose()
        GC.SuppressFinalize(True)
        GC.Collect()
        
    End Sub
End Class
