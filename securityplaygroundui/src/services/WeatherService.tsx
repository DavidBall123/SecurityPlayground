import http from "../http-common";
import IWeatherData from "../types/Weather";

const getAll = () => {
  return http.get<Array<IWeatherData>>("/WeatherForecast");
};

// const get = (id: any) => {
//   return http.get<IWeatherData>(`/tutorials/${id}`);
// };

// const create = (data: IWeatherData) => {
//   return http.post<IWeatherData>("/tutorials", data);
// };

// const update = (id: any, data: IWeatherData) => {
//   return http.put<any>(`/tutorials/${id}`, data);
// };

// const remove = (id: any) => {
//   return http.delete<any>(`/tutorials/${id}`);
// };

// const removeAll = () => {
//   return http.delete<any>(`/tutorials`);
// };

// const findByTitle = (title: string) => {
//   return http.get<Array<IWeatherData>>(`/tutorials?title=${title}`);
// };

const WeatherService = {
  getAll,
//   get,
//   create,
//   update,
//   remove,
//   removeAll,
//   findByTitle,
};

export default WeatherService;