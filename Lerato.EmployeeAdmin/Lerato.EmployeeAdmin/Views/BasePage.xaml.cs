using System;
using System.Collections.Generic;
using System.Windows.Input;
using Lerato.CompositionRoot.Extensions;
using Lerato.EmployeeAdmin.Enums;
using Lerato.EmployeeAdmin.Extensions;
using Lerato.EmployeeAdmin.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Lerato.EmployeeAdmin.Views
{
    public partial class BasePage : ContentPage
    {

        public IList<View> ContentContainer => ContentGrid.Children;

        public Sections ActiveSection => BasePageHelper.Instance.GetActiveActiveSection();

        public ICommand NavigateToClientListCommand { get; set; }

        public BasePage()
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.iOS)
            {
                On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            }
        }

        private async void EmployeeTapped_Tapped(object sender, EventArgs e)
        {
            BasePageHelper.Instance.SetActiveSection(Sections.Employees);

            await this.Navigation.NavigateToPageAsync<EmployeeListPage>();
        }

        protected override bool OnBackButtonPressed()
        {
            var disposable = this.BindingContext as IDisposable;

            if (disposable.IsNotNull())
            {
                disposable.Dispose();
            }

            return true;
        }
    }
}