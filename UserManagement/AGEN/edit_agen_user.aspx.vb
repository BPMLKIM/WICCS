Imports System.Security
Imports secureInfo
Partial Class UserManagement_AGEN_edit_agen_user
    Inherits System.Web.UI.Page
#Region "Variables Declaration"
    Protected myEnc As New Encryption64
    Protected opClass As SQLOperation
    Protected hakAkses As String
    Protected display As String
    Dim kodAgen As String = ""
    Dim userStatus As String = ""
    Dim passwordHash As String = ""
    Dim penggunaSend As String = ""

#End Region

    Protected Sub NewUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewUser.Click

        Dim password As String
        Dim passwordHashSha256 As String
        Dim sqlText As String


        sqlText = "select count(*) from front_login where user_name='" & kata_pengguna.Text & "'"
        Dim rcount As Integer = opClass.SingleFieldResults(sqlText)

        If rcount < 1 Then
            Dim popupScript As String = "<script language='javascript'>" & _
                                         "alert('Kata Pengguna Tidak Wujud!!!');" & _
                                         "</script>"
            Response.Write(popupScript)
        Else
            password = Encryption64.Generate(8, 10)
            passwordHashSha256 = Encryption64.ComputeHash(password, "SHA256", Nothing)


            sqlText = "UPDATE [front_login] set " & _
                      "[kod_agen_pengangkutan]='" & Agen.SelectedValue & "'," & _
                      "[name]='" & nama.Text & "'," & _
                      "[designation]='" & jawatan.Text & "'," & _
                      "[email_address]='" & email.Text & "'," & _
                      "[contact_no]='" & contact_no.Text & "'," & _
                      "[user_type]='" & hak_akses.SelectedValue & "'," & _
                      "[created_by]='" & Session("username") & "'," & _
                      "[last_update]=getdate(),user_status='" & status.SelectedValue & "' " & _
                      "WHERE [user_name]='" & kata_pengguna.Text & "'"

            opClass.InsertData(sqlText)
            'Response.Write(sqlText)

            If resetPassword.Checked = True Then
                
                sqlText = "UPDATE [front_login] set user_password='" & passwordHashSha256 & "' WHERE [user_name]='" & kata_pengguna.Text & "'"
                opClass.InsertData(sqlText)

                If opClass.ErrorSignal = False Then
                    kata_laluan.Text = password
                    display = "block"
                End If

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
                ' Response.Write(opClass.ErrorList(0))
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
            penggunaSend = Request("user")
            kodAgen = Request("agentCode")

            sqlText = "SELECT     front_login.kod_agen_pengangkutan, front_login.name, front_login.designation, front_login.email_address, front_login.contact_no, " & _
                      "front_login.user_name, front_login.user_type, front_login.user_status, AGEN_PENGANGKUTAN.Nama_Agen_Pengangkutan,front_login.id " & _
                      "FROM front_login INNER JOIN " & _
                      "AGEN_PENGANGKUTAN ON front_login.kod_agen_pengangkutan = AGEN_PENGANGKUTAN.Kod_Agen_Pengangkutan " & _
                      "WHERE front_login.user_name ='" & penggunaSend & "'"

            'Response.Write("codeAgent=" & Request("agentCode"))
            Dim sqlRdr As System.Data.SqlClient.SqlDataReader
            sqlRdr = opClass.DataReader(sqlText)
            If sqlRdr.HasRows Then
                sqlRdr.Read()
                kodAgen = sqlRdr.GetValue(0)
                nama.Text = sqlRdr.GetValue(1)
                jawatan.Text = sqlRdr.GetValue(2)
                email.Text = sqlRdr.GetValue(3)
                contact_no.Text = sqlRdr.GetValue(4)
                kata_pengguna.Text = sqlRdr.GetValue(5)
                hakAkses = sqlRdr.GetValue(6)
                userStatus = sqlRdr.GetValue(7)
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

        Dim sqlText As String = "select count(*) from front_login where user_name='" & kata_pengguna.Text & "'"
        Dim rcount As Integer = opClass.SingleFieldResults(sqlText)

        If rcount < 1 Then
            Dim popupScript As String = "<script language='javascript'>" & _
                                         "alert('Maklumat Pengguna Tidak Wujud!!!');" & _
                                         "</script>"
            Response.Write(popupScript)

        Else
            sqlText = "update front_login set deleted='Y' where user_name='" & kata_pengguna.Text & "'"
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

    Protected Sub Agen_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Agen.PreRender
        If kodAgen <> "" Then
            'Response.Write("test" & kodAgen)
            Agen.ClearSelection()
            Agen.Items.FindByValue(kodAgen).Selected = True
        End If
    End Sub

    Protected Sub status_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles status.PreRender
        If userStatus <> "" Then
            'Response.Write(userStatus)
            status.ClearSelection()
            status.Items.FindByValue(userStatus).Selected = True
        End If
    End Sub
End Class
