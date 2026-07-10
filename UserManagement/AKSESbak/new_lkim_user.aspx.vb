Imports System.Security
Imports secureInfo
Partial Class UserManagement_LKIM_new_lkim_user
    Inherits System.Web.UI.Page

    Protected myEnc As New Encryption64
    Protected opClass As SQLOperation


    Protected Sub NewUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewUser.Click

        Dim password As String
        Dim passwordHashSha256 As String
        Dim sqlText As String


        'sqlText = "select count(*) from pegawai where kata_pengguna='" & kata_pengguna.Text & "'"
        Dim rcount As Integer = opClass.SingleFieldResults(sqlText)

        If rcount > 0 Then
            Dim popupScript As String = "<script language='javascript'>" & _
                                         "alert('Kata Pengguna Sudah Wujud!!!\nPilih Nama Kata Pengguna Yang Lain.');" & _
                                         "</script>"
            Response.Write(popupScript)
        Else
            password = Encryption64.Generate(8, 10)
            passwordHashSha256 = Encryption64.ComputeHash(password, "SHA256", Nothing)


            'sqlText = "INSERT INTO [W-ICCS].[dbo].[PEGAWAI]" & _
            '   "([id_pegawai]" & _
            '   ",[nama]" & _
            '   ",[gelaran]" & _
            '   ",[jawatan]" & _
            '   ",[kebenaran_akses]" & _
            '   ",[kata_pengguna]" & _
            '   ",[kata_laluan]" & _
            '   ",[date_created]" & _
            '   ",[date_updated])" & _
            '"VALUES('" & id_pegawai.Text & "'" & _
            '",'" & nama_pegawai.Text & "'" & _
            '",'" & gelaran.Text & "'" & _
            '",'" & jawatan.Text & "'" & _
            '"," & hak_akses.SelectedValue & "," & _
            '"'" & kata_pengguna.Text & "'" & _
            '",'" & passwordHashSha256 & "'" & _
            '",getdate(),getdate())"

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
