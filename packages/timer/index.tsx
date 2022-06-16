import * as React from "react";
import { Box, Button, ButtonGroup, Divider, IconButton, Paper, TextField, Typography } from "@mui/material";
import { TestTimer, TestType, Timer as TTimer } from "shared-types";
import * as yup from "yup";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import TimerIcon from "@mui/icons-material/Timer";
import AddCircleOutlineIcon from "@mui/icons-material/AddCircleOutline";
import { useStore } from "store";
import TimerItem from "./TimerItem";

export const testTimerTypes: TestTimer[] = [
  { text: "", type: TestType.Common, description: "", seconds: 0 },
  { text: "NO₂", type: TestType.NO2, description: "5ml Wasser, 5 Tropfen 1, 5 Tropfen 2", seconds: 300 },
  {
    text: "NH₄",
    type: TestType.NH4,
    description: "5ml Wasser, 4 Tropfen 1, 4 Tropfen 2, 5 Tropfen 3",
    seconds: 60 * 15
  },
  { text: "NO₃", type: TestType.NO3, description: "10ml Wasser, 1 großer Löffel 1, 6 Tropfen 2", seconds: 600 },
  { text: "PO₄", type: TestType.PO4, description: "10ml Wasser, 1 kleiner Löffel 1, 10 Tropfen 2", seconds: 600 },
  { text: "FE", type: TestType.FE, description: "5ml Wasser, 5 Tropfen 1", seconds: 600 },
  { text: "PH", type: TestType.PH, description: "5ml Wasser, 4 Tropfen 1", seconds: 180 },
  { text: "K", type: TestType.K, description: "15ml Wasser, 10 Tropfen 1, 1 großer Löffel 2", seconds: 60 }
];

const schema = yup.object({
  timerName: yup.string().required("benötigt")
}).required();

const Timer = () => {
  const addTimer = useStore(state => state.addTimer);

  const {
    formState: { errors },
    handleSubmit,
    resetField,
    register
  } = useForm<{ timerName: string }>({ resolver: yupResolver(schema) });

  const handleAddTypeTimer = (type: TestType, name?: string) => {
    const timerType = testTimerTypes.find(ttt => ttt.type === type);
    if (timerType) {
      const timer: TTimer = {
        testType: type,
        name: name ?? timerType.text,
        current: 0,
        seconds: timerType.seconds,
        ringActive: false,
        active: false
      };
      addTimer(timer);
    }
    resetField("timerName");
  };


  const onSubmit = (data: { timerName: string }) => {
    handleAddTypeTimer(TestType.Common, data.timerName);
  };

  return (
    <Box sx={{
      mt: 2
    }}>
      <Box sx={{
        mt: 2,
        display: "flex",
        justifyContent: "space-between",
        alignItems: "baseline"
      }}>
        <Typography
          variant="h4">Timer</Typography>
        <TimerIcon fontSize="medium" color="disabled" />
      </Box>
      <Divider orientation="horizontal" />
      <Paper sx={{ p: 2, mt: 2 }}>
        <Box sx={{ display: "flex", justifyContent: "space-around", pb: 2 }}>
          <ButtonGroup
            size="small"
            variant="outlined"
            aria-label="outlined button group">
            <Button onClick={() => handleAddTypeTimer(TestType.PO4)}>PO₄</Button>
            <Button onClick={() => handleAddTypeTimer(TestType.NO2)}>NO₂</Button>
            <Button onClick={() => handleAddTypeTimer(TestType.NH4)}>NH₄</Button>
            <Button onClick={() => handleAddTypeTimer(TestType.FE)}>FE</Button>
            <Button onClick={() => handleAddTypeTimer(TestType.NO3)}>NO₃</Button>
            <Button onClick={() => handleAddTypeTimer(TestType.PH)}>PH</Button>
            <Button onClick={() => handleAddTypeTimer(TestType.K)}>K</Button>
          </ButtonGroup>
        </Box>
        <form onSubmit={handleSubmit(onSubmit)}>
          <Box sx={{
            display: "flex"
          }}>
            <TextField
              label="Timer Name"
              {...register("timerName")}
              defaultValue=""
              helperText={errors.timerName?.message}
              error={!!errors.timerName}
              fullWidth
              name="timerName"
              type="text" />
            <IconButton type="submit"><AddCircleOutlineIcon fontSize="large" /></IconButton>
          </Box>
        </form>
      </Paper>
    </Box>
  );
};

export default Timer;
export { TimerItem };