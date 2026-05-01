using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPMORGAN_LOANS_BusinessEntities.Dtos
{
    public class OrderDto
    {
        public int Orderid { get; set; }

        public string? Ordername { get; set; }

        public string? Orderlocation { get; set; }

    }
}
