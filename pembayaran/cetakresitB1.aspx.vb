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

        Session.LCID = 2057

        Dim arrloop As String

        Dim strValue = Trim(Request("arrayValT"))
        Dim i As Integer
        Dim rowArray = strValue.Split("~")

        If UBound(rowArray) = 0 Then
            arrloop = 0
        Else
            arrloop = UBound(rowArray) - 1

        End If


        'For i = 0 To arrloop
        '    Dim arrBayarCol1() As String = rowArray(i).ToString().Split("`")

        '    'Dim sqlnew As String = "select bil_siri_resit from no_siri_resit_nekad where no_barcode='" & Trim(arrBayarCol1(0)) & "' and kod_agen = '" & Trim(Request("kod_agen")) & "'"
        '    'SQLReader = opClass.DataReader(sqlnew)

        '    'SQLReader.Read()

        '    'If Not SQLReader.HasRows Then
        '    '    'empty()
        '    '    serial_no = ""

        '    'Else

        '    '    serial_no = SQLReader("bil_siri_resit")


        '    'End If

        '    'SQLReader.Close()
        '    'SQLReader = Nothing


        'Next

        'If Request("print_status") <> "Y" And serial_no = "" Then

        'Dim rstSerial As String = "insert into serialno_resit_nekad (no_barcode) values ('X');"
        'opClass1.InsertData(rstSerial)

        'Dim rstSerial1 As String = "select newresit from serialno_resit_nekad  order by newresit desc"
        'SQLReader = opClass.DataReader(rstSerial1)

        'SQLReader.Read()

        'serial_no = SQLReader(0)

        'SQLReader.Close()
        'SQLReader = Nothing

        Dim sqlserialno As String = "select bil_siri_resit from no_siri_resit_nekad where kod_agen = '" & Trim(Request("kod_agen")) & "' and day(edate)=day(getdate()) and month(edate)=month(getdate()) and year(edate)=year(getdate()) and siri_module='agent_receipt' and print_status='0'"
        SQLReaderSerial = opClass.DataReader(sqlserialno)

        SQLReaderSerial.Read()

        If Not SQLReaderSerial.HasRows Then
            'empty()

            Dim rstSerial As String = "insert into serialno_resit_nekad (no_barcode) values ('X');"
            opClass1.InsertData(rstSerial)

            Dim rstSerial1 As String = "select newresit from serialno_resit_nekad  order by newresit desc"
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



        For i = 0 To arrloop

            Dim intInvois As Integer
            Dim arrBayarCol() As String = rowArray(i).ToString().Split("`")

            Dim sql10 As String = "select no_invois from no_invois where no_barcode='" & Trim(arrBayarCol(0)) & "'"
            SQLReader = opClass.DataReader(sql10)

            SQLReader.Read()

            intInvois = SQLReader("no_invois")

            SQLReader.Close()
            SQLReader = Nothing

            Dim sql11 As String = "select bil_siri_resit from no_siri_resit_nekad where no_barcode='" & Trim(arrBayarCol(0)) & "' and no_invois='" & Trim(intInvois) & "'"
            SQLReader = opClass.DataReader(sql11)

            SQLReader.Read()

            If Not SQLReader.HasRows Then
                'empty()
                Dim gconSQL As String = "insert into no_siri_resit_nekad(no_barcode,no_invois,bil_siri_resit,siri_module,kod_agen,print_status,site_code) " _
                & " values('" & Trim(arrBayarCol(0)) & "','" & Trim(intInvois) & "','" & Trim(serial_no) & "','" & Trim(siri_module) & "','" & Trim(Request("kod_agen")) & "','0','" & Right(Trim(arrBayarCol(0)), 3) & "')"
                opClass1.InsertData(gconSQL)

                ''Else

                ''    serial_no = SQLReader("bil_siri_resit")

            End If

            SQLReader.Close()
            SQLReader = Nothing

        Next


        Dim strSQL As String = "select h.company_name,h.company_add1,h.company_add2,h.company_add3,h.company_add4 from iccs_payment_receipt p inner join  iccs_form_header h " _
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

            For i = 0 To arrloop


                Dim arrBayarCol() As String = rowArray(i).ToString().Split("`")

                Dim gconSQL As String = "update pembayaran_caj_skpi set print_status='1' where no_barcode='" & Trim(arrBayarCol(0)) & "'"
                opClass1.InsertData(gconSQL)

                Dim gconSQL1 As String = "update no_siri_resit_nekad set print_status='1' where no_barcode='" & Trim(arrBayarCol(0)) & "'"
                opClass1.InsertData(gconSQL1)

            Next

        End If

        Dim nama_agen As String = ""
        Dim sqlAgen As String = "select Nama_Agen_Pengangkutan from AGEN_PENGANGKUTAN " _
        & " where Kod_Agen_Pengangkutan='" & Trim(Request("kod_agen")) & "'"
        SQLReader = opClass.DataReader(sqlAgen)

        SQLReader.Read()

        nama_agen = SQLReader("Nama_Agen_Pengangkutan")

        SQLReader.Close()
        SQLReader = Nothing


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

        If Request("print_status") = "Y" Then
            myCrystalReportViewer.HasPrintButton = True
            myCrystalReportViewer1.HasPrintButton = True
        Else
            myCrystalReportViewer.HasPrintButton = False
            myCrystalReportViewer1.HasPrintButton = False
        End If

        Dim selectFormula As String = ""


        ' If Trim(Request("carabayar")) = "kumpul" Then
        'selectFormula = "{ITEM_CAJ.Kod_Service_Caj}= 'Caj Pengisytiharan (Borang SKPI) - NEKAD' AND {no_siri_resit_nekad.kod_agen} = '" & Trim(Request("kod_agen")) & "' AND {ITEM_CAJ.Dicaj_Oleh} = 'NEKAD'"
        'Else
        selectFormula = "{ITEM_CAJ.Kod_Service_Caj}= 'Caj Pengisytiharan (Borang SKPI) - PNK SRI MUARA' AND {no_siri_resit_nekad.bil_siri_resit} = '" & Trim(serial_no) & "' AND {ITEM_CAJ.Dicaj_Oleh} = 'PNK SRI MUARA'"
        'End If


        Dim sdatetime As String = ""

        Dim sqldate As String = "select getdate() as sdatetime"
        SQLReader = opClass.DataReader(sqldate)

        SQLReader.Read()

        sdatetime = SQLReader("sdatetime")

        SQLReader.Close()
        SQLReader = Nothing

        iResitG2b1.DataDefinition.FormulaFields("company_name").Text = "'" & cname & "'"
        'iResitG2b1.DataDefinition.FormulaFields("company_desc").Text = "'" & cdesc & "'"
        iResitG2b1.DataDefinition.FormulaFields("company_add1").Text = "'" & add1 & "'"
        iResitG2b1.DataDefinition.FormulaFields("company_add2").Text = "'" & add2 & "'"
        iResitG2b1.DataDefinition.FormulaFields("company_add3").Text = "'" & add3 & "'"
        iResitG2b1.DataDefinition.FormulaFields("company_add4").Text = "'" & add4 & "'"
        iResitG2b1.DataDefinition.FormulaFields("sdatetime").Text = "'" & sdatetime & "'"
        iResitG2b1.DataDefinition.FormulaFields("no_siri").Text = "'" & serial_no.PadLeft(6, "0") & "'"
        iResitG2b1.DataDefinition.FormulaFields("agen_pengangkutan").Text = "'" & nama_agen & "'"


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

        iResitG2b1.DataDefinition.RecordSelectionFormula = selectFormula

        If Request("printer_name") = "" Then
            myCrystalReportViewer.ReportSource = iResitG2b1
        End If

        SetDBLogonForReport(myConnectionInfo, iResitG2b1)

        If Request("printer_name") <> "" Then
            'Response.Write(Replace(Request("printer_name"), "/", "\"))
            'response.end()

            Dim namaPrinter As String = Replace(Request("printer_name"), "/", "\") '"KONICA MINOLTA 7145/IP-432"'
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
