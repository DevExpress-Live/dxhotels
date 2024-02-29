export async function initializeSlider(dotNetHelper, element, options) {

    var o = options || {};

    o.tooltip = {
        enabled: false,
        format(value) {
            return `${value}%`;
        },
        showMode: 'always',
        position: 'bottom'
    };
    //o.valueChangeMode = 'onHandleRelease';
    //Event initialization
    o.onContentReady = async (e) => await dotNetHelper.invokeMethodAsync('JSContentReady');
    o.onDisposing = async (e) => await dotNetHelper.invokeMethodAsync('JSDisposing');
    o.onInitialized = async (e) => await dotNetHelper.invokeMethodAsync('JSInitialized');
    o.onValueChanged = async (e) => await dotNetHelper.invokeMethodAsync('JSValueChanged', e.value, e.previousValue);
    //o.onOptionChanged = (e) => {
    //    try {
    //        dotNetHelper.invokeMethodAsync('JSOptionChanged', e.value, e.previousValue, e.name, e.fullName);
    //    } catch (error) {
    //        console.error(error);
    //    }
    //}
    var result = new DevExpress.ui.dxSlider(element, o);
    return result;
}

export async function setSliderOptions(slider, options) {
    slider.option(options);
};

export async function setSliderOption(slider, optionName, optionValue) {
    slider.option(optionName, optionValue);
};
