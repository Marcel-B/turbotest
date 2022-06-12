import * as React from "react";
import { Box, Divider, Typography } from "@mui/material";
import { useEffect } from "react";
import { useStore } from "store";

const Feed = () => {
  const { aquarien, fetchAquarien } = useStore();

  useEffect(() => {
    fetchAquarien();
  }, [fetchAquarien]);
  return (
    <Box>
      <Typography variant="h4">Feed</Typography>
      <Divider orientation="horizontal" />
      {aquarien.map(aq => <p key={aq.id}>{aq.name}</p>)}
    </Box>);
};

export default Feed;