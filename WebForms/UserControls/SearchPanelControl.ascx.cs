using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HotelBookingContext;

public partial class UserControls_SearchPanel : System.Web.UI.UserControl {
    public bool IsPopup { get; set; }
    public SearchState State { get; set; }

    protected void Page_Init(object sender, EventArgs e) {
        CheckInDateEdit.MinDate = DateTime.Now + TimeSpan.FromDays(1);

        if(!IsPostBack)
            BindLocationComboBox();

        if(State != null) {
            LocationComboBox.DataBindItems();
            LocationComboBox.SelectedItem = LocationComboBox.Items.FindByValue(State.Metro_Area.ID);
            CheckOutDateEdit.Value = State.CheckOutDate;
            CheckInDateEdit.Value = State.CheckInDate;
            RoomsComboBox.Value = State.RoomsCount;
            AdultsSpinEdit.Value = State.AdultsCount;
            ChildrenSpinEdit.Value = State.ChildrenCount;
        }
        else {
            CheckOutDateEdit.Value = DateTime.Now + TimeSpan.FromDays(3);
            CheckInDateEdit.Value = DateTime.Now + TimeSpan.FromDays(1);
        }
    }
    void BindLocationComboBox() {
        using(var dataContext = new HotelBookingDataContext()) {
            var data = dataContext.Metro_Areas.ToList().Select(ma => new { ma.ID, ma.Country, ma.City, ma.Area_Name, ma.Hotels_Count });
            LocationComboBox.DataSource = data.OrderBy(a => a.Area_Name);
            LocationComboBox.DataBind();
        }
    }

    protected void Page_Load(object sender, EventArgs e) {
        if(IsPopup) {
            Search.Attributes["class"] = "searchPanelPopUp";
            SearchButton.Text = "Apply";
        }
    }

    protected void SearchButton_Click(object sender, EventArgs e) {
        NameValueCollection parameters = new NameValueCollection() {
            { "location", LocationComboBox.Value.ToString() },
            { "checkin", CheckInDateEdit.Date.ToString("M-d-yyyy") },
            { "checkout", CheckOutDateEdit.Date.ToString("M-d-yyyy") },
            { "rooms", RoomsComboBox.Value.ToString() },
            { "adults", AdultsSpinEdit.Value.ToString() },
            { "children", ChildrenSpinEdit.Value.ToString() },
        };
        var redirectUrl = "Results.aspx?" + DataProvider.GetQueryString(parameters);
        if(Page.IsCallback)
            DevExpress.Web.ASPxWebControl.RedirectOnCallback(redirectUrl);
        else
            Response.Redirect(redirectUrl);    
    }
}
