using AcmeContracts;
using AcmeEntities;
using System.Threading.Tasks;


namespace AcmeRepository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly AcmeContext _acmeContext;
        private GetEmployeeByIdAsync _employee;
    

        public GetEmployeeByIdAsync Employee
        {
            get
            {
                if (_employee == null)
                {
                    _employee = new EmployeeRepository(_acmeContext);
                }

                return _employee;
            }
        }
        public RepositoryWrapper(AcmeContext acmeContext)
        {

            _acmeContext = acmeContext;
        }

        public async Task SaveAsync()
        {
            await _acmeContext.SaveChangesAsync();
        }
    }
}
