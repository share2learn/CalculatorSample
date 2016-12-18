using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using CalculatorSample.Client.Web.Clients;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using CalculatorSample.Client.Web.Configuration;

namespace CalculatorSample.Client.Web.Controllers
{
    public class HomeController : Controller
    {
		private static MathClient _client;

		public HomeController(IOptions<ApimSettings> apimSettings)
		{
			if (_client == null)
			{
				_client = new MathClient(apimSettings.Value.Endpoint, apimSettings.Value.SubscriptionKey);
			}
		}

        public IActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> DoMath([FromForm] double number1, [FromForm] double number2, [FromForm] string operation)
		{
			object result = null;

			try
			{
				switch (operation.ToLower())
				{
					case "add":
						result = await _client.AddAsync(number1, number2);
						break;
					case "subtract":
						result = await _client.SubtractAsync(number1, number2);
						break;
					case "multiply":
						result = await _client.MultiplyAsync(number1, number2);
						break;
					case "divide":
						result = await _client.DivideAsync(number1, number2);
						break;
				}
			}
			catch (Exception ex)
			{
				result = ex;
			}
			
			return View("Index", result);
		}

	}
}
