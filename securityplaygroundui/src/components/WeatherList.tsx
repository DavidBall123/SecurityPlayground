 import React, { useState, useEffect, ChangeEvent } from "react";
import WeatherService from "../services/WeatherService";
import IWeatherData from '../types/Weather'


const WeatherList: React.FC = () => {
    const [weatherList, setWeatherList] = useState<Array<IWeatherData>>([]);
    const [currentWeather, setCurrentWeather] = useState<IWeatherData | null>(null);
    const [currentIndex, setCurrentIndex] = useState<number>(-1);

    useEffect(() => {
        retrieveWeatherList();
    }, []);

    const retrieveWeatherList = () => {
        WeatherService.getAll()
          .then((response: any) => {
            setWeatherList(response.data);
            console.log(response.data);
          })
          .catch((e: Error) => {
            console.log(e);
          });
      };
    
    const refreshList = () => {
        retrieveWeatherList();
        setCurrentWeather(null);
        setCurrentIndex(-1);
    };

    const setActiveWeather = (weather: IWeatherData, index: number) => {
        setCurrentWeather(weather);
        setCurrentIndex(index);
      };

      return (
        <div className="list row">
          <div className="col-md-6">
            <h4>Weather List</h4>
    
            <ul className="list-group">
              {weatherList &&
                weatherList.map((weather, index) => (
                  <li
                    className={
                      "list-group-item " + (index === currentIndex ? "active" : "")
                    }
                    onClick={() => setCurrentWeather(weather)}
                    key={index}
                  >
                    {weather.summary}
                  </li>
                ))}
            </ul>
    
          </div>
          <div className="col-md-6">
            {currentWeather ? (
              <div>
                <h4>Weather</h4>
                <div>
                  <label>
                    <strong>Date:</strong>
                  </label>{" "}
                  {currentWeather.date}
                </div>
                <div>
                  <label>
                    <strong>Sumamry:</strong>
                  </label>{" "}
                  {currentWeather.summary}
                </div>
                <div>
                  <label>
                    <strong>Temperature C:</strong>
                  </label>{" "}
                  {currentWeather.temperatureC ? "Published" : "Pending"}
                </div>
    
              </div>
            ) : (
              <div>
                <br />
                <p>Please click on a Tutorial...</p>
              </div>
            )}
          </div>
        </div>
      );
    
}

export default WeatherList