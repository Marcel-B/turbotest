import * as React from "react";
import { Menu, MenuItem } from "@mui/material";
import { useStore } from "store";
import Neu from "./Neu";

const AddMenu = () => {
  const [anchorEl, setAnchorEl] = React.useState<null | HTMLElement>(null);
  const setRedirectUrl = useStore(state => state.setRedirectUrl);
  const addFeedItem = useStore(state => state.addFeedItem);

  const handleProfileMenuOpen = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorEl(event.currentTarget);
  };
  const isMenuOpen = Boolean(anchorEl);

  const handleMenuClose = (data: React.SyntheticEvent) => {
    const pressedButton = data.currentTarget.textContent;
    console.log("pressedButton", pressedButton);
    if (pressedButton) {
      addFeedItem(pressedButton);
    }
    setAnchorEl(null);
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
      <MenuItem onClick={handleMenuClose}>Notiz</MenuItem>
      <MenuItem onClick={handleMenuClose}>Aquarium</MenuItem>
    </Menu>
  );
  return (
    <>
      <MenuItem onClick={handleProfileMenuOpen}>
        Neu
      </MenuItem>
      {renderMenu}
    </>
  );
};

export default AddMenu;
export { Neu };