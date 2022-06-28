import React from "react";
import { FormControl, TextField } from "@mui/material";
import { DatePicker, LocalizationProvider } from "@mui/x-date-pickers";
import { AdapterDateFns } from "@mui/x-date-pickers/AdapterDateFns";
import { useController, UseControllerProps } from "react-hook-form";
import deLocale from "date-fns/locale/de";

interface Props extends UseControllerProps<any, any> {
  default?: Date | null;
}

const AppDatePicker = (props: Props) => {
  const { field, fieldState } = useController({ ...props, defaultValue: props.default ?? new Date() });
  return (
    <FormControl
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

export default AppDatePicker;