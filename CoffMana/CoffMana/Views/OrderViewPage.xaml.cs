using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using CoffMana.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using QRCoder;
using System.Drawing;

namespace CoffMana.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OrderViewPage : ContentPage
	{
		public OrderViewPage (CoffeeOrder order)
		{
			InitializeComponent ();
            BindingContext = order;
            /*
            if(coffeeOrderItem != null)
            {
                Order_Day.Text = "Create Date :" + coffeeOrderItem.order_year + "-" + coffeeOrderItem.order_month + "-" + coffeeOrderItem.order_day;
                String tempStr =""+ coffeeOrderItem.order_id;

                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(tempStr, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(20);

            }
            */
        }

	}
}