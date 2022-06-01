using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PL.Filters;
using PL.ViewModels.PaymentTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PL.Controllers
{
    [CustomExceptionFilter]
    [ModelStateActionFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTypesController : ControllerBase
    {
        private readonly IPaymentTypeService _service;
        private readonly IMapper _mapper;

        public PaymentTypesController(IPaymentTypeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/<PaymentTypesController>
        [HttpGet]
        public IEnumerable<PaymentTypeDto> Get()
        {
            return _service.GetAll();
        }

        // GET api/<PaymentTypesController>/5
        [HttpGet("{id}")]
        public async Task<PaymentTypeDto> Get(int id)
        {
            return await _service.GetByIdAsync(id);
        }

        // POST api/<PaymentTypesController>
        [Authorize(Roles = "manager, admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PaymentTypeAddModel model)
        {
            var paymentType = _mapper.Map<PaymentTypeAddModel, PaymentTypeDto>(model);
            await _service.AddAsync(paymentType);
            return Ok(paymentType);
        }

        // PUT api/<PaymentTypesController>
        [Authorize(Roles = "manager, admin")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PaymentTypeUpdateModel model)
        {
            var paymentType = _mapper.Map<PaymentTypeUpdateModel, PaymentTypeDto>(model);
            await _service.UpdateAsync(paymentType);
            return Ok(paymentType);
        }

        // DELETE api/<PaymentTypesController>/5
        [Authorize(Roles = "manager, admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteByIdAsync(id);
            return Ok();
        }
    }
}
