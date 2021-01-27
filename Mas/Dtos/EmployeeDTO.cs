using Mas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mas.Dtos
{
    public class EmployeeDTO : Employee
    {
        public double AnnualSalary { get; set; }
    }
}
