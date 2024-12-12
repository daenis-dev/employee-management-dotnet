namespace EmployeeUI
{
    public partial class MainPage : ContentPage
    {
        private readonly EmployeeService _employeeService;

        public MainPage()
        {
            InitializeComponent();
            _employeeService = new EmployeeService();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadEmployeesAsync();
        }

        private async Task LoadEmployeesAsync()
        {
            var employees = await _employeeService.GetEmployeesAsync();
            EmployeeCollectionView.ItemsSource = employees;
        }
    }

}