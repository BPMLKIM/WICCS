<%@ Page Language="VB" AutoEventWireup="false" CodeFile="mainpage.aspx.vb" Inherits="script1_tocTab" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script language="javascript" type="text/javascript">

var tocTab = new Array();
tocTab[0] = new Array ("0", "", "");
tocTab[1] = new Array ("1", "Home ", "blank.htm");

</script>

<%

    Dim m As Integer
    Response.Write("<script>" & vbCrLf)
    For m = 0 To menutree_list.Count() - 1
       
        Response.Write(menutree_list(m).ToString & vbCrLf)
    Next
    Response.Write("var nCols = 4;")
    Response.Write("</script>" & vbCrLf)
    
    
%>    

<html>
<head>
    <title><%=titles%></title> 		
    <script language="JavaScript" src="<%=tocparas%>"></script>
    <script language="JavaScript" src="<%=displayToc%>"></script>	
</head>
	
<frameset name="razmeer" border="0" rows="96,*" onload="reDisplay('0',true);" cols=*>
  <frame name="topFrame" src="<%=top%>" noresize="noresize" scrolling="no" />
  <frameset border="0" rows=* onload="reDisplay('0',true);"
cols=238,* name="razmeer1">
    <frameset rows="*" cols="213,*" framespacing="0" frameborder="NO" border="0" name="raz">
      <frame name="toc" src="blank1.htm"/>
      <frame src="showhideframe.htm" name="leftFrame" scrolling="NO" noresize  >
    </frameset>
    <%=toctab%> 
    <frame name="content" id="content" src="blank.htm" />
  </frameset>
</frameset>
</frameset>
<noframes></noframes>
</html>
    
    

