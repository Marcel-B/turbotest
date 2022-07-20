/*! For license information please see 461.ca72a0b9.chunk.js.LICENSE.txt */
"use strict";(self.webpackChunkidentity=self.webpackChunkidentity||[]).push([[461,610,742,700,51],{6037:function(t,e,r){r.d(e,{X:function(){return o}});var n=r(8701),i=r(5977),o=function(t,e,r){return void 0===e&&(e={}),void 0===r&&(r={}),function(o,a,u){try{return Promise.resolve(function(i,c){try{var s=(e.context,Promise.resolve(t["sync"===r.mode?"validateSync":"validate"](o,Object.assign({abortEarly:!1},e,{context:a}))).then((function(t){return u.shouldUseNativeValidation&&(0,n.validateFieldsNatively)({},u),{values:r.rawValues?o:t,errors:{}}})))}catch(l){return c(l)}return s&&s.then?s.then(void 0,c):s}(0,(function(t){if(!t.inner)throw t;return{values:{},errors:(0,n.toNestError)((e=t,r=!u.shouldUseNativeValidation&&"all"===u.criteriaMode,(e.inner||[]).reduce((function(t,e){if(t[e.path]||(t[e.path]={message:e.message,type:e.type}),r){var n=t[e.path].types,o=n&&n[e.type];t[e.path]=(0,i.appendErrors)(e.path,r,t,e.type,o?[].concat(o,e.message):e.message)}return t}),{})),u)};var e,r})))}catch(c){return Promise.reject(c)}}}},2452:function(t,e,r){var n=r(8655),i=Symbol.for("react.element"),o=Symbol.for("react.fragment"),a=Object.prototype.hasOwnProperty,u=n.__SECRET_INTERNALS_DO_NOT_USE_OR_YOU_WILL_BE_FIRED.ReactCurrentOwner,c={key:!0,ref:!0,__self:!0,__source:!0};function s(t,e,r){var n,o={},s=null,l=null;for(n in void 0!==r&&(s=""+r),void 0!==e.key&&(s=""+e.key),void 0!==e.ref&&(l=e.ref),e)a.call(e,n)&&!c.hasOwnProperty(n)&&(o[n]=e[n]);if(t&&t.defaultProps)for(n in e=t.defaultProps)void 0===o[n]&&(o[n]=e[n]);return{$$typeof:i,type:t,key:s,ref:l,props:o,_owner:u.current}}e.Fragment=o,e.jsx=s,e.jsxs=s},6610:function(t,e,r){t.exports=r(2452)},6461:function(t,e,r){r.r(e);var n=r(9742),i=r(6610),o=r(8641),a=r(8948),u=r(6037),c=r(8871),s=r(3298),l=r(3671),f=function(t,e,r,n){return new(r||(r=Promise))((function(i,o){function a(t){try{c(n.next(t))}catch(e){o(e)}}function u(t){try{c(n.throw(t))}catch(e){o(e)}}function c(t){var e;t.done?i(t.value):(e=t.value,e instanceof r?e:new r((function(t){t(e)}))).then(a,u)}c((n=n.apply(t,e||[])).next())}))},d=s.object({email:s.string().email("email Format").required("ben\xf6tigt"),username:s.string().required("ben\xf6tigt"),displayName:s.string().required("ben\xf6tigt"),password:s.string().required("ben\xf6tigt")}).required();e.default=function(t){var e,r,s,p,h=t.redirectUrl,m=(0,c.useStore)(),y=m.setRedirectUrl,v=m.setUser,g=(0,a.useForm)({resolver:(0,u.X)(d)}),x=g.formState.errors,w=g.handleSubmit,b=g.register;return(0,i.jsxs)(o.Box,{children:[(0,i.jsx)(o.Typography,Object.assign({variant:"h4"},{children:"Registrieren"})),(0,i.jsx)(o.Divider,{orientation:"horizontal",sx:{mb:2}}),(0,i.jsx)("form",Object.assign({onSubmit:w((function(t){return f(void 0,void 0,void 0,(0,n.Z)().mark((function e(){var r;return(0,n.Z)().wrap((function(e){for(;;)switch(e.prev=e.next){case 0:if(!t){e.next=6;break}return e.next=3,l.Z.AccountCall.register(t);case 3:r=e.sent,v(r),y(h);case 6:case"end":return e.stop()}}),e)})))}))},{children:(0,i.jsxs)(o.Grid,Object.assign({container:!0,spacing:2,sx:{justifyContent:"flex-end"}},{children:[(0,i.jsx)(o.Grid,Object.assign({item:!0,md:6,xs:12},{children:(0,i.jsx)(o.TextField,Object.assign({label:"Email",type:"text",autoComplete:"username",defaultValue:"",error:!!x.email},b("email"),{helperText:null===(e=x.email)||void 0===e?void 0:e.message,fullWidth:!0,name:"email"}))})),(0,i.jsx)(o.Grid,Object.assign({item:!0,md:6,xs:12},{children:(0,i.jsx)(o.TextField,Object.assign({label:"Benutzername",type:"text",autoComplete:"username",error:!!x.username,fullWidth:!0},b("username"),{helperText:null===(r=x.username)||void 0===r?void 0:r.message,defaultValue:"",name:"username"}))})),(0,i.jsx)(o.Grid,Object.assign({item:!0,md:6,xs:12},{children:(0,i.jsx)(o.TextField,Object.assign({label:"Anzeigename",type:"text",autoComplete:"current-display-name",error:!!x.displayName,fullWidth:!0},b("displayName"),{helperText:null===(s=x.displayName)||void 0===s?void 0:s.message,defaultValue:"",name:"displayName"}))})),(0,i.jsx)(o.Grid,Object.assign({item:!0,md:6,xs:12},{children:(0,i.jsx)(o.TextField,Object.assign({label:"Passwort",type:"password",autoComplete:"current-password",error:!!x.password,fullWidth:!0},b("password"),{helperText:null===(p=x.password)||void 0===p?void 0:p.message,defaultValue:"",name:"password"}))})),(0,i.jsx)(o.Grid,Object.assign({item:!0},{children:(0,i.jsx)(o.Button,Object.assign({type:"submit"},{children:"Registrieren"}))}))]}))}))]})}},3671:function(t,e,r){var n=r(6969),i=r.n(n),o=function(t){return t.data};i().defaults.baseURL="http://localhost:5046",i().interceptors.request.use((function(t){var e=window.localStorage.getItem("token");return e&&t.headers&&(t.headers.Authorization="Bearer ".concat(e)),t}));var a=function(t){return i().get(t).then(o)},u=function(t,e){return i().post(t,e).then(o)},c=function(t,e){return i().put(t,e).then(o)},s=function(t){return i().delete(t).then(o)},l={AquariumCall:{list:function(){return a("/api/aquarium")},create:function(t){return u("/api/aquarium",t)},read:function(t){return a("/api/aquarium/".concat(t))},update:function(t){return c("/api/aquarium/".concat(t.id),t)},delete:function(t){return s("/api/aquarium/".concat(t))}},AccountCall:{current:function(){return a("/api/account")},login:function(t){return u("/api/account/login",t)},register:function(t){return u("/api/account/register",t)}},DuengungCall:{list:function(){return a("/api/duengung")},create:function(t){return u("/api/duengung",t)},update:function(t){return c("/api/duengung/".concat(t.id),t)},delete:function(t){return s("/api/duengung/".concat(t))}},FeedCall:{list:function(t,e){return a("/api/feed/grouped?page=".concat(t,"&days=").concat(e))}},FischCall:{list:function(){return a("/api/fisch")},create:function(t){return u("/api/fisch",t)},read:function(t){return a("/api/fisch/".concat(t))},update:function(t){return c("/api/fisch/".concat(t.id),t)},delete:function(t){return s("/api/fisch/".concat(t))}},KoralleCall:{list:function(){return a("/api/koralle")},create:function(t){return u("/api/koralle",t)},read:function(t){return a("/api/koralle/".concat(t))},update:function(t){return c("/api/koralle/".concat(t.id),t)},delete:function(t){return s("/api/koralle/".concat(t))}},MessungCall:{list:function(){return a("/api/messung")},create:function(t){return u("/api/messung",t)},update:function(t){return c("/api/messung/".concat(t.id),t)},delete:function(t){return s("/api/messung/".concat(t))}},NotizCall:{list:function(){return a("/api/notiz")},create:function(t){return u("/api/notiz",t)},read:function(t){return a("/api/notiz/".concat(t))},update:function(t){return c("/api/notiz/".concat(t.id),t)},delete:function(t){return s("/api/notiz/".concat(t))}}};e.Z=l},9742:function(t,e,r){r.d(e,{Z:function(){return i}});var n=r(5700);function i(){i=function(){return t};var t={},e=Object.prototype,r=e.hasOwnProperty,o="function"==typeof Symbol?Symbol:{},a=o.iterator||"@@iterator",u=o.asyncIterator||"@@asyncIterator",c=o.toStringTag||"@@toStringTag";function s(t,e,r){return Object.defineProperty(t,e,{value:r,enumerable:!0,configurable:!0,writable:!0}),t[e]}try{s({},"")}catch(S){s=function(t,e,r){return t[e]=r}}function l(t,e,r,n){var i=e&&e.prototype instanceof p?e:p,o=Object.create(i.prototype),a=new L(n||[]);return o._invoke=function(t,e,r){var n="suspendedStart";return function(i,o){if("executing"===n)throw new Error("Generator is already running");if("completed"===n){if("throw"===i)throw o;return k()}for(r.method=i,r.arg=o;;){var a=r.delegate;if(a){var u=j(a,r);if(u){if(u===d)continue;return u}}if("next"===r.method)r.sent=r._sent=r.arg;else if("throw"===r.method){if("suspendedStart"===n)throw n="completed",r.arg;r.dispatchException(r.arg)}else"return"===r.method&&r.abrupt("return",r.arg);n="executing";var c=f(t,e,r);if("normal"===c.type){if(n=r.done?"completed":"suspendedYield",c.arg===d)continue;return{value:c.arg,done:r.done}}"throw"===c.type&&(n="completed",r.method="throw",r.arg=c.arg)}}}(t,r,a),o}function f(t,e,r){try{return{type:"normal",arg:t.call(e,r)}}catch(S){return{type:"throw",arg:S}}}t.wrap=l;var d={};function p(){}function h(){}function m(){}var y={};s(y,a,(function(){return this}));var v=Object.getPrototypeOf,g=v&&v(v(_([])));g&&g!==e&&r.call(g,a)&&(y=g);var x=m.prototype=p.prototype=Object.create(y);function w(t){["next","throw","return"].forEach((function(e){s(t,e,(function(t){return this._invoke(e,t)}))}))}function b(t,e){function i(o,a,u,c){var s=f(t[o],t,a);if("throw"!==s.type){var l=s.arg,d=l.value;return d&&"object"==(0,n.Z)(d)&&r.call(d,"__await")?e.resolve(d.__await).then((function(t){i("next",t,u,c)}),(function(t){i("throw",t,u,c)})):e.resolve(d).then((function(t){l.value=t,u(l)}),(function(t){return i("throw",t,u,c)}))}c(s.arg)}var o;this._invoke=function(t,r){function n(){return new e((function(e,n){i(t,r,e,n)}))}return o=o?o.then(n,n):n()}}function j(t,e){var r=t.iterator[e.method];if(void 0===r){if(e.delegate=null,"throw"===e.method){if(t.iterator.return&&(e.method="return",e.arg=void 0,j(t,e),"throw"===e.method))return d;e.method="throw",e.arg=new TypeError("The iterator does not provide a 'throw' method")}return d}var n=f(r,t.iterator,e.arg);if("throw"===n.type)return e.method="throw",e.arg=n.arg,e.delegate=null,d;var i=n.arg;return i?i.done?(e[t.resultName]=i.value,e.next=t.nextLoc,"return"!==e.method&&(e.method="next",e.arg=void 0),e.delegate=null,d):i:(e.method="throw",e.arg=new TypeError("iterator result is not an object"),e.delegate=null,d)}function O(t){var e={tryLoc:t[0]};1 in t&&(e.catchLoc=t[1]),2 in t&&(e.finallyLoc=t[2],e.afterLoc=t[3]),this.tryEntries.push(e)}function E(t){var e=t.completion||{};e.type="normal",delete e.arg,t.completion=e}function L(t){this.tryEntries=[{tryLoc:"root"}],t.forEach(O,this),this.reset(!0)}function _(t){if(t){var e=t[a];if(e)return e.call(t);if("function"==typeof t.next)return t;if(!isNaN(t.length)){var n=-1,i=function e(){for(;++n<t.length;)if(r.call(t,n))return e.value=t[n],e.done=!1,e;return e.value=void 0,e.done=!0,e};return i.next=i}}return{next:k}}function k(){return{value:void 0,done:!0}}return h.prototype=m,s(x,"constructor",m),s(m,"constructor",h),h.displayName=s(m,c,"GeneratorFunction"),t.isGeneratorFunction=function(t){var e="function"==typeof t&&t.constructor;return!!e&&(e===h||"GeneratorFunction"===(e.displayName||e.name))},t.mark=function(t){return Object.setPrototypeOf?Object.setPrototypeOf(t,m):(t.__proto__=m,s(t,c,"GeneratorFunction")),t.prototype=Object.create(x),t},t.awrap=function(t){return{__await:t}},w(b.prototype),s(b.prototype,u,(function(){return this})),t.AsyncIterator=b,t.async=function(e,r,n,i,o){void 0===o&&(o=Promise);var a=new b(l(e,r,n,i),o);return t.isGeneratorFunction(r)?a:a.next().then((function(t){return t.done?t.value:a.next()}))},w(x),s(x,c,"Generator"),s(x,a,(function(){return this})),s(x,"toString",(function(){return"[object Generator]"})),t.keys=function(t){var e=[];for(var r in t)e.push(r);return e.reverse(),function r(){for(;e.length;){var n=e.pop();if(n in t)return r.value=n,r.done=!1,r}return r.done=!0,r}},t.values=_,L.prototype={constructor:L,reset:function(t){if(this.prev=0,this.next=0,this.sent=this._sent=void 0,this.done=!1,this.delegate=null,this.method="next",this.arg=void 0,this.tryEntries.forEach(E),!t)for(var e in this)"t"===e.charAt(0)&&r.call(this,e)&&!isNaN(+e.slice(1))&&(this[e]=void 0)},stop:function(){this.done=!0;var t=this.tryEntries[0].completion;if("throw"===t.type)throw t.arg;return this.rval},dispatchException:function(t){if(this.done)throw t;var e=this;function n(r,n){return a.type="throw",a.arg=t,e.next=r,n&&(e.method="next",e.arg=void 0),!!n}for(var i=this.tryEntries.length-1;i>=0;--i){var o=this.tryEntries[i],a=o.completion;if("root"===o.tryLoc)return n("end");if(o.tryLoc<=this.prev){var u=r.call(o,"catchLoc"),c=r.call(o,"finallyLoc");if(u&&c){if(this.prev<o.catchLoc)return n(o.catchLoc,!0);if(this.prev<o.finallyLoc)return n(o.finallyLoc)}else if(u){if(this.prev<o.catchLoc)return n(o.catchLoc,!0)}else{if(!c)throw new Error("try statement without catch or finally");if(this.prev<o.finallyLoc)return n(o.finallyLoc)}}}},abrupt:function(t,e){for(var n=this.tryEntries.length-1;n>=0;--n){var i=this.tryEntries[n];if(i.tryLoc<=this.prev&&r.call(i,"finallyLoc")&&this.prev<i.finallyLoc){var o=i;break}}o&&("break"===t||"continue"===t)&&o.tryLoc<=e&&e<=o.finallyLoc&&(o=null);var a=o?o.completion:{};return a.type=t,a.arg=e,o?(this.method="next",this.next=o.finallyLoc,d):this.complete(a)},complete:function(t,e){if("throw"===t.type)throw t.arg;return"break"===t.type||"continue"===t.type?this.next=t.arg:"return"===t.type?(this.rval=this.arg=t.arg,this.method="return",this.next="end"):"normal"===t.type&&e&&(this.next=e),d},finish:function(t){for(var e=this.tryEntries.length-1;e>=0;--e){var r=this.tryEntries[e];if(r.finallyLoc===t)return this.complete(r.completion,r.afterLoc),E(r),d}},catch:function(t){for(var e=this.tryEntries.length-1;e>=0;--e){var r=this.tryEntries[e];if(r.tryLoc===t){var n=r.completion;if("throw"===n.type){var i=n.arg;E(r)}return i}}throw new Error("illegal catch attempt")},delegateYield:function(t,e,r){return this.delegate={iterator:_(t),resultName:e,nextLoc:r},"next"===this.method&&(this.arg=void 0),d}},t}},5700:function(t,e,r){function n(t){return n="function"==typeof Symbol&&"symbol"==typeof Symbol.iterator?function(t){return typeof t}:function(t){return t&&"function"==typeof Symbol&&t.constructor===Symbol&&t!==Symbol.prototype?"symbol":typeof t},n(t)}r.d(e,{Z:function(){return n}})}}]);
//# sourceMappingURL=461.ca72a0b9.chunk.js.map