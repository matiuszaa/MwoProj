using Microsoft.AspNetCore.Mvc;
using System;

namespace P01WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpPost]
    public string NowaMetoda()
    {
        return "ok";
    }

    [HttpPost("test/{text}")]
    public string MetodaZParametrem(
        [FromRoute] string text,
        [FromQuery] int liczba1,
        [FromQuery] int liczba2,
        [FromBody] Player osoba
        )
    {
        return $"text: {text} liczba1: {liczba1} " +
            $" liczba2: {liczba2} Person: name: {osoba.name} age: {osoba.birthDate}";
    }
}
