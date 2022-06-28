import { Box, Button, Divider, Grid, TextField, Typography } from "@mui/material";
import { useForm } from "react-hook-form";
import { AquariumFormValues } from "domain/aquarium";
import React from "react";
import { useStore } from "store";
import agent from "transport";

const AquariumForm = () => {
  const { register, handleSubmit } = useForm<AquariumFormValues>();
  const closeModal = useStore(state => state.closeModal);
  const fetchFeed = useStore(state => state.fetchFeed);
  const addAquarium = useStore(state => state.addAquarium);

  const onSubmit = async (data: AquariumFormValues) => {
    console.log("Data", data);
    closeModal();
    try {
      const aquarium = await agent.AquariumCall.create(data);
      addAquarium(aquarium);
      await fetchFeed();
    } catch (err) {
      console.error(err);
    }
  };

  return (
    <>
      <form onSubmit={handleSubmit(onSubmit)}>
        <Typography variant="h5">Neues Aquarium</Typography>
        <Divider orientation="horizontal" sx={{
          mb: 2
        }} />
        <Grid container spacing={2}>
          <Grid item xs={12}>
            <TextField {...register("name")} fullWidth label="Name" type="text" defaultValue="" name="name" />
          </Grid>
          <Grid item xs={12}>
            <TextField {...register("liter")} fullWidth label="Liter" type="number" defaultValue="" name="liter" />
          </Grid>
          <Grid item xs={12}>
            <Divider orientation="horizontal" />
          </Grid>
          <Grid item xs={12}>
            <Box sx={{
              display: "flex",
              justifyContent: "space-between"
            }}>
              <Button
                variant="outlined"
                size="large"
                color="secondary"
                onClick={closeModal}>Schließen</Button>
              <Button
                variant="outlined"
                size="large"
                color="primary"
                type="submit">Speichern</Button>
            </Box>
          </Grid>
        </Grid>
      </form>
    </>);
};
export default AquariumForm;