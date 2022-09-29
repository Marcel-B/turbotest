import React, { Suspense, useEffect, useState } from "react";
import { useStore } from "store";
import { BrowserRouter, Navigate, NavLink, Outlet, Route, Routes } from "react-router-dom";
import { AppBar, Box, Container, Grid, Toolbar, Typography } from "@mui/material";
import Feed from "feed";
import Overview from "overview";
import SigninOidc from "signin-oidc";
import AddMenu, { Neu } from "add-menu";
import UserMenu from "user-menu";
import Righthand from "righthand";
import Loader from "./Loader";

// @ts-ignore
const LoginUser = React.lazy(() => import("identity/LoginUser"));

function App() {
  const user = useStore((state) => state.displayName);

  useEffect(() => {
    console.log("__Env", process.env.REACT_APP_API_URL);
  }, [user]);

  return (
    <BrowserRouter>
      <Box sx={{ fexGrow: 1 }}>
        <AppBar position="sticky">
          <Container>
            <Toolbar disableGutters>
              <Typography variant="h4" sx={{ mr: 3, fontFamily: "monospace" }}>Fishbook</Typography>
              <NavLink to="/" style={{ textDecoration: "none" }}>
                <Typography variant="body1" color="whitesmoke" sx={{ mr: 3 }}>
                  Feed
                </Typography>
              </NavLink>
              <NavLink to="/overview" style={{ textDecoration: "none" }}>
                <Typography variant="body1" color="whitesmoke" sx={{ mr: 3 }}>
                  Übersicht
                </Typography>
              </NavLink>
              {user ? <AddMenu /> : <></>}
              <UserMenu />
            </Toolbar>
          </Container>
        </AppBar>
      </Box>
      <Container sx={{ mt: 2 }}>
        <Grid container spacing={2}>
          <Grid item xs={8}>
            <Routes>
              <Route path="/" element={<Feed />}></Route>
              <Route path="/overview" element={<Overview />}></Route>
              <Route path="/callback" element={<SigninOidc />}></Route>
              <Route path="/login" element={
                <Suspense fallback={<Loader />}>
                  <LoginUser />
                </Suspense>
              }></Route>
            </Routes>
            <Neu />
          </Grid>
          <Grid item xs={4}><Righthand /></Grid>
        </Grid>
      </Container>
      <Outlet />
    </BrowserRouter>
  );
}

export default App;