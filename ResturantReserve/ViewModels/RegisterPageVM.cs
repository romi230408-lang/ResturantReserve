using ResturantReserve.Models;
using System.Windows.Input;

namespace ResturantReserve.ViewModels
{
    public partial class RegisterPageVM: ObservableObject
    {

        private readonly User user = new();
        public ICommand RegisterCommand { get; }
        public bool CanRegister()
        {
            return !string.IsNullOrWhiteSpace(user.Name)
                && !string.IsNullOrWhiteSpace(user.Email)
                && !string.IsNullOrEmpty(user.Password);
        }

        private async void Register()
        {
            user.Register();
            await Shell.Current.GoToAsync("///LoginPage");
        }

        public string Name
        {
            get => user.Name;
            set
            {
                if (user.Name != value)
                {
                    user.Name = value;
                    OnPropertyChanged();
                    (RegisterCommand as Command)?.ChangeCanExecute();
                }
            }
        }

        public string Email
        {
            get => user.Email;
            set
            {
                if (user.Email != value)
                {
                    user.Email = value;
                    OnPropertyChanged();
                    (RegisterCommand as Command)?.ChangeCanExecute();
                }
            }
        }

        public string Password
        {
            get => user.Password;
            set
            {
                if (user.Password != value)
                {
                    user.Password = value;
                    OnPropertyChanged();
                    (RegisterCommand as Command)?.ChangeCanExecute();
                }
            }
        }

        public RegisterPageVM()
        {
            RegisterCommand = new Command(Register, CanRegister);
        }
    }
}
