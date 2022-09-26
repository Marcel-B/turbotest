import React, { Fragment, useEffect, useState } from "react";
import { useStore } from "store";
import { AxisOptions, Chart as FooChart } from "react-charts";

type DailyStars = {
  date: Date,
  stars: number,
}

type Series = {
  label: string,
  data: DailyStars[]
}

const Chart = () => {
  const fetchMessungen = useStore(state => state.fetchAquariumMessungen);
  const messungen = useStore(state => state.aquariumMessungen);
  const aquarium = useStore(state => state.aquarium);
  const [foo, setFoo] = useState<DailyStars[]>([]);

  const data: Series[] = [
    {
      label: "React Charts",
      data: foo
    }
  ];

  useEffect(() => {
    console.log("__useEffect - Chart");

    if (aquarium)
      fetchMessungen(aquarium.id)
        .catch(e => console.error(e));

    if (messungen) {
      const h = messungen.header[0];
      const l: DailyStars[] = messungen.timestamps.map(x => {

        console.log("__mes", messungen);
        const res = { stars: x.messungen.find(y => y.wert === h)?.menge ?? 0, date: new Date(x.datum) };
        console.log("__res", res);
        return res;
      });
      setFoo(l);
    }

  }, [fetchMessungen, setFoo, aquarium]);


  const primaryAxis = React.useMemo(
    (): AxisOptions<DailyStars> => ({
      getValue: datum => datum.date
    }),
    []
  );

  const secondaryAxes = React.useMemo(
    (): AxisOptions<DailyStars>[] => [
      {
        getValue: datum => datum.stars
      }
    ],
    []
  );

  return (
    <>
      {aquarium &&
        <Fragment>

          <h1>{aquarium?.name}</h1>
          {foo.length > 0 &&
            <FooChart
              options={{
                data,
                primaryAxis,
                secondaryAxes
              }}
            />}
        </Fragment>
      }
    </>);
};

export default Chart;