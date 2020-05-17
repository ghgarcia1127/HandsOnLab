using AutoMapper;
using HandsOnLab.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnLab.Core.Factory
{
    public class HourlyEmployeeFactory : IEmployeeFactory
    {
        private readonly IMapper mapper;

        public HourlyEmployeeFactory(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public Employee ObtainFullyConstrutedEmployee(Domain.Employee employee)
        {
            HourlyPayedEmployee hourlyEmployee = mapper.Map<HourlyPayedEmployee>(employee);
            return hourlyEmployee;
        }
    }
}
