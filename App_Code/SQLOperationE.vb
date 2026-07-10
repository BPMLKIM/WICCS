Imports Microsoft.VisualBasic
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared


Public Class SQLOperationE
    Inherits System.Web.UI.Page

#Region "Variables Declaration"
    Protected connString As String
    Protected sqlConn As New System.Data.SqlClient.SqlConnection
    Public eSKPEArray As New ArrayList()
    Protected ieArrayE As New ArrayList()
    Protected eSKPEArray_Index As New ArrayList()
    Protected urusanArrayE As New ArrayList()
    Protected kadarPKArrayE As New ArrayList()
    Protected kadarPBArrayE As New ArrayList()
    Protected kadarEkorArrayE As New ArrayList()
    Protected kadarQtyArrayE As New ArrayList()
    Protected totalSemuaNilaiE As Decimal = 0
    Protected totalSemuaCajE As Decimal = 0
    Protected totalPetiBesarE As Decimal = 0
    Protected totalPetiKecilE As Decimal = 0
    Protected totalKuantitiKecilE As Decimal = 0
    Protected totalKuantitiBesarE As Decimal = 0
    Protected totalPekE As Decimal = 0
    Protected totalEkorE As Decimal = 0
    Public transactionProcessE As New ArrayList()
    Public ErrorSignalE As Boolean = False
    Public ErrorListE As New ArrayList()
    Public vIsytiharImporter As New ArrayList()
    Public vIsytiharImporterName As New ArrayList()
    Public ImporterErr As New ArrayList()
    Public foundImportErr As Boolean
    Protected ExporterfishItem As New ArrayList()
    Protected fishItem As New ArrayList()
    Public crSKPE As ReportDocument
    Public crMasterSheetEksport As ReportDocument

    'edited by kmz for caj eksport
    Protected jkategoriIkanCajE As New ArrayList()
    Protected kadarPKArrayCajE As New ArrayList()
    Protected kadarPBArrayCajE As New ArrayList()
    Protected kadarEkorArrayCajE As New ArrayList()
    Protected kadarQtyArrayCajE As New ArrayList()
    Protected idIkanCajE As New ArrayList()
    Protected companyPCajE As New ArrayList()
    'end of edited by kmz for caj eksport

    'EDITED BY KMZ FOR CAJ EKSPORT ON 27032014
    Protected jkategoriIkanE As New ArrayList()
    Protected normalIdIkanCajE As New ArrayList()
    'END OF EDITED BY KMZ FOR CAJ EKSPORT ON 27032014

    'shah edit for caj gst
    Protected gst As Decimal = 0
    Protected gst1 As Decimal = 0


#End Region

    Public Function FormatNumber(ByVal val As String) As String

        Dim autoNumber As String = ""

        Select Case (val.ToString().Length())
            Case 0
                autoNumber = "0000000"
            Case 1
                autoNumber = "000000" & val
            Case 2
                autoNumber = "00000" & val
            Case 3
                autoNumber = "0000" & val
            Case 4
                autoNumber = "000" & val
            Case 5
                autoNumber = "00" & val
            Case 6
                autoNumber = "0" & val
            Case 7
                autoNumber = val
        End Select

        Return autoNumber

    End Function

    Public Function GenerateBarcode()

        Dim BarcodeSerialNumber As String = ""

        If sqlConn.State = Data.ConnectionState.Open Then

            Dim sql As String
            sql = "select right(cast(datepart(YYYY,getdate()) as varchar(5)),2)+ " & _
                  "case when datepart(MM,getdate())<10 then '0'+ cast(datepart(MM,getdate()) as varchar(2)) " & _
                  "else cast(datepart(MM,getdate()) as varchar(2))" & _
                  "end + case when datepart(DD,getdate())<10 then '0'+ cast(datepart(DD,getdate()) as varchar(2)) " & _
                  "else cast(datepart(DD,getdate()) as varchar(2))" & _
                  "end + case when datepart(HH,getdate())<10 then '0'+ cast(datepart(HH,getdate()) as varchar(2)) " & _
                  "else cast(datepart(HH,getdate()) as varchar(2))" & _
                  "end + case when datepart(MI,getdate())<10 then '0'+ cast(datepart(MI,getdate()) as varchar(2)) " & _
                  "else cast(datepart(MI,getdate()) as varchar(2))" & _
                  "end + case when datepart(SS,getdate())<10 then '0'+ cast(datepart(SS,getdate()) as varchar(2)) " & _
                  "else cast(datepart(SS,getdate()) as varchar(2))" & _
                  "end "

            Dim execSQL As New System.Data.SqlClient.SqlCommand(sql, sqlConn)
            BarcodeSerialNumber = execSQL.ExecuteScalar()
            BarcodeSerialNumber = "55" & BarcodeSerialNumber & System.Configuration.ConfigurationManager.AppSettings("site_code")

        End If

        Return BarcodeSerialNumber
    End Function

    Public Function InsertAutoNumber(ByVal sqlText As String)

        Dim valNumber As Integer
        Dim autoNumber As String = "0000000"

        If sqlConn.State = Data.ConnectionState.Open Then

            Dim execOperation As New System.Data.SqlClient.SqlCommand(sqlText, sqlConn)
            Try
                valNumber = execOperation.ExecuteScalar()
                execOperation = Nothing
            Catch ex As Exception
                ErrorSignalE = True
                ErrorListE.Add(ex.Message.ToString)
                valNumber = 0
                execOperation = Nothing
            End Try

        End If

        Select Case (valNumber.ToString().Length())
            Case 0
                autoNumber = "0000000"
            Case 1
                autoNumber = "000000" & valNumber.ToString()
            Case 2
                autoNumber = "00000" & valNumber.ToString()
            Case 3
                autoNumber = "0000" & valNumber.ToString()
            Case 4
                autoNumber = "000" & valNumber.ToString()
            Case 5
                autoNumber = "00" & valNumber.ToString()
            Case 6
                autoNumber = "0" & valNumber.ToString()
            Case 7
                autoNumber = valNumber.ToString()
        End Select

        Return autoNumber

    End Function

    Public Function Set_NoDaftar(ByVal strBarcode) As Integer


        Dim sqlText As String
        Dim valNumber As Integer = 0
        Dim trans_no As Integer = 0

        If sqlConn.State = Data.ConnectionState.Open Then

            sqlText = "Select cast(trans_id as varchar(10)) as trans_id  from p_isytihar_transNo_e where no_barcode='" & strBarcode & "'"


            Dim strData As System.Data.SqlClient.SqlDataReader = DataReader(sqlText)

            If strData.HasRows Then
                strData.Read()
                valNumber = strData.GetValue(0)
                sqlText = "select count(*) as data from p_isytihar_transNo_e where trans_id<=" & valNumber & " and " & _
                     "(datepart(d,trans_date)=datepart(d,trans_date)" & _
                     "and datepart(m,trans_date)=datepart(m,trans_date)" & _
                     "and datepart(yy,trans_date)=datepart(yy,trans_date))"
                strData.Close()
                strData = Nothing
            Else
                strData.Close()
                strData = Nothing
                sqlText = "insert into p_isytihar_transNo_e(no_barcode)values('" & strBarcode & "');select SCOPE_IDENTITY()"
                Dim execOperation As New System.Data.SqlClient.SqlCommand(sqlText, sqlConn)
                Try
                    valNumber = execOperation.ExecuteScalar()
                    execOperation = Nothing
                Catch ex As Exception
                    'Response.Write("Sistem Error !!! Berikut ialah error yang telah dikesan = " & ex.Message())
                    ErrorSignalE = True
                    ErrorListE.Add(ex.Message.ToString)
                    valNumber = 0
                    execOperation = Nothing
                End Try
                sqlText = "select count(*) as data from p_isytihar_transNo_e where trans_id<=" & valNumber & " and " & _
                     "(datepart(d,trans_date)=datepart(d,getdate())" & _
                     "and datepart(m,trans_date)=datepart(m,getdate())" & _
                     "and datepart(yy,trans_date)=datepart(yy,getdate()))"
            End If


            Dim execOperationNew As New System.Data.SqlClient.SqlCommand(sqlText, sqlConn)
            trans_no = execOperationNew.ExecuteScalar()

        End If

        Return trans_no

    End Function

    Public Sub Generate_eSKPE(ByVal strValue As String, ByVal strBarcode As String, ByVal PPI As String, ByVal strFishItem As String)

        Dim sqlText As String = ""
        'Dim rowArray() As String = strValue.Split("~")
        Dim i As Integer


        For i = 0 To ExporterfishItem.Count - 1

            Dim rowArray() As String = fishItem(i).Split("~")
            Dim totalItem As Integer = UBound(rowArray)
            'Checked whether skpi already generated or not
            'sqlText = "select noSkpi from nosiri_skpi where no_barcode='" & strBarcode & "' and kod_pengimport='" & importerStr(0) & "' order by kod_pengimport asc "
            'Dim data As String = SingleFieldResults(sqlText)
            'If data <> "" Then

            'str_eSKPI = str_eSKPI & "-" & Data.PadLeft(7, "0")
            'eSKPIArray.Add(str_eSKPI)
            'ieArray.Add(importerStr(0))
            'eSKPIArray_Index.Add(idx_skpi)

            'Else
            Dim totalSkpe As Integer = 0
            If totalItem > 0 And totalItem <= 8 Then
                totalSkpe = 1
            ElseIf totalItem > 8 Then
                Dim divTotalSkpe As Integer = math.floor(totalItem / 8)
                Dim modTotalSkpe As Integer = totalItem Mod 8
                If modTotalSkpe > 0 Then
                    totalSkpe = Math.Round(divTotalSkpe, 0) + 1
                ElseIf modTotalSkpe = 0 Then
                    totalSkpe = Math.Round(divTotalSkpe, 0)
                End If
            End If


            If totalSkpe > 0 Then
                Dim ix As Integer
                Dim idx_skpe As String
                For ix = 1 To totalSkpe
                    Dim str_eSKPe As String = PPI.Trim()
                    sqlText = "insert into nosiri_skpe(no_barcode,kod_pengeksport)values('" & strBarcode & "','" & ExporterfishItem(i) & "');select SCOPE_IDENTITY()"
                    str_eSKPe = str_eSKPe & "-" & InsertAutoNumber(sqlText)
                    eSKPEArray.Add(str_eSKPe)
                    ieArrayE.Add(ExporterfishItem(i))
                    idx_skpe = ExporterfishItem(i) & "-" & ix
                    eSKPEArray_Index.Add(idx_skpe)
                Next

            End If
        Next


        
    End Sub

#Region "old Genenrate_eSKPE"
    'Dim sqlText As String = ""
    ''Dim rowArray() As String = strValue.Split("~")
    'Dim i As Integer


    '    For i = 0 To ImporterfishItem.Count - 1

    'Dim rowArray() As String = fishItem(i).Split("~")
    'Dim totalItem As Integer = UBound(rowArray)
    ''Checked whether skpi already generated or not
    ''sqlText = "select noSkpi from nosiri_skpi where no_barcode='" & strBarcode & "' and kod_pengimport='" & importerStr(0) & "' order by kod_pengimport asc "
    ''Dim data As String = SingleFieldResults(sqlText)
    ''If data <> "" Then

    ''str_eSKPI = str_eSKPI & "-" & Data.PadLeft(7, "0")
    ''eSKPIArray.Add(str_eSKPI)
    ''ieArray.Add(importerStr(0))
    ''eSKPIArray_Index.Add(idx_skpi)

    ''Else
    'Dim totalSkpi As Integer = 0
    '        If totalItem > 0 And totalItem <= 8 Then
    '            totalSkpi = 1
    '        ElseIf totalItem > 8 Then
    'Dim divTotalSkpi As Integer = totalItem / 8
    'Dim modTotalSkpi As Integer = totalItem Mod 8
    '            If modTotalSkpi > 0 Then
    '                totalSkpi = Math.Round(divTotalSkpi, 0) + 1
    '            End If
    '        End If


    '        If totalSkpi > 0 Then
    'Dim ix As Integer
    'Dim idx_skpi As String
    '            For ix = 1 To totalSkpi
    'Dim str_eSKPI As String = PPI.Trim()
    '                sqlText = "insert into nosiri_skpi(no_barcode,kod_pengimport)values('" & strBarcode & "','" & ImporterfishItem(i) & "');select SCOPE_IDENTITY()"
    '                str_eSKPI = str_eSKPI & "-" & InsertAutoNumber(sqlText)
    '                eSKPIArray.Add(str_eSKPI)
    '                ieArray.Add(ImporterfishItem(i))
    '                idx_skpi = ImporterfishItem(i) & "-" & ix
    '                eSKPIArray_Index.Add(idx_skpi)
    '            Next

    '        End If
    '    Next
#End Region

    Public Sub Generate_eSKPE_Semula(ByVal strValue As String, ByVal strBarcode As String, ByVal PPI As String, ByVal strFishItem As String)

        Dim sqlText As String = ""
        Dim rowArray() As String = strValue.Split("~")
        Dim i As Integer

        For i = 0 To UBound(rowArray) - 1
            Dim valStr() As String
            Dim exporterStr() As String


            valStr = rowArray(i).Split("`")
            exporterStr = valStr(0).Split("|")

            If valStr(6).Trim() <> "A" Then
                'Checked whether skpi already generated or not
                'sqlText = "select noSkpe from nosiri_skpe where no_barcode='" & strBarcode & "' and kod_pengeksport='" & exporterStr(0) & "'"
                'Dim data As String = SingleFieldResults(sqlText)
                'If data <> "" Then
                '    str_eSKPE = str_eSKPE & "-" & data.PadLeft(7, "0")
                '    eSKPEArray.Add(str_eSKPE)
                '    ieArrayE.Add(exporterStr(0))
                'Else
                Dim totalItem As Integer = CountFishItemDeclared(strFishItem, exporterStr(0).ToString())
                Dim totalSkpe As Integer = 0

                If totalItem > 0 And totalItem <= 8 Then
                    totalSkpe = 1
                ElseIf totalItem > 8 Then
                    Dim divTotalSkpe As Integer = math.floor(totalItem / 8)
                    Dim modTotalSkpe As Integer = totalItem Mod 8
                    If modTotalSkpe > 0 Then
                        totalSkpe = Math.Round(divTotalSkpe, 0) + 1
                    ElseIf modTotalSkpe = 0 Then
                        totalSkpe = Math.Round(divTotalSkpe, 0)
                    End If
                End If

                If totalSkpe > 0 Then


                    Dim ix As Integer
                    Dim idx_skpe As String
                    For ix = 1 To totalSkpe
                        Dim str_eSKPE As String = PPI.Trim()
                        sqlText = "insert into nosiri_skpe(no_barcode,kod_pengeksport)values('" & strBarcode & "','" & exporterStr(0) & "');select SCOPE_IDENTITY()"
                        str_eSKPE = str_eSKPE & "-" & InsertAutoNumber(sqlText)
                        eSKPEArray.Add(str_eSKPE)
                        ieArrayE.Add(exporterStr(0))
                        idx_skpe = exporterStr(0) & "-" & ix
                        eSKPEArray_Index.Add(idx_skpe)
                    Next

                End If
                'sqlText = "insert into nosiri_skpe(no_barcode,kod_pengeksport)values('" & strBarcode & "','" & exporterStr(0) & "');select SCOPE_IDENTITY()"
                'str_eSKPE = str_eSKPE & "-" & InsertAutoNumber(sqlText)
                'eSKPEArray.Add(str_eSKPE)
                'ieArrayE.Add(exporterStr(0))

                'End If
            End If

        Next
    End Sub

    Public Function CountFishItemDeclared(ByVal strFish As String, ByVal kodExporter As String) As Integer
        Dim rowArray() As String
        Dim i As Integer
        Dim cntItem As New ArrayList()
        Dim totalItem As Integer = 0

        rowArray = strFish.Split("~")
        For i = 0 To UBound(rowArray) - 1
            Dim arrColIkan() As String = rowArray(i).Split("`")
            If (kodExporter = arrColIkan(0).ToString()) Then
                totalItem = totalItem + 1
            End If
        Next

        Return totalItem

    End Function


    'EDITED BY KMZ FOR CAJ EKSPORT ON 27032014

    Public Sub Load_CajIkan()

        Dim sqlText As String = "SELECT RTRIM(Kategori_Ikan) as Kategori_Ikan, RTRIM(Jenis_Urusan) as Jenis_Urusan, Kadar_Peti_Kecil, Kadar_Peti_Besar, Kadar_Ekor, Kadar_Kuantiti, id " & _
                                "FROM IKAN_CAJ WHERE status = 'yes'"

        Dim cajIkanRdr As System.Data.SqlClient.SqlDataReader
        cajIkanRdr = DataReader(sqlText)
        Do While cajIkanRdr.Read
            Dim urusanKategori As String = cajIkanRdr.GetValue(1) & "_" & cajIkanRdr.GetValue(0)
            jkategoriIkanE.Add(cajIkanRdr.GetValue(0))
            urusanArrayE.Add(urusanKategori)
            kadarPKArrayE.Add(cajIkanRdr.GetValue(2))
            kadarPBArrayE.Add(cajIkanRdr.GetValue(3))
            kadarEkorArrayE.Add(cajIkanRdr.GetValue(4))
            kadarQtyArrayE.Add(cajIkanRdr.GetValue(5))
            normalIdIkanCajE.Add(cajIkanRdr.GetValue(6))

        Loop
        cajIkanRdr.Close()
        'cajIkanRdr = Nothing

    End Sub

    Public Sub SortFishItem(ByVal strFish)
        Dim rowArray() As String
        Dim i As Integer

        rowArray = strFish.Split("~")
        For i = 0 To UBound(rowArray) - 1
            Dim arrColIkan() As String = rowArray(i).Split("`")
            Dim strFindObj As String = arrColIkan(0)
            If (ExporterfishItem.IndexOf(strFindObj) < 0) Then
                ExporterfishItem.Add(strFindObj)
                Dim strFishTempValue = rowArray(i) & "~"
                fishItem.Add(strFishTempValue)
            Else
                Dim locIndex As Integer = ExporterfishItem.IndexOf(strFindObj)
                fishItem(locIndex) = fishItem(locIndex) & rowArray(i) & "~"
            End If
        Next

    End Sub

    Public Sub ProsesFish_Item(ByVal strFish As String, ByVal strBarcode As String, ByVal kodUrusan As String)

        Dim mx As Integer
        For mx = 0 To ExporterfishItem.Count - 1
            Dim i As Integer
            Dim stringFish As String = fishItem(mx).ToString
            Dim rowArray() As String = stringFish.Split("~")
            Dim totRowArray As Integer = UBound(rowArray) - 1
            Dim rowCount = 1
            Dim bil_item As Integer = 1
            Dim pkodUrusan = kodUrusan
            For i = 0 To totRowArray

                If bil_item = 9 Then
                    rowCount = rowCount + 1
                    bil_item = 1
                End If

                Dim arrColIkan() As String = rowArray(i).Split("`")
                Dim strFindObj As String = arrColIkan(0) & "-" & rowCount.ToString

                'Find specific kod_importer index location to get eSKPI no from arrayList
                Dim skpe_idx As Integer = eSKPEArray_Index.IndexOf(strFindObj) 'BinarySearch(strFindObj)

                'edited by kmz for caj eksport ON 27032014
                Dim nilaiCaj As Double = 0

                nilaiCaj = CDbl(arrColIkan(18))

                Dim nilaiCajSvr As Double = 0

                Dim kateIkan As String = arrColIkan(3).Substring(0, 1)
                'Dim kodeikan As String = arrColIkan(3)

                'Periksa sama ada company ini ada pengurangan caj atau tidak
                Dim cariKodSyarikat As String = arrColIkan(0) & "_" & kateIkan

                Dim cariKodSyarikatIdx As Integer = companyPCajE.IndexOf(cariKodSyarikat) '.BinarySearch(strFindObj)

                Dim cajIkanKodId As Integer = 0
                If arrColIkan(17).Trim() <> "" Then
                    cajIkanKodId = arrColIkan(17).Trim()
                End If

                If cariKodSyarikatIdx >= 0 Then

                    If jkategoriIkanCajE(cariKodSyarikatIdx) = kateIkan Then
                        'If kodikanCaj(cariKodSyarikatIdx) = kodeikan Then
                        nilaiCajSvr = (CDbl(arrColIkan(5)) * CDbl(kadarPKArrayCajE(cariKodSyarikatIdx))) + (CDbl(arrColIkan(7)) * CDbl(kadarPBArrayCajE(cariKodSyarikatIdx))) + (CDbl(arrColIkan(6)) * CDbl(kadarQtyArrayCajE(cariKodSyarikatIdx))) + (CDbl(arrColIkan(10)) * CDbl(kadarEkorArrayCajE(cariKodSyarikatIdx)))
                        cajIkanKodId = idIkanCajE(cariKodSyarikatIdx).ToString()
                    Else
                        'Find index location for jenis urusan for cajIkan calculation
                        pkodUrusan = kodUrusan '& arrColIkan(3).Substring(0, 1)
                        pkodUrusan = pkodUrusan & "_" & kateIkan
                        Dim cajIdx As Integer = urusanArrayE.IndexOf(pkodUrusan) '.BinarySearch(strFindObj)
                        If cajIdx >= 0 Then
                            'If jkategoriIkan(cajIdx) = kateIkan Then
                            nilaiCajSvr = (CDbl(arrColIkan(5)) * CDbl(kadarPKArrayE(cajIdx))) + (CDbl(arrColIkan(7)) * CDbl(kadarPBArrayE(cajIdx))) _
                            + (CDbl(arrColIkan(6)) * CDbl(kadarQtyArrayE(cajIdx))) _
                            + (CDbl(arrColIkan(10)) * CDbl(kadarEkorArrayE(cajIdx)))
                            cajIkanKodId = normalIdIkanCajE(cajIdx).ToString()
                            'End If
                        End If

                    End If

                Else
                    'Find index location for jenis urusan for cajIkan calculation
                    pkodUrusan = kodUrusan '& arrColIkan(3).Substring(0, 1)
                    pkodUrusan = pkodUrusan & "_" & kateIkan
                    Dim cajIdx As Integer = urusanArrayE.IndexOf(pkodUrusan) '.BinarySearch(strFindObj)
                    If cajIdx >= 0 Then
                        'If jkategoriIkan(cajIdx) = kateIkan Then
                        nilaiCajSvr = (CDbl(arrColIkan(5)) * CDbl(kadarPKArrayE(cajIdx))) + (CDbl(arrColIkan(7)) * CDbl(kadarPBArrayE(cajIdx))) + (CDbl(arrColIkan(6)) * CDbl(kadarQtyArrayE(cajIdx))) + (CDbl(arrColIkan(10)) * CDbl(kadarEkorArrayE(cajIdx)))
                        cajIkanKodId = normalIdIkanCajE(cajIdx).ToString()
                        'End If
                    End If

                End If

                ''Find index location for jenis urusan for cajIkan calculation
                'pkodUrusan = kodUrusan & arrColIkan(3).Substring(0, 1)
                'strFindObj = pkodUrusan

                'Dim cajIdx As Integer = urusanArrayE.IndexOf(pkodUrusan) '.BinarySearch(strFindObj)


                'Dim nilaiCaj As Double = (CDbl(arrColIkan(5)) * CDbl(kadarPKArrayE(cajIdx))) + (CDbl(arrColIkan(7)) * CDbl(kadarPBArrayE(cajIdx))) _
                '    + (CDbl(arrColIkan(6)) * CDbl(kadarQtyArrayE(cajIdx))) _
                '    + (CDbl(arrColIkan(10)) * CDbl(kadarEkorArrayE(cajIdx)))

                'END OF EDITED BY KMZ FOR CAJ EKSPORT ON 27032014



                If (skpe_idx > -1) Then
                    'Insert Fish Item Into Item_Isytihar_I
                    Dim sqlText As String

                    'EDITED BY KMZ FOR CAJ EKSPORT ON 27032014
                    sqlText = "INSERT INTO [w-iccs].[dbo].[ITEM_ISYTIHAR_E]" & _
                              "([Nombor_Barcode], [No_SKPE], [Bil_Item], [Kod_Ikan]," & _
                              "[Destinasi_Eksport], [PetiKecil], [KuantitiKecil]," & _
                              "[PetiBesar], [KuantitiBesar], [Pek], [Ekor], [Nilai]," & _
                              "[Caj],[Site_Code],[Caj_Ikan_ID],[CajSvr]) values('" & strBarcode & "','" & eSKPEArray(skpe_idx).ToString() & _
                              "'," & bil_item & ",'" & arrColIkan(3) & "','" & arrColIkan(4) & _
                              "'," & arrColIkan(5) & "," & arrColIkan(6) & "," & arrColIkan(7) & _
                              "," & arrColIkan(8) & "," & arrColIkan(9) & "," & arrColIkan(10) & "," & arrColIkan(11) & "," & nilaiCajSvr & ",'055'," & cajIkanKodId & "," & nilaiCaj & ")"
                    'END OF EDITED BY KMZ FOR CAJ EKSPORT ON 27032014
                    InsertData(sqlText)
                    'transactionProcessE.Add(sqlText)
                    'InsertData(sqlText)

                    'Calculate total for all item declaration
                    totalSemuaCajE = totalSemuaCajE + CDec(nilaiCaj)
                    totalSemuaNilaiE = totalSemuaNilaiE + CDec(arrColIkan(11))
                    totalPetiKecilE = totalPetiKecilE + CDec(arrColIkan(5))
                    totalKuantitiKecilE = totalKuantitiKecilE + CDec(arrColIkan(6))
                    totalPetiBesarE = totalPetiBesarE + CDec(arrColIkan(7))
                    totalKuantitiBesarE = totalKuantitiBesarE + CDec(arrColIkan(8))
                    totalPekE = totalPekE + CDec(arrColIkan(9))
                    totalEkorE = totalEkorE + CDec(arrColIkan(10))

                    bil_item = bil_item + 1
                End If
            Next
        Next

    End Sub

    Public Sub Proses_Pengisytiharan(ByVal strExporter As String, ByVal strBarcode As String, ByVal no_daftar As Integer, ByVal no_kenderaan As String, ByVal jenisUrusan As String, ByVal caraPengangkutan As String, ByVal bekalan As String, ByVal ppi As String, ByVal online As String)
        'ByVal eu As String, ByVal no_sijil As String

        

        Dim i As Integer
        Dim arrExporterRow() = strExporter.Split("~")
        Dim mx As Integer
        For mx = 0 To eSKPEArray_Index.Count - 1

            For i = 0 To UBound(arrExporterRow) - 1

                Dim arrExporterCol() As String = arrExporterRow(i).ToString().Split("`")
                Dim arrExporterDetails() As String = arrExporterCol(0).Split("|")
                Dim kodPengeksport As String = arrExporterDetails(0)
                Dim kodnegaraEU As String = arrExporterCol(8)
                Dim noSijil As String = arrExporterCol(7)
                Dim noKontena As String = arrExporterCol(9)

                If kodPengeksport = ieArrayE(mx).ToString Then

                    'Find eSKPI Generated For The Specific kodPengimport
                    Dim strFindObj As Object = kodPengeksport
                    'Dim eskpi_idx As Integer = ieArrayE.IndexOf(kodPengeksport) '.BinarySearch(strFindObj)
                    Dim eskpi_val As String = eSKPEArray(mx).ToString()
                    Dim nama_pegawai = Session("username")

                    Dim namaPemanduPindahan As String = ""
                    Dim noKenderaanPindahan As String = ""

                    If jenisUrusan = "008" Then
                        namaPemanduPindahan = arrExporterCol(6)
                        noKenderaanPindahan = arrExporterCol(7)
                    End If

                    Dim sqlText As String = ""

                    sqlText = "SELECT No_SKPE, SUM(PetiKecil) AS TPK, SUM(KuantitiKecil) AS TQK, SUM(PetiBesar) AS TPB, SUM(KuantitiBesar) AS TQB, SUM(Pek) AS tpek, SUM(Ekor) " & _
                              "AS ekor, SUM(Nilai) AS tnilai, round((SUM(Caj)),2) AS tcaj FROM ITEM_ISYTIHAR_E WHERE Nombor_Barcode ='" & strBarcode & "' AND No_SKPE ='" & eskpi_val & "' " & _
                              "GROUP BY No_SKPE"
                    Dim myCaj As System.Data.SqlClient.SqlDataReader = DataReader(sqlText)

                    If myCaj.HasRows Then
                        myCaj.Read()
                        totalPetiKecilE = myCaj.GetValue(1)
                        totalKuantitiKecilE = myCaj.GetValue(2)
                        totalPetiBesarE = myCaj.GetValue(3)
                        totalKuantitiBesarE = myCaj.GetValue(4)
                        totalPekE = myCaj.GetValue(5)
                        totalEkorE = myCaj.GetValue(6)
                        totalSemuaNilaiE = myCaj.GetValue(7)
                        totalSemuaCajE = myCaj.GetValue(8)
                    End If
                    myCaj.Close()
                    myCaj = Nothing

                    'shah edit or caj gst
                    gst1 = totalSemuaCajE * 0.0
                    gst = Math.Round(gst1, 2)

                    'Generate Insert Statement For Insertion Prosess



                    sqlText = "INSERT INTO [W-ICCS].[dbo].[PENGISYTIHARAN_E]" & _
                                                               "([No_Barcode], [No_SKPE], [No_Daftar], [No_Kenderaan]," & _
                                                               "[Cara_Pengangkutan], [Kod_Pengeksport],[Kod_Pengimport] ," & _
                                                               "[KodPPI], [totalPetiKecil]," & _
                                                               "[totalKuantitiKecil], [totalPetiBesar], [totalKuantitiBesar], [totalPek]," & _
                                                               "[totalEkor], [TotalNilai], [TotalCajIkan], [Destinasi_Negara], [Status]," & _
                                                               "[Nama_Pegawai],[Nama_PemanduPindahan],[No_KenderaanPindahan],[OnlineSend_By],[Kod_Urusan],[Site_Code],[Destinasi_Negara_EU],[No_Sijil],[No_Kontena], [gst])" & _
                                                               "VALUES('" & strBarcode & "','" & eskpi_val & "','" & no_daftar & "'," & _
                                                               "'" & no_kenderaan & "','" & caraPengangkutan & "','" & kodPengeksport & "','" & arrExporterCol(4) & "'," & _
                                                               "'" & ppi & "'," & totalPetiKecilE & "," & totalKuantitiKecilE & "," & totalPetiBesarE & "," & _
                                                               totalKuantitiBesarE & "," & totalPekE & "," & totalEkorE & "," & totalSemuaNilaiE & "," & totalSemuaCajE & "," & _
                                                               "'" & bekalan & "','A','" & nama_pegawai & "','" & namaPemanduPindahan & "','" & noKenderaanPindahan & "','" & online & "','" & jenisUrusan & "','055','" & kodnegaraEU & "', '" & noSijil & "','" & noKontena & "', '" & gst & "')"


                    'end of shah edit or caj gst
                    transactionProcessE.Add(sqlText)
                    'InsertData(sqlText)
                End If
               
            Next
        Next

    End Sub

    Public Sub InsertData(ByVal sqlText As String)

        If sqlConn.State = Data.ConnectionState.Open Then

            Dim execOperation As New System.Data.SqlClient.SqlCommand(sqlText, sqlConn)
            Try
                execOperation.ExecuteNonQuery()
            Catch ex As Exception
                ErrorSignalE = True
                ErrorListE.Add(ex.Message.ToString)
                execOperation = Nothing
            End Try
        End If

    End Sub

    Public Function SingleFieldResults(ByVal sqlText As String) As String

        Dim dataField As String = ""

        If sqlConn.State = Data.ConnectionState.Open Then

            Dim execOperation As New System.Data.SqlClient.SqlCommand(sqlText, sqlConn)
            Try
                dataField = CStr(execOperation.ExecuteScalar())
                execOperation = Nothing
            Catch ex As Exception
                ErrorSignalE = True
                ErrorListE.Add(ex.Message.ToString)
                execOperation = Nothing
            End Try

        End If

        Return dataField

    End Function

    Public Function Identity(ByVal sqlText As String) As Int32

        Dim iden As System.Int32
        If sqlConn.State = Data.ConnectionState.Open Then

            Dim execOperation As New System.Data.SqlClient.SqlCommand(sqlText, sqlConn)
            Try
                iden = System.Convert.ToInt32(execOperation.ExecuteScalar())
                execOperation = Nothing
            Catch ex As Exception
                ErrorSignalE = True
                ErrorListE.Add(ex.Message.ToString)
                execOperation = Nothing
            End Try

        End If

        Return iden

    End Function

    Public Sub dbConnection()
        connString = System.Configuration.ConfigurationManager.ConnectionStrings("W-ICCS_Conn").ToString()
        sqlConn.ConnectionString = connString
        Try
            sqlConn.Open()
        Catch ex As Exception
            'Response.Write("Sistem Error !!! Berikut ialah error yang telah dikesan = " & ex.Message())
            ErrorSignalE = True
            ErrorListE.Add(ex.Message.ToString)
        End Try
    End Sub

    Public Sub dbConnection_Close()
        If sqlConn.State = Data.ConnectionState.Open Then
            sqlConn.Close()
        End If
    End Sub

    Public Function VerifyBarcode(ByVal strBarcode As String)
        Dim sqlText As String
        sqlText = "select kod_jenis_urusan from pendaftaran_pintu where nombor_barcode='" & strBarcode & "'"
        Dim urusan As String = SingleFieldResults(sqlText)
        Dim strUrl As String = ""
        Select Case urusan
            Case "001"
                strUrl = "../import/pengisyitiharan.aspx?&barcode=" & strBarcode
            Case Else
                strUrl = "../import/pengisyitiharan.aspx?&barcode=" & strBarcode
        End Select

        Return strUrl
    End Function

    Public Function DataReader(ByVal sqlText As String) As System.Data.SqlClient.SqlDataReader

        Dim Rdr As System.Data.SqlClient.SqlDataReader = Nothing
        Dim cmd As New System.Data.SqlClient.SqlCommand(sqlText, sqlConn)
        If sqlConn.State = Data.ConnectionState.Open Then
            Rdr = cmd.ExecuteReader()
        End If

        Return Rdr
    End Function

    Public Function VerifyItemIsytihar(ByVal arrval As String, ByVal arrfish As String) As Boolean
        Dim i As Integer
        Dim arrImporterRow() = arrval.Split("~")
        foundImportErr = False

        For i = 0 To UBound(arrImporterRow) - 1
            Dim arrImporterCol() As String = arrImporterRow(i).ToString().Split("`")
            Dim arrImporterDetails() As String = arrImporterCol(0).Split("|")

            Dim kodPengimport As Object = arrImporterDetails(0)
            If vIsytiharImporter.IndexOf(kodPengimport) < 0 Then
                vIsytiharImporter.Add(arrImporterDetails(0))
                vIsytiharImporterName.Add(arrImporterCol(1))
            End If
        Next

        For i = 0 To vIsytiharImporter.Count() - 1

            Dim fishfound As Integer = 0
            Dim x As Integer = 0
            Dim arrFishRow() = arrfish.Split("~")
            Dim fishKodImporter As String = ""
            For x = 0 To UBound(arrFishRow) - 1
                Dim arrFishCol() As String = arrFishRow(x).ToString().Split("`")
                fishKodImporter = arrFishCol(0)
                If vIsytiharImporter(i).ToString().Trim() = fishKodImporter.Trim() Then
                    fishfound = fishfound + 1
                End If
            Next

            If fishfound = 0 Then
                ImporterErr.Add(vIsytiharImporter(i).ToString().Trim())
                foundImportErr = True
            End If
        Next

        Return foundImportErr

    End Function

    Public Sub ConfigureCrystalReportsSKPEPrint(ByVal file As String, ByVal strFormula As String)

        'DropDownList1.DataSource = System.Drawing.Printing.PrinterSettings.InstalledPrinters
        'DropDownList1.DataBind()

        Dim myConnectionInfo As ConnectionInfo = New ConnectionInfo()
        myConnectionInfo.DatabaseName = System.Configuration.ConfigurationManager.AppSettings("dbname")
        myConnectionInfo.UserID = System.Configuration.ConfigurationManager.AppSettings("userid")
        myConnectionInfo.Password = System.Configuration.ConfigurationManager.AppSettings("dbpassword")
        myConnectionInfo.ServerName = System.Configuration.ConfigurationManager.AppSettings("servername")

        crSKPE = New ReportDocument()

        Dim reportPath As String = Server.MapPath(file)

        crSKPE.Load(reportPath)



        Dim selectFormula As String = strFormula '"{PENGISYTIHARAN_I.No_Barcode} = '" & Request("barcode") & "' AND {PENGISYTIHARAN_I.Status} = 'A'"
        crSKPE.DataDefinition.RecordSelectionFormula = selectFormula
        SetDBLogonForReport(myConnectionInfo, crSKPE)

    End Sub

    Public Sub SetDBLogonForReport(ByVal myConnectionInfo As ConnectionInfo, ByVal myReportDocument As ReportDocument)
        Dim myTables As Tables = myReportDocument.Database.Tables
        For Each myTable As CrystalDecisions.CrystalReports.Engine.Table In myTables
            Dim myTableLogonInfo As TableLogOnInfo = myTable.LogOnInfo
            myTableLogonInfo.ConnectionInfo = myConnectionInfo
            myTable.ApplyLogOnInfo(myTableLogonInfo)
        Next
    End Sub

    Public Sub SetDBLogonForSubreports(ByVal myConnectionInfo As ConnectionInfo, ByVal myReportDocument As ReportDocument)
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

    Public Sub ConfigureCrystalReports_MSheet(ByVal file As String, ByVal strFormula As String, ByVal formulafields1 As String, ByVal formulafields2 As String, ByVal CajMasuk As String, ByVal NoKenderaan As String, ByVal NoAgenPengangkutan As String, ByVal Urusan As String, ByVal Barangan As String, ByVal NamaPegawai As String)


        crMasterSheetEksport = New ReportDocument()

        Dim reportPath As String = Server.MapPath(file)

        crMasterSheetEksport.Load(reportPath)

        Dim myConnectionInfo As ConnectionInfo = New ConnectionInfo()
        myConnectionInfo.DatabaseName = System.Configuration.ConfigurationManager.AppSettings("dbname")
        myConnectionInfo.UserID = System.Configuration.ConfigurationManager.AppSettings("userid")
        myConnectionInfo.Password = System.Configuration.ConfigurationManager.AppSettings("dbpassword")
        myConnectionInfo.ServerName = System.Configuration.ConfigurationManager.AppSettings("servername")


        'crMasterSheetImport.PrintToPrinter(1, False, 0, 0)
        '
        'myCrystalReportViewer.SelectionFormula = "{PENGISYTIHARAN_I.No_Barcode} = '1070222170213001' AND {PENGISYTIHARAN_I.Status} = 'A'"

        'Dim selectFormula As String = "{PENGISYTIHARAN_I.No_Barcode} = '" & Request("barcode") & "' AND {PENGISYTIHARAN_I.Status} = 'A'"
        crMasterSheetEksport.DataDefinition.FormulaFields("MS_NoInvois").Text = "'" & formulafields1 & "'"
        crMasterSheetEksport.DataDefinition.FormulaFields("MS_Salinan").Text = "'" & formulafields2 & "'"
        crMasterSheetEksport.DataDefinition.FormulaFields("Caj_Masuk").Text = "'" & CajMasuk & "'"
        crMasterSheetEksport.DataDefinition.FormulaFields("No_Kenderaan").Text = "'" & NoKenderaan & "'"
        crMasterSheetEksport.DataDefinition.FormulaFields("no_agen_pengangkutan").Text = "'" & NoAgenPengangkutan & "'"
        crMasterSheetEksport.DataDefinition.FormulaFields("urusan").Text = "'" & Urusan & "'"
        crMasterSheetEksport.DataDefinition.FormulaFields("barangan").Text = "'" & Barangan & "'"
        crMasterSheetEksport.DataDefinition.FormulaFields("pegawai").Text = "'" & NamaPegawai & "'"
        crMasterSheetEksport.DataDefinition.RecordSelectionFormula = strFormula
        SetDBLogonForReport(myConnectionInfo, crMasterSheetEksport)
        SetDBLogonForSubreports(myConnectionInfo, crMasterSheetEksport)

    End Sub


    'edited by kmz for caj eksport
    Public Sub Load_CajIkanSyarikat()
        'Load Kadar Caj Ikan Untuk Pengimport Tertentu
        Dim caj_sqlText As String = "SELECT RTRIM(Kategori_Ikan) as Kategori_Ikan, RTRIM(Jenis_Urusan) as Jenis_Urusan, Kadar_Peti_Kecil, Kadar_Peti_Besar, Kadar_Ekor, Kadar_Kuantiti, Kod_Pengimport +'_'+ RTRIM(Kategori_Ikan) ,id " & _
                                    "FROM COMPANY_IKAN_CAJ_eksport WHERE (tarikh_tamat >= GETDATE() and status='yes')"
        Dim caj_jsReader As System.Data.SqlClient.SqlDataReader = DataReader(caj_sqlText)
        Do While caj_jsReader.Read
            jkategoriIkanCajE.Add(caj_jsReader.GetValue(0).ToString.Trim())
            'urusanArrayCaj.Add(caj_jsReader.GetValue(1))
            kadarPKArrayCajE.Add(caj_jsReader.GetValue(2))
            kadarPBArrayCajE.Add(caj_jsReader.GetValue(3))
            kadarEkorArrayCajE.Add(caj_jsReader.GetValue(4))
            kadarQtyArrayCajE.Add(caj_jsReader.GetValue(5))
            idIkanCajE.Add(caj_jsReader.GetValue(7))
            companyPCajE.Add(caj_jsReader.GetValue(6))
        Loop
        caj_jsReader.Close()
        'caj_jsReader = Nothing
    End Sub
    'end of edited by kmz for caj eksport

End Class
