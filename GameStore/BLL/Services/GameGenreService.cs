using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class GameGenreService : IGameGenreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GameGenreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(GameGenreDto model)
        {
            var gameGenre = _mapper.Map<GameGenreDto, GameGenre>(model);
            await _unitOfWork.GameGenreRepository.AddAsync(gameGenre);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            await _unitOfWork.GameGenreRepository.DeleteByIdAsync(modelId);
            await _unitOfWork.SaveAsync();
        }

        public IEnumerable<GameGenreDto> GetAll()
        {
            var gameGenres = _unitOfWork.GameGenreRepository.GetAllWithDetails().ToList();
            return _mapper.Map<List<GameGenre>, List<GameGenreDto>>(gameGenres);
        }

        public async Task<GameGenreDto> GetByIdAsync(int id)
        {
            var gameGenre = await _unitOfWork.GameGenreRepository.GetByIdWithDetailsAsync(id);
            return _mapper.Map<GameGenre, GameGenreDto>(gameGenre);
        }

        public async Task UpdateAsync(GameGenreDto model)
        {
            var gameGenre = _mapper.Map<GameGenreDto, GameGenre>(model);
            _unitOfWork.GameGenreRepository.Update(gameGenre);
            await _unitOfWork.SaveAsync();
        }
    }
}
