using System;
using System.Collections.Generic;

namespace DxHotels.Blazor.Data.Models;

public partial class Hotel
{
    public int ID { get; set; }

    public string? Hotel_Name { get; set; }

    public string? Description { get; set; }

    public string? Hotel_Class { get; set; }

    public int? Room_Count { get; set; }

    public string? Location_Rating { get; set; }

    public double? Avg_Customer_Rating { get; set; }

    public double? Our_Rating { get; set; }

    public string? Address { get; set; }

    public int? City_ID { get; set; }

    public string? Postal_Code { get; set; }

    public string? Phone { get; set; }

    public string? Website { get; set; }

    public string? Metro_Area { get; set; }

    public virtual City? Cities { get; set; }

    public virtual ICollection<Hotel_Feature> Hotel_Features { get; set; } = new List<Hotel_Feature>();

    public virtual ICollection<Hotel_Image> Hotel_Images { get; set; } = new List<Hotel_Image>();

    public virtual ICollection<Picture> Pictures { get; set; } = new List<Picture>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
