using System.Threading.Tasks;

namespace AcmeContracts
{
    public interface IRepositoryWrapper
    {
        GetEmployeeByIdAsync Employee { get; }
        Task SaveAsync();
    }
}
