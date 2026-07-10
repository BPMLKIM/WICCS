Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class _Default
    Inherits System.Web.UI.Page
    Private crMasterSheetImport As ReportDocument
    Private crMasterSheetImport_SubReport As ReportDocument

    Private Sub ConfigureCrystalReports()
       

        crMasterSheetImport = New ReportDocument()

        Dim reportPath As String = Server.MapPath("rpt/crMasterSheetExport_Top.rpt")
        
        crMasterSheetImport.Load(reportPath)

        Dim myConnectionInfo As ConnectionInfo = New ConnectionInfo()
        myConnectionInfo.DatabaseName = System.Configuration.ConfigurationManager.AppSettings("dbname")
        myConnectionInfo.UserID = System.Configuration.ConfigurationManager.AppSettings("userid")
        myConnectionInfo.Password = System.Configuration.ConfigurationManager.AppSettings("dbpassword")
        myConnectionInfo.ServerName = System.Configuration.ConfigurationManager.AppSettings("servername")


        'myConnectionInfo.DatabaseName = "w-iccs"
        'myConnectionInfo.UserID = "sa"
        'myConnectionInfo.Password = ""
        'myConnectionInfo.ServerName = "."


        'crMasterSheetImport.PrintToPrinter(1, False, 0, 0)
        '
        'myCrystalReportViewer.SelectionFormula = "{PENGISYTIHARAN_I.No_Barcode} = '1070222170213001' AND {PENGISYTIHARAN_I.Status} = 'A'"

        Dim selectFormula As String = "{PENGISYTIHARAN_I.No_Barcode} = '" & Request("barcode") & "' AND {PENGISYTIHARAN_I.Status} = 'A'"
        crMasterSheetImport.DataDefinition.FormulaFields("MS_NoInvois").Text = "'" & Request("invois_id") & "'"
        crMasterSheetImport.DataDefinition.FormulaFields("MS_Salinan").Text = "'" & Request("SalinanMs") & "'"
        crMasterSheetImport.DataDefinition.RecordSelectionFormula = selectFormula
        SetDBLogonForReport(myConnectionInfo, crMasterSheetImport)
        SetDBLogonForSubreports(myConnectionInfo, crMasterSheetImport)
        myCrystalReportViewer.ReportSource = crMasterSheetImport
        
        

    End Sub

    Private Sub SetDBLogonForReport(ByVal myConnectionInfo As ConnectionInfo, ByVal myReportDocument As ReportDocument)
        Dim myTables As Tables = myReportDocument.Database.Tables
        For Each myTable As CrystalDecisions.CrystalReports.Engine.Table In myTables
            Dim myTableLogonInfo As TableLogOnInfo = myTable.LogOnInfo
            myTableLogonInfo.ConnectionInfo = myConnectionInfo
            myTable.ApplyLogOnInfo(myTableLogonInfo)
        Next
    End Sub
    Private Sub SetDBLogonForSubreports(ByVal myConnectionInfo As ConnectionInfo, ByVal myReportDocument As ReportDocument)
        Dim mySections As Sections = myReportDocument.ReportDefinition.Sections
        For Each mySection As Section In mySections
            Dim myReportObjects As ReportObjects = mySection.ReportObjects
            For Each myReportObject As ReportObject In myReportObjects
                If myReportObject.Kind = ReportObjectKind.SubreportObject Then
                    Dim mySubreportObject As SubreportObject = CType(myReportObject, SubreportObject)
                    Dim subReportDocument As ReportDocument = mySubreportObject.OpenSubreport(mySubreportObject.SubreportName)
                    SetDBLogonForReport(myConnectionInfo, subReportDocument)
                End If
            Next
        Next

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        ConfigureCrystalReports()

    End Sub
End Class
