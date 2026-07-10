Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class _Default
    Inherits System.Web.UI.Page
    Private sistem_q_report As ReportDocument

    Private Sub ConfigureCrystalReports()

        sistem_q_report = New ReportDocument()

        Dim reportPath As String = Server.MapPath("rpt/sistem_q_report.rpt")

        Dim aDate As String
        Dim adate2 As String

        aDate = Left(Right(Request("tarikhmasa"), 7), 2) & "/" & Left(Request("tarikhmasa"), 2) & "/" & Right(Request("tarikhmasa"), 4)
        adate2 = Left(Right(Request("tarikhmasa2"), 7), 2) & "/" & Left(Request("tarikhmasa2"), 2) & "/" & Right(Request("tarikhmasa2"), 4)
        sistem_q_report.Load(reportPath)

        Dim myConnectionInfo As ConnectionInfo = New ConnectionInfo()
        myConnectionInfo.DatabaseName = System.Configuration.ConfigurationManager.AppSettings("dbname")
        myConnectionInfo.UserID = System.Configuration.ConfigurationManager.AppSettings("userid")
        myConnectionInfo.Password = System.Configuration.ConfigurationManager.AppSettings("dbpassword")
        myConnectionInfo.ServerName = System.Configuration.ConfigurationManager.AppSettings("servername")

        'myConnectionInfo.DatabaseName = "w-iccs"
        'myConnectionInfo.UserID = "sa"
        'myConnectionInfo.Password = ""
        'myConnectionInfo.ServerName = "."


        If Request("pilihan") = "Import" Or Request("tarikhmasa") = "" Or Request("tarikhmasa2") = "" Then
            Dim selectFormula As String = "{pendaftaran_pintu.kod_jenis_urusan}<>'003' and {pendaftaran_pintu.kod_jenis_urusan}<>'004' and {pendaftaran_pintu.kod_jenis_urusan}<>'005' and {pendaftaran_pintu.kod_jenis_urusan}<>'006' and {pendaftaran_pintu.kod_jenis_urusan}<>'007' and {pendaftaran_pintu.kod_jenis_urusan}<>'008' and {pendaftaran_pintu.kod_jenis_urusan}<>'009' and {pendaftaran_pintu.kod_jenis_urusan}<>'010' and {pendaftaran_pintu.kod_jenis_urusan}<>'011' and {pendaftaran_pintu.kod_jenis_urusan}<>'012' and {pendaftaran_pintu.kod_jenis_urusan}<>'013' and {pendaftaran_pintu.kod_jenis_urusan}<>'014' and {pendaftaran_pintu.kod_jenis_urusan}<>'015' and {pendaftaran_pintu.kod_jenis_urusan}<>'017' and {pendaftaran_pintu.kod_jenis_urusan}<>'018' and {pendaftaran_pintu.kod_jenis_urusan}<>'019' and {pendaftaran_pintu.kod_jenis_urusan}<>'020' and {pendaftaran_pintu.tarikh_masa_masuk}>=date('" & aDate & "') and {pendaftaran_pintu.tarikh_masa_masuk}<=date('" & adate2 & "')"
            sistem_q_report.DataDefinition.FormulaFields("data1").Text = "'" & Request("SalinanMs") & "'"
            sistem_q_report.DataDefinition.FormulaFields("status").Text = "'" & Request("pilihan") & "'"
            sistem_q_report.DataDefinition.FormulaFields("status2").Text = "'" & Request("SalinanMs2") & "'"
            sistem_q_report.DataDefinition.FormulaFields("jawatanvalue").Text = "'" & Request("SalinanMs3") & "'"
            sistem_q_report.DataDefinition.RecordSelectionFormula = selectFormula
            myCrystalReportViewer.ReportSource = sistem_q_report
            SetDBLogonForReport(myConnectionInfo, sistem_q_report)
        End If

        If Request("pilihan") = "Eksport" Or Request("tarikhmasa") = "" Or Request("tarikhmasa2") = "" Then
            Dim selectFormula As String = "{pendaftaran_pintu.kod_jenis_urusan}<>'001' and {pendaftaran_pintu.kod_jenis_urusan}<>'002' and {pendaftaran_pintu.kod_jenis_urusan}<>'004' and {pendaftaran_pintu.kod_jenis_urusan}<>'005' and {pendaftaran_pintu.kod_jenis_urusan}<>'006' and {pendaftaran_pintu.kod_jenis_urusan}<>'007' and {pendaftaran_pintu.kod_jenis_urusan}<>'008' and {pendaftaran_pintu.kod_jenis_urusan}<>'009' and {pendaftaran_pintu.kod_jenis_urusan}<>'010' and {pendaftaran_pintu.kod_jenis_urusan}<>'011' and {pendaftaran_pintu.kod_jenis_urusan}<>'012' and {pendaftaran_pintu.kod_jenis_urusan}<>'013' and {pendaftaran_pintu.kod_jenis_urusan}<>'014' and {pendaftaran_pintu.kod_jenis_urusan}<>'015' and {pendaftaran_pintu.kod_jenis_urusan}<>'016' and {pendaftaran_pintu.kod_jenis_urusan}<>'017' and {pendaftaran_pintu.kod_jenis_urusan}<>'019' and {pendaftaran_pintu.kod_jenis_urusan}<>'020' and {pendaftaran_pintu.tarikh_masa_masuk}>=date('" & aDate & "') and {pendaftaran_pintu.tarikh_masa_masuk}<=date('" & adate2 & "')"
            sistem_q_report.DataDefinition.FormulaFields("data1").Text = "'" & Request("SalinanMs") & "'"
            sistem_q_report.DataDefinition.FormulaFields("status").Text = "'" & Request("pilihan") & "'"
            sistem_q_report.DataDefinition.FormulaFields("status2").Text = "'" & Request("SalinanMs2") & "'"
            sistem_q_report.DataDefinition.FormulaFields("jawatanvalue").Text = "'" & Request("SalinanMs3") & "'"
            sistem_q_report.DataDefinition.RecordSelectionFormula = selectFormula
            myCrystalReportViewer.ReportSource = sistem_q_report
            SetDBLogonForReport(myConnectionInfo, sistem_q_report)
        End If

        If Request("pilihan") = "Transit" Or Request("tarikhmasa") = "" Or Request("tarikhmasa2") = "" Then
            Dim selectFormula As String = "{pendaftaran_pintu.kod_jenis_urusan}<>'001' and {pendaftaran_pintu.kod_jenis_urusan}<>'002' and {pendaftaran_pintu.kod_jenis_urusan}<>'003' and {pendaftaran_pintu.kod_jenis_urusan}<>'007' and {pendaftaran_pintu.kod_jenis_urusan}<>'008' and {pendaftaran_pintu.kod_jenis_urusan}<>'009' and {pendaftaran_pintu.kod_jenis_urusan}<>'016' and {pendaftaran_pintu.kod_jenis_urusan}<>'017' and {pendaftaran_pintu.kod_jenis_urusan}<>'018' and {pendaftaran_pintu.kod_jenis_urusan}<>'019' and {pendaftaran_pintu.kod_jenis_urusan}<>'020' and {pendaftaran_pintu.tarikh_masa_masuk}>=date('" & aDate & "') and {pendaftaran_pintu.tarikh_masa_masuk}<=date('" & adate2 & "')"
            sistem_q_report.DataDefinition.FormulaFields("data1").Text = "'" & Request("SalinanMs") & "'"
            sistem_q_report.DataDefinition.FormulaFields("status").Text = "'" & Request("pilihan") & "'"
            sistem_q_report.DataDefinition.FormulaFields("status2").Text = "'" & Request("SalinanMs2") & "'"
            sistem_q_report.DataDefinition.FormulaFields("jawatanvalue").Text = "'" & Request("SalinanMs3") & "'"
            sistem_q_report.DataDefinition.RecordSelectionFormula = selectFormula
            myCrystalReportViewer.ReportSource = sistem_q_report
            SetDBLogonForReport(myConnectionInfo, sistem_q_report)
        End If

        If Request("pilihan") = "Barangan Bukan Ikan" Or Request("tarikhmasa") = "" Or Request("tarikhmasa2") = "" Then
            Dim selectFormula As String = "{pendaftaran_pintu.kod_jenis_urusan}<>'001' and {pendaftaran_pintu.kod_jenis_urusan}<>'002' and {pendaftaran_pintu.kod_jenis_urusan}<>'003' and {pendaftaran_pintu.kod_jenis_urusan}<>'004' and {pendaftaran_pintu.kod_jenis_urusan}<>'005' and {pendaftaran_pintu.kod_jenis_urusan}<>'006' and {pendaftaran_pintu.kod_jenis_urusan}<>'010' and {pendaftaran_pintu.kod_jenis_urusan}<>'011' and {pendaftaran_pintu.kod_jenis_urusan}<>'012' and {pendaftaran_pintu.kod_jenis_urusan}<>'013' and {pendaftaran_pintu.kod_jenis_urusan}<>'014' and {pendaftaran_pintu.kod_jenis_urusan}<>'015' and {pendaftaran_pintu.kod_jenis_urusan}<>'016' and {pendaftaran_pintu.kod_jenis_urusan}<>'018' and {pendaftaran_pintu.tarikh_masa_masuk}>=date('" & aDate & "') and {pendaftaran_pintu.tarikh_masa_masuk}<=date('" & adate2 & "')"
            sistem_q_report.DataDefinition.FormulaFields("data1").Text = "'" & Request("SalinanMs") & "'"
            sistem_q_report.DataDefinition.FormulaFields("status").Text = "'" & Request("pilihan") & "'"
            sistem_q_report.DataDefinition.FormulaFields("status2").Text = "'" & Request("SalinanMs2") & "'"
            sistem_q_report.DataDefinition.FormulaFields("jawatanvalue").Text = "'" & Request("SalinanMs3") & "'"
            sistem_q_report.DataDefinition.RecordSelectionFormula = selectFormula
            myCrystalReportViewer.ReportSource = sistem_q_report
            SetDBLogonForReport(myConnectionInfo, sistem_q_report)
        End If

        If Request("pilihan") = "Semua" Or Request("tarikhmasa") = "" Or Request("tarikhmasa2") = "" Then
            Dim selectFormula As String = "{pendaftaran_pintu.tarikh_masa_masuk}>=date('" & aDate & "') and {pendaftaran_pintu.tarikh_masa_masuk}<=date('" & adate2 & "')"
            sistem_q_report.DataDefinition.FormulaFields("data1").Text = "'" & Request("SalinanMs") & "'"
            sistem_q_report.DataDefinition.FormulaFields("status").Text = "'" & Request("pilihan") & "'"
            sistem_q_report.DataDefinition.FormulaFields("status2").Text = "'" & Request("SalinanMs2") & "'"
            sistem_q_report.DataDefinition.FormulaFields("jawatanvalue").Text = "'" & Request("SalinanMs3") & "'"
            sistem_q_report.DataDefinition.RecordSelectionFormula = selectFormula
            myCrystalReportViewer.ReportSource = sistem_q_report
            SetDBLogonForReport(myConnectionInfo, sistem_q_report)
        End If

        If Request("pilihan") = "" Or Request("tarikhmasa") = "" Or Request("tarikhmasa2") = "" Then
            Dim selectFormula As String = ""
            sistem_q_report.DataDefinition.FormulaFields("data1").Text = "'" & Request("SalinanMs") & "'"
            sistem_q_report.DataDefinition.FormulaFields("status").Text = "'" & Request("pilihan") & "'"
            sistem_q_report.DataDefinition.FormulaFields("status2").Text = "'" & Request("SalinanMs2") & "'"
            sistem_q_report.DataDefinition.FormulaFields("jawatanvalue").Text = "'" & Request("SalinanMs3") & "'"
            sistem_q_report.DataDefinition.RecordSelectionFormula = selectFormula
            myCrystalReportViewer.ReportSource = sistem_q_report
            SetDBLogonForReport(myConnectionInfo, sistem_q_report)
        End If
       
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
        sistem_q_report.Close()
        sistem_q_report.Dispose()
        GC.SuppressFinalize(True)
        GC.Collect()
    End Sub
End Class
