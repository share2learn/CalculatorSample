using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorSample.Api.Web.Models
{
	/// <summary>
	/// Error result returned when math operations fails.
	/// </summary>
    public class ErrorResult
    {
		public string Message { get; set; }

		public ErrorResult(string message)
		{
			Message = message;
		}
    }
}
