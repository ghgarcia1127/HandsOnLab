using AutoMapper;
using HandsOnLab.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnLab.Core.Factory
{
    public class MontlyEmployeeFactory : IEmployeeFactory
    {
        private readonly IMapper mapper;

        public MontlyEmployeeFactory(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public Employee ObtainFullyConstrutedEmployee(Domain.Employee employee)
        {
            MonthlyPayedEmployee hourlyEmployee = mapper.Map<MonthlyPayedEmployee>(employee);
            return hourlyEmployee;
        }
    }
}
