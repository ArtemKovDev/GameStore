using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PL.Filters;
using PL.ViewModels.CartLines;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PL.Controllers
{
    [CustomExceptionFilter]
    [ModelStateActionFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class CartLinesController : ControllerBase
    {
        private readonly ICartLineService _service;
        private readonly IMapper _mapper;

        public CartLinesController(ICartLineService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/<CartLinesController>
        [HttpGet]
        public IEnumerable<CartLineDto> Get()
        {
            return _service.GetAll();
        }

        // GET api/<CartLinesController>/5
        [HttpGet("{id}")]
        public async Task<CartLineDto> Get(int id)
        {
            return await _service.GetByIdAsync(id);
        }

        // POST api/<CartLinesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CartLineAddModel model)
        {
            var cartLine = _mapper.Map<CartLineAddModel, CartLineDto>(model);
            await _service.AddAsync(cartLine);
            return Ok(cartLine);
        }

        // PUT api/<CartLinesController>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CartLineUpdateModel model)
        {
            var cartLine = _mapper.Map<CartLineUpdateModel, CartLineDto>(model);
            await _service.UpdateAsync(cartLine);
            return Ok(cartLine);
        }

        // DELETE api/<CartLinesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteByIdAsync(id);
            return Ok();
        }
    }
}
