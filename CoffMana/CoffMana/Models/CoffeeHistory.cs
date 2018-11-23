using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CoffMana.Models
{
    [Table("CoffeeHistory")]
    public class CoffeeHistory
    {
        [PrimaryKey, AutoIncrement]
        public int history_id { get; set; } // (primary),
        public string guid { get; set; }
        public int for_coffee_id { get; set; } // (forgin),
        public int for_user_id { get; set; } // (forgin)
        public int start_year { get; set; }
	    public int start_month { get; set; }
        public int start_day { get; set; }
        public float order_price { get; set; }
        public float sell_price { get; set; }
    }
}
