using FinancialRiskManagement.DataAccess.Model;
using FinancialRiskManagement.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialRiskManagement.DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            BusinessPartnerRepository = new Repository<BusinessPartner>(_context);
            BusinessTopicRepository = new Repository<BusinessTopic>(_context);
            ContractRepository = new Repository<Contract>(_context);
            FinancialReportRepository = new Repository<FinancialReport>(_context);
            RiskAnalysisRepository = new Repository<RiskAnalysis>(_context);
            UserRepository = new UserRepository(_context);
            AgreementEvaluationRepository = new Repository<AgreementEvaluation>(_context);
        }

        public IRepository<BusinessPartner> BusinessPartnerRepository { get; private set; }
        public IRepository<BusinessTopic> BusinessTopicRepository { get; private set; }
        public IRepository<Contract> ContractRepository { get; private set; }
        public IRepository<FinancialReport> FinancialReportRepository { get; private set; }
        public IRepository<RiskAnalysis> RiskAnalysisRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }
        public IRepository<AgreementEvaluation> AgreementEvaluationRepository { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
