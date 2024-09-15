using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialRiskManagement.DataAccess.Model
{
    public class Contract : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public ICollection<BusinessTopic> BusinessTopics { get; set; } = new List<BusinessTopic>();
        public ICollection<FinancialReport> FinancialReports { get; set; } = new List<FinancialReport>();

        public ICollection<AgreementEvaluation> AgreementEvaluations { get; set; } = new List<AgreementEvaluation>();



        

        public Contract(string name, string description, DateTime effectiveDate, DateTime expiryDate)
        {
            Name = name;
            Description = description;
            EffectiveDate = effectiveDate;
            ExpiryDate = expiryDate;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
