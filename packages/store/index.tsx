import create from "zustand";
import agent from "./agent";
import { devtools, persist } from "zustand/middleware";
import { Aquarium, Timer } from "shared-types";
import User from "shared-types/user";

export default agent;

interface State {
  aquarien: Aquarium[],
  redirectUrl: string | null,
  token: string | undefined,
  displayName: string | null,
  user: User | null,
  timers: Timer[],
  addAquarium: (aquarium: Aquarium) => void;
  addTimer: (timer: Timer) => void;
  fetchAquarien: () => Promise<void>;
  logout: () => void;
  setRedirectUrl: (redirectUrl?: string | null) => void;
  setToken: (token: string) => void;
  setUser: (user: User) => void;
};

const initial = {
  aquarien: [],
  token: undefined,
  timers: [],
  displayName: null,
  redirectUrl: null,
  user: null
};

export const useStore = create<State>()(devtools(persist((set, get, api) => ({
  ...initial,
  addAquarium: (aquarium: Aquarium) => set((state) => ({ aquarien: [...state.aquarien, aquarium] }), false, "addAquarium"),
  addTimer: (timer: Timer) => set((state) => ({
    timers: [...state.timers, timer]
  }), false, "addTimer"),
  logout: () => {
    set((state) => ({
      aquariuen: [],
      token: undefined,
      user: null,
      displayName: null,
      timers: [],
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
    }
}), {
  name: "fishbook-storage", // unique name
  getStorage: () => sessionStorage // (optional) by default, 'localStorage' is used
}), {
  enabled: true,
  anonymousActionType: "unbekannt",
  name: "Fishbook"
}));
