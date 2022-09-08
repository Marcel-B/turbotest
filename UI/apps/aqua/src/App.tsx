import React, { useEffect, useState } from "react";
import { AppShell } from "ui";
import Feed from "feed";
import { NavLink } from "domain/nav-link";
import Oidc from "oidc";
import Logout from "logout";
import { Route } from "domain/Route";
import UserProfile from "user-profile";
import { useStore } from "store";

// @ts-ignore
const LoginUser = React.lazy(() => import("identity/LoginUser"));

// @ts-ignore
const AdminPanel = React.lazy(() => import("admin/AdminPanel"));

function App() {
  const user = useStore((state) => state.displayName);
  const [navLinks, setNavLinks] = useState<NavLink[]>([]);
  const [routes, setRoutes] = useState<Route[]>([]);

  useEffect(() => {
    console.log("__Env", process.env.REACT_APP_API_URL);
    if (user) {
      setNavLinks([
        { label: "Feed", path: "/" },
        { label: "Übersicht", path: "/list" }
      ]);
      setRoutes([
        { path: "/", element: () => <Feed /> },
        { path: "/profile", element: () => <UserProfile /> },
        { path: "/list", element: () => <AdminPanel /> },
        { path: "/callback", element: () => <Oidc /> },
        { path: "/logout", element: () => <Logout /> }
      ]);
    } else {
      setNavLinks([{ label: "Feed", path: "/" }]);
      setRoutes([
        { path: "/", element: () => <Feed /> },
        { path: "/login", element: () => <LoginUser /> },
        { path: "/profile", element: () => <UserProfile /> },
        { path: "/callback", element: () => <Oidc /> },
        { path: "/logout", element: () => <Logout /> }
      ]);
    }
  }, [user]);

  return (
    <>
      <AppShell title="Fishbook" navLinks={navLinks} routes={routes} />
    </>
  );
}

export default App;

