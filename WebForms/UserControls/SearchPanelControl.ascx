<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchPanelControl.ascx.cs" Inherits="UserControls_SearchPanel" %>
<script type="text/javascript">
    function CalcRooms() {
        RoomsComboBox.SetText(Math.ceil(AdultsSpinEdit.GetNumber() / 2));
    };
    function SetChildMax() {
        ChildrenSpinEdit.SetMaxValue(AdultsSpinEdit.GetNumber() * 3);
        if (ChildrenSpinEdit.GetNumber() > ChildrenSpinEdit.GetMaxValue()) {
            ChildrenSpinEdit.SetNumber(ChildrenSpinEdit.GetMaxValue());
        }
        CalcRooms();
    };
    function ValidateAndPerformSearch() {
        if (ASPxClientEdit.ValidateGroup('location') & ASPxClientEdit.ValidateGroup('dateRange') & ASPxClientEdit.ValidateGroup('search'))
           CallbackPanel.PerformCallback('');
    };
</script>
<div id="Search" class="search-panel" runat="server">
    <dx:ASPxFormLayout ID="SearchPanelLayout" runat="server" Width="100%" ColCount="3" Height="100%" ShowItemCaptionColon="false" RequiredMarkDisplayMode="None">
        <Styles>
            <LayoutItem CssClass="item">
                <Caption CssClass="item-caption"></Caption>
            </LayoutItem>
        </Styles>
        <SettingsItemCaptions Location="Top" />
        <Items>
            <dx:LayoutItem ShowCaption="False" ColSpan="3">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer>
                        <h3>HOTEL SEARCH</h3>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem Caption="Location" ColSpan="3" CssClass="cmbLocs">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer>
                        <dx:ASPxComboBox ID="LocationComboBox" runat="server" TextField="City_Name" TextFormatString="{0}, {1}" Width="100%"
                            DropDownStyle="DropDownList" ValueType="System.Int32" IncrementalFilteringMode="StartsWith" ValueField="ID" Height="30px" CssClass="editor">
                            <ListBoxStyle Font-Size="14px"></ListBoxStyle>
                            <Columns>
                                <dx:ListBoxColumn Caption="City" FieldName="City" Width="40%"></dx:ListBoxColumn>
                                <dx:ListBoxColumn Caption="Country" FieldName="Country" Width="30%"></dx:ListBoxColumn>
                                <dx:ListBoxColumn Caption="# of Hotels" FieldName="Hotels_Count" Width="30%"></dx:ListBoxColumn>
                            </Columns>
                            <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorDisplayMode="None" SetFocusOnError="true" ValidationGroup="location">
                                <RequiredField ErrorText="Location must be selected" IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxComboBox>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem ShowCaption="False" ColSpan="3" >
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer>
                        <dx:ASPxValidationSummary ID="ValidationSummaryLocation" ValidationGroup="location" runat="server" ShowErrorsInEditors="True">
                        </dx:ASPxValidationSummary>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem Caption="Check in" ColSpan="1" Width="50%" CssClass="cmbLocs">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer>
                        <dx:ASPxDateEdit ID="CheckInDateEdit" runat="server" Width="100%" Height="30px" EditFormat="Custom" EditFormatString="d MMM yyyy" ClientInstanceName="CheckInDateEdit" CssClass="editor">
                            <DropDownButton>
                                <Image IconID="scheduling_today_16x16gray" Url="~/Content/Images/calendar.png">
                                </Image>
                            </DropDownButton>
                            <Paddings PaddingLeft="10px" />
                            <ValidationSettings ValidationGroup="dateRange" Display="Dynamic" ErrorDisplayMode="None" SetFocusOnError="true" ValidateOnLeave="False">
                                <RequiredField IsRequired="True" ErrorText="Check in date is required"></RequiredField>
                            </ValidationSettings>
                        </dx:ASPxDateEdit>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem Caption="Check out" ColSpan="2" Width="50%" CssClass="cmbLocs">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer>
                        <dx:ASPxDateEdit ID="CheckOutDateEdit" runat="server" Width="100%" Height="30px" EditFormat="Custom" EditFormatString="d MMM yyyy" ClientInstanceName="CheckOutDateEdit" CssClass="editor">
                            <DropDownButton>
                                <Image IconID="scheduling_today_16x16gray" Url="~/Content/Images/calendar.png">
                                </Image>
                            </DropDownButton>
                            <Paddings PaddingLeft="10px" />
                            <ValidationSettings ValidationGroup="dateRange" Display="Dynamic" ErrorDisplayMode="None" SetFocusOnError="true" ValidateOnLeave="False">
                                <RequiredField IsRequired="True" ErrorText="Check out date is required"></RequiredField>
                            </ValidationSettings>
                            <DateRangeSettings StartDateEditID="CheckInDateEdit" MinDayCount="1" MaxDayCount="28"></DateRangeSettings>
                        </dx:ASPxDateEdit>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem ShowCaption="False" ColSpan="3" >
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer>
                        <dx:ASPxValidationSummary ID="DateRangeValidationSummary" ValidationGroup="dateRange" runat="server" ShowErrorsInEditors="True">
                        </dx:ASPxValidationSummary>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem Caption="Rooms" Width="50%">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer>
                        <dx:ASPxComboBox ID="RoomsComboBox" ClientInstanceName="RoomsComboBox" runat="server" Width="100%" SelectedIndex="0" Height="30px" CssClass="editor">
                            <Items>
                                <dx:ListEditItem Text="1" Value="1" Selected="True"></dx:ListEditItem>
                                <dx:ListEditItem Text="2" Value="2"></dx:ListEditItem>
                                <dx:ListEditItem Text="3" Value="3"></dx:ListEditItem>
                                <dx:ListEditItem Text="4" Value="4"></dx:ListEditItem>
                                <dx:ListEditItem Text="5" Value="5"></dx:ListEditItem>
                            </Items>
                            <ValidationSettings ValidationGroup="search"></ValidationSettings>
                        </dx:ASPxComboBox>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem Caption="Adults" Width="25%">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer>
                        <dx:ASPxSpinEdit ID="AdultsSpinEdit" runat="server" ClientInstanceName="AdultsSpinEdit" Number="1" AllowNull="False" LargeIncrement="1" 
                            NumberType="Integer" MaxValue="10" Width="100%" Height="30px" MinValue="1" CssClass="editor">
                            <SpinButtons ShowIncrementButtons="False" ShowLargeIncrementButtons="True">
                            </SpinButtons>
                            <ClientSideEvents NumberChanged="function(s, e) { SetChildMax(); }" />
                            <ValidationSettings ValidationGroup="search"></ValidationSettings>
                        </dx:ASPxSpinEdit>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem Caption="Children" Width="25%">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer>
                        <dx:ASPxSpinEdit ID="ChildrenSpinEdit" runat="server" ClientInstanceName="ChildrenSpinEdit" Number="0" AllowNull="False" LargeIncrement="1" 
                            NumberType="Integer" MaxValue="10" Width="100%" Height="30px" CssClass="editor">
                            <SpinButtons ShowIncrementButtons="False" ShowLargeIncrementButtons="True">
                            </SpinButtons>
                            <ValidationSettings ValidationGroup="search"></ValidationSettings>
                        </dx:ASPxSpinEdit>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem ShowCaption="False" ColSpan="3">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer>
                        <dx:ASPxCallbackPanel runat="server" ID="CallbackPanel" ClientInstanceName="CallbackPanel" OnCallback="SearchButton_Click"></dx:ASPxCallbackPanel>
                        <dx:ASPxButton ID="SearchButton" runat="server" Text="SEARCH" CssClass="search-button" Width="100%" AutoPostBack="False">
                            <ClientSideEvents Click="ValidateAndPerformSearch"></ClientSideEvents>
                            <Border BorderStyle="None" />
                            <HoverStyle CssClass="search-button-hover">
                            </HoverStyle>
                        </dx:ASPxButton>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
        </Items>
    </dx:ASPxFormLayout>
</div>
