import { Aquarium } from "./aquarium";
import { Entity } from "./entity";

export interface Notiz extends Entity {
  id: string;
  text: string;
  datum: Date;
  tag: string;
  aquarium: Aquarium;
}

export interface NotizFormValues {
  id?: string;
  text?: string;
  datum: Date;
  tag?: string;
  aquarium: string;
}

export default Notiz;