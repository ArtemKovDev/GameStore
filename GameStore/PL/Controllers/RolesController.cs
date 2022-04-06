using AutoMapper;
using BLL.Interfaces;
using BLL.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PL.Filters;
using PL.ViewModels.Identity;
using PL.ViewModels.Identity.Responses;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Controllers
{
    [CustomExceptionFilter]
    [ModelStateActionFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RolesController(
            IRoleService roleService,
            IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _roleService.GetRoles();
            return Ok(roles.Select(r => r.Name));
        }

        [HttpGet("{userName}")]
        public async Task<IEnumerable<string>> GetUserRoles(string userName)
        {
            return await _roleService.GetRoles(userName);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("assignUserToRole")]
        public async Task<IActionResult> AssignUserToRole(UserRoleModel model)
        {
            var result = await _roleService.AssignUserToRole(_mapper.Map<UserRoleModel, UserRole>(model));

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                return BadRequest(new RoleAssignmentResponseModel { Errors = errors, IsRoleAssignmentSuccessful = false });
            }
            return Ok();
        }
    }
}
