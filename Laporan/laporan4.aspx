<%@ Page Language="VB" AutoEventWireup="false" CodeFile="laporan4.aspx.vb" Inherits="laporan1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript" src="src/popcalendar.js"></script>
    <link href="../css/bhea2.css" rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>

<script type="text/javascript">

function viewReport()
{	
	
for (i=0;i<document.Form1.rblPilihan.length;i++) {
	if (document.Form1.rblPilihan[i].checked) {
		user_input = document.Form1.rblPilihan[i].value;
	}
}

    
   var myurl;  
   if (user_input =="Harian")
   {
     myurl="crlaporan4.aspx?id=" + user_input  + "&RptH=&Tarikh1="+ document.all.txtTarikh1.value +"&Tarikh2="+ document.all.txtTarikh1.value +"&type=H";
   }
   else if (user_input =="Bulanan")
   {
     myurl="crlaporan4.aspx?id=" + user_input  + "&RptH=&bulan1="+ document.all.txtBulan1.value +"&bulan2="+ document.all.txtBulan2.value +"&type=B";   
   }
   else if (user_input =="Tahunan")
   {
     myurl="crlaporan4.aspx?id=" + user_input  + "&RptH=&Tahun1="+ document.all.txtTahun1.value +"&Tahun2="+ document.all.txtTahun1.value +"&type=T";
   }


}
</script>

<body>
    <form id="Form1" runat="server">
    <div>
            
    <table width="841" border="0" cellpadding="1" cellspacing="1">
      <tr>
        <td colspan="3" style="height: 15px">
            <br />
            <table border="0" cellpadding="0" cellspacing="0" width="938">
                <tr>
                    <td style="width: 11%; height: 12px">
                        Laporan Kad Prepaid</td>
                    <td bgcolor="#006699" style="height: 12px" width="73%">
                        &nbsp;</td>
                </tr>
            </table>
            <br />
            Senarai Smart Card ( Ganti / Batal ) Report</td>
                </tr>
                <tr>
                    <td width="36">&nbsp;</td>
                    <td width="194" style="width: 29px">
                            <asp:RadioButtonList id="rblPilihan" runat="server" AutoPostBack="true" Width="129px" RepeatLayout="Flow" onSelectedIndexChanged="pilihanReload">
                                <asp:ListItem Value="Harian" Selected="True">Harian&#160;&#160;&#160;&#160;</asp:ListItem>
                                <asp:ListItem Value="Bulanan">Bulanan&#160;&#160;&#160;&#160;</asp:ListItem>
                                <asp:ListItem Value="Tahunan">Tahunan</asp:ListItem>
                            </asp:RadioButtonList>
                        &nbsp;&nbsp;&nbsp;</td>
                    <td width="601" style="width: 312px">
                        <asp:Panel ID="PanelSpesis" runat="server" Height="20px" Width="350px">
                        </asp:Panel>
                        <asp:Panel ID="PanelPasar" runat="server" Height="20px" Width="350px">
                        </asp:Panel>
                        <asp:Panel ID="PanelHarian" runat="server" Height="50px" Width="350px">
                        <table border="0" style="width: 350px" id="TABLE1">
                            <tr>
                                <td style="width: 110px; height: 36px;">
                                        <asp:Label ID="lblTarikh1" runat="server" Width="100px">Bagi Tarikh :</asp:Label></td>
                                <td style="width: 232px; height: 36px">
                                    <asp:TextBox ID="txtTarikh1" runat="server" Width="120px" EnableViewState="False"></asp:TextBox>
                                    <asp:Button id="dtButton1" style="BORDER-LEFT-COLOR: white; BACKGROUND-IMAGE: url(img/calendar.jpg); BORDER-BOTTOM-COLOR: white; CURSOR: hand; BORDER-TOP-STYLE: none; BORDER-TOP-COLOR: white; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BACKGROUND-COLOR: white; BORDER-RIGHT-COLOR: white; BORDER-BOTTOM-STYLE: none" tabIndex="1" runat="server" Width="15" Text="  " EnableViewState="False" Height="18"></asp:Button>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTarikh1"
                                        Display="None" ErrorMessage="Bagi Tarikh Wajib Diisi"></asp:RequiredFieldValidator></td>
                            </tr>
                        </table>
                        </asp:Panel>
                        <asp:Panel ID="PanelBulanan" runat="server" Height="50px" Width="350px">
                            <table border="0" style="width: 350px">
                                <tr>
                                    <td style="width: 110px" >
                                            <asp:Label ID="lblBulan" runat="server" Width="100px">Bagi Bulan :</asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtBulan1" runat="server" Width="120px" EnableViewState="False"></asp:TextBox>
                                        <asp:Button ID="dtButton3" style="BORDER-LEFT-COLOR: white; BACKGROUND-IMAGE: url(img/calendar.jpg); BORDER-BOTTOM-COLOR: white; CURSOR: hand; BORDER-TOP-STYLE: none; BORDER-TOP-COLOR: white; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BACKGROUND-COLOR: white; BORDER-RIGHT-COLOR: white; BORDER-BOTTOM-STYLE: none" tabIndex="1" runat="server" Width="15" Text="  " EnableViewState="False" Height="18"></asp:Button>
                                        to &nbsp;&nbsp;<br />
                                        <asp:TextBox ID="txtBulan2" runat="server" EnableViewState="False" Width="120px"></asp:TextBox>
                                        <asp:Button ID="dtButton4" runat="server" EnableViewState="False" Height="18" Style="border-left-color: white;
                                            background-image: url(img/calendar.jpg); border-bottom-color: white; cursor: hand;
                                            border-top-style: none; border-top-color: white; border-right-style: none; border-left-style: none;
                                            background-color: white; border-right-color: white; border-bottom-style: none"
                                            TabIndex="1" Text="  " Width="15" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBulan1" 
                                            Display="None" ErrorMessage="Bagi Bulan Wajib Diisi" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtBulan2"
                                            Display="None" ErrorMessage="Bagi Bulan Wajib Diisi" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="PanelTahunan" runat="server" Height="50px" Width="350px">
                            <table border="0" style="width: 350px">
                                <tr>
                                    <td style="width: 110px" >
                                        <asp:Label id="lblTahunan" runat="server" Width="100px">Bagi Tahun :</asp:Label></td>
                                    <td>
                                        <asp:TextBox id="txtTahun1" runat="server" Width="120px" EnableViewState="False"></asp:TextBox> 
                                        <asp:Button id="dtButton5" style="BORDER-LEFT-COLOR: white; BACKGROUND-IMAGE: url(img/calendar.jpg); BORDER-BOTTOM-COLOR: white; CURSOR: hand; BORDER-TOP-STYLE: none; BORDER-TOP-COLOR: white; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BACKGROUND-COLOR: white; BORDER-RIGHT-COLOR: white; BORDER-BOTTOM-STYLE: none" tabIndex="1" runat="server" Width="15" Text="  " EnableViewState="False" Height="18"></asp:Button>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtTahun1" 
                                            Display="None" ErrorMessage="Bagi Tahun Wajib Diisi" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                                </tr>
                            </table>
                        </asp:Panel>                        
                    </td>
               </tr>
                <tr>
                    <td style="height: 35px">&nbsp;</td>
                    <td align="left" colspan="2">
                    <asp:Button ID="redisplay" runat="server" Style="border-right: #333333 1px ridge; padding-right: 1px;
            border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px; padding-bottom: 1px;
            border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge;
            font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1" Text="Papar Laporan" OnClientClick="viewReport()" /><input id="Button2" onclick="location.href='Laporankad.aspx' " Style="border-right: #333333 1px ridge; padding-right: 1px;
            border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px; padding-bottom: 1px;
            border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge;
            font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1" type="button" value="Menu Laporan" />
                                        
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                            ShowSummary="False" Width="272px" />
                    </td>
                </tr>
         </table>        
        </div>
    </form>
</body>
</html>
