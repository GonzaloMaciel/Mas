using Mas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mas.Dtos
{
    public class HourlyEmployeeDTO : EmployeeDTO
    {
        public HourlyEmployeeDTO(double hourlySalary)
        {
            AnnualSalary = 120 * hourlySalary * 12;
        }
    }
}
