using HospitalManagementSystem.DataAccessLayer;
using HospitalManagementSystem.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HospitalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {
        private readonly PrescriptionRepository _repository;

        public PrescriptionsController(PrescriptionRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("prescriptions")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _repository.GetAllPrescriptions();
            return response.Success ? Ok(response) : BadRequest(response);
        }
        // GET: api/Prescriptions  → For Doctor and Patient
        [HttpGet]
        [Authorize(Roles = "Doctor,Patient")]
        public async Task<IActionResult> GetMyPrescriptions()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized(new { message = "User ID not found in token." });

            bool isDoctor = User.IsInRole("Doctor");
            bool isPatient = User.IsInRole("Patient");

            var response = await _repository.GetMyPrescriptions(userId, isDoctor, isPatient);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        // GET: api/Prescriptions/all  → Admin only
        [HttpGet("all")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllPrescriptions()
        {
            var response = await _repository.GetAllPrescriptions();
            return response.Success ? Ok(response) : BadRequest(response);
        }

        // POST: api/Prescriptions/create  → Doctor only
        [HttpPost("create")]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> Create([FromBody] CreatePrescriptionRequest request)
        {
            if (request == null || request.Items == null || !request.Items.Any())
                return BadRequest(new { message = "Invalid prescription data." });

            var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdStr) || !int.TryParse(userIdStr, out int userId))
                return Unauthorized(new { message = "User identity not found." });

            var response = await _repository.CreatePrescription(userId, request);
            return response.Success ? Ok(response) : BadRequest(response);
        }
        [HttpGet("{id:int}")] // Force it to only match if it's an integer
        [Authorize(Roles = "Doctor,Admin,Patient")]
        public async Task<IActionResult> GetPrescriptionDetails(int id)
        { 
            if (id == 0)
                return BadRequest(new { message = "Id not found" });
            var response = await _repository.GetPrescriptionDetails(id);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}