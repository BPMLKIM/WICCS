<%@ Page Language="VB" AutoEventWireup="false" CodeFile="pemeriksaan.aspx.vb" Inherits="Pemeriksaan_Ikan" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Microsoft.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="Microsoft.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head id="Head1" runat="server">
    <title>[WICCS]PINTU MASUK UTARA</title>
    <link href="../css/stylesheet.css" rel="stylesheet" type="text/css" />
</head>


<script languange="javascript">

//function AddArray()
//{
//var dataItem = document.form1.items;

//if (document.form1.per_name.value==''){alert('Name field is blank!'); return;}
//if (document.form1.add1.value==''){alert('Address field is blank!'); return;}
//if (document.form1.city.value==''){alert('City field is blank!'); return;}
//if (document.form1.state.value=='0'){alert('State field is blank!'); return;}
//if (document.form1.postcode.value==''){alert('Postcode field is blank!'); return;}
//if ((document.form1.ic4.value=='') && (document.form1.ic2.value=='') && (document.form1.ic3.value=='')) {if (document.form1.passport.value==''){alert('Icno field is blank!'); return;}}
//if (document.form1.passport.value==''){if (document.form1.ic4.value==''){alert('Passport field is blank!'); return;}}
//if (document.form1.relation.value=='0'){alert('Relationship field is blank!'); return;}

//if (((document.form1.ic2.value!='') && (document.form1.ic3.value!='')) && ((document.form1.passport.value !='0') && (document.form1.passport.value !='')) ){alert('Please key-in either ic no or passport no'); return;}
//if (document.form1.dd.value=='')&& (document.form1.mm.value=='') && (document.form1.yy.value=='') {alert('DOB field is blank!'); return;}
//if (document.form1.relation.value==''){alert('Relationship field is blank!'); return;}

//alert(document.form1.items)


//document.form1.arrayVal.value = document.form1.arrayVal.value + document.form1.per_name.value + '`' + document.form1.add1.value + '`' + document.form1.add2.value + '`' + document.form1.add3.value + '`' + document.form1.city.value+ '`' + document.form1.state.value + '`' + document.form1.postcode.value+ '`' + document.form1.ic4.value + '`' + document.form1.ic2.value + '`' + document.form1.ic3.value + '`' + document.form1.passport.value+ '`' + document.form1.dd.value + '`' +  document.form1.mm.value  + '`' + document.form1.yy.value + '`' + document.form1.relation.value +'~';
//showHint(document.form1.arrayVal.value);
//document.form1.per_name.value='';document.form1.ic4.value='';document.form1.ic2.value='';document.form1.ic3.value='';document.form1.passport.value='';document.form1.dd.value='';document.form1.mm.value='';document.form1.yy.value='';document.form1.relation.value='';
//}


function showHint(str)
{

//alert(str.length);
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
var url="pemeriksaan.asp";
url=url+"?dataVal="+str;
url=url+"&sid="+Math.random();
xmlHttp.onreadystatechange=stateChanged;
xmlHttp.open("GET",url,true);
xmlHttp.send(null);

}

</script>
<body runat="server">
      
    <form id="form1" runat="server">
        &nbsp;
        &nbsp;<br />
        <table style="width: 100%">
            <tr>
                <td colspan="4" style="height: 18px" bgcolor="#6600ff">
                    <strong>&nbsp;<span style="color: #ffffff">PEMERIKSAAN IKAN</span></strong></td>
            </tr>
            <tr>
                <td style="width: 97px">
                </td>
                <td style="width: 177px">
                </td>
                <td style="width: 86px">
                </td>
                <td style="width: 308px">
                </td>
            </tr>
            <tr>
                <td style="width: 97px" >
                    <strong>&nbsp;#Barcode</strong></td>
                <td style="width: 177px" >
                    <asp:TextBox ID="Barcode" runat="server" Width="156px" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 86px" >
                    <strong>&nbsp;Jenis Urusan</strong></td>
                <td style="width: 308px" >
                    <asp:TextBox ID="jenis_urusan" runat="server" ReadOnly="True" Width="156px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 23px; width: 97px;" >
                    &nbsp;<strong>No. Kenderaan</strong></td>
                <td style="height: 23px; width: 177px;" >
                    <asp:TextBox ID="noKenderaan" runat="server" Width="93px" ReadOnly="True"></asp:TextBox></td>
                <td style="height: 23px; width: 86px;" >
                </td>
                <td style="height: 23px; width: 308px;" >
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 17px">
                    <hr />
                </td>
            </tr>
            
        </table>
        
        
        
            <table style="width: 100%">
                <tr  >
                    <td style="width: 163px; height: 21px;" >
                        <b>Status Pemeriksaan</b></td>
                    <td style="height: 21px; width: 594px;" >
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem Value="1">Sah ( Pemeriksaan Rambang )</asp:ListItem>
                            <asp:ListItem Value="1">Sah ( Pemeriksaan 100% )</asp:ListItem>
                            <asp:ListItem Value="0">Tidak Sah</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr style="display : none" id="a1" runat="server">
                    <td style="width: 163px; height: 24px;">
                        <strong>Tindakan</strong></td>
                    <td style="height: 24px; width: 594px;" >
                    <asp:DropDownList ID="DropDownList2" runat="server">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Mahkamah</asp:ListItem>
                        <asp:ListItem>Isytihar Semula</asp:ListItem>
                    </asp:DropDownList></td>
                </tr>
                
                
                
                <tr >
                    <td style="width: 163px; height: 56px">
                        <b>Alasan</b></td>
                    <td style="height: 56px; width: 594px;">
                        <input id="Text1" style="width: 248px; height: 64px" type="text" /></td>
                </tr>
            </table>
        <br />
            
        <table id="tblViewInfo" border="0" runat="server">
              <tr>
                  <td style="width: 186px" >
                      No.</td>
                  <td style="width: 429px" >
                      Pengimport</td>
                  <td style="width: 669px" >
                      No SKPI</td>
              </tr>
            <tr>
                <td style="width: 186px">
                    </td>
                <td style="width: 429px">
                </td>
                <td style="width: 669px">
                 </td>
            </tr>
           </table> &nbsp;<br />
        &nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
          <br>
          <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr> 
              <td colspan="3"><span id="txtHint"></span></td>
            </tr>
            <tr> 
              <td width="22%" >&nbsp;</td>
              <td width="78%" colspan="2">: 
               </td>
            </tr>
          </table>
       
    </form>
    <script language="javascript" type="text/javascript">
     showHint(document.all.arrayVal.value,"pemeriksaan.aspx");
  //  refreshTableGridImporter()
   // refreshTableGridIkan();
    //showHint2(document.all.arrayFishVal.value,"Load_ImporterFishInfo.aspx");
</script>   

    <asp:HiddenField ID="HiddenField1" runat="server" />

</body>
</html>
