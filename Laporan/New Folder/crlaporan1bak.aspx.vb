Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class _Default
    Inherits System.Web.UI.Page
    Private crDisplayreport As ReportDocument

    Private Sub ConfigureCrystalReports()

        Dim aDate As String = ""
        Dim aDate2 As String = ""
        Dim bDate As String = ""
        Dim ReportName As String = ""
        Dim selectFormula As String = ""

        If Request("type") = "H" Then
            aDate = Right(Request("Tarikh1"), 4) & "," & Left(Right(Request("Tarikh1"), 7), 2) & "," & Left(Request("Tarikh1"), 2)
            bDate = Right(Request("Tarikh2"), 4) & "," & Left(Right(Request("Tarikh2"), 7), 2) & "," & Left(Request("Tarikh2"), 2)

            'Response.Write(aDate)
            ReportName = Request("rptH")
            selectFormula = "{kad_transaction_log.transaction_date}= date(" & aDate & ")"
            Response.Write(selectFormula)

        ElseIf Request("type") = "B" Then
            aDate = startDate(Left(Request("Bulan1"), 2), Right(Request("Bulan1"), 4))
            bDate = EndDate(Left(Request("Bulan2"), 2), Right(Request("Bulan2"), 4))
            ReportName = Request("rptB")
            selectFormula = "{kad_transaction_log.transaction_date}>= date(" & aDate & ") and {kad_transaction_log.transaction_date}<= date(" & bDate & ") "
        ElseIf Request("type") = "T" Then
            aDate = startDate("01", Request("Tahun1"))
            bDate = EndDate("12", Request("Tahun2"))
            selectFormula = "{kad_transaction_log.transaction_date}>= date(" & aDate & ") and {kad_transaction_log.transaction_date}<= date(" & bDate & ")"
        End If

       
        Dim myConnectionInfo As ConnectionInfo = New ConnectionInfo()

        crDisplayreport = New ReportDocument()

        'edited by zue on 16/06/2007
        myConnectionInfo.DatabaseName = System.Configuration.ConfigurationManager.AppSettings("dbname")
        myConnectionInfo.UserID = System.Configuration.ConfigurationManager.AppSettings("userid")
        myConnectionInfo.Password = System.Configuration.ConfigurationManager.AppSettings("dbpassword")
        myConnectionInfo.ServerName = System.Configuration.ConfigurationManager.AppSettings("servername")

        Dim reportPath As String = Server.MapPath("laporan kad prepaid report/rpt/Log_pergerakan_kenderaan_keluar_masuk_komplex_report.rpt")
        crDisplayreport.Load(reportPath)

        

        crDisplayreport.DataDefinition.RecordSelectionFormula = selectFormula
        SetDBLogonForReport(myConnectionInfo, crDisplayreport)
        myCrystalReportViewer.ReportSource = crDisplayreport

    End Sub

    Private Sub SetDBLogonForReport(ByVal myConnectionInfo As ConnectionInfo, ByVal myReportDocument As ReportDocument)
        Dim myTables As Tables = myReportDocument.Database.Tables
        For Each myTable As CrystalDecisions.CrystalReports.Engine.Table In myTables
            Dim myTableLogonInfo As TableLogOnInfo = myTable.LogOnInfo
            myTableLogonInfo.ConnectionInfo = myConnectionInfo
            myTable.ApplyLogOnInfo(myTableLogonInfo)
        Next
    End Sub

    Private Function startDate(ByVal strMonth As String, ByVal strYear As String) As String
        startDate = "Error"

        Select Case strMonth
            Case "01" : startDate = strYear & ",01,01"
            Case "02" : startDate = strYear & ",02,01"
            Case "03" : startDate = strYear & ",03,01"
            Case "04" : startDate = strYear & ",04,01"
            Case "05" : startDate = strYear & ",05,01"
            Case "06" : startDate = strYear & ",06,01"
            Case "07" : startDate = strYear & ",07,01"
            Case "08" : startDate = strYear & ",08,01"
            Case "09" : startDate = strYear & ",09,01"
            Case "10" : startDate = strYear & ",10,01"
            Case "11" : startDate = strYear & ",11,01"
            Case "12" : startDate = strYear & ",12,01"
        End Select

    End Function

    Public Function EndDate(ByVal strMonth As String, ByVal strYear As String) As String
        Dim baki As Long

        EndDate = "Error"

        Select Case strMonth
            Case "01" : EndDate = strYear & ",01,31"

            Case "02"
                baki = strYear Mod 4
                If baki <> 0 Then
                    EndDate = strYear & ",02,28"
                Else
                    EndDate = strYear & ",02,29"
                End If
            Case "03" : EndDate = strYear & ",03,31"
            Case "04" : EndDate = strYear & ",04,30"
            Case "05" : EndDate = strYear & ",05,31"
            Case "06" : EndDate = strYear & ",06,30"
            Case "07" : EndDate = strYear & ",07,31"
            Case "08" : EndDate = strYear & ",08,31"
            Case "09" : EndDate = strYear & ",09,30"
            Case "10" : EndDate = strYear & ",10,31"
            Case "11" : EndDate = strYear & ",11,30"
            Case "12" : EndDate = strYear & ",12,31"
        End Select
    End Function

    Private Function Month2Name(ByVal strMonth As Integer) As String
        Month2Name = "Januari"

        If strMonth = 1 Then
            Month2Name = "Januari"
        ElseIf strMonth = 2 Then
            Month2Name = "Februari"
        ElseIf strMonth = 3 Then
            Month2Name = "Mac"
        ElseIf strMonth = 4 Then
            Month2Name = "April"
        ElseIf strMonth = 5 Then
            Month2Name = "Mei"
        ElseIf strMonth = 6 Then
            Month2Name = "Jun"
        ElseIf strMonth = 7 Then
            Month2Name = "Julai"
        ElseIf strMonth = 8 Then
            Month2Name = "Ogos"
        ElseIf strMonth = 9 Then
            Month2Name = "September"
        ElseIf strMonth = 10 Then
            Month2Name = "Oktober"
        ElseIf strMonth = 11 Then
            Month2Name = "November"
        ElseIf strMonth = 12 Then
            Month2Name = "Disember"
        End If
    End Function

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        ConfigureCrystalReports()

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        crDisplayreport.Close()
        crDisplayreport.Dispose()
        GC.SuppressFinalize(True)
        GC.Collect()

    End Sub
End Class