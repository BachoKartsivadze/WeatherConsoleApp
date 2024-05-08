// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net;
using WeatherConsoleApp;


IConfigurationRoot configuration = new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build();
var API_key = configuration.GetValue<string>("APIKey");

// enter city
Console.WriteLine("enter the city");
string city = Console.ReadLine();

using (HttpClient client = new HttpClient())
{
    // create url
    string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={API_key}&units=metric";

    // Send a GET request asynchronously and read the response as a string
    var response = await client.GetAsync(url);
    var json = await response.Content.ReadAsStringAsync();

    // Deserialize the JSON response into your WeatherInfo class
    WeatherInfo.root Info = JsonConvert.DeserializeObject<WeatherInfo.root>(json);

    // Output result
    Console.WriteLine($"coordinates = {Info.coord.lon}, {Info.coord.lat}");
    Console.WriteLine($"weather = {Info.weather[0].main}");
    Console.WriteLine($"temperature = {Info.main.temp} F");
    Console.WriteLine($"pressure = {Info.main.pressure} P");
    Console.WriteLine($"humidity = {Info.main.humidity}");

    int temperatureInfarenheits = convertTofarenheits(Info.main.temp);
    Console.WriteLine($"temperature in farenheit is {temperatureInfarenheits}F");
}

int convertTofarenheits(double celsiusValue) {
    double farenheitValue = 0;
    farenheitValue = (celsiusValue * 1.8) + 32;
    return (int)farenheitValue;
}



