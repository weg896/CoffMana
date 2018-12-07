using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffMana.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Acr.UserDialogs;
using CoffMana.Services;
using System.Diagnostics;

namespace CoffMana.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

        public  void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string tempUsername = usernameEntry.Text;
            string tempPassword = passwordEntry.Text;

            if (tempUsername == null || passwordEntry== null || 0 == tempUsername.CompareTo("") || 0 == tempPassword.CompareTo(""))
            {
                loginFail("please type in both username and password");
            }
            else
            {
                App.currentUser = new User();
                App.currentUser.username = tempUsername;
                App.currentUser.password = tempPassword;

                /* bool tempIsAuth = false;
                 using (UserDialogs.Instance.Loading("Prepare Device for You",null, null,true, MaskType.Black))
                {
                    Debug.WriteLine(@""+ tempUsername +"  : " + tempPassword);
                    tempIsAuth = await Task.Run(() => loginHelper(App.currentUser));
                }
                */
                if (true)//tempIsAuth) // assume no password, don't care about network connection and authentication token
                {
                    Application.Current.MainPage = new MainPage();
                }
            }
        }

        private async Task<bool> loginHelper(User u)
        {

            List<User> response = await DatabaseService.GetDatabaseInstance().GetUserAsync(u);
            if(response == null || response.Count != 1)
            {
                App.restService = new RestService();
                App.currentUser = await App.restService.RestLogin(u);
                if (App.currentUser == null)
                {
                    loginFail("please check your username and password");
                    return false;
                }
                return true;
            }
            return true;
        }

        private static void loginFail(string message)
        {
            ToastConfig toastConfig = new ToastConfig(message);
            toastConfig.SetDuration(2500);
            toastConfig.SetBackgroundColor(Color.DimGray);
            UserDialogs.Instance.Toast(toastConfig);
        }

    }


}