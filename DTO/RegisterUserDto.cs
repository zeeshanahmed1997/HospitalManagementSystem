namespace HospitalManagementSystem.DTO
{
    public class RegisterUserDto
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Gender { get; set; }
        public int Age { get; set; }
        public required string Address { get; set; }
        public required string PhoneNumber { get; set; }
    }
}
