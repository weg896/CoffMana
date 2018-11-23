using SQLite;

namespace CoffMana.Models
{
    [Table("User")]
    public class User
    {
        [PrimaryKey]
        public string username { get; set; } // Primary
        public string password { get; set; }
        public string temp_token { get; set; }
    }
   
}
