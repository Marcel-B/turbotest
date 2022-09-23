import * as React from "react";
import { Button, Menu, MenuItem } from "@mui/material";
import { useStore } from "store";
import { NavLink } from "react-router-dom";

const UserMenu = () => {
  const [anchorEl, setAnchorEl] = React.useState<null | HTMLElement>(null);
  const displayName = useStore(state => state.displayName);
  const logout = useStore(state => state.logout);


  const handleProfileMenuOpen = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorEl(event.currentTarget);
  };
  const isMenuOpen = Boolean(anchorEl);

  const handleMenuClose = (data: React.SyntheticEvent) => {
    const pressedButton = data.currentTarget.textContent;
    switch (pressedButton) {
      case "Profil":
        setAnchorEl(null);
        // setRedirectUrl("profile");
        break;
      case "Ausloggen":
        logout();
        setAnchorEl(null);
        break;
    }
  };

  const menuId = "primary-search-account-menu";
  const renderMenu = (
    <Menu
      anchorEl={anchorEl}
      anchorOrigin={{
        vertical: "top",
        horizontal: "right"
      }}
      id={menuId}
      keepMounted
      transformOrigin={{
        vertical: "top",
        horizontal: "right"
      }}
      open={isMenuOpen}
      onClose={handleMenuClose}
    >
      <MenuItem onClick={handleMenuClose}>Profil</MenuItem>
      <MenuItem onClick={handleMenuClose}>Ausloggen</MenuItem>
    </Menu>
  );
  return (
    <>
      {displayName ?
        <MenuItem onClick={handleProfileMenuOpen}>
          {displayName ?? "Login"}
        </MenuItem>
        :
        <NavLink to="login">Login</NavLink>
      }
      {renderMenu}
    </>
  );
};

export default UserMenu;