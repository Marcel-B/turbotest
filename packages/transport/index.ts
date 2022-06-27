import axios, { AxiosResponse } from "axios";
import { Aquarium, Duengung } from "../domain";
import User from "domain/user";
import UserLogin from "domain/user-login";
import Feed from "domain/feed";
import { AquariumFormValues } from "domain/aquarium";
import { Notiz, NotizFormValues } from "domain/notiz";
import { DuengungFormValues } from "domain/duengung";

//const token = useStore.getState().token;
//const unsub1 = useStore.subscribe(console.log);

const responseBody = <T>(response: AxiosResponse<T>) => response.data;
//axios.defaults.baseURL = process.env.REACT_APP_API_URL;
axios.defaults.baseURL = "http://localhost:5046";
//axios.defaults.baseURL = "http://192.168.2.103:3088";

axios.interceptors.request.use(config => {
  const token = window.localStorage.getItem("token");
  if (token) {
    if (config.headers)
      config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});

const requests = {
  get: <T>(url: string) => axios.get<T>(url).then(responseBody),
  post: <T>(url: string, body: {}) => axios.post<T>(url, body).then(responseBody),
  put: <T>(url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
  del: <T>(url: string) => axios.delete<T>(url).then(responseBody)
};

const AquariumCall = {
  list: () => requests.get<Aquarium[]>("/api/aquarium"),
  //details: (id: string) => requests.get<Activity>(`/activities/${id}`),
  create: (aquarium: AquariumFormValues) => requests.post<Aquarium>("/api/aquarium", aquarium)
  //update: (aquarium: AquariumFormValues) => requests.put<Aquarium>(`/api/aquarium/${aquarium.id}`, aquarium),
  //delete: (id: string) => requests.del<string>(`/api/aquarium/${id}`),
};
const NotizCall = {
//  list: () => requests.get<Notiz[]>('/api/notiz'),
  //details: (id: string) => requests.get<Activity>(`/activities/${id}`),
  create: (notiz: NotizFormValues) => requests.post<Notiz>("/api/notiz", notiz)
// update: (notiz: NotizFormValues) => requests.put<Notiz>(`/api/notiz/${notiz.id}`, notiz),
//   delete: (id: string) => requests.del<string>(`/api/notiz/${id}`),
};

/*
const FischCall = {
  list: () => requests.get<Fisch[]>('/api/fisch'),
  create: (fisch: FischFormValues) => requests.post<Fisch>('/api/fisch', fisch),
  update: (fisch: FischFormValues) => requests.put<Fisch>(`/api/fisch/${fisch.id}`, fisch),
  delete: (id: string) => requests.del<string>(`/api/fisch/${id}`),
};
*/
const DuengungCall = {
  list: () => requests.get<Duengung[]>("/api/duengung"),
  create: (duengung: DuengungFormValues) => requests.post<Duengung>("/api/duengung", duengung),
  //update: (duengung: DuengungFormValues) => requests.put<Duengung>(`/api/duengung/${duengung.id}`, duengung),
  delete: (id: string) => requests.del<string>(`/api/duengung/${id}`)
};
/*
const MessungCall = {
  list: () => requests.get<Messung[]>('/api/messung'),
  create: (messung: MessungFormValues) => requests.post<Messung>('/api/messung', messung),
  update: (messung: MessungFormValues) => requests.put<Messung>(`/api/messung/${messung.id}`, messung),
  delete: (id: string) => requests.del<string>(`/api/messung/${id}`),
};
*/
const FeedCall = {
  list: (page: number, days: number) => requests.get<Feed>(`/api/feed/grouped?page=${page}&days=${days}`)
};
/*
const TagCall = {
  list: () => requests.get<string[]>('/api/tag')
};

*/
const AccountCall = {
//current: () => requests.get<User>('/api/account'),
  login: (user: UserLogin) => requests.post<User>("/api/account/login", user)
  //register: (user: UserFormValues) => requests.post<User>('/api/account/register', user)
};

export const agent = {
  AquariumCall,
  AccountCall,
  DuengungCall,
  FeedCall,
  NotizCall
};

export default agent;