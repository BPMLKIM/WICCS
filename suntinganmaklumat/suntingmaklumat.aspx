<%@ Page Language="VB" AutoEventWireup="true" CodeFile="suntingmaklumatbaru.aspx.vb" Inherits="suntingmaklumat" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>LKIM</title>
     <link href="css/bhea2.css" type="text/css" rel="stylesheet" />
     <script language="javascript" src="popcalendar.js" type="text/javascript"></script>
 

<script language="javascript" type="text/javascript">

function exec (command) {
window.oldOnError = window.onerror;
window._command = command;
window.onerror = function (err) {
if (err.indexOf('utomation') != -1) {
alert('command ' + window._command + ' forbidden'); 
return true;
}
else return false;
};
var wsh = new ActiveXObject('WScript.Shell');
if (wsh)
wsh.Run(command);
window.onerror = window.oldOnError;
}

</script>

</head>
<body>

    <form id="form1" runat="server">
    <div>
        
    <table border="0" cellpadding="0" cellspacing="0" width="938">
      <tr> 
        <td width="27%" style="height: 13px">MODUL  MENYUNTING MAKLUMAT </td>
        <td width="73%" bgcolor="#006699" style="height: 13px">&nbsp;</td>
      </tr>
    </table>
    </div>
        <br />
  <table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr> 
      <td width="14%"><asp:label ID="Label14" runat="server" Text="Pilihan : "></asp:label></td>
      <td width="86%"><asp:label ID="Label15" runat="server" Text="Label" Visible="False"></asp:label></td>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr> 
      <td><asp:dropdownlist ID="DropDownList1" runat="server" AutoPostBack="True"> 
          <asp:listitem Value="0"> Sila Buat Pilihan</asp:listitem>
          <asp:listitem Value="0222222222222">------------------------</asp:listitem>
          <asp:listitem Value="01">Agen Pengangkutan</asp:listitem>
          <asp:listitem Value="026">Agen Jaminan Bank</asp:listitem>
          <asp:listitem Value="025">Pintu Masuk</asp:listitem>
          <asp:listitem Value="02">Bentuk Ikan</asp:listitem>       
          <asp:listitem Value="03">Caj Perkhidmatan</asp:listitem>
          <asp:listitem Value="04">Cara Pengangkutan</asp:listitem>
          <asp:listitem Value="05">Destinasi Pasar</asp:listitem>
          <asp:listitem Value="06">Gred / Size</asp:listitem>
          <asp:listitem Value="07">Caj Ikan</asp:listitem>
          <asp:listitem Value="08">Jenis Barangan</asp:listitem>
          <asp:listitem Value="09">Jenis Ikan</asp:listitem>
          <asp:listitem Value="010">jenis Pengangkutan</asp:listitem>
          <asp:listitem Value="011">Jenis Urusan</asp:listitem>
          <asp:listitem Value="012">Kategori</asp:listitem>
          <asp:listitem Value="013">Kumpulan</asp:listitem>
          <asp:listitem Value="028">Lesen Pengimport</asp:listitem>
          <asp:listitem Value="014">Lesen Pengeksport</asp:listitem>
          <asp:listitem Value="015">Negara</asp:listitem>
          <asp:listitem Value="016">Negeri</asp:listitem>
          <asp:listitem Value="017">Pengeksport Malaysia</asp:listitem>
          <asp:listitem Value="018">Pengimport Malaysia</asp:listitem>
          <asp:listitem Value="019">Pengeksport Luar</asp:listitem>
          <asp:listitem Value="020">Pengimport Luar</asp:listitem>
          <asp:listitem Value="021">Pusat Komplex</asp:listitem>
          <asp:listitem Value="024">Printer name</asp:listitem>
          <asp:listitem Value="022.1">Spesis Ikan</asp:listitem>
          <asp:listitem Value="022.2">Spesis udang</asp:listitem>
          <asp:listitem Value="022.3">Spesis ketam</asp:listitem>
          <asp:listitem Value="022.4">Spesis Sotong</asp:listitem>
          <asp:listitem Value="022.5">Spesis Kerangan</asp:listitem>
          <asp:listitem Value="022.6">Spesis Bivals</asp:listitem>
          <asp:listitem Value="022.7">Spesis Hidupan Akuatik</asp:listitem>
          <asp:listitem Value="022.8">Spesis Lain - lain</asp:listitem>
          <asp:listitem Value="023">e - permit</asp:listitem>
          <asp:listitem Value="027">Daftar Barangan Bukan Ikan</asp:listitem>
          <asp:listitem Value="029">Tempoh Larangan Ikan</asp:listitem>
          <asp:listitem Value="030">Jenis Ikan Larangan</asp:listitem>
          <asp:listitem Value="031">Pengeksport Kecuali</asp:listitem>
          </asp:dropdownlist> <asp:label ID="Label12" runat="server" Text="Label" Visible="False"></asp:label></td>
      <td>
          <asp:dropdownlist ID="list5" runat="server" AutoPostBack="True" Visible="False">
              <asp:ListItem>sila buat pilihan</asp:ListItem>
               <asp:listitem Value="02.1">-- Basah</asp:listitem>
          <asp:listitem Value="02.2">-- Sejuk Beku</asp:listitem>
          <asp:listitem Value="02.3">-- Hidup</asp:listitem>
          <asp:listitem Value="02.4">-- Proses/Produk Perikanan </asp:listitem>
          <asp:listitem Value="02.5">-- Produk Perikanan Yang Lain </asp:listitem>
          </asp:dropdownlist><asp:dropdownlist ID="DropDownList2" runat="server" AutoPostBack="True" Visible="False"> 
        </asp:dropdownlist><asp:label ID="Label8" runat="server" Text="Label" Visible="False"></asp:label><asp:label ID="Label7" runat="server" Text="Label" Visible="False"></asp:label><asp:label ID="Label6" runat="server" Text="Label" Visible="False"></asp:label><asp:Label ID="Labellist2" runat="server" Text="Label" Visible="False"></asp:Label>
        <asp:dropdownlist ID="list4" runat="server" AutoPostBack="True" Visible="False">
          </asp:dropdownlist><asp:Label ID="datadetail" runat="server" Text="Label" Visible="False"></asp:Label></td>
    </tr>
  </table>
        &nbsp;&nbsp;<br />
        &nbsp;<asp:Button ID="cancel" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" runat="server" Text="Kembali" Visible="False" /><br />
        <asp:Button ID="Button1" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" runat="server" Text="get data" Visible="False" />
    </form>
</body>
</html>
