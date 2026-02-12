using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.DTO
{
    public class UserDto
    {
        public int? Id { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }

        public required string Gender { get; set; }

        public required int Age { get; set; }

        public required string Address { get; set; }

        public required string Role { get; set; }

        public required string PhoneNumber { get; set; }

        public string? Password { get; set; }
    }
}