import * as React from "react";
import { useEffect } from "react";
import { getUserManager } from "security";
import { useStore } from "store";
import { useNavigate } from "react-router-dom";
import jwt_decode from "jwt-decode";

export const SigninOidc = () => {
  const setToken = useStore(state => state.setToken);
  const setUser = useStore(state => state.setUser);
  const token = useStore(state => state.token);
  const navigate = useNavigate();

  useEffect(() => {
    console.log("__useEffect - Oidc");
    const userManager = getUserManager();
    userManager
      .signinRedirectCallback()
      .then(user => {
        setToken(user.access_token);
        if (user) {
          console.info(("__Login Callback erfolgreich"));
          const decoded = jwt_decode(user.access_token) as { email: string, name: string };
          console.info("__Decoded", decoded);
          setUser({
            username: decoded.name,
            displayName: user.scopes.join(":"),
            email: decoded.email,
            token: user.access_token,
            image: "null"
          });
        }
        navigate("/");
      })
      .catch((e) => console.error(e));
  }, []);

  return (
    <>
      <h1>Redirect</h1>
      <p>{token}</p>
    </>
  );
};

export default SigninOidc;

