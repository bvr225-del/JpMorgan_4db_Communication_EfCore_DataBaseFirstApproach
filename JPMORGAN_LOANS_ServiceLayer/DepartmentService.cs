using JPMORGAN_LOANS_BusinessEntities.Dtos;
using JPMORGAN_LOANS_BusinessEntities.Interfaces;
using JPMORGAN_LOANS_BusinessEntities.NorthWind_DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPMORGAN_LOANS_ServiceLayer
{
    public class DepartmentService : IDepartmentService
    {
        #region Constructor Injection for IDepartmentRepository
        private readonly IDepartmentRepository _repository;
        //constructor injection
        public DepartmentService(IDepartmentRepository repository)
        {
            _repository = repository;
        }
        #endregion

        #region AddDepartments
        public async Task<int> AddDepartments(DepartmentDto deptdetail)
        {
            //In future this code was replaced by automapper conncept.
            Department dept = new Department();
            dept.Deptid = deptdetail.Deptid;
            dept.Deptname = deptdetail.Deptname;
            dept.Deptlocation = deptdetail.Deptlocation;
            var res = await _repository.AddDepartments(dept);
            return res;
        }
        #endregion

        #region DeleteDepartmentById

        public async Task<bool> DeleteDepartmentById(int deptid)
        {
            await _repository.DeleteDepartmentById(deptid);
            return true;
        }
        #endregion

        #region GetDepartmentById

        public async Task<DepartmentDto> GetDepartmentById(int deptid)
        {
            var res = await _repository.GetDepartmentById(deptid);
            DepartmentDto deptdto = new DepartmentDto();
            deptdto.Deptid = res.Deptid;//Here i am mapping entity object properties to Dto Object properties.
            deptdto.Deptname = res.Deptname;
            deptdto.Deptlocation = res.Deptlocation;
            return deptdto;
        }
        #endregion

        #region GetDepartments
        public async Task<List<DepartmentDto>> GetDepartments()
        {
            List<DepartmentDto> lstdeptdto = new List<DepartmentDto>();
            var res = await _repository.GetDepartments();
            foreach (Department dept in res)
            {

                DepartmentDto deptdto = new DepartmentDto();
                deptdto.Deptid = dept.Deptid;//Here i am mapping entity object properties to Dto Object properties.
                deptdto.Deptname = dept.Deptname;
                deptdto.Deptlocation = dept.Deptlocation;
                lstdeptdto.Add(deptdto);

            }
            return lstdeptdto;
        }
        #endregion

        #region UpdateDepartment

        public async Task<bool> UpdateDepartment(DepartmentDto deptdetail)
        {
            Department dept = new Department();
            dept.Deptid = deptdetail.Deptid;
            dept.Deptname = deptdetail.Deptname;
            dept.Deptlocation = deptdetail.Deptlocation;
            await _repository.UpdateDepartment(dept);
            return true;
        }
        #endregion
    }
}
