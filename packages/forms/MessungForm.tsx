import {
  Box,
  Button,
  Divider,
  FormControl,
  Grid,
  InputLabel,
  MenuItem,
  Select,
  Typography
} from "@mui/material";
import { useForm } from "react-hook-form";
import React, { useEffect } from "react";
import { useStore } from "store";
import agent from "transport";
import { NotizFormValues } from "domain/notiz";
import { AppTextInput, AppDatePicker } from "controlls";
import { DuengungFormValues } from "domain/duengung";

const werte = [
  { value: "Phosphat (PO)", key: "Phosphat" },
  { value: "Eisen (FE)", key: "Eisen" },
  { value: "Kalium (KA)", key: "Kalium" },
  { value: "Nitrat (NO₃)", key: "Nitrat" }
];

const MessungForm = () => {
  const {
    register,
    control,
    handleSubmit
  } = useForm<DuengungFormValues>();
  const closeModal = useStore(state => state.closeModal);
  const fetchFeed = useStore(state => state.fetchFeed);
  const fetchAquarien = useStore(state => state.fetchAquarien);
  const aquarien = useStore(state => state.aquarien);

  useEffect(() => {
    if (aquarien.length === 0) {
      fetchAquarien().catch(err => console.error(err));
    }
  }, [aquarien.length, fetchAquarien]);

  const onSubmit = async (data: DuengungFormValues) => {
    console.log("Data", data);
    const aqua = aquarien.find(a => a.name === data.aquarium.toString());
    data.aquarium = aqua!;
    closeModal();
    try {
      await agent.MessungCall.create(data);
      await fetchFeed();
    } catch (err) {
      console.error(err);
    }
  };

  return (
    <>
      <form onSubmit={handleSubmit(onSubmit)}>
        <Typography variant="h5">Neue Messung</Typography>
        <Divider orientation="horizontal" sx={{
          mb: 2
        }} />
        <Grid container spacing={2}>
          <Grid item xs={12}>
            <AppDatePicker name="datum" control={control} default={new Date()} />
          </Grid>
          <Grid item xs={12}>
            <FormControl fullWidth>
              <InputLabel id="aquarium-id">Aquarium</InputLabel>
              <Select
                label="Aquarium"
                {...register("aquarium")}
                defaultValue=""
                labelId="aquarium-id">
                {aquarien.map(aquarium => <MenuItem key={aquarium.id} value={aquarium.name}>{aquarium.name}</MenuItem>)}
              </Select>
            </FormControl>
          </Grid>
          <Grid item xs={12}>
            <FormControl fullWidth>
              <InputLabel id="test-id">Test</InputLabel>
              <Select
                label="Test"
                {...register("wert")}
                defaultValue=""
                labelId="test-id">
                {werte.map(wert => <MenuItem key={wert.key} value={wert.value}>{wert.value}</MenuItem>)}
              </Select>
            </FormControl>
          </Grid>
          <Grid item xs={12}>
            <AppTextInput
              control={control}
              label="Ergebnis"
              type="number"
              default={""}
              name="menge" />
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

export default MessungForm;