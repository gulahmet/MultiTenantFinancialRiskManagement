using FinancialRiskManagement.Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialRiskManagement.Business.Repositories
{
    public interface IBusinessPartnerService
    {
        Task<IEnumerable<BusinessPartnerDto>> GetAllAsync();
        Task<BusinessPartnerDto> GetByIdAsync(int id);
        Task<OperationResult> AddAsync(CreateBusinessPartnerDto dto);
        Task<OperationResult> UpdateAsync(BusinessPartnerDto dto);
        Task<OperationResult> DeleteAsync(int id);
    }
}
