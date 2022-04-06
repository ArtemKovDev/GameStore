using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using BLL.Validation;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GameService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(GameDto model)
        {
            if (model.Name == "" || model.Description == "" || model.Price < 0)
            {
                throw new ServiceException(string.Join(';', "Model is not valid"));
            }

            var game = _mapper.Map<GameDto, Game>(model);
            await _unitOfWork.GameRepository.AddAsync(game);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            await _unitOfWork.GameRepository.DeleteByIdAsync(modelId);
            await _unitOfWork.SaveAsync();
        }

        public IEnumerable<GameDto> GetAll()
        {
            var games = _unitOfWork.GameRepository.GetAllWithDetails().ToList();
            return _mapper.Map<List<Game>, List<GameDto>>(games);
        }

        public async Task<GameDto> GetByIdAsync(int id)
        {
            var game = await _unitOfWork.GameRepository.GetByIdWithDetailsAsync(id);
            return _mapper.Map<Game, GameDto>(game);
        }

        public async Task UpdateAsync(GameDto model)
        {
            if (model.Name == "" || model.Description == "" || model.Price < 0)
            {
                throw new ServiceException(string.Join(';', "Model is not valid"));
            }

            var game = _mapper.Map<GameDto, Game>(model);
            _unitOfWork.GameRepository.Update(game);
            await _unitOfWork.SaveAsync();
        }
    }
}
