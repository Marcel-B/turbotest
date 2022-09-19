import React, { useEffect } from "react";
import { DataGrid, GridColDef, GridRowsProp } from "@mui/x-data-grid";
import { useStore } from "store";

const AdminPanel = () => {
  const messungen = useStore(state => state.aquariumMessungen);
  const fetchMessungen = useStore(state => state.fetchAquariumMessungen);
  const fetchAquarien = useStore(state => state.fetchAquarien);
  const aquarien = useStore(state => state.aquarien);

  useEffect(() => {
    console.log("__useEffect - AdminPanel");

    fetchAquarien()
      .then(() => {
        if (aquarien && aquarien.length > 0) {
          const aqua = aquarien[0];
          if (aqua) {
            fetchMessungen(aqua.id)
              .catch(e => console.error(e));
          }
        }
      })
      .catch(e => console.error(e));

  }, [fetchAquarien, aquarien, fetchMessungen]);

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
      {aquarien?.length > 0 ?
        <div style={{ height: 300, width: "100%" }}>
          <DataGrid rows={rows} columns={columns} />
        </div> : <></>
      }
    </>);
};
export default AdminPanel;