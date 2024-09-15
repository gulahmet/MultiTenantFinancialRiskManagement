using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialRiskManagement.Business.Dto
{
    public class RiskAnalysisDto
    {

        public int Id { get; set; }
        public string RiskDescription { get; set; }
        public decimal RiskAmount { get; set; }
    }
}
