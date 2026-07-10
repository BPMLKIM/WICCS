Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalLibrary

Partial Class _Default
    Inherits System.Web.UI.Page
    Private iResitG2c1 As ReportDocument
    Private iResitG2c1Salinan As ReportDocument

#Region "Variables Declaration"
    Protected opClass As SQLOperation
    Protected opClass1 As SQLOperation

#End Region

    Private Sub ConfigureCrystalReports()

        Dim myConnectionInfo As ConnectionInfo = New ConnectionInfo()
        myConnectionInfo.DatabaseName = System.Configuration.ConfigurationManager.AppSettings("dbname")
        myConnectionInfo.UserID = System.Configuration.ConfigurationManager.AppSettings("userid")
        myConnectionInfo.Password = System.Configuration.ConfigurationManager.AppSettings("dbpassword")
        myConnectionInfo.ServerName = System.Configuration.ConfigurationManager.AppSettings("servername")


        Dim siri_module As String = "individual_receipt"
        opClass = New SQLOperation()
        opClass.dbConnection()
        opClass1 = New SQLOperation()
        opClass1.dbConnection()

        Dim SQLReader As System.Data.SqlClient.SqlDataReader
        Dim SQLReader1 As System.Data.SqlClient.SqlDataReader
        Dim serial_no As String = ""
        Dim cname As String = ""
        Dim cdesc As String = ""
        Dim add1 As String = ""
        Dim add2 As String = ""
        Dim add3 As String = ""
        Dim add4 As String = ""
        Dim gstno As String = ""
        Dim bolPrinted As Boolean = False

        Session.LCID = 2057

        Dim rstbayar As String = "select no_barcode from pembayaran_caj_skpe where no_barcode = '" & Trim(Request("barcode")) & "'"
        SQLReader = opClass.DataReader(rstbayar)

        If Not SQLReader.HasRows Then

            Response.Write("<script language = javascript>alert('Tiada maklumat pembayaran dibuat.');window.close();</script>")
            Response.End()

        End If

        SQLReader.Close()
        SQLReader = Nothing


        'If Request("print_status") <> "Y" And serial_no = "" Then

        '    Dim rstSerial As String = "insert into serialno_resit_nekad_eksport  (no_barcode) values ('X');"
        '    opClass1.InsertData(rstSerial)

        '    Dim rstSerial1 As String = "select newresit from serialno_resit_nekad_eksport   order by newresit desc"
        '    SQLReader = opClass.DataReader(rstSerial1)

        '    SQLReader.Read()

        '    serial_no = SQLReader(0)

        '    SQLReader.Close()
        '    SQLReader = Nothing

        'End If

        opClass1 = New SQLOperation()
        opClass1.dbConnection()


        Dim no_invois As Integer
        Dim kod_agen As String = ""
        Dim nama_agen As String = ""

        Dim sqlAgen As String = "select r.Nama_Agen_Pengangkutan,p.kod_agen_pengangkutan,s.no_invois from pendaftaran_pintu p " _
        & " inner join no_invois_eksport s ON p.nombor_barcode = s.no_barcode inner join agen_pengangkutan r on r.Kod_Agen_Pengangkutan = p.kod_agen_pengangkutan" _
        & " where p.nombor_barcode='" & Trim(Request("barcode")) & "'"
        SQLReader = opClass.DataReader(sqlAgen)

        SQLReader.Read()

        kod_agen = SQLReader("kod_agen_pengangkutan")
        no_invois = SQLReader("no_invois")
        nama_agen = SQLReader("Nama_Agen_Pengangkutan")

        SQLReader.Close()
        SQLReader = Nothing


        Dim rstemp As String = "select bil_siri_resit from no_siri_resit_nekad_eksport where no_barcode = '" & Trim(Request("barcode")) & "'"
        SQLReader = opClass.DataReader(rstemp)

        If Not SQLReader.HasRows Then

            'If Request("print_status") <> "Y" And serial_no = "" Then
            If serial_no = "" Then

                Dim rstSerial As String = "insert into serialno_resit_nekad_eksport  (no_barcode) values ('X');"
                opClass1.InsertData(rstSerial)

                Dim rstSerial1 As String = "select newresit from serialno_resit_nekad_eksport   order by newresit desc"
                SQLReader1 = opClass1.DataReader(rstSerial1)

                SQLReader1.Read()

                serial_no = SQLReader1(0)

                SQLReader1.Close()
                SQLReader1 = Nothing

            End If

            Dim a As String = "insert into no_siri_resit_nekad_eksport(no_barcode,no_invois,bil_siri_resit,siri_module,kod_agen,print_status,site_code) " _
            & " values('" & Trim(Request("barcode")) & "','" & Trim(no_invois) & "','" & Trim(serial_no) & "','" & Trim(siri_module) & "','" & Trim(kod_agen) & "','0','" & Right(Trim(Request("barcode")), 3) & "')"
            opClass1.InsertData(a)

        Else

            SQLReader.Read()
            serial_no = SQLReader("bil_siri_resit")

        End If

        SQLReader.Close()
        SQLReader = Nothing


        If Request("print_status") = "Y" Then

            Dim gconSQL As String = "update pembayaran_caj_skpe set print_status='1' where no_barcode='" & Trim(Request("barcode")) & "'"
            opClass1.InsertData(gconSQL)

            Dim gconSQL1 As String = "update no_siri_resit_nekad_eksport set print_status='1' where no_barcode='" & Trim(Request("barcode")) & "'"
            opClass1.InsertData(gconSQL1)

        End If


        Dim rpt As String = ""

        Dim strSQL As String = "select h.company_name,h.company_add1,h.company_add2,h.company_add3,h.company_add4,h.gst_no from iccs_payment_receipt p inner join  iccs_form_header h " _
        & "on p.form_header_id=h.company_code where  p.receipt_id='iResitNEKAD'"
        ' Dim strSQL As String = "select h.company_name,h.company_add1,h.company_add2,h.company_add3,h.company_add4,h.gst_no from iccs_payment_receipt p inner join  iccs_form_header h " _
        '& "on p.form_header_id=h.company_code where  p.receipt_id='iResitLKIM'"
        SQLReader = opClass.DataReader(strSQL)


        If SQLReader.HasRows Then
            SQLReader.Read()

            cname = Trim(SQLReader("company_name"))
            'cdesc = Trim(SQLReader("company_desc"))
            add1 = Trim(SQLReader("company_add1"))
            add2 = Trim(SQLReader("company_add2"))
            add3 = Trim(SQLReader("company_add3"))
            add4 = Trim(SQLReader("company_add4"))
            gstno = Trim(SQLReader("gst_no"))

        End If


        SQLReader.Close()
        SQLReader = Nothing

        iResitG2c1 = New ReportDocument()
        Dim reportPath As String = Server.MapPath("cetakrpt/iResitG2c1.rpt")
        iResitG2c1.Load(reportPath)
        iResitG2c1Salinan = New ReportDocument()

        If Request("printer_name") <> "" Then

            Dim reportPath1 As String = Server.MapPath("cetakrpt/iResitG2c1Salinan.rpt")
            iResitG2c1Salinan.Load(reportPath1)
            myCrystalReportViewer.Visible = False
            myCrystalReportViewer1.Visible = False

        Else
            myCrystalReportViewer.Visible = True
            myCrystalReportViewer1.Visible = False

        End If

        Dim selectFormula As String = ""

        selectFormula = "{ITEM_CAJ_EKSPORT.Kod_Service_Caj}= 'Caj Pengisytiharan (Borang SKPI) - PNK SRI MUARA' AND {no_siri_resit_nekad_eksport.bil_siri_resit} = '" & Trim(serial_no) & "' AND {ITEM_CAJ_EKSPORT.Dicaj_Oleh} = 'PNK SRI MUARA'"
        'selectFormula = "{ITEM_CAJ_EKSPORT.Kod_Service_Caj}= 'Caj Pengisytiharan (Borang SKPI) - LKIM' AND {no_siri_resit_nekad_eksport.bil_siri_resit} = '" & Trim(serial_no) & "' AND {ITEM_CAJ_EKSPORT.Dicaj_Oleh} = 'LKIM'"
        Dim sdatetime As String = ""

        Dim sqldate As String = "select getdate() as sdatetime"
        SQLReader = opClass.DataReader(sqldate)

        SQLReader.Read()

        sdatetime = SQLReader("sdatetime")

        SQLReader.Close()
        SQLReader = Nothing

        iResitG2c1.DataDefinition.FormulaFields("company_name").Text = "'" & cname & "'"
        'iResitG2c1.DataDefinition.FormulaFields("company_desc").Text = "'" & cdesc & "'"
        iResitG2c1.DataDefinition.FormulaFields("company_add1").Text = "'" & add1 & "'"
        iResitG2c1.DataDefinition.FormulaFields("company_add2").Text = "'" & add2 & "'"
        iResitG2c1.DataDefinition.FormulaFields("company_add3").Text = "'" & add3 & "'"
        iResitG2c1.DataDefinition.FormulaFields("company_add4").Text = "'" & add4 & "'"
        iResitG2c1.DataDefinition.FormulaFields("gst_no").Text = "'" & gstno & "'"
        iResitG2c1.DataDefinition.FormulaFields("sdatetime").Text = "'" & sdatetime & "'"
        iResitG2c1.DataDefinition.FormulaFields("no_siri").Text = "'" & serial_no.PadLeft(6, "0") & "'"
        iResitG2c1.DataDefinition.FormulaFields("agen_pengangkutan").Text = "'" & nama_agen & "'"

        If Request("printer_name") <> "" Then

            iResitG2c1Salinan.DataDefinition.FormulaFields("company_name").Text = "'" & cname & "'"
            'iResitG2c1Salinan.DataDefinition.FormulaFields("company_desc").Text = "'" & cdesc & "'"
            iResitG2c1Salinan.DataDefinition.FormulaFields("company_add1").Text = "'" & add1 & "'"
            iResitG2c1Salinan.DataDefinition.FormulaFields("company_add2").Text = "'" & add2 & "'"
            iResitG2c1Salinan.DataDefinition.FormulaFields("company_add3").Text = "'" & add3 & "'"
            iResitG2c1Salinan.DataDefinition.FormulaFields("company_add4").Text = "'" & add4 & "'"
            iResitG2c1.DataDefinition.FormulaFields("gst_no").Text = "'" & gstno & "'"
            iResitG2c1Salinan.DataDefinition.FormulaFields("sdatetime").Text = "'" & sdatetime & "'"
            iResitG2c1Salinan.DataDefinition.FormulaFields("no_siri").Text = "'" & serial_no.PadLeft(6, "0") & "'"
            iResitG2c1Salinan.DataDefinition.FormulaFields("agen_pengangkutan").Text = "'" & nama_agen & "'"

            iResitG2c1Salinan.DataDefinition.RecordSelectionFormula = selectFormula
            'myCrystalReportViewer1.ReportSource = iResitG2c1Salinan
            SetDBLogonForReport(myConnectionInfo, iResitG2c1Salinan)

        End If

        iResitG2c1.DataDefinition.RecordSelectionFormula = selectFormula

        If Request("printer_name") = "" Then
            myCrystalReportViewer.ReportSource = iResitG2c1
        End If


        SetDBLogonForReport(myConnectionInfo, iResitG2c1)

        If Request("printer_name") <> "" Then
            'Response.Write(Replace(Request("printer_name"), "/", "\"))
            'response.end()

            Dim namaPrinter As String = Replace(Request("printer_name"), "/", "\") '"KONICA MINOLTA 7145/IP-432" '        
            'Dim namaPrinter As String = "KONICA MINOLTA 7145/IP-432"
            iResitG2c1.PrintOptions.PrinterName = namaPrinter
            iResitG2c1.PrintToPrinter(1, False, 0, 0)
            iResitG2c1Salinan.PrintOptions.PrinterName = namaPrinter
            iResitG2c1Salinan.PrintToPrinter(1, False, 0, 0)

            Response.Write("<script languange=javascript>window.close();</script>")
            Response.End()

        End If

        opClass.dbConnection_Close()
        opClass1.dbConnection_Close()

    End Sub

    Private Sub SetDBLogonForReport(ByVal myConnectionInfo As ConnectionInfo, ByVal myReportDocument As ReportDocument)
        Dim myTables As Tables = myReportDocument.Database.Tables
        For Each myTable As CrystalDecisions.CrystalReports.Engine.Table In myTables
            Dim myTableLogonInfo As TableLogOnInfo = myTable.LogOnInfo
            myTableLogonInfo.ConnectionInfo = myConnectionInfo
            myTable.ApplyLogOnInfo(myTableLogonInfo)
        Next
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        ConfigureCrystalReports()

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        iResitG2c1.Close()
        iResitG2c1.Dispose()
        iResitG2c1Salinan.Close()
        iResitG2c1Salinan.Dispose()
        GC.SuppressFinalize(True)
        GC.Collect()
    End Sub
End Class
