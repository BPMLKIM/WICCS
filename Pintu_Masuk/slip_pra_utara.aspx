<%@ Page Language="VB" AutoEventWireup="false" CodeFile="slip_pra_utara.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" PrintMode="ActiveX" />
        <br />
        <CR:CrystalReportViewer ID="CrystalReportViewer2" runat="server" AutoDataBind="true" PrintMode="ActiveX" />
        <br />
        <CR:CrystalReportViewer ID="CrystalReportViewer3" runat="server" AutoDataBind="true" PrintMode="ActiveX" />
        <br />
        <CR:CrystalReportViewer ID="CrystalReportViewer5" runat="server" AutoDataBind="true" PrintMode="ActiveX" />
        <br />
        <CR:CrystalReportViewer ID="CrystalReportViewer4" runat="server" AutoDataBind="true" PrintMode="ActiveX" />
        <br />
        <asp:HiddenField ID="cetak" runat="server" />
    
    </div>
    </form>
</body>
<script type="text/javascript">
   // alert(document.all.cetak.value);
    if (document.all.cetak.value=="1")
     {       
        window.close();
    }
    
    </script>
</html>
