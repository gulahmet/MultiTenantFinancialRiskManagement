using FinancialRiskManagement.Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialRiskManagement.Business.Repositories
{
    public interface IAgreementEvaluationService
    {
        Task<IEnumerable<AgreementEvaluationDto>> GetAllAsync();
        Task<AgreementEvaluationDto> GetByIdAsync(int id);
        Task AddAsync(AgreementEvaluationDto dto);
        Task UpdateAsync(AgreementEvaluationDto dto);
        Task DeleteAsync(int id);
    }
}
