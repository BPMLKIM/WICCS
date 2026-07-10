Imports System.Security
Imports secureInfo
Partial Class UserManagement_LKIM_new_lkim_user
    Inherits System.Web.UI.Page

    Protected myEnc As New Encryption64
    Protected opClass As SQLOperation


    Protected Sub NewUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewUser.Click

        Dim sqlText As String

        sqlText = "select count(*) from ikan_caj where id='" & textbox1.Text & "'"
        Dim rcount As Integer = opClass.SingleFieldResults(sqlText)

        If rcount > 0 Then
            Dim popupScript As String = "<script language='javascript'>" & _
                                         "alert('Kod caj ikan Sudah Wujud!!!\nPilih kod Yang Lain.');" & _
                                         "</script>"
            Response.Write(popupScript)
        Else
            sqlText = "INSERT INTO [W-ICCS].[dbo].[ikan_caj] (ID, Kategori_Ikan , Jenis_Urusan, Kadar_Peti_Kecil, Kadar_Peti_Besar, Kadar_Ekor, Kadar_Kuantiti )" & _
            "VALUES('" & textbox1.Text & "','" & textbox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "')"
            opClass.InsertData(sqlText)

            If opClass.ErrorSignal = True Then
                Response.Write(opClass.ErrorList(0).ToString())
                Dim popupScript As String = "<script language='javascript'>" & _
                                            "alert('Sistem Error !!! Maklumat Tidak Dapat Disimpan!!!');history.back();" & _
                                            "</script>"
                Response.Write(popupScript)
            Else
                Dim popupScript As String = "<script language='javascript'>" & _
                                            "alert('Maklumat Telah Selamat Disimpan!!!');" & _
                                            "</script>"
                Response.Write(popupScript)
                NewUser.Enabled = False
            End If
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        myEnc = New Encryption64()
        opClass = New SQLOperation()
        opClass.dbConnection()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        opClass.dbConnection_Close()
    End Sub
End Class
