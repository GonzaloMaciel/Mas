using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mas.Dtos
{
    public class MonthlyEmployeeDTO : EmployeeDTO
    {
        public MonthlyEmployeeDTO(double MonthtlySalary)
        {
            AnnualSalary = MonthtlySalary * 12;
        }
    }
}
