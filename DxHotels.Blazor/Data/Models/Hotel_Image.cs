using System;
using System.Collections.Generic;

namespace DxHotels.Blazor.Data.Models;

public partial class Hotel_Image
{
    public int ID { get; set; }

    public int? Hotel_ID { get; set; }

    public string? Image_Id { get; set; }

    public virtual Hotel? Hotel { get; set; }
}
