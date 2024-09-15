using FinancialRiskManagement.Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialRiskManagement.Business.Repositories
{
    public interface IBusinessTopicService
    {
        Task<IEnumerable<BusinessTopicDto>> GetAllAsync();
        Task<BusinessTopicDto> GetByIdAsync(int id);
        Task AddAsync(BusinessTopicDto dto);
        Task UpdateAsync(BusinessTopicDto dto);
        Task DeleteAsync(int id);
    }
}
