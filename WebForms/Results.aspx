<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Results.aspx.cs" Inherits="Results" MasterPageFile="~/Site.Master" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="results-header">
        <div class="content-column">
            <div class="map-image">
                <dx:ASPxImage ID="MapImage" runat="server" ShowLoadingImage="true">
                </dx:ASPxImage>
            </div>
            <h3><%= State.Metro_Area.Area_Name %></h3>
            <br />
            <span class="start-filter"><%= State.StartFilterText %></span>
        </div>
    </div>
    <div class="content-column results">
        <div class="results-summary">
            <dx:ASPxLabel ID="HotelsResultsLabel" runat="server" Text="RESULTS " Font-Size="36px" ForeColor="#f78119"></dx:ASPxLabel>
            <dx:ASPxLabel ID="HotelsCountLabel" runat="server" Text=" {0} HOTELS" Font-Size="36px" ForeColor="#999999"></dx:ASPxLabel>
            <dx:ASPxTokenBox ID="FilterTokenBox" runat="server" ItemValueType="System.String" Font-Size="16px" Width="100%" CssClass="token-box" AutoPostBack="true" OnValueChanged="FilterTokenBox_ValueChanged">
                <TokenRemoveButtonStyle CssClass="token-remove-button"></TokenRemoveButtonStyle>
                <TokenTextStyle CssClass="token-text"></TokenTextStyle>
                <TokenStyle CssClass="token"></TokenStyle>
                <TokenBoxInputStyle CssClass="token-box-input"></TokenBoxInputStyle>
            </dx:ASPxTokenBox>
        </div>
        <div class="results-content">
            <dx:ASPxDataView runat="server" ID="HotelsDataView" Layout="Table" Width="100%" PagerAlign="Left" ItemSpacing="0">
                <ClientSideEvents EndCallback="onDataViewEndCallback"></ClientSideEvents>
                <ContentStyle>
                    <Border BorderStyle="None" />
                </ContentStyle>
                <ItemStyle CssClass="item" />
                <SettingsTableLayout ColumnCount="1" RowsPerPage="3" />
                <PagerSettings Position="Bottom" ShowNumericButtons="true">
                    <Summary Visible="false" />
                </PagerSettings>
                <PagerStyle CssClass="pager"></PagerStyle>
                <ItemTemplate>
                    <div class="hotel-image">
                        <dx:ASPxHyperLink ID="HotelImage" runat="server" ImageWidth="140px" ImageHeight="140px"
                            ImageUrl='<%# Eval("PrimaryPicture.Url") %>' NavigateUrl='<%# GetHotelDetailsUrl(Eval("ID")) %>'>
                        </dx:ASPxHyperLink>
                    </div>
                    <div class="hotel-common">
                        <dx:ASPxHyperLink ID="HotelTitleHyperLink" runat="server" Text='<%# Eval("Hotel_Name") %>' CssClass="hotel-title"
                            NavigateUrl='<%# GetHotelDetailsUrl(Eval("ID")) %>'>
                        </dx:ASPxHyperLink>
                        <div class="hotel-address">
                            <%# Eval("Address") %><br />
                            <%# Eval("DetailsCity") %>
                        </div>
                        <div class="hotel-stats">
                            <div class="stat">
                                TYPE:
                                <dx:ASPxLabel ID="HotelClassLabel" runat="server" Font-Bold="False" Text='<%# Eval("Hotel_Class") %>' Font-Size="14px"></dx:ASPxLabel>
                            </div>
                            <div class="stat">
                                LOCATION:
                                <dx:ASPxLabel ID="HotelLocRatingLabel" runat="server" Font-Bold="False" Text='<%# Eval("Location_Rating") %>' Font-Size="14px"></dx:ASPxLabel>
                            </div>
                            <div class="stat">
                                RATING:
                                <dx:ASPxLabel ID="HotelOurRatingLabel" runat="server" Font-Bold="False" Text='<%# Eval("Our_Rating") %>' Font-Size="14px"></dx:ASPxLabel>
                                <dx:ASPxImage runat="server" ID="StarImage" ImageUrl="~/Content/Images/star.png"></dx:ASPxImage>
                            </div>
                        </div>
                        <dx:ASPxRatingControl ID="HotelCustomerRatingControl" runat="server" Value='<%# Eval("Customer_Rating") %>' ReadOnly="True" CssClass="rating-control"></dx:ASPxRatingControl>
                    </div>
                    <div class="hotel-right-block">
                        <div class="price"><%# Eval("StartPrice","{0:C}") %></div>
                        per night<br />
                        <dx:ASPxButton ID="BookItButton" runat="server" Text="Book It" Width="110px" Height="40px" CssClass="button" OnClick="BookItButton_Click" BackColor="#f7f7f7">
                            <HoverStyle CssClass="orange-button-hover"></HoverStyle>
                        </dx:ASPxButton>
                    </div>
                    <div class="clear"></div>
                    <div class="hotel-description">
                        <%# Eval("Description") %>
                    </div>
                </ItemTemplate>
            </dx:ASPxDataView>
        </div>
        <div class="results-filter">
            <dx:ASPxFormLayout ID="FilterFormLayout" runat="server" Width="100%">
                <Styles>
                    <LayoutItem CssClass="item">
                        <Caption CssClass="caption"></Caption>
                        <NestedControlCell CssClass="cell"></NestedControlCell>
                    </LayoutItem>
                </Styles>
                <Items>
                    <dx:LayoutItem Caption="Search by City" CssClass="editor-item">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxComboBox ID="LocationComboBox" runat="server" Width="100%" Height="30px" DataSourceID="LocationDataSource"
                                    TextField="Area_Name" ValueField="ID" ValueType="System.Int32" CssClass="editor">
                                    <Border BorderStyle="None" />
                                    <DropDownButton>
                                        <Image Url="~/Content/Images/search.png"></Image>
                                    </DropDownButton>
                                </dx:ASPxComboBox>
                                <ef:EntityDataSource ID="LocationDataSource" runat="server" ContextTypeName="HotelBookingContext.HotelBookingDataContext" EntitySetName="Metro_Areas" OrderBy="it.Area_Name">
                                </ef:EntityDataSource>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="Nightly Rate">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <div class="trackbar-container-lr">
                                    <div id="NightyRateTrackBarLabel_L" class="trackbar-label-l">$100</div>
                                    <div id="NightyRateTrackBarLabel_R" class="trackbar-label-r">$400</div>
                                    <dx:ASPxTrackBar ID="NightlyRateTrackBar" runat="server" Position="0" PositionStart="0" Step="1"
                                        ShowChangeButtons="false" AllowRangeSelection="true" Width="100%" Height="25px" OnCustomJSProperties="NightyRateTrackBar_CustomJSProperties"
                                        ValueToolTipPosition="None" CssClass="trackbar">
                                        <ClientSideEvents Init="updateRatingLabels" PositionChanging="updateRatingLabels" PositionChanged="updateRatingLabels" />
                                    </dx:ASPxTrackBar>
                                </div>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="Customer Rating">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <div class="trackbar-container-r">
                                    <div id="CustomerRatingTrackbarLabel_R" class="trackbar-label-r">$400</div>
                                    <dx:ASPxTrackBar ID="CustomerRatingTrackBar" runat="server" Position="0" PositionStart="0"
                                        Step="1" ShowChangeButtons="false" Width="100%" OnCustomJSProperties="CustomerRatingTrackBar_CustomJSProperties"
                                        ValueToolTipPosition="None" MinValue="1" MaxValue="5" Height="25px" CssClass="trackbar">
                                        <ClientSideEvents Init="updateRatingLabels" PositionChanging="updateRatingLabels" PositionChanged="updateRatingLabels" />
                                    </dx:ASPxTrackBar>
                                </div>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="Our Rating">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxCheckBoxList ID="OurRatingCheckBoxList" CssClass="resultrating" runat="server" ValueType="System.Int32" Height="100px">
                                    <Border BorderStyle="None" />
                                    <Items>
                                        <dx:ListEditItem ImageUrl="~/Content/Images/star1.png" Value="1" Text="" />
                                        <dx:ListEditItem ImageUrl="~/Content/Images/star2.png" Value="2" Text="" />
                                        <dx:ListEditItem ImageUrl="~/Content/Images/star3.png" Value="3" Text="" />
                                        <dx:ListEditItem ImageUrl="~/Content/Images/star4.png" Value="4" Text="" />
                                        <dx:ListEditItem ImageUrl="~/Content/Images/star5.png" Value="5" Text="" />
                                    </Items>
                                </dx:ASPxCheckBoxList>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="Location" CssClass="editor-item">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxComboBox ID="LocationRatingComboBox" runat="server" Width="200px" Height="30px" CssClass="editor">
                                    <Border BorderStyle="None" />
                                    <Items>
                                        <dx:ListEditItem Text="AAA" Value="AAA" />
                                        <dx:ListEditItem Text="AA" Value="AA" />
                                        <dx:ListEditItem Text="A" Value="A" />
                                        <dx:ListEditItem Text="BBB" Value="BBB" />
                                    </Items>
                                </dx:ASPxComboBox>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="" CssClass="button-item">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxButton runat="server" ID="ApplyFilterButton" Text="APPLY" Width="100%" OnClick="ApplyFilterButton_Click" Font-Size="14px"></dx:ASPxButton>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                </Items>
                <SettingsItemCaptions Location="Top" />
            </dx:ASPxFormLayout>
        </div>
        <div style="clear: both"></div>
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="FooterControlsPlaceHolder" runat="server">
    ASP.NET Data View Control<br />
    ASP.NET Data Editors Library<br />
    ASP.NET Rating Control
</asp:Content>
