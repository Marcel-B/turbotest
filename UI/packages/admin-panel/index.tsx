import React, { useEffect } from "react";
import { DataGrid, GridColDef, GridRowsProp } from "@mui/x-data-grid";
import { useStore } from "store";
import { format } from "date-fns";
import { Box, Divider, FormControl, InputLabel, MenuItem, Select, SelectChangeEvent, Typography } from "@mui/material";

const AdminPanel = () => {
  const messungen = useStore(state => state.aquariumMessungen);
  const fetchMessungen = useStore(state => state.fetchAquariumMessungen);
  const fetchAquarien = useStore(state => state.fetchAquarien);
  const aquarien = useStore(state => state.aquarien);

  const [aquarium, setAquarium] = React.useState("");

  const handleChange = (event: SelectChangeEvent) => {
    setAquarium(event.target.value as string);
  };

  useEffect(() => {
    console.log("__useEffect - AdminPanel");

    fetchAquarien()
      .catch(e => console.error(e));

    if (aquarium) {
      fetchMessungen(aquarium)
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
      <Typography variant="h4">Messwertübersicht</Typography>
      <Divider orientation="horizontal" sx={{ mb: 2 }} />
      <Box sx={{ minWidth: 120, paddingBottom: 2 }}>
        <FormControl fullWidth>
          <InputLabel id="demo-simple-select-label">Aquarium</InputLabel>
          <Select
            labelId="demo-simple-select-label"
            id="demo-simple-select"
            value={aquarium}
            label="Aquarium"
            onChange={handleChange}
          >
            {aquarien && aquarien.map(a =>
              <MenuItem key={a.id} value={a.id}>{a.name}</MenuItem>
            )}
          </Select>
        </FormControl>
      </Box>
      {aquarien && aquarien.length > 0 ?
        <div style={{ height: 300, width: "100%" }}>
          <DataGrid rows={rows} columns={columns} />
        </div> : <></>
      }
    </>);
};
export default AdminPanel;