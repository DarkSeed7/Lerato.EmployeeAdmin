using Lerato.EmployeeAdmin.Constants;
using Lerato.EmployeeAdmin.Extensions;
using System;
using Xamarin.Forms;

namespace Lerato.EmployeeAdmin.ViewModels
{
    public sealed class LandingPageViewModel : BaseViewModel
    {

        #region Properties
        public INavigation NavigationHandler { get; set; }
        public string WelcomeMessage { get; set; }
        #endregion

        #region ctor
        public LandingPageViewModel(INavigation navigationHandler)
        {
            NavigationHandler = navigationHandler;

            InitialiseFields();
        }
        #endregion

        #region Methods

        private void InitialiseFields()
        {
            var now = DateTime.Now;

            if (now.Hour >= 5 && now.Hour < 12)
            {
                WelcomeMessage = StringConstants.Morning.ReplaceStringWithEnter();
            }
            else if (now.Hour >= 12 && now.Hour < 16)
            {
                WelcomeMessage = StringConstants.Afternoon.ReplaceStringWithEnter();
            }
            else
            {
                WelcomeMessage = StringConstants.Evening.ReplaceStringWithEnter();
            }
        }
        public override void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
