Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class _Default
    Inherits System.Web.UI.Page
    Private crSKPI As ReportDocument

    Private Sub ConfigureCrystalReports()
        Dim myConnectionInfo As ConnectionInfo = New ConnectionInfo()
        myConnectionInfo.DatabaseName = System.Configuration.ConfigurationManager.AppSettings("dbname")
        myConnectionInfo.UserID = System.Configuration.ConfigurationManager.AppSettings("userid")
        myConnectionInfo.Password = System.Configuration.ConfigurationManager.AppSettings("dbpassword")
        myConnectionInfo.ServerName = System.Configuration.ConfigurationManager.AppSettings("servername")

        
        'myConnectionInfo.DatabaseName = "w-iccs"
        'myConnectionInfo.UserID = "sa"
        'myConnectionInfo.Password = ""
        'myConnectionInfo.ServerName = "."
        crSKPI = New ReportDocument()

        Dim reportPath As String = Server.MapPath("rpt/crSKPI-P.rpt")

        crSKPI.Load(reportPath)

        'crSKPI.PrintToPrinter(1, False, 0, 0)
        '
        'myCrystalReportViewer.SelectionFormula = "{PENGISYTIHARAN_I.No_Barcode} = '1070222170213001' AND {PENGISYTIHARAN_I.Status} = 'A'"

        Dim selectFormula As String = "{PENGISYTIHARAN_I.No_Barcode} = '" & Request("barcode") & "' AND {PENGISYTIHARAN_I.Status} = 'A'"

        crSKPI.DataDefinition.RecordSelectionFormula = selectFormula
        myCrystalReportViewer.ReportSource = crSKPI
        
        SetDBLogonForReport(myConnectionInfo, crSKPI)
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
End Class
