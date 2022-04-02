using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using BLL.Validation;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GenreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(GenreDto model)
        {
            if(model.Name == "")
            {
                throw new ServiceException(string.Join(';', "Model is not valid"));
            }

            var genre = _mapper.Map<GenreDto, Genre>(model);
            await _unitOfWork.GenreRepository.AddAsync(genre);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            await _unitOfWork.GenreRepository.DeleteByIdAsync(modelId);
            await _unitOfWork.SaveAsync();
        }

        public IEnumerable<GenreDto> GetAll()
        {
            var genres = _unitOfWork.GenreRepository.GetAllWithDetails().ToList();
            return _mapper.Map<List<Genre>, List<GenreDto>>(genres);
        }

        public async Task<GenreDto> GetByIdAsync(int id)
        {
            var genre = await _unitOfWork.GenreRepository.GetByIdWithDetailsAsync(id);
            return _mapper.Map<Genre, GenreDto>(genre);
        }

        public async Task UpdateAsync(GenreDto model)
        {
            if (model.Name == "")
            {
                throw new ServiceException(string.Join(';', "Model is not valid"));
            }

            var genre = _mapper.Map<GenreDto, Genre>(model);
            _unitOfWork.GenreRepository.Update(genre);
            await _unitOfWork.SaveAsync();
        }
    }
}
