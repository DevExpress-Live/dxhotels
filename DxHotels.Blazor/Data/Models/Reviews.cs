using System;
using System.Collections.Generic;

namespace DxHotels.Blazor.Data.Models;

public partial class Reviews
{
    public int ID { get; set; }

    public int? Hotel_ID { get; set; }

    public string? Review_Text { get; set; }

    public DateTime? Posted_On { get; set; }

    public double? Rating { get; set; }

    public string? Reviewer_Name { get; set; }

    public virtual Hotel? Hotel { get; set; }
}
