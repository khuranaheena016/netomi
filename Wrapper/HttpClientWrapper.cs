using System.Net.Http;

namespace OpenWeather.Wrapper
{
    class HttpClientWrapper
    {
        public static HttpResponseMessage Get(string requestUri)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = httpClient.GetAsync(requestUri).Result;
                return response;
            }
        }
    }
}
