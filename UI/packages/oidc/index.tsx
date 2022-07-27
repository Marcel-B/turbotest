import * as React from "react";

import { UserManager } from "oidc-client";
import { useEffect } from "react";

export const Oidc = () => {
  useEffect(() => {
    const config = {
      authority: "https://localhost:6065",
      client_id: "fishbook.client",
      redirect_uri: "http://localhost:3000/callback",
      response_type: "code",
      response_mode: "query",
      scope: "openid",
      post_logout_redirect_uri: "http://localhost:3000/"
    };
    console.log("__Callback here", config);
    const userManager = new UserManager(config);
    userManager.signinRedirectCallback().then(data => console.log(data)).catch((e) => console.error(e));
  }, []);

  return <h1>Redirect</h1>;
};

export default Oidc;

