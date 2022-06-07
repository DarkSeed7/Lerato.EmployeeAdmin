using Lerato.ApplicationCore.Domain.Database;
using Lerato.DomainServices.Services;
using Lerato.EmployeeAdmin.Extensions;
using System.Collections.ObjectModel;
using Lerato.EmployeeAdmin.Helpers;
using Lerato.EmployeeAdmin.Models;
using System.Collections.Generic;
using Lerato.EmployeeAdmin.Views;
using System.Windows.Input;
using System.Threading;
using System.Linq;
using Xamarin.Forms;
using System;
using System.Threading.Tasks;

namespace Lerato.EmployeeAdmin.ViewModels
{
    public sealed class EmployeeListViewModel : BaseViewModel
    {
        #region propeties

        private EmployeeDatabaseService employeeDatabase;

        private IEnumerable<Employee> employees;

        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();


        private ObservableCollection<ListViewGrouping<string, Employee>> listViewItems;

        public ObservableCollection<ListViewGrouping<string, Employee>> ListViewItems
        {
            get => listViewItems;
            set
            {
                SetProperty(ref listViewItems, value);
            }
        }


        private string searchText;

        public string SearchText
        {
            get => searchText;
            set
            {
                SetProperty(ref searchText, value);
            }
        }

        private bool isAscendingSort;


        public INavigation NavigationHandler { get; set; }

        public ICommand NavigateToAddEmployeeCommand { get; set; }

        public ICommand SearchTextChangedCommand { get; set; }
        
        public ICommand SortCommand { get; set; }

        #endregion


        #region ctor
        public EmployeeListViewModel(INavigation navigationHandler)
        {
            NavigationHandler = navigationHandler;

            InitServices();

            InitProperties();

            InitCommands();
        }
        #endregion

        #region Methods

        private void InitServices()
        {
            employeeDatabase = DatabaseServiceHelper.Instance.GetDatabaseService();
        }

        private void InitProperties()
        {
            isAscendingSort = true;

            employees = employeeDatabase.GetEmployees();

            PopulateListViewItems(employees, isAscendingSort);
        }

        private void InitCommands()
        {
            NavigateToAddEmployeeCommand = new Command(NavigateToAddEmployeeCommandAsync);

            SearchTextChangedCommand = new Command(HandleSearchTextChanged);

            SortCommand = new Command(SortEmployees);
        }

        private void PopulateListViewItems(IEnumerable<Employee> employee, bool isAscendingOrder)
        {
             
            var sorted = from emp in employee

                         orderby emp.LastName

                         group emp by emp.LastName.GetFirstLetter().ToString().ToUpper() into employeeGroup

                         select new ListViewGrouping<string, Employee>(employeeGroup.Key, employeeGroup);

            if (!isAscendingOrder)
            {
                sorted = sorted.Reverse();
            }

            listViewItems = new ObservableCollection<ListViewGrouping<string, Employee>>(sorted);

            OnPropertyChanged(nameof(ListViewItems));
        }

        private async void NavigateToAddEmployeeCommandAsync(object obj)
        {
            await NavigationHandler.NavigateToModalResultAsync<AddEmployeePage>(HandleAdded);
        }

        private void HandleAdded(object arg1, ModalPoppingEventArgs arg2)
        {
            Application.Current.ModalPopping -= HandleAdded;

            InitProperties();
        }

        private void SortEmployees()
        {
            isAscendingSort = !isAscendingSort;

            PopulateListViewItems(employees, isAscendingSort);
        }

        private void HandleSearchTextChanged()
        {
            Interlocked.Exchange(ref cancellationTokenSource, new CancellationTokenSource()).Cancel();

            Task.Delay(TimeSpan.FromMilliseconds(200), this.cancellationTokenSource.Token)

                .ContinueWith (

                    delegate { PerformSearch(); },

                    CancellationToken.None,

                    TaskContinuationOptions.OnlyOnRanToCompletion,

                    TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void PerformSearch()
        {
            var text = searchText.ToLower();

            var filtered = employees.Where(x => x.LastName.ToLower().Contains(text));

            PopulateListViewItems(filtered, isAscendingSort);
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
