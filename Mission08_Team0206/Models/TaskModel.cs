using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Team0206.Models
{
    public class TaskModel // We named it TaskModel because apparently Task is an ASP.Net keyword
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
        public int? CategoryID { get; set; } // Links to the Categories table via CategoryID and the Category Class
        public Category? Category { get; set; }

        public bool? Completed { get; set; }
    }
}
