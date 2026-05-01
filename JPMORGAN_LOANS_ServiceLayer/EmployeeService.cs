using JPMORGAN_LOANS_BusinessEntities.Dtos;
using JPMORGAN_LOANS_BusinessEntities.hotelmanagementModels;
using JPMORGAN_LOANS_BusinessEntities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPMORGAN_LOANS_ServiceLayer
{
    public class EmployeeService : IEmployeeService
    {
        #region Constructor Injection for IEmployeeRepository
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        #endregion

        #region AddEmployes
        public async Task<int> AddEmployes(EmployeeDto empdetail)
        {
            Employee emp = new Employee();
            emp.Empid = empdetail.Empid;
            emp.Empsalary = empdetail.Empsalary;
            emp.Empname = empdetail.Empname;
            var res = await _employeeRepository.AddEmployes(emp);
            return res;
        }
        #endregion

        #region DeleteEmployesById
        public async Task<bool> DeleteEmployesById(int empid)
        {
            await _employeeRepository.DeleteEmployesById(empid);
            return true;
        }
        #endregion

        #region GetEmployeeById
        public async Task<EmployeeDto> GetEmployeeById(int empid)
        {
            var res = await _employeeRepository.GetEmployeeById(empid);
            EmployeeDto empdto = new EmployeeDto();
            empdto.Empid = res.Empid;
            empdto.Empname = res.Empname;
            empdto.Empsalary = res.Empsalary;
            return empdto;
        }
        #endregion

        #region GetEmployees
        public async Task<List<EmployeeDto>> GetEmployees()
        {

            List<EmployeeDto> lstempdto = new List<EmployeeDto>();
            var res = await _employeeRepository.GetEmployees();
            foreach (Employee emp in res)
            {
                EmployeeDto empdto = new EmployeeDto();
                empdto.Empid = emp.Empid;
                empdto.Empsalary = emp.Empsalary;
                empdto.Empname = emp.Empname;
                lstempdto.Add(empdto);

            }
            return lstempdto;
        }
        #endregion

        #region UpdateEmploye
        public async Task<bool> UpdateEmploye(EmployeeDto empdetail)
        {
            Employee emp = new Employee();
            emp.Empid = empdetail.Empid;
            emp.Empsalary = empdetail.Empsalary;
            emp.Empname = empdetail.Empname;
            await _employeeRepository.UpdateEmploye(emp);
            return true;
        }
        #endregion
    }
}
