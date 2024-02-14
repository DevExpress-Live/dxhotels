using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HotelBookingContext;
using DevExpress.Web;

public partial class Results : BasePage {
    public Results() 
        : base("Results") {
    }

    protected void Page_Load(object sender, EventArgs e) {
        if(!IsPostBack) {
            LocationComboBox.DataBindItems();
            LocationComboBox.SelectedItem = LocationComboBox.Items.FindByValue(State.Metro_Area.ID);

            NightlyRateTrackBar.MaxValue = Math.Floor(State.Metro_Area.MaxRoomPrice);
            NightlyRateTrackBar.MinValue = Math.Floor(State.Metro_Area.MinRoomPrice);

            NightlyRateTrackBar.PositionStart = GetDecimalValue(State.FilterMinPrice, NightlyRateTrackBar.MinValue, NightlyRateTrackBar.MaxValue, NightlyRateTrackBar.MinValue);
            NightlyRateTrackBar.PositionEnd = GetDecimalValue(State.FilterMaxPrice, NightlyRateTrackBar.MinValue, NightlyRateTrackBar.MaxValue, NightlyRateTrackBar.MaxValue);

            CustomerRatingTrackBar.Position = GetDecimalValue(State.FilterCustomerRating, CustomerRatingTrackBar.MinValue, CustomerRatingTrackBar.MaxValue, CustomerRatingTrackBar.MinValue);

            LocationRatingComboBox.Value = State.FilterLocationRating ?? "BBB";

            MapImage.ImageUrl = State.Metro_Area.Map_ImageUrl;

            for(int i = 0; i < 5; i++)
                OurRatingCheckBoxList.Items[i].Selected = State.FilterOurRatingArray.Contains(i + 1);
            EnsureTokensList(false);
        }

        var hotels = FindHotels().ToList();
        HotelsDataView.DataSource = hotels;
        HotelsDataView.DataBind();
        HotelsCountLabel.Text = String.Format("{0} HOTELS", hotels.Count());
    }

    void EnsureTokensList(bool updateFilter) {
        if(!updateFilter)
            FilterTokenBox.Tokens.Clear();
        EnsureToken(State.Metro_Area.Area_Name, updateFilter, () => Response.Redirect("Default.aspx"));
        if(NightlyRateTrackBar.PositionStart != NightlyRateTrackBar.MinValue || NightlyRateTrackBar.PositionEnd != NightlyRateTrackBar.MaxValue) {
            EnsureToken(string.Format("${0}-${1}", NightlyRateTrackBar.PositionStart, NightlyRateTrackBar.PositionEnd), updateFilter, () => {
                State.FilterMaxPrice = null;
                State.FilterMinPrice = null;
            });
        }
        if(CustomerRatingTrackBar.Position > 1)
            EnsureToken(string.Format("{0}+ Customer Rating", CustomerRatingTrackBar.Position), updateFilter, () => State.FilterCustomerRating = null);
        if(State.FilterOurRatingArray.Length < 5)
            EnsureToken(string.Format("{0} Stars", string.Join(", ", State.FilterOurRatingArray)), updateFilter, () => State.FilterOurRating = null);
        if(!string.IsNullOrEmpty(State.FilterLocationRating) && State.FilterLocationRating != "BBB")
            EnsureToken(string.Format("{0}+ Location Rating", State.FilterLocationRating), updateFilter, () => State.FilterLocationRating = null);
        if(updateFilter)
            Response.Redirect("Results.aspx?" + DataProvider.GetQueryString(State.GetQueryParameters(true)));
    }
    void EnsureToken(string text, bool updateFilter, Action changeFilterAction) {
        if(updateFilter && !FilterTokenBox.Tokens.Contains(text))
            changeFilterAction();
        else if(!updateFilter)
            FilterTokenBox.Tokens.Add(text);
    }

    IEnumerable<Hotel> FindHotels() {
        return State.DataContext.Hotels.ToList().Where(h => CheckHotelFilters(h));
    }
    bool CheckHotelFilters(Hotel hotel) {
        return hotel.Cities.Metro_Area_ID == State.Metro_Area.ID &&
               NightlyRateTrackBar.PositionStart <= hotel.EndPrice &&
               hotel.StartPrice <= (NightlyRateTrackBar.PositionEnd + 1) &&
               hotel.Customer_Rating >= CustomerRatingTrackBar.Position &&
               State.FilterOurRatingArray.Contains((int)Math.Floor(hotel.Our_Rating.Value)) &&
               DataProvider.LocationRatings.IndexOf(hotel.Location_Rating) >= DataProvider.LocationRatings.IndexOf(LocationRatingComboBox.Value.ToString());
    }

    protected string GetHotelDetailsUrl(object hotelID) {
        var parameters = State.GetQueryParameters(false);
        parameters["hotelID"] = hotelID.ToString();
        return string.Format("~/Details.aspx?{0}", DataProvider.GetQueryString(parameters));
    }

    protected void ApplyFilterButton_Click(object sender, EventArgs e) {
        var parameters = State.GetQueryParameters(false);
        parameters["location"] = LocationComboBox.Value.ToString();        
        if(NightlyRateTrackBar.PositionStart > NightlyRateTrackBar.MinValue)
            parameters["minprice"] = NightlyRateTrackBar.PositionStart.ToString();
        if(NightlyRateTrackBar.PositionEnd < NightlyRateTrackBar.MaxValue)
            parameters["maxprice"] = NightlyRateTrackBar.PositionEnd.ToString();
        if(CustomerRatingTrackBar.Value != null)
            parameters["custrating"] = CustomerRatingTrackBar.Value.ToString();
        if(LocationRatingComboBox.Value != null)
            parameters["locrating"] = LocationRatingComboBox.Value.ToString();
        if(OurRatingCheckBoxList.SelectedValues.Count > 0)
            parameters["ourrating"] = string.Join(",", OurRatingCheckBoxList.SelectedValues.Cast<int>());
        Response.Redirect("Results.aspx?" + DataProvider.GetQueryString(parameters));
    }
    protected decimal GetDecimalValue(string textValue, decimal minValue, decimal maxValue, decimal defaultValue) {
        if(string.IsNullOrEmpty(textValue))
            return defaultValue;
        var value = Convert.ToDecimal(textValue);
        return Math.Min(Math.Max(minValue, value), maxValue);
    }

    protected void NightyRateTrackBar_CustomJSProperties(object sender, DevExpress.Web.CustomJSPropertiesEventArgs e) {
        e.Properties.Add("cpLeftLabelID", "NightyRateTrackBarLabel_L");
        e.Properties.Add("cpRightLabelID", "NightyRateTrackBarLabel_R");
        e.Properties.Add("cpLabelPrefix", "$");
    }
    protected void CustomerRatingTrackBar_CustomJSProperties(object sender, DevExpress.Web.CustomJSPropertiesEventArgs e) {
        e.Properties.Add("cpRightLabelID", "CustomerRatingTrackbarLabel_R");
    }
    protected void BookItButton_Click(object sender, EventArgs e) {
        var container = ((ASPxButton)sender).BindingContainer as DataViewItemTemplateContainer;
        var hotel = container.DataItem as Hotel;
        var parameters = State.GetQueryParameters(false);
        parameters["hotelID"] = hotel.ID.ToString();
        parameters["roomID"] = hotel.Rooms.Aggregate((room, r) => (room == null || r.Nighly_Rate.Value < room.Nighly_Rate.Value ? room : r)).ID.ToString();
        Response.Redirect("Booking.aspx?" + DataProvider.GetQueryString(parameters));
    }
    protected void FilterTokenBox_ValueChanged(object sender, EventArgs e) {
        EnsureTokensList(true);
    }
}
