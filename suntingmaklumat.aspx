<%@ Page Language="VB" AutoEventWireup="true" CodeFile="suntingmaklumat.aspx.vb" Inherits="suntingmaklumat" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>LKIM - BUKIT KAYU HITAM</title>
     <link href="css/bhea2.css" type="text/css" rel="stylesheet" />
     <script language="javascript" src="popcalendar.js" type="text/javascript"></script>
 
 <script language="javascript" type="text/javascript">
 
     function maskKeyPress(objEvent)
{
    var iKeyCode; 
    iKeyCode = objEvent.keyCode;              
    if (iKeyCode>=48 && iKeyCode<=57) 
    {
    return true;
    }
    else if (iKeyCode == 45) {
    return true;
    }
    else {
    return false;
    }
 }

function validateInt1()
{
    var TextBox9; 
    TextBox9 = parseFloat(document.form1.TextBox9.value); if ( isNaN(TextBox9) || (TextBox9 % 1 != 0) ) { document.form1.TextBox9.value = 0; } 
    var textbox4; 
    TextBox4 = parseFloat(document.form1.TextBox4.value); if ( isNaN(TextBox4) || (TextBox4 % 1 != 0) ) { document.form1.TextBox4.value = 0; } 
    calculate1();
 }
function calculate1() 
{
    var tbTextBox9 = parseFloat(document.form1.TextBox9.value);
    var tbTextBox4 = parseFloat(document.form1.TextBox4.value);
    document.form1.TextBox10.value = parseInt(tbTextBox9) + parseInt(tbTextBox4);
    }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
    <table border="0" cellpadding="0" cellspacing="0" width="938">
      <tr> 
        <td width="27%" style="height: 13px">M O D U L &nbsp;&nbsp;M E N Y U N T I N G &nbsp;&nbsp;M 
          A K U L U M A T </td>
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
          <asp:listitem Value="0">Please Select</asp:listitem>
          <asp:listitem Value="0222222222222">------------------------</asp:listitem>
          <asp:listitem Value="01">Agen Pengankutan</asp:listitem>
          <asp:listitem Value="02">Bentuk Ikan</asp:listitem>
          <asp:listitem Value="02.1">-- Basah</asp:listitem>
          <asp:listitem Value="02.2">-- Sejuk Beku</asp:listitem>
          <asp:listitem Value="02.3">-- Hidup</asp:listitem>
          <asp:listitem Value="02.4">-- Proses/Produk Perikanan </asp:listitem>
          <asp:listitem Value="02.5">-- Produk Perikanan Yang Lain </asp:listitem>
          <asp:listitem Value="03">Caj Perkhidmatan</asp:listitem>
          <asp:listitem Value="04">Cara Pengangkutan</asp:listitem>
          <asp:listitem Value="05">Destinasi Pasar</asp:listitem>
          <asp:listitem Value="06">Gred / Size</asp:listitem>
          <asp:listitem Value="07">Caj Ikan</asp:listitem>
          <asp:listitem Value="08">Jenis Barangan</asp:listitem>
          <asp:listitem Value="09">Jenis Ikan</asp:listitem>
          <asp:listitem Value="010">jenis Pengankutan</asp:listitem>
          <asp:listitem Value="011">Jenis Urusan</asp:listitem>
          <asp:listitem Value="012">Kategori</asp:listitem>
          <asp:listitem Value="013">Kumpulan</asp:listitem>
          <asp:listitem Value="014">Lesen</asp:listitem>
          <asp:listitem Value="015">Negara</asp:listitem>
          <asp:listitem Value="016">Negeri</asp:listitem>
          <asp:listitem Value="017">Pengeksport Malaysia</asp:listitem>
          <asp:listitem Value="018">Pengimport Malaysia</asp:listitem>
          <asp:listitem Value="019">Pengeksport Thailand</asp:listitem>
          <asp:listitem Value="020">Pengimport Thailand</asp:listitem>
          <asp:listitem Value="021">Pusat Komplex</asp:listitem>
          <asp:listitem Value="022">Spesis</asp:listitem>
          <asp:listitem Value="022.1">-- Ikan</asp:listitem>
          <asp:listitem Value="022.2">-- udang</asp:listitem>
          <asp:listitem Value="022.3">-- ketam</asp:listitem>
          <asp:listitem Value="022.4">-- Sotong</asp:listitem>
          <asp:listitem Value="022.5">-- Kerangan</asp:listitem>
          <asp:listitem Value="022.6">-- Bivals</asp:listitem>
          <asp:listitem Value="022.7">-- Hidupan Akuatik</asp:listitem>
          <asp:listitem Value="022.8">-- Lain - lain</asp:listitem>
          <asp:listitem Value="023">e - permit</asp:listitem>
        </asp:dropdownlist> <asp:label ID="Label12" runat="server" Text="Label" Visible="False"></asp:label></td>
      <td><asp:dropdownlist ID="DropDownList2" runat="server" AutoPostBack="True" Visible="False"> 
        </asp:dropdownlist> <asp:label ID="Label8" runat="server" Text="Label" Visible="False"></asp:label> <asp:label ID="Label7" runat="server" Text="Label" Visible="False"></asp:label> <asp:label ID="Label6" runat="server" Text="Label" Visible="False"></asp:label> 
          <asp:Label ID="Labellist2" runat="server" Text="Label" Visible="False"></asp:Label>
          &nbsp;&nbsp;&nbsp;</td>
    </tr>
  </table>
  &nbsp;&nbsp; <br />
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="width: 112px; height: 13px">
                    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label></td>
                <td style="height: 13px">
                    <asp:TextBox ID="TextBox1" runat="server" Visible="False" Width="300px"></asp:TextBox>
                    <asp:TextBox ID="TextBox6" runat="server" Visible="False" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 112px; height: 13px">
                    <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label></td>
                <td style="height: 13px">
                    <asp:TextBox ID="TextBox2" runat="server" Visible="False" Width="300px"></asp:TextBox>
                    <asp:TextBox ID="TextBox7" runat="server" Visible="False" Width="300px"></asp:TextBox>
                    <input runat="server" visible="False" id="calender1" class="textbox" name="choose2" onclick="popUpCalendar(this, TextBox7, 'mm/dd/yyyy')"
                        style="border-left-color: white; background-image: url(calendar.jpg); border-bottom-color: white;
                        width: 15px; cursor: hand; border-top-style: none; border-top-color: white; border-right-style: none;
                        border-left-style: none; height: 18px; background-color: white; border-right-color: white;
                        border-bottom-style: none" type="button" value=" " /></td>
            </tr>
            <tr>
                <td style="width: 112px; height: 13px">
                    <asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label></td>
                <td style="height: 13px">
                    <asp:TextBox ID="TextBox3" runat="server" Visible="False" Width="300px"></asp:TextBox>
                    <asp:TextBox ID="TextBox8" runat="server" Visible="False" Width="300px"></asp:TextBox>
                    <input runat="server" visible="False" id="calender2" class="textbox" name="choose2" onclick="popUpCalendar(this, TextBox8, 'mm/dd/yyyy')"
                        style="border-left-color: white; background-image: url(calendar.jpg); border-bottom-color: white;
                        width: 15px; cursor: hand; border-top-style: none; border-top-color: white; border-right-style: none;
                        border-left-style: none; height: 18px; background-color: white; border-right-color: white;
                        border-bottom-style: none" type="button" value=" " /></td>
            </tr>
            <tr>
                <td style="width: 112px; height: 13px">
                    <asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label></td>
                <td style="height: 13px">
                    <asp:TextBox ID="TextBox4" runat="server" Visible="False" Width="300px"></asp:TextBox>
                    <asp:DropDownList ID="DropDownList3" runat="server" Visible="False">
                        <asp:ListItem Value="0">-- Please Select --</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem Value="2">No</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 112px; height: 11px">
                    <asp:Label ID="Label5" runat="server" Text="Label" Visible="False"></asp:Label></td>
                <td style="height: 11px">
                    <asp:TextBox ID="TextBox5" runat="server" Visible="False" Width="300px"></asp:TextBox>
                    <input runat="server" visible="False" id="calender3" class="textbox" name="choose2" onclick="popUpCalendar(this, TextBox5, 'mm/dd/yyyy')"
                        style="border-left-color: white; background-image: url(calendar.jpg); border-bottom-color: white;
                        width: 15px; cursor: hand; border-top-style: none; border-top-color: white; border-right-style: none;
                        border-left-style: none; height: 18px; background-color: white; border-right-color: white;
                        border-bottom-style: none" type="button" value=" " /></td>
            </tr>
            <tr>
                <td style="width: 112px; height: 11px">
                    <asp:Label ID="Label9" runat="server" Text="Label" Visible="False"></asp:Label></td>
                <td style="height: 11px">
                    <asp:TextBox ID="TextBox9" runat="server" Visible="False" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 112px; height: 11px">
                    <asp:Label ID="Label10" runat="server" Text="Label" Visible="False"></asp:Label></td>
                <td style="height: 11px">
                    <asp:TextBox ID="TextBox10" runat="server" Visible="False" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 112px; height: 11px">
                    <asp:Label ID="Label11" runat="server" Text="Label" Visible="False"></asp:Label></td>
                <td style="height: 11px">
                    <asp:TextBox ID="TextBox11" runat="server" Visible="False" Width="300px"></asp:TextBox></td>
            </tr>
        </table>
        <br />
        &nbsp;<asp:Button ID="add" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" runat="server" Text="Add" Visible="False" /><asp:Button ID="add_deposit" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" runat="server" Text="Add Current Deposit" Visible="False" /><asp:Button ID="save" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" runat="server" Text="Update Record" Visible="False" /><asp:Button ID="save1" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" runat="server" Text="Save" Visible="False" /><asp:Button ID="saveadd" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" runat="server" Text="Save" Visible="False" /><asp:Button ID="delete" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" runat="server" Text="Delete" Visible="False" /><asp:Button ID="view" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" runat="server" Text="View Table" Visible="False" /><asp:Button ID="cancel" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" runat="server" Text="Back" Visible="False" /><asp:Button ID="back2" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" runat="server" Text="Back" Visible="False" /><br />
        <br />
        <asp:Label ID="Label13" runat="server" Text="Label" Visible="False"></asp:Label><br />
        <br />
        <asp:GridView ID="GridView1" runat="server" Visible="False" GridLines="None" CellPadding="3" AllowSorting="True" EnableTheming="True">
            <RowStyle BorderStyle="None" />
            <EditRowStyle BorderStyle="None" />
            <HeaderStyle BorderStyle="None" />
            <AlternatingRowStyle BackColor="#FFE0C0" BorderStyle="Dotted" />
        </asp:GridView>
        &nbsp;<br />
    </form>
</body>
</html>
