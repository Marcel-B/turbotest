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
    return {
      id: messung.datum, col1: messung.datum, col2: messung.datum
    };
  });
  /*
    [
      { id: 1, col1: "Hello", col2: "World" },
      { id: 2, col1: "DataGridPro", col2: "is Awesome" },
      { id: 3, col1: "MUI", col2: "is Amazing" }
    ];
  */
  const columns: GridColDef[] = [
    { field: "col1", headerName: "Column 1", width: 150 },
    { field: "col2", headerName: "Column 2", width: 150 }
  ];

  return (
    <>
      <h1>Listen</h1>
      <div style={{ height: 300, width: "100%" }}>
        <DataGrid rows={rows} columns={columns} />
      </div>
    </>);
};
export default AdminPanel;