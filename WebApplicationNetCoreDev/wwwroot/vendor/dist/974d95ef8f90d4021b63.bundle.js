(self.webpackChunk_5_112_1332=self.webpackChunk_5_112_1332||[]).push([[5604],{4688:(e,t,n)=>{e.exports=function(e){var t={};function n(o){if(t[o])return t[o].exports;var r=t[o]={exports:{},id:o,loaded:!1};return e[o].call(r.exports,r,r.exports,n),r.loaded=!0,r.exports}return n.m=e,n.c=t,n.p="",n(0)}({0:function(e,t,n){n(1589),e.exports=n(1589)},3:function(e,t){e.exports=function(){throw new Error("define cannot be used indirect")}},964:function(e,t){e.exports=n(32)},1589:function(e,t,n){var o,r,i;n(3),r=[n(1590),n(964)],void 0===(i="function"==typeof(o=function(){"use strict";var e=kendo.spreadsheet,t=e.Range,n=e.calc.runtime.Formula,o="incompatibleRanges",r=t.FillError=function(e){this.code=e};function i(e){for(var t=e.length,n=(t+1)/2,o=e.reduce((function(e,t){return e+t}),0)/t,r=0,i=0,s=0;s<t;s++){var a=s+1-n;r+=a*(e[s]-o),i+=a*a}if(!i)return function(t){return e[t%e.length]};var l=r/i,u=o-l*n;return function(e){return u+l*(e+1)}}function s(e){function t(e){return e.map((function(e){return e.number}))}var o=[],r=e.map((function(e){return e.formula||e.value}));return function(e,t){for(var n,o=null,r=0,i=[],s=0;s<e.length;++s)n=a(e[s]),i.push(n),null!=o&&n.type!==o.type&&(t(r,s,o.type,i.slice(r,s)),r=s),o=n;t(r,s,o.type,i.slice(r,s))}(r,(function(e,n,s,a){var l,u;if("number"==s)l=i(u=t(a));else if("string"==s||"formula"==s||"boolean"==s)l=function(e,t){return r[t]};else if(Array.isArray(s))if(1==a.length)l=function(e){return s[(a[0].number+e)%s.length]};else{var c=function(e){for(var t=e[1]-e[0],n=2;n<e.length;++n)if(e[n]-e[n-1]!=t)return null;return t}(t(a));l=null==c?function(e){return a[e%a.length].value}:function(e){var t=a[0].number+c*e;return s[t%s.length]}}else"null"!=s?(1==(u=t(a)).length&&u.push(u[0]+1),u=i(u),l=function(e,t){return r[t].replace(/^(.*\D)\d+/,"$1"+u(e,t))}):l=function(){return null};for(var h={f:l,begin:e,end:n,len:n-e},d=e;d<n;++d)o[d]=h})),function(t,i){var s,a,l=o[i],u=t/r.length|0,c=t%r.length,h=u*l.len+c-l.begin,d=l.f(h,i),f=(s=e[i],a={},Object.keys(s||{}).forEach((function(e){a[e]=s[e]})),a);return delete f.enable,d instanceof n?f.formula=d:f.value=d,f}}function a(e){if("number"==typeof e)return{type:"number",number:e};if("string"==typeof e){var t=function(e){for(var t=e.toLowerCase(),n=(s=void 0,s=kendo.culture(),[s.calendars.standard.days.namesAbbr,s.calendars.standard.days.names,s.calendars.standard.months.namesAbbr,s.calendars.standard.months.names]),o=0;o<n.length;++o)for(var r=n[o],i=r.length;--i>=0;)if(r[i].toLowerCase()==t)return{type:r,number:i,value:e};var s}(e);if(t)return t;var o=/^(.*\D)(\d+)/.exec(e);return o?{type:e=e.replace(/^(.*\D)\d+/,"$1-######"),match:o,number:parseFloat(o[2])}:{type:"string"}}if("boolean"==typeof e)return{type:"boolean"};if(null==e)return{type:"null"};if(e instanceof n)return{type:"formula"};throw window.console.error(e),new Error("Cannot fill data")}function l(e){for(var t=e.length,n=e[0].length,o=[],r=0;r<n;++r){o[r]=[];for(var i=0;i<t;++i)o[r][i]=e[i][r]}return o}t.prototype._previewFillFrom=function(e,t){var n=this,i=n._sheet;"string"==typeof e&&(e=i.range(e));var a=e._ref.toRangeRef().clone().setSheet(i.name()),u=n._ref.toRangeRef().clone().setSheet(i.name());if(a.intersects(u)){if(a.eq(u))return null;if(u=u.clone(),a.topLeft.eq(u.topLeft))if(a.width()==u.width())u.topLeft.row+=a.height(),t=0;else{if(a.height()!=u.height())throw new r(o);u.topLeft.col+=a.width(),t=1}else{if(!a.bottomRight.eq(u.bottomRight))throw new r(o);if(a.width()==u.width())u.bottomRight.row-=a.height(),t=2;else{if(a.height()!=u.height())throw new r(o);u.bottomRight.col-=a.width(),t=3}}return i.range(u)._previewFillFrom(e,t)}if(null==t)if(a.topLeft.col==u.topLeft.col)t=a.topLeft.row<u.topLeft.row?0:2;else{if(a.topLeft.row!=u.topLeft.row)throw new r("noFillDirection");t=a.topLeft.col<u.topLeft.col?1:3}var c=1&t,h=2&t;if(c&&a.height()!=u.height()||!c&&a.width()!=u.width())throw new r(o);var d,f=e._properties();c?d=u.width():(f=l(f),d=u.height());for(var p=new Array(f.length),v=null,b=0;b<f.length;++b)for(var m=f[b],w=s(m),g=p[b]=new Array(d),_=0;_<d;++_){var x=h?-_-1:m.length+_,C=h?m.length-_%m.length-1:_%m.length,R=g[h?d-_-1:_]=w(x,C);null!=R.value&&(v=R.value)}return c||(p=l(p)),{props:p,direction:t,dest:n,hint:v}},t.prototype.fillFrom=function(e,t){var n=this._previewFillFrom(e,t);return n.dest._properties(n.props,!0),n.dest}})?o.apply(t,r):o)||(e.exports=i)},1590:function(e,t){e.exports=n(4541)}})},5256:(e,t,n)=>{e.exports=function(e){var t={};function n(o){if(t[o])return t[o].exports;var r=t[o]={exports:{},id:o,loaded:!1};return e[o].call(r.exports,r,r.exports,n),r.loaded=!0,r.exports}return n.m=e,n.c=t,n.p="",n(0)}({0:function(e,t,n){n(1591),e.exports=n(1591)},3:function(e,t){e.exports=function(){throw new Error("define cannot be used indirect")}},20:function(e,t){e.exports=n(1657)},1591:function(e,t,n){var o,r,i;n(3),r=[n(20)],void 0===(i="function"==typeof(o=function(){!function(e){var t=e.spreadsheet.RangeRef,n=e.spreadsheet.CellRef,o=e.Class.extend({init:function(e){this._grid=e},rectIsVertical:function(e,t,n,o){var r=this._grid.rectangle(e.toRangeRef()),i=this._grid.rectangle(t.toRangeRef());return Math.abs(i[o]-r[o])>Math.abs(r[n]-i[n])},autoFillDest:function(e,o){var r,i,s,a,l=e.topLeft,u=e.bottomRight,c=o.row>=l.row,h=o.col>=l.col;if(4==(r=c?h?4:3:h?2:1))i=l,s=u,(o.row>s.row||o.col>s.col)&&(o=new n(Math.max(o.row,s.row),Math.max(o.col,s.col))),a=this.rectIsVertical(s,o,"right","bottom")?new n(o.row,s.col):new n(s.row,o.col);else if(3===r){var d=new n(l.col,u.row);o.row>u.row&&this.rectIsVertical(d,o,"left","bottom")?(i=l,a=new n(o.row,u.col)):(i=u,a=new n(l.row,o.col))}else if(2===r){var f=new n(l.row,u.col);o.col>u.col&&!this.rectIsVertical(f,o,"right","top")?(i=l,a=new n(u.row,o.col)):(i=u,a=new n(o.row,l.col))}else i=u,a=this.rectIsVertical(l,o,"left","top")?new n(o.row,l.col):new n(l.row,o.col);return this._grid.normalize(new t(i,a))}});e.spreadsheet.AutoFillCalculator=o}(kendo)})?o.apply(t,r):o)||(e.exports=i)}})},4584:(e,t,n)=>{e.exports=function(e){var t={};function n(o){if(t[o])return t[o].exports;var r=t[o]={exports:{},id:o,loaded:!1};return e[o].call(r.exports,r,r.exports,n),r.loaded=!0,r.exports}return n.m=e,n.c=t,n.p="",n(0)}({0:function(e,t,n){n(1592),e.exports=n(1592)},3:function(e,t){e.exports=function(){throw new Error("define cannot be used indirect")}},20:function(e,t){e.exports=n(1657)},1592:function(e,t,n){var o,r,i;n(3),r=[n(20)],void 0===(i="function"==typeof(o=function(){!function(e){var t=e.Class.extend({init:function(t,n){this._value=n,this._count=t,this.values=new e.spreadsheet.RangeList(0,t-1,n),this._hidden=new e.spreadsheet.RangeList(0,t-1,0),this.scrollBarSize=e.support.scrollbar(),this._refresh()},adjust:function(e,t){t<0?(this.values.copy(e-t,this._count-1,e),this._hidden.copy(e-t,this._count-1,e)):(this.values.copy(e,this._count,e+t),this._hidden.copy(e,this._count,e+t),this.values.value(e,e+t-1,this._value),this._hidden.value(e,e+t-1,0)),this._refresh()},toJSON:function(e,t){for(var n=[],o=this.values.iterator(0,this._count-1),r=0;r<this._count;r++){var i=o.at(r),s=this._hidden.value(r,r);if(i!==this._value||s){var a=t[r];if(void 0===a){a=n.length;var l={index:r};l[e]=i,s&&(l.hidden=s),n.push(l),t[r]=a}}}return n},fromJSON:function(e,t){for(var n=0;n<t.length;n++){var o=t[n],r=o.index;void 0===r&&(r=n);var i=o[e];0===i?(this._hidden.value(r,r,o.hidden||this._value),this.value(r,r,0)):this.value(r,r,i)}},hide:function(e){if(!this.hidden(e)){var t=this.value(e,e);this._hidden.value(e,e,t),this.value(e,e,0)}},hidden:function(e){return 0!==this._hidden.value(e,e)},includesHidden:function(e,t){return this._hidden.intersecting(e,t).length>1},nextVisible:function(e){for(var t=this._count-1,n=e;++n<=t;)if(!this.hidden(n))return n;return e},nextUntil:function(e,t){for(var n=this._count-1,o=e,r=!1;++o<=n;){var i=t(o,r,this.hidden(o));if("number"==typeof i)return i;if(i)break;r=!0}return o-1},nextPage:function(e,t){return this.index(this.sum(0,e-1)+t)},prevPage:function(e,t){return this.index(this.sum(0,e)-t)},firstVisible:function(){var e=this._hidden.first();return 0===e.value?0:e.end+1},lastVisible:function(){var e=this._hidden.last();return 0===e.value?this._count-1:e.start-1},prevVisible:function(e){for(var t=e;--t>=0;)if(!this.hidden(t))return t;return e},prevUntil:function(e,t){for(var n=e,o=!1;--n>=0;){var r=t(n,o,this.hidden(n));if("number"==typeof r)return r;if(r)break;o=!0}return n+1},unhide:function(e){if(this.hidden(e)){var t=this._hidden.value(e,e);this._hidden.value(e,e,0),this.value(e,e,t)}},value:function(e,t,n){if(void 0===n)return this.values.iterator(e,t).at(0);this.values.value(e,t,n),this._refresh()},sum:function(e,t){for(var n=this.values.iterator(e,t),o=0,r=e;r<=t;r++)o+=n.at(r);return o},locate:function(e,t,n){for(var o=this.values.iterator(e,t),r=0,i=e;i<=t;i++)if(n(r+=o.at(i)))return i;return null},visible:function(e,t){var n,o,r=!1;t>=this.total+this.scrollBarSize&&(r=!0);var i=this._pixelValues.intersecting(e,t);if(n=i[0],o=i[i.length-1],!n)return{values:this.values.iterator(0,0),offset:0};var s=e-n.start,a=(s/n.value.value>>0)+n.value.start,l=s-(a-n.value.start)*n.value.value,u=t-o.start,c=(u/o.value.value>>0)+o.value.start;return c>o.value.end&&(c=o.value.end),r&&(l+=o.value.value-(u-(c-o.value.start)*o.value.value)),l=Math.min(-l,0),{values:this.values.iterator(a,c),offset:l}},index:function(e){for(var t=0,n=this.values.iterator(0,this._count-1),o=n.at(0);o<e&&t<this._count-1;)o+=n.at(++t);return t},indexVisible:function(e){var t=this.index(e);return this.hidden(t)&&(t=this.prevVisible(t)),t},_refresh:function(){var t=0;this._pixelValues=this.values.map((function(n){var o=t,r=(t+=(n.end-n.start+1)*n.value)-1;return new e.spreadsheet.ValueRange(o,r,n)})),this.total=t},getState:function(){return{values:this.values.getState(),hidden:this._hidden.getState()}},setState:function(e){this.values.setState(e.values),this._hidden.setState(e.hidden),this._refresh()}}),n=e.Class.extend({init:function(e,t,n,o){this._axis=e,this._start=t,this._count=n,this.hasHeader=0===t,this.headerSize=o,this.defaultValue=e._value,this.frozen=n>0},viewSize:function(e){this._viewSize=e},sum:function(e,t){return this._axis.sum(e,t-1)},start:function(){return this.sum(0,this._start)},size:function(){return this.sum(this._start,this._start+this._count)},index:function(e,t){return this._axis.index(e+(this.frozen?0:t)-this.headerSize)},indexVisible:function(e,t){return this._axis.indexVisible(e+(this.frozen?0:t)-this.headerSize)},paneSegment:function(){var e,t=this.start();return this.hasHeader||(t+=this.headerSize),this.frozen?(e=this.size(),this.hasHeader?e+=this.headerSize:e-=this.headerSize):e=this._viewSize-t,{offset:t,length:e}},visible:function(e){var t,n=this.start();this.frozen?(t=this.size(),this.hasHeader||(t-=this.headerSize)):(t=this._viewSize-n-this.headerSize,n+=e);var o=this._axis.visible(n,n+t-1);return this.frozen&&(o.offset=0),o.start=n,this.hasHeader&&(o.offset+=this.headerSize,o.start-=this.headerSize),o},contains:function(e,t){return this.frozen?!(e>this._start+this._count||t<this._start):t>=this._start}});e.spreadsheet.Axis=t,e.spreadsheet.PaneAxis=n}(kendo)})?o.apply(t,r):o)||(e.exports=i)}})},6857:(e,t,n)=>{e.exports=function(e){var t={};function n(o){if(t[o])return t[o].exports;var r=t[o]={exports:{},id:o,loaded:!1};return e[o].call(r.exports,r,r.exports,n),r.loaded=!0,r.exports}return n.m=e,n.c=t,n.p="",n(0)}({0:function(e,t,n){n(1593),e.exports=n(1593)},3:function(e,t){e.exports=function(){throw new Error("define cannot be used indirect")}},20:function(e,t){e.exports=n(1657)},1593:function(e,t,n){var o,r,i;n(3),r=[n(20)],void 0===(i="function"==typeof(o=function(){!function(e){var t=e.Class.extend({init:function(e){this._sheet=e},forEachSelectedColumn:function(e){var t=this._sheet;t.batch((function(){t.select().forEachColumnIndex((function(n,o){e(t,n,o)}))}),{layout:!0,recalc:!0})},forEachSelectedRow:function(e){var t=this._sheet;t.batch((function(){t.select().forEachRowIndex((function(n,o){e(t,n,o)}))}),{layout:!0,recalc:!0})},includesHiddenColumns:function(e){return this._sheet._grid._columns.includesHidden(e.topLeft.col,e.bottomRight.col)},includesHiddenRows:function(e){return this._sheet._grid._rows.includesHidden(e.topLeft.row,e.bottomRight.row)},selectionIncludesHiddenColumns:function(){return this.includesHiddenColumns(this._sheet.select())},selectionIncludesHiddenRows:function(){return this.includesHiddenRows(this._sheet.select())},deleteSelectedColumns:function(){var e=[],t=0;return this.forEachSelectedColumn((function(n,o){if(o-=t,!n.isHiddenColumn(o)){t++;var r=[];e.unshift({index:o,formulas:r,width:n.columnWidth(o)}),n._saveModifiedFormulas(r,(function(){n.deleteColumn(o)}))}})),e},deleteSelectedRows:function(){var e=[],t=0;return this.forEachSelectedRow((function(n,o){if(o-=t,!n.isHiddenRow(o)){t++;var r=[];e.unshift({index:o,formulas:r,height:n.rowHeight(o)}),n._saveModifiedFormulas(r,(function(){n.deleteRow(o)}))}})),e},hideSelectedColumns:function(){this.forEachSelectedColumn((function(e,t){e.hideColumn(t)}));for(var t=this._sheet,n=t.select().toRangeRef(),o=n.topLeft.col,r=n.bottomRight.col,i=null;;){var s=r<t._columns._count,a=o>=0;if(!a&&!s)break;if(s&&!t.isHiddenColumn(r)){i=r;break}if(a&&!t.isHiddenColumn(o)){i=o;break}o--,r++}null!==i&&(n=new e.spreadsheet.RangeRef(new e.spreadsheet.CellRef(0,i),new e.spreadsheet.CellRef(t._rows._count-1,i)),t.range(n).select())},hideSelectedRows:function(){this.forEachSelectedRow((function(e,t){e.hideRow(t)}));for(var t=this._sheet,n=t.select().toRangeRef(),o=n.topLeft.row,r=n.bottomRight.row,i=null;;){var s=r<t._rows._count,a=o>=0;if(!a&&!s)break;if(s&&!t.isHiddenRow(r)){i=r;break}if(a&&!t.isHiddenRow(o)){i=o;break}o--,r++}null!==i&&(n=new e.spreadsheet.RangeRef(new e.spreadsheet.CellRef(i,0),new e.spreadsheet.CellRef(i,t._columns._count-1)),t.range(n).select())},unhideSelectedColumns:function(){this.forEachSelectedColumn((function(e,t){e.unhideColumn(t)}))},unhideSelectedRows:function(){this.forEachSelectedRow((function(e,t){e.unhideRow(t)}))},preventAddRow:function(){var e=this._sheet.select().toRangeRef().height();return this._sheet.preventInsertRow(0,e)},preventAddRowAfterLast:function(){var e=this._sheet.select().toRangeRef(),t=e.height();return this._sheet.preventInsertBelowLastRow(e.bottomRight.row,t)},preventAddColumn:function(){var e=this._sheet.select().toRangeRef().width();return this._sheet.preventInsertColumn(0,e)},preventAddColumnAfterLast:function(){var e=this._sheet.select().toRangeRef(),t=e.width();return this._sheet.preventInsertAfterLastColumn(e.bottomRight.col,t)},addColumnLeft:function(){var e,t=this._sheet,n=0;return t.batch((function(){t.select().forEachColumnIndex((function(o){e||(e=o),t.insertColumn(e),++n}))}),{recalc:!0,layout:!0}),{base:e,count:n}},addColumnRight:function(){var e,t=this._sheet,n=0;return t.batch((function(){t.select().forEachColumnIndex((function(t){e=t+1,++n}));for(var o=0;o<n;++o)t.insertColumn(e)}),{recalc:!0,layout:!0}),{base:e,count:n}},addRowAbove:function(){var e,t=this._sheet,n=0,o=t._grid.rowCount,r=t.select(),i=r.bottomRight.row-r.topLeft.row+1;return t.batch((function(){r.forEachRowIndex((function(s){e||(e=s),r.bottomRight.row+i<o&&t.insertRow(e),++n}))}),{recalc:!0,layout:!0}),{base:e,count:n}},addRowBelow:function(){var e,t=this._sheet,n=0,o=t._grid.rowCount;return t.batch((function(){if(t.select().forEachRowIndex((function(t){e=t+1,++n})),e+n<o)for(var r=0;r<n;++r)t.insertRow(e)}),{recalc:!0,layout:!0}),{base:e,count:n}}});e.spreadsheet.AxisManager=t}(kendo)})?o.apply(t,r):o)||(e.exports=i)}})},8398:(e,t,n)=>{e.exports=function(e){var t={};function n(o){if(t[o])return t[o].exports;var r=t[o]={exports:{},id:o,loaded:!1};return e[o].call(r.exports,r,r.exports,n),r.loaded=!0,r.exports}return n.m=e,n.c=t,n.p="",n(0)}({0:function(e,t,n){n(1594),e.exports=n(1594)},3:function(e,t){e.exports=function(){throw new Error("define cannot be used indirect")}},20:function(e,t){e.exports=n(1657)},953:function(e,t){e.exports=n(3261)},969:function(e,t){e.exports=n(2066)},1594:function(e,t,n){var o,r,i;n(3),r=[n(20),n(969),n(953)],void 0===(i="function"==typeof(o=function(){!function(e){var t=e.jQuery,n=["allBorders","insideBorders","insideHorizontalBorders","insideVerticalBorders","outsideBorders","leftBorder","topBorder","rightBorder","bottomBorder","noBorders"],o=e.spreadsheet.messages.borderPalette={allBorders:"All borders",insideBorders:"Inside borders",insideHorizontalBorders:"Inside horizontal borders",insideVerticalBorders:"Inside vertical borders",outsideBorders:"Outside borders",leftBorder:"Left border",topBorder:"Top border",rightBorder:"Right border",bottomBorder:"Bottom border",noBorders:"No border"},r=e.spreadsheet.messages.colorPicker={reset:"Reset color",customColor:"Custom color...",apply:"Apply",cancel:"Cancel"};function i(e){return function(t){return t.preventDefault(),e.apply(this,arguments)}}var s=e.ui.Widget.extend({init:function(t,n){e.ui.Widget.call(this,t,n),this.element=t,this.color=n.color,this._resetButton(),this._colorPalette(),this._customColorPalette(),this._customColorButton(),this.resetButton.on("click",i(this.resetColor.bind(this))),this.customColorButton.on("click",i(this.customColor.bind(this)))},options:{name:"ColorChooser"},events:["change"],destroy:function(){e.unbind(this.dialog.element.find(".k-action-buttons")),this.dialog.destroy(),this.colorPalette.destroy(),this.resetButton.off("click"),this.customColorButton.off("click")},value:function(e){if(void 0===e)return this.color;this.color=e,this.customColorButton.find(".k-icon").css("background-color",this.color),this.colorPalette.value(null),this.flatColorPicker.value(this.color)},_change:function(e){this.color=e,this.trigger("change",{value:e})},_colorPalette:function(){var e=t("<div />",{class:"k-spreadsheet-color-palette"}),n=this.colorPalette=t("<div />").kendoColorPalette({palette:["#ffffff","#000000","#d6ecff","#4e5b6f","#7fd13b","#ea157a","#feb80a","#00addc","#738ac8","#1ab39f","#f2f2f2","#7f7f7f","#a7d6ff","#d9dde4","#e5f5d7","#fad0e4","#fef0cd","#c5f2ff","#e2e7f4","#c9f7f1","#d8d8d8","#595959","#60b5ff","#b3bcca","#cbecb0","#f6a1c9","#fee29c","#8be6ff","#c7d0e9","#94efe3","#bfbfbf","#3f3f3f","#007dea","#8d9baf","#b2e389","#f272af","#fed46b","#51d9ff","#aab8de","#5fe7d5","#a5a5a5","#262626","#003e75","#3a4453","#5ea226","#af0f5b","#c58c00","#0081a5","#425ea9","#138677","#7f7f7f","#0c0c0c","#00192e","#272d37","#3f6c19","#750a3d","#835d00","#00566e","#2c3f71","#0c594f"],value:this.color,change:function(e){this.customColorButton.find(".k-icon").css("background-color","transparent"),this.flatColorPicker.value(null),this._change(e.value)}.bind(this)}).data("kendoColorPalette");e.append(n.wrapper).appendTo(this.element)},_customColorPalette:function(){var n=t("<div />",{class:"k-spreadsheet-window",html:"<div></div><div class='k-action-buttons'><button class='k-button k-primary' data-bind='click: apply'>"+r.apply+"</button><button class='k-button' data-bind='click: close'>"+r.cancel+"</button></div>"}),o=this.dialog=n.appendTo(document.body).kendoWindow({animation:!1,scrollable:!1,resizable:!1,maximizable:!1,modal:!0,visible:!1,width:"auto",open:function(){this.center()}}).data("kendoWindow");o.one("activate",(function(){this.element.find("[data-role=flatcolorpicker]").data("kendoFlatColorPicker")._hueSlider.resize()}));var i=this.flatColorPicker=o.element.children().first().kendoFlatColorPicker().data("kendoFlatColorPicker"),s=e.observable({apply:function(){this.customColorButton.find(".k-icon").css("background-color",i.value()),this.colorPalette.value(null),this._change(i.value()),o.close()}.bind(this),close:function(){i.value(null),o.close()}});e.bind(o.element.find(".k-action-buttons"),s)},_resetButton:function(){this.resetButton=t("<a role='button' class='k-button k-reset-color' href='#'><span class='k-icon k-i-reset-color'></span>"+r.reset+"</a>").appendTo(this.element)},_customColorButton:function(){this.customColorButton=t("<a role='button' class='k-button k-custom-color' href='#'><span class='k-icon'></span>"+r.customColor+"</a>").appendTo(this.element)},resetColor:function(){this.colorPalette.value(null),this.flatColorPicker.value(null),this._change(null)},customColor:function(){this.dialog.open()}}),a=e.ui.Widget.extend({init:function(t,n){e.ui.Widget.call(this,t,n),this.element=t,this.color="#000",this.element.addClass("k-spreadsheet-border-palette"),this._borderTypePalette(),this._borderColorPalette(),this.element.on("click",".k-spreadsheet-border-type-palette .k-button",i(this._click.bind(this)))},options:{name:"BorderPalette"},events:["change"],destroy:function(){this.colorChooser.destroy(),this.element.off("click")},_borderTypePalette:function(){var r=o,i=n.map((function(t){return'<a role="button" title="'+r[t]+'" aria-label="'+r[t]+'" href="#" data-border-type="'+t+'" class="k-button k-button-icon"><span class="k-icon k-i-'+e.toHyphens(t)+'"></span></a>'})).join("");t("<div />",{class:"k-spreadsheet-border-type-palette",html:i}).appendTo(this.element)},_borderColorPalette:function(){var e=t("<div />",{class:"k-spreadsheet-border-color-palette"});e.appendTo(this.element),this.colorChooser=new s(e,{color:this.color,change:this._colorChange.bind(this)})},_click:function(e){this.type=t(e.currentTarget).data("borderType"),this.trigger("change",{type:this.type,color:this.color})},_colorChange:function(e){this.color=e.value,this.type&&this.trigger("change",{type:this.type,color:this.color})}});e.spreadsheet.ColorChooser=s,e.spreadsheet.BorderPalette=a}(window.kendo)})?o.apply(t,r):o)||(e.exports=i)}})}}]);