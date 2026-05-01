using JPMORGAN_LOANS_BusinessEntities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPMORGAN_LOANS_BusinessEntities.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetEmployees();
        Task<EmployeeDto> GetEmployeeById(int empid);
        Task<int> AddEmployes(EmployeeDto empdetail);
        Task<bool> DeleteEmployesById(int empid);
        Task<bool> UpdateEmploye(EmployeeDto empdetail);

    }
}
