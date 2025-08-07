using Market.Application.DTOs.Role;
using Market.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Market.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _roleService.GetAllRolesAsync();
            return Ok(roles);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole([FromBody] AddRoleDto dto)
        {
            var role = await _roleService.AddRoleAsync(dto.Name);
            return Ok(role);
        }

        [HttpPut("{roleId:guid}")]
        public async Task<IActionResult> UpdateRole([FromRoute] Guid roleId, [FromBody] AddRoleDto dto)
        {
            var role = await _roleService.UpdateRoleAsync(roleId, dto.Name);
            return Ok(role);
        }
    }
}