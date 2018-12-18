using CoffMana.Models;
using System;
using System.Diagnostics;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoffMana.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();
            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.OrderedList, Title="Ordered List" },
                new HomeMenuItem {Id = MenuItemType.PlaceOrder, Title="Place Order" },
                new HomeMenuItem {Id = MenuItemType.QRCodeScan, Title="QRCode Scan" },
                new HomeMenuItem {Id = MenuItemType.NonConfirmedOrder, Title="Non Confirmed Order" },
                new HomeMenuItem {Id = MenuItemType.ShippingOrder, Title="Shipping Order" },
                new HomeMenuItem {Id = MenuItemType.Customers, Title="Customers" },
                new HomeMenuItem {Id = MenuItemType.CustRequest, Title="Customer Request" },
                new HomeMenuItem {Id = MenuItemType.RevenueHistory, Title="Revenue History" },
                new HomeMenuItem {Id = MenuItemType.About, Title="About" },
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}