using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffMana.Models;
using CoffMana.CoffDebug;
using CoffMana.Services;
using CoffMana.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoffMana.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlaceOrder : ContentPage
	{
		public PlaceOrder ()
		{
			InitializeComponent ();
		}

        public async void OnPlaceOrderClicked(object sender, EventArgs e)
        {
            CoffeeOrder tempOrder = new CoffeeOrder();
            tempOrder.order_year = DateTime.Today.Year;
            tempOrder.order_month = DateTime.Today.Month;
            tempOrder.order_day = DateTime.Today.Day;

            tempOrder.order_status = "OrderPlaced";
            tempOrder.variety = variety.Text;
            tempOrder.quantity = int.Parse(quantity.Text);

            int ID = await DatabaseService.GetDatabaseInstance().InsertMockingCoffeeOrderAsync(tempOrder);
            ToastViewPart.toastMessage("add New Coffee Order: "+ID);
        }
	}
}