using SAP.Addon.Domain.Mapping.Administration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCore.Domain
{
    public class WebCoreDbContext : DbContext
    {
        public WebCoreDbContext() : base("name=ConnectionString") { }

        public virtual int Commit()
        {
            return base.SaveChanges();
        }
 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new TerminologyConfiguration());
            modelBuilder.Configurations.Add(new TerminologyItemConfiguration());
        }

        //public System.Data.Entity.DbSet<SAP.Addon.Domain.Entities.Administration.Terminology> Terminologies { get; set; }
    }
}
