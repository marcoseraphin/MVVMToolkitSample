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
        public async Task Save(string saveName)
        {
            await UserDialogs.Instance.AlertAsync("Pressed Save for " + saveName);
        }

        private bool CheckName(string saveName)
        {
            if (saveName != null)
            {
                return saveName == "Peter Jackson";
            }

            return false;
        }

        // ctor
        public MainViewModel()
        {
            this.firstName = "Peter";
            this.lastName = "Jackson";
        }
    }
}
