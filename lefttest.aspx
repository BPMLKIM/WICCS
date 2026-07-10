<?xml version="1.0" encoding="iso-8859-1"?><%@ Page Language="VB" AutoEventWireup="false" CodeFile="left.aspx.vb" Inherits="left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<style>
<!--
BODY, TD {
	font-family : arial,  ;
	font-size : 9pt;
}

A {
	text-decoration: none;
	color: darkblue;
}

A:Hover {
	text-decoration: none;
	color: white;
}

-->
</style>
</head>
<body background="image/95.gif">
<form id="form1" runat="server">
<font size="2" face="Arial, Helvetica, sans-serif"  >  
 <%   
     Dim cntArray As Integer = 0
     Dim sqlText As String = "SELECT [menu],[sub],[link] FROM [menu]"
     jsReader = opClass.DataReader(sqlText)
     Do While (jsReader.Read)
         
         Response.Write("<br>+")
         Response.Write(jsReader.GetValue(0))
         Response.Write("<br>")
         Response.Write("&nbsp;&nbsp;&nbsp;")
         Response.Write("<br>-")
         Response.Write(jsReader.GetValue(1))
         cntArray = cntArray + 1
     Loop
     jsReader.Close()
     jsReader = Nothing
%>        

</font>

    </form>
</body>
</html>
