<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SalinanSKPI_MsSheet_kibfg.aspx.vb" Inherits="Laporan_Papar_Laporan_kibfg" %>

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
                        &nbsp; &nbsp;&nbsp;
                        <asp:RadioButtonList ID="pilihan" runat="server">
                            <asp:ListItem Selected="True">SLIP REBAT</asp:ListItem>
                            <asp:ListItem>MasterSheet</asp:ListItem>
                        </asp:RadioButtonList></td>
                    <td style="width: 440px">
                        &nbsp; &nbsp;&nbsp;&nbsp;
                        <table id="TABLE1" border="0" style="width: 433px">
                            <tr>
                                <td style="width: 159px">
                                    <asp:Label ID="lblNoBarcode" runat="server" Width="117px" style="text-align: right">No. Barcode :</asp:Label></td>
                                <td style="width: 368px">
                                    <asp:TextBox ID="txtNoBarcode" runat="server" EnableViewState="False" Width="120px"></asp:TextBox>&nbsp;
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNoBarcode"
                                        Display="None" ErrorMessage="No. Barcode Wajib Diisi"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td style="width: 159px; height: 23px;">
                                    <asp:Label ID="lblNoSKPI" runat="server" Width="100px" visible="False">No. SKPIE :</asp:Label></td>
                                <td style="width: 368px; height: 23px">
                                    <asp:TextBox ID="txtNoSkpi" runat="server" EnableViewState="False" Width="120px" visible="False">02201-</asp:TextBox>&nbsp;
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNoSkpi"
                                        Display="None" ErrorMessage="No. SKPI Wajib Diisi" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                            </tr>
                        </table>
                    </td>
               </tr>
                <tr>
                    <td>&nbsp</td>
                    <td align="left" colspan="2"><br />    
                    <asp:Button ID="redisplay" runat="server" OnClick="redisplay_Click" Text="Papar Laporan" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                            ShowSummary="False" Width="272px" />
                    </td>
                </tr>
         </table>        
        </div>
    </form>
</body>
</html>
