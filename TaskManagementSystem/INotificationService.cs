namespace TaskManagementSystem
{
    public interface INotificationService
    {
        void SendNotification(string to, string subject, string message);
    }
}
