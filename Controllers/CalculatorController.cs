using Microsoft.AspNetCore.Mvc;
using MediatR;
using SajjadCalculator.Requests;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace SajjadCalculator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CalculatorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Endpoint for addition
        [HttpGet("add")]
        [Authorize(Policy = "CanAddPolicy")]
        public async Task<IActionResult> Add([FromQuery] AddRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(new { Operation = "Addition", Result = result });
        }

        // Endpoint for subtraction
        [HttpGet("subtract")]
        [Authorize(Policy = "CanSubtractPolicy")]
        public async Task<IActionResult> Subtract([FromQuery] SubtractRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(new { Operation = "Subtraction", Result = result });
        }

        // Endpoint for multiplication
        [HttpGet("multiply")]
        [Authorize(Policy = "CanMultiplyPolicy")]
        public async Task<IActionResult> Multiply([FromQuery] MultiplyRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(new { Operation = "Multiplication", Result = result });
        }

        // Endpoint for division
        [HttpGet("divide")]
        [Authorize(Policy = "CanDividePolicy")]
        public async Task<IActionResult> Divide([FromQuery] DivideRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(new { Operation = "Division", Result = result });
        }
    }
}
