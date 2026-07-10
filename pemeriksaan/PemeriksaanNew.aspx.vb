
Partial Class pemeriksaan_PemeriksaanNew
    Inherits System.Web.UI.Page

#Region "Variables Declaration"
    Protected opClass As SQLOperation
    Protected opClass1 As SQLOperation

    Dim SQLReader As System.Data.SqlClient.SqlDataReader
    Dim SQLReader1 As System.Data.SqlClient.SqlDataReader


#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        opClass = New SQLOperation()
        opClass.dbConnection()

        Dim strSQL As String

        urusan.Value = Trim(Request("urusan"))

        Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5))

        Try
            If Session("username").ToString() Is Nothing Then

                Session.Clear()
                Dim popupScript As String = "<script language='javascript'>" & _
                "alert('Sessi penggunaan anda telah tamat !!!');parent.location.href='../index.aspx';" & _
                "</script>"
                Response.Write(popupScript)
                Response.End()

            End If
        Catch ex As Exception
            Dim popupScript As String = "<script language='javascript'>" & _
            "alert('Sessi penggunaan anda telah tamat !!!');parent.location.href='../index.aspx';" & _
            "</script>"
            Response.Write(popupScript)
            Response.End()

        End Try


        ' javascript load here
        DropDownList1.Attributes.Add("onChange", "javascript: if (document.form1.DropDownList1.options[document.form1.DropDownList1.selectedIndex].text=='Tidak Sah') {document.all.a1.style.display='block';document.all.a2.style.display='block'} else {document.all.a1.style.display='none';document.all.a2.style.display='none';document.form1.DropDownList2.value='';document.form1.Text1.value='';}")
        Button6.Attributes.Add("OnClick", "javascript: self.location.href='verifikasi_periksa.aspx?urusan=" & Trim(Request("urusan")) & "'")
        Button4.Attributes.Add("OnClick", "javascript: self.location.href='verifikasi_periksa.aspx?urusan=" & Trim(Request("urusan")) & "'")

        ' end of javascript code

        If Not Page.IsPostBack Then


            '********* to view information from pendaftaran pintu *********

            strSQL = " SELECT Pendaftaran_Pintu.No_Kenderaan,JENIS_URUSAN.Nama_Urusan FROM " & _
                     " Pendaftaran_Pintu INNER JOIN" & _
                      " JENIS_URUSAN ON Pendaftaran_Pintu.Kod_Jenis_Urusan = JENIS_URUSAN.Kod_Urusan" & _
                      " WHERE (Pendaftaran_Pintu.Nombor_Barcode = '" & Request("strBarcode") & "')"
            SQLReader = opClass.DataReader(strSQL)

            If SQLReader.HasRows Then

                SQLReader.Read()

                noKenderaan.Text = SQLReader.GetString(0)
                Barcode.Text = Request("strBarcode")
                jenis_urusan.Text = SQLReader.GetString(1)

            End If

            SQLReader.Close()
            SQLReader = Nothing



            '****************** ended program *********************************************

            If Trim(Request("urusan")) = "I" Then

                Dim sqlText As String = "SELECT  dbo.PENGISYTIHARAN_I.No_SKPI+'`````' as data FROM dbo.PENGISYTIHARAN_I INNER JOIN " _
                & "dbo.PENGIMPORT ON dbo.PENGISYTIHARAN_I.Kod_Pengimport = dbo.PENGIMPORT.Kod_Pengimport WHERE " _
                & "PENGISYTIHARAN_I.Status='A' and dbo.PENGISYTIHARAN_I.No_Barcode = '" & Request("strBarcode") & "' order by no_skpi asc"
                SQLReader = opClass.DataReader(sqlText)

                tittle.Text = "PEMERIKSAAN IMPORT"
                Label3.Text = "No SKPI"
                Label4.Text = "No SKPI"

            ElseIf Trim(Request("urusan")) = "E" Then

                tittle.Text = "PEMERIKSAAN EKSPORT"

                Dim sqlText1 As String = "SELECT  dbo.PENGISYTIHARAN_E.No_SKPE+'`````' as data FROM dbo.PENGISYTIHARAN_E INNER JOIN " _
                & "dbo.PENGEKSPORT ON dbo.PENGISYTIHARAN_E.Kod_Pengeksport = dbo.PENGEKSPORT.Kod_Pengeksport WHERE " _
                & "PENGISYTIHARAN_E.Status='A' and dbo.PENGISYTIHARAN_E.No_Barcode = '" & Request("strBarcode") & "' order by no_skpe asc"
                SQLReader = opClass.DataReader(sqlText1)

                Label3.Text = "No SKPE"
                Label4.Text = "No SKPE"


            End If


            '********* to view information for SKPI for import *********

            Dim dataVal As String = ""
            Dim labelnull As Integer = 0

            While SQLReader.Read()

                If SQLReader.HasRows Then
                    dataVal = dataVal & SQLReader("data") & "~"
                End If

            End While

            SQLReader.Close()
            SQLReader = Nothing

            arrayVal.Value = dataVal

            '******************** ended program *************************************

        End If


    End Sub


    Protected Sub SIMPAN_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        opClass = New SQLOperation()
        opClass.dbConnection()
        opClass1 = New SQLOperation()
        opClass1.dbConnection()

        Dim strSKPI As String = ""
        Dim Alasan As String
        Dim Tindakan As String

        If (sender.Id) = "Simpan" Then

            If (opClass.ErrorSignal = False) Then

                'Inserting System Que Information
                Dim myRstQue = "SELECT * FROM SISTEM_Q WHERE No_Barcode = '" & Trim(Barcode.Text) & "'"
                SQLReader = opClass.DataReader(myRstQue)

                If Not SQLReader.HasRows Then

                    Response.Write("<script languange=javascript>alert('Sistem-Q tidak dapat mengemaskini status pemeriksaan kerana maklumat belum wujud.');self.location.href='verifikasi_periksa.aspx?urusan=" & Trim(urusan.Value) & "';</script>")
                    Response.End()

                End If

                SQLReader.Close()
                SQLReader = Nothing

            End If


            If DropDownList1.selectedValue = "0" And arrayValT.value = "" Then

                Response.Write("<script languange=javascript>alert('Sila pilih nombor barcode untuk status tidak sah.');self.location.href='pemeriksaanNew.aspx?urusan=" & Trim(urusan.Value) & "&strBarcode=" & Trim(Barcode.Text) & "';</script>")
                Response.End()

            End If




            'Generate Insert Statement For Insertion Prosess

            Dim stmttable As String
            Dim stmttable1 As String
            Dim strField As String
            Dim strTable As String
            Dim strnoSKPI As String = ""

            If tittle.Text = "PEMERIKSAAN IMPORT" Then

                stmttable = "PEMERIKSAAN_IMPORT"
                strField = "No_Skpi"
                stmttable1 = "Kod_PPI,Kod_Pengimport FROM PENGISYTIHARAN_I"
                strTable = "PENGISYTIHARAN_I"
                strnoSKPI = "Bil_SKPI"

            Else

                stmttable = "PEMERIKSAAN_EKSPORT"
                stmttable1 = "KodPPI,Kod_Pengeksport FROM PENGISYTIHARAN_E "
                strField = "No_Skpe"
                strTable = "PENGISYTIHARAN_E"
                strnoSKPI = "Bil_SKPI"

            End If

            Dim sqlbarcode As String = "SELECT " & stmttable1 & " where No_Barcode = '" & Request("strBarcode") & "'"
            SQLReader = opClass.DataReader(sqlbarcode)

            SQLReader.Read()

            Dim kod_ppi As String = SQLReader.GetString(0)
            Dim kod_import_eksport As String = SQLReader.GetString(1)

            SQLReader.Close()
            SQLReader = Nothing

            ' end coded

            ' inserting for pemeriksaan status tidak sah

            If arrayValT.Value <> "" Then

                strSKPI = arrayValT.Value

                Dim i As Integer
                Dim arrSKPIRow = strSKPI.Split("~")
                Dim arrloop As String

                If UBound(arrSKPIRow) = 0 Then
                    arrloop = 0
                Else
                    arrloop = UBound(arrSKPIRow) - 1

                End If

                For i = 0 To arrloop

                    Dim arrSKPICol() As String = arrSKPIRow(i).ToString().Split("`")

                    If arrSKPICol(1) = 1 Then
                        Alasan = "Tiada"
                        Tindakan = "Tiada"

                    Else

                        Alasan = arrSKPICol(4)
                        Tindakan = arrSKPICol(3)

                    End If


                    Dim sqlText1 = "INSERT INTO [W-ICCS].[dbo].[" & stmttable & "]" _
                    & "([No_Barcode], [No_SKPI_Batal], [Alasan_Batal], [Status],[Tindakan],[Kod_Nama_Pegawai],[Jawatan],[Kod_PPI],[site_code])" _
                    & " VALUES('" & Trim(Barcode.Text) & "','" & arrSKPICol(0) & "','" & Alasan & "','" & arrSKPICol(1) & "','" & Tindakan & "','" & Session("id_pegawai") & "','" & Session("jobtitle") & "','" & Trim(kod_ppi) & "','" & Right(Trim(Barcode.Text), 3) & "')"
                    opClass1.InsertData(sqlText1)

                    If (opClass.ErrorSignal = True) Then
                        Response.Write(opClass.ErrorList(0).ToString)
                        Response.End()
                    End If

                    ' update table pengisytiharan untuk status batal "B"

                    If DropDownList1.SelectedItem.Value = "0" Then
                        Dim isytihar = "UPDATE " & strTable & " Set status='B' WHERE " & strField & "='" & arrSKPICol(0) & "' and No_Barcode = '" & Trim(Barcode.Text) & "'"
                        opClass1.InsertData(isytihar)

                    Else

                        Dim isytihar = "UPDATE " & strTable & " Set status='A' WHERE " & strField & "='" & arrSKPICol(0) & "' and No_Barcode = '" & Trim(Barcode.Text) & "'"
                        opClass1.InsertData(isytihar)

                    End If


                    'end coded


                    ' update table nosiri untuk status batal "B"

                    If tittle.Text = "PEMERIKSAAN IMPORT" Then

                        Dim nosiri = "UPDATE nosiri_SKPI Set status='B' WHERE Kod_Pengimport='" & Trim(kod_import_eksport) & "' and No_Barcode = '" & Trim(Barcode.Text) & "'"
                        opClass1.InsertData(nosiri)

                    Else

                        Dim nosiri = "UPDATE nosiri_SKPE Set status='B' WHERE Kod_Pengeksport='" & Trim(kod_import_eksport) & "' and No_Barcode = '" & Trim(Barcode.Text) & "'"
                        opClass1.InsertData(nosiri)

                    End If

                    ' end coded

                Next


            Else

                'inserting for status sah pemeriksaan dan sah pemeriksaan 100%

                Dim strSKPSah As String = ""

                strSKPSah = arrayVal.Value

                Dim j As Integer
                Dim arrSKPIRowS = strSKPSah.Split("~")
                Dim arrloop1 As String

                If UBound(arrSKPIRowS) = 0 Then
                    arrloop1 = 0
                Else
                    arrloop1 = UBound(arrSKPIRowS) - 1

                End If

                For j = 0 To arrloop1

                    Dim arrSKPICol1() As String = arrSKPIRowS(j).ToString().Split("`")

                    Dim sqlText2 As String = "INSERT INTO [W-ICCS].[dbo].[" & stmttable & "]" _
                    & "([No_Barcode], [No_SKPI_Batal], [Alasan_Batal],[Status],[Tindakan],[Kod_Nama_Pegawai],[Jawatan],[Kod_PPI],[site_code])" _
                    & " VALUES('" & Trim(Barcode.Text) & "','" & arrSKPICol1(0) & "','Tiada','1','Tiada','" & Session("id_pegawai") & "','" & Session("jobtitle") & "','" & Trim(kod_ppi) & "','" & Right(Trim(Barcode.Text), 3) & "')"
                    opClass1.InsertData(sqlText2)

                    If (opClass.ErrorSignal = True) Then
                        Response.Write(opClass.ErrorList(0).ToString)
                        Response.End()
                    End If

                Next

            End If

            ' end coded


            ' update status at sistem Q

            If arrayValT.Value <> "" Then
                ' untuk status tidak sah
                Dim myRstQue1 = "UPDATE SISTEM_Q Set status='Periksa'," & strnoSKPI & " ='0',pegawai='" & Session("namaPegawai") & "' WHERE No_Barcode = '" & Trim(Barcode.Text) & "'"
                opClass1.InsertData(myRstQue1)
            Else
                ' untuk status sah
                Dim myRstQue1 = "UPDATE SISTEM_Q Set status='Periksa',pegawai='" & Session("namaPegawai") & "' WHERE No_Barcode = '" & Trim(Barcode.Text) & "'"
                opClass1.InsertData(myRstQue1)

                Dim isytihar = "UPDATE PENGISYTIHARAN_E Set status='A' WHERE No_Barcode = '" & Trim(Barcode.Text) & "'"
                opClass1.InsertData(isytihar)
            End If

            ' end coded

            ' insert for status transaction

            Dim sqlupdate As String = "INSERT INTO IsyProgressStatus_Front([no_rujukan],[no_barcode], [proses], [dateEnter], [entryBy])" & _
            "VALUES('','" & Trim(Barcode.Text) & "','" & tittle.Text & "',getdate(),'" & Session("username") & "')"
            opClass1.InsertData(sqlupdate)

            ' end coded

            Response.Write("<script languange=javascript>alert('Maklumat Untuk Pemeriksaan Telah Selamat Disimpan.');self.location.href='verifikasi_periksa.aspx?urusan=" & Trim(urusan.Value) & "';</script>")
            Response.End()

        End If


    End Sub


    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        opClass.dbConnection_Close()
    End Sub

End Class
