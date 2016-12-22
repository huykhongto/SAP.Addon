using Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAP.Addon.Controllers
{
    [WebCoreAuthorizeAttribute]
    public class BaseController : Controller
    {
        // GET: Base
        public WebCorePrincipal CurrentUser { get { return (User as WebCorePrincipal); } }
    }
}