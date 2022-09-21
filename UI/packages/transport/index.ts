import axios, { AxiosResponse } from "axios";
import { Aquarium, Duengung, Fisch, Messung } from "../domain";
import User from "domain/user";
import UserLogin from "domain/user-login";
import Feed from "domain/feed";
import { Notiz } from "domain/notiz";
import UserFormValues from "./formValues/userFormValues";
import NotizFormValues from "./formValues/notizFormValues";
import AquariumFormValues from "./formValues/aquariumFormValues";
import DuengungFormValues from "./formValues/duengungFormValues";
import MessungFormValues from "./formValues/messungFormValues";
import FischFormValues from "./formValues/fischFormValues";
import KoralleFormValues from "./formValues/koralleFormValues";
import { AquariumMessungen } from "./dtos/aquariumMessungen";
import { getUserManager } from "security";

const responseBody = <T>(response: AxiosResponse<T>) => response.data;
console.log("__Agent URL", process.env.REACT_APP_API_URL);
// axios.defaults.baseURL = process.env.REACT_APP_API_URL;
 axios.defaults.baseURL = "http://localhost:5046";
//axios.defaults.baseURL = "http://192.168.2.103:5046";

axios
  .interceptors
  .request
  .use(config => {
    const token = window.localStorage.getItem("token");
    if (token) {
      if (config.headers)
        config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
  });

axios
  .interceptors
  .response
  .use(config => {
    return config;
  }, error => {
    if (error.request.status === 401) {
      const userManager = getUserManager();
      userManager.signinRedirect().catch(e => console.error(e));
    }
    return Promise.reject(error);
  });

const requests = {
  get: <T>(url: string) => axios.get<T>(url).then(responseBody),
  post: <T>(url: string, body: {}) => axios.post<T>(url, body).then(responseBody),
  put: <T>(url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
  del: <T>(url: string) => axios.delete<T>(url).then(responseBody)
};

const AquariumCall = {
  list: () => requests.get<Aquarium[]>("/api/aquarium"),
  create: (aquarium: AquariumFormValues) => requests.post<Aquarium>("/api/aquarium", aquarium),
  read: (id: string) => requests.get<Aquarium>(`/api/aquarium/${id}`),
  update: (aquarium: AquariumFormValues) => requests.put<Aquarium>(`/api/aquarium/${aquarium.id}`, aquarium),
  delete: (id: string) => requests.del<string>(`/api/aquarium/${id}`),
  messungenById: (id: string) => requests.get<AquariumMessungen>(`/api/Aquarium/${id}/Messungen`)
};

const NotizCall = {
  list: () => requests.get<Notiz[]>("/api/notiz"),
  create: (notiz: NotizFormValues) => requests.post<Notiz>("/api/notiz", notiz),
  read: (id: string) => requests.get<Notiz>(`/api/notiz/${id}`),
  update: (notiz: NotizFormValues) => requests.put<Notiz>(`/api/notiz/${notiz.id}`, notiz),
  delete: (id: string) => requests.del<string>(`/api/notiz/${id}`)
};

const FischCall = {
  list: () => requests.get<Fisch[]>("/api/fisch"),
  create: (fisch: FischFormValues) => requests.post<Fisch>("/api/fisch", fisch),
  read: (id: string) => requests.get<Fisch>(`/api/fisch/${id}`),
  update: (fisch: FischFormValues) => requests.put<Fisch>(`/api/fisch/${fisch.id}`, fisch),
  delete: (id: string) => requests.del<string>(`/api/fisch/${id}`)
};

const KoralleCall = {
  list: () => requests.get<Fisch[]>("/api/koralle"),
  create: (koralle: KoralleFormValues) => requests.post<Fisch>("/api/koralle", koralle),
  read: (id: string) => requests.get<Fisch>(`/api/koralle/${id}`),
  update: (koralle: KoralleFormValues) => requests.put<Fisch>(`/api/koralle/${koralle.id}`, koralle),
  delete: (id: string) => requests.del<string>(`/api/koralle/${id}`)
};

const DuengungCall = {
  list: () => requests.get<Duengung[]>("/api/duengung"),
  create: (duengung: DuengungFormValues) => requests.post<Duengung>("/api/duengung", duengung),
  update: (duengung: DuengungFormValues) => requests.put<Duengung>(`/api/duengung/${duengung.id}`, duengung),
  delete: (id: string) => requests.del<string>(`/api/duengung/${id}`)
};

const MessungCall = {
  list: () => requests.get<Messung[]>("/api/messung"),
  create: (messung: MessungFormValues) => requests.post<Messung>("/api/messung", messung),
  update: (messung: MessungFormValues) => requests.put<Messung>(`/api/messung/${messung.id}`, messung),
  delete: (id: string) => requests.del<string>(`/api/messung/${id}`)
};

const FeedCall = {
  list: (page: number, days: number) => requests.get<Feed>(`/api/feed/grouped?page=${page}&days=${days}`)
};

const AccountCall = {
  current: () => requests.get<User>("/api/account"),
  login: (user: UserLogin) => requests.post<User>("/api/account/login", user),
  register: (user: UserFormValues) => requests.post<User>("/api/account/register", user)
};

export const agent = {
  AquariumCall,
  AccountCall,
  DuengungCall,
  FeedCall,
  FischCall,
  KoralleCall,
  MessungCall,
  NotizCall
};

export default agent;
export type {
  UserFormValues,
  DuengungFormValues,
  AquariumFormValues,
  NotizFormValues,
  MessungFormValues,
  FischFormValues
};
