import * as React from "react";
import { Box, Typography } from "@mui/material";
import InfoCard from "info";
import { useEffect } from "react";
import { useStore } from "store";

const Feed = () => {
  const { aquarien, fetchAquarien } = useStore();

  useEffect(() => {
    fetchAquarien();
  }, [fetchAquarien]);
  return (
    <Box sx={{
      display: "flex",
      justifyContent: "space-between"
    }}>
      <Box>
        <Typography variant="h3">Feed</Typography>
        {aquarien.map(aq => <p key={aq.id}>{aq.name}</p>)}
      </Box>
      <Box>
        <InfoCard />
      </Box>
    </Box>);
};

export default Feed;