
Partial Class pemeriksaan_pemeriksaan_caj
    Inherits System.Web.UI.Page
#Region "Variables Declaration"
    Protected opClass As SQLOperation
    Protected opClass1 As SQLOperation
    Protected opClass2 As SQLOperation
    Dim SQLReader As System.Data.SqlClient.SqlDataReader
    Dim SQLReader1 As System.Data.SqlClient.SqlDataReader
    Dim tablep As String = ""
    Public filetransfer As String = ""
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        opClass = New SQLOperation()
        opClass.dbConnection()

        strBarcode.Text = Trim(Request("strBarcode"))
        txtRujukan.Text = Trim(Request("strBarcode"))
        If Trim(Request("urusan")) = "I" Then
            title.Text = "PENGISYTIHARAN CAJ LAIN UNTUK IMPORT"
        Else
            title.Text = "PENGISYTIHARAN CAJ LAIN UNTUK EKSPORT"
        End If

        urusan.Value = Trim(Request("urusan"))
        no_kenderaan.Text = Trim(Request("no_kenderaan"))



        '********* Checking for Item Caj ***************************

        Dim labelnull As Integer = 0
        Dim dataVal As String = ""

        If urusan.Value = "I" Then

            tablep = "item_caj"
            filetransfer = "cetakResit1B.aspx"
        Else
            tablep = "item_caj_eksport"
            filetransfer = "cetakResit1BE.aspx"

        End If

        Dim sqlText As String = "SELECT * from " & tablep & " where No_barcode = '" & Trim(Request("strBarcode")) & "' and tempat_isytihar='PEMERIKSAAN'"
        SQLReader = opClass.DataReader(sqlText)

        If SQLReader.HasRows Then

            While SQLReader.Read()

                If labelnull = 0 Then

                    dataVal = Trim(SQLReader("Kod_Service_Caj")) & "`" & SQLReader("Nilai_Caj") & "`" & SQLReader("Cara_Pembayaran") & "`" & SQLReader("No_Cek") & "`" & SQLReader("DiCaj_Oleh") & "~"

                Else
                    dataVal = dataVal & Trim(SQLReader("Kod_Service_Caj")) & "`" & SQLReader("Nilai_Caj") & "`" & SQLReader("Cara_Pembayaran") & "`" & SQLReader("No_Cek") & "`" & SQLReader("DiCaj_Oleh") & "~"
                End If

                labelnull = labelnull + 1

            End While
            arrayVal.Value = dataVal
            cmdBayar.Enabled = False

        End If



    End Sub

    Protected Sub BAYAR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBayar.Click

        opClass = New SQLOperation()
        opClass.dbConnection()
        opClass2 = New SQLOperation()
        opClass2.dbConnection()

        If (sender.Id) = "cmdBayar" Then

            Dim strValue = arrayVal.Value
            Dim i As Integer
            Dim rowArray = strValue.Split("~")
            Dim bil_item As Integer = 1

            If urusan.Value = "I" Then

                tablep = "item_caj"
            Else
                tablep = "item_caj_eksport"

            End If


            If strValue <> "" Then

                ' to insert the data into the specific table

                For i = 0 To UBound(rowArray) - 1

                    Dim arrBayarCol() As String = rowArray(i).ToString().Split("`")

                    Dim sqlText1 = "INSERT INTO [W-ICCS].[dbo].[" & tablep & "]" _
                    & " ([No_Barcode], [Bil_Item], [Kod_Service_Caj], [Nilai_Caj],[Cara_Pembayaran],[No_Cek],[Dicaj_Oleh],[Tempat_Isytihar],[Nama_Pegawai],[No_Pegawai],site_code)" _
                    & " VALUES('" & Trim(strBarcode.Text) & "','" & bil_item & "','" & arrBayarCol(0) & "','" & CDec(arrBayarCol(1)) & "','" & arrBayarCol(2) & "','" & arrBayarCol(3) & "','" & arrBayarCol(4) & "','PEMERIKSAAN','" & Session("namaPegawai") & "','" & Session("id_pegawai") & "','" & Right(Trim(strBarcode.Text), 3) & "')"
                    opClass2.InsertData(sqlText1)


                    bil_item = bil_item + 1

                Next

                Response.Write("<script language = javascript>alert('Maklumat pembayaran untuk caj Perkhidmatan telah disimpan.');self.location.href='pemeriksaan_caj.aspx?urusan=" & urusan.Value & "&no_kenderaan=" & Trim(no_kenderaan.Text) & "&strBarcode=" & Trim(strBarcode.Text) & "';</script>")
                Response.End()

            Else

                Response.Write("<script language = javascript>alert('Tiada caj untuk perkhidmatan lain.');self.location.href='pemeriksaan_caj.aspx?no_kenderaan=" & Trim(no_kenderaan.Text) & "&strBarcode=" & Trim(strBarcode.Text) & "';</script>")
                Response.End()

            End If




        End If

        opClass.dbConnection_Close()
        opClass2.dbConnection_Close()

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        opClass.dbConnection_Close()
    End Sub

End Class
