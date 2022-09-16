import { AquariumMessung } from "./aquariumMessung";
export interface Timestamp<T> {
  datum: string;
  messungen: T;
}
export interface AquariumMessungen{
  id: string;
  name: string;
  liter: number;
  timestamps: Timestamp<AquariumMessung>[];
}