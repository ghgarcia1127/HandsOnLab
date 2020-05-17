using System.Collections.Generic;
using System.Threading.Tasks;

namespace HandsOnLab.Domain.IRepository
{
    public interface IEmployeeRepository
    {
        Task<IList<Employee>> GetEmployeeAsync();
    }
}
