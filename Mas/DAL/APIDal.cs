using Mas.Dtos;
using Mas.Factory;
using Mas.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mas.DAL
{
    public class APIDal
    {
        public async Task<EmployeeDTO> GetById(int id) {
            
            List<EmployeeDTO> employeeList = new List<EmployeeDTO>();
            EmployeeDTO emReponse = new EmployeeDTO();
            EmployeeDTO emLoaded;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://masglobaltestapi.azurewebsites.net/api/Employees"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    employeeList = JsonConvert.DeserializeObject<List<EmployeeDTO>>(apiResponse);
                }
            }
            emReponse = employeeList.Where(x => x.Id == id).FirstOrDefault();

            if (emReponse == null)
            {
                emLoaded = null;
                return emLoaded; 
            }

            if (emReponse.ContractTypeName == "HourlySalaryEmployee")
            {
                emLoaded = CreatorFactory.Creator(emReponse.ContractTypeName, emReponse.HourlySalary);
                
            }
            else 
            {
                emLoaded = CreatorFactory.Creator(emReponse.ContractTypeName, emReponse.MonthlySalary);
            }

                emLoaded.Id = emReponse.Id;
                emLoaded.Name = emReponse.Name;
                emLoaded.ContractTypeName = emReponse.ContractTypeName;
                emLoaded.RoleId = emReponse.RoleId;
                emLoaded.RoleName = emReponse.RoleName;
                emLoaded.RoleDescription = emReponse.RoleDescription;
                emLoaded.HourlySalary = emReponse.HourlySalary;
                emLoaded.MonthlySalary = emReponse.MonthlySalary;

            return emLoaded;
        }

        public async Task<List<EmployeeDTO>> GetAll()
        {
            try
            {
                List<EmployeeDTO> employeeResponseList = new List<EmployeeDTO>();
                List<EmployeeDTO> employeeemLoadedList = new List<EmployeeDTO>();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("http://masglobaltestapi.azurewebsites.net/api/Employees"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        employeeResponseList = JsonConvert.DeserializeObject<List<EmployeeDTO>>(apiResponse);
                    }
                }

                foreach (var emReponse in employeeResponseList)
                {
                    EmployeeDTO emLoaded;

                    if (emReponse.ContractTypeName == "HourlySalaryEmployee")
                    {
                        emLoaded = CreatorFactory.Creator(emReponse.ContractTypeName, emReponse.HourlySalary);

                    }
                    else
                    {
                        emLoaded = CreatorFactory.Creator(emReponse.ContractTypeName, emReponse.MonthlySalary);
                    }
                    emLoaded.Id = emReponse.Id;
                    emLoaded.Name = emReponse.Name;
                    emLoaded.ContractTypeName = emReponse.ContractTypeName;
                    emLoaded.RoleId = emReponse.RoleId;
                    emLoaded.RoleName = emReponse.RoleName;
                    emLoaded.RoleDescription = emReponse.RoleDescription;
                    emLoaded.HourlySalary = emReponse.HourlySalary;
                    emLoaded.MonthlySalary = emReponse.MonthlySalary;
                    employeeemLoadedList.Add(emLoaded);
                }
                return employeeemLoadedList;

            }
            catch (Exception ex)
            {

                throw ex;
            }
       
        }
    }
}
