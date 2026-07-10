Imports System.Security
Imports secureInfo
Partial Class UserManagement_LKIM_new_lkim_user
    Inherits System.Web.UI.Page

    Protected myEnc As New Encryption64
    Protected opClass As SQLOperation
    Protected kodAgen As String = ""
    Protected display As String = "none"



    Protected Sub NewUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewUser.Click

        Dim password As String
        Dim passwordHashSha256 As String
        Dim sqlText As String

        'Session("username") = "razmeer"

        sqlText = "select count(*) from front_login where user_name='" & kata_pengguna.Text & "'"
        Dim rcount As Integer = opClass.SingleFieldResults(sqlText)

        If rcount > 0 Then
            Dim popupScript As String = "<script language='javascript'>" & _
                                         "alert('Kata Pengguna Sudah Wujud!!!\nPilih Nama Kata Pengguna Yang Lain.');" & _
                                         "</script>"
            Response.Write(popupScript)
        Else
            password = Encryption64.Generate(8, 10)
            passwordHashSha256 = Encryption64.ComputeHash(password, "SHA256", Nothing)


            sqlText = "INSERT INTO [W-ICCS].[dbo].[front_login]" & _
               "([kod_agen_pengangkutan]" & _
               ",[name]" & _
               ",[designation]" & _
               ",[email_address]" & _
               ",[user_type]" & _
               ",[contact_no]" & _
               ",[user_name]" & _
               ",[user_password]" & _
               ",[user_status]" & _
               ",[created_by],[last_update])" & _
            "VALUES('" & Agen.SelectedValue & "'" & _
            ",'" & nama.Text & "'" & _
            ",'" & jawatan.Text & "'" & _
            ",'" & email.Text & "'" & _
            "," & hak_akses.SelectedValue & "," & _
            "'" & contact_no.Text & "'," & _
            "'" & kata_pengguna.Text & "'" & _
            ",'" & passwordHashSha256 & "'" & _
            ",'" & status.SelectedValue & "','" & Session("username") & "',getdate())"

            opClass.InsertData(sqlText)

            If opClass.ErrorSignal = True Then
                'Response.Write(sqlText)
                'Response.Write(opClass.ErrorList(0).ToString())
                Dim popupScript As String = "<script language='javascript'>" & _
                                            "alert('Sistem Error !!! Maklumat Tidak Dapat Disimpan!!!');" & _
                                            "</script>"
                Response.Write(popupScript)
            Else
                display = "block"
                kata_laluan.Text = password
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
        kodAgen = Request("agentCode")

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        opClass.dbConnection_Close()
    End Sub

   
    Protected Sub Agen_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Agen.PreRender

        If kodAgen <> "" Then
            '   Response.Write(kodAgen)
            Agen.ClearSelection()
            Agen.Items.FindByValue(kodAgen).Selected = True
        End If
    End Sub
End Class
