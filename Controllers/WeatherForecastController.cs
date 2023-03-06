using Microsoft.AspNetCore.Mvc;

namespace ApiTareas.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private static List<WeatherForecast> listWeather=new List<WeatherForecast>();

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;

        if(listWeather==null || !listWeather.Any()){

            listWeather= Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToList();

        }
    }

    [HttpGet(Name = "GetWeatherForecast")]
   // [Route("obtener")]
   /// [Route("action")]
    public IEnumerable<WeatherForecast> getw()

    {
        _logger.LogDebug("se retornan los datos correctammente");
       return listWeather; 
        
    }

    [HttpPost]

    public IActionResult post(WeatherForecast weatherForecast){
     listWeather.Add(weatherForecast);

     return Ok();

    }

    [HttpDelete("{index}")]
    public IActionResult delete( int index){

        listWeather.RemoveAt(index);

        return Ok();

    }
} 
