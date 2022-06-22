import { Entity } from "./entity";

export interface Aquarium extends Entity {
  id: string;
  name: string;
  liter: number;
  datum: Date;
}

export interface AquariumFormValues {
  name: string;
  liter: number;
  datum?: Date;
}

export default Aquarium;
