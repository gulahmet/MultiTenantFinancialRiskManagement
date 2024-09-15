using FinancialRiskManagement.Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialRiskManagement.Business.Repositories
{
    public interface IFinancialReportService
    {
        Task<IEnumerable<FinancialReportDto>> GetAllAsync();
        Task<FinancialReportDto> GetByIdAsync(int id);
        Task AddAsync(FinancialReportDto dto);
        Task UpdateAsync(FinancialReportDto dto);
        Task DeleteAsync(int id);
    }
}
