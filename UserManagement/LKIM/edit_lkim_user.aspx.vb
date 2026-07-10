Imports System.Security
Imports secureInfo
Partial Class UserManagement_LKIM_edit_lkim_user
    Inherits System.Web.UI.Page

    Protected myEnc As New Encryption64
    Protected opClass As SQLOperation
    Protected hakAkses As String
    Protected display As String


    Protected Sub NewUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewUser.Click

        Dim password As String
        Dim passwordHashSha256 As String
        Dim sqlText As String


        sqlText = "select count(*) from pegawai where kata_pengguna='" & kata_pengguna.Text & "'"
        Dim rcount As Integer = opClass.SingleFieldResults(sqlText)

        If rcount < 1 Then
            Dim popupScript As String = "<script language='javascript'>" & _
                                         "alert('Kata Pengguna Tidak Wujud!!!');" & _
                                         "</script>"
            Response.Write(popupScript)
        Else
            password = Encryption64.Generate(8, 10)
            passwordHashSha256 = Encryption64.ComputeHash(password, "SHA256", Nothing)


            sqlText = "UPDATE [PEGAWAI] set " & _
                      "[id_pegawai]='" & id_pegawai.Text & "'," & _
                      "[nama]='" & nama_pegawai.Text & "'," & _
                      "[jawatan]='" & jawatan.Text & "'," & _
                      "[kebenaran_akses]='" & hak_akses.SelectedValue & "'," & _
                      "[date_updated]=getdate() " & _
                      "WHERE [kata_pengguna]='" & kata_pengguna.Text & "'"

            opClass.InsertData(sqlText)

            If resetPassword.Checked = True Then
                kata_laluan.Text = password
                sqlText = "UPDATE [PEGAWAI] set kata_laluan='" & passwordHashSha256 & "' WHERE [kata_pengguna]='" & kata_pengguna.Text & "'"
                opClass.InsertData(sqlText)
                display = "block"
                'Dim popupScript As String = "<script language='javascript'>" & _
                '                        "document.all.kataLaluan.style.display='block';" & _
                '                        "</script>"
                'Response.Write(popupScript)
            End If

            If opClass.ErrorSignal = False Then
                Dim popupScript As String = "<script language='javascript'>" & _
                                        "alert('Maklumat Telah Selamat Dikemaskini!!!');" & _
                                        "</script>"
                Response.Write(popupScript)
                NewUser.Enabled = False
            Else
                Dim popupScript As String = "<script language='javascript'>" & _
                                         "alert('Sistem Error !!! Maklumat Tidak Dapat Dikemaskini!!!');" & _
                                         "</script>"
                Response.Write(popupScript)
            End If


        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sqlText As String
        myEnc = New Encryption64()
        opClass = New SQLOperation()
        opClass.dbConnection()
        display = "none"

        If Not Page.IsPostBack Then

            sqlText = "SELECT id_pegawai, nama, gelaran, jawatan, kebenaran_akses, kata_pengguna, kata_laluan, date_created, date_updated" & _
                      " FROM PEGAWAI WHERE kata_pengguna='" & Request("user") & "'"
            Dim sqlRdr As System.Data.SqlClient.SqlDataReader
            sqlRdr = opClass.DataReader(sqlText)
            If sqlRdr.HasRows Then
                sqlRdr.Read()
                id_pegawai.Text = sqlRdr.GetValue(0)
                nama_pegawai.Text = sqlRdr.GetValue(1)
                gelaran.Text = sqlRdr.GetValue(2)
                jawatan.Text = sqlRdr.GetValue(3)
                hakAkses = sqlRdr.GetValue(4)
                kata_pengguna.Text = sqlRdr.GetValue(5)
                sqlRdr.Close()
                sqlRdr = Nothing
            Else
                Dim popupScript As String = "<script language='javascript'>" & _
                                               "alert('Pengguna Tidak Wujud!!!');history.back();" & _
                                               "</script>"
                Response.Write(popupScript)
            End If
        End If
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        opClass.dbConnection_Close()
    End Sub

    Protected Sub hak_akses_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles hak_akses.PreRender
        If hakAkses <> "" Then
            hak_akses.ClearSelection()
            hak_akses.Items.FindByValue(hakAkses).Selected = True
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim sqlText As String = "select count(*) from pegawai where kata_pengguna='" & kata_pengguna.Text & "'"
        Dim rcount As Integer = opClass.SingleFieldResults(sqlText)

        If rcount < 1 Then
            Dim popupScript As String = "<script language='javascript'>" & _
                                         "alert('Maklumat Pengguna Tidak Wujud!!!');" & _
                                         "</script>"
            Response.Write(popupScript)

        Else
            sqlText = "update pegawai set deleted='Y' where kata_pengguna='" & kata_pengguna.Text & "'"
            opClass.InsertData(sqlText)

            If opClass.ErrorSignal = False Then
                Dim popupScript As String = "<script language='javascript'>" & _
                                        "alert('Maklumat Pengguna Telah Selamat Dihapuskan!!!');location.href='list_users.aspx';" & _
                                        "</script>"
                Response.Write(popupScript)
            Else
                Dim popupScript As String = "<script language='javascript'>" & _
                                         "alert('Sistem Error !!! Maklumat Pengguna Tidak Dapat Dihapuskan!!!');" & _
                                         "</script>"
                Response.Write(popupScript)
            End If
        End If
    End Sub
End Class
