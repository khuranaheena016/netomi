using NUnit.Framework;
using OpenWeather.API;
using System;
using TechTalk.SpecFlow;

namespace OpenWeather.Steps
{
    [Binding]
    public sealed class OpenWeatherSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        public string cityName;
        OpenWeatherAPI openWeatherAPI;

        public OpenWeatherSteps()
        {
            openWeatherAPI = new OpenWeatherAPI();
        }

        [Given(@"I have a invalid city name '(.*)'")]
        [Given(@"I have a city name '(.*)'")]
        public void GivenIHaveACityName(string cityName)
        {
            this.cityName = cityName == "empty" ? string.Empty : cityName ;
        }

        [When(@"I call weather api")]
        public void WhenICallWeatherApi()
        {
            try
            {
                this.openWeatherAPI.ExecuteAPI(cityName);
            }
            catch (Exception ex)
            {
                Assert.Fail($"{ex.GetType().Name} : {ex.Message}");
            }
        }

        [Then(@"it should give me the '(.*)' of '(.*)'")]
        public void ThenItShouldGiveMeTheOf(string expectedPossibility, string weatherCondition)
        {
            try
            {
                this.openWeatherAPI.VerifyResponse(weatherCondition, expectedPossibility);
            }
            catch (Exception ex)
            {
                Assert.Fail($"{ex.GetType().Name} : {ex.Message}");
            }
        }

        [Then(@"it should give me error message '(.*)'")]
        public void ThenItShouldGiveMeErrorMessage(string errormessage)
        {
            try
            {
                this.openWeatherAPI.VerifyResponse(errormessage);
            }
            catch (Exception ex)
            {
                Assert.Fail($"{ex.GetType().Name} : {ex.Message}");
            }
        }
    }
}
