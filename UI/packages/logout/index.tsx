import * as React from "react";
import { getUserManager } from "security";
import { useEffect } from "react";


export const Logout = () => {

  useEffect(() => {
    const userManager = getUserManager();
    userManager.signoutRedirectCallback()
      .then(cb => console.log("__Logout erfolgreich", cb))
      .catch(reason => console.error(reason));
  }, []);

  return (
    <>Logout erfolgreich</>
  );
};

export default Logout;

