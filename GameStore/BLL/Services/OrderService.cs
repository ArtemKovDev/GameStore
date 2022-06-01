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
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(OrderDto model)
        {
            if (model.FirstName == "" || model.LastName == "" || model.Email == "" || model.Phone == "")
            {
                throw new ServiceException("Model is not valid;");
            }

            var order = _mapper.Map<OrderDto, Order>(model);
            await _unitOfWork.OrderRepository.AddAsync(order);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            await _unitOfWork.OrderRepository.DeleteByIdAsync(modelId);
            await _unitOfWork.SaveAsync();
        }

        public IEnumerable<OrderDto> GetAll()
        {
            var order = _unitOfWork.OrderRepository.GetAllWithDetails().ToList();
            return _mapper.Map<List<Order>, List<OrderDto>>(order);
        }

        public async Task<OrderDto> GetByIdAsync(int id)
        {
            var order = await _unitOfWork.OrderRepository.GetByIdWithDetailsAsync(id);
            return _mapper.Map<Order, OrderDto>(order);
        }

        public async Task UpdateAsync(OrderDto model)
        {
            if (model.FirstName == "" || model.LastName == "" || model.Email == "" || model.Phone == "")
            {
                throw new ServiceException("Model is not valid;");
            }

            var order = _mapper.Map<OrderDto, Order>(model);
            _unitOfWork.OrderRepository.Update(order);
            await _unitOfWork.SaveAsync();
        }
    }
}
