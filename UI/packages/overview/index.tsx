import React, { Fragment, useEffect } from "react";
import { DataGrid, GridColDef, GridRowsProp } from "@mui/x-data-grid";
import { useStore } from "store";
import { format } from "date-fns";
import { Box, Divider, FormControl, InputLabel, MenuItem, Select, SelectChangeEvent, Typography } from "@mui/material";
import Chart from "chart";

const Overview = () => {
  const messungen = useStore(state => state.aquariumMessungen);
  const fetchMessungen = useStore(state => state.fetchAquariumMessungen);
  const fetchAquarien = useStore(state => state.fetchAquarien);
  const aquarien = useStore(state => state.aquarien);
  const aquarium = useStore(state => state.aquarium);
  const setAquarium = useStore(state => state.setAquarium);

  const handleChange = (event: SelectChangeEvent) => {
    const aquar = aquarien.find(x => x.id === event.target.value as string);
    if (aquar)
      setAquarium(aquar);
  };

  useEffect(() => {

    fetchAquarien()
      .catch(e => console.error(e));

    if (aquarium) {
      fetchMessungen(aquarium.id)
        .catch(e => console.error(e));
    }
  }, [fetchAquarien, aquarium]);

  const rows: GridRowsProp = messungen?.timestamps?.map(messung => {
    const rowData = messung.messungen.reduce((result, item) => {
      return { ...result, [item.wert]: item.menge };
    }, {});
    return { id: messung.datum, datum: format(new Date(messung.datum), "dd.MM."), ...rowData };
  }) ?? [];

  const columns: GridColDef[] = [{ field: "datum", headerName: "Datum" }, ...messungen?.header?.map(name => {
    return {
      field: name, headerName: name, width: 150
    };
  }) ?? []];


  return (
    <>
      <Fragment>
        <Typography variant="h4">Messwertübersicht</Typography>
        <Divider orientation="horizontal" sx={{ mb: 2 }} />
        <Box sx={{ minWidth: 120, paddingBottom: 2 }}>
          <FormControl fullWidth>
            <InputLabel id="demo-simple-select-label">Aquarium</InputLabel>
            <Select
              labelId="demo-simple-select-label"
              id="demo-simple-select"
              value={aquarium?.id}
              label="Aquarium"
              onChange={handleChange}
            >
              {aquarien && aquarien.map(a =>
                <MenuItem key={a?.id} value={a?.id}>{a.name}</MenuItem>
              )}
            </Select>
          </FormControl>
        </Box>
        {aquarium &&
          <div style={{ height: 300, width: "100%" }}>
            <DataGrid rows={rows} columns={columns} />
          </div>
        }
        <Chart />
      </Fragment>
    </>);
};
export default Overview;