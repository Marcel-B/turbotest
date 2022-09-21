import * as React from "react";
import {Box, Button, Divider, Grid, TextField, Typography} from "@mui/material";
import {useForm} from "react-hook-form";
import {yupResolver} from "@hookform/resolvers/yup";
import {useStore} from "store";
import * as yup from "yup";
import { UserFormValues } from "transport";


interface Props {
  redirectUrl: string;
}

const schema = yup.object({
  email: yup.string().email("email Format").required("benötigt"),
  username: yup.string().required("benötigt"),
  displayName: yup.string().required("benötigt"),
  password: yup.string().required("benötigt")
}).required();

const RegisterUserForm = ({redirectUrl}: Props) => {
  const {setRedirectUrl, setUser} = useStore();

  const {
    formState: {errors},
    handleSubmit,
    register
  } = useForm<UserFormValues>({resolver: yupResolver(schema)});

  const submit = async (data: UserFormValues) => {
    if (data) {
      //const user = await agent.AccountCall.register(data);
      // fetch("http://localhost:6065/api/register/register", {
        fetch("http://192.168.2.103:6065/api/register/register", {
        method: 'POST',
        headers: {
          'Accept': 'application/json, text/plain',
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
      }).then(r => console.log("__R", r))
      //setUser(user);
      setRedirectUrl(redirectUrl);
    }
  };

  return (
    <Box>
      <Typography variant="h4">Registrieren</Typography>
      <Divider orientation="horizontal" sx={{mb: 2}}/>
      <form onSubmit={handleSubmit(submit)}>
        <Grid container spacing={2}
              sx={{justifyContent: "flex-end"}}>
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
              name="email"/>
          </Grid>
          <Grid item md={6} xs={12}>
            <TextField
              label="Benutzername"
              type="text"
              autoComplete="username"
              error={!!errors.username}
              fullWidth
              {...register("username")}
              helperText={errors.username?.message}
              defaultValue=""
              name="username"/>
          </Grid>
          <Grid item md={6} xs={12}>
            <TextField
              label="Anzeigename"
              type="text"
              autoComplete="current-display-name"
              error={!!errors.displayName}
              fullWidth
              {...register("displayName")}
              helperText={errors.displayName?.message}
              defaultValue=""
              name="displayName"/>
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
              name="password"/>
          </Grid>
          <Grid item>
            <Button type="submit">Registrieren</Button>
          </Grid>
        </Grid>
      </form>
    </Box>
  );
};

export default RegisterUserForm;