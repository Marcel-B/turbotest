import {
  Box,
  Button,
  Divider,
  FormControl,
  Grid,
  InputLabel,
  MenuItem,
  Select, TextField,
  Typography
} from "@mui/material";
import { useController, UseControllerProps, useForm } from "react-hook-form";
import React, { useEffect } from "react";
import { useStore } from "store";
import agent from "transport";
import { NotizFormValues } from "domain/notiz";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import { DatePicker } from "@mui/x-date-pickers/DatePicker";
import { AdapterDateFns } from "@mui/x-date-pickers/AdapterDateFns";
import deLocale from "date-fns/locale/de";

interface Props extends UseControllerProps<NotizFormValues, any> {
  default?: Date | null;
}

const AppDatePicker = (props: Props) => {
  const { field, fieldState } = useController({ ...props, defaultValue: props.default ?? new Date() });
  return (
    <FormControl
      margin="dense"
      fullWidth>
      <LocalizationProvider dateAdapter={AdapterDateFns} locale={deLocale}>
        <DatePicker
          {...field}
          label="Datum"
          mask={"__.__.____"}
          onChange={field.onChange}
          renderInput={(params) =>
            <TextField
              {...params}
              helperText={fieldState.error?.message}
              error={!!fieldState.error} />}
        />
      </LocalizationProvider>
    </FormControl>
  );
};

const NotizForm = () => {
  const {
    register,
    control,
    handleSubmit
  } = useForm<NotizFormValues>();
  const closeModal = useStore(state => state.closeModal);
  const fetchFeed = useStore(state => state.fetchFeed);
  const fetchAquarien = useStore(state => state.fetchAquarien);
  const aquarien = useStore(state => state.aquarien);

  useEffect(() => {
    if (aquarien.length === 0) {
      fetchAquarien().catch(err => console.error(err));
    }
  }, [aquarien.length, fetchAquarien]);

  const onSubmit = async (data: NotizFormValues) => {
    console.debug("Data", data);
    const aqua = aquarien.find(a => a.name === data.aquarium.toString());
    data.aquarium = aqua!;
    closeModal();
    try {
      await agent.NotizCall.create(data);
      await fetchFeed();
    } catch (err) {
      console.error(err);
    }
  };

  return (
    <>
      <form onSubmit={handleSubmit(onSubmit)}>
        <Typography variant="h5">Neue Notiz</Typography>
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
            <TextField {...register("text")} fullWidth label="Text" type="text" defaultValue="" name="text" />
          </Grid>
          <Grid item xs={12}>
            <TextField {...register("tag")} fullWidth label="Tag" type="text" defaultValue="" name="tag" />
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
export default NotizForm;