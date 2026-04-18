using HospitalManagementSystem.DataAccessLayer;
using HospitalManagementSystem.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinesController : ControllerBase
    {
        private readonly MedicineRepository _repository;

        public MedicinesController(MedicineRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Doctor,Staff")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _repository.GetAllMedicines();
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("low-stock")]
        [Authorize(Roles = "Admin,Staff")]
        public async Task<IActionResult> GetLowStock([FromQuery] int threshold = 20)
        {
            var response = await _repository.GetLowStockMedicines(threshold);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Doctor,Staff")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _repository.GetMedicineById(id);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Staff")]
        public async Task<IActionResult> Create([FromBody] CreateMedicineRequest request)
        {
            if (string.IsNullOrEmpty(request.Name) || request.UnitPrice <= 0)
                return BadRequest(new { message = "Invalid medicine data." });

            var response = await _repository.CreateMedicine(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Staff")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateMedicineRequest request)
        {
            var response = await _repository.UpdateMedicine(id, request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPatch("stock")]
        [Authorize(Roles = "Admin,Staff")]
        public async Task<IActionResult> UpdateStock([FromBody] StockUpdateRequest request)
        {
            if (request.Quantity == 0)
                return BadRequest(new { message = "Quantity cannot be zero." });

            var response = await _repository.UpdateStock(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _repository.DeleteMedicine(id);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}