import axios from "axios";

const getUrl = window.location;
//let baseUrl = getUrl.protocol + "//http:localhost:8080/ebuy";

let baseUrl="//http:localhost:8080/ebuy";

// // set different base url and proxy url if running from localhost:3000
// if (process.env.REACT_APP_ENV === "development") {
//  // baseUrl = "http://127.0.0.1:9090/https:// /ebuy";
//   baseUrl = "http://127.0.0.1:8080/http://127.0.0.1:8080/ebuy";
// } else if (process.env.REACT_APP_ENV === "local") {
// //   baseUrl = "http://127.0.0.1:8080/http://127.0.0.1:8080/ebuy";
//   baseUrl = "http:localhost:8080/ebuy";
// }

let instanceAxios = axios.create({
  baseURL: baseUrl,
  headers: {
    "Access-Control-Allow-Origin": "*",
     "Access-Control-Allow-Methods": "GET,PUT,POST,DELETE,PATCH,OPTIONS",
    // "Access-Control-Allow-Headers":
    //   "Origin, X-Requested-With, Content-Type, Accept",
    "Content-type": "application/json",
  },
});
// instanceAxios.interceptors.request.use((config) => {
//   let accessToken = sessionStorage.getItem("react-token");
//   config.headers.Authorization = accessToken ? `Bearer ${accessToken}` : "";
//   return config;
// });

export default instanceAxios;