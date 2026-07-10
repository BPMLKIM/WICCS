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
    Dim SQLReader As System.Data.SqlClient.SqlDataReader
    Dim SQLReader1 As System.Data.SqlClient.SqlDataReader
    Dim SQLReader2 As System.Data.SqlClient.SqlDataReader


#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        opClass = New SQLOperation()
        opClass.dbConnection()

        title.Text = "PENGURUSAN HAK AKSES PENGAWAI LKIM"

        CheckBoxList1.Attributes.Add("onclick", "javascript: if (document.all.CheckBoxList1_10.checked==true) {document.all.table_laporan.style.display='block';} else {document.all.table_laporan.style.display='none';}")
        idgroup.Attributes.Add("onclick", "javascript:self.location.href='list_akses.aspx';")

    End Sub

    Protected Sub Simpan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles simpan.Click

        opClass = New SQLOperation()
        opClass.dbConnection()

        opClass1 = New SQLOperation()
        opClass1.dbConnection()

        opClass2 = New SQLOperation()
        opClass2.dbConnection()

        Dim j As Integer
        Dim i as Integer
        Dim group_id As Integer
        Dim menu_laporan As Boolean


        If (sender.id) = "simpan" Then

            Dim sql As String = "select * from [group] where group_name ='" & group_name.Text & "'"
            SQLReader = opClass.DataReader(sql)


            If Not SQLReader.HasRows Then

                Dim sqlinsert As String = "Insert into [group] (group_name) Values ('" & group_name.Text & "')"
                opClass1.InsertData(sqlinsert)

                Dim sql1 As String = "select * from [group] where group_name ='" & group_name.Text & "'"
                SQLReader2 = opClass2.DataReader(sql1)

                SQLReader2.Read()

                If SQLReader2.HasRows Then

                    group_id = SQLReader2("group_id")

                End If

                SQLReader2.Close()
                SQLReader2 = Nothing

            Else

                SQLReader.Read()
                group_id = SQLReader("group_id")

                'Response.Write("<script languange=javascript>alert('Group Name telah wujud');self.location.href='hak_akses.aspx'</script>")
                'Response.End()

            End If

            SQLReader.Close()
            SQLReader = Nothing

            ' untuk menu utama


            Dim sqlview As String = "Delete group_setting where group_id = '" & group_id & "'"
            opClass1.InsertData(sqlview)

            Dim sqlview1 As String = "Delete group_setting_sub where group_id  = '" & group_id & "'"
            opClass1.InsertData(sqlview1)

            For j = 0 To CheckBoxList1.Items.Count - 1

                If CheckBoxList1.Items(j).Selected = True Then

                    Dim sql3 As String = "Insert into group_setting (group_id,status,module_id) " _
                    & " Values ('" & Trim((group_id)) & "','yes','" & CheckBoxList1.Items(j).Value & "')"
                    opClass1.InsertData(sql3)

                    If Trim(CheckBoxList1.Items(j).Value) <> "15" Then

                        Dim sql4 As String = "Select submodule_id from menu_sub where module_id = '" & Trim(CheckBoxList1.Items(j).Value) & "'"
                        SQLReader = opClass.DataReader(sql4)


                        If SQLReader.HasRows Then

                            While SQLReader.Read()

                                Dim sql5 As String = "Insert into group_setting_sub (group_id,status,module_id,sub_module_id) " _
                                & " Values ('" & Trim((group_id)) & "','yes','" & CheckBoxList1.Items(j).Value & "','" & Trim(SQLReader("submodule_id")) & "')"
                                opClass1.InsertData(sql5)

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

                    End If

                Next

            End If

            ' end coded

            Response.Write("<script languange=javascript>alert('Maklumat telah disimpan');self.location.href='hak_akses.aspx'</script>")
            Response.End()


        End If

    End Sub

End Class
