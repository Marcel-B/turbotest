import { UserManager } from "oidc-client";

export const getUserManager = () => {
  const config = {
    authority: "http://localhost:6065",
    client_id: "fishbook.client",
    redirect_uri: "http://localhost:3000/callback",
    response_type: "code",
    response_mode: "query",
    scope: "openid",
    post_logout_redirect_uri: "http://localhost:3000/"
  };
  return new UserManager(config);
};