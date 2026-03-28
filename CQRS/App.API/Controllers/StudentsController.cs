using App.Application.Features.Students.Commands;
using App.Application.Features.Students.Queries;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly CreateStudentHandler _createHandler;
        private readonly GetStudentByIdHandler _getHandler;

        public StudentsController(
            CreateStudentHandler createHandler,
            GetStudentByIdHandler getHandler)
        {
            _createHandler = createHandler;
            _getHandler = getHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentCommand command)
        {
            await _createHandler.HandleAsync(command);
            return Ok(new { message = "Student Created Successfully!" });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetStudentByIdQuery(id);
            var result = await _getHandler.HandleAsync(query);

            if (result == null) return NotFound();

            return Ok(result);
        }
    }
}
