using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public string Priority { get; set; } = "Low"; // Low, Medium, High
        public string Status { get; set; } = "Pending"; // Pending, In Progress, Completed

        public string AssignedTo { get; set; } = string.Empty; // UserId
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [ForeignKey("AssignedTo")]
        public User User { get; set; }

       


    }
}
