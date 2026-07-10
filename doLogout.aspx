<%@ Page Language="VB" EnableSessionState="True"%>
<script runat="server">
</script>
<SCRIPT Language="Javascript">

if (confirm('Confirm logout?')==true)
	{
	parent.location.href='index.aspx';
	}
else
	{
	parent.location.href="javascript:history.back();";
	}

//parent.location.href="par_redirect_main.aspx";
</SCRIPT>
<html>
<head>
</head>
<body>
    <form runat="server">

</form>
</body>
</html>
