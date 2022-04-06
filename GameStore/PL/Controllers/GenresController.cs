using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PL.Filters;
using PL.ViewModels.Genres;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PL.Controllers
{
    [CustomExceptionFilter]
    [ModelStateActionFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _service;
        private readonly IMapper _mapper;

        public GenresController(IGenreService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/<GenresController>
        [HttpGet]
        public IEnumerable<GenreDto> Get()
        {
            return _service.GetAll();
        }

        // GET api/<GenresController>/5
        [HttpGet("{id}")]
        public async Task<GenreDto> Get(int id)
        {
            return await _service.GetByIdAsync(id);
        }

        // POST api/<GenresController>
        [Authorize(Roles = "manager, admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GenreAddModel model)
        {
            var genre = _mapper.Map<GenreAddModel, GenreDto>(model);
            await _service.AddAsync(genre);
            return Ok(genre);
        }

        // PUT api/<GenresController>
        [Authorize(Roles = "manager, admin")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] GenreUpdateModel model)
        {
            var genre = _mapper.Map<GenreUpdateModel, GenreDto>(model);
            await _service.UpdateAsync(genre);
            return Ok(genre);
        }

        // DELETE api/<GenresController>/5
        [Authorize(Roles = "manager, admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteByIdAsync(id);
            return Ok();
        }
    }
}
