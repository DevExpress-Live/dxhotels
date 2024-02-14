<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HotelSummaryControl.ascx.cs" Inherits="UserControls_HotelSummaryControl" %>
<div class="hotel-summary">
    <h2 class="hotel-title"><%= hotel.Hotel_Name %></h2>
    <dx:ASPxRatingControl ID="HotelRating" runat="server" CssClass="header-rating-control" OnLoad="HotelRating_Load" OnItemClick="HotelRating_ItemClick"></dx:ASPxRatingControl>
    <div class="hotel-address">
        <dx:ASPxLabel ID="lblAddress" runat="server" Text="" Font-Size="14px" ForeColor="#7c7c7c" EncodeHtml="false"></dx:ASPxLabel>
    </div>
</div>
