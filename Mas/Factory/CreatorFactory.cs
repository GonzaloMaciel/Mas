using Mas.Dtos;
using Mas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mas.Factory
{
    public  static class CreatorFactory
    {
        public static EmployeeDTO Creator(string contractType, double salary)
        {

            if (contractType == "HourlySalaryEmployee")
            {
                return new HourlyEmployeeDTO(salary);
            }
            else
            {
                return new MonthlyEmployeeDTO(salary);
            }
        }
    }
}
