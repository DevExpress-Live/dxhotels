<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" MasterPageFile="~/Site.Master" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="index-banner">
        <div class="searchPanelContainer">
            <dx:SearchPanel runat="server" ID="SearchPanel" />
            <div class="text">
                <h1>Hotel Booking</h1>
                <h2>powered by DevExpress ASP.NET Controls</h2>
            </div>
        </div>
    </div>
    <div class="clear"></div>
    <div class="widgets">
        <div class="content-column">
            <dx:ASPxDockZone ID="WidgetsDockZone" runat="server" Orientation="Horizontal" PanelSpacing="10px" ZoneUID="dz" Height="148px" ClientInstanceName="dockZone">
                <Paddings PaddingTop="30px" />
            </dx:ASPxDockZone>
            <dx:ASPxDockPanel ID="dpWidget2" runat="server" AllowedDockState="DockedOnly" OwnerZoneUID="dz" DragElement="Window" ShowHeader="false"
                CssClass="widget" ClientInstanceName="dpw2">
                <ContentCollection>
                    <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">
                        <div class="closeImageContainer">
                            <dx:ASPxImage ID="dpWidget2CloseImage" runat="server" ShowLoadingImage="true" ImageUrl="~/Content/Images/offer-close-ico.png" CssClass="closeImage">
                                <ClientSideEvents Click="function(){ closeWidget(2); }" />
                            </dx:ASPxImage>
                        </div>
                        <div class="imageContainer">
                            <dx:ASPxImage ID="dpWidget2Image" runat="server" ShowLoadingImage="true" ImageUrl="~/Content/Images/wid2.png" CssClass="image">
                                <ClientSideEvents Click="function(s, e){ pcWidgetInfo.Show(); }" />
                            </dx:ASPxImage>
                        </div>
                    </dx:PopupControlContentControl>
                </ContentCollection>
            </dx:ASPxDockPanel>
            <dx:ASPxDockPanel ID="dpWidget1" runat="server" AllowedDockState="DockedOnly" OwnerZoneUID="dz" DragElement="Window" ShowHeader="false"
                CssClass="widget" ClientInstanceName="dpw1">
                <ContentCollection>
                    <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                        <div class="closeImageContainer">
                            <dx:ASPxImage ID="dpWidget1CloseImage" runat="server" ShowLoadingImage="true" ImageUrl="~/Content/Images/offer-close-ico.png" CssClass="closeImage">
                                <ClientSideEvents Click="function(){ closeWidget(1); }" />
                            </dx:ASPxImage>
                        </div>
                        <div class="imageContainer">
                            <dx:ASPxImage ID="dpWidget1Image" runat="server" ShowLoadingImage="true" ImageUrl="~/Content/Images/wid1.png" CssClass="image">
                                <ClientSideEvents Click="function(s, e){ pcWidgetInfo.Show(); }" />
                            </dx:ASPxImage>
                        </div>
                    </dx:PopupControlContentControl>
                </ContentCollection>
            </dx:ASPxDockPanel>
            <dx:ASPxDockPanel ID="dpWidget3" runat="server" AllowedDockState="DockedOnly" OwnerZoneUID="dz" DragElement="Window" ShowHeader="false"
                Width="230px" Height="148px" CssClass="widget" ClientInstanceName="dpw3">
                <ContentCollection>
                    <dx:PopupControlContentControl ID="PopupControlContentControl3" runat="server">
                        <div class="closeImageContainer">
                            <dx:ASPxImage ID="dpWidget3CloseImage" runat="server" ShowLoadingImage="true" ImageUrl="~/Content/Images/offer-close-ico.png" CssClass="closeImage">
                                <ClientSideEvents Click="function(){ closeWidget(3); }" />
                            </dx:ASPxImage>
                        </div>
                        <div class="imageContainer">
                            <dx:ASPxImage ID="dpWidget3Image" runat="server" ShowLoadingImage="true" ImageUrl="~/Content/Images/wid3.png" CssClass="image">
                                <ClientSideEvents Click="function(s, e){ pcWidgetInfo.Show(); }" />
                            </dx:ASPxImage>
                        </div>
                    </dx:PopupControlContentControl>
                </ContentCollection>
            </dx:ASPxDockPanel>
        </div>
    </div>
    <div class="index-offers content-column">
        <div class="title">
            SPECIAL OFFERS
        </div>
        <div class="imageSlider">
            <dx:ASPxImageSlider ID="SpecialOffersImageSlider" runat="server" Height="505px" Width="100%" EncodeHtml="False">
                <SettingsImageArea AnimationType="Fade" ImageSizeMode="FillAndCrop" ItemTextVisibility="Always" />
                <SettingsAutoGeneratedImages ImageCacheFolder="~\Thumb\" />
                <SettingsSlideShow AutoPlay="True" />
                <Items>
                    <dx:ImageSliderItem ImageUrl="~/Content/Images/Cities/Athens.jpg" Text="<div class='hotel'>Greece Majesty</div><div class='city'>Athens, Greece</div><div class='price'>$214</div>">
                    </dx:ImageSliderItem>
                    <dx:ImageSliderItem ImageUrl="~/Content/Images/Cities/Barcelona.jpg" Text="<div class='hotel'>Hotel Barcelona Universal</div><div  class='city'>Barcelona, Spain</div><div class='price'>$136</div>">
                    </dx:ImageSliderItem>
                    <dx:ImageSliderItem ImageUrl="~/Content/Images/Cities/Berlin.jpg" Text="<div class='hotel'>Das Hotel</div><div class='city'>Berlin, Germany</div><div class='price'>$155</div>">
                    </dx:ImageSliderItem>
                    <dx:ImageSliderItem ImageUrl="~/Content/Images/Cities/Cairo.jpg" Text="<div class='hotel'>Sand Castle</div><div class='city'>Cairo, Egypt</div><div class='price'>$215</div>">
                    </dx:ImageSliderItem>
                    <dx:ImageSliderItem ImageUrl="~/Content/Images/Cities/LA.jpg" Text="<div class='hotel'>Hotel LA</div><div class='city'>Los Angeles, USA</div><div class='price'>$215</div>">
                    </dx:ImageSliderItem>
                    <dx:ImageSliderItem ImageUrl="~/Content/Images/Cities/London.jpg" Text="<div class='hotel'>Posh House</div><div class='city'>London, England</div><div class='price'>$355</div>">
                    </dx:ImageSliderItem>
                    <dx:ImageSliderItem ImageUrl="~/Content/Images/Cities/Moscow.jpg" Text="<div class='hotel'>Hotel Profit</div><div class='city'>Moscow, Russia</div><div class='price'>$143</div>">
                    </dx:ImageSliderItem>
                    <dx:ImageSliderItem ImageUrl="~/Content/Images/Cities/NY.jpg" Text="<div class='hotel'>The Hood</div><div class='city'>New York, USA</div><div class='price'>$199</div>">
                    </dx:ImageSliderItem>
                    <dx:ImageSliderItem ImageUrl="~/Content/Images/Cities/Paris.jpg" Text="<div class='hotel'>Hotel Des Ducs D'Anjou</div><div class='city'>Paris, France</div><div class='price'>$438</div>">
                    </dx:ImageSliderItem>
                    <dx:ImageSliderItem ImageUrl="~/Content/Images/Cities/Prague.jpg" Text="<div class='hotel'>Hotel Tyl</div><div class='city'>Prague, Czech Republic</div><div class='price'>$227</div>">
                    </dx:ImageSliderItem>
                    <dx:ImageSliderItem ImageUrl="~/Content/Images/Cities/Rio.jpg" Text="<div class='hotel'>La Maison</div><div class='city'>Rio, Brazil</div><div class='price'>$600</div>">
                    </dx:ImageSliderItem>
                    <dx:ImageSliderItem ImageUrl="~/Content/Images/Cities/Sydney.jpg" Text="<div class='hotel'>Harbour Rocks Hotel</div><div class='city'>Sydney, Australia</div><div class='price'>$354</div>">
                    </dx:ImageSliderItem>
                    <dx:ImageSliderItem ImageUrl="~/Content/Images/Cities/Tokoyo.jpg" Text="<div class='hotel'>Shibuya Tobu Hotel</div><div class='city'>Tokoyo, Japan</div><div class='price'>$230</div>">
                    </dx:ImageSliderItem>
                </Items>
            </dx:ASPxImageSlider>
        </div>
    </div>
    <dx:ASPxPopupControl ID="pcWidgetInfo" ClientInstanceName="pcWidgetInfo" runat="server" Modal="True" ShowPageScrollbarWhenModal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ShowHeader="false">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl4" runat="server">
                <div class="widgetPopup">
                    <h2 class="title">DevExpress ASP.NET Widget View
                    </h2>
                    <br />
                    <div class="text">
                        Use widgets to display dynamic content and allow your end users to re-position or delete individual widget panes.
                    </div>
                    <br />
                    <dx:ASPxButton ID="btnCloseWidgetPopup" runat="server" Text="Close" Width="300px" AutoPostBack="False" BackColor="#F7F7F7" Font-Size="14px" Height="40px">
                        <ClientSideEvents Click="function(s, e) { pcWidgetInfo.Hide(); }" />
                        <HoverStyle BackColor="#F88E1D">
                        </HoverStyle>
                    </dx:ASPxButton>
                </div>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
</asp:Content>
<asp:Content ContentPlaceHolderID="FooterControlsPlaceHolder" runat="server">
    ASP.NET Images Gallery<br />
    ASP.NET Data Editors Library<br />
    ASP.NET Popup Controls
</asp:Content>
