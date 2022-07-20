import ExpandMoreIcon from "@mui/icons-material/ExpandMore";
import AquariumFeedItem from "./AquariumFeedItem";
import { Accordion, AccordionDetails, AccordionSummary, Box } from "@mui/material";
import React from "react";
import { Aquarium } from "../domain";
import Notiz from "domain/notiz";
import { Messung } from "domain/messung";
import { Duengung } from "domain/duengung";
import { Fisch } from "domain/fisch";
import MessungFeedItem from "./MessungFeedItem";
import DuengungFeedItem from "./DuengungFeedItem";
import NotizFeedItem from "./NotizFeedItem";
import FischFeedItem from "./FischFeedItem";

interface Props {
  id: string;
  item: Aquarium | Notiz | Messung | Duengung | Fisch;
  aquaType: string;
  datum: string;
}

const FeedItem = ({ id, item, aquaType, datum }: Props) => {
  return (
    <Box>
      {
        aquaType === "notiz" ? (
            <NotizFeedItem
              key={id}
              datum={datum}
              notiz={item as Notiz} />
          ) :
          aquaType === "fisch" ? (
              <FischFeedItem
                key={id}
                datum={datum}
                fisch={item as Fisch} />
            ) :
            aquaType === "aquarium" ? (
                <AquariumFeedItem
                  key={id}
                  datum={datum}
                  aquarium={item as Aquarium} />
              ) :
              aquaType === "duengung" ? (
                  <DuengungFeedItem
                    key={id}
                    datum={datum}
                    duengung={item as Duengung} />
                ) :
                aquaType === "messung" ? (
                  <MessungFeedItem
                    key={id}
                    datum={datum}
                    messung={item as Messung} />
                ) : (

                  <Accordion>
                    <AccordionSummary
                      expandIcon={<ExpandMoreIcon />}>
                      Unbekannter Eingrag
                    </AccordionSummary>
                    <AccordionDetails>
                      <p>Unbekannter Eingrag</p>
                    </AccordionDetails>
                  </Accordion>)
      }
    </Box>
  );
};

export default FeedItem;