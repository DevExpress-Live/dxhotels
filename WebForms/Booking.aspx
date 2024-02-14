<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Booking.aspx.cs" Inherits="Booking" MasterPageFile="~/Site.Master" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="booking-header">
        <div class="content">
            <dx:HotelSummary runat="server" ID="HotelSummaryControl" />
            <div class="help-block">
                <div class="text">
                    <h5>We are here to help.</h5>
                    <span class="contact">Contact us by email: <a href="mailto:info@devexpress.com" style="color: #f88e1d; text-decoration: underline">info@devexpress.com</a>
                    </span>
                </div>
                <dx:ASPxImage ID="HelpImage" runat="server" ImageUrl="~/Content/Images/help.png" CssClass="image"></dx:ASPxImage>
            </div>
        </div>
    </div>
    <div class="clear"></div>
    <div class="booking-title">
        <h5>Book now and remember...</h5>
        <h4>This is not a real travel website and these are not real hotels.
        </h4>
    </div>
    <div class="booking-content">
        <div class="form">
            <h3>Already have a DX Hotels account? Login below.</h3>
            <div class="block">
                <dx:ASPxFormLayout ID="AccountFormLayout" runat="server" CssClass="form-layout" RequiredMarkDisplayMode="None" ColCount="2">
                    <Styles>
                        <LayoutItem CssClass="item"></LayoutItem>
                    </Styles>
                    <Items>
                        <dx:LayoutItem ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="AccountEmailTextBox" ClientInstanceName="AccountEmailTextBox" NullText="Email" NullTextDisplayMode="UnfocusedAndFocused" runat="server" Height="30px" Width="328px" CssClass="editor">
                                        <NullTextStyle CssClass="nulltext"></NullTextStyle>
                                        <ValidationSettings ValidationGroup="Account" ErrorDisplayMode="None" Display="Dynamic" SetFocusOnError="true">
                                            <RegularExpression ErrorText="" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                            <RequiredField IsRequired="true" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="AccountPasswordTextBox" Password="true" NullText="Password" NullTextDisplayMode="UnfocusedAndFocused" Height="30px" runat="server" Width="328px" CssClass="editor">
                                        <NullTextStyle CssClass="nulltext"></NullTextStyle>
                                        <ValidationSettings ValidationGroup="Account" ErrorDisplayMode="None" Display="Dynamic" SetFocusOnError="true">
                                            <RequiredField IsRequired="true" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:EmptyLayoutItem Height="15px">
                        </dx:EmptyLayoutItem>
                        <dx:LayoutItem ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxCaptcha ID="AccountCaptcha" ClientInstanceName="AccountCaptcha" runat="server" CssClass="captcha" Width="100%" CodeLength="5">
                                        <ValidationSettings ValidationGroup="Account" ErrorDisplayMode="None" Display="Dynamic" SetFocusOnError="true"></ValidationSettings>
                                        <TextBox Visible="false" />
                                        <ChallengeImage Width="328"></ChallengeImage>
                                        <RefreshButton Position="Right"></RefreshButton>
                                    </dx:ASPxCaptcha>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem CssClass="captcha-text-item">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="AccountCaptchaEditor" Height="30px" runat="server" Width="232px" CssClass="editor" NullText="Type the code" NullTextDisplayMode="UnfocusedAndFocused">
                                        <NullTextStyle CssClass="nulltext"></NullTextStyle>
                                        <ValidationSettings ValidationGroup="Account" ErrorDisplayMode="None" Display="Dynamic" SetFocusOnError="true">
                                            <RequiredField IsRequired="true" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem>
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxButton runat="server" ID="CheckCaptchaButton" Text="Submit" Width="80px" Height="30px" Font-Size="14px" 
                                        ValidationGroup="Account" OnClick="CheckCaptchaButton_Click">
                                    </dx:ASPxButton>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                    <SettingsItems ShowCaption="False" />
                </dx:ASPxFormLayout>
            </div>
            <h3>Room Details</h3>
            <div class="block">
                <div class="room-info"><%= State.Room.Room_Short_Description %></div>
                <div class="comment">
                    Please give us the name of one of the people
                    <br />
                    staying in this room.
                </div>
                <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" CssClass="form-layout no-margin-top" EncodeHtml="false"
                    ShowItemCaptionColon="false" RequiredMarkDisplayMode="None">
                    <SettingsItems ShowCaption="False" />
                    <Styles>
                        <LayoutItem CssClass="item" />
                    </Styles>
                    <Items>
                        <dx:LayoutItem>
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="FirstNameTextBox" runat="server" Width="328px" NullText="First Name" NullTextDisplayMode="UnfocusedAndFocused" Height="30px" CssClass="editor">
                                        <NullTextStyle CssClass="nulltext"></NullTextStyle>
                                        <ValidationSettings ValidationGroup="RoomDetails" ErrorDisplayMode="None" Display="Dynamic">
                                            <RequiredField IsRequired="true" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem>
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="LastNameTextBox" runat="server" Width="328px" NullText="Last Name" NullTextDisplayMode="UnfocusedAndFocused" Height="30px" CssClass="editor">
                                        <NullTextStyle CssClass="nulltext"></NullTextStyle>
                                        <ValidationSettings ValidationGroup="RoomDetails" ErrorDisplayMode="None" Display="Dynamic">
                                            <RequiredField IsRequired="true" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem>
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="EmailTextBox" ClientInstanceName="EmailTextBox" runat="server" Width="328px" NullText="Email" NullTextDisplayMode="UnfocusedAndFocused" Height="30px" CssClass="editor">
                                        <NullTextStyle CssClass="nulltext"></NullTextStyle>
                                        <ValidationSettings ValidationGroup="RoomDetails" ErrorDisplayMode="None" Display="Dynamic">
                                            <RegularExpression ErrorText="" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                            <RequiredField IsRequired="true" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                </dx:ASPxFormLayout>
                <div class="room-info-bottom">
                    <dx:ASPxCheckBoxList runat="server" ID="RoomOptionsCheckBoxList" RepeatColumns="2" CssClass="checkbox-list" Font-Size="14px">
                        <Border BorderStyle="None" />
                        <Paddings Padding="0" />
                        <CheckBoxStyle CssClass="checkbox-button"></CheckBoxStyle>
                        <Items>
                            <dx:ListEditItem Text="Queen Bed" Value="QueenBed" Selected="true" />
                            <dx:ListEditItem Text="Smoking" Value="Smoking" />
                        </Items>
                    </dx:ASPxCheckBoxList>
                </div>
            </div>
            <h3>Payment Details</h3>
            <div class="block-info">
                <div class="block">
                    <dx:ASPxPageControl ID="PaymentPageControl" runat="server" ActiveTabIndex="0" Width="100%" BackColor="White" CssClass="page-control">
                        <ContentStyle CssClass="page-control-content"></ContentStyle>
                        <Paddings PaddingTop="0" />
                        <TabStyle CssClass="tab">
                            <Paddings Padding="18px" />
                            <Border BorderColor="#dedede" BorderStyle="Solid" BorderWidth="1px" />
                            <BorderTop BorderStyle="None" />
                        </TabStyle>
                        <ActiveTabStyle CssClass="active-tab">
                            <BorderBottom BorderStyle="None" />
                        </ActiveTabStyle>
                        <ContentStyle CssClass="tab-content">
                            <BorderTop BorderColor="#dedede" BorderStyle="Solid" BorderWidth="1px" />
                        </ContentStyle>
                        <TabPages>
                            <dx:TabPage Text="Credit Card">
                                <TabStyle>
                                    <BorderLeft BorderStyle="None" />
                                </TabStyle>
                                <ContentCollection>
                                    <dx:ContentControl runat="server">
                                        <div class="comment">
                                            We accept the following payment methods<br />
                                            <dx:ASPxImage runat="server" ImageUrl="~/Content/Images/card_visa.png" CssClass="card-image">
                                            </dx:ASPxImage>
                                            <dx:ASPxImage runat="server" ImageUrl="~/Content/Images/card_ax.png" CssClass="card-image">
                                            </dx:ASPxImage>
                                            <dx:ASPxImage runat="server" ImageUrl="~/Content/Images/card_master.png" CssClass="card-image">
                                            </dx:ASPxImage>
                                        </div>
                                        <dx:ASPxFormLayout ID="CreditCardFormLayout" CssClass="form-layout" runat="server" ColCount="2" RequiredMarkDisplayMode="None">
                                            <Styles>
                                                <LayoutItem CssClass="item">
                                                    <Caption Font-Size="14px"></Caption>
                                                </LayoutItem>
                                            </Styles>
                                            <Items>
                                                <dx:LayoutItem ColSpan="2" ShowCaption="False">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxTextBox ID="CreditCardNameTextBox" NullText="Name" NullTextDisplayMode="UnfocusedAndFocused" runat="server" Width="328px" Height="30px" CssClass="editor">
                                                                <NullTextStyle CssClass="nulltext"></NullTextStyle>
                                                                <ValidationSettings ValidationGroup="CreditCard" ErrorDisplayMode="None" Display="Dynamic">
                                                                    <RequiredField IsRequired="true" />
                                                                </ValidationSettings>
                                                            </dx:ASPxTextBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem ColSpan="2" ShowCaption="False">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxTextBox ID="CreditCardEmailTextBox" ClientInstanceName="CreditCardEmailTextBox" NullText="Email" NullTextDisplayMode="UnfocusedAndFocused" runat="server" Width="328px" CssClass="editor" Height="30px">
                                                                <NullTextStyle CssClass="nulltext"></NullTextStyle>
                                                                <ValidationSettings ValidationGroup="CreditCard" ErrorDisplayMode="None" Display="Dynamic">
                                                                    <RegularExpression ErrorText="" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                                                    <RequiredField IsRequired="true" />
                                                                </ValidationSettings>
                                                            </dx:ASPxTextBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem ColSpan="2" ShowCaption="False">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxTextBox ID="CreditCardNumberTextBox" NullText="Card #" runat="server" Width="328px" CssClass="editor" Height="30px">
                                                                <NullTextStyle CssClass="nulltext"></NullTextStyle>
                                                                <MaskSettings Mask="0000 0000 0000 0009" IncludeLiterals="None" PromptChar=" " />
                                                                <ValidationSettings ValidationGroup="CreditCard" ErrorDisplayMode="None" Display="Dynamic">
                                                                    <RequiredField IsRequired="true" />
                                                                </ValidationSettings>
                                                            </dx:ASPxTextBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem ColSpan="2" ShowCaption="False">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxTextBox ID="CreditCardPasswordTextBox" NullText="CVV" runat="server"
                                                                Width="328px" CssClass="editor" Height="30px">
                                                                <NullTextStyle CssClass="nulltext"></NullTextStyle>
                                                                <MaskSettings Mask="0009" PromptChar=" "  />
                                                                <ValidationSettings ValidationGroup="CreditCard" ErrorDisplayMode="None" Display="Dynamic">
                                                                    <RequiredField IsRequired="true" />
                                                                </ValidationSettings>
                                                            </dx:ASPxTextBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:EmptyLayoutItem ColSpan="2" Height="14px">
                                                </dx:EmptyLayoutItem>
                                                <dx:LayoutItem Caption="Exp. Date" CaptionSettings-VerticalAlign="Middle">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxComboBox ID="CreditCardMonthComboBox" runat="server" NullText="Month" NullTextDisplayMode="UnfocusedAndFocused" Width="125px"
                                                                ValueField="Key" TextField="Value" DataSourceID="MonthsDataSource" CssClass="editor" Height="30px">
                                                                <NullTextStyle CssClass="nulltext"></NullTextStyle>
                                                                <ValidationSettings ValidationGroup="CreditCard" ErrorDisplayMode="None" Display="Dynamic">
                                                                    <RequiredField IsRequired="true" />
                                                                </ValidationSettings>
                                                            </dx:ASPxComboBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                    <CaptionSettings VerticalAlign="Middle"></CaptionSettings>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem ShowCaption="False">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxComboBox ID="CreditCardYearComboBox" NullText="Year" runat="server" Width="125px" Height="30px"
                                                                DataSourceID="CardExpiredYearsDataSource" CssClass="editor" NullTextDisplayMode="UnfocusedAndFocused">
                                                                <NullTextStyle CssClass="nulltext"></NullTextStyle>
                                                                <ValidationSettings ValidationGroup="CreditCard" ErrorDisplayMode="None" Display="Dynamic">
                                                                    <RequiredField IsRequired="true" />
                                                                </ValidationSettings>
                                                            </dx:ASPxComboBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                            </Items>
                                        </dx:ASPxFormLayout>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:TabPage>
                            <dx:TabPage Text="PayPal">
                                <ContentCollection>
                                    <dx:ContentControl runat="server">
                                        <div class="comment">Thank you for visiting our website. At present, we do not accept PayPal payments.</div>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:TabPage>
                        </TabPages>
                    </dx:ASPxPageControl>
                </div>
                <div class="info">
                    <h5>YOU CAN COUNT ON US</h5>
                    <ul>
                        <li>We don’t process credit cards</li>
                        <li>We don’t have any hotels</li>
                        <li>We only offer great controls</li>
                    </ul>
                </div>
            </div>
            <div class="clear"></div>
            <h3>Billing Information</h3>
            <div class="block">
                <dx:ASPxFormLayout ID="BillingFormLayout" CssClass="form-layout" runat="server" ColCount="2" RequiredMarkDisplayMode="None">
                    <Styles>
                        <LayoutItem CssClass="item" />
                    </Styles>
                    <Items>
                        <dx:LayoutItem ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="BillingAddressTextBox" NullText="Address" NullTextDisplayMode="UnfocusedAndFocused" runat="server" Width="328px" Height="30px" CssClass="editor">
                                        <NullTextStyle CssClass="nulltext"></NullTextStyle>
                                        <ValidationSettings ValidationGroup="Billing" ErrorDisplayMode="None" Display="Dynamic">
                                            <RequiredField IsRequired="true" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="BillingCityTextBox" NullText="City" NullTextDisplayMode="UnfocusedAndFocused" runat="server" Width="328px" Height="30px" CssClass="editor">
                                        <NullTextStyle CssClass="nulltext"></NullTextStyle>
                                        <ValidationSettings ValidationGroup="Billing" ErrorDisplayMode="None" Display="Dynamic">
                                            <RequiredField IsRequired="true" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem>
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxComboBox ID="BillingStateComboBox" NullText="State" NullTextDisplayMode="UnfocusedAndFocused" runat="server" Width="112px" Height="30px" CssClass="editor"
                                        DataSourceID="StatesDataSource">
                                        <NullTextStyle CssClass="nulltext"></NullTextStyle>
                                        <ValidationSettings ValidationGroup="Billing" ErrorDisplayMode="None" Display="Dynamic">
                                            <RequiredField IsRequired="true" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem>
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="BillingZipCodeTextBox" NullText="Zip Code" NullTextDisplayMode="UnfocusedAndFocused" runat="server" Width="200px" Height="30px" CssClass="editor">
                                        <NullTextStyle CssClass="nulltext"></NullTextStyle>
                                        <ValidationSettings ValidationGroup="Billing" ErrorDisplayMode="None" Display="Dynamic">
                                            <RequiredField IsRequired="true" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxCheckBox ID="BillingCreateAccountCheckBox" runat="server" CssClass="editor" CheckState="Unchecked" Text="Please create an account">
                                        <CheckBoxStyle CssClass="checkbox-button"></CheckBoxStyle>
                                    </dx:ASPxCheckBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                    <SettingsItems ShowCaption="False" />
                </dx:ASPxFormLayout>
            </div>
        </div>
        <div class="summary">
            <h3>Your Reservation Summary</h3>
            <div class="block">
                <div class="common">
                    <dx:ASPxImage ID="HotelImage" runat="server" CssClass="hotel-image" Width="70px" Height="70px" />
                    <h5><%= State.Hotel.Hotel_Name %></h5>
                    <span class="address"><%= State.Hotel.Address %><br />
                        <%= State.Hotel.DetailsCity %></span>
                    <div class="clear"></div>
                    <div class="date-container">
                        Check in<br />
                        <span class="date"><%= State.CheckInDate.ToString("MMMM dd, yyyy") %></span>
                    </div>
                    <div class="date-container">
                        Check out<br />
                        <span class="date"><%= State.CheckOutDate.ToString("MMMM dd, yyyy") %></span>
                    </div>
                    <div class="clear"></div>
                </div>
                <div class="room-info">
                    <h5><%= State.Room.Room_Types.Type_Name %></h5>
                    <dx:ASPxDataView runat="server" ID="RoomFeaturesDataView" CssClass="features-data-view" ItemSpacing="6px">
                        <ContentStyle CssClass="content"></ContentStyle>
                        <SettingsTableLayout ColumnCount="2" RowsPerPage="3" />
                        <ItemStyle Width="148px" Height="22px" CssClass="item" />
                        <PagerSettings Visible="false"></PagerSettings>
                        <ItemTemplate>
                            <dx:ASPxImage runat="server" CssClass="feature-img" ImageAlign="Middle" ID="RoomFeatureIcon" ImageUrl='<%# Eval("ImageUrl") %>'></dx:ASPxImage>
                            <div class="feature-description"><%# Eval("Description") %></div>
                        </ItemTemplate>
                    </dx:ASPxDataView>
                </div>
                <div class="price-info">
                    <table class="price-block">
                        <asp:Repeater runat="server" ID="PriceRepeater">
                            <ItemTemplate>
                                <tr class="price-day">
                                    <td class="period"><%# Eval("Period") %></td>
                                    <td class="price"><%# Eval("Price", "{0:C}") %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr class="price-result">
                            <td class="period">TOTAL</td>
                            <td class="price"><%= string.Format("{0:C}", State.Room.Nighly_Rate.Value * State.NightsCount) %></td>
                        </tr>
                    </table>
                    <div class="small-price-block">
                        TOTAL<br />
                        <span class="price">
                            <%= string.Format("{0:C}", State.Room.Nighly_Rate.Value * State.NightsCount) %>
                        </span>
                    </div>
                </div>
                <div class="deals-info">
                    <h5 style="margin: 0;">Deals and Discounts</h5>
                    <dx:ASPxRadioButtonList runat="server" ID="DealsRadioButtonList" CssClass="radio-list" Font-Size="14px">
                        <Border BorderWidth="0" />
                        <RadioButtonStyle CssClass="radio-button"></RadioButtonStyle>
                        <Items>
                            <dx:ListEditItem Text="10-15% discount at Macy’s stores" Value="Macy" Selected="true" />
                            <dx:ListEditItem Text="Exclusive offers — $500 value" Value="Offer" />
                        </Items>
                    </dx:ASPxRadioButtonList>
                </div>
                <div class="invoice-info">
                    <dx:ASPxButton runat="server" CssClass="button" Width="150px" Height="40px" ID="InvoiceButton" Text="Print Invoice" AutoPostBack="false">
                        <ClientSideEvents Click="onInvoiceButtonClick" />
                        <HoverStyle CssClass="orange-button-hover"></HoverStyle>
                    </dx:ASPxButton>
                </div>
            </div>
        </div>
    </div>
    <div style="clear: both"></div>
    <asp:ObjectDataSource ID="MonthsDataSource" runat="server" SelectMethod="GetMonths" TypeName="DataProvider"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="CardExpiredYearsDataSource" runat="server" SelectMethod="GetCardExpiredYears" TypeName="DataProvider"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="StatesDataSource" runat="server" SelectMethod="GetStates" TypeName="DataProvider"></asp:ObjectDataSource>
    <dx:ASPxPopupControl runat="server" ID="ReportPopupControl" ClientInstanceName="ReportPopupControl" Width="800px" CssClass="report-popup" Modal="True" 
        ShowHeader="false" ShowPageScrollbarWhenModal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="TopSides" LoadContentViaCallback="OnFirstShow">
        <ModalBackgroundStyle Opacity="80" BackColor="Black"></ModalBackgroundStyle>
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxButton runat="server" CssClass="report-button" AutoPostBack="false">
                    <Image Url="~/Content/Images/r-print.png"></Image>
                    <ClientSideEvents Click="function() { InvoiceDocumentViewer.GetViewer().Print(); }" />
                </dx:ASPxButton>
                <dx:ASPxButton runat="server" CssClass="report-button" AutoPostBack="false">
                    <Image Url="~/Content/Images/r-export.png"></Image>
                    <ClientSideEvents Click="function() { InvoiceDocumentViewer.GetViewer().SaveToDisk('pdf'); }" />
                </dx:ASPxButton>
                <dx:ASPxButton runat="server" CssClass="report-button button-right" AutoPostBack="false">
                    <Image Url="~/Content/Images/r-close.png"></Image>
                    <ClientSideEvents Click="function() { ReportPopupControl.Hide(); }" />
                </dx:ASPxButton>
                <dx:ASPxDocumentViewer ID="InvoiceDocumentViewer" ClientInstanceName="InvoiceDocumentViewer" runat="server" OnLoad="InvoiceDocumentViewer_Load" 
                    CssClass="invoice-viewer" ToolbarMode="None" BackColor="Transparent">
                    <StylesSplitter>
                        <Pane CssClass="report-pane"></Pane>
                    </StylesSplitter>
                </dx:ASPxDocumentViewer>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
</asp:Content>
<asp:Content ContentPlaceHolderID="FooterControlsPlaceHolder" runat="server">
    ASP.NET Data Editors Library<br />
    ASP.NET Image Slider<br />
    ASP.NET Tab Control
</asp:Content>
