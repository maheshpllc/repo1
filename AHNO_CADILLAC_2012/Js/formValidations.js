// General Form validations


    var n_errorcount =0;
    var v_message = '';

    function strip_lspaces(element)
    {
        /// <summary>Trims left spaces of a control's value</summary>
        /// <param name="element" type="string"></param>
        if (element != '')
	        while('' + element.charAt(0) == ' ')
	            element = element.substring(1,element.length);
        return element;
    }
    
    function isNotValidWebSiteURL(url)
    {
        /// <summary>Validates the Website URL.</summary>
        /// <param name="url" type="string"></param>
        if(url.length!=0)
           if(!/^https?:\/\/([\w-]+\.?)+[\w-]+(\/[\w- ./?%&=]*)?$/.test(url)) return true;
        return false;
    }
  
    
    function isNotPositiveInteger(val)
    {
        /// <summary>Checks for a Positive integer value.</summary>
        /// <param name="val" type="int"></param>
        if (parseInt(val) < 0 || isNaN(val) || val.indexOf('.')!=-1) return true;
        return false;
    }
    
    function isNotFloatValue(val)
    {
        /// <summary>Checks for a floating point value.</summary>
        /// <param name="val" type="string"></param>
        if(isNaN(val)) return true;
        return false;
    }
    
    function isEmpty(val)
    {
        /// <summary>Checks whether input control has value or not.</summary>
        /// <param name="" type=""></param>
	    if (val.length==0) return true;
	    return false;
    }
    
    function isNotZipCode(zip)
	{
	    /// <summary>Validates Zip Code.</summary>
        /// <param name="zip" type="string"></param>
		if((zip.length!=0) && (zip.length < 5 || zip.length >5))
			return true;
		else if(isNaN(zip)) 
			return true;
		return false;
	}
	
 function isNotDealerAlphaNumeric(val)
    {
        /// <summary>Validates string without special characters (Alpha numaric).</summary>
        /// <param name="val" type="string"></param>    ----------   '\'','&',
        var arraychars = new Array('\\','[',']','{','}','@','~','!','$','%','^','*','+','<','>','=','|','"',':','`');
        for(p=0;p<val.length;++p)
		    for(j=0;j<arraychars.length;++j)
			    if(val.charAt(p)==arraychars[j])			
				    return true;
	    return false;
    }
	
	function isNotTournamentAlphaNumeric(val)
    {
        /// <summary>Validates string without special characters (Alpha numaric).</summary>
        /// <param name="val" type="string"></param>    ----------   '\'','&',
        var arraychars = new Array('\\','[',']','{','}','@','~','!','$','%','^','*','+','<','>','=','|','"',':','`','.');
        for(p=0;p<val.length;++p)
		    for(j=0;j<arraychars.length;++j)
			    if(val.charAt(p)==arraychars[j])			
				    return true;
	    return false;
    }
	 function isNotGiftCard(GiftCard)
	{
	    /// <summary>Validates Zip Code.</summary>
        /// <param name="zip" type="string"></param>
		if((GiftCard.length!=0) && (GiftCard.length < 7 || GiftCard.length >7))
			return true;
		else if(isNaN(GiftCard)) 
			return true;
		return false;
	}
	
	function isNotPhoneNumber(phone)
	{
	    /// <summary>Validates Phone number.</summary>
        /// <param name="phone" type="string"></param>
		if (phone.length!=0)
			var sep = getseparator(phone, '-');
		if((phone.length!=0) && (phone.length < 12 || phone.length >12))
			return true;
		else if((isNaN(phone.substring(0,3))) || (isNaN(phone.substring(4,7))) || (isNaN(phone.substring(8,12)))) 
			return true;
		else if ((sep !="") && (phone.length!=0))
		{
			if((phone.indexOf(sep)!=3) || (phone.lastIndexOf(sep)!=7))
				return true;
		}
		else if(sep =='') 
			return true;
	    return false;
	}

   function isNotCity(val)
    {
        /// <summary>Validates string without special characters (Alpha numaric).</summary>
        /// <param name="val" type="string"></param>    ----------   '\'','&',
        var arraychars = new Array('\\','@','~','!','#','$','%','^','*','+','<','>','=','(',')','|','"','/',';',':','`',',');
        for(p=0;p<val.length;++p)
		    for(j=0;j<arraychars.length;++j)
			    if(val.charAt(p)==arraychars[j])			
				    return true;
	    return false;
    }
    
    function isSelected(ddl)
    {
        /// <summary>Checks the Dropdown is Selected or not.</summary>
        /// <param name="ddl" type="int"></param>
        if(ddl==0) return false;
        return true;
    }
    
    function isNotAnEmail(email)
    {
        /// <summary>Validates email.</summary>
        /// <param name="email" type="string"></param>
        if (!/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(email)) return true;
	    return false;
    }

    //This function checks whether the mail
    //contains any special characters other then
    //'@' and '.'.
    function validate_chars(field,arraychars)
    {
	    for(p=0;p<field.length;++p)
		    for(j=0;j<arraychars.length;++j)
			    if(field.charAt(p)==arraychars[j])			
				    return arraychars[j];
    }
    
    function isNotAlphaNumeric(val)
    {
        /// <summary>Validates string without special characters (Alpha numaric).</summary>
        /// <param name="val" type="string"></param>    ----------   '\'','&',
        var arraychars = new Array('\\','@','.','~','!','#','$','%','^','*','-','+','<','>','=','(',')','|','"','/',';',':','`',',');
        for(p=0;p<val.length;++p)
		    for(j=0;j<arraychars.length;++j)
			    if(val.charAt(p)==arraychars[j])			
				    return true;
	    return false;
    }
    
    function isNotDate(edate)
	{
	    /// <summary>Validates the date in mm/dd/yyyy.</summary>
        /// <param name="date" type="string"></param>
		var date1=edate;
		var mm,dd,yy,sptr;
		sptr=getseparator(date1,'/');
		
	    if (sptr != "")
	    {       
	        mm=date1.substring(0,date1.indexOf(sptr));
	        dd=date1.substring(date1.indexOf(sptr)+1,date1.lastIndexOf(sptr));
	        yy=date1.substring(date1.lastIndexOf(sptr)+1,date1.length);
	        if(date1.length==0)
	            return true;
	        else if(isNaN(mm)||isNaN(dd)||isNaN(yy))
		        return true;
	        else if(parseInt(dd)>31)
	    	    return true;
	        else if(parseInt(mm)>12)
		        return true;
	        else if(yy.length==3 || yy.length==1 || yy.length>4 || yy.length==0)
		        return true;
	        else if((parseInt(mm)==4 || parseInt(mm)==6 || parseInt(mm)==9 || parseInt(mm)==11) && (parseInt(dd)>30))
	    	    return true;
	        else if( (parseInt(yy))%4 == 0 && parseInt(dd)>29 && parseInt(mm)==2)
		        return true;
		    else if(parseInt(yy)%4!=0 && parseInt(dd)>28 && parseInt(mm)==2)
	    	    return true;
	    }
	    else if(sptr == '' && date1.length!=0)
	        return true;
	    return false;
		    
	}
	
	
	 function CompareTodayDate(cDate)
	{
	    /// <summary>Comparing From Date and To Date</summary>
        /// <param name="date" type="string"></param>
        var l_today           = new Date();             // Initialize Date in raw form
        var l_cdate           = l_today.getDate();      //   Get the numerical date
        var l_cyear           = l_today.getFullYear();       // Get the year
        var l_cday            = l_today.getDay();       // Get the day in number form (0,1,2,3,etc.)
        var l_cmonth          = l_today.getMonth()+1;   // Get the month
        var l_crrdt           = l_cmonth + '/' + (l_cdate) + '/' + l_cyear;   
        
        //alert(l_cyear);  
         l_today =  new Date(l_crrdt); 
       // alert(l_today);   
        
        /**/
        // var d = new Date();
         var d = new Date(cDate);
         
        // alert(d >= l_today) 
         
         //alert(d);
         // var month = parseInt(cDate.split('/')[0]) -1;
        //  d1 = new Date(cDate.split('/')[2],month,cDate.split('/')[1]);
       //   var today = new Date();   
          if(d >= l_today ){
           return false;
          }
          
        return true;
   }
	
	function isInvalidTime(time)
    {
        /// <summary>Validates the time.</summary>
        /// <param name="time" type="string"></param>
        if(!(/^(\d{1,2}):(\d{2})(:(\d{2}))?(\s(AM|am|PM|pm))?$/.test(time)))
            return true;
        else
        {
            var splitTime = time.split(':');
            var hrs = splitTime[0];
            var _min = splitTime[1].split(' ');
            var min = _min[0];
            var am_pm = _min[1].toLowerCase();
            if (hrs == '' || min == '' || am_pm == '')
                return true;
            else if (hrs > 12)
                return true;
            else if(min >= 60)
                return true;
        }
        return false;
    }
    
	function getseparator(val, separator)
	{
	    /// <summary>checks whether separator exists in val or not.</summary>
        /// <param name="value" type="string"></param>
        /// <param name="separator" type="string"></param>
		if(val.indexOf(separator)!=-1)
			return separator;
		else
			return '';
	}
	
	
    //************* An Fckeditor Validation **********
    function  isEditorEmpty(FCKInst)
    {
        /// <summary>Checks the FCK Edirot value empty or not.</summary>
        /// <param name="FCKInstance" type="string"></param>
        if(window.navigator.appName.indexOf('Opera')==-1)
        {
            var oEditor = FCKeditorAPI.GetInstance(FCKInst);
            oEditor.UpdateLinkedField();
        }
        
        var v_editor = document.getElementById(FCKInst).value;
        if(v_editor =='' || v_editor=='<p>&nbsp;</p>') return true;
        return false;
    }
    
    function isNotValidFile(entered)
    {
        /// <summary>Checks whether the entered is a valid file name or not.</summary>
        /// <param name="msg" type="string"></param>
        var ext = entered.substr(entered.lastIndexOf(".")).toLowerCase();
        if ( ext!=".aspx") return true;
        return false;
    }
     
    function isNotValidImgFormat(imgName)
    {
        /// <summary>Checks whether the selected file is a valid file or not.</summary>
        /// <param name="imgName" type="string"></param>
        var ext = imgName.substring(imgName.lastIndexOf('.') + 1 ,imgName.length);
        ext = ext.toLowerCase(); 
        if(ext == 'gif' || ext == 'jpg' || ext == 'png' || ext == 'jpeg' || ext == 'gif' || ext == 'bmp')
            return false;
        return true;
    }   
    
    function isNotValidWordFormat(filename)
    {
        /// <summary>Checks whether the selected file is a valid file or not.</summary>
        /// <param name="imgName" type="string"></param>
        var ext = filename.substring(imgName.lastIndexOf('.') + 1 ,imgName.length);
        ext = ext.toLowerCase(); 
        if(ext == 'doc' || ext == 'txt' || ext == 'xls' || ext == 'pdf')
            return false;
        return true;
    }
    
    function isNotValidFileFormat(fileName)
    {
        /// <summary>Checks whether the selected file is a valid or not.</summary>
        /// <param name="fileName" type="string"></param>
        var ext = fileName.substring(fileName.lastIndexOf('.') + 1 ,fileName.length);
        ext = ext.toLowerCase(); 
        var fileFormats = new Array('jpg','png','jpeg','gif','bmp','swf','doc','xls','ppt','txt','pdf');
        
        for(var j=0;j<fileFormats.length; j++)
        {
            if(fileFormats[j] == ext )
                return false;
        }
        return true;
    }
    
    function addErrorMessage(msg)
    {
        /// <summary>Adds msg to the list of Error messages.</summary>
        /// <param name="msg" type="string"></param>
        n_errorcount = n_errorcount + 1;
        v_message =v_message + " (" + n_errorcount + ") " + msg + "\n";
    }
    
    function displayErrors()
    {
        /// <summary>Displays the list of Error messages.</summary>
        if (n_errorcount == 0)
		    return true;
	    else
	    {
		    alert('Please check the following information\n\n' + v_message);
		    v_message = '';
		    n_errorcount =0;
		    return false;
	    }
	    return false;
    }
    
     function displayErrorsEvent(e)
    {
        /// <summary>Displays the list of Error messages.</summary>
        
         if (n_errorcount != 0)
         {
            alert('Please check the following information\n\n' + v_message);
		    v_message = '';
		    n_errorcount =0;
		    return false;
         }else{
            var ctrl ;
                
            if (!e) var e = window.event;
            if (e.ctrl) ctrl = e.target; // In Fire Fox
            else if (e.srcElement) ctrl = e.srcElement;
            if (ctrl.nodeType == 3) // defeat Safari bug
            ctrl = ctrl.parentNode;

            window.setTimeout("disableButton('" + ctrl.id + "')", 0); 
        }   
	    return true;
    }
    
    function charsMax(control,display,val)
        {
            ///<summary>Display number of characters left for the Textarea</summary>
            var s = control.value;
            if (s.length > val)
            {
                control.value= s.substring(0,val);
            }
            display.value = val - control.value.length;
        }
    
    function isValidPhone(val){
        var phonechars = '1234567890- ()'
        var isValid = true;
        for(var l=0; l< val.length ; l++){
            var curChar = val.charAt(l);
            if(phonechars.indexOf(curChar) == -1){
                isValid = false;
                break;
            }
        }
        return isValid;
    }
    
     function formatphonenumber(phone)
        {
           
            var p = phone;
            var pp = '';
            phone = phone.value;
            
            if(phone.length > 0)
            {
               if(phone.length <=3)
                {   
                    pp='';
                    for(c=0;c<phone.length;c++)
                    {
                        if(isNaN(phone.charAt(c))   || phone.charAt(c)  ==' ')
                           continue; 
                        else
                            pp = pp + phone.charAt(c);   
                    }
                    
                    p.value = pp;
                }
                else if(phone.length > 3 )
                {
                    var pAry = phone.split('-');
                    phone ='';
                    
                    for(r=0;r<pAry.length; r++)
                        if(pAry[r])
                            phone += pAry[r];
                    
                    pp='';
                    for(c=0;c<phone.length;c++)
                    {
                        if(isNaN(phone.charAt(c))  || phone.charAt(c)  ==' ')    
                           continue; 
                        else
                            pp = pp + phone.charAt(c);
                    }
                    
                    if(pp.length > 10)
                        pp = pp.substring(0,3)  + '-' + pp.substring(3,6)  + '-' + pp.substring(6,10);
                    else if(pp.length > 6)
                        pp = pp.substring(0,3)  + '-' + pp.substring(3,6)  + '-' + pp.substring(6);
                    else
                        pp = pp.substring(0,3)  + '-' + pp.substring(3,6)  ;
                    p.value = pp;
                }
            }
            if(p.value == '-')  p.value = '';
        }
    
    
    function formatDealerCode(code)
        {
           
            var p = code;
            var pp = '';
            code = code.value;
            
            if(code.length > 0)
            {
               if(code.length <=2)
                {   
                    pp='';
                    for(c=0;c<code.length;c++)
                    {
                        if(isNaN(code.charAt(c))   || code.charAt(c)  ==' ')
                           continue; 
                        else
                            pp = pp + code.charAt(c);   
                    }
                    
                    p.value = pp;
                }
                else if(code.length > 2 )
                {
                    var pAry = code.split('-');
                    code ='';
                    
                    for(r=0;r<pAry.length; r++)
                        if(pAry[r])
                            code += pAry[r];
                    
                    pp='';
                    for(c=0;c<code.length;c++)
                    {
                        if(isNaN(code.charAt(c))  || code.charAt(c)  ==' ')    
                           continue; 
                        else
                            pp = pp + code.charAt(c);
                    }
                    
                 if(pp.length > 6)
                        pp = pp.substring(0,2)  + '-' + pp.substring(6);
                 else
                    pp = pp.substring(0,2)  + '-' + pp.substring(2,6)  ;
                    p.value = pp;
                }
            }
            if(p.value == '-')  p.value = '';
        }
        
        function isNotDealerCode(code)
	{
	    /// <summary>Validates Dealer Code.</summary>
        /// <param name="Dealer Code" type="string"></param>
		if (code.length!=0)
			var sep = getseparator(code, '-');
		if((code.length!=0) && (code.length < 6 || code.length > 6))
			return true;
		else if((isNaN(code.substring(0,2))) || (isNaN(code.substring(4,6)))) 
			return true;
		else if ((sep !="") && (code.length!=0))
		{
			if((code.indexOf(sep)!=2))
				return true;
		}
		else if(sep =='') 
			return true;
	    return false;
	}
        