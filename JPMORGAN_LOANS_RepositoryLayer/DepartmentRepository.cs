using JPMORGAN_LOANS_BusinessEntities.Interfaces;
using JPMORGAN_LOANS_BusinessEntities.NorthWind_DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPMORGAN_LOANS_RepositoryLayer
{
    public class DepartmentRepository : IDepartmentRepository
    {
        #region Constructor Injection for DbContext class
        private readonly NorthwindDbContext _northWindDbContext;
        public DepartmentRepository(NorthwindDbContext northwindDbContext)
        {
            _northWindDbContext = northwindDbContext;
        }
        #endregion

        #region AddDepartments
        public async Task<int> AddDepartments(Department deptdetail)
        {
            //throw new NotImplementedException();//It will throw the error,
            await _northWindDbContext.Departments.AddAsync(deptdetail);//add the record by using addasync
            _northWindDbContext.SaveChanges();//it will commit/save the data perminently in table
            return 1;

        }
        #endregion

        #region DeleteDepartmentById
        public async Task<bool> DeleteDepartmentById(int deptid)
        {
            var result = await _northWindDbContext.Departments.Where(a => a.Deptid == deptid).FirstOrDefaultAsync();
            if (result != null)
            {
                _northWindDbContext.Departments.Remove(result);
                _northWindDbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region GetDepartmentById
        public async Task<Department> GetDepartmentById(int deptid)
        {
            //To get the one record use below linq query
            var result = await _northWindDbContext.Departments.Where(b => b.Deptid == deptid).FirstOrDefaultAsync();
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

        #region GetDepartments
        public async Task<List<Department>> GetDepartments()
        {
            var result = await _northWindDbContext.Departments.ToListAsync();
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

        #region UpdateDepartment
        public async Task<bool> UpdateDepartment(Department deptdetail)
        {
            //this is one way of update the data
            //  _northWindDbContext.Departments.Update(deptdetail);

            //second way of update the data(Realtime use this way)
            var departmentResult = await _northWindDbContext.Departments.Where(b => b.Deptid == deptdetail.Deptid).FirstOrDefaultAsync();
            departmentResult.Deptid = deptdetail.Deptid;
            departmentResult.Deptname = deptdetail.Deptname;//map the properties clearly
            departmentResult.Deptlocation = deptdetail.Deptlocation;
            _northWindDbContext.Departments.Update(departmentResult);
            await _northWindDbContext.SaveChangesAsync();
            return true;

        }
        #endregion
    }
}
