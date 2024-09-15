using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialRiskManagement.DataAccess.Model
{
    public  class RiskAnalysis : BaseEntity
    {
        public int BusinessTopicId { get; set; }
        public BusinessTopic BusinessTopic { get; set; }
        public decimal RiskAmount { get; set; }
        public DateTime AnalysisDate { get; set; }

        public RiskAnalysis(int businessTopicId, decimal riskAmount, DateTime analysisDate)
        {
            BusinessTopicId = businessTopicId;
            RiskAmount = riskAmount;
            AnalysisDate = analysisDate;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
