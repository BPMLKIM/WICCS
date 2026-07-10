Imports System.Security
Imports secureInfo
Partial Class tempoh_larangan_ikan_edit
    Inherits System.Web.UI.Page
    Protected myEnc As New Encryption64
    Protected opClass As SQLOperation
    Protected hakAkses As String
    Protected display As String
    Public jsReader As System.Data.SqlClient.SqlDataReader


    Protected Sub NewUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewUser.Click


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

        
        Dim sqlText As String = "UPDATE tempoh_larangan set catatan= '" & catatan.Text & _
                      "', link='" & link.Text & "', status='A' where  t_mula='" & tmula & "' and t_tamat='" & ttamat & "' and status='A'"

        opClass.InsertData(sqlText)

        If opClass.ErrorSignal = False Then
            Dim popupScript As String = "<script language='javascript'>" & _
                                    "alert('Maklumat Telah Selamat Dikemaskini!!!');location.href='tempoh_larangan_ikan.aspx';" & _
                                    "</script>"
            Response.Write(popupScript)
            NewUser.Enabled = False

            'Dim sqlText1 As String
            'sqlText1 = "INSERT INTO [log_pemantauan] " & _
            '  "(user_id, nama_skrin,aktiviti, entry_date) values('" & Session("username") & _
            '  "', 'w_entry_peribadi_edit.aspx','Kemaskini Maklumat Peribadi', getdate())"
            'opClass.InsertData(sqlText1)

        Else
            Dim popupScript As String = "<script language='javascript'>" & _
                                     "alert('Sistem Error !!! Maklumat Tidak Dapat Dikemaskini!!!');" & _
                                     "</script>"
            Response.Write(popupScript)
        End If




    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sqlText As String
        myEnc = New Encryption64()
        opClass = New SQLOperation()
        opClass.dbConnection()
        display = "none"


        'If Session("viewas") = "V" Then
        '    NewUser.Visible = False
        '    Button1.Visible = False
        'Else
        '    NewUser.Visible = True
        '    Button1.Visible = True
        'End If
        Dim nop As String = Request.QueryString("t_mula")
        Dim idp As String = Request.QueryString("idp")

        If Not Page.IsPostBack Then


            sqlText = "SELECT t_mula, t_tamat,catatan,link,status from tempoh_larangan WHERE t_mula='" & nop & "' and t_tamat='" & idp & "'"

            Dim sqlRdr As System.Data.SqlClient.SqlDataReader
            sqlRdr = opClass.DataReader(sqlText)
            If sqlRdr.HasRows Then
                sqlRdr.Read()
                t_mula.Text = Format(sqlRdr.GetValue(0), "dd/MM/yyyy")
                t_tamat.Text = Format(sqlRdr.GetValue(1), "dd/MM/yyyy")
                catatan.Text = sqlRdr.GetValue(2).Trim & ("")
                link.Text = sqlRdr.GetValue(3).Trim & ("")
                Dim statusa As String = sqlRdr.GetValue(4).Trim & ("")

                If t_mula.Text = "01/01/1900" Then
                    t_mula.Text = ""
                End If

                If t_tamat.Text = "01/01/1900" Then
                    t_tamat.Text = ""
                End If
                If statusa = "B" Then
                    Button1.Enabled = False
                    NewUser.Enabled = False
                Else
                    Button1.Enabled = True
                    NewUser.Enabled = True
                End If


               


            End If
            sqlRdr.Close()
            sqlRdr = Nothing
        End If
        catatan.Attributes.Add("onKeyPress", "return keyToUpperCase(this, event);")
           

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        opClass.dbConnection_Close()
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        'Dim sqlText As String = "delete from psm_pekerja where no_pekerja='" & no_pekerja.Text & "'"
        'opClass.InsertData(sqlText)

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


        Dim sqlText As String = "UPDATE tempoh_larangan set status= 'B' where t_mula= '" & tmula & "' and t_tamat='" & ttamat & "' and status='A'"

        opClass.InsertData(sqlText)

        If opClass.ErrorSignal = False Then
            Dim popupScript As String = "<script language='javascript'>" & _
                                    "alert('Maklumat Telah Selamat Dihapuskan!!!');location.href='tempoh_larangan_ikan.aspx?user=';" & _
                                    "</script>"
            Response.Write(popupScript)


            
        Else
            Dim popupScript As String = "<script language='javascript'>" & _
                                     "alert('Sistem Error !!! Maklumat Tidak Dapat Dihapuskan!!!');" & _
                                     "</script>"
            Response.Write(popupScript)
        End If
    End Sub

   
End Class
