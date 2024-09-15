using AutoMapper;
using FinancialRiskManagement.Business.Dto;
using FinancialRiskManagement.Business.Repositories;
using FinancialRiskManagement.DataAccess.Model;
using FinancialRiskManagement.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialRiskManagement.Business.Services
{
    public class BusinessTopicService : IBusinessTopicService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BusinessTopicService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BusinessTopicDto>> GetAllAsync()
        {
            var topics = await _unitOfWork.BusinessTopicRepository.GetAll().ToListAsync();
            return _mapper.Map<IEnumerable<BusinessTopicDto>>(topics);
        }

        public async Task<BusinessTopicDto> GetByIdAsync(int id)
        {
            var topic = await _unitOfWork.BusinessTopicRepository.GetByIdAsync(id);
            return _mapper.Map<BusinessTopicDto>(topic);
        }

        public async Task AddAsync(BusinessTopicDto dto)
        {
            var topic = _mapper.Map<BusinessTopic>(dto);
            await _unitOfWork.BusinessTopicRepository.AddAsync(topic);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(BusinessTopicDto dto)
        {
            var topic = _mapper.Map<BusinessTopic>(dto);
            await _unitOfWork.BusinessTopicRepository.UpdateAsync(topic);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.BusinessTopicRepository.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}
