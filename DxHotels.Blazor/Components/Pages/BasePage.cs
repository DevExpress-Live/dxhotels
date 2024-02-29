using DxHotels.Blazor.Data.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Specialized;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Web;

namespace DxHotels.Blazor.Components.Pages
{
    public abstract class BasePage : ComponentBase
    {
        static readonly CultureInfo culture = new CultureInfo("en-US");

        public BasePage()
        {
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }

        protected abstract string Name { get; }
        protected SearchState State { get; set; }

        [Inject] protected NavigationManager NavigationManager { get; set; }
        [Inject] protected HotelBookingContext DataContext { get; set; }

        protected override void OnInitialized()
        {
            State = new SearchState(Name, NavigationManager.QueryString(), DataContext);
            if(!State.ValidState)
                NavigationManager.NavigateTo("/");
        }
    }

    public static class NavigationManagerExtensions
    {
        public static NameValueCollection QueryString(this NavigationManager nav)
        {
            var uri = nav.ToAbsoluteUri(nav.Uri);
            return HttpUtility.ParseQueryString(uri.Query);
        }
        public static string QueryString(this NavigationManager navigationManager, string key)
        {
            return navigationManager.QueryString()[key]!;
        }
    }
}
