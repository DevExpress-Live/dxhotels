using System;
using System.Collections.Generic;

public partial class Booking : BasePage {
    public Booking() 
        : base("Booking") {
    }

    protected void Page_Load(object sender, EventArgs e) {
        HotelImage.ImageUrl = State.Hotel.PrimaryPicture.Url;

        HotelSummaryControl.hotel = State.Hotel;

        RoomFeaturesDataView.DataSource = State.Room.Room_Features;
        RoomFeaturesDataView.DataBind();

        BindPriceRepeater();
    }

    void BindPriceRepeater() {
        List<object> prices = new List<object>();
        if(State.NightsCount < 4) {
            for(int i = 0; i < State.NightsCount; i++) {
                var date = State.CheckInDate + TimeSpan.FromDays(i);
                prices.Add(new { Period = date.ToString("dddd, MMMM dd, yyyy"), Price = State.Room.Nighly_Rate });
            }
        }
        else {
            prices.Add(new { Period = State.CheckInDate.ToString("dddd, MMMM dd, yyyy"), Price = State.Room.Nighly_Rate });
            prices.Add(new {
                Period = string.Format("{0:MMM d} - {1:MMM d}", State.CheckInDate + TimeSpan.FromDays(1), State.CheckOutDate - TimeSpan.FromDays(1)),
                Price = State.Room.Nighly_Rate * (State.NightsCount - 2)
            });

            prices.Add(new { Period = State.CheckOutDate.ToString("dddd, MMMM dd, yyyy"), Price = State.Room.Nighly_Rate });
        }
        PriceRepeater.DataSource = prices;
        PriceRepeater.DataBind();
    }
    protected void InvoiceDocumentViewer_Load(object sender, EventArgs e) {
        InvoiceDocumentViewer.Report = DataProvider.CreateReport(State);
    }
    protected void CheckCaptchaButton_Click(object sender, EventArgs e) {
        AccountCaptchaEditor.IsValid = AccountCaptcha.Code == AccountCaptchaEditor.Text;
    }
}
