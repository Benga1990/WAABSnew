using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WAABSnew.Models;


namespace WAABSnew.DataAccessLayer
{
    public class WAABSContext : DbContext
    {
        public WAABSContext() : base("WAABSContext")
        {
        }

        public DbSet<BuyerModel> BuyerModels { get; set; }
        public DbSet<SellerModel> SellerModels { get; set; }
        public DbSet<BankModel> BankModels { get; set; }
        public DbSet<EstateAgentModel> EstateAgentModels { get; set; }
        public DbSet<SolicitorModel> SolicitorModels { get; set; }
        public DbSet<JobModel> JobModels { get; set; }
        public DbSet<AssistantModel> AssistantModels { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}