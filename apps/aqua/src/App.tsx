import React, { useEffect, useState } from "react";
import { AppShell } from "ui";
import { Typography } from "@mui/material";
import { useStore } from "store";
import { NavLink } from "domain/nav-link";
import { Route } from "domain/Route";
import Feed from "feed";
import UserProfile from "user-profile";
// @ts-ignore
const LoginUser = React.lazy(() => import("identity/LoginUser"));

function App() {
  const user = useStore(state => state.displayName);
  const [navLinks, setNavLinks] = useState<NavLink[]>([]);
  const [routes, setRoutes] = useState<Route[]>([]);

  useEffect(() => {
      if (user) {
        setNavLinks([
          { label: "Feed", path: "/" },
          { label: "Admin", path: "/admin" }]);
        setRoutes([
          { path: "/", element: () => <Feed /> },
          { path: "/profile", element: () => <UserProfile /> },
          { path: "/admin", element: () => <Typography variant="h3">Admin</Typography> }
        ]);
      } else {
        setNavLinks([
          { label: "Feed", path: "/" }]);
        setRoutes([
          { path: "/", element: () => <Feed /> },
          { path: "/login", element: () => <LoginUser /> },
          { path: "/profile", element: () => <UserProfile /> }]);
      }
    },
    [user]);

  return (
    <>
      <AppShell
        title="Fishbook"
        navLinks={navLinks}
        routes={routes} />
    </>
  );
}

export default App;
