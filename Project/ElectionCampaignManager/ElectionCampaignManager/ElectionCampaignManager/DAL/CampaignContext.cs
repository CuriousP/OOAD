using ElectionCampaignManager.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ElectionCampaignManager.DAL
{
    public class CampaignContext : DbContext
    {
        public CampaignContext() : base("CampaignContext")
        {
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Proposition> Propositions { get; set; }
        public DbSet<Voter> Voters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<ElectionCampaignManager.Models.CandidateProposition> CandidatePropositions { get; set; }

        public System.Data.Entity.DbSet<ElectionCampaignManager.Models.VoterProposition> VoterPropositions { get; set; }

        public System.Data.Entity.DbSet<ElectionCampaignManager.Models.VoterCategory> VoterCategories { get; set; }

        public System.Data.Entity.DbSet<ElectionCampaignManager.Models.VendorPayment> VendorPayments { get; set; }
    }
}