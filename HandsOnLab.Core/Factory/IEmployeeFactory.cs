using HandsOnLab.Core.Dto;

namespace HandsOnLab.Core.Factory
{
    public interface IEmployeeFactory
    {
        Employee ObtainFullyConstrutedEmployee(Domain.Employee employee);
    }
}
