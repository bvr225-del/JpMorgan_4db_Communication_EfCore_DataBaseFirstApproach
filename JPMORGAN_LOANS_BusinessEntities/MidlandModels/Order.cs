using System;
using System.Collections.Generic;

namespace JPMORGAN_LOANS_BusinessEntities.MidlandModels;

public partial class Order
{
    public int Orderid { get; set; }

    public string? Ordername { get; set; }

    public string? Orderlocation { get; set; }
}
