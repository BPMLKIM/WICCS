Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class _Default
    Inherits System.Web.UI.Page
    Private crDisplayreport As ReportDocument

    Private Sub ConfigureCrystalReports()

        Dim aDate As String = ""
        Dim bDate As String = ""
        Dim ReportName As String = ""

        If Request("type") = "H" Then
            aDate = Right(Request("Tarikh1"), 4) & "," & Left(Right(Request("Tarikh1"), 7), 2) & "," & Left(Request("Tarikh1"), 2)
            bDate = Right(Request("Tarikh2"), 4) & "," & Left(Right(Request("Tarikh2"), 7), 2) & "," & Left(Request("Tarikh2"), 2)
            ReportName = Request("rptH")
        ElseIf Request("type") = "B" Then
            aDate = startDate(Left(Request("Bulan1"), 2), Right(Request("Bulan1"), 4))
            bDate = EndDate(Left(Request("Bulan2"), 2), Right(Request("Bulan2"), 4))
            ReportName = Request("rptB")
        ElseIf Request("type") = "T" Then
            aDate = startDate("01", Request("Tahun1"))
            bDate = EndDate("12", Request("Tahun2"))
            ReportName = Request("rptT")
        End If

        Dim selectFormula As String = ""
        Dim myConnectionInfo As ConnectionInfo = New ConnectionInfo()

        crDisplayreport = New ReportDocument()

        'edited by zue on 16/06/2007
        myConnectionInfo.DatabaseName = System.Configuration.ConfigurationManager.AppSettings("dbname")
        myConnectionInfo.UserID = System.Configuration.ConfigurationManager.AppSettings("userid")
        myConnectionInfo.Password = System.Configuration.ConfigurationManager.AppSettings("dbpassword")
        myConnectionInfo.ServerName = System.Configuration.ConfigurationManager.AppSettings("servername")


        'myConnectionInfo.DatabaseName = "w-iccs"
        'myConnectionInfo.UserID = "sa"
        'myConnectionInfo.Password = ""
        'myConnectionInfo.ServerName = "."

        ' end coded
        

        Dim reportPath As String = Server.MapPath("rpt/" & ReportName)
        crDisplayreport.Load(reportPath)

        If Request("id") = 3 Or Request("id") = 5 Then
            selectFormula = "{PENGISYTIHARAN_I.Status} = 'A' and {PENGISYTIHARAN_I.Tarikh_Isytihar} >= date(" & aDate & ") and {PENGISYTIHARAN_I.Tarikh_Isytihar} <= date(" & bDate & ")"
        ElseIf Request("id") = 7 Or Request("id") = 9 Or Request("id") = 11 Then
            selectFormula = "{PENGISYTIHARAN_I.Status} = 'A' AND {PENGISYTIHARAN_I.Tarikh_Isytihar} >= date(" & aDate & ") and {PENGISYTIHARAN_I.Tarikh_Isytihar} <= date(" & bDate & ") AND ({PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '004' AND {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '005' AND {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '006' AND {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '011' AND {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '012' AND {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '010')"
        ElseIf Request("id") = 8 Then
            selectFormula = "{PENGISYTIHARAN_E.Status} = 'A' AND {PENGISYTIHARAN_E.Tarikh_Isytihar} >= date(" & aDate & ") and {PENGISYTIHARAN_E.Tarikh_Isytihar} <= date(" & bDate & ") AND {JENIS_IKAN.Kod_Kategori_Ikan} = '4' AND ({PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '004' AND {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '005' AND {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '006' AND {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '011' AND {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '012' AND {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '010')"
        ElseIf Request("id") = 12 Then
            If Request("Spesis") = "Semua" Then
                selectFormula = "{PENGISYTIHARAN_I.Status} = 'A' and ({PENGISYTIHARAN_I.Tarikh_Isytihar} >= date('" & aDate & "') and {PENGISYTIHARAN_I.Tarikh_Isytihar} <= date('" & bDate & "'))"
            Else
                selectFormula = "{JENIS_IKAN.Nama_BKH} = '" & Request("Spesis") & "' and {PENGISYTIHARAN_I.Status} = 'A' and ({PENGISYTIHARAN_I.Tarikh_Isytihar} >= date('" & aDate & "') and {PENGISYTIHARAN_I.Tarikh_Isytihar} <= date('" & bDate & "'))"
            End If
        ElseIf Request("id") = 14 Then
            selectFormula = "{PENGISYTIHARAN_I.Status} = 'A' AND {PENGISYTIHARAN_I.Tarikh_Isytihar} >= date(" & aDate & ") and {PENGISYTIHARAN_I.Tarikh_Isytihar} <= date(" & bDate & ") AND {JENIS_IKAN.Kod_Kategori_Ikan} = '4' AND ({PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '004' AND {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '005' AND {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '006' AND {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '011' AND {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '012' AND {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '010')"
        ElseIf Request("id") = 16 Then
            selectFormula = "{PENGISYTIHARAN_I.Status} = 'A' AND {PENGISYTIHARAN_I.Tarikh_Isytihar} >= date(" & aDate & ") and {PENGISYTIHARAN_I.Tarikh_Isytihar} <= date(" & bDate & ") AND ({PENDAFTARAN_PINTU.Kod_Jenis_Urusan} = '004' OR {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} = '005' OR {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} = '006' OR {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} = '011' OR {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} = '012' OR {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} = '014' OR {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} = '015' OR {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} = '010')"
        ElseIf Request("id") = 18 Then 'Destinasi Pasar'
            If Request("Pasar") = "Semua" Then
                selectFormula = "{PENGISYTIHARAN_I.Status} = 'A' AND {PENGISYTIHARAN_I.Tarikh_Isytihar} >= date(" & aDate & ") and {PENGISYTIHARAN_I.Tarikh_Isytihar} <= date(" & bDate & ") AND ({PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '004' AND {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '005' AND {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '006' AND {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '011' AND {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '012' AND {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '010')"
            Else
                selectFormula = "{DESTINASI_PASAR.Nama_Pasar} = '" & Request("Pasar") & "' and {PENGISYTIHARAN_I.Status} = 'A' AND {PENGISYTIHARAN_I.Tarikh_Isytihar} >= date(" & aDate & ") and {PENGISYTIHARAN_I.Tarikh_Isytihar} <= date(" & bDate & ") AND ({PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '004' AND {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '005' AND {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '006' AND {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '011' AND {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '012' AND {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '010')"
            End If
        ElseIf Request("id") = 23 Then
            selectFormula = "{PENGISYTIHARAN_E.Status} = 'A' AND {PENGISYTIHARAN_E.Tarikh_Isytihar} >= date(" & aDate & ") and {PENGISYTIHARAN_E.Tarikh_Isytihar} <= date(" & bDate & ")"
        ElseIf Request("id") < 40 Then 'Laporan Keaktifan Import Ikan
            selectFormula = "{PENGISYTIHARAN_I.Status} = 'A' AND {PENGISYTIHARAN_I.Tarikh_Isytihar} >= date(" & aDate & ") and {PENGISYTIHARAN_I.Tarikh_Isytihar} <= date(" & bDate & ") AND ({PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '004' AND {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '005' AND {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '006' AND {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '011' AND {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '012' AND {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '010')"
        ElseIf Request("id") = 40 Then ' --> Laporan Import/Eksport/Transit udang 
            selectFormula = "({PENGISYTIHARAN_I.Tarikh_Isytihar} >= date('" & aDate & "') and {PENGISYTIHARAN_I.Tarikh_Isytihar} <= date('" & bDate & "')) and {JENIS_IKAN.Kod_Kumpulan}='2'"
        ElseIf Request("id") < 45 Then 'Laporan Keaktifan Eksport Ikan
            selectFormula = "{PENGISYTIHARAN_E.Status} = 'A' AND ({PENGISYTIHARAN_E.Tarikh_Isytihar} >= date(" & aDate & ") and {PENGISYTIHARAN_E.Tarikh_Isytihar} <= date(" & bDate & "))"
        ElseIf Request("id") = 45 Then 'Laporan Keaktifan Eksport Ikan
            selectFormula = "{PENGISYTIHARAN_E.Status} = 'A' AND {PENGISYTIHARAN_E.Tarikh_Isytihar} >= date(" & aDate & ") and {PENGISYTIHARAN_E.Tarikh_Isytihar} <= date(" & bDate & ") AND ({PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '004' AND {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '005' AND {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '006' AND {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '011' AND {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '012' AND {PENDAFTARAN_PINTU.Kod_Jenis_Urusan} <> '010')"
        ElseIf Request("id") = 64 Then 'Pemantauan Kenderaan
            selectFormula = "({PENDAFTARAN_PINTU.Tarikh_Masa_Masuk} >= date(" & aDate & ") AND {PENDAFTARAN_PINTU.Tarikh_Masa_Masuk} <= date(" & bDate & "))"
        ElseIf Request("id") = 65 Then 'Pemantauan Pemeriksaan Import
            selectFormula = "({PEMERIKSAAN_IMPORT.Tarikh} >= date(" & aDate & ") AND {PEMERIKSAAN_IMPORT.Tarikh} <= date(" & bDate & "))"
        ElseIf Request("id") = 66 Then 'Pemantauan Pemeriksaan Import
            selectFormula = "({PEMERIKSAAN_EKSPORT.Tarikh} >= date(" & aDate & ") AND {PEMERIKSAAN_EKSPORT.Tarikh} <= date(" & bDate & "))"
        ElseIf Request("id") = 67 Then 'Pemantauan Pengisytiharan Import
            selectFormula = "({PENGISYTIHARAN_I.Tarikh_Isytihar} >= date(" & aDate & ") AND {PENGISYTIHARAN_I.Tarikh_Isytihar} <= date(" & bDate & "))"
        ElseIf Request("id") = 68 Then 'Pemantauan Pengisytiharan Import
            selectFormula = "({PENGISYTIHARAN_E.Tarikh_Isytihar} >= date(" & aDate & ") AND {PENGISYTIHARAN_E.Tarikh_Isytihar} <= date(" & bDate & "))"
        ElseIf Request("id") = 69 Then 'Pemantauan Pengisytiharan Import
            selectFormula = "({PEMBAYARAN_CAJ.TARIKH_BAYAR} >= date(" & aDate & ") AND {PEMBAYARAN_CAJ.TARIKH_BAYAR} <= date(" & bDate & "))"
        ElseIf Request("id") = 70 Then 'Pemantauan Pengisytiharan Import
            selectFormula = "({pendaftaran_pintu.TARIKH_masa_masuk} >= date(" & aDate & ")AND {pendaftaran_pintu.TARIKH_masa_masuk} <= date(" & bDate & "))"

        End If

       
        If Request("type") = "H" Then
            If aDate = bDate Then
                crDisplayreport.DataDefinition.FormulaFields("Tajuk2").Text = "'" & Request("Tarikh1") & "'"
            Else
                crDisplayreport.DataDefinition.FormulaFields("Tajuk2").Text = "'" & Request("Tarikh1") & " - " & Request("Tarikh2") & "'"
            End If
        ElseIf Request("type") = "B" Then
            If Request("Bulan1") = Request("Bulan2") Then
                crDisplayreport.DataDefinition.FormulaFields("Tajuk2").Text = "'Untuk Bulan " & Month2Name(Left(Request("Bulan1"), 2)) & ", " & Right(Request("Bulan1"), 4) & "'"
            Else
                crDisplayreport.DataDefinition.FormulaFields("Tajuk2").Text = "'Dari Bulan " & Month2Name(Left(Request("Bulan1"), 2)) & ", " & Right(Request("Bulan1"), 4) & " Hingga " & Month2Name(Left(Request("Bulan2"), 2)) & ", " & Right(Request("Bulan2"), 4) & "'"
            End If
        ElseIf Request("type") = "T" Then
            If Request("Tahun1") = Request("Tahun2") Then
                crDisplayreport.DataDefinition.FormulaFields("Tajuk2").Text = "'Untuk Tahun " & Request("Tahun1") & "'"
            Else
                crDisplayreport.DataDefinition.FormulaFields("Tajuk2").Text = "'Dari Tahun " & Request("Tahun1") & " Hingga " & Request("Tahun2") & "'"
            End If
        End If

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