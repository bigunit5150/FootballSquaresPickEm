using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using FSPE.API.DAL.Models;

namespace FSPE.API.DAL
{
    public class PoolManagerContext : DbContext
    {

        public PoolManagerContext()
            : base("PoolManagerContext")
        {
        }

        public DbSet<Pool> Pools { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Square> Squares { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}