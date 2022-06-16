import create from "zustand";
import agent from "./agent";
import { devtools, persist } from "zustand/middleware";
import { Aquarium, Timer } from "shared-types";
import User from "shared-types/user";
import produce from "immer";
import Feed from "shared-types/feed";

export default agent;

const devToolsOptions = {
  enabled: true,
  anonymousActionType: "unbekannt",
  name: "Fishbook"
};

const stateOptions = {
  name: "fishbook-storage", // unique name
  getStorage: () => sessionStorage // (optional) by default, 'localStorage' is used
};

interface State {
  aquarien: Aquarium[],
  displayName: string | null,
  feed: Feed,
  redirectUrl: string | null,
  timers: Timer[],
  token: string | null,
  user: User | null,
  addAquarium: (aquarium: Aquarium) => void;
  addTimer: (timer: Timer) => void;
  fetchAquarien: () => Promise<void>;
  fetchFeed: (page: number, days: number) => Promise<void>;
  incrementSecond: (timer: Timer) => void;
  logout: () => void;
  pauseTimer: (timer: Timer) => void;
  removeTimer: (timer: Timer) => void;
  setRedirectUrl: (redirectUrl?: string | null) => void;
  setTime: (time: { timer: Timer, seconds: number }) => void;
  setToken: (token: string) => void;
  setUser: (user: User) => void;
  startTimer: (timer: Timer) => void;
}

const initial = {
  aquarien: [],
  displayName: null,
  feed: { total: 0, groupedFeeds: [] },
  redirectUrl: null,
  timers: [],
  token: null,
  user: null
};

let start = { ...initial };
export const useStore = create<State>()(devtools(persist((set) => ({
  ...start,
  addAquarium: (aquarium: Aquarium) => set(produce(state => {
    state.aquarien = [...state.aquarien, aquarium];
  }), false, "addAquarium"),
  addTimer: (timer: Timer) => set(produce((state: State) => {
    if (state.timers.find((t: Timer) => t.name === timer.name)) {
      alert(`Timer '${timer.name}' schon vorhanden`);
      return;
    }
    state.timers = [...state.timers, timer]
      .sort((a, b) => a.current > b.current ? 1 : a.current === b.current ? 0 : -1);
  }), false, "addTimer"),
  fetchAquarien: async () => {
    const aquarien = await agent.AquariumCall.list();
    set(produce(state => {
      state.aquarien = aquarien;
    }), false, "fetchAquarien");
  },
  fetchFeed: async (page: number, days = 7) => {
    const feed = await agent.FeedCall.list(page, days);
    set(produce(state => {
      state.feed = feed;
    }), false, "fetchFeed");
  },
  incrementSecond: (timer: Timer) => {
    set(produce(state => {
      const ti = state.timers.find((t: Timer) => t.name === timer.name)!;
      ti.current -= 1;
      if (ti.current <= 0) {
        ti.ringActive = true;
        ti.active = false;
        ti.current = 0;
      }
    }), false, "incrementSecond");
  },
  logout: () => {
    window.localStorage.removeItem("token");
    window.sessionStorage.removeItem("fishbook-storage");
    set(produce(state => {
      state.aquarien = initial.aquarien;
      state.token = initial.token;
      state.feed = initial.feed;
      state.timers = initial.timers;
      state.user = initial.user;
      state.displayName = initial.displayName;
      state.redirectUrl = "/";
    }), false, "logout");
  },
  pauseTimer: (timer: Timer) => {
    //timer.active = false;
    set(produce(state => {
      state.timers.find((t: Timer) => t.name === timer.name)!.active = false;
    }), false, "pauseTimer");
  },
  removeTimer: (timer: Timer) => {
    set(produce(state => {
      state.timers = [...state.timers.filter((t: Timer) => t.name !== timer.name)];
    }), false, "removeTimer");
  },
  setRedirectUrl: (redirectUrl: string | null = null) => {
    set(produce(state => {
      state.redirectUrl = redirectUrl;
    }), false, "setRedirectUrl");
  },
  setTime: (time: { timer: Timer, seconds: number }) => {
    set(produce(state => {
      const ti = state.timers.find((t: Timer) => t.name === time.timer.name)!;
      ti.current = time.seconds;
      ti.seconds = time.seconds;
    }), false, "setTime");
  },
  setToken: (token: string) => {
    window.localStorage.setItem("token", token);
    set(produce(state => {
      state.token = token;
    }), false, "setToken");
  },
  setUser: (user: User) => {
    window.localStorage.setItem("token", user.token);
    set(produce(state => {
      state.user = user;
      state.token = user.token;
      state.displayName = user.displayName;
    }), false, "setUser");
  },
  startTimer: (timer: Timer) => {
    set(produce(state => {
      const t = state.timers.find((t: Timer) => t.name === timer.name)!;
      t.active = true;
      t.ringActive = false;
    }), false, "startTimer");
  }
}), stateOptions), devToolsOptions));
