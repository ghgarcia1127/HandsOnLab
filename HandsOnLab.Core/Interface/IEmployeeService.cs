using HandsOnLab.Core.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HandsOnLab.Core.Interface
{
    public interface IEmployeeService 
    {
        Task<Employee> FindEmployeeAsync(int id);
        Task<IList<Employee>> GetAllEmployeeAsync();

    }
}
