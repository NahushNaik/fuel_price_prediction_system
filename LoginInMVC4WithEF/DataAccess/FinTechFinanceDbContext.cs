
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTech.DataAccess
{
    public class FinTechFinanceDbContext : DbContext
    {
        public FinTechFinanceDbContext() : base("Name=DestinationDBContext")
        {

            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer<FinTechFinanceDbContext>(null);
        }

      

        //SystemMaster Dbset Creation End

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Configurations.AddFromAssembly(typeof(FinTechFinanceDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
