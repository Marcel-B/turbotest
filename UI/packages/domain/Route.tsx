import * as React from "react";

export interface Route {
  element: React.FunctionComponent;
  path: string;
}

export default Route;