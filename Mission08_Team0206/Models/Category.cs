using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0206.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }
    }
}
