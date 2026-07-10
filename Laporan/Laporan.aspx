<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Laporan.aspx.vb" Inherits="Laporan_Laporan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
	<meta http-equiv="content-type" content="text/html; charset=iso-8859-1"/>
	<title>Laporan ICCS</title>
	<style type="text/css">
		@import "css/dtree.css";
	</style>    
    <script type="text/javascript" src="src/dtree.js"></script>

</head>
<body>
<table border="0" cellpadding="0" cellspacing="0" width="938">
  <tr> 
    <td width="17%" height="19" valign="middle" style="height: 13px"><font size="1" face="Arial, Helvetica, sans-serif">M 
      O D U L &nbsp;&nbsp;L A P O R A N </font></td>
    <td width="83%" bgcolor="#339999" style="height: 13px">&nbsp;</td>
  </tr>
</table>
<br />
<table style="width: 653px">
        <tr>
            <td colspan="3">
                <strong><span style="font-size: 10pt; font-family: Arial Black">LAPORAN ICCS</span></strong>
            </td>
        </tr>
	</table>
<br/>

<div class="dtree">
    <%
        ' view for main menu
        opClass = New SQLOperation()
        opClass.dbConnection()
        
        sqluser = "Select kebenaran_akses from pegawai where kata_pengguna = '" & Trim(Session("username")) & "'"
        SQLReader = opClass.DataReader(sqluser)
   
        SQLReader.Read()
        
        group_id = Trim(SQLReader("kebenaran_akses"))
                
        SQLReader.Close()
        SQLReader = Nothing
                
        sqlText = "Select * from group_setting_sub where sub_module_id='" & Trim(Request("sub_module_id")) & "' and module_id='15' and group_id = '" & group_id & "'"
        SQLReader = opClass.DataReader(sqlText)
        
        If SQLReader.HasRows Then
            
            SQLReader.Read()
            
            Select Case (SQLReader("sub_module_id"))
                Case "36"
                    Response.Write("<script type='text/javascript' src='src/import.js'></script>")
                Case "38"
                    Response.Write("<script type='text/javascript' src='src/eksport.js'></script>")
                Case "39"
                    Response.Write("<script type='text/javascript' src='src/aktif.js'></script>")
               
                Case "41"
                    Response.Write("<script type='text/javascript' src='src/cfc.js'></script>")
                Case "42"
                    Response.Write("<script type='text/javascript' src='src/pantau.js'></script>")
            
                
            End Select
  
        End If

        SQLReader.Close()
        SQLReader = Nothing
    
        ' end coded    
    
    
    %>

	
</div>
</body>
</html>
