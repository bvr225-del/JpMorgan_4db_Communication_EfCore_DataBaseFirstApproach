using JPMORGAN_LOANS_BusinessEntities.Dtos;
using JPMORGAN_LOANS_BusinessEntities.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JPMORGAN_LOANS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        #region Constructor Injection for IEmployeeService
        private IEmployeeService _employeeService;
        //Inject the dependencies into constrctor.
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        #endregion

        #region [HttpPost]
        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> Post([FromBody] EmployeeDto empdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var empdata = await _employeeService.AddEmployes(empdto);
                    return StatusCode(StatusCodes.Status201Created, empdata);
                }
            }
            catch (Exception ex)
            {//if you got any error we are using this statuscode:Status500InternalServerError
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        #endregion

        #region [HttpDelete]
        [HttpDelete]
        [Route("DeleteEmployeeByEmpid/{empid}")]
        public async Task<IActionResult> delete(int empid)
        {
            if (empid < 0)
            {//If input parameters are wrongly sent -1..like negitive values or empty, we will get 400 badrequest statuscode:Status400BadRequest
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var empdata = await _employeeService.DeleteEmployesById(empid);
                if (empdata == null)
                {//in db if you get empty data we need to retrun this statuscode:Status404NotFound
                    return StatusCode(StatusCodes.Status404NotFound, "empdata not  found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, "deleted successfully");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        #endregion

        #region [HttpGet]
        [HttpGet]
        [Route("GetEmployee")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var empdata = await _employeeService.GetEmployees();
                if (empdata == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "empdata not  found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, empdata);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }

        }
        #endregion

        #region [HttpGetById]
        [HttpGet]
        [Route("GetEmployeeByEmpid/{empid}")]
        public async Task<IActionResult> Get(int empid)
        {
            if (empid < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var empdata = await _employeeService.GetEmployeeById(empid);
                return StatusCode(StatusCodes.Status200OK, empdata);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server eror");
            }
        }
        #endregion

        #region [HttpPut]
        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> put([FromBody] EmployeeDto empdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var empdata = await _employeeService.UpdateEmploye(empdto);
                    return StatusCode(StatusCodes.Status200OK, empdata);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        #endregion
    }
}
#region commented code
/*
 *  To implement db first approach use this MIGRATION COMMNDS
 * ==================THESE ARE 4 DATABASE MIGRATION COMMANDS=============
PM>Scaffold-DbContext "Server=DESKTOP-13B42NJ;Database=hotelmanagement;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir hotelmanagementModels
PM>Scaffold-DbContext "Server=DESKTOP-13B42NJ;Database=MIDLAND;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir MidlandModels
PM>Scaffold-DbContext "Server=DESKTOP-13B42NJ;Database=Northwind_DB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir NorthWind_DbModels
PM>Scaffold-DbContext "Server=DESKTOP-13B42NJ;Database=RestaurantDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir RestarentModels

ERROR:
=======
i am using entity framework core db first approach ,
by using sccaffold-dbcontext i already generted context class and model classes ,
if i perform add opetion it is thorwing primary key below error 
.aftet hat i have applied primary key empid column in database and again when 
i perform ad opertion it is not added record in database.
i want to update the db changes again into Sccafold-dbcontext command.how?
i want to update the database chnages to my context class again 
how we can perfome in ef core db first approach?

TO FIX THE ABOVE ISSUE BELOW IS THE SOLUTION:
==================================================
roblem 1: “Entity has no primary key”

Error:

Unable to track an instance of type 'Employee' because it does not have a primary key

This happens because when you first ran Scaffold-DbContext, your table didn’t have a primary key, so EF generated your Employee model without a key.

Even though you later added a PK in Microsoft SQL Server, your C# model is still outdated.

✅ Solution: Re-scaffold (update models from DB)

EF Core DB-first does NOT auto-sync. You must regenerate models.
================
BEFORE UPDATING THIS COMMAND FIRST IN DATABASE APPLY PRIMARY KEY TO THE ID COLUMN
creating the primary key after creating the table.(add below command in hotelmanagment database)
====================================
 
ALTER TABLE employee ADD CONSTRAINT PK_employee PRIMARY KEY (empid);

==========
ONCE YOU ADD PRIMARY KEY,APPLY BELOW COMMAND.
===================
🔹 Command to update models

Run the same command again with -Force:(USE   -fORCE AT ENDING OF STATEMENT)IF ANY DB MODIFICATIONS PERFOMED AND TO EFFECT THOSE CHANGES TO OUR ENTITY CLASSES.
==========================================
PM>Scaffold-DbContext "Server=DESKTOP-13B42NJ;Database=hotelmanagement;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir hotelmanagementModels -Force
=============================

👉 -Force = overwrite existing models & DbContext
################################

To fix that primary key issue we  need to add the primary key to that table
=====================================================
creating the primary key after creating the table.(add below command in NorthWin_db database)
====================================

ALTER TABLE Department ADD CONSTRAINT PK_Department PRIMARY KEY (deptid);
 
 ==========
ONCE YOU ADD PRIMARY KEY,APPLY BELOW COMMAND.
===================
🔹 Command to update models

Run the same command again with -Force:(USE   -fORCE AT ENDING OF STATEMENT)IF ANY DB MODIFICATIONS PERFOMED AND TO EFFECT THOSE CHANGES TO OUR ENTITY CLASSES.
==========================================
PM>Scaffold-DbContext "Server=DESKTOP-13B42NJ;Database=Northwind_DB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir NorthWind_DbModels -Force
=============================

👉 -Force = overwrite existing models & DbContext
 
 */
#endregion