import * as React from "react";
import { AppBar, Toolbar, Typography, Box, Link, Container, Grid } from "@mui/material";
import { BrowserRouter, Navigate, Outlet, Route, Routes } from "react-router-dom";
import { useStore } from "store";
import { useEffect, useState } from "react";
import NavLink from "domain/nav-link";
import * as RouteType from "domain/Route";
import Righthand from "righthand";
import UserMenu from "user-menu";
import AddMenu, { Neu } from "add-menu";

interface Props {
  title: string;
  routes: RouteType.Route[];
  navLinks: NavLink[];
}

export const AppShell = ({ title, routes, navLinks }: Props) => {
  const { setRedirectUrl, redirectUrl } = useStore();
  const [nav, setNav] = useState(false);

  useEffect(() => {
    if (nav) {
      setNav(false);
      setRedirectUrl();
    } else if (redirectUrl) {
      setNav(true);
    }
  }, [redirectUrl, nav, setNav]);

  return (
    <BrowserRouter>
      {nav && redirectUrl && (
        <Navigate to={redirectUrl} replace={true} />
      )}
      <Box sx={{ flexGrow: 1 }}>
        <AppBar position="sticky">
          <Container>
            <Toolbar disableGutters>
              <Typography
                variant="h4"
                sx={{
                  mr: 3,
                  fontFamily: "monospace"
                }}>{title}</Typography>
              {navLinks.map(navLink => <Link
                key={navLink.path}
                href={navLink.path}
                underline="none"
                color="inherit"
                sx={{
                  mr: 2
                }}
              >{navLink.label}</Link>)}
              <AddMenu />
              <UserMenu />
            </Toolbar>
          </Container>
        </AppBar>
      </Box>
      <Container sx={{
        mt: 2
      }}>
        <Grid container spacing={2}>
          <Grid item xs={8}>
            <Routes>
              {routes.map(route => <Route key={route.path} path={route.path} element={<route.element />} />)}
            </Routes>
            <Neu />
          </Grid>
          <Grid item xs={4}><Righthand /></Grid>
        </Grid>
      </Container>
      <Outlet />
    </BrowserRouter>
  );
};

export default AppShell;