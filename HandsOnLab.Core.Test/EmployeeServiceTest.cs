using Autofac.Features.Indexed;
using AutoMapper;
using HandsOnLab.Core.Dto;
using HandsOnLab.Core.Factory;
using HandsOnLab.Core.Interface;
using HandsOnLab.Core.Service;
using HandsOnLab.Domain.IRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandsOnLab.Core.Test
{
    [TestClass]
    public class EmployeeServiceTest
    {
        private IEmployeeService Service { get; set; }
        private IEmployeeRepository Repository { get; set; }
        private IIndex<EmployeeType, IEmployeeFactory> Index { get; set; }
        private IMapper Mapper { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            Repository = Substitute.For<IEmployeeRepository>();
            Index = Substitute.For<IIndex<EmployeeType, IEmployeeFactory>>();
            Mapper = Mapper = new Mapper(new MapperConfiguration(config => { config.AddProfile(new MappingProfile()); }));
            Index[EmployeeType.MonthlySalaryEmployee].Returns(new MontlyEmployeeFactory(Mapper));
            Index[EmployeeType.HourlySalaryEmployee].Returns(new HourlyEmployeeFactory(Mapper));

            Service = new EmployeeService(Repository, Index);
        }

        [TestMethod]
        public async Task FindEmployeeAsync()
        {
            var employee = await Service.FindEmployeeAsync(1).ConfigureAwait(false);
            var expectedSalary = 120 * employees.FirstOrDefault(emp => emp.Id == 1).HourlySalary * 12;
            Assert.AreEqual("Juan", employee.Name);
            Assert.AreEqual(expectedSalary, employee.AnnualSalary);
        }

        private IList<Domain.Employee> employees { get; set; } = new List<Domain.Employee>
        {
            new Domain.Employee { ContractTypeName = "HourlySalaryEmployee", Id = 1,Name = "Juan", HourlySalary = 60000, MonthlySalary = 80000,RoleDescription = "", RoleId = 1, RoleName="Administrator" },
            new Domain.Employee { ContractTypeName = "MonthlySalaryEmployee", Id = 2,Name = "Sebastian", HourlySalary = 60000, MonthlySalary = 80000,RoleDescription = "", RoleId = 2, RoleName="Contractor" }
        };
    }
}
