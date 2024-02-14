using System;
using HotelBookingContext;

public partial class UserControls_HotelSummaryControl : System.Web.UI.UserControl {

    public Hotel hotel { get; set; }

    protected void Page_Load(object sender, EventArgs e) {
        lblAddress.Text = hotel.Address + "<br />" + hotel.DetailsCity;
        HotelRating.Value = hotel.Customer_Rating;
    }

    protected void Page_Init(object sender, EventArgs e) {
    }

    protected void HotelRating_Load(object sender, EventArgs e) {
        HotelRating.ImageMapUrl = "~/Content/Images/rating-map.png";
        HotelRating.BackColor = System.Drawing.Color.Transparent;
        HotelRating.ItemHeight = 32;
        HotelRating.ItemWidth = 34;
    }
    protected void HotelRating_ItemClick(object sender, DevExpress.Web.RatingControlItemEventArgs e) {
        DataProvider.CustomRatings[hotel.ID] = e.ItemIndex + 1;
        HotelRating.Value = DataProvider.CustomRatings[hotel.ID];
    }
}
