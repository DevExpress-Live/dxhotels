using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXHotels.Controls
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
        protected abstract Dictionary<string, object> options { get; }
        protected abstract string ModuleName { get; }
        protected abstract Task<IJSObjectReference> InitializeDXControl();
        protected virtual string JSSetOptionName => "setOption";
        protected virtual string JSSetOptionsName => "setOptions";

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

        protected virtual void ChangeProperty<T>(string name, T value)
        {
            if (EqualityComparer<T>.Default.Equals((T)options[name], value)) return;
            options[name] = value!;
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
