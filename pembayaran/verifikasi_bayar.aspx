<%@ Page Language="VB" AutoEventWireup="false" CodeFile="verifikasi_bayar.aspx.vb" Inherits="pembayaran_verifikasi_bayar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
     <link href="../css/stylesheet.css" rel="stylesheet" type="text/css" />
</head>

<script language="javascript" type="text/javascript">

function display()
{
if (document.form1.selectpay.options[document.form1.selectpay.selectedIndex].text=='Bayar') 
    {document.all.idbarcode.style.display='block';} 
if (document.form1.selectpay.options[document.form1.selectpay.selectedIndex].text=='Bayar Terkumpul')
    {document.all.idbarcode.style.display='none';}
if (document.form1.selectpay.options[document.form1.selectpay.selectedIndex].text=='Cetak Resit Bayar Terkumpul')
    {document.all.idbarcode.style.display='none';}
if (document.form1.selectpay.options[document.form1.selectpay.selectedIndex].text=='Bayar Terkumpul Rebat')
    {document.all.idbarcode.style.display='none';}
if (document.form1.selectpay.options[document.form1.selectpay.selectedIndex].text=='Cetak Resit Bayar Terkumpul Rebat')
    {document.all.idbarcode.style.display='none';}
}

function display1()
{
if (document.form1.selecttype.options[document.form1.selecttype.selectedIndex].text=='Agen') 
    {document.all.idbarcode.style.display='none';document.all.idagen.style.display='block';} else {document.all.idbarcode.style.display='block';document.all.idagen.style.display='none';}
}

</script>
<body>
    <form id="form1" runat="server">
  <br />
        <table style="width: 90%">
            <tr>
                
      <td colspan="2" style="text-align: center; width: 682px;" bgcolor="#996666"> 
        <strong><span style="color: #ffffff"> 
        <asp:Label ID="title" runat="server"></asp:Label>
        </span></strong></td>
            </tr>
        </table>
        <br />
        <div style="text-align: center">
        <table style="width: 80%; text-align: center">
            <tr>
                <td style="width: 24%; height: 15px; text-align: left">
                    Jenis Pembayaran</td>
                <td style="height: 15px; width: 339px; text-align: left">
                    <asp:DropDownList ID="selectpay" runat="server" OnClick="display();">
                        <asp:ListItem Value="0">Please Select</asp:ListItem>
                        <asp:ListItem Value="Bayar" Selected="True">Bayar</asp:ListItem>
                        <asp:ListItem Value="Bayar Terkumpul">Bayar Terkumpul</asp:ListItem>
                        <asp:ListItem Value="Cetak Resit Bayar Terkumpul">Cetak Resit Bayar Terkumpul</asp:ListItem> 
                        <asp:ListItem Value="Bayar Terkumpul Rebat">Bayar Terkumpul Rebat</asp:ListItem>
                        <asp:ListItem Value="Cetak Resit Bayar Terkumpul Rebat">Cetak Resit Bayar Terkumpul Rebat</asp:ListItem>                       
                    </asp:DropDownList></td>
            </tr>
            <tr style="Display: none; width: 339px; text-align: left" id="idbarcode" runat="server">
                <td style="width: 24%; height: 15px; text-align: left">
                    Barcode</td>
                <td style="width: 339px; height: 15px; text-align: left">
                    <asp:TextBox ID="strBarcode" runat="server" Width="160px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 24%; height: 15px; text-align: left">
                </td>
                <td style="width: 339px; height: 15px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 24%; height: 15px; text-align: left">
                </td>
                <td style="width: 339px; height: 15px; text-align: left">
                    <asp:Button ID="btn_semak" runat="server" Style="border-right: #333333 1px ridge;
                        padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
                        padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
                        border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
                        Text="HANTAR" /></td>
            </tr>
        </table></div>
        <br />
        <table style="width: 90%">
            <tr>
                
      <td colspan="2" style="text-align: center; width: 682px;" bgcolor="#996666"> 
        <strong><span style="color: #ffffff">&nbsp;</span></strong></td>
            </tr>
        </table>
    
    </form>
</body>
</html>
