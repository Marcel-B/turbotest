import * as React from "react";
import { Box, Button, Divider, Grid, TextField, Typography } from "@mui/material";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import agent, { useStore } from "store";
import * as yup from "yup";
import UserLogin from "shared-types/user-login";

interface Props {
  redirectUrl: string;
}

const schema = yup.object({
  email: yup.string().email("email Format").required("benötigt"),
  password: yup.string().required("benötigt")
}).required();

const LoginUserForm = ({ redirectUrl }: Props) => {
  const { setRedirectUrl, setUser } = useStore();
  const {
    formState: { errors },
    handleSubmit,
    register
  } = useForm<UserLogin>({ resolver: yupResolver(schema) });

  const submit = async (data: UserLogin) => {
    if (data) {
      const user = await agent.AccountCall.login(data);
      setUser(user);
      setRedirectUrl(redirectUrl);
    }
  };

  return (
    <Box>
      <Typography variant="h3">Anmelden</Typography>
      <Divider orientation="horizontal" sx={{ mb: 2 }} />
      <form onSubmit={handleSubmit(submit)}>
        <Grid container spacing={2}
              sx={{ justifyContent: "flex-end" }}>
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
              name="email" />
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
              name="password" />
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