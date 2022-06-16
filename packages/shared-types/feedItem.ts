import { Aquarium } from "./dist";
import { Notiz } from "./notiz";
import { Messung } from "./messung";
import { Duengung } from "./duengung";
import { Fisch } from "./fisch";

export interface FeedItem {
  id: string;
  aquaType: string;
  item: Aquarium | Notiz | Messung | Duengung | Fisch;
}

export default FeedItem;