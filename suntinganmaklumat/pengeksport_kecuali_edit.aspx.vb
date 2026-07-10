Imports System.Security
Imports secureInfo
Partial Class pengeksport_kecuali_edit
    Inherits System.Web.UI.Page
    Protected myEnc As New Encryption64
    Protected opClass As SQLOperation
    Protected hakAkses As String
    Protected display As String
    Public jsReader As System.Data.SqlClient.SqlDataReader


    Protected Sub NewUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewUser.Click


        'If t_mula.Text = "" Then
        '    t_mula.Text = "01/01/1900"
        'End If
        ''Dim tmula1 As Date = CDate(t_mula.Text)
        'Dim tmula As String = Format(CDate(t_mula.Text), "MM/dd/yyyy")

        'If t_tamat.Text = "" Then
        '    t_tamat.Text = "01/01/1900"
        'End If
        ''Dim ttamat1 As Date = CDate(t_tamat.Text)
        'Dim ttamat As String = Format(CDate(t_tamat.Text), "MM/dd/yyyy")


        'Dim sqlText As String = "UPDATE pengeksport_kecuali set kod_bkh= '" & searchKodIkan.Text & _
        '              "', status='yes' where  kod_ikan='" & Ikan.Text & "' and t_mula='" & tmula & "' and t_tamat='" & ttamat & "' and status='A'"

        'opClass.InsertData(sqlText)

        'If opClass.ErrorSignal = False Then
        '    Dim popupScript As String = "<script language='javascript'>" & _
        '                            "alert('Maklumat Telah Selamat Dikemaskini!!!');location.href='jenis_ikan_larangan.aspx';" & _
        '                            "</script>"
        '    Response.Write(popupScript)
        '    NewUser.Enabled = False

        '    'Dim sqlText1 As String
        '    'sqlText1 = "INSERT INTO [log_pemantauan] " & _
        '    '  "(user_id, nama_skrin,aktiviti, entry_date) values('" & Session("username") & _
        '    '  "', 'w_entry_peribadi_edit.aspx','Kemaskini Maklumat Peribadi', getdate())"
        '    'opClass.InsertData(sqlText1)

        'Else
        '    Dim popupScript As String = "<script language='javascript'>" & _
        '                             "alert('Sistem Error !!! Maklumat Tidak Dapat Dikemaskini!!!');" & _
        '                             "</script>"
        '    Response.Write(popupScript)
        'End If




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
        Dim kodeksport As String = Request.QueryString("kod_pengeksport")
        Dim kodikan As String = Request.QueryString("kod_ikan")
        Dim nop As String = Request.QueryString("t_mula")
        Dim idp As String = Request.QueryString("idp")

        If Not Page.IsPostBack Then


            sqlText = "SELECT kod_pengeksport, kod_ikan, nama_syarikat_eksport, t_mula, t_tamat,status from pengeksport_kecuali WHERE kod_pengeksport='" & kodeksport & "' and kod_ikan='" & kodikan & "' and t_mula='" & nop & "' and t_tamat='" & idp & "'"

            Dim sqlRdr As System.Data.SqlClient.SqlDataReader
            sqlRdr = opClass.DataReader(sqlText)
            If sqlRdr.HasRows Then
                sqlRdr.Read()
                searchKodPengeksport.Text = sqlRdr.GetValue(0).Trim & ("")
                Ikan.Text = sqlRdr.GetValue(1).Trim & ("")
                Pengeksport.Text = sqlRdr.GetValue(2).Trim & ("")
                t_mula.Text = Format(sqlRdr.GetValue(3), "dd/MM/yyyy")
                t_tamat.Text = Format(sqlRdr.GetValue(4), "dd/MM/yyyy")

                Dim statusa As String = sqlRdr.GetValue(5).Trim & ("")

                If t_mula.Text = "01/01/1900" Then
                    t_mula.Text = ""
                End If

                If t_tamat.Text = "01/01/1900" Then
                    t_tamat.Text = ""
                End If
                If statusa = "no" Then
                    Button1.Enabled = False
                    ' NewUser.Enabled = False
                Else
                    Button1.Enabled = True
                    'NewUser.Enabled = True
                End If

            End If

            sqlRdr.Close()
            sqlRdr = Nothing

            sqlText = "SELECT kod_bkh, nama_bkh from jenis_ikan WHERE kod_ikan='" & kodikan & "'"

            Dim sqlRdr1 As System.Data.SqlClient.SqlDataReader
            sqlRdr1 = opClass.DataReader(sqlText)
            If sqlRdr1.HasRows Then
                sqlRdr1.Read()
                searchKodIkan.Text = sqlRdr1.GetValue(0).Trim & ("")
                Ikan1.Text = sqlRdr1.GetValue(1).Trim & ("")
            End If

            sqlRdr1.Close()
            sqlRdr1 = Nothing



        End If



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


        Dim sqlText As String = "UPDATE pengeksport_kecuali set status= 'no' where kod_pengeksport='" & searchKodPengeksport.Text & "' and kod_ikan='" & Ikan.Text & "' and t_mula= '" & tmula & "' and t_tamat='" & ttamat & "' and status='yes'"

        opClass.InsertData(sqlText)

        If opClass.ErrorSignal = False Then
            Dim popupScript As String = "<script language='javascript'>" & _
                                    "alert('Maklumat Telah Selamat Dihapuskan!!!');location.href='pengeksport_kecuali.aspx?user=';" & _
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
