using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Conventions;
using FSPE.API.DAL.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FSPE.API.DAL
{
    public class PoolManagerContext : IdentityDbContext<ApplicationUser>
    {

        public PoolManagerContext()
            : base("PoolManagerDBConnection",throwIfV1Schema:false)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }


        public DbSet<Pool> Pools { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Square> Squares { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public static PoolManagerContext Create()
        {
            return new PoolManagerContext();
        }
    }
}