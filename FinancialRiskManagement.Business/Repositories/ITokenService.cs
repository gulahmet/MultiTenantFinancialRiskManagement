using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FinancialRiskManagement.Business.Repositories
{
    public interface ITokenService
    {
        Task<string> GenerateTokenAsync(string username);

        Task<ClaimsPrincipal> ValidateTokenAsync(string token);
    }
}
