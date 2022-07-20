import * as React from "react";

import { UserManager } from "oidc-client";
import { useEffect } from "react";

export const Oidc = () => {
  useEffect(() => {
    const config = {
      authority: "http://localhost:6065",
      client_id: "fishbook.js.client",
      redirect_uri: "http://localhost:3000/callback",
      response_type: "code",
      response_mode: "query",
      scope: "openid profile fishbook",
      post_logout_redirect_uri: "http://localhost:3000",
    };
    console.log("__Callback here", config);
    const userManager = new UserManager(config);
    userManager.signinRedirectCallback().catch((e) => console.error(e));
  }, []);

  return <h1>Redirect</h1>;
};

export default Oidc;

