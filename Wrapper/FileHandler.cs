using Newtonsoft.Json.Linq;
using System.IO;

namespace OpenWeather.Wrapper
{
    class FileHandler
    {
        static string basePath = @"D:\OpenWeatherAPI\OpenWeather\";

        public static JObject ReadDataFromJson(string fileName)
        {
            JObject fileContent = JObject.Parse(File.ReadAllText(basePath + fileName));
            return fileContent;
        }
    }
}
