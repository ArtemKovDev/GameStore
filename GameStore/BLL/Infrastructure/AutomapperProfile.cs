using AutoMapper;
using BLL.Models;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                .ForMember(dest => dest.GameGenreIds, opt => opt.MapFrom(src => src.Genres.Select(x => x.Id)))
                .ForMember(dest => dest.CommentIds, opt => opt.MapFrom(src => src.Comments.Select(x => x.Id)))
                .ForMember(dest => dest.CartLineIds, opt => opt.MapFrom(src => src.CartLines.Select(x => x.Id)))
                .ReverseMap();
            CreateMap<GameGenre, GameGenreDto>()
                .ReverseMap();
            CreateMap<Genre, GenreDto>()
                .ForMember(dest => dest.GameGenreIds, opt => opt.MapFrom(src => src.Games.Select(x => x.Id)))
                .ReverseMap();
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.CartLineIds, opt => opt.MapFrom(src => src.CartLines.Select(x => x.Id)))
                .ReverseMap();
            CreateMap<PaymentType, PaymentTypeDto>()
                .ForMember(dest => dest.OrderIds, opt => opt.MapFrom(src => src.Orders.Select(x => x.Id)))
                .ReverseMap();
            CreateMap<RegisteredUser, RegisteredUserDto>()
                .ForMember(dest => dest.CommentIds, opt => opt.MapFrom(src => src.Comments.Select(x => x.Id)))
                .ReverseMap();
        }
    }
}
