
using App.Business.DTOs;
using App.Business.Interfaces;
using App.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _departmentService.GetAllAsync();
            return Ok(departments);
        }
        [HttpPost]
        public async Task<IActionResult> Add(DepartmentDTO departmentDto)
        {
            var department = new Department
            {
                Code = departmentDto.Code,
                Name = departmentDto.Name,
                Description = departmentDto.Description,
                IsActive = departmentDto.IsActive
            };
            await _departmentService.AddAsync(department);
            return Ok();
        }
    }
}
