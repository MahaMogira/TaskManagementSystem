using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TaskManagementSystem.Data;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TaskController:ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly INotificationService _notificationService;
        public TaskController(ApplicationDbContext context, INotificationService notificationService)
        {
            _context = context; 
            _notificationService = notificationService;
        }

        // POST: api/Task
        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> CreateTask([FromBody] TaskCreateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var task = new TaskItem
            {
                Title = model.Title,
                Description = model.Description,
                Priority = model.Priority,
                Status = "Pending",
                DueDate = model.DueDate,
                AssignedTo = model.AssignedToId,
                CreatedAt = DateTime.UtcNow
            };
            _context.TaskItems.Add(task);
            await _context.SaveChangesAsync();
            // Notify assigned users
            if (task.User != null && task.User.Email!=null)
            {
                
                    _notificationService.SendNotification(task.User.Email, "New Task Assigned",
                        $"You have been assigned a new task: {task.Title}");
               
            }

            return CreatedAtAction(nameof(GetTaskById),new {id=task.Id},task);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {

              var task= await _context.TaskItems.Include(t=>t.AssignedTo)
                .FirstOrDefaultAsync(t=>t.Id==id);
            if (task == null)
                return NotFound();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userRole = User.FindFirstValue(ClaimTypes.Role);

            if (userRole != "Manager" && task.AssignedTo != userId)
                return Forbid();

            return Ok(new
            {
                task.Id,
                task.Title,
                task.Description,
                task.Priority,
                task.Status,
                task.DueDate,
                AssignedTo = task.User?.FullName
            });


        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Manager,Employee")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskUpdateModel model)
        {
            var task= await _context.TaskItems.FindAsync(id);
            if (task == null)
                return NotFound();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userRole = User.FindFirstValue(ClaimTypes.Role);
            if (userRole == "Employee" && task.AssignedTo != userId)
                return Forbid();
            task.Status = model.Status;
            task.Description = model.Description;
            task.DueDate = model.DueDate;
            task.Priority = model.Priority;
            _context.TaskItems.Update(task);
            await _context.SaveChangesAsync();

            if (task.User != null && task.User.Email != null)
            {

                _notificationService.SendNotification(task.User.Email, "Task Status Updated",
                        $"The status of the task '{task.Title}' has been updated to: {task.Status}");
            
           }

            return NoContent();

        }
        // DELETE: api/Task/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.TaskItems.FindAsync(id);

            if (task == null)
                return NotFound();

            _context.TaskItems.Remove(task);
            await _context.SaveChangesAsync();
            if (task.User != null && task.User.Email != null)
            {

                _notificationService.SendNotification(task.User.Email, "Task Deleted",
                    $"The task '{task.Title}' has been deleted.");
            }

            return NoContent();
        }

        private void NotifyUser(string userId, string message)
        {
            // Placeholder for actual notification logic
            Console.WriteLine($"Notification to {userId}: {message}");
        }
    

    public class TaskCreateModel
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string Priority { get; set; } // Low, Medium, High
            public DateTime DueDate { get; set; }
            public string AssignedToId { get; set; }
        }
        public class TaskUpdateModel
        {
            public string Description { get; set; }
            public string Priority { get; set; } // Low, Medium, High
            public string Status { get; set; } // Pending, In Progress, Completed
            public DateTime DueDate { get; set; }
        }
    }
}
