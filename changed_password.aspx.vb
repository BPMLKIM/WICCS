Imports System.Security
Imports secureInfo
Partial Class UserManagement_LKIM_new_lkim_user
    Inherits System.Web.UI.Page

    Protected myEnc As New Encryption64
    Protected opClass As SQLOperation
    Public bcolor As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        myEnc = New Encryption64()
        opClass = New SQLOperation()
        opClass.dbConnection()
        loginid.Text = Session("namaPegawai")
        loginid.ReadOnly = True


    End Sub

    Public Sub submit_Click(ByVal Src As Object, ByVal E As EventArgs) Handles submit.Click

        If Page.IsValid Then
            Dim pwd As String
            pwd = newpassword.Text

            If pwd.ToString().Length < 6 Or pwd.ToString().Length > 20 Then

                Response.Write("<script>alert('Password length must be at least 6 character');</script>")

            ElseIf (newpassword.Text = confirmpassword.Text) Then

                Dim kataPengguna As String = ""
                Dim passwordHash As String = ""
                Dim penggunaSend As String = loginid.Text
                Dim passwordSend As String = oldpassword.Text

                Dim sqlText As String = "SELECT [nama],[kata_laluan]" & _
                                        "FROM [pegawai] " & _
                                        "WHERE nama ='" & penggunaSend & "'"

                Dim sqlRdr As System.Data.SqlClient.SqlDataReader
                sqlRdr = opClass.DataReader(sqlText)
                If sqlRdr.HasRows Then
                    sqlRdr.Read()
                    kataPengguna = sqlRdr.GetValue(0)
                    passwordHash = sqlRdr.GetValue(1)
                    sqlRdr.Close()
                    sqlRdr = Nothing

                    'Verifying Password
                    Dim passwordStat As Boolean
                    passwordStat = Encryption64.VerifyHash(passwordSend, "SHA256", passwordHash)

                    If passwordStat Then

                        Dim pwdHash As String = Encryption64.ComputeHash(pwd, "SHA256", Nothing)
                        sqlText = "Update pegawai set [first_time_login]='F',kata_laluan='" & pwdHash & "' where nama='" & penggunaSend & "'"
                        'Response.Write(sqlText)
                        opClass.InsertData(sqlText)

                        If opClass.ErrorSignal Then
                            Dim popupScript As String = "<script language='javascript'>" & _
                                                              "alert('Sistem Error!!!Kata Laluan Tidak Dapat Dikemasikinikan.');" & _
                                                              "</script>"
                            Response.Write(popupScript)
                        Else

                            Dim popupScript As String = "<script language='javascript'>" & _
                                                              "alert('Kata Laluan anda telah berjaya dikemaskini.');location.href='blank.htm';" & _
                                                              "</script>"
                            Response.Write(popupScript)
                        End If
                    Else
                        Dim popupScript As String = "<script language='javascript'>" & _
                                                                             "alert('Kata Pengguna atau Kata Laluan Tidak Sah!!!');" & _
                                                                             "</script>"
                        Response.Write(popupScript)
                    End If

                Else

                    sqlRdr.Close()
                    sqlRdr = Nothing
                    Dim popupScript As String = "<script language='javascript'>" & _
                                                              "alert('Kata Pengguna atau Kata Laluan Tidak Sah!!!');" & _
                                                              "</script>"
                    Response.Write(popupScript)
                End If
            ElseIf (newpassword.Text <> confirmpassword.Text) Then

                Dim popupScript As String = "<script language='javascript'>" & _
                                                      "alert('Kata Laluan Baru & Kepastian Kata Laluan Tidak Sama!!!');" & _
                                                      "</script>"
                Response.Write(popupScript)
            End If
        End If
    End Sub

    Public Sub return_Click(ByVal Src As Object, ByVal E As EventArgs)
        Server.Transfer("index.aspx", True)
    End Sub
End Class

