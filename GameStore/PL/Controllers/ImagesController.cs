using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PL.Filters;
using PL.ViewModels.Games;
using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PL.Controllers
{
    [CustomExceptionFilter]
    [ModelStateActionFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        [HttpPost("game")]
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
                    fileName = new Guid().ToString() + ext;

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
    }
}
