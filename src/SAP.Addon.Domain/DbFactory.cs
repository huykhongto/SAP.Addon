using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCore.Domain.Interfaces;

namespace WebCore.Domain
{
    public class DbFactory : Disposable, IDbFactory
    {
        WebCoreDbContext dbContext;

        public WebCoreDbContext Init()
        {
            return dbContext ?? (dbContext = new WebCoreDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
