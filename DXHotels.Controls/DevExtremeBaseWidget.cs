using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DxHotels.Controls
{
    public class DXWidgetEventArgs
    {
        public DXWidgetEventArgs(IJSObjectReference sender) => Sender = sender;
        public IJSObjectReference Sender { get; } = default!;
    }

    public abstract class DevExtremeBaseWidget : ComponentBase, IAsyncDisposable
    {
        [Inject] protected IJSRuntime JS { get; set; } = default!;

        protected readonly Lazy<Task<IJSObjectReference>> moduleTask = default!;
        protected readonly DotNetObjectReference<DevExtremeBaseWidget> dotNetObjectReference;

        protected bool ResourcesLoaded { get; set; }
        protected bool ClientInitializationInProgress { get; set; }

        protected ElementReference DXWidget { get; set; } = default!;
        protected IJSObjectReference DXClientWidget { get; set; } = default!;
        protected abstract Dictionary<string, object> options { get; set; }
        protected abstract string ModuleName { get; }
        protected abstract Task<IJSObjectReference> InitializeDXControl();
        protected virtual string JSSetOptionName => "setOption";
        protected virtual string JSSetOptionsName => "setOptions";

        [Parameter] public virtual EventCallback<DXWidgetEventArgs> ContentReady { get; set; }
        [Parameter] public virtual EventCallback<DXWidgetEventArgs> Disposing { get; set; }
        [Parameter] public virtual EventCallback<DXWidgetEventArgs> Initialized { get; set; }

        [JSInvokable]
        public async virtual Task JSContentReady() =>
            await ContentReady.InvokeAsync(new DXWidgetEventArgs(DXClientWidget));

        [JSInvokable]
        public async virtual Task JSDisposing() =>
            await Disposing.InvokeAsync(new DXWidgetEventArgs(DXClientWidget));

        [JSInvokable]
        public async virtual void JSInitialized() =>
            await Initialized.InvokeAsync(new DXWidgetEventArgs(DXClientWidget));


        public DevExtremeBaseWidget()
        {
            moduleTask = new(() => JS.InvokeAsync<IJSObjectReference>("import", ModuleName).AsTask());
            dotNetObjectReference = DotNetObjectReference.Create(this);
        }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (ResourcesLoaded && DXClientWidget == null && !ClientInitializationInProgress)
            {
                ClientInitializationInProgress = true;
                DXClientWidget = await InitializeDXControl();
                ClientInitializationInProgress = false;
            }
        }

        protected async virtual Task SetWidgetOption<T>(string option, T value)
        {
            if (DXClientWidget != null)
            {
                var module = await moduleTask.Value;
                await module.InvokeVoidAsync(JSSetOptionName, DXClientWidget, option, value);
            }
        }
        public async virtual Task UpdateWidget()
        {
            if (DXClientWidget != null)
            {
                var module = await moduleTask.Value;
                await module.InvokeVoidAsync(JSSetOptionsName, DXClientWidget, options);
            }
        }

        protected virtual void ChangeProperty<T>(string name, T value, bool skipSet = false)
        {
            if (EqualityComparer<T>.Default.Equals((T)options[name], value)) return;
            options[name] = value!;
            if (!skipSet)
                InvokeAsync(async () => await SetWidgetOption(name, value));
        }

        public async virtual ValueTask DisposeAsync()
        {

            if (DXClientWidget != null)
                await DXClientWidget.DisposeAsync();

            if (dotNetObjectReference != null)
                dotNetObjectReference.Dispose();

            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.DisposeAsync();
            }
        }
    }
}
