using Lerato.EmployeeAdmin.Facades;
using Lerato.EmployeeAdmin.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lerato.EmployeeAdmin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            InitializationFacade.InitializeApplication();

            MainPage = new NavigationPage(new LandingPage());
        }

    }
}
