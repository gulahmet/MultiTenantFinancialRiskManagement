using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialRiskManagement.DataAccess.Model
{
    public class AgreementEvaluation : BaseEntity
    {
        public int ContractId { get; set; }
        public Contract Contract { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string EvaluationResult { get; set; }
        public DateTime EvaluationDate { get; set; }

        public ICollection<AgreementEvaluation> AgreementEvaluations { get; set; } = new List<AgreementEvaluation>();

        public AgreementEvaluation(int contractId, int userId, string evaluationResult, DateTime evaluationDate)
        {
            ContractId = contractId;
            UserId = userId;
            EvaluationResult = evaluationResult;
            EvaluationDate = evaluationDate;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
