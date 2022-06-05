using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using libraryManagement.Models;
using libraryManagement.Repository;

namespace libraryManagement.Controllers
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
        private readonly ITblBook _tblBook;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,ITblBook tblBook)
        {
            _logger = logger;
            this._tblBook = tblBook;
        }

        [HttpGet]
        public string Get()
        {
            return "hello";
        }
    }
}
