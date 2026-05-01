using System;
using System.Collections.Generic;

namespace JPMORGAN_LOANS_BusinessEntities.NorthWind_DbModels;

public partial class Region
{
    public int RegionId { get; set; }

    public string RegionDescription { get; set; } = null!;

    public virtual ICollection<Territory> Territories { get; set; } = new List<Territory>();
}
