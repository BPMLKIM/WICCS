<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Papar_Laporan_Harian.aspx.vb" Inherits="Laporan_Papar_Laporan_Harian" %>

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
    <form id="Form1" runat="server" method="post">
    <div>
            <table cellspacing="1" cellpadding="1" border="0">
                <tr><td colspan="5">&nbsp</td>
                </tr>
                <tr>
                    <td style="height: 23px">&nbsp</td>
                    <td align="left" style="height: 23px">
                        <span class="style3">
                        <asp:Label ID="lblTarikh1" runat="server" Width="105px">Dari Tarikh :</asp:Label>
                        <asp:TextBox ID="txtTarikh1" runat="server" Width="130px" Wrap="False" EnableViewState="False"></asp:TextBox>
                        <asp:Button id="dtButton1" style="BORDER-LEFT-COLOR: white; BACKGROUND-IMAGE: url(img/calendar.jpg); BORDER-BOTTOM-COLOR: white; CURSOR: hand; BORDER-TOP-STYLE: none; BORDER-TOP-COLOR: white; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BACKGROUND-COLOR: white; BORDER-RIGHT-COLOR: white; BORDER-BOTTOM-STYLE: none" tabIndex="1" runat="server" Width="15" Text="  " EnableViewState="False" Height="18"></asp:Button>
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="lblTarikh2" runat="server" Width="115px">Hingga Tarikh :</asp:Label>
                        <asp:TextBox ID="txtTarikh2" runat="server" Width="130px" EnableViewState="False"></asp:TextBox>
                        <asp:Button id="dtButton2" style="BORDER-LEFT-COLOR: white; BACKGROUND-IMAGE: url(img/calendar.jpg); BORDER-BOTTOM-COLOR: white; CURSOR: hand; BORDER-TOP-STYLE: none; BORDER-TOP-COLOR: white; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BACKGROUND-COLOR: white; BORDER-RIGHT-COLOR: white; BORDER-BOTTOM-STYLE: none" tabIndex="1" runat="server" Width="15" Text="  " EnableViewState="False" Height="18"></asp:Button>                                
                        </span>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp</td>
                    <td align="left" colspan="4"><br />    
                    <asp:Button ID="redisplay" runat="server" OnClick="redisplay_Click" Text="Papar Laporan" />
                        <input id="Button2" onclick="location.href='Laporan.aspx'" type="button" value="Menu Laporan" />&nbsp;<br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTarikh1"
                            Display="None" ErrorMessage="Dari Tarikh Wajib Diisi"></asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTarikh2" Display="None"
                                ErrorMessage="Hingga Tarikh Wajib Diisi" SetFocusOnError="True"></asp:RequiredFieldValidator><asp:ValidationSummary
                                    ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False"
                                    Width="272px" />
                    </td>
                </tr>
        </table>
        </div>        
    </form>
</body>
</html>
