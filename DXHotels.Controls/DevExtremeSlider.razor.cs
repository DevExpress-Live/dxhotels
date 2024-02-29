using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DxHotels.Controls
{
    public partial class DevExtremeSlider : DevExtremeBaseWidget
    {
        public DevExtremeSlider() : base()
        {
        }
        protected override Dictionary<string, object> options { get; set; } = new Dictionary<string, object>
        {
            { "accessKey", null! },
            { "activeStateEnabled", true },
            { "disabled", false },
            { "elementAttr", null! },
            { "focusStateEnabled", true },
            { "height", "" },
            { "hint", "" },
            { "hoverStateEnabled", true },
            { "isDirty", false },
            { "isValid", true },
            { "keyStep", 1 },
            { "label",  "" }, // <-- sub-object
            { "max", 100 },
            { "min", 0 },
            { "name", "" },
            { "readOnly", false },
            { "rtlEnabled", false },
            { "showRange", true },
            { "step", 1 },
            { "tabIndex", 0 },
            { "tooltip",  "" },
            { "validationError", null! },
            { "validationErrors", new ValidationMessageMode[] { } },
            { "validationMessageMode", ValidationMessageMode.auto },
            { "validationMessagePosition", Position.bottom },
            { "validationStatus", ValidationStatus.valid },
            { "value", 50 },
            { "visible", true },
            { "width", "" }
        };

        protected override string ModuleName => "./_content/DXHotels.Controls/DevExtremeSlider.razor.js";
        protected override string JSSetOptionName => "setSliderOption";
        protected override string JSSetOptionsName => "setSliderOptions";

        protected async override Task<IJSObjectReference> InitializeDXControl()
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<IJSObjectReference>("initializeSlider", dotNetObjectReference, DXWidget, options);
        }

        protected override async Task OnParametersSetAsync()
        {
            if (DXClientWidget != null)
            {
                var module = await moduleTask.Value;
                await module.InvokeVoidAsync(JSSetOptionName, DXClientWidget, "value", Value);
            }
        }
#pragma warning disable BL0007

        //[Parameter] public bool AccessKey { get => (bool)options["accessKey"]; set => ChangeProperty("accessKey", value); }
        [Parameter] public bool ActiveStateEnabled { get => (bool)options["activeStateEnabled"]; set => ChangeProperty("activeStateEnabled", value); }
        [Parameter] public bool Disabled { get => (bool)options["disabled"]; set => ChangeProperty("disabled", value); }
        //[Parameter] public bool ElementAttr { get => (bool)options["elementAttr"]; set => ChangeProperty("elementAttr", value); }
        [Parameter] public bool FocusStateEnabled { get => (bool)options["focusStateEnabled"]; set => ChangeProperty("focusStateEnabled", value); }
        [Parameter] public string Height { get => (string)options["height"]; set => ChangeProperty("height", value); }
        [Parameter] public string Hint { get => (string)options["hint"]; set => ChangeProperty("hint", value); }
        [Parameter] public bool HoverStateEnabled { get => (bool)options["hoverStateEnabled"]; set => ChangeProperty("hoverStateEnabled", value); }
        [Parameter] public bool IsDirty { get => (bool)options["isDirty"]; set => ChangeProperty("isDirty", value); }
        [Parameter] public bool IsValid { get => (bool)options["isValid"]; set => ChangeProperty("isValid", value); }
        [Parameter] public int KeyStep { get => (int)options["keyStep"]; set => ChangeProperty("keyStep", value); }
        [Parameter] public string Label { get => (string)options["label"]; set => ChangeProperty("label", value); }
        [Parameter] public int Max { get => (int)options["max"]; set => ChangeProperty("max", value); }
        [Parameter] public int Min { get => (int)options["min"]; set => ChangeProperty("min", value); }
        [Parameter] public string Name { get => (string)options["name"]; set => ChangeProperty("name", value); }
        [Parameter] public bool ReadOnly { get => (bool)options["readOnly"]; set => ChangeProperty("readOnly", value); }
        [Parameter] public bool RtlEnabled { get => (bool)options["rtlEnabled"]; set => ChangeProperty("rtlEnabled", value); }
        [Parameter] public bool ShowRange { get => (bool)options["showRange"]; set => ChangeProperty("showRange", value); }
        [Parameter] public int Step { get => (int)options["step"]; set => ChangeProperty("step", value); }
        [Parameter] public int TabIndex { get => (int)options["tabIndex"]; set => ChangeProperty("tabIndex", value); }
        [Parameter] public string Tooltip { get => (string)options["tooltip"]; set => ChangeProperty("tooltip", value); }
        [Parameter] public ValidationError ValidationError { get => (ValidationError)options["validationError"]; set => ChangeProperty("validationError", value); }
        [Parameter] public ValidationError[] ValidationErrors { get => (ValidationError[])options["validationErrors"]; set => ChangeProperty("validationErrors", value); }
        [Parameter] public ValidationMessageMode ValidationMessageMode { get => (ValidationMessageMode)options["validationMessageMode"]; set => ChangeProperty("validationMessageMode", value); }
        [Parameter] public Position ValidationMessagePosition { get => (Position)options["validationMessagePosition"]; set => ChangeProperty("validationMessagePosition", value); }
        [Parameter] public ValidationStatus ValidationStatus { get => (ValidationStatus)options["validationStatus"]; set => ChangeProperty("validationStatus", value); }
        [Parameter] public int Value { get => (int)options["value"]; set => ChangeProperty("value", value, valueChanging); }
        [Parameter] public EventCallback<int> ValueChanged { get; set; }
        //this will loop in the ui when changed
        //[Parameter] public SliderValueChangeMode ValueChangeMode { get => (SliderValueChangeMode)options["valueChangeMode"]; set => ChangeProperty("valueChangeMode", value); }
        [Parameter] public bool Visible { get => (bool)options["visible"]; set => ChangeProperty("visible", value); }
        [Parameter] public string Width { get => (string)options["width"]; set => ChangeProperty("width", value); }

#pragma warning restore BL0007

        [Parameter] public EventCallback<DXSliderValueChangedEventArgs> OnValueChanged { get; set; }

        private bool valueChanging = false;
        [JSInvokable]
        public async Task JSValueChanged(int value, int previousValue)
        {
            if (valueChanging) return;
            valueChanging = true;
            if (value != previousValue)
                await ValueChanged.InvokeAsync(value);
            await OnValueChanged.InvokeAsync(new DXSliderValueChangedEventArgs(DXClientWidget, value, previousValue));
            valueChanging = false;
        }
    }

    public class DXSliderValueChangedEventArgs : DXWidgetEventArgs
    {
        public DXSliderValueChangedEventArgs(IJSObjectReference widget, int value, int previousValue) : base(widget)
        {
            Value = value;
            PreviousValue = previousValue;
        }
        public int Value { get; }
        public int PreviousValue { get; }
    }

    public class ValidationError
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = default!;

        [JsonPropertyName("message")]
        public string Message { get; set; } = default!;
    }
    public enum ValidationMessageMode { always, auto };
    public enum ValidationStatus { valid, invalid, pending };
    public enum Position { bottom, left, right, top };
}
