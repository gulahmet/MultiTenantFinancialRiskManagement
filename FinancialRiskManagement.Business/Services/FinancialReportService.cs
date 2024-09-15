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
    public class FinancialReportService : IFinancialReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FinancialReportService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FinancialReportDto>> GetAllAsync()
        {
            var reports = await _unitOfWork.FinancialReportRepository.GetAll().ToListAsync();
            return _mapper.Map<IEnumerable<FinancialReportDto>>(reports);
        }

        public async Task<FinancialReportDto> GetByIdAsync(int id)
        {
            var report = await _unitOfWork.FinancialReportRepository.GetByIdAsync(id);
            return _mapper.Map<FinancialReportDto>(report);
        }

        public async Task AddAsync(FinancialReportDto dto)
        {
            var report = _mapper.Map<FinancialReport>(dto);
            await _unitOfWork.FinancialReportRepository.AddAsync(report);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(FinancialReportDto dto)
        {
            var report = _mapper.Map<FinancialReport>(dto);
            await _unitOfWork.FinancialReportRepository.UpdateAsync(report);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.FinancialReportRepository.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}
