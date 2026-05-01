using System;
using System.Collections.Generic;

namespace JPMORGAN_LOANS_BusinessEntities.hotelmanagementModels;

public partial class NewBooking
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? CustomerName { get; set; }

    public string? Country { get; set; }

    public string? City { get; set; }
}
