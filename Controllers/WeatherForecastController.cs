
using Microsoft.Extensions.Options;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DemoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
       
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IOptionsSnapshot<ExtAPIConfigOptions> _extAPIConfig;
        private readonly IHttpClientFactory _httpclientFactory;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
                IOptionsSnapshot< ExtAPIConfigOptions> extAPIConfig,
                IHttpClientFactory httpclientFactory)
        {
            _logger = logger;
            _extAPIConfig = extAPIConfig;
            _httpclientFactory = httpclientFactory;
        }

        [HttpGet]
        public async Task<string> Get(string cityName)
        {
            _logger.LogInformation($" API URL {_extAPIConfig.Value.BaseURL} called for city={cityName}");
            
            var httpclient = _httpclientFactory.CreateClient();
            var baseURL = $"{_extAPIConfig.Value.BaseURL}?key={_extAPIConfig.Value.APIKey}&q={cityName}";
            var response = await httpclient.GetAsync(baseURL);
            return await response.Content.ReadAsStringAsync();

        }
    }
}
