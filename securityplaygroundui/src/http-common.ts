import axios from "axios";

export default axios.create({
  baseURL: "https://localhost:49153/api",
  headers: {
    "Content-type": "application/json",
    "Access-Control-Allow-Origin": "*"
  }
});