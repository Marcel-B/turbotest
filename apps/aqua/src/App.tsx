import React, { useEffect, useState } from "react";
import { AppShell } from "ui";
import Feed from "feed";
import { Typography } from "@mui/material";
import { useStore } from "store";
// @ts-ignore
const LoginUser = React.lazy(() => import("identity/LoginUser"));

function App() {
  const user = useStore(state => state.displayName);
  const [navLinks, setNavLinks] = useState<{ label: string; path: string }[]>([]);
  const [routes, setRoutes] = useState<{ path: string, element: React.FunctionComponent }[]>([]);

  useEffect(() => {
    if (user) {
      setNavLinks([
        { label: "Feed", path: "/" },
        { label: "Neu", path: "/neu" },
        { label: "Admin", path: "/admin" }]);
      setRoutes([
        { path: "/", element: () => <Feed /> },
        { path: "/neu", element: () => <Typography variant="h3">Neu</Typography> },
        { path: "/admin", element: () => <Typography variant="h3">Admin</Typography> }
      ]);
    } else {
      setNavLinks([
        { label: "Feed", path: "/" },
        { label: "Neu", path: "/neu" },
        { label: "Login", path: "/login" }]);
      setRoutes([
        { path: "/", element: () => <Feed /> },
        { path: "/login", element: () => <LoginUser /> },
        { path: "/neu", element: () => <Typography variant="h3">Neu</Typography> }
      ]);
    }

  }, [user]);

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
