(self.webpackChunk_5_112_1332=self.webpackChunk_5_112_1332||[]).push([[9272],{619:(t,e,r)=>{t.exports=function(t){var e={};function r(n){if(e[n])return e[n].exports;var i=e[n]={exports:{},id:n,loaded:!1};return t[n].call(i.exports,i,i.exports,r),i.loaded=!0,i.exports}return r.m=t,r.c=e,r.p="",r(0)}({0:function(t,e,r){r(1617),t.exports=r(1617)},3:function(t,e){t.exports=function(){throw new Error("define cannot be used indirect")}},20:function(t,e){t.exports=r(1657)},1617:function(t,e,r){var n,i,o;r(3),i=[r(20),r(1618)],void 0===(o="function"==typeof(n=function(){!function(t){var e=t.spreadsheet.CellRef,r=t.spreadsheet.RangeRef,n=t.spreadsheet.UnionRef,i=t.Class.extend({init:function(t,e,r,n){this.left=t,this.top=e,this.width=r,this.height=n,this.right=this.left+this.width,this.bottom=this.top+this.height},offset:function(t,e){return new i(this.left+t,this.top+e,this.width,this.height)},resize:function(t,e){return new i(this.left,this.top,this.width+t,this.height+e)},intersects:function(t,e){return t instanceof i?this.intersectsRect(t):this.left<t&&t<this.left+this.width&&this.top<e&&e<this.top+this.height},intersectsRect:function(t){var e=this;return e.left<=t.right&&t.left<=e.right&&e.top<=t.bottom&&t.top<=e.bottom},toDiv:function(e){return t.dom.element("div",{className:e,style:{width:this.width+"px",height:this.height+"px",top:this.top+"px",left:this.left+"px"}})}}),o=t.Class.extend({init:function(t,e,r,n,i,o){this.rowCount=r,this.columnCount=n,this._columns=e,this._rows=t,this._headerHeight=i,this._headerWidth=o},isAxis:function(t){var e=(t=t.toRangeRef()).topLeft,r=t.bottomRight;return 0===e.row&&r.row===this.rowCount-1||0===e.col&&r.col===this.columnCount-1},width:function(t,e){return this._columns.sum(t,e)},height:function(t,e){return this._rows.sum(t,e)},totalHeight:function(){return this._rows.total+this._headerHeight},totalWidth:function(){return this._columns.total+this._headerWidth},index:function(t,e){return e*this.rowCount+t},cellRef:function(t){return new e(t%this.rowCount,t/this.rowCount>>0)},rowRef:function(t){return new r(new e(t,0),new e(t,this.columnCount-1))},colRef:function(t){return new r(new e(0,t),new e(this.rowCount-1,t))},cellRefIndex:function(t){return this.index(t.row,t.col)},normalize:function(t){return t instanceof r?new r(this.normalize(t.topLeft),this.normalize(t.bottomRight)).setSheet(t.sheet,t.hasSheet()):t instanceof n?t.map((function(t){return this.normalize(t)}),this):(t instanceof e&&((t=t.clone()).col=Math.max(0,Math.min(this.columnCount-1,t.col)),t.row=Math.max(0,Math.min(this.rowCount-1,t.row))),t)},rectangle:function(t){var e=this.normalize(t.topLeft),r=this.normalize(t.bottomRight);return new i(this.width(0,e.col-1),this.height(0,e.row-1),this.width(e.col,r.col),this.height(e.row,r.row))},pane:function(e){return new s(new t.spreadsheet.PaneAxis(this._rows,e.row,e.rowCount,this._headerHeight),new t.spreadsheet.PaneAxis(this._columns,e.column,e.columnCount,this._headerWidth),this)},rangeDimensions:function(t){return{rows:this._rows.values.iterator(t.topLeft.row,t.bottomRight.row),columns:this._columns.values.iterator(t.topLeft.col,t.bottomRight.col)}},forEach:function(t,r){for(var n=this.normalize(t.topLeft),i=this.normalize(t.bottomRight),o=n.col;o<=i.col;o++)for(var s=n.row;s<=i.row;s++)r(new e(s,o))},trim:function(t,n){for(var i=this.normalize(t.topLeft),o=this.normalize(t.bottomRight),s=i.row,a=i.col,c=i.col;c<=o.col;c++){var l=this.index(i.row,c),u=this.index(o.row,c),h=n.tree.intersecting(l,u);if(h.length){var p=this.cellRef(h[h.length-1].end);s=Math.max(s,p.row),a=c}}return new r(t.topLeft,new e(Math.min(s,t.bottomRight.row),a))}}),s=t.Class.extend({init:function(t,e,r){this.rows=t,this.columns=e,this._grid=r,this.headerHeight=t.headerSize,this.headerWidth=e.headerSize,this.hasRowHeader=e.hasHeader,this.hasColumnHeader=t.hasHeader},refresh:function(t,e){this.columns.viewSize(t),this.rows.viewSize(e);var r=this.columns.paneSegment(),n=this.rows.paneSegment();this.left=r.offset,this.top=n.offset,this.right=r.offset+r.length,this.bottom=n.offset+n.length,this.style={top:n.offset+"px",left:r.offset+"px",height:n.length+"px",width:r.length+"px"}},view:function(t,n){var i=this.rows.visible(n),o=this.columns.visible(t);return{rows:i,columns:o,rowOffset:i.offset,columnOffset:o.offset,mergedCellLeft:o.start,mergedCellTop:i.start,ref:new r(new e(i.values.start,o.values.start),new e(i.values.end,o.values.end))}},contains:function(t){return this.rows.contains(t.topLeft.row,t.bottomRight.row)&&this.columns.contains(t.topLeft.col,t.bottomRight.col)},index:function(t,e){return this._grid.index(t,e)},boundingRectangle:function(t){return this._grid.rectangle(t)},cellRefIndex:function(t){return this._grid.cellRefIndex(t)},scrollBoundaries:function(t){var e=this.boundingRectangle(t),r={top:Math.max(0,e.top-this.top+(this.hasColumnHeader?0:this.headerHeight)),left:Math.max(0,e.left-this.left+(this.hasRowHeader?0:this.headerWidth)),right:e.right-this.columns._viewSize+this.headerWidth,bottom:e.bottom-this.rows._viewSize+this.headerHeight},n=this.columns.defaultValue/2,i=this.rows.defaultValue/2;return r.scrollTop=r.top-i,r.scrollBottom=r.bottom+i,r.scrollLeft=r.left-n,r.scrollRight=r.right+n,r}});t.spreadsheet.Grid=o,t.spreadsheet.PaneGrid=s,t.spreadsheet.Rectangle=i}(kendo)})?n.apply(e,i):n)||(t.exports=o)},1618:function(t,e){t.exports=r(7731)}})},3903:(t,e,r)=>{t.exports=function(t){var e={};function r(n){if(e[n])return e[n].exports;var i=e[n]={exports:{},id:n,loaded:!1};return t[n].call(i.exports,i,i.exports,r),i.loaded=!0,i.exports}return r.m=t,r.c=e,r.p="",r(0)}({0:function(t,e,r){r(1619),t.exports=r(1619)},3:function(t,e){t.exports=function(){throw new Error("define cannot be used indirect")}},20:function(t,e){t.exports=r(1657)},1619:function(t,e,r){var n,i,o;r(3),i=[r(20)],void 0===(o="function"==typeof(n=function(){!function(t){var e=t.jQuery,r="k-spreadsheet-name-editor",n=t.ui.Widget.extend({init:function(n,i){t.ui.Widget.call(this,n,i),n.addClass(r);var o=i.messages.nameBox||"Name Box",s=new t.data.DataSource({transport:{read:function(e){var r=[];this._workbook.forEachName((function(e){!e.hidden&&e.value instanceof t.spreadsheet.Ref&&r.push({name:e.name})})),e.success(r)}.bind(this),cache:!1}}),a=e("<input />").attr("title",o).attr("aria-label",o);this.combo=a.appendTo(n).kendoComboBox({clearButton:!1,dataTextField:"name",dataValueField:"name",template:"#:data.name#<a role='button' class='k-button-delete' href='\\#'><span class='k-icon k-i-close'></span></a>",dataSource:s,autoBind:!1,ignoreCase:!0,change:this._on_listChange.bind(this),noDataTemplate:"<div></div>",open:function(){s.read()}}).getKendoComboBox(),this.combo.input.on("keydown",this._on_keyDown.bind(this)).on("focus",this._on_focus.bind(this)),this.combo.popup.element.addClass("k-spreadsheet-names-popup").on("mousemove",(function(t){t.stopPropagation()})).on("click",".k-button-delete",function(t){t.preventDefault(),t.stopPropagation();var r=e(t.target).closest(".k-item");r=this.combo.dataItem(r),this._deleteItem(r.name)}.bind(this))},value:function(t){if(void 0===t)return this.combo.value();this.combo.value(t)},_deleteItem:function(t){this.trigger("delete",{name:t})},_on_keyDown:function(t){switch(t.keyCode){case 27:this.combo.value(this._prevValue),this.trigger("cancel");break;case 13:this.trigger("enter")}},_on_focus:function(){this._prevValue=this.combo.value()},_on_listChange:function(){var t=this.combo.value();t&&this.trigger("select",{name:t})}});t.spreadsheet.NameEditor=n}(window.kendo)})?n.apply(e,i):n)||(t.exports=o)}})},2292:(t,e,r)=>{t.exports=function(t){var e={};function r(n){if(e[n])return e[n].exports;var i=e[n]={exports:{},id:n,loaded:!1};return t[n].call(i.exports,i,i.exports,r),i.loaded=!0,i.exports}return r.m=t,r.c=e,r.p="",r(0)}({0:function(t,e,r){r(1620),t.exports=r(1620)},3:function(t,e){t.exports=function(){throw new Error("define cannot be used indirect")}},20:function(t,e){t.exports=r(1657)},1620:function(t,e,r){var n,i,o;r(3),i=[r(20),r(1621)],void 0===(o="function"==typeof(n=function(){!function(t){var e=t.spreadsheet.RangeRef,r=t.spreadsheet.CellRef,n=t.Class.extend({init:function(t,e,r,n){this.rangeGetter=r,this.prevLeft=function(r){var i=n(this.range(r)),o=this.range(e.prevVisible(i.topLeft[t]));return n(o).topLeft[t]},this.nextRight=function(r){var i=n(this.range(r)),o=this.range(e.nextVisible(i.bottomRight[t]));return n(o).bottomRight[t]},this.nextLeft=function(r){var i=n(this.range(r));return e.nextVisible(i.bottomRight[t])},this.prevRight=function(r){var i=n(this.range(r));return e.prevVisible(i.topLeft[t])}},boundary:function(t,e){this.top=t,this.bottom=e},range:function(t){return this.rangeGetter(t,this.top,this.bottom)}}),i=t.Class.extend({init:function(e){this._sheet=e,this.autoFillCalculator=new t.spreadsheet.AutoFillCalculator(e._grid),this.colEdge=new n("col",this._sheet._grid._columns,this.columnRange.bind(this),this.union.bind(this)),this.rowEdge=new n("row",this._sheet._grid._rows,this.rowRange.bind(this),this.union.bind(this))},height:function(t){this._viewPortHeight=t},union:function(t){return this._sheet.unionWithMerged(t)},columnRange:function(t,e,r){return this._sheet._ref(e,t,r-e,1)},rowRange:function(t,e,r){return this._sheet._ref(t,e,1,r-e)},selectionIncludesMergedCells:function(){return this._sheet.select().contains(this._sheet._mergedCells)},setSelectionValue:function(t){var e=this._sheet.selection();setTimeout((function(){e.value(t())}))},selectAll:function(){this._sheet.select(this._sheet._sheetRef)},select:function(t,e,r){t=this.refForMode(t,e),r&&(t=this._sheet.select().concat(t)),this._sheet.select(t)},refForMode:function(t,e){var r=this._sheet._grid;switch(e){case"range":t=r.normalize(t);break;case"row":t=r.rowRef(t.row);break;case"column":t=r.colRef(t.col);break;case"sheet":t=this._sheet._sheetRef}return t},startSelection:function(t,r,n,i,o){if("autofill"==r)this._sheet.startAutoFill();else if(i&&"range"==r){var s=new e(this._sheet.activeCell().first(),t);this._sheet.select(s,!1,!1),this._sheet.startSelection(o)}else this._sheet.startSelection(o),this.select(t,r,n)},completeSelection:function(){this._sheet.completeSelection()},selectForContextMenu:function(t,e){var r=this._sheet;r._activeDrawing=null,r.select().contains(this.refForMode(t,e))||this.select(t,e)},selectDrawingForContextMenu:function(t){var e=this._sheet;e._activeDrawing=t,e.triggerChange({selection:!0})},modifySelection:function(t){var n,i=this.determineDirection(t),s=this._sheet,a=this._viewPortHeight,c=s._grid._rows,l=s._grid._columns,u=s.currentOriginalSelectionRange(),h=s.select().toRangeRef(),p=s.activeCell(),f=u.topLeft.clone(),d=u.bottomRight.clone(),m=new r(d.row,f.col);switch(this.colEdge.boundary(h.topLeft.row,h.bottomRight.row),this.rowEdge.boundary(h.topLeft.col,h.bottomRight.col),i){case"expand-left":f.col=this.colEdge.prevLeft(f.col),n=f;break;case"shrink-right":f.col=this.colEdge.nextLeft(f.col),n=f;break;case"expand-right":d.col=this.colEdge.nextRight(d.col),n=d;break;case"shrink-left":d.col=this.colEdge.prevRight(d.col),n=d;break;case"expand-up":f.row=this.rowEdge.prevLeft(f.row),n=f;break;case"shrink-down":f.row=this.rowEdge.nextLeft(f.row),n=f;break;case"expand-down":d.row=this.rowEdge.nextRight(d.row),n=d;break;case"shrink-up":d.row=this.rowEdge.prevRight(d.row),n=d;break;case"expand-page-up":f.row=c.prevPage(f.row,a);break;case"shrink-page-up":d.row=c.prevPage(d.row,a);break;case"expand-page-down":d.row=c.nextPage(d.row,a);break;case"shrink-page-down":f.row=c.nextPage(f.row,a);break;case"first-col":f.col=l.firstVisible(),d.col=p.bottomRight.col,n=f;break;case"last-col":d.col=l.lastVisible(),f.col=p.topLeft.col,n=d;break;case"first-row":f.row=c.firstVisible(),d.row=p.bottomRight.row,n=f;break;case"last-row":d.row=c.lastVisible(),f.row=p.topLeft.row,n=d;break;case"last":d.row=c.lastVisible(),d.col=l.lastVisible(),f=p.topLeft,n=d;break;case"first":f.row=c.firstVisible(),f.col=l.firstVisible(),d=p.bottomRight,n=f;break;case"expand-word-right":d.col=l.nextUntil(d.col,o(s,d,!0)),n=d;break;case"shrink-word-right":f.col=l.nextUntil(m.col,o(s,m,!0)),n=f;break;case"expand-word-left":f.col=l.prevUntil(m.col,o(s,m,!0)),n=f;break;case"shrink-word-left":d.col=l.prevUntil(d.col,o(s,d,!0)),n=d;break;case"expand-word-up":f.row=c.prevUntil(f.row,o(s,f,!1)),n=f;break;case"shrink-word-up":d.row=c.prevUntil(d.row,o(s,d,!1)),n=d;break;case"expand-word-down":d.row=c.nextUntil(d.row,o(s,d,!1)),n=d;break;case"shrink-word-down":f.row=c.nextUntil(f.row,o(s,f,!1)),n=f}var g=new e(f,d);this.union(g).intersects(p)?(n&&s.focus(n),this.updateCurrentSelectionRange(g)):this.modifySelection(i.replace("shrink","expand"))},moveActiveCell:function(t){var e=this._sheet,n=e.activeCell(),i=n.topLeft,s=n.bottomRight,a=e.originalActiveCell(),c=e._grid._rows,l=e._grid._columns,u=a.row,h=a.col;switch(t){case"left":h=l.prevVisible(i.col);break;case"up":u=c.prevVisible(i.row);break;case"right":h=l.nextVisible(s.col);break;case"down":u=c.nextVisible(s.row);break;case"first-col":h=l.firstVisible();break;case"last-col":h=l.lastVisible();break;case"first-row":u=c.firstVisible();break;case"last-row":u=c.lastVisible();break;case"last":u=c.lastVisible(),h=l.lastVisible();break;case"first":u=c.firstVisible(),h=l.firstVisible();break;case"next-page":u=c.nextPage(s.row,this._viewPortHeight);break;case"prev-page":u=c.prevPage(s.row,this._viewPortHeight);break;case"word-right":h=l.nextUntil(h,o(e,s,!0));break;case"word-left":h=l.prevUntil(h,o(e,s,!0));break;case"word-up":u=c.prevUntil(u,o(e,s,!1));break;case"word-down":u=c.nextUntil(u,o(e,s,!1))}e.select(new r(u,h))},navigateInSelection:function(e){var n,i,o,s=this._sheet,a=s.activeCell().topLeft,c=s.originalActiveCell(),l=s._grid._rows,u=s._grid._columns,h=c.row,p=c.col,f=!1,d=!1,m=a.col,g=a.row;function w(t){n=t.topLeft,i=t.bottomRight}w(s.currentNavigationRange());for(var v=!1,b=!1;!v&&!b;){var y=new r(h,p);switch(s.singleCellSelection()&&(f=n.eq(y)&&s._sheetRef.topLeft.eq(y),d=i.eq(y)&&s._sheetRef.bottomRight.eq(y),f||(f=u.firstVisible()===p&&l.firstVisible()===h),d||(d=u.lastVisible()===p&&l.lastVisible()===h)),e){case"next":d?(b=!0,t.focusNextElement()):i.eq(y)?(w(s.nextNavigationRange()),h=n.row,p=n.col):((p=u.nextVisible(m))==m||p>i.col)&&(p=n.col,h=(o=l.nextVisible(h))==h||o>i.row?n.row:o);break;case"previous":f?(b=!0,this._sheet._workbook._view.element.find(".k-spreadsheet-name-editor .k-input").focus()):n.eq(y)?(w(s.previousNavigationRange()),h=i.row,p=i.col):((p=u.prevVisible(m))==m||p<n.col)&&(p=i.col,h=(o=l.prevVisible(h))==h||o<n.row?i.row:o);break;case"lower":i.eq(y)?(w(s.nextNavigationRange()),h=n.row,p=n.col):((h=l.nextVisible(g))==g||h>i.row)&&(h=n.row,p=(o=u.nextVisible(p))==p||o>i.col?n.col:o);break;case"upper":n.eq(y)?(w(s.previousNavigationRange()),h=i.row,p=i.col):((h=l.prevVisible(g))==g||h<n.row)&&(h=i.row,p=(o=u.prevVisible(p))==p||o<n.col?i.col:o);break;default:throw new Error("Unknown entry navigation: "+e)}v=!this.shouldSkip(h,p),m=p,g=h}v&&(s.singleCellSelection()?s.select(new r(h,p)):s.activeCell(new r(h,p)))},extendSelection:function(t,r){var n=this._sheet,i=n._grid;if("autofill"!==r){"range"===r?t=i.normalize(t):"row"===r?t=i.rowRef(t.row).bottomRight:"column"===r&&(t=i.colRef(t.col).bottomRight);var o=n.originalActiveCell().toRangeRef();this.updateCurrentSelectionRange(new e(o.topLeft,t))}else this.resizeAutoFill(t)},shouldSkip:function(t,e){if(this._sheet.isHiddenRow(t)||this._sheet.isHiddenColumn(e))return!0;var n=new r(t,e),i=!1;return this._sheet.forEachMergedCell((function(t){t.intersects(n)&&!t.collapse().eq(n)&&(i=!0)})),i},resizeAutoFill:function(t){var e,r,n=this._sheet,i=n.select(),o=n._autoFillOrigin,s=this.autoFillCalculator.autoFillDest(i,t),a=this.punch(i,s);if(!a){var c=n.range(s)._previewFillFrom(n.range(o));c&&(r=c.direction,e=c.hint)}n.updateAutoFill(s,a,e,r)},determineDirection:function(t){var e=this._sheet.currentSelectionRange(),r=this._sheet.activeCell(),n=r.topLeft.col==e.topLeft.col,i=r.bottomRight.col==e.bottomRight.col,o=r.topLeft.row==e.topLeft.row,s=r.bottomRight.row==e.bottomRight.row;switch(t){case"left":t=i?"expand-left":"shrink-left";break;case"right":t=n?"expand-right":"shrink-right";break;case"up":t=s?"expand-up":"shrink-up";break;case"down":t=o?"expand-down":"shrink-down";break;case"prev-page":t=s?"expand-page-up":"shrink-page-up";break;case"next-page":t=o?"expand-page-down":"shrink-page-down";break;case"word-left":t=i?"expand-word-left":"shrink-word-left";break;case"word-right":t=n?"expand-word-right":"shrink-word-right";break;case"word-up":t=s?"expand-word-up":"shrink-word-up";break;case"word-down":t=o?"expand-word-down":"shrink-word-down"}return t},updateCurrentSelectionRange:function(t){var e=this._sheet;e.select(e.originalSelect().replaceAt(e.selectionRangeIndex(),t),!1)},punch:function(t,n){var i;if(n.topLeft.eq(t.topLeft))if(n.bottomRight.row<t.bottomRight.row){var o=this.rowEdge.nextRight(n.bottomRight.row);i=new e(new r(o,t.topLeft.col),t.bottomRight)}else if(n.bottomRight.col<t.bottomRight.col){var s=this.colEdge.nextRight(n.bottomRight.col);i=new e(new r(t.topLeft.row,s),t.bottomRight)}return i}});function o(t,e,r){var n=t.range(e).value();return function(i,o,s){if(s)return!0;var a=(r?t.range(e.row,i):t.range(i,e.col)).value();return null===n?null!==a&&i:o||null!==a?null===a:(n=null,!1)}}t.spreadsheet.SheetNavigator=i}(kendo)})?n.apply(e,i):n)||(t.exports=o)},1621:function(t,e){t.exports=r(5256)}})},6551:(t,e,r)=>{t.exports=function(t){var e={};function r(n){if(e[n])return e[n].exports;var i=e[n]={exports:{},id:n,loaded:!1};return t[n].call(i.exports,i,i.exports,r),i.loaded=!0,i.exports}return r.m=t,r.c=e,r.p="",r(0)}({0:function(t,e,r){r(1622),t.exports=r(1622)},3:function(t,e){t.exports=function(){throw new Error("define cannot be used indirect")}},1609:function(t,e){t.exports=r(7266)},1622:function(t,e,r){var n,i,o;r(3),i=[r(1609),r(1623),r(1624)],void 0===(o="function"==typeof(n=function(){"use strict";var t=kendo.util,e=kendo.spreadsheet.calc,r=kendo.dom,n=/^\[(black|green|white|blue|magenta|yellow|cyan|red)\]/i,i=/^\[(<=|>=|<>|<|>|=)(-?[0-9.]+)\]/;function o(t){t=e.InputStream(t);for(var r,o=[],s=!1;!t.eof();){var a=p();o.push(a),a.cond&&(s=!0)}return s||(1==o.length?o[0].cond="num":2==o.length?(o[0].cond={op:">=",value:0},o[1].cond={op:"<",value:0}):o.length>=3&&(o[0].cond={op:">",value:0},o[1].cond={op:"<",value:0},o[2].cond={op:"=",value:0},o.length>3&&(o[3].cond="text",o=o.slice(0,4)))),o;function c(){var e=t.skip(n);if(e)return e[1].toLowerCase()}function l(){for(var e,r=[],n=null;!t.eof()&&(e=h());)"date"==e.type?n&&/^(el)?time$/.test(n.type)&&"h"==n.part&&"m"==e.part&&e.format<3&&(e.type="time"):/^(el)?time$/.test(e.type)&&"s"==e.part&&n&&"date"==n.type&&"m"==n.part&&n.format<3&&(n.type="time"),/^(?:str|space|fill)$/.test(e.type)||(n=e),r.push(e);return r}function u(e){if("date"!=e.type||"m"==e.part&&e.format<3){var r=t.skip(/^\.(0+)/);r&&(e.fraction=r[1].length,"date"==e.type&&(e.type="time"))}return e}function h(){var e,n;if(n=t.skip(/^([#0?]+)(?:,([#0?]+))+/))return{type:"digit",sep:!0,format:n[1]+n[2],decimal:r};if(n=t.skip(/^[#0?]+/))return{type:"digit",sep:!1,format:n[0],decimal:r};if(n=t.skip(/^(e)([+-])/i))return{type:"exp",ch:n[1],sign:n[2]};if(n=t.skip(/^(d{1,4}|m{1,5}|yyyy|yy)/i))return u({type:"date",part:(n=n[1].toLowerCase()).charAt(0),format:n.length});if(n=t.skip(/^(hh?|ss?)/i))return u({type:"time",part:(n=n[1].toLowerCase()).charAt(0),format:n.length});if(n=t.skip(/^\[(hh?|mm?|ss?)\]/i))return u({type:"eltime",part:(n=n[1].toLowerCase()).charAt(0),format:n.length});if(n=t.skip(/^(a[.]?m[.]?\/p[.]?m[.]?|a\/p)/i))return{type:"ampm",am:(n=n[1].split("/"))[0],pm:n[1]};switch(e=t.next()){case";":return null;case"\\":return{type:"str",value:t.next()};case'"':return{type:"str",value:t.readEscaped(e)};case"@":return{type:"text"};case"_":return{type:"space",value:t.next()};case"*":return{type:"fill",value:t.next()};case".":return t.lookingAt(/^\s*[#0?]/)?(r=!0,{type:"dec"}):{type:"str",value:"."};case"%":return{type:"percent"};case",":return{type:"comma"}}return{type:"str",value:e}}function p(){r=!1;var e=c(),n=function(){var e=t.skip(i);if(e){var r=parseFloat(e[2]);if(!isNaN(r))return{op:e[1],value:r,custom:!0}}}();return!e&&n&&(e=c()),{color:e,cond:n,body:l()}}}function s(t){var e,r,n=(e=t.body,r=0,{next:function(){return e[r++]},eof:function(){return r>=e.length},ahead:function(t,n){if(r+t<=e.length){var i=n.apply(null,e.slice(r,r+t));return i&&(r+=t),i}},restart:function(){r=0}}),i=!1,o=!1,s=!1,a=0,c=/[\$\xA2-\xA5\u058F\u060B\u09F2\u09F3\u09FB\u0AF1\u0BF9\u0E3F\u17DB\u20A0-\u20BD\uA838\uFDFC\uFE69\uFF04\uFFE0\uFFE1\uFFE5\uFFE6]/,l=0,u="var intPart, decPart, isNegative, date, time; ",h=!1,p=0,f=[],d=[],m=t.cond,g="";function w(t,e){("digit"==t.type&&"comma"==e.type||"comma"==t.type&&t.hidden&&"comma"==e.type)&&(e.hidden=!0,l++)}for("text"==m?g="if (typeof value == 'string' || value instanceof kendo.spreadsheet.CalcError) { ":"num"==m?g="if (typeof value == 'number') { ":m&&(g="if (typeof value == 'number' && value "+("="==m.op?"==":m.op)+" "+m.value+") { ",m.custom||(u+="value = Math.abs(value); ")),t.color&&(u+="result.color = "+JSON.stringify(t.color)+"; ");!n.eof();)n.ahead(2,w),"percent"==(v=n.next()).type?a++:"digit"==v.type?v.decimal?(p+=v.format.length,d.push(v.format)):(f.push(v.format),v.sep&&(h=!0)):"time"==v.type?o=!0:"date"==v.type?i=!0:"ampm"==v.type&&(s=o=!0);for(a>0&&(u+="value *= "+Math.pow(100,a)+"; "),l>0&&(u+="value /= "+Math.pow(1e3,l)+"; "),f.length&&(u+="intPart = runtime.formatInt(culture, value, "+JSON.stringify(f)+", "+p+", "+h+"); ",u+="isNegative = parseInt(intPart[0]) < 0;"),d.length&&(u+="decPart = runtime.formatDec(value, "+JSON.stringify(d)+", "+p+"); "),(f.length||d.length)&&(u+="type = 'number'; "),i&&(u+="date = runtime.unpackDate(value); "),o&&(u+="time = runtime.unpackTime(value); "),(i||o)&&(u+="type = 'date'; "),(a>0||l>0||f.length||d.length||i||o)&&(g||(g="if (typeof value == 'number') { ")),n.restart(),u+="var matchedCurrency = false;";!n.eof();){var v;"dec"==(v=n.next()).type?u+="output += culture.numberFormat['.']; ":"comma"!=v.type||v.hidden?"percent"==v.type?(u+="type = 'percent'; ",u+="output += culture.numberFormat.percent.symbol; "):"str"==v.type?(c.test(v.value)&&(u+="type = 'currency'; ",u+="if (isNegative) { output += '-'; matchedCurrency = true; }"),u+="output += "+JSON.stringify(v.value)+"; "):"text"==v.type?(u+="type = 'text'; ",u+="output += value; "):"space"==v.type?(u+="if (output) result.body.push(output); ",u+="output = ''; ",u+="result.body.push({ type: 'space', value: "+JSON.stringify(v.value)+" }); "):"fill"==v.type?u+="output += runtime.fill("+JSON.stringify(v.value)+"); ":"digit"==v.type?(u+="if (isNegative && intPart[0] && matchedCurrency) {intPart[0] = intPart[0].replace('-', '');}",u+="output += "+(v.decimal?"decPart":"intPart")+".shift(); "):"date"==v.type?u+="output += runtime.date(culture, date, "+JSON.stringify(v.part)+", "+v.format+"); ":"time"==v.type?u+="output += runtime.time(time, "+JSON.stringify(v.part)+", "+v.format+", "+s+", "+v.fraction+"); ":"eltime"==v.type?u+="output += runtime.eltime(value, "+JSON.stringify(v.part)+", "+v.format+", "+v.fraction+"); ":"ampm"==v.type&&(u+="output += time.hours < 12 ? "+JSON.stringify(v.am)+" : "+JSON.stringify(v.pm)+"; "):u+="output += ','; "}return u+="if (output) result.body.push(output); ",u+="result.type = type; ",u+="return result; ",g&&(u=g+u+"}"),u}var a=s({cond:"text",body:[{type:"text"}]}),c=t.memoize((function(t){var e=o(t).map(s);return e.push(a),e="'use strict'; return function(value, culture){ if (!culture) culture = kendo.culture(); var output = '', type = null, result = { body: [] }; "+(e=e.join("\n"))+"; return result; };",new Function("runtime",e)(u)})),l=t.memoize((function(t){for(var e,r=o(t),n=!1,i=!1,s=0;s<r.length;++s){e=r[s];for(var a=0;a<e.body.length;++a)/^(?:date|time|ampm)$/.test(e.body[a].type)&&(n=!0,"ampm"==e.body[a].type&&(i=!0));if(n)break}return n?e.body.map((function(t){if("digit"==t.type)return t.sep?t.format.charAt(0)+","+t.format.substr(1):t.format;if("exp"==t.type)return t.ch+t.sign;if("date"==t.type||"time"==t.type){var e=t.part;return"date"==t.type&&/^m/.test(e)?e="M":"time"==t.type&&/^h/.test(e)&&(i||(e=e.toUpperCase())),function(t,e){return e.fraction&&(t+=h("",Math.max(e.fraction,3),"f")),t}(h("",t.format,e),t)}return"ampm"==t.type?"tt":"str"==t.type?t.value:"space"==t.type?" ":"dec"==t.type?".":"percent"==t.type?"%":"comma"==t.type?",":""})).join(""):null})),u={unpackDate:e.runtime.unpackDate,unpackTime:e.runtime.unpackTime,date:function(t,e,r,n){switch(r){case"d":switch(n){case 1:return e.date;case 2:return h(e.date,2,"0");case 3:return t.calendars.standard.days.namesAbbr[e.day];case 4:return t.calendars.standard.days.names[e.day]}break;case"m":switch(n){case 1:return e.month+1;case 2:return h(e.month+1,2,"0");case 3:return t.calendars.standard.months.namesAbbr[e.month];case 4:return t.calendars.standard.months.names[e.month];case 5:return t.calendars.standard.months.names[e.month].charAt(0)}break;case"y":switch(n){case 2:return e.year%100;case 4:return e.year}}return"##"},time:function(t,e,r,n,i){var o,s;switch(e){case"h":o=h(n?t.hours%12||12:t.hours,r,"0"),i&&(s=(t.minutes+(t.seconds+t.milliseconds/1e3)/60)/60);break;case"m":o=h(t.minutes,r,"0"),i&&(s=(t.seconds+t.milliseconds/1e3)/60);break;case"s":o=h(t.seconds,r,"0"),i&&(s=t.milliseconds/1e3)}return s&&(o+=u.toFixed(s,i).replace(/^0+/,"")),o},eltime:function(t,e,r,n){var i,o;switch(e){case"h":i=24*t;break;case"m":i=24*t*60;break;case"s":i=24*t*60*60}return n&&(o=i-(0|i)),i=h(0|i,r,"0"),o&&(i+=u.toFixed(o,n).replace(/^0+/,"")),i},fill:function(t){return t},formatInt:function(t,e,r,n,i){e=u.toFixed(e,n).replace(/\..*$/,"");var o=r[r.length-1];n>0&&"0"!=o[r.length-1]&&("0"===e?e="":"-0"===e&&(e="-"));var s,a=!1,c=e.length-1,l=[],h=0;function p(e,r){i&&h&&h%3==0&&/^[0-9]$/.test(e)&&(s=t.numberFormat[","]+s),r&&"-"===e&&(a=!0,e="0"),s=e+s,h++}for(var f=r.length;--f>=0;){var d=r[f];s="";for(var m=d.length;--m>=0;){var g=d.charAt(m);c<0?"0"==g?p("0"):"?"==g&&p(" "):("0"==e&&"?"==g?p(" "):"0"==g?p(e.charAt(c),!0):p(e.charAt(c)),c--)}if(0===f)for(;c>=0;)p(e.charAt(c--));l.unshift(s)}return a&&(l[0]="-"+l[0]),l},formatDec:function(t,e,r){var n=(t=u.toFixed(t,r)).indexOf(".");t=n>=0?t.substr(n+1).replace(/0+$/,""):"";for(var i=0,o=[],s=0;s<e.length;++s){for(var a=e[s],c="",l=0;l<a.length;++l){var h=a.charAt(l);i<t.length?c+=t.charAt(i++):"0"==h?c+="0":"?"==h&&(c+=" ")}o.push(c)}return o},toFixed:function(t,e){return function t(r,n){if(!isFinite(r))return"#NUM!";if(r<0)return"-"+t(-r);if(0===e)return String(Math.round(r));if(r===Math.round(r)&&!/e/i.test(String(r)))return r.toFixed(e);var i=function(t){var e,r,n,i=String(t).toLowerCase(),o=i.indexOf(".");if(o<0?(o=i.indexOf("e"))<0?(e=i,r=""):(e=i.substr(0,o),r=i.substr(o)):(e=i.substr(0,o),r=i.substr(o+1)),n=/(\d*)e([-+]?\d+)/.exec(r)){var s=parseInt(n[2],10);s>=0?(e+=(r=function(t,e,r){for(t+="";t.length<e;)t+=r;return t}(n[1],s,"0")).substr(0,s),r=r.substr(s)):(r=(e=h(e,-s,"0")).substr(s)+n[1],e=e.substr(0,e.length+s))}return{intpart:e||"0",decpart:r}}(r),o=i.intpart,s=i.decpart;if(s.length<=e){for(;s.length<e;)s+="0";return o+"."+s}if(n)return o+"."+s.substr(0,e);var a=Math.pow(10,e);return t(Math.round(r*a)/a,!0)}(Number(t.toFixed(14)))}};function h(t,e,r){for(t+="";t.length<e;)t=r+t;return t}function p(t){for(var e=t.body,r="",n=0;n<e.length;++n){var i=e[n];"string"==typeof i?r+=i:"space"==i.type&&(r+=" ")}return r}kendo.spreadsheet.formatting={compile:c,parse:o,format:function(t,e,n){var i=c(e)(t,n),o=r.element("span");o.__dataType=i.type;var s=i.body;i.color&&(o.attr.style={color:i.color});for(var a=0;a<s.length;++a){var l=s[a];"string"==typeof l?o.children.push(r.text(l)):"space"==l.type&&o.children.push(r.element("span",{style:{visibility:"hidden"}},[r.text(l.value)]))}return o},text:function(t,e,r){return p(c(e)(t,r))},textAndColor:function(t,e,r){var n=c(e)(t,r);return{text:p(n),color:n.color,type:n.type}},type:function(t,e){return c(e)(t).type},adjustDecimals:function(t,e){var r,n=o(t);return r=e,n.forEach((function(t){var e=r;if("text"!=t.cond){for(var n=t.body,i=!1,o=n.length;0!==e&&--o>=0;){var s=n[o];if("digit"==s.type){if(s.decimal){if(i=!0,e>0)s.format+=h("",e,"0");else if(e<0){var a=s.format.length;s.format=s.format.substr(0,a+e),e+=a-s.format.length}if(0===s.format.length)for(n.splice(o,1);--o>=0;){if("digit"==(s=n[o]).type&&s.decimal){++o;break}if("dec"==s.type){n.splice(o,1);break}}}if(e>0)break}}!i&&e>0&&n.splice(o+1,0,{type:"dec"},{type:"digit",sep:!1,decimal:!0,format:h("",e,"0")})}})),function(t){return t.map((function(t){var e="";return t.color&&(e+="["+t.color+"]"),t.cond&&"text"!=t.cond&&"num"!=t.cond&&(e+="["+t.cond.op+t.cond.value+"]"),e+t.body.map(r).join("")})).join(";");function e(t,e){return e.fraction&&(t+="."+h("",e.fraction,"0")),t}function r(t){return"digit"==t.type?t.sep?t.format.charAt(0)+","+t.format.substr(1):t.format:"exp"==t.type?t.ch+t.sign:"date"==t.type||"time"==t.type?e(h("",t.format,t.part),t):"eltime"==t.type?e("["+h("",t.format,t.part)+"]",t):"ampm"==t.type?t.am+"/"+t.pm:"str"==t.type?JSON.stringify(t.value):"text"==t.type?"@":"space"==t.type?"_"+t.value:"fill"==t.type?"*"+t.value:"dec"==t.type?".":"percent"==t.type?"%":"comma"==t.type?",":void 0}}(n)},makeDateFormat:l}})?n.apply(e,i):n)||(t.exports=o)},1623:function(t,e){t.exports=r(1906)},1624:function(t,e){t.exports=r(1599)}})}}]);