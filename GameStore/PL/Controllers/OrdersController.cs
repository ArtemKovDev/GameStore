using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PL.Filters;
using PL.ViewModels.Orders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PL.Controllers
{
    [CustomExceptionFilter]
    [ModelStateActionFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/<OrdersController>
        [HttpGet]
        public IEnumerable<OrderDto> Get()
        {
            return _service.GetAll();
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public async Task<OrderDto> Get(int id)
        {
            return await _service.GetByIdAsync(id);
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderAddModel model)
        {
            var order = _mapper.Map<OrderAddModel, OrderDto>(model);
            await _service.AddAsync(order);
            return Ok(order);
        }

        // PUT api/<OrdersController>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] OrderUpdateModel model)
        {
            var order = _mapper.Map<OrderUpdateModel, OrderDto>(model);
            await _service.UpdateAsync(order);
            return Ok(order);
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteByIdAsync(id);
            return Ok();
        }
    }
}
