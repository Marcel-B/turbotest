import { Entity } from "./entity";
import { Aquarium } from "./aquarium";

export interface Messung extends Entity {
  id: string;
  menge: number;
  datum: Date;
  wert: string;
  aquarium: Aquarium;
}
