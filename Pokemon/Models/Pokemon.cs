using System.ComponentModel.DataAnnotations;

namespace Pokemon.Models
{
    public class Pokemon
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string type1 { get; set; }
    }
}
