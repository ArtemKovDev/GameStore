using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using BLL.Validation;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Services
{
    public class GameSearchService : IGameSearchService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GameSearchService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public IEnumerable<GameDto> GetGamesByName(string name)
        {
            if(name.Length >= 3)
            {
                //var games = _unitOfWork.GameRepository.GetAllWithDetails().
                //    Where(gm => gm.Name.StartsWith(name));

                IQueryable<Game> queryableData = _unitOfWork.GameRepository.GetAllWithDetails();

                ParameterExpression gm = Expression.Parameter(typeof(Game), "gm");

                Expression gameNameProperty = Expression.Property(gm, typeof(Game).GetProperty("Name"));

                Expression nameParametr = Expression.Constant(name, typeof(string));

                Expression predicateBody = Expression.Call(gameNameProperty, typeof(string).
                    GetMethod("StartsWith", new Type[] { typeof(string)}), nameParametr);

                MethodCallExpression whereCallExpression = Expression.Call(
                    typeof(Queryable),
                    "Where",
                    new Type[] {queryableData.ElementType},
                    queryableData.Expression,
                    Expression.Lambda<Func<Game, bool>>(predicateBody, new ParameterExpression[] {gm}));

                IQueryable<Game> games = queryableData.Provider.CreateQuery<Game>(whereCallExpression);

                return _mapper.Map<List<Game>, List<GameDto>>(games.ToList());
            }
            else
            {
                throw new ServiceException(string.Join(';', "Model is not valid"));
            }
        }

        public IEnumerable<GameDto> GetGamesByGenre(int[] genreIds)
        {
            var games = _unitOfWork.GameRepository.GetAllWithDetails().ToList().
                Where(gm => !genreIds.Except(gm.Genres.Select(g => g.GenreId)).Any());

            return _mapper.Map<List<Game>, List<GameDto>>(games.ToList());
        }
    }
}
