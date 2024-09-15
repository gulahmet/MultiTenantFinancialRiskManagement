using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialRiskManagement.DataAccess.Model
{
    public class BusinessTopic : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public string Name { get; set; }
        public int ContractId { get; set; }
        public Contract Contract { get; set; }
        public int BusinessPartnerId { get; set; }
        public BusinessPartner BusinessPartner { get; set; }
        public ICollection<RiskAnalysis> RiskAnalyses { get; set; } = new List<RiskAnalysis>();

        public BusinessTopic(string title, string description, int contractId, int businessPartnerId)
        {
            Title = title;
            Description = description;
            ContractId = contractId;
            BusinessPartnerId = businessPartnerId;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
