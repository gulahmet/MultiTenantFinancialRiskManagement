using FinancialRiskManagement.DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialRiskManagement.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<BusinessPartner> BusinessPartners { get; set; }
        public DbSet<BusinessTopic> BusinessTopics { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<RiskAnalysis> RiskAnalyses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FinancialReport> FinancialReports { get; set; }
        public DbSet<AgreementEvaluation> AgreementEvaluations { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // BusinessPartner ve BusinessTopic arasında bire çok ilişki
            modelBuilder.Entity<BusinessPartner>()
                .HasMany(bp => bp.BusinessTopics)
                .WithOne(bt => bt.BusinessPartner)
                .HasForeignKey(bt => bt.BusinessPartnerId);

            // BusinessTopic ve RiskAnalysis arasında bire çok ilişki
            modelBuilder.Entity<BusinessTopic>()
                .HasMany(bt => bt.RiskAnalyses)
                .WithOne(ra => ra.BusinessTopic)
                .HasForeignKey(ra => ra.BusinessTopicId);

            // Contract ve BusinessTopic arasında bire çok ilişki
            modelBuilder.Entity<Contract>()
                .HasMany(c => c.BusinessTopics)
                .WithOne(bt => bt.Contract)
                .HasForeignKey(bt => bt.ContractId);

            // Contract ve FinancialReport arasında bire çok ilişki
            modelBuilder.Entity<Contract>()
                .HasMany(c => c.FinancialReports)
                .WithOne(fr => fr.Contract)
                .HasForeignKey(fr => fr.ContractId);

            // Contract ve AgreementEvaluation arasında bire çok ilişki
            modelBuilder.Entity<Contract>()
                .HasMany(c => c.AgreementEvaluations)
                .WithOne(ae => ae.Contract)
                .HasForeignKey(ae => ae.ContractId);

            // AgreementEvaluation ve User arasında bire çok ilişki
            modelBuilder.Entity<AgreementEvaluation>()
                .HasOne(ae => ae.User)
                .WithMany(u => u.AgreementEvaluations)
                .HasForeignKey(ae => ae.UserId);

            modelBuilder.Entity<User>()
             .HasIndex(u => u.UserName)
             .IsUnique();


        }
    }
}
