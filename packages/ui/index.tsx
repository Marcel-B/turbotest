import * as React from "react";
import { AppBar, Toolbar, Typography, Box, Link, Button, Container, MenuItem } from "@mui/material";
import { BrowserRouter, Navigate, Outlet, Route, Routes } from "react-router-dom";
import { useStore } from "store";
import { useEffect, useState } from "react";

export type Route = {
  element: React.FunctionComponent;
  path: string;
}

export type NavLink = {
  label: string;
  path: string;
};

interface Props {
  title: string;
  routes: Route[];
  navLinks: NavLink[];
}

export const AppShell = ({ title, routes, navLinks }: Props) => {
  const { setRedirectUrl, redirectUrl, displayName, logout } = useStore();
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
              {displayName && <MenuItem onClick={logout}>{displayName}</MenuItem>}
            </Toolbar>
          </Container>
        </AppBar>
      </Box>
      <Container sx={{
        mt: 2
      }}>
        <Routes>
          {routes.map(route => <Route key={route.path} path={route.path} element={<route.element />} />)}
        </Routes>
      </Container>
      <Outlet />
    </BrowserRouter>
  );
};

export default AppShell;