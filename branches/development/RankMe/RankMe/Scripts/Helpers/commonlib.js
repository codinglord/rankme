//Enhance trim ability for string
if (typeof String.prototype.trim !== 'function') {
    String.prototype.trim = function () {
        return this.replace(/^\s+|\s+$/g, '');
    }
}
//Enhance indexOf function for Array
if (!Array.prototype.indexOf) {
    Array.prototype.indexOf = function (elt) {
        var len = this.length >>> 0;

        var from = Number(arguments[1]) || 0;
        from = (from < 0)
             ? Math.ceil(from)
             : Math.floor(from);
        if (from < 0)
            from += len;

        for (; from < len; from++) {
            if (from in this &&
                this[from] === elt)
                return from;
        }
        return -1;
    };
}


$.codeengine = {
    func: {},
    helper: {},
    models: {}
};

//standard format
//{Message , StatusCode }

$.codeengine.func.done = function () { }

$.codeengine.func.error = function () { }

$.codeengine.func.fail = function () { }


$.fn.cssByText = function (text) {

    var cElement = text.split(';');
    var output = {};
    $(cElement).each(function (i, iObj) {
        if (iObj.trim() != '') {
            var iCss = iObj.split(':');
            var iText = iCss[0].trim();
            var iValue = iCss[1].trim();
            output[iText] = iValue;
        }
    });

    $(this).css(output);

}



$.codeengine.helper.ajaxPost = function (url,json,settings) {


    if (settings == null)
    {
        settings = {}
    }

    settings = $.extend({
        url: url,
        type: 'post',
        dataType: 'json',
        contentType: 'application/json',
        data: JSON.stringify(json),
        cache: false,
        success: $.codeengine.func.done,
        error: $.codeengine.func.error
    }, settings);

    return $.ajax(settings);
}





//Shortage references
$.helper = $.codeengine.helper;
$.helper.func = $.codeengine.func;



$.helper.notify = function (message,type) {

 


        $('div.growlUI').html(message);
        var bgColor = "green";


        if (type != null)
        {
            switch (type)
            {
                case "complete":
                    {
                        bgColor = "green";
                    }
                    break;
                case "error":
                    {
                        bgColor = "red";
                    }
                    break;
                case "warning":
                    {
                        bgColor = "orange";
                    }
                    break;
            }
        }


    
        $.blockUI({
            message: $('div.growlUI'),
            fadeIn: 700,
            fadeOut: 700,
            timeout: 9000,
            showOverlay: false,
            centerY: false,
            centerX: true,
            css: {
                width: $(window).width(),
                top: '10px',
                left: '',
                //right: '10px',
                border: 'none',
                padding: '5px',
                backgroundColor: '#000',
                //'-webkit-border-radius': '10px',
                //'-moz-border-radius': '10px',
                opacity: .6,
                color: '#fff',
                'background-color': bgColor
            }
        });
  
    

}






