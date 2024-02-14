using System;
using System.Collections.Generic;

namespace DxHotels.Blazor.Data.Models;

public partial class Room_Feature
{
    public int ID { get; set; }

    public int? Room_ID { get; set; }

    public string? Description { get; set; }

    public string? Feature_Image { get; set; }

    public virtual Room? Room { get; set; }
}
