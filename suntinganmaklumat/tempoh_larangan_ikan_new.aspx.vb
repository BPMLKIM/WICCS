Imports System.Security
Imports secureInfo
Imports system.Data.SqlTypes


Partial Class tempoh_larangan_ikan_new
    Inherits System.Web.UI.Page
    Protected myEnc As New Encryption64
    Protected opClass As SQLOperation
    Public jsReader As System.Data.SqlClient.SqlDataReader



    Protected Sub NewUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewUser.Click



        Dim sqlText As String
        If t_mula.Text = "" Then
            t_mula.Text = "01/01/1900"
        End If
        'Dim tmula1 As Date = CDate(t_mula.Text)
        Dim tmula As String = Format(CDate(t_mula.Text), "MM/dd/yyyy")

        If t_tamat.Text = "" Then
            t_tamat.Text = "01/01/1900"
        End If
        'Dim ttamat1 As Date = CDate(t_tamat.Text)
        Dim ttamat As String = Format(CDate(t_tamat.Text), "MM/dd/yyyy")

        sqlText = "select count(*) from tempoh_larangan where t_mula='" & tmula & "' and t_tamat='" & ttamat & "' and status='A'"
        Dim rcount As Integer = opClass.SingleFieldResults(sqlText)

        If rcount > 0 Then
            Dim popupScript As String = "<script language='javascript'>" & _
                                         "alert('No Pekerja Sudah Wujud!!!\nPilih No Pekerja Yang Lain.');" & _
                                         "</script>"
            Response.Write(popupScript)
        Else

           

            sqlText = "INSERT INTO [w-iccs].[dbo].[tempoh_larangan] " & _
                      "(t_mula, t_tamat,catatan,link,status) values('" & tmula & _
                      "', '" & ttamat & "','" & catatan.Text & "','" & link.Text & "','A')"


            opClass.InsertData(sqlText)

            If t_mula.Text = "01/01/1900" Then
                t_mula.Text = ""
            End If

            If t_tamat.Text = "01/01/1900" Then
                t_tamat.Text = ""
            End If


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



                'Dim sqlText1 As String
                'sqlText1 = "INSERT INTO [log_pemantauan] " & _
                '  "(user_id, nama_skrin,aktiviti, entry_date) values('" & Session("username") & _
                '  "', 'w_entry_peribadi_new.aspx','Simpan Maklumat Peribadi', getdate())"
                'opClass.InsertData(sqlText1)

            End If
        End If



    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        myEnc = New Encryption64()
        opClass = New SQLOperation()
        opClass.dbConnection()



        catatan.Attributes.Add("onKeyPress", "return keyToUpperCase(this, event);")


    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        opClass.dbConnection_Close()
    End Sub



End Class
