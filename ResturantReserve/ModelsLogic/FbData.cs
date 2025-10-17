using ResturantReserve.Models;
using ResturantReserve.Views;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Plugin.CloudFirestore;


namespace ResturantReserve.ModelsLogic
{
    class FbData : FbDataModel
    {
        public override async void CreateUserWithEmailAndPasswordAsync(string email, string password, string name, Action<System.Threading.Tasks.Task> OnComplete)
        {
            try
            {
                await facl.CreateUserWithEmailAndPasswordAsync(email, password, name).ContinueWith(OnComplete);
                await Shell.Current.DisplayAlert(Strings.Success, Strings.UserRegistered,Strings.Ok);
                await Shell.Current.GoToAsync(nameof(LoginPage));

            }
            catch (Exception)
            {

                await Shell.Current.DisplayAlert(Strings.Error, Strings.CreateUserError, Strings.Ok);
            }
        }
        public override async void SignInWithEmailAndPasswordAsync(string email, string password, Action<System.Threading.Tasks.Task> OnComplete)
        {
            try
            {
                await facl.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(OnComplete);
                await Shell.Current.DisplayAlert(Strings.Success, Strings.UserSignedIn, Strings.Ok);
                await Shell.Current.GoToAsync(nameof(RegisterPage));

            }
            catch (Exception)
            {
                await Shell.Current.DisplayAlert(Strings.Error, Strings.UserLoginError, Strings.Ok);
            }

        }
        public override string DisplayName
        {
            get
            {
                string dn = string.Empty;
                if (facl.User != null)
                    dn = facl.User.Info.DisplayName;
                return dn;
            }
        }
        public override string UserId
        {
            get
            {
                return facl.User.Uid;
            }
        }
    }
}

