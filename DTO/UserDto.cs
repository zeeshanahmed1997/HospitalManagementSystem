namespace HospitalManagementSystem.DTO
{
    public class UserDto
    {
        public required string Fullname { get; set; }
        public required string Email { get; set; }
        public required string Role { get; set; }
        public required int Id { get; set; }
        public required string PhoneNumber { get; set; }
        public string? Password{get;set;}
    }
}
