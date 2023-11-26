using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WebApiHumanModels.Enums;

namespace WebApiHuman.Repositories
{
    public class OperationRepository : IOperationRepository
    {
        public readonly ILogger<HumanRepository> _logger;

        public OperationRepository(ILogger<HumanRepository> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<double?> ResolveOperation(double num1, double num2, BasicOperations operation)
        {
            double? result = null;
            try
            {
                switch (operation)
                {
                    case BasicOperations.Addition: result = num1+num2; break;
                    case BasicOperations.Subtraction: result = num1-num2; break;
                    case BasicOperations.Multiplication: result = num1*num2; break;
                    case BasicOperations.Division: result = num1/num2; break;
                }

            }catch(Exception ex)
            {
                _logger.LogError($"Exception in @ResolveOperation :{ex.Message}");
            }
            return result;
        }
    }
}
