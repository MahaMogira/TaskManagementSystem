using Microsoft.AspNetCore.Identity;

namespace TaskManagementSystem.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }

        public List<Task> tasks { get; set; }
    }
}
