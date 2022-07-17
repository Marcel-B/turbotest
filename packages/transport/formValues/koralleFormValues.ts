import {Bereich} from "domain/bereich";

export interface KoralleFormValues {
  id?: string;
  name: string;
  wissenschaftlich: string;
  herkunft: string;
  salinitaet: Bereich;
  nitrat: Bereich;
  phosphat: Bereich;
  calcium: Bereich;
  magnesium: Bereich;
  kh: Bereich;
  temperatur: Bereich;
  stroemung: string;
  schwierigketisgrad: string;
  datum: Date;
  aquariumId: string;
}

export default KoralleFormValues;
