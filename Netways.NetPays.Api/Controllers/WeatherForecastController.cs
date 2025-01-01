using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
using System.Text.Json.Serialization;

namespace Netways.NetPays.Api.Controllers
{
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
            Guid guid = Guid.NewGuid();
            Log.Information("API Log {Guid}.", guid);

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

        }

        [HttpPost(Name = "CreateWeatherForecast")]
        public void CreateWeatherItems([FromBody] WeatherForecast weatherForecast)
        {
            Guid guid = Guid.NewGuid();
            Log.Information("API Log {Guid}.,{payload}", guid, JsonConvert.SerializeObject(weatherForecast));
        }
    }
}
