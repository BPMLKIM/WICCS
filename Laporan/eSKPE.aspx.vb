Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class _Default
    Inherits System.Web.UI.Page
    Private crSKPE As ReportDocument
    Protected opClass As SQLOperationE

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        opClass = New SQLOperationE()
        opClass.dbConnection()
        Dim formula As String = "{PENGISYTIHARAN_I.No_Barcode} = '" & Request("barcode") & "' AND {PENGISYTIHARAN_I.Status} = 'A'" '  and {PENGISYTIHARAN_I.No_SKPE} = '" & request("skpi") & "'"
        'Response.Write(printer_name.Value)

        Dim myConnectionInfo As ConnectionInfo = New ConnectionInfo()
        myConnectionInfo.DatabaseName = System.Configuration.ConfigurationManager.AppSettings("dbname")
        myConnectionInfo.UserID = System.Configuration.ConfigurationManager.AppSettings("userid")
        myConnectionInfo.Password = System.Configuration.ConfigurationManager.AppSettings("dbpassword")
        myConnectionInfo.ServerName = System.Configuration.ConfigurationManager.AppSettings("servername")

        crSKPE = New ReportDocument()
        Dim reportPath As String = Server.MapPath("rpt/SalinancrSKPE.rpt")
        crSKPE.Load(reportPath)

        'Dim selectFormula As String = formula '"{PENGISYTIHARAN_I.No_Barcode} = '" & Request("barcode") & "' AND {PENGISYTIHARAN_I.Status} = 'A'"
        crSKPE.DataDefinition.RecordSelectionFormula = formula
        opClass.SetDBLogonForReport(myConnectionInfo, crSKPE)
        CrystalReportViewer1.ReportSource = crSKPE

        'Dim namaPrinter As String = printer_name.Value '"KONICA MINOLTA 7145/IP-432" '
        'opClass.ConfigureCrystalReportsSKPEPrint("rpt/SalinancrSKPE.rpt", formula)
        'CrystalReportViewer1.ReportSource = opClass.crSKPE
        'opClass.crSKPI.PrintOptions.PrinterName = namaPrinter
        'opClass.crSKPI.PrintToPrinter(1, False, 0, 0)

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        crSKPE.Close()
        crSKPE.Dispose()
        GC.SuppressFinalize(True)
        GC.Collect()
    End Sub
End Class
