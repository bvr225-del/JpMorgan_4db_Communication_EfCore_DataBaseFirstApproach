using System;
using System.Collections.Generic;

namespace JPMORGAN_LOANS_BusinessEntities.hotelmanagementModels;

public partial class SipDashboard
{
    public int Position { get; set; }

    public string? Name { get; set; }

    public decimal? Weight { get; set; }

    public string? Symbol { get; set; }

    public string? Location { get; set; }
}
