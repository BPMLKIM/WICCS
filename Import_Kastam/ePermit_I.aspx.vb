Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class ePermit_I
    Inherits System.Web.UI.Page
    Private ePermit As ReportDocument

    Private Sub ConfigureCrystalReports()
        Dim myConnectionInfo As ConnectionInfo = New ConnectionInfo()
        myConnectionInfo.DatabaseName = System.Configuration.ConfigurationManager.AppSettings("dbname")
        myConnectionInfo.UserID = System.Configuration.ConfigurationManager.AppSettings("userid")
        myConnectionInfo.Password = System.Configuration.ConfigurationManager.AppSettings("dbpassword")
        myConnectionInfo.ServerName = System.Configuration.ConfigurationManager.AppSettings("servername")

        ePermit = New ReportDocument()

        Dim reportPath As String = Server.MapPath("rpt/e_permit_i.rpt")

        ePermit.Load(reportPath)

        'ePermit.PrintToPrinter(1, False, 0, 0)
        '
        'myCrystalReportViewer.SelectionFormula = "{PENGISYTIHARAN_I.No_Barcode} = '1070222170213001' AND {PENGISYTIHARAN_I.Status} = 'A'"

        Dim selectFormula As String = "{PENGISYTIHARAN_I.No_Barcode} = '" & Request("barcode") & "' AND {PENGISYTIHARAN_I.Status} = 'A' AND {NO_INVOIS.No_Invois} = '" & Request("CurrentInvois") & "'"

        ePermit.DataDefinition.RecordSelectionFormula = selectFormula
        myCrystalReportViewer.ReportSource = ePermit

        SetDBLogonForReport(myConnectionInfo, ePermit)
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
