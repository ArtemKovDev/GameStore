using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PL.Filters;
using PL.Services;

namespace PL.Controllers
{
    [CustomExceptionFilter]
    [ModelStateActionFilter]
    [Authorize(Roles = "manager, admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class GameImagesController : ControllerBase
    {
        [HttpPost("upload")]
        public IActionResult UploadGameImage(IFormFile file)
        {
            string imageUrl = ImageService.UploadGameImage(file, "Images\\Games");

            return Ok(new { imageUrl });
        }

        [HttpDelete("delete/{imageUrl}")]
        public IActionResult Delete(string imageUrl)
        {
            if (imageUrl.Contains("Games", System.StringComparison.OrdinalIgnoreCase))
            {
                ImageService.Delete(imageUrl);

                return Ok();
            }
            else
            {
                return BadRequest();
            }
            
        }
    }
}
