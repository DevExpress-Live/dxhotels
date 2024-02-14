
export async function initializeGallery(dotNetHelper, element, datasource, options) {
   
    var o = options || {};    
    o.dataSource = datasource;
    if (Array.isArray(datasource) && datasource.length > 0 && datasource[0].hasOwnProperty('template')) {
        o.itemTemplate = (item) => item.template;
    }

    //Event initialization
    o.onContentReady = (e) => dotNetHelper.invokeMethodAsync('JSContentReady');
    o.onDisposing = (e) => dotNetHelper.invokeMethodAsync('JSDisposing');
    o.onInitialized = (e) => dotNetHelper.invokeMethodAsync('JSInitialized');
    o.onItemClick = (e) => dotNetHelper.invokeMethodAsync('JSItemClick', e.itemIndex, e.itemData);
    o.onItemContextMenu = (e) => dotNetHelper.invokeMethodAsync('JSItemContextMenu', e.itemIndex, e.itemData);
    o.onItemHold = (e) => dotNetHelper.invokeMethodAsync('JSItemHold ', e.itemIndex, e.itemData);
    o.onItemRendered = (e) => dotNetHelper.invokeMethodAsync('JSItemRendered', e.itemIndex, e.itemData);
    //o.onOptionChanged = (e) => {
    //    try {
    //        dotNetHelper.invokeMethodAsync('JSOptionChanged', e.value, e.previousValue, e.name, e.fullName);
    //    } catch (error) {
    //        console.error(error);
    //    }
    //}

    //o.onSelectionChanged = (e) => {
    //    try {
    //        dotNetHelper.invokeMethodAsync('JSSelectionChanged', e.removedItems, a.addedItems);
    //    } catch (error) {
    //        console.error(error);
    //    }
    //}

    var result = new DevExpress.ui.dxGallery(element, o);
    return result;
}

export async function setGalleryOptions(gallery, options) {
    gallery.option(options);
};

export async function setGalleryOption(gallery, optionName, optionValue) {    
    gallery.option(optionName, optionValue);
};

export async function changeGalleryDataSource(gallery, datasource) {
    gallery.option('dataSource', datasource);
}