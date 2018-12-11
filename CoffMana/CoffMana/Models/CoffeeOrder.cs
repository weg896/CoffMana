using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CoffMana.Models
{
    [Table("CoffeeOrder")]
    public class CoffeeOrder
    {
        [PrimaryKey, AutoIncrement]
        public int order_id { get; set; } // (primary)
        public string guid { get; set; }
        public int for_coffee_id { get; set; } // (forgin)
        public int quantity { get; set; }
        public int order_year { get; set; }
        public int order_month { get; set; }
        public int order_day { get; set; }
        public string order_status { get; set; }
        public string comment { get; set; }
        /// <summary>
        /// ///////////////////////////////////
        /// </summary>
        /// varienty
        public string variety { get; set; }
        public string process { get; set; }
    }
}
