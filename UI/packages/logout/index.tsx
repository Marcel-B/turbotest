import * as React from "react";
import { getUserManager } from "security";
import { useEffect } from "react";


export const Logout = () => {

  useEffect(() => {
    const userManager = getUserManager();
    console.log("__Signout Redirect Callback")
    userManager.signoutRedirectCallback().then(nix => console.log("__Fertig", nix)).catch(reason => console.error(reason));
  }, []);

  return (
    <>Logout</>
  );
};

export default Logout;

