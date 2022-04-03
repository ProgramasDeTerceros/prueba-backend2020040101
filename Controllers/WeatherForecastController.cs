﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Memory;

namespace backendEscuela.Controllers
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

		private readonly IMemoryCache _memoryCache;

		public WeatherForecastController(ILogger<WeatherForecastController> logger,IMemoryCache memoryCache)
		{
			_memoryCache = memoryCache;
			_logger = logger;
		}

		[HttpGet]
		public IEnumerable<WeatherForecast> Get()
		{
			var rng = new Random();
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = rng.Next(-20, 55),
				Summary = Summaries[rng.Next(Summaries.Length)]
			})
			.ToArray();
		}

	}
}
