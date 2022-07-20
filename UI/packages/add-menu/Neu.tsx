import * as React from "react";
import { Box, Fade, Modal } from "@mui/material";
import { useStore } from "store";
import { useEffect } from "react";
import { NotizColor } from "styles";
import { AquariumForm, MessungForm, NotizForm, DuengungForm, FischForm } from "forms";

const Neu = () => {
  const showModal = useStore(state => state.showModal);
  const feedItemType = useStore(state => state.feedItemType);

  const style = {
    position: "absolute" as "absolute",
    top: "50%",
    left: "50%",
    transform: "translate(-50%, -50%)",
    width: 640,
    bgcolor: "background.paper",
    border: "6px solid",
    borderColor: NotizColor,
    borderRadius: 4,
    boxShadow: 24,
    p: 4
  };

  useEffect(() => {
    console.log("useEffect Neu");
    console.log("feedItemType", feedItemType);
    console.log("showModal", showModal);
  }, []);

  const handleClose = () => {
    console.log("handleClose");
  };


  return (
    <Modal
      onClose={handleClose}
      closeAfterTransition
      open={showModal}>
      <Fade in={showModal}>
        <Box sx={style}>
          {feedItemType === "Aquarium" ?
            <AquariumForm />
            : feedItemType === "Notiz" ?
              <NotizForm />
              : feedItemType === "Düngung" ?
                <DuengungForm />
                : feedItemType === "Messung" ?
                  <MessungForm />
                  : feedItemType === "Fisch" ?
                    <FischForm />
                    : <h1>Nix hier</h1>
          }
        </Box>
      </Fade>
    </Modal>);
};

export default Neu;