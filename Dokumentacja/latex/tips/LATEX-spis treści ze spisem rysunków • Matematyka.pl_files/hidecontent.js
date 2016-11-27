var expDays = 90;
var exp = new Date();
exp.setTime(exp.getTime() + (expDays*24*60*60*1000));

function SetCookie(name, value)
{
        var argv = SetCookie.arguments;
        var argc = SetCookie.arguments.length;
        var expires = (argc > 2) ? argv[2] : null;
        document.cookie = cname + name + "=" + escape(value) +
                ((expires == null) ? "" : ("; expires=" + expires.toGMTString())) +
                ((cpath == null) ? "" : ("; path=" + cpath)) +
                ((cdomain == null) ? "" : ("; domain=" + cdomain)) +
                ((csecure == 1) ? "; secure" : "");
}
function getCookieVal(offset)
{
        var endstr = document.cookie.indexOf(";",offset);
        if (endstr == -1)
        {
                endstr = document.cookie.length;
        }
        return unescape(document.cookie.substring(offset, endstr));
}
function GetCookie(name)
{
        var arg = cname + name + "=";
        var alen = arg.length;
        var clen = document.cookie.length;
        var i = 0;
        while (i < clen)
        {
                var j = i + alen;
                if (document.cookie.substring(i, j) == arg)
                        return getCookieVal(j);
                i = document.cookie.indexOf(" ", i) + 1;
                if (i == 0)
                        break;
        }
        return null;
}

function ShowHide(id1, id2, id3)
{
        // System to show/hide page elements, cookie based
        // Take from Morpheus style Created by Vjacheslav Trushkin (aka CyberAlien)
        var res = expMenu(id1);
        if (id2 != '') expMenu(id2);
        if (id3 != '') SetCookie(id3, res, exp);
}

function expMenu(id)
{
        var itm = null;
        if (document.getElementById)
        {
                itm = document.getElementById(id);
        }
        else if (document.all)
        {
                itm = document.all[id];
        }
        else if (document.layers)
        {
                itm = document.layers[id];
        }
        if (!itm)
        {
                // do nothing
        }
        else if (itm.style)
        {
                if (itm.style.display == "none")
                {
                        itm.style.display = "inline";
                        return 1;
                }
                else
                {
                        itm.style.display = "none";
                        return 2;
                }
        }
        else
        {
                itm.visibility = "show";
                return 1;
        }
}