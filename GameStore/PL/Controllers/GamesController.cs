using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PL.Filters;
using PL.ViewModels.Games;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PL.Controllers
{
    [CustomExceptionFilter]
    [ModelStateActionFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _service;
        private readonly IMapper _mapper;

        public GamesController(IGameService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/<GamesController>
        [HttpGet]
        public IEnumerable<GameDto> Get()
        {
            return _service.GetAll();
        }

        // GET api/<GamesController>/5
        [HttpGet("{id}")]
        public async Task<GameDto> Get(int id)
        {
            return await _service.GetByIdAsync(id);
        }

        // POST api/<GamesController>
        [Authorize(Roles = "manager, admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GameAddModel model)
        {
            var game = _mapper.Map<GameAddModel, GameDto>(model);
            await _service.AddAsync(game);
            return Ok(game);
        }

        // PUT api/<GamesController>
        [Authorize(Roles = "manager, admin")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] GameUpdateModel model)
        {
            var game = _mapper.Map<GameUpdateModel, GameDto>(model);
            await _service.UpdateAsync(game);
            return Ok(game);
        }

        // DELETE api/<GamesController>/5
        [Authorize(Roles = "manager, admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteByIdAsync(id);
            return Ok();
        }
    }
}
