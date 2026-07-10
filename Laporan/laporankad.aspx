<%@ Page Language="VB" AutoEventWireup="true" CodeFile="suntingmaklumatbaru.aspx.vb" Inherits="suntingmaklumat" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>LKIM - BUKIT KAYU HITAM</title>
     <link href="css/bhea2.css" type="text/css" rel="stylesheet" />
     <script language="javascript" src="popcalendar.js" type="text/javascript"></script>
 
 
</head>
<body style="font-size: 12pt">
    <form id="form1" runat="server">
    <div>
        <br />
        
    <table border="0" cellpadding="0" cellspacing="0" width="938">
      <tr> 
        <td style="height: 13px; width: 11%;">
            <span style="font-size: 8pt; font-family: Arial;">Laporan Kad Prepaid</span></td>
        <td width="73%" bgcolor="#006699" style="height: 13px">&nbsp;</td>
      </tr>
    </table>
    </div>
        <br />
  <table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr> 
      <td width="14%"></td>
      <td width="86%"><asp:label ID="Label15" runat="server" Text="Label" Visible="False"></asp:label></td>
    </tr>
    <tr> 
      <td><asp:dropdownlist ID="DropDownList1" runat="server" AutoPostBack="True"> 
          <asp:listitem Value="0"> Sila Buat Pilihan</asp:listitem>
          <asp:listitem Value="0222222222222">------------------------</asp:listitem>
          <asp:listitem Value="01">Log Pergerakan Kenderaan Keluar Masuk Kompleks Report</asp:listitem>
          <asp:listitem Value="02">Log Transaksi Smart Card Report</asp:listitem>
          <asp:listitem Value="03">Log Pembelian Smart Card Report</asp:listitem>
          <asp:listitem Value="04">Senarai Smart Card Report (batal/ganti)</asp:listitem> 
          <asp:listitem Value="05">Log Palang Gate Automatik</asp:listitem>      
         
        </asp:dropdownlist> <asp:label ID="Label12" runat="server" Text="Label" Visible="False"></asp:label></td>
      <td>
          <asp:dropdownlist ID="list5" runat="server" AutoPostBack="True" Visible="False">
              <asp:ListItem>sila buat pilihan</asp:ListItem>
               <asp:listitem Value="02.1">-- Basah</asp:listitem>
          <asp:listitem Value="02.2">-- Sejuk Beku</asp:listitem>
          <asp:listitem Value="02.3">-- Hidup</asp:listitem>
          <asp:listitem Value="02.4">-- Proses/Produk Perikanan </asp:listitem>
          <asp:listitem Value="02.5">-- Produk Perikanan Yang Lain </asp:listitem>
          </asp:DropDownList><asp:dropdownlist ID="DropDownList2" runat="server" AutoPostBack="True" Visible="False"> 
        </asp:dropdownlist><asp:label ID="Label8" runat="server" Text="Label" Visible="False"></asp:label><asp:label ID="Label7" runat="server" Text="Label" Visible="False"></asp:label><asp:label ID="Label6" runat="server" Text="Label" Visible="False"></asp:label><asp:Label ID="Labellist2" runat="server" Text="Label" Visible="False"></asp:Label><asp:dropdownlist ID="list4" runat="server" AutoPostBack="True" Visible="False">
          </asp:DropDownList><asp:Label ID="datadetail" runat="server" Text="Label" Visible="False"></asp:Label></td>
    </tr>
  </table>
        &nbsp;&nbsp;<br />
        &nbsp;<br />
        <br />
        <br />
        <br />
        &nbsp;
  &nbsp;&nbsp;<br />
        <br />
        <br />
        <br />
        &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;<br />
    </form>
</body>
</html>
