import { Entity } from "./entity";
import { Aquarium } from "./dist";

export interface Duengung extends Entity {
  id: string;
  menge: number;
  datum: Date;
  duenger: string;
  aquarium: Aquarium;
}