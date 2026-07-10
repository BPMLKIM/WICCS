Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalLibrary

Partial Class _Default
    Inherits System.Web.UI.Page
    Private iResitG2b1 As ReportDocument
    Private iResitG2b1Salinan As ReportDocument
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
        Dim SQLReader As System.Data.SqlClient.SqlDataReader
        Dim SQLReader1 As System.Data.SqlClient.SqlDataReader
        Dim serial_no As String = ""
        Dim cname As String = ""
        Dim cdesc As String = ""
        Dim add1 As String = ""
        Dim add2 As String = ""
        Dim add3 As String = ""
        Dim add4 As String = ""
        Dim bolPrinted As Boolean = False

        Session.LCID = 2057
        'Response.Write("<br>StartReport 1 =" & Now())


        opClass1 = New SQLOperation()
        opClass1.dbConnection()

        Dim no_invois As Integer
        Dim kod_agen As String = ""
        Dim nama_agen As String = ""

        'Dim rstbayar As String = "select no_barcode from pembayaran_caj_skpi where no_barcode = '" & Trim(Request("barcode")) & "'"
        'SQLReader = opClass.DataReader(rstbayar)

        'If Not SQLReader.HasRows Then

        '    Response.Write("<script language = javascript>alert('Tiada maklumat pembayaran dibuat.');window.close();</script>")
        '    Response.End()

        'End If

        'SQLReader.Close()
        'SQLReader = Nothing

        'If Request("print_status") <> "Y" And serial_no = "" Then

        '    Dim rstSerial As String = "insert into serialno_resit_nekad (no_barcode) values ('X');"
        '    opClass1.InsertData(rstSerial)

        '    Dim rstSerial1 As String = "select newresit from serialno_resit_nekad  order by newresit desc"
        '    SQLReader = opClass.DataReader(rstSerial1)

        '    SQLReader.Read()

        '    serial_no = SQLReader(0)

        '    SQLReader.Close()
        '    SQLReader = Nothing

        'End If


        Dim sqlAgen As String = "select r.Nama_Agen_Pengangkutan,p.kod_agen_pengangkutan from pendaftaran_pintu p " _
        & " inner join agen_pengangkutan r on r.Kod_Agen_Pengangkutan = p.kod_agen_pengangkutan" _
        & " where p.nombor_barcode='" & Trim(Request("barcode")) & "'"
        SQLReader = opClass.DataReader(sqlAgen)

        SQLReader.Read()

        kod_agen = SQLReader("kod_agen_pengangkutan")
        'no_invois = SQLReader("no_invois")
        nama_agen = SQLReader("Nama_Agen_Pengangkutan")

        SQLReader.Close()
        SQLReader = Nothing


        Dim rstemp As String = "select bil_siri,bil_siri_resit from no_siri_resit_nekad where no_barcode = '" & Trim(Request("barcode")) & "' and no_invois='0'"
        SQLReader = opClass.DataReader(rstemp)


        If Not SQLReader.HasRows Then

            If Request("print_status") <> "Y" And serial_no = "" Then

                Dim rstSerial As String = "insert into serialno_resit_nekad (no_barcode) values ('X');"
                opClass1.InsertData(rstSerial)

                Dim rstSerial1 As String = "select newresit from serialno_resit_nekad  order by newresit desc"
                SQLReader1 = opClass1.DataReader(rstSerial1)

                SQLReader1.Read()

                serial_no = SQLReader1(0)

                SQLReader1.Close()
                SQLReader1 = Nothing

            End If



            Dim a As String = "insert into no_siri_resit_nekad(no_barcode,no_invois,bil_siri_resit,siri_module,kod_agen,print_status,site_code) " _
            & " values('" & Trim(Request("barcode")) & "','" & Trim(no_invois) & "','" & Trim(serial_no) & "','" & Trim(siri_module) & "','" & Trim(kod_agen) & "','0','" & Right(Trim(Request("barcode")), 3) & "')"
            opClass1.InsertData(a)


        Else

            'do nothing
            SQLReader.Read()
            serial_no = Trim(SQLReader("bil_siri_resit"))


        End If

        SQLReader.Close()
        SQLReader = Nothing

        Dim rpt As String = ""

        Dim strSQL As String = "select h.company_name,h.company_add1,h.company_add2,h.company_add3,h.company_add4 " _
        & "from iccs_payment_receipt p inner join iccs_form_header h " _
        & "on p.form_header_id=h.company_code where  p.receipt_id='iResitNekad'"
        SQLReader = opClass.DataReader(strSQL)


        If SQLReader.HasRows Then
            SQLReader.Read()

            cname = Trim(SQLReader("company_name"))
            'cdesc = Trim(SQLReader("company_desc"))
            add1 = Trim(SQLReader("company_add1"))
            add2 = Trim(SQLReader("company_add2"))
            add3 = Trim(SQLReader("company_add3"))
            add4 = Trim(SQLReader("company_add4"))

        End If

        SQLReader.Close()
        SQLReader = Nothing


        If Request("print_status") = "Y" Then

            'Dim gconSQL As String = "update pembayaran_caj_skpi set print_status='1' where no_barcode='" & Trim(Request("barcode")) & "'"
            'opClass1.InsertData(gconSQL)

            Dim gconSQL1 As String = "update no_siri_resit_nekad set print_status='1' where no_barcode='" & Trim(Request("barcode")) & "'"
            opClass1.InsertData(gconSQL1)

        End If

       ' Response.Write("<br>StartEndReport 2 =" & Now())

        iResitG2b1 = New ReportDocument()
        Dim reportPath As String = Server.MapPath("cetakrpt/iResitG2b1.rpt")
        iResitG2b1.Load(reportPath)

        iResitG2b1Salinan = New ReportDocument()

        If Request("printer_name") <> "" Then

            Dim reportPath1 As String = Server.MapPath("cetakrpt/iResitG2b1Salinan.rpt")
            iResitG2b1Salinan.Load(reportPath1)
            myCrystalReportViewer.Visible = False
            myCrystalReportViewer1.Visible = False

        Else
            myCrystalReportViewer.Visible = True
            myCrystalReportViewer1.Visible = False

        End If

        Dim selectFormula As String = ""

        'selectFormula = "{ITEM_CAJ.Kod_Service_Caj}= 'Caj Pengisytiharan (Borang SKPI) - CFC' AND {ITEM_CAJ.Dicaj_Oleh} = 'CFC' and {no_siri_resit_nekad.bil_siri_resit} = '" & serial_no & "'"
        selectFormula = "{ITEM_CAJ.Kod_Service_Caj}<> 'Caj Pengisytiharan (Borang SKPI) - PNK SRI MUARA' AND {ITEM_CAJ.Dicaj_Oleh} = 'PNK SRI MUARA' and {no_siri_resit_nekad.bil_siri_resit} = '" & serial_no & "'"

        Dim sdatetime As String = ""

        Dim sqldate As String = "select getdate() as sdatetime"
        SQLReader = opClass.DataReader(sqldate)

        SQLReader.Read()

        sdatetime = SQLReader("sdatetime")

        SQLReader.Close()
        SQLReader = Nothing

        'Response.Write("<br>StartReport 2 =" & Now())


        iResitG2b1.DataDefinition.FormulaFields("company_name").Text = "'" & cname & "'"
        'iResitG2b1.DataDefinition.FormulaFields("company_desc").Text = "'" & cdesc & "'"
        iResitG2b1.DataDefinition.FormulaFields("company_add1").Text = "'" & add1 & "'"
        iResitG2b1.DataDefinition.FormulaFields("company_add2").Text = "'" & add2 & "'"
        iResitG2b1.DataDefinition.FormulaFields("company_add3").Text = "'" & add3 & "'"
        iResitG2b1.DataDefinition.FormulaFields("company_add4").Text = "'" & add4 & "'"
        iResitG2b1.DataDefinition.FormulaFields("sdatetime").Text = "'" & sdatetime & "'"
        iResitG2b1.DataDefinition.FormulaFields("no_siri").Text = "'" & serial_no.PadLeft(6, "0") & "'"
        iResitG2b1.DataDefinition.FormulaFields("agen_pengangkutan").Text = "'" & nama_agen & "'"
        iResitG2b1.DataDefinition.RecordSelectionFormula = selectFormula

        If Request("printer_name") <> "" Then

            iResitG2b1Salinan.DataDefinition.FormulaFields("company_name").Text = "'" & cname & "'"
            'iResitG2b1Salinan.DataDefinition.FormulaFields("company_desc").Text = "'" & cdesc & "'"
            iResitG2b1Salinan.DataDefinition.FormulaFields("company_add1").Text = "'" & add1 & "'"
            iResitG2b1Salinan.DataDefinition.FormulaFields("company_add2").Text = "'" & add2 & "'"
            iResitG2b1Salinan.DataDefinition.FormulaFields("company_add3").Text = "'" & add3 & "'"
            iResitG2b1Salinan.DataDefinition.FormulaFields("company_add4").Text = "'" & add4 & "'"
            iResitG2b1Salinan.DataDefinition.FormulaFields("sdatetime").Text = "'" & sdatetime & "'"
            iResitG2b1Salinan.DataDefinition.FormulaFields("no_siri").Text = "'" & serial_no.PadLeft(6, "0") & "'"
            iResitG2b1Salinan.DataDefinition.FormulaFields("agen_pengangkutan").Text = "'" & nama_agen & "'"

            iResitG2b1Salinan.DataDefinition.RecordSelectionFormula = selectFormula
            'myCrystalReportViewer1.ReportSource = iResitG2b1Salinan
            SetDBLogonForReport(myConnectionInfo, iResitG2b1Salinan)

        End If

        If Request("printer_name") = "" Then
            myCrystalReportViewer.ReportSource = iResitG2b1
        End If

        SetDBLogonForReport(myConnectionInfo, iResitG2b1)

        'Response.Write("<br>endReport 2 =" & Now())
        'Response.End()
        'Response.End()
        If Request("printer_name") <> "" Then

            Dim namaPrinter As String = Replace(Request("printer_name"), "/", "\") '"KONICA MINOLTA 7145/IP-432" '        
            'Dim namaPrinter As String = "KONICA MINOLTA 7145/IP-432"
            iResitG2b1.PrintOptions.PrinterName = namaPrinter
            iResitG2b1.PrintToPrinter(1, False, 0, 0)
            iResitG2b1Salinan.PrintOptions.PrinterName = namaPrinter
            iResitG2b1Salinan.PrintToPrinter(1, False, 0, 0)
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
        iResitG2b1.Close()
        iResitG2b1.Dispose()
        iResitG2b1Salinan.Close()
        iResitG2b1Salinan.Dispose()
        GC.SuppressFinalize(True)
        GC.Collect()

    End Sub
End Class
