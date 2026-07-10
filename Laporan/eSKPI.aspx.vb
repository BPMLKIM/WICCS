Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class _Default
    Inherits System.Web.UI.Page
    Private crSKPI As ReportDocument
    Protected opClass As SQLOperation

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        opClass = New SQLOperation()
        opClass.dbConnection()
        Dim formula As String = "{PENGISYTIHARAN_I.No_Barcode} = '" & Request("barcode") & "' AND {PENGISYTIHARAN_I.Status} = 'A'" '  and {PENGISYTIHARAN_I.No_SKPI} = '" & Request("skpi") & "'"
        'Response.Write(printer_name.Value)

        Dim myConnectionInfo As ConnectionInfo = New ConnectionInfo()
        myConnectionInfo.DatabaseName = System.Configuration.ConfigurationManager.AppSettings("dbname")
        myConnectionInfo.UserID = System.Configuration.ConfigurationManager.AppSettings("userid")
        myConnectionInfo.Password = System.Configuration.ConfigurationManager.AppSettings("dbpassword")
        myConnectionInfo.ServerName = System.Configuration.ConfigurationManager.AppSettings("servername")

        crSKPI = New ReportDocument()

        Dim reportPath As String = Server.MapPath("rpt/SalinancrSKPI.rpt")

        crSKPI.Load(reportPath)

        Dim selectFormula As String = formula '"{PENGISYTIHARAN_I.No_Barcode} = '" & Request("barcode") & "' AND {PENGISYTIHARAN_I.Status} = 'A'"
        crSKPI.DataDefinition.RecordSelectionFormula = selectFormula
        opClass.SetDBLogonForReport(myConnectionInfo, crSKPI)
        CrystalReportViewer1.ReportSource = crSKPI
        'If request("barcode") = "1080224073343001" Then
        'CrystalReportViewer1.hasprintbutton = False
        'End If
        'Dim namaPrinter As String = printer_name.Value '"KONICA MINOLTA 7145/IP-432" '
        'opClass.ConfigureCrystalReportsSKPIPrint("rpt/SalinancrSKPI.rpt", formula)
        'CrystalReportViewer1.ReportSource = opClass.crSKPI
        'opClass.crSKPI.PrintOptions.PrinterName = namaPrinter
        'opClass.crSKPI.PrintToPrinter(1, False, 0, 0)
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        crSKPI.Close()
        crSKPI.Dispose()
        GC.SuppressFinalize(True)
        GC.Collect()
    End Sub

End Class
