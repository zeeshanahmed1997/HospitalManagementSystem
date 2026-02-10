using HospitalManagementSystem.DataAccessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class Usercontroller : ControllerBase
{
    private readonly UserRepository _userRepository;

    public Usercontroller(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet("users")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllUsers()
    {
        // No more LINQ errors or .Result deadlocks!
        var users = await _userRepository.GetAllUsersAsync();
        return Ok(users);
    }
}