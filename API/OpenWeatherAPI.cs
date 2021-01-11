using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenWeather.Wrapper;
using System;
using System.Collections.Generic;

namespace OpenWeather.API
{
    class OpenWeatherAPI
    {
        string apiUri;
        string apiResponse;

        public OpenWeatherAPI()
        {
            apiUri = "http://api.openweathermap.org/data/2.5/forecast?q={0}&appid={1}";
        }

        internal void ExecuteAPI(string cityName)
        {
            string apiKey = FileHandler.ReadDataFromJson("keys.json")["APIKey"].ToString();
            apiResponse = HttpClientWrapper.Get(string.Format(apiUri, cityName, apiKey)).Content.ReadAsStringAsync().Result.ToString();
        }

        internal void VerifyResponse(string errorMsg)
        {
            JObject errMsg = JsonConvert.DeserializeObject<JObject>(apiResponse);
            if (!errorMsg.Equals(errMsg["message"].ToString()))
            {
                throw new Exception("Error Message does not match");
            }
        }

        internal void VerifyResponse(string weatherCondition, string expectedPossibility)
        {
            JObject weatherData = JsonConvert.DeserializeObject<dynamic>(apiResponse);
            JArray weatherDataList = (JArray)weatherData["list"];
            List<string> weatherCondlst = new List<string>();

            foreach (JObject item in weatherDataList)
            {
                weatherCondlst.Add(item["weather"][0]["main"].ToString());
            }

            if (expectedPossibility == "Yes")
            {
                if (!weatherCondlst.Contains(weatherCondition))
                {
                    throw new Exception(string.Format("Expected possibility of {0}  does not match with weather data", weatherCondition));
                }
            }
            else
            {
                if (weatherCondlst.Contains(weatherCondition))
                {
                    throw new Exception(string.Format("Expected possibility of {0}  does not match with weather data", weatherCondition));
                }
            }
        }
    }
}
