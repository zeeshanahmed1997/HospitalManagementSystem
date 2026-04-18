using HospitalManagementSystem.DataAccessLayer;
using HospitalManagementSystem.DTO;
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

    [HttpPost("user")]
     [Authorize(Roles = "Admin")]
    [AllowAnonymous]
    public async Task<IActionResult> CreateUser([FromBody] UserDto user)
    {
        var result = await _userRepository.CreateUser(user);
        return Ok(result);
        
    }

    [HttpGet("users")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllUsers()
    {
        // No more LINQ errors or .Result deadlocks!
        var users = await _userRepository.GetAllUsersAsync();
        return Ok(users);
    }
    [HttpPut("edit/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> EditUser([FromRoute] int id,[FromBody] UserDto updatedUser)
    {
        // No more LINQ errors or .Result deadlocks!
        var users = await _userRepository.UpdateUser(id,updatedUser);
        return Ok(users);
    }
    [HttpDelete("delete/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteUser([FromRoute] int id)
    {
        var result = await _userRepository.DeleteUser(id);
        return Ok(result);
    }

    [HttpGet("doctors")]
    [Authorize(Roles ="Admin, Patient")]
    public async Task<IActionResult> GetDoctors()
    {
        var result = await _userRepository.GetDoctors();
        return Ok(result);
    }
    [HttpGet("patients")]
    [Authorize(Roles = "Admin, Doctor")]
    public async Task<IActionResult> GetPatients()
    {
        var result = await _userRepository.GetPatients();
        return Ok(result);
    }
    [HttpGet("patients-by-doctor")]
    [Authorize(Roles = "Admin, Doctor")]
    public async Task<IActionResult> GetPatientsByDoctor([FromQuery] int doctorId)
    {
        var result = await _userRepository.GetPatientsByDoctor(doctorId);
        return Ok(result);
    }
}