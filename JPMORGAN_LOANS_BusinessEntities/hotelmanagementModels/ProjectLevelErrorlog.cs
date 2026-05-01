using System;
using System.Collections.Generic;

namespace JPMORGAN_LOANS_BusinessEntities.hotelmanagementModels;

public partial class ProjectLevelErrorlog
{
    public int Id { get; set; }

    public string? StatusCode { get; set; }

    public string? ErrorMessage { get; set; }

    public string? StackTraceError { get; set; }

    public string? InnerExceptionError { get; set; }
}
