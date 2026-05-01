using AutoMapper;
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
        private readonly IMapper _mapper;

        //constructor injection
        public DepartmentService(IDepartmentRepository repository,IMapper mapper)
        {
            _repository = repository;
            this._mapper = mapper;
        }
        #endregion

        #region AddDepartments
        public async Task<int> AddDepartments(DepartmentDto deptdetail)
        {
            //In future this code was replaced by automapper conncept.
            Department dept = new Department();
            _mapper.Map(deptdetail, dept);
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
            return _mapper.Map<DepartmentDto>(res);
        }
        #endregion

        #region GetDepartments
        public async Task<List<DepartmentDto>> GetDepartments()
        {
            var res = await _repository.GetDepartments();
            return _mapper.Map<List<DepartmentDto>>(res);
        }
        #endregion

        #region UpdateDepartment

        public async Task<bool> UpdateDepartment(DepartmentDto deptdetail)
        {
            Department dept = new Department();
            _mapper.Map(deptdetail, dept);
            await _repository.UpdateDepartment(dept);
            return true;
        }
        #endregion
    }
}
