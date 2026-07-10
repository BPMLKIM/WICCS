<%@ Page Language="VB" AutoEventWireup="false" CodeFile="sistemq.aspx.vb" Inherits="sistemq" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>SISTEM ICCS - BUKIT KAYU HITAM</title>
    <link href="css/bhea2.css" type="text/css" rel="stylesheet" />
    <script language="javascript" src="popcalendar.js" type="text/javascript"></script>
</head>
<script language="javascript" type="text/javascript">

function printReport()
{
winTitle = "Salinan Sistem Q";
nama = "<%=Session("namaPegawai") %>";
jawatan = "<%=Session("jobtitle") %>";
str ="sistem_q_report.aspx?item=1&tarikhmasa="+ document.all.datefrom.value +"&tarikhmasa2="+document.all.dateto.value +"&pilihan="+document.all.DropDownList1.value+"&SalinanMs="+ escape(winTitle)+"&SalinanMs2="+ escape(nama)+"&SalinanMs3="+ escape(jawatan);
window.open(str,'LKIM','');
}
</script>
<body>

  <span id="clock"></span>
      <form id="form1" runat="server">
       <div>
        <table border="0" cellpadding="0" cellspacing="0" width="938">
        <tr>
                <td style="height: 13px; width: 15%;">
                    M O D U L &nbsp; &nbsp; &nbsp;P E M A N T U A N&nbsp;</td>
                <td bgcolor="#006699" style="height: 13px" width="73%">
                    &nbsp;</td>
            </tr>
        </table>    
    </div>
        <br />
        Senarai Pilihan<br />
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" CausesValidation="True"><asp:ListItem>Sila buat pilihan</asp:ListItem>
<asp:ListItem Selected="True">Import</asp:ListItem>
<asp:ListItem>Eksport</asp:ListItem>
<asp:ListItem>Transit</asp:ListItem>
<asp:ListItem>Barangan Bukan Ikan</asp:ListItem>
            <asp:ListItem>Semua</asp:ListItem>
</asp:DropDownList>
        <asp:Label ID="Label1" runat="server" Text="Import" Visible="False"></asp:Label>&nbsp;&nbsp;<br>
        <br>
        <asp:RadioButton ID="specific" runat="server" Text="Specific" Visible="False" />
        <asp:TextBox ID="dated" runat="server" Width="60px" Visible="False"></asp:TextBox>
        <input style="border-left-color: white; background-image: url(calendar.jpg); border-bottom-color: white; width: 15px; cursor: hand; border-top-style: none; border-top-color: white; border-right-style: none; border-left-style: none; height: 18px; background-color: white; border-right-color: white; border-bottom-style: none" class="textbox" id="calender3" name="choose2" onclick="popUpCalendar(this, dated, 'mm/dd/yyyy')" runat="server" type="button" value=" " visible="false"><asp:RadioButton
                ID="range" runat="server" Text="Range" /><asp:TextBox ID="datefrom" runat="server" Width="60px"></asp:TextBox>
        <input style="border-left-color: white; background-image: url(calendar.jpg); border-bottom-color: white; width: 15px; cursor: hand; border-top-style: none; border-top-color: white; border-right-style: none; border-left-style: none; height: 18px; background-color: white; border-right-color: white; border-bottom-style: none" class="textbox" id="calender1" name="choose2" onclick="popUpCalendar(this, datefrom, 'dd/mm/yyyy')" runat="server" type="button" value=" " visible="true">&nbsp; To&nbsp;&nbsp;
        <asp:TextBox ID="dateto" runat="server" Width="60px"></asp:TextBox>
        <input
            id="calender2" runat="server" class="textbox" name="choose2" onclick="popUpCalendar(this, dateto, 'dd/mm/yyyy')"
            style="border-left-color: white; background-image: url(calendar.jpg); border-bottom-color: white;
            width: 15px; cursor: hand; border-top-style: none; border-top-color: white; border-right-style: none;
            border-left-style: none; height: 18px; background-color: white; border-right-color: white;
            border-bottom-style: none" type="button" value=" " visible="true" />&nbsp;&nbsp;<br />
        <br />
        <asp:Button ID="query" runat="server" Style="border-right: #333333 1px ridge; padding-right: 1px;
            border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px; padding-bottom: 1px;
            border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge;
            font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1" Text="Query / Terkini" /><asp:Button ID="Button1" runat="server" Style="border-right: #333333 1px ridge; padding-right: 1px;
            border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px; padding-bottom: 1px;
            border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge;
            font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1" Text="Terkini" Visible="False" /><input id="Cetak" type="button" validation="true" value="Cetak" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" onclick="printReport();"  /><asp:Button
                    ID="reset" runat="server" Style="border-right: #333333 1px ridge; padding-right: 1px;
                    border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px; padding-bottom: 1px;
                    border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge;
                    font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1" Text="Reset" CausesValidation="False" /><asp:Button ID="cetak" runat="server" Text="Cetak" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" Visible="False"/><br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Senarai Import Terkini :"></asp:Label><br />
        &nbsp;&nbsp;
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <asp:DataGrid ID="DataGrid1" runat="server" AllowPaging="True" AllowSorting="True" CellPadding="4" Font-Bold="False"
            Font-Italic="False" Font-Overline="False" Font-Size="Small" Font-Strikeout="False"
            Font-Underline="False" GridLines="None" OnPageIndexChanged="DataGrid1_PageIndexChanged" Width="100%" ForeColor="#333333" Height="22px" Visible="False">
            <FooterStyle BackColor="#5D7B9D" Font-Size="8pt" ForeColor="White" Font-Bold="True" /><EditItemStyle BackColor="#999999" />
                <SelectedItemStyle BackColor="WhiteSmoke" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#284775" BorderColor="Black" Font-Names="arial" Font-Size="Small"
                ForeColor="White" HorizontalAlign="Center" Mode="NumericPages" />
                <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                <ItemStyle BackColor="#F7F6F3" Font-Names="arial" Font-Size="8pt" ForeColor="#333333"
                HorizontalAlign="Justify" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" Font-Names="arial" Font-Size="8pt"
                ForeColor="White" HorizontalAlign="Center" />
                <Columns>
                    <asp:TemplateColumn HeaderText="No.">
                        <ItemTemplate>
                            <asp:Label ID="bil" runat="server" Text='<%# Container.ItemIndex+1 + (DataGrid1.PageSize() * DataGrid1.CurrentPageIndex()) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                </Columns>
            </asp:DataGrid><asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Nombor_Barcode" DataSourceID="SqlDataSource1"
                ForeColor="#333333" GridLines="None" Height="22px" Width="100%">
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Height="22px" />
                <Columns>
                    <asp:BoundField DataField="Nombor_Barcode" HeaderText="Nombor_Barcode" ReadOnly="True"
                        SortExpression="Nombor_Barcode" />
                    <asp:BoundField DataField="Tarikh_Masa_Masuk" HeaderText="Tarikh_Masa_Masuk" SortExpression="Tarikh_Masa_Masuk" />
                    <asp:BoundField DataField="No_Kenderaan" HeaderText="No_Kenderaan" SortExpression="No_Kenderaan" />
                    <asp:BoundField DataField="Jenis_Barangan" HeaderText="Jenis_Barangan" SortExpression="Jenis_Barangan" />
                    <asp:BoundField DataField="EntryMasuk_By" HeaderText="EntryMasuk_By" SortExpression="EntryMasuk_By" />
                    <asp:BoundField DataField="Pegawai" HeaderText="Pegawai" SortExpression="Pegawai" />
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                </Columns>
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Height="18px" />
                <EditRowStyle BackColor="#999999" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Height="22px" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
                <br />
                <asp:Timer ID="Timer1" runat="server">
                </asp:Timer>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
                    SelectCommand="SELECT PENDAFTARAN_PINTU.Nombor_Barcode, PENDAFTARAN_PINTU.Tarikh_Masa_Masuk, PENDAFTARAN_PINTU.No_Kenderaan, PENDAFTARAN_PINTU.Jenis_Barangan, PENDAFTARAN_PINTU.EntryMasuk_By, SISTEM_Q.Pegawai, SISTEM_Q.Status FROM PENDAFTARAN_PINTU LEFT OUTER JOIN SISTEM_Q ON PENDAFTARAN_PINTU.Nombor_Barcode = SISTEM_Q.No_Barcode WHERE (PENDAFTARAN_PINTU.Kod_Jenis_Urusan IN ('001', '002', '016')) AND (DAY(SISTEM_Q.Tarikh) = DAY(GETDATE())) AND (MONTH(SISTEM_Q.Tarikh) = MONTH(GETDATE())) AND (YEAR(SISTEM_Q.Tarikh) = YEAR(GETDATE())) ORDER BY PENDAFTARAN_PINTU.Tarikh_Masa_Masuk">
                </asp:SqlDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="datefrom"
              Display="None" ErrorMessage="Kata Laluan"></asp:RequiredFieldValidator><asp:ValidationSummary
                  ID="ValidationSummary1" runat="server" HeaderText="Tarikh Wajib Diisi" ShowMessageBox="True"
                  ShowSummary="False" />
    </form>
  </body>
</html>
