using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HandsOnLab.Core.Dto
{
    public class HourlyPayedEmployee : Employee
    {
        public override long? AnnualSalary { get => 120 * base.HourlySalary * 12;}
    }
}
