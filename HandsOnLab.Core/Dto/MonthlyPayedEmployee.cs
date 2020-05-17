using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnLab.Core.Dto
{
    public class MonthlyPayedEmployee : Employee
    {
        public override long? AnnualSalary { get =>  MonthlySalary * 12; }
    }
}
