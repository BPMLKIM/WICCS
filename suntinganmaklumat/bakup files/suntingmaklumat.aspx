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
          <asp:listitem Value="02">Bentuk Ikan</asp:listitem>       
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
          <asp:listitem Value="022.1">Spesis Ikan</asp:listitem>
          <asp:listitem Value="022.2">Spesis udang</asp:listitem>
          <asp:listitem Value="022.3">Spesis ketam</asp:listitem>
          <asp:listitem Value="022.4">Spesis Sotong</asp:listitem>
          <asp:listitem Value="022.5">Spesis Kerangan</asp:listitem>
          <asp:listitem Value="022.6">Spesis Bivals</asp:listitem>
          <asp:listitem Value="022.7">Spesis Hidupan Akuatik</asp:listitem>
          <asp:listitem Value="022.8">Spesis Lain - lain</asp:listitem>
          <asp:listitem Value="023">e - permit</asp:listitem>
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
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <br />
        <asp:Label ID="Label13" runat="server" Text="Label" Visible="False"></asp:Label><br />
                <br />
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Kod_Agen_Pengangkutan"
                    DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" ShowFooter="True"
                    Visible="False" Width="100%">
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EmptyDataRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Kod_Agen_Pengangkutan" HeaderText="Kod_Agen_Pengangkutan"
                            ReadOnly="True" SortExpression="Kod_Agen_Pengangkutan" />
                        <asp:BoundField DataField="Nama_Agen_Pengangkutan" HeaderText="Nama_Agen_Pengangkutan"
                            SortExpression="Nama_Agen_Pengangkutan" />
                        <asp:BoundField DataField="Alamat_Agen_Pengangkutan" HeaderText="Alamat_Agen_Pengangkutan"
                            SortExpression="Alamat_Agen_Pengangkutan" />
                        <asp:BoundField DataField="Deposit_Semasa" HeaderText="Deposit_Semasa" SortExpression="Deposit_Semasa" />
                        <asp:BoundField DataField="Transaksi_Semasa" HeaderText="Transaksi_Semasa" SortExpression="Transaksi_Semasa" />
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" CancelText="Batal" DeleteText="Hapus" EditText="Kemaskini" UpdateText="Simpan" />
                    </Columns>
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <EditRowStyle BackColor="#999999" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView><asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Kod_Bentuk_Ikan_1"
                    DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None" ShowFooter="True"
                    Visible="False" Width="100%">
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EmptyDataRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Kod_Bentuk_Ikan_1" HeaderText="Kod Bentuk Ikan Basah"
                            ReadOnly="True" SortExpression="Kod_Bentuk_Ikan_1" />
                        <asp:BoundField DataField="Nama_Bentuk_Ikan_1" HeaderText="Nama Bentuk Ikan basah"
                            SortExpression="Nama_Bentuk_Ikan_1" />
                        <asp:CommandField CancelText="Batal" DeleteText="Hapus" EditText="Kemaskini" ShowDeleteButton="True"
                            ShowEditButton="True" UpdateText="Simpan" />
                    </Columns>
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <EditRowStyle BackColor="#999999" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                <br />
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
                    DeleteCommand="DELETE FROM [AGEN_PENGANGKUTAN] WHERE [Kod_Agen_Pengangkutan] = @Kod_Agen_Pengangkutan"
                    InsertCommand="INSERT INTO [AGEN_PENGANGKUTAN] ([Kod_Agen_Pengangkutan], [Nama_Agen_Pengangkutan], [Alamat_Agen_Pengangkutan], [Deposit_Semasa], [Transaksi_Semasa]) VALUES (@Kod_Agen_Pengangkutan, @Nama_Agen_Pengangkutan, @Alamat_Agen_Pengangkutan, @Deposit_Semasa, @Transaksi_Semasa)"
                    SelectCommand="SELECT [Kod_Agen_Pengangkutan], [Nama_Agen_Pengangkutan], [Alamat_Agen_Pengangkutan], [Deposit_Semasa], [Transaksi_Semasa] FROM [AGEN_PENGANGKUTAN]"
                    UpdateCommand="UPDATE [AGEN_PENGANGKUTAN] SET [Nama_Agen_Pengangkutan] = @Nama_Agen_Pengangkutan, [Alamat_Agen_Pengangkutan] = @Alamat_Agen_Pengangkutan, [Deposit_Semasa] = @Deposit_Semasa, [Transaksi_Semasa] = @Transaksi_Semasa WHERE [Kod_Agen_Pengangkutan] = @Kod_Agen_Pengangkutan">
                    <DeleteParameters>
                        <asp:Parameter Name="Kod_Agen_Pengangkutan" Type="String" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Nama_Agen_Pengangkutan" Type="String" />
                        <asp:Parameter Name="Alamat_Agen_Pengangkutan" Type="String" />
                        <asp:Parameter Name="Deposit_Semasa" Type="Single" />
                        <asp:Parameter Name="Transaksi_Semasa" Type="Single" />
                        <asp:Parameter Name="Kod_Agen_Pengangkutan" Type="String" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Kod_Agen_Pengangkutan" Type="String" />
                        <asp:Parameter Name="Nama_Agen_Pengangkutan" Type="String" />
                        <asp:Parameter Name="Alamat_Agen_Pengangkutan" Type="String" />
                        <asp:Parameter Name="Deposit_Semasa" Type="Single" />
                        <asp:Parameter Name="Transaksi_Semasa" Type="Single" />
                    </InsertParameters>
                </asp:SqlDataSource><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
                    DeleteCommand="DELETE FROM [BENTUK_IKAN_1] WHERE [Kod_Bentuk_Ikan_1] = @Kod_Bentuk_Ikan_1"
                    InsertCommand="INSERT INTO [BENTUK_IKAN_1] ([Kod_Bentuk_Ikan_1], [Nama_Bentuk_Ikan_1]) VALUES (@Kod_Bentuk_Ikan_1, @Nama_Bentuk_Ikan_1)"
                    SelectCommand="SELECT [Kod_Bentuk_Ikan_1], [Nama_Bentuk_Ikan_1] FROM [BENTUK_IKAN_1]"
                    UpdateCommand="UPDATE [BENTUK_IKAN_1] SET [Nama_Bentuk_Ikan_1] = @Nama_Bentuk_Ikan_1 WHERE [Kod_Bentuk_Ikan_1] = @Kod_Bentuk_Ikan_1">
                    <DeleteParameters>
                        <asp:Parameter Name="Kod_Bentuk_Ikan_1" Type="String" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Nama_Bentuk_Ikan_1" Type="String" />
                        <asp:Parameter Name="Kod_Bentuk_Ikan_1" Type="String" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Kod_Bentuk_Ikan_1" Type="String" />
                        <asp:Parameter Name="Nama_Bentuk_Ikan_1" Type="String" />
                    </InsertParameters>
                </asp:SqlDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
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
                    <asp:TextBox ID="TextBox12" runat="server" Visible="False" Width="300px"></asp:TextBox></td>
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
                        border-bottom-style: none" type="button" value=" " />
                    <asp:TextBox ID="TextBox13" runat="server" Visible="False" Width="300px"></asp:TextBox>
                    <asp:DropDownList ID="DropDownList3" runat="server" Visible="False">
                        <asp:ListItem Value="0">-- Sila Buat Pilihan --</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem Value="2">No</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 112px; height: 11px">
                    <asp:Label ID="Label9" runat="server" Text="Label" Visible="False"></asp:Label></td>
                <td style="height: 11px">
                    <asp:TextBox ID="TextBox9" runat="server" Visible="False" Width="300px"></asp:TextBox>
                    <asp:TextBox ID="TextBox14" runat="server" Visible="False" Width="300px"></asp:TextBox>
                    <input runat="server" visible="False" id="calender4" class="textbox" name="choose2" onclick="popUpCalendar(this, TextBox14, 'mm/dd/yyyy')"
                        style="border-left-color: white; background-image: url(calendar.jpg); border-bottom-color: white;
                        width: 15px; cursor: hand; border-top-style: none; border-top-color: white; border-right-style: none;
                        border-left-style: none; height: 18px; background-color: white; border-right-color: white;
                        border-bottom-style: none" type="button" value=" " /></td>
            </tr>
            <tr>
                <td style="width: 112px; height: 11px">
                    <asp:Label ID="Label10" runat="server" Text="Label" Visible="False"></asp:Label></td>
                <td style="height: 11px">
                    <asp:TextBox ID="TextBox10" runat="server" Visible="False" Width="300px"></asp:TextBox>
                    <asp:TextBox ID="TextBox15" runat="server" Visible="False" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 112px; height: 11px">
                    <asp:Label ID="Label11" runat="server" Text="Label" Visible="False"></asp:Label></td>
                <td style="height: 11px">
                    <asp:TextBox ID="TextBox11" runat="server" Visible="False" Width="300px"></asp:TextBox>
                    <asp:TextBox ID="TextBox16" runat="server" Visible="False" Width="300px"></asp:TextBox></td>
            </tr>
        </table>
        <br />
        &nbsp;<asp:Button ID="add" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" runat="server" Text="Tambah" Visible="False" /><asp:Button ID="add_deposit" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" runat="server" Text="Tambah Deposit Semasa" Visible="False" /><asp:Button ID="save" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" runat="server" Text="Kemaskini" Visible="False" /><asp:Button ID="save1" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" runat="server" Text="Simpan" Visible="False" /><asp:Button ID="saveadd" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" runat="server" Text="Simpan" Visible="False" /><asp:Button ID="delete" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" runat="server" Text="Hapus" Visible="False" /><asp:Button ID="view" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" runat="server" Text="Papar Jadual" Visible="False" /><asp:Button ID="cancel" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" runat="server" Text="Kembali" Visible="False" /><asp:Button ID="back2" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" runat="server" Text="kembali" Visible="False" /><br />
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
