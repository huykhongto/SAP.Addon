using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Security
{
    public abstract class BaseViewPage : WebViewPage
    {
        public virtual new WebCorePrincipal User
        {
            get { return base.User as WebCorePrincipal; }
        }
    }
    public abstract class BaseViewPage<TModel> : WebViewPage<TModel>
    {
        public virtual new WebCorePrincipal User
        {
            get { return base.User as WebCorePrincipal; }
        }
    }
}