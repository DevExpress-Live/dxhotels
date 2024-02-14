using System;
using System.Collections.Generic;

namespace DxHotels.Blazor.Data.Models;

public partial class Picture
{
    public int ID { get; set; }

    public string? Picture_Id { get; set; }

    public int? Hotel_ID { get; set; }

    public int? Room_ID { get; set; }

    public virtual Hotel? Hotel { get; set; }

    public virtual Room? Room { get; set; }
}
