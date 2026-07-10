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
        'ICCS_CAJ04.rpt()
        ' end coded
        'Response.Write(ReportName)
        'Response.End()


        Dim reportPath As String = Server.MapPath("rpt/" & ReportName)
        crDisplayreport.Load(reportPath)

        If Request("id") = 48 Then ' --> Laporan Caj Kenderaan Masuk Melalui Pintu Utara 
            selectFormula = "({PENDAFTARAN_PINTU.Tarikh_Masa_Masuk} >= date('" & aDate & "') and {PENDAFTARAN_PINTU.Tarikh_Masa_Masuk} <= date('" & bDate & "')) and ({PENDAFTARAN_PINTU.Pintu_Masuk} = 'Import' or {PENDAFTARAN_PINTU.Pintu_Masuk} = 'utara')"

            'If Request("type") = "H" Then
            '    selectFormula = "({PENDAFTARAN_PINTU.Tarikh_Masa_Masuk} >= date('" & aDate & "') and {PENDAFTARAN_PINTU.Tarikh_Masa_Masuk} <= date('" & bDate & "')) and ({PENDAFTARAN_PINTU.Pintu_Masuk} = 'Import' or {PENDAFTARAN_PINTU.Pintu_Masuk} = 'utara')"
            'ElseIf Request("type") = "B" Then
            '    selectFormula = "({pintumasuk.Tarikh_Masa_Masuk} >= date('" & aDate & "') and {pintumasuk.Tarikh_Masa_Masuk} <= date('" & bDate & "')) and ({pintumasuk.Pintu_Masuk} = 'Import' or {pintumasuk.Pintu_Masuk} = 'utara')"
            'ElseIf Request("type") = "T" Then
            '    selectFormula = "({PENDAFTARAN_PINTU.Tarikh_Masa_Masuk} >= date('" & aDate & "') and {PENDAFTARAN_PINTU.Tarikh_Masa_Masuk} <= date('" & bDate & "')) and ({PENDAFTARAN_PINTU.Pintu_Masuk} = 'Import' or {PENDAFTARAN_PINTU.Pintu_Masuk} = 'utara')"
            'End If

        ElseIf Request("id") = 49 Then ' --> Laporan Caj Kenderaan Masuk Melalui Pintu Selatan
            selectFormula = "({PENDAFTARAN_PINTU.Tarikh_Masa_Masuk} >= date('" & aDate & "') and {PENDAFTARAN_PINTU.Tarikh_Masa_Masuk} <= date('" & bDate & "')) and ({PENDAFTARAN_PINTU.Pintu_Masuk} = 'Eksport' or {PENDAFTARAN_PINTU.Pintu_Masuk} = 'Selatan')"

            'If Request("type") = "H" Then
            '    selectFormula = "({PENDAFTARAN_PINTU.Tarikh_Masa_Masuk} >= date('" & aDate & "') and {PENDAFTARAN_PINTU.Tarikh_Masa_Masuk} <= date('" & bDate & "')) and ({PENDAFTARAN_PINTU.Pintu_Masuk} = 'Eksport' or {PENDAFTARAN_PINTU.Pintu_Masuk} = 'Selatan')"
            'ElseIf Request("type") = "B" Then
            '    selectFormula = "({pintumasuk.Tarikh_Masa_Masuk} >= date('" & aDate & "') and {pintumasuk.Tarikh_Masa_Masuk} <= date('" & bDate & "')) and ({pintumasuk.Pintu_Masuk} = 'Eksport' or {pintumasuk.Pintu_Masuk} = 'Selatan')"
            'ElseIf Request("type") = "T" Then
            '    selectFormula = "({PENDAFTARAN_PINTU.Tarikh_Masa_Masuk} >= date('" & aDate & "') and {PENDAFTARAN_PINTU.Tarikh_Masa_Masuk} <= date('" & bDate & "')) and ({PENDAFTARAN_PINTU.Pintu_Masuk} = 'Eksport' or {PENDAFTARAN_PINTU.Pintu_Masuk} = 'Selatan')"
            'End If

        ElseIf Request("id") = 50 Then ' --> Laporan Caj Ikan Import / Transit (Kaunter Bayaran)
            If Request("Agen") = "Semua" Then
                selectFormula = "({PEMBAYARAN_CAJ.Tarikh_bayar} >= date('" & aDate & "') and {PEMBAYARAN_CAJ.Tarikh_bayar} <= date('" & bDate & "')) and {PENGISYTIHARAN_I.Status} = 'A'"
            Else
                selectFormula = "{AGEN_PENGANGKUTAN.nama_agen_pengangkutan}='" & Request("Agen") & "' and ({PEMBAYARAN_CAJ.Tarikh_bayar} >= date('" & aDate & "') and {PEMBAYARAN_CAJ.Tarikh_bayar} <= date('" & bDate & "')) and {PENGISYTIHARAN_I.Status} = 'A' "
            End If

            'edited by kmz for caj eksport
        ElseIf Request("id") = 501 Then ' --> Laporan Caj Ikan Eksport / Transit (Kaunter Bayaran)
            If Request("Agen") = "Semua" Then
                selectFormula = "({PEMBAYARAN_CAJ.Tarikh_bayar} >= date('" & aDate & "') and {PEMBAYARAN_CAJ.Tarikh_bayar} <= date('" & bDate & "')) and {PENGISYTIHARAN_I.Status} = 'A'"
            Else
                selectFormula = "{AGEN_PENGANGKUTAN.nama_agen_pengangkutan}='" & Request("Agen") & "' and ({PEMBAYARAN_CAJ.Tarikh_bayar} >= date('" & aDate & "') and {PEMBAYARAN_CAJ.Tarikh_bayar} <= date('" & bDate & "')) and {PENGISYTIHARAN_I.Status} = 'A' "
            End If
            'end of 'edited by kmz for caj eksport

        ElseIf Request("id") = 52 Then ' --> Laporan Caj Ikan Import / Transit Rebat (Kaunter Bayaran)
            'selectFormula = "({PENDAFTARAN_PINTU.Tarikh_Masa_Masuk} >= date('" & aDate & "') and {PENDAFTARAN_PINTU.Tarikh_Masa_Masuk} <= date('" & bDate & "')) and {PENGISYTIHARAN_I_Kibfg.Status} = 'A'"
            selectFormula = "({PEMBAYARAN_CAJ.Tarikh_bayar} >= date('" & aDate & "') and {PEMBAYARAN_CAJ.Tarikh_bayar} <= date('" & bDate & "')) and {PENGISYTIHARAN_I_Kibfg.Status} = 'A'"

            'If Request("type") = "H" Then
            '    selectFormula = "({PENDAFTARAN_PINTU.Tarikh_Masa_Masuk} >= date('" & aDate & "') and {PENDAFTARAN_PINTU.Tarikh_Masa_Masuk} <= date('" & bDate & "')) and {PENGISYTIHARAN_I_Kibfg.Status} = 'A'"
            'ElseIf Request("type") = "B" Then
            '    selectFormula = "({test.Tarikh_Masa_Masuk} >= date('" & aDate & "') and {test.Tarikh_Masa_Masuk} <= date('" & bDate & "')) and {test.Status} = 'A'"
            'ElseIf Request("type") = "T" Then
            '    selectFormula = "({PENDAFTARAN_PINTU.Tarikh_Masa_Masuk} >= date('" & aDate & "') and {PENDAFTARAN_PINTU.Tarikh_Masa_Masuk} <= date('" & bDate & "')) and {PENGISYTIHARAN_I_Kibfg.Status} = 'A'"
            'End If

        ElseIf Request("id") = 51 Then ' --> Laporan Import/Eksport/Transit(SKPI status sah) 
            If Request("Agen") = "Semua" Then
                'selectFormula = "{@Status} = 'A' AND ({PENGISYTIHARAN_I.Tarikh_Isytihar} >= date('" & aDate & "') and {PENGISYTIHARAN_I.Tarikh_Isytihar} <= date('" & bDate & "'))"
                selectFormula = "{@Status} = 'A' AND ({PENDAFTARAN_PINTU.Tarikh_Masa_Masuk} >= date('" & aDate & "') and {PENDAFTARAN_PINTU.Tarikh_Masa_Masuk} <= date('" & bDate & "'))"
            Else
                'selectFormula = "{AGEN_PENGANGKUTAN.nama_agen_pengangkutan}='" & Request("Agen") & "' and {@Status} = 'A' AND ({PENGISYTIHARAN_I.Tarikh_Isytihar} >= date('" & aDate & "') and {PENGISYTIHARAN_I.Tarikh_Isytihar} <= date('" & bDate & "'))"
                selectFormula = "{AGEN_PENGANGKUTAN.nama_agen_pengangkutan}='" & Request("Agen") & "' and {@Status} = 'A' AND ({PENDAFTARAN_PINTU.Tarikh_Masa_Masuk} >= date('" & aDate & "') and {PENDAFTARAN_PINTU.Tarikh_Masa_Masuk} <= date('" & bDate & "'))"
            End If
        ElseIf Request("id") = 53 Then ' --> Laporan Bilangan Kotak Biru
            selectFormula = "({PENDAFTARAN_PINTU.Tarikh_Masa_Masuk} >= date('" & aDate & "') and {PENDAFTARAN_PINTU.Tarikh_Masa_Masuk} <= date('" & bDate & "')) and {PENGISYTIHARAN_I.Status} = 'A'"

            'If Request("type") = "H" Then
            '    selectFormula = "({PENDAFTARAN_PINTU.Tarikh_Masa_Masuk} >= date('" & aDate & "') and {PENDAFTARAN_PINTU.Tarikh_Masa_Masuk} <= date('" & bDate & "')) and {PENGISYTIHARAN_I_Kibfg.Status} = 'A'"
            'ElseIf Request("type") = "B" Then
            '    selectFormula = "({bilkotakbiru.Tarikh_Masa_Masuk} >= date('" & aDate & "') and {bilkotakbiru.Tarikh_Masa_Masuk} <= date('" & bDate & "')) and {bilkotakbiru.Status} = 'A'"
            'ElseIf Request("type") = "T" Then
            '    selectFormula = "({PENDAFTARAN_PINTU.Tarikh_Masa_Masuk} >= date('" & aDate & "') and {PENDAFTARAN_PINTU.Tarikh_Masa_Masuk} <= date('" & bDate & "')) and {PENGISYTIHARAN_I_Kibfg.Status} = 'A'"
            'End If
        ElseIf Request("id") = 54 Then 'laporan Borang SKPI bagi status Batal --> Laporan harian caj skpi
            'asal punya selectFormula = "({PENGISYTIHARAN_I.Tarikh_Isytihar} >= date('" & aDate & "') and {PENGISYTIHARAN_I.Tarikh_Isytihar} <= date('" & bDate & "')) and {PENGISYTIHARAN_I.Status} = 'A'"
            If Request("Agen") = "Semua" Then
                selectFormula = "{@Status} = 'B' AND ({PENDAFTARAN_PINTU.Tarikh_Masa_Masuk} >= date('" & aDate & "') and {PENDAFTARAN_PINTU.Tarikh_Masa_Masuk} <= date('" & bDate & "'))"
            Else
                selectFormula = "{AGEN_PENGANGKUTAN.nama_agen_pengangkutan}='" & Request("Agen") & "' and {@Status} = 'B' AND ({PENDAFTARAN_PINTU.Tarikh_Masa_Masuk} >= date('" & aDate & "') and {PENDAFTARAN_PINTU.Tarikh_Masa_Masuk} <= date('" & bDate & "'))"
            End If
        End If

            If Request("type") = "H" Then
                crDisplayreport.DataDefinition.FormulaFields("Tajuk2").Text = "'" & Request("Tarikh1") & "'"
            ElseIf Request("type") = "B" Then
                If Request("Bulan1") = Request("Bulan2") Then
                    crDisplayreport.DataDefinition.FormulaFields("Tajuk2").Text = "'Untuk Bulan " & Month2Name(Left(Request("Bulan1"), 2)) & ", " & Right(Request("Bulan1"), 4) & "'"
                Else
                    crDisplayreport.DataDefinition.FormulaFields("Tajuk2").Text = "'Dari Bulan " & Month2Name(Left(Request("Bulan1"), 2)) & ", " & Right(Request("Bulan1"), 4) & " Hingga " & Month2Name(Left(Request("Bulan2"), 2)) & ", " & Right(Request("Bulan2"), 4) & "'"
                End If

                If Request("id") = 48 Then
                    crDisplayreport.DataDefinition.FormulaFields("Tajuk").Text = "'LAPORAN BULANAN CAJ KENDERAAN MASUK MELALUI PINTU IMPORT'"
                ElseIf Request("id") = 49 Then
                    crDisplayreport.DataDefinition.FormulaFields("Tajuk").Text = "'LAPORAN BULANAN CAJ KENDERAAN MASUK MELALUI PINTU EKSPORT'"
                ElseIf Request("id") = 52 Then
                    crDisplayreport.DataDefinition.FormulaFields("Tajuk").Text = "'Laporan Bulanan Caj Ikan Import / Transit Dengan Rebat KIBFG'"
                ElseIf Request("id") = 53 Then
                    crDisplayreport.DataDefinition.FormulaFields("Tajuk").Text = "'Laporan Bulanan Bilangan Kotak Biru'"
                ElseIf Request("id") = 54 Then
                crDisplayreport.DataDefinition.FormulaFields("Tajuk").Text = "'Penyata Kutipan Caj Bulanan Borang SKPI Bagi Status Batal'"
                'edited by kmz for caj eksport
            ElseIf Request("id") = 501 Then
                crDisplayreport.DataDefinition.FormulaFields("Tajuk").Text = "'Laporan Bulanan Caj Ikan Eksport / Transit (Kaunter Bayaran) (ICCS CAJ06E)'"
                'end of edited by kmz for caj eksport
                End If
            ElseIf Request("type") = "T" Then
                If Request("Tahun1") = Request("Tahun2") Then
                    crDisplayreport.DataDefinition.FormulaFields("Tajuk2").Text = "'Untuk Tahun " & Request("Tahun1") & "'"
                Else
                    crDisplayreport.DataDefinition.FormulaFields("Tajuk2").Text = "'Dari Tahun " & Request("Tahun1") & " Hingga " & Request("Tahun2") & "'"
                End If

                If Request("id") = 48 Then
                    crDisplayreport.DataDefinition.FormulaFields("Tajuk").Text = "'LAPORAN TAHUNAN CAJ KENDERAAN MASUK MELALUI PINTU IMPORT (ICCS CAJ08)'"
                    crDisplayreport.DataDefinition.FormulaFields("Tajuk3").Text = "'ICCS_CAJ08'"
                ElseIf Request("id") = 49 Then
                    crDisplayreport.DataDefinition.FormulaFields("Tajuk").Text = "'LAPORAN TAHUNAN CAJ KENDERAAN MASUK MELALUI PINTU EKSPORT (ICCS CAJ08a)'"
                    crDisplayreport.DataDefinition.FormulaFields("Tajuk3").Text = "'ICCS_CAJ08a'"
                ElseIf Request("id") = 50 Then
                    crDisplayreport.DataDefinition.FormulaFields("Tajuk").Text = "'Laporan Tahunan Caj Ikan Import / Transit (Kaunter Bayaran) (ICCS CAJ09)'"
                'edited by kmz for caj eksport
            ElseIf Request("id") = 501 Then
                crDisplayreport.DataDefinition.FormulaFields("Tajuk").Text = "'Laporan Tahunan Caj Ikan Eksport / Transit (Kaunter Bayaran) (ICCS CAJ09E)'"
                'end of edited by kmz for caj eksport
            ElseIf Request("id") = 52 Then
                crDisplayreport.DataDefinition.FormulaFields("Tajuk").Text = "'Laporan Tahunan Caj Ikan Import / Transit Dengan Rebat KIBFG'"
                ElseIf Request("id") = 53 Then
                    crDisplayreport.DataDefinition.FormulaFields("Tajuk").Text = "'Laporan Tahunan Bilangan Kotak Biru'"
                ElseIf Request("id") = 54 Then
                crDisplayreport.DataDefinition.FormulaFields("Tajuk").Text = "'Penyata Kutipan Caj Tahunan Borang SKPI Bagi Status Batal'"
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