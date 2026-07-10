
<script>
    function verifychar(inputstr,Fn)
	{
      for(var i=0; i < inputstr.length; i++)
	  {
        var inputchar=inputstr.substring(i, i+1);
        if (inputchar == "." )
		{
          return true;
        }
        else if (inputchar < "0" || inputchar > "9" )
		{
		  eval("document.borang." + Fn + ".value=''");
          return false;
        }
      }
      return true;
    }
	


function calculate(Fn,Gp,Gp1,GD,ST,SD,PP,HC,Sn,AP,TAP,Enum)
{
	var count_category=eval("document."+Fn+"." + HC + ".value")
	var staffno=eval("document." + Fn + "." + Sn + Enum + ".value")
	var tgp=0
	if (!IsEmpty(staffno) && IsNumeric(staffno))
	{
		annualpremium=eval("document." + Fn + "." + AP + Enum + ".value")
		premium=parseFloat(staffno) * parseFloat(annualpremium)
		eval("document." + Fn + "." + TAP + Enum + ".value=" + premium)
		for (i=1;i<=count_category;i++)
		{
			tgp=parseFloat(tgp) + parseFloat(eval("document." + Fn + "." + TAP + i + ".value"))
		}
		eval("document." + Fn + "." + Gp + ".value=" + tgp)
		showHint(tgp);
	}
	else
	{
		eval("document." + Fn + "." + TAP + Enum + ".value=0"  )
		for (i=1;i<=count_category;i++)
		{
			tgp=parseFloat(tgp) + parseFloat(eval("document." + Fn + "." + TAP + i + ".value"))
		}
		eval("document." + Fn + "." + Gp + ".value=" + tgp)
		//eval("document." + Fn + "." + Gp1 + ".value=" + tgp)
		//Premium()		
	}
}


function showHint(str)
{


xmlHttp=GetXmlHttpObject();
if (xmlHttp==null)
{
alert ("Browser does not support HTTP Request");
return;
} 
var url="rhbi_PA-31.asp";
url=url+"?dataVal="+str;
url=url+"&sid="+Math.random();
xmlHttp.onreadystatechange=stateChanged;
xmlHttp.open("GET",url,true);
xmlHttp.send(null);
}

function stateChanged() 
{ 
if (xmlHttp.readyState==4 || xmlHttp.readyState=="complete")
{ 
//alert(xmlHttp.responseText );
document.getElementById("payable").innerHTML=xmlHttp.responseText;
} 
} 

function GetXmlHttpObject()
{ 
var objXMLHttp=null;
if (window.XMLHttpRequest)
{
objXMLHttp=new XMLHttpRequest();
}
else if (window.ActiveXObject)
{
objXMLHttp=new ActiveXObject("Microsoft.XMLHTTP");
}
return objXMLHttp;
} 


function IsNumeric(sText)
{
   var ValidChars = "0123456789.";
   var IsNumber=true;
   var Char;

 
   for (i = 0; i < sText.length && IsNumber == true; i++) 
      { 
      Char = sText.charAt(i); 
      if (ValidChars.indexOf(Char) == -1) 
         {
         IsNumber = false;
         }
      }
   return IsNumber;
   
   }

function IsEmpty(aTextField) 
{
   if ((aTextField.length==0) || (aTextField==null)) 
   { return true;  }
   else 
   { return false; }
}	



	
</script>
