let valueChanging = false;
export async function initializeRangeSlider(dotNetHelper, element, options) {

    var o = options || {};
    o.tooltip = {
        enabled: false,
        format(value) {
            return `${value}`;
        },
        showMode: 'always',
        position: 'bottom'
    };
    //o.valueChangeMode = 'onHandleRelease';
    //Event initialization
    o.onContentReady = async (e) => await dotNetHelper.invokeMethodAsync('JSContentReady');
    o.onDisposing = async (e) => await dotNetHelper.invokeMethodAsync('JSDisposing');
    o.onInitialized = async (e) => await dotNetHelper.invokeMethodAsync('JSInitialized');
    o.onValueChanged = async (e) => {
        if (valueChanging) return;
        valueChanging = true;
        try {
            await dotNetHelper.invokeMethodAsync('JSValueChanged', e.value, e.start, e.end, e.previousValue);
        }
        finally {
            valueChanging = false;
        }
    }
    //o.onOptionChanged = (e) => {
    //    try {
    //        dotNetHelper.invokeMethodAsync('JSOptionChanged', e.value, e.previousValue, e.name, e.fullName);
    //    } catch (error) {
    //        console.error(error);
    //    }
    //}
    var result = new DevExpress.ui.dxRangeSlider(element, o);
    return result;
}

export async function setRangeSliderValues(rangeSlider, start, end) {
    rangeSlider.option('value', Array(start, end));
    rangeSlider.option('start', start);
    rangeSlider.option('end', end);
}

export async function setRangeSliderOptions(rangeSlider, options) {
    rangeSlider.option(options);
};

export async function setRangeSliderOption(rangeSlider, optionName, optionValue) {
    rangeSlider.option(optionName, optionValue);
};