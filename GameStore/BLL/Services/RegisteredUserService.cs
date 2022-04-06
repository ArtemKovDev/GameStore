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
    public class RegisteredUserService : IRegisteredUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegisteredUserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(RegisteredUserDto model)
        {
            if (model.UserName == "" || model.FirstName == "" || model.LastName == "")
            {
                throw new ServiceException(string.Join(';', "Model is not valid"));
            }

            var user = _mapper.Map<RegisteredUserDto, RegisteredUser>(model);
            await _unitOfWork.RegisteredUserRepository.AddAsync(user);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            await _unitOfWork.RegisteredUserRepository.DeleteByIdAsync(modelId);
            await _unitOfWork.SaveAsync();
        }

        public IEnumerable<RegisteredUserDto> GetAll()
        {
            var users = _unitOfWork.RegisteredUserRepository.GetAllWithDetails().ToList();
            return _mapper.Map<List<RegisteredUser>, List<RegisteredUserDto>>(users);
        }

        public async Task<RegisteredUserDto> GetByIdAsync(int id)
        {
            var user = await _unitOfWork.RegisteredUserRepository.GetByIdWithDetailsAsync(id);
            return _mapper.Map<RegisteredUser, RegisteredUserDto>(user);
        }

        public async Task UpdateAsync(RegisteredUserDto model)
        {
            if (model.UserName == "" || model.FirstName == "" || model.LastName == "")
            {
                throw new ServiceException(string.Join(';', "Model is not valid"));
            }

            var user = _mapper.Map<RegisteredUserDto, RegisteredUser>(model);
            _unitOfWork.RegisteredUserRepository.Update(user);
            await _unitOfWork.SaveAsync();
        }
    }
}
