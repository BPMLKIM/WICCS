<%@ Page Language="VB" AutoEventWireup="false" CodeFile="demo.aspx.vb" Inherits="demo" Debug="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<script language="javascript" type="text/javascript">

function AddArray()
{
    var dataItem = document.all.items1;
    
    document.all.arrayVal.value = document.all.arrayVal.value + document.all.items1.options.value + '`' +dataItem.options[dataItem.selectedIndex].text + '`' +document.all.Qty.value +'~';
    showHint(document.all.arrayVal.value);
}

function RemoveArray()
{
    var dataItem = document.all.items;
    var myString;
    var strReplace;
    var elementsName;

    if(document.all.checkbox.length>1)
    {
	    for (i=0;i<document.all.checkbox.length;i++)
	    {
		    myString = document.all.arrayVal.value;
		    elementsName="checkbox" + String(i);
		    if(document.all.checkbox(i).checked)
		    {
	   	        //alert(document.all.checkbox(i).value);
	   	        strReplace = document.all.checkbox(i).value;
	   	        document.all.arrayVal.value=myString.replace(strReplace,"");
	   	        showHint(document.all.arrayVal.value);	   
		    }
	     }//end for
    }
    else
    {
 	    if(document.all.checkbox.checked)
	    {
	        myString = document.all.arrayVal.value;
	        strReplace = document.all.checkbox.value;
	        document.all.arrayVal.value=myString.replace(strReplace,"");	   
	        showHint(document.all.arrayVal.value);	   
	    } 
	}
}


function showHint(str)
{

alert(str.length);
//if (str.length==0)
//{ 
//document.getElementById("txtHint").innerHTML=""
//return
//}
xmlHttp=GetXmlHttpObject();
if (xmlHttp==null)
{
alert ("Browser does not support HTTP Request");
return;
} 

var url="Load_Content_Information.aspx";
url=url+"?dataVal="+str;

url=url+"&sid="+Math.random();
xmlHttp.onreadystatechange=stateChanged;
xmlHttp.open("GET",url,true);
xmlHttp.send(null);
}

function stateChanged() 
{ 
if (xmlHttp.readyState==4 || xmlHttp.readyState=="complete")
{ 
//alert(xmlHttp.responseText );
document.getElementById("txtHint").innerHTML=xmlHttp.responseText;
} 
} 

function GetXmlHttpObject()
{ 
var objXMLHttp=null;
if (window.XMLHttpRequest)
{
objXMLHttp=new XMLHttpRequest();
}
else if (window.ActiveXObject)
{
objXMLHttp=new ActiveXObject("Microsoft.XMLHTTP");
}
return objXMLHttp;
} 



</script>
<body>
    <form id="all" runat="server">
    <div>
        <asp:DropDownList ID="items1" runat="server">
            <asp:ListItem Value="mazda1">mazda</asp:ListItem>
            <asp:ListItem Value="proton1">proton</asp:ListItem>
            <asp:ListItem Value="honda1">honda</asp:ListItem>
            <asp:ListItem Value="toyota1">toyota</asp:ListItem>
        </asp:DropDownList>&nbsp;
        <input id="Add" type="button" value="Add" language="javascript" onclick="AddArray()" />
        <input id="Remove" type="button" value="Remove" /><br />
        <br />
        <asp:TextBox ID="Qty" runat="server"></asp:TextBox><br />
    
    </div>
        <asp:TextBox ID="arrayVal" runat="server" />
    <span id="txtHint"></span>
    </form>
</body>
</html>
