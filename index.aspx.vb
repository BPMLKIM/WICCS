Imports secureInfo
Partial Class index
    Inherits System.Web.UI.Page
    Protected opClass As SQLOperation
    Protected myEnc As New Encryption64

    Protected Sub Button_masuk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button_masuk.Click
        Dim idPegawai As String = ""
        Dim nama_pegawai As String = ""
        Dim gelaran As String = ""
        Dim jawatan As String = ""
        Dim hakAkses As String = ""
        Dim kataPengguna As String = ""
        Dim firstTime As String = "T"
        Dim passwordHash As String = ""
        Dim penggunaSend As String = LoginId.Text
        Dim passwordSend As String = Password.Text

        Dim sqlText As String = "SELECT [id],[id_pegawai],[nama],[gelaran],[jawatan]," & _
                                "[kebenaran_akses],[kata_pengguna],[first_time_login],[kata_laluan]" & _
                                "FROM [PEGAWAI] " & _
                                "WHERE kata_pengguna ='" & penggunaSend & "' and deleted='N'"

        Dim sqlRdr As System.Data.SqlClient.SqlDataReader
        sqlRdr = opClass.DataReader(sqlText)
        If sqlRdr.HasRows Then
            sqlRdr.Read()
            idPegawai = sqlRdr.GetValue(1)
            nama_pegawai = sqlRdr.GetValue(2)
            gelaran = sqlRdr.GetValue(3)
            jawatan = sqlRdr.GetValue(4)
            hakAkses = sqlRdr.GetValue(5)
            kataPengguna = sqlRdr.GetValue(6)
            firstTime = sqlRdr.GetValue(7)
            passwordHash = sqlRdr.GetValue(8)
            sqlRdr.Close()
            sqlRdr = Nothing

            'Verifying Password
            Dim passwordStat As Boolean

            passwordStat = Encryption64.VerifyHash(passwordSend, "SHA256", passwordHash)

            If passwordStat Then

                Session("username") = kataPengguna
                Session("id_pegawai") = idPegawai
                Session("namaPegawai") = nama_pegawai
                Session("akses") = hakAkses
                Session("nickName") = gelaran
                Session("jobtitle") = jawatan

                If firstTime = "T" Then
                    Response.Redirect("firsttime_login.aspx")
                Else
                    Server.Transfer("mainpage.aspx")
                    Server.Transfer("mainpage.aspx")
                End If

            Else
                'Alert Invalid UserName Or Password
                Dim popupScript As String = "<script language='javascript'>" & _
                                                         "alert('Kata Pengguna atau Kata Laluan Tidak Sah!!!');" & _
                                                         "</script>"
                Response.Write(popupScript)
            End If

        Else
            sqlRdr.Close()
            sqlRdr = Nothing
            Dim popupScript As String = "<script language='javascript'>" & _
                                                      "alert('Kata Pengguna atau Kata Laluan Tidak Sah atau Pengguna Tidak Wujud!!!');" & _
                                                      "</script>"
            Response.Write(popupScript)
        End If
        

        
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        opClass = New SQLOperation()
        opClass.dbConnection()

    End Sub
End Class
