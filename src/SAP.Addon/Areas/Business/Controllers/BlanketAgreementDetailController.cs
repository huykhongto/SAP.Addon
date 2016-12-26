using SAP.Addon.Controllers;
using SAP.Addon.Domain.Entities.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAP.AddOn.Areas.Business.Controllers
{
    public class BlanketAgreementDetailController : BaseController
    {
        // GET: Business/BlanketAgreementDetail
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddItem()
        {
            var model = new ZOAT1TMP();
            return PartialView("DetailItem", model);
        }
    }
}