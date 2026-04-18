using HospitalManagementSystem.DataAccessLayer;
using HospitalManagementSystem.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HospitalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]  // All dashboard endpoints require authentication
    public class DashboardController : ControllerBase
    {
        private readonly DashboardRepository _repository;

        public DashboardController(DashboardRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Dashboard/admin-stats
        // Admin Only - Returns statistics for Admin Dashboard
        [HttpGet("admin-stats")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAdminDashboardStats()
        {
            try
            {
                var response = await _repository.GetAdminDashboardStatsAsync();

                if (response.Success)
                {
                    return Ok(response);
                }

                return BadRequest(new
                {
                    Success = false,
                    Message = response.Message ?? "Failed to fetch dashboard statistics."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Success = false,
                    Message = "An unexpected error occurred while fetching dashboard stats.",
                    Error = ex.Message
                });
            }
        }

        // Optional: Future endpoints (you can expand later)

        // GET: api/Dashboard/doctor-stats  → For Doctors
        //[HttpGet("doctor-stats")]
        //[Authorize(Roles = "Doctor")]
        //public async Task<IActionResult> GetDoctorDashboardStats()
        //{
        //    var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //    if (string.IsNullOrEmpty(userId))
        //        return Unauthorized(new { Success = false, Message = "User ID not found in token." });

        //    // Call doctor-specific repository method here
        //    return Ok(new { Success = true, Message = "Doctor dashboard coming soon..." });
        //}

        // GET: api/Dashboard/patient-stats  → For Patients
        //[HttpGet("patient-stats")]
        //[Authorize(Roles = "Patient")]
        //public async Task<IActionResult> GetPatientDashboardStats()
        //{
        //    var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //    if (string.IsNullOrEmpty(userId))
        //        return Unauthorized(new { Success = false, Message = "User ID not found in token." });

        //    // Call patient-specific repository method here
        //    return Ok(new { Success = true, Message = "Patient dashboard coming soon..." });
        //}
    }
}