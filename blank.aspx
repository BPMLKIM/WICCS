<%@ Page Language="VB" AutoEventWireup="false" CodeFile="blank.aspx.vb" Inherits="blank" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>ICCS - Bukit Kayu Hitam</title>
  <script language="javascript" src="popcalendar.js" type="text/javascript"></script>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
</head>

<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
<table width="100%" height="26" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td height="26" valign="top"> 
      <div align="left">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr> 
            <td width="18%" height="26"><img src="image/12.jpg" width="150" height="23"></td>
            <td width="25%" valign="middle"><font size="1" face="Arial, Helvetica, sans-serif"><%=Session("namaPegawai") %></font></td>
            <td width="4%"><img src="image/13.jpg" width="161" height="23"></td>
            <td width="53%" valign="middle"><font size="1" face="Arial, Helvetica, sans-serif"><%=Session("jobtitle")%></td>
          </tr>
        </table>
        
      </div></td>
  </tr>
</table>
<br>
</body>
</html>
