using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CoffMana.Views;
using CoffMana.Services;
using CoffMana.Models;
using Acr.UserDialogs;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CoffMana
{
    public partial class App : Application
    {
        private static DatabaseService database;
        public static User currentUser;
        public static RestService restService;

        public App()
        {
            InitializeComponent();
            GetDatabase(); //first init;
            MainPage = new LoginPage();
        }

        public static DatabaseService GetDatabase()
        {
            if(database == null)
            {
                database = new DatabaseService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CoffManaDB.db3"));
                database.creatAllTalbe();
            }
            return database;
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
