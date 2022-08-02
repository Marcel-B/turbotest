import * as React from "react";
import { Box, Divider, Typography } from "@mui/material";
import { useEffect } from "react";
import { getUserManager } from "security";
import { useNavigate } from "react-router-dom";
import { useStore } from "store";

// Only 4 compatibility
interface Props {
  redirectUrl?: string;
}

const LoginUserForm = (props: Props) => {
  // const navigate = useNavigate();
  const setUser = useStore(state => state.setUser);

  useEffect(() => {
    const userManager = getUserManager();
    userManager.getUser().then((user) => {
      if (user) {
        console.log("User logged in", user.profile);
        setUser({
          username: user.scope,
          displayName: user.scopes.join(":"),
          email: "foo",
          token: user.access_token,
          image: "null"
        });
      } else {
        console.log("User not logged in");
        userManager
          .signinRedirect()
          .catch(err => console.error(err));
      }
    });
  }, []);

  return (
    <Box>
      <Typography variant="h4">Redirect to Authority</Typography>
      <Divider orientation="horizontal" sx={{ mb: 2 }} />
    </Box>
  );
};

export default LoginUserForm;

