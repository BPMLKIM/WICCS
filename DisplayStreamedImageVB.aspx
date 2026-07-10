<%@ Page Language="vb" AutoEventWireup="false" Inherits="LinearStreamVB.WebForm1" CodeFile="DisplayStreamedImageVB.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Stream Image VB Example</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<FORM id="DisplayStreamedImage" method="post" runat="server">
			<DIV style="WIDTH: 100%; HEIGHT: 590px" align="center">
				<P>
					<asp:Label id="Label1" runat="server" Height="81px" Width="490px">This page will use the properties and data entered into the text fields to display a streamed barcode image below the submit button.  The page uses a Web Forms Image control, which is invisible when the page is initially loaded.  Once the Submit button is pressed, the Image URL property is updated to call the IDAutomationLinearImage.aspx page passing the appropriate parameters.  For more information see the Code Behind window of this page.</asp:Label></P>
				<P>
					<asp:Label id="lblBarcode" runat="server">Barcode Data</asp:Label>
					<asp:TextBox id="txtBarcode" runat="server" Height="20px" Width="136px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="lblX" runat="server">X Dimension</asp:Label>
					<asp:TextBox id="txtX" runat="server" Height="20px" Width="50px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="Label2" runat="server">Symbology</asp:Label>
					<asp:dropdownlist id="lstSymbology" runat="server" Height="31px" Width="169px" Font-Names="Times New Roman"
						Font-Size="12pt">
						<asp:ListItem Value="Code128">Code128</asp:ListItem>
						<asp:ListItem Value="Code39">Code39</asp:ListItem>
						<asp:ListItem Value="Interleaved 2 of 5">Interleaved 2 of 5</asp:ListItem>
						<asp:ListItem Value="Code39EXT">Code39EXT</asp:ListItem>
						<asp:ListItem Value="Code11">Code11</asp:ListItem>
						<asp:ListItem Value="Codabar">Codabar</asp:ListItem>
						<asp:ListItem Value="MSI">MSI</asp:ListItem>
						<asp:ListItem Value="UPCA">UPCA</asp:ListItem>
						<asp:ListItem Value="UPCE">UPCE</asp:ListItem>
						<asp:ListItem Value="EAN8">EAN8</asp:ListItem>
						<asp:ListItem Value="EAN13">EAN13</asp:ListItem>
						<asp:ListItem Value="IND25">IND25</asp:ListItem>
						<asp:ListItem Value="MAT25">MAT25</asp:ListItem>
						<asp:ListItem Value="Code93">Code93</asp:ListItem>
						<asp:ListItem Value="Code93EXT">Code93EXT</asp:ListItem>
						<asp:ListItem Value="Postnet">Postnet</asp:ListItem>
						<asp:ListItem Value="Planet">Planet</asp:ListItem>
					</asp:dropdownlist></P>
				<P>
					<asp:Label id="Label3" runat="server">Bar Height</asp:Label>
					<asp:TextBox id="txtBarHeight" runat="server" Height="20px" Width="52px"></asp:TextBox>
					<asp:CheckBox id="chkCheckChar" runat="server" Height="37px" Width="115px" Text="Calculate Check Character"></asp:CheckBox>
					<asp:CheckBox id="chkCheckCharText" runat="server" Height="37px" Width="115px" Text="Place Check Character in Text"></asp:CheckBox>
					<asp:label id="lblRotation" runat="server" Height="20px" Width="107px" Font-Size="12pt">Rotation Angle</asp:label>
					<asp:dropdownlist id="lstRotation" runat="server" Height="31px" Width="93px" Font-Names="Times New Roman"
						Font-Size="12pt">
						<asp:ListItem Value="0 Degrees">0 Degrees</asp:ListItem>
						<asp:ListItem Value="90 Degrees">90 Degrees</asp:ListItem>
						<asp:ListItem Value="180 Degrees">180 Degrees</asp:ListItem>
						<asp:ListItem Value="270 Degrees">270 Degrees</asp:ListItem>
					</asp:dropdownlist></P>
				<P>
					<asp:CheckBox id="chkShowText" runat="server" Height="22px" Width="105px" Text="Show Text"></asp:CheckBox>
					<asp:Label id="Label4" runat="server">Left Margin</asp:Label>
					<asp:TextBox id="txtLM" runat="server" Height="20px" Width="52px"></asp:TextBox>
					<asp:Label id="Label5" runat="server">Top Margin</asp:Label>
					<asp:TextBox id="txtTopMargin" runat="server" Height="20px" Width="52px"></asp:TextBox>
					<asp:Label id="Label6" runat="server">Resolution</asp:Label>
					<asp:TextBox id="txtResolution" runat="server" Height="20px" Width="52px"></asp:TextBox></P>
				<P>
					<asp:Label id="Label7" runat="server">Bearer Bars</asp:Label>
					<asp:TextBox id="txtBearerBars" runat="server" Width="22px">0</asp:TextBox>
					<asp:Label id="Label8" runat="server" Width="114px">Character Group</asp:Label>
					<asp:TextBox id="txtCharacterGroup" runat="server" Width="22px">0</asp:TextBox>
					<asp:Label id="Label9" runat="server" Width="130px">White Bar Increase</asp:Label>
					<asp:TextBox id="txtWhiteBarIncrease" runat="server" Width="22px">0</asp:TextBox></P>
				<P>
					<asp:Label id="Label10" runat="server" Width="130px">Caption Above</asp:Label>
					<asp:TextBox id="txtCaptionAbove" runat="server" Width="160px">0</asp:TextBox>
					<asp:Label id="Label11" runat="server" Width="130px">Caption Below</asp:Label>
					<asp:TextBox id="txtCaptionBelow" runat="server" Width="176px">0</asp:TextBox></P>
				<P>
					<asp:Button id="Button1" runat="server" Height="40px" Width="72px" Text="Submit"></asp:Button></P>
				<P>
					<asp:Image id="Image1" runat="server" Height="112px" Width="264px" Visible="False"></asp:Image></P>
			</DIV>
			&nbsp;&nbsp;&nbsp;</FORM>
	</body>
</HTML>
