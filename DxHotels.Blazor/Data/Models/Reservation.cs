using System;
using System.Collections.Generic;

namespace DxHotels.Blazor.Data.Models;

public partial class Reservation
{
    public int ID { get; set; }

    public int? Room_ID { get; set; }

    public DateTime? Check_In { get; set; }

    public DateTime? Check_Out { get; set; }

    public decimal? Amount_Due { get; set; }

    public decimal? Amount_Paid { get; set; }

    public int? Reservation_Satus { get; set; }

    public int? Number_Of_Adults { get; set; }

    public int? Number_Of_Children { get; set; }

    public string? Special_Requests { get; set; }

    public virtual Room? Room { get; set; }
}
