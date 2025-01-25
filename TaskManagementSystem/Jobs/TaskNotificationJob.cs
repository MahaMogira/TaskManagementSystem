using TaskManagementSystem.Data;

namespace TaskManagementSystem.Jobs
{
    public class TaskNotificationJob
    {
        private readonly ApplicationDbContext _context;
        private readonly INotificationService _notificationService;
        public TaskNotificationJob(ApplicationDbContext context, INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }
        public void CheckOverdueTasks()
        {
            var overdueTasks = _context.TaskItems
                .Where(t => t.DueDate < DateTime.UtcNow && t.Status != "Completed")
                .ToList();

            foreach (var task in overdueTasks)
            {
                var assignedUsers = _context.Users
                    .Where(u => u.tasks.Any(ut => ut.Id == task.Id))
                    .ToList();


                foreach (var user in assignedUsers)
                {
                    var message = $"Task '{task.Title}' is overdue. Please take action.";
                    _notificationService.SendNotification(user.Email, "Overdue Task Notification", message);
                }
            }
        }
    }
}
