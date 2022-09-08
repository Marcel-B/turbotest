import * as React from "react";
import { useEffect } from "react";
import { getUserManager } from "security";
import { useStore } from "store";
import { useNavigate } from "react-router-dom";

export const Oidc = () => {
  const setToken = useStore(state => state.setToken);
  const token = useStore(state => state.token);
  const navigate = useNavigate();

  useEffect(() => {
    const userManager = getUserManager();
    userManager
      .signinRedirectCallback()
      .then(user => {
        setToken(user.access_token);
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

export default Oidc;

