using System;
using System.Collections.Generic;

namespace JPMORGAN_LOANS_BusinessEntities.NorthWind_DbModels;

public partial class SummaryOfSalesByYear
{
    public DateTime? ShippedDate { get; set; }

    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
