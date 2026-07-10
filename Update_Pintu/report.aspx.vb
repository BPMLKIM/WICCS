Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class _Default
    Inherits System.Web.UI.Page
    Private report As ReportDocument

    Private Sub ConfigureCrystalReports()

        report = New ReportDocument()

        Dim myConnectionInfo As ConnectionInfo = New ConnectionInfo()
        myConnectionInfo.DatabaseName = System.Configuration.ConfigurationManager.AppSettings("dbname")
        myConnectionInfo.UserID = System.Configuration.ConfigurationManager.AppSettings("userid")
        myConnectionInfo.Password = System.Configuration.ConfigurationManager.AppSettings("dbpassword")
        myConnectionInfo.ServerName = System.Configuration.ConfigurationManager.AppSettings("servername")

If Request("cetak") = "1" Then

        cetak.Value = Request("cetak")
        Dim namaPrinter As String = Request("pname").Replace("/", "\") 
   	    report = New ReportDocument()
        Dim reportPath As String = Server.MapPath("rpt/report.rpt")
        report.Load(reportPath)
        myCrystalReportViewer.ReportSource = report
		myCrystalReportViewer.Visible = False

            'Image1.ImageUrl = "../IDAutomationStreamingLinear.aspx?barcode='" & Request("strBarcode") & "'&X=&CODE_TYPE=39&ROTATE=&Bar_Height=&Left_Margin=&Top_Margin=&Check_Char=&Check_Char_Text=&Show_Text=&IR=&BearerBarVertical=&BearerBarHorizontal=&WhiteBarIncrease=&CharacterGrouping=&CaptionAbove=&CaptionBelow="
        Dim selectFormula As String = "{pendaftaran_pintu.nombor_barcode}='" & Request("strBarcode") & "'"
        report.DataDefinition.RecordSelectionFormula = selectFormula
        myCrystalReportViewer.ReportSource = report
        SetDBLogonForReport(myConnectionInfo, report)
		report.PrintOptions.PrinterName = namaPrinter
        report.PrintToPrinter(1, False, 0, 0)
	
        Else
            response.write(request)
            report = New ReportDocument()
            Dim reportPath As String = Server.MapPath("rpt/report.rpt")
            report.Load(reportPath)
            myCrystalReportViewer.ReportSource = report

            Dim selectFormula As String = "{pendaftaran_pintu.nombor_barcode}='" & Request("strBarcode") & "'"
            report.DataDefinition.RecordSelectionFormula = selectFormula
            myCrystalReportViewer.ReportSource = report
            SetDBLogonForReport(myConnectionInfo, report)
end if
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
        report.Close()
        report.Dispose()
        GC.SuppressFinalize(True)
        GC.Collect()
    End Sub
End Class
