(self.webpackChunk_5_112_1332=self.webpackChunk_5_112_1332||[]).push([[3804],{3804:(r,n,e)=>{r.exports=function(r){var n={};function e(u){if(n[u])return n[u].exports;var t=n[u]={exports:{},id:u,loaded:!1};return r[u].call(t.exports,t,t.exports,e),t.loaded=!0,t.exports}return e.m=r,e.c=n,e.p="",e(0)}({0:function(r,n,e){e(1633),r.exports=e(1633)},3:function(r,n){r.exports=function(){throw new Error("define cannot be used indirect")}},1590:function(r,n){r.exports=e(4541)},1624:function(r,n){r.exports=e(1599)},1633:function(r,n,e){var u,t,a;e(3),t=[e(1590),e(1624)],void 0===(a="function"==typeof(u=function(){"use strict";var r=kendo.util,n=kendo.spreadsheet,e=n.calc,u=e.runtime,t=u.defineFunction,a=u.defineAlias,i=u.CalcError,o=n.RangeRef,s=n.CellRef,c=n.UnionRef,f=u.Matrix,l=n.Ref,g=n.NameRef,m=u.daysInMonth,h=u.packDate,F=u.unpackDate,b=u.daysInYear;function d(r){return(Math.exp(r)+Math.exp(-r))/2}function A(r){return(Math.exp(r)-Math.exp(-r))/2}function v(r){return A(r)/d(r)}function p(r,n){for(;n;){var e=r%n;r=n,n=e}return r}function C(r,n){return Math.abs(r*n)/p(r,n)}function D(r,n){for(var e=[],u=0,t=r[0];u<r.length;)e.push({matrix:r[u++],pred:z(r[u++])});for(var a=0;a<t.height;++a)r:for(var i=0;i<t.width;++i){for(u=0;u<e.length;++u){var o=e[u].matrix.get(a,i);if(!e[u].pred(null==o||""===o?0:o))continue r}n(a,i)}}["abs","cos","sin","acos","asin","tan","atan","exp","sqrt"].forEach((function(r){t(r,Math[r]).args([["*n","number"]])})),t("ln",Math.log).args([["*n","number"]]),t("log",(function(r,n){return Math.log(r)/Math.log(n)})).args([["*num","number++"],["*base",["or","number++",["null",10]]],["?",["assert","$base != 1","DIV/0"]]]),t("log10",(function(r){return Math.log(r)/Math.log(10)})).args([["*num","number++"]]),t("pi",(function(){return Math.PI})).args([]),t("sqrtpi",(function(r){return Math.sqrt(r*Math.PI)})).args([["*num","number+"]]),t("degrees",(function(r){return 180*r/Math.PI%360})).args([["*radians","number"]]),t("radians",(function(r){return Math.PI*r/180})).args([["*degrees","number"]]),t("cosh",d).args([["*num","number"]]),t("acosh",(function(r){return Math.log(r+Math.sqrt(r-1)*Math.sqrt(r+1))})).args([["*num","number"],["?",["assert","$num >= 1"]]]),t("sinh",A).args([["*num","number"]]),t("asinh",(function(r){return Math.log(r+Math.sqrt(r*r+1))})).args([["*num","number"]]),t("sec",(function(r){return 1/Math.cos(r)})).args([["*num","number"]]),t("sech",(function(r){return 1/d(r)})).args([["*num","number"]]),t("csc",(function(r){return 1/Math.sin(r)})).args([["*num","number"]]),t("csch",(function(r){return 1/A(r)})).args([["*num","number"]]),t("atan2",(function(r,n){return Math.atan(n/r)})).args([["*x","divisor"],["*y","number"]]),t("tanh",v).args([["*num","number"]]),t("atanh",(function(r){return Math.log(Math.sqrt(1-r*r)/(1-r))})).args([["*num",["and","number",["(between)",-1,1]]]]),t("cot",(function(r){return 1/Math.tan(r)})).args([["*num","divisor"]]),t("coth",(function(r){return 1/v(r)})).args([["*num","divisor"]]),t("acot",(function(r){return Math.PI/2-Math.atan(r)})).args([["*num","number"]]),t("acoth",(function(r){return Math.log((r+1)/(r-1))/2})).args([["*num","number"],["?",["or",["assert","$num < -1"],["assert","$num > 1"]]]]),t("power",(function(r,n){return Math.pow(r,n)})).args([["*a","number"],["*b","number"]]),t("mod",(function(r,n){return r%n})).args([["*a","number"],["*b","divisor"]]),t("quotient",(function(r,n){return Math.floor(r/n)})).args([["*a","number"],["*b","divisor"]]),t("ceiling",(function(r,n){return n?n*Math.ceil(r/n):0})).args([["*number","number"],["*significance","number"],["?",["assert","$significance >= 0 || $number < 0"]]]),t("ceiling.precise",(function(r,n){return(n=Math.abs(n))?n*Math.ceil(r/n):0})).args([["*number","number"],["*significance",["or","number",["null",1]]]]),a("iso.ceiling","ceiling.precise"),t("ceiling.math",(function(r,n,e){return n&&r?(r<0&&(!e&&n<0||e&&n>0)&&(n=-n),n?n*Math.ceil(r/n):0):0})).args([["*number","number"],["*significance",["or","number",["null","$number < 0 ? -1 : 1"]]],["*mode",["or","logical",["null",0]]]]),t("floor",(function(r,n){return n?n*Math.floor(r/n):0})).args([["*number","number"],["*significance","number"],["?",["assert","$significance >= 0 || $number < 0"]]]),t("floor.precise",(function(r,n){return(n=Math.abs(n))?n*Math.floor(r/n):0})).args([["*number","number"],["*significance",["or","number",["null",1]]]]),t("floor.math",(function(r,n,e){return n&&r?(r<0&&(!e&&n<0||e&&n>0)&&(n=-n),n?n*Math.floor(r/n):0):0})).args([["*number","number"],["*significance",["or","number",["null","$number < 0 ? -1 : 1"]]],["*mode",["or","logical",["null",0]]]]),t("int",Math.floor).args([["*number","number"]]),t("mround",(function(r,n){return n?n*Math.round(r/n):0})).args([["*number","number"],["*multiple","number"]]),t("round",(function(r,n){var e=r<0?-1:1;return e<0&&(r=-r),r*=n=Math.pow(10,n),e*(r=Math.round(r))/n})).args([["*number","number"],["*digits","number"]]),t("roundup",(function(r,n){return(r=(r*=n=Math.pow(10,n))<0?Math.floor(r):Math.ceil(r))/n})).args([["*number","number"],["*digits","number"]]),t("rounddown",(function(r,n){return(r=(r*=n=Math.pow(10,n))<0?Math.ceil(r):Math.floor(r))/n})).args([["*number","number"],["*digits","number"]]),t("even",(function(r){var n=r<0?Math.floor(r):Math.ceil(r);return n%2?n+(n<0?-1:1):n})).args([["*number","number"]]),t("odd",(function(r){var n=r<0?Math.floor(r):Math.ceil(r);return n%2?n:n+(n<0?-1:1)})).args([["*number","number"]]),t("sign",(function(r){return r<0?-1:r>0?1:0})).args([["*number","number"]]),t("gcd",(function(r){for(var n=r[0],e=1;e<r.length;++e)n=p(n,r[e]);return n})).args([["numbers",["collect","number"]]]),t("lcm",(function(r){for(var n=r[0],e=1;e<r.length;++e)n=C(n,r[e]);return n})).args([["numbers",["collect","number"]]]),t("sum",(function(r){return r.reduce((function(r,n){return r+n}),0)})).args([["numbers",["collect","number"]]]),t("product",(function(r){return r.reduce((function(r,n){return r*n}),1)})).args([["numbers",["collect","number"]]]),t("sumproduct",(function(r,n){var e=0;return r.each((function(r,u,t){if("number"==typeof r){for(var a=0;a<n.length;++a){var i=n[a].get(u,t);if("number"!=typeof i)return;r*=i}e+=r}})),e})).args([["a1","matrix"],["+",["a2",["and","matrix",["assert","$a2.width == $a1.width"],["assert","$a2.height == $a1.height"]]]]]),t("sumsq",(function(r){return r.reduce((function(r,n){return r+n*n}),0)})).args([["numbers",["collect","number"]]]),t("sumx2my2",(function(r,n){var e=0;return r.each((function(r,u,t){var a=n.get(u,t);"number"==typeof r&&"number"==typeof a&&(e+=r*r-a*a)})),e})).args([["a","matrix"],["b",["and","matrix",["assert","$b.width == $a.width"],["assert","$b.height == $a.height"]]]]),t("sumx2py2",(function(r,n){var e=0;return r.each((function(r,u,t){var a=n.get(u,t);"number"==typeof r&&"number"==typeof a&&(e+=r*r+a*a)})),e})).args([["a","matrix"],["b",["and","matrix",["assert","$b.width == $a.width"],["assert","$b.height == $a.height"]]]]),t("sumxmy2",(function(r,n){var e=0;return r.each((function(r,u,t){var a=n.get(u,t);"number"==typeof r&&"number"==typeof a&&(e+=(r-a)*(r-a))})),e})).args([["a","matrix"],["b",["and","matrix",["assert","$b.width == $a.width"],["assert","$b.height == $a.height"]]]]),t("seriessum",(function(r,n,e,u){var t=0;return u.each((function(u){if("number"!=typeof u)throw new i("VALUE");t+=u*Math.pow(r,n),n+=e})),t})).args([["x","number"],["y","number"],["m","number"],["a","matrix"]]),t("min",(function(r){return r.length?Math.min.apply(Math,r):0})).args([["numbers",["collect","number"]]]),t("max",(function(r){return r.length?Math.max.apply(Math,r):0})).args([["numbers",["collect","number"]]]),t("counta",(function(r){return r.length})).args([["values",["#collect","anyvalue"]]]),t("count",(function(r){return r.length})).args([["numbers",["#collect","number"]]]),t("countunique",(function(r){var n=0,e=[];return r.forEach((function(r){e.indexOf(r)<0&&(n++,e.push(r))})),n})).args([["values",["#collect","anyvalue"]]]),t("countblank",(function(r){var n=0;function e(r){null!=r&&""!==r||n++}return function(r){for(var n=0;n<r.length;++n){var u=r[n];u instanceof f?u.each(e,!0):e(u)}}(r),n})).args([["+",["args",["or","matrix","anyvalue"]]]]),t("iseven",(function(r){return r%2==0})).args([["*number","number"]]),t("isodd",(function(r){return r%2!=0})).args([["*number","number"]]),t("n",(function(r){return"boolean"==typeof r?r?1:0:"number"==typeof r?r:0})).args([["*value","anyvalue"]]),t("na",(function(){return new i("N/A")})).args([]);var E=[["m1","matrix"],["c1","anyvalue"],[["m2","matrix"],["c2","anyvalue"]]];t("countifs",(function(r,n,e){var u=0;return e.unshift(r,n),D(e,(function(){u++})),u})).args(E);var w=[["range","matrix"]].concat(E);t("sumifs",(function(r,n,e,u){u.unshift(r,Q,n,e);var t=0;return D(u,(function(n,e){var u=r.get(n,e);u&&(t+=u)})),t})).args(w),t("averageifs",(function(r,n,e,u){u.unshift(r,Q,n,e);var t=0,a=0;return D(u,(function(n,e){var u=r.get(n,e);null!=u&&""!==u||(u=0),t+=u,a++})),a?t/a:new i("DIV/0")})).args(w),t("countif",(function(r,n){n=z(n);var e=0;return r.each((function(r){n(r)&&e++})),e})).args([["range","matrix"],["*criteria","anyvalue"]]);var B,x=[["range","matrix"],["*criteria","anyvalue"],["sumRange",["or","area","#matrix",["null","$range"]]]];function y(r){return function(n,e,u,t){var a=this;if(t instanceof l){var i=t.clone().toRangeRef();if(i.width()!=e.width||i.height()!=e.height)return isFinite(i.topLeft.row)||(i.topLeft.row=0),isFinite(i.topLeft.col)||(i.topLeft.col=0),i.bottomRight.row=i.topLeft.row+e.height-1,i.bottomRight.col=i.topLeft.col+e.width-1,a.resolveCells([i],(function(){n(r(e,u,a.asMatrix(i)))}))}n(r(e,u,a.asMatrix(t)))}}function M(r){return r.reduce((function(r,n){return r+n}),0)/r.length}function $(r,n,e){return null==e&&(e=M(r)),r.reduce((function(r,n){return r+Math.pow(n-e,2)}),0)/n}function L(r,n){return Math.sqrt($(r,n))}function N(r,n,e){var u=0,t=0,a=null,o=null,s=!1;return r.forEach((function(r){r<n?(u++,a=null==a?r:Math.max(a,r)):r>n?(t++,o=null==o?r:Math.min(o,r)):s=!0})),u||t?s?e?(u+1)/(r.length+1):u/(u+t):((o-n)*N(r,a,e)+(n-a)*N(r,o,e))/(o-a):new i("N/A")}t("sumif",y((function(r,n,e){var u=0;return n=z(n),r.each((function(r,t,a){if(n(r)){var i=e.get(t,a);Q(i)&&(u+=i||0)}})),u}))).argsAsync(x),t("averageif",y((function(r,n,e){var u=0,t=0;return n=z(n),r.each((function(r,a,i){if(n(r)){var o=e.get(a,i);Q(o)&&(u+=o||0,t++)}})),t?u/t:new i("DIV/0")}))).argsAsync(x),(B=function(r,n){t(r,(function(r,e){var u=[];return r.each((function(r){if(r instanceof i)return r;"number"==typeof r&&u.push(r)}))||(e>u.length?new i("NUM"):n(u,e-1))})).args([["array","matrix"],["*nth","number++"]])})("large",(function(r,n){return r.sort(H)[n]})),B("small",(function(r,n){return r.sort(Y)[n]})),t("stdev.s",(function(r){return L(r,r.length-1)})).args([["numbers",["collect","number"]],["?",["assert","$numbers.length >= 2","NUM"]]]),t("stdev.p",(function(r){return L(r,r.length)})).args([["numbers",["collect","number"]],["?",["assert","$numbers.length >= 2","NUM"]]]),t("var.s",(function(r){return $(r,r.length-1)})).args([["numbers",["collect","number"]],["?",["assert","$numbers.length >= 2","NUM"]]]),t("var.p",(function(r){return $(r,r.length)})).args([["numbers",["collect","number"]],["?",["assert","$numbers.length >= 2","NUM"]]]),t("median",(function(r){var n=r.length;return r.sort(Y),n%2?r[n>>1]:(r[n>>=1]+r[n-1])/2})).args([["numbers",["collect","number"]],["?",["assert","$numbers.length > 0","N/A"]]]),t("mode.sngl",(function(r){r.sort(Y);for(var n=null,e=0,u=1,t=null,a=0;a<r.length;++a){var o=r[a];o!=n?(e=1,n=o):e++,e>u&&(u=e,t=o)}return null==t?new i("N/A"):t})).args([["numbers",["collect","number"]]]),t("mode.mult",(function(r){var n=Object.create(null),e=2,u=[];r.forEach((function(r){var t=n[r]||0;n[r]=++t,t==e?u.push(r):t>e&&(e=t,u=[r])}));var t=new f(this);return u.forEach((function(r,n){t.set(n,0,r)})),t})).args([["numbers",["collect","number"]]]),t("geomean",(function(r){var n=r.length,e=r.reduce((function(r,n){if(n<0)throw new i("NUM");return r*n}),1);return Math.pow(e,1/n)})).args([["numbers",["collect","number"]],["?",["assert","$numbers.length > 0","NUM"]]]),t("harmean",(function(r){return r.length/r.reduce((function(r,n){if(!n)throw new i("DIV/0");return r+1/n}),0)})).args([["numbers",["collect","number"]],["?",["assert","$numbers.length > 0","NUM"]]]),t("trimmean",(function(r,n){var e=r.length;r.sort(Y);var u=Math.floor(e*n);u%2&&--u;for(var t=0,a=u/=2;a<e-u;++a)t+=r[a];return t/(e-2*u)})).args([["numbers",["collect","number",1]],["percent",["and","number",["[between)",0,1]]],["?",["assert","$numbers.length > 0","NUM"]]]),t("frequency",(function(r,n){r.sort(Y),n.sort(Y);var e=-1/0,u=0;function t(n){for(var t=0;u<r.length&&r[u]>e&&r[u]<=n;)++t,++u;return t}var a=new f(this);return n.forEach((function(r,n){var u=t(r);e=r,a.set(n,0,u)})),a.set(a.height,0,r.length-u),a})).args([["data",["collect","number",1]],["bins",["collect","number",1]]]),t("rank.eq",(function(r,n,e){n.sort(e?Y:H);var u=n.indexOf(r);return u<0?new i("N/A"):u+1})).args([["value","number"],["numbers",["collect","number"]],["order",["or","logical",["null",!1]]]]),a("rank","rank.eq"),t("rank.avg",(function(r,n,e){n.sort(e?Y:H);var u=n.indexOf(r);if(u<0)return new i("N/A");for(var t=u;n[t]==r;++t);return(u+t+1)/2})).args([["value","number"],["numbers",["collect","number"]],["order",["or","logical",["null",!1]]]]),t("kurt",(function(r){var n=r.length,e=M(r),u=$(r,n-1,e),t=Math.sqrt(u);return n*(n+1)/((n-1)*(n-2)*(n-3))*r.reduce((function(r,n){return r+Math.pow((n-e)/t,4)}),0)-3*Math.pow(n-1,2)/((n-2)*(n-3))})).args([["numbers",["collect","number"]],["?",["assert","$numbers.length >= 4","NUM"]]]);var U=[["array",["collect","number",1]],["x","number"],["significance",["or",["null",3],"integer++"]],["?",["assert","$array.length > 0","NUM"]]];function k(r,n,e){for(var u=0,t=M(r),a=M(n),i=r.length,o=0;o<i;++o)u+=(r[o]-t)*(n[o]-a);return u/e}t("percentrank.inc",(function(r,n,e){var u=N(r,n,0);return u=u.toFixed(e+1),parseFloat(u.substr(0,u.length-1))})).args(U),t("percentrank.exc",(function(r,n,e){var u=N(r,n,1);return u=u.toFixed(e+1),parseFloat(u.substr(0,u.length-1))})).args(U),a("percentrank","percentrank.inc"),t("covariance.p",(function(r,n){return k(r,n,r.length)})).args([["array1",["collect","number",1]],["array2",["collect","number",1]],["?",["assert","$array1.length == $array2.length","N/A"]],["?",["assert","$array1.length > 0","DIV/0"]]]),t("covariance.s",(function(r,n){return k(r,n,r.length-1)})).args([["array1",["collect","number",1]],["array2",["collect","number",1]],["?",["assert","$array1.length == $array2.length","N/A"]],["?",["assert","$array1.length > 1","DIV/0"]]]),a("covar","covariance.p");var R=r.memoize((function(r){for(var n=2,e=1;n<=r;++n)e*=n;return e}));t("fact",R).args([["*n","integer+"]]),t("factdouble",(function(r){for(var n=2+(1&r),e=1;n<=r;n+=2)e*=n;return e})).args([["*n","integer+"]]),t("multinomial",(function(r){var n=1,e=0;return r.forEach((function(r){if(r<0)throw new i("NUM");e+=r,n*=R(r)})),R(e)/n})).args([["numbers",["collect","number"]]]);var I=r.memoize((function(r,n){for(var e=n+1,u=1,t=1,a=1;u<=r-n;++e,++u)t*=e,a*=u;return t/a}));function V(r,n){r.sort(Y);var e=r.length,u=0|n,t=n-u;return 0===u?r[0]:u>=e?r[e-1]:r[--u]+t*(r[u+1]-r[u])}function _(r,n){return V(r,n*(r.length-1)+1)}function T(r,n){return V(r,n*(r.length+1))}t("combin",I).args([["*n","integer++"],["*k",["and","integer",["[between]",0,"$n"]]]]),t("combina",(function(r,n){return I(r+n-1,r-1)})).args([["*n","integer++"],["*k",["and","integer",["[between]",1,"$n"]]]]),t("average",(function(r){return r.reduce((function(r,n){return r+n}),0)/r.length})).args([["numbers",["collect","number!"]],["?",["assert","$numbers.length > 0","DIV/0"]]]),t("averagea",(function(r){var n=0,e=0;return r.forEach((function(r){"string"!=typeof r&&(n+=r),++e})),e?n/e:new i("DIV/0")})).args([["values",["collect","anyvalue"]]]),t("percentile.inc",_).args([["numbers",["collect","number",1]],["p",["and","number",["[between]",0,1]]]]),t("percentile.exc",T).args([["numbers",["collect","number",1]],["p",["and","number",["(between)",0,1]]]]),t("quartile.inc",(function(r,n){return _(r,n/4)})).args([["numbers",["collect","number",1]],["quarter",["values",0,1,2,3,4]]]),t("quartile.exc",(function(r,n){return T(r,n/4)})).args([["numbers",["collect","number",1]],["quarter",["values",0,1,2,3,4]]]),a("quartile","quartile.inc"),a("percentile","percentile.inc");var q=["AVERAGE","COUNT","COUNTA","MAX","MIN","PRODUCT","STDEV.S","STDEV.P","SUM","VAR.S","VAR.P","MEDIAN","MODE.SNGL","LARGE","SMALL","PERCENTILE.INC","QUARTILE.INC","PERCENTILE.EXC","QUARTILE.EXC"];function S(r,n,e){var u=[];return function n(t){if(t instanceof l)r.getRefCells(t,!0).forEach((function(r){var n=r.value;if(!(1&e&&r.hidden)){if(r.formula){var t=r.formula.print(r.row,r.col);if(/^\s*(?:aggregate|subtotal)\s*\(/i.test(t)&&!(4&e))return}2&e&&n instanceof i||("number"==typeof n||n instanceof i)&&u.push(n)}}));else if(Array.isArray(t))for(var a=0;a<t.length;++a)n(t[a]);else t instanceof f?t.each(n):("number"==typeof t||t instanceof i&&!(2&e))&&u.push(t)}(n),u}function O(r,n,e,u){if(u){for(var t=0,a=0;a<=r;++a)t+=I(n,a)*Math.pow(e,a)*Math.pow(1-e,n-a);return t}return I(n,r)*Math.pow(e,r)*Math.pow(1-e,n-r)}function P(r){var n=F(h(r,0,1));return 4==n.day||3==n.day&&u.isLeapYear(r)?53:52}function j(r,n,e){var u=F(r),t=F(n);return e?(31==u.date&&(u.date=30),31==t.date&&(t.date=30)):(1==u.month&&1==t.month&&u.date==m(u.year,1)&&t.date==m(t.year,1)&&(t.date=30),u.date==m(u.year,u.month)?(u.date=30,31==t.date&&(t.date=30)):30==u.date&&31==t.date&&(t.date=30)),360*(t.year-u.year)+30*(t.month-u.month)+(t.date-u.date)}t("aggregate",(function(r,n,e,u){var t=this;t.resolveCells(u,(function(){var a;if(n>12){a=S(t,u[0],e);var o=u[1];if(o instanceof s&&(o=t.getRefData(o)),"number"!=typeof o)return r(new i("VALUE"))}else a=S(t,u,e);t.func(q[n-1],r,a)}))})).argsAsync([["funcId",["values",1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19]],["options",["or",["null",0],["values",0,1,2,3,4,5,6,7]]],["args","rest"]]),t("subtotal",(function(r,n){var e=this,u=n>100;u&&(n-=100);for(var t=[],a=2;a<arguments.length;++a)t.push(arguments[a]);e.resolveCells(t,(function(){var a=S(e,t,u?1:0);e.func(q[n-1],r,a)}))})).argsAsync([["funcId",["values",1,2,3,4,5,6,7,8,9,10,11,101,102,103,104,105,106,107,108,109,110,111]],["+",["ref",["or","ref","#matrix"]]]]),t("avedev",(function(r){var n=r.reduce((function(r,n){return r+n}),0)/r.length;return r.reduce((function(r,e){return r+Math.abs(e-n)}),0)/r.length})).args([["numbers",["collect","number"]],["?",["assert","$numbers.length >= 2","NUM"]]]),t("binom.dist",O).args([["successes","integer+"],["trials",["and","integer",["assert","$trials >= $successes"]]],["probability",["and","number",["[between]",0,1]]],["cumulative","logical"]]),a("binomdist","binom.dist"),t("binom.inv",(function(r,n,e){for(var u=0;u<=r;++u)if(O(u,r,n,!0)>=e)return u;return new i("N/A")})).args([["trials","integer+"],["probability",["and","number",["[between]",0,1]]],["alpha",["and","number",["[between]",0,1]]]]),a("critbinom","binom.inv"),t("binom.dist.range",(function(r,n,e,u){for(var t=0,a=e;a<=u;++a)t+=I(r,a)*Math.pow(n,a)*Math.pow(1-n,r-a);return t})).args([["trials","integer+"],["probability",["and","number",["[between]",0,1]]],["successes_min",["and","integer",["[between]",0,"$trials"]]],["successes_max",["or",["and","integer",["[between]","$successes_min","$trials"]],["null","$successes_min"]]]]),t("negbinom.dist",(function(r,n,e,u){if(u){for(var t=0;r>=0;)t+=I(r+n-1,r)*Math.pow(e,n)*Math.pow(1-e,r),r--;return t}return I(r+n-1,r)*Math.pow(e,n)*Math.pow(1-e,r)})).args([["number_f","integer+"],["number_s","integer+"],["probability_s",["and","number",["[between]",0,1]]],["cumulative","logical"]]),a("negbinomdist","negbinom.dist"),t("address",(function(r,n,e,u,t){var a=new s(r-1,n-1,e-1);return t&&a.setSheet(t,!0),u?a.print(0,0):a.print()})).args([["row","integer++"],["col","integer++"],["abs",["or",["null",1],["values",1,2,3,4]]],["a1",["or",["null",!0],"logical"]],["sheet",["or","null","string"]]]),t("areas",(function(r){var n=0;return function r(e){e instanceof s||e instanceof o?n++:e instanceof c&&e.refs.forEach(r)}(r),n})).args([["ref","ref"]]),t("choose",(function(r,n){return r>n.length?new i("N/A"):n[r-1]})).args([["*index","integer"],["+",["value","anything"]]]),t("column",(function(r){return r?r instanceof s?r.col+1:this.asMatrix(r).mapCol((function(n){return n+r.topLeft.col+1})):this.formula.col+1})).args([["ref",["or","area","null"]]]),t("columns",(function(r){return r instanceof l?r.width():r.width})).args([["ref",["or","area","#matrix"]]]),t("formulatext",(function(r){var n=this.getRefCells(r)[0];return n.formula?n.formula.print(n.row,n.col):new i("N/A")})).args([["ref","ref"]]),t("hlookup",(function(r,n,e,u){var t=null;return n.eachCol((function(e){var a=n.get(0,e);if(u){if(a>r)return!0;t=e}else if(a===r)return t=e,!0})),null==t?new i("N/A"):n.get(e-1,t)})).args([["value","anyvalue"],["range","matrix"],["row","integer++"],["approx",["or","logical",["null",!0]]]]),t("index",(function(r,n,e,u,t){var a=this;if(n instanceof c&&(n=n.refs[t-1]),!e&&!u||!n)return r(new i("N/A"));if(n instanceof s&&(n=n.toRangeRef()),n instanceof o){if(e&&u){if(u>n.width()||e>n.height())return r(new i("REF"));var l=n.toCell(e-1,u-1);return void a.resolveCells([l],(function(){r(a.getRefData(l))}))}if(!e){var g=n.toColumn(u-1);return void a.resolveCells([g],(function(){r(a.asMatrix(g))}))}if(!u){var m=n.toRow(e-1);return void a.resolveCells([m],(function(){r(a.asMatrix(m))}))}}else if(n instanceof f){if(n.width>1&&n.height>1){if(e&&u)return r(n.get(e-1,u-1));if(!e)return r(n.mapRow((function(r){return n.get(r,u-1)})));if(!u)return r(n.mapCol((function(r){return n.get(e-1,r)})))}if(1==n.width)return r(n.get(e-1,0));if(1==n.height)return r(n.get(0,u-1))}else r(new i("REF"))})).argsAsync([["range",["or","ref","matrix"]],["row",["or","integer+","null"]],["col",["or","integer+","null"]],["areanum",["or","integer++",["null",1]]]]),t("indirect",(function(r){try{var n=this.formula,u=e.parseFormula(n.sheet,n.row,n.col,r).ast;if(u instanceof g&&(u=this.ss.nameValue(u,n.sheet,n.row,n.col)),!(u instanceof l))throw 1;return u.absolute(n.row,n.col)}catch(r){return new i("REF")}})).args([["thing","string"]]),t("match",(function(r,n,e){var u,t=1;return 0===e?u=z(r):-1===e?u=z("<="+r):1===e&&(u=z(">="+r)),n.each((function(n){if(null!=n&&u(n))return 0!==e&&r!=n&&--t,!0;t++}),!0)&&t>0?t:new i("N/A")})).args([["value","anyvalue"],["range","matrix"],["type",["or",["values",-1,0,1],["null",1]]]]),t("offset",(function(r,n,e,u,t){var a=(r instanceof s?r:r.topLeft).clone();return a.row+=n,a.col+=e,a.row<0||a.col<0?new i("VALUE"):u>1||t>1?new o(a,new s(a.row+u-1,a.col+t-1)).setSheet(r.sheet,r.hasSheet()):a})).args([["ref","area"],["*rows","integer"],["*cols","integer"],["*height",["or","integer++",["null","$ref.height()"]]],["*width",["or","integer++",["null","$ref.width()"]]]]),t("row",(function(r){return r?r instanceof s?r.row+1:this.asMatrix(r).mapRow((function(n){return n+r.topLeft.row+1})):this.formula.row+1})).args([["ref",["or","area","null"]]]),t("rows",(function(r){return r instanceof l?r.height():r.height})).args([["ref",["or","area","#matrix"]]]),t("vlookup",(function(r,n,e,u){var t=null;return"number"!=typeof r&&(u=!1),"string"==typeof r&&(r=r.toLowerCase()),n.eachRow((function(e){var a=n.get(e,0);if(u){if(a>r)return!0;t=e}else if("string"==typeof a&&(a=a.toLowerCase()),a===r)return t=e,!0})),null==t?new i("N/A"):n.get(t,e-1)})).args([["value","anyvalue"],["range","matrix"],["col","integer++"],["approx",["or","logical",["null",!0]]]]),t("date",(function(r,n,e){return h(r,n-1,e)})).args([["*year","integer"],["*month","integer"],["*date","integer"]]),t("day",(function(r){return F(r).date})).args([["*date","date"]]),t("month",(function(r){return F(r).month+1})).args([["*date","date"]]),t("year",(function(r){return F(r).year})).args([["*date","date"]]),t("weekday",(function(r){return F(r).day+1})).args([["*date","date"]]),t("weeknum",(function(r,n){var e,u=h(F(r).year,0,1),t=F(u);return 21==n?((e=3-(t.day+6)%7)<0&&(e+=7),u+=e,t.date+=e,t.day=4,n=1):n=1==n?0:2==n?1:(n-10)%7,(e=t.day-n)<0&&(e+=7),u-=e,Math.ceil((r+1-u)/7)})).args([["*date","date"],["*type",["or",["null",1],["values",1,2,11,12,13,14,15,16,17,21]]]]),t("isoweeknum",(function(r){var n=F(r),e=n.day||7,u=Math.floor((n.ord-e+10)/7);return u<1?P(n.year-1):53==u&&u>P(n.year)?1:u})).args([["*date","date"]]),t("now",(function(){return u.dateToSerial(new Date)})).args([]),t("today",(function(){return 0|u.dateToSerial(new Date)})).args([]),t("time",(function(r,n,e){return u.packTime(r,n,e,0)})).args([["*hours","integer"],["*minutes","integer"],["*seconds","integer"]]),t("hour",(function(r){return u.unpackTime(r).hours})).args([["*time","datetime"]]),t("minute",(function(r){return u.unpackTime(r).minutes})).args([["*time","datetime"]]),t("second",(function(r){return u.unpackTime(r).seconds})).args([["*time","datetime"]]),t("edate",(function(r,n){var e=F(r),u=e.month+n,t=e.year+Math.floor(u/12);return(u%=12)<0&&(u+=12),e=Math.min(e.date,m(t,u)),h(t,u,e)})).args([["*start_date","date"],["*months","integer"]]),t("eomonth",(function(r,n){var e=F(r),u=e.month+n,t=e.year+Math.floor(u/12);return(u%=12)<0&&(u+=12),e=m(t,u),h(t,u,e)})).args([["*start_date","date"],["*months","integer"]]),t("workday",(function(r,n,e){var u=n>0?1:-1;n=Math.abs(n);for(var t=F(r).day;n>0;)r+=u,(t=(t+u)%7)>0&&t<6&&e.indexOf(r)<0&&--n;return r})).args([["start_date","date"],["days","integer"],["holidays",["collect","date"]]]),t("networkdays",(function(r,n,e){if(r>n){var u=r;r=n,n=u}for(var t=0,a=F(r).day;r<=n;)a>0&&a<6&&e.indexOf(r)<0&&t++,r++,a=(a+1)%7;return t})).args([["start_date","date"],["end_date","date"],["holidays",["collect","date"]]]),t("days",(function(r,n){return n-r})).args([["*start_date","date"],["*end_date","date"]]),u._days_360=j,t("days360",j).args([["*start_date","date"],["*end_date","date"],["*method",["or","logical",["null",!1]]]]),t("yearfrac",(function(r,n,e){switch(e){case 0:return j(r,n,!1)/360;case 1:return(n-r)/b(F(r).year);case 2:return(n-r)/360;case 3:return(n-r)/365;case 4:return j(r,n,!0)/360}})).args([["*start_date","date"],["*end_date","date"],["*method",["or",["null",0],["values",0,1,2,3,4]]]]),t("datevalue",(function(r){var n=u.parseDate(r);return n?u.dateToSerial(n):new i("VALUE")})).args([["*text","string"]]),t("timevalue",(function(r){var n=r.toLowerCase().match(/(\d+):(\d+)(:(\d+)(\.(\d+))?)?\s*(am?|pm?)?/);if(n){var e=parseFloat(n[1]),t=parseFloat(n[2]),a=n[3]?parseFloat(n[4]):0,o=n[7];return o&&(e>12||e<1)?new i("VALUE"):(/^p/.test(o)&&(e+=12),u.packTime(e,t,a,0))}return new i("VALUE")})).args([["*text","string"]]),t("mdeterm",(function(r){return r.each((function(r){if("number"!=typeof r)return new i("VALUE")}),!0)||r.determinant()})).args([["m",["and","matrix",["assert","$m.width == $m.height"]]]]),t("transpose",(function(r){return r.transpose()})).args([["range","matrix"]]),t("mmult",(function(r,n){return r.multiply(n)})).args([["a","matrix"],["b",["and","matrix",["assert","$b.height == $a.width"]]]]),t("munit",(function(r){return new f(this).unit(r)})).args([["n","integer+"]]),t("minverse",(function(r){return r.each((function(r){if("number"!=typeof r)return new i("VALUE")}),!0)||r.inverse()||new i("VALUE")})).args([["m",["and","matrix",["assert","$m.width == $m.height"]]]]),t("rand",(function(){return Math.random()})).args([]),t("randbetween",(function(r,n){return r+Math.floor((n-r+1)*Math.random())})).args([["min","integer"],["max",["and","integer",["assert","$max >= $min"]]]]),t("true",(function(){return!0})).args([]),t("false",(function(){return!0})).args([]),t("roman",(function(n){return r.arabicToRoman(n).toUpperCase()})).args([["*number","integer"]]),t("arabic",(function(n){var e=r.romanToArabic(n);return null==e?new i("VALUE"):e})).args([["*roman","string"]]),t("base",(function(r,n,e){for(var u=r.toString(n).toUpperCase();u.length<e;)u="0"+u;return u})).args([["*number","integer"],["*radix",["and","integer",["[between]",2,36]]],["*minLen",["or","integer+",["null",0]]]]),t("decimal",(function(r,n){r=r.toUpperCase();for(var e=0,u=0;u<r.length;++u){var t=r.charCodeAt(u);if(t>=48&&t<=57)t-=48;else{if(!(t>=65&&t<55+n))return new i("VALUE");t-=55}e=e*n+t}return e})).args([["*text","string"],["*radix",["and","integer",["[between]",2,36]]]]),t("char",(function(r){return String.fromCharCode(r)})).args([["*code","integer+"]]);var G=/[\0-\x1F\x7F-\x9F\xAD\u0378\u0379\u037F-\u0383\u038B\u038D\u03A2\u0528-\u0530\u0557\u0558\u0560\u0588\u058B-\u058E\u0590\u05C8-\u05CF\u05EB-\u05EF\u05F5-\u0605\u061C\u061D\u06DD\u070E\u070F\u074B\u074C\u07B2-\u07BF\u07FB-\u07FF\u082E\u082F\u083F\u085C\u085D\u085F-\u089F\u08A1\u08AD-\u08E3\u08FF\u0978\u0980\u0984\u098D\u098E\u0991\u0992\u09A9\u09B1\u09B3-\u09B5\u09BA\u09BB\u09C5\u09C6\u09C9\u09CA\u09CF-\u09D6\u09D8-\u09DB\u09DE\u09E4\u09E5\u09FC-\u0A00\u0A04\u0A0B-\u0A0E\u0A11\u0A12\u0A29\u0A31\u0A34\u0A37\u0A3A\u0A3B\u0A3D\u0A43-\u0A46\u0A49\u0A4A\u0A4E-\u0A50\u0A52-\u0A58\u0A5D\u0A5F-\u0A65\u0A76-\u0A80\u0A84\u0A8E\u0A92\u0AA9\u0AB1\u0AB4\u0ABA\u0ABB\u0AC6\u0ACA\u0ACE\u0ACF\u0AD1-\u0ADF\u0AE4\u0AE5\u0AF2-\u0B00\u0B04\u0B0D\u0B0E\u0B11\u0B12\u0B29\u0B31\u0B34\u0B3A\u0B3B\u0B45\u0B46\u0B49\u0B4A\u0B4E-\u0B55\u0B58-\u0B5B\u0B5E\u0B64\u0B65\u0B78-\u0B81\u0B84\u0B8B-\u0B8D\u0B91\u0B96-\u0B98\u0B9B\u0B9D\u0BA0-\u0BA2\u0BA5-\u0BA7\u0BAB-\u0BAD\u0BBA-\u0BBD\u0BC3-\u0BC5\u0BC9\u0BCE\u0BCF\u0BD1-\u0BD6\u0BD8-\u0BE5\u0BFB-\u0C00\u0C04\u0C0D\u0C11\u0C29\u0C34\u0C3A-\u0C3C\u0C45\u0C49\u0C4E-\u0C54\u0C57\u0C5A-\u0C5F\u0C64\u0C65\u0C70-\u0C77\u0C80\u0C81\u0C84\u0C8D\u0C91\u0CA9\u0CB4\u0CBA\u0CBB\u0CC5\u0CC9\u0CCE-\u0CD4\u0CD7-\u0CDD\u0CDF\u0CE4\u0CE5\u0CF0\u0CF3-\u0D01\u0D04\u0D0D\u0D11\u0D3B\u0D3C\u0D45\u0D49\u0D4F-\u0D56\u0D58-\u0D5F\u0D64\u0D65\u0D76-\u0D78\u0D80\u0D81\u0D84\u0D97-\u0D99\u0DB2\u0DBC\u0DBE\u0DBF\u0DC7-\u0DC9\u0DCB-\u0DCE\u0DD5\u0DD7\u0DE0-\u0DF1\u0DF5-\u0E00\u0E3B-\u0E3E\u0E5C-\u0E80\u0E83\u0E85\u0E86\u0E89\u0E8B\u0E8C\u0E8E-\u0E93\u0E98\u0EA0\u0EA4\u0EA6\u0EA8\u0EA9\u0EAC\u0EBA\u0EBE\u0EBF\u0EC5\u0EC7\u0ECE\u0ECF\u0EDA\u0EDB\u0EE0-\u0EFF\u0F48\u0F6D-\u0F70\u0F98\u0FBD\u0FCD\u0FDB-\u0FFF\u10C6\u10C8-\u10CC\u10CE\u10CF\u1249\u124E\u124F\u1257\u1259\u125E\u125F\u1289\u128E\u128F\u12B1\u12B6\u12B7\u12BF\u12C1\u12C6\u12C7\u12D7\u1311\u1316\u1317\u135B\u135C\u137D-\u137F\u139A-\u139F\u13F5-\u13FF\u169D-\u169F\u16F1-\u16FF\u170D\u1715-\u171F\u1737-\u173F\u1754-\u175F\u176D\u1771\u1774-\u177F\u17DE\u17DF\u17EA-\u17EF\u17FA-\u17FF\u180F\u181A-\u181F\u1878-\u187F\u18AB-\u18AF\u18F6-\u18FF\u191D-\u191F\u192C-\u192F\u193C-\u193F\u1941-\u1943\u196E\u196F\u1975-\u197F\u19AC-\u19AF\u19CA-\u19CF\u19DB-\u19DD\u1A1C\u1A1D\u1A5F\u1A7D\u1A7E\u1A8A-\u1A8F\u1A9A-\u1A9F\u1AAE-\u1AFF\u1B4C-\u1B4F\u1B7D-\u1B7F\u1BF4-\u1BFB\u1C38-\u1C3A\u1C4A-\u1C4C\u1C80-\u1CBF\u1CC8-\u1CCF\u1CF7-\u1CFF\u1DE7-\u1DFB\u1F16\u1F17\u1F1E\u1F1F\u1F46\u1F47\u1F4E\u1F4F\u1F58\u1F5A\u1F5C\u1F5E\u1F7E\u1F7F\u1FB5\u1FC5\u1FD4\u1FD5\u1FDC\u1FF0\u1FF1\u1FF5\u1FFF\u200B-\u200F\u202A-\u202E\u2060-\u206F\u2072\u2073\u208F\u209D-\u209F\u20BB-\u20CF\u20F1-\u20FF\u218A-\u218F\u23F4-\u23FF\u2427-\u243F\u244B-\u245F\u2700\u2B4D-\u2B4F\u2B5A-\u2BFF\u2C2F\u2C5F\u2CF4-\u2CF8\u2D26\u2D28-\u2D2C\u2D2E\u2D2F\u2D68-\u2D6E\u2D71-\u2D7E\u2D97-\u2D9F\u2DA7\u2DAF\u2DB7\u2DBF\u2DC7\u2DCF\u2DD7\u2DDF\u2E3C-\u2E7F\u2E9A\u2EF4-\u2EFF\u2FD6-\u2FEF\u2FFC-\u2FFF\u3040\u3097\u3098\u3100-\u3104\u312E-\u3130\u318F\u31BB-\u31BF\u31E4-\u31EF\u321F\u32FF\u4DB6-\u4DBF\u9FCD-\u9FFF\uA48D-\uA48F\uA4C7-\uA4CF\uA62C-\uA63F\uA698-\uA69E\uA6F8-\uA6FF\uA78F\uA794-\uA79F\uA7AB-\uA7F7\uA82C-\uA82F\uA83A-\uA83F\uA878-\uA87F\uA8C5-\uA8CD\uA8DA-\uA8DF\uA8FC-\uA8FF\uA954-\uA95E\uA97D-\uA97F\uA9CE\uA9DA-\uA9DD\uA9E0-\uA9FF\uAA37-\uAA3F\uAA4E\uAA4F\uAA5A\uAA5B\uAA7C-\uAA7F\uAAC3-\uAADA\uAAF7-\uAB00\uAB07\uAB08\uAB0F\uAB10\uAB17-\uAB1F\uAB27\uAB2F-\uABBF\uABEE\uABEF\uABFA-\uABFF\uD7A4-\uD7AF\uD7C7-\uD7CA\uD7FC-\uF8FF\uFA6E\uFA6F\uFADA-\uFAFF\uFB07-\uFB12\uFB18-\uFB1C\uFB37\uFB3D\uFB3F\uFB42\uFB45\uFBC2-\uFBD2\uFD40-\uFD4F\uFD90\uFD91\uFDC8-\uFDEF\uFDFE\uFDFF\uFE1A-\uFE1F\uFE27-\uFE2F\uFE53\uFE67\uFE6C-\uFE6F\uFE75\uFEFD-\uFF00\uFFBF-\uFFC1\uFFC8\uFFC9\uFFD0\uFFD1\uFFD8\uFFD9\uFFDD-\uFFDF\uFFE7\uFFEF-\uFFFB\uFFFE\uFFFF]/g;function X(r,n){this.link=r,this.text=n}t("clean",(function(r){return r.replace(G,"")})).args([["*text","string"]]),t("code",(function(r){return r.charAt(0)})).args([["*text","string"]]),a("unichar","char"),a("unicode","code"),t("concatenate",(function(r){for(var n="",e=0;e<r.length;++e)n+=r[e];return n})).args([["+",["*text","string"]]]),t("dollar",(function(r,e){for(var u="$#,##0DECIMALS;($#,##0DECIMALS)",t="",a=1;e-- >0;)t+="0";for(;++e<0;)a*=10;return""!==t?t="."+t:1!==a&&(r=Math.round(r/a)*a),u=u.replace(/DECIMALS/g,t),n.formatting.text(r,u)})).args([["*number","number"],["*decimals",["or","integer",["null",2]]]]),t("exact",(function(r,n){return r===n})).args([["*text1","string"],["*text2","string"]]),t("find",(function(r,n,e){var u=n.indexOf(r,e-1);return u<0?new i("VALUE"):u+1})).args([["*substring","string"],["*string","string"],["*start",["or","integer++",["null",1]]]]),t("fixed",(function(r,e,u){var t=Math.pow(10,e);r=Math.round(r*t)/t;var a=u?"0":"#,##0";if(e>0)for(a+=".";e-- >0;)a+="0";return n.formatting.text(r,a)})).args([["*number","number"],["*decimals",["or","integer",["null",2]]],["*noCommas",["or","boolean",["null",!1]]]]),t("left",(function(r,n){return r.substr(0,n)})).args([["*text","string"],["*length",["or","integer+",["null",1]]]]),t("right",(function(r,n){return r.substr(-n)})).args([["*text","string"],["*length",["or","integer+",["null",1]]]]),t("len",(function(r){return r.length})).args([["*text","string"]]),t("lower",(function(r){return r.toLowerCase()})).args([["*text","string"]]),t("upper",(function(r){return r.toUpperCase()})).args([["*text","string"]]),t("ltrim",(function(r){return r.replace(/^\s+/,"")})).args([["*text","string"]]),t("rtrim",(function(r){return r.replace(/\s+$/,"")})).args([["*text","string"]]),t("trim",(function(r){return r.replace(/^\s+|\s+$/,"")})).args([["*text","string"]]),t("mid",(function(r,n,e){return r.substr(n-1,e)})).args([["*text","string"],["*start","integer++"],["*length","integer+"]]),t("proper",(function(r){return r.toLowerCase().replace(/\b./g,(function(r){return r.toUpperCase()}))})).args([["*text","string"]]),t("replace",(function(r,n,e,u){return r.substr(0,--n)+u+r.substr(n+e)})).args([["*text","string"],["*start","integer++"],["*length","integer+"],["*newText","string"]]),t("rept",(function(r,n){for(var e="";n-- >0;)e+=r;return e})).args([["*text","string"],["*number","integer+"]]),t("search",(function(r,n,e){var u=n.toLowerCase().indexOf(r.toLowerCase(),e-1);return u<0?new i("VALUE"):u+1})).args([["*substring","string"],["*string","string"],["*start",["or","integer++",["null",1]]]]),t("substitute",(function(r,n,e,u){if(n===e)return r;var t=r.split(n);if(null==u)return t.join(e);r="",u--;for(var a=0;a<t.length;++a)r+=t[a],a<t.length-1&&(r+=a===u?e:n);return r})).args([["*text","string"],["*oldText","string"],["*newText","string"],["*nth",["or","integer++","null"]]]),t("t",(function(r){return"string"==typeof r?r:""})).args([["*value","anyvalue"]]),t("text",(function(r,e){return n.formatting.text(r,e)})).args([["*value","anyvalue"],["*format","string"]]),t("value",(function(r){return"number"==typeof r?r:"boolean"==typeof r?+r:(r=(r+"").replace(/[$€,]/g,""),r=parseFloat(r),isNaN(r)?new i("VALUE"):r)})).args([["*value","anyvalue"]]),X.prototype.toString=function(){return this.text},t("hyperlink",(function(r,n){return new X(r,n)})).args([["*link","string"],["*text",["or","string",["null","$link"]]]]),t("iferror",(function(r,n){return r instanceof i?n:r})).args([["*value","forced!"],["*value_if_error","anyvalue!"]]);var z=function(){var r=Object.create(null);function n(r,n){if("string"==typeof n){var e=parseFloat(n);isNaN(e)||e!=n||(n=e)}return function(e){var u=n;return"string"==typeof e&&"string"==typeof u&&(e=e.toLowerCase(),u=u.toLowerCase()),r(e,u)}}function e(r){var n,e;return"string"==typeof r&&(r=r.toLowerCase()),/^[0-9.]+%$/.test(r)?(e=r.substr(0,r.length-1),n=parseFloat(e),isNaN(n)||n!=e||(r=n/100)):/^[0-9.]+$/.test(r)&&(n=parseFloat(r),isNaN(n)||n!=r||(r=n)),r}function u(r,n){return e(r)<e(n)}function t(r,n){return e(r)<=e(n)}function a(r,n){return e(r)>e(n)}function i(r,n){return e(r)>=e(n)}function o(r,n){return!s(r,n)}function s(r,n){return n instanceof RegExp?n.test(r):("string"!=typeof r&&"string"!=typeof n||(r=String(r),n=String(n)),e(r)==e(n))}return function(e){if("function"==typeof e)return e;var c;if(c=/^=(.*)$/.exec(e))return n(s,c[1]);if(c=/^<>(.*)$/.exec(e))return n(o,c[1]);if(c=/^<=(.*)$/.exec(e))return n(t,c[1]);if(c=/^<(.*)$/.exec(e))return n(u,c[1]);if(c=/^>=(.*)$/.exec(e))return n(i,c[1]);if(c=/^>(.*)$/.exec(e))return n(a,c[1]);if(/[?*]/.exec(e)){var f=r[e];return f||(f=e.replace(/(~\?|~\*|[\]({\+\.\|\^\$\\})\[]|[?*])/g,(function(r){switch(r){case"~?":return"\\?";case"~*":return"\\*";case"?":return".";case"*":return".*";default:return"\\"+r}})),f=r[e]=new RegExp("^"+f+"$","i")),n(s,f)}return n(s,e)}}();function Q(r){return"number"==typeof r||"boolean"==typeof r||null==r||""===r}function Y(r,n){return r===n?0:r<n?-1:1}function H(r,n){return r===n?0:r<n?1:-1}})?u.apply(n,t):u)||(r.exports=a)}})}}]);