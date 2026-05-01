using System;
using System.Collections.Generic;

namespace JPMORGAN_LOANS_BusinessEntities.NorthWind_DbModels;

public partial class CurrentProductList
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;
}
