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
    public class PaymentTypeService : IPaymentTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(PaymentTypeDto model)
        {
            if (model.Name == "")
            {
                throw new ServiceException(string.Join(';', "Model is not valid"));
            }

            var paymentType = _mapper.Map<PaymentTypeDto, PaymentType>(model);
            await _unitOfWork.PaymentTypeRepository.AddAsync(paymentType);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            await _unitOfWork.PaymentTypeRepository.DeleteByIdAsync(modelId);
            await _unitOfWork.SaveAsync();
        }

        public IEnumerable<PaymentTypeDto> GetAll()
        {
            var paymentType = _unitOfWork.PaymentTypeRepository.GetAllWithDetails().ToList();
            return _mapper.Map<List<PaymentType>, List<PaymentTypeDto>>(paymentType);
        }

        public async Task<PaymentTypeDto> GetByIdAsync(int id)
        {
            var paymentType = await _unitOfWork.PaymentTypeRepository.GetByIdWithDetailsAsync(id);
            return _mapper.Map<PaymentType, PaymentTypeDto>(paymentType);
        }

        public async Task UpdateAsync(PaymentTypeDto model)
        {
            if (model.Name == "")
            {
                throw new ServiceException(string.Join(';', "Model is not valid"));
            }

            var paymentType = _mapper.Map<PaymentTypeDto, PaymentType>(model);
            _unitOfWork.PaymentTypeRepository.Update(paymentType);
            await _unitOfWork.SaveAsync();
        }
    }
}
