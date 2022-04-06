using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using BLL.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PL.Filters;
using PL.Helpers;
using PL.ViewModels.Identity;
using PL.ViewModels.Identity.Responses;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Controllers
{
    [CustomExceptionFilter]
    [ModelStateActionFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IRoleService _roleService;
        private readonly IRegisteredUserService _registeredUserService;
        private readonly JwtSettings _jwtSettings;
        private readonly IMapper _mapper;

        public AccountController(
            IAccountService accountService,
            IRoleService roleService,
            IRegisteredUserService registeredUserService,
            IOptionsSnapshot<JwtSettings> jwtSettings,
            IMapper mapper)
        {
            _accountService = accountService;
            _roleService = roleService;
            _registeredUserService = registeredUserService;
            _jwtSettings = jwtSettings.Value;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var result = await _accountService.Register(_mapper.Map<RegisterModel, Register>(model));

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                return BadRequest(new RegistrationResponseModel { Errors = errors, IsSuccessfulRegistration = false });
            }

            await _registeredUserService.AddAsync(_mapper.Map<RegisterModel, RegisteredUserDto>(model));

            await _roleService.AssignUserToRole(_mapper.Map<UserRoleModel, UserRole>(new UserRoleModel { UserName = model.UserName, Role = "user" }));

            return Created(string.Empty, string.Empty);
        }

        [HttpPost("logon")]
        public async Task<IActionResult> Logon(LogonModel model)
        {
            var user = await _accountService.Logon(_mapper.Map<LogonModel, Logon>(model));

            if (user is null) return Unauthorized(new AuthResponseModel { ErrorMessage = "Invalid Authentication" });

            var roles = await _roleService.GetRoles(user);

            var token = JwtHelper.GenerateJwt(user, roles, _jwtSettings);

            return Ok(new AuthResponseModel { IsAuthSuccessful = true, Token = token });
        }
    }
}
