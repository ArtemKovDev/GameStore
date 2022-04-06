using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PL.Filters;
using PL.ViewModels.Comments;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PL.Controllers
{
    [CustomExceptionFilter]
    [ModelStateActionFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _service;
        private readonly IMapper _mapper;

        public CommentsController(ICommentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/<CommentsController>
        [HttpGet]
        public IEnumerable<CommentDto> Get()
        {
            return _service.GetAll();
        }

        // GET api/<CommentsController>/5
        [HttpGet("{id}")]
        public async Task<CommentDto> Get(int id)
        {
            return await _service.GetByIdAsync(id);
        }

        // POST api/<CommentsController>
        [Authorize(Roles = "manager, admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CommentAddModel model)
        {
            var comment = _mapper.Map<CommentAddModel, CommentDto>(model);

            comment.CommentDate = System.DateTime.Now;

            await _service.AddAsync(comment);
            return Ok(comment);
        }

        // PUT api/<CommentsController>
        [Authorize(Roles = "manager, admin")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CommentUpdateModel model)
        {
            var comment = _mapper.Map<CommentUpdateModel, CommentDto>(model);

            comment.CommentDate = System.DateTime.Now;

            await _service.UpdateAsync(comment);
            return Ok(comment);
        }

        // DELETE api/<CommentsController>/5
        [Authorize(Roles = "manager, admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteByIdAsync(id);
            return Ok();
        }
    }
}
