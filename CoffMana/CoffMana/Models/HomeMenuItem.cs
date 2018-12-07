using System;
using System.Collections.Generic;
using System.Text;

namespace CoffMana.Models
{
    public enum MenuItemType
    {
        OrderedList,
        PlaceOrder,
        NonConfirmedOrder,
        ShippingOrder,
        Customers,
        CustRequest,
        RevenueHistory,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
