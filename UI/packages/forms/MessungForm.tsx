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
import {useForm} from "react-hook-form";
import React, {useEffect} from "react";
import {useStore} from "store";
import agent from "transport";
import {AppTextInput, AppDatePicker} from "controlls";
import MessungFormValues from "transport/formValues/messungFormValues";

const werte = [
  {text: 'NO₂ (Nitrit)', value: 'NO₂', unit: 'mg/l'},
  {text: 'NH₄ (Ammonium)', value: 'NH₄', unit: 'mg/l'},
  {text: 'NO₃ (Nitrat)', value: 'NO₃', unit: 'mg/l'},
  {text: 'PO₄ (Phosphat)', value: 'PO₄', unit: 'mg/l'},
  {text: 'FE (Eisen)', value: 'FE', unit: 'mg/l'},
  {text: 'GH (Gesamthärte)', value: 'GH', unit: '°dH'},
  {text: 'KH (Karbonathärte)', value: 'KH', unit: '°dH'},
  {text: 'PH', value: 'PH', unit: ''},
  {text: 'K (Kalium)', value: 'K', unit: 'mg/l'},
];

const MessungForm = () => {
  const {
    register,
    control,
    handleSubmit
  } = useForm<MessungFormValues>();
  const closeModal = useStore(state => state.closeModal);
  const fetchFeed = useStore(state => state.fetchFeed);
  const fetchAquarien = useStore(state => state.fetchAquarien);
  const aquarien = useStore(state => state.aquarien);

  useEffect(() => {
    if (aquarien.length === 0) {
      fetchAquarien().catch(err => console.error(err));
    }
  }, [aquarien.length, fetchAquarien]);

  const onSubmit = async (data: MessungFormValues) => {
    console.log("Data", data);
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
        }}/>
        <Grid container spacing={2}>
          <Grid item xs={12}>
            <AppDatePicker name="datum" control={control} default={new Date()}/>
          </Grid>
          <Grid item xs={12}>
            <FormControl fullWidth>
              <InputLabel id="aquarium-id">Aquarium</InputLabel>
              <Select
                label="Aquarium"
                {...register("aquariumId")}
                defaultValue=""
                labelId="aquarium-id">
                {aquarien.map(aquarium => <MenuItem key={aquarium.id} value={aquarium.id}>{aquarium.name}</MenuItem>)}
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
                {werte.map(wert => <MenuItem key={wert.value} value={wert.value}>{wert.text}</MenuItem>)}
              </Select>
            </FormControl>
          </Grid>
          <Grid item xs={12}>
            <AppTextInput
              control={control}
              label="Ergebnis"
              type="number"
              default={""}
              name="menge"/>
          </Grid>
          <Grid item xs={12}>
            <Divider orientation="horizontal"/>
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