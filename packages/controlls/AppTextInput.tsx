import { TextField } from "@mui/material";
import React from "react";
import { useController, UseControllerProps } from "react-hook-form";

interface Props extends UseControllerProps<any, any> {
  label: string;
  multiline?: boolean;
  rows?: number;
  default?: string | number | null;
  type?: string;
}

const AppTextInput = (props: Props) => {
  const { fieldState, field } = useController({ ...props, defaultValue: props.default });
  return (<TextField
      variant="outlined" {
      ...props} {...field}
      fullWidth
      error={!!fieldState.error}
      helperText={fieldState.error?.message}
      multiline={props.multiline}
      rows={props.rows}
      type={props.type} />
  );
};

export default AppTextInput;