import {HubConnection, HubConnectionBuilder} from "@microsoft/signalr";

const URL = process.env.HUB_ADDRESS ?? "http://localhost:5285/hub"; //or whatever your backend port is

const connection = new HubConnectionBuilder()
  .withUrl(URL)
  .withAutomaticReconnect()
  .build();

connection.start().catch(err => console.error(err));

export default connection;

