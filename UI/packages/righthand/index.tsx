import * as React from "react";
import { Box } from "@mui/material";
import InfoCard from "info";
import Timer, { TimerItem } from "timer";
import { useStore } from "store";

export const Righthand = () => {
  const { timers } = useStore();
  return (
    <Box>
      <InfoCard />
      <Timer />
      {timers.map(timer => <TimerItem timer={timer} key={timer.name} />)}
    </Box>
  );
};

export default Righthand;