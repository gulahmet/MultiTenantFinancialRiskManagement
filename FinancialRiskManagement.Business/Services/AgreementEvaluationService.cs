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
    public class AgreementEvaluationService : IAgreementEvaluationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AgreementEvaluationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AgreementEvaluationDto>> GetAllAsync()
        {
            var evaluations = await _unitOfWork.AgreementEvaluationRepository.GetAll().ToListAsync();
            return _mapper.Map<IEnumerable<AgreementEvaluationDto>>(evaluations);
        }

        public async Task<AgreementEvaluationDto> GetByIdAsync(int id)
        {
            var evaluation = await _unitOfWork.AgreementEvaluationRepository.GetByIdAsync(id);
            return _mapper.Map<AgreementEvaluationDto>(evaluation);
        }

        public async Task AddAsync(AgreementEvaluationDto dto)
        {
            var evaluation = _mapper.Map<AgreementEvaluation>(dto);
            await _unitOfWork.AgreementEvaluationRepository.AddAsync(evaluation);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(AgreementEvaluationDto dto)
        {
            var evaluation = _mapper.Map<AgreementEvaluation>(dto);
            await _unitOfWork.AgreementEvaluationRepository.UpdateAsync(evaluation);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.AgreementEvaluationRepository.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}
