
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SQLClient
Imports System.Web
Imports System.Web.Mail
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Text
Imports System.DBNull
Imports secureInfo
Imports Microsoft.VisualBasic
Imports System.Web.Caching





Public Class firsttime_login

  Inherits Page


    Protected opClass As SQLOperation
	Public loginid As TextBox
	Public oldpassword As TextBox
	Public newpassword As TextBox
	Public confirmpassword As TextBox
	Public submit As Button
	Public returns as button
	Public colorBar as string
	Public url as string
	Dim myEnc as new Encryption64

  	Public Sub Page_Load(Src As Object, E As EventArgs)

       
		
        Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5))

        opClass = New SQLOperation()
        opClass.dbConnection()

        If Session("username") Is Nothing Then
            Session.Clear()
            Dim popupScript As String = "<script language='javascript'>" & _
                                                         "alert('Kata Pengguna atau Kata Laluan Tidak Sah!!!');" & _
                                                         "</script>"
            Response.Write(popupScript)
        End If

        loginid.Text = Session("username")

	End Sub

  	Public Sub submit_Click(Src As Object, E As EventArgs)

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

                Dim sqlText As String = "SELECT [kata_pengguna],[kata_laluan]" & _
                                        "FROM [PEGAWAI] " & _
                                        "WHERE kata_pengguna ='" & penggunaSend & "'"

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
                        sqlText = "Update Pegawai set [first_time_login]='F',kata_laluan='" & pwdHash & "' where kata_pengguna='" & penggunaSend & "'"
                        opClass.InsertData(sqlText)
                        If opClass.ErrorSignal Then
                            Dim popupScript As String = "<script language='javascript'>" & _
                                                              "alert('Sistem Error!!!Kata Laluan Tidak Dapat Dikemasikinikan.');" & _
                                                              "</script>"
                            Response.Write(popupScript)
                        Else

                            Dim popupScript As String = "<script language='javascript'>" & _
                                                              "alert('Kata Laluan anda telah berjaya dikemaskini.');location.href='mainpage.aspx';" & _
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

	Public Sub return_Click(Src As Object, E As EventArgs)
        Response.Redirect("index.aspx", True)
 	End Sub

	

    Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        opClass.dbConnection_Close()
    End Sub
End Class





