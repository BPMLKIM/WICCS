Imports System.Web
Partial Class Pintu_Masuk_verifikasi_rebat
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


            Dim checki As String = "SELECT peti_biru_kecil,peti_biru_besar FROM PENGISYTIHARAN_I where No_Barcode = '" & Trim(Barcode.Text) & "'"
            SQLReader = opClass.DataReader(checki)

            SQLReader.Read()
            If (SQLReader.HasRows = False) Then

                Response.Write("<script languange=javascript>alert('Barcode tidak wujud di dalam sistem');history.back();</script>")


            Else
                SQLReader.Close()
                SQLReader = Nothing

                Dim checkstat As String = ""
                checkstat = "select * from pengisytiharan_i where no_barcode='" & Trim(Barcode.Text) & "' and status='B'"
                SQLReader = opClass.DataReader(checkstat)
                SQLReader.Read()

                If SQLReader.HasRows Then
                    SQLReader.Close()
                    SQLReader = Nothing
                    Response.Write("<script languange=javascript>alert('Barcode ini telah membuat pemeriksaan dan terdapat SKPI yang mempunyai status tidak sah. Sila isytihar semula');history.back();</script>")
                    Response.End()
                Else
                    SQLReader.Close()
                    SQLReader = Nothing

                    Dim rstBayar1 As String = ""
                    rstBayar1 = "select no_barcode from item_caj  where no_barcode='" & Trim(Barcode.Text) & "' and kod_service_caj='Caj Perkhidmatan Ikan'"
                    SQLReader = opClass.DataReader(rstBayar1)
                    If SQLReader.HasRows Then
                        SQLReader.Close()
                        SQLReader = Nothing
                        Response.Write("<script languange=javascript>alert('Barcode ini telah membuat pembayaran');history.back();</script>")
                        Response.End()
                    Else
                        SQLReader.Close()
                        SQLReader = Nothing

                        Dim check2 As String = ""
                        check2 = "select no_barcode from pengisytiharan_i_kibfg  where no_barcode='" & Trim(Barcode.Text) & "'"
                        SQLReader = opClass.DataReader(check2)
                        If SQLReader.HasRows Then
                            SQLReader.Close()
                            SQLReader = Nothing
                            Dim strUrlshah As String
                            strUrlshah = "pengisyitiharan_semula_kibfg_view.aspx?&barcode=" & Barcode.Text
                            ' strUrlshah = "pengisyitiharan_semula_kibfg.aspx?&barcode=" & Barcode.Text
                            Response.Write("<script>location.href= '" & strUrlshah & "';</script>")
                        Else
                            SQLReader.Close()
                            SQLReader = Nothing

                            Dim strUrlshah1 As String
                            strUrlshah1 = "pengisyitiharan_semula_kibfg.aspx?&barcode=" & Barcode.Text
                            Response.Write("<script>location.href= '" & strUrlshah1 & "';</script>")
                        End If


                    End If
                End If

                'SQLReader.Close()
                'SQLReader = Nothing

                End If


                'Dim strSQL As String = " SELECT * FROM Pendaftaran_Pintu WHERE " _
                '& " (Nombor_Barcode = '" & Request("Barcode") & "' or No_Kenderaan = '" & Request("Barcode") & "' and " _
                '& " DAY(Tarikh_Masa_Masuk) = day(getdate())) AND (MONTH(Tarikh_Masa_Masuk) = month(getdate())) AND (YEAR(Tarikh_Masa_Masuk) = year(getdate()))"
                'SQLReader = opClass.DataReader(strSQL)


                'If SQLReader.HasRows Then

                '    SQLReader.Read()

                '    Response.Redirect("pintu_masuk.aspx?strBarcode=" & Trim(Request("Barcode")) & "")
                'Else

                '    Response.Write("<script languange=javascript>alert('Maklumat tidak wujud dalam system');history.back();</script>")

                'End If

                'SQLReader.Close()
                'SQLReader = Nothing

        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Response.Redirect("SalinanSKPI_MsSheet_kibfg.aspx")
    End Sub
End Class
