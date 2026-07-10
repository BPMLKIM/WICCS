Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class _Default
    Inherits System.Web.UI.Page
    Private crSKPE As ReportDocument
    Private crMasterSheetEksport1 As ReportDocument
    Private crMasterSheetEksport2 As ReportDocument
    Private crMasterSheetEksport3 As ReportDocument
    Private crMasterSheetEksport4 As ReportDocument
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


        'edited by kmz for caj eksport
        Dim TarikhMasaMasuk As String = ""

        'Response.Write("StarQuery=" & Now())
        'Get Information For Invoice Top Report Information
        sqlText = "SELECT DISTINCT " & _
                  "PENDAFTARAN_PINTU.Nombor_Barcode, PENGISYTIHARAN_E.No_Kenderaan, " & _
                  "PENDAFTARAN_PINTU.Kod_Agen_Pengangkutan, JENIS_URUSAN.Nama_Urusan,PENDAFTARAN_PINTU.Caj_Masuk,PEGAWAI.Nama,PENDAFTARAN_PINTU.Tarikh_Masa_Masuk " & _
                  "FROM PENDAFTARAN_PINTU INNER JOIN " & _
                  "PENGISYTIHARAN_E ON PENDAFTARAN_PINTU.Nombor_Barcode = PENGISYTIHARAN_E.No_Barcode INNER JOIN " & _
                  "JENIS_URUSAN ON PENDAFTARAN_PINTU.Kod_Jenis_Urusan = JENIS_URUSAN.Kod_Urusan INNER JOIN " & _
                  "PEGAWAI ON PEGAWAI.KATA_PENGGUNA = PENGISYTIHARAN_E.Nama_Pegawai " & _
                  "WHERE PENDAFTARAN_PINTU.Nombor_Barcode = '" & barcodeEntry & "' AND PENGISYTIHARAN_E.Status = 'A'"
        'end of edited by kmz for caj eksport

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

        'Response.Write("<br>EndQuery =" & Now())

        'edited by kmz for caj eksport
        'Get Ringkasan Caj Information

        Dim PetiBesarCajBiasaKg As Double = 0
        Dim PetiKecilCajBiasaKg As Double = 0

        sqlText = "SELECT ISNULL(SUM(PETIKECIL),0) AS PETIKECIL, ISNULL(SUM(PETIBESAR),0) AS PETIBESAR " & _
                  "FROM v_GetMasterSheetEksportCajBiasa_1 " & _
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
                  "FROM v_GetMasterSheetEksportCajBiasa_1 WHERE NOMBOR_BARCODE='" & barcodeEntry & "' " & _
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
                  "FROM v_GetMasterSheetEksportCajBiasa_1 WHERE NOMBOR_BARCODE='" & barcodeEntry & "' " & _
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
                  "FROM v_GetMasterSheetEksportCajBiasa_1 " & _
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
                  "FROM v_GetMasterSheetEksportCajBiasa_1 " & _
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
                  "FROM v_GetMasterSheetEksportCajBiasa_1 " & _
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
                  "FROM v_GetMasterSheetEksportCajBiasa_1  " & _
                  "WHERE NOMBOR_BARCODE='" & barcodeEntry & "' " & _
                  "AND CAJ_IKAN_ID>=10000 "
        sqlreader = opClass.DataReader(sqlText)
        If sqlreader.HasRows Then
            Kurang_caj = 1
        End If
        sqlreader.Close()
        sqlreader = Nothing
        'end of edited by kmz for caj eksport


        Dim myConnectionInfo As ConnectionInfo = New ConnectionInfo()
        myConnectionInfo.DatabaseName = System.Configuration.ConfigurationManager.AppSettings("dbname")
        myConnectionInfo.UserID = System.Configuration.ConfigurationManager.AppSettings("userid")
        myConnectionInfo.Password = System.Configuration.ConfigurationManager.AppSettings("dbpassword")
        myConnectionInfo.ServerName = System.Configuration.ConfigurationManager.AppSettings("servername")


        Dim formula As String = "{PENGISYTIHARAN_I.No_Barcode} = '" & Request("barcode") & "' AND {PENGISYTIHARAN_I.Status} = 'A'"
        'Response.Write(printer_name.Value)

        'edited by kmz for caj eksport
        Dim Kira_peti_besar As String = PetiBesarCajBiasaKg.ToString() + " Peti Besar x $" + KdrPetiBesarCajBiasa.ToString()
        Dim Total_peti_besar As Double = PetiBesarCajBiasaKg * KdrPetiBesarCajBiasa

        Dim Kira_peti_kecil As String = PetiKecilCajBiasaKg.ToString() + " Peti Kecil x $" + KdrPetiKecilCajBiasa.ToString()
        Dim Total_peti_kecil As Double = PetiKecilCajBiasaKg * KdrPetiKecilCajBiasa

        Dim Kira_berat As String = KuantitiKg.ToString() + " Berat (Kg) x $" + KdrKuantitiCajBiasa.ToString()
        Dim Total_berat As Double = KuantitiKg * KdrKuantitiCajBiasa

        Dim Kira_ekor As String = Ekor.ToString() + " Ekor x $" + KdrEkorCajBiasa.ToString()
        Dim Total_ekor As Double = Ekor * KdrEkorCajBiasa
        'end of edited by kmz for caj eksport

        If Request("cetak") = "0" Then

            crSKPE = New ReportDocument()
            Dim reportPath As String = Server.MapPath("rpt/crSKPE.rpt")
            crSKPE.Load(reportPath)
            crSKPE.DataDefinition.RecordSelectionFormula = formula
            opClass.SetDBLogonForReport(myConnectionInfo, crSKPE)
            CrystalReportViewer1.ReportSource = crSKPE


            'MasterSheet Process Viewer

            'formula = "{v_MasterSheetTop_Eksport.Nombor_Barcode} = '" & barcodeEntry & "'"

            'crMasterSheetEksport1 = New ReportDocument()

            'reportPath = Server.MapPath("rpt/crMasterSheetExport_Top.rpt")

            'crMasterSheetEksport1.Load(reportPath)
            'crMasterSheetEksport1.DataDefinition.FormulaFields("MS_NoInvois").Text = "'" & Request("invois_id") & "'"
            'crMasterSheetEksport1.DataDefinition.FormulaFields("MS_Salinan").Text = "'SALINAN LKIM'"
            'crMasterSheetEksport1.DataDefinition.FormulaFields("Caj_Masuk").Text = "'" & CajMasuk & "'"
            'crMasterSheetEksport1.DataDefinition.FormulaFields("No_Kenderaan").Text = "'" & NoKenderaan & "'"
            'crMasterSheetEksport1.DataDefinition.FormulaFields("no_agen_pengangkutan").Text = "'" & NoAgenPengangkutan & "'"
            'crMasterSheetEksport1.DataDefinition.FormulaFields("urusan").Text = "'" & Urusan & "'"
            'crMasterSheetEksport1.DataDefinition.FormulaFields("barangan").Text = "'" & Barangan & "'"
            'crMasterSheetEksport1.DataDefinition.FormulaFields("Kurang_caj").Text = "'" & Kurang_caj & "'"
            'crMasterSheetEksport1.DataDefinition.FormulaFields("pegawai").Text = "'" & NamaPegawai & "'"

            ''edited by kmz for caj eksport
            'crMasterSheetEksport1.DataDefinition.FormulaFields("Caj_Masuk").Text = "'" & CajMasuk & "'"
            'crMasterSheetEksport1.DataDefinition.FormulaFields("Kira_peti_kecil").Text = "'" & Kira_peti_kecil & "'"
            'crMasterSheetEksport1.DataDefinition.FormulaFields("Total_peti_kecil").Text = "'" & Total_peti_kecil & "'"
            'crMasterSheetEksport1.DataDefinition.FormulaFields("Kira_peti_besar").Text = "'" & Kira_peti_besar & "'"
            'crMasterSheetEksport1.DataDefinition.FormulaFields("Total_peti_besar").Text = "'" & Total_peti_besar & "'"
            'crMasterSheetEksport1.DataDefinition.FormulaFields("Kira_berat").Text = "'" & Kira_berat & "'"
            'crMasterSheetEksport1.DataDefinition.FormulaFields("Total_berat").Text = "'" & Total_berat & "'"
            'crMasterSheetEksport1.DataDefinition.FormulaFields("Kira_ekor").Text = "'" & Kira_ekor & "'"
            'crMasterSheetEksport1.DataDefinition.FormulaFields("Total_ekor").Text = "'" & Total_ekor & "'"
            'crMasterSheetEksport1.DataDefinition.FormulaFields("tarikh_masa").Text = "'" & TarikhMasaMasuk & "'"
            ''end of edited by kmz for caj eksport

            'crMasterSheetEksport1.DataDefinition.RecordSelectionFormula = formula
            'opClass.SetDBLogonForReport(myConnectionInfo, crMasterSheetEksport1)
            'opClass.SetDBLogonForSubreports(myConnectionInfo, crMasterSheetEksport1)
            'CrystalReportViewer2.ReportSource = crMasterSheetEksport1


            'crMasterSheetEksport2 = New ReportDocument()
            'crMasterSheetEksport2.Load(reportPath)
            'crMasterSheetEksport2.DataDefinition.FormulaFields("MS_NoInvois").Text = "'" & Request("invois_id") & "'"
            'crMasterSheetEksport2.DataDefinition.FormulaFields("MS_Salinan").Text = "'SALINAN AGEN PENGANGKUTAN'"
            'crMasterSheetEksport2.DataDefinition.FormulaFields("Caj_Masuk").Text = "'" & CajMasuk & "'"
            'crMasterSheetEksport2.DataDefinition.FormulaFields("No_Kenderaan").Text = "'" & NoKenderaan & "'"
            'crMasterSheetEksport2.DataDefinition.FormulaFields("no_agen_pengangkutan").Text = "'" & NoAgenPengangkutan & "'"
            'crMasterSheetEksport2.DataDefinition.FormulaFields("urusan").Text = "'" & Urusan & "'"
            'crMasterSheetEksport2.DataDefinition.FormulaFields("barangan").Text = "'" & Barangan & "'"
            'crMasterSheetEksport2.DataDefinition.FormulaFields("Kurang_caj").Text = "'" & Kurang_caj & "'"
            'crMasterSheetEksport2.DataDefinition.FormulaFields("pegawai").Text = "'" & NamaPegawai & "'"

            ''edited by kmz for caj eksport
            'crMasterSheetEksport2.DataDefinition.FormulaFields("Caj_Masuk").Text = "'" & CajMasuk & "'"
            'crMasterSheetEksport2.DataDefinition.FormulaFields("Kira_peti_kecil").Text = "'" & Kira_peti_kecil & "'"
            'crMasterSheetEksport2.DataDefinition.FormulaFields("Total_peti_kecil").Text = "'" & Total_peti_kecil & "'"
            'crMasterSheetEksport2.DataDefinition.FormulaFields("Kira_peti_besar").Text = "'" & Kira_peti_besar & "'"
            'crMasterSheetEksport2.DataDefinition.FormulaFields("Total_peti_besar").Text = "'" & Total_peti_besar & "'"
            'crMasterSheetEksport2.DataDefinition.FormulaFields("Kira_berat").Text = "'" & Kira_berat & "'"
            'crMasterSheetEksport2.DataDefinition.FormulaFields("Total_berat").Text = "'" & Total_berat & "'"
            'crMasterSheetEksport2.DataDefinition.FormulaFields("Kira_ekor").Text = "'" & Kira_ekor & "'"
            'crMasterSheetEksport2.DataDefinition.FormulaFields("Total_ekor").Text = "'" & Total_ekor & "'"
            'crMasterSheetEksport2.DataDefinition.FormulaFields("tarikh_masa").Text = "'" & TarikhMasaMasuk & "'"
            ''end of edited by kmz for caj eksport

            'crMasterSheetEksport2.DataDefinition.RecordSelectionFormula = formula
            'opClass.SetDBLogonForReport(myConnectionInfo, crMasterSheetEksport2)
            'opClass.SetDBLogonForSubreports(myConnectionInfo, crMasterSheetEksport2)
            'CrystalReportViewer3.ReportSource = crMasterSheetEksport2

            'crMasterSheetEksport3 = New ReportDocument()
            'crMasterSheetEksport3.Load(reportPath)
            'crMasterSheetEksport3.DataDefinition.FormulaFields("MS_NoInvois").Text = "'" & Request("invois_id") & "'"
            'crMasterSheetEksport3.DataDefinition.FormulaFields("MS_Salinan").Text = "'SALINAN PERSATUAN NELAYAN NEGERI'"
            'crMasterSheetEksport3.DataDefinition.FormulaFields("Caj_Masuk").Text = "'" & CajMasuk & "'"
            'crMasterSheetEksport3.DataDefinition.FormulaFields("No_Kenderaan").Text = "'" & NoKenderaan & "'"
            'crMasterSheetEksport3.DataDefinition.FormulaFields("no_agen_pengangkutan").Text = "'" & NoAgenPengangkutan & "'"
            'crMasterSheetEksport3.DataDefinition.FormulaFields("urusan").Text = "'" & Urusan & "'"
            'crMasterSheetEksport3.DataDefinition.FormulaFields("barangan").Text = "'" & Barangan & "'"
            'crMasterSheetEksport3.DataDefinition.FormulaFields("Kurang_caj").Text = "'" & Kurang_caj & "'"
            'crMasterSheetEksport3.DataDefinition.FormulaFields("pegawai").Text = "'" & NamaPegawai & "'"

            ''edited by kmz for caj eksport
            'crMasterSheetEksport3.DataDefinition.FormulaFields("Caj_Masuk").Text = "'" & CajMasuk & "'"
            'crMasterSheetEksport3.DataDefinition.FormulaFields("Kira_peti_kecil").Text = "'" & Kira_peti_kecil & "'"
            'crMasterSheetEksport3.DataDefinition.FormulaFields("Total_peti_kecil").Text = "'" & Total_peti_kecil & "'"
            'crMasterSheetEksport3.DataDefinition.FormulaFields("Kira_peti_besar").Text = "'" & Kira_peti_besar & "'"
            'crMasterSheetEksport3.DataDefinition.FormulaFields("Total_peti_besar").Text = "'" & Total_peti_besar & "'"
            'crMasterSheetEksport3.DataDefinition.FormulaFields("Kira_berat").Text = "'" & Kira_berat & "'"
            'crMasterSheetEksport3.DataDefinition.FormulaFields("Total_berat").Text = "'" & Total_berat & "'"
            'crMasterSheetEksport3.DataDefinition.FormulaFields("Kira_ekor").Text = "'" & Kira_ekor & "'"
            'crMasterSheetEksport3.DataDefinition.FormulaFields("Total_ekor").Text = "'" & Total_ekor & "'"
            'crMasterSheetEksport3.DataDefinition.FormulaFields("tarikh_masa").Text = "'" & TarikhMasaMasuk & "'"
            ''end of edited by kmz for caj eksport

            'crMasterSheetEksport3.DataDefinition.RecordSelectionFormula = formula
            'opClass.SetDBLogonForReport(myConnectionInfo, crMasterSheetEksport3)
            'opClass.SetDBLogonForSubreports(myConnectionInfo, crMasterSheetEksport3)
            'CrystalReportViewer4.ReportSource = crMasterSheetEksport3

            'crMasterSheetEksport4 = New ReportDocument()
            'crMasterSheetEksport4.Load(reportPath)
            'crMasterSheetEksport4.DataDefinition.FormulaFields("MS_NoInvois").Text = "'" & Request("invois_id") & "'"
            'crMasterSheetEksport4.DataDefinition.FormulaFields("MS_Salinan").Text = "'SALINAN PENGUATKUASA'"
            'crMasterSheetEksport4.DataDefinition.FormulaFields("Caj_Masuk").Text = "'" & CajMasuk & "'"
            'crMasterSheetEksport4.DataDefinition.FormulaFields("No_Kenderaan").Text = "'" & NoKenderaan & "'"
            'crMasterSheetEksport4.DataDefinition.FormulaFields("no_agen_pengangkutan").Text = "'" & NoAgenPengangkutan & "'"
            'crMasterSheetEksport4.DataDefinition.FormulaFields("urusan").Text = "'" & Urusan & "'"
            'crMasterSheetEksport4.DataDefinition.FormulaFields("barangan").Text = "'" & Barangan & "'"
            'crMasterSheetEksport4.DataDefinition.FormulaFields("Kurang_caj").Text = "'" & Kurang_caj & "'"
            'crMasterSheetEksport4.DataDefinition.FormulaFields("pegawai").Text = "'" & NamaPegawai & "'"

            ''edited by kmz for caj eksport
            'crMasterSheetEksport4.DataDefinition.FormulaFields("Caj_Masuk").Text = "'" & CajMasuk & "'"
            'crMasterSheetEksport4.DataDefinition.FormulaFields("Kira_peti_kecil").Text = "'" & Kira_peti_kecil & "'"
            'crMasterSheetEksport4.DataDefinition.FormulaFields("Total_peti_kecil").Text = "'" & Total_peti_kecil & "'"
            'crMasterSheetEksport4.DataDefinition.FormulaFields("Kira_peti_besar").Text = "'" & Kira_peti_besar & "'"
            'crMasterSheetEksport4.DataDefinition.FormulaFields("Total_peti_besar").Text = "'" & Total_peti_besar & "'"
            'crMasterSheetEksport4.DataDefinition.FormulaFields("Kira_berat").Text = "'" & Kira_berat & "'"
            'crMasterSheetEksport4.DataDefinition.FormulaFields("Total_berat").Text = "'" & Total_berat & "'"
            'crMasterSheetEksport4.DataDefinition.FormulaFields("Kira_ekor").Text = "'" & Kira_ekor & "'"
            'crMasterSheetEksport4.DataDefinition.FormulaFields("Total_ekor").Text = "'" & Total_ekor & "'"
            'crMasterSheetEksport4.DataDefinition.FormulaFields("tarikh_masa").Text = "'" & TarikhMasaMasuk & "'"
            ''end of edited by kmz for caj eksport

            'crMasterSheetEksport4.DataDefinition.RecordSelectionFormula = formula
            'opClass.SetDBLogonForReport(myConnectionInfo, crMasterSheetEksport4)
            'opClass.SetDBLogonForSubreports(myConnectionInfo, crMasterSheetEksport4)
            'CrystalReportViewer5.ReportSource = crMasterSheetEksport4

            
        ElseIf Request("cetak") = "1" Then

            cetak.Value = Request("cetak")
            Dim namaPrinter As String = Request("pname").Replace("/", "\") 'printer_name.Value '"KONICA MINOLTA 7145/IP-432" '

            crSKPE = New ReportDocument()
            Dim reportPath As String = Server.MapPath("rpt/crSKPE.rpt")
            crSKPE.Load(reportPath)
            crSKPE.DataDefinition.RecordSelectionFormula = formula
            opClass.SetDBLogonForReport(myConnectionInfo, crSKPE)
            CrystalReportViewer1.Visible = False
            crSKPE.PrintOptions.PrinterName = namaPrinter
            crSKPE.PrintToPrinter(1, False, 0, 0)



            'MasterSheet Process Viewer

            'formula = "{v_MasterSheetTop_Eksport.Nombor_Barcode} = '" & barcodeEntry & "'"

            'crMasterSheetEksport1 = New ReportDocument()

            'reportPath = Server.MapPath("rpt/crMasterSheetExport_Top.rpt")

            'crMasterSheetEksport1.Load(reportPath)
            'crMasterSheetEksport1.DataDefinition.FormulaFields("MS_NoInvois").Text = "'" & Request("invois_id") & "'"
            'crMasterSheetEksport1.DataDefinition.FormulaFields("MS_Salinan").Text = "'SALINAN LKIM'"
            'crMasterSheetEksport1.DataDefinition.FormulaFields("Caj_Masuk").Text = "'" & CajMasuk & "'"
            'crMasterSheetEksport1.DataDefinition.FormulaFields("No_Kenderaan").Text = "'" & NoKenderaan & "'"
            'crMasterSheetEksport1.DataDefinition.FormulaFields("no_agen_pengangkutan").Text = "'" & NoAgenPengangkutan & "'"
            'crMasterSheetEksport1.DataDefinition.FormulaFields("urusan").Text = "'" & Urusan & "'"
            'crMasterSheetEksport1.DataDefinition.FormulaFields("barangan").Text = "'" & Barangan & "'"
            'crMasterSheetEksport1.DataDefinition.FormulaFields("Kurang_caj").Text = "'" & Kurang_caj & "'"
            'crMasterSheetEksport1.DataDefinition.FormulaFields("pegawai").Text = "'" & NamaPegawai & "'"

            ''edited by kmz for caj eksport
            'crMasterSheetEksport1.DataDefinition.FormulaFields("Caj_Masuk").Text = "'" & CajMasuk & "'"
            'crMasterSheetEksport1.DataDefinition.FormulaFields("Kira_peti_kecil").Text = "'" & Kira_peti_kecil & "'"
            'crMasterSheetEksport1.DataDefinition.FormulaFields("Total_peti_kecil").Text = "'" & Total_peti_kecil & "'"
            'crMasterSheetEksport1.DataDefinition.FormulaFields("Kira_peti_besar").Text = "'" & Kira_peti_besar & "'"
            'crMasterSheetEksport1.DataDefinition.FormulaFields("Total_peti_besar").Text = "'" & Total_peti_besar & "'"
            'crMasterSheetEksport1.DataDefinition.FormulaFields("Kira_berat").Text = "'" & Kira_berat & "'"
            'crMasterSheetEksport1.DataDefinition.FormulaFields("Total_berat").Text = "'" & Total_berat & "'"
            'crMasterSheetEksport1.DataDefinition.FormulaFields("Kira_ekor").Text = "'" & Kira_ekor & "'"
            'crMasterSheetEksport1.DataDefinition.FormulaFields("Total_ekor").Text = "'" & Total_ekor & "'"
            'crMasterSheetEksport1.DataDefinition.FormulaFields("tarikh_masa").Text = "'" & TarikhMasaMasuk & "'"
            ''end of edited by kmz for caj eksport

            'crMasterSheetEksport1.DataDefinition.RecordSelectionFormula = formula
            'opClass.SetDBLogonForReport(myConnectionInfo, crMasterSheetEksport1)
            'opClass.SetDBLogonForSubreports(myConnectionInfo, crMasterSheetEksport1)
            'CrystalReportViewer2.Visible = False
            'crMasterSheetEksport1.PrintOptions.PrinterName = namaPrinter
            'crMasterSheetEksport1.PrintToPrinter(1, False, 0, 0)



            'crMasterSheetEksport2 = New ReportDocument()
            'crMasterSheetEksport2.Load(reportPath)
            'crMasterSheetEksport2.DataDefinition.FormulaFields("MS_NoInvois").Text = "'" & Request("invois_id") & "'"
            'crMasterSheetEksport2.DataDefinition.FormulaFields("MS_Salinan").Text = "'SALINAN AGEN PENGANGKUTAN'"
            'crMasterSheetEksport2.DataDefinition.FormulaFields("Caj_Masuk").Text = "'" & CajMasuk & "'"
            'crMasterSheetEksport2.DataDefinition.FormulaFields("No_Kenderaan").Text = "'" & NoKenderaan & "'"
            'crMasterSheetEksport2.DataDefinition.FormulaFields("no_agen_pengangkutan").Text = "'" & NoAgenPengangkutan & "'"
            'crMasterSheetEksport2.DataDefinition.FormulaFields("urusan").Text = "'" & Urusan & "'"
            'crMasterSheetEksport2.DataDefinition.FormulaFields("barangan").Text = "'" & Barangan & "'"
            'crMasterSheetEksport2.DataDefinition.FormulaFields("Kurang_caj").Text = "'" & Kurang_caj & "'"
            'crMasterSheetEksport2.DataDefinition.FormulaFields("pegawai").Text = "'" & NamaPegawai & "'"

            ''edited by kmz for caj eksport
            'crMasterSheetEksport2.DataDefinition.FormulaFields("Caj_Masuk").Text = "'" & CajMasuk & "'"
            'crMasterSheetEksport2.DataDefinition.FormulaFields("Kira_peti_kecil").Text = "'" & Kira_peti_kecil & "'"
            'crMasterSheetEksport2.DataDefinition.FormulaFields("Total_peti_kecil").Text = "'" & Total_peti_kecil & "'"
            'crMasterSheetEksport2.DataDefinition.FormulaFields("Kira_peti_besar").Text = "'" & Kira_peti_besar & "'"
            'crMasterSheetEksport2.DataDefinition.FormulaFields("Total_peti_besar").Text = "'" & Total_peti_besar & "'"
            'crMasterSheetEksport2.DataDefinition.FormulaFields("Kira_berat").Text = "'" & Kira_berat & "'"
            'crMasterSheetEksport2.DataDefinition.FormulaFields("Total_berat").Text = "'" & Total_berat & "'"
            'crMasterSheetEksport2.DataDefinition.FormulaFields("Kira_ekor").Text = "'" & Kira_ekor & "'"
            'crMasterSheetEksport2.DataDefinition.FormulaFields("Total_ekor").Text = "'" & Total_ekor & "'"
            'crMasterSheetEksport2.DataDefinition.FormulaFields("tarikh_masa").Text = "'" & TarikhMasaMasuk & "'"
            ''end of edited by kmz for caj eksport

            'crMasterSheetEksport2.DataDefinition.RecordSelectionFormula = formula
            'opClass.SetDBLogonForReport(myConnectionInfo, crMasterSheetEksport2)
            'opClass.SetDBLogonForSubreports(myConnectionInfo, crMasterSheetEksport2)
            'CrystalReportViewer3.Visible = False
            'crMasterSheetEksport2.PrintOptions.PrinterName = namaPrinter
            'crMasterSheetEksport2.PrintToPrinter(1, False, 0, 0)

            'crMasterSheetEksport3 = New ReportDocument()
            'crMasterSheetEksport3.Load(reportPath)
            'crMasterSheetEksport3.DataDefinition.FormulaFields("MS_NoInvois").Text = "'" & Request("invois_id") & "'"
            'crMasterSheetEksport3.DataDefinition.FormulaFields("MS_Salinan").Text = "'SALINAN PERSATUAN NELAYAN NEGERI'"
            'crMasterSheetEksport3.DataDefinition.FormulaFields("Caj_Masuk").Text = "'" & CajMasuk & "'"
            'crMasterSheetEksport3.DataDefinition.FormulaFields("No_Kenderaan").Text = "'" & NoKenderaan & "'"
            'crMasterSheetEksport3.DataDefinition.FormulaFields("no_agen_pengangkutan").Text = "'" & NoAgenPengangkutan & "'"
            'crMasterSheetEksport3.DataDefinition.FormulaFields("urusan").Text = "'" & Urusan & "'"
            'crMasterSheetEksport3.DataDefinition.FormulaFields("barangan").Text = "'" & Barangan & "'"
            'crMasterSheetEksport3.DataDefinition.FormulaFields("Kurang_caj").Text = "'" & Kurang_caj & "'"
            'crMasterSheetEksport3.DataDefinition.FormulaFields("pegawai").Text = "'" & NamaPegawai & "'"

            ''edited by kmz for caj eksport
            'crMasterSheetEksport3.DataDefinition.FormulaFields("Caj_Masuk").Text = "'" & CajMasuk & "'"
            'crMasterSheetEksport3.DataDefinition.FormulaFields("Kira_peti_kecil").Text = "'" & Kira_peti_kecil & "'"
            'crMasterSheetEksport3.DataDefinition.FormulaFields("Total_peti_kecil").Text = "'" & Total_peti_kecil & "'"
            'crMasterSheetEksport3.DataDefinition.FormulaFields("Kira_peti_besar").Text = "'" & Kira_peti_besar & "'"
            'crMasterSheetEksport3.DataDefinition.FormulaFields("Total_peti_besar").Text = "'" & Total_peti_besar & "'"
            'crMasterSheetEksport3.DataDefinition.FormulaFields("Kira_berat").Text = "'" & Kira_berat & "'"
            'crMasterSheetEksport3.DataDefinition.FormulaFields("Total_berat").Text = "'" & Total_berat & "'"
            'crMasterSheetEksport3.DataDefinition.FormulaFields("Kira_ekor").Text = "'" & Kira_ekor & "'"
            'crMasterSheetEksport3.DataDefinition.FormulaFields("Total_ekor").Text = "'" & Total_ekor & "'"
            'crMasterSheetEksport3.DataDefinition.FormulaFields("tarikh_masa").Text = "'" & TarikhMasaMasuk & "'"
            ''end of edited by kmz for caj eksport

            'crMasterSheetEksport3.DataDefinition.RecordSelectionFormula = formula
            'opClass.SetDBLogonForReport(myConnectionInfo, crMasterSheetEksport3)
            'opClass.SetDBLogonForSubreports(myConnectionInfo, crMasterSheetEksport3)
            'CrystalReportViewer4.Visible = False
            'crMasterSheetEksport3.PrintOptions.PrinterName = namaPrinter
            'crMasterSheetEksport3.PrintToPrinter(1, False, 0, 0)

            'crMasterSheetEksport4 = New ReportDocument()
            'crMasterSheetEksport4.Load(reportPath)
            'crMasterSheetEksport4.DataDefinition.FormulaFields("MS_NoInvois").Text = "'" & Request("invois_id") & "'"
            'crMasterSheetEksport4.DataDefinition.FormulaFields("MS_Salinan").Text = "'SALINAN PENGUATKUASA'"
            'crMasterSheetEksport4.DataDefinition.FormulaFields("Caj_Masuk").Text = "'" & CajMasuk & "'"
            'crMasterSheetEksport4.DataDefinition.FormulaFields("No_Kenderaan").Text = "'" & NoKenderaan & "'"
            'crMasterSheetEksport4.DataDefinition.FormulaFields("no_agen_pengangkutan").Text = "'" & NoAgenPengangkutan & "'"
            'crMasterSheetEksport4.DataDefinition.FormulaFields("urusan").Text = "'" & Urusan & "'"
            'crMasterSheetEksport4.DataDefinition.FormulaFields("barangan").Text = "'" & Barangan & "'"
            'crMasterSheetEksport4.DataDefinition.FormulaFields("Kurang_caj").Text = "'" & Kurang_caj & "'"
            'crMasterSheetEksport4.DataDefinition.FormulaFields("pegawai").Text = "'" & NamaPegawai & "'"

            ''edited by kmz for caj eksport
            'crMasterSheetEksport4.DataDefinition.FormulaFields("Caj_Masuk").Text = "'" & CajMasuk & "'"
            'crMasterSheetEksport4.DataDefinition.FormulaFields("Kira_peti_kecil").Text = "'" & Kira_peti_kecil & "'"
            'crMasterSheetEksport4.DataDefinition.FormulaFields("Total_peti_kecil").Text = "'" & Total_peti_kecil & "'"
            'crMasterSheetEksport4.DataDefinition.FormulaFields("Kira_peti_besar").Text = "'" & Kira_peti_besar & "'"
            'crMasterSheetEksport4.DataDefinition.FormulaFields("Total_peti_besar").Text = "'" & Total_peti_besar & "'"
            'crMasterSheetEksport4.DataDefinition.FormulaFields("Kira_berat").Text = "'" & Kira_berat & "'"
            'crMasterSheetEksport4.DataDefinition.FormulaFields("Total_berat").Text = "'" & Total_berat & "'"
            'crMasterSheetEksport4.DataDefinition.FormulaFields("Kira_ekor").Text = "'" & Kira_ekor & "'"
            'crMasterSheetEksport4.DataDefinition.FormulaFields("Total_ekor").Text = "'" & Total_ekor & "'"
            'crMasterSheetEksport4.DataDefinition.FormulaFields("tarikh_masa").Text = "'" & TarikhMasaMasuk & "'"
            ''end of edited by kmz for caj eksport

            'crMasterSheetEksport4.DataDefinition.RecordSelectionFormula = formula
            'opClass.SetDBLogonForReport(myConnectionInfo, crMasterSheetEksport4)
            'opClass.SetDBLogonForSubreports(myConnectionInfo, crMasterSheetEksport4)
            'CrystalReportViewer5.Visible = False
            'crMasterSheetEksport4.PrintOptions.PrinterName = namaPrinter
            'crMasterSheetEksport4.PrintToPrinter(1, False, 0, 0)
            
        End If

    End Sub


    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        'crSKPE.Close()
        'crSKPE.Dispose()
        'crMasterSheetEksport1.Close()
        'crMasterSheetEksport1.Dispose()
        'crMasterSheetEksport2.Close()
        'crMasterSheetEksport2.Dispose()
        'crMasterSheetEksport3.Close()
        'crMasterSheetEksport3.Dispose()
        'crMasterSheetEksport4.Close()
        'crMasterSheetEksport4.Dispose()
        GC.SuppressFinalize(True)
        GC.Collect()
    End Sub

End Class
