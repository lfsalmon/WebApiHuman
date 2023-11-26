using System.Threading.Tasks;
using WebApiHumanModels.Enums;

namespace WebApiHuman.Repositories
{
    public interface IOperationRepository
    {
        Task<double?> ResolveOperation(double num1, double num2, BasicOperations operation);
    }
}
