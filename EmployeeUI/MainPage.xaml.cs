using EmployeeUI.ViewModels;

namespace EmployeeUI
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();
            var employeeService = new EmployeeService();
            _viewModel = new MainPageViewModel(employeeService);
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadEmployeesAsync();
        }
    }

}