<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Details.aspx.cs" Inherits="Details" MasterPageFile="~/Site.Master" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="details-header">
        <div class="content-column">
            <dx:HotelSummary runat="server" ID="HotelSummaryControl" />
            <div class="filter-info">
                <%= State.StartFilterText %>
                <dx:ASPxButton ID="UpdateFilterButton" runat="server" CssClass="button-white" Height="40px" Text="Change Search" Width="138px" AutoPostBack="False">
                    <HoverStyle CssClass="orange-button-hover"></HoverStyle>
                </dx:ASPxButton>
            </div>
            <div class="clear"></div>
        </div>
    </div>
    <div class="details-content">
        <dx:ASPxImageSlider runat="server" ID="HotelPicturesImageSlider" Height="463px" Width="620px" CssClass="details-slider" ImageUrlField="Url"></dx:ASPxImageSlider>
        <div class="details-comments">
            <h5>What our guests say...</h5>
            <dx:ASPxDataView ID="ReviewsDataView" runat="server" ItemSpacing="0">
                <ContentStyle CssClass="dataview-content"></ContentStyle>
                <ItemStyle CssClass="item" />
                <SettingsTableLayout ColumnCount="1" />
                <ItemTemplate>
                    <%# Eval("Review_Text") %>
                    <div class="date"><%# Eval("Posted_On","{0:MMM d, yyyy}") %></div>
                    <dx:ASPxRatingControl ID="ReviewRatingControl" runat="server" Value='<%# Convert.ToDecimal(Eval("Rating")) %>' ReadOnly="true">
                    </dx:ASPxRatingControl>
                </ItemTemplate>
            </dx:ASPxDataView>
        </div>
        <div style="clear: both;"></div>
        <div class="description">
            <h5>Description</h5>
            <dx:ASPxLabel ID="DescriptionLabel" runat="server" Text="Hotel description" Font-Size="14px"></dx:ASPxLabel>
        </div>
        <div class="feature-info">
            <div class="block">
                <h5>Features</h5>
                <dx:ASPxDataView ID="HotelFeaturesDataView" runat="server" ItemSpacing="6px">
                    <ContentStyle Border-BorderStyle="None"></ContentStyle>
                    <SettingsTableLayout ColumnCount="1" RowsPerPage="10" />
                    <ItemStyle CssClass="item" />
                    <PagerSettings Visible="False"></PagerSettings>
                    <ItemTemplate>
                        <dx:ASPxLabel ID="HotelFeatureLabel" runat="server" Font-Size="14px" Text='<%# Eval("Description") %>'>
                        </dx:ASPxLabel>
                    </ItemTemplate>
                </dx:ASPxDataView>
            </div>
            <div class="block">
                <h5>Rooms</h5>
                <dx:ASPxDataView ID="RoomFeaturesDataView" runat="server" ItemSpacing="6px">
                    <ContentStyle Border-BorderStyle="None"></ContentStyle>
                    <SettingsTableLayout ColumnCount="1" RowsPerPage="10" />
                    <ItemStyle CssClass="item" />
                    <PagerSettings Visible="False"></PagerSettings>
                    <ItemTemplate>
                        <dx:ASPxLabel ID="RoomFeatureLabel" runat="server" Font-Size="14px" Text='<%# Eval("Description") %>'>
                        </dx:ASPxLabel>
                    </ItemTemplate>
                </dx:ASPxDataView>
            </div>
            <div class="block">
                <h5>Location</h5>
                <dx:ASPxDataView ID="HotelLocationDataView" runat="server" ItemSpacing="6px">
                    <ContentStyle Border-BorderStyle="None"></ContentStyle>
                    <SettingsTableLayout ColumnCount="1" RowsPerPage="10" />
                    <ItemStyle CssClass="item" />
                    <PagerSettings Visible="False"></PagerSettings>
                    <ItemTemplate>
                        <dx:ASPxLabel ID="HotelLocationLabel" runat="server" Font-Size="14px" Text='<%# Container.DataItem %>'>
                        </dx:ASPxLabel>
                    </ItemTemplate>
                </dx:ASPxDataView>
            </div>
        </div>
        <div style="clear: both;"></div>
        <dx:ASPxNavBar runat="server" ID="RoomsNavBar" ClientInstanceName="RoomsNavBar" CssClass="rooms-navbar" ExpandButtonPosition="Left" Width="100%" AutoCollapse="true">
            <ClientSideEvents ExpandedChanged="onRoomsNavBarExpandedChanged" />
            <GroupHeaderStyle CssClass="navbar-header" />
            <GroupContentStyle CssClass="navbar-content" />
            <CollapseImage Url="~/Content/Images/RoomColButton.png"></CollapseImage>
            <ExpandImage Url="~/Content/Images/RoomExpButton.png"></ExpandImage>
            <GroupHeaderTemplate>
                <div class="title">
                    <%# Eval("Text") %>
                </div>
                <div class="right-panel">
                    <div class="rate-date">
                        <div class="low-rate">
                            LOWEST PRICE
                        </div>
                        <div class="date">
                            available on <%# Eval("DataItem.PriceAvailableDate", "{0:M/dd/yyyy}") %>
                        </div>
                    </div>
                    <div class="price">
                        <%# Eval("DataItem.Nighly_Rate", "{0:C}") %>
                    </div>
                    <dx:ASPxButton runat="server" Text="Book It" Height="40px" Font-Size="14px" Width="110px" CssClass="button-grey" ID="RoomBookItButton" OnClick="RoomBookItButton_Click" UseSubmitBehavior="false">
                        <ClientSideEvents Click="function(s, e) { e.cancelBubbleEvent = true; }" />
                        <HoverStyle CssClass="button-grey-hover"></HoverStyle>
                    </dx:ASPxButton>
                </div>
                <div class="clear"></div>
            </GroupHeaderTemplate>
            <GroupContentTemplate>
                <div class="room-description">
                    <%# Eval("DataItem.Room_Short_Description") %>
                </div>
                <div class="clear"></div>
                <div class="slider-container">
                    <dx:ASPxImageSlider runat="server" ID="RoomImageSlider" CssClass="room-slider" OnInit="RoomImageSlider_Init" ShowImageArea="false"
                        NameField="Picture_Id" ThumbnailUrlField="Url" Width="100%" ClientSideEvents-ThumbnailItemClick='<%# string.Format("function(s, e) {{ onRoomImageNavItemClick({0}, e.item.name); }}", State.Hotel.Rooms[Container.ItemIndex].ID) %>'>
                        <SettingsNavigationBar ThumbnailsNavigationButtonPosition="Outside" ItemSpacing="10px" />
                        <Styles>
                            <NavigationBarThumbnailsModeBottom CssClass="navbar">
                            </NavigationBarThumbnailsModeBottom>
                            <Thumbnail CssClass="thumb" ImageWidth="120px" ImageHeight="70px"></Thumbnail>
                        </Styles>
                    </dx:ASPxImageSlider>
                </div>
                <div class="room-info">
                    <dx:ASPxDataView runat="server" ID="FeaturesDataView" OnInit="FeaturesDataView_Init" ItemSpacing="6px">
                        <ContentStyle Border-BorderStyle="None"></ContentStyle>
                        <SettingsTableLayout ColumnCount="2" RowsPerPage="3" />
                        <PagerSettings Visible="false"></PagerSettings>
                        <ItemStyle Width="162px" Height="22px" Paddings-Padding="0" CssClass="feature-item" />
                        <ItemTemplate>
                            <dx:ASPxImage runat="server" CssClass="feature-img" ID="RoomFeatureIcon" ImageUrl='<%# Eval("ImageUrl") %>'></dx:ASPxImage>
                            <div class="feature-description"><%# Eval("Description") %></div>
                        </ItemTemplate>
                    </dx:ASPxDataView>
                </div>
                <div class="clear"></div>
            </GroupContentTemplate>
        </dx:ASPxNavBar>
        <dx:ASPxPopupControl ID="StartFilterPopupControl" runat="server" HeaderText="" ShowHeader="False" FooterText="" Height="300px" PopupElementID="UpdateFilterButton" PopupHorizontalAlign="RightSides" PopupVerticalAlign="Below" ShowCloseButton="False" Width="400px">
            <ContentCollection>
                <dx:PopupControlContentControl runat="server">
                    <dx:SearchPanel runat="server" ID="SearchPanel" IsPopup="true" />
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>
        <dx:ASPxPopupControl ID="ImagePopupControl" ClientInstanceName="ImagePopupControl" runat="server" OnWindowCallback="ImagePopupControl_WindowCallback"
            Modal="True" PopupAnimationType="Fade" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ShowPageScrollbarWhenModal="true"
            ShowHeader="False" Width="600px" Height="500px" CssClass="popup">
            <ModalBackgroundStyle CssClass="modal-bg" />
            <ContentCollection>
                <dx:PopupControlContentControl runat="server">
                    <dx:ASPxImageSlider ID="RoomPopupImageSlider" ClientInstanceName="RoomPopupImageSlider" Width="100%" Height="500px" runat="server" ImageUrlField="Url">
                        <SettingsAutoGeneratedImages ImageCacheFolder="~\Thumb\" />
                    </dx:ASPxImageSlider>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="FooterControlsPlaceHolder" runat="server">
    ASP.NET Navigation Bar<br />
    ASP.NET Image Slider<br />
    ASP.NET Data View Control
</asp:Content>
