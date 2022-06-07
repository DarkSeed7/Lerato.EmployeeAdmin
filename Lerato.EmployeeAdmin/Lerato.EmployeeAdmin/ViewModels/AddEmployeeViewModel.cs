using Lerato.ApplicationCore.Domain.Database;
using Lerato.CompositionRoot.Constants;
using Lerato.CompositionRoot.Extensions;
using Lerato.DomainServices.Services;
using Lerato.EmployeeAdmin.Extensions;
using Lerato.EmployeeAdmin.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lerato.EmployeeAdmin.ViewModels
{
    public sealed class AddEmployeeViewModel : BaseViewModel
    {
        #region Properties
        public Employee Employee { get; set; }

        private EmployeeDatabaseService employeeDatabase;

        private bool canSave;

        public bool CanSave
        {
            get => canSave;
            set
            {

                SetProperty(ref canSave, value);

            }
        }

        private string firstName;

        public string FirstName
        {
            get => firstName;
            set
            {
                SetProperty(ref firstName, value);
            }
        }

        private string lastName;

        public string LastName
        {
            get => lastName;
            set
            {
                SetProperty(ref lastName, value);
            }
        }

        private string title;
        public string Title
        {
            get => title;

            set
            {
                SetProperty(ref title, value);
            }
        }


        private DateTime? dateOfBirth;
        public DateTime? DateOfBirth
        {
            get => dateOfBirth;

            set
            {
                SetProperty(ref dateOfBirth, value);
            }
        }

        private string employeeNum;
        public string EmployeeNum
        {
            get => employeeNum;

            set
            {
                SetProperty(ref employeeNum, value);
            }
        }



        private ObservableCollection<string> titleList;

        public ObservableCollection<string> TitleList
        {
            get => titleList;

            set
            {
                SetProperty(ref titleList, value);
            }
        }

        private string gender;

        public string Gender
        {
            get => gender;
            set
            {
                SetProperty(ref gender, value);
            }
        }

        public ICommand CloseCommand { get; set; }

        public ICommand SaveCommand { get; set; }

        public ICommand SelectedGenderCommand { get; set; }

        public ICommand CanSaveOnUnFocusCommand { get; set; }

        public INavigation NavigationHandler { get; set; }

        #endregion


        #region ctor
        public AddEmployeeViewModel(INavigation navigationHandler, Employee employee)
        {
            NavigationHandler = navigationHandler;

            Employee = employee;

            InitialiseService();

            InitCommands();
        }

        #endregion


        #region Methods
        private void InitialiseService()
        {
            employeeDatabase = DatabaseServiceHelper.Instance.GetDatabaseService();
        }
        
        private void InitCommands()
        {
            CloseCommand = new Command(CloseEmployeeAsync);

            SelectedGenderCommand = new Command(OnGenderSelected);

            SaveCommand = new Command(SaveAsync);

            CanSaveOnUnFocusCommand = new Command(CanSaveOnUnFocus);
        }

        private async void SaveAsync(object obj)
        {
            if (!CanSave)
            {
                return;
            }

            try
            {
                var employee = new Employee()
                {
                   FirstName = FirstName,
                   LastName = LastName,
                   Title = Title,
                   Gender = Gender,
                   BirthDate = DateOfBirth.IsNotNull() ? DateOfBirth.Value.ToString(DateTimeConstants.DefaultShort) : null,
                   EmployeeNum = EmployeeNum
                };

                employeeDatabase.AddEmployee(employee);
            }

            catch (Exception ex)
            {
                throw ex;
            }

            await NavigationHandler
               .GetCurrentModalPage()
               .DisplayAlert("Response", "Employee Saved Successfully", "OK");

            await NavigationHandler.PopModalAsync();

        }

        private void HandleAdded(object arg1, ModalPoppingEventArgs arg2)
        {
            Application.Current.ModalPopping -= HandleAdded;
        }

        private async void CloseEmployeeAsync(object obj)
        {
            await NavigationHandler.PopModalAsync();
        }

        internal ObservableCollection<string> GetTitles()
        {
            if (string.IsNullOrEmpty(Gender) || Gender.Equals("Male"))
            {
                return new ObservableCollection<string> { "Mr", "Dr", "Prof" };
            }

            return new ObservableCollection<string> { "Ms", "Miss", "Mrs", "Dr", "Prof" };
        }


        private void CanSaveOnUnFocus(object obj)
        {
            CanSave = !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName);
        }

        private void OnGenderSelected(object obj)
        {
            TitleList = GetTitles();
        }


        public override void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
