(window.webpackJsonp=window.webpackJsonp||[]).push([[63],{"./node_modules/@progress/kendo-ui/js/kendo.groupable.js":
/*!***************************************************************!*\
  !*** ./node_modules/@progress/kendo-ui/js/kendo.groupable.js ***!
  \***************************************************************/
/*! no static exports found */function(module,exports,__webpack_require__){eval('module.exports =\n/******/ (function(modules) { // webpackBootstrap\n/******/ \t// The module cache\n/******/ \tvar installedModules = {};\n\n/******/ \t// The require function\n/******/ \tfunction __webpack_require__(moduleId) {\n\n/******/ \t\t// Check if module is in cache\n/******/ \t\tif(installedModules[moduleId])\n/******/ \t\t\treturn installedModules[moduleId].exports;\n\n/******/ \t\t// Create a new module (and put it into the cache)\n/******/ \t\tvar module = installedModules[moduleId] = {\n/******/ \t\t\texports: {},\n/******/ \t\t\tid: moduleId,\n/******/ \t\t\tloaded: false\n/******/ \t\t};\n\n/******/ \t\t// Execute the module function\n/******/ \t\tmodules[moduleId].call(module.exports, module, module.exports, __webpack_require__);\n\n/******/ \t\t// Flag the module as loaded\n/******/ \t\tmodule.loaded = true;\n\n/******/ \t\t// Return the exports of the module\n/******/ \t\treturn module.exports;\n/******/ \t}\n\n\n/******/ \t// expose the modules object (__webpack_modules__)\n/******/ \t__webpack_require__.m = modules;\n\n/******/ \t// expose the module cache\n/******/ \t__webpack_require__.c = installedModules;\n\n/******/ \t// __webpack_public_path__\n/******/ \t__webpack_require__.p = "";\n\n/******/ \t// Load entry module and return exports\n/******/ \treturn __webpack_require__(0);\n/******/ })\n/************************************************************************/\n/******/ ({\n\n/***/ 0:\n/***/ (function(module, exports, __webpack_require__) {\n\n\tmodule.exports = __webpack_require__(1240);\n\n\n/***/ }),\n\n/***/ 3:\n/***/ (function(module, exports) {\n\n\tmodule.exports = function() { throw new Error("define cannot be used indirect"); };\n\n\n/***/ }),\n\n/***/ 1018:\n/***/ (function(module, exports) {\n\n\tmodule.exports = __webpack_require__(/*! ./kendo.core */ "./node_modules/@progress/kendo-ui/js/kendo.core.js");\n\n/***/ }),\n\n/***/ 1077:\n/***/ (function(module, exports) {\n\n\tmodule.exports = __webpack_require__(/*! ./kendo.draganddrop */ "./node_modules/@progress/kendo-ui/js/kendo.draganddrop.js");\n\n/***/ }),\n\n/***/ 1240:\n/***/ (function(module, exports, __webpack_require__) {\n\n\tvar __WEBPACK_AMD_DEFINE_FACTORY__, __WEBPACK_AMD_DEFINE_ARRAY__, __WEBPACK_AMD_DEFINE_RESULT__;(function(f, define){\n\t    !(__WEBPACK_AMD_DEFINE_ARRAY__ = [ __webpack_require__(1018), __webpack_require__(1077) ], __WEBPACK_AMD_DEFINE_FACTORY__ = (f), __WEBPACK_AMD_DEFINE_RESULT__ = (typeof __WEBPACK_AMD_DEFINE_FACTORY__ === \'function\' ? (__WEBPACK_AMD_DEFINE_FACTORY__.apply(exports, __WEBPACK_AMD_DEFINE_ARRAY__)) : __WEBPACK_AMD_DEFINE_FACTORY__), __WEBPACK_AMD_DEFINE_RESULT__ !== undefined && (module.exports = __WEBPACK_AMD_DEFINE_RESULT__));\n\t})(function(){\n\n\tvar __meta__ = { // jshint ignore:line\n\t    id: "groupable",\n\t    name: "Groupable",\n\t    category: "framework",\n\t    depends: [ "core", "draganddrop" ],\n\t    advanced: true\n\t};\n\n\t(function ($, undefined) {\n\t    var kendo = window.kendo,\n\t        Widget = kendo.ui.Widget,\n\t        outerWidth = kendo._outerWidth,\n\t        kendoAttr = kendo.attr,\n\t        extend = $.extend,\n\t        each = $.each,\n\t        proxy = $.proxy,\n\t        isRtl = false,\n\n\t        DIR = "dir",\n\t        FIELD = "field",\n\t        TITLE = "title",\n\t        ASCENDING = "asc",\n\t        DESCENDING = "desc",\n\t        GROUP_SORT = "group-sort",\n\t        NS = ".kendoGroupable",\n\t        CHANGE = "change",\n\t        indicatorTmpl = kendo.template(\'<div class="k-group-indicator" data-#=data.ns#field="${data.field}" data-#=data.ns#title="${data.title || ""}" data-#=data.ns#dir="${data.dir || "asc"}">\' +\n\t                \'<a href="\\\\#" class="k-link">\' +\n\t                    \'<span class="k-icon k-i-sort-${(data.dir || "asc") == "asc" ? "asc-sm" : "desc-sm"}" title="(sorted ${(data.dir || "asc") == "asc" ? "ascending": "descending"})"></span>\' +\n\t                    \'${data.title ? data.title: data.field}\' +\n\t                \'</a>\' +\n\t                \'<a class="k-button k-button-icon k-flat">\' +\n\t                    \'<span class="k-icon k-i-close"></span>\' +\n\t                \'</a>\' +\n\t             \'</div>\',  { useWithBlock:false }),\n\t        hint = function(target) {\n\t            var title = target.attr(kendo.attr("title"));\n\t            if (title) {\n\t                title = kendo.htmlEncode(title);\n\t            }\n\n\t            return $(\'<div class="k-header k-group-clue k-drag-clue" />\')\n\t                .html(title || target.attr(kendo.attr("field")))\n\t                .prepend(\'<span class="k-icon k-drag-status k-i-cancel"></span>\');\n\t        },\n\t        dropCue = $(\'<div class="k-grouping-dropclue"/>\');\n\n\t    var Groupable = Widget.extend({\n\t        init: function(element, options) {\n\t            var that = this,\n\t                group = kendo.guid(),\n\t                intializePositions = proxy(that._intializePositions, that),\n\t                draggable,\n\t                horizontalCuePosition,\n\t                dropCuePositions = that._dropCuePositions = [];\n\n\t            Widget.fn.init.call(that, element, options);\n\n\t            isRtl = kendo.support.isRtl(element);\n\t            horizontalCuePosition = isRtl ? "right" : "left";\n\n\t            that.draggable = draggable = that.options.draggable || new kendo.ui.Draggable(that.element, {\n\t                filter: that.options.draggableElements,\n\t                hint: hint,\n\t                group: group\n\t            });\n\n\t            that.groupContainer = $(that.options.groupContainer, that.element)\n\t                .kendoDropTarget({\n\t                    group: draggable.options.group,\n\t                    dragenter: function(e) {\n\t                        if (that._canDrag(e.draggable.currentTarget)) {\n\t                            e.draggable.hint.find(".k-drag-status").removeClass("k-i-cancel").addClass("k-i-plus");\n\t                            dropCue.css(horizontalCuePosition, 0).appendTo(that.groupContainer);\n\t                        }\n\t                    },\n\t                    dragleave: function(e) {\n\t                        e.draggable.hint.find(".k-drag-status").removeClass("k-i-plus").addClass("k-i-cancel");\n\t                        dropCue.remove();\n\t                    },\n\t                    drop: function(e) {\n\t                        var targetElement = e.draggable.currentTarget,\n\t                            field = targetElement.attr(kendo.attr("field")),\n\t                            title = targetElement.attr(kendo.attr("title")),\n\t                            sourceIndicator = that.indicator(field),\n\t                            dropCuePositions = that._dropCuePositions,\n\t                            lastCuePosition = dropCuePositions[dropCuePositions.length - 1],\n\t                            position;\n\t                        var sortOptions = extend({}, that.options.sort, targetElement.data(GROUP_SORT));\n\t                        var dir = sortOptions.dir;\n\n\t                        if (!targetElement.hasClass("k-group-indicator") && !that._canDrag(targetElement)) {\n\t                            return;\n\t                        }\n\t                        if(lastCuePosition) {\n\t                            position = that._dropCuePosition(kendo.getOffset(dropCue).left + parseInt(lastCuePosition.element.css("marginLeft"), 10) * (isRtl ? -1 : 1) + parseInt(lastCuePosition.element.css("marginRight"), 10));\n\t                            if(position && that._canDrop($(sourceIndicator), position.element, position.left)) {\n\t                                if(position.before) {\n\t                                    position.element.before(sourceIndicator || that.buildIndicator(field, title, dir));\n\t                                } else {\n\t                                    position.element.after(sourceIndicator || that.buildIndicator(field, title, dir));\n\t                                }\n\n\t                                that._setIndicatorSortOptions(field, sortOptions);\n\t                                that._change();\n\t                            }\n\t                        } else {\n\t                            that.groupContainer.empty();\n\t                            that.groupContainer.append(that.buildIndicator(field, title, dir));\n\t                            that._setIndicatorSortOptions(field, sortOptions);\n\t                            that._change();\n\t                        }\n\t                    }\n\t                })\n\t                .kendoDraggable({\n\t                    filter: "div.k-group-indicator",\n\t                    hint: hint,\n\t                    group: draggable.options.group,\n\t                    dragcancel: proxy(that._dragCancel, that),\n\t                    dragstart: function(e) {\n\t                        var element = e.currentTarget,\n\t                            marginLeft = parseInt(element.css("marginLeft"), 10),\n\t                            elementPosition = element.position(),\n\t                            left = isRtl ? elementPosition.left - marginLeft : elementPosition.left + outerWidth(element);\n\n\t                        intializePositions();\n\t                        dropCue.css("left", left).appendTo(that.groupContainer);\n\t                        this.hint.find(".k-drag-status").removeClass("k-i-cancel").addClass("k-i-plus");\n\t                    },\n\t                    dragend: function() {\n\t                        that._dragEnd(this);\n\t                    },\n\t                    drag: proxy(that._drag, that)\n\t                })\n\t                .on("click" + NS, ".k-button", function(e) {\n\t                    e.preventDefault();\n\t                    that._removeIndicator($(this).parent());\n\t                })\n\t                .on("click" + NS,".k-link", function(e) {\n\t                    var indicator = $(this).parent();\n\t                    var newDir = indicator.attr(kendoAttr(DIR)) === ASCENDING ? DESCENDING : ASCENDING;\n\n\t                    indicator.attr(kendoAttr(DIR), newDir);\n\t                    that._change();\n\t                    e.preventDefault();\n\t                });\n\n\t            draggable.bind([ "dragend", "dragcancel", "dragstart", "drag" ],\n\t            {\n\t                dragend: function() {\n\t                    that._dragEnd(this);\n\t                },\n\t                dragcancel: proxy(that._dragCancel, that),\n\t                dragstart: function(e) {\n\t                    var element, marginRight, left;\n\n\t                    if (!that.options.allowDrag && !that._canDrag(e.currentTarget)) {\n\t                        e.preventDefault();\n\t                        return;\n\t                    }\n\n\t                    intializePositions();\n\t                    if(dropCuePositions.length) {\n\t                        element = dropCuePositions[dropCuePositions.length - 1].element;\n\t                        marginRight = parseInt(element.css("marginRight"), 10);\n\t                        left = element.position().left + outerWidth(element) + marginRight;\n\t                    } else {\n\t                        left = 0;\n\t                    }\n\t                },\n\t                drag: proxy(that._drag, that)\n\t            });\n\n\t            that.dataSource = that.options.dataSource;\n\n\t            if (that.dataSource && that._refreshHandler) {\n\t                that.dataSource.unbind(CHANGE, that._refreshHandler);\n\t            } else {\n\t                that._refreshHandler = proxy(that.refresh, that);\n\t            }\n\n\t            if(that.dataSource) {\n\t                that.dataSource.bind("change", that._refreshHandler);\n\t                that.refresh();\n\t            }\n\t        },\n\n\t        refresh: function() {\n\t            var that = this,\n\t                dataSource = that.dataSource;\n\t            var groups = dataSource.group() || [];\n\t            var fieldAttr = kendoAttr(FIELD);\n\t            var titleAttr = kendoAttr(TITLE);\n\t            var indicatorHtml;\n\n\t            if (that.groupContainer) {\n\t                that.groupContainer.empty();\n\n\t                each(groups, function(index, group) {\n\t                    var field = group.field;\n\t                    var dir =group.dir;\n\t                    var element = that.element\n\t                        .find(that.options.filter)\n\t                        .filter(function() {\n\t                            return $(this).attr(fieldAttr) === field;\n\t                        });\n\n\t                    indicatorHtml = that.buildIndicator(field, element.attr(titleAttr), dir);\n\t                    that.groupContainer.append(indicatorHtml);\n\t                    that._setIndicatorSortOptions(field, extend({}, that.options.sort, { dir: dir, compare: group.compare }));\n\t                });\n\t            }\n\n\t            that._invalidateGroupContainer();\n\t        },\n\n\t        destroy: function() {\n\t            var that = this;\n\n\t            Widget.fn.destroy.call(that);\n\n\t            that.groupContainer.off(NS);\n\n\t            if (that.groupContainer.data("kendoDropTarget")) {\n\t                that.groupContainer.data("kendoDropTarget").destroy();\n\t            }\n\n\t            if (that.groupContainer.data("kendoDraggable")) {\n\t                that.groupContainer.data("kendoDraggable").destroy();\n\t            }\n\n\t            if (!that.options.draggable) {\n\t                that.draggable.destroy();\n\t            }\n\n\t            if (that.dataSource && that._refreshHandler) {\n\t                that.dataSource.unbind("change", that._refreshHandler);\n\t                that._refreshHandler = null;\n\t            }\n\n\t            that.groupContainer = that.element = that.draggable = null;\n\t        },\n\n\t        events: ["change"],\n\n\t        options: {\n\t            name: "Groupable",\n\t            filter: "th",\n\t            draggableElements: "th",\n\t            messages: {\n\t                empty: "Drag a column header and drop it here to group by that column"\n\t            },\n\t            sort: {\n\t                dir: ASCENDING,\n\t                compare: null\n\t            }\n\t        },\n\n\t        indicator: function(field) {\n\t            var indicators = $(".k-group-indicator", this.groupContainer);\n\t            return $.grep(indicators, function (item)\n\t                {\n\t                    return $(item).attr(kendo.attr("field")) === field;\n\t                })[0];\n\t        },\n\n\t        buildIndicator: function(field, title, dir) {\n\t            var that = this;\n\t            var indicator = indicatorTmpl({\n\t                ns: kendo.ns,\n\t                field: field.replace(/"/g, "\'"),\n\t                title: title,\n\t                dir: dir || (that.options.sort || {}).dir || ASCENDING\n\t            });\n\n\t            return indicator;\n\t        },\n\n\t        _setIndicatorSortOptions: function(field, options) {\n\t            var indicator = $(this.indicator(field));\n\t            indicator.data(GROUP_SORT, options);\n\t        },\n\n\t        aggregates: function() {\n\t            var that = this;\n\t            var names;\n\t            var idx;\n\t            var length;\n\n\t            return that.element.find(that.options.filter).map(function() {\n\t                var cell = $(this),\n\t                    aggregate = cell.attr(kendo.attr("aggregates")),\n\t                    member = cell.attr(kendo.attr("field"));\n\n\t                if (aggregate && aggregate !== "") {\n\t                    names = aggregate.split(",");\n\t                    aggregate = [];\n\t                    for (idx = 0, length = names.length; idx < length; idx++) {\n\t                        aggregate.push({ field: member, aggregate: names[idx] });\n\t                    }\n\t                }\n\t                return aggregate;\n\t            }).toArray();\n\t        },\n\n\t        descriptors: function() {\n\t            var that = this,\n\t                indicators = $(".k-group-indicator", that.groupContainer),\n\t                field,\n\t                aggregates = that.aggregates();\n\n\t            return $.map(indicators, function(item) {\n\t                item = $(item);\n\t                field = item.attr(kendo.attr("field"));\n\t                var sortOptions = that.options.sort || {};\n\t                var indicatorSortOptions = item.data(GROUP_SORT) || {};\n\n\t                return {\n\t                    field: field,\n\t                    dir: item.attr(kendo.attr("dir")),\n\t                    aggregates: aggregates || [],\n\t                    compare: indicatorSortOptions.compare || sortOptions.compare\n\t                };\n\t            });\n\t        },\n\n\t        _removeIndicator: function(indicator) {\n\t            var that = this;\n\t            indicator.off();\n\t            indicator.removeData();\n\t            indicator.remove();\n\t            that._invalidateGroupContainer();\n\t            that._change();\n\t        },\n\n\t        _change: function() {\n\t            var that = this;\n\t            if(that.dataSource) {\n\t                var descriptors = that.descriptors();\n\t                if (that.trigger("change", { groups: descriptors })) {\n\t                    that.refresh();\n\t                    return;\n\t                }\n\t                that.dataSource.group(descriptors);\n\t            }\n\t        },\n\n\t        _dropCuePosition: function(position) {\n\t            var dropCuePositions = this._dropCuePositions;\n\t            if(!dropCue.is(":visible") || dropCuePositions.length === 0) {\n\t                return;\n\t            }\n\n\t            position = Math.ceil(position);\n\n\t            var lastCuePosition = dropCuePositions[dropCuePositions.length - 1],\n\t                left = lastCuePosition.left,\n\t                right = lastCuePosition.right,\n\t                marginLeft = parseInt(lastCuePosition.element.css("marginLeft"), 10),\n\t                marginRight = parseInt(lastCuePosition.element.css("marginRight"), 10);\n\n\t            if(position >= right && !isRtl || position < left && isRtl) {\n\t                position = {\n\t                    left: lastCuePosition.element.position().left + (!isRtl ? outerWidth(lastCuePosition.element) + marginRight : - marginLeft),\n\t                    element: lastCuePosition.element,\n\t                    before: false\n\t                };\n\t            } else {\n\t                position = $.grep(dropCuePositions, function(item) {\n\t                    return (item.left <= position && position <= item.right) || (isRtl && position > item.right);\n\t                })[0];\n\n\t                if(position) {\n\t                    position = {\n\t                        left: isRtl ? position.element.position().left + outerWidth(position.element) + marginRight : position.element.position().left - marginLeft,\n\t                        element: position.element,\n\t                        before: true\n\t                    };\n\t                }\n\t            }\n\n\t            return position;\n\t        },\n\t        _drag: function(event) {\n\t            var position = this._dropCuePosition(event.x.location);\n\n\t            if (position) {\n\t                dropCue.css({ left: position.left, right: "auto" });\n\t            }\n\t        },\n\t        _canDrag: function(element) {\n\t            var field = element.attr(kendo.attr("field"));\n\n\t            return element.attr(kendo.attr("groupable")) != "false" &&\n\t                field &&\n\t                (element.hasClass("k-group-indicator") ||\n\t                    !this.indicator(field));\n\t        },\n\t        _canDrop: function(source, target, position) {\n\t            var next = source.next(),\n\t                result = source[0] !== target[0] && (!next[0] || target[0] !== next[0] || (!isRtl && position > next.position().left || isRtl && position < next.position().left));\n\t            return result;\n\t        },\n\t        _dragEnd: function(draggable) {\n\t            var that = this,\n\t                field = draggable.currentTarget.attr(kendo.attr("field")),\n\t                sourceIndicator = that.indicator(field);\n\n\t            if (draggable !== that.options.draggable && !draggable.dropped && sourceIndicator) {\n\t                that._removeIndicator($(sourceIndicator));\n\t            }\n\n\t            that._dragCancel();\n\t        },\n\t        _dragCancel: function() {\n\t            dropCue.remove();\n\t            this._dropCuePositions = [];\n\t        },\n\t        _intializePositions: function() {\n\t            var that = this,\n\t                indicators = $(".k-group-indicator", that.groupContainer),\n\t                left;\n\n\t            that._dropCuePositions = $.map(indicators, function(item) {\n\t                item = $(item);\n\t                left = kendo.getOffset(item).left;\n\t                return {\n\t                    left: parseInt(left, 10),\n\t                    right: parseInt(left + outerWidth(item), 10),\n\t                    element: item\n\t                };\n\t            });\n\t        },\n\t        _invalidateGroupContainer: function() {\n\t            var groupContainer = this.groupContainer;\n\t            if(groupContainer && groupContainer.is(":empty")) {\n\t                groupContainer.html(this.options.messages.empty);\n\t            }\n\t        }\n\t    });\n\n\t    kendo.ui.plugin(Groupable);\n\n\t})(window.kendo.jQuery);\n\n\treturn window.kendo;\n\n\t}, __webpack_require__(3));\n\n\n/***/ })\n\n/******/ });\n\n//# sourceURL=webpack:///./node_modules/@progress/kendo-ui/js/kendo.groupable.js?')},"./node_modules/@progress/kendo-ui/js/kendo.imagebrowser.js":
/*!******************************************************************!*\
  !*** ./node_modules/@progress/kendo-ui/js/kendo.imagebrowser.js ***!
  \******************************************************************/
/*! no static exports found */function(module,exports,__webpack_require__){eval('module.exports =\n/******/ (function(modules) { // webpackBootstrap\n/******/ \t// The module cache\n/******/ \tvar installedModules = {};\n\n/******/ \t// The require function\n/******/ \tfunction __webpack_require__(moduleId) {\n\n/******/ \t\t// Check if module is in cache\n/******/ \t\tif(installedModules[moduleId])\n/******/ \t\t\treturn installedModules[moduleId].exports;\n\n/******/ \t\t// Create a new module (and put it into the cache)\n/******/ \t\tvar module = installedModules[moduleId] = {\n/******/ \t\t\texports: {},\n/******/ \t\t\tid: moduleId,\n/******/ \t\t\tloaded: false\n/******/ \t\t};\n\n/******/ \t\t// Execute the module function\n/******/ \t\tmodules[moduleId].call(module.exports, module, module.exports, __webpack_require__);\n\n/******/ \t\t// Flag the module as loaded\n/******/ \t\tmodule.loaded = true;\n\n/******/ \t\t// Return the exports of the module\n/******/ \t\treturn module.exports;\n/******/ \t}\n\n\n/******/ \t// expose the modules object (__webpack_modules__)\n/******/ \t__webpack_require__.m = modules;\n\n/******/ \t// expose the module cache\n/******/ \t__webpack_require__.c = installedModules;\n\n/******/ \t// __webpack_public_path__\n/******/ \t__webpack_require__.p = "";\n\n/******/ \t// Load entry module and return exports\n/******/ \treturn __webpack_require__(0);\n/******/ })\n/************************************************************************/\n/******/ ({\n\n/***/ 0:\n/***/ (function(module, exports, __webpack_require__) {\n\n\tmodule.exports = __webpack_require__(1241);\n\n\n/***/ }),\n\n/***/ 3:\n/***/ (function(module, exports) {\n\n\tmodule.exports = function() { throw new Error("define cannot be used indirect"); };\n\n\n/***/ }),\n\n/***/ 1241:\n/***/ (function(module, exports, __webpack_require__) {\n\n\tvar __WEBPACK_AMD_DEFINE_FACTORY__, __WEBPACK_AMD_DEFINE_ARRAY__, __WEBPACK_AMD_DEFINE_RESULT__;(function(f, define){\n\t    !(__WEBPACK_AMD_DEFINE_ARRAY__ = [ __webpack_require__(1242) ], __WEBPACK_AMD_DEFINE_FACTORY__ = (f), __WEBPACK_AMD_DEFINE_RESULT__ = (typeof __WEBPACK_AMD_DEFINE_FACTORY__ === \'function\' ? (__WEBPACK_AMD_DEFINE_FACTORY__.apply(exports, __WEBPACK_AMD_DEFINE_ARRAY__)) : __WEBPACK_AMD_DEFINE_FACTORY__), __WEBPACK_AMD_DEFINE_RESULT__ !== undefined && (module.exports = __WEBPACK_AMD_DEFINE_RESULT__));\n\t})(function(){\n\n\tvar __meta__ = { // jshint ignore:line\n\t    id: "imagebrowser",\n\t    name: "ImageBrowser",\n\t    category: "web",\n\t    description: "",\n\t    hidden: true,\n\t    depends: [ "filebrowser" ]\n\t};\n\n\t(function($, undefined) {\n\t    var kendo = window.kendo,\n\t        FileBrowser = kendo.ui.FileBrowser,\n\t        isPlainObject = $.isPlainObject,\n\t        proxy = $.proxy,\n\t        extend = $.extend,\n\t        browser = kendo.support.browser,\n\t        isFunction = kendo.isFunction,\n\t        trimSlashesRegExp = /(^\\/|\\/$)/g,\n\t        ERROR = "error",\n\t        NS = ".kendoImageBrowser",\n\t        NAMEFIELD = "name",\n\t        SIZEFIELD = "size",\n\t        TYPEFIELD = "type",\n\t        DEFAULTSORTORDER = { field: TYPEFIELD, dir: "asc" },\n\t        EMPTYTILE = kendo.template(\'<div class="k-listview-item k-listview-item-empty"><span class="k-file-preview"><span class="k-file-icon k-icon k-i-none"></span></span><span class="k-file-name">${text}</span></div>\');\n\n\t    extend(true, kendo.data, {\n\t        schemas: {\n\t            "imagebrowser": {\n\t                data: function(data) {\n\t                    return data.items || data || [];\n\t                },\n\t                model: {\n\t                    id: "name",\n\t                    fields: {\n\t                        name: "name",\n\t                        size: "size",\n\t                        type: "type"\n\t                    }\n\t                }\n\t            }\n\t        }\n\t    });\n\n\t    extend(true, kendo.data, {\n\t        transports: {\n\t            "imagebrowser": kendo.data.RemoteTransport.extend({\n\t                init: function(options) {\n\t                    kendo.data.RemoteTransport.fn.init.call(this, $.extend(true, {}, this.options, options));\n\t                },\n\t                _call: function(type, options) {\n\t                    options.data = $.extend({}, options.data, { path: this.options.path() });\n\n\t                    if (isFunction(this.options[type])) {\n\t                        this.options[type].call(this, options);\n\t                    } else {\n\t                        kendo.data.RemoteTransport.fn[type].call(this, options);\n\t                    }\n\t                },\n\t                read: function(options) {\n\t                    this._call("read", options);\n\t                },\n\t                create: function(options) {\n\t                    this._call("create", options);\n\t                },\n\t                destroy: function(options) {\n\t                    this._call("destroy", options);\n\t                },\n\t                update: function() {\n\t                    //updates are handled by the upload\n\t                },\n\t                options: {\n\t                    read: {\n\t                        type: "POST"\n\t                    },\n\t                    update: {\n\t                        type: "POST"\n\t                    },\n\t                    create: {\n\t                        type: "POST"\n\t                    },\n\t                    destroy: {\n\t                        type: "POST"\n\t                    }\n\t                }\n\t            })\n\t        }\n\t    });\n\n\t    var offsetTop;\n\t    if (browser.msie && browser.version < 8) {\n\t        offsetTop = function (element) {\n\t            return element.offsetTop;\n\t        };\n\t    } else {\n\t        offsetTop = function (element) {\n\t            return element.offsetTop - $(element).height();\n\t        };\n\t    }\n\n\t    function concatPaths(path, name) {\n\t        if(path === undefined || !path.match(/\\/$/)) {\n\t            path = (path || "") + "/";\n\t        }\n\t        return path + name;\n\t    }\n\n\t    function sizeFormatter(value) {\n\t        if(!value) {\n\t            return "";\n\t        }\n\n\t        var suffix = " bytes";\n\n\t        if (value >= 1073741824) {\n\t            suffix = " GB";\n\t            value /= 1073741824;\n\t        } else if (value >= 1048576) {\n\t            suffix = " MB";\n\t            value /= 1048576;\n\t        } else  if (value >= 1024) {\n\t            suffix = " KB";\n\t            value /= 1024;\n\t        }\n\n\t        return Math.round(value * 100) / 100 + suffix;\n\t    }\n\n\t    var ImageBrowser = FileBrowser.extend({\n\t        init: function(element, options) {\n\t            var that = this;\n\n\t            options = options || {};\n\n\t            FileBrowser.fn.init.call(that, element, options);\n\n\t            that.element.addClass("k-imagebrowser");\n\t        },\n\n\t        options: {\n\t            name: "ImageBrowser",\n\t            fileTypes: "*.png,*.gif,*.jpg,*.jpeg"\n\t        },\n\n\t        value: function () {\n\t            var that = this,\n\t                selected = that._selectedItem(),\n\t                path,\n\t                imageUrl = that.options.transport.imageUrl;\n\n\t            if (selected && selected.get(TYPEFIELD) === "f") {\n\t                path = concatPaths(that.path(), selected.get(NAMEFIELD)).replace(trimSlashesRegExp, "");\n\t                if (imageUrl) {\n\t                    path = isFunction(imageUrl) ? imageUrl(path) : kendo.format(imageUrl, encodeURIComponent(path));\n\t                }\n\t                return path;\n\t            }\n\t        },\n\n\t        _fileUpload: function(e) {\n\t            var that = this,\n\t                options = that.options,\n\t                fileTypes = options.fileTypes,\n\t                filterRegExp = new RegExp(("(" + fileTypes.split(",").join(")|(") + ")").replace(/\\*\\./g , ".*."), "i"),\n\t                fileName = e.files[0].name,\n\t                fileSize = e.files[0].size,\n\t                fileNameField = NAMEFIELD,\n\t                sizeField = SIZEFIELD,\n\t                file;\n\n\t            if (filterRegExp.test(fileName)) {\n\t                e.data = { path: that.path() };\n\n\t                file = that._createFile(fileName, fileSize);\n\n\t                if (!file) {\n\t                    e.preventDefault();\n\t                } else {\n\t                    file._uploading = true;\n\n\t                    that.upload.one("error", function() {\n\t                        file = undefined;\n\t                    });\n\n\t                    that.upload.one("success", function(e) {\n\t                        if (file) {\n\t                            delete file._uploading;\n\n\t                            var model = that._insertFileToList(file);\n\n\t                            if(model._override) {\n\t                                model.set(fileNameField, e.response[that._getFieldName(fileNameField)]);\n\t                                model.set(sizeField, e.response[that._getFieldName(sizeField)]);\n\n\t                                that.listView.dataSource.pushUpdate(model);\n\t                            }\n\n\t                            that._tiles = that.listView.items().filter("[" + kendo.attr("type") + "=f]");\n\t                            that._scroll();\n\t                        }\n\t                    });\n\t                }\n\t            } else {\n\t                e.preventDefault();\n\t                that._showMessage(kendo.format(options.messages.invalidFileType, fileName, fileTypes));\n\t            }\n\t        },\n\n\t        _content: function() {\n\t            var that = this;\n\n\t            that.list = $(\'<div class="k-filemanager-listview" />\')\n\t                .appendTo(that.element)\n\t                .on("scroll" + NS, proxy(that._scroll, that))\n\t                .on("dblclick" + NS, ".k-listview-item", proxy(that._dblClick, that));\n\n\t            that.listView = new kendo.ui.ListView(that.list, {\n\t                layout: "flex",\n\t                flex: {\n\t                    direction: "row",\n\t                    wrap: "wrap"\n\t                },\n\t                dataSource: that.dataSource,\n\t                template: that._itemTmpl(),\n\t                editTemplate: that._editTmpl(),\n\t                selectable: true,\n\t                autoBind: false,\n\t                dataBinding: function(e) {\n\n\t                    that.toolbar.find(".k-i-close").parent().addClass("k-state-disabled");\n\n\t                    if (e.action === "remove" || e.action === "sync") {\n\t                        e.preventDefault();\n\t                        kendo.ui.progress(that.listView.content, false);\n\t                    }\n\t                },\n\t                dataBound: function() {\n\t                    if (that.dataSource.view().length) {\n\t                        that._tiles = this.items().filter("[" + kendo.attr("type") + "=f]");\n\t                        that._scroll();\n\t                    } else {\n\t                        this.content.append(EMPTYTILE({ text: that.options.messages.emptyFolder }));\n\t                    }\n\t                },\n\t                change: proxy(that._listViewChange, that)\n\t            });\n\t        },\n\n\t        _dataSource: function() {\n\t            var that = this,\n\t                options = that.options,\n\t                transport = options.transport,\n\t                typeSortOrder = extend({}, DEFAULTSORTORDER),\n\t                nameSortOrder = { field: NAMEFIELD, dir: "asc" },\n\t                schema,\n\t                dataSource = {\n\t                    type: transport.type || "imagebrowser",\n\t                    sort: [typeSortOrder, nameSortOrder]\n\t                };\n\n\t            if (isPlainObject(transport)) {\n\t                transport.path = proxy(that.path, that);\n\t                dataSource.transport = transport;\n\t            }\n\n\t            if (isPlainObject(options.schema)) {\n\t                dataSource.schema = options.schema;\n\t            } else if (transport.type && isPlainObject(kendo.data.schemas[transport.type])) {\n\t                schema = kendo.data.schemas[transport.type];\n\t            }\n\n\t            if (that.dataSource && that._errorHandler) {\n\t                that.dataSource.unbind(ERROR, that._errorHandler);\n\t            } else {\n\t                that._errorHandler = proxy(that._error, that);\n\t            }\n\n\t            that.dataSource = kendo.data.DataSource.create(dataSource)\n\t                .bind(ERROR, that._errorHandler);\n\t        },\n\n\t        _loadImage: function(li) {\n\t            var that = this,\n\t                element = $(li),\n\t                dataItem = that.dataSource.getByUid(element.attr(kendo.attr("uid"))),\n\t                name = dataItem.get(NAMEFIELD),\n\t                thumbnailUrl = that.options.transport.thumbnailUrl,\n\t                img = $("<img />", { alt: name }),\n\t                urlJoin = "?";\n\n\t            if (dataItem._uploading) {\n\t                return;\n\t            }\n\n\t            img.hide()\n\t               .on("load" + NS, function() {\n\t                   $(this).prev().remove().end().addClass("k-image k-file-image").fadeIn();\n\t               });\n\n\t            element.find(".k-i-loading").after(img);\n\n\t            if (isFunction(thumbnailUrl)) {\n\t                thumbnailUrl = thumbnailUrl(that.path(), encodeURIComponent(name));\n\t            } else {\n\t                if (thumbnailUrl.indexOf("?") >= 0) {\n\t                    urlJoin = "&";\n\t                }\n\n\t                thumbnailUrl = thumbnailUrl + urlJoin + "path=" + encodeURIComponent(that.path() + name);\n\t                if (dataItem._override) {\n\t                    thumbnailUrl += "&_=" + new Date().getTime();\n\t                    delete dataItem._override;\n\t                }\n\t            }\n\n\t            // IE8 will trigger the load event immediately when the src is assigned\n\t            // if the image is loaded from the cache\n\t            img.attr("src", thumbnailUrl);\n\n\t            li.loaded = true;\n\t        },\n\n\t        _scroll: function() {\n\t            var that = this;\n\t            if (that.options.transport && that.options.transport.thumbnailUrl) {\n\t                clearTimeout(that._timeout);\n\n\t                that._timeout = setTimeout(function() {\n\t                    var height = kendo._outerHeight(that.list),\n\t                        viewTop = that.list.scrollTop(),\n\t                        viewBottom = viewTop + height;\n\n\t                    that._tiles.each(function() {\n\t                        var top = offsetTop(this),\n\t                            bottom = top + this.offsetHeight;\n\n\t                        if ((top >= viewTop && top < viewBottom) || (bottom >= viewTop && bottom < viewBottom)) {\n\t                            that._loadImage(this);\n\t                        }\n\n\t                        if (top > viewBottom) {\n\t                            return false;\n\t                        }\n\t                    });\n\n\t                    that._tiles = that._tiles.filter(function() {\n\t                        return !this.loaded;\n\t                    });\n\n\t                }, 250);\n\t            }\n\t        },\n\n\t        _itemTmpl: function() {\n\t            var that = this,\n\t                html = \'<div class="k-listview-item" \' + kendo.attr("uid") + \'="#=uid#" \';\n\n\t            html += kendo.attr("type") + \'="${\' + TYPEFIELD + \'}">\';\n\t            html += \'#if(\' + TYPEFIELD + \' == "d") { #\';\n\t            html += \'<div class="k-file-preview"><span class="k-file-icon k-icon k-i-folder"></span></div>\';\n\t            html += "#}else{#";\n\t            if (that.options.transport && that.options.transport.thumbnailUrl) {\n\t                html += \'<div class="k-file-preview"><span class="k-file-icon k-icon k-i-loading"></span></div>\';\n\t            } else {\n\t                html += \'<div class="k-file-preview"><span class="k-file-icon k-icon k-i-file"></span></div>\';\n\t            }\n\t            html += "#}#";\n\t            html += \'<span class="k-file-name">${\' + NAMEFIELD + \'}</span>\';\n\t            html += \'#if(\' + TYPEFIELD + \' == "f") { # <span class="k-file-size">${this.sizeFormatter(\' + SIZEFIELD + \')}</span> #}#\';\n\t            html += \'</div>\';\n\n\t            return proxy(kendo.template(html), { sizeFormatter: sizeFormatter } );\n\t        }\n\t    });\n\n\t    kendo.ui.plugin(ImageBrowser);\n\t})(window.kendo.jQuery);\n\n\treturn window.kendo;\n\n\t}, __webpack_require__(3));\n\n\n/***/ }),\n\n/***/ 1242:\n/***/ (function(module, exports) {\n\n\tmodule.exports = __webpack_require__(/*! ./kendo.filebrowser */ "./node_modules/@progress/kendo-ui/js/kendo.filebrowser.js");\n\n/***/ })\n\n/******/ });\n\n//# sourceURL=webpack:///./node_modules/@progress/kendo-ui/js/kendo.imagebrowser.js?')}}]);