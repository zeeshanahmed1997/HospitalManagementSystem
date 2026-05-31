using HospitalManagementSystem.DataAccessLayer;
using HospitalManagementSystem.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace HospitalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly AppointmentRepository _repository;

        public AppointmentsController(AppointmentRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<AppointmentsController>
        [HttpGet("all-appointments")]
        [Authorize(Roles = "Admin")] // Only Admin can access all appointments
        public async Task<IActionResult> GetAllAppointments()
        {
            var response = await _repository.GetAllAppointments();
            if (!response.Success)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpGet("appointments")]
        [Authorize(Roles = "Admin,Doctor,Patient")]
        public async Task<IActionResult> Get()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { message = "User ID not found in token." });
            }
            // Get roles from current user context
            bool isDoctor = User.IsInRole("Doctor");
            bool isPatient = User.IsInRole("Patient");
            // bool isAdmin = User.IsInRole("Admin"); // if needed
            var response = await _repository.GetAppointments(userId, isDoctor, isPatient);
            if (!response.Success)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpGet("patient-appointments")]
        [Authorize(Roles = "Admin,Patient")]
        public async Task<IActionResult> GetPatientAppointments()
        {
            // Get the ID from the JWT Token
            var patientId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(patientId))
            {
                return Unauthorized(new { message = "Patient ID not found in token." });
            }
            // Pass the patientId to the repository
            var response = await _repository.GetAppointmentsForPatient(patientId);
            if (!response.Success) return BadRequest(response);
            return Ok(response);
        }

        [HttpPost("create")]
        [Authorize(Roles = "Patient,Doctor")]
        public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentRequest request)
        {
            if (request == null)
                return BadRequest(new { message = "Invalid appointment data." });
            // Get logged-in UserId from token
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                      ?? User.FindFirst("sub")?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized(new { message = "User identity not found in token." });
            try
            {
                var response = await _repository.CreateAppointment(int.Parse(userId), request, User);
                if (!response.Success)
                    return BadRequest(response);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", detail = ex.Message });
            }
        }

        [HttpPatch("cancel/{appointmentId}")]
        [Authorize(Roles = "Admin,Patient,Doctor")]
        public async Task<IActionResult> CancelAppointment([FromRoute] int appointmentId)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { message = "User ID not found in token." });
            }
            if (User.IsInRole("Doctor"))
            {
            }
            var response = await _repository.CancelAppointment(appointmentId);
            if (!response.Success) return BadRequest(response);
            return Ok(response);
        }

        [HttpPatch("update")]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> UpdateAppointment([FromQuery] int appointmentId, [FromBody] UpdateAppointmentRequest request)
        {
            // Get the ID from the JWT Token
            var doctorId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(doctorId))
            {
                return Unauthorized(new { message = "Doctor ID not found in token." });
            }
            // Pass the doctorId to the repository
            var response = await _repository.UpdateAppointment(appointmentId, request);
            if (!response.Success) return BadRequest(response);
            return Ok(response);
        }

        // ==================== NEW TOKEN & QUEUE SYSTEM ENDPOINTS ====================

        [HttpPost("generate-token/{appointmentId}")]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> GenerateToken([FromRoute] int appointmentId)
        {
            var response = await _repository.GenerateAppointmentToken(appointmentId);
            if (!response.Success)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpGet("today-queue")]
        [Authorize(Roles = "Doctor,Admin")]
        public async Task<IActionResult> GetTodayQueue()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { message = "User ID not found in token." });
            }

            bool isDoctor = User.IsInRole("Doctor");
            if (!isDoctor)
            {
                return BadRequest(new { message = "Only doctors can view today's queue." });
            }

            var response = await _repository.GetTodayQueue((userId));   // You can adjust parameter if needed
            if (!response.Success)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpPatch("queue-status/{appointmentId}")]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> UpdateQueueStatus([FromRoute] int appointmentId, [FromBody] string queueStatus)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { message = "User ID not found in token." });
            }

            var response = await _repository.UpdateQueueStatus(appointmentId, queueStatus);
            if (!response.Success)
                return BadRequest(response);
            return Ok(response);
        }
    }
}