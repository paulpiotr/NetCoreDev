(self.webpackChunk_5_112_1332=self.webpackChunk_5_112_1332||[]).push([[8635],{8635:(t,e,i)=>{t.exports=function(t){var e={};function i(n){if(e[n])return e[n].exports;var o=e[n]={exports:{},id:n,loaded:!1};return t[n].call(o.exports,o,o.exports,i),o.loaded=!0,o.exports}return i.m=t,i.c=e,i.p="",i(0)}({0:function(t,e,i){t.exports=i(905)},3:function(t,e){t.exports=function(){throw new Error("define cannot be used indirect")}},884:function(t,e){t.exports=i(3889)},898:function(t,e){t.exports=i(219)},905:function(t,e,i){var n,o,s;i(3),o=[i(884),i(898)],void 0===(s="function"==typeof(n=function(){!function(t,e){var i=window.kendo,n=i.dataviz.diagram,o=i.Class,s=n.Group,r=n.Rect,a=n.Rectangle,h=n.Utils,c=h.isUndefined,d=n.Point,u=n.Circle,l=n.Ticker,f=i.deepExtend,p=i.ui.Movable,g=i.drawing.util,v=g.defined,_=t.inArray,m=t.proxy,y={arrow:"default",grip:"pointer",cross:"pointer",add:"pointer",move:"move",select:"pointer",south:"s-resize",east:"e-resize",west:"w-resize",north:"n-resize",rowresize:"row-resize",colresize:"col-resize"},x=10,w="Auto",S="Top",b="Right",T="Left",C="Bottom",M="dragStart",k="drag",z="dragEnd",B="itemBoundsChange",P="transparent",A="rotated",I="target",R={"-1":"source",1:I};n.Cursors=y;var H=i.Class.extend({init:function(t){this.layoutState=t,this.diagram=t.diagram},initState:function(){this.froms=[],this.tos=[],this.subjects=[],this.layoutState.nodeMap.forEach((function(t,e){var i=this.diagram.getShapeById(t);i&&(this.subjects.push(i),this.froms.push(i.bounds().topLeft()),this.tos.push(e.topLeft()))}),this)},update:function(t){if(!(this.subjects.length<=0))for(var e=0;e<this.subjects.length;e++)this.subjects[e].position(new d(this.froms[e].x+(this.tos[e].x-this.froms[e].x)*t,this.froms[e].y+(this.tos[e].y-this.froms[e].y)*t))}}),L=o.extend({init:function(t,e,i){c(i)?this.animate=!1:this.animate=i,this._initialState=t,this._finalState=e,this.title="Diagram layout"},undo:function(){this.setState(this._initialState)},redo:function(){this.setState(this._finalState)},setState:function(t){var e=t.diagram;if(this.animate){t.linkMap.forEach((function(t,i){var n=e.getShapeById(t);n.visible(!1),n&&n.points(i)}));var i=new l;i.addAdapter(new H(t)),i.onComplete((function(){t.linkMap.forEach((function(t){e.getShapeById(t).visible(!0)}))})),i.play()}else t.nodeMap.forEach((function(t,i){var n=e.getShapeById(t);n&&n.position(i.topLeft())})),t.linkMap.forEach((function(t,i){var n=e.getShapeById(t);n&&n.points(i)}))}}),D=o.extend({init:function(t){this.units=[],this.title="Composite unit",t!==e&&this.units.push(t)},add:function(t){this.units.push(t)},undo:function(){for(var t=0;t<this.units.length;t++)this.units[t].undo()},redo:function(){for(var t=0;t<this.units.length;t++)this.units[t].redo()}}),E=o.extend({init:function(t,e,i){this.item=t,this._redoSource=e,this._redoTarget=i,v(e)&&(this._undoSource=t.source()),v(i)&&(this._undoTarget=t.target()),this.title="Connection Editing"},undo:function(){this._undoSource!==e&&this.item._updateConnector(this._undoSource,"source"),this._undoTarget!==e&&this.item._updateConnector(this._undoTarget,"target"),this.item.updateModel()},redo:function(){this._redoSource!==e&&this.item._updateConnector(this._redoSource,"source"),this._redoTarget!==e&&this.item._updateConnector(this._redoTarget,"target"),this.item.updateModel()}}),U=o.extend({init:function(t,e,i){this.item=t,this._undoSource=e,this._undoTarget=i,this._redoSource=t.source(),this._redoTarget=t.target(),this.title="Connection Editing"},undo:function(){this.item._updateConnector(this._undoSource,"source"),this.item._updateConnector(this._undoTarget,"target"),this.item.updateModel()},redo:function(){this.item._updateConnector(this._redoSource,"source"),this.item._updateConnector(this._redoTarget,"target"),this.item.updateModel()}}),O=o.extend({init:function(t){this.connection=t,this.diagram=t.diagram,this.targetConnector=t.targetConnector,this.title="Delete connection"},undo:function(){this.diagram._addConnection(this.connection,!1)},redo:function(){this.diagram.remove(this.connection,!1)}}),K=o.extend({init:function(t){this.shape=t,this.diagram=t.diagram,this.title="Deletion"},undo:function(){this.diagram._addShape(this.shape,!1),this.shape.select(!1)},redo:function(){this.shape.select(!1),this.diagram.remove(this.shape,!1)}}),V=o.extend({init:function(t,e,i){this.shapes=t,this.undoStates=e,this.title="Transformation",this.redoStates=[],this.adorner=i;for(var n=0;n<this.shapes.length;n++){var o=this.shapes[n];this.redoStates.push(o.bounds())}},undo:function(){for(var t=0;t<this.shapes.length;t++){var e=this.shapes[t];e.bounds(this.undoStates[t]),e.hasOwnProperty("layout")&&e.layout(e,this.redoStates[t],this.undoStates[t]),e.updateModel()}this.adorner&&(this.adorner.refreshBounds(),this.adorner.refresh())},redo:function(){for(var t=0;t<this.shapes.length;t++){var e=this.shapes[t];e.bounds(this.redoStates[t]),e.hasOwnProperty("layout")&&e.layout(e,this.undoStates[t],this.redoStates[t]),e.updateModel()}this.adorner&&(this.adorner.refreshBounds(),this.adorner.refresh())}}),N=o.extend({init:function(t,e){this.connection=t,this.diagram=e,this.title="New connection"},undo:function(){this.diagram.remove(this.connection,!1)},redo:function(){this.diagram._addConnection(this.connection,!1)}}),G=o.extend({init:function(t,e){this.shape=t,this.diagram=e,this.title="New shape"},undo:function(){this.diagram.deselect(),this.diagram.remove(this.shape,!1)},redo:function(){this.diagram._addShape(this.shape,!1)}}),j=o.extend({init:function(t,e,i){this.initial=t,this.finalPos=e,this.diagram=i,this.title="Pan Unit"},undo:function(){this.diagram.pan(this.initial)},redo:function(){this.diagram.pan(this.finalPos)}}),F=o.extend({init:function(t,e,i){this.shapes=e,this.undoRotates=i,this.title="Rotation",this.redoRotates=[],this.redoAngle=t._angle,this.adorner=t,this.center=t._innerBounds.center();for(var n=0;n<this.shapes.length;n++){var o=this.shapes[n];this.redoRotates.push(o.rotate().angle)}},undo:function(){var t,e;for(t=0;t<this.shapes.length;t++)(e=this.shapes[t]).rotate(this.undoRotates[t],this.center,!1),e.hasOwnProperty("layout")&&e.layout(e),e.updateModel();this.adorner&&(this.adorner._initialize(),this.adorner.refresh())},redo:function(){var t,e;for(t=0;t<this.shapes.length;t++)(e=this.shapes[t]).rotate(this.redoRotates[t],this.center,!1),e.hasOwnProperty("layout")&&e.layout(e),e.updateModel();this.adorner&&(this.adorner._initialize(),this.adorner.refresh())}}),q=o.extend({init:function(t,e,i){this.diagram=t,this.indices=i,this.items=e,this.title="Rotate Unit"},undo:function(){this.diagram._toIndex(this.items,this.indices)},redo:function(){this.diagram.toFront(this.items,!1)}}),Q=o.extend({init:function(t,e,i){this.diagram=t,this.indices=i,this.items=e,this.title="Rotate Unit"},undo:function(){this.diagram._toIndex(this.items,this.indices)},redo:function(){this.diagram.toBack(this.items,!1)}}),W=i.Observable.extend({init:function(t){i.Observable.fn.init.call(this,t),this.bind(this.events,t),this.stack=[],this.index=0,this.capacity=100},events:["undone","redone"],begin:function(){this.composite=new D},cancel:function(){this.composite=e},commit:function(t){this.composite.units.length>0&&this._restart(this.composite,t),this.composite=e},addCompositeItem:function(t){this.composite?this.composite.add(t):this.add(t)},add:function(t,e){this._restart(t,e)},pop:function(){this.index>0&&(this.stack.pop(),this.index--)},count:function(){return this.stack.length},undo:function(){this.index>0&&(this.index--,this.stack[this.index].undo(),this.trigger("undone"))},redo:function(){this.stack.length>0&&this.index<this.stack.length&&(this.stack[this.index].redo(),this.index++,this.trigger("redone"))},_restart:function(t,e){this.stack.splice(this.index,this.stack.length-this.index),this.stack.push(t),!1!==e?this.redo():this.index++,this.stack.length>this.capacity&&(this.stack.splice(0,this.stack.length-this.capacity),this.index=this.capacity)},clear:function(){this.stack=[],this.index=0}}),X=o.extend({init:function(t){this.toolService=t},start:function(){},move:function(){},end:function(){},tryActivate:function(){return!1},getCursor:function(){return y.arrow}}),J=X.extend({init:function(e){var n=this,o=i.support.mobileOS?.93:.9;X.fn.init.call(n,e);var s=n.toolService.diagram,r=s.canvas,a=s.scroller=n.scroller=t(s.scrollable).kendoMobileScroller({friction:o,velocityMultiplier:5,mousewheelScrolling:!1,zoom:!1,scroll:m(n._move,n)}).data("kendoMobileScroller");r.translate&&(n.movableCanvas=new p(r.element));var h=function(t,e,i){t.makeVirtual(),t.virtualSize(e||-2e4,i||2e4)};h(a.dimensions.x),h(a.dimensions.y),a.disable()},tryActivate:function(t,e){var i=this.toolService,n=i.diagram.options.pannable,o=e.ctrlKey;return v(n.key)&&(o=n.key&&"none"!=n.key?e[n.key+"Key"]:pt(e)&&!v(i.hoveredItem)),!1!==n&&o&&!v(i.hoveredAdorner)&&!v(i._hoveredConnector)},start:function(){this.scroller.enable()},move:function(){},_move:function(t){var e=this.toolService.diagram,i=e.canvas,n=new d(t.scrollLeft,t.scrollTop);i.translate?(e._storePan(n.times(-1)),this.movableCanvas.moveTo(n),i.translate(n.x,n.y)):n=n.plus(e._pan.times(-1)),e.trigger("pan",{pan:n})},end:function(){this.scroller.disable()},getCursor:function(){return y.move}}),Y=o.extend({init:function(t){this.toolService=t},tryActivate:function(){return!0},start:function(t,e){var i=this.toolService,n=i.diagram,o=i.hoveredItem;o&&(i.selectSingle(o,e),o.adorner&&(this.adorner=o.adorner,this.handle=this.adorner._hitTest(t))),this.handle||(this.handle=n._resizingAdorner._hitTest(t),this.handle&&(this.adorner=n._resizingAdorner)),this.adorner&&(this.adorner.isDragHandle(this.handle)&&n.trigger(M,{shapes:this.adorner.shapes,connections:[]})?(i.startPoint=t,i.end(t)):this.adorner.start(t))},move:function(t){this.adorner&&(this.adorner.move(this.handle,t),this.adorner.isDragHandle(this.handle)&&this.toolService.diagram.trigger(k,{shapes:this.adorner.shapes,connections:[]}))},end:function(){var t,i=this.toolService.diagram,n=this.adorner;n&&(n.isDragHandle(this.handle)&&i.trigger(z,{shapes:n.shapes,connections:[]})?n.cancel():(t=n.stop())&&i.undoRedoService.add(t,!1)),this.adorner=e,this.handle=e},getCursor:function(t){return this.toolService.hoveredItem?this.toolService.hoveredItem._getCursor(t):y.arrow}}),Z=o.extend({init:function(t){this.toolService=t},tryActivate:function(t,e){var i=this.toolService,n=i.diagram.options.selectable,o=n&&!1!==n.multiple;return o&&(o=n.key&&"none"!=n.key?e[n.key+"Key"]:pt(e)),o&&!v(i.hoveredItem)&&!v(i.hoveredAdorner)},start:function(t){var e=this.toolService.diagram;e.deselect(),e.selector.start(t)},move:function(t){this.toolService.diagram.selector.move(t)},end:function(t,e){var i=this.toolService.diagram,n=this.toolService.hoveredItem,o=i.selector.bounds();n&&n.isSelected||e.ctrlKey||i.deselect(),o.isEmpty()||i.selectArea(o),i.selector.end()},getCursor:function(){return y.arrow}}),$=o.extend({init:function(t){this.toolService=t,this.type="ConnectionTool"},tryActivate:function(){return this.toolService._hoveredConnector},start:function(t,e){var i=this.toolService,n=i.diagram,o=i._hoveredConnector,s=n._createConnection({},o._c,t);ft(s)&&!n.trigger(M,{shapes:[],connections:[s],connectionHandle:I})&&n._addConnection(s)?(i._connectionManipulation(s,o._c.shape,!0),i._removeHover(),i.selectSingle(i.activeConnection,e),"touchmove"==e.type&&(n._cachedTouchTarget=o.visual)):(s.source(null),i.end(t))},move:function(t){var e=this.toolService,i=e.activeConnection;return i.target(t),e.diagram.trigger(k,{shapes:[],connections:[i],connectionHandle:I}),!0},end:function(t){var e,i=this.toolService,o=i.diagram,s=i.activeConnection,r=i.hoveredItem,a=i._hoveredConnector,h=o._cachedTouchTarget;s&&(e=a&&a._c!=s.sourceConnector?a._c:r&&r instanceof n.Shape?r.getConnector(w)||r.getConnector(t):t,s.target(e),o.trigger(z,{shapes:[],connections:[s],connectionHandle:I})?(o.remove(s,!1),o.undoRedoService.pop()):(s.updateModel(),o._syncConnectionChanges()),i._connectionManipulation(),h&&(o._connectorsAdorner.visual.remove(h),o._cachedTouchTarget=null))},getCursor:function(){return y.arrow}}),tt=o.extend({init:function(t){this.toolService=t,this.type="ConnectionTool"},tryActivate:function(t,e){var i=this.toolService,n=i.diagram.options.selectable,o=i.hoveredItem,s=!1!==n&&o&&o.path&&!(o.isSelected&&e.ctrlKey);return s&&(this._c=o),s},start:function(t,e){var i=this.toolService,n=this._c;i.selectSingle(n,e);var o,s,r=n.adorner;r&&(o=r._hitTest(t),s=R[o]),ft(n)&&r&&!i.diagram.trigger(M,{shapes:[],connections:[n],connectionHandle:s})?(this.handle=o,this.handleName=s,r.start(t)):(i.startPoint=t,i.end(t))},move:function(t){var e=this._c.adorner;if(ft(this._c)&&e)return e.move(this.handle,t),this.toolService.diagram.trigger(k,{shapes:[],connections:[this._c],connectionHandle:this.handleName}),!0},end:function(t){var e=this._c,i=e.adorner,n=this.toolService.diagram;if(i&&ft(e)){var o=i.stop(t);n.trigger(z,{shapes:[],connections:[e],connectionHandle:this.handleName})?o.undo():(n.undoRedoService.add(o,!1),e.updateModel(),n._syncConnectionChanges())}},getCursor:function(){return y.move}});function et(t,e){return e.charCodeAt(0)==t||e.toUpperCase().charCodeAt(0)==t}var it=o.extend({init:function(t){this.diagram=t,this.tools=[new J(this),new tt(this),new $(this),new Z(this),new Y(this)],this.activeTool=e},start:function(t,e){return e=f({},e),this.activeTool&&this.activeTool.end(t,e),this._updateHoveredItem(t),this._activateTool(t,e),this.activeTool.start(t,e),this._updateCursor(t),this.diagram.focus(),this.diagram.canvas.surface.suspendTracking(),this.startPoint=t,!0},move:function(t,e){e=f({},e);var i=!0;return this.activeTool&&(i=this.activeTool.move(t,e)),i&&this._updateHoveredItem(t),this._updateCursor(t),!0},end:function(t,i){return i=f({},i),this.activeTool&&this.activeTool.end(t,i),this.diagram.canvas.surface.resumeTracking(),this.activeTool=e,this._updateCursor(t),!0},keyDown:function(t,e){var i=this.diagram;if(!(e=f({ctrlKey:!1,metaKey:!1,altKey:!1},e)).ctrlKey&&!e.metaKey||e.altKey){if(46===t||8===t){var n=this.diagram._triggerRemove(i.select());return n.length&&(this.diagram.remove(n,!0),this.diagram._syncChanges(),this.diagram._destroyToolBar()),!0}if(27===t)return this._discardNewConnection(),i.deselect(),i._destroyToolBar(),!0}else{if(et(t,"a"))return i.selectAll(),i._destroyToolBar(),!0;if(et(t,"z"))return i.undo(),i._destroyToolBar(),!0;if(et(t,"y"))return i.redo(),i._destroyToolBar(),!0;et(t,"c")?(i.copy(),i._destroyToolBar()):et(t,"x")?(i.cut(),i._destroyToolBar()):et(t,"v")?(i.paste(),i._destroyToolBar()):et(t,"l")?(i.layout(),i._destroyToolBar()):et(t,"d")&&(i._destroyToolBar(),i.copy(),i.paste())}},wheel:function(t,e){var n=this.diagram,o=e.delta,s=n.zoom(),r=n.options,a=r.zoomRate,h={point:t,meta:e,zoom:s};if(!n.trigger("zoomStart",h))return o<0?s+=a:s-=a,s=i.dataviz.round(Math.max(r.zoomMin,Math.min(r.zoomMax,s)),2),h.zoom=s,n.zoom(s,h),n.trigger("zoomEnd",h),!0},setTool:function(t,e){t.toolService=this,this.tools[e]=t},selectSingle:function(t,e){var i=this.diagram,n=i.options.selectable;if(n&&!t.isSelected&&!1!==t.options.selectable){var o=e.ctrlKey&&!1!==n.multiple;i.select(t,{addToSelection:o})}},_discardNewConnection:function(){this.newConnection&&(this.diagram.remove(this.newConnection),this.newConnection=e)},_activateTool:function(t,e){for(var i=0;i<this.tools.length;i++){var n=this.tools[i];if(n.tryActivate(t,e)){this.activeTool=n;break}}},_updateCursor:function(t){var e=this.diagram.element,i=this.activeTool?this.activeTool.getCursor(t):this.hoveredAdorner?this.hoveredAdorner._getCursor(t):this.hoveredItem?this.hoveredItem._getCursor(t):y.arrow;e.css({cursor:i})},_connectionManipulation:function(t,i,n){this.activeConnection=t,this.disabledShape=i,this.newConnection=n?this.activeConnection:e},_updateHoveredItem:function(t){var i=this._hitTest(t),n=this.diagram;i==this.hoveredItem||this.disabledShape&&i==this.disabledShape||(this.hoveredItem&&(n.trigger("mouseLeave",{item:this.hoveredItem}),this.hoveredItem._hover(!1)),i&&i.options.enable?(n.trigger("mouseEnter",{item:i}),this.hoveredItem=i,this.hoveredItem._hover(!0)):this.hoveredItem=e)},_removeHover:function(){this.hoveredItem&&(this.hoveredItem._hover(!1),this.hoveredItem=e)},_hitTest:function(t){var i,o,s,r=this.diagram;if(this._hoveredConnector&&(this._hoveredConnector._hover(!1),this._hoveredConnector=e),r._connectorsAdorner._visible&&(i=r._connectorsAdorner._hitTest(t)))return i;if(i=this.diagram._resizingAdorner._hitTest(t)){if(this.hoveredAdorner=r._resizingAdorner,0!==i.x||0!==i.y)return;i=e}else this.hoveredAdorner=e;if(!this.activeTool||"ConnectionTool"!==this.activeTool.type){var a=[];for(s=0;s<r._selectedItems.length;s++)(o=r._selectedItems[s])instanceof n.Connection&&a.push(o);i=this._hitTestItems(a,t)}return i||this._hitTestElements(t)},_hitTestElements:function(t){var e,i=this.diagram,n=this._hitTestItems(i.shapes,t),o=this._hitTestItems(i.connections,t);if((!this.activeTool||"ConnectionTool"!=this.activeTool.type)&&n&&o&&!function(t,e){for(var i,n,o,s=0;s<t.connectors.length;s++)if(n=(i=t.connectors[s]).position(),(o=new r(n.x,n.y)).inflate(x,x),o.contains(e))return i}(n,t)){var s=i.mainLayer;e=_(n.visual,s.children)>_(o.visual,s.children)?n:o}return e||n||o},_hitTestItems:function(t,e){var i,n;for(i=t.length-1;i>=0;i--)if(n=t[i]._hitTest(e))return n}}),nt=i.Class.extend({init:function(){}}),ot=nt.extend({init:function(t){nt.fn.init.call(this),this.connection=t},hitTest:function(t){return!!this.getBounds().inflate(x).contains(t)&&n.Geometry.distanceToPolyline(t,this.connection.allPoints())<x},getBounds:function(){for(var t=this.connection.allPoints(),e=t[0],i=t[t.length-1],n=Math.max(e.x,i.x),o=Math.min(e.x,i.x),s=Math.min(e.y,i.y),a=Math.max(e.y,i.y),h=1;h<t.length-1;++h)n=Math.max(n,t[h].x),o=Math.min(o,t[h].x),s=Math.min(s,t[h].y),a=Math.max(a,t[h].y);return new r(o,s,n-o,a-s)}}),st=ot.extend({init:function(t){ot.fn.init.call(this),this.connection=t},route:function(){}}),rt=ot.extend({SAME_SIDE_DISTANCE_RATIO:5,init:function(t){ot.fn.init.call(this),this.connection=t},routePoints:function(t,e,i,n){return i&&n?this._connectorPoints(t,e,i,n):this._floatingPoints(t,e,i)},route:function(){var t=this.connection._resolvedSourceConnector,e=this.connection._resolvedTargetConnector,i=this.connection.sourcePoint(),n=this.connection.targetPoint(),o=this.routePoints(i,n,t,e);this.connection.points(o)},_connectorSides:[{name:"Top",axis:"y",boundsPoint:"topLeft",secondarySign:1},{name:"Left",axis:"x",boundsPoint:"topLeft",secondarySign:1},{name:"Bottom",axis:"y",boundsPoint:"bottomRight",secondarySign:-1},{name:"Right",axis:"x",boundsPoint:"bottomRight",secondarySign:-1}],_connectorSide:function(t,e){for(var i,n,o,s,r=t.position(),a=t.shape.bounds(A),h={topLeft:a.topLeft(),bottomRight:a.bottomRight()},c=this._connectorSides,d=g.MAX_NUM,u=0;u<c.length;u++)o=(s=c[u]).axis,(i=Math.round(Math.abs(r[o]-h[s.boundsPoint][o])))<d?(d=i,n=s):i===d&&(r[o]-e[o])*s.secondarySign>(r[n.axis]-e[n.axis])*n.secondarySign&&(n=s);return n.name},_sameSideDistance:function(t){var e=t.shape.bounds(A);return Math.min(e.width,e.height)/this.SAME_SIDE_DISTANCE_RATIO},_connectorPoints:function(t,e,i,n){var o,s,r=this._connectorSide(i,e),a=this._connectorSide(n,t),h=e.x-t.x,c=e.y-t.y,u=this._sameSideDistance(i),l=[];return r===S||r==C?a==S||a==C?r==a?(s=r==S?Math.min(t.y,e.y)-u:Math.max(t.y,e.y)+u,l=[new d(t.x,s),new d(e.x,s)]):l=[new d(t.x,t.y+c/2),new d(e.x,t.y+c/2)]:l=[new d(t.x,e.y)]:a==T||a==b?r==a?(o=r==T?Math.min(t.x,e.x)-u:Math.max(t.x,e.x)+u,l=[new d(o,t.y),new d(o,e.y)]):l=[new d(t.x+h/2,t.y),new d(t.x+h/2,t.y+c)]:l=[new d(e.x,t.y)],l},_floatingPoints:function(t,e,i){for(var n,o,s=i?this._connectorSide(i,e):null,r=this._startHorizontal(t,e,s),a=[t,t,e,e],h=e.x-t.x,c=e.y-t.y,u=a.length,l=1;l<u-1;++l)r?l%2!=0?(n=h/(u/2),o=0):(n=0,o=c/((u-1)/2)):l%2!=0?(n=0,o=c/(u/2)):(n=h/((u-1)/2),o=0),a[l]=new d(a[l-1].x+n,a[l-1].y+o);return l--,a[u-2]=r&&l%2!=0||!r&&l%2==0?new d(a[u-1].x,a[u-2].y):new d(a[u-2].x,a[u-1].y),[a[1],a[2]]},_startHorizontal:function(t,e,i){return null!==i&&(i===b||i===T)||Math.abs(t.x-e.x)>Math.abs(t.y-e.y)}}),at=o.extend({init:function(t,e){var i=this;i.diagram=t,i.options=f({},i.options,e),i.visual=new s,i.diagram._adorners.push(i)},refresh:function(){}}),ht=at.extend({init:function(t,e){var i,n=this;n.connection=t,i=n.connection.diagram,n._ts=i.toolService,at.fn.init.call(n,i,e);var o=n.connection.sourcePoint(),s=n.connection.targetPoint();n.spVisual=new u(f(n.options.handles,{center:o})),n.epVisual=new u(f(n.options.handles,{center:s})),n.visual.append(n.spVisual),n.visual.append(n.epVisual)},options:{handles:{}},_getCursor:function(){return y.move},start:function(t){switch(this.handle=this._hitTest(t),this.startPoint=t,this._initialSource=this.connection.source(),this._initialTarget=this.connection.target(),this.handle){case-1:this.connection.targetConnector&&this._ts._connectionManipulation(this.connection,this.connection.targetConnector.shape);break;case 1:this.connection.sourceConnector&&this._ts._connectionManipulation(this.connection,this.connection.sourceConnector.shape)}},move:function(t,e){switch(t){case-1:this.connection.source(e);break;case 1:this.connection.target(e);break;default:var i=e.minus(this.startPoint);this.startPoint=e,this.connection.sourceConnector||this.connection.source(this.connection.sourcePoint().plus(i)),this.connection.targetConnector||this.connection.target(this.connection.targetPoint().plus(i))}return this.refresh(),!0},stop:function(t){var i,o=this.diagram.toolService,s=o.hoveredItem;return i=o._hoveredConnector?o._hoveredConnector._c:s&&s instanceof n.Shape?s.getConnector(w)||s.getConnector(t):t,-1===this.handle?this.connection.source(i):1===this.handle&&this.connection.target(i),this.handle=e,this._ts._connectionManipulation(),new U(this.connection,this._initialSource,this._initialTarget)},_hitTest:function(t){var e=this.connection.sourcePoint(),i=this.connection.targetPoint(),n=this.options.handles.width/2+x,o=this.options.handles.height/2+x,s=e.distanceTo(t),a=i.distanceTo(t),h=new r(e.x,e.y).inflate(n,o).contains(t),c=new r(i.x,i.y).inflate(n,o).contains(t),d=0;return h&&(!c||s<a)?d=-1:c&&(!h||a<s)&&(d=1),d},refresh:function(){this.spVisual.redraw({center:this.diagram.modelToLayer(this.connection.sourcePoint())}),this.epVisual.redraw({center:this.diagram.modelToLayer(this.connection.targetPoint())})}}),ct=at.extend({init:function(t,e){var i=this;at.fn.init.call(i,t,e),i._refreshHandler=function(t){t.item==i.shape&&i.refresh()}},show:function(t){var e,i,n,o=this;for(o._visible=!0,o.shape=t,o.diagram.bind(B,o._refreshHandler),e=t.connectors.length,o.connectors=[],o._clearVisual(),i=0;i<e;i++)n=new lt(t.connectors[i]),o.connectors.push(n),o.visual.append(n.visual);o.visual.visible(!0),o.refresh()},_clearVisual:function(){var t=this;t.diagram._cachedTouchTarget?t._keepCachedTouchTarget():t.visual.clear()},_keepCachedTouchTarget:function(){for(var t=this,e=t.visual.children,i=e.length,n=_(t.diagram._cachedTouchTarget,e),o=i-1;o>=0;o--)o!=n&&t.visual.remove(e[o])},destroy:function(){var t=this;t.diagram.unbind(B,t._refreshHandler),t.shape=e,t._visible=e,t.visual.visible(!1)},_hitTest:function(t){var e,i;for(i=0;i<this.connectors.length;i++)if((e=this.connectors[i])._hitTest(t)){e._hover(!0),this.diagram.toolService._hoveredConnector=e;break}},refresh:function(){if(this.shape){var e=this.shape.bounds();e=this.diagram.modelToLayer(e),this.visual.position(e.topLeft()),t.each(this.connectors,(function(){this.refresh()}))}}});var dt=at.extend({init:function(t,e){var i=this;at.fn.init.call(i,t,e),i._manipulating=!1,i.map=[],i.shapes=[],i._initSelection(),i._createHandles(),i.redraw(),i.diagram.bind("select",(function(t){i._initialize(t.selected)})),i._refreshHandler=function(){i._internalChange||(i.refreshBounds(),i.refresh())},i._rotatedHandler=function(){1==i.shapes.length&&(i._angle=i.shapes[0].rotate().angle),i._refreshHandler()},i.diagram.bind(B,i._refreshHandler).bind("itemRotate",i._rotatedHandler),i.refreshBounds(),i.refresh()},options:{handles:{fill:{color:"#fff"},stroke:{color:"#282828"},height:7,width:7,hover:{fill:{color:"#282828"},stroke:{color:"#282828"}}},selectable:{stroke:{color:"#778899",width:1,dashType:"dash"},fill:{color:P}},offset:10},_initSelection:function(){var t=this,e=t.diagram.options.selectable,i=f({},t.options.selectable,e);t.rect=new a(i),t.visual.append(t.rect)},_resizable:function(){return this.options.editable&&!1!==this.options.editable.resize},_handleOptions:function(){return(this.options.editable.resize||{}).handles||this.options.handles},_createHandles:function(){var t,e,i,n;if(this._resizable())for(t=this._handleOptions(),n=-1;n<=1;n++)for(i=-1;i<=1;i++)0===n&&0===i||((e=new a(t)).drawingElement._hover=m(this._hover,this),this.map.push({x:n,y:i,visual:e}),this.visual.append(e))},bounds:function(t){if(!t)return this._bounds;this._innerBounds=t.clone(),this._bounds=this.diagram.modelToLayer(t).inflate(this.options.offset,this.options.offset)},_hitTest:function(t){var e,i,n,o,s=this.diagram.modelToLayer(t),r=this.map.length;if(this._angle&&(s=s.clone().rotate(this._bounds.center(),this._angle)),this._resizable())for(e=0;e<r;e++)if(o=this.map[e],i=new d(o.x,o.y),(n=this._getHandleBounds(i)).offset(this._bounds.x,this._bounds.y),n.contains(s))return i;if(this._bounds.contains(s))return new d(0,0)},_getHandleBounds:function(t){if(this._resizable()){var e=this._handleOptions(),i=e.width,n=e.height,o=new r(0,0,i,n);return t.x<0?o.x=-i/2:0===t.x?o.x=Math.floor(this._bounds.width/2)-i/2:t.x>0&&(o.x=this._bounds.width+1-i/2),t.y<0?o.y=-n/2:0===t.y?o.y=Math.floor(this._bounds.height/2)-n/2:t.y>0&&(o.y=this._bounds.height+1-n/2),o}},_getCursor:function(t){var e=this._hitTest(t);if(e&&e.x>=-1&&e.x<=1&&e.y>=-1&&e.y<=1&&this._resizable()){var i=this._angle;if(i&&(i=360-i,e.rotate(new d(0,0),i),e=new d(Math.round(e.x),Math.round(e.y))),-1==e.x&&-1==e.y)return"nw-resize";if(1==e.x&&1==e.y)return"se-resize";if(-1==e.x&&1==e.y)return"sw-resize";if(1==e.x&&-1==e.y)return"ne-resize";if(0===e.x&&-1==e.y)return"n-resize";if(0===e.x&&1==e.y)return"s-resize";if(1==e.x&&0===e.y)return"e-resize";if(-1==e.x&&0===e.y)return"w-resize"}return this._manipulating?y.move:y.select},_initialize:function(){var t,e,i=this,o=i.diagram.select();for(i.shapes=[],t=0;t<o.length;t++)(e=o[t])instanceof n.Shape&&(i.shapes.push(e),e._rotationOffset=new d);i._angle=1==i.shapes.length?i.shapes[0].rotate().angle:0,i._startAngle=i._angle,i._rotates(),i._positions(),i.refreshBounds(),i.refresh(),i.redraw()},_rotates:function(){var t,e,i=this;for(i.initialRotates=[],t=0;t<i.shapes.length;t++)e=i.shapes[t],i.initialRotates.push(e.rotate().angle)},_positions:function(){var t,e,i=this;for(i.initialStates=[],t=0;t<i.shapes.length;t++)e=i.shapes[t],i.initialStates.push(e.bounds())},_hover:function(t,e){if(this._resizable()){var i=this._handleOptions(),n=i.hover,o=i.stroke,s=i.fill;t&&h.isDefined(n.stroke)&&(o=f({},o,n.stroke)),t&&h.isDefined(n.fill)&&(s=n.fill),e.stroke(o.color,o.width,o.opacity),e.fill(s.color,s.opacity)}},start:function(t){this._sp=t,this._cp=t,this._lp=t,this._manipulating=!0,this._internalChange=!0,this.shapeStates=[];for(var e=0;e<this.shapes.length;e++){var i=this.shapes[e];this.shapeStates.push(i.bounds())}},redraw:function(){var t,e=this._resizable();for(t=0;t<this.map.length;t++)this.map[t].visual.visible(e)},angle:function(t){return v(t)&&(this._angle=t),this._angle},rotate:function(){var t=this._innerBounds.center(),e=this.angle();this._internalChange=!0;for(var i=0;i<this.shapes.length;i++){var n=this.shapes[i];e=(e+this.initialRotates[i]-this._startAngle)%360,n.rotate(e,t)}this.refresh()},move:function(t,e){var i,n,o,s,a,c,u,l,f,p,g,v=new d,_=new d,m=0;if(-2===t.y&&-1===t.x){for(s=this._innerBounds.center(),this._angle=this._truncateAngle(h.findAngle(s,e)),c=0;c<this.shapes.length;c++)a=this.shapes[c],u=(this._angle+this.initialRotates[c]-this._startAngle)%360,a.rotate(u,s),a.hasOwnProperty("layout")&&a.layout(a),this._rotating=!0;this.refresh()}else{if(this.shouldSnap()){var y=this._truncateDistance(e.minus(this._lp));if(0===y.x&&0===y.y)return void(this._cp=e);i=y,this._lp=new d(this._lp.x+y.x,this._lp.y+y.y)}else i=e.minus(this._cp);for(this.isDragHandle(t)?(_=v=i,n=!0):(this._angle&&i.rotate(new d(0,0),this._angle),-1==t.x?v.x=i.x:1==t.x&&(_.x=i.x),-1==t.y?v.y=i.y:1==t.y&&(_.y=i.y)),n||(f=function(t,e){var i;return-1==t.x&&-1==t.y?i=e.bottomRight():1==t.x&&1==t.y?i=e.topLeft():-1==t.x&&1==t.y?i=e.topRight():1==t.x&&-1==t.y?i=e.bottomLeft():0===t.x&&-1==t.y?i=e.bottom():0===t.x&&1==t.y?i=e.top():1==t.x&&0===t.y?i=e.left():-1==t.x&&0===t.y&&(i=e.right()),i}(t,this._innerBounds),p=(this._innerBounds.width+i.x*t.x)/this._innerBounds.width,g=(this._innerBounds.height+i.y*t.y)/this._innerBounds.height),c=0;c<this.shapes.length;c++){if(o=(a=this.shapes[c]).bounds(),n){if(!ft(a))continue;l=this._displaceBounds(o,v,_,n)}else{(l=o.clone()).scale(p,g,f,this._innerBounds.center(),a.rotate().angle);var x=l.center();x.rotate(o.center(),-this._angle),l=new r(x.x-l.width/2,x.y-l.height/2,l.width,l.height)}if(l.width>=a.options.minWidth&&l.height>=a.options.minHeight){var w=o;a.bounds(l),a.hasOwnProperty("layout")&&a.layout(a,w,l),w.width===l.width&&w.height===l.height||a.rotate(a.rotate().angle),m+=1}}m&&(m==c?(l=this._displaceBounds(this._innerBounds,v,_,n),this.bounds(l)):this.refreshBounds(),this.refresh()),this._positions()}this._cp=e},isDragHandle:function(t){return 0===t.x&&0===t.y},cancel:function(){for(var t=this.shapes,i=this.shapeStates,n=0;n<t.length;n++)t[n].bounds(i[n]);this.refreshBounds(),this.refresh(),this._manipulating=e,this._internalChange=e,this._rotating=e},_truncatePositionToGuides:function(t){return this.diagram.ruler?this.diagram.ruler.truncatePositionToGuides(t):t},_truncateSizeToGuides:function(t){return this.diagram.ruler?this.diagram.ruler.truncateSizeToGuides(t):t},_truncateAngle:function(t){var e=this.snapOptions(),i=Math.max(e.angle||10,5);return e?Math.floor(t%360/i)*i:t%360},_truncateDistance:function(t){if(t instanceof n.Point)return new n.Point(this._truncateDistance(t.x),this._truncateDistance(t.y));var e=this.snapOptions()||{},i=Math.max(e.size||10,5);return e?Math.floor(t/i)*i:t},snapOptions:function(){return((this.diagram.options.editable||{}).drag||{}).snap||{}},shouldSnap:function(){var t=this.diagram.options.editable,e=(t||{}).drag,i=(e||{}).snap;return!1!==t&&!1!==e&&!1!==i},_displaceBounds:function(t,e,i,n){var o,s=t.topLeft().plus(e),a=t.bottomRight().plus(i),h=r.fromPoints(s,a);return n||((o=h.center()).rotate(t.center(),-this._angle),h=new r(o.x-h.width/2,o.y-h.height/2,h.width,h.height)),h},stop:function(){var t,i,n;if(this._cp!=this._sp)if(this._rotating)t=new F(this,this.shapes,this.initialRotates),this._rotating=!1;else if(this._diffStates()){if(this.diagram.ruler)for(i=0;i<this.shapes.length;i++){var o=(n=this.shapes[i]).bounds();o=this._truncateSizeToGuides(this._truncatePositionToGuides(o)),n.bounds(o),this.refreshBounds(),this.refresh()}for(i=0;i<this.shapes.length;i++)(n=this.shapes[i]).updateModel();t=new V(this.shapes,this.shapeStates,this),this.diagram._syncShapeChanges()}return this._manipulating=e,this._internalChange=e,this._rotating=e,t},_diffStates:function(){for(var t=this.shapes,e=this.shapeStates,i=0;i<t.length;i++)if(!t[i].bounds().equals(e[i]))return!0;return!1},refreshBounds:function(){var t=1==this.shapes.length?this.shapes[0].bounds().clone():this.diagram.boundingBox(this.shapes,!0);this.bounds(t)},refresh:function(){var e,i,n=this;if(this.shapes.length>0){i=this.bounds(),this.visual.visible(!0),this.visual.position(i.topLeft()),t.each(this.map,(function(){e=n._getHandleBounds(new d(this.x,this.y)),this.visual.position(e.topLeft())})),this.visual.position(i.topLeft());var o=new d(i.width/2,i.height/2);if(this.visual.rotate(this._angle,o),this.rect.redraw({width:i.width,height:i.height}),this.rotationThumb){var s=this.options.editable.rotate.thumb;this._rotationThumbBounds=new r(i.center().x,i.y+s.y,0,0).inflate(s.width),this.rotationThumb.redraw({x:i.width/2-s.width/2})}}else this.visual.visible(!1)}}),ut=o.extend({init:function(t){var e=t.options.selectable;this.options=f({},this.options,e),this.visual=new a(this.options),this.diagram=t},options:{stroke:{color:"#778899",width:1,dashType:"dash"},fill:{color:P}},start:function(t){this._sp=this._ep=t,this.refresh(),this.diagram._adorn(this,!0)},end:function(){this._sp=this._ep=e,this.diagram._adorn(this,!1)},bounds:function(t){return t&&(this._bounds=t),this._bounds},move:function(t){this._ep=t,this.refresh()},refresh:function(){if(this._sp){var t=r.fromPoints(this.diagram.modelToLayer(this._sp),this.diagram.modelToLayer(this._ep));this.bounds(r.fromPoints(this._sp,this._ep)),this.visual.position(t.topLeft()),this.visual.redraw({height:t.height+1,width:t.width+1})}}}),lt=o.extend({init:function(t){this.options=f({},t.options),this._c=t,this.visual=new u(this.options),this.refresh()},_hover:function(t){var e=this.options,i=e.hover,n=e.stroke,o=e.fill;t&&h.isDefined(i.stroke)&&(n=f({},n,i.stroke)),t&&h.isDefined(i.fill)&&(o=i.fill),this.visual.redraw({stroke:n,fill:o})},refresh:function(){var t=this._c.shape.diagram.modelToView(this._c.position()),e=t.minus(this._c.shape.bounds("transformed").topLeft()),i=new r(t.x,t.y,0,0);i.inflate(this.options.width/2,this.options.height/2),this._visualBounds=i,this.visual.redraw({center:new d(e.x,e.y)})},_hitTest:function(t){var e=this._c.shape.diagram.modelToView(t);return this._visualBounds.contains(e)}});function ft(t){var e=t.options.editable;return e&&!1!==e.drag}function pt(t){return!1===t.ctrlKey&&!1===t.altKey&&!1===t.shiftKey}f(n,{CompositeUnit:D,TransformUnit:V,PanUndoUnit:j,AddShapeUnit:G,AddConnectionUnit:N,DeleteShapeUnit:K,DeleteConnectionUnit:O,ConnectionEditAdorner:ht,ConnectionTool:$,ConnectorVisual:lt,UndoRedoService:W,ResizingAdorner:dt,Selector:ut,ToolService:it,ConnectorsAdorner:ct,LayoutUndoUnit:L,ConnectionEditUnit:E,ToFrontUnit:q,ToBackUnit:Q,ConnectionRouterBase:nt,PolylineRouter:st,CascadingRouter:rt,SelectionTool:Z,ScrollerTool:J,PointerTool:Y,ConnectionEditTool:tt,RotateUnit:F})}(window.kendo.jQuery)})?n.apply(e,o):n)||(t.exports=s)}})}}]);