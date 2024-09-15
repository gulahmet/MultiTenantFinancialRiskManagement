using FinancialRiskManagement.Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialRiskManagement.Business.Repositories
{
    public interface IRiskAnalysisService
    {
        Task<IEnumerable<RiskAnalysisDto>> GetAllAsync();
        Task<RiskAnalysisDto> GetByIdAsync(int id);
        Task AddAsync(RiskAnalysisDto dto);
        Task UpdateAsync(RiskAnalysisDto dto);
        Task DeleteAsync(int id);
    }
}
