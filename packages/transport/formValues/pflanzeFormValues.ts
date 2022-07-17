import {Bereich} from "domain/bereich";

export interface PflanzeFormValues {
  id?: string;
  name: string;
  wissenschaftlich: string;
  herkunft: string;
  ph: Bereich;
  gh: Bereich;
  kh: Bereich;
  temperatur: Bereich;
  bereich: string;
  wachstum: string;
  emers: boolean;
  schwierigkeitsgrad: string
  datum: Date;
  aquariumId: string;
}

export default PflanzeFormValues;
