Imports Microsoft.VisualBasic
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared


Public Class SQLOperationAsal
    Inherits System.Web.UI.Page

#Region "Variables Declaration"
    Protected connString As String
    Protected sqlConn As New System.Data.SqlClient.SqlConnection
    Public eSKPIArray As New ArrayList()
    Protected ieArray As New ArrayList()
    Protected eSKPIArray_Index As New ArrayList()

    Protected urusanArray As New ArrayList()
    Protected kadarPKArray As New ArrayList()
    Protected kadarPBArray As New ArrayList()
    Protected kadarEkorArray As New ArrayList()
    Protected kadarQtyArray As New ArrayList()
    Protected jkategoriIkan As New ArrayList()
    Protected normalIdIkanCaj As New ArrayList()


    Protected companyPCaj As New ArrayList()
    Protected kadarPKArrayCaj As New ArrayList()
    Protected kadarPBArrayCaj As New ArrayList()
    Protected kadarEkorArrayCaj As New ArrayList()
    Protected kadarQtyArrayCaj As New ArrayList()
    Protected jkategoriIkanCaj As New ArrayList()
    Protected idIkanCaj As New ArrayList()


    Protected totalSemuaNilai As Decimal = 0
    Protected totalSemuaCaj As Decimal = 0
    Protected totalPetiBesar As Decimal = 0
    Protected totalPetiKecil As Decimal = 0
    Protected totalKuantitiKecil As Decimal = 0
    Protected totalKuantitiBesar As Decimal = 0
    Protected totalPek As Decimal = 0
    Protected totalEkor As Decimal = 0
    Public transactionProcess As New ArrayList()
    Public ErrorSignal As Boolean = False
    Public ErrorList As New ArrayList()
    Public vIsytiharImporter As New ArrayList()
    Public vIsytiharImporterName As New ArrayList()
    Public ImporterErr As New ArrayList()
    Public foundImportErr As Boolean
    Protected ImporterfishItem As New ArrayList()
    Protected fishItem As New ArrayList()
    Public crSKPI As ReportDocument
    Public crSKPE As ReportDocument

    Public crMasterSheetImport As ReportDocument
    Public iResitG2b As ReportDocument

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
            BarcodeSerialNumber = "1" & BarcodeSerialNumber & System.Configuration.ConfigurationManager.AppSettings("site_code")

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
                ErrorSignal = True
                ErrorList.Add(ex.Message.ToString)
                valNumber = 0
                execOperation = Nothing
            End Try

        End If

        autoNumber = valNumber.ToString().PadLeft(7, "0")

        Return autoNumber

    End Function

    Public Function Set_NoDaftar(ByVal strBarcode) As Integer


        Dim sqlText As String
        Dim valNumber As Integer = 0
        Dim trans_no As Integer = 0

        If sqlConn.State = Data.ConnectionState.Open Then

            sqlText = "Select cast(trans_id as varchar(10)) as trans_id  from p_isytihar_transNo where no_barcode='" & strBarcode & "'"


            Dim strData As System.Data.SqlClient.SqlDataReader = DataReader(sqlText)

            If strData.HasRows Then
                strData.Read()
                valNumber = strData.GetValue(0)
                sqlText = "select count(*) as data from p_isytihar_transNo where trans_id<=" & valNumber & " and " & _
                     "(datepart(d,trans_date)=datepart(d,trans_date)" & _
                     "and datepart(m,trans_date)=datepart(m,trans_date)" & _
                     "and datepart(yy,trans_date)=datepart(yy,trans_date))"
                strData.Close()
                strData = Nothing
            Else
                strData.Close()
                strData = Nothing
                sqlText = "insert into p_isytihar_transNo(no_barcode)values('" & strBarcode & "');select SCOPE_IDENTITY()"
                Dim execOperation As New System.Data.SqlClient.SqlCommand(sqlText, sqlConn)
                Try
                    valNumber = execOperation.ExecuteScalar()
                    execOperation = Nothing
                Catch ex As Exception
                    'Response.Write("Sistem Error !!! Berikut ialah error yang telah dikesan = " & ex.Message())
                    ErrorSignal = True
                    ErrorList.Add(ex.Message.ToString)
                    valNumber = 0
                    execOperation = Nothing
                End Try
                sqlText = "select count(*) as data from p_isytihar_transNo where trans_id<=" & valNumber & " and " & _
                     "(datepart(d,trans_date)=datepart(d,getdate())" & _
                     "and datepart(m,trans_date)=datepart(m,getdate())" & _
                     "and datepart(yy,trans_date)=datepart(yy,getdate()))"
            End If


            Dim execOperationNew As New System.Data.SqlClient.SqlCommand(sqlText, sqlConn)
            trans_no = execOperationNew.ExecuteScalar()

        End If

        Return trans_no

    End Function

    Public Sub SortFishItem(ByVal strFish)
        Dim rowArray() As String
        Dim i As Integer

        rowArray = strFish.Split("~")
        For i = 0 To UBound(rowArray) - 1
            Dim arrColIkan() As String = rowArray(i).Split("`")
            Dim strFindObj As String = arrColIkan(0)
            If (ImporterfishItem.IndexOf(strFindObj) < 0) Then
                ImporterfishItem.Add(strFindObj)
                Dim strFishTempValue = rowArray(i) & "~"
                fishItem.Add(strFishTempValue)
            ElseIf (ImporterfishItem.IndexOf(strFindObj) >= 0) Then
                Dim locIndex As Integer = ImporterfishItem.IndexOf(strFindObj)
                fishItem(locIndex) = fishItem(locIndex) & rowArray(i) & "~"
            End If
        Next

    End Sub
    Public Sub SortFishItem_kibfg(ByVal strFish)
        Dim rowArray() As String
        Dim i As Integer

        rowArray = strFish.Split("~")
        For i = 0 To UBound(rowArray) - 1
            Dim arrColIkan() As String = rowArray(i).Split("`")
            Dim strFindObj As String = arrColIkan(0)
            If (ImporterfishItem.IndexOf(strFindObj) < 0) Then
                ImporterfishItem.Add(strFindObj)
                Dim strFishTempValue = rowArray(i) & "~"
                fishItem.Add(strFishTempValue)
            ElseIf (ImporterfishItem.IndexOf(strFindObj) >= 0) Then
                Dim locIndex As Integer = ImporterfishItem.IndexOf(strFindObj)
                fishItem(locIndex) = fishItem(locIndex) & rowArray(i) & "~"
            End If
        Next

    End Sub
    Public Sub Generate_eSKPI(ByVal strValue As String, ByVal strBarcode As String, ByVal PPI As String, ByVal strFishItem As String)

        Dim sqlText As String = ""
        'Dim rowArray() As String = strValue.Split("~")
        Dim i As Integer


        For i = 0 To ImporterfishItem.Count - 1

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
            Dim totalSkpi As Integer = 0
            If totalItem > 0 And totalItem <= 8 Then
                totalSkpi = 1
            ElseIf totalItem > 8 Then
                Dim divTotalSkpi As Integer = totalItem / 8
                Dim modTotalSkpi As Integer = totalItem Mod 8
                If modTotalSkpi > 0 Then
                    totalSkpi = Math.Round(divTotalSkpi, 0) + 1
                End If
            End If


            If totalSkpi > 0 Then
                Dim ix As Integer
                Dim idx_skpi As String
                For ix = 1 To totalSkpi
                    Dim str_eSKPI As String = PPI.Trim()
                    sqlText = "insert into nosiri_skpi(no_barcode,kod_pengimport)values('" & strBarcode & "','" & ImporterfishItem(i) & "');select SCOPE_IDENTITY()"
                    str_eSKPI = str_eSKPI & "-" & InsertAutoNumber(sqlText)
                    eSKPIArray.Add(str_eSKPI)
                    ieArray.Add(ImporterfishItem(i))
                    idx_skpi = ImporterfishItem(i) & "-" & ix
                    eSKPIArray_Index.Add(idx_skpi)
                Next

            End If
        Next
    End Sub

    Public Sub Generate_eSKPI_KIBFG(ByVal strValue As String, ByVal strBarcode As String, ByVal PPI As String, ByVal strFishItem As String)

        Dim sqlText As String = ""
        'Dim rowArray() As String = strValue.Split("~")
        Dim i As Integer


        For i = 0 To ImporterfishItem.Count - 1

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
            Dim totalSkpi As Integer = 0
            If totalItem > 0 And totalItem <= 8 Then
                totalSkpi = 1
            ElseIf totalItem > 8 Then
                Dim divTotalSkpi As Integer = totalItem / 8
                Dim modTotalSkpi As Integer = totalItem Mod 8
                If modTotalSkpi > 0 Then
                    totalSkpi = Math.Round(divTotalSkpi, 0) + 1
                End If
            End If


            If totalSkpi > 0 Then
                Dim ix As Integer
                Dim idx_skpi As String
                For ix = 1 To totalSkpi
                    Dim str_eSKPI As String = PPI.Trim()
                    sqlText = "insert into nosiri_skpi_KIBFG(no_barcode,kod_pengimport)values('" & strBarcode & "','" & ImporterfishItem(i) & "');select SCOPE_IDENTITY()"
                    str_eSKPI = str_eSKPI & "-" & InsertAutoNumber(sqlText)
                    eSKPIArray.Add(str_eSKPI)
                    ieArray.Add(ImporterfishItem(i))
                    idx_skpi = ImporterfishItem(i) & "-" & ix
                    eSKPIArray_Index.Add(idx_skpi)
                Next

            End If
        Next
    End Sub

#Region "Remarks By Nizam On 16th Aug 2007 "
    Public Sub ProsesFish_Item(ByVal strFish As String, ByVal strBarcode As String, ByVal kodUrusan As String)


        Dim mx As Integer
        For mx = 0 To ImporterfishItem.Count - 1
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


                ''Find specific kod_importer index location to get eSKPI no from arrayList
                'Dim skpi_idx As Integer = eSKPIArray_Index.IndexOf(strFindObj) 'BinarySearch(strFindObj)



                ''Find index location for jenis urusan for cajIkan calculation
                'pkodUrusan = kodUrusan & arrColIkan(3).Substring(0, 1)
                'strFindObj = pkodUrusan
                'Dim cajIdx As Integer = urusanArray.IndexOf(pkodUrusan) '.BinarySearch(strFindObj)


                'Dim nilaiCaj As Double = 0

                ''(CDbl(arrColIkan(5)) * CDbl(kadarPKArray(cajIdx))) + (CDbl(arrColIkan(7)) * CDbl(kadarPBArray(cajIdx))) _
                ''                   + (CDbl(arrColIkan(6)) * CDbl(kadarQtyArray(cajIdx))) _
                ''                   + (CDbl(arrColIkan(10)) * CDbl(kadarEkorArray(cajIdx)))

                ''Insert Fish Item Into Item_Isytihar_I
                'Dim sqlText As String
                ''sqlText = "INSERT INTO [W-ICCS].[dbo].[ITEM_ISYTIHAR_I]" & _
                ''          "([Nombor_Barcode], [No_SKPI], [Bil_Item], [Kod_Ikan]," & _
                ''          "[Destinasi_Pasar], [PetiKecil], [KuantitiKecil]," & _
                ''          "[PetiBesar], [KuantitiBesar], [Pek], [Ekor], [Nilai]," & _
                ''          "[Caj],[Site_Code]) values('" & strBarcode & "','" & eSKPIArray(skpi_idx).ToString() & _
                ''          "'," & bil_item & ",'" & arrColIkan(3) & "','" & arrColIkan(4) & _
                ''          "'," & arrColIkan(5) & "," & arrColIkan(6) & "," & arrColIkan(7) & _
                ''          "," & arrColIkan(8) & "," & arrColIkan(9) & "," & arrColIkan(10) & "," & arrColIkan(11) & "," & nilaiCaj & ",'001')"

                '' closed by zue on 17 June 
                'nilaiCaj = CDbl(arrColIkan(18))
                '' end coded
                'Dim cajIkanKodId As Integer = 0
                'If arrColIkan(17).Trim() <> "" Then
                '    cajIkanKodId = arrColIkan(17).Trim()
                'End If

                'Find specific kod_importer index location to get eSKPI no from arrayList

                Dim skpi_idx As Integer = eSKPIArray_Index.IndexOf(strFindObj) 'BinarySearch(strFindObj)

                Dim nilaiCaj As Double = 0

                nilaiCaj = CDbl(arrColIkan(18))

                Dim nilaiCajSvr As Double = 0

                Dim kateIkan As String = arrColIkan(3).Substring(0, 1)

                'Periksa sama ada company ini ada pengurangan caj atau tidak
                Dim cariKodSyarikat As String = arrColIkan(0) & "_" & kateIkan
                Dim cariKodSyarikatIdx As Integer = companyPCaj.IndexOf(cariKodSyarikat) '.BinarySearch(strFindObj)

                Dim cajIkanKodId As Integer = 0
                If arrColIkan(17).Trim() <> "" Then
                    cajIkanKodId = arrColIkan(17).Trim()
                End If

                If cariKodSyarikatIdx >= 0 Then

                    If jkategoriIkanCaj(cariKodSyarikatIdx) = kateIkan Then
                        nilaiCajSvr = (CDbl(arrColIkan(5)) * CDbl(kadarPKArrayCaj(cariKodSyarikatIdx))) + (CDbl(arrColIkan(7)) * CDbl(kadarPBArrayCaj(cariKodSyarikatIdx))) + (CDbl(arrColIkan(6)) * CDbl(kadarQtyArrayCaj(cariKodSyarikatIdx))) + (CDbl(arrColIkan(10)) * CDbl(kadarEkorArrayCaj(cariKodSyarikatIdx)))
                        cajIkanKodId = idIkanCaj(cariKodSyarikatIdx).ToString()
                    Else
                        'Find index location for jenis urusan for cajIkan calculation
                        pkodUrusan = kodUrusan '& arrColIkan(3).Substring(0, 1)
                        pkodUrusan = pkodUrusan & "_" & kateIkan
                        Dim cajIdx As Integer = urusanArray.IndexOf(pkodUrusan) '.BinarySearch(strFindObj)
                        If cajIdx >= 0 Then
                            'If jkategoriIkan(cajIdx) = kateIkan Then
                            nilaiCajSvr = (CDbl(arrColIkan(5)) * CDbl(kadarPKArray(cajIdx))) + (CDbl(arrColIkan(7)) * CDbl(kadarPBArray(cajIdx))) + (CDbl(arrColIkan(6)) * CDbl(kadarQtyArray(cajIdx))) + (CDbl(arrColIkan(10)) * CDbl(kadarEkorArray(cajIdx)))
                            cajIkanKodId = normalIdIkanCaj(cajIdx).ToString()
                            'End If
                        End If

                    End If

                Else
                    'Find index location for jenis urusan for cajIkan calculation
                    pkodUrusan = kodUrusan '& arrColIkan(3).Substring(0, 1)
                    pkodUrusan = pkodUrusan & "_" & kateIkan
                    Dim cajIdx As Integer = urusanArray.IndexOf(pkodUrusan) '.BinarySearch(strFindObj)
                    If cajIdx >= 0 Then
                        'If jkategoriIkan(cajIdx) = kateIkan Then
                        nilaiCajSvr = (CDbl(arrColIkan(5)) * CDbl(kadarPKArray(cajIdx))) + (CDbl(arrColIkan(7)) * CDbl(kadarPBArray(cajIdx))) + (CDbl(arrColIkan(6)) * CDbl(kadarQtyArray(cajIdx))) + (CDbl(arrColIkan(10)) * CDbl(kadarEkorArray(cajIdx)))
                        cajIkanKodId = normalIdIkanCaj(cajIdx).ToString()
                        'End If
                    End If

                End If

                Dim sqlText As String

                If (skpi_idx > -1) Then


                    sqlText = "INSERT INTO [W-ICCS].[dbo].[ITEM_ISYTIHAR_I]" & _
                              "([Nombor_Barcode], [No_SKPI], [Bil_Item], [Kod_Ikan]," & _
                              "[Destinasi_Pasar], [PetiKecil], [KuantitiKecil]," & _
                              "[PetiBesar], [KuantitiBesar], [Pek], [Ekor], [Nilai]," & _
                              "[Caj],[Site_Code],[Caj_Ikan_ID],[CajSvr]) values('" & strBarcode & "','" & eSKPIArray(skpi_idx).ToString() & _
                              "'," & bil_item & ",'" & arrColIkan(3) & "','" & arrColIkan(4) & _
                              "'," & arrColIkan(5) & "," & arrColIkan(6) & "," & arrColIkan(7) & _
                              "," & arrColIkan(8) & "," & arrColIkan(9) & "," & arrColIkan(10) & "," & arrColIkan(11) & "," & nilaiCajSvr & ",'001'," & cajIkanKodId & "," & nilaiCaj & ")"


                    InsertData(sqlText)


                    'transactionProcess.Add(sqlText)
                    'InsertData(sqlText)

                    'Calculate total for all item declaration
                    totalSemuaCaj = totalSemuaCaj + CDec(nilaiCaj)
                    totalSemuaNilai = totalSemuaNilai + CDec(arrColIkan(11))
                    totalPetiKecil = totalPetiKecil + CDec(arrColIkan(5))
                    totalKuantitiKecil = totalKuantitiKecil + CDec(arrColIkan(6))
                    totalPetiBesar = totalPetiBesar + CDec(arrColIkan(7))
                    totalKuantitiBesar = totalKuantitiBesar + CDec(arrColIkan(8))
                    totalPek = totalPek + CDec(arrColIkan(9))
                    totalEkor = totalEkor + CDec(arrColIkan(10))

                    bil_item = bil_item + 1
                End If
            Next

        Next
    End Sub

#End Region


    Public Sub Generate_eSKPI_SemulaPindahan(ByVal strValue As String, ByVal strBarcode As String, ByVal PPI As String, ByVal strFishItem As String)

        Dim sqlText As String = ""
        Dim rowArray() As String = strValue.Split("~")
        Dim i As Integer

        For i = 0 To UBound(rowArray) - 1
            Dim valStr() As String
            Dim importerStr() As String


            valStr = rowArray(i).Split("`")
            importerStr = valStr(0).Split("|")

            If valStr(8).Trim() <> "A" Then
                'If valStr(8).Trim() = "B" Then

                'Checked whether skpi already generated or not
                'sqlText = "select noSkpi from nosiri_skpi where no_barcode='" & strBarcode & "' and kod_pengimport='" & importerStr(0) & "' order by kod_pengimport asc "
                'Dim data As String = SingleFieldResults(sqlText)
                'If data <> "" Then

                'str_eSKPI = str_eSKPI & "-" & Data.PadLeft(7, "0")
                'eSKPIArray.Add(str_eSKPI)
                'ieArray.Add(importerStr(0))
                'eSKPIArray_Index.Add(idx_skpi)

                'Else

                Dim totalSkpi As Integer = 0
                Dim totalItem As Integer = CountFishItemDeclared(strFishItem, importerStr(0).ToString())

                If totalItem > 0 And totalItem <= 8 Then
                    totalSkpi = 1
                ElseIf totalItem > 8 Then
                    Dim divTotalSkpi As Integer = totalItem / 8
                    Dim modTotalSkpi As Integer = totalItem Mod 8

                    If modTotalSkpi > 0 Then
                        totalSkpi = Math.Round(divTotalSkpi, 0) + 1
                    End If
                End If

                If totalSkpi > 0 Then
                    Dim ix As Integer
                    Dim idx_skpi As String
                    For ix = 1 To totalSkpi
                        Dim str_eSKPI As String = PPI.Trim()
                        sqlText = "insert into nosiri_skpi(no_barcode,kod_pengimport)values('" & strBarcode & "','" & importerStr(0) & "');select SCOPE_IDENTITY()"
                        str_eSKPI = str_eSKPI & "-" & InsertAutoNumber(sqlText)
                        eSKPIArray.Add(str_eSKPI)
                        ieArray.Add(importerStr(0))
                        idx_skpi = importerStr(0) & "-" & ix
                        eSKPIArray_Index.Add(idx_skpi)
                    Next
                End If


            End If ' If valStar(6)=="B"
        Next
    End Sub

    Public Sub Generate_eSKPI_Semula(ByVal strValue As String, ByVal strBarcode As String, ByVal PPI As String, ByVal strFishItem As String)

        Dim sqlText As String = ""
        Dim rowArray() As String = strValue.Split("~")
        Dim i As Integer

        For i = 0 To UBound(rowArray) - 1
            Dim valStr() As String
            Dim importerStr() As String


            valStr = rowArray(i).Split("`")
            importerStr = valStr(0).Split("|")

            If valStr(6).Trim() <> "A" Then
                ' If valStr(6).Trim() = "B" Or valStr(6).Trim() = "" Then

                'Checked whether skpi already generated or not
                'sqlText = "select noSkpi from nosiri_skpi where no_barcode='" & strBarcode & "' and kod_pengimport='" & importerStr(0) & "' order by kod_pengimport asc "
                'Dim data As String = SingleFieldResults(sqlText)
                'If data <> "" Then

                'str_eSKPI = str_eSKPI & "-" & data.PadLeft(7, "0")
                'eSKPIArray.Add(str_eSKPI)
                'ieArray.Add(importerStr(0))
                'eSKPIArray_Index.Add(idx_skpi)

                ' Else
                Dim totalItem As Integer = CountFishItemDeclared(strFishItem, importerStr(0).ToString())
                Dim totalSkpi As Integer = 0

                If totalItem > 0 And totalItem <= 8 Then
                    totalSkpi = 1
                ElseIf totalItem > 8 Then

                    Dim divTotalSkpi As Integer = totalItem / 8
                    Dim modTotalSkpi As Integer = totalItem Mod 8
                    If modTotalSkpi > 0 Then
                        totalSkpi = Math.Round(divTotalSkpi, 0) + 1
                    End If
                End If

                If totalSkpi > 0 Then

                    Dim ix As Integer
                    Dim idx_skpi As String
                    For ix = 1 To totalSkpi
                        Dim str_eSKPI As String = PPI.Trim()
                        sqlText = "insert into nosiri_skpi(no_barcode,kod_pengimport)values('" & strBarcode & "','" & importerStr(0) & "');select SCOPE_IDENTITY()"
                        str_eSKPI = str_eSKPI & "-" & InsertAutoNumber(sqlText)
                        eSKPIArray.Add(str_eSKPI)
                        ieArray.Add(importerStr(0))
                        idx_skpi = importerStr(0) & "-" & ix
                        eSKPIArray_Index.Add(idx_skpi)
                    Next
                End If
                'End If
                'End If
            End If ' If valStar(6)=="B"
        Next
    End Sub

    Public Function CountFishItemDeclared(ByVal strFish As String, ByVal kodImporter As String) As Integer
        Dim rowArray() As String
        Dim i As Integer
        Dim cntItem As New ArrayList()
        Dim totalItem As Integer = 0

        rowArray = strFish.Split("~")
        For i = 0 To UBound(rowArray) - 1
            Dim arrColIkan() As String = rowArray(i).Split("`")
            If (kodImporter = arrColIkan(0).ToString()) Then
                totalItem = totalItem + 1
            End If
        Next

        Return totalItem

    End Function



    Public Sub Load_CajIkan()

        Dim sqlText As String = "SELECT RTRIM(Kategori_Ikan) as Kategori_Ikan, RTRIM(Jenis_Urusan) as Jenis_Urusan, Kadar_Peti_Kecil, Kadar_Peti_Besar, Kadar_Ekor, Kadar_Kuantiti, id " & _
                                "FROM IKAN_CAJ WHERE status = 'yes'"

        Dim cajIkanRdr As System.Data.SqlClient.SqlDataReader
        cajIkanRdr = DataReader(sqlText)
        Do While cajIkanRdr.Read
            Dim urusanKategori As String = cajIkanRdr.GetValue(1) & "_" & cajIkanRdr.GetValue(0)
            jkategoriIkan.Add(cajIkanRdr.GetValue(0))
            urusanArray.Add(urusanKategori)
            kadarPKArray.Add(cajIkanRdr.GetValue(2))
            kadarPBArray.Add(cajIkanRdr.GetValue(3))
            kadarEkorArray.Add(cajIkanRdr.GetValue(4))
            kadarQtyArray.Add(cajIkanRdr.GetValue(5))
            normalIdIkanCaj.Add(cajIkanRdr.GetValue(6))

        Loop
        cajIkanRdr.Close()
        'cajIkanRdr = Nothing

    End Sub
    Public Sub Load_CajIkan_KIBFG()

        Dim sqlText As String = "SELECT RTRIM(Kategori_Ikan) as Kategori_Ikan, RTRIM(Jenis_Urusan) as Jenis_Urusan, Kadar_Peti_Kecil, Kadar_Peti_Besar, Kadar_Ekor, Kadar_Kuantiti, id " & _
                                "FROM IKAN_CAJ_KIBFG WHERE status = 'yes'"

        Dim cajIkanRdr As System.Data.SqlClient.SqlDataReader
        cajIkanRdr = DataReader(sqlText)
        Do While cajIkanRdr.Read
            Dim urusanKategori As String = cajIkanRdr.GetValue(1) & "_" & cajIkanRdr.GetValue(0)
            jkategoriIkan.Add(cajIkanRdr.GetValue(0))
            urusanArray.Add(urusanKategori)
            kadarPKArray.Add(cajIkanRdr.GetValue(2))
            kadarPBArray.Add(cajIkanRdr.GetValue(3))
            kadarEkorArray.Add(cajIkanRdr.GetValue(4))
            kadarQtyArray.Add(cajIkanRdr.GetValue(5))
            normalIdIkanCaj.Add(cajIkanRdr.GetValue(6))

        Loop
        cajIkanRdr.Close()
        'cajIkanRdr = Nothing

    End Sub
    Public Sub Load_CajIkanSyarikat()
        'Load Kadar Caj Ikan Untuk Pengimport Tertentu
        Dim caj_sqlText As String = "SELECT RTRIM(Kategori_Ikan) as Kategori_Ikan, RTRIM(Jenis_Urusan) as Jenis_Urusan, Kadar_Peti_Kecil, Kadar_Peti_Besar, Kadar_Ekor, Kadar_Kuantiti, Kod_Pengimport +'_'+ RTRIM(Kategori_Ikan) ,id " & _
                                    "FROM COMPANY_IKAN_CAJ WHERE (tarikh_tamat >= GETDATE())"
        Dim caj_jsReader As System.Data.SqlClient.SqlDataReader = DataReader(caj_sqlText)
        Do While caj_jsReader.Read
            jkategoriIkanCaj.Add(caj_jsReader.GetValue(0).ToString.Trim())
            'urusanArrayCaj.Add(caj_jsReader.GetValue(1))
            kadarPKArrayCaj.Add(caj_jsReader.GetValue(2))
            kadarPBArrayCaj.Add(caj_jsReader.GetValue(3))
            kadarEkorArrayCaj.Add(caj_jsReader.GetValue(4))
            kadarQtyArrayCaj.Add(caj_jsReader.GetValue(5))
            idIkanCaj.Add(caj_jsReader.GetValue(7))
            companyPCaj.Add(caj_jsReader.GetValue(6))
        Loop
        caj_jsReader.Close()
        'caj_jsReader = Nothing
    End Sub



    'Public Sub ProsesFish_Item(ByVal strFish As String, ByVal strBarcode As String, ByVal kodUrusan As String)
    '    Dim mx As Integer
    '    For mx = 0 To ImporterfishItem.Count - 1
    '        Dim i As Integer
    '        Dim stringFish As String = fishItem(mx).ToString
    '        Dim rowArray() As String = stringFish.Split("~")
    '        Dim totRowArray As Integer = UBound(rowArray) - 1
    '        Dim rowCount = 1
    '        Dim bil_item As Integer = 1
    '        Dim pkodUrusan = kodUrusan
    '        For i = 0 To totRowArray

    '            If bil_item = 9 Then
    '                rowCount = rowCount + 1
    '                bil_item = 1
    '            End If

    '            Dim arrColIkan() As String = rowArray(i).Split("`")
    '            Dim strFindObj As String = arrColIkan(0) & "-" & rowCount.ToString
    '            'Find specific kod_importer index location to get eSKPI no from arrayList
    '            Dim skpi_idx As Integer = eSKPIArray_Index.IndexOf(strFindObj) 'BinarySearch(strFindObj)

    '            Dim nilaiCaj As Double = 0
    '            Dim nilaiCajSvr As Double = 0

    '            Dim kateIkan As String = arrColIkan(3).Substring(0, 1)

    '            'Periksa sama ada company ini ada pengurangan caj atau tidak
    '            Dim cariKodSyarikat As String = arrColIkan(0) & "_" & kateIkan
    '            Dim cariKodSyarikatIdx As Integer = companyPCaj.IndexOf(cariKodSyarikat) '.BinarySearch(strFindObj)

    '            If cariKodSyarikatIdx >= 0 Then

    '                If jkategoriIkanCaj(cariKodSyarikatIdx) = kateIkan Then
    '                    nilaiCajSvr = (CDbl(arrColIkan(5)) * CDbl(kadarPKArrayCaj(cariKodSyarikatIdx))) + (CDbl(arrColIkan(7)) * CDbl(kadarPBArrayCaj(cariKodSyarikatIdx))) + (CDbl(arrColIkan(6)) * CDbl(kadarQtyArrayCaj(cariKodSyarikatIdx))) + (CDbl(arrColIkan(10)) * CDbl(kadarEkorArrayCaj(cariKodSyarikatIdx)))
    '                Else
    '                    'Find index location for jenis urusan for cajIkan calculation
    '                    pkodUrusan = kodUrusan '& arrColIkan(3).Substring(0, 1)
    '                    pkodUrusan = pkodUrusan & "_" & kateIkan
    '                    Dim cajIdx As Integer = urusanArray.IndexOf(pkodUrusan) '.BinarySearch(strFindObj)
    '                    If cajIdx >= 0 Then
    '                        'If jkategoriIkan(cajIdx) = kateIkan Then
    '                        nilaiCajSvr = (CDbl(arrColIkan(5)) * CDbl(kadarPKArray(cajIdx))) + (CDbl(arrColIkan(7)) * CDbl(kadarPBArray(cajIdx))) + (CDbl(arrColIkan(6)) * CDbl(kadarQtyArray(cajIdx))) + (CDbl(arrColIkan(10)) * CDbl(kadarEkorArray(cajIdx)))
    '                        'End If
    '                    End If

    '                End If

    '            Else
    '                'Find index location for jenis urusan for cajIkan calculation
    '                pkodUrusan = kodUrusan '& arrColIkan(3).Substring(0, 1)
    '                pkodUrusan = pkodUrusan & "_" & kateIkan
    '                Dim cajIdx As Integer = urusanArray.IndexOf(pkodUrusan) '.BinarySearch(strFindObj)
    '                If cajIdx >= 0 Then
    '                    'If jkategoriIkan(cajIdx) = kateIkan Then
    '                    nilaiCajSvr = (CDbl(arrColIkan(5)) * CDbl(kadarPKArray(cajIdx))) + (CDbl(arrColIkan(7)) * CDbl(kadarPBArray(cajIdx))) + (CDbl(arrColIkan(6)) * CDbl(kadarQtyArray(cajIdx))) + (CDbl(arrColIkan(10)) * CDbl(kadarEkorArray(cajIdx)))
    '                    'End If
    '                End If

    '            End If

    '            'Insert Fish Item Into Item_Isytihar_I
    '            Dim sqlText As String
    '            nilaiCaj = CDbl(arrColIkan(18))

    '            Dim cajIkanKodId As Integer = 0
    '            If arrColIkan(17).Trim() <> "" Then
    '                cajIkanKodId = arrColIkan(17).Trim()
    '            End If

    '            If (skpi_idx > -1) Then


    '                sqlText = "INSERT INTO [W-ICCS].[dbo].[ITEM_ISYTIHAR_I]" & _
    '                          "([Nombor_Barcode], [No_SKPI], [Bil_Item], [Kod_Ikan]," & _
    '                          "[Destinasi_Pasar], [PetiKecil], [KuantitiKecil]," & _
    '                          "[PetiBesar], [KuantitiBesar], [Pek], [Ekor], [Nilai]," & _
    '                          "[CajSvr],[Site_Code],[Caj_Ikan_ID],[Caj]) values('" & strBarcode & "','" & eSKPIArray(skpi_idx).ToString() & _
    '                          "'," & bil_item & ",'" & arrColIkan(3) & "','" & arrColIkan(4) & _
    '                          "'," & arrColIkan(5) & "," & arrColIkan(6) & "," & arrColIkan(7) & _
    '                          "," & arrColIkan(8) & "," & arrColIkan(9) & "," & arrColIkan(10) & "," & arrColIkan(11) & "," & nilaiCaj & ",'001'," & cajIkanKodId & "," & nilaiCajSvr & ")"


    '                InsertData(sqlText)


    '                'transactionProcess.Add(sqlText)
    '                'InsertData(sqlText)

    '                'Calculate total for all item declaration
    '                totalSemuaCaj = totalSemuaCaj + CDec(nilaiCaj)
    '                totalSemuaNilai = totalSemuaNilai + CDec(arrColIkan(11))
    '                totalPetiKecil = totalPetiKecil + CDec(arrColIkan(5))
    '                totalKuantitiKecil = totalKuantitiKecil + CDec(arrColIkan(6))
    '                totalPetiBesar = totalPetiBesar + CDec(arrColIkan(7))
    '                totalKuantitiBesar = totalKuantitiBesar + CDec(arrColIkan(8))
    '                totalPek = totalPek + CDec(arrColIkan(9))
    '                totalEkor = totalEkor + CDec(arrColIkan(10))

    '                bil_item = bil_item + 1
    '            End If
    '        Next

    '    Next

    'End Sub


    Public Sub ProsesFish_Item_KIBFG(ByVal strFish As String, ByVal strBarcode As String, ByVal kodUrusan As String)
        Dim mx As Integer
        For mx = 0 To ImporterfishItem.Count - 1
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
                Dim skpi_idx As Integer = eSKPIArray_Index.IndexOf(strFindObj) 'BinarySearch(strFindObj)

                Dim nilaiCaj As Double = 0
                Dim nilaiCajSvr As Double = 0

                Dim kateIkan As String = arrColIkan(3).Substring(0, 1)

                'Periksa sama ada company ini ada pengurangan caj atau tidak
                Dim cariKodSyarikat As String = arrColIkan(0) & "_" & kateIkan
                Dim cariKodSyarikatIdx As Integer = companyPCaj.IndexOf(cariKodSyarikat) '.BinarySearch(strFindObj)

                If cariKodSyarikatIdx >= 0 Then

                    If jkategoriIkanCaj(cariKodSyarikatIdx) = kateIkan Then
                        nilaiCajSvr = (CDbl(arrColIkan(5)) * CDbl(kadarPKArrayCaj(cariKodSyarikatIdx))) + (CDbl(arrColIkan(7)) * CDbl(kadarPBArrayCaj(cariKodSyarikatIdx))) + (CDbl(arrColIkan(6)) * CDbl(kadarQtyArrayCaj(cariKodSyarikatIdx))) + (CDbl(arrColIkan(10)) * CDbl(kadarEkorArrayCaj(cariKodSyarikatIdx)))
                    Else
                        'Find index location for jenis urusan for cajIkan calculation
                        pkodUrusan = kodUrusan '& arrColIkan(3).Substring(0, 1)
                        pkodUrusan = pkodUrusan & "_" & kateIkan
                        Dim cajIdx As Integer = urusanArray.IndexOf(pkodUrusan) '.BinarySearch(strFindObj)
                        If cajIdx >= 0 Then
                            'If jkategoriIkan(cajIdx) = kateIkan Then
                            nilaiCajSvr = (CDbl(arrColIkan(5)) * CDbl(kadarPKArray(cajIdx))) + (CDbl(arrColIkan(7)) * CDbl(kadarPBArray(cajIdx))) + (CDbl(arrColIkan(6)) * CDbl(kadarQtyArray(cajIdx))) + (CDbl(arrColIkan(10)) * CDbl(kadarEkorArray(cajIdx)))
                            'End If
                        End If

                    End If

                Else
                    'Find index location for jenis urusan for cajIkan calculation
                    pkodUrusan = kodUrusan '& arrColIkan(3).Substring(0, 1)
                    pkodUrusan = pkodUrusan & "_" & kateIkan
                    Dim cajIdx As Integer = urusanArray.IndexOf(pkodUrusan) '.BinarySearch(strFindObj)
                    If cajIdx >= 0 Then
                        'If jkategoriIkan(cajIdx) = kateIkan Then
                        nilaiCajSvr = (CDbl(arrColIkan(5)) * CDbl(kadarPKArray(cajIdx))) + (CDbl(arrColIkan(7)) * CDbl(kadarPBArray(cajIdx))) + (CDbl(arrColIkan(6)) * CDbl(kadarQtyArray(cajIdx))) + (CDbl(arrColIkan(10)) * CDbl(kadarEkorArray(cajIdx)))
                        'End If
                    End If

                End If

                'Insert Fish Item Into Item_Isytihar_I
                Dim sqlText As String
                nilaiCaj = CDbl(arrColIkan(18))

                Dim cajIkanKodId As Integer = 0
                If arrColIkan(17).Trim() <> "" Then
                    cajIkanKodId = arrColIkan(17).Trim()
                End If

                If (skpi_idx > -1) Then


                    sqlText = "INSERT INTO [W-ICCS].[dbo].[ITEM_ISYTIHAR_I_KIBFG]" & _
                              "([Nombor_Barcode], [No_SKPI], [Bil_Item], [Kod_Ikan]," & _
                              "[Destinasi_Pasar], [PetiKecil], [KuantitiKecil]," & _
                              "[PetiBesar], [KuantitiBesar], [Pek], [Ekor], [Nilai]," & _
                              "[CajSvr],[Site_Code],[Caj_Ikan_ID],[Caj]) values('" & strBarcode & "','" & eSKPIArray(skpi_idx).ToString() & _
                              "'," & bil_item & ",'" & arrColIkan(3) & "','" & arrColIkan(4) & _
                              "'," & arrColIkan(5) & "," & arrColIkan(6) & "," & arrColIkan(7) & _
                              "," & arrColIkan(8) & "," & arrColIkan(9) & "," & arrColIkan(10) & "," & arrColIkan(11) & "," & nilaiCaj & ",'001'," & cajIkanKodId & "," & nilaiCajSvr & ")"


                    InsertData(sqlText)


                    'transactionProcess.Add(sqlText)
                    'InsertData(sqlText)

                    'Calculate total for all item declaration
                    totalSemuaCaj = totalSemuaCaj + CDec(nilaiCaj)
                    totalSemuaNilai = totalSemuaNilai + CDec(arrColIkan(11))
                    totalPetiKecil = totalPetiKecil + CDec(arrColIkan(5))
                    totalKuantitiKecil = totalKuantitiKecil + CDec(arrColIkan(6))
                    totalPetiBesar = totalPetiBesar + CDec(arrColIkan(7))
                    totalKuantitiBesar = totalKuantitiBesar + CDec(arrColIkan(8))
                    totalPek = totalPek + CDec(arrColIkan(9))
                    totalEkor = totalEkor + CDec(arrColIkan(10))

                    bil_item = bil_item + 1
                End If
            Next

        Next

    End Sub
#Region "Remarks By Nizam On 16th Aug 2006"
    'Public Sub Load_CajIkan()

    '    Dim sqlText As String = "SELECT     RTRIM(CAST(Jenis_Urusan AS varchar(3))) + RTRIM(CAST(Kategori_Ikan AS varchar(5))) AS Jenis_Urusan, Kadar_Peti_Kecil," & _
    '                            " Kadar_Peti_Besar, Kadar_Ekor, Kadar_Kuantiti FROM IKAN_CAJ"

    '    Dim cajIkanRdr As System.Data.SqlClient.SqlDataReader
    '    cajIkanRdr = DataReader(sqlText)
    '    Do While cajIkanRdr.Read
    '        urusanArray.Add(cajIkanRdr.GetValue(0))
    '        kadarPKArray.Add(cajIkanRdr.GetValue(1))
    '        kadarPBArray.Add(cajIkanRdr.GetValue(2))
    '        kadarEkorArray.Add(cajIkanRdr.GetValue(3))
    '        kadarQtyArray.Add(cajIkanRdr.GetValue(4))
    '    Loop
    '    cajIkanRdr.Close()

    'End Sub
#End Region


    Public Sub Proses_Pengisytiharan(ByVal strImporter As String, ByVal strBarcode As String, ByVal no_daftar As Integer, ByVal no_kenderaan As String, ByVal jenisUrusan As String, ByVal namaPemandu As String, ByVal caraPengangkutan As String, ByVal bekalan As String, ByVal ppi As String, ByVal online As String)
        Dim i As Integer
        Dim arrImporterRow() = strImporter.Split("~")
        Dim mx As Integer
        For mx = 0 To eSKPIArray_Index.Count - 1

            For i = 0 To UBound(arrImporterRow) - 1

                Dim arrImporterCol() As String = arrImporterRow(i).ToString().Split("`")
                Dim arrImporterDetails() As String = arrImporterCol(0).Split("|")
                Dim kodPengimport As String = arrImporterDetails(0)

                If kodPengimport = ieArray(mx).ToString Then

                    'Find eSKPI Generated For The Specific kodPengimport
                    Dim strFindObj As Object = kodPengimport
                    'Dim eskpi_idx As Integer = ieArray.IndexOf(kodPengimport) '.BinarySearch(strFindObj)
                    Dim eskpi_val As String = eSKPIArray(mx).ToString()
                    Dim nama_pegawai = Session("username")

                    Dim namaPemanduPindahan As String = ""
                    Dim noKenderaanPindahan As String = ""

                    If jenisUrusan = "008" Then
                        namaPemanduPindahan = arrImporterCol(6)
                        noKenderaanPindahan = arrImporterCol(7)

                        namaPemanduPindahan = namaPemanduPindahan.Replace("'", "''")
                        noKenderaanPindahan = noKenderaanPindahan.Replace("'", "''")

                    End If

                    Dim sqlText As String = ""
                    sqlText = "SELECT No_SKPI, SUM(PetiKecil) AS TPK, SUM(KuantitiKecil) AS TQK, SUM(PetiBesar) AS TPB, SUM(KuantitiBesar) AS TQB, SUM(Pek) AS tpek, SUM(Ekor) " & _
                              "AS ekor, SUM(Nilai) AS tnilai, SUM(Caj) AS tcaj FROM ITEM_ISYTIHAR_I WHERE Nombor_Barcode ='" & strBarcode & "' AND No_SKPI ='" & eskpi_val & "' " & _
                              "GROUP BY No_SKPI"
                    Dim myCaj As System.Data.SqlClient.SqlDataReader = DataReader(sqlText)

                    If myCaj.HasRows Then
                        myCaj.Read()
                        totalPetiKecil = myCaj.GetValue(1)
                        totalKuantitiKecil = myCaj.GetValue(2)
                        totalPetiBesar = myCaj.GetValue(3)
                        totalKuantitiBesar = myCaj.GetValue(4)
                        totalPek = myCaj.GetValue(5)
                        totalEkor = myCaj.GetValue(6)
                        totalSemuaNilai = myCaj.GetValue(7)
                        totalSemuaCaj = myCaj.GetValue(8)
                    End If
                    myCaj.Close()
                    myCaj = Nothing


                    Dim myTotalItemSS As Integer = 0
                    Dim myDataS As String = ""
                    sqlText = "select count(*) as rectotal from item_isytihar_i where nombor_barcode='" & strBarcode & "' and no_skpi='" & eskpi_val & "'"
                    myDataS = SingleFieldResults(sqlText)
                    If myDataS <> "" Then
                        myTotalItemSS = CInt(myDataS)
                    End If



                    If myTotalItemSS > 0 Then
                        namaPemandu = namaPemandu.Replace("'", "''")

                        'Generate Insert Statement For Insertion Prosess
                        sqlText = "INSERT INTO [W-ICCS].[dbo].[PENGISYTIHARAN_I]" & _
                                                "([No_Barcode], [No_SKPI], [No_Daftar], [No_Kenderaan]," & _
                                                "[Cara_Pengangkutan], [Kod_Pengimport], [Kod_Pengeksport]," & _
                                                "[Kod_PPI], [TotalPetiKecil]," & _
                                                "[TotalKuantitiKecil], [TotalPetiBesar], [TotalKuantitiBesar], [TotalPek]," & _
                                                "[TotalEkor], [TotalNilai], [TotalCajIkan], [Sumber_Bekalan], [Status]," & _
                                                "[Nama_Pegawai],[Nama_PemanduPindahan],[No_KenderaanPindahan],[OnlineSend_by],[Kod_Urusan],[Site_Code],[Nama_Pemandu])" & _
                                                "VALUES('" & strBarcode & "','" & eskpi_val & "','" & no_daftar & "'," & _
                                                "'" & no_kenderaan & "','" & caraPengangkutan & "','" & kodPengimport & "','" & arrImporterCol(4) & "'," & _
                                                "'" & ppi & "'," & totalPetiKecil & "," & totalKuantitiKecil & "," & totalPetiBesar & "," & _
                                                totalKuantitiBesar & "," & totalPek & "," & totalEkor & "," & totalSemuaNilai & "," & totalSemuaCaj & "," & _
                                                "'" & bekalan & "','A','" & nama_pegawai & "','" & namaPemanduPindahan & "','" & noKenderaanPindahan & "','" & online & "','" & jenisUrusan & "','001','" & namaPemandu & "')"
                        transactionProcess.Add(sqlText)
                    End If

                    'InsertData(sqlText)
                End If
            Next
        Next 'End Next of eSkpi Array
    End Sub
    Public Sub Proses_Pengisytiharan_KIBFG(ByVal strImporter As String, ByVal strBarcode As String, ByVal no_daftar As Integer, ByVal no_kenderaan As String, ByVal jenisUrusan As String, ByVal namaPemandu As String, ByVal caraPengangkutan As String, ByVal bekalan As String, ByVal ppi As String, ByVal online As String)
        Dim i As Integer
        Dim arrImporterRow() = strImporter.Split("~")
        Dim mx As Integer
        For mx = 0 To eSKPIArray_Index.Count - 1

            For i = 0 To UBound(arrImporterRow) - 1

                Dim arrImporterCol() As String = arrImporterRow(i).ToString().Split("`")
                Dim arrImporterDetails() As String = arrImporterCol(0).Split("|")
                Dim kodPengimport As String = arrImporterDetails(0)

                If kodPengimport = ieArray(mx).ToString Then

                    'Find eSKPI Generated For The Specific kodPengimport
                    Dim strFindObj As Object = kodPengimport
                    'Dim eskpi_idx As Integer = ieArray.IndexOf(kodPengimport) '.BinarySearch(strFindObj)
                    Dim eskpi_val As String = eSKPIArray(mx).ToString()
                    Dim nama_pegawai = Session("username")

                    Dim namaPemanduPindahan As String = ""
                    Dim noKenderaanPindahan As String = ""

                    If jenisUrusan = "008" Then
                        namaPemanduPindahan = arrImporterCol(6)
                        noKenderaanPindahan = arrImporterCol(7)

                        namaPemanduPindahan = namaPemanduPindahan.Replace("'", "''")
                        noKenderaanPindahan = noKenderaanPindahan.Replace("'", "''")

                    End If

                    Dim sqlText As String = ""
                    sqlText = "SELECT No_SKPI, SUM(PetiKecil) AS TPK, SUM(KuantitiKecil) AS TQK, SUM(PetiBesar) AS TPB, SUM(KuantitiBesar) AS TQB, SUM(Pek) AS tpek, SUM(Ekor) " & _
                              "AS ekor, SUM(Nilai) AS tnilai, SUM(Caj) AS tcaj FROM ITEM_ISYTIHAR_I WHERE Nombor_Barcode ='" & strBarcode & "' AND No_SKPI ='" & eskpi_val & "' " & _
                              "GROUP BY No_SKPI"
                    Dim myCaj As System.Data.SqlClient.SqlDataReader = DataReader(sqlText)

                    If myCaj.HasRows Then
                        myCaj.Read()
                        totalPetiKecil = myCaj.GetValue(1)
                        totalKuantitiKecil = myCaj.GetValue(2)
                        totalPetiBesar = myCaj.GetValue(3)
                        totalKuantitiBesar = myCaj.GetValue(4)
                        totalPek = myCaj.GetValue(5)
                        totalEkor = myCaj.GetValue(6)
                        totalSemuaNilai = myCaj.GetValue(7)
                        totalSemuaCaj = myCaj.GetValue(8)
                    End If
                    myCaj.Close()
                    myCaj = Nothing


                    Dim myTotalItemSS As Integer = 0
                    Dim myDataS As String = ""
                    sqlText = "select count(*) as rectotal from item_isytihar_i where nombor_barcode='" & strBarcode & "' and no_skpi='" & eskpi_val & "'"
                    myDataS = SingleFieldResults(sqlText)
                    If myDataS <> "" Then
                        myTotalItemSS = CInt(myDataS)
                    End If



                    If myTotalItemSS > 0 Then
                        namaPemandu = namaPemandu.Replace("'", "''")

                        'Generate Insert Statement For Insertion Prosess
                        sqlText = "INSERT INTO [W-ICCS].[dbo].[PENGISYTIHARAN_I_KIBFG]" & _
                                                "([No_Barcode], [No_SKPI], [No_Daftar], [No_Kenderaan]," & _
                                                "[Cara_Pengangkutan], [Kod_Pengimport], [Kod_Pengeksport]," & _
                                                "[Kod_PPI], [TotalPetiKecil]," & _
                                                "[TotalKuantitiKecil], [TotalPetiBesar], [TotalKuantitiBesar], [TotalPek]," & _
                                                "[TotalEkor], [TotalNilai], [TotalCajIkan], [Sumber_Bekalan], [Status]," & _
                                                "[Nama_Pegawai],[Nama_PemanduPindahan],[No_KenderaanPindahan],[OnlineSend_by],[Kod_Urusan],[Site_Code],[Nama_Pemandu])" & _
                                                "VALUES('" & strBarcode & "','" & eskpi_val & "','" & no_daftar & "'," & _
                                                "'" & no_kenderaan & "','" & caraPengangkutan & "','" & kodPengimport & "','" & arrImporterCol(4) & "'," & _
                                                "'" & ppi & "'," & totalPetiKecil & "," & totalKuantitiKecil & "," & totalPetiBesar & "," & _
                                                totalKuantitiBesar & "," & totalPek & "," & totalEkor & "," & totalSemuaNilai & "," & totalSemuaCaj & "," & _
                                                "'" & bekalan & "','A','" & nama_pegawai & "','" & namaPemanduPindahan & "','" & noKenderaanPindahan & "','" & online & "','" & jenisUrusan & "','001','" & namaPemandu & "')"
                        transactionProcess.Add(sqlText)
                    End If

                    'InsertData(sqlText)
                End If
            Next
        Next 'End Next of eSkpi Array
    End Sub
    Public Sub Proses_Pengisytiharan_Semula(ByVal strImporter As String, ByVal strBarcode As String, ByVal no_daftar As Integer, ByVal no_kenderaan As String, ByVal jenisUrusan As String, ByVal namaPemandu As String, ByVal caraPengangkutan As String, ByVal bekalan As String, ByVal ppi As String, ByVal online As String)
        Dim i As Integer
        Dim arrImporterRow() = strImporter.Split("~")
        Dim mx As Integer
        For mx = 0 To eSKPIArray_Index.Count - 1

            For i = 0 To UBound(arrImporterRow) - 1

                Dim arrImporterCol() As String = arrImporterRow(i).ToString().Split("`")
                Dim arrImporterDetails() As String = arrImporterCol(0).Split("|")
                Dim kodPengimport As String = arrImporterDetails(0)

                If kodPengimport = ieArray(mx).ToString Then

                    'Find eSKPI Generated For The Specific kodPengimport
                    Dim strFindObj As Object = kodPengimport
                    'Dim eskpi_idx As Integer = ieArray.IndexOf(kodPengimport) '.BinarySearch(strFindObj)
                    Dim eskpi_val As String = eSKPIArray(mx).ToString()
                    Dim nama_pegawai = Session("username")

                    Dim namaPemanduPindahan As String = ""
                    Dim noKenderaanPindahan As String = ""

                    If jenisUrusan = "008" Then
                        namaPemanduPindahan = arrImporterCol(6)
                        noKenderaanPindahan = arrImporterCol(7)

                        namaPemanduPindahan = namaPemanduPindahan.Replace("'", "''")
                        noKenderaanPindahan = noKenderaanPindahan.Replace("'", "''")

                    End If

                    Dim sqlText As String = ""
                    sqlText = "SELECT No_SKPI, SUM(PetiKecil) AS TPK, SUM(KuantitiKecil) AS TQK, SUM(PetiBesar) AS TPB, SUM(KuantitiBesar) AS TQB, SUM(Pek) AS tpek, SUM(Ekor) " & _
                              "AS ekor, SUM(Nilai) AS tnilai, SUM(Caj) AS tcaj FROM ITEM_ISYTIHAR_I WHERE Nombor_Barcode ='" & strBarcode & "' AND No_SKPI ='" & eskpi_val & "' " & _
                              "GROUP BY No_SKPI"
                    Dim myCaj As System.Data.SqlClient.SqlDataReader = DataReader(sqlText)

                    If myCaj.HasRows Then
                        myCaj.Read()
                        totalPetiKecil = myCaj.GetValue(1)
                        totalKuantitiKecil = myCaj.GetValue(2)
                        totalPetiBesar = myCaj.GetValue(3)
                        totalKuantitiBesar = myCaj.GetValue(4)
                        totalPek = myCaj.GetValue(5)
                        totalEkor = myCaj.GetValue(6)
                        totalSemuaNilai = myCaj.GetValue(7)
                        totalSemuaCaj = myCaj.GetValue(8)
                    End If
                    myCaj.Close()
                    myCaj = Nothing

                    Dim myTotalItemSS As Integer = 0
                    Dim myDataS As String = ""
                    sqlText = "select count(*) as rectotal from item_isytihar_i where nombor_barcode='" & strBarcode & "' and no_skpi='" & eskpi_val & "'"
                    myDataS = SingleFieldResults(sqlText)
                    If myDataS <> "" Then
                        myTotalItemSS = CInt(myDataS)
                    End If

                    If myTotalItemSS > 0 Then

                        namaPemandu = namaPemandu.Replace("'", "''")
                        'Generate Insert Statement For Insertion Prosess
                        sqlText = "INSERT INTO [W-ICCS].[dbo].[PENGISYTIHARAN_I]" & _
                                                "([No_Barcode], [No_SKPI], [No_Daftar], [No_Kenderaan]," & _
                                                "[Cara_Pengangkutan], [Kod_Pengimport], [Kod_Pengeksport]," & _
                                                "[Kod_PPI], [TotalPetiKecil]," & _
                                                "[TotalKuantitiKecil], [TotalPetiBesar], [TotalKuantitiBesar], [TotalPek]," & _
                                                "[TotalEkor], [TotalNilai], [TotalCajIkan], [Sumber_Bekalan], [Status]," & _
                                                "[Nama_Pegawai],[Nama_PemanduPindahan],[No_KenderaanPindahan],[OnlineSend_by],[Kod_Urusan],[Site_Code])" & _
                                                "VALUES('" & strBarcode & "','" & eskpi_val & "','" & no_daftar & "'," & _
                                                "'" & no_kenderaan & "','" & caraPengangkutan & "','" & kodPengimport & "','" & arrImporterCol(4) & "'," & _
                                                "'" & ppi & "'," & totalPetiKecil & "," & totalKuantitiKecil & "," & totalPetiBesar & "," & _
                                                totalKuantitiBesar & "," & totalPek & "," & totalEkor & "," & totalSemuaNilai & "," & totalSemuaCaj & "," & _
                                                "'" & bekalan & "','A','" & nama_pegawai & "','" & namaPemanduPindahan & "','" & noKenderaanPindahan & "','" & online & "','" & jenisUrusan & "','001')"
                        transactionProcess.Add(sqlText)
                    End If
                    'InsertData(sqlText)
                End If
            Next
        Next 'End Next of eSkpi Array
    End Sub

    Public Sub InsertData(ByVal sqlText As String)

        If sqlConn.State = Data.ConnectionState.Open Then

            Dim execOperation As New System.Data.SqlClient.SqlCommand(sqlText, sqlConn)
            Try
                execOperation.ExecuteNonQuery()
            Catch ex As Exception
                ErrorSignal = True
                ErrorList.Add(ex.Message.ToString)
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
                ErrorSignal = True
                ErrorList.Add(ex.Message.ToString)
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
                ErrorSignal = True
                ErrorList.Add(ex.Message.ToString)
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
            ErrorSignal = True
            ErrorList.Add(ex.Message.ToString)
        End Try
    End Sub

    Public Sub dbConnection_Close()
        If sqlConn.State = Data.ConnectionState.Open Then
            sqlConn.Close()
        End If
    End Sub

    Public Function VerifyBarcode(ByVal strBarcode As String) As String
        Dim strUrl As String = ""
        Dim sqlText As String
        'sqlText = "select kod_jenis_urusan,pintu_masuk,entry_by,declarationStatus,tmp_barcode from verifikasi_barcode where nombor_barcode='" & strBarcode & "'"
        sqlText = "select kod_jenis_urusan,tmp_barcode from verifikasi_barcode_new where nombor_barcode='" & strBarcode & "'"
        Dim sqlRdr As System.Data.SqlClient.SqlDataReader
        sqlRdr = DataReader(sqlText)
        If sqlRdr.HasRows Then
            sqlRdr.Read()
            Dim urusan As String = sqlRdr.GetValue(0)
            'Dim entryBy As String = sqlRdr.GetValue(2)
            'Dim decStat As String = sqlRdr.GetValue(3)
            Dim tmpBCode As String = ""
            If IsDBNull(sqlRdr.GetValue(1)) = False Then
                tmpBCode = sqlRdr.GetValue(1)
            End If

            sqlRdr.Close()
            sqlRdr = Nothing
            'If urusan <> "007" Then
            Dim countA As Integer = 0
            Dim countB As Integer = 0
            If tmpBCode = "" Then
                'Dim entStat As Integer = ("select count(*) as cnt from pengisyitiharan_all where no_barcode='" & strBarcode & "'")
                Select Case urusan
                    Case "003", "0017", "018"
                        sqlText = "select count(*) as cnt from pengisytiharan_e where no_barcode='" & strBarcode & "' and status='A'"
                        countA = SingleFieldResults(sqlText)
                        sqlText = "select count(*) as cnt from pengisytiharan_e where no_barcode='" & strBarcode & "' and status='B'"
                        countB = SingleFieldResults(sqlText)
                    Case "008", "001", "002", "007", "013", "016", "004", "005", "006", "010", "011", "012", "014", "015"
                        sqlText = "select count(*) as cnt from pengisytiharan_i where no_barcode='" & strBarcode & "' and status='A'"
                        countA = SingleFieldResults(sqlText)
                        sqlText = "select count(*) as cnt from pengisytiharan_i where no_barcode='" & strBarcode & "' and status='B'"
                        countB = SingleFieldResults(sqlText)
                End Select

                If countA = 0 And countB = 0 Then

                    'New Pendaftaran Directly From BKH
                    Select Case urusan
                        Case "003", "0017", "018"
                            strUrl = "../eksport/pengisyitiharan.aspx?&barcode=" & strBarcode
                        Case "008"
                            strUrl = "../import/pengisyitiharan_pindahan.aspx?&barcode=" & strBarcode
                        Case Else '"001", "002", "007", "013", "016", "004", "005", "006", "010", "011", "012", "014", "015"
                            strUrl = "../import/pengisyitiharan.aspx?&barcode=" & strBarcode
                    End Select

                ElseIf countA > 0 And countB = 0 Then

                    'For View Only Mode                        
                    strUrl = "1"

                ElseIf countA >= 0 And countB > 0 Then

                    'Pengisyitiharan Semula
                    Select Case urusan
                        Case "003", "0017", "018"
                            strUrl = "../onlineSubmissionProcess/eksport/pengisyitiharan_semula.aspx?&barcode=" & strBarcode
                        Case "008"
                            strUrl = "../onlineSubmissionProcess/import/pengisyitiharan_pindahan_semula.aspx?&barcode=" & strBarcode
                        Case Else '"001", "002", "013", "016", "004", "005", "006", "010", "011", "012", "014", "015"
                            strUrl = "../onlineSubmissionProcess/import/pengisyitiharan_semula.aspx?&barcode=" & strBarcode
                    End Select

                End If

            ElseIf tmpBCode <> "" Then

                Select Case urusan
                    Case "003", "0017", "018"
                        sqlText = "select count(*) as cnt from pengisytiharan_e where no_barcode='" & strBarcode & "' and status='A'"
                        countA = SingleFieldResults(sqlText)
                        sqlText = "select count(*) as cnt from pengisytiharan_e where no_barcode='" & strBarcode & "' and status='B'"
                        countB = SingleFieldResults(sqlText)
                    Case "008", "001", "002", "007", "013", "016", "004", "005", "006", "010", "011", "012", "014", "015"
                        sqlText = "select count(*) as cnt from pengisytiharan_i where no_barcode='" & strBarcode & "' and status='A'"
                        countA = SingleFieldResults(sqlText)
                        sqlText = "select count(*) as cnt from pengisytiharan_i where no_barcode='" & strBarcode & "' and status='B'"
                        countB = SingleFieldResults(sqlText)
                End Select

                If countA = 0 And countB = 0 Then

                    Select Case urusan
                        Case "003", "0017", "018"
                            strUrl = "../onlineSubmissionProcess/eksport/pengisyitiharan.aspx?&barcode=" & tmpBCode
                        Case "008"
                            strUrl = "../onlineSubmissionProcess/import/pengisyitiharan_pindahan.aspx?&barcode=" & tmpBCode
                        Case Else '"001", "002", "013", "016", "004", "005", "006", "010", "011", "012", "014", "015"
                            strUrl = "../onlineSubmissionProcess/import/pengisyitiharan.aspx?&barcode=" & tmpBCode
                    End Select

                ElseIf countA > 0 And countB = 0 Then

                    'For View Only Mode                        
                    strUrl = "1"

                ElseIf countA >= 0 And countB > 0 Then

                    'Pengisyitiharan Semula
                    Select Case urusan
                        Case "003", "0017", "018"
                            strUrl = "../onlineSubmissionProcess/eksport/pengisyitiharan_semula.aspx?&barcode=" & strBarcode
                        Case "008"
                            strUrl = "../onlineSubmissionProcess/import/pengisyitiharan_pindahan_semula.aspx?&barcode=" & strBarcode
                        Case Else '"001", "002", "013", "016", "004", "005", "006", "010", "011", "012", "014", "015"
                            strUrl = "../onlineSubmissionProcess/import/pengisyitiharan_semula.aspx?&barcode=" & strBarcode
                    End Select

                End If

            End If
            'Else
            '    strUrl = "2"
            'End If
        Else
            sqlRdr.Close()
            sqlRdr = Nothing
            strUrl = "0"
        End If



        Return strUrl

    End Function

    Public Function VerifyBarcode_KIBFG(ByVal strBarcode As String) As String
        Dim strUrl As String = ""
        Dim sqlText As String
        'sqlText = "select kod_jenis_urusan,pintu_masuk,entry_by,declarationStatus,tmp_barcode from verifikasi_barcode where nombor_barcode='" & strBarcode & "'"
        sqlText = "select kod_jenis_urusan,tmp_barcode from verifikasi_barcode_new where nombor_barcode='" & strBarcode & "'"
        Dim sqlRdr As System.Data.SqlClient.SqlDataReader
        sqlRdr = DataReader(sqlText)
        If sqlRdr.HasRows Then
            sqlRdr.Read()
            Dim urusan As String = sqlRdr.GetValue(0)
            'Dim entryBy As String = sqlRdr.GetValue(2)
            'Dim decStat As String = sqlRdr.GetValue(3)
            Dim tmpBCode As String = ""
            If IsDBNull(sqlRdr.GetValue(1)) = False Then
                tmpBCode = sqlRdr.GetValue(1)
            End If

            sqlRdr.Close()
            sqlRdr = Nothing
            'If urusan <> "007" Then
            Dim countA As Integer = 0
            Dim countB As Integer = 0
            If tmpBCode = "" Then
                'Dim entStat As Integer = ("select count(*) as cnt from pengisyitiharan_all where no_barcode='" & strBarcode & "'")
                Select Case urusan
                    Case "003", "0017", "018"
                        sqlText = "select count(*) as cnt from pengisytiharan_e where no_barcode='" & strBarcode & "' and status='A'"
                        countA = SingleFieldResults(sqlText)
                        sqlText = "select count(*) as cnt from pengisytiharan_e where no_barcode='" & strBarcode & "' and status='B'"
                        countB = SingleFieldResults(sqlText)
                    Case "008", "001", "002", "007", "013", "016", "004", "005", "006", "010", "011", "012", "014", "015"
                        sqlText = "select count(*) as cnt from pengisytiharan_i_KIBFG where no_barcode='" & strBarcode & "' and status='A'"
                        countA = SingleFieldResults(sqlText)
                        sqlText = "select count(*) as cnt from pengisytiharan_i_KIBFG where no_barcode='" & strBarcode & "' and status='B'"
                        countB = SingleFieldResults(sqlText)
                End Select

                If countA = 0 And countB = 0 Then

                    'New Pendaftaran Directly From BKH
                    Select Case urusan
                        Case "003", "0017", "018"
                            strUrl = "../eksport/pengisyitiharan.aspx?&barcode=" & strBarcode
                        Case "008"
                            strUrl = "../import/pengisyitiharan_pindahan.aspx?&barcode=" & strBarcode
                        Case Else '"001", "002", "007", "013", "016", "004", "005", "006", "010", "011", "012", "014", "015"
                            strUrl = "../import/pengisyitiharan_baru.aspx?&barcode=" & strBarcode
                    End Select

                ElseIf countA > 0 And countB = 0 Then

                    'For View Only Mode                        
                    strUrl = "1"

                ElseIf countA >= 0 And countB > 0 Then

                    'Pengisyitiharan Semula
                    Select Case urusan
                        Case "003", "0017", "018"
                            strUrl = "../onlineSubmissionProcess/eksport/pengisyitiharan_semula.aspx?&barcode=" & strBarcode
                        Case "008"
                            strUrl = "../onlineSubmissionProcess/import/pengisyitiharan_pindahan_semula.aspx?&barcode=" & strBarcode
                        Case Else '"001", "002", "013", "016", "004", "005", "006", "010", "011", "012", "014", "015"
                            strUrl = "../onlineSubmissionProcess/import/pengisyitiharan_semula.aspx?&barcode=" & strBarcode
                    End Select

                End If

            ElseIf tmpBCode <> "" Then

                Select Case urusan
                    Case "003", "0017", "018"
                        sqlText = "select count(*) as cnt from pengisytiharan_e where no_barcode='" & strBarcode & "' and status='A'"
                        countA = SingleFieldResults(sqlText)
                        sqlText = "select count(*) as cnt from pengisytiharan_e where no_barcode='" & strBarcode & "' and status='B'"
                        countB = SingleFieldResults(sqlText)
                    Case "008", "001", "002", "007", "013", "016", "004", "005", "006", "010", "011", "012", "014", "015"
                        sqlText = "select count(*) as cnt from pengisytiharan_i_kibfg where no_barcode='" & strBarcode & "' and status='A'"
                        countA = SingleFieldResults(sqlText)
                        sqlText = "select count(*) as cnt from pengisytiharan_i_kibfg where no_barcode='" & strBarcode & "' and status='B'"
                        countB = SingleFieldResults(sqlText)
                End Select

                If countA = 0 And countB = 0 Then

                    Select Case urusan
                        Case "003", "0017", "018"
                            strUrl = "../onlineSubmissionProcess/eksport/pengisyitiharan.aspx?&barcode=" & tmpBCode
                        Case "008"
                            strUrl = "../onlineSubmissionProcess/import/pengisyitiharan_pindahan.aspx?&barcode=" & tmpBCode
                        Case Else '"001", "002", "013", "016", "004", "005", "006", "010", "011", "012", "014", "015"
                            strUrl = "../onlineSubmissionProcess/import/pengisyitiharan_baru.aspx?&barcode=" & tmpBCode
                    End Select

                ElseIf countA > 0 And countB = 0 Then

                    'For View Only Mode                        
                    strUrl = "1"

                ElseIf countA >= 0 And countB > 0 Then

                    'Pengisyitiharan Semula
                    Select Case urusan
                        Case "003", "0017", "018"
                            strUrl = "../onlineSubmissionProcess/eksport/pengisyitiharan_semula.aspx?&barcode=" & strBarcode
                        Case "008"
                            strUrl = "../onlineSubmissionProcess/import/pengisyitiharan_pindahan_semula.aspx?&barcode=" & strBarcode
                        Case Else '"001", "002", "013", "016", "004", "005", "006", "010", "011", "012", "014", "015"
                            strUrl = "../onlineSubmissionProcess/import/pengisyitiharan_semula.aspx?&barcode=" & strBarcode
                    End Select

                End If

            End If
            'Else
            '    strUrl = "2"
            'End If
        Else
            sqlRdr.Close()
            sqlRdr = Nothing
            strUrl = "0"
        End If



        Return strUrl

    End Function
    Public Function VerifyBarcodeP(ByVal strBarcode As String)
        Dim sqlText As String
        sqlText = "select kod_jenis_urusan from pendaftaran_pintu where nombor_barcode='" & strBarcode & "'"
        Dim urusan As String = SingleFieldResults(sqlText)
        Dim strUrl As String = ""

        '  Select Case urusan
        '     Case "001"
        strUrl = "../pemeriksaan/pemeriksaan.aspx?&barcode=" & strBarcode
        '    Case Else
        'strUrl = "../import/pengisyitiharan.aspx?ZA&barcode=" & strBarcode
        'End Select

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

    Public Sub UpdateFrontEndStatus(ByVal no_rujukan As String, ByVal no_barcode As String, ByVal statusFront As String)
        Dim sqlText As String = "INSERT INTO IsyProgressStatus_Front([no_rujukan],[no_barcode], [proses], [dateEnter], [entry_by])" & _
                                "VALUES('" & no_rujukan & "','" & no_barcode & "','" & statusFront & "',getdate(),'" & Session("username") & "')"
        InsertData(sqlText)
    End Sub

    Public Sub ConfigureCrystalReportsSKPIPrint(ByVal file As String, ByVal strFormula As String)

        'DropDownList1.DataSource = System.Drawing.Printing.PrinterSettings.InstalledPrinters
        'DropDownList1.DataBind()

        Dim myConnectionInfo As ConnectionInfo = New ConnectionInfo()
        myConnectionInfo.DatabaseName = System.Configuration.ConfigurationManager.AppSettings("dbname")
        myConnectionInfo.UserID = System.Configuration.ConfigurationManager.AppSettings("userid")
        myConnectionInfo.Password = System.Configuration.ConfigurationManager.AppSettings("dbpassword")
        myConnectionInfo.ServerName = System.Configuration.ConfigurationManager.AppSettings("servername")

        crSKPI = New ReportDocument()

        Dim reportPath As String = Server.MapPath(file)

        crSKPI.Load(reportPath)



        Dim selectFormula As String = strFormula '"{PENGISYTIHARAN_I.No_Barcode} = '" & Request("barcode") & "' AND {PENGISYTIHARAN_I.Status} = 'A'"
        crSKPI.DataDefinition.RecordSelectionFormula = selectFormula
        SetDBLogonForReport(myConnectionInfo, crSKPI)


        'Dim margins As PageMargins = crSKPI.PrintOptions.PageMargins
        'margins.bottomMargin = 0.21
        'margins.leftMargin = 0.15
        'margins.rightMargin = 0.2
        'margins.topMargin = 0.25

        'crSKPI.PrintOptions.ApplyPageMargins(margins)
        'crSKPI.PrintOptions.    
        'crSKPI.PrintOptions.PaperOrientation = PaperOrientation.Portrait
        'crSKPI.PrintOptions.PaperSize = PaperSize.PaperLetter
        'crSKPI.PrintOptions.PaperSource = PaperSource.Auto   


    End Sub

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

    Public Sub ConfigureCrystalReports_MSheet(ByVal file As String, ByVal strFormula As String, ByVal formulafields1 As String, ByVal formulafields2 As String, ByVal NoKenderaan As String, ByVal NoAgenPengangkutan As String, ByVal TarikhMasaMasuk As String, ByVal CajMasuk As String, ByVal Urusan As String, ByVal Barangan As String, ByVal PetiBesarCajBiasaKg As Double, ByVal PetiKecilCajBiasaKg As Double, ByVal KuantitiKg As Double, ByVal Ekor As Double, ByVal KdrPetiBesarCajBiasa As Double, ByVal KdrPetiKecilCajBiasa As Double, ByVal KdrKuantitiCajBiasa As Double, ByVal KdrEkorCajBiasa As Double, ByVal Kurang_caj As Integer, ByVal NamaPegawai As String)

        crMasterSheetImport = New ReportDocument()

        'If crMasterSheetImport = Nothing Then
        '    crMasterSheetImport = New ReportDocument()
        'Else
        '    crMasterSheetImport.Close()
        'End If


        Dim reportPath As String = Server.MapPath(file)

        crMasterSheetImport.Load(reportPath)

        Dim myConnectionInfo As ConnectionInfo = New ConnectionInfo()
        myConnectionInfo.DatabaseName = System.Configuration.ConfigurationManager.AppSettings("dbname")
        myConnectionInfo.UserID = System.Configuration.ConfigurationManager.AppSettings("userid")
        myConnectionInfo.Password = System.Configuration.ConfigurationManager.AppSettings("dbpassword")
        myConnectionInfo.ServerName = System.Configuration.ConfigurationManager.AppSettings("servername")

        Dim Kira_peti_besar As String = PetiBesarCajBiasaKg.ToString() + " Peti Besar x $" + KdrPetiBesarCajBiasa.ToString()
        Dim Total_peti_besar As Double = PetiBesarCajBiasaKg * KdrPetiBesarCajBiasa

        Dim Kira_peti_kecil As String = PetiKecilCajBiasaKg.ToString() + " Peti Kecil x $" + KdrPetiKecilCajBiasa.ToString()
        Dim Total_peti_kecil As Double = PetiKecilCajBiasaKg * KdrPetiKecilCajBiasa

        Dim Kira_berat As String = KuantitiKg.ToString() + " Berat (Kg) x $" + KdrKuantitiCajBiasa.ToString()
        Dim Total_berat As Double = KuantitiKg * KdrKuantitiCajBiasa

        Dim Kira_ekor As String = Ekor.ToString() + " Ekor x $" + KdrEkorCajBiasa.ToString()
        Dim Total_ekor As Double = Ekor * KdrEkorCajBiasa



        'crMasterSheetImport.PrintToPrinter(1, False, 0, 0)
        '
        'myCrystalReportViewer.SelectionFormula = "{PENGISYTIHARAN_I.No_Barcode} = '1070222170213001' AND {PENGISYTIHARAN_I.Status} = 'A'"

        'Dim selectFormula As String = "{PENGISYTIHARAN_I.No_Barcode} = '" & Request("barcode") & "' AND {PENGISYTIHARAN_I.Status} = 'A'"
        crMasterSheetImport.DataDefinition.FormulaFields("MS_NoInvois").Text = "'" & formulafields1 & "'"
        crMasterSheetImport.DataDefinition.FormulaFields("MS_Salinan").Text = "'" & formulafields2 & "'"
        crMasterSheetImport.DataDefinition.FormulaFields("Caj_Masuk").Text = "'" & CajMasuk & "'"
        crMasterSheetImport.DataDefinition.FormulaFields("Kira_peti_kecil").Text = "'" & Kira_peti_kecil & "'"
        crMasterSheetImport.DataDefinition.FormulaFields("Total_peti_kecil").Text = "'" & Total_peti_kecil & "'"
        crMasterSheetImport.DataDefinition.FormulaFields("Kira_peti_besar").Text = "'" & Kira_peti_besar & "'"
        crMasterSheetImport.DataDefinition.FormulaFields("Total_peti_besar").Text = "'" & Total_peti_besar & "'"
        crMasterSheetImport.DataDefinition.FormulaFields("Kira_berat").Text = "'" & Kira_berat & "'"
        crMasterSheetImport.DataDefinition.FormulaFields("Total_berat").Text = "'" & Total_berat & "'"
        crMasterSheetImport.DataDefinition.FormulaFields("Kira_ekor").Text = "'" & Kira_ekor & "'"
        crMasterSheetImport.DataDefinition.FormulaFields("Total_ekor").Text = "'" & Total_ekor & "'"
        crMasterSheetImport.DataDefinition.FormulaFields("tarikh_masa").Text = "'" & TarikhMasaMasuk & "'"
        crMasterSheetImport.DataDefinition.FormulaFields("No_Kenderaan").Text = "'" & NoKenderaan & "'"
        crMasterSheetImport.DataDefinition.FormulaFields("no_agen_pengangkutan").Text = "'" & NoAgenPengangkutan & "'"
        crMasterSheetImport.DataDefinition.FormulaFields("urusan").Text = "'" & Urusan & "'"
        crMasterSheetImport.DataDefinition.FormulaFields("barangan").Text = "'" & Barangan & "'"
        crMasterSheetImport.DataDefinition.FormulaFields("Kurang_caj").Text = "'" & Kurang_caj & "'"
        crMasterSheetImport.DataDefinition.FormulaFields("pegawai").Text = "'" & NamaPegawai & "'"


        crMasterSheetImport.DataDefinition.RecordSelectionFormula = strFormula
        SetDBLogonForReport(myConnectionInfo, crMasterSheetImport)
        SetDBLogonForSubreports(myConnectionInfo, crMasterSheetImport)

        'crMasterSheetImport.Close()


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



End Class
