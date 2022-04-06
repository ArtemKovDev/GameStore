using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PL.Filters;
using PL.ViewModels.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Controllers
{
    [CustomExceptionFilter]
    [ModelStateActionFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IRegisteredUserService _registeredUserService;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public UserInfoController(IRegisteredUserService registeredUserService, 
            IRoleService roleService, IMapper mapper)
        {
            _registeredUserService = registeredUserService;
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetUserCredentials()
        {
            var user = _registeredUserService.GetAll().SingleOrDefault(u => u.UserName == User.Identity.Name);
            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UserUpdateModel model)
        {
            if(model.UserName == User.Identity.Name)
            {
                var user = _mapper.Map<UserUpdateModel, RegisteredUserDto>(model);
                await _registeredUserService.UpdateAsync(user);
                return Ok(user);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpGet("roles")]
        public async Task<IEnumerable<string>> GetUserRoles()
        {
            return await _roleService.GetRoles(User.Identity.Name);
        }
    }
}
