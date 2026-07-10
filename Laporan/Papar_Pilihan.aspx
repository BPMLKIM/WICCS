<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Papar_Pilihan.aspx.vb" Inherits="Papar_Pilihan" %>

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
            
    <table width="841" border="0" cellpadding="1" cellspacing="1">
      <tr>
        <td colspan="3" style="height: 15px"><br />
          <br />
          <br />
          <br />
        </td>
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
                        <asp:Panel ID="PanelPasar" runat="server" Height="20px" Width="350px">
                            <table border="0" style="width: 350px" id="Table3">
                                <tr>
                                    <td style="width: 110px">
                                        <asp:Label ID="Label2" runat="server" Width="100px">Pasar :</asp:Label></td>
                                    <td>
                                        <asp:DropDownList ID="DropDownListPasar" runat="server" DataTextField="Nama_Pasar" DataValueField="Nama_Pasar">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        
                        <asp:Panel ID="PanelAgen" runat="server" Height="20px" Width="350px">
                            <table border="0" style="width: 350px" id="Table4">
                                <tr>
                                    <td style="width: 110px">
                                        <asp:Label ID="Label3" runat="server" Width="100px">Agen Pengangkutan :</asp:Label></td>
                                    <td>
                                        <asp:DropDownList ID="DropDownListAgen" runat="server" DataTextField="Nama_Agen_Pengangkutan" DataValueField="Nama_Agen_Pengangkutan">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        
                        <asp:Panel ID="PanelHarian" runat="server" Height="50px" Width="350px">
                        <table border="0" style="width: 350px" id="TABLE1">
                            <tr>
                                <td style="width: 110px">
                                        <asp:Label ID="lblTarikh1" runat="server" Width="100px">Bagi Tarikh :</asp:Label></td>
                                <td>
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
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBulan1" 
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
                    <td align="left" colspan="2"><br />    
                    <asp:Button ID="redisplay" runat="server" OnClick="redisplay_Click" Text="Papar Laporan" />
                        <% If Request("id") < 19 Then%>
                            <input id="Button2" onclick="location.href='Laporan.aspx?sub_module_id=36'" type="button" value="Menu Laporan" />&nbsp;
                        <% elseIf Request("id") >= 21 And Request("id") <= 32 Then%>
                            <input id="Button1" onclick="location.href='Laporan.aspx?sub_module_id=38'" type="button" value="Menu Laporan" />&nbsp;                           
                        <% elseIf Request("id") >= 34 And Request("id") <= 45 Then%>
                            <input id="Button3" onclick="location.href='Laporan.aspx?sub_module_id=39'" type="button" value="Menu Laporan" />&nbsp;                           
                        <% ElseIf Request("id") >= 48 And Request("id") <= 54 Then%>
                            <input id="Button4" onclick="location.href='Laporan.aspx?sub_module_id=41'" type="button" value="Menu Laporan" />&nbsp;                           
                        <% ElseIf Request("id") = 501 Then%>
                            <input id="Button6" onclick="location.href='Laporan.aspx?sub_module_id=41'" type="button" value="Menu Laporan" />&nbsp;                          
                        <% ElseIf Request("id") >= 64 Then%>
                            <input id="Button5" onclick="location.href='Laporan.aspx?sub_module_id=42'" type="button" value="Menu Laporan" />&nbsp;                           
                        <% End If%>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                            ShowSummary="False" Width="272px" />
                    </td>
                </tr>
         </table>        
        </div>
    </form>
</body>
</html>
