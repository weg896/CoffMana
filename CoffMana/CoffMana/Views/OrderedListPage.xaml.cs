using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using CoffMana.Services;
using CoffMana.Models;
using CoffMana.CoffDebug;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;

namespace CoffMana.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderedListPage : ContentPage
    {
        public ObservableCollection<CoffeeOrder> Items { get; set; }

        public OrderedListPage()
        {
            InitializeComponent();
            helperFunction();
        }

        private async void helperFunction()
        {
            Items = new ObservableCollection<CoffeeOrder>();
            List<CoffeeOrder> tempCoffeeOrderList = await MockingOperation.GetSomeFakeOrder();

            foreach(CoffeeOrder t in tempCoffeeOrderList)
            {
                Items.Add(t);
                Debug.WriteLine("add to list +++"+t.variety + "-"+t.process+"-"+t.quantity);
            }

            MyListView.ItemsSource = Items;

        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
            {
                return;
            }

            await Navigation.PushAsync(new OrderViewPage(e.Item as CoffeeOrder));

            /*
            await DisplayAlert("Item Tapped"+ ((CoffeeOrder)((ListView)sender).SelectedItem).process, "An item was tapped.", "OK");
            */
            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            //((App)App.Current).ResumeAtTodoId = -1;
            Debug.WriteLine("on appering");
            helperFunction();
        }
    }
}
