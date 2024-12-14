using System.ComponentModel;
using System.Diagnostics;

namespace EmployeeUI.Models
{
    public class Employee : INotifyPropertyChanged
    {
        public required int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required decimal Salary { get; set; }
        public required string JobTitleName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        private bool isEditing;
        public bool IsEditing
        {
            get => isEditing;
            set
            {
                if (isEditing != value)
                {
                    isEditing = value;
                    OnPropertyChanged(nameof(IsEditing));
                    OnPropertyChanged(nameof(IsNotEditing));
                }
            }
        }

        public bool IsNotEditing => !IsEditing;

        private bool isDetailsVisible;
        public bool IsDetailsVisible
        {
            get => isDetailsVisible;
            set
            {
                if (isDetailsVisible != value)
                {
                    isDetailsVisible = value;
                    OnPropertyChanged(nameof(IsDetailsVisible));
                }
            }
        }

        private string editingFirstName;
        public string EditingFirstName
        {
            get => editingFirstName ?? FirstName;
            set
            {
                if (editingFirstName != value)
                {
                    editingFirstName = value;
                    OnPropertyChanged(nameof(EditingFirstName));
                }
            }
        }

        private string editingLastName;
        public string EditingLastName
        {
            get => editingLastName ?? LastName;
            set
            {
                if (editingLastName != value)
                {
                    editingLastName = value;
                    OnPropertyChanged(nameof(EditingLastName));
                }
            }
        }

        private decimal editingSalary;

        public decimal EditingSalary
        {
            get => editingSalary == 0 ? Salary : editingSalary;
            set
            {
                if (editingSalary != value)
                {
                    editingSalary = value;
                    OnPropertyChanged(nameof(EditingSalary));
                }
            }
        }


        private string editingJobTitleName;
        public string EditingJobTitleName
        {
            get => editingJobTitleName ?? JobTitleName;
            set
            {
                if (editingJobTitleName != value)
                {
                    editingJobTitleName = value;
                    OnPropertyChanged(nameof(EditingJobTitleName));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void CancelEdit()
        {
            EditingFirstName = FirstName;
            EditingLastName = LastName;
            EditingSalary = Salary;
            EditingJobTitleName = JobTitleName;
            IsEditing = false;
        }

        public void SaveEdit()
        {
            FirstName = EditingFirstName;
            LastName = EditingLastName;
            Salary = EditingSalary; // TODO: An issue occurs if the first number is edited
            JobTitleName = EditingJobTitleName;
            IsEditing = false;

            OnPropertyChanged(nameof(FirstName));
            OnPropertyChanged(nameof(LastName));
            OnPropertyChanged(nameof(Salary));
            OnPropertyChanged(nameof(JobTitleName));
        }
    }
}

