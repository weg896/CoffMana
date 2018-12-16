using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CoffMana.Models;
using CoffMana.Services;

namespace CoffMana.CoffDebug
{
    class MockingOperation
    {

        public static async void InsertSomeFakeCoffee()
        {
            Coffee tempOne = new Coffee();
            Coffee tempTwo = new Coffee();
            Coffee tempThree = new Coffee();

            tempOne.coffee_id = 1001;
            tempOne.variety = "Arusha";
            tempOne.process = "semi-dry";

            tempTwo.coffee_id = 1002;
            tempTwo.variety = "Arusha";
            tempTwo.process = "dry";

            tempThree.coffee_id = 1003;
            tempThree.variety = "Typica";
            tempThree.process = "wet dry";

            await DatabaseService.GetDatabaseInstance().InsertNewCoffeeAsync(tempOne);
            await DatabaseService.GetDatabaseInstance().InsertNewCoffeeAsync(tempTwo);
            await DatabaseService.GetDatabaseInstance().InsertNewCoffeeAsync(tempThree);
        }

        public static async void InsertSomeFakeOrder()
        {
            for(int i = 0; i < 6; i++)
            {
                CoffeeOrder temp = new CoffeeOrder();
                temp.order_id = i+1;
                temp.for_coffee_id = i%3 + 1001;
                temp.order_day = 2;
                temp.order_month = 1+i;
                temp.order_year = 2018;
                temp.quantity = 10;
                temp.order_status = "shipping";
                temp.variety = "Typica";
                temp.process = "wet dry";

                await DatabaseService.GetDatabaseInstance().InsertMockingCoffeeOrderAsync(temp);
            }
        }


        public static Task<List<CoffeeOrder>> GetSomeFakeOrder()
        {
            return DatabaseService.GetDatabaseInstance().GetAllMockingCoffeeOrderList();
        }

        public static Task<List<object>> GetSoemFakeCoffee()
        {
            return  DatabaseService.GetDatabaseInstance().GetAllMockingCoffeeList();
        }
    }
}
