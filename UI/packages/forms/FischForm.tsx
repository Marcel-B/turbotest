import {Box, Button, Divider, FormControl, Grid, InputLabel, MenuItem, Select, Typography} from "@mui/material";
import {useForm} from "react-hook-form";
import React, {useEffect} from "react";
import * as yup from "yup";
import {yupResolver} from "@hookform/resolvers/yup";
import {useStore} from "store";
import {AppDatePicker, AppTextInput, AppRadioButton} from "controlls";
import agent from "transport";
import FischFormValues from "transport/formValues/fischFormValues";

const schema = yup.object({
  name: yup
    .string()
    .required("benötigt"),
  wissenschaftlich: yup
    .string()
    .required("benötigt"),
  herkunft: yup
    .string()
    .required("benötigt"),
  schwimmzone: yup
    .string()
    .required("benötigt"),
  anzahl: yup
    .number()
    .typeError("muss eine Zahl sein")
    .positive("muss positiv sein")
    .integer("muss eine natürliche Zahl sein")
    .required("benötigt")
}).required();

const geschlechtTypOptions: { text: string, value: string }[] = [
  {text: "♂", value: "♂"},
  {text: "♀", value: "♀"},
  {text: "?", value: "?"}
];

const NeuerFischForm = () => {
  const {control, handleSubmit, reset, register} = useForm<FischFormValues>({resolver: yupResolver(schema)});
  const aquarien = useStore(state => state.aquarien);
  const fetchAquarien = useStore(state => state.fetchAquarien);
  const fetchFeed = useStore(state => state.fetchFeed);
  const closeModal = useStore(state => state.closeModal);

  const handleClose = (event?: React.SyntheticEvent | Event, reason?: string) => {
    if (reason === "clickaway") {
      return;
    }
  };

  useEffect(() => {
    // if (aquarien?.length <= 0) {
    fetchAquarien().catch(err => console.error(err));
    // }
  }, [aquarien.length, fetchAquarien]);

  const onSubmit = async (data: FischFormValues) => {
    console.log('Fisch', data);
    data.kh.einheit = "°dH";
    data.gh.einheit = "°dH";
    data.ph.einheit = "";
    data.temperatur.einheit = "°C";
    closeModal();
    try {
      await agent.FischCall.create(data);
      await fetchFeed();
    } catch (err) {
      console.error(err);
    }

    reset({});
  };

  return (
    <>
      <form onSubmit={handleSubmit(onSubmit)}>
        <Typography variant="h5">Neuer Fisch</Typography>
        <Divider orientation="horizontal" sx={{mb: 2}}/>

        <Grid container spacing={2}>
          <Grid item xs={7}>
            <Grid container spacing={2}>
              <Grid item xs={6}>
                <AppTextInput
                  control={control}
                  label="Name"
                  name="name"
                  default=""
                  type="text"/>
              </Grid>
              <Grid item xs={6}>
                <AppTextInput
                  control={control}
                  label="Wissenschaftlich"
                  name="wissenschaftlich"
                  default=""
                  type="text"/>
              </Grid>
              <Grid item xs={6}>
                <AppTextInput
                  control={control}
                  label="Herkunft"
                  name="herkunft"
                  default=""
                  type="text"/>
              </Grid>
              <Grid item xs={6}>
                <AppTextInput
                  control={control}
                  label="Schwimmzone"
                  name="schwimmzone" default=""
                  type="text"/>
              </Grid>
              <Grid item xs={6}>
                <AppDatePicker control={control} default={new Date()} name="datum"/>
              </Grid>
              <Grid item xs={6}>
                <FormControl fullWidth>
                  <InputLabel id="aquarium-id">Aquarium</InputLabel>
                  <Select
                    label="Aquarium"
                    {...register("aquariumId")}
                    defaultValue=""
                    labelId="aquarium-id">
                    {aquarien.map(aquarium => <MenuItem
                      key={aquarium.id}
                      value={aquarium.id}>{aquarium.name}</MenuItem>)}
                  </Select>
                </FormControl>
              </Grid>
              <Grid item xs={6}>
                <AppTextInput
                  control={control} label="Anzahl" name="anzahl" default="" type="number"/>
              </Grid>
              <Grid item xs={6}>
                <AppRadioButton
                  name="geschlecht"
                  defaultValue={null}
                  control={control}
                  label="Geschlecht"
                  values={geschlechtTypOptions}/>
              </Grid>
            </Grid>
          </Grid>

          <Grid item xs={5}>
            <Grid container spacing={2}>
              <Grid item xs={4}>
                <Typography variant="subtitle1" sx={{pt: 2}}>PH</Typography>
              </Grid>
              <Grid item xs={4}>
                <AppTextInput control={control} label="Von" name="ph.von" default="" type="number"/>
              </Grid>
              <Grid item xs={4}>
                <AppTextInput control={control} label="Bis" name="ph.bis" default="" type="number"/>
              </Grid>
              <Grid item xs={4}>
                <Typography variant="subtitle1" sx={{pt: 2}}>Temp.</Typography>
              </Grid>
              <Grid item xs={4}>
                <AppTextInput
                  control={control} label="Von" name="temperatur.von" default=""
                  type="number"/>
              </Grid>
              <Grid item xs={4}>
                <AppTextInput
                  control={control}
                  label="Bis"
                  name="temperatur.bis"
                  default=""
                  type="number"/>
              </Grid>
              <Grid item xs={4}>
                <Typography variant="subtitle1" sx={{pt: 2}}>GH</Typography>
              </Grid>
              <Grid item xs={4}>
                <AppTextInput control={control} label="Von" name="gh.von" default="" type="number"/>
              </Grid>
              <Grid item xs={4}>
                <AppTextInput control={control} label="Bis" name="gh.bis" default="" type="number"/>
              </Grid>
              <Grid item xs={4}>
                <Typography variant="subtitle1" sx={{pt: 2}}>KH</Typography>
              </Grid>
              <Grid item xs={4}>
                <AppTextInput control={control} label="Von" name="kh.von" default="" type="number"/>
              </Grid>
              <Grid item xs={4}>
                <AppTextInput control={control} label="Bis" name="kh.bis" default="" type="number"/>
              </Grid>
            </Grid>
          </Grid>
        </Grid>

        <Divider orientation="horizontal" sx={{mb: 2, mt: 2}}/>

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

      </form>
    </>
  );
};
export default NeuerFischForm;