<%@ Page Language="VB" Debug="true" %>

<table width="71%" border="0" cellpadding="0" cellspacing="0">
  <tr> 
    <td width="7%" height="18" class="zam"> <div align="center"><strong><font color="#FFFFFF">NO.</font></strong></div></td>
    <td width="66%" bgcolor="#f1f1f1" class="zam"> <div align="center"><strong><font color="#FFFFFF">ITEM 
        DESCRIPTION</font></strong></div></td>
    <td width="23%" bgcolor="#f1f1f1" class="zam"><div align="center"><strong><font color="#FFFFFF">UNIT 
        / QUANTITY</font></strong></div></td>
  </tr>
<%
	
    Dim dataVal As String
    Dim rowArray() As String
    Dim i As Integer
    If Request("dataVal") <> "" Then
        dataVal = Request("dataVal")
        rowArray = dataVal.Split("~")
        Dim m As Integer
        For i = 0 To UBound(rowArray) - 1
            m = m + 1
            Dim tempStr As String
            Dim valStr() As String
            
            'tempStr = rowArray(i).
            
            valStr = rowArray(i).Split("`")
            'Dim z As Integer
            
                
                
		
%>
  <tr onClick="doSubmit('<?=$link?>');"> 
    <td height="18" class="zam2"><div align="center"> 
        <%=m%>
        <input type="checkbox" name="checkbox" value="<%=rowArray(i)&"~"%>" >
      </div></td>
    <td class="zam2"><div align="center">
        <%=valStr(0)%>
      </div></td>
    <td class="zam2"><div align="center">
        <%=valStr(2)%>
      </div></td>
  </tr>
  <% 
	Next
End If
  %>
  <tr> 
    <td height="18" class="zam">&nbsp;</td>
    <td class="zam">&nbsp;</td>
    <td class="zam">&nbsp;</td>
  </tr>
</table>

