import React, { useEffect } from "react";
import { DataGrid, GridColDef, GridRowsProp } from "@mui/x-data-grid";
import { useStore } from "store";

const AdminPanel = () => {
  const messungen = useStore(state => state.aquariumMessungen);
  const fetchMessungen = useStore(state => state.fetchAquariumMessungen);
  const aquarien = useStore(state => state.aquarien);

  useEffect(() => {
    const aqua = aquarien[0];
    fetchMessungen(aqua.id).catch(e => console.error(e));
  }, []);

  const rows: GridRowsProp = messungen!.timestamps.map(messung => {
    const foo = messung.messungen.reduce((fi, x) => {
      return { ...fi, [x.wert]: x.menge };
    }, {});
    return { id: messung.datum, datum: messung.datum, ...foo };
  });
 
  const columns: GridColDef[] = [{ field: "datum", headerName: "Datum" }, ...messungen!.header.map(s => {
    return {
      field: s, headerName: s, width: 150
    };
  })];

  return (
    <>
      <h1>Listen</h1>
      <div style={{ height: 300, width: "100%" }}>
        <DataGrid rows={rows} columns={columns} />
      </div>
    </>);
};
export default AdminPanel;