using FinancialRiskManagement.Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialRiskManagement.Business.Repositories
{
    public interface IContractService
    {
        Task<IEnumerable<ContractDto>> GetAllAsync();
        Task<ContractDto> GetByIdAsync(int id);
        Task AddAsync(ContractDto dto);
        Task UpdateAsync(ContractDto dto);
        Task DeleteAsync(int id);
    }
}
