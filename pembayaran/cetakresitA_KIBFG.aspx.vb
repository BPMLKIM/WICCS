Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalLibrary

Partial Class _Default_kibfg
    Inherits System.Web.UI.Page
    Private iResitG1a As ReportDocument
    Private iResitG1aSalinan As ReportDocument


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

        Dim siri_module As String = "agent_receipt"
        opClass = New SQLOperation()
        opClass.dbConnection()
        opClass1 = New SQLOperation()
        opClass1.dbConnection()

        Dim SQLReader As System.Data.SqlClient.SqlDataReader
        Dim SQLReaderSerial As System.Data.SqlClient.SqlDataReader
        Dim serial_no As String = ""
        Dim cname As String = ""
        Dim cdesc As String = ""
        Dim add1 As String = ""
        Dim add2 As String = ""
        Dim add3 As String = ""
        Dim add4 As String = ""
        Dim bolPrinted As Boolean = False

        bolPrinted = False
        siri_module = "agent_receipt(rebat)"

        Session.LCID = 2057

        'Response.Write("<br>StartReport 1 =" & Now())


        'If Request("print_status") <> "Y" And serial_no = "" Then

        Dim sqlserialno As String = "select bil_siri_resit from no_siri_resit_lkim where kod_agen = '" & Trim(Request("kod_agen")) & "' and day(edate)=day(getdate()) and month(edate)=month(getdate()) and year(edate)=year(getdate()) and siri_module='agent_receipt(rebat)' and print_status='0'"
        SQLReaderSerial = opClass.DataReader(sqlserialno)

        SQLReaderSerial.Read()

        If Not SQLReaderSerial.HasRows Then
            'empty()

            Dim rstSerial As String = "insert into serialno_resit_lkim (no_barcode) values ('X');"
            opClass1.InsertData(rstSerial)

            Dim rstSerial1 As String = "select newresit from serialno_resit_lkim  order by newresit desc"
            SQLReader = opClass1.DataReader(rstSerial1)

            SQLReader.Read()

            serial_no = SQLReader(0)

            SQLReader.Close()
            SQLReader = Nothing


        Else
            serial_no = SQLReaderSerial("bil_siri_resit")
        End If

        SQLReaderSerial.Close()
        SQLReaderSerial = Nothing
        'End If



        Dim arrloop As String

        Dim strValue = Trim(Request("arrayValT"))
        Dim i As Integer
        Dim rowArray = strValue.Split("~")

        If UBound(rowArray) = 0 Then
            arrloop = 0
        Else
            arrloop = UBound(rowArray) - 1

        End If

        For i = 0 To arrloop

            Dim intInvois As Integer
            Dim arrBayarCol() As String = rowArray(i).ToString().Split("`")

            Dim sql10 As String = "select no_invois from no_invois where no_barcode='" & Trim(arrBayarCol(0)) & "'"
            SQLReader = opClass.DataReader(sql10)

            SQLReader.Read()

            intInvois = SQLReader("no_invois")

            SQLReader.Close()
            SQLReader = Nothing

            Dim sqlinsert As String = "select bil_siri from no_siri_resit_lkim where no_barcode='" & Trim(arrBayarCol(0)) & "' and no_invois='" & Trim(intInvois) & "'"
            SQLReader = opClass.DataReader(sqlinsert)

            SQLReader.Read()
            If SQLReader.HasRows() Then

            Else

                Dim gconSQL As String = "insert into no_siri_resit_lkim(no_barcode,no_invois,bil_siri_resit,siri_module,kod_agen,print_status,site_code) " _
                & " values('" & Trim(arrBayarCol(0)) & "','" & Trim(intInvois) & "','" & Trim(serial_no) & "','" & Trim(siri_module) & "','" & Trim(Request("kod_agen")) & "','0','" & Right(Trim(arrBayarCol(0)), 3) & "')"
                opClass1.InsertData(gconSQL)
            End If
            SQLReader.Close()
            SQLReader = Nothing
        Next

        Dim nama_agen As String = ""
        Dim sqlAgen As String = "select Nama_Agen_Pengangkutan from AGEN_PENGANGKUTAN " _
        & " where Kod_Agen_Pengangkutan='" & Trim(Request("kod_agen")) & "'"
        SQLReader = opClass.DataReader(sqlAgen)

        SQLReader.Read()

        nama_agen = SQLReader("Nama_Agen_Pengangkutan")

        SQLReader.Close()
        SQLReader = Nothing

        Dim strSQL As String = "select h.company_name,h.company_add1,h.company_add2,h.company_add3,h.company_add4 from iccs_payment_receipt p inner join  iccs_form_header h " _
        & "on p.form_header_id=h.company_code where  p.receipt_id='iResitLKIM'"
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

            For i = 0 To arrloop

                Dim arrBayarCol() As String = rowArray(i).ToString().Split("`")

                Dim gconSQL As String = "update pembayaran_caj_ikan set print_status='1' where no_barcode='" & Trim(arrBayarCol(0)) & "'"
                opClass1.InsertData(gconSQL)

                Dim gconSQL1 As String = "update no_siri_resit_lkim set print_status='1' where no_barcode='" & Trim(arrBayarCol(0)) & "'"
                opClass1.InsertData(gconSQL1)


            Next

        End If

        'Response.Write("<br>endreport 1 =" & Now())

        'Response.Write("<br>StartReport 2 =" & Now())

        iResitG1a = New ReportDocument()
        Dim reportPath As String = Server.MapPath("cetakrpt/iResitG1a_kibfg.rpt")
        iResitG1a.Load(reportPath)

        iResitG1aSalinan = New ReportDocument()

        If Request("printer_name") <> "" Then

            Dim reportPath1 As String = Server.MapPath("cetakrpt/iResitG1aSalinan_kibfg.rpt")
            iResitG1aSalinan.Load(reportPath1)
            myCrystalReportViewer.Visible = False
            myCrystalReportViewer1.Visible = False


        Else
            myCrystalReportViewer.Visible = True
            myCrystalReportViewer1.Visible = False

        End If

        If Request("print_status") = "Y" Then
            myCrystalReportViewer.HasPrintButton = True
            myCrystalReportViewer1.HasPrintButton = True
        Else
            myCrystalReportViewer.HasPrintButton = False
            myCrystalReportViewer1.HasPrintButton = False
        End If

        Dim selectFormula As String = ""

        selectFormula = "{no_siri_resit_lkim.bil_siri_resit} = '" & Trim(serial_no) & "' AND {ITEM_CAJ_KIBFG.Dicaj_Oleh} = 'LKIM' AND {ITEM_CAJ_KIBFG.Kod_Service_Caj}='Caj Perkhidmatan Ikan(Kotak Insulasi)' AND {ITEM_CAJ.Dicaj_Oleh} = 'LKIM' AND {ITEM_CAJ.Kod_Service_Caj}='Caj Perkhidmatan Ikan' and {no_siri_resit_lkim.siri_module} = 'agent_receipt(rebat)'"

        Dim sdatetime As String = ""

        Dim sqldate As String = "select getdate() as sdatetime"
        SQLReader = opClass.DataReader(sqldate)

        SQLReader.Read()

        sdatetime = SQLReader("sdatetime")

        SQLReader.Close()
        SQLReader = Nothing

        iResitG1a.DataDefinition.FormulaFields("company_name").Text = "'" & cname & "'"
        'iResitG1a.DataDefinition.FormulaFields("company_desc").Text = "'" & cdesc & "'"
        iResitG1a.DataDefinition.FormulaFields("company_add1").Text = "'" & add1 & "'"
        iResitG1a.DataDefinition.FormulaFields("company_add2").Text = "'" & add2 & "'"
        iResitG1a.DataDefinition.FormulaFields("company_add3").Text = "'" & add3 & "'"
        iResitG1a.DataDefinition.FormulaFields("company_add4").Text = "'" & add4 & "'"
        iResitG1a.DataDefinition.FormulaFields("sdatetime").Text = "'" & sdatetime & "'"
        iResitG1a.DataDefinition.FormulaFields("no_siri").Text = "'" & serial_no.PadLeft(6, "0") & "'"
        iResitG1a.DataDefinition.FormulaFields("agen_pengangkutan").Text = "'" & nama_agen & "'"



        If Request("printer_name") <> "" Then

            iResitG1aSalinan.DataDefinition.FormulaFields("company_name").Text = "'" & cname & "'"
            'iResitG1aSalinan.DataDefinition.FormulaFields("company_desc").Text = "'" & cdesc & "'"
            iResitG1aSalinan.DataDefinition.FormulaFields("company_add1").Text = "'" & add1 & "'"
            iResitG1aSalinan.DataDefinition.FormulaFields("company_add2").Text = "'" & add2 & "'"
            iResitG1aSalinan.DataDefinition.FormulaFields("company_add3").Text = "'" & add3 & "'"
            iResitG1aSalinan.DataDefinition.FormulaFields("company_add4").Text = "'" & add4 & "'"
            iResitG1aSalinan.DataDefinition.FormulaFields("sdatetime").Text = "'" & sdatetime & "'"
            iResitG1aSalinan.DataDefinition.FormulaFields("no_siri").Text = "'" & serial_no.PadLeft(6, "0") & "'"
            iResitG1aSalinan.DataDefinition.FormulaFields("agen_pengangkutan").Text = "'" & nama_agen & "'"

            iResitG1aSalinan.DataDefinition.RecordSelectionFormula = selectFormula
            'myCrystalReportViewer1.ReportSource = iResitG1aSalinan
            SetDBLogonForReport(myConnectionInfo, iResitG1aSalinan)

        End If

        iResitG1a.DataDefinition.RecordSelectionFormula = selectFormula
        If Request("printer_name") = "" Then
            myCrystalReportViewer.ReportSource = iResitG1a
        End If



        SetDBLogonForReport(myConnectionInfo, iResitG1a)

        'Response.Write("<br>EndReport 2 =" & Now())

        If Request("printer_name") <> "" Then

            Dim namaPrinter As String = Replace(Request("printer_name"), "/", "\") '"KONICA MINOLTA 7145/IP-432" '        
            'Dim namaPrinter As String = "KONICA MINOLTA 7145/IP-432"
            iResitG1a.PrintOptions.PrinterName = namaPrinter
            iResitG1a.PrintToPrinter(1, False, 0, 0)
            iResitG1aSalinan.PrintOptions.PrinterName = namaPrinter
            iResitG1aSalinan.PrintToPrinter(1, False, 0, 0)

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
        iResitG1a.Close()
        iResitG1a.Dispose()
        iResitG1aSalinan.Close()
        iResitG1aSalinan.Dispose()
        GC.SuppressFinalize(True)
        GC.Collect()
    End Sub
End Class
