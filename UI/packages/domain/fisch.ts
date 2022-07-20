import { Entity } from "./entity";
import { Aquarium } from "./aquarium";
import { Bereich } from "./bereich";

export interface Fisch extends Entity {
  id: string;
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
  aquarium: Aquarium;
}
