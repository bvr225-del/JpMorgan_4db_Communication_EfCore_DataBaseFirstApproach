using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPMORGAN_LOANS_BusinessEntities.Dtos
{
    public class EmployeeDto
    {
        public int Empid { get; set; }
        public string? Empname { get; set; }
        public decimal? Empsalary { get; set; }

    }
}
