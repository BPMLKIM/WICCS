<%@ Page Language="vb" Trace="false" AutoEventWireup="false" Inherits="LinearStreamVB.IDAutomationStreamingLinear" CodeFile="IDAutomationStreamingLinear.aspx.vb" %>
<%@ Register TagPrefix="cc1" Namespace="IDAutomation.LinearServerControl" Assembly="IDAutomation.LinearServerControl" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>IDAutomationStreamingLinear</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<cc1:linearbarcode id="LinearBarcode1" 
				runat="server" StreamImage="True" Height="35px" Width="133px" LeftMarginCM="0.000"></cc1:linearbarcode></form>
	</body>
</HTML>
