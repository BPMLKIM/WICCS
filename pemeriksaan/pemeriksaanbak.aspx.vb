
Partial Class Pemeriksaan_Ikan
    Inherits System.Web.UI.Page
#Region "Variables Declaration Area"
    Protected opClass As SQLOperation
    Protected strKodKenderaan As String
    Protected strJenisUrusan As String
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        opClass = New SQLOperation()
        opClass.dbConnection()

        '  Dim PlaceHolder1 As PlaceHolder
        Dim Table1 As New Table
        Dim strBarcode As String = Request.QueryString("Barcode")
        Dim j As Integer

        '        PlaceHolder1.Controls.Add(Table1)

        '********* to view information for pendaftaran pintu *********

        Dim strSQL As String = ""
        Dim SQLReader As System.Data.SqlClient.SqlDataReader

        strSQL = " SELECT Pendaftaran_Pintu.No_Kenderaan,JENIS_URUSAN.Nama_Urusan FROM " & _
                 " Pendaftaran_Pintu INNER JOIN" & _
                  " JENIS_URUSAN ON Pendaftaran_Pintu.Kod_Jenis_Urusan = JENIS_URUSAN.Kod_Urusan" & _
                  " WHERE (Pendaftaran_Pintu.Nombor_Barcode = '" & strBarcode & "')"
        SQLReader = opClass.DataReader(strSQL)
        ' Response.Write(strSQL)

        If SQLReader.HasRows Then

            SQLReader.Read()

            noKenderaan.Text = SQLReader.GetString(0)
            Barcode.Text = strBarcode
            jenis_urusan.Text = SQLReader.GetString(1)

        End If

        SQLReader.Close()
        SQLReader = Nothing

        '************* end **********************************************

        strSQL = " SELECT PENGISYTIHARAN_I.No_SKPI FROM PENGISYTIHARAN_I " & _
                 " WHERE (PENGISYTIHARAN_I.No_Barcode = '" & strBarcode & "')"

        SQLReader = opClass.DataReader(strSQL)
        

        PlaceHolder1.Controls.Add(Table1)

        j = 0

        Dim r As New TableRow()
        Dim c1 As New TableCell()
        Dim c2 As New TableCell()
        Dim c3 As New TableCell()
        Dim c4 As New TableCell()

        Dim title1 As New Label()
        title1.Text = "<b><font color=white>Bil Borang</font></b>"
        c1.Controls.Add(title1)

        Dim title2 As New Label()
        title2.Text = "<b><font color=white>Borang e-SKPI</font></b>"
        c2.Controls.Add(title2)
        c2.HorizontalAlign = HorizontalAlign.Center

        Dim title3 As New Label()
        title3.Text = "<b><font color=white>Alasan Batal</font></b>"
        c3.Controls.Add(title3)
        c3.HorizontalAlign = HorizontalAlign.Center

        Dim title4 As New Label()
        title4.Text = "<b><font color=white>Tindakan</font></b>"
        c4.Controls.Add(title4)
        c4.HorizontalAlign = HorizontalAlign.Center


        r.Cells.Add(c1)
        r.Cells.Add(c2)
        r.Cells.Add(c3)
        r.Cells.Add(c4)

        r.Attributes.Add("bgcolor", "#6600ff")
        Table1.Rows.Add(r)

        Table1.Attributes.Add("border", "1")
        Table1.Width = Unit.Pixel(700)

        While SQLReader.Read()

            j = j + 1

            Dim r1 As New TableRow()
            Dim c5 As New TableCell()
            Dim c6 As New TableCell()
            Dim c7 As New TableCell()
            Dim c8 As New TableCell()

            Dim no_id As New CheckBox()
            no_id.ID = "no_id" & j & ""





            no_id.Width = Unit.Pixel(30)

            Dim no_skpi As New Label()
            no_skpi.ID = "no_skpi" & j & ""
            no_skpi.Text = SQLReader.GetString(0)


            Dim alasan As New TextBox()
            alasan.ID = "alasan" & j & ""
            alasan.Width = Unit.Pixel(100)

            Dim tindakan As New TextBox()
            tindakan.ID = "tindakan" & j & ""
            tindakan.Width = Unit.Pixel(100)

            c5.Controls.Add(no_id)
            c6.Controls.Add(no_skpi)
            c7.Controls.Add(alasan)
            c8.Controls.Add(tindakan)

            r1.Cells.Add(c5)
            r1.Cells.Add(c6)
            r1.Cells.Add(c7)
            r1.Cells.Add(c8)

            Table1.Rows.Add(r1)

        End While


        SQLReader.Close()
        SQLReader = Nothing


    End Sub



End Class
