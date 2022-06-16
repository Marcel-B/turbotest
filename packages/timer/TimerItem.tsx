import * as React from "react";
import Timer from "shared-types/timer";
import { useEffect, useRef } from "react";
import { useForm } from "react-hook-form";
import DeleteIcon from "@mui/icons-material/Delete";
import PlayArrowIcon from "@mui/icons-material/PlayArrow";
import StopIcon from "@mui/icons-material/Stop";
import { Box, Divider, Grid, IconButton, Paper, TextField, Typography } from "@mui/material";
import { TestType } from "shared-types";
import { testTimerTypes } from "./index";
import { useStore } from "store";

interface Props {
  timer: Timer;
}

export const TimerItem = ({ timer }: Props) => {
  const { register, reset, handleSubmit } = useForm<TimerItemValues>();
  const incrementSecond = useStore(state => state.incrementSecond);
  const { setTime, startTimer, pauseTimer, removeTimer } = useStore();
  const timers = useRef(useStore.getState().timers);

  useEffect(() => {
    console.log("Use timer Effect");
    useStore.subscribe(
      state => (timers.current = state.timers));
    if (timer.seconds && !timer.active) {
      reset({
        minuten: Math.floor(timer.seconds / 60).toString(),
        sekunden: Math.floor(timer.seconds % 60).toString()
      });
    }

    // @ts-ignore
    let interval: NodeJS.Timer | null = null;
    console.log("Intervall", interval);
    console.log("Timer", timer);
    if (timer.active) {
      interval = setInterval(() => {
        console.log("Increment Timer", timer);
        incrementSecond(timer);
      }, 1000);
    } else if (!timer.active && timer.seconds === 0) {
      clearInterval(interval!);
      //dispatch(resetTimer(timer.name));
    }
    if (timer.ringActive) {
      playSound();
    }
    return () => clearInterval(interval!);
  }, [timer, timers, incrementSecond, reset]);

  const displayTime = (seconds: number) => {
    const sek = Math.floor(seconds % 60);
    const min = Math.floor(seconds / 60);
    return `${String(min).padStart(2, "0")}${sek % 2 === 0 ? ":" : " "}${String(sek).padStart(2, "0")}`;
  };

  const handleStopTimer = () => {
    pauseTimer(timer);
  };

  const playSound = () => {
    /*
    const synth = new Tone.PolySynth(Tone.Synth).toDestination();
     const now = Tone.now()
     synth.triggerAttack("D4", now);
     synth.triggerAttack("F4", now + 0.2);
     synth.triggerAttack("A4", now + 0.4);
     synth.triggerAttack("C5", now + 0.6);
     synth.triggerAttack("E5", now + 0.8);
     synth.triggerRelease(["D4", "F4", "A4", "C5", "E5"], now + 1.2);
     */
  };

  const handleDeleteTimer = () => {
    removeTimer(timer);
  };

  const start = (data: TimerItemValues) => {
    const { minuten, sekunden } = data;
    const sek = parseInt(sekunden);
    const min = parseInt(minuten);
    const gesamt = (isNaN(sek) ? 0 : sek) + 60 * (isNaN(min) ? 0 : min);

    setTime({ seconds: gesamt, timer: timer });
    startTimer(timer);
    console.log("Start Timer");
  };

  return (<Paper sx={{
    p: 2,
    mt: 2
  }}>
    <Box sx={{
      display: "flex",
      justifyContent: "space-between",
      mb: 1
    }}>
      <Typography variant="h5">{timer.name}</Typography>
      <Typography
        sx={{ fontFamily: "monospace" }}
        color="text.secondary"
        variant="h5">{displayTime(timer.current)}</Typography>
    </Box>
    <Divider orientation="horizontal" />
    {timer.testType !== TestType.Common ?
      <ul>{testTimerTypes.find(ttt => ttt.type === timer.testType)!.description.split(",").map((item, idx) =>
        <li key={idx}><Typography variant="body2">{item}</Typography></li>)}</ul> :
      <></>}

    <form onSubmit={handleSubmit(start)}>
      <Grid container spacing={2}>
        <Grid item xs={12}>
          <TextField
            disabled={timer.active}
            {...register("minuten")}
            name="minuten"
            label="Minuten"
            fullWidth
            type="number" />
        </Grid>
        <Grid item xs={12}>
          <TextField
            disabled={timer.active}
            {...register("sekunden")}
            name="sekunden"
            fullWidth
            label="Sekunden"
            type="number" />
        </Grid>
      </Grid>

      <Box sx={{
        display: "flex",
        justifyContent: "space-between"
      }}>
        <Box>
          <IconButton disabled={timer.active} color="primary" type="submit"><PlayArrowIcon /></IconButton>
          <IconButton
            disabled={!timer.active}
            color="warning"
            onClick={() => handleStopTimer()}>
            <StopIcon />
          </IconButton>
        </Box>
        <Box>
          <IconButton
            color="error"
            onClick={() => handleDeleteTimer()}>
            <DeleteIcon />
          </IconButton>
        </Box>
      </Box>
    </form>
  </Paper>);
};

interface TimerItemValues {
  name: string;
  minuten: string;
  sekunden: string;
}

export default TimerItem;