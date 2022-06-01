using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;
using PL.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PL.Controllers
{
    [CustomExceptionFilter]
    [ModelStateActionFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRegisteredUserService _registeredUserService;

        public UsersController(IRegisteredUserService registeredUserService)
        {
            _registeredUserService = registeredUserService;
        }

        [HttpGet]
        public IEnumerable<RegisteredUserDto> Get()
        {
            return _registeredUserService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<RegisteredUserDto> Get(int id)
        {
            return await _registeredUserService.GetByIdAsync(id);
        }
    }
}
