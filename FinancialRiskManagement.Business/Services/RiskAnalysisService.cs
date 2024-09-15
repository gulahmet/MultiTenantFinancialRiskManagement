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
    public class RiskAnalysisService : IRiskAnalysisService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RiskAnalysisService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RiskAnalysisDto>> GetAllAsync()
        {
            var risks = await _unitOfWork.RiskAnalysisRepository.GetAll().ToListAsync();
            return _mapper.Map<IEnumerable<RiskAnalysisDto>>(risks);
        }

        public async Task<RiskAnalysisDto> GetByIdAsync(int id)
        {
            var risk = await _unitOfWork.RiskAnalysisRepository.GetByIdAsync(id);
            return _mapper.Map<RiskAnalysisDto>(risk);
        }

        public async Task AddAsync(RiskAnalysisDto dto)
        {
            var risk = _mapper.Map<RiskAnalysis>(dto);
            await _unitOfWork.RiskAnalysisRepository.AddAsync(risk);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(RiskAnalysisDto dto)
        {
            var risk = _mapper.Map<RiskAnalysis>(dto);
            await _unitOfWork.RiskAnalysisRepository.UpdateAsync(risk);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.RiskAnalysisRepository.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}
