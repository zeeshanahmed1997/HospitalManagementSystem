using Microsoft.AspNetCore.Identity;

namespace HospitalManagementSystem.Data.Models
{
    // MUST have <int> here
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}