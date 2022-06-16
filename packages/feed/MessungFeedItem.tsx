import { Accordion, AccordionDetails, AccordionSummary, Box, Chip, Typography } from "@mui/material";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore";
import DeviceThermostatIcon from "@mui/icons-material/DeviceThermostat";
import React from "react";
import { Messung } from "shared-types/messung";
import { MessungColor } from "styles";

interface Props {
  messung: Messung;
  datum: string;
}

const MessungFeedItem = ({ datum, ...props }: Props) => {
  const getFormattedValue = (value: number, wert: string) => {
    switch (wert) {
      case "PO₄":
      case "NH₄":
      case "NO₂":
      case "NO₃":
      case "K":
      case "FE":
        return new Intl.NumberFormat("de-DE", {
          maximumFractionDigits: 2,
          minimumFractionDigits: 2
        }).format(value) + ` mg/l`;
      case "GH":
      case "KH":
        return new Intl.NumberFormat("de-DE"
        ).format(value) + "°dH";
      default:
        return new Intl.NumberFormat("de-DE", {
          maximumFractionDigits: 2,
          minimumFractionDigits: 2
        }).format(value);
    }
  };

  return (
    <Accordion>
      <AccordionSummary
        expandIcon={<ExpandMoreIcon />}>
        <DeviceThermostatIcon sx={{ color: MessungColor }} />
        <Typography sx={{ width: "50%", flexGrow: 2, ml: 1 }}>Messung</Typography>
        <Chip label={props.messung.aquarium.name} variant="outlined" />
      </AccordionSummary>
      <AccordionDetails>

        <Box sx={{
          display: "flex",
          justifyContent: "space-between"
        }}>
          <Box sx={{
            display: "flex"
          }}>
            <Box sx={{
              mr: 1
            }}>{props.messung.wert}</Box>
            <Box>{getFormattedValue(props.messung.menge, props.messung.wert)}</Box>
          </Box>
          <Box>{datum}</Box>
        </Box>
      </AccordionDetails>
    </Accordion>);
};

export default MessungFeedItem;