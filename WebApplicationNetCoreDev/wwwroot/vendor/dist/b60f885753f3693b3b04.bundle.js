(self.webpackChunk_5_112_1332=self.webpackChunk_5_112_1332||[]).push([[147],{242:(e,t,i)=>{e.exports=function(e){var t={};function i(l){if(t[l])return t[l].exports;var a=t[l]={exports:{},id:l,loaded:!1};return e[l].call(a.exports,a,a.exports,i),a.loaded=!0,a.exports}return i.m=e,i.c=t,i.p="",i(0)}({0:function(e,t,i){e.exports=i(1014)},3:function(e,t){e.exports=function(){throw new Error("define cannot be used indirect")}},1014:function(e,t,i){var l,a,o;i(3),a=[i(1015)],void 0===(o="function"==typeof(l=function(){!function(e,t){var i=window.kendo,l=i.ui.editor,a=l.EditorUtils,o=l.RangeUtils,s=l.Dom,n=a.registerTool,d=l.ToolTemplate,r=l.Command,c=new l.BlockFormatFinder([{tags:["table"]}]),p=new l.BlockFormatFinder([{tags:["td","th"]}]),b=/([a-z]+|%)$/i,u="scope",g="col-index",h="th",m="td",v=r.extend({exec:function(){var a=this,o=a.editor,s=a.range=a.lockRange(),n=a._sourceTable=a.options.insertNewTable?t:a._selectedTable(s),d=a._selectedTableCells=n?a._selectedCells(s):t,r={visible:!1,messages:o.options.messages,closeCallback:e.proxy(a.onDialogClose,a),table:a.parseTable(n,d),dialogOptions:o.options.dialogOptions,isRtl:i.support.isRtl(o.wrapper)};new l.TableWizardDialog(r).open()},onDialogClose:function(e){var t=this;t.releaseRange(t.range),e&&(t.options.insertNewTable?t.insertTable(t.createNewTable(e)):t.updateTable(e,t._sourceTable,t._selectedTableCells))},releaseRange:function(e){var t=this.editor.document;s.windowFromDocument(t).focus(),r.fn.releaseRange.call(this,e)},insertTable:function(e){var t=this.range;t.insertNode(e),t.collapse(!0),this.editor.selectRange(t),this._ensureFocusableAfterTable(e)},_ensureFocusableAfterTable:function(t){for(var i=e(t).parent().contents(),l=i.length-1,a=i.get(l);null!==a.nodeValue&&(" "===a.nodeValue||""===a.nodeValue);)l-=1,a=i.get(l);a===t&&s.insertAfter(s.createEmptyNode(this.editor.document,"p"),t)},updateTable:function(t,i,l){for(var a,o,n=this,d=e(i.rows).toArray(),r=t.tableProperties,c=r.rows,p=i.tHead,b=n._lastInCollection;l.length>1;)l.pop();a=l.length?b(l).parentNode:b(d),n._deleteTableRows(d,d.length-c),d.length<c&&n._addRows(a,c,d),s.reMapTableColumns(i,g),n._updateColumns(d,r.columns,l,a),n._updateTableProperties(i,r),o=t.cellProperties,l[0]&&s.attr(l[0],{id:o.id||null}),(o.selectAllCells?e(d).children():e(l)).each((function(e,t){n._updateCellProperties(t,o)})),n._updateCaption(i,r),p?n._updateHeadersWithThead(i,t):n._updateHeadersNoThead(i,t),n._updateHeaderAssociates(i,r),s.clearTableMappings(i,g)},_isHeadingRow:function(e){return s.is(e.cells[0],h)&&s.is(e.parentNode,"thead")},_isHeadingCell:function(e){return s.is(e,h)},cellsWithHeadersAssociated:function(t){var i=e(t.rows).children(),l=[],a=function(e){return l.indexOf(e)>-1};return i.each((function(e,t){t.id&&s.is(t,h)&&l.push(t.id)})),!!i.filter((function(e,t){var i,l=t.getAttribute("headers");return!!(l&&!s.is(t,h)&&(i=l.split(" "))&&i.length>0)&&i.some(a)})).length},_insertCells:function(e,t,i){i=isNaN(i)?-1:i;for(var l=0;l<e;l++)t.insertCell(i).innerHTML="&nbsp;"},_deleteTableRows:function(e,t){for(var i,l,a=0;a<t;a++)(l=(i=e.pop()).parentNode).removeChild(i),l.rows.length||s.remove(l)},createNewTable:function(e){var t,i=this,l=i.editor.document,a=e.tableProperties,o=s.create(l,"table"),n=0;i._updateTableProperties(o,a),i._updateCaption(o,a),a.headerRows&&a.headerRows>0&&(t=o.createTHead(),i._createTableRows(e,t,n,!0),n+=a.headerRows);var d=o.createTBody();return i._createTableRows(e,d,n,!1),s.reMapTableColumns(o,g),"ids"===a.cellsWithHeaders?s.associateWithIds(o):"scope"===a.cellsWithHeaders&&i._addScopes(o,a.headerRows,a.headerColumns),s.clearTableMappings(o,g),o},_createTableRows:function(e,t,i,l){for(var a,o=e.tableProperties,s=e.cellProperties,n=o.columns,d=l?o.headerRows:o.rows,r=s.selectAllCells,c=o.headerColumns,p=i;p<d;p++){a=t.insertRow();for(var b,u=0;u<n;u++)b=l||c>u?document.createElement(h):document.createElement(m),a.appendChild(b),b.innerHTML="&nbsp;",0===p&&0===u&&s.id&&(b.id=s.id),this._updateCellProperties(b,r||0===p&&0===u?s:{})}},_addRows:function(t,i,l){for(var a,o=e(t).index(),s=t.cells.length,n=i-l.length,d=t.parentNode;n;)a=d.insertRow(o+1),this._insertCells(s-a.cells.length,a),n--},_updateColumns:function(t,i,l,a){var o=this,s=o._lastInCollection,n=s(t[0].cells),d=Number(n.getAttribute(g))+n.colSpan;if(d>i&&e(t).each((function(e,t){for(var l=s(t.cells),a=Number(l.getAttribute(g))+l.colSpan;a>i;)l.colSpan&&l.colSpan>1?l.colSpan-=1:t.deleteCell(-1),l=s(t.cells),a=Number(l.getAttribute(g))+l.colSpan})),d<i){var r=e(s(l)||s(a.cells)).index();e(t).each((function(e,t){var l=s(t.cells);o._insertCells(i-Number(l.getAttribute(g))-l.colSpan,t,r+1)}))}},_updateTableProperties:function(t,i){var l=this._getStylesData(i);s.attr(t,{cellSpacing:i.cellSpacing||null,cellPadding:i.cellPadding||null,className:i.className||null,id:i.id||null,summary:i.summary||null,style:l||null}),e(t).addClass("k-table")},_updateCellProperties:function(e,t){var i=this._getStylesData(t);i.padding=t.cellPadding||null,i.margin=t.cellMargin||null,s.attr(e,{style:i||null,className:t.className||null})},_updateCaption:function(e,t){if(e.caption&&!t.captionContent)e.deleteCaption();else if(t.captionContent){var i=e.createCaption();i.innerHTML=t.captionContent;var l=this._getAlignmentData(t.captionAlignment);s.attr(i,{style:{textAlign:l.textAlign,verticalAlign:l.verticalAlign}})}},_updateHeadersNoThead:function(e,t){var i,l,a,o,n=t.tableProperties,d=e.rows;for(a=0;a<d.length;a++)for(i=d[a].cells,o=0;o<i.length;o++)l=i[o],!this._isHeadingCell(l)&&(a<n.headerRows||n.headerColumns>l.getAttribute(g))?s.changeTag(l,h,!1):this._isHeadingCell(l)&&a>=n.headerRows&&n.headerColumns<=l.getAttribute(g)&&s.changeTag(l,m,!1)},_updateHeadersWithThead:function(e,t){var i,l,a,o=this,n=t.tableProperties,d=e.tHead,r=0,c=e.tBodies[0];if(c||(c=e.createTBody()),n.headerRows&&n.headerRows>0){for(d||(d=e.createTHead());d.rows.length<n.headerRows;)d.appendChild(c.rows[0]);for(;d.rows.length>n.headerRows;)c.appendChild(d.rows[0]);o._swapToHeaderCells(d)}else if(d){for(;d.rows.length>0;)c.appendChild(d.rows[d.rows.length-1]);e.deleteTHead()}for(;c.rows.length>r;){for(i=c.rows[r],a=0;a<i.cells.length;a++)l=i.cells[a],o._isHeadingCell(l)&&n.headerColumns<=l.getAttribute(g)?s.changeTag(l,m,!1):!o._isHeadingCell(l)&&n.headerColumns>l.getAttribute(g)&&s.changeTag(l,h,!1);r+=1}},_updateHeaderAssociates:function(e,t){var i=this;"ids"===t.cellsWithHeaders?(i.cellsWithHeadersAssociated(e)||i._removeScopes(e),s.associateWithIds(e)):"scope"===t.cellsWithHeaders?(i.cellsWithHeadersAssociated(e)&&i._removeAssociates(e),i._addScopes(e,t.headerRows,t.headerColumns)):i.cellsWithHeadersAssociated(e)?i._removeAssociates(e):i._removeScopes(e)},_addScopes:function(e,t,i){var l,a,o,s,n=e.rows;for(l=0;l<n.length;l++)for(o=n[l],a=0;a<o.cells.length;a++)s=o.cells[a],l<t?s.setAttribute(u,"col"):s.getAttribute(g)<i&&s.setAttribute(u,"row")},_removeScopes:function(t){e(t).find(h).removeAttr(u),e(t).find("col").remove(),e(t).find("colgroup").remove()},_removeAssociates:function(t){e(t).find("th, td").removeAttr("id headers")},_swapToHeaderCells:function(t){e(t).find("td").each((function(e,t){s.changeTag(t,h,!1)}))},_getStylesData:function(e){var t=this._getAlignmentData(e.alignment),i="wrapText"in e?e.wrapText?"":"nowrap":null;return{width:e.width?e.width+e.widthUnit:null,height:e.height?e.height+e.heightUnit:null,textAlign:t.textAlign,verticalAlign:t.verticalAlign,backgroundColor:e.bgColor||"",borderWidth:e.borderWidth,borderStyle:e.borderStyle,borderColor:e.borderColor||"",borderCollapse:e.collapseBorders?"collapse":null,whiteSpace:i}},_getAlignmentData:function(e){var t="",i=t;if(e)if(-1!=e.indexOf(" ")){var l=e.split(" ");t=l[0],i=l[1]}else t=e;return{textAlign:t,verticalAlign:i}},parseTable:function(i,l){if(!i)return{tableProperties:{},selectedCells:[]};var a=this,o=i.style,n=i.rows,d=i.caption,r=e(d?d.cloneNode(!0):t);r.find(".k-marker").remove();var c=i.className;c=(c=(c=c.replace(/^k-table\s|\sk-table$/,"")).replace(/\sk-table\s/," ")).replace(/^k-table$/,"");var p,b=a._getAlignment(i,!0),u=d?a._getAlignment(d):t,h=s._getNumberOfHeaderRows(i);p=a.cellsWithHeadersAssociated(i)?"ids":e(i).find("th[scope]").length>0?"scope":"none",s.reMapTableColumns(i,g);var m=s._getNumberOfColumns(i),v=s._getNumberOfHeaderColumns(i,h);s.clearTableMappings(i,g);var k={tableProperties:{width:o.width||i.width?parseFloat(o.width||i.width):null,height:o.height||i.height?parseFloat(o.height||i.height):null,columns:m,rows:n.length,widthUnit:a._getUnit(o.width),heightUnit:a._getUnit(o.height),cellSpacing:i.cellSpacing,cellPadding:i.cellPadding,alignment:b.textAlign,bgColor:o.backgroundColor||i.bgColor,className:c,id:i.id,borderWidth:o.borderWidth||i.border,borderColor:o.borderColor,borderStyle:o.borderStyle||"",collapseBorders:!!o.borderCollapse,summary:i.summary,captionContent:d?r.html():"",captionAlignment:d&&u.textAlign?u.textAlign+" "+u.verticalAlign:"",headerRows:h,headerColumns:v,cellsWithHeaders:p},selectedCells:[]};return k.rows=a.parseTableRows(n,l,k),k},parseTableRows:function(t,i,l){for(var a,o,s,n,d=[],r=0;r<t.length;r++){a={cells:[]},o=t[r].cells,d.push(a);for(var c=0;c<o.length;c++)s=o[c],n=this.parseCell(s),-1!=e.inArray(s,i)&&l.selectedCells.push(n),a.cells.push(n)}return d},parseCell:function(e){var t=this,i=e.style,l=t._getAlignment(e);return l=l.textAlign?l.textAlign+" "+l.verticalAlign:"",{width:i.width||e.width?parseFloat(i.width||e.width):null,height:i.height||e.height?parseFloat(i.height||e.height):null,widthUnit:t._getUnit(i.width),heightUnit:t._getUnit(i.height),cellMargin:i.margin,cellPadding:i.padding,alignment:l,bgColor:i.backgroundColor||e.bgColor,className:e.className,id:e.id,borderWidth:i.borderWidth||e.border,borderColor:i.borderColor,borderStyle:i.borderStyle,wrapText:"nowrap"!=i.whiteSpace}},_getAlignment:function(e,t){var i=e.style,l=i.textAlign||e.align||"";if(t)return{textAlign:l};var a=i.verticalAlign||e.vAlign||"";return l&&a?{textAlign:l,verticalAlign:a}:!l&&a?{textAlign:"left",verticalAlign:a}:l&&!a?{textAlign:l,verticalAlign:"top"}:{textAlign:"",verticalAlign:""}},_getUnit:function(e){var t=(e||"").match(b);return t?t[0]:"px"},_selectedTable:function(e){var t=s.filterBy(o.nodes(e),s.htmlIndentSpace,!0);return c.findSuitable(t)[0]},_selectedCells:function(e){var t=s.filterBy(o.nodes(e),s.htmlIndentSpace,!0);return p.findSuitable(t)},_lastInCollection:function(e){return e[e.length-1]}}),k=l.Tool.extend({command:function(e){return e.insertNewTable=this.options.insertNewTable,new v(e)}}),f=k.extend({update:function(e,t){1==!c.isFormatted(t)?(e.parent().addClass("k-hidden k-state-disabled"),e.attr("disabled","disabled"),e.addClass("k-state-disabled")):(e.parent().removeClass("k-hidden k-state-disabled"),e.removeAttr("disabled"),e.removeClass("k-state-disabled"))}});i.ui.editor.TableWizardTool=k,i.ui.editor.TableWizardCommand=v,n("tableWizard",new f({command:v,insertNewTable:!1,template:new d({template:a.buttonTemplate,title:"Table Wizard"})}))}(window.kendo.jQuery)})?l.apply(t,a):l)||(e.exports=o)},1015:function(e,t){e.exports=i(2943)}})},147:(e,t,i)=>{e.exports=function(e){var t={};function i(l){if(t[l])return t[l].exports;var a=t[l]={exports:{},id:l,loaded:!1};return e[l].call(a.exports,a,a.exports,i),a.loaded=!0,a.exports}return i.m=e,i.c=t,i.p="",i(0)}({0:function(e,t,i){e.exports=i(1016)},3:function(e,t){e.exports=function(){throw new Error("define cannot be used indirect")}},1016:function(e,t,i){var l,a,o;i(3),a=[i(1017),i(1018)],void 0===(o="function"==typeof(l=function(){var e,t,i,l,a,o,s,n,d;e=window.kendo.jQuery,t=window.kendo,i={format:"0",min:0},l=["px","em"],a=["solid","dotted","dashed","double","groove","ridge","inset","outset","initial","inherit","none","hidden"],o={dataSource:[{className:"k-icon k-i-table-align-middle-left",value:"left"},{className:"k-icon k-i-table-align-middle-center",value:"center"},{className:"k-icon k-i-table-align-middle-right",value:"right"},{className:"k-icon k-i-align-remove",value:""}],dataTextField:"className",dataValueField:"value",template:"<span class='#: className #' title='#: tooltip #'></span>",valueTemplate:"<span class='k-align-group #: className #' title='#: tooltip #'></span>"},s={dataSource:[{className:"k-icon k-i-table-align-top-left",value:"left top"},{className:"k-icon k-i-table-align-top-center",value:"center top"},{className:"k-icon k-i-table-align-top-right",value:"right top"},{className:"k-icon k-i-table-align-middle-left",value:"left middle"},{className:"k-icon k-i-table-align-middle-center",value:"center middle"},{className:"k-icon k-i-table-align-middle-right",value:"right middle"},{className:"k-icon k-i-table-align-bottom-left",value:"left bottom"},{className:"k-icon k-i-table-align-bottom-center",value:"center bottom"},{className:"k-icon k-i-table-align-bottom-right",value:"right bottom"},{className:"k-icon k-i-align-remove",value:""}],dataTextField:"className",dataValueField:"value",template:"<span class='#: className #' title='#: tooltip #'></span>",valueTemplate:"<span class='k-align-group #: className #' title='#: tooltip #'></span>"},n={dataSource:[{className:"k-icon k-i-table-align-top-left",value:"left top"},{className:"k-icon k-i-table-align-top-center",value:"center top"},{className:"k-icon k-i-table-align-top-right",value:"right top"},{className:"k-icon k-i-table-align-bottom-left",value:"left bottom"},{className:"k-icon k-i-table-align-bottom-center",value:"center bottom"},{className:"k-icon k-i-table-align-bottom-right",value:"right bottom"},{className:"k-icon k-i-align-remove",value:""}],dataTextField:"className",dataValueField:"value",template:"<span class='#: className #' title='#: tooltip #'></span>",valueTemplate:"<span class='k-align-group #: className #' title='#: tooltip #'></span>"},d=t.Class.extend({init:function(e){this.options=e},open:function(){var i,l=this,a=l.options,o=a.dialogOptions,s=a.table,n=a.messages,d=t.support.browser.msie;function r(e){e.preventDefault(),l.destroy(),i.destroy()}function c(e){r(e),a.closeCallback()}o.close=c,o.title=n.tableWizard,o.visible=a.visible;var p=(i=e(l._dialogTemplate(n)).appendTo(document.body).kendoWindow(o).closest(".k-window").toggleClass("k-rtl",a.isRtl).end().find(".k-dialog-ok").click((function(e){l.collectDialogValues(s),r(e),l.change&&l.change(),a.closeCallback(s)})).end().find(".k-dialog-close").click(c).end().data("kendoWindow")).element;if(l._initTabStripComponent(p),l._initTableViewComponents(p,s),l._initCellViewComponents(p,s),l._initAccessibilityViewComponents(p,s),i.center(),i.open(),d){var b=p.closest(".k-window").height();p.css("max-height",b)}},_initTabStripComponent:function(e){(this.components={}).tabStrip=e.find("#k-table-wizard-tabs").kendoTabStrip({animation:!1}).data("kendoTabStrip")},collectDialogValues:function(){var e=this,t=e.options.table;e._collectTableViewValues(t),e._collectCellViewValues(t),e._collectAccessibilityViewValues(t)},_collectTableViewValues:function(e){var t=this.components.tableView,i=e.tableProperties;i.width=t.width.value(),i.widthUnit=t.widthUnit.value(),i.height=t.height.value(),i.columns=t.columns.value(),i.rows=t.rows.value(),i.heightUnit=t.heightUnit.value(),i.cellSpacing=t.cellSpacing.value(),i.cellPadding=t.cellPadding.value(),i.alignment=t.alignment.value(),i.bgColor=t.bgColor.value(),i.className=t.className.value,i.id=t.id.value,i.borderWidth=t.borderWidth.value(),i.borderColor=t.borderColor.value(),i.borderStyle=t.borderStyle.value(),i.collapseBorders=t.collapseBorders.checked},_collectCellViewValues:function(e){var t=e.cellProperties={},i=this.components.cellView;t.selectAllCells=i.selectAllCells.checked,t.width=i.width.value(),t.widthUnit=i.widthUnit.value(),t.height=i.height.value(),t.heightUnit=i.heightUnit.value(),t.cellMargin=i.cellMargin.value(),t.cellPadding=i.cellPadding.value(),t.alignment=i.alignment.value(),t.bgColor=i.bgColor.value(),t.className=i.className.value,t.id=i.id.value,t.borderWidth=i.borderWidth.value(),t.borderColor=i.borderColor.value(),t.borderStyle=i.borderStyle.value(),t.wrapText=i.wrapText.checked,t.width||(t.selectAllCells=!0,t.width=100/e.tableProperties.columns,t.widthUnit="%")},_collectAccessibilityViewValues:function(e){var t=e.tableProperties,i=this.components.accessibilityView;t.captionContent=i.captionContent.value,t.captionAlignment=i.captionAlignment.value(),t.summary=i.summary.value,t.cellsWithHeaders=i.cellsWithHeaders.value(),t.headerRows=i.headerRows.value(),t.headerColumns=i.headerColumns.value()},_addUnit:function(t,i){i&&-1==e.inArray(i,t)&&t.push(i)},_initTableViewComponents:function(e,t){var i=this,o=i.components.tableView={},s=t.tableProperties=t.tableProperties||{};s.borderStyle=s.borderStyle||"";i._addUnit(l,s.widthUnit),i._addUnit(l,s.heightUnit),i._initNumericTextbox(e.find("#k-editor-table-width"),"width",s,o),i._initNumericTextbox(e.find("#k-editor-table-height"),"height",s,o),i._initNumericTextbox(e.find("#k-editor-table-columns"),"columns",s,o,{min:1,value:4,change:function(e){var t=i.components.accessibilityView.headerColumns,l=t.value(),a=e.sender.value();a<l&&t.value(a),t.max(a)}}),i._initNumericTextbox(e.find("#k-editor-table-rows"),"rows",s,o,{min:1,value:4,change:function(e){var t=i.components.accessibilityView.headerRows,l=t.value(),a=e.sender.value();a<l&&t.value(a),t.max(a)}}),i._initDropDownList(e.find("#k-editor-table-width-type"),"widthUnit",s,o,l),i._initDropDownList(e.find("#k-editor-table-height-type"),"heightUnit",s,o,l),i._initNumericTextbox(e.find("#k-editor-table-cell-spacing"),"cellSpacing",s,o),i._initNumericTextbox(e.find("#k-editor-table-cell-padding"),"cellPadding",s,o),i._initTableAlignmentDropDown(e.find("#k-editor-table-alignment"),s),i._initColorPicker(e.find("#k-editor-table-bg"),"bgColor",s,o),i._initInput(e.find("#k-editor-css-class"),"className",s,o),i._initInput(e.find("#k-editor-id"),"id",s,o),i._initNumericTextbox(e.find("#k-editor-border-width"),"borderWidth",s,o),i._initColorPicker(e.find("#k-editor-border-color"),"borderColor",s,o),i._initDropDownList(e.find("#k-editor-border-style"),"borderStyle",s,o,a),i._initCheckbox(e.find("#k-editor-collapse-borders"),"collapseBorders",s,o)},_initCellViewComponents:function(e,t){var i=this.components.cellView={};t.selectedCells=t.selectedCells=t.selectedCells||[];var o=t.selectedCells[0]||{borderStyle:"",wrapText:!0};this._addUnit(l,o.widthUnit),this._addUnit(l,o.heightUnit),this._initCheckbox(e.find("#k-editor-selectAllCells"),"selectAllCells",t.tableProperties,i),this._initNumericTextbox(e.find("#k-editor-cell-width"),"width",o,i),this._initNumericTextbox(e.find("#k-editor-cell-height"),"height",o,i),this._initDropDownList(e.find("#k-editor-cell-width-type"),"widthUnit",o,i,l),this._initDropDownList(e.find("#k-editor-cell-height-type"),"heightUnit",o,i,l),this._initNumericTextbox(e.find("#k-editor-table-cell-margin"),"cellMargin",o,i),this._initNumericTextbox(e.find("#k-editor-table-cells-padding"),"cellPadding",o,i),this._initCellAlignmentDropDown(e.find("#k-editor-cell-alignment"),o),this._initColorPicker(e.find("#k-editor-cell-bg"),"bgColor",o,i),this._initInput(e.find("#k-editor-cell-css-class"),"className",o,i),this._initInput(e.find("#k-editor-cell-id"),"id",o,i),this._initNumericTextbox(e.find("#k-editor-cell-border-width"),"borderWidth",o,i),this._initColorPicker(e.find("#k-editor-cell-border-color"),"borderColor",o,i),this._initDropDownList(e.find("#k-editor-cell-border-style"),"borderStyle",o,i,a),this._initCheckbox(e.find("#k-editor-wrap-text"),"wrapText",o,i)},_initAccessibilityViewComponents:function(e,t){var i=this.components.accessibilityView={},l=t.tableProperties;this._initInput(e.find("#k-editor-table-caption"),"captionContent",l,i),this._initAccessibilityAlignmentDropDown(e.find("#k-editor-accessibility-alignment"),l),this._initInput(e.find("#k-editor-accessibility-summary"),"summary",l,i),this._initAssociationDropDown(e.find("#k-editor-cells-headers"),"cellsWithHeaders",{valuePrimitive:!0},l,i),this._initNumericTextbox(e.find("#k-editor-table-header-rows"),"headerRows",l,i,{max:l.rows||4}),this._initNumericTextbox(e.find("#k-editor-table-header-columns"),"headerColumns",l,i,{max:l.columns||4})},_initNumericTextbox:function(t,l,a,o,s){var n=o[l]=t.kendoNumericTextBox(s?e.extend({},i,s):i).data("kendoNumericTextBox");l in a&&n.value(parseInt(a[l],10))},_initDropDownList:function(e,t,i,l,a){var o=l[t]=e.kendoDropDownList({dataSource:a}).data("kendoDropDownList");this._setComponentValue(o,i,t)},_initTableAlignmentDropDown:function(e,t){var i=this.options.messages,l=this.components.tableView,a=o.dataSource;a[0].tooltip=i.alignLeft,a[1].tooltip=i.alignCenter,a[2].tooltip=i.alignRight,a[3].tooltip=i.alignRemove,this._initAlignmentDropDown(e,o,"alignment",t,l)},_initCellAlignmentDropDown:function(e,t){var i=this.options.messages,l=this.components.cellView,a=s.dataSource;a[0].tooltip=i.alignLeftTop,a[1].tooltip=i.alignCenterTop,a[2].tooltip=i.alignRightTop,a[3].tooltip=i.alignLeftMiddle,a[4].tooltip=i.alignCenterMiddle,a[5].tooltip=i.alignRightMiddle,a[6].tooltip=i.alignLeftBottom,a[7].tooltip=i.alignCenterBottom,a[8].tooltip=i.alignRightBottom,a[9].tooltip=i.alignRemove,this._initAlignmentDropDown(e,s,"alignment",t,l)},_initAccessibilityAlignmentDropDown:function(e,t){var i=this.options.messages,l=this.components.accessibilityView,a=n.dataSource;a[0].tooltip=i.alignLeftTop,a[1].tooltip=i.alignCenterTop,a[2].tooltip=i.alignRightTop,a[3].tooltip=i.alignLeftBottom,a[4].tooltip=i.alignCenterBottom,a[5].tooltip=i.alignRightBottom,a[6].tooltip=i.alignRemove,this._initAlignmentDropDown(e,n,"captionAlignment",t,l)},_initAlignmentDropDown:function(e,t,i,l,a){var o=a[i]=e.kendoDropDownList(t).data("kendoDropDownList");o.list.addClass("k-align").css("width","110px"),this._setComponentValue(o,l,i)},_initAssociationDropDown:function(e,t,i,l,a){var o=a[t]=e.kendoDropDownList(i).data("kendoDropDownList");this._setComponentValue(o,l,t)},_setComponentValue:function(e,t,i){i in t&&e.value(t[i])},_initColorPicker:function(e,t,i,l){var a=l[t]=e.kendoColorPicker({buttons:!1,clearButton:!0}).data("kendoColorPicker");i[t]&&a.value(i[t])},_initInput:function(e,t,i,l){var a=l[t]=e.get(0);t in i&&(a.value=i[t])},_initCheckbox:function(e,t,i,l){var a=l[t]=e.get(0);t in i&&(a.checked=i[t])},destroy:function(){this._destroyComponents(this.components.tableView),this._destroyComponents(this.components.cellView),this._destroyComponents(this.components.accessibilityView),this._destroyComponents(this.components),delete this.components},_destroyComponents:function(e){for(var t in e)e[t].destroy&&e[t].destroy(),delete e[t]},_dialogTemplate:function(e){return t.template('<div class="k-editor-dialog k-editor-table-wizard-dialog k-action-window k-popup-edit-form"><div class="k-edit-form-container"><div id="k-table-wizard-tabs" class="k-root-tabs"><ul><li class="k-state-active">#= messages.tableTab #</li><li>#= messages.cellTab #</li><li>#= messages.accessibilityTab #</li></ul><div id="k-table-properties"><div class="k-edit-label"><label for="k-editor-table-width">#= messages.width #</label></div><div class="k-edit-field"><input type="numeric" id="k-editor-table-width" /><input id="k-editor-table-width-type" aria-label="#= messages.units #" /></div><div class="k-edit-label"><label for="k-editor-table-height">#= messages.height #</label></div><div class="k-edit-field"><input type="numeric" id="k-editor-table-height" /><input id="k-editor-table-height-type" aria-label="#= messages.units #" /></div><div class="k-edit-label"><label for="k-editor-table-columns">#= messages.columns #</label></div><div class="k-edit-field"><input type="numeric" id="k-editor-table-columns" /></div><div class="k-edit-label"><label for="k-editor-table-rows">#= messages.rows #</label></div><div class="k-edit-field"><input type="numeric" id="k-editor-table-rows" /></div><div class="k-edit-label"><label for="k-editor-table-cell-spacing">#= messages.cellSpacing #</label></div><div class="k-edit-field"><input type="numeric" id="k-editor-table-cell-spacing" /></div><div class="k-edit-label"><label for="k-editor-table-cell-padding">#= messages.cellPadding #</label></div><div class="k-edit-field"><input type="numeric" id="k-editor-table-cell-padding" /></div><div class="k-edit-label"><label for="k-editor-table-alignment">#= messages.alignment #</label></div><div class="k-edit-field"><input id="k-editor-table-alignment" class="k-align" /></div><div class="k-edit-label"><label for="k-editor-table-bg">#= messages.background #</label></div><div class="k-edit-field"><input id="k-editor-table-bg" /></div><div class="k-edit-label"><label for="k-editor-css-class">#= messages.cssClass #</label></div><div class="k-edit-field"><input id="k-editor-css-class" class="k-textbox" type="text" /></div><div class="k-edit-label"><label for="k-editor-id">#= messages.id #</label></div><div class="k-edit-field"><input id="k-editor-id" class="k-textbox" type="text" /></div><div class="k-edit-label"><label for="k-editor-border-width">#= messages.border #</label></div><div class="k-edit-field"><input type="numeric" id="k-editor-border-width" /><input id="k-editor-border-color" /></div><div class="k-edit-label"><label for="k-editor-border-style">#= messages.borderStyle #</label></div><div class="k-edit-field"><input id="k-editor-border-style" /></div><div class="k-edit-label">&nbsp;</div><div class="k-edit-field"><input id="k-editor-collapse-borders" type="checkbox" class="k-checkbox" /><label for="k-editor-collapse-borders" class="k-checkbox-label">#= messages.collapseBorders #</label></div></div><div id="k-cell-properties"><div class="k-edit-field"><input id="k-editor-selectAllCells" type="checkbox" class="k-checkbox" /><label for="k-editor-selectAllCells" class="k-checkbox-label">#= messages.selectAllCells #</label></div><div class="k-edit-label"><label for="k-editor-cell-width">#= messages.width #</label></div><div class="k-edit-field"><input type="numeric" id="k-editor-cell-width" /><input id="k-editor-cell-width-type" aria-label="#= messages.units #" /></div><div class="k-edit-label"><label for="k-editor-cell-height">#= messages.height #</label></div><div class="k-edit-field"><input type="numeric" id="k-editor-cell-height" /><input id="k-editor-cell-height-type" aria-label="#= messages.units #" /></div><div class="k-edit-label"><label for="k-editor-table-cell-margin">#= messages.cellMargin #</label></div><div class="k-edit-field"><input type="numeric" id="k-editor-table-cell-margin" /></div><div class="k-edit-label"><label for="k-editor-table-cells-padding">#= messages.cellPadding #</label></div><div class="k-edit-field"><input type="numeric" id="k-editor-table-cells-padding" /></div><div class="k-edit-label"><label for="k-editor-cell-alignment">#= messages.alignment #</label></div><div class="k-edit-field"><input id="k-editor-cell-alignment" class="k-align" /></div><div class="k-edit-label"><label for="k-editor-cell-bg">#= messages.background #</label></div><div class="k-edit-field"><input id="k-editor-cell-bg" /></div><div class="k-edit-label"><label for="k-editor-cell-css-class">#= messages.cssClass #</label></div><div class="k-edit-field"><input id="k-editor-cell-css-class" class="k-textbox" type="text" /></div><div class="k-edit-label"><label for="k-editor-cell-id">#= messages.id #</label></div><div class="k-edit-field"><input id="k-editor-cell-id" class="k-textbox" type="text" /></div><div class="k-edit-label"><label for="k-editor-cell-border-width">#= messages.border #</label></div><div class="k-edit-field"><input type="numeric" id="k-editor-cell-border-width" /><input id="k-editor-cell-border-color" /></div><div class="k-edit-label"><label for="k-editor-cell-border-style">#= messages.borderStyle #</label></div><div class="k-edit-field"><input id="k-editor-cell-border-style" /></div><div class="k-edit-label">&nbsp;</div><div class="k-edit-field"><input id="k-editor-wrap-text" type="checkbox" class="k-checkbox" /><label for="k-editor-wrap-text" class="k-checkbox-label">#= messages.wrapText #</label></div></div><div id="k-accessibility-properties"><div class="k-edit-label"><label for="k-editor-table-header-rows">#= messages.headerRows #</label></div><div class="k-edit-field"><input type="numeric" id="k-editor-table-header-rows" /></div><div class="k-edit-label"><label for="k-editor-table-header-columns">#= messages.headerColumns #</label></div><div class="k-edit-field"><input type="numeric" id="k-editor-table-header-columns" /></div><div class="k-edit-label"><label for="k-editor-table-caption">#= messages.caption #</label></div><div class="k-edit-field"><input id="k-editor-table-caption" class="k-textbox" type="text"/></div><div class="k-edit-label"><label for="k-editor-accessibility-alignment">#= messages.alignment #</label></div><div class="k-edit-field"><input id="k-editor-accessibility-alignment" class="k-align" /></div><div class="k-edit-label"><label for="k-editor-accessibility-summary">#= messages.summary #</label></div><div class="k-edit-field"><textarea id="k-editor-accessibility-summary" rows="5" class="k-textbox k-editor-accessibility-summary" placeholder="#= messages.tableSummaryPlaceholder #"></textarea></div><div class="k-edit-label"><label for="k-editor-cells-headers">#= messages.associateCellsWithHeaders #</label></div><div class="k-edit-field"><select id="k-editor-cells-headers"><option value="none">#= messages.associateNone #</option><option value="scope">#= messages.associateScope #</option><option value="ids">#= messages.associateIds #</option></select></div></div></div><div class="k-edit-buttons k-state-default"><button class="k-button k-primary k-dialog-ok">#= messages.dialogOk #</button><button class="k-button k-dialog-close">#= messages.dialogCancel #</button></div></div></div>')({messages:e})}}),t.ui.editor.TableWizardDialog=d})?l.apply(t,a):l)||(e.exports=o)},1017:function(e,t){e.exports=i(242)},1018:function(e,t){e.exports=i(4203)}})}}]);