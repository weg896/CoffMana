using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CoffMana.Models
{
    [Table("Producer")]
    public class Producer
    {
        [PrimaryKey, AutoIncrement]
        public int producer_id { get; set; } //(primary),
        public string guid { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string picture { get; set; }
    }
}
