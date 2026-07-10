<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Papar_Laporan.aspx.vb" Inherits="Laporan_Papar_Laporan" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript" src="src/popcalendar.js"></script>
    <link href="../css/stylesheet.css" rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form1" runat="server">
    <div>
            <table cellspacing="1" cellpadding="1" border="0">
                <tr><td colspan="3">&nbsp</td>
                </tr>
                <tr>
                    <td>&nbsp</td>
                    <td style="width: 29px">
                            <asp:RadioButtonList id="rblPilihan" runat="server" AutoPostBack="true" Width="129px" RepeatLayout="Flow" onSelectedIndexChanged="pilihanReload">
                                <asp:ListItem Value="Harian" Selected="True">Harian&#160;&#160;&#160;&#160;</asp:ListItem>
                                <asp:ListItem Value="Bulanan">Bulanan&#160;&#160;&#160;&#160;</asp:ListItem>
                                <asp:ListItem Value="Tahunan">Tahunan</asp:ListItem>
                            </asp:RadioButtonList>
                        &nbsp;&nbsp;&nbsp;

                    </td>
                    <td style="width: 312px">
                        <asp:Panel ID="PanelSpesis" runat="server" Height="25px" Width="350px">
                        <table border="0" style="width: 350px" id="TABLE2">
                            <tr>
                                <td style="width: 110px">
                                        <asp:Label ID="Label1" runat="server" Width="100px">Spesis :</asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="DropDownListSpesis" runat="server" DataTextField="Nama_BKH" DataValueField="Nama_BKH">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                        </asp:Panel>
                        <asp:Panel ID="PanelHarian" runat="server" Height="50px" Width="350px">
                        <table border="0" style="width: 350px" id="TABLE1">
                            <tr>
                                <td style="width: 110px">
                                        <asp:Label ID="lblTarikh1" runat="server" Width="100px">Dari Tarikh :</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtTarikh1" runat="server" Width="120px" EnableViewState="False"></asp:TextBox>
                                    <asp:Button id="dtButton1" style="BORDER-LEFT-COLOR: white; BACKGROUND-IMAGE: url(img/calendar.jpg); BORDER-BOTTOM-COLOR: white; CURSOR: hand; BORDER-TOP-STYLE: none; BORDER-TOP-COLOR: white; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BACKGROUND-COLOR: white; BORDER-RIGHT-COLOR: white; BORDER-BOTTOM-STYLE: none" tabIndex="1" runat="server" Width="15" Text="  " EnableViewState="False" Height="18"></asp:Button>
                                    <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtTarikh1" Display="None" ErrorMessage="Hingga Tarikh Wajib Diisi"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td style="width: 110px">
                                        <asp:Label ID="lblTarikh2" runat="server" Width="100px">Hingga Tarikh :</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtTarikh2" runat="server" Width="120px" EnableViewState="False"></asp:TextBox>
                                    <asp:Button id="dtButton2" style="BORDER-LEFT-COLOR: white; BACKGROUND-IMAGE: url(img/calendar.jpg); BORDER-BOTTOM-COLOR: white; CURSOR: hand; BORDER-TOP-STYLE: none; BORDER-TOP-COLOR: white; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BACKGROUND-COLOR: white; BORDER-RIGHT-COLOR: white; BORDER-BOTTOM-STYLE: none" tabIndex="1" runat="server" Width="15" Text="  " EnableViewState="False" Height="18"></asp:Button>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTarikh2"
                                        Display="None" ErrorMessage="Hingga Tarikh Wajib Diisi" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                            </tr>
                        </table>
                        </asp:Panel>
                        <asp:Panel ID="PanelBulanan" runat="server" Height="50px" Width="350px">
                            <table border="0" width="350">
                                <tr>
                                    <td style="width: 110px" >
                                            <asp:Label ID="lblBulan" runat="server" Width="100px">Bagi Bulan :</asp:Label></td>
                                    <td >
                                        <asp:TextBox ID="txtBulan" runat="server" Width="120px" EnableViewState="False"></asp:TextBox>
                                        <asp:Button ID="dtButton3" runat="server" EnableViewState="False" Height="18" Style="border-left-color: white;
                                            background-image: url(img/calendar.jpg); border-bottom-color: white; cursor: hand;
                                            border-top-style: none; border-top-color: white; border-right-style: none; border-left-style: none;
                                            background-color: white; border-right-color: white; border-bottom-style: none"
                                            TabIndex="1" Text="  " Width="15" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBulan"
                                            Display="None" ErrorMessage="Bagi Bulan Wajib Diisi" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td style="width: 110px" >
                                            <asp:Label ID="lblTahun" runat="server" Height="17px" Width="100px">Bagi Tahun :</asp:Label></td>
                                    <td >
                                        <asp:TextBox ID="txtTahun" runat="server" Width="120px" EnableViewState="False"></asp:TextBox>
                                        <asp:Button ID="dtButton4" runat="server" EnableViewState="False" Height="18" Style="border-left-color: white;
                                            background-image: url(img/calendar.jpg); border-bottom-color: white; cursor: hand;
                                            border-top-style: none; border-top-color: white; border-right-style: none; border-left-style: none;
                                            background-color: white; border-right-color: white; border-bottom-style: none"
                                            TabIndex="1" Text="  " Width="15" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTahun"
                                            Display="None" ErrorMessage="Bagi Tahun Wajib Diisi" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="PanelTahunan" runat="server" Height="50px" Width="350px">
                            <table border="0" width="350">
                                <tr>
                                    <td style="width: 110px">
                                        <asp:Label ID="lblTahunan" runat="server" Width="100px">Bagi Tahun :</asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtTahun1" runat="server" Width="120px" EnableViewState="False"></asp:TextBox>
                                        <asp:Button ID="dtButton5" runat="server" EnableViewState="False" Height="18" Style="border-left-color: white;
                                            background-image: url(img/calendar.jpg); border-bottom-color: white; cursor: hand;
                                            border-top-style: none; border-top-color: white; border-right-style: none; border-left-style: none;
                                            background-color: white; border-right-color: white; border-bottom-style: none"
                                            TabIndex="1" Text="  " Width="15" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtTahun1"
                                            Display="None" ErrorMessage="Bagi Tahun Wajib Diisi" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                                </tr>
 
                            </table>
                        </asp:Panel>                    
                    </td>
               </tr>
                <tr>
                    <td>&nbsp</td>
                    <td align="left" colspan="2"><br />    
                    <asp:Button ID="redisplay" runat="server" OnClick="redisplay_Click" Text="Papar Laporan" />
                        <input id="Button2" onclick="location.href='Laporan.aspx'" type="button" value="Menu Laporan">&nbsp;
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                            ShowSummary="False" Width="272px" />
                    </td>
                </tr>
         </table>        
        </div>
    </form>
</body>
</html>
