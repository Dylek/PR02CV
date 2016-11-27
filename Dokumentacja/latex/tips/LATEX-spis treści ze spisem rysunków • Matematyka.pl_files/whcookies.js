/*
 * Skrypt wyświetlający okienko z informacją o wykorzystaniu ciasteczek (cookies)
 * 
 * Więcej informacji: http://webhelp.pl/artykuly/okienko-z-informacja-o-ciasteczkach-cookies/
 * 
 */

function WHCreateCookie(name, value, days) {
    var date = new Date();
    date.setTime(date.getTime() + (days*24*60*60*1000));
    var expires = "; expires=" + date.toGMTString();
	document.cookie = name+"="+value+expires+"; path=/";
}
function WHReadCookie(name) {
	var nameEQ = name + "=";
	var ca = document.cookie.split(';');
	for(var i=0; i < ca.length; i++) {
		var c = ca[i];
		while (c.charAt(0) == ' ') c = c.substring(1, c.length);
		if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
	}
	return null;
}

window.onload = WHCheckCookies;

function WHCheckCookies() {
    if(WHReadCookie('cookies_accepted') != 'T') {
        var message_container = document.createElement('div');
        message_container.id = 'cookies-message-container';
        var content = ''
		content += '<style>';
		content += '.cookemessage{';
				content += 'cursor:pointer;';
				content += 'position:fixed;';
				content += 'width:100%;';
				content += 'height: 44px;';
				content += 'margin:0 auto;';
				content += 'font-family:arial;';
				content += 'font-size:12px;';
				content += 'bottom: 0;';
				content += 'z-index: 1000000;';
				content += 'color: #ffffff;';
		content += '}';
		content += '.cookemessage:hover{';
				content += 'color: #ffffff;';
		content += '}';
		content += '.cookemessage a{';
				content += 'text-decoration:underline;';
				content += 'color: #ffffff;';
		content += '}';
		content += '.cookemessage:hover a{';
				content += 'color: #ffffff;';
		content += '}';
		content += '.cookemessagecloseico{';
				content += 'background: transparent url("http://www.matematyka.pl/close2.png") 0px 0px no-repeat; ';
				content += 'width:	102px;';
				content += 'height:	36px;';
				content += 'position:absolute;';
				content += 'top:	4px;';
				content += 'right:	5px}';
		content += '.cookemessagecloseico:hover{';

		content += '}';
		content += '.opacityholder {';
			content += 'position: relative;';
		content += '}';
		content += '.opacitybox {';
			content += 'position: absolute;';
			content += 'background: black;';
			content += 'width: 100%;';
			content += 'height: 100%;';
			content += 'opacity: 0.8;';
			content += 'filter: alpha(opacity = 80);';
		content += '}';
		content += '.cookemessagetext {';
			content += 'position: relative;';
			content += 'width: 935px;';
			content += 'margin: auto;';
			content += 'text-align: left;';
			content += 'padding: 15px 0;';
		content += '}';
		content += '.cookemessagetext .bold {';
			content += 'font-weight: bold;';
		content += '}';
		content += '</style>';
		content += '<div id="cookemessagehandler" class="cookemessage" onclick="javascript:WHCloseCookiesWindow();">';
			content += '<div id="opacityholder">';
				content += '<div class="opacitybox"></div>';
				content += '<div class="cookemessagetext">';
					content += '<span>Na stronie używamy cookies. Korzystanie z witryny oznacza zgodę na ich wykorzystywanie.</span>';
					content += '<span>Szczegóły znajdziesz w</span> <a href="/regulamin.htm">Regulaminie.</a>';
					content += '<div class="cookemessagecloseico"></div>';
				content += '</div>';
			content += '</div>';
		content += '</div>';
        message_container.innerHTML = content;
        document.body.appendChild(message_container);
    }
}

function WHCloseCookiesWindow() {
    WHCreateCookie('cookies_accepted', 'T', 365);
	document.getElementById('cookies-message-container').removeChild(document.getElementById('cookemessagehandler'));
}
