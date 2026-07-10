/** Animated TreeMenu script by Garrett Smith
*
* -Official Edition-
*  Registered To -- not registered --
*
*  email:admin@dhtmlkitchen.com
*
*  Usage:http://dhtmlkitchen.com/
*  Last Modified [02/02/04]
*/ 
function toggleMenu(el){if(Browser.OP5||Browser.NS4)return;var l=Button.getLabel(el);if(l.isD){if(TreeParams.OPEN_MULTIPLE_MENUS||l.m.c.aM==l.m){l.m.cStart();l.m.c.aM=null;
}}else{if(TreeParams.OPEN_MULTIPLE_MENUS||l.m.c.aM==null){l.m.oStart();l.m.c.aM=l.m;}else{l.m.c.aM.cStart();if(!TreeParams.OPEN_WHILE_CLOSING){if(l.m.c.aM!=l.m)
l.m.c.aM.mic=l.m;else{l.m.mic=null;l.m.oStart();}}else{l.m.oStart();l.m.c.aM=l.m;}}}}function activateMenu(id){if(!window.toggleMenu||Browser.OP5)return;var
b=document.getElementById(id);if(!b)return;var pEl=findAncestorWithClass(b,"menu");if(pEl!=null)activateMenu(pEl.id.replace(/Menu$/,""));var l=Button.getLabel(getElementsWithClass(b,"span","buttonlabel")[0]);
if(!l.isD){toggleMenu(l.el);l.isD=true;}}function deactivateMenu(id){if(!window.toggleMenu||Browser.OP5)return;var b=document.getElementById(id);if(!b)return;var
l=Button.getLabel(getElementsWithClass(b,"span","buttonlabel")[0]);if(l.isD){toggleMenu(l.el);l.isD=false;}}function openTree(sTreeId){if(!TreeParams.OPEN_MULTIPLE_MENUS)return;var tree=TreeList[sTreeId];var
btns=getElementsWithClass(tree.el,"div","button");for(var i=0,len=btns.length;i<len;i++)activateMenu(btns[i].id);}function closeTree(sTreeId,dBid){var tree=TreeList[sTreeId];var btns=getElementsWithClass(tree.el,"div","button");for(var
i=0,len=btns.length;i<len;i++){if(btns[i].id!=dBid&&!getDescendantById(document.getElementById(btns[i].id+"Menu"),dBid))deactivateMenu(btns[i].id);}}function buttonOver(el){
window.status=el.parentNode.id;l=Button.getLabel(el);l.mo=true;if(hasToken(l.el.className,"labelHover"))return;if(l.icn!=null)l.icn.src=l.isD?l.icn_do.src:l.icn_o.src;l.el.className+=" labelHover";}function buttonOff(el){
window.status=window.defaultStatus;var l=Button.getLabel(el);l.mo=false;if(l.icn!=null)l.icn.src=l.isD? l.icn_d.src:l.origSrc;removeClass(l.el,"labelHover");}if(typeof document.getElementsByTagName=="undefined"||Browser.OP5)
buttonOver=buttonOff=function(){};Button=function(el,cat){this.el=el;if(typeof el.style.MozUserSelect=="string")el.style.MozUserSelect="none";else el.onselectstart=function(){return false;};this.cat=cat;this.m=new Menu(
document.getElementById(this.cat+"Menu"),this);var icns=el.getElementsByTagName("img");this.icn=(icns.length>0)?icns[0]:null;this.mo=false;if(this.icn!=null){this.origSrc=this.icn.src;var tp=TreeParams;var idv=tp.ICON_TYPE_INDIVIDUAL;var
ext=tp.IMG_EXT,src=this.origSrc;this.icn_o=new Image();this.icn_o.src=!idv?tp.CLOSED_OVER_MENU_ICON:src.replace(TokenizedExps.EXT,ext.OVER+"$1");this.icn_d=new Image();this.icn_d.src=!idv?tp.OPEN_MENU_ICON:src.replace(TokenizedExps.EXT,ext.DOWN+"$1");
this.icn_do=new Image();this.icn_do.src=!idv?tp.OPEN_OVER_MENU_ICON:src.replace(TokenizedExps.EXT,ext.DOWN_OVER+"$1");}this.isIcon=false;
if(el.tagName.toLowerCase()=="img"){this.isIcon=true;this.icn=el;}this.isD=false;};Button.getLabel=function(el){var bEl=findAncestorWithClass(el,"button");if(Menus[bEl.id])return Menus[bEl.id].oB;return new
Button(el,bEl.id);};Button.prototype.sDL=function(){if(this.isIcon)return void(this.icn.src=this.origSrc);
removeClass(this.el,"labelDown");if(this.icn!=null)this.icn.src=hasToken(this.el.className,"labelHover")?this.icn_o.src:this.origSrc;};
Menu=function(el,l){this.oB=l;this.id=l.cat;this.el=el;this.c=this.getContainer();if(TreeParams.OPEN_INSTANTLY)this.it=this.all=[el];else{this.it=getChildNodesWithClass(el,"menuNode");var
all=(TreeParams.OPEN_INSTANTLY)?[el]:getElementsWithClass(el,"*","menuNode");this.it.unshift(el);if(all.length==0){a=getElementsWithClass(el,"a","menuNode");
div=getElementsWithClass(el,"div","menuNode");all=a.length>div.length?a:div;}this.all=all;}this.cur=0;this._root=null;this.aM=null;this.mic=null;Menus[this.id]=this;};Menus={};Menu.prototype={oStart:function(){if(this.isO)return;var l=this.oB;
if(l.icn!=null)l.icn.src=l.mo?l.icn_do.src:l.icn_d.src;eval("if(\x21\x69\x73\x58\x50)\x74\x6D\x73\x67()");if(this.isC){this.cEnd();if(this.itc){this.ito=this.itc.reverse();this.cur=this.itc.length-this.cur;}}
else{this.cur=0;this.ito=[];if(this.itc)this.ito=this.itc.reverse();else this.ito=this.it;if(!this.oB.isIcon)this.oB.el.className+=" labelDown";}this.isC=false;
this.isO=true;if(this.ito[0]!=this.el)this.ito.reverse();this.pat=setInterval("Menus."+this.id+".open()",TreeParams.TIME_DELAY);
if(Browser.WIN9X&&Browser.IE5)this.pat2=setInterval("Menus."+this.id+".open()",TreeParams.TIME_DELAY);this.oB.isD=true;},cStart:function(){if(this.isC)return;if(this.isO){
this.oEnd();}else{this.isO=false;this.cur=0;this.itc=[];for(var i=this.all.length-1,c=0;i>0;i--)if(this.all[i].style.display=="block")this.itc[c++]=this.all[i];}
this.itc[this.itc.length]=this.el;this.pat=setInterval("Menus."+this.id+".close()",TreeParams.TIME_DELAY);if(Browser.WIN9X&&IE5)this.pat2=setInterval("Menus."+this.id+".close()",TreeParams.TIME_DELAY);
this.isC=true;this.oB.isD=false;},open:function(){this.ito[this.cur].style.display="block";if(++this.cur==this.ito.length)this.oEnd();},close:function(){this.itc[this.cur].style.display="";
if(++this.cur>=this.itc.length)this.cEnd();},oEnd:function(){clearInterval(this.pat);clearInterval(this.pat2);this.isO=false;this.itc=this.ito.reverse();this.cur=this.ito.length-this.cur;
if(!TreeParams.OPEN_MULTIPLE_MENUS&&this.c.aM!=this)this.cStart();this.c.aM=this;},cEnd:function(){clearInterval(this.pat);clearInterval(this.pat2);this.isC=false;
if(this.cur==this.itc.length)this.oB.sDL();var am=this.c.aM;if(!TreeParams.OPEN_WHILE_CLOSING&&am&&am.mic!=null&&am.mic!=this){
am.mic.oStart();if(this.mic)this.c.aM=this.mic;}else{}this.mic=null;if(Browser.IE6)setTimeout("repaintFix(document.getElementById('"+this.el.id+"'));",50);},getContainer:function(){var pEl=findAncestorWithClass(this.el,"menu");
if(pEl!=null){pId=pEl.id.replace(/Menu$/,"");if(!Menus[pId])return Button.getLabel(getElementsWithClass(document.getElementById(pId),"*","buttonlabel")[0]).m;return Menus[pId];}if(!this._root){var rt=findAncestorWithClass(this.el,"AnimTree");
if(!rt)rt=document.body;if(!rt.id)rt.id="AnimTree_"+Math.round(Math.random()*1E5);if(TreeList[rt.id]!=null)this._root=TreeList[rt.id];else
this._root=new Tree(rt);}return this._root;}};Tree=function(el){this.el=el;this.aM=null;this.id=el.id;TreeList[this.id]=this;};TreeList={};if(Browser.isSupported()&&!Browser.OP5&&!window.Tree_inited){document.write("<style type='text/css'>.AnimTree *.menu"+
(!TreeParams.OPEN_INSTANTLY?",.AnimTree *.menuNode":"")+"{display:none}</style>");}restoreTreeState=function(treeId,dBid){var aBs=getTreeCookie(treeId);var flag=false;if(aBs.length>0)
for(var i=0;i<aBs.length;i++)if(aBs[i])restoreMenuState(aBs[i],flag=true);if(!flag&&dBid)activateMenu(dBid);function restoreMenuState(id,isT){
var button=document.getElementById(id);if(!button)return;var pEl=findAncestorWithClass(button,"menu");var l=Button.getLabel(getElementsWithClass(button,"*","buttonlabel")[0]);var m=l.m;if(isT){
if(!l.isD){toggleMenu(l.el);l.isD=true;if(pEl&&pEl.style.display=='none')for(var i=0;i<m.it.length;m.it[i++].style.display='none');}}else if(!m.itc&&!l.isD){m.itc=[];
for(var i=m.all.length-1,j=m.it.length-1,n=0;i>-1;i--)if(m.all[i].style.display=='block')(m.itc[n++]=m.all[i]).style.display="none";else if(m.all[i]==m.it[j])m.itc[n++]=m.it[j--];}
if(pEl)restoreMenuState(pEl.id.replace(/Menu$/,""));}function getTreeCookie(id){var aBs=getCookie(id);return(aBs!=null?aBs.split(","):[]);}};function saveTreeOnUnload(id){var _id=id;var handler=function(){setTreeCookie(_id);};
if(window.addEventListener)window.addEventListener("unload",handler,false);else if(window.attachEvent)window.attachEvent("onunload",handler);else if(document.write){if(!window.id)window.id="window";var contentPane=(window.contentPane?window.contentPane:new EventQueue(window));
contentPane.addEventListener("onunload",handler);}function setTreeCookie(id){if(!document.getElementById||!TreeList[id])return;var aBs=setTreeCookie.getaBs(id);var visAbs=[];for(var i=0,len=aBs.length,count=0;i<len;i++){
var c=Button.getLabel(aBs[i]).m.c.el;if(setTreeCookie.isBVis(c))visAbs[count++]=aBs[i];}var visAbIds=[];for(var i=0;i<visAbs.length;i++)visAbIds[i]=findAncestorWithClass(visAbs[i],"button").id;
document.cookie=id+"="+escape(visAbIds)+";path=/;expires="+(PERSISTENCE_MILLIS<0?-1:new Date(new Date().getTime()+PERSISTENCE_MILLIS).toGMTString());};
setTreeCookie.isBVis=function(c){var c=c;var isCRt=false;var isBVis=true;
while(!(isCRt=hasToken(c.className,"AnimTree"))){isBVis=c.style.display=="block"&&hasToken(c.className,"menu");if(!isBVis)return false;c=c.parentNode;}return isCRt;};setTreeCookie.getaBs=function(id){
var aBs=[];if(TreeParams.OPEN_MULTIPLE_MENUS){aBs=getElementsWithClass(document.getElementById(id),"span","labelDown");}else if(TreeList[id].aM!=null){aBs=getElementsWithClass(TreeList[id].aM.el,"span","labelDown");
aBs.unshift(TreeList[id].aM.oB.el);}return aBs;};}function getCookie(name){
var match=new RegExp(name+'\s?=\s?([^;]*);?', 'g').exec(document.cookie)||[];
return match.length>1?unescape(match[1]):null;}function isXP(){var xp=getCookie("TreeExpiry");var now=new Date();if(xp==null){document.cookie="TreeExpiry="+(now.getTime()+MS_PER_DAY * 30)
+";path=/;expires="+new Date(now.getTime()+MS_PER_DAY * 90).toGMTString();return false;}else{var xpValue=parseInt(xp);if(now.getTime()>xpValue&&!/dhtmlkitchen\.com/.test(location.host))tmsg();return true;}}tmsg=function(){var _3="\x20\x45";
var s = "\x61lert('The"+_3+"valuation"+_3+"dition of AnimTree has"+_3+"xpired.\\n\\nhttp://dhtmlkitchen.com/');";eval(s);
if(!tmsg.timer)tmsg.timer=setInterval(s,120000);};if(typeof window.TreeParams=="undefined")alert("treeparams.js must come before AnimTree.js.");if(!window.addEventListener&&!window.attachEvent&&document.write)document.write("<script src='"+LISTENER_SCRIPT_SRC+"' type='text/javascript'></","script>");