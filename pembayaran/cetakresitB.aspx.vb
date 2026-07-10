Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalLibrary

Partial Class _Default
    Inherits System.Web.UI.Page
    Private iResitG2b As ReportDocument
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
        Dim serial_no As String = ""
        Dim cname As String = ""
        Dim cdesc As String = ""
        Dim add1 As String = ""
        Dim add2 As String = ""
        Dim add3 As String = ""
        Dim add4 As String = ""
        Dim bolPrinted As Boolean = False

        Session.LCID = 2057

        If Request("print_status") <> "Y" And serial_no = "" Then

            Dim rstSerial As String = "insert into serialno_resit_nekad (no_barcode) values ('X');"
            opClass1.InsertData(rstSerial)

            Dim rstSerial1 As String = "select newresit from serialno_resit_nekad  order by newresit desc"
            SQLReader = opClass.DataReader(rstSerial1)

            SQLReader.Read()

            serial_no = SQLReader(0)

            SQLReader.Close()
            SQLReader = Nothing

        End If


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

            Dim sql11 As String = "select bil_siri_resit from no_siri_resit_nekad where no_barcode='" & Trim(arrBayarCol(0)) & "' and kod_agen = '" & Trim(Request("kod_agen")) & "'"
            SQLReader = opClass.DataReader(sql11)

            SQLReader.Read()

            If Not SQLReader.HasRows Then
                'empty()
                Dim gconSQL As String = "insert into no_siri_resit_nekad(no_barcode,no_invois,bil_siri_resit,siri_module,kod_agen,print_status,site_code) " _
                & " values('" & Trim(arrBayarCol(0)) & "','" & Trim(intInvois) & "','" & Trim(serial_no) & "','" & Trim(siri_module) & "','" & Trim(Request("kod_agen")) & "','0','" & Right(Trim(arrBayarCol(0)), 3) & "')"
                opClass1.InsertData(gconSQL)

            Else

                serial_no = SQLReader("bil_siri_resit")

            End If

            SQLReader.Close()
            SQLReader = Nothing

        Next


        Dim strSQL As String = "select h.* from iccs_payment_receipt p inner join  iccs_form_header h " _
        & "on p.form_header_id=h.company_code where  p.receipt_id='iResitCFC'"
        SQLReader = opClass.DataReader(strSQL)


        If SQLReader.HasRows Then
            SQLReader.Read()

            cname = Trim(SQLReader("company_name"))
            cdesc = Trim(SQLReader("company_desc"))
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


        iResitG2b = New ReportDocument()

        Dim reportPath As String = Server.MapPath("rpt/iResitG2b.rpt")

        iResitG2b.Load(reportPath)

        Dim selectFormula As String = ""

        selectFormula = "{ITEM_CAJ.Kod_Service_Caj}= 'Caj Pengisytiharan (Borang SKPI) - CFC' AND {no_siri_resit_nekad.bil_siri_resit} = '" & Trim(serial_no) & "' AND {ITEM_CAJ.Dicaj_Oleh} = 'CFC' AND {PEMBAYARAN_CAJ_SKPI.siri_module}='agent_receipt'"

        Dim sdatetime As String = ""

        Dim sqldate As String = "select getdate() as sdatetime"
        SQLReader = opClass.DataReader(sqldate)

        SQLReader.Read()

        sdatetime = SQLReader("sdatetime")

        SQLReader.Close()
        SQLReader = Nothing

        iResitG2b.DataDefinition.FormulaFields("company_name").Text = "'" & cname & "'"
        iResitG2b.DataDefinition.FormulaFields("company_desc").Text = "'" & cdesc & "'"
        iResitG2b.DataDefinition.FormulaFields("company_add1").Text = "'" & add1 & "'"
        iResitG2b.DataDefinition.FormulaFields("company_add2").Text = "'" & add2 & "'"
        iResitG2b.DataDefinition.FormulaFields("company_add3").Text = "'" & add3 & "'"
        iResitG2b.DataDefinition.FormulaFields("company_add4").Text = "'" & add4 & "'"
        iResitG2b.DataDefinition.FormulaFields("sdatetime").Text = "'" & sdatetime & "'"

        iResitG2b.DataDefinition.RecordSelectionFormula = selectFormula
        myCrystalReportViewer.ReportSource = iResitG2b

        SetDBLogonForReport(myConnectionInfo, iResitG2b)

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
        iResitG2b.Close()
        iResitG2b.Dispose()
        GC.SuppressFinalize(True)
        GC.Collect()

    End Sub
End Class
