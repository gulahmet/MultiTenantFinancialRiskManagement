using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialRiskManagement.Business.Dto
{
    public class FinancialReportDto
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public string ReportDetails { get; set; }
    }
}
