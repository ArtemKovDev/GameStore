using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PL.Filters;
using System;
using System.IO;
using System.Net.Http.Headers;

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
            var folderName = Path.Combine("wwwroot", "Images\\Games");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                string ext = Path.GetExtension(fileName);

                if (ext == ".jpg" || ext == ".jpeg")
                {
                    fileName = Guid.NewGuid().ToString() + ext;

                    var fullPath = Path.Combine(pathToSave, fileName);
                    var imageUrl = Path.Combine("Images\\Games", fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(new { imageUrl });
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete/{imageUrl}")]
        public IActionResult Delete(string imageUrl)
        {
            var folderName = Path.Combine("wwwroot", imageUrl);
            var pathToDelete = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            if (System.IO.File.Exists(pathToDelete))
            {
                System.IO.File.Delete(pathToDelete);

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
