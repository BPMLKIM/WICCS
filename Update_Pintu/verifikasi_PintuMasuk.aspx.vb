Imports System.Web
Partial Class Pintu_Masuk_verifikasi_PintuMasuk
    Inherits System.Web.UI.Page
#Region "Variables Declaration Area"
    Protected opClass As SQLOperation

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        opClass = New SQLOperation()
        opClass.dbConnection()

        Barcode.Focus()

        Dim SQLReader As System.Data.SqlClient.SqlDataReader

       
            If Session.Item("username") Is Nothing Then
                Dim popupScript As String = "<script language='javascript'>" & _
                                                 "alert('Sistem Error!!! Sessi Anda Telah Tamat Atau Tidak Sah!!!');" & _
                                                 "parent.location.href='../index.aspx';" & _
                                                 "</script>"
                Response.Write(popupScript)

            End If

            If Page.IsPostBack Then


                Dim rstBayar As String = "SELECT status FROM SISTEM_Q WHERE No_Barcode = '" & Trim(Barcode.Text) & "' or No_Kenderaan = '" & Trim(Barcode.Text) & "'"
                SQLReader = opClass.DataReader(rstBayar)

                SQLReader.Read()

                If SQLReader.HasRows Then

                    If Trim(SQLReader("status")) = "Pintu Keluar Utara" Or Trim(SQLReader("status")) = "Pintu Keluar Selatan" Then

                        Response.Write("<script languange=javascript>alert('Status bagi barcode tersebut adalah telah keluar dari kompleks.');history.back();</script>")
                        Response.End()

                    End If

                End If

                SQLReader.Close()
                SQLReader = Nothing

                Dim strSQL As String = " SELECT * FROM Pendaftaran_Pintu WHERE " _
                & " (Nombor_Barcode = '" & Request("Barcode") & "' or No_Kenderaan = '" & Request("Barcode") & "' and " _
                & " DAY(Tarikh_Masa_Masuk) = day(getdate())) AND (MONTH(Tarikh_Masa_Masuk) = month(getdate())) AND (YEAR(Tarikh_Masa_Masuk) = year(getdate()))"
                SQLReader = opClass.DataReader(strSQL)


                If SQLReader.HasRows Then

                    SQLReader.Read()

                    Response.Redirect("pintu_masuk.aspx?strBarcode=" & Trim(Request("Barcode")) & "")
                Else

                    Response.Write("<script languange=javascript>alert('Maklumat tidak wujud dalam system');history.back();</script>")

                End If

                SQLReader.Close()
                SQLReader = Nothing

            End If
       
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

    End Sub
End Class
