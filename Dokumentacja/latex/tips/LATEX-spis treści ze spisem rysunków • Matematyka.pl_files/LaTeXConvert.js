var LCon = {};

LCon.version = '2011.07.11.14.23b';

//preprocessing nawiasów
LCon.braceId=0, LCon.braceStack=[], LCon.qBraceId=0, LCon.dBraceId=0, LCon.qStack=[], LCon.dOpened=false, LCon.stdC=0;
LCon.tmp='';

//theorems
LCon.theorems = {};
LCon.commands = {};
LCon.labels = {};
LCon.package = [];
LCon.inTag = '';
LCon.inTagId = -1;
LCon.thCount = 0;
LCon.labelC = 1;


LCon.addslashes = function(str) {
	return (str + '').replace(/[\\"']/g, '\\$&').replace(/\u0000/g, '\\0');
}

LCon.bracesPreproces = function(t,m) {
	switch(t) {
	case '{':
		LCon.braceId++;
		LCon.braceStack.push(LCon.braceId);
		LCon.tmp = 'BL_'+LCon.braceId;
	break;
	case '}':
		LCon.tmp = 'BR_'+LCon.braceStack.pop();
	break;
	case '\\[':
		LCon.qBraceId++;
		LCon.qStack.push(LCon.qBraceId);
		LCon.tmp = 'QL_'+LCon.qBraceId;
	break;
	case '\\]':
		LCon.tmp = 'QR_'+LCon.qStack.pop();
	break;
	case '$':
		if(LCon.dOpened) {
			LCon.tmp = 'DR_'+LCon.dBraceId;
		} else {
			LCon.dBraceId++;
			LCon.tmp = 'DL_'+LCon.dBraceId;
		}
		LCon.dOpened=!LCon.dOpened;
	break;
	default:
		return m; //cos poszlo zle
	break;
	}

	return '__'+LCon.tmp+'_';
}

LCon.bracesAfter = function(t,m) {
	switch(m) {
		case 'BL': return '{';
		case 'BR': return '}';
		case 'QL': return '\\[';
		case 'QR': return '\\]';
		case 'DL': case 'DR': return '$';
		
		return t; //cos poszlo zle
	}
}
//wraper do stdFormating
LCon.stdFormatingIn = function(t,p1,p2,p3,p4) {
	return LCon.stdFormating(p2,p4,p3);
}
LCon.stdFormatingOut = function(t,p1,p2,p3) {
	return LCon.stdFormating('',p3,p1);
}
LCon.stdF2ndPass = function(t,p1,p2,p3,p4) {
	return '['+p1+']'+LCon.stdFormating(p2,p4,p3)+'[/'+p1+']';
}

LCon.color2ndPass = function(t,p1,p2,p3,p4,p5,p6) {
	//'[$1]$2[color=$5]$6[/color][/$1]'
	//recursive regexp
	return ('['+p1+']'+p2+'[color='+p5+']'+p6+'[/color][/'+p1+']').replace(LCon.re.color2ndPass[0], LCon.re.color2ndPass[1]);
}
//funkcja do obsługi formatowania typu [b],[i] itd.
LCon.stdFormating = function(t1,t2,tag) {
	LCon.stdC++;
	switch(tag) {
		case 'bf': case 'textbf': 
			LCon.tmp='b'; 
		break;
		case 'em': case 'it': case 'emph': case 'textit':
			LCon.tmp='i';
		break;
		default:
			return (t1+''+t2);
	}
	//recursive regexp
	return (t1+'['+LCon.tmp+':'+LCon.stdC+']'+t2+'[/'+LCon.tmp+':'+LCon.stdC+']').replace(LCon.re.stdF2ndPass[0], LCon.re.stdF2ndPass[1]);
}

LCon.enumerateP = function(t,p1,p2,p3) {
	//checking only one character, maybe more in future (css3/gc)
	if(p2 == undefined) p2= '';
	if(p1=='itemize') LCon.tmp='';
	else switch(p2.substr(0,1)) {
		case '': 
			LCon.tmp='=1';
		break;
		case '1': case 'i': case 'I': case 'a': case 'A':
			LCon.tmp='='+p2.substr(0,1);
		break;
		default:
			LCon.tmp='';
		break;
	}

	return '[list'+LCon.tmp+']'+p3.replace(/\\item/g, '[*]')+'[/list]';
}

//na razie tylko
//\newtheorem{name}{Printed output}
//\newtheorem*...
LCon.tPreprocess1 = function(t,p1,p2,p3,p4,p5) {
	LCon.theoremsPreprocess(p1, p3, p5);
	return t;
}

LCon.theoremsPreprocess = function(star, name, fullName) {
	if(star == '*') {
		LCon.theorems[name] = [fullName, false];
	} else {
		LCon.theorems[name] = [fullName, true, 1];
	}
}
//\[re]newcommand
LCon.newCommands = function(t,p1,p2,p3,p4) {
	//LCon.commands[p2] = LCon.addslashes(p4);
	LCon.commands[LCon.addslashes(p2)] = p4.replace(LCon.re.braceAfter[0], LCon.re.braceAfter[1]);
	return t;
}

LCon.newCommandsReal = function(t) {
	LCon.tmp = t;
	var ttmp = {};
	for(i in LCon.commands) {
		ttmp = new RegExp(i+"(\\W)","g");
		LCon.tmp = LCon.tmp.replace(ttmp, LCon.commands[i]+"$1");
	}
	return LCon.tmp;
}

LCon.usePackage = function(t,p1) {
	var ttmp = p1.split(',');
	for(var i in ttmp) {
		LCon.package.push(ttmp[i]);
	}
}

LCon.headParse = function(t,p1) {
	LCon.headParsed = true;
	//wczytujemy paczki
	p1 = p1.replace(LCon.ree['usepackage'][0], LCon.ree['usepackage'][1]);
	for(var i in LCon.package) {
		LCon.tmp = prompt("Nieznana paczka "+LCon.package[i],"Wklej tu zawartosc paczki");
		p1+=LCon.tmp;
	}
	p1 = p1.replace(LCon.re['bracePreprocess'][0], LCon.re['bracePreprocess'][1]);
	p1 = p1.replace(LCon.re['bracePreprocess2'][0], LCon.re['bracePreprocess2'][1]);
	p1 = p1.replace(LCon.ree['newCommands'][0], LCon.ree['newCommands'][1]);
	p1 = p1.replace(LCon.ree['tPreprocess'][0], LCon.ree['tPreprocess'][1]);
	//reset
	LCon.braceId=LCon.qBraceId=LCon.dBraceId=LCon.stdC=0;
	LCon.braceStack=[];
	LCon.qStack=[];
	LCon.dOpened=false;
	return '\\begin{document}';
}
//potrzbne do intertexta
LCon.blocksEnv = [
	['\n[tex]', '[/tex]\n'], //0
	['\n[tex]\n\\begin{aligned}', '\\end{aligned}\n[/tex]\n'], //1
	['\n[tex]\n\\begin{gathered}', '\\end{gathered}\n[/tex]\n'], //2
	['[center]', '[/center]'], //3
];

//parser bloków, theorems, numerowanie, spisywanie etykiet
LCon.parseBlock = function(t, tag, title, text) {
	var rep = '';
	LCon.inTag = tag;
	LCon.inTagId = -1;
	LCon.thCount = 0;
	switch(tag) {
		case 'equation': case 'displaymath': case 'equation*':
			LCon.inTagId = 0;
		break;
		case 'align': case 'align*': case 'aligned':
			LCon.inTagId = 1;
		break;
		case 'gather': case 'gathered': case 'gather*': case 'multline': case 'multline*':
			LCon.inTagId = 2;
		break;
		case 'center':
			LCon.inTagId = 3;
		break;
		case 'document':
			return (text.replace(LCon.ree.labels[0], LCon.ree.labels[1]).replace(LCon.re.blocks[0], LCon.re.blocks[1]).replace(LCon.ree.intertext[0], LCon.ree.intertext[1]));
		break;
		default:
			if(LCon.theorems[tag]) {
				rep = '[b]'+LCon.theorems[tag][0]+' ';
				if(LCon.theorems[tag][1]) {
					rep += LCon.theorems[tag][2];
					LCon.thCount = LCon.theorems[tag][2];
					LCon.theorems[tag][2]++;
				}
				rep+='[/b]';
				if(title) {
					rep += '('+title.substr(1,title.length-2)+')';
				}
				rep +='. '+text.replace(LCon.ree.labels[0], LCon.ree.labels[1]);
				//zwracamy bo juz nic z tym nie zrobimy
				//rekursywnie
				return rep.replace(LCon.re.blocks[0], LCon.re.blocks[1]);
			} else {
				return ('\\begin{'+tag+'}'+text.replace(LCon.ree.labels[0], LCon.ree.labels[1]).replace(LCon.re.blocks[0], LCon.re.blocks[1]).replace(LCon.ree.intertext[0], LCon.ree.intertext[1])+'\\end{'+tag+'}'); //ni wiadomo co to
			}
		break;
	}
	LCon.inTag = '__main';
	return (''+LCon.blocksEnv[LCon.inTagId][0]+text.replace(LCon.ree.labels[0], LCon.ree.labels[1]).replace(LCon.ree.intertext[0], LCon.ree.intertext[1])+LCon.blocksEnv[LCon.inTagId][1]);
}

LCon.labelProcess = function(t, parentTag, name) {
	return '\\label_'+LCon.inTag+'_'+LCon.thCount+'_{'+name+'}';
}
LCon.intertextProcess = function(t, parentTag, txt) {
	return '\\intertext_'+LCon.inTagId+'_{'+txt+'}';
}
LCon.label2nPass = function(t, tag, id, name) {
	if(tag == '__main') {
		LCon.labels[name] = LCon.labelC;
		return '('+(LCon.labelC++)+')\\qquad ';
	} else {
		LCon.labels[name] = id;
		return '';
	}
}
LCon.intertext2nPass = function(t, id, txt) {
	return LCon.blocksEnv[id][1] + txt + LCon.blocksEnv[id][0];
}
LCon.refResolve = function(t, type, name) {
	if(LCon.labels[name]) {
		if(type == 'eq') {
			return '('+LCon.labels[name]+')';
		} else {
			return LCon.labels[name]+'.';
		}
	} else {
		return '[unknown ref]';
	}
}

//dodatkowe regexpy
LCon.ree = {
	labels		: [/\\label(_.+_)?\{(.+)\}/g, LCon.labelProcess],
	intertext	: [/\\intertext(_.+_)?\{(.+)\}/g, LCon.intertextProcess],
	usepackage	: [/\\usepackage\{(.+)\}/g, LCon.usePackage],
	documentHead	: [/(\\documentclass[\s\S]+)\\begin\{document\}/, LCon.headParse],
	//analiza nagłówków, newtheorem 
	newCommands	: [/\\(?:re)?newcommand__BL_([0-9]+_)(.+)__BR_\1__BL_([0-9]+_)(.+)__BR_\3/g, LCon.newCommands],
	tPreprocess	: [/\\newtheorem(\*?)__BL_([0-9]+_)(.+)__BR_\2__BL_([0-9]+_)(.+)__BR_\4/g, LCon.tPreprocess1],
}
//podstawowe regexpy 
LCon.re = {
	newCommandsReal	: [/([\s\S]*)/, LCon.newCommandsReal],
	bracePreprocess	: [/(?!\\)(\{|\}|\$)/gi, LCon.bracesPreproces],
	bracePreprocess2: [/(\\\[|\\\])/gi, LCon.bracesPreproces],

	stdFormatingOut	: [/\\(textbf|emph|textit)__BL_([0-9]+_)([\s\S]*)__BR_\2/g, LCon.stdFormatingOut],
	stdFormatingIn	: [/__BL_([0-9]+_)([\s\S]*?)\\(bf|em|it)((?: |\\)[\s\S]*)__BR_\1/g, LCon.stdFormatingIn],
	stdF2ndPass	: [/\[((?:b|i):[0-9]+)\]([\s\S]*?)\\(bf|em|it)((?: |\\)[\s\S]*)\[\/\1\]/g, LCon.stdF2ndPass],

	color		: [/__BL_([0-9]+_)([\s\S]*)(\\color__BL_([0-9]+_)(.*)__BR_\4)([\s\S]*)__BR_\1/g, '$2[color=$5]$6[/color]'],
	color2ndPass	: [/\[((?:b|i):[0-9]+)\]([\s\S]*?)(\\color__BL_([0-9]+_)(.*)__BR_\4)([\s\S]*)\[\/\1\]/g, LCon.color2ndPass],
	

	latexNormalL	: [/__QL_[0-9]+_\s*\n/g, '\n[tex]'],
	latexNormalR	: [/\n\s*__QR_[0-9]+_/g, '[/tex]\n'],
	latexInlineL	: [/__DL_[0-9]+_/g, '[tex]'],
	latexInlineR	: [/__DR_[0-9]+_/g, '[/tex]'],

	braceAfter		: [/__([BQD][RL])_[0-9]+_/g, LCon.bracesAfter],
	stdFAfter		: [/\[(\/?)(b|i):[0-9]+\]/g, '[$1$2]'],

	enumerate		: [/\\begin\{(enumerate|itemize)\}(?:\[(.+)\])?([\s\S]*?)\\end\{\1\}/g, LCon.enumerateP],
	//ogólny parser bloków
	blocks			: [/\\begin\{(.+)\}(\[.+\])?([\s\S]*?)\\end\{\1\}/g, LCon.parseBlock],
	labels2nPass	: [/\\label_(.+?)_([0-9]+)_\{(.+?)\}/g, LCon.label2nPass],
	refsResolve		: [/\\(eq)?ref\{(.+?)\}/g, LCon.refResolve],
	intertext2nPass : [/\\intertext_([0-9]+)_\{(.+?)\}/g, LCon.intertext2nPass],

	tylda			: [/~/g, ' '],

	multipleTagFix	: [/\[(\/?)tex\]\s*\[\1tex\]/g, '[$1tex]'],
}
//funkcja zwraca juz gotowy kod do wrzucenia na forum
LCon.LConvert = function(txt) {
	LCon.braceId=LCon.qBraceId=LCon.dBraceId=LCon.stdC=0;
	LCon.braceStack=[];
	LCon.qStack=[];
	LCon.dOpened=false;
	//theorems
	LCon.theorems = {};
	LCon.commands = {};
	LCon.labels = {};
	LCon.package = [];
	LCon.inTag = '';
	LCon.inTagId = -1;
	LCon.thCount = 0;
	LCon.labelC = 1;
	LCon.headParsed = false;
	//parsowanie nagłówka
	txt = txt.replace(LCon.ree['documentHead'][0], LCon.ree['documentHead'][1]);
	
	
	if(!LCon.headParsed)
	{
		alert('Nie wykryto nagłówka dokumentu.');
	}
	var start = new Date();
	for(rName in LCon.re) {
		txt = txt.replace(LCon.re[rName][0], LCon.re[rName][1]);
	}
	var stop=new Date();
	//for(i in LCon.commands) alert(i+":"+LCon.commands[i]);
	alert('Konwersja w '+(stop.getTime()-start.getTime())+' ms\n\nWersja: '+LCon.version);
	return txt;
}

LCon.convert = function() {
	document.forms[form_name].elements[text_name].value = LCon.LConvert(document.forms[form_name].elements[text_name].value);
}

