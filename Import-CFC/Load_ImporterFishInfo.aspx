<%@ Page Language="VB" Debug="true" %>
<table border="0"  style="width: 100%; border-right: gray thin groove; border-top: gray thin groove; border-left: gray thin groove; border-bottom: gray thin groove;">
    <tr>
        <td rowspan="2" bgcolor="#f1f1f1">
            Kod BKH</td>
        <td bordercolor="#0" rowspan="2" style="width: 20%" bgcolor="#f1f1f1">
            Nama</td>
        <td rowspan="2" bgcolor="#f1f1f1">
            <div align="center">
                Kod 8 Digit</div>
        </td>
        <td rowspan="2" style="width: 15%" bgcolor="#f1f1f1">
            <div align="center">
                Destinasi</div>
        </td>
        <td colspan="4" style="border-bottom: black thin solid" bgcolor="#f1f1f1">
            <div align="center">
                Peti</div>
        </td>
        <td rowspan="2" bgcolor="#f1f1f1">
            <div align="center">
                Pek</div>
        </td>
        <td rowspan="2" bgcolor="#f1f1f1">
            <div align="center">
                Ekor</div>
        </td>
        <td rowspan="2" style="text-align: center" bgcolor="#f1f1f1">
            Nilai (RM)</td>
    </tr>
    <tr>
        <td style="height: 15px" bgcolor="#f1f1f1">
            Kecil</td>
        <td style="height: 15px" bgcolor="#f1f1f1">
            Kuantiti (kg)</td>
        <td style="height: 15px" bgcolor="#f1f1f1">
            Besar</td>
        <td style="height: 15px" bgcolor="#f1f1f1">
            Kuantiti(kg)</td>
    </tr>
    <%
	
        Dim dataVal As String
        Dim importerCode As String
        Dim rowArray() As String
        Dim i As Integer
        Dim totalNilai As Double = 0
            
        Dim totalPetiKecil As Double = 0
        Dim totalQtyKecil As Decimal = 0
            
        Dim totalPetiBesar As Decimal = 0
        Dim totalQtyBesar As Decimal = 0
            
        Dim totalPek As Decimal = 0
        Dim totalEkor As Decimal = 0
        
        
        
        If Request("dataVal") <> "" And Request("iCode") <> "" Then
            dataVal = Request("dataVal") 'Request("arrayFishVal") 
            importerCode = Request("iCode")
            rowArray = dataVal.Split("~")
            Dim m As Integer
            
            For i = 0 To UBound(rowArray) - 1
                m = m + 1
                
                Dim valStr() As String
                valStr = rowArray(i).Split("`")
                
                If valStr(0) = importerCode Then
                    totalPetiKecil = totalPetiKecil + CDbl(valStr(5))
                    totalQtyKecil = totalQtyKecil + valStr(6)
                    totalPetiBesar = totalPetiBesar + valStr(7)
                    totalQtyBesar = totalQtyBesar + valStr(8)
                    totalPek = totalPek + valStr(9)
                    totalEkor = totalEkor + valStr(10)
                    totalNilai = totalNilai + valStr(11)
                    
                    'Response.Write("<script>document.all.total.value='" & total & "';")
                    
		
%>
    <tr onClick="HighLightTR('#c9cc99','cc3333');">
        <td style="width: 55px; height: 23px">
            <input name="checkboxIkan" type="checkbox" value='<%=rowArray(i)&"~"%>' />&nbsp;<%=valStr(1)%></td>
        <td style="height: 23px"><%=valStr(2)%>
        </td>
        <td style="height: 23px"><%=valStr(3)%>
        </td>
        <td style="height: 23px"><%=valStr(12)%>
        </td>
        <td style="height: 23px"><%=valStr(5)%>
        </td>
        <td style="height: 23px"><%=valStr(6)%>
        </td>
        <td style="height: 23px"><%=valStr(7)%>
        </td>
        <td style="height: 23px"><%=valStr(8)%>
        </td>
        <td style="height: 23px"><%=valStr(9)%>
        </td>
        <td style="height: 23px"><%=valStr(10)%>
        </td>
        <td style="height: 23px"><%=valStr(11)%>
        </td>
    </tr>
     <% 
     End If
     Next
 End If
  %>
    
    <tr>
        <td bgcolor="#ffffcc" colspan="4" >
            <strong>[CTRL] <span style="color: #0000ff">Senarai Ikan &nbsp; &nbsp; &nbsp; &nbsp;
                <input id="Button1" language="javascript" onclick="AddFishArray()" style="border-right: #333333 1px ridge;
                    padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
                    padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
                    border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
                    type="button" value="Tambah" /><input id="Button2" language="javascript" onclick="RemoveFishArray()"
                        style="border-right: #333333 1px ridge; padding-right: 1px; border-top: #ffffff 1px ridge;
                        padding-left: 1px; font-size: 10px; padding-bottom: 1px; border-left: #ffffff 1px ridge;
                        width: 56px; color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge;
                        font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1" type="button"
                        value="Batal" /></span></strong></td>
        <td bgcolor="#ffffcc" style="border-top-style: solid; border-top-color: teal; border-bottom: teal thin solid;"><%=totalPetiKecil%>
        </td>
        <td bgcolor="#ffffcc" style="border-top-style: solid; border-top-color: teal; border-bottom: teal thin solid;"><%=totalQtyKecil%>
        </td>
        <td bgcolor="#ffffcc" style="border-top-style: solid; border-top-color: teal; border-bottom: teal thin solid;"><%=totalPetiBesar%>
        </td>
        <td bgcolor="#ffffcc" style="border-top-style: solid; border-top-color: teal; border-bottom: teal thin solid;"><%=totalQtyBesar%>
        </td>
        <td bgcolor="#ffffcc" style="border-top-style: solid; border-top-color: teal; border-bottom: teal thin solid;"><%=totalPek%>
        </td>
        <td bgcolor="#ffffcc" style="border-top-style: solid; border-top-color: teal; border-bottom: teal thin solid;"><%=totalEkor%>
        </td>
        <td bgcolor="#ffffcc" style="border-top-style: solid; border-top-color: teal; border-bottom: teal thin solid;"><%=totalNilai%>
        </td>
    </tr>
    <tr>
        <td bgcolor="#f1f1f1" style="width: 55px; height: 23px">
        </td>
        <td bgcolor="#f1f1f1" style="height: 23px">
        </td>
        <td bgcolor="#f1f1f1" style="height: 23px">
        </td>
        <td bgcolor="#f1f1f1" style="height: 23px">
        </td>
        <td bgcolor="#f1f1f1" style="height: 23px">
        </td>
        <td bgcolor="#f1f1f1" style="height: 23px">
        </td>
        <td bgcolor="#f1f1f1" style="height: 23px">
        </td>
        <td bgcolor="#f1f1f1" style="height: 23px">
        </td>
        <td bgcolor="#f1f1f1" style="height: 23px">
        </td>
        <td bgcolor="#f1f1f1" style="height: 23px">
        </td>
        <td bgcolor="#f1f1f1" style="height: 23px">
        </td>
    </tr>
    <tr>
        <td bgcolor="#ffffff" colspan="11" style="height: 23px">
            <strong>
            Jumlah Peti :&nbsp;
            <%=totalPetiKecil + totalPetiBesar%></strong>
        </td>
    </tr>
</table>

