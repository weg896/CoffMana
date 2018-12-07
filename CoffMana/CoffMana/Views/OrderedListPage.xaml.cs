using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using CoffMana.Services;
using CoffMana.Models;
using CoffMana.Debug;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;

namespace CoffMana.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderedListPage : ContentPage
    {
        public ObservableCollection<Order> Items { get; set; }

        public OrderedListPage()
        {
            InitializeComponent();
            helperFunction();

        }

        private async void helperFunction()
        {
            Items = new ObservableCollection<Order>();
            List<Order> tempI = await Task.Run(() => MockingOperation.GetSomeFakeOrder());
            foreach(Order t in tempI)
            {
                Items.Add(t);
            }

            MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
