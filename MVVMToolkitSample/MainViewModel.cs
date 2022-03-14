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
        [AlsoNotifyChangeFor(nameof(FullName))]
        private string? firstName;

        [ObservableProperty]
        [AlsoNotifyChangeFor(nameof(FullName))]
        private string? lastName;

        public string? FullName => $"{FirstName} {LastName}";

        [ICommand]
        public async Task Save()
        {
            await UserDialogs.Instance.AlertAsync("Pressed Save for " + this.FullName);
        }

        public MainViewModel()
        {
            this.firstName = "Marco";
            this.lastName = "Seraphin";
        }
    }
}
