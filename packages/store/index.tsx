import create from "zustand";
import agent from "./agent";
import { devtools, persist } from "zustand/middleware";
import { Aquarium } from "shared-types";
import User from "shared-types/user";

export default agent;

export type State = {
  aquarien: Aquarium[],
  redirectUrl: string | null,
  token: string | undefined,
  displayName: string | null,
  user: User | null,
  addAquarium: (aquarium: Aquarium) => void;
  logout: () => void;
  setToken: (token: string) => void;
  setUser: (user: User) => void;
  setRedirectUrl: (redirectUrl?: string | null) => void;
  fetchAquarien: () => Promise<void>;
};

export const useStore = create<State>()(devtools(persist((set, get, api) => ({
  aquarien: [],
  token: undefined,
  displayName: null,
  redirectUrl: null,
  user: null,
  logout: () => {
    set((state) => ({
      aquariuen: [],
      token: undefined,
      user: null,
      displayName: null,
      redirectUrl: "/"
    }), false, "logout");
    window.localStorage.removeItem("token");
    window.sessionStorage.removeItem("fishbook-storage");
  },
  setToken: (token: string) => {
    window.localStorage.setItem("token", token);
    set((state: State) => ({ token }), false, "setToken");
  },
  setUser: (user: User) => {
    set((state) => ({ token: user.token, displayName: user.displayName, user: user }), false, "setUser");
  },
  setRedirectUrl: (redirectUrl: string | null = null) => {
    set((state: State) => ({ redirectUrl }), false, "setRedirectUrl");
  },
  fetchAquarien:
    async () => {
      const aquarien = await agent.AquariumCall.list();
      set((state: State) => ({ aquarien }), false, "fetchAquarien");
    },
  addAquarium: (aquarium: Aquarium) => set((state) => ({ aquarien: [...state.aquarien, aquarium] }), false, "addAquarium")
}), {
  name: "fishbook-storage", // unique name
  getStorage: () => sessionStorage // (optional) by default, 'localStorage' is used
}), {
  enabled: true,
  anonymousActionType: "unbekannt",
  name: "Fishbook"
}));
