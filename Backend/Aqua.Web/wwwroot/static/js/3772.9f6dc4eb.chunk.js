/*! For license information please see 3772.9f6dc4eb.chunk.js.LICENSE.txt */
"use strict";(self.webpackChunkaqua=self.webpackChunkaqua||[]).push([[3772,6610,3948,8556],{12452:function(e,r,o){var t=o(68655),n=Symbol.for("react.element"),c=Symbol.for("react.fragment"),l=Object.prototype.hasOwnProperty,a=t.__SECRET_INTERNALS_DO_NOT_USE_OR_YOU_WILL_BE_FIRED.ReactCurrentOwner,i={key:!0,ref:!0,__self:!0,__source:!0};function s(e,r,o){var t,c={},s=null,u=null;for(t in void 0!==o&&(s=""+o),void 0!==r.key&&(s=""+r.key),void 0!==r.ref&&(u=r.ref),r)l.call(r,t)&&!i.hasOwnProperty(t)&&(c[t]=r[t]);if(e&&e.defaultProps)for(t in r=e.defaultProps)void 0===c[t]&&(c[t]=r[t]);return{$$typeof:n,type:e,key:s,ref:u,props:c,_owner:a.current}}r.Fragment=c,r.jsx=s,r.jsxs=s},86610:function(e,r,o){e.exports=o(12452)},43772:function(e,r,o){o.r(r),o.d(r,{Oidc:function(){return l}});var t=o(86610),n=o(93689),c=o(68655),l=function(){return(0,c.useEffect)((function(){var e={authority:"http://localhost:6065",client_id:"fishbook.js.client",redirect_uri:"http://localhost:3000/callback",response_type:"code",response_mode:"query",scope:"openid profile fishbook-feed",post_logout_redirect_uri:"http://localhost:3000"};console.log("__Callback here",e),new n.UserManager(e).signinRedirectCallback().catch((function(e){return console.error(e)}))}),[]),(0,t.jsx)("h1",{children:"Redirect"})};r.default=l}}]);
//# sourceMappingURL=3772.9f6dc4eb.chunk.js.map