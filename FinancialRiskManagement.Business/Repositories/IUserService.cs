using FinancialRiskManagement.Business.Dto;
using FinancialRiskManagement.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialRiskManagement.Business.Repositories
{
    public interface IUserService
    {
        Task<UserDto> GetUserByIdAsync(int id);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<User> GetUserByUsernameAsync(LoginDto loginDto);
        Task UpdateUserAsync(UserDto userDto);

        Task AddUserAsync(UserDto userDto);
        Task DeleteUserAsync(int id);

     
    }
}
