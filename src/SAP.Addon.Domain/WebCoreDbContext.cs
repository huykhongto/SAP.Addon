using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCore.Domain.Mappers.Configuration;

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
            Database.SetInitializer<WebCoreDbContext>(null);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new CategoryMapper());
            modelBuilder.Configurations.Add(new CategoryItemMapper());
        }
    }
}
