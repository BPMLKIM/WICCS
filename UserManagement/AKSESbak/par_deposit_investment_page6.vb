
    ' Author          : Zuraini Ariffin
    ' Date Created    : 2005
    ' File Name       : par_deposit_investment_page6.aspx



    Imports System
    Imports System.IO
    Imports System.Data
    Imports System.Data.SQLClient
    Imports System.Web
    Imports System.Web.UI
    Imports System.Web.UI.WebControls
    Imports System.Web.UI.HtmlControls
    Imports System.Configuration
    Imports System.Text
	Imports System.DBNull
	Imports System.drawing

    Public Class par_deposit_investment_page6

      Inherits Page

	    Public prodId as integer
		Public label1 as label
		Public label2 as label
		Public label3 as label
		Public label4 as label
		Public label5 as label
		Public label6 as label
		Public label7 as label
		Public label8 as label
		Public label9 as label
		Public label10 as label
		Public label11 as label
        Public textbox1 as HtmlInputHidden
		Public textrisk as textbox
        Public addBox as textbox
        Public addBox1 as textbox
		Public btn_attach as HtmlInputButton
        Public btn_view as HtmlInputButton
        Public btn_clear as HtmlInputButton
        Public btn_attach1 as HtmlInputButton
        Public btn_view1 as HtmlInputButton
        Public btn_clear1 as HtmlInputButton
		Public getresult as integer
		Public btn_save as button
		Public Button1 as button
		Public Button2 as Button
		Public Button4 as button
		Public Button6 as button
		Public Button5 as button
		Public strSQL as string
		Public PlaceHolder1 as PlaceHolder
		Public textothers as textbox
		Public bil as textbox
     	Public strConn as string=configurationSettings.AppSettings("connectionstring")
        Public conn as new SQLConnection(strConn)
		Public strConn1 as string=configurationSettings.AppSettings("connectionstring")
        Public conn1 as new SQLConnection(strConn1)
		Public strConn2 as string=configurationSettings.AppSettings("connectionstring")
        Public conn2 as new SQLConnection(strConn2)
        Public product_line as textbox
        Public prod_category,frmtype,pageid as textbox
		Public otherrisk as HTMLTABLEROW
		Public help1 as string
		Public help2 as string
		Public help3 as string
		Public Rdr2 as SQLDataReader
        Public Cmd2 as SQLCommand
		Public Rdr as SQLDataReader
        Public Cmd as SQLCommand

        Public btn_image1,btn_image2,btn_image3 as imagebutton
        Public fiid,ibi_type,formtype as string



        Public Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)


	     Response.AddHeader("Refresh",Convert.ToString((Session.Timeout * 60) +5))

	       if session("uid") is nothing then
		      session.clear()
		      response.redirect ("../../function/par_session_expired.aspx")
	       end if



	     If Not Page.IsPostBack Then

		 prodId=Context.Items("prodId")
         ViewState.Add("prodId",prodId)

		 If prodId=0 then
         prodId=request("prodId")
         ViewState.Add("prodId",prodId)
         End if


       'JAVASCRIPT

		  Button1.Attributes.Add("onClick","javascript:{document.borang.textbox1.value=frames.Box1.document.body.innerHTML;}")
		  Button2.Attributes.Add("onClick","javascript:{document.borang.textbox1.value=frames.Box1.document.body.innerHTML;}")
		  Button4.Attributes.Add("onClick","javascript:{document.borang.textbox1.value=frames.Box1.document.body.innerHTML;}")
		  Button6.Attributes.Add("onClick","javascript:{document.borang.textbox1.value=frames.Box1.document.body.innerHTML;}")
		  Button5.Attributes.Add("onClick","javascript:{document.borang.textbox1.value=frames.Box1.document.body.innerHTML;}")
  		  btn_save.Attributes.Add("onClick","javascript:{document.borang.textbox1.value=frames.Box1.document.body.innerHTML;}")
		  textrisk.Attributes.Add("onchange","javascript:checkDecimal('borang','textrisk','Risk weight assigned');document.borang.textrisk.value=centPlace(document.borang.textrisk.value);")

	   'END




	  '********************* VIEW DATA ***************************************************

		 Dim Rdr3 as SQLDataReader
         Dim Cmd3 as SQLCommand
         Dim nocomplete  as string

		strSQL="select risk_management,risk_management_additional_info,risk_weight,risk_analysis_info,ibi_master,ibi_type from par_products where ID=" & prodId
		Cmd3=New SQLCOmmand(strSQL,conn)

		conn.open()
		Rdr3=Cmd3.executeReader(system.data.CommandBehavior.CloseConnection)

		While Rdr3.Read()

		  fiid=Rdr3("ibi_master")
          ibi_type=Rdr3("ibi_type")


		  If (Rdr3("risk_management") Is DBNull.value) Then
		      nocomplete="Incomplete"
		  Else
		      If (Rdr3("risk_management").ToString().length<14) then
 		      nocomplete = "Incomplete"
 		      End If
 		  End If

 		  If nocomplete="Incomplete" then
    	   Label1.Font.Bold = True
           Label2.Font.Bold = True
           Label1.forecolor = Color.red
           Label2.forecolor = Color.Red
		  End If

		  If Not (Rdr3("risk_management_additional_info") Is DBNull.Value) Then
		 	addBox.text= Rdr3("risk_management_additional_info").ToString()
		  End if

		  If Not (Rdr3("risk_weight") Is DBNull.Value) Then
			textrisk.text= Rdr3("risk_weight").ToString()
		  End if

		  If Not (Rdr3("risk_analysis_info") Is DBNull.Value) Then
		    addBox1.text= Rdr3("risk_analysis_info").ToString()
		  End if

		End While
        conn.close()


    '*********************SQL TO DISPLAY LABEL ********************************************

		Dim i as integer
		Dim strSQL2 as string

        Dim Rdr7 as SQLDataReader
        Dim Cmd7 as SQLCommand

		strSQL="select app_biz,prodline,frmtype,product_line from par_view_prodCategory where productID=" & prodId
        Cmd7=New SQLCOmmand(strSQL,conn)
        conn.open()

        Rdr7=Cmd7.executeReader(system.data.CommandBehavior.CloseConnection)

        Rdr7.Read()
		     product_line.text=Rdr7("prodline")
             prod_category.text=Rdr7("app_biz")
		     frmtype.text=Rdr7("frmtype")
        conn.close()


        dim sqlocation,pageno as string


        sqlocation="select par_locationfile.pageno,par_locationfile.formtype from par_locationfile" _
                & " inner join par_masterlocation ON par_masterlocation.formtype = par_locationfile.formtype" _
                & " where par_masterlocation.product_category= " & prod_category.text & " and par_masterlocation.product_line=" & product_line.text & " order by pageno desc"
        Cmd2=New SQLCOmmand(sqlocation,conn)

        conn.open()

            Rdr2=Cmd2.executeReader(system.data.CommandBehavior.CloseConnection)

            Rdr2.Read()

		       If frmtype.text="Specific Approval" Then
		              pageno = Rdr2("pageno")
		          Else
		              pageno = Rdr2("pageno")-1
		       End If

		       formtype = Rdr2("formtype")

            conn.close()


		    label11.text=" [ Page "+request("pageid")+" of "+pageno+" ] "
			pageid.text = request("pageid")

        strSQL2="select label,description,helpdesc from par_label WHERE page="+pageid.text+" and formType='" + formtype + "' order by id asc"
        Cmd2=New SQlCommand(strSQL2,conn)
        conn.open()

        Rdr2=Cmd2.executeReader(system.data.CommandBehavior.CloseConnection)

          i=0
          While (Rdr2.Read())

          i = i+1

          select case (i)

            case "1"
		      label1.text= Rdr2("label")
              label2.text= Rdr2("description")
              help1 = Rdr2("helpdesc")

                'JAVASCRIPT

	               btn_attach.Attributes.Add("onclick","javascript:MM_openBrWindow('par_attachfile.uplx?prodId=" & prodId & "&fname='+document.borang.addBox.value+'&field=addBox&label="&(Rdr2("description").ToLower)&"','','status=no,scrollbars=yes,resizable=yes,width=600,height=150');return false;")
                  ' btn_view.Attributes.Add("onclick","javascript:if (document.borang.addBox.value==''){alert('No Attachment Found');return false;} else {window.open('" + application("path") + "" + Session("ibi_master") + "/'+document.borang.addBox.value,'','status=no,scrollbars=yes,resizable=yes,width=800,height=600');return false;}")
                   btn_view.attributes.add("onclick","javascript:viewImage(document.borang.addBox.value,'" +Application("path") + "" + ibi_type + fiid + "/' );return false;")
                   btn_clear.Attributes.Add("onclick","javascript:document.borang.addBox.value='';return false;")

                'END


            case "2"
            label3.text=Rdr2("label")
            label4.text= Rdr2("description")


            case "3"
            label5.text=Rdr2("label")
            label6.text= Rdr2("description")


                if Not (Rdr2("helpdesc") Is DBNull.Value) then
                    help2 = Rdr2("helpdesc")
                end if

            case "4"
            label7.text=Rdr2("label")
            label8.text= Rdr2("description")


                if Not (Rdr2("helpdesc") Is DBNull.Value) then
                    help3 = Rdr2("helpdesc")
                end if

		          'JAVASCRIPT

	               btn_attach1.Attributes.Add("onclick","javascript:MM_openBrWindow('par_attachfile.uplx?prodId=" & prodId & "&fname='+document.borang.addBox1.value+'&field=addBox1&label="&(Rdr2("description").ToLower)&"','','status=no,scrollbars=yes,resizable=yes,width=600,height=150');return false;")
                  ' btn_view1.Attributes.Add("onclick","javascript:if (document.borang.addBox1.value==''){alert('No Attachment Found');return false;} else {window.open('" + application("path") + "" + Session("ibi_master") + "/'+document.borang.addBox1.value,'','status=no,scrollbars=yes,resizable=yes,width=800,height=600');return false;}")
                   btn_view1.attributes.add("onclick","javascript:viewImage(document.borang.addBox1.value,'" +Application("path") + "" + ibi_type + fiid + "/' );return false;")
                   btn_clear1.Attributes.Add("onclick","javascript:document.borang.addBox1.value='';return false;")

                  'END


          case "5"
          label9.text=Rdr2("label")
          label10.text= Rdr2("description")

          End Select

          End While
          conn.close()


          Dim Rdr6 as SQLDataReader
          Dim Cmd6 as SQLCommand

		  strSQL="select othersvalue from par_othersInfo where id=" & prodId & " and label='11.3'"
     	  Cmd6=New SQLCOmmand(strSQL,conn2)
          conn2.open()
          Rdr6=Cmd6.executeReader(system.data.CommandBehavior.CloseConnection)
		  Rdr6.Read()

		  If Rdr6.HasRows Then
  		    otherrisk.Attributes.Add("style","DISPLAY:BLOCK")
			textothers.text = Rdr6("othersvalue")
		  else
			textothers.text = ""
          End If

		  conn2.close()



     'checking for information help

        btn_image1.Attributes.Add("onclick","javascript:helpdesc('" + label1.text + "','" + formtype + "');return false;")
        btn_image2.Attributes.Add("onclick","javascript:helpdesc('" + label5.text + "','" + formtype + "');return false;")
        btn_image3.Attributes.Add("onclick","javascript:helpdesc('" + label7.text + "','" + formtype + "');return false;")

     'end of statement for javascript


	  '***************************************  END  ************************************

		  Else
		  prodId=ViewState.Item("prodId")

		  End If


		Dim Rdr4 as SQLDataReader
        Dim Cmd4 as SQLCommand
		Dim Rdr5 as SQLDataReader
        Dim Cmd5 as SQLCommand
        Dim j as integer
		Dim Table1 as new table
	    dim fieldE,fieldothers as string
	    dim idno as integer



        PlaceHolder1.controls.add(table1)


          strSQL="select * from par_type_risk"
          Cmd4=New SQLCOmmand(strSQL,conn)
          conn.open()
          Rdr4=Cmd4.executeReader(system.data.CommandBehavior.CloseConnection)

		  j=0

	   	  Dim r As New TableRow()
		  Dim c3 As New TableCell()
          Dim c4 as New TableCell()
          Dim c5 as New TableCell()

		  dim title1 as new label()
          title1.text="<b>Type Of Risks</b>"
		  c3.Controls.Add(title1)

		  dim title2 as new label()
          title2.text="<b>Assessment Risk <br>( To type 1 - 9 )</b>"
		  c4.Controls.Add(title2)
		  c4.HorizontalAlign = HorizontalAlign.Center


		  dim title3 as new label()
          title3.text="<b>Control Measures</b>"
		  c5.Controls.Add(title3)
		  c5.HorizontalAlign = HorizontalAlign.Center

		  r.Cells.Add(c3)
          r.Cells.Add(c4)
          r.Cells.Add(c5)

		  r.Attributes.Add("bgcolor", "#0099ff")
		  table1.Rows.Add(r)

		  table1.Attributes.Add("border", "1")
		  table1.Width = Unit.Pixel(700)

		   While Rdr4.Read()

			j=j+1

            	Dim r1 As New TableRow()
				Dim c As New TableCell()
                Dim c1 as New TableCell()
                Dim c2 as New TableCell()

                  dim labelrisk as new label()
                  labelrisk.ID="labelrisk" & j & ""
                  labelrisk.text=Rdr4("risk")

                  dim labelid as new label()
                  labelid.ID="labelid" & j & ""
                  labelid.text=Rdr4("id")
				  labelid.visible=false

                  c.Controls.Add(labelrisk)
				  c.Controls.Add(labelid)

                  dim text_assessment as textbox = New textbox()
                  text_assessment.ID="text_assessment" & j.tostring() & ""
				  text_assessment.MaxLength=1
				  text_assessment.Width = Unit.Pixel(50)
				  c1.HorizontalAlign = HorizontalAlign.Center

		  	      strSQL="select risk_id,asessment_id,control_measures from par_list_risk where risk_id = " & Rdr4("id") & " and prodId=" & prodId & ""
          	      Cmd5=New SQLCOmmand(strSQL,conn1)
                  conn1.open()
                  Rdr5=Cmd5.executeReader(system.data.CommandBehavior.CloseConnection)

		          Rdr5.Read()

		          If not (Rdr5.HasRows) Then
                    fieldE="No Record"
                  End If

			  	  If (Rdr5.HasRows) Then
			  	        idno = (idno + (Rdr5("asessment_id")))

		                  If (Rdr5("asessment_id")<>"0") and (Rdr5("control_measures")="" or (Rdr5("control_measures").Tostring()  Is DBNull.value)) Then
		                      fieldE="0"
		 	              End If

                          If Rdr5("risk_id")="8" Then

              	             strSQL="select othersvalue from par_othersInfo where id=" & prodId & " and label='11.3'"
     	                     Cmd2=New SQLCOmmand(strSQL,conn2)
                             conn2.open()
                             Rdr2=Cmd2.executeReader(system.data.CommandBehavior.CloseConnection)
		                     Rdr2.Read()

		                     If Rdr2.HasRows Then
  		                        If (Rdr2("othersvalue")="" or (Rdr2("othersvalue").Tostring() Is System.DBNull.Value)) Then
                                 fieldOthers="0"
  		                        End If
                             End If

			  	          End If

			  	          If Rdr5("asessment_id")=0 Then
			  	              text_assessment.text = ""
			  	          Else
			  	              text_assessment.text = Rdr5("asessment_id")
			  	          End If
				  End If

				  text_assessment.Attributes.Add("onchange","javascript:checkDecimal1('borang','text_assessment" & j.tostring() & "','assessment');")

                  c1.Controls.Add(text_assessment)

                  dim text_control as new textbox()

                  text_control.ID="text_control" & j.tostring() & ""
                  text_control.MaxLength=250
                  text_control.TextMode = TextBoxMode.MultiLine
				  If Rdr5.HasRows Then
				  text_control.text = Rdr5("control_measures")
            	  End If
            	  text_control.Width = Unit.Pixel(300)
            	  text_control.Height = Unit.Pixel(70)

				  If Rdr4("id")=8 Then
				  text_assessment.Attributes.Add("onClick","javascript:document.all.otherrisk.style.display='block';")
				  text_control.Attributes.Add("onClick","javascript:document.all.otherrisk.style.display='block';")
				  End If

				  c2.Controls.Add(text_control)
		  		  c2.HorizontalAlign = HorizontalAlign.Center

			      conn1.close()

                  r1.Cells.Add(c)
                  r1.Cells.Add(c1)
                  r1.Cells.Add(c2)

            	  Table1.Rows.Add(r1)


            	  If (fieldE="No Record" or fieldE="0" or idno=0 or fieldOthers="0") then
                  Label7.Font.Bold = True
                  Label8.Font.Bold = True
                  Label7.forecolor = Color.red
                  Label8.forecolor = Color.Red
                  End If

	  End While

        conn.close()

		bil.text=j

	  '***************************************  END  **************************************
        End Sub




     '******************************* FUNCTION TO SUBMIT TO THE NEXT PAGE ************************

    Public Sub Submit_button (Sender As Object, E As EventArgs)


		If Page.IsValid Then

        Context.Items.Add("prodId", prodId)

		Dim j as integer
		Dim Rdr6 as SQLDataReader
        Dim Cmd6 as SQLCommand
        Dim Rdr1 as SQLDataReader
        Dim Cmd1 as SQLCommand

        If (sender.Id)="btn_save" Then

		strSQL="delete from par_list_risk where prodId=" & prodId & ""
        Cmd6=New SQLCOmmand(strSQL,conn)
        conn.open()
        Rdr6=Cmd6.executeReader(system.data.CommandBehavior.CloseConnection)
		conn.close()

		for j = 1 to (bil.text)

		Dim riskId as label = CType(PlaceHolder1.FindControl("labelid" & j ), label)
		Dim assessment as textbox = CType(PlaceHolder1.FindControl("text_assessment" & j ), textbox)
        Dim control as textbox = CType(PlaceHolder1.FindControl("text_control" & j ), textbox)

        If riskId.text=8 Then

           If (assessment.text="0") or (control.text="") Then
              strSQL="delete par_othersInfo where id=" & prodId & " and label='11.3'"
              Cmd1=New SQLCOmmand(strSQL,conn)
              conn.open()
              Cmd1.ExecuteNonQuery()
              conn.close()
           End If
        Else

		  if textothers.text<>"" then
		   dim mastertable as string
           mastertable="par_type_risk"
           getresult=ins_other(prodId,"11.3",mastertable,textothers.text,Session("uid"))
          end if

        End If

	    getresult=list_risk(prodId,riskId.text,assessment.text,control.text)

		next




              ' CODING FOR DELETE FOR FILE REPLACING BY CHECKING THE EXISTING FILE


		      '******************* View Location File For IBI **********************

    		    Dim viewpath as string

                strSQL="select * from par_viewimage where typelocation='IBI'"
                Cmd=New SQLCommand(strSQL,conn)
                conn.open()
                Rdr=Cmd.executereader(system.data.commandbehavior.closeconnection)

                Rdr.read()
                    viewpath=Rdr("path")
                Rdr.close()
                conn.close()

              '**************************** end *************************************

		        strSQL="select idcloning, risk_management_additional_info,risk_analysis_info from par_products where ID=" & prodId
		        Cmd=New SQLCOmmand(strSQL,conn)
                conn.open()

                Rdr=Cmd.executeReader(system.data.CommandBehavior.CloseConnection)

                Rdr.Read()

                if not Rdr("idcloning") is system.dbnull.value then

                    strSQL="select risk_management_additional_info,risk_analysis_info from par_products where ID=" & rdr("idcloning")
                    Cmd1=New SQLCOmmand(strSQL,conn1)
                    conn1.open()

                    Rdr1=Cmd1.executeReader(system.data.CommandBehavior.CloseConnection)

                    Rdr1.Read()

                    if Rdr("risk_management_additional_info").tostring()<>Rdr1("risk_management_additional_info").tostring() then
                        If Rdr("risk_management_additional_info").tostring() <>"" Then
                            If addBox.text<>"" then
                                If Rdr("risk_management_additional_info").tostring()<>addBox.text then
                                System.IO.File.Delete(viewpath & session("fitype") & session("ibi_master") & "\" & Rdr("risk_management_additional_info"))
                                end if
                            end if
                        End If
                    end if

                    if Rdr("risk_analysis_info").tostring()<> Rdr1("risk_analysis_info").tostring() then
                        If Rdr("risk_analysis_info").tostring() <>"" Then
                            If addBox1.text<>"" then
                                If Rdr("risk_analysis_info").tostring()<>addBox1.text then
                                System.IO.File.Delete(viewpath & session("fitype") & session("ibi_master") & "\" & Rdr("risk_analysis_info"))
                                end if
                            end if
                        End If
                    end if

                else

                    If Rdr("risk_management_additional_info").tostring() <>"" Then
                        If addBox.text<>"" then
                            If Rdr("risk_management_additional_info").tostring()<>addBox.text then
                            System.IO.File.Delete(viewpath & session("fitype") & session("ibi_master") & "\" & Rdr("risk_management_additional_info"))
                            end if
                        end if
                    End If

                    If Rdr("risk_analysis_info").tostring() <>"" Then
                        If addBox1.text<>"" then
                            If Rdr("risk_analysis_info").tostring()<>addBox1.text then
                            System.IO.File.Delete(viewpath & session("fitype") & session("ibi_master") & "\" & Rdr("risk_analysis_info"))
                            end if
                        end if
                    End If

                end if

                conn1.close()
                conn.close()

                ' END

		        getresult=update_product(prodId,session("ibi_master"),textbox1.value,addbox.text,textrisk.text,addBox1.text)

                ' funtion to delete data from table par_temptable

                    getResult=deletefile(prodId,addBox.text)
                    getResult=deletefile(prodId,addBox1.text)

                ' end


        end if


        dim filetransfer,nextlocation,previouslocation,filevalidate,filetoprint as string

        dim sqlocation as string


            sqlocation="select par_locationfile.pageno,par_locationfile.filelocation,par_locationfile.nextlocation," _
                & " par_locationfile.previouslocation,par_locationfile.filevalidatelast,par_locationfile.filetoprint  from par_locationfile" _
                & " inner join par_masterlocation ON par_masterlocation.formtype = par_locationfile.formtype" _
                & " where par_masterlocation.product_category= " & prod_category.text & " and " _
                & " par_masterlocation.product_line=" & product_line.text & " and par_locationfile.pageno="+pageid.text
            Cmd1=New SQLCOmmand(sqlocation,conn)
            conn.open()

            Rdr1=Cmd1.executeReader(system.data.CommandBehavior.CloseConnection)

            Rdr1.Read()

	            filetransfer = Rdr1("filelocation").tostring()
	            nextlocation = Rdr1("nextlocation").tostring()
	            previouslocation = Rdr1("previouslocation").tostring()
	            filevalidate = Rdr1("filevalidatelast").tostring()
	            filetoprint = Rdr1("filetoprint").tostring()

            conn.close()


 		 Select Case (sender.id)
 		 Case "btn_save"
         response.write ("<script>alert('The information has been successfully saved.');self.location.href='par_tittle.aspx?fname="+filetransfer+"&prodId=" & prodId & "'</script>")
         response.end
		 case "Button1"
		 Server.transfer("par_tittle.aspx?fname="+nextlocation+"",True)
		 case "Button2"
		 Server.transfer("par_tittle.aspx?fname="+previouslocation+"",True)
		 case "Button4"
		 Server.Transfer("par_automatic_feebased_continue.aspx",True)
		 case "Button6"
	 	 Context.Items.Add("validate", "v")
	     Server.transfer("par_tittle.aspx?fname="+filevalidate+"",True)
		 case "Button5"
		 Context.Items.Add("print", "y")
		 Context.Items.Add("noprint", "y")
		 Server.transfer("par_tittle.aspx?fname="+filetoprint+"",True)
		 End Select

         End if


    End Sub

	'**************************************** END ******************************


	'*** function to update information


    Public Function update_product(Byval id as integer, Byval ibimaster as integer, Byval textbox1 as string, Byval addBox as string, Byval risk_weight as Decimal, Byval risk_analysis as string) as integer

        Dim strConn as string = configurationSettings.AppSettings("connectionstring")
        Dim dbConnection as System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(strConn)

        Dim querystring as string = "par_hybrid_page4"

        Dim dbCommand as System.Data.IDbCommand = New system.Data.SqlClient.SqlCommand
        dbCommand.CommandText = querystring
        dbCommand.Connection = dbConnection
        dbCommand.CommandType = CommandType.StoredProcedure

        Dim dbParam_prodID as System.Data.IDataParameter = New System.Data.SqlClient.Sqlparameter
        dbParam_prodID.ParameterName = "@prodId"
        dbParam_prodID.Value = id
        dbCommand.Parameters.Add(dbParam_prodID)

        Dim dbParam_ibimaster as System.Data.IDataParameter = New System.Data.SqlClient.Sqlparameter
        dbParam_ibimaster.ParameterName = "@ibimaster"
        dbParam_ibimaster.Value = ibimaster
        dbCommand.Parameters.Add(dbParam_ibimaster)


        Dim dbParam_textbox1 as System.Data.IDataParameter = New System.Data.SqlClient.Sqlparameter
        dbParam_textbox1.ParameterName = "@risk"
		If textbox1="" then
		dbParam_textbox1.Value = DbNull.value
		Else
        dbParam_textbox1.Value = textbox1
        End If
		dbParam_textbox1.DbType = System.Data.Dbtype.String
        dbCommand.Parameters.Add(dbParam_textbox1)


        Dim dbParam_addBox as System.Data.IDataParameter = New System.Data.SqlClient.Sqlparameter
        dbParam_addBox.ParameterName = "@risk_info"
	    If addBox="" Then
	    dbParam_addBox.Value = DbNull.value
	    Else
        dbParam_addBox.Value = addBox
        End If
	    dbParam_addBox.DbType = System.Data.Dbtype.String
        dbCommand.Parameters.Add(dbParam_addBox)

        Dim dbParam_risk_weight as System.Data.IDataParameter = New System.Data.SqlClient.Sqlparameter
        dbParam_risk_weight.ParameterName = "@risk_weight"
        dbParam_risk_weight.Value = risk_weight
		dbParam_risk_weight.DbType = System.Data.Dbtype.String
        dbCommand.Parameters.Add(dbParam_risk_weight)

        Dim dbParam_risk_analysis as System.Data.IDataParameter = New System.Data.SqlClient.Sqlparameter
        dbParam_risk_analysis.ParameterName = "@risk_analysis"
		If risk_analysis="" Then
		dbParam_risk_analysis.Value = DbNull.value
		Else
        dbParam_risk_analysis.Value = risk_analysis
        End If
		dbParam_risk_analysis.DbType = System.Data.Dbtype.String
        dbCommand.Parameters.Add(dbParam_risk_analysis)

        Dim dbParam_results as System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_results.ParameterName = "RETURN VALUE"
        dbParam_results.Direction = ParameterDirection.REturnValue
        dbCommand.Parameters.Add(dbParam_results)

        Dim results as Integer = 0

        dbConnection.Open

        Try
            dbCommand.ExecuteNonQuery

            if dbCommand.Parameters("RETURN VALUE").Value then
                results=dbCOmmand.Parameters("RETURN VALUE").Value
            end if

        Finally
            dbConnection.Close

        End Try

        Return results

    End Function



'*** function to add list of type risk


    Public Function list_risk(Byval id as integer, Byval risk_id as integer, Byval assessment as string, Byval txt_control as string) as integer

        Dim strConn as string = configurationSettings.AppSettings("connectionstring")
        Dim dbConnection as System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(strConn)

        Dim querystring as string = "par_risk"

        Dim dbCommand as System.Data.IDbCommand = New system.Data.SqlClient.SqlCommand
        dbCommand.CommandText = querystring
        dbCommand.Connection = dbConnection
        dbCommand.CommandType = CommandType.StoredProcedure

        Dim dbParam_prodID as System.Data.IDataParameter = New System.Data.SqlClient.Sqlparameter
        dbParam_prodID.ParameterName = "@prodId"
        dbParam_prodID.Value = id
        dbCommand.Parameters.Add(dbParam_prodID)

        Dim dbParam_risk_id as System.Data.IDataParameter = New System.Data.SqlClient.Sqlparameter
        dbParam_risk_id.ParameterName = "@risk_id"
        dbParam_risk_id.Value = risk_id
        dbCommand.Parameters.Add(dbParam_risk_id)

        Dim dbParam_assessment as System.Data.IDataParameter = New System.Data.SqlClient.Sqlparameter
        dbParam_assessment.ParameterName = "@assessment"
	    dbParam_assessment.Value = assessment
        dbCommand.Parameters.Add(dbParam_assessment)

        Dim dbParam_control as System.Data.IDataParameter = New System.Data.SqlClient.Sqlparameter
        dbParam_control.ParameterName = "@control"
	    dbParam_control.Value = txt_control
        dbParam_control.DbType = System.Data.Dbtype.String
        dbCommand.Parameters.Add(dbParam_control)

        Dim dbParam_results as System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_results.ParameterName = "RETURN VALUE"
        dbParam_results.Direction = ParameterDirection.REturnValue
        dbCommand.Parameters.Add(dbParam_results)

        Dim results as Integer = 0

        dbConnection.Open

        Try
            dbCommand.ExecuteNonQuery

            if dbCommand.Parameters("RETURN VALUE").Value then
                results=dbCOmmand.Parameters("RETURN VALUE").Value
            end if

        Finally
            dbConnection.Close

        End Try

        Return results

    End Function

		'*** function to insert value others for all label

    Public Function ins_other(Byval id as integer,Byval label as string,Byval table as string,Byval fieldV as string, Byval uid as string) as integer

        Dim strConn as string = configurationSettings.AppSettings("connectionstring")
        Dim dbConnection as System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(strConn)


        Dim querystring as string = "par_SPOther"

        Dim dbCommand as System.Data.IDbCommand = New system.Data.SqlClient.SqlCommand
        dbCommand.CommandText = querystring
        dbCommand.Connection = dbConnection
        dbCommand.CommandType = CommandType.StoredProcedure

        Dim dbParam_prodID as System.Data.IDataParameter = New System.Data.SqlClient.Sqlparameter
        dbParam_prodID.ParameterName = "@prodId"
        dbParam_prodID.Value = id
        dbCommand.Parameters.Add(dbParam_prodID)

        Dim dbParam_label as System.Data.IDataParameter = New System.Data.SqlClient.Sqlparameter
        dbParam_label.ParameterName = "@label"
        dbParam_label.Value = label
        dbParam_label.DbType = System.Data.Dbtype.String
        dbCommand.Parameters.Add(dbParam_label)

        Dim dbParam_table as System.Data.IDataParameter = New System.Data.SqlClient.Sqlparameter
        dbParam_table.ParameterName = "@table"
        dbParam_table.Value = table
        dbParam_table.DbType = System.Data.Dbtype.String
        dbCommand.Parameters.Add(dbParam_table)


        Dim dbParam_value as System.Data.IDataParameter = New System.Data.SqlClient.Sqlparameter
        dbParam_value.ParameterName = "@field"
        dbParam_value.Value = fieldV
        dbParam_value.DbType = System.Data.Dbtype.String
        dbCommand.Parameters.Add(dbParam_value)


        Dim dbParam_uid as System.Data.IDataParameter = New System.Data.SqlClient.Sqlparameter
        dbParam_uid.ParameterName = "@uid"
        dbParam_uid.Value = uid
        dbParam_uid.DbType = System.Data.Dbtype.String
        dbCommand.Parameters.Add(dbParam_uid)


        Dim dbParam_results as System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_results.ParameterName = "RETURN VALUE"
        dbParam_results.Direction = ParameterDirection.REturnValue
        dbCommand.Parameters.Add(dbParam_results)

        Dim results as Integer = 0

        dbConnection.Open

        Try
            dbCommand.ExecuteNonQuery

            if dbCommand.Parameters("RETURN VALUE").Value then
                results=dbCOmmand.Parameters("RETURN VALUE").Value
            end if

        Finally
            dbConnection.Close

        End Try

        Return results

    End Function

 	' FUNCTION TO delete the attchment in the temporary table

    Public Function deletefile(ByVal prodId as Integer, ByVal fname as String) As Integer

        Dim strConn as string = configurationSettings.AppSettings("connectionstring")
        Dim dbConnection as System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(strConn)

        Dim querystring as string = "par_deletetemp"

        Dim dbCommand as System.Data.IDbCommand = New system.Data.SqlClient.SqlCommand
        dbCommand.CommandText = querystring
        dbCommand.Connection = dbConnection
        dbCommand.CommandType = CommandType.StoredProcedure

        Dim dbParam_prodID as System.Data.IDataParameter = New System.Data.SqlClient.Sqlparameter
        dbParam_prodID.ParameterName = "@prodId"
        dbParam_prodID.Value = prodId
        dbParam_prodID.DbType = System.Data.Dbtype.String
        dbCommand.Parameters.Add(dbParam_prodID)


		Dim dbParam_label as System.Data.IDataParameter = New System.Data.SqlClient.Sqlparameter
        dbParam_label.ParameterName = "@fname"
        dbParam_label.Value = fname
		dbParam_label.DbType = System.Data.Dbtype.String
        dbCommand.Parameters.Add(dbParam_label)

        Dim dbParam_results as System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_results.ParameterName = "RETURN VALUE"
        dbParam_results.Direction = ParameterDirection.REturnValue
        dbCommand.Parameters.Add(dbParam_results)


        Dim results as Integer = 0

        dbConnection.Open

        Try
            dbCommand.ExecuteNonQuery

            if dbCommand.Parameters("RETURN VALUE").Value then
                results=dbCOmmand.Parameters("RETURN VALUE").Value
            end if

        Finally
            dbConnection.Close

        End Try

        Return results

    End Function


'*** end of function



End Class

