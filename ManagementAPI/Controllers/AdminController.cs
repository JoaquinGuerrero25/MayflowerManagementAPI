using Application.Interfaces;
using Application.Models.Request.Admin;
using Microsoft.AspNetCore.Mvc;

namespace ManagementAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _adminService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _adminService.GetById(id);
            return Ok(result);
        }

        [HttpPost("/CreateAdmin")]
        public IActionResult CreateAdmin([FromBody] AdminCreateRequest request)
        {
            var newAdmin = _adminService.CreateAdmin(request);
            return CreatedAtAction(nameof(GetById), new { id = newAdmin.Id }, newAdmin);
        }

        [HttpPut("/UpdateAdmin/{id}")]
        public IActionResult UpdateAdmin(Guid id, [FromBody] AdminUpdateRequest request)
        {
            _adminService.UpdateAdmin(id, request); 
            return NoContent();
        }

        [HttpPut("/DeleteAdmin/{id}")]
        public IActionResult DeleteAdmin(Guid id)
        {
            _adminService.DeleteAdmin(id);
            return NoContent();
        }
    }
}
