
using Autofac.Features.Indexed;
using HandsOnLab.Core.Dto;
using HandsOnLab.Core.Factory;
using HandsOnLab.Core.Interface;
using HandsOnLab.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandsOnLab.Core.Service
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository repository;
        private IIndex<EmployeeType, IEmployeeFactory> index;

        public EmployeeService(IEmployeeRepository repository, IIndex<EmployeeType, IEmployeeFactory> index)
        {
            this.repository = repository;
            this.index = index;
        }

        public async Task<Employee> FindEmployeeAsync(int id)
        {
            var employees = await repository.GetEmployeeAsync().ConfigureAwait(false);
            var employee = employees.FirstOrDefault(emp => emp.Id == id);

            IEmployeeFactory factory = LoadFactory(employee);
            return factory.ObtainFullyConstrutedEmployee(employee);
        }


        public async Task<IList<Employee>> GetAllEmployeeAsync()
        {
            var employees = await repository.GetEmployeeAsync().ConfigureAwait(false);
            var response = new List<Employee>();
            IEmployeeFactory factory;
            foreach (Domain.Employee employee in employees)
            {
                factory = LoadFactory(employee);
                response.Add(factory.ObtainFullyConstrutedEmployee(employee));
            }
            return response;
        }



        private IEmployeeFactory LoadFactory(Domain.Employee employee)
        {
            EmployeeType choice;
            if (Enum.TryParse<EmployeeType>(employee.ContractTypeName, out choice))
            {
                return index[choice];
            }
            else 
            {
                throw new KeyNotFoundException($"The contract type {employee.ContractTypeName} is not sopported");
            }
        }
    }
}
