using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace BLL.Infrastructure
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<CartLine, CartLineDto>()
                .ReverseMap();
            CreateMap<Comment, CommentDto>()
                .ReverseMap();
            CreateMap<Game, GameDto>()
                .ReverseMap();
            CreateMap<GameGenre, GameGenreDto>()
                .ReverseMap();
            CreateMap<Genre, GenreDto>()
                .ReverseMap();
            CreateMap<Order, OrderDto>()
                .ReverseMap();
            CreateMap<PaymentType, PaymentTypeDto>()
                .ReverseMap();
            CreateMap<RegisteredUser, RegisteredUserDto>()
                .ReverseMap();
        }
    }
}
