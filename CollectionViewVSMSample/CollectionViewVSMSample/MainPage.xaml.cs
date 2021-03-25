using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace CollectionViewVSMSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        public ICommand LoadContentsCommand { get; set; }
        public ICommand NextCommand { get; set; }
        public ICommand PreviousCommand { get; set; }
        public ICommand DoubleTapCommand { get; set; }
        public EmployeeViewModel()
        {
            LoadContentsCommand = new Command(() => LoadContents());
            NextCommand = new Command(() => Next());
            PreviousCommand = new Command(() => Previous());
            DoubleTapCommand = new Command<Employee>((e) => DoubleTap(e));

            LoadContentsCommand.Execute(null);
        }
        ObservableCollection<Employee> _employees;
        public ObservableCollection<Employee> Employees
        {
            get => _employees;
            set { SetProperty(ref _employees, value); }
        }
        Employee _selectedEmployee;
        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set { SetProperty(ref _selectedEmployee, value); }
        }
        private void LoadContents()
        {
            try
            {
                Employees = new ObservableCollection<Employee>()
                {
                    new Employee(){Id = 1, Name = "Test 1"},
                    new Employee(){Id = 2, Name = "Test 2"},
                    new Employee(){Id = 3, Name = "Test 3"},
                    new Employee(){Id = 4, Name = "Test 4"},
                    new Employee(){Id = 5, Name = "Test 5"},
                    new Employee(){Id = 6, Name = "Test 6"},
                    new Employee(){Id = 7, Name = "Test 7"},
                    new Employee(){Id = 8, Name = "Test 8"},
                    new Employee(){Id = 9, Name = "Test 9"},
                    new Employee(){Id = 10, Name = "Test 10"},
                    new Employee(){Id = 11, Name = "Test 11"},
                    new Employee(){Id = 12, Name = "Test 12"},
                    new Employee(){Id = 13, Name = "Test 13"},
                    new Employee(){Id = 14, Name = "Test 14"},
                    new Employee(){Id = 15, Name = "Test 15"},
                    new Employee(){Id = 16, Name = "Test 16"},
                };
                SelectedEmployee = Employees.FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void Next() { Console.WriteLine($"Next Command"); }
        private void Previous() { Console.WriteLine($"Previous Command"); }
        private void DoubleTap(Employee e) { Console.WriteLine($"DoubleTap Command on Employee {e.Id}"); }
        #region events
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
