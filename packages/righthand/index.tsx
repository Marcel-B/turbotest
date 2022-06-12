import * as React from "react";
import { Box } from "@mui/material";
import InfoCard from "info";
import Timer from "timer";
import { useStore } from "store";

export const Righthand = () => {
  const timers = useStore(state => state.timers);
  return (
    <Box>
      <InfoCard />
      <Timer />
      {timers && timers.map(timer => <p key={timer.name}>{timer.name}</p>)}
    </Box>
  );
};

export default Righthand;