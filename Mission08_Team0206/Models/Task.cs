using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Team0206.Models
{
    public partial class Task
    {
        [Key]
        [Required]
        public int TaskID { get; set; }

        [Required(ErrorMessage = "Please enter a task name")]
        public string TaskName { get; set; }

        public string? DueDate { get; set; }

        [Required(ErrorMessage = "Please enter a quadrant")]
        public int Quadrant { get; set; }

        [ForeignKey("CategoryID")]
        public int? CategoryID { get; set; }
        public Category? Category { get; set; }

        public bool? Completed { get; set; }
    }
}
