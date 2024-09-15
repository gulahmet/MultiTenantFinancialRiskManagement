using FinancialRiskManagement.DataAccess.Concrete;
using FinancialRiskManagement.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialRiskManagement.DataAccess.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);

        Task<User> GetUserByUsernameAsync(string username);
        // Kullanıcıya özgü ek metodlar burada olabilir
    }

}
