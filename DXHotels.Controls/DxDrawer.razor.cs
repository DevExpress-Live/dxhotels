using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DXHotels.Controls
{    
    public enum DrawerExpandMode { Move, Shrink, Push };
    public partial class DxDrawer
    {
        const string jsFile = "./_content/DXHotels.Controls/DxDrawer.razor.js";        
        protected Lazy<Task<IJSObjectReference>> moduleTask;
        protected DotNetObjectReference<DxDrawer> dotNetObjectReference;

        protected ElementReference dxDrawer { get; set; }

        public DxDrawer()
        {
            dotNetObjectReference = DotNetObjectReference.Create(this);
            moduleTask = new(() => JsRuntime.InvokeAsync<IJSObjectReference>("import", jsFile).AsTask());
        }

        public async ValueTask DisposeAsync()
        {
            if (moduleTask != null && moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                if (!RenderStatic) 
                    await module.InvokeVoidAsync("disposeDrawerObserver");
                await module.DisposeAsync();
            }
        }

        protected void SetPropertyValue<T>(ref T member, T value, bool invokeStateChanged = false)
        {
            if (!EqualityComparer<T>.Default.Equals(member, value))
            {
                member = value;
                if (invokeStateChanged)
                    InvokeAsync(StateHasChanged);
            }
        }

        public bool IsFullExpand { get; set; }

        [Parameter] public bool RenderStatic { get; set; } = false;
        [Parameter] public int FullExpandWidth { get; set; } = 1200;
        [Parameter] public DrawerExpandMode Mode { get; set; } = DrawerExpandMode.Push;

        [Parameter] public string? LeftHamburgerSelector { get; set; }
        [Parameter] public string? RightHamburgerSelector { get; set; }

#pragma warning disable BL0007
        private bool _LeftPanelVisible;
        [Parameter]
        public bool LeftPanelVisible { get => _LeftPanelVisible; set => SetPropertyValue(ref _LeftPanelVisible, value, true); }
        [Parameter] public EventCallback<bool> LeftPanelVisibleChanged { get; set; }

        private bool _RightPanelVisible;
        [Parameter]
        public bool RightPanelVisible { get => _RightPanelVisible; set => SetPropertyValue(ref _RightPanelVisible, value, true); }
        [Parameter] public EventCallback<bool> RightPanelVisibleChanged { get; set; }
#pragma warning restore BL0007

        [Parameter] public string LeftPanelWidth { get; set; } = "200px";
        [Parameter] public bool LeftPanelFixed { get; set; } = false;
        [Parameter] public RenderFragment? LeftPanel { get; set; }
        [Parameter] public string CssClassLeftPanel { get; set; } = "";

        [Parameter] public string RightPanelWidth { get; set; } = "200px";
        [Parameter] public bool RightPanelFixed { get; set; } = false;
        [Parameter] public RenderFragment? RightPanel { get; set; }
        [Parameter] public string CssClassRightPanel { get; set; } = "";

        [Parameter] public string CssClass { get; set; } = "";
        [Parameter] public string CssClassContent { get; set; } = "";

        [Parameter] public RenderFragment? Content { get; set; }
        
        protected async override Task OnAfterRenderAsync(bool firstRender)
        {            
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                var module = await moduleTask.Value;                
                await module.InvokeVoidAsync("dxdrawerInitialize", dotNetObjectReference, dxDrawer,
                        LeftHamburgerSelector, RightHamburgerSelector, FullExpandWidth, LeftPanelFixed, RightPanelFixed);
            }
        }

        string AddCssClass(string classes, params string[] newClasses)
        {
            var result = new List<string>(classes.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries));
            result.AddRange(newClasses.Where(x => !string.IsNullOrEmpty(x) && !result.Contains(x)));
            return string.Join(" ", result.ToArray());
        }

        [JSInvokable]
        public Task JSDrawerAttributeChanged(string attributeName, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                var left = value.Contains("show-drawer-left");
                var right = value.Contains("show-drawer-right");

                if (left != _LeftPanelVisible)
                    _LeftPanelVisible = left;
                if (right != RightPanelVisible)
                    _RightPanelVisible = right;
            }
            return Task.CompletedTask;
        }

        static readonly Dictionary<DrawerExpandMode, string> modeClass = new Dictionary<DrawerExpandMode, string> {
            { DrawerExpandMode.Move, ""},
            { DrawerExpandMode.Shrink, "drawer-shrink-content"},
            { DrawerExpandMode.Push, "drawer-push-content"}
        };

        string LeftPanelClass { get => AddCssClass("drawer-left", CssClassLeftPanel); }
        string ContentClass { get => AddCssClass("drawer-content", CssClassContent); }
        string RightPanelClass { get => AddCssClass("drawer-right", CssClassRightPanel); }

        string ControlClass
        {
            get => AddCssClass("drawer-control", CssClass, modeClass[Mode],
                        LeftPanelVisible ? "show-drawer-left" : "",
                        RightPanelVisible ? "show-drawer-right" : "");
        }

        protected MarkupString InlineScript => new MarkupString(string.Format("dxdrawerInitialize(null, document.querySelector(':scope #dxdrawer'), '{0}', '{1}', {2}, {3}, {4});",
                    LeftHamburgerSelector, RightHamburgerSelector, FullExpandWidth,
                    $"{LeftPanelFixed}".ToLowerInvariant(),
                    $"{RightPanelFixed}".ToLowerInvariant()));
    }
}
