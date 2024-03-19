namespace DxHotels.Blazor.Data.Models
{
    public partial class Metro_Area
    {
        public int ID { get; set; }

        public string? Area_Name { get; set; }

        public string? Map_Image { get; set; }

        public string? Country { get; set; }

        public string? City { get; set; }

        public virtual ICollection<City> Cities { get; set; } = new List<City>();
    }

}
