using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialRiskManagement.DataAccess.Model
{
    public class FinancialReport : BaseEntity
    {
        public int ContractId { get; set; }
        public Contract Contract { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal NetProfit { get; set; }
        public DateTime ReportDate { get; set; }

        public FinancialReport(int contractId, decimal totalRevenue, decimal totalExpense, decimal netProfit, DateTime reportDate)
        {
            ContractId = contractId;
            TotalRevenue = totalRevenue;
            TotalExpense = totalExpense;
            NetProfit = netProfit;
            ReportDate = reportDate;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
