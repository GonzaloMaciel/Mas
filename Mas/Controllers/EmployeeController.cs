using Mas.BLL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetAllEmployees()
        {
            try
            {
                EmployeeBLL bll = new EmployeeBLL();
                var result = await bll.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        /// <summary>
        /// Get employee by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmployeeByID(int id)
        {
            try
            {
                EmployeeBLL bll = new EmployeeBLL();
                var result = await bll.GetByID(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
