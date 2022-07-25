import * as React from "react";
import * as yup from "yup";

import {Box, Button, Divider, Grid, TextField, Typography} from "@mui/material";
import {OidcClientSettings, UserManager} from "oidc-client";
import agent, {useStore} from "store";

import {UserLogin} from "domain/user-login";
import {useEffect} from "react";
import {useForm} from "react-hook-form";
import {yupResolver} from "@hookform/resolvers/yup";

interface Props {
  redirectUrl: string;
}

const schema = yup
  .object({
    email: yup.string().email("email Format").required("benötigt"),
    password: yup.string().required("benötigt"),
  })
  .required();

const LoginUserForm = ({redirectUrl}: Props) => {
  const {setRedirectUrl, setUser} = useStore();
  const {
    formState: {errors},
    handleSubmit,
    register,
  } = useForm<UserLogin>({resolver: yupResolver(schema)});

  useEffect(() => {
    const config: OidcClientSettings = {
      authority: "http://localhost:6065",
      client_id: "fishbook.js.client",
      redirect_uri: "http://localhost:3000/callback",
      response_type: "code",
      scope: "openid profile fishbook-feed",
      post_logout_redirect_uri: "http://localhost:3000/",
    };
    const userManager = new UserManager(config);
    userManager.getUser().then((user) => {
      if (user) {
        console.log("User logged in", user.profile);
      } else {
        console.log("User not logged in");
        userManager.signinRedirect().catch(err => console.error(err));
      }
    });
  }, []);

  const submit = async (data: UserLogin) => {
    if (data) {
      const user = await agent.AccountCall.login(data);
      setUser(user);
      setRedirectUrl(redirectUrl);
    }
  };

  return (
    <Box>
      <Typography variant="h4">Anmelden</Typography>
      <Divider orientation="horizontal" sx={{mb: 2}}/>
      <form onSubmit={handleSubmit(submit)}>
        <Grid container spacing={2} sx={{justifyContent: "flex-end"}}>
          <Grid item md={6} xs={12}>
            <TextField
              label="Email"
              type="text"
              autoComplete="username"
              defaultValue=""
              error={!!errors.email}
              {...register("email")}
              helperText={errors.email?.message}
              fullWidth
              name="email"
            />
          </Grid>
          <Grid item md={6} xs={12}>
            <TextField
              label="Passwort"
              type="password"
              autoComplete="current-password"
              error={!!errors.password}
              fullWidth
              {...register("password")}
              helperText={errors.password?.message}
              defaultValue=""
              name="password"
            />
          </Grid>
          <Grid item>
            <Button type="submit">Login</Button>
          </Grid>
        </Grid>
      </form>
    </Box>
  );
};

export default LoginUserForm;

