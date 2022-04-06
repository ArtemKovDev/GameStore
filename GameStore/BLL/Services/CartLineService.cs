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
    public class CartLineService : ICartLineService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CartLineService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(CartLineDto model)
        {
            if (model.Quantity < 0)
            {
                throw new ServiceException(string.Join(';', "Model is not valid"));
            }

            var cartLine = _mapper.Map<CartLineDto, CartLine>(model);
            await _unitOfWork.CartLineRepository.AddAsync(cartLine);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            await _unitOfWork.CartLineRepository.DeleteByIdAsync(modelId);
            await _unitOfWork.SaveAsync();
        }

        public IEnumerable<CartLineDto> GetAll()
        {
            var cartLine = _unitOfWork.CartLineRepository.GetAllWithDetails().ToList();
            return _mapper.Map<List<CartLine>, List<CartLineDto>>(cartLine);
        }

        public async Task<CartLineDto> GetByIdAsync(int id)
        {
            var cartLine = await _unitOfWork.CartLineRepository.GetByIdWithDetailsAsync(id);
            return _mapper.Map<CartLine, CartLineDto>(cartLine);
        }

        public async Task UpdateAsync(CartLineDto model)
        {
            if (model.Quantity < 0)
            {
                throw new ServiceException(string.Join(';', "Model is not valid"));
            }

            var cartLine = _mapper.Map<CartLineDto, CartLine>(model);
            _unitOfWork.CartLineRepository.Update(cartLine);
            await _unitOfWork.SaveAsync();
        }
    }
}
