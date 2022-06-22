import * as React from "react";
import { useStore } from "store";
import { Box, Card, CardContent, CardHeader, Divider, Grid, TextField, Typography } from "@mui/material";

const UserProfile = () => {
  const user = useStore(state => state.user);

  return (
    <>
      <Box sx={{
        display: "flex",
        alignItems: "baseline",
        justifyContent: "space-between"
      }}>
        <Typography variant="h4">Benutzerprofil</Typography>
        <Typography variant="subtitle2"
                    color="text.secondary">{user?.displayName}</Typography>
      </Box>

      <Divider orientation="horizontal" sx={{ mb: 2 }} />
      {user &&
        <Card sx={{ padding: 2 }}>
          <CardContent>
            <Grid container spacing={2}>
              <Grid item xs={12}>
                <TextField name="Display Name" fullWidth label={"Display Name"} disabled value={user.displayName} />
              </Grid>
              <Grid item xs={12}>
                <TextField disabled fullWidth label="Username" value={user.username} />
              </Grid>
              <Grid item xs={12}>
                <TextField disabled fullWidth label="Email" value={user.email} />
              </Grid>
              <Grid item xs={12}>
                <TextField disabled fullWidth label="Access Token" value={user.token} />
              </Grid>
            </Grid>
            <br />
            {user.image ?? "kein Bild"}
          </CardContent>
        </Card>
      }
    </>
  );
};

export default UserProfile;