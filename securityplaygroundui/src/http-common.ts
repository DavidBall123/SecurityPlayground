import axios from "axios";

export default axios.create({
  baseURL: "http://localhost:49155/api",
  headers: {
    "Content-type": "application/json"
  }
});