using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using System;
using System.Threading.Tasks;
using WebApiHuman.Repositories;
using WebApiHumanModels.Enums;
using WebApiHumanModels.ViewModels.BasicOperation;

namespace WebApiHuman.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasicOperationController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IOperationRepository _operationRepository;

        public BasicOperationController(ILogger<WeatherForecastController> logger, IOperationRepository operationRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _operationRepository = operationRepository ?? throw new ArgumentNullException(nameof(operationRepository));
        }

        [HttpPost]
        [Route("DoOperation")]

        public async Task<IActionResult> DoOperation([FromBody] BasicOperationViewModel operation)
        {
            var result=await _operationRepository.ResolveOperation(operation.num1, operation.num2, operation.BasicOperation);
            if (result.HasValue)
                return Ok(result.Value);
            else
                return BadRequest("Please verify the logs of the service");
        }
        [HttpGet]
        [Route("DoOperationHeader")]

        public async Task<IActionResult> DoOperation()
        {
            double num1=0, num2=0;
            BasicOperations bo=BasicOperations.Addition;
            if (Request.Headers.TryGetValue("Num1", out StringValues strnum1))
                num1 = Convert.ToDouble(strnum1);
            if (Request.Headers.TryGetValue("Num2", out StringValues strnum2))
                num2 = Convert.ToDouble(strnum2);
            if (Request.Headers.TryGetValue("BasicOperation", out StringValues strbo))
                bo = (BasicOperations)Convert.ToInt32(strbo);

            var result = await _operationRepository.ResolveOperation(num1, num2, bo);
            if (result.HasValue)
                return Ok(result.Value);
            else
                return BadRequest("Please verify the logs of the service");
        }
    }
}
