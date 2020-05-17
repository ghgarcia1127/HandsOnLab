using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HandsOnLab.Core.Dto
{
    [DataContract]
    public abstract class Employee
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "contractTypeName")]
        public string ContractTypeName { get; set; }
        [DataMember(Name = "roleId")]
        public int RoleId { get; set; }
        [DataMember(Name = "roleName")]
        public string RoleName { get; set; }
        [DataMember(Name = "roleDescription")]
        public string RoleDescription { get; set; }
       
        [DataMember(Name = "monthlySalary")]
        public long MonthlySalary { get; set; }
        [DataMember(Name = "hourlySalary")]
        public long HourlySalary { get; set; }

        [DataMember(Name = "annualSalary")]
        public abstract long? AnnualSalary  { get; }

    }
}
