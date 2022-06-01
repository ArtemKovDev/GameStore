using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PL.Filters;
using PL.ViewModels.GameGenres;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PL.Controllers
{
    [CustomExceptionFilter]
    [ModelStateActionFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class GameGenresController : ControllerBase
    {
        private readonly IGameGenreService _service;
        private readonly IMapper _mapper;

        public GameGenresController(IGameGenreService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/<GameGenresController>
        [HttpGet]
        public IEnumerable<GameGenreDto> Get()
        {
            return _service.GetAll();
        }

        // GET api/<GameGenresController>/5
        [HttpGet("{id}")]
        public async Task<GameGenreDto> Get(int id)
        {
            return await _service.GetByIdAsync(id);
        }

        // POST api/<GameGenresController>
        [Authorize(Roles = "manager, admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GameGenreAddModel model)
        {
            var gameGenre = _mapper.Map<GameGenreAddModel, GameGenreDto>(model);
            await _service.AddAsync(gameGenre);
            return Ok(gameGenre);
        }

        // PUT api/<GameGenresController>
        [Authorize(Roles = "manager, admin")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] GameGenreUpdateModel model)
        {
            var gameGenre = _mapper.Map<GameGenreUpdateModel, GameGenreDto>(model);
            await _service.UpdateAsync(gameGenre);
            return Ok(gameGenre);
        }

        // DELETE api/<GameGenresController>/5
        [Authorize(Roles = "manager, admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteByIdAsync(id);
            return Ok();
        }
    }
}
