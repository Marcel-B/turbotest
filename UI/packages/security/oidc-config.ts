import { UserManager } from "oidc-client";

export const getUserManager = () => {
  const config = {
    authority: process.env.REACT_APP_AUTHORITY,
    client_id: "fishbook.client",
    redirect_uri: `${process.env.REACT_APP_URL}/callback`,
    response_type: "code",
    response_mode: "query",
    scope: "openid",
    post_logout_redirect_uri: `${process.env.REACT_APP_URL}/logout`
  };

  console.log("__security config", config);
  return new UserManager(config);
};