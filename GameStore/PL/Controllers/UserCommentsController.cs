using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PL.Filters;
using PL.ViewModels.UserComments;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Controllers
{
    [CustomExceptionFilter]
    [ModelStateActionFilter]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserCommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IRegisteredUserService _registeredUserService;
        private readonly IMapper _mapper;

        public UserCommentsController(ICommentService commentService,
            IRegisteredUserService registeredUserService,
            IMapper mapper)
        {
            _commentService = commentService;
            _registeredUserService = registeredUserService;
            _mapper = mapper;
        }

        // POST api/<UserCommentsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserCommentAddModel model)
        {
            var comment = _mapper.Map<UserCommentAddModel, CommentDto>(model);

            var user = _registeredUserService.GetAll().SingleOrDefault(u => u.UserName == User.Identity.Name);

            comment.RegisteredUserId = user.Id;

            comment.CommentDate = System.DateTime.Now;

            await _commentService.AddAsync(comment);
            return Ok(comment);
        }

        // PUT api/<UserCommentsController>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UserCommentUpdateModel model)
        {
            var user = _registeredUserService.GetAll().SingleOrDefault(u => u.UserName == User.Identity.Name);

            var comment = await _commentService.GetByIdAsync(model.Id);

            if (comment != null && comment.RegisteredUserId == user.Id)
            {
                var updateComment = _mapper.Map<UserCommentUpdateModel, CommentDto>(model);

                updateComment.RegisteredUserId = user.Id;
                updateComment.CommentDate = System.DateTime.Now;

                await _commentService.UpdateAsync(updateComment);
                return Ok(updateComment);
            }
            else
            {
                return StatusCode(403);
            }
        }

        // DELETE api/<UserCommentsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = _registeredUserService.GetAll().SingleOrDefault(u => u.UserName == User.Identity.Name);

            var comment = await _commentService.GetByIdAsync(id);

            if (comment != null && comment.RegisteredUserId == user.Id)
            {
                await _commentService.DeleteByIdAsync(id);
                return Ok();
            }
            else
            {
                return StatusCode(403);
            }
        }
    }
}
