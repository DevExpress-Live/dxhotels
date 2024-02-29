using System;
using System.Collections.Generic;

namespace DxHotels.Blazor.Data.Models;

public partial class Hotel_Features
{
    public int ID { get; set; }

    public int? Hotel_ID { get; set; }

    public string? Description { get; set; }

    public virtual Hotel? Hotel { get; set; }
}
