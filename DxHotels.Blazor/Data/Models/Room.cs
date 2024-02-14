using System;
using System.Collections.Generic;

namespace DxHotels.Blazor.Data.Models;

public partial class Room
{
    public int ID { get; set; }

    public int? Hotel_ID { get; set; }

    public int? Room_Type { get; set; }

    public string? Room_Short_Description { get; set; }

    public decimal? Nighly_Rate { get; set; }

    public string? Room_Image1 { get; set; }

    public string? Room_Image2 { get; set; }

    public string? Room_Image3 { get; set; }

    public string? Room_Image4 { get; set; }

    public string? Room_image5 { get; set; }

    public virtual Hotel? Hotel { get; set; }

    public virtual ICollection<Picture> Pictures { get; set; } = new List<Picture>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual ICollection<Room_Feature> Room_Features { get; set; } = new List<Room_Feature>();

    public virtual Room_Type? Room_TypeNavigation { get; set; }
}
