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

using (WebClient web = new WebClient())
 {

    // create url
    string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={API_key}";

    // wrire information from url in json
    var json = web.DownloadString(url);

    // write json information in my class(weatherinfo)
    WeatherInfo.root Info = JsonConvert.DeserializeObject<WeatherInfo.root>(json);                               


    // output result
    Console.WriteLine($"coordinates = {Info.coord.lon}, {Info.coord.lat}");
    Console.WriteLine($"weather = {Info.weather[0].main}");
    Console.WriteLine($"temperature = {Info.main.temp} F");
    Console.WriteLine($"pressure = {Info.main.pressure} P");
    Console.WriteLine($"humidity = {Info.main.humidity}");
 }


