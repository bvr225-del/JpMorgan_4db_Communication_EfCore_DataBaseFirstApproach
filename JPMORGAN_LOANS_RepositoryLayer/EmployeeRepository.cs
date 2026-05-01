using JPMORGAN_LOANS_BusinessEntities.hotelmanagementModels;
using JPMORGAN_LOANS_BusinessEntities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPMORGAN_LOANS_RepositoryLayer
{
    public class EmployeeRepository : IEmployeeRepository
    {
        #region Constructor Injection for DbContext class
        private readonly HotelmanagementContext _hotelManagementContext;

        public EmployeeRepository(HotelmanagementContext hotelManagementContext)
        {
            _hotelManagementContext = hotelManagementContext;
        }
        #endregion

        #region AddEmployes
        public async Task<int> AddEmployes(Employee empdetail)
        {
            await _hotelManagementContext.Employees.AddAsync(empdetail);
            _hotelManagementContext.SaveChanges();
            return 1;
        }
        #endregion

        #region DeleteEmployesById
        public async Task<bool> DeleteEmployesById(int empid)
        {
            var result = await _hotelManagementContext.Employees.Where(a => a.Empid == empid).FirstOrDefaultAsync();
            if (result != null)
            {
                _hotelManagementContext.Employees.Remove(result);
                _hotelManagementContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region GetEmployeeById
        public async Task<Employee> GetEmployeeById(int empid)
        {
            //To get the one record use below linq query
            var result = await _hotelManagementContext.Employees.Where(b => b.Empid == empid).FirstOrDefaultAsync();
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region GetEmployees
        public async Task<List<Employee>> GetEmployees()
        {
            var result = await _hotelManagementContext.Employees.ToListAsync();
            if (result.Count == 0)
            {
                return null;
            }
            else
            {
                return result;
            }
        }
        #endregion

        #region UpdateEmploye
        public async Task<bool> UpdateEmploye(Employee empdetail)
        {

            //this is one way of update the data
            //  _hotelManagementContext.Employees.Update(empdetail);

            //second way of update the data(Realtime use this way)
            var employeeResult = await _hotelManagementContext.Employees.Where(b => b.Empid == empdetail.Empid).FirstOrDefaultAsync();
            employeeResult.Empid = empdetail.Empid;
            employeeResult.Empname = empdetail.Empname;
            employeeResult.Empsalary = empdetail.Empsalary;
            _hotelManagementContext.Employees.Update(employeeResult);
            await _hotelManagementContext.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}
