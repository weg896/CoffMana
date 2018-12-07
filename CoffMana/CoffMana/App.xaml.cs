using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CoffMana.Views;
using CoffMana.Services;
using CoffMana.Models;
using Acr.UserDialogs;
using CoffMana.Debug;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CoffMana
{
    public partial class App : Application
    {
        public static User currentUser;
        public static RestService restService;

        public App()
        {
            InitializeComponent();
            MockingOperation.InsertSomeFakeCoffee();
            MockingOperation.InsertSomeFakeOrder();
            MainPage = new LoginPage();
        }



        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
