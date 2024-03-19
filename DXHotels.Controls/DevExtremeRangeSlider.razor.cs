
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXHotels.Controls
{
    public partial class DevExtremeRangeSlider : DevExtremeBaseWidget
    {
        public DevExtremeRangeSlider() : base()
        {

        }
        protected override Dictionary<string, object> options { get; set; } = new Dictionary<string, object> {
            { "accessKey", null!},
            { "activeStateEnabled", true },
            { "disabled", false },
            { "elementAttr", null! },
            { "end", 60 },
            { "endName", "" },
            { "focusStateEnabled", true },
            { "height", "" },
            { "hint", "" },
            { "hoverStateEnabled", true },
            { "isDirty", false },
            { "isValid", true },
            { "keyStep", 1 },
            { "label",  "" }, //<--sub-object
            { "max", 100 },
            { "min", 0 },

            { "readOnly", false },
            { "rtlEnabled", false },
            { "showRange", true },
            { "start", 40 },
            { "startName", "" },
            { "step", 1 },
            { "tabIndex", 0 },
            { "tooltip",  "" }, //<--sub-object
            { "validationError", null! },
            { "validationErrors", new ValidationMessageMode[] { } },
            { "validationMessageMode", ValidationMessageMode.auto },
            { "validationMessagePosition", Position.bottom },
            { "validationStatus", ValidationStatus.valid },
            //{ "value", new int[] {0, 0 }"40" },
            //{ "valueChangeMode", "onHandleMove" },
            { "visible", true },
            { "width", "" }
        };

        protected override string ModuleName { get => "./_content/DXHotels.Controls/DevExtremeRangeSlider.razor.js"; }
        protected override string JSSetOptionName => "setRangeSliderOption";
        protected override string JSSetOptionsName => "setRangeSliderOptions";

        protected async override Task<IJSObjectReference> InitializeDXControl()
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<IJSObjectReference>("initializeRangeSlider", dotNetObjectReference, DXWidget, options);
        }

        protected override async Task OnParametersSetAsync()
        {
            if (DXClientWidget != null)
            {
                var module = await moduleTask.Value;
                await module.InvokeVoidAsync("setRangeSliderValues", DXClientWidget, Start, End);
            }
        }

#pragma warning disable BL0007

        //[Parameter] public bool AccessKey { get => (bool)options["accessKey"]; set => ChangeProperty("accessKey", value); }
        [Parameter] public bool ActiveStateEnabled { get => (bool)options["activeStateEnabled"]; set => ChangeProperty("activeStateEnabled", value); }
        [Parameter] public bool Disabled { get => (bool)options["disabled"]; set => ChangeProperty("disabled", value); }
        //[Parameter] public bool ElementAttr { get => (bool)options["elementAttr"]; set => ChangeProperty("elementAttr", value); }
        [Parameter] public int End { get => (int)options["end"]; set => ChangeProperty("end", value, valueChanging); }
        [Parameter] public EventCallback<int> EndChanged { get; set; }

        [Parameter] public string EndName { get => (string)options["endName"]; set => ChangeProperty("endName", value); }
        [Parameter] public bool FocusStateEnabled { get => (bool)options["focusStateEnabled"]; set => ChangeProperty("focusStateEnabled", value); }
        [Parameter] public string Height { get => (string)options["height"]; set => ChangeProperty("height", value); }
        [Parameter] public string Hint { get => (string)options["hint"]; set => ChangeProperty("hint", value); }
        [Parameter] public bool HoverStateEnabled { get => (bool)options["hoverStateEnabled"]; set => ChangeProperty("hoverStateEnabled", value); }
        [Parameter] public bool IsDirty { get => (bool)options["isDirty"]; set => ChangeProperty("isDirty", value); }
        [Parameter] public bool IsValid { get => (bool)options["isValid"]; set => ChangeProperty("isValid", value); }
        [Parameter] public int KeyStep { get => (int)options["keyStep"]; set => ChangeProperty("keyStep", value); }
        [Parameter] public int Max { get => (int)options["max"]; set => ChangeProperty("max", value); }
        [Parameter] public int Min { get => (int)options["min"]; set => ChangeProperty("min", value); }

        [Parameter] public bool ReadOnly { get => (bool)options["readOnly"]; set => ChangeProperty("readOnly", value); }
        [Parameter] public bool RtlEnabled { get => (bool)options["rtlEnabled"]; set => ChangeProperty("rtlEnabled", value); }
        [Parameter] public bool ShowRange { get => (bool)options["showRange"]; set => ChangeProperty("showRange", value); }
        [Parameter] public int Start { get => (int)options["start"]; set => ChangeProperty("start", value, valueChanging); }
        [Parameter] public EventCallback<int> StartChanged { get; set; }

        [Parameter] public string StartName { get => (string)options["startName"]; set => ChangeProperty("startName", value); }
        [Parameter] public int Step { get => (int)options["step"]; set => ChangeProperty("step", value); }
        [Parameter] public int TabIndex { get => (int)options["tabIndex"]; set => ChangeProperty("tabIndex", value); }
        [Parameter] public ValidationError ValidationError { get => (ValidationError)options["validationError"]; set => ChangeProperty("validationError", value); }
        [Parameter] public ValidationError[] ValidationErrors { get => (ValidationError[])options["validationErrors"]; set => ChangeProperty("validationErrors", value); }
        [Parameter] public ValidationMessageMode ValidationMessageMode { get => (ValidationMessageMode)options["validationMessageMode"]; set => ChangeProperty("validationMessageMode", value); }
        [Parameter] public Position ValidationMessagePosition { get => (Position)options["validationMessagePosition"]; set => ChangeProperty("validationMessagePosition", value); }
        [Parameter] public ValidationStatus ValidationStatus { get => (ValidationStatus)options["validationStatus"]; set => ChangeProperty("validationStatus", value); }
        //[Parameter] public int[] Value { get => (int[])options["value"]; set => ChangeProperty("value", value); }
        //[Parameter] public EventCallback<int> ValueChanged { get; set; }

        [Parameter] public bool Visible { get => (bool)options["visible"]; set => ChangeProperty("visible", value); }
        [Parameter] public string Width { get => (string)options["width"]; set => ChangeProperty("width", value); }

#pragma warning restore BL0007

        [Parameter] public EventCallback<DXRangeSliderValueChangedEventArgs> OnValueChanged { get; set; }

        private bool valueChanging = false;
        [JSInvokable]
        public async Task JSValueChanged(int[] value, int start, int end, int[] previousValue)
        {
            if (valueChanging) return;
            valueChanging = true;
            if (start != previousValue[0])
                await StartChanged.InvokeAsync(start);
            if (end != previousValue[1])
                await EndChanged.InvokeAsync(end);
            await OnValueChanged.InvokeAsync(new DXRangeSliderValueChangedEventArgs(DXClientWidget, value, start, end, previousValue));
            valueChanging = false;
        }

    }

    public class DXRangeSliderValueChangedEventArgs : DXWidgetEventArgs
    {
        public DXRangeSliderValueChangedEventArgs(IJSObjectReference widget, int[] value, int start, int end, int[] previousValue) : base(widget)
        {
            Value = value;
            Start = start;
            End = end;
            PreviousValue = previousValue;
        }
        public int[] Value { get; }
        public int Start { get; }
        public int End { get; }
        public int[] PreviousValue { get; }
    }

}
