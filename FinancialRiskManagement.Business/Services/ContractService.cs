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
    public class ContractService : IContractService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContractService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContractDto>> GetAllAsync()
        {
            var contracts = await _unitOfWork.ContractRepository.GetAll().ToListAsync();
            return _mapper.Map<IEnumerable<ContractDto>>(contracts);
        }

        public async Task<ContractDto> GetByIdAsync(int id)
        {
            var contract = await _unitOfWork.ContractRepository.GetByIdAsync(id);
            return _mapper.Map<ContractDto>(contract);
        }

        public async Task AddAsync(ContractDto dto)
        {
            var contract = _mapper.Map<Contract>(dto);
            await _unitOfWork.ContractRepository.AddAsync(contract);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(ContractDto dto)
        {
            var contract = _mapper.Map<Contract>(dto);
            await _unitOfWork.ContractRepository.UpdateAsync(contract);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.ContractRepository.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}
