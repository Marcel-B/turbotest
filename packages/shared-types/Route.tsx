import * as React from "react";

export type Route = {
  element: React.FunctionComponent;
  path: string;
}

export default Route;