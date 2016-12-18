using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorSample.Api.Web.Models
{
	/// <summary>
	/// Response model from math API.
	/// </summary>
    public class MathResult
    {
		[Required]
		public double Input1 { get; set; }

		[Required]
		public double Input2 { get; set; }

		[Required]
		public double Result { get; set; }

		public MathResult(double input1, double input2, double result)
		{
			Input1 = input1;
			Input2 = input2;
			Result = result;
		}
    }
}
