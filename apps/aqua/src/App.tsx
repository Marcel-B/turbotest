import React, { useEffect, useState } from "react";
import { AppShell } from "ui";
import { useStore } from "store";
import { NavLink } from "domain/nav-link";
import { Route } from "domain/Route";
import Feed from "feed";
import UserProfile from "user-profile";
// @ts-ignore
const LoginUser = React.lazy(() => import("identity/LoginUser"));

// @ts-ignore
const AdminPanel = React.lazy(() => import("admin/AdminPanel"));

function App() {
  const user = useStore(state => state.displayName);
  const [navLinks, setNavLinks] = useState<NavLink[]>([]);
  const [routes, setRoutes] = useState<Route[]>([]);

  useEffect(() => {
    console.log("__Env", process.env.REACT_APP_API_URL);
      if (user) {
        setNavLinks([
          { label: "Feed", path: "/" },
          { label: "Übersicht", path: "/list" }]);
        setRoutes([
          { path: "/", element: () => <Feed /> },
          { path: "/profile", element: () => <UserProfile /> },
          { path: "/list", element: () => <AdminPanel /> }
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
