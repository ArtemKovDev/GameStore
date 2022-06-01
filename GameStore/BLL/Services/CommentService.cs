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
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(CommentDto model)
        {
            if (model.CommentText == "")
            {
                throw new ServiceException("Model is not valid;");
            }

            var comment = _mapper.Map<CommentDto, Comment>(model);
            await _unitOfWork.CommentRepository.AddAsync(comment);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            await _unitOfWork.CommentRepository.DeleteByIdAsync(modelId);
            await _unitOfWork.SaveAsync();
        }

        public IEnumerable<CommentDto> GetAll()
        {
            var comments = _unitOfWork.CommentRepository.GetAllWithDetails().ToList();
            return _mapper.Map<List<Comment>, List<CommentDto>>(comments);
        }

        public async Task<CommentDto> GetByIdAsync(int id)
        {
            var comment = await _unitOfWork.CommentRepository.GetByIdWithDetailsAsync(id);
            return _mapper.Map<Comment, CommentDto>(comment);
        }

        public async Task UpdateAsync(CommentDto model)
        {
            if (model.CommentText == "")
            {
                throw new ServiceException("Model is not valid;");
            }

            var comment = _mapper.Map<CommentDto, Comment>(model);
            _unitOfWork.CommentRepository.Update(comment);
            await _unitOfWork.SaveAsync();
        }
    }
}
