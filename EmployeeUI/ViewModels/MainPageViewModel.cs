using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using EmployeeUI.Models;
using EmployeeUI.Commands;
using System.ComponentModel;
namespace EmployeeUI.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Employee _selectedEmployee;
        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                if (_selectedEmployee != value)
                {
                    _selectedEmployee = value;
                    OnPropertyChanged(nameof(SelectedEmployee));
                }
            }
        }

        private readonly EmployeeService _employeeService;

        public ObservableCollection<Employee> Employees { get; set; }
        public ICommand ToggleDetailsCommand { get; }
        public ICommand StartEditCommand { get; }
        public ICommand SaveEmployeeCommand { get; }
        public ICommand CancelEditCommand { get; }
        public ICommand DeleteEmployeeCommand { get; }

        public MainPageViewModel(EmployeeService employeeService)
        {
            _employeeService = employeeService;
            Employees = new ObservableCollection<Employee>();

            ToggleDetailsCommand = new RelayCommand<Employee>(ToggleDetails);
            StartEditCommand = new RelayCommand<Employee>(StartEdit);

            SaveEmployeeCommand = new RelayCommand<Employee>(async (employee) => await SaveEmployee(employee));
            CancelEditCommand = new RelayCommand<Employee>(CancelEdit);
            DeleteEmployeeCommand = new RelayCommand<Employee>(async (employee) => await DeleteEmployee(employee));
        }

        public async Task LoadEmployeesAsync()
        {
            var employees = await _employeeService.GetEmployeesAsync();

            Employees.Clear();
            foreach (var employee in employees)
            {
                Employees.Add(employee);
            }
        }

        private void ToggleDetails(Employee employee)
        {
            if (employee != null)
            {
                employee.IsDetailsVisible = !employee.IsDetailsVisible;
            }
        }

        private void StartEdit(Employee employee)
        {
            if (employee != null)
            {
                SelectedEmployee = employee;
                employee.IsEditing = true;
            }
        }

        private async Task SaveEmployee(Employee employee)
        {
            if (employee != null)
            {
                try
                {
                    employee.SaveEdit();

                    await _employeeService.UpdateEmployeeAsync(employee);

                    employee.IsEditing = false;

                    SelectedEmployee = null;
                }
                catch (Exception ex)
                {
                }
            }
        }


        private void CancelEdit(Employee employee)
        {
            if (employee != null)
            {
                employee.CancelEdit(); 
                employee.IsEditing = false;
                SelectedEmployee = null;
            }
        }

        private async Task DeleteEmployee(Employee employee)
        {
            if (employee != null)
            {
                try
                {
                    await _employeeService.DeleteEmployeeAsync(employee.Id);
                    Employees.Remove(employee);
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}
