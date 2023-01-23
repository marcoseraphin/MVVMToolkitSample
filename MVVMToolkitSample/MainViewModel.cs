using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MVVMToolkitSample
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(FullName))]
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
        private string? firstName;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(FullName))]
        private string? lastName;

        public string? FullName => $"{FirstName} {LastName}";

        [RelayCommand(CanExecute = nameof(CheckName))]
        public async Task Save()
        {
            await UserDialogs.Instance.AlertAsync("Pressed Save for " + this.FullName);
        }

        private bool CheckName()
        {
            return FirstName == "Marco";
        }

        // ctor
        public MainViewModel()
        {
            this.firstName = "Marco";
            this.lastName = "Seraphin";
        }
    }
}
