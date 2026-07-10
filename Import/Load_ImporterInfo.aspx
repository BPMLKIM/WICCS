<%@ Page Language="VB" Debug="true" %>

<table border="0" style="width: 100%; border-right: gray thin groove; border-top: gray thin groove; border-left: gray thin groove; border-bottom: gray thin groove;" bordercolor="#ffffff">
  <tr> 
    <td width="7%" bgcolor="#f1f1f1">
        No.</td>
    <td bgcolor="#f1f1f1" height="22"> Pengimport</td>
    <td bgcolor="#f1f1f1" height="22" >
        No. Lesen</td>
      <td bgcolor="#f1f1f1" height="22">
          No. e-SKPI</td>
      <td bgcolor="#f1f1f1" height="22">
          Tarikh Luput</td>
      <td bgcolor="#f1f1f1" height="22">
          Pengeksport</td>
      <td bgcolor="#f1f1f1" height="22">
          Kod Pengimport</td>
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
            
            
            Dim valStr() As String
            Dim lesenStr() As String
            
            valStr = rowArray(i).Split("`")
            lesenStr = valStr(0).Split("|")
            
            Response.Write("<script>document.all.currentImporter.value='" & lesenStr(0) & "';</script>")
                
		
%>
  <tr onClick="HighLightTR('#c9cc99','cc3333');document.all.currentImporter.value='<%=lesenStr(0)%>';refreshTableGridIkan();" > 
    <td><%=m%>
        <input type="checkbox" name="checkbox" value="<%=rowArray(i)&"~"%>">
    </td>
    <td ><%=valStr(1)%>
      </td>
    <td><%=lesenStr(1)%>
      </td>
      <td >&nbsp;
      </td>
      <td ><%=lesenStr(2)%>
      </td>
      <td ><%=valStr(5)%>
      </td>
      <td ><%=lesenStr(0)%>
      </td>
  </tr>
  <% 
	Next
End If
  %>
  <tr> 
    <td bgcolor="#f1f1f1" >&nbsp;</td>
    <td bgcolor="#f1f1f1" height="22">&nbsp;</td>
    <td bgcolor="#f1f1f1" height="22">&nbsp;</td>
    <td bgcolor="#f1f1f1" height="22">&nbsp;</td>
    <td bgcolor="#f1f1f1" height="22">&nbsp;</td>
    <td bgcolor="#f1f1f1" height="22">&nbsp;</td>
    <td bgcolor="#f1f1f1" height="22">&nbsp;</td>
  </tr>
</table>

