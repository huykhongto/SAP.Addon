using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using SAP.Addon.Controllers;
using SAP.Addon.Domain.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAP.Addon.Areas.Business.Controllers
{
    public class BlanketAgreementController : BaseController
    {
        private BlanketAgreementService service;
        public BlanketAgreementController(BlanketAgreementService service)
        {
            this.service = service;
        }

        // GET: Business/BlanketAgreement
        public ActionResult Index()
        {
            //var model = service.GetAgreements();
            return View();
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(service.GetAgreements().ToDataSourceResult(request));
        }

        // GET: Business/BlanketAgreement/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Business/BlanketAgreement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Business/BlanketAgreement/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Business/BlanketAgreement/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Business/BlanketAgreement/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Business/BlanketAgreement/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Business/BlanketAgreement/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
