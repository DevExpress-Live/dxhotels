using System;
using System.Collections.Generic;

namespace DxHotels.Blazor.Data.Models;

public partial class Guests
{
    public int ID { get; set; }

    public string? First_Name { get; set; }

    public string? Last_Name { get; set; }

    public string? Title { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Postal_Code { get; set; }

    public string? Country { get; set; }

    public string? Phone_Number { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }
}
