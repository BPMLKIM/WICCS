Imports System
Imports System.Data
Imports System.Data.SQLClient
Imports System.Configuration
Imports System.IO
Imports System.Text
Partial Class akses
    Inherits System.Web.UI.Page
#Region "Variables Declaration"
    Protected opClass As SQLOperation
    Protected opClass1 As SQLOperation
    Protected opClass2 As SQLOperation
    Public SQLReader As System.Data.SqlClient.SqlDataReader
    Public j As Integer
    Public sqlText As String
    Public sqlText1 As String
    Dim SQLReader1 As System.Data.SqlClient.SqlDataReader
    Dim SQLReader2 As System.Data.SqlClient.SqlDataReader


#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        opClass = New SQLOperation()
        opClass.dbConnection()

        title.Text = "PENGURUSAN HAK AKSES PENGAWAI LKIM"

        group_name.Text = Trim(Request("user"))

        CheckBoxList1.Attributes.Add("onclick", "javascript: if (document.all.CheckBoxList1_11.checked==true) {document.all.table_laporan.style.display='block';} else {document.all.table_laporan.style.display='none';}")
        idgroup.Attributes.Add("onclick", "javascript:self.location.href='list_akses.aspx';")

        iduser.Value = Trim(Request("iduser"))


    End Sub

    Protected Sub Simpan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles simpan.Click

        opClass = New SQLOperation()
        opClass.dbConnection()

        opClass1 = New SQLOperation()
        opClass1.dbConnection()

        opClass2 = New SQLOperation()
        opClass2.dbConnection()

        Dim j As Integer
        Dim i As Integer
        Dim group_id As Integer
        Dim menu_laporan As Boolean

        group_id = iduser.Value



        If (sender.id) = "simpan" Then

            Dim sqlview As String = "Delete group_setting where group_id = '" & iduser.Value & "'"
            opClass1.InsertData(sqlview)

            Dim sqlview1 As String = "Delete group_setting_sub where group_id  = '" & iduser.Value & "'"
            opClass1.InsertData(sqlview1)

            For j = 0 To CheckBoxList1.Items.Count - 1

                If CheckBoxList1.Items(j).Selected = True Then


                    Dim sql3 As String = "Insert into group_setting (group_id,status,module_id) " _
                    & " Values ('" & Trim((group_id)) & "','yes','" & CheckBoxList1.Items(j).Value & "')"
                    opClass1.InsertData(sql3)
                    'Response.Write("Sql3=" & sql3 & "<br>")

                    If Trim(CheckBoxList1.Items(j).Value) <> "15" Then

                        Dim sql4 As String = "Select submodule_id from menu_sub where module_id = '" & Trim(CheckBoxList1.Items(j).Value) & "'"
                        SQLReader = opClass.DataReader(sql4)


                        If SQLReader.HasRows Then

                            While SQLReader.Read()

                                Dim sql5 As String = "Insert into group_setting_sub (group_id,status,module_id,sub_module_id) " _
                                & " Values ('" & Trim((group_id)) & "','yes','" & CheckBoxList1.Items(j).Value & "','" & Trim(SQLReader("submodule_id")) & "')"
                                opClass1.InsertData(sql5)

                                'Response.Write("Sql5=" & sql5 & "<br>")

                            End While

                        End If

                        SQLReader.Close()
                        SQLReader = Nothing

                    End If

                    If Trim(CheckBoxList1.Items(j).Value) = "15" Then
                        menu_laporan = True
                    End If

                End If

            Next


            ' end coded

            ' for menu laporan


            If menu_laporan = True Then

                For i = 0 To CheckBoxList2.Items.Count - 1

                    If CheckBoxList2.Items(i).Selected = True Then

                        Dim sql6 As String = "Insert into group_setting_sub (group_id,status,module_id,sub_module_id) " _
                        & " Values ('" & Trim((group_id)) & "','yes','15','" & CheckBoxList2.Items(i).Value & "')"
                        opClass1.InsertData(sql6)
                        'Response.Write("Sql6=" & sql6 & "<br>")

                    End If

                Next

            End If

            ' end coded

            Response.Write("<script languange=javascript>alert('Maklumat telah disimpan');self.location.href='edit_group.aspx?iduser=" & iduser.Value & "&user=" & group_name.Text & "'</script>")
            Response.End()


        End If

    End Sub

End Class
