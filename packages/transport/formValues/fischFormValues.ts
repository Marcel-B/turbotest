import {Bereich} from "domain/bereich";

export interface FischFormValues {
  id?: string;
  name: string;
  wissenschaftlich: string;
  herkunft: string;
  ph: Bereich;
  gh: Bereich;
  kh: Bereich;
  temperatur: Bereich;
  schwimmzone: string;
  datum: Date;
  anzahl: number;
  geschlecht: string;
  aquariumId: string;
}

export default FischFormValues;