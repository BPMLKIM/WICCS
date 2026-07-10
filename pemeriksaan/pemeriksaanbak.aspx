<%@ Page Language="VB" AutoEventWireup="false" CodeFile="pemeriksaan.aspx.vb" Inherits="Pemeriksaan_Ikan" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Microsoft.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="Microsoft.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../css/stylesheet.css" rel="stylesheet" type="text/css" />
</head>

<script languange="javascript">

 // function display_row()
   //  {
     //   if (document.getElementById("DropDownList1").options[3].text=="Tidak Sah")
       //    {document.all.tindakan1.style.display='block';}
       // if (document.getElementById("DropDownList1").options[3].text=="Tidak Sah"){document.all.tindakan1.style.display="none";}
   //  }
     
 function display_row()
{
   
  if (document.form1.DropDownList1.value=="0")
   {document.all.a1.style.display='block';} else
   {document.all.a1.style.display='none';}   
}    

</script>

<body>
      
    <form id="form1" runat="server">
        &nbsp;
        <br /><br /><br /><br />
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
        <br />        
        <div id="txtHint2"></div>
        <div>           
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            &nbsp;&nbsp;&nbsp;<br />
            <table style="width: 100%">
                <tr  align="top">
                    <td style="width: 163px; height: 21px;" >
                        <b>Status Pemeriksaan</b></td>
                    <td style="height: 21px" >
                        <asp:DropDownList ID="DropDownList1" runat="server" onClick="display_row();">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem Value="1">Sah ( Pemeriksaan Rambang )</asp:ListItem>
                            <asp:ListItem Value="1">Sah ( Pemeriksaan 100% )</asp:ListItem>
                            <asp:ListItem Value="0">Tidak Sah</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr align="top"  style="display :none" id="a1">
                    <td style="width: 163px; height: 21px;">
                        <strong>Tindakan</strong></td>
                    <td style="height: 21px" >
                    <asp:DropDownList ID="DropDownList2" runat="server">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem Value="Mahkamah">Mahkamah</asp:ListItem>
                        <asp:ListItem Value="Isytihar Semula">Isytihar Semula</asp:ListItem>
                    </asp:DropDownList></td>
                </tr>
                <tr align="top">
                    <td style="width: 163px; height: 107px">
                        <b>Alasan</b></td>
                    <td style="height: 107px">
                        <input id="Text1" style="width: 290px; height: 99px" type="text" /></td>
                </tr>
                <tr align="top">
                    <td colspan="2">
                        <asp:Button ID="Button3" runat="server" Style="border-right: #333333 1px ridge; padding-right: 1px;
                            border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px; padding-bottom: 1px;
                            border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge;
                            font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1" Text="BARU" /><asp:Button
                                    ID="Button5" runat="server" Style="border-right: #333333 1px ridge; padding-right: 1px;
                                    border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px; padding-bottom: 1px;
                                    border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge;
                                    font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1" Text="PENGISYTAHARAAN CAJ" />
                        <asp:Button
                                ID="Button4" runat="server" Style="border-right: #333333 1px ridge; padding-right: 1px;
                                border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px; padding-bottom: 1px;
                                border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge;
                                font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1" Text="SIMPAN" />
                        <asp:Button
                                        ID="Button6" runat="server" Style="border-right: #333333 1px ridge; padding-right: 1px;
                                        border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px; padding-bottom: 1px;
                                        border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge;
                                        font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1" Text="KELUAR" /></td>
                </tr>
            </table>
        </div>  
                        <hr />
        
    </form>

</body>
</html>
