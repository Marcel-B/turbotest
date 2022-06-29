import { useController, UseControllerProps } from "react-hook-form";
import { FormControl, FormControlLabel, Radio, RadioGroup, Typography } from "@mui/material";

interface Props extends UseControllerProps<any, any> {
  label: string;
  values: { text: string, value: string | number }[];
}

export const AppRadioButton = (props: Props) => {
  const { fieldState, field } = useController({ ...props, defaultValue: props.defaultValue ?? "" });
  return (
    <FormControl
      fullWidth
      margin="dense"
      error={!!fieldState.error}>
      <Typography>{props.label}</Typography>
      <RadioGroup
        row
        value={field.value}
        onChange={(e) => {
          field.onChange(e.target.value);
        }}
        name="row-radio-buttons-group">
        {props.values.map(option =>
          <FormControlLabel control={<Radio />} label={option.text} key={option.value} value={option.value} />
        )}
      </RadioGroup>
    </FormControl>
  );
};

export default AppRadioButton;