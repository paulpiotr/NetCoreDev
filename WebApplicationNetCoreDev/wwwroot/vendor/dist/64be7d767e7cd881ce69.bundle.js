(self.webpackChunk_5_112_1332=self.webpackChunk_5_112_1332||[]).push([[5528],{6378:(e,t,n)=>{e.exports=function(e){var t={};function n(r){if(t[r])return t[r].exports;var o=t[r]={exports:{},id:r,loaded:!1};return e[r].call(o.exports,o,o.exports,n),o.loaded=!0,o.exports}return n.m=e,n.c=t,n.p="",n(0)}({0:function(e,t,n){n(957),e.exports=n(957)},3:function(e,t){e.exports=function(){throw new Error("define cannot be used indirect")}},957:function(e,t,n){var r,o,i;n(3),o=[n(958)],void 0===(i="function"==typeof(r=function(){var e,t,n,r,o,i,a,s,l,u;e=window.kendo.jQuery,t=window.kendo,n=t.Class,r=t.ui.editor,o=r.Dom,i=r.RestorePoint,a=r.Marker,s=e.extend,l=n.extend({init:function(e){this.options=e,this.restorePoint=new i(e.range,e.body,{immutables:e.immutables}),this.marker=new a,this.formatter=e.formatter},getRange:function(){return this.restorePoint.toRange()},lockRange:function(e){return this.marker.add(this.getRange(),e)},releaseRange:function(e){this.marker.remove(e),this.editor.selectRange(e)},undo:function(){var e=this.restorePoint;e.restoreHtml(),this.editor.selectRange(e.toRange())},redo:function(){this.exec()},createDialog:function(n,r){var o=this.editor;return e(n).appendTo(document.body).kendoWindow(s({},o.options.dialogOptions,r)).closest(".k-window").toggleClass("k-rtl",t.support.isRtl(o.wrapper)).end()},exec:function(){var e=this.lockRange(!0);this.formatter.editor=this.editor,this.formatter.toggle(e),this.releaseRange(e)},immutables:function(){return this.editor&&this.editor.options.immutables},expandImmutablesIn:function(e){this.immutables()&&(t.ui.editor.Immutables.expandImmutablesIn(e),this.restorePoint=new i(e,this.editor.body))}}),u=n.extend({init:function(e,t){this.body=e.body,this.startRestorePoint=e,this.endRestorePoint=t},redo:function(){o.removeChildren(this.body),this.body.innerHTML=this.endRestorePoint.html,this.editor.selectRange(this.endRestorePoint.toRange())},undo:function(){o.removeChildren(this.body),this.body.innerHTML=this.startRestorePoint.html,this.editor.selectRange(this.startRestorePoint.toRange())}}),s(r,{_finishUpdate:function(e,t){var n=e.selectionRestorePoint=new i(e.getRange(),e.body),r=new u(t,n);return r.editor=e,e.undoRedoStack.push(r),n},Command:l,GenericCommand:u})})?r.apply(t,o):r)||(e.exports=i)},958:function(e,t){e.exports=n(3673)}})},758:(e,t,n)=>{e.exports=function(e){var t={};function n(r){if(t[r])return t[r].exports;var o=t[r]={exports:{},id:r,loaded:!1};return e[r].call(o.exports,o,o.exports,n),o.loaded=!0,o.exports}return n.m=e,n.c=t,n.p="",n(0)}({0:function(e,t,n){n(959),e.exports=n(959)},3:function(e,t){e.exports=function(){throw new Error("define cannot be used indirect")}},959:function(e,t,n){var r,o,i;n(3),o=[n(960)],void 0===(i="function"==typeof(r=function(){var e,t,n,r,o;e=window.kendo.jQuery,t=window.kendo,n=t.ui.DropDownList,r=t.ui.editor.Dom,o=n.extend({init:function(r,o){var i=this;n.fn.init.call(i,r,o),t.support.mobileOS.ios&&(this._initSelectOverlay(),this.bind("dataBound",e.proxy(this._initSelectOverlay,this))),i.text(i.options.title),i.element.attr("title",i.options.title),i.wrapper.attr("title",i.options.title),i.bind("open",(function(){if(i.options.autoSize){var e,n=i.list;n.css({whiteSpace:"nowrap",width:"auto"}),(e=n.width())>0?e+=20:e=i._listWidth,n.css("width",e+t.support.scrollbar()),i._listWidth=e}}))},options:{name:"SelectBox",index:-1},_initSelectOverlay:function(){for(var n,r=this,o=r.value(),i=this.dataSource.view(),a="",s=t.htmlEncode,l=0;l<i.length;l++)a+="<option value='"+s((n=i[l]).value)+"'",n.value==o&&(a+=" selected"),a+=">"+s(n.text)+"</option>";var u=e("<select class='k-select-overlay'>"+a+"</select>"),c=e(this.element).closest(".k-widget");c.next(".k-select-overlay").remove(),u.insertAfter(c),u.on("change",(function(){r.value(this.value),r.trigger("change")}))},value:function(e){var t=this,r=n.fn.value.call(t,e);if(void 0===e)return r;n.fn.value.call(t)||t.text(t.options.title)},decorate:function(t){var n,o,i,a,s=this.dataSource,l=s.data();for(t&&this.list.css("background-color",r.getEffectiveBackground(e(t))),n=0;n<l.length;n++)o=l[n].tag||"span",i=l[n].className,a=(a=r.inlineStyle(t,o,{className:i})).replace(/"/g,"'"),l[n].style=a+";display:inline-block";s.trigger("change")}}),t.ui.plugin(o),t.ui.editor.SelectBox=o})?r.apply(t,o):r)||(e.exports=i)},960:function(e,t){e.exports=n(9260)}})},4086:(e,t,n)=>{e.exports=function(e){var t={};function n(r){if(t[r])return t[r].exports;var o=t[r]={exports:{},id:r,loaded:!1};return e[r].call(o.exports,o,o.exports,n),o.loaded=!0,o.exports}return n.m=e,n.c=t,n.p="",n(0)}({0:function(e,t,n){n(961),e.exports=n(961)},3:function(e,t){e.exports=function(){throw new Error("define cannot be used indirect")}},961:function(e,t,n){var r,o,i;n(3),o=[n(962)],void 0===(i="function"==typeof(r=function(){!function(e){var t=window.kendo,n=e.map,r=e.extend,o=t.support.browser,i="style",a="float",s="cssFloat",l="styleFloat",u="class",c="k-marker";function d(e){var t,n,r={};for(t=0,n=e.length;t<n;t++)r[e[t]]=!0;return r}var f=d("area,base,basefont,br,col,frame,hr,img,input,isindex,link,meta,param,embed".split(",")),p="p,div,h1,h2,h3,h4,h5,h6,address,applet,blockquote,button,center,dd,dir,dl,dt,fieldset,form,frameset,hr,iframe,isindex,map,menu,noframes,noscript,object,pre,script,table,tbody,td,tfoot,th,thead,tr,header,article,nav,footer,section,aside,main,figure,figcaption".split(","),m=p.concat(["ul","ol","li"]),h=d(m),g=d("area,base,br,col,command,embed,hr,img,input,keygen,link,menuitem,meta,param,source,track,wbr".split(",")),b="span,em,a,abbr,acronym,applet,b,basefont,bdo,big,br,button,cite,code,del,dfn,font,i,iframe,img,input,ins,kbd,label,map,object,q,s,samp,script,select,small,strike,strong,sub,sup,textarea,tt,u,var,data,time,mark,ruby".split(","),v=d(b),y=d("checked,compact,declare,defer,disabled,ismap,multiple,nohref,noresize,noshade,nowrap,readonly,selected".split(",")),N=function(e){1==e.nodeType&&e.normalize()};o.msie&&o.version>=8&&(N=function(e){if(1==e.nodeType&&e.firstChild){var t=e.firstChild,n=t;for(N(n);n=n.nextSibling;)N(n),3==n.nodeType&&3==t.nodeType&&(n.nodeValue=t.nodeValue+n.nodeValue,D.remove(t)),t=n}});var x,w=/^\s+$/,T=/^[\n\r\t]+$/,k=/rgb\s*\(\s*(\d+)\s*,\s*(\d+)\s*,\s*(\d+)\s*\)/i,C=/\ufeff/g,E=/^(\s+|\ufeff)$/,A="color,padding-left,padding-right,padding-top,padding-bottom,background-color,background-attachment,background-image,background-position,background-repeat,border-top-style,border-top-width,border-top-color,border-bottom-style,border-bottom-width,border-bottom-color,border-left-style,border-left-width,border-left-color,border-right-style,border-right-width,border-right-color,font-family,font-size,font-style,font-variant,font-weight,line-height".split(","),_=/[<>\&]/g,O=/[\u00A0-\u2666<>\&]/g,S={34:"quot",38:"amp",39:"apos",60:"lt",62:"gt",160:"nbsp",161:"iexcl",162:"cent",163:"pound",164:"curren",165:"yen",166:"brvbar",167:"sect",168:"uml",169:"copy",170:"ordf",171:"laquo",172:"not",173:"shy",174:"reg",175:"macr",176:"deg",177:"plusmn",178:"sup2",179:"sup3",180:"acute",181:"micro",182:"para",183:"middot",184:"cedil",185:"sup1",186:"ordm",187:"raquo",188:"frac14",189:"frac12",190:"frac34",191:"iquest",192:"Agrave",193:"Aacute",194:"Acirc",195:"Atilde",196:"Auml",197:"Aring",198:"AElig",199:"Ccedil",200:"Egrave",201:"Eacute",202:"Ecirc",203:"Euml",204:"Igrave",205:"Iacute",206:"Icirc",207:"Iuml",208:"ETH",209:"Ntilde",210:"Ograve",211:"Oacute",212:"Ocirc",213:"Otilde",214:"Ouml",215:"times",216:"Oslash",217:"Ugrave",218:"Uacute",219:"Ucirc",220:"Uuml",221:"Yacute",222:"THORN",223:"szlig",224:"agrave",225:"aacute",226:"acirc",227:"atilde",228:"auml",229:"aring",230:"aelig",231:"ccedil",232:"egrave",233:"eacute",234:"ecirc",235:"euml",236:"igrave",237:"iacute",238:"icirc",239:"iuml",240:"eth",241:"ntilde",242:"ograve",243:"oacute",244:"ocirc",245:"otilde",246:"ouml",247:"divide",248:"oslash",249:"ugrave",250:"uacute",251:"ucirc",252:"uuml",253:"yacute",254:"thorn",255:"yuml",402:"fnof",913:"Alpha",914:"Beta",915:"Gamma",916:"Delta",917:"Epsilon",918:"Zeta",919:"Eta",920:"Theta",921:"Iota",922:"Kappa",923:"Lambda",924:"Mu",925:"Nu",926:"Xi",927:"Omicron",928:"Pi",929:"Rho",931:"Sigma",932:"Tau",933:"Upsilon",934:"Phi",935:"Chi",936:"Psi",937:"Omega",945:"alpha",946:"beta",947:"gamma",948:"delta",949:"epsilon",950:"zeta",951:"eta",952:"theta",953:"iota",954:"kappa",955:"lambda",956:"mu",957:"nu",958:"xi",959:"omicron",960:"pi",961:"rho",962:"sigmaf",963:"sigma",964:"tau",965:"upsilon",966:"phi",967:"chi",968:"psi",969:"omega",977:"thetasym",978:"upsih",982:"piv",8226:"bull",8230:"hellip",8242:"prime",8243:"Prime",8254:"oline",8260:"frasl",8472:"weierp",8465:"image",8476:"real",8482:"trade",8501:"alefsym",8592:"larr",8593:"uarr",8594:"rarr",8595:"darr",8596:"harr",8629:"crarr",8656:"lArr",8657:"uArr",8658:"rArr",8659:"dArr",8660:"hArr",8704:"forall",8706:"part",8707:"exist",8709:"empty",8711:"nabla",8712:"isin",8713:"notin",8715:"ni",8719:"prod",8721:"sum",8722:"minus",8727:"lowast",8730:"radic",8733:"prop",8734:"infin",8736:"ang",8743:"and",8744:"or",8745:"cap",8746:"cup",8747:"int",8756:"there4",8764:"sim",8773:"cong",8776:"asymp",8800:"ne",8801:"equiv",8804:"le",8805:"ge",8834:"sub",8835:"sup",8836:"nsub",8838:"sube",8839:"supe",8853:"oplus",8855:"otimes",8869:"perp",8901:"sdot",8968:"lceil",8969:"rceil",8970:"lfloor",8971:"rfloor",9001:"lang",9002:"rang",9674:"loz",9824:"spades",9827:"clubs",9829:"hearts",9830:"diams",338:"OElig",339:"oelig",352:"Scaron",353:"scaron",376:"Yuml",710:"circ",732:"tilde",8194:"ensp",8195:"emsp",8201:"thinsp",8204:"zwnj",8205:"zwj",8206:"lrm",8207:"rlm",8211:"ndash",8212:"mdash",8216:"lsquo",8217:"rsquo",8218:"sbquo",8220:"ldquo",8221:"rdquo",8222:"bdquo",8224:"dagger",8225:"Dagger",8240:"permil",8249:"lsaquo",8250:"rsaquo",8364:"euro"},D={block:h,inline:v,findNodeIndex:function(e,t){var n=0;if(!e)return-1;for(;e=e.previousSibling;)t&&3==e.nodeType||n++;return n},isDataNode:function(e){return e&&null!==e.nodeValue&&null!==e.data},isAncestorOf:function(t,n){try{return!D.isDataNode(t)&&(e.contains(t,D.isDataNode(n)?n.parentNode:n)||n.parentNode==t)}catch(e){return!1}},isAncestorOrSelf:function(e,t){return D.isAncestorOf(e,t)||e==t},findClosestAncestor:function(e,t){if(D.isAncestorOf(e,t))for(;t&&t.parentNode!=e;)t=t.parentNode;return t},getAllComments:function(e){for(var t=[],n=document.createNodeIterator(e,NodeFilter.SHOW_COMMENT,(function(){return NodeFilter.FILTER_ACCEPT}),!1),r=n.nextNode();r;)t.push(r.nodeValue),r=n.nextNode();return t},getNodeLength:function(e){return D.isDataNode(e)?e.length:e.childNodes.length},splitDataNode:function(e,t){for(var n,r=e.cloneNode(!1),o="",i=e.nextSibling;i&&3==i.nodeType&&i.nodeValue;)o+=i.nodeValue,n=i,i=i.nextSibling,D.remove(n);e.deleteData(t,e.length),r.deleteData(0,t),r.nodeValue+=o,D.insertAfter(r,e)},attrEquals:function(e,n){for(var r in n){var o=e[r];if(r==a&&(o=e[t.support.cssFloat?s:l]),"object"==typeof o){if(!D.attrEquals(o,n[r]))return!1}else if(o!=n[r])return!1}return!0},blockParentOrBody:function(e){return D.parentOfType(e,m)||e.ownerDocument.body},blockParents:function(t){var n,r,o=[];for(n=0,r=t.length;n<r;n++){var i=D.parentOfType(t[n],D.blockElements);i&&e.inArray(i,o)<0&&o.push(i)}return o},windowFromDocument:function(e){return e.defaultView||e.parentWindow},normalize:N,blockElements:m,nonListBlockElements:p,inlineElements:b,empty:f,fillAttrs:y,nodeTypes:{ELEMENT_NODE:1,ATTRIBUTE_NODE:2,TEXT_NODE:3,CDATA_SECTION_NODE:4,ENTITY_REFERENCE_NODE:5,ENTITY_NODE:6,PROCESSING_INSTRUCTION_NODE:7,COMMENT_NODE:8,DOCUMENT_NODE:9,DOCUMENT_TYPE_NODE:10,DOCUMENT_FRAGMENT_NODE:11,NOTATION_NODE:12},toHex:function(e){var t=k.exec(e);return t?"#"+n(t.slice(1),(function(e){return(e=parseInt(e,10).toString(16)).length>1?e:"0"+e})).join(""):e},encode:function(e,t){var n=!t||t.entities?O:_;return e.replace(n,(function(e){var t=e.charCodeAt(0),n=S[t];return n?"&"+n+";":e}))},isBom:function(e){return e&&3===e.nodeType&&/^[\ufeff]+$/.test(e.nodeValue)},stripBom:function(e){return(e||"").replace(C,"")},stripBomNode:function(e){D.isBom(e)&&e.parentNode.removeChild(e)},insignificant:function(e){var t=e.attributes;return"k-marker"==e.className||D.is(e,"br")&&("k-br"==e.className||t._moz_dirty||t._moz_editor_bogus_node)||D.is(e,"span")&&"k-br"==e.className},tableCell:function(e){return D.is(e,"td")||D.is(e,"th")},significantNodes:function(t){return e.grep(t,(function(e){var t=D.name(e);return!("br"==t||D.insignificant(e)||D.emptyTextNode(e)||1==e.nodeType&&!f[t]&&D.emptyNode(e))}))},emptyTextNode:function(e){return e&&3==e.nodeType&&E.test(e.nodeValue)},emptyNode:function(e){return 1==e.nodeType&&!D.significantNodes(e.childNodes).length},name:function(e){return e.nodeName.toLowerCase()},significantChildNodes:function(t){return e.grep(t.childNodes,(function(e){return 3!=e.nodeType||!D.isWhitespace(e)}))},lastTextNode:function(e){var t=null;if(3==e.nodeType)return e;for(var n=e.lastChild;n;n=n.previousSibling)if(t=D.lastTextNode(n))return t;return t},is:function(e,t){return e&&D.name(e)==t},isMarker:function(e){return e.className==c},isWhitespace:function(e){return w.test(e.nodeValue)},allWhitespaceContent:function(e){for(var t=e.firstChild;t&&D.isWhitespace(t);)t=t.nextSibling;return!t},isEmptyspace:function(e){return T.test(e.nodeValue)},htmlIndentSpace:function(t){if(!D.isDataNode(t)||!D.isWhitespace(t))return!1;if(T.test(t.nodeValue))return!0;var n=function(e,t){for(;e[t];)if(e=e[t],D.significantNodes([e]).length>0)return e},r=t.parentNode,o=n(t,"previousSibling"),i=n(t,"nextSibling");if(C.test(t.nodeValue))return!(!o&&!i);if(e(r).is("tr,tbody,thead,tfoot,table,ol,ul"))return!0;if(D.isBlock(r)||D.is(r,"body")){var a=o&&D.isBlock(o),s=i&&D.isBlock(i);if(!i&&a||!o&&s||a&&s)return!0}return!1},isBlock:function(e){return h[D.name(e)]},isSelfClosing:function(e){return g[D.name(e)]},isEmpty:function(e){return f[D.name(e)]},isInline:function(e){return v[D.name(e)]},isBr:function(e){return"br"==D.name(e)},list:function(e){var t=e?D.name(e):"";return"ul"==t||"ol"==t||"dl"==t},scrollContainer:function(e){var t=D.windowFromDocument(e),n=(t.contentWindow||t).document||t.ownerDocument||t;return"BackCompat"==n.compatMode?n.body:n.scrollingElement||n.documentElement},scrollTo:function(t,n){var r,o,i,a,s=t.ownerDocument,l=D.windowFromDocument(s).innerHeight,u=D.scrollContainer(s);D.isDataNode(t)?n?(a=D.create(s,"span",{innerHTML:"&#xfeff;"}),D.insertBefore(a,t),r=e(a)):r=e(t.parentNode):r=e(t),o=r.offset().top,i=r[0].offsetHeight,!n&&i||(i=parseInt(r.css("line-height"),10)||Math.ceil(1.2*parseInt(r.css("font-size"),10))||15),a&&D.remove(a),i+o>u.scrollTop+l&&(u.scrollTop=i+o-l)},persistScrollTop:function(e){x=D.scrollContainer(e).scrollTop},offset:function(e,t){for(var n={top:e.offsetTop,left:e.offsetLeft},r=e.offsetParent;r&&(!t||D.isAncestorOf(t,r));)n.top+=r.offsetTop,n.left+=r.offsetLeft,r=r.offsetParent;return n},restoreScrollTop:function(e){"number"==typeof x&&(D.scrollContainer(e).scrollTop=x,x=void 0)},insertAt:function(e,t,n){e.insertBefore(t,e.childNodes[n]||null)},insertBefore:function(e,t){return t.parentNode?t.parentNode.insertBefore(e,t):t},insertAfter:function(e,t){return t.parentNode.insertBefore(e,t.nextSibling)},remove:function(e){e.parentNode&&e.parentNode.removeChild(e)},removeChildren:function(e){for(;e.firstChild;)e.removeChild(e.firstChild)},removeTextSiblings:function(e){for(var t=e.parentNode;e.nextSibling&&3==e.nextSibling.nodeType;)t.removeChild(e.nextSibling);for(;e.previousSibling&&3==e.previousSibling.nodeType;)t.removeChild(e.previousSibling)},trim:function(e){for(var t=e.childNodes.length-1;t>=0;t--){var n=e.childNodes[t];D.isDataNode(n)?D.stripBom(n.nodeValue).length||D.remove(n):n.className!=c&&(D.trim(n),(!D.isEmpty(n)&&0===n.childNodes.length||D.isBlock(n)&&D.allWhitespaceContent(n))&&D.remove(n))}return e},closest:function(e,t){for("string"==typeof t&&(t=[t]);e&&t.indexOf(D.name(e))<0;)e=e.parentNode;return e},closestBy:function(e,t,n){for(;e&&!t(e);){if(n&&n(e))return null;e=e.parentNode}return e},sibling:function(e,t){do{e=e[t]}while(e&&1!=e.nodeType);return e},next:function(e){return D.sibling(e,"nextSibling")},prev:function(e){return D.sibling(e,"previousSibling")},parentOfType:function(e,t){do{e=e.parentNode}while(e&&!D.ofType(e,t));return e},ofType:function(t,n){return e.inArray(D.name(t),n)>=0},changeTag:function(e,t,n){var r,o,a,s,l,c=D.create(e.ownerDocument,t),d=e.attributes;if(!n)for(r=0,o=d.length;r<o;r++)(l=d[r]).specified&&(a=l.nodeName,s=l.nodeValue,a==u?c.className=s:a==i?c.style.cssText=e.style.cssText:c.setAttribute(a,s));for(;e.firstChild;)c.appendChild(e.firstChild);return D.insertBefore(c,e),D.remove(e),c},editableParent:function(e){for(;e&&(3==e.nodeType||"true"!==e.contentEditable);)e=e.parentNode;return e},wrap:function(e,t){return D.insertBefore(t,e),t.appendChild(e),t},unwrap:function(e){for(var t=e.parentNode;e.firstChild;)t.insertBefore(e.firstChild,e);t.removeChild(e)},wrapper:function(t){var n=D.closestBy(t,(function(e){return e.parentNode&&D.significantNodes(e.parentNode.childNodes).length>1}));return e(n).is("body,.k-editor")?void 0:n},create:function(e,t,n){return D.attr(e.createElement(t),n)},createEmptyNode:function(e,t,n){var r=D.attr(e.createElement(t),n);return r.innerHTML="\ufeff",r},attr:function(e,t){for(var n in(t=r({},t))&&i in t&&(D.style(e,t.style),delete t.style),t)null===t[n]?(e.removeAttribute(n),delete t[n]):"className"==n&&(e[n]=t[n]);return r(e,t)},mergeAttributes:function(t,n,r){t.attributes.length&&e.each(t.attributes,(function(){"contenteditable"===this.name||r&&this.name===i||e(n).attr(this.name,this.value),r&&this.name===i&&e.each(t.style,(function(){n.style[this]=t.style[this]}))}))},style:function(t,n){e(t).css(n||{})},unstyle:function(e,n){for(var r in n)r==a&&(r=t.support.cssFloat?s:l),e.style[r]="";""===e.style.cssText&&e.removeAttribute(i)},inlineStyle:function(t,r,i){var a,s=e(D.create(t.ownerDocument,r,i));return t.appendChild(s[0]),a=n(A,(function(e){return o.msie&&"line-height"==e&&"1px"==s.css(e)?"line-height:1.5":e+":"+s.css(e)})).join(";"),s.remove(),a},getEffectiveBackground:function(e){var t=e.css("background-color")||"";return t.indexOf("rgba(0, 0, 0, 0")<0&&"transparent"!==t?t:"html"===e[0].tagName.toLowerCase()?"Window":D.getEffectiveBackground(e.parent())},innerText:function(e){var t=e.innerHTML;return(t=t.replace(/<!--(.|\s)*?-->/gi,"")).replace(/<\/?[^>]+?\/?>/gm,"")},removeClass:function(e,n){var r,o,i=" "+e.className+" ",a=n.split(" ");for(r=0,o=a.length;r<o;r++)i=i.replace(" "+a[r]+" "," ");(i=t.trim(i)).length?e.className=i:e.removeAttribute(u)},commonAncestor:function(){var e,t,n,r,o,i=arguments.length,a=[],s=1/0,l=null;if(!i)return null;if(1==i)return arguments[0];for(e=0;e<i;e++){for(t=[],n=arguments[e];n;)t.push(n),n=n.parentNode;a.push(t.reverse()),s=Math.min(s,t.length)}if(1==i)return a[0][0];for(e=0;e<s;e++){for(r=a[0][e],o=1;o<i;o++)if(r!=a[o][e])return l;l=r}return l},closestSplittableParent:function(t){var r;(r=1==t.length?D.parentOfType(t[0],["ul","ol"]):D.commonAncestor.apply(null,t))||(r=D.parentOfType(t[0],["p","td"])||t[0].ownerDocument.body),D.isInline(r)&&(r=D.blockParentOrBody(r));var o=n(t,D.editableParent),i=D.commonAncestor(o)[0];return e.contains(r,i)&&(r=i),r},closestEditable:function(t,n){var r,o=D.editableParent(t);return((r=D.ofType(t,n)?t:D.parentOfType(t,n))&&o&&e.contains(r,o)||!r&&o)&&(r=o),r},closestEditableOfType:function(t,n){var r=D.closestEditable(t,n);if(r&&D.ofType(r,n)&&!e(r).is(".k-editor"))return r},filter:function(e,t,n){return D.filterBy(t,(function(t){return D.name(t)==e}),n)},filterBy:function(e,t,n){for(var r,o=0,i=e.length,a=[];o<i;o++)((r=t(e[o]))&&!n||!r&&n)&&a.push(e[o]);return a},ensureTrailingBreaks:function(t){var n=e(t).find("p,td,th"),r=n.length,o=0;if(r)for(;o<r;o++)D.ensureTrailingBreak(n[o]);else D.ensureTrailingBreak(t)},removeTrailingBreak:function(t){e(t).find("br[type=_moz],.k-br").remove()},ensureTrailingBreak:function(e){D.removeTrailingBreak(e);var t,n=e.lastChild,r=n&&D.name(n);(!r||"br"!=r&&"img"!=r||"br"==r&&"k-br"!=n.className)&&((t=e.ownerDocument.createElement("br")).className="k-br",e.appendChild(t))},reMapTableColumns:function(e,t){D._mapColIndices(e,t)},clearTableMappings:function(t,n){e(t).find("["+n+"]").removeAttr(n)},_mapColIndices:function(e,t){for(var n={},r=0;r<e.rows.length;r++)for(var o=e.rows[r].cells,i=0,a=0;a<o.length;a++,i++){var s=o[a];if(s.rowSpan>1&&this._mapColspan(s,r,i,n),n[r])for(;n[r][i];)i++;s.setAttribute(t,i),s.colSpan>1&&(i=i+s.colSpan-1)}},_mapColspan:function(e,t,n,r){for(var o,i=e.rowSpan,a=e.colSpan,s=0;s<a;s++){o=n+s;for(var l=t+1;l<t+i;l++){if(r[l]||(r[l]={},r[l].length=0),r[t])for(;r[t][o];)o++;r[l][o]=!0,r[l].length++}}},associateWithIds:function(e){var t,n,r=this,o=0,i=e.rows,a=i.length,s=[],l=[];if(e.tHead)o=(t=e.tHead.rows).length;else for(o=r._getNumberOfHeaderRows(e),t=[],n=0;n<o;n++)t.push(i[n]);for(n=0;n<o;n++)s.push([]);for(n=0;n<a;n++)l.push([]);r._generateIdsForColumns(s,t),r._generateIdsForRows(s,l,o,i),r._assignIds(s,l,o,i)},_generateIdsForColumns:function(e,t){var n,r,o,i,a,s,l,u,c,d,f=(new Date).getTime(),p=t?t.length:0;for(l=0;l<p;l++)for(n=t[l].cells,o=0,u=0;u<n.length;u++){for(i="table"+l+u+ ++f,(r=n[u]).setAttribute("id",i),a=r.getAttribute("colspan")||1,s=r.getAttribute("rowspan")||1;e[l][u+o];)o+=1;for(c=0;c<s;c++)for(d=0;d<a;d++)e[l+c][u+o+d]=i}},_generateIdsForRows:function(t,n,r,o){var i,a,s,l,u,c,d,f,p,m,h,g,b,v=(new Date).getTime(),y=o.length,N=function(e){b.push(e[g])};for(f=r;f<y;f++)for(i=o[f],a=e(i.cells).filter("th"),l=0,p=0;p<a.length;p++){for(u="table"+f+p+ ++v,(s=a[p]).setAttribute("id",u),c=s.getAttribute("colspan")||1,d=s.getAttribute("rowspan")||1;n[f][p+l];)l+=1;for(m=0;m<d;m++)for(h=0;h<c;h++)n[f+m][p+l+h]=u;g=s.getAttribute("col-index"),b=[],t.forEach(N),b=b.filter(this._onlyUnique),s.setAttribute("headers",b.join(" ").trim())}},_assignIds:function(t,n,r,o){var i,a,s,l,u,c,d,f=o.length,p=function(e){d.push(e[c])};for(l=r;l<f;l++)for(i=o[l],a=e(i.cells).filter("td"),u=0;u<a.length;u++)s=a[u],c=s.getAttribute("col-index"),d=n[l].slice(),t.forEach(p),d=d.filter(this._onlyUnique),s.setAttribute("headers",d.join(" ").trim())},_getNumberOfColumns:function(t){var n,r,o,i=e(t).find("th, td"),a=0;for(r=0;r<i.length;r++)n=i[r],(o=Number(n.getAttribute("col-index"))+1)>a&&(a=o);return a},_getNumberOfHeaderColumns:function(e,t){var n,r,o,i,a,s=e.rows,l=0;for(o=t;o<s.length;o++)for(r=s[o],i=0;i<r.cells.length;i++)a=r.cells[i],this.is(a,"th")&&(n=Number(a.getAttribute("col-index"))+1)>l&&(l=n);return l},_getNumberOfHeaderRows:function(e){var t,n,r,o,i=e.rows,a=e.tHead&&e.tHead.rows?e.tHead.rows.length:0;if(0===a)for(o=(n=i[0]).cells&&n.cells.length;n&&o&&this.is(n.cells[0],"th");){for(t=0;t<o;t++)r=n?n.cells[t]:null,this.is(r,"th")||(n=null);n&&(a+=1,o=(n=this.next(n))&&n.cells&&n.cells.length)}return a},_onlyUnique:function(e,t,n){return n.indexOf(e)===t}};t.ui.editor.Dom=D}(window.kendo.jQuery)})?r.apply(t,o):r)||(e.exports=i)},962:function(e,t){e.exports=n(5846)}})},3673:(e,t,n)=>{e.exports=function(e){var t={};function n(r){if(t[r])return t[r].exports;var o=t[r]={exports:{},id:r,loaded:!1};return e[r].call(o.exports,o,o.exports,n),o.loaded=!0,o.exports}return n.m=e,n.c=t,n.p="",n(0)}({0:function(e,t,n){n(963),e.exports=n(963)},3:function(e,t){e.exports=function(){throw new Error("define cannot be used indirect")}},963:function(e,t,n){var r,o,i;n(3),o=[n(964)],void 0===(i="function"==typeof(r=function(){var e,t,n,r,o,i,a,s,l,u,c,d,f,p,m,h,g;e=window.kendo.jQuery,t=window.kendo,n=t.Class,r=t.ui.editor,o=r.Dom,i=t.template,a=r.RangeUtils,s=["ul","ol","tbody","thead","table"],l="k-immutable",u="[k-immutable]",c=function(t){return e(t).is("body,.k-editor")},d=function(e){return e.getAttribute&&"false"==e.getAttribute("contenteditable")},f=function(e){return o.closestBy(e,d,c)},p=function(e){return!!f(e.commonAncestorContainer)||!(!f(e.startContainer)&&!f(e.endContainer)||0!==a.editableTextNodes(e).length)},m=function(e){for(var t="",n="0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ",r=e||10;r>0;--r)t+=n.charAt(Math.round(Math.random()*(n.length-1)));return t},h=function(e){var t=e?e.options:void 0;t&&t.finder&&t.finder._initOptions({immutables:!0})},(g=n.extend({init:function(t){this.editor=t,this.serializedImmutables={},this.options=e.extend({},t&&t.options&&t.options.immutables);var n=t.toolbar.tools;h(n.justifyLeft),h(n.justifyCenter),h(n.justifyRight),h(n.justifyFull)},serialize:function(e){var t,n=this._toHtml(e);return-1===n.indexOf(l)?(t=this.randomId(),n=n.replace(/>/,' k-immutable="'+t+'">')):t=n.match(/k-immutable\s*=\s*['"](.*)['"]/)[1],this.serializedImmutables[t]=e,n},_toHtml:function(e){var t,n=this.options.serialization;switch(typeof n){case"string":return i(n)(e);case"function":return n(e);default:return"<"+(t=o.name(e))+"></"+t+">"}},deserialize:function(n){var r=this,o=this.options.deserialization;e(u,n).each((function(){var n=this.getAttribute(l),i=r.serializedImmutables[n];t.isFunction(o)&&o(this,i),e(this).replaceWith(i)})),r.serializedImmutables={}},randomId:function(e){return m(e)},keydown:function(e,n){var r,o,i=(r=e.keyCode,o=t.keys,r===o.BACKSPACE||r==o.DELETE);if(i&&this._cancelDeleting(e,n)||!i&&this._cancelTyping(e,n))return e.preventDefault(),!0},_cancelTyping:function(e,t){var n=this.editor.keyboard;return t.collapsed&&!n.typingInProgress&&n.isTypingKey(e)&&p(t)},_cancelDeleting:function(e,n){var r=t.keys,i=e.keyCode===r.BACKSPACE,a=e.keyCode==r.DELETE;if(!i&&!a)return!1;var l=!1;if(n.collapsed){if(p(n))return!0;var u=this.nextImmutable(n,a);if(u&&i){var c=o.closest(n.commonAncestorContainer,"li");if(c){var d=o.closest(u,"li");if(d&&d!==c)return l}}if(u&&!o.tableCell(u)){if(o.parentOfType(u,s)===o.parentOfType(n.commonAncestorContainer,s)){for(;u&&1==u.parentNode.childNodes.length;)u=u.parentNode;if(o.tableCell(u))return l;this._removeImmutable(u,n)}l=!0}}return l},nextImmutable:function(e,t){var n=e.commonAncestorContainer;if(o.isBom(n)||t&&a.isEndOf(e,n)||!t&&a.isStartOf(e,n)){var r=this._nextNode(n,t);if(r&&o.isBlock(r)&&!f(r))for(;r&&r.children&&r.children[t?0:r.children.length-1];)r=r.children[t?0:r.children.length-1];return f(r)}},_removeImmutable:function(e,t){var n=this.editor,i=new r.RestorePoint(t,n.body);o.remove(e),r._finishUpdate(n,i)},_nextNode:function(e,t){for(var n,r=t?"nextSibling":"previousSibling",i=e;i&&!n;)(n=i[r])&&o.isDataNode(n)&&/^\s|[\ufeff]$/.test(n.nodeValue)&&(n=(i=n)[r]),n||(i=i.parentNode);return n}})).immutable=d,g.immutableParent=f,g.expandImmutablesIn=function(e){var t=f(e.startContainer),n=f(e.endContainer);(t||n)&&(t&&e.setStartBefore(t),n&&e.setEndAfter(n))},g.immutablesContext=p,g.toolsToBeUpdated=["bold","italic","underline","strikethrough","superscript","subscript","forecolor","backcolor","fontname","fontsize","createlink","unlink","autolink","addcolumnleft","addcolumnright","addrowabove","addrowbelow","deleterow","deletecolumn","mergecells","formatting","cleanformatting"],g.removeImmutables=function(t){var n,r,i,a={empty:!0};return e(t).find("[contenteditable='false']").each((function(t,s){n=o.name(s),r=m(),i="<"+n+" k-immutable='"+r+"'></"+n+">",a[r]={node:s,style:e(s).attr("style")},a.empty=!1,e(s).replaceWith(i)})),a},g.restoreImmutables=function(t,n){var r,o;e(t).find(u).each((function(t,i){r=i.getAttribute(l),o=n[r],e(i).replaceWith(o.node),o.style!=e(o.node).attr("style")&&e(o.node).removeAttr("style").attr("style",o.style)}))},r.Immutables=g})?r.apply(t,o):r)||(e.exports=i)},964:function(e,t){e.exports=n(3538)}})}}]);