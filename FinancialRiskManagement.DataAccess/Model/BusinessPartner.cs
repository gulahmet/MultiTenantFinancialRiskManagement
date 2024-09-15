using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialRiskManagement.DataAccess.Model
{
    public class BusinessPartner : BaseEntity
    {
        public string Name { get; set; }
        public string ContactInfo { get; set; }
        public ICollection<BusinessTopic> BusinessTopics { get; set; } = new List<BusinessTopic>();

        public BusinessPartner(string name, string contactInfo)
        {
            Name = name;
            ContactInfo = contactInfo;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
