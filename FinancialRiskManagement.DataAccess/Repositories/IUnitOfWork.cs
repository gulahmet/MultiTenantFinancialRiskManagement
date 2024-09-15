using FinancialRiskManagement.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialRiskManagement.DataAccess.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<BusinessPartner> BusinessPartnerRepository { get; }
        IRepository<BusinessTopic> BusinessTopicRepository { get; }
        IRepository<Contract> ContractRepository { get; }
        IRepository<FinancialReport> FinancialReportRepository { get; }
        IRepository<RiskAnalysis> RiskAnalysisRepository { get; }
        IUserRepository UserRepository { get; }
        IRepository<AgreementEvaluation> AgreementEvaluationRepository { get; }

        Task<int> CompleteAsync();
    }
}
