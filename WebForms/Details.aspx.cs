using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using HotelBookingContext;

public partial class Details : BasePage {
    public Details() 
        : base("Details") {
    }

    protected void Page_Init(object sender, EventArgs e) {
        SearchPanel.State = State;
        BindRoomsNavBar(State.Hotel);
    }
    
    protected void Page_Load(object sender, EventArgs e) {
        HotelSummaryControl.hotel = State.Hotel;
        DescriptionLabel.Text = State.Hotel.Description;
        HotelPicturesImageSlider.DataSource = State.Hotel.Pictures;
        HotelPicturesImageSlider.DataBind();
        ReviewsDataView.DataSource = State.Hotel.Reviews;
        ReviewsDataView.DataBind();

        HotelFeaturesDataView.DataSource = State.Hotel.Hotel_Features.Take(6);
        HotelFeaturesDataView.DataBind();

        RoomFeaturesDataView.DataSource = State.Hotel.Rooms[0].Room_Features;
        RoomFeaturesDataView.DataBind();

        HotelLocationDataView.DataSource = DataProvider.GetDefaultHotelLocations();
        HotelLocationDataView.DataBind();
    }

    void BindRoomsNavBar(Hotel hotel) {
        RoomsNavBar.Groups.Clear();
        foreach(var room in hotel.Rooms) {
            var group = new NavBarGroup(room.Room_Types.Type_Name, room.ID.ToString());
            group.Expanded = false;
            group.DataItem = room;
            RoomsNavBar.Groups.Add(group);
            group.Items.Add();
        }
    }

    protected void FeaturesDataView_Init(object sender, EventArgs e) {
        var dv = sender as ASPxDataView;
        var room = State.Hotel.Rooms[(dv.NamingContainer as NavBarGroupTemplateContainer).Group.VisibleIndex];
        dv.DataSource = room.Room_Features;
        dv.DataBind();
    }

    protected void RoomImageSlider_Init(object sender, EventArgs e) {
        var slider = sender as ASPxImageSlider;
        var room = State.Hotel.Rooms[(slider.NamingContainer as NavBarGroupTemplateContainer).Group.VisibleIndex];
        slider.ClientInstanceName = "RoomSlider" + (slider.NamingContainer as NavBarGroupTemplateContainer).Group.VisibleIndex.ToString();
        slider.DataSource = room.Pictures;
        slider.DataBind();
    }

    protected void ImagePopupControl_WindowCallback(object source, DevExpress.Web.PopupWindowCallbackArgs e) {
        var roomID = Convert.ToInt32(e.Parameter.Substring(0, e.Parameter.IndexOf("|")));
        var imageName = e.Parameter.Substring(e.Parameter.IndexOf("|") + 1);
        var context = new HotelBookingDataContext();
        var room = context.Rooms.First(r => r.ID == roomID);

        RoomPopupImageSlider.DataSource = room.Pictures;
        RoomPopupImageSlider.DataBind();
        RoomPopupImageSlider.ActiveItemIndex = RoomPopupImageSlider.Items.IndexOf(isi => ((Picture)isi.DataItem).Picture_Id == imageName);
    }
    protected void RoomBookItButton_Click(object sender, EventArgs e) {
        var button = sender as ASPxButton;
        var room = State.Hotel.Rooms[(button.NamingContainer as NavBarGroupTemplateContainer).Group.VisibleIndex];
        var parameters = State.GetQueryParameters(false);
        parameters["roomID"] = room.ID.ToString();
        Response.Redirect("Booking.aspx?" + DataProvider.GetQueryString(parameters));
    }
}
