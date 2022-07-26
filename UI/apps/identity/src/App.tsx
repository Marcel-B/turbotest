import * as React from "react";
import LoginUserForm from "login-form";
import RegisterUserForm from "register-form";
import {useState} from "react";
import { Button} from "@mui/material";

const App = () => {
  const [registrieren, setRegistrieren] = useState(false);

  return (
    <>
      {registrieren ?
        <RegisterUserForm redirectUrl="/"/>
        :
        <>
          <LoginUserForm redirectUrl="/"/>
          <Button onClick={() => setRegistrieren(true)}>Neu Registrieren</Button>
        </>
      }
    </>
  );
};

export default App;
