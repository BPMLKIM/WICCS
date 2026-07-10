Imports System.Web
Partial Class verifikasi_Keluar
    Inherits System.Web.UI.Page
#Region "Variables Declaration Area"
    Protected opClass As SQLOperation

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        opClass = New SQLOperation()
        opClass.dbConnection()
        Dim SQLReader As System.Data.SqlClient.SqlDataReader

        Barcode.Focus()

        If Session.Item("username") Is Nothing Then
            Dim popupScript As String = "<script language='javascript'>" & _
                                             "alert('Sistem Error!!! Sessi Anda Telah Tamat Atau Tidak Sah!!!');" & _
                                             "parent.location.href='../index.aspx';" & _
                                             "</script>"
            Response.Write(popupScript)
        End If

        If Page.IsPostBack Then
            Dim strSQL As String = " SELECT Sistem_Q.Status,Pendaftaran_Pintu.tarikh_masa_keluar FROM Pendaftaran_Pintu " & _
                                   "INNER JOIN Sistem_Q ON Sistem_Q.No_Barcode=Pendaftaran_Pintu.Nombor_Barcode " & _
                                   "WHERE Nombor_Barcode = '" & Request("Barcode") & "'"
            SQLReader = opClass.DataReader(strSQL)
            If SQLReader.HasRows Then
                SQLReader.Read()

                If IsDBNull(SQLReader.GetValue(1)) Then

                    If SQLReader("Status").trim() = "Bayar" Or SQLReader("Status").trim() = "Pelepasan" Or SQLReader("Status").trim() = "Pintu Masuk Utara" Or SQLReader("Status").trim() = "Pintu Masuk Selatan" Or SQLReader("Status").trim() = "Pintu Masuk Import" Or SQLReader("Status").trim() = "Pintu Masuk Eksport" Then
                        SQLReader.Close()
                        SQLReader = Nothing
                        Response.Redirect("pintu_keluar.aspx?strBarcode=" & Trim(Request("Barcode")) & "")
                    Else
                        Response.Write("<script languange=javascript>alert('Maklumat Pembayaran Tidak Wujud.\nSila Lakukan Pembayaran Terlebih Dahulu.!!!');</script>")
                        Barcode.Focus()
                        Barcode.Text = ""
                    End If

                Else

                    If SQLReader("Status").trim() = "Pintu Keluar Utara" Or SQLReader("Status").trim() = "Pintu Keluar Selatan" Or SQLReader("Status").trim() = "Pintu Keluar Import" Or SQLReader("Status").trim() = "Pintu Keluar Eksport" Then
                        SQLReader.Close()
                        SQLReader = Nothing
                        Response.Write("<script languange=javascript>alert('\nBarcode Tidak Sah!!!.\nKenderaan Sudah Pun Didaftarkan Sebagai Keluar Dari Kompleks.!!!');</script>")
                        Barcode.Focus()
                        Barcode.Text = ""
                    End If

                End If

            Else

                SQLReader.Close()
                SQLReader = Nothing
                Response.Write("<script languange=javascript>alert('Maklumat Pembayaran Tidak Wujud.\nSila Lakukan Pembayaran Terlebih Dahulu.!!!');</script>")
                Barcode.Focus()
                barcode.text = ""

            End If

        End If


    End Sub
End Class
