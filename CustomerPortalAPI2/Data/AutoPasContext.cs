using Microsoft.EntityFrameworkCore;
using CustomerPortalAPI2.Models;

namespace CustomerPortalAPI2.Data
{
    public class AutoPasContext : DbContext
    {
        public AutoPasContext(DbContextOptions<AutoPasContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<PolicyHolderDetails> PolicyHolderDetails { get; set; }
        public DbSet<CoverageDetails> CoverageDetails { get; set; }
        public DbSet<VehicleDetails> VehicleDetails { get; set; }
        public DbSet<UserPolicyList> UserPolicyLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("portalKAG_Users");
            modelBuilder.Entity<Policy>().ToTable("policy");
            modelBuilder.Entity<PolicyHolderDetails>().ToTable("insured");
            modelBuilder.Entity<CoverageDetails>().ToTable("policycoverage");
            modelBuilder.Entity<VehicleDetails>().ToTable("vehicle");
            modelBuilder.Entity<UserPolicyList>().ToTable("portalKAG_UserPolicyList");

            modelBuilder.Entity<UserPolicyList>()
                .HasKey(upl => new { upl.UserId, upl.PolicyNumber });

            modelBuilder.Entity<UserPolicyList>()
                .HasOne(upl => upl.User)
                .WithMany(u => u.UserPolicyLists)
                .HasForeignKey(upl => upl.UserId);

            modelBuilder.Entity<UserPolicyList>()
                .HasOne(upl => upl.Policy)
                .WithMany(p => p.UserPolicyLists)
                .HasForeignKey(upl => upl.PolicyNumber);
        }
    }
}
