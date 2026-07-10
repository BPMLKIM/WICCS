Imports System
Imports System.Data
Imports System.Data.SQLClient
Imports System.Configuration
Imports System.IO
Imports System.Text
Partial Class pemeriksaan_pemeriksaan_caj
    Inherits System.Web.UI.Page
#Region "Variables Declaration"
    Protected opClass As SQLOperation
    Protected opClass1 As SQLOperation
    Protected opClass2 As SQLOperation
    Dim SQLReader As System.Data.SqlClient.SqlDataReader
    Dim SQLReader1 As System.Data.SqlClient.SqlDataReader
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        opClass = New SQLOperation()
        opClass.dbConnection()

        'strBarcode.Text = Trim(Request("strBarcode"))

        title.Text = "PENGURUSAN HAK AKSES PENGAWAI LKIM"
    

        'no_kenderaan.Text = Trim(Request("no_kenderaan"))

        '********* Checking for Item Caj ***************************

        Dim labelnull As Integer = 0
        Dim dataVal As String = ""

        Dim sqlText As String = "SELECT * from Item_Caj where No_barcode = '" & Trim(Request("strBarcode")) & "' and tempat_isytihar='PEMERIKSAAN'"
        SQLReader = opClass.DataReader(sqlText)

        If SQLReader.HasRows Then

            While SQLReader.Read()

                If labelnull = 0 Then

                    dataVal = Trim(SQLReader("Kod_Service_Caj")) & "`" & SQLReader("Nilai_Caj") & "`" & SQLReader("Cara_Pembayaran") & "`" & SQLReader("DiCaj_Oleh") & "~"

                Else
                    dataVal = dataVal & Trim(SQLReader("Kod_Service_Caj")) & "`" & SQLReader("Nilai_Caj") & "`" & SQLReader("Cara_Pembayaran") & "`" & SQLReader("DiCaj_Oleh") & "~"
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

            If strValue <> "" Then

                ' to insert the data into the specific table

                For i = 0 To UBound(rowArray) - 1

                    Dim arrBayarCol() As String = rowArray(i).ToString().Split("`")

                    'Dim sqlText1 = "INSERT INTO [W-ICCS].[dbo].[ITEM_CAJ]" _
                    '& " ([No_Barcode], [Bil_Item], [Kod_Service_Caj], [Nilai_Caj],[Cara_Pembayaran],[Dicaj_Oleh],[Tempat_Isytihar],[Nama_Pegawai],[No_Pegawai],site_code)" _
                    '& " VALUES('" & Trim(strBarcode.Text) & "','" & bil_item & "','" & arrBayarCol(0) & "','" & CDec(arrBayarCol(1)) & "','" & arrBayarCol(2) & "','" & arrBayarCol(3) & "','PEMERIKSAAN','" & Session("namaPegawai") & "','" & Session("id_pegawai") & "','" & Right(Trim(strBarcode.Text), 3) & "')"
                    'opClass2.InsertData(sqlText1)


                    bil_item = bil_item + 1

                Next

                'Response.Write("<script language = javascript>alert('Maklumat pembayaran untuk caj Perkhidmatan telah disimpan.');self.location.href='pemeriksaan_caj.aspx?no_kenderaan=" & Trim(no_kenderaan.Text) & "&strBarcode=" & Trim(strBarcode.Text) & "';</script>")
                Response.End()

            Else

                'Response.Write("<script language = javascript>alert('Tiada caj untuk perkhidmatan lain.');self.location.href='pemeriksaan_caj.aspx?no_kenderaan=" & Trim(no_kenderaan.Text) & "&strBarcode=" & Trim(strBarcode.Text) & "';</script>")
                Response.End()

            End If




        End If


    End Sub

    Protected Sub reset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles reset.Click
        Server.Transfer("hak_akses.aspx")
    End Sub
End Class
