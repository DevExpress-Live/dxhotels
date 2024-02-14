using System;
using System.Collections.Generic;

namespace DxHotels.Blazor.Data.Models;

public partial class City
{
    public int ID { get; set; }

    public string? City_Name { get; set; }

    public string? State_Province { get; set; }

    public string? Country { get; set; }

    public string? Offer { get; set; }

    public string? City_Image { get; set; }

    public int? Metro_Area_ID { get; set; }

    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();

    public virtual Metro_Area? Metro_Area { get; set; }
}
