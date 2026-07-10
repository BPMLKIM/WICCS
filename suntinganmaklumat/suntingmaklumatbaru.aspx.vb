Imports System
Imports System.Data
Imports System.Data.SQLClient
Imports System.Configuration
Imports System.IO
Imports System.Text
Imports System.Diagnostics
Imports System.Diagnostics.Process

Partial Class suntingmaklumat
    Inherits System.Web.UI.Page

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged

        If Session("akses") <> "3" Then

            If (DropDownList1.SelectedIndex <> 0) Then
                If DropDownList1.SelectedItem.Value = "01" Then
                    Server.Transfer("list_users.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "02" Then
                    list5.Visible = True
                    Label15.Text = "Senarai Pilihan :"
                ElseIf DropDownList1.SelectedItem.Value = "03" Then
                    Server.Transfer("caj_perkhidmatan.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "04" Then
                    Server.Transfer("cara_pengangkutan.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "05" Then
                    Server.Transfer("destinasi.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "06" Then
                    Server.Transfer("gred.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "07" Then
                    Server.Transfer("caj.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "08" Then
                    Server.Transfer("jenisbarangan.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "09" Then
                    Server.Transfer("jenisikan.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "010" Then
                    Server.Transfer("jenispengangkutan.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "011" Then
                    Server.Transfer("jenisurusan.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "012" Then
                    Server.Transfer("kategori.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "013" Then
                    Server.Transfer("kumpulan.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "014" Then
                    Server.Transfer("lesen.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "015" Then
                    Server.Transfer("negara.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "016" Then
                    Server.Transfer("negeri.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "017" Then
                    Server.Transfer("pengeksportm.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "018" Then
                    Server.Transfer("pengimporttm.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "019" Then
                    Server.Transfer("pengeksportt.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "020" Then
                    Server.Transfer("pengimportt.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "021" Then
                    Server.Transfer("pusatkomplex.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "022.1" Then
                    Server.Transfer("s1.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "022.2" Then
                    Server.Transfer("s2.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "022.3" Then
                    Server.Transfer("s3.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "022.4" Then
                    Server.Transfer("s4.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "022.5" Then
                    Server.Transfer("s5.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "022.6" Then
                    Server.Transfer("s6.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "022.7" Then
                    Server.Transfer("s7.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "022.8" Then
                    Server.Transfer("s8.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "023" Then
                    Server.Transfer("epermit.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "024" Then
                    Server.Transfer("printername.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "025" Then
                    Server.Transfer("pintumasuk.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "026" Then
                    Server.Transfer("agen_jaminan_list_users.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "027" Then
                    Server.Transfer("daftar.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "028" Then
                    Server.Transfer("Copy of lesen.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "029" Then
                    Server.Transfer("tempoh_larangan_ikan.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "030" Then
                    Server.Transfer("jenis_ikan_larangan.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "031" Then
                    Server.Transfer("pengeksport_kecuali.aspx")
                Else

                End If
                DropDownList1.Enabled = False
                cancel.Visible = True
                'add.Visible = True

            End If

        ElseIf Session("akses") = "3" Then

            If (DropDownList1.SelectedIndex <> 0) Then
                If DropDownList1.SelectedItem.Value = "01" Then
                    Response.Write("<script>alert('Anda Tiada Hak Untuk Menyunting Maklumat Ini!');</script>")
                    Server.Transfer("suntingmaklumat.aspx")

                ElseIf DropDownList1.SelectedItem.Value = "02" Then
                    Response.Write("<script>alert('Anda Tiada Hak Untuk Menyunting Maklumat Ini!');</script>")
                    Server.Transfer("suntingmaklumat.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "03" Then
                    Response.Write("<script>alert('Anda Tiada Hak Untuk Menyunting Maklumat Ini!');</script>")
                    Server.Transfer("suntingmaklumat.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "04" Then
                    Response.Write("<script>alert('Anda Tiada Hak Untuk Menyunting Maklumat Ini!');</script>")
                    Server.Transfer("suntingmaklumat.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "05" Then
                    Response.Write("<script>alert('Anda Tiada Hak Untuk Menyunting Maklumat Ini!');</script>")
                    Server.Transfer("suntingmaklumat.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "06" Then
                    Response.Write("<script>alert('Anda Tiada Hak Untuk Menyunting Maklumat Ini!');</script>")
                    Server.Transfer("suntingmaklumat.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "07" Then
                    Response.Write("<script>alert('Anda Tiada Hak Untuk Menyunting Maklumat Ini!');</script>")
                    Server.Transfer("suntingmaklumat.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "08" Then
                    Response.Write("<script>alert('Anda Tiada Hak Untuk Menyunting Maklumat Ini!');</script>")
                    Server.Transfer("suntingmaklumat.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "09" Then
                    Response.Write("<script>alert('Anda Tiada Hak Untuk Menyunting Maklumat Ini!');</script>")
                    Server.Transfer("suntingmaklumat.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "010" Then
                    Response.Write("<script>alert('Anda Tiada Hak Untuk Menyunting Maklumat Ini!');</script>")
                    Server.Transfer("suntingmaklumat.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "011" Then
                    Response.Write("<script>alert('Anda Tiada Hak Untuk Menyunting Maklumat Ini!');</script>")
                    Server.Transfer("suntingmaklumat.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "012" Then
                    Response.Write("<script>alert('Anda Tiada Hak Untuk Menyunting Maklumat Ini!');</script>")
                    Server.Transfer("suntingmaklumat.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "013" Then
                    Response.Write("<script>alert('Anda Tiada Hak Untuk Menyunting Maklumat Ini!');</script>")
                    Server.Transfer("suntingmaklumat.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "014" Then
                    Server.Transfer("lesen.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "015" Then
                    Response.Write("<script>alert('Anda Tiada Hak Untuk Menyunting Maklumat Ini!');</script>")
                    Server.Transfer("suntingmaklumat.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "016" Then
                    Response.Write("<script>alert('Anda Tiada Hak Untuk Menyunting Maklumat Ini!');</script>")
                    Server.Transfer("suntingmaklumat.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "017" Then
                    Response.Write("<script>alert('Anda Tiada Hak Untuk Menyunting Maklumat Ini!');</script>")
                    Server.Transfer("suntingmaklumat.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "018" Then
                    Response.Write("<script>alert('Anda Tiada Hak Untuk Menyunting Maklumat Ini!');</script>")
                    Server.Transfer("suntingmaklumat.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "019" Then
                    Response.Write("<script>alert('Anda Tiada Hak Untuk Menyunting Maklumat Ini!');</script>")
                    Server.Transfer("suntingmaklumat.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "020" Then
                    Response.Write("<script>alert('Anda Tiada Hak Untuk Menyunting Maklumat Ini!');</script>")
                    Server.Transfer("suntingmaklumat.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "021" Then
                    Response.Write("<script>alert('Anda Tiada Hak Untuk Menyunting Maklumat Ini!');</script>")
                    Server.Transfer("suntingmaklumat.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "022.1" Then
                    Response.Write("<script>alert('Anda Tiada Hak Untuk Menyunting Maklumat Ini!');</script>")
                    Server.Transfer("suntingmaklumat.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "022.2" Then
                    Response.Write("<script>alert('Anda Tiada Hak Untuk Menyunting Maklumat Ini!');</script>")
                    Server.Transfer("suntingmaklumat.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "022.3" Then
                    Response.Write("<script>alert('Anda Tiada Hak Untuk Menyunting Maklumat Ini!');</script>")
                    Server.Transfer("suntingmaklumat.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "022.4" Then
                    Response.Write("<script>alert('Anda Tiada Hak Untuk Menyunting Maklumat Ini!');</script>")
                    Server.Transfer("suntingmaklumat.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "022.5" Then
                    Response.Write("<script>alert('Anda Tiada Hak Untuk Menyunting Maklumat Ini!');</script>")
                    Server.Transfer("suntingmaklumat.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "022.6" Then
                    Response.Write("<script>alert('Anda Tiada Hak Untuk Menyunting Maklumat Ini!');</script>")
                    Server.Transfer("suntingmaklumat.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "022.7" Then
                    Response.Write("<script>alert('Anda Tiada Hak Untuk Menyunting Maklumat Ini!');</script>")
                    Server.Transfer("suntingmaklumat.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "022.8" Then
                    Response.Write("<script>alert('Anda Tiada Hak Untuk Menyunting Maklumat Ini!');</script>")
                    Server.Transfer("suntingmaklumat.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "023" Then
                    Response.Write("<script>alert('Anda Tiada Hak Untuk Menyunting Maklumat Ini!');</script>")
                    Server.Transfer("suntingmaklumat.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "024" Then
                    Response.Write("<script>alert('Anda Tiada Hak Untuk Menyunting Maklumat Ini!');</script>")
                    Server.Transfer("suntingmaklumat.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "025" Then
                    Response.Write("<script>alert('Anda Tiada Hak Untuk Menyunting Maklumat Ini!');</script>")
                    Server.Transfer("suntingmaklumat.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "026" Then
                    Response.Write("<script>alert('Anda Tiada Hak Untuk Menyunting Maklumat Ini!');</script>")
                    Server.Transfer("suntingmaklumat.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "027" Then
                    Response.Write("<script>alert('Anda Tiada Hak Untuk Menyunting Maklumat Ini!');</script>")
                    Server.Transfer("suntingmaklumat.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "028" Then
                    Server.Transfer("Copy of lesen.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "029" Then
                    Response.Write("<script>alert('Anda Tiada Hak Untuk Menyunting Maklumat Ini!');</script>")
                    Server.Transfer("suntingmaklumat.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "030" Then
                    Response.Write("<script>alert('Anda Tiada Hak Untuk Menyunting Maklumat Ini!');</script>")
                    Server.Transfer("suntingmaklumat.aspx")
                ElseIf DropDownList1.SelectedItem.Value = "031" Then
                    Response.Write("<script>alert('Anda Tiada Hak Untuk Menyunting Maklumat Ini!');</script>")
                    Server.Transfer("suntingmaklumat.aspx")
                Else

                End If
                DropDownList1.Enabled = False
                cancel.Visible = True
                'add.Visible = True

            End If

        End If
    End Sub

    Protected Sub list5_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles list5.SelectedIndexChanged
        Label6.Text = DropDownList1.SelectedItem.Value
        If list4.SelectedIndex <> 0 Then
            If list5.SelectedItem.Value = "02.1" Then
                Server.Transfer("bentuk_ikan1.aspx")

            ElseIf list5.SelectedItem.Value = "02.2" Then
                Server.Transfer("bentuk_ikan2.aspx")

            ElseIf list5.SelectedItem.Value = "02.3" Then
                Server.Transfer("bentuk_ikan3.aspx")

            ElseIf list5.SelectedItem.Value = "02.4" Then
                Server.Transfer("bentuk_ikan4.aspx")

            ElseIf list5.SelectedItem.Value = "02.5" Then
                Server.Transfer("bentuk_ikan5.aspx")
            Else
            End If
        End If
    End Sub


    Protected Sub cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cancel.Click
        Server.Transfer("suntingmaklumat.aspx")
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        'Process.Start("Notepad.exe")
        'Process.Start("C:\WINDOWS\system32\dvdplay.exe")
        Process.Start("notepad.exe")
    End Sub
End Class


