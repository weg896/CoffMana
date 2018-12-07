using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CoffMana.Models
{
    [Table("Coffee")]
    public class Coffee
    {
        [PrimaryKey, AutoIncrement]
        public int coffee_id { get; set; } // (primary),
        public string guid { get; set; }
        public int for_producter_id { get; set; } // (forgin),
        public int for_farm_id { get; set; } // (forgin),
        public int for_history_id { get; set; } // (forgin),
        public string variety { get; set; }
	    public string process { get; set; }
	    public string description { get; set; }
    }
}
