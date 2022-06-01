using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PL.ViewModels.GameSearch;
using System.Collections.Generic;

namespace PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameSearchController : ControllerBase
    {
        private readonly IGameSearchService _service;

        public GameSearchController(IGameSearchService service)
        {
            _service = service;
        }

        [HttpPost("genre")]
        public IEnumerable<GameDto> GetGamesByGenres(SearchByGenresModel model)
        {
            return _service.GetGamesByGenre(model.GenreIds);
        }

        [HttpPost("name")]
        public IEnumerable<GameDto> GetGamesByName(SearchByGameNameModel model)
        {
            return _service.GetGamesByName(model.GameName);
        }
    }
}
