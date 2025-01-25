namespace TaskManagementSystem
{
    public class EmailNotificationService : INotificationService
    {
        public void SendNotification(string to, string subject, string message)
        {
            // Simulate sending an email (you can integrate an SMTP service like SendGrid or MailKit here)
            Console.WriteLine($"Email sent to {to}: {subject} - {message}");
        }
    }
}
