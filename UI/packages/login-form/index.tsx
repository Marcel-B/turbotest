import * as React from "react";
import { Box, Divider, Typography } from "@mui/material";
import { useEffect } from "react";
import { getUserManager } from "security";
import { useStore } from "store";

interface Props {
  redirectUrl?: string;
}

const LoginUserForm = (props: Props) => {
  const setUser = useStore(state => state.setUser);

  useEffect(() => {
    console.log("__useEffect - LoginUserForm");
    const userManager = getUserManager();
    userManager
      .getUser()
      .then((user) => {
        if (user) {
          console.info("__Login erfolgreich", user.profile);
          setUser({
            username: user?.profile?.name ?? "keine Angaben",
            displayName: user.scopes.join(":"),
            email: user?.profile?.email ?? "keine Angaben",
            token: user.access_token,
            image: "null"
          });
        } else {
          console.info("__Login erforderlich");
          userManager
            .signinRedirect()
            .catch(err => console.error(err));
        }
      })
      .catch(reason => console.error("__Login fehlgeschlagen", reason));
  }, []);

  return (
    <Box>
      <Typography variant="h4">Redirect to Authority</Typography>
      <Divider orientation="horizontal" sx={{ mb: 2 }} />
    </Box>
  );
};

export default LoginUserForm;

