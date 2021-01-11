Feature: OpenWeather
	In order to verify weather condition in next 5 days
	API - api.openweathermap.org/data/2.5/forecast?q={city name}&appid={API key}

@PositiveScenario
Scenario Outline: Need to check weather condition for valid values for next 5 days
	Given I have a city name '<CityName>'
	When I call weather api
	Then it should give me the '<ExpectedPossiblity>' of '<WeatherCondition>'

	Examples:
		| Scenario                                               | CityName | WeatherCondition | ExpectedPossiblity |
		| Expected Possibility of Rain is equal to predicted     | London   | Rain             | Yes                |
		| Expected possibility of Rain is not equal to predicted | London   | Extreme          | No                 |
		| Expected Possibility of Clouds is equal to predicted   | Rohtak   | Clouds           | Yes                |

@NegativeScenario
Scenario Outline: Need to check weather condition for invalid values
	Given I have a invalid city name '<CityName>'
	When I call weather api
	Then it should give me error message '<ErrorMessage>'

	Examples:
		| Scenario           | CityName | ErrorMessage       |
		| Invalid city name  | ak       | city not found     |
		| City name as empty | empty    | Nothing to geocode |