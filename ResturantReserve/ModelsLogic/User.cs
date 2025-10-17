using ResturantReserve.Models;
using System.Xml.Linq;

internal class User : UserModel
{
    public override void Register()
    {
        Preferences.Set(Keys.NameKey, Name);
        Preferences.Set(Keys.EmailKey, Email);
        Preferences.Set(Keys.PasswordKey, Password);
        Preferences.Set(Keys.RememberMeKey, RememberMe);
    }
    public User()
    {
        Name = Preferences.Get(Keys.NameKey, string.Empty);
        Email = Preferences.Get(Keys.EmailKey, string.Empty);
        Password = Preferences.Get(Keys.PasswordKey, string.Empty);
        Preferences.Remove(Keys.RememberMeKey);
        RememberMe = Preferences.Get(Keys.RememberMeKey, false);
    }

    public override void Login()
    {
       
    }
}
