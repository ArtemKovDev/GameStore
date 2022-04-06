using AutoMapper;
using BLL.Models;
using BLL.Models.Identity;
using PL.ViewModels.CartLines;
using PL.ViewModels.Comments;
using PL.ViewModels.GameGenres;
using PL.ViewModels.Games;
using PL.ViewModels.Genres;
using PL.ViewModels.Identity;
using PL.ViewModels.Orders;
using PL.ViewModels.PaymentTypes;

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

            CreateMap<GameGenreAddModel, GameGenreDto>();
            CreateMap<GameGenreUpdateModel, GameGenreDto>();

            CreateMap<PaymentTypeAddModel, PaymentTypeDto>();
            CreateMap<PaymentTypeUpdateModel, PaymentTypeDto>();

            CreateMap<OrderAddModel, OrderDto>();
            CreateMap<OrderUpdateModel, OrderDto>();

            CreateMap<CartLineAddModel, CartLineDto>();
            CreateMap<CartLineUpdateModel, CartLineDto>();

            CreateMap<CommentAddModel, CommentDto>();
            CreateMap<CommentUpdateModel, CommentDto>();

            CreateMap<LogonModel, Logon>();
            CreateMap<RegisterModel, Register>();
            CreateMap<RegisterModel, RegisteredUserDto>();

            CreateMap<UserRoleModel, UserRole>();
            CreateMap<UserUpdateModel, RegisteredUserDto>();
        }
    }
}
