using AutoMapper;
using BLL.Models;
using PL.ViewModels.Games;
using PL.ViewModels.Genres;

namespace PL.Infrastructure
{
    public class ViewAutomapperProfile : Profile
    {
        public ViewAutomapperProfile()
        {
            CreateMap<GenreAddModel, GenreDto>();
            CreateMap<GenreUpdateModel, GenreDto>();

            CreateMap<GameAddModel, GameDto>();
            CreateMap<GameUpdateModel, GameDto>();
        }
    }
}
