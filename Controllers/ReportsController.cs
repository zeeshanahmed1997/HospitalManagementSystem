// Controllers/ReportsController.cs
using HospitalManagementSystem.DataAccessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HospitalManagementSystem.Controllers
{
    [ApiController]
    [Route("api/reports")]
    [Authorize]
    public class ReportsController(ReportRepository repository) : ControllerBase
    {
        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAdminReport()
        {
            var response = await repository.GetAdminReport();
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("doctor")]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> GetDoctorReport()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var response = await repository.GetDoctorReport(userId);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}