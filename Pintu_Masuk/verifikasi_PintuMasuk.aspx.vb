Imports System.Web
Partial Class Pintu_Masuk_verifikasi_PintuMasuk
    Inherits System.Web.UI.Page
#Region "Variables Declaration Area"
    Protected opClass As SQLOperation

#End Region
#Region "tak pakai"
    ' Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

    'If Button1.Page.IsPostBack = True Then
    '    'Response.Write("select count(*) as cnt from pengisyitiharan_i where no_barcode='" & Barcode.Text & "'")
    '    Dim data As String = "0"
    '    data = opClass.VerifyBarcode(Barcode.Text)

    '    'Response.Write("test=" & data)

    '    If data = "2" Then
    '        Dim popupScript As String = "<script language='javascript'>" & _
    '                                                "alert('Jenis Urusan Tidak Dibenarkan!!!');" & _
    '                                                "</script>"
    '        Response.Write(popupScript)
    '    ElseIf data = "0" Then
    '        Dim popupScript As String = "<script language='javascript'>" & _
    '                                                 "alert('Nombor Barcode Tidak Sah atau Wujud!!!');" & _
    '                                                 "</script>"
    '        Response.Write(popupScript)
    '    ElseIf data = "3" Then
    '        Dim popupScript As String = "<script language='javascript'>" & _
    '                                    "alert('Sila Daftar No. Barcode Ini Terlebih Dahulu Di Pintu Masuk!!!');" & _
    '                                    "</script>"
    '        Response.Write(popupScript)

    '    ElseIf data = "1" Then
    '        Dim urusan As String = ""
    '        Dim entStat As String = ""
    '        Dim strUrl As String
    '        Dim sqlText As String = "select kod_jenis_urusan,status from pengisyitiharan_all where no_barcode='" & Barcode.Text & "'"
    '        Dim sqlRdr As System.Data.SqlClient.SqlDataReader
    '        sqlRdr = opClass.DataReader(sqlText)
    '        If sqlRdr.HasRows Then
    '            sqlRdr.Read()
    '            urusan = sqlRdr.GetValue(0)
    '            entStat = sqlRdr.GetValue(1)
    '        End If
    '        sqlRdr.Close()
    '        sqlRdr = Nothing

    '        If entStat.Trim <> "A" And entStat.Trim <> " " Then
    '            'Ready To Redirect To Edit Pengisyitiharan
    '            'strUrl = "1"
    '        ElseIf entStat.Trim = "A" Then
    '            Select Case urusan
    '                Case "003", "0017", "018"
    '                    strUrl = "../eksport/v_pengisyitiharan.aspx?&barcode=" & Barcode.Text
    '                Case "008"
    '                    strUrl = "../import/v_pengisyitiharan_pindahan.aspx?&barcode=" & Barcode.Text
    '                Case Else '"001", "002", "007", "013", "016", "004", "005", "006", "010", "011", "012", "014", "015"
    '                    strUrl = "../import/v_pengisyitiharan.aspx?&barcode=" & Barcode.Text
    '            End Select

    '            Dim str = "input_box=confirm('Pengisytiharan Bagi Nombor Barcode Berikut " & Barcode.Text & " Sudah Wujud!!! \nAdakah Anda Ingin Memaparkan Maklumat Pengisytiharan Tersebut? \nSila Tekan OK untuk YA CANCEL untuk TIDAK');"
    '            Dim str2 = "if (input_box==true) {location.href='" & strUrl & "';} else {location.href='verifikasi_PintuMasuk.aspx';} </script>"
    '            Dim popupScript As String = "<script language='javascript'>" & _
    '                                            "" & str & str2
    '            Response.Write(popupScript)
    '        End If

    '    Else
    '        'Response.Write(urusan)
    '        Response.Redirect(opClass.VerifyBarcode(Barcode.Text))
    '    End If

    'End If
    ' End Sub
#End Region


    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        opClass = New SQLOperation()
        opClass.dbConnection()
        'If Button1.Page.IsPostBack Then


        '------------------------checking pintu masuk--------------------------------------------------------
        Dim status As String = ""
        Dim nama_pegawai As String = ""
        Dim gelaran As String = ""
        Dim jawatan As String = ""
        Dim hakAkses As String = ""
        Dim kataPengguna As String = ""
        Dim firstTime As String = "T"
        Dim passwordHash As String = ""
       

        Dim sqlText1 As String = "SELECT [Kod_PPI],[pintu_masuk_keluar]" & _
                                "FROM [PUSATKOMPLEK_TITLE] "

        Dim sqlRdr1 As System.Data.SqlClient.SqlDataReader
        sqlRdr1 = opClass.DataReader(sqlText1)
        If sqlRdr1.HasRows Then
            sqlRdr1.Read()
            status = sqlRdr1.GetValue(1)

            sqlRdr1.Close()
            sqlRdr1 = Nothing

        End If


        If status = "YES" Then
            Button3.Disabled = True
            Button2.Disabled = True
        ElseIf status = "NO" Then
            Button3.Disabled = False
            Button2.Disabled = False
        End If




        '------------------------checking pintu masuk--------------------------------------------------------
        Barcode.Focus()

        If Page.IsPostBack Then

            'Response.Write("select count(*) as cnt from pengisyitiharan_i where no_barcode='" & Barcode.Text & "'")
            Dim data As String = "0"
            data = opClass.VerifyBarcode(Barcode.Text)

            'Response.Write("test=" & data)

            Select Case data
                Case "2"
                    Dim popupScript As String = "<script language='javascript'>" & _
                                            "alert('Jenis Urusan Tidak Dibenarkan!!!');" & _
                                            "</script>"
                    Response.Write(popupScript)
                Case "0"
                    'Dim popupScript As String = "<script language='javascript'>" & _
                    '                                                     "alert('Jenis Urusan Tidak Dibenarkan!!!');" & _
                    '                                                      "</script>"
                    Dim popupScript As String = "<script language='javascript'>" & _
                                                                          "alert('Barcode Tidak Sah!!!');" & _
                                                                          "</script>"
                    Response.Write(popupScript)
                    Barcode.Focus()
                    Barcode.Text = ""
                Case "1"
                    Dim urusan As String = ""
                    Dim entStat As String = ""
                    Dim strUrl As String
                    Dim sqlText As String = "select kod_jenis_urusan,status from pengisyitiharan_all where no_barcode='" & Barcode.Text & "'"
                    Dim sqlRdr As System.Data.SqlClient.SqlDataReader
                    sqlRdr = opClass.DataReader(sqlText)
                    If sqlRdr.HasRows Then
                        sqlRdr.Read()
                        urusan = sqlRdr.GetValue(0)
                        entStat = sqlRdr.GetValue(1)
                    End If
                    sqlRdr.Close()
                    sqlRdr = Nothing

                    If entStat.Trim <> "A" And entStat.Trim <> " " Then
                        'Ready To Redirect To Edit Pengisyitiharan
                        'strUrl = "1"
                    ElseIf entStat.Trim = "A" Then
                        Select Case urusan
                            Case "003", "0017", "018"
                                strUrl = "../eksport/v_pengisyitiharan.aspx?&barcode=" & Barcode.Text
                            Case "008"
                                strUrl = "../import/v_pengisyitiharan_pindahan.aspx?&barcode=" & Barcode.Text
                            Case Else '"001", "002", "007", "013", "016", "004", "005", "006", "010", "011", "012", "014", "015"
                                strUrl = "../import/v_pengisyitiharan.aspx?&barcode=" & Barcode.Text
                        End Select

                        Dim str = "input_box=confirm('Pengisytiharan Bagi Nombor Barcode Berikut " & Barcode.Text & " Sudah Wujud!!! \nAdakah Anda Ingin Memaparkan Maklumat Pengisytiharan Tersebut? \nSila Tekan OK untuk YA CANCEL untuk TIDAK');"
                        Dim str2 = "if (input_box==true) {location.href='" & strUrl & "';} else {location.href='verifikasi_PintuMasuk.aspx';} </script>"
                        Dim popupScript As String = "<script language='javascript'>" & _
                        "" & str & str2
                        Response.Write(popupScript)
                    End If

                Case Else
                    'Response.Write(urusan)

                    Response.Write("<script>location.href='" & opClass.VerifyBarcode(Barcode.Text) & "';</script>")
                    'Response.Redirect(opClass.VerifyBarcode(Barcode.Text))
            End Select


        End If



    End Sub

    'Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click


    '    Dim strUrl As String
    '    strUrl = "../pintu_masuk/pra_pintu_masuk_utara.aspx?"
    '    Response.Write("<script>location.href='" & strUrl & "';</script>")


    'End Sub

    'Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click


    '    Dim strUrl As String
    '    strUrl = "../pintu_masuk/pra_pintu_masuk_selatan.aspx?"
    '    Response.Write("<script>location.href='" & strUrl & "';</script>")
    'End Sub
End Class
