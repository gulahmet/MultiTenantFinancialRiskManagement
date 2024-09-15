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
    public class BusinessPartnerService : IBusinessPartnerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BusinessPartnerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BusinessPartnerDto>> GetAllAsync()
        {
            var partners = await _unitOfWork.BusinessPartnerRepository.GetAll().ToListAsync();
            return _mapper.Map<IEnumerable<BusinessPartnerDto>>(partners);
        }

        public async Task<BusinessPartnerDto> GetByIdAsync(int id)
        {
            var partner = await _unitOfWork.BusinessPartnerRepository.GetByIdAsync(id);
            return _mapper.Map<BusinessPartnerDto>(partner);
        }

        public async Task<OperationResult> AddAsync(CreateBusinessPartnerDto dto)
        {
            var partner = _mapper.Map<BusinessPartner>(dto);
            var result = new OperationResult();

            try
            {
                await _unitOfWork.BusinessPartnerRepository.AddAsync(partner);
                await _unitOfWork.CompleteAsync();

                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false; // İşlem başarısız
                result.ErrorMessage = ex.Message; // Hata mesajını döndür
            }
            return result;
        }

        public async Task<OperationResult> UpdateAsync(BusinessPartnerDto dto)
        {
            var result = new OperationResult();

            try
            {
                var partner = _mapper.Map<BusinessPartner>(dto);
                await _unitOfWork.BusinessPartnerRepository.UpdateAsync(partner);
                await _unitOfWork.CompleteAsync();
                result.Success = true; // İşlem başarılı
            }
            catch (Exception ex)
            {
                result.Success = false; // İşlem başarısız
                result.ErrorMessage = ex.Message; // Hata mesajını döndür
            }

            return result;
        }

        public async Task<OperationResult> DeleteAsync(int id)
        {
            var result = new OperationResult();

            try
            {
                await _unitOfWork.BusinessPartnerRepository.DeleteAsync(id);
                await _unitOfWork.CompleteAsync();
                result.Success = true; // İşlem başarılı
            }
            catch (Exception ex)
            {
                result.Success = false; // İşlem başarısız
                result.ErrorMessage = ex.Message; // Hata mesajını döndür
            }

            return result;
        }
    }
}
