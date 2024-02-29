﻿using System;
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

    public virtual City? City { get; set; }

    public virtual ICollection<Hotel_Features> Hotel_Features { get; set; } = new List<Hotel_Features>();

    public virtual ICollection<Hotel_Images> Hotel_Images { get; set; } = new List<Hotel_Images>();

    public virtual ICollection<Picture> Pictures { get; set; } = new List<Picture>();

    public virtual ICollection<Reviews> Reviews { get; set; } = new List<Reviews>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
