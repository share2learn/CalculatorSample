using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CalculatorSample.Api.Web.Models;
using System.Net;
using Swashbuckle.SwaggerGen.Annotations;

namespace CalculatorSample.Api.Web.Controllers
{
	/// <summary>
	/// API for simple math operations.
	/// </summary>
    [Route("api/[controller]")]
    public class MathController : Controller
    {
		/// <summary>
		/// Adds two numbers.
		/// </summary>
		/// <param name="augend">Augend of the equation. (input1).</param>
		/// <param name="addend">Addend of the equation. (input2).</param>
		/// <returns>Sum of adding augend and addend.</returns>
		[SwaggerOperation("Add")]
		[ProducesResponseType(typeof(MathResult), 202)]
		[HttpPost("add/{augend}/{addend}")]
        public IActionResult PostAdd([FromRoute] double augend, [FromRoute] double addend)
        {
			var result = new MathResult(augend, addend, augend + addend);
		
			return StatusCode((int)HttpStatusCode.Accepted, result);
		}

		/// <summary>
		/// Subtracts two numbers.
		/// </summary>
		/// <param name="minuend">Minuend of the equation. (input1).</param>
		/// <param name="subtrahend">Subtrahend of the equation. (input2).</param>
		/// <returns>Difference of subtracting the subtrahend from minuend.</returns>
		[SwaggerOperation("Subtract")]
		[ProducesResponseType(typeof(MathResult), 202)]
		[HttpPost("subtract/{minuend}/{subtrahend}")]
		public IActionResult PostSubtract([FromRoute] double minuend, [FromRoute] double subtrahend)
		{
			var result = new MathResult(minuend, subtrahend, minuend - subtrahend);

			return StatusCode((int)HttpStatusCode.Accepted, result);
		}

		/// <summary>
		/// Multiplies two numbers.
		/// </summary>
		/// <param name="multiplicand">Multiplicand of the equation. (input1).</param>
		/// <param name="multiplier">Multiplier of the equation. (input2).</param>
		/// <returns>Product of multiplying the multiplicand by the multiplier</returns>
		[SwaggerOperation("Multiply")]
		[ProducesResponseType(typeof(MathResult), 202)]
		[HttpPost("multiply/{multiplicand}/{multiplier}")]
		public IActionResult PostMultiply([FromRoute] double multiplicand, [FromRoute] double multiplier)
		{
			var result = new MathResult(multiplicand, multiplier, multiplicand * multiplier);

			return StatusCode((int)HttpStatusCode.Accepted, result);
		}

		/// <summary>
		/// Divides two numbers.
		/// </summary>
		/// <param name="dividend">Dividend of the equation. (input1).</param>
		/// <param name="divisor">Divisor of the equation. (input2).</param>
		/// <returns>Quotient of dividing the dividend by the divisor.</returns>
		[SwaggerOperation("Divide")]
		[ProducesResponseType(typeof(MathResult), 202)]
		[ProducesResponseType(typeof(ErrorResult), 405)]
		[HttpPost("divide/{dividend}/{divisor}")]
		public IActionResult PostDivide([FromRoute] double dividend, [FromRoute] double divisor)
		{
			// As all good developers do, we check for and gracefully handle divide by zero cases... ;-)
			if (divisor == 0)
			{
				var errorResult = new ErrorResult(new DivideByZeroException().Message);
				return StatusCode((int)HttpStatusCode.MethodNotAllowed, errorResult);
			}

			var result = new MathResult(dividend, divisor, dividend / divisor);

			return StatusCode((int)HttpStatusCode.Accepted, result);
		}
	}
}
