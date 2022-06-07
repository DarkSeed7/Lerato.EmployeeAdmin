using Lerato.EmployeeAdmin.Views;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lerato.EmployeeAdmin.Extensions
{
    public static class NavigationExtentions
    {
        public static async Task<bool> NavigateToPageAsync<TPage>(this INavigation navigationHandler)
          where TPage : BasePage, new()
        {
            var page = new TPage();

            await navigationHandler.PushAsync(page);

            return true;
        }

        public static async Task<bool> NavigateToPageAsync<TPage>(this INavigation navigationHandler, object[] args)
            where TPage : BasePage, new()
        {
            var page = (TPage)Activator.CreateInstance(typeof(TPage), args);

            await navigationHandler.PushAsync(page);

            return true;
        }

        public static async Task<bool> NavigateToModalAsync<TPage>(this INavigation navigationHandler)
            where TPage : BasePage, new()
        {
            var page = new TPage();

            await navigationHandler.PushModalAsync(page);

            return true;
        }

        public static async Task<bool> NavigateToModalAsync<TPage>(this INavigation navigationHandler, object[] args)
            where TPage : BasePage, new()
        {
            var page = (TPage)Activator.CreateInstance(typeof(TPage), args);

            await navigationHandler.PushModalAsync(page);

            return true;
        }

        public static async Task<bool> NavigateToModalResultAsync<T>(this INavigation navigationHandler, Action<object, ModalPoppingEventArgs> handleMethod)
            where T : Page, new()
        {
            await navigationHandler.PushModalAsync(new T());

            Application.Current.ModalPopping += handleMethod.Invoke;

            return true;
        }

        public static async Task<bool> NavigateToModalResultAsync<T>(this INavigation navigationHandler, Action<object, ModalPoppingEventArgs> handleMethod, object[] args)
           where T : Page, new()
        {
            var page = (T)Activator.CreateInstance(typeof(T), args);

            await navigationHandler.PushModalAsync(page);

            Application.Current.ModalPopping += handleMethod.Invoke;

            return true;
        }

        public static async Task<bool> NavigateToPageResultAsync<T>(this INavigation navigationHandler, Action<object, EventArgs> handleMethod)
          where T : Page, new()
        {
            var page = (T)Activator.CreateInstance(typeof(T));

            await navigationHandler.PushAsync(page);

            page.Disappearing += handleMethod.Invoke;

            return true;
        }

        public static async Task<bool> NavigateToPageResultAsync<T>(this INavigation navigationHandler, Action<object, EventArgs> handleMethod, object[] args)
           where T : Page, new()
        {
            var page = (T)Activator.CreateInstance(typeof(T), args);

            await navigationHandler.PushAsync(page);

            page.Disappearing += handleMethod.Invoke;

            return true;
        }

        public static Page GetCurrentNavigationPage(this INavigation navigationHandler)
        {
            return navigationHandler
                .NavigationStack
                .LastOrDefault();
        }

        public static Page GetCurrentModalPage(this INavigation navigationHandler)
        {
            return navigationHandler
                .ModalStack
                .LastOrDefault();
        }
    }
}
