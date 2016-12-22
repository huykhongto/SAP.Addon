using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SAP.Addon.Domain.Entities.Administration;
using WebCore.Domain;
using SAP.Addon.Domain.Services.Administration;
using WebCore.Domain.Services.Configuration;

namespace AdminLTE_Template1.Areas.Administration.Controllers
{
    public class TerminologiesController : Controller
    {
        private ICategoryService service;

        public TerminologiesController(ICategoryService ts)
        {
            service = ts;
        }

        // GET: Administration/Terminologies
        public ActionResult Index()
        {
            return View(service.Get());
        }

        // GET: Administration/Terminologies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terminology terminology = service.GetTerminology((int)id);
            if (terminology == null)
            {
                return HttpNotFound();
            }
            return View(terminology);
        }

        // GET: Administration/Terminologies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/Terminologies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,OrderId,Code,CreatedUserId,CreatedDate,ModifiedUserId,ModifiedDate,IsDeleted")] Terminology terminology)
        {
            if (ModelState.IsValid)
            {
                service.CreateTerminology(terminology);
                service.SaveTerminology();
                return RedirectToAction("Index");
            }

            return View(terminology);
        }

        // GET: Administration/Terminologies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terminology terminology = service.GetTerminology((int)id);
            if (terminology == null)
            {
                return HttpNotFound();
            }
            return View(terminology);
        }

        // POST: Administration/Terminologies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,OrderId,Code,CreatedUserId,CreatedDate,ModifiedUserId,ModifiedDate,IsDeleted")] Terminology terminology)
        {
            if (ModelState.IsValid)
            {
                service.UpdateTerminology(terminology);
                service.SaveTerminology();
                return RedirectToAction("Index");
            }
            return View(terminology);
        }

        // GET: Administration/Terminologies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terminology terminology = service.GetTerminology((int)id);
            if (terminology == null)
            {
                return HttpNotFound();
            }
            return View(terminology);
        }

        // POST: Administration/Terminologies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            service.RemoveTerminology(id);
            service.SaveTerminology();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
