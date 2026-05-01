using System;
using System.Collections.Generic;

namespace JPMORGAN_LOANS_BusinessEntities.hotelmanagementModels;

public partial class Booking
{
    public int? Id { get; set; }

    public string? CustomerName { get; set; }

    public string? Location { get; set; }

    public DateOnly? Date { get; set; }
}
