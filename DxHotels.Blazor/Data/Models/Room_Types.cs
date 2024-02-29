using System;
using System.Collections.Generic;

namespace DxHotels.Blazor.Data.Models;

public partial class Room_Types
{
    public int ID { get; set; }

    public string? Type_Name { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
