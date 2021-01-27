using Mas.DAL;
using Mas.Dtos;
using Mas.Factory;
using Mas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mas.BLL
{
    public class EmployeeBLL
    {
        public Task<EmployeeDTO> GetByID (int id)
        {
            APIDal ad = new APIDal();
            Task<EmployeeDTO> em = ad.GetById(id);

            return em;

        }

        public Task<List<EmployeeDTO>> GetAll() 
        {
            APIDal ad = new APIDal();
            Task<List<EmployeeDTO>> emList = ad.GetAll();        

            return emList;
        }
    }
}
