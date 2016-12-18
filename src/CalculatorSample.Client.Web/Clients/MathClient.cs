using CalculatorSample.Client.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CalculatorSample.Client.Web.Clients
{
    public class MathClient
    {
		private HttpClient _client;

		public MathClient(string endpoint, string subscriptionKey)
		{
			_client = new HttpClient();
			_client.BaseAddress = new Uri(endpoint);
			_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			_client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
		}

		public async Task<double> AddAsync(double augend, double addend)
		{
			var uri = $"/math/api/Math/add/{augend}/{addend}";
			var response = await _client.PostAsync(uri, new StringContent(String.Empty));

			if (response.IsSuccessStatusCode)
			{
				var json = await response.Content.ReadAsStringAsync();
				var model = JsonConvert.DeserializeObject<MathResult>(json);
				return model.Result;
			}
			else
			{
				throw new Exception(response.ReasonPhrase);
			}
		}

		public async Task<double> SubtractAsync(double minuend, double subtrahend)
		{
			var uri = $"/math/api/Math/subtract/{minuend}/{subtrahend}";
			var response = await _client.PostAsync(uri, new StringContent(String.Empty));

			if (response.IsSuccessStatusCode)
			{
				var json = await response.Content.ReadAsStringAsync();
				var model = JsonConvert.DeserializeObject<MathResult>(json);
				return model.Result;
			}
			else
			{
				throw new Exception(response.ReasonPhrase);
			}
		}

		public async Task<double> MultiplyAsync(double multiplicand, double multiplier)
		{
			var uri = $"/math/api/Math/multiply/{multiplicand}/{multiplier}";
			var response = await _client.PostAsync(uri, new StringContent(String.Empty));

			if (response.IsSuccessStatusCode)
			{
				var json = await response.Content.ReadAsStringAsync();
				var model = JsonConvert.DeserializeObject<MathResult>(json);
				return model.Result;
			}
			else
			{
				throw new Exception(response.ReasonPhrase);
			}
		}

		public async Task<double> DivideAsync(double dividend, double divisor)
		{
			var uri = $"/math/api/Math/divide/{dividend}/{divisor}";
			var response = await _client.PostAsync(uri, new StringContent(String.Empty));

			if (response.IsSuccessStatusCode)
			{
				var json = await response.Content.ReadAsStringAsync();
				var model = JsonConvert.DeserializeObject<MathResult>(json);
				return model.Result;
			}
			else
			{
				throw new Exception(response.ReasonPhrase);
			}
		}
	}
}
