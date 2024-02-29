using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DXHotels.Controls
{
    public partial class DevExtremeGallery<TItem> : DevExtremeBaseWidget
    {
        public DevExtremeGallery() : base()
        {

        }

        protected override Dictionary<string, object> options { get; set; } = new Dictionary<string, object>
        {
            {"accessKey", null!},
            {"animationDuration", 400},
            {"animationEnabled", true},
            //{"dataSource", null!},
            {"disabled", false},
            {"elementAttr", null!},
            {"focusStateEnabled", true},
            {"height", "400"},
            {"hint", ""},
            {"hoverStateEnabled", false},
            {"indicatorEnabled", true},
            {"initialItemWidth", ""},
            {"itemComponent", null!},
            {"itemHoldTimeout", 750},
            {"itemRender", null!},
            //{"items", Edit},
            {"itemTemplate", "item"},
            {"loop", false},
            {"noDataText", "No data to display"},
            {"rtlEnabled", false},
            {"selectedIndex", 0},
            {"selectedItem", null!},
            {"showIndicator", true},
            {"showNavButtons", false},
            {"slideshowDelay", 0},
            {"stretchImages", false},
            {"swipeEnabled", true},
            {"tabIndex", 0},
            {"visible", true},
            {"width", ""},
            {"wrapAround", false}
        };


        protected override string ModuleName => "./_content/DXHotels.Controls/DevExtremeGallery.razor.js";
        protected override string JSSetOptionName => "setGalleryOption";
        protected override string JSSetOptionsName => "setGalleryOptions";

        protected async override Task<IJSObjectReference> InitializeDXControl()
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<IJSObjectReference>("initializeGallery", dotNetObjectReference, DXWidget, DataSource, options);
        }

        protected override async Task OnParametersSetAsync()
        {
            if (DXClientWidget != null)
            {
                var module = await moduleTask.Value;
                await module.InvokeVoidAsync("changeGalleryDataSource", DXClientWidget, DataSource);
            }
        }

        // DevExtreme properties
#pragma warning disable BL0007
        [Parameter] public IEnumerable<TItem> DataSource { get; set; } = default!;

        [Parameter]
        public int AnimationDuration { get => (int)options["animationDuration"]; set => ChangeProperty("animationDuration", value); }
        [Parameter]
        public bool AnimationEnabled { get => (bool)options["animationEnabled"]; set => ChangeProperty("animationEnabled", value); }

        //dataSource:Edit,
        [Parameter]
        public bool Disabled { get => (bool)options["disabled"]; set => ChangeProperty("disabled", value); }
        //elementAttr:{},
        [Parameter]
        public bool FocusStateEnabled { get => (bool)options["focusStateEnabled"]; set => ChangeProperty("focusStateEnabled", value); }
        [Parameter]
        public string Height { get => (string)options["height"]; set => ChangeProperty("height", value); }
        [Parameter]
        public string Hint { get => (string)options["hint"]; set => ChangeProperty("hint", value); }
        [Parameter]
        public bool HoverStateEnabled { get => (bool)options["hoverStateEnabled"]; set => ChangeProperty("hoverStateEnabled", value); }
        [Parameter]
        public bool IndicatorEnabled { get => (bool)options["indicatorEnabled"]; set => ChangeProperty("indicatorEnabled", value); }
        [Parameter]
        public string InitialItemWidth { get => (string)options["initialItemWidth"]; set => ChangeProperty("initialItemWidth", value); }



        [Parameter]
        public int ItemHoldTimeout { get => (int)options["itemHoldTimeout"]; set => ChangeProperty("itemHoldTimeout", value); }
        //itemComponent:null,
        //itemRender:null,
        //items:Edit,
        //itemTemplate:"item",
        //selectedItem:null,
        [Parameter]
        public bool Loop { get => (bool)options["loop"]; set => ChangeProperty("loop", value); }
        [Parameter]
        public string NoDataText { get => (string)options["noDataText"]; set => ChangeProperty("noDataText", value); }

        [Parameter]
        public bool RtlEnabled { get => (bool)options["rtlEnabled"]; set => ChangeProperty("rtlEnabled", value); }
        [Parameter]
        public int SelectedIndex { get => (int)options["selectedIndex"]; set => ChangeProperty("selectedIndex", value); }
        [Parameter]
        public EventCallback<int> SelectedIndexChanged { get; set; }

        [Parameter]
        public bool ShowIndicator { get => (bool)options["showIndicator"]; set => ChangeProperty("showIndicator", value); }
        [Parameter]
        public bool ShowNavButtons { get => (bool)options["showNavButtons"]; set => ChangeProperty("showNavButtons", value); }
        [Parameter]
        public int SlideshowDelay { get => (int)options["slideshowDelay"]; set => ChangeProperty("slideshowDelay", value); }
        [Parameter]
        public bool StretchImages { get => (bool)options["stretchImages"]; set => ChangeProperty("stretchImages", value); }
        [Parameter]
        public bool SwipeEnabled { get => (bool)options["swipeEnabled"]; set => ChangeProperty("swipeEnabled", value); }
        [Parameter]
        public int TabIndex { get => (int)options["tabIndex"]; set => ChangeProperty("tabIndex", value); }
        [Parameter]
        public bool Visible { get => (bool)options["visible"]; set => ChangeProperty("visible", value); }
        [Parameter]
        public string Width { get => (string)options["width"]; set => ChangeProperty("width", value); }
        [Parameter]
        public bool WrapAround { get => (bool)options["wrapAround"]; set => ChangeProperty("wrapAround", value); }

#pragma warning restore BL0007

        [Parameter] public EventCallback<DXGalleryDataEventArgs<TItem>> ItemClick { get; set; }
        [Parameter] public EventCallback<DXGalleryDataEventArgs<TItem>> ItemContextMenu { get; set; }
        [Parameter] public EventCallback<DXGalleryDataEventArgs<TItem>> ItemHold { get; set; }
        [Parameter] public EventCallback<DXGalleryDataEventArgs<TItem>> ItemRendered { get; set; }
        [Parameter] public EventCallback<DXGalleryOptionChangedEventArgs<TItem>> OptionChanged { get; set; }
        [Parameter] public EventCallback<DXGallerySelectionChangedEventArgs<TItem>> SelectionChanged { get; set; }

        [JSInvokable]
        public async Task JSItemClick(int itemIndex, JsonElement itemData) =>
            await ItemClick.InvokeAsync(new DXGalleryDataEventArgs<TItem>(DXClientWidget, itemIndex, itemData));

        [JSInvokable]
        public async Task JSItemContextMenu(int itemIndex, JsonElement itemData) =>
            await ItemContextMenu.InvokeAsync(new DXGalleryDataEventArgs<TItem>(DXClientWidget, itemIndex, itemData));

        [JSInvokable]
        public async Task JSItemHold(int itemIndex, JsonElement itemData) =>
            await ItemHold.InvokeAsync(new DXGalleryDataEventArgs<TItem>(DXClientWidget, itemIndex, itemData));

        [JSInvokable]
        public async Task JSItemRendered(int itemIndex, JsonElement itemData) =>
            await ItemRendered.InvokeAsync(new DXGalleryDataEventArgs<TItem>(DXClientWidget, itemIndex, itemData));

        [JSInvokable]
        public async Task JSOptionChanged(object value, object previousValue, string name, string fullName) =>
            await OptionChanged.InvokeAsync(new DXGalleryOptionChangedEventArgs<TItem>(DXClientWidget, value, previousValue, name, fullName));

        //[JSInvokable]
        //public Task JSSelectionChanged(JsonElement[] removedItems, JsonElement[] addedItems)
        //{

        //    var r = removedItems;
        //    var a = addedItems;
        //    //await SelectionChanged.InvokeAsync(new DXGallerySelectionChangedEventArgs<TItem>(DXClientWidget, removedItems, addedItems));
        //}

    }

    public class DXGalleryDataEventArgs<T> : DXWidgetEventArgs
    {
        public DXGalleryDataEventArgs(IJSObjectReference sender, int itemIndex, JsonElement itemData)
            : base(sender)
        {
            ItemIndex = itemIndex;
            ItemData = JsonSerializer.Deserialize<T>(itemData.GetRawText());
        }
        public int ItemIndex { get; }
        public T? ItemData { get; }
    }
    public class DXGalleryOptionChangedEventArgs<T> : DXWidgetEventArgs
    {
        public DXGalleryOptionChangedEventArgs(IJSObjectReference sender, object value, object previousValue, string name, string fullName)
                : base(sender)
        {
            Value = value;// JsonSerializer.Deserialize<T>(value.GetRawText());
            PreviousValue = previousValue; // JsonSerializer.Deserialize<T>(previousValue.GetRawText());
            Name = name;
            FullName = fullName;
        }
        public object Value { get; }
        public object PreviousValue { get; }
        public string Name { get; }
        public string FullName { get; }
    }

    public class DXGallerySelectionChangedEventArgs<T> : DXWidgetEventArgs
    {
        public DXGallerySelectionChangedEventArgs(IJSObjectReference sender, T[] removedValues, T[] addedValues)
                : base(sender)
        {
            RemovedValues = removedValues;// JsonSerializer.Deserialize<T[]>(removedValues.GetRawText());
            AddedValues = addedValues; // JsonSerializer.Deserialize<T[]>(addedValues.GetRawText());
            //RemovedValues = removedValues.Select(x => JsonSerializer.Deserialize<T>(x.GetRawText())).ToArray();
        }
        public T[]? RemovedValues { get; }
        public T[]? AddedValues { get; }
    }


}
