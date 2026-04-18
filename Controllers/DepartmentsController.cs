using HospitalManagementSystem.DataAccessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly DepartmentRepository _repository;
        public DepartmentsController(DepartmentRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetDepartments()
        {
            var response = await _repository.GetDepartments();
            if (!response.Success)
                return BadRequest(response);
            return Ok(response);
        }
    }
}
