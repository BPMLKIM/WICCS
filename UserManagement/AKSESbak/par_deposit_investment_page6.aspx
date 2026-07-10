<%@ Page Inherits="par_deposit_investment_page6" Src="par_deposit_investment_page6.vb" validaterequest="false" Language="VB" EnableSessionState="True" %>
<!--#include file="../../function/javascript.js" -->
<html>
<head>
    <link href="../../css/default.css" type="text/css" rel="stylesheet" />
</head>
<body id="bodytag" runat="server">
    <form id="borang" runat="server">
        <table style="HEIGHT: 59px" width="100%">
            <tbody>
                <tr>
                    <td>
                        <asp:Label id="label1" runat="server" width="46px" font-bold="True"></asp:Label></td>
                    <td>
                        <asp:Label id="label2" runat="server" font-bold="True"></asp:Label>
                        <asp:ImageButton id="btn_image1" runat="server" ImageUrl="../../images/icon_questionmark.gif"></asp:ImageButton>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <input id="textbox1" type="hidden" name="textbox1" runat="server" />
                        <table cellspacing="4" cellpadding="0" width="735" border="0">
                            <tbody>
                                <tr>
                                    <td colspan="2">
                                        <table cellspacing="0" cellpadding="0" width="702" align="left" bgcolor="#d8d8d7" border="0">
                                            <tbody>
                                                <tr id="edbtoolbar1" height="30">
                                                    <td class="icon_bar" valign="top">
                                                        <img src="../../images/init_separator.gif" align="absMiddle" /> 
                                                        <select class="formbut" id="select100" onblur="fontHasFocus = false;" onfocus="fontHasFocus = true;" onchange="editbox_putformat6('fontname',this.options[this.selectedIndex].value);" name="select42">
                                                            <option value="">- Select Font -</option>
                                                            <option value="Arial">Arial</option>
                                                            <option value="Courier">Courier</option>
                                                            <option value="Helvetica">Helvetica</option>
                                                            <option value="Impact">Impact</option>
                                                            <option value="Lucida Console">Lucida Console</option>
                                                            <option value="Symbol">Symbol</option>
                                                            <option value="Tahoma">Tahoma</option>
                                                            <option value="Times New Roman" selected="selected">Times New Roman</option>
                                                            <option value="Verdana">Verdana</option>
                                                            <option value="Wingdings">Wingdings</option>
                                                            <option value="Webdings">Webdings</option>
                                                        </select>
                                                        <select class="formbut" id="select101" onblur="fontsizeHasFocus = false;" onfocus="fontsizeHasFocus = true;" onchange="editbox_putformat6('fontsize',this.options[this.selectedIndex].value);" name="select42">
                                                            <option value="">- Select Size -</option>
                                                            <option value="1">Tiny</option>
                                                            <option value="2">Very Small</option>
                                                            <option value="3" selected="selected">Small</option>
                                                            <option value="4">Medium</option>
                                                            <option value="5">Large</option>
                                                            <option value="6">Largest</option>
                                                        </select>
                                                        <select class="formbut" id="select102" onblur="headingHasFocus = false;" onfocus="headingHasFocus = true;" onchange="editbox_putformat6('formatblock',this.options[this.selectedIndex].value);" name="select42">
                                                            <option value="">- Heading -</option>
                                                            <option value="Normal" selected="selected">Normal</option>
                                                            <option value="Heading 1">H1</option>
                                                            <option value="Heading 2">H2</option>
                                                            <option value="Heading 3">H3</option>
                                                            <option value="Heading 4">H4</option>
                                                            <option value="Heading 5">H5</option>
                                                            <option value="Heading 6">H6</option>
                                                        </select>
                                                    </td>
                                                </tr>
                                                <tr id="edbtoolbar2">
                                                    <td class="icon_bar">
                                                        <nobr style="FONT-SIZE: 2px" /><img class="btnstyle" src="../../images/init_separator.gif" /> <img onmouseup="icon_mouseup(this)" class="btnstyle" onmousedown="icon_mousedown(this)" onmouseover="icon_mouseover(this)" onclick="editbox_putformat6('bold',null)" onmouseout="icon_mouseout(this)" alt="Bold" src="../../images/bold.gif" /> <img onmouseup="icon_mouseup(this)" class="btnstyle" onmousedown="icon_mousedown(this)" onmouseover="icon_mouseover(this)" onclick="editbox_putformat6('italic',null)" onmouseout="icon_mouseout(this)" alt="Italics" src="../../images/italic.gif" /> <img onmouseup="icon_mouseup(this)" class="btnstyle" onmousedown="icon_mousedown(this)" onmouseover="icon_mouseover(this)" onclick="editbox_putformat6('underline',null)" onmouseout="icon_mouseout(this)" alt="Underline" src="../../images/underline.gif" /> <img onmouseup="icon_mouseup(this)" class="btnstyle" onmousedown="icon_mousedown(this)" onmouseover="icon_mouseover(this)" onclick="editbox_putformat6('strikethrough',null)" onmouseout="icon_mouseout(this)" alt="Strikethrough" src="../../images/strikethrough.gif" /> <img src="../../images/separator.gif" /> <img onmouseup="icon_mouseup(this)" class="btnstyle" onmousedown="icon_mousedown(this)" onmouseover="icon_mouseover(this)" onclick="editbox_putformat6('justifyleft',null)" onmouseout="icon_mouseout(this)" alt="Left" src="../../images/left.gif" /> <img onmouseup="icon_mouseup(this)" class="btnstyle" onmousedown="icon_mousedown(this)" onmouseover="icon_mouseover(this)" onclick="editbox_putformat6('justifycenter',null)" onmouseout="icon_mouseout(this)" alt="Center" src="../../images/center.gif" /> <img onmouseup="icon_mouseup(this)" class="btnstyle" onmousedown="icon_mousedown(this)" onmouseover="icon_mouseover(this)" onclick="editbox_putformat6('justifyright',null)" onmouseout="icon_mouseout(this)" alt="Right" src="../../images/right.gif" /> <img src="../../images/separator.gif" /> <img onmouseup="icon_mouseup(this)" class="btnstyle" onmousedown="icon_mousedown(this)" onmouseover="icon_mouseover(this)" onclick="editbox_putformat6('insertorderedlist',null)" onmouseout="icon_mouseout(this)" alt="Numbered List" src="../../images/numberedlist.gif" /> <img onmouseup="icon_mouseup(this)" class="btnstyle" onmousedown="icon_mousedown(this)" onmouseover="icon_mouseover(this)" onclick="editbox_putformat6('insertunorderedlist',null)" onmouseout="icon_mouseout(this)" alt="Bulleted List" src="../../images/bulletedlist.gif" /> <img onmouseup="icon_mouseup(this)" class="btnstyle" onmousedown="icon_mousedown(this)" onmouseover="icon_mouseover(this)" onclick="editbox_putformat6('indent',null)" onmouseout="icon_mouseout(this)" alt="Indent" src="../../images/indent.gif" /> <img onmouseup="icon_mouseup(this)" class="btnstyle" onmousedown="icon_mousedown(this)" onmouseover="icon_mouseover(this)" onclick="editbox_putformat6('outdent',null)" onmouseout="icon_mouseout(this)" alt="Outdent" src="../../images/outdent.gif" /> <img src="../../images/separator.gif" />&nbsp; <img onmouseup="icon_mouseup(this)" class="btnstyle" onmousedown="icon_mousedown(this)" onmouseover="icon_mouseover(this)" onclick="editbox_putformat6('inserthorizontalrule',null)" onmouseout="icon_mouseout(this)" alt="Ruler" src="../../images/rule.gif" /> <img src="../../images/separator.gif" /> <img onmouseup="icon_mouseup(this)" class="btnstyle" onmousedown="icon_mousedown(this)" onmouseover="icon_mouseover(this)" onclick="editbox_putformat6('cut',null)" onmouseout="icon_mouseout(this)" alt="Cut" src="../../images/cut.gif" /> <img onmouseup="icon_mouseup(this)" class="btnstyle" onmousedown="icon_mousedown(this)" onmouseover="icon_mouseover(this)" onclick="editbox_putformat6('copy',null)" onmouseout="icon_mouseout(this)" alt="Copy" src="../../images/copy.gif" /> <img onmouseup="icon_mouseup(this)" class="btnstyle" onmousedown="icon_mousedown(this)" onmouseover="icon_mouseover(this)" onclick="editbox_putformat6('paste',null)" onmouseout="icon_mouseout(this)" alt="Paste" src="../../images/paste.gif" /> <img onmouseup="icon_mouseup(this)" class="btnstyle" onmousedown="icon_mousedown(this)" onmouseover="icon_mouseover(this)" onclick="editbox_putformat6('print',null)" onmouseout="icon_mouseout(this)" alt="Print" src="../../images/print.gif" /> </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <iframe id="Box1" onblur="editbox_blur6();" style="WIDTH: 700px; HEIGHT: 200px" onfocus="edibox_focus6();" name="Box1" src="blank.htm">
                                                        </iframe>
                                                        <span id="editbox_init_frame6" style="DISPLAY: none" name="editbox_init_frame6"></span></td>
                                                </tr>
                                                <tr id="edbtoolbar3" height="30">
                                                    <td class="tdstyle" align="right">
                                                        &nbsp; 
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        <script language="JavaScript">
			<!--
			editbox_load6();
			window.setTimeout("edibox_focus6()", 1000);

			var viewmodeEditbox = true;
			var fontHasFocus = false;
			var fontsizeHasFocus = false;
			var headingHasFocus = false;

			function edibox_focus6()
			{
				var i;
				editbox_blur6();

				var fontname = Box1.document.queryCommandValue('FontName');
				var fontsize = Box1.document.queryCommandValue('FontSize');
				var formatblock = Box1.document.queryCommandValue('formatblock');

				if (!fontHasFocus)
				{
					if (fontname != null )
					{
    					fontname = fontname.toLowerCase();
						oSelect = document.all.editbox_selectfont;
						if (oSelect !=  null)
						{
							for ( i = 0; i <  oSelect.options.length ; i++ )
							{
	 							if (oSelect.options[i].value.toLowerCase() ==  fontname)
								{
									oSelect.options[i].selected = true;
								}
							}
						}
					}
				}

				if ( !fontsizeHasFocus )
				{
					if ( fontsize != null )
					{
						oSelect = document.all.editbox_selectsize;
						if (oSelect !=  null)
						{
							for ( i = 0; i <  oSelect.options.length ; i++ )
							{
								if (oSelect.options[i].value ==  fontsize)
								{
									oSelect.options[i].selected = true;
								}
							}
						}
					}
				}

				if ( !headingHasFocus )
				{
					if ( formatblock != null )
					{
						formatblock = formatblock.toLowerCase();
						oSelect = document.all.editbox_selectheading;
						if ( oSelect !=  null)
						{
							for ( i = 0; i <  oSelect.options.length ; i++ )
							{
								if (oSelect.options[i].value.toLowerCase() ==  formatblock)
								{
									oSelect.options[i].selected = true;
								}
							}
						}
					}
				}
				window.setTimeout("edibox_focus6()", 1000);
			}

			function editbox_blur6()
			{
				//alert("as");
				if ( viewmodeEditbox )
				{
					document.all.textbox1.value = Box1.document.body.innerHTML;
				}
				else
				{
					document.all.textbox1.value = Box1.document.body.innerText;
				}
			}

			function editbox_load6()
			{
				Box1.document.designMode = 'On';
				Box1.document.open();
				Box1.document.write("<body></body>");
				Box1.document.close();
				Box1.document.body.innerHTML = document.all.editbox_init_frame6.innerHTML;
				editbox_blur6();
			}

			function icon_mouseover(butn)
			{
				butn.style.borderTop = "solid white 1px";
				butn.style.borderLeft = "solid white 1px";
				butn.style.borderBottom = "solid gray 1px";
				butn.style.borderRight = "solid gray 1px";
				butn.style.cursor = 'hand';
			}

			function icon_mouseout(butn)
			{
				butn.style.borderTop = "solid #D8D8D7 1px";
				butn.style.borderLeft = "solid #D8D8D7 1px";
				butn.style.borderBottom = "solid #D8D8D7 1px";
				butn.style.borderRight =  "solid #D8D8D7 1px";
			}

			function icon_mousedown(butn)
			{
				butn.style.borderTop = "solid gray 1px";
				butn.style.borderLeft = "solid gray 1px";
				butn.style.borderBottom = "solid white 1px";
				butn.style.borderRight =  "solid white 1px";
			}

			function icon_mouseup(butn)
			{
				butn.style.borderTop = "solid white 1px";
				butn.style.borderLeft = "solid white 1px";
				butn.style.borderBottom = "solid gray 1px";
				butn.style.borderRight =  "solid gray 1px";
			}

			function editbox_putformat6(command,arg)
			{
				if (arg == '<body>')
				{
					Box1.document.execCommand('formatblock', false, 'Normal');
					Box1.document.execCommand('removeFormat');
					return;
				}


				Box1.focus();


				if (arg == 'removeFormat')
				{
					command=arg;
					arg = null;
				}


								if ( arg == null )
									Box1.document.execCommand(command, false, arg);
								else
									Box1.document.execCommand(command, false, arg);

								Box1.focus();
							}


				function InsertEntityEditbox6(svalue)
				{
					Box1.focus();
					var oSel = Box1.document.selection;
					var oFrame = oSel.createRange();
					oFrame.pasteHTML(svalue);

				}

				function ShowResult6(stoggle)
				{
					viewmodeEditbox = stoggle;
					if ( viewmodeEditbox == true )
					{
						var sHTML = Box1.document.body.innerHTML;
						Box1.document.body.innerText = sHTML;
						edbtoolbar1.style.display = 'none';
						edbtoolbar2.style.display = 'none';
						Box1.focus();
						viewmodeEditbox = false;
					}
					else
					{
						var sText = Box1.document.body.innerText;
						Box1.document.body.innerHTML = sText;
						edbtoolbar1.style.display = 'inline';
						edbtoolbar2.style.display = 'inline';
						Box1.focus();
						viewmodeEditbox = true;
					}
				}
						//--></script>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Label id="label3" runat="server"></asp:Label>&nbsp; <asp:Label id="label4" runat="server" width="487px"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <em><font color="#000066" size="1">(Only one document is allowed, MS Word or MS Excel
                        or PDF file)</font></em>&nbsp;<br />
                        <asp:TextBox id="addBox" runat="server" MaxLength="250" ReadOnly="True" Width="291px"></asp:TextBox>
                        <input class="button" id="btn_attach" type="button" value="Attach" runat="server" />
                        <input class="button" id="btn_view" type="button" value="View" runat="server" />
                        <input class="button" id="btn_clear" type="button" value="Clear" runat="server" />&nbsp; 
                    </td>
                </tr>
                <tr runat="server">
                    <td>
                    </td>
                    <td>
                        <asp:Label id="label5" runat="server" width="55px"></asp:Label><asp:Label id="label6" runat="server" width="140px"></asp:Label>
                        <asp:ImageButton id="btn_image2" runat="server" ImageUrl="../../images/icon_questionmark.gif"></asp:ImageButton>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:TextBox id="textrisk" runat="server" MaxLength="5" Width="139px">0</asp:TextBox>
                        % 
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Label id="label7" runat="server" width="54px"></asp:Label><asp:Label id="label8" runat="server" width="95px"></asp:Label>
                        <asp:ImageButton id="btn_image3" runat="server" ImageUrl="../../images/icon_questionmark.gif"></asp:ImageButton>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <table style="WIDTH: 801px; HEIGHT: 110px">
                            <tbody>
                                <tr>
                                    <td>
                                        <table style="WIDTH: 233px; HEIGHT: 70px" bordercolor="black" cellspacing="0" cellpadding="0" bgcolor="#e0e0e0" border="1">
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <table style="WIDTH: 233px; HEIGHT: 70px">
                                                            <tbody>
                                                                <tr>
                                                                    <td>
                                                                        <strong>&nbsp;&nbsp;&nbsp;Assessment Risk</strong> 
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <p align="left">
                                                                            &nbsp;&nbsp;&nbsp;1 - 3 = Low 
                                                                        </p>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <p align="left">
                                                                            &nbsp;&nbsp;&nbsp;4 - 6 = Medium 
                                                                        </p>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        &nbsp;&nbsp;&nbsp;7 - 9 = high</td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:PlaceHolder id="PlaceHolder1" runat="server"></asp:PlaceHolder>
                                        <asp:TextBox id="bil" runat="server" Width="70px" Visible="False"></asp:TextBox>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <br />
                    </td>
                </tr>
                <tr id="otherrisk" style="DISPLAY: none" runat="server">
                    <td>
                    </td>
                    <td>
                        ( If Others ) Please Specify 
                        <asp:TextBox id="textothers" runat="server" Width="183px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Label id="label9" runat="server" width="51px"></asp:Label><asp:Label id="label10" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <em><font color="#000066" size="1">(Only one document is allowed, MS Word or MS Excel
                        or PDF file)</font></em>&nbsp;<br />
                        <asp:TextBox id="addBox1" runat="server" MaxLength="250" ReadOnly="True" Width="291px"></asp:TextBox>
                        <input class="button" id="btn_attach1" type="button" value="Attach" runat="server" />
                        <input class="button" id="btn_view1" type="button" value="View" runat="server" />
                        <input class="button" id="btn_clear1" type="button" value="Clear" runat="server" /></td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button id="btn_save" onclick="Submit_button" runat="server" Text="  Save  " CssClass="button"></asp:Button>
                        <asp:Button id="Button2" onclick="Submit_button" runat="server" Text="  Previous  " CssClass="button"></asp:Button>
                        <asp:Button id="Button4" onclick="Submit_button" runat="server" Text="Continue Later" CssClass="button"></asp:Button>
                        <asp:Button id="Button6" onclick="Submit_button" runat="server" Text="Summary Page" CssClass="button"></asp:Button>
                        <asp:Button id="Button5" onclick="Submit_button" runat="server" Text="  Print  " CssClass="button"></asp:Button>
                        <asp:Button id="Button1" onclick="Submit_button" runat="server" Text="  Next  " CssClass="button"></asp:Button>
                        <asp:TextBox id="product_line" runat="server" Width="76px" Visible="False" AutoPostBack="True"></asp:TextBox>
                        <asp:TextBox id="product_category" runat="server" Width="76px" Visible="False" AutoPostBack="True"></asp:TextBox>
                        <asp:TextBox id="frmtype" runat="server" Width="76px" Visible="False" AutoPostBack="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <strong> 
                        <p align="left">
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="label11" runat="server"></asp:Label>
                        </p>
                        </strong></td>
                </tr>
            </tbody>
        </table>
    </form>
    <script languange="Javascript">
    document.frames['Box1'].location.href = "par_view_data.aspx?prodID=<%=prodId%>&txt=risk_management&table=par_products";
    </script>
</body>
</html>