using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CoffMana.Models
{
    [Table("Farm")]
    public class Farm
    {
        [PrimaryKey, AutoIncrement]
        public int farm_id { get; set; } // (primary) 
        public string guid { get; set; }
        public string regin { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int for_producer_id { get; set; } // (forgin)
    }
}
