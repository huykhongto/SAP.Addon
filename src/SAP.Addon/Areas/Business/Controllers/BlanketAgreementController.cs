﻿using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using SAP.Addon.Controllers;
using SAP.Addon.Domain.Entities.Business;
using SAP.Addon.Domain.Services.Administration;
using SAP.Addon.Domain.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCore.Domain.Entities.Configuration;
using WebCore.Domain.Services.Configuration;

namespace SAP.Addon.Areas.Business.Controllers
{
    public class BlanketAgreementController : BaseController
    {
        private BlanketAgreementService service;
        private ICategoryService categoryService;
        private ICategoryItemService itemService;
        public BlanketAgreementController(BlanketAgreementService service, ICategoryService ts, ICategoryItemService itemService)
        {
            this.service = service;
            this.categoryService = ts;
            this.itemService = itemService;
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
            ViewBag.AgreementMethod = new SelectList(itemService.GetItemByCode(Category.AGREEMENT_METHOD), "Code", "Name");
            ViewBag.Status = new SelectList(itemService.GetItemByCode(Category.AGREEMENT_STATUS), "Code", "Name");
            ViewBag.DocumentTypes = new SelectList(itemService.GetItemByCode(Category.DOCUMENT_TYPE), "Code", "Name");
            ViewBag.PaymentTerms = new SelectList(itemService.GetItemByCode(Category.PAYMENT_TERM), "Code", "Name");
            ViewBag.AgreementTypes = new SelectList(itemService.GetItemByCode(Category.AGREEMENT_TYPE), "Code", "Name");

            var ownerList = service.GetOwnerList();
            ViewBag.Owners = new SelectList(ownerList,"Code","Name");

            return View(new ZOOAT() { Owner = "53", StartDate = DateTime.Now, EndDate = DateTime.Now, Details = new List<ZOAT1TMP>()});
        }

        // POST: Business/BlanketAgreement/Create
        [HttpPost]
        public ActionResult Create(ZOOAT model)
        {
            ViewBag.AgreementMethod = new SelectList(itemService.GetItemByCode(Category.AGREEMENT_METHOD), "Code", "Name");
            ViewBag.Status = new SelectList(itemService.GetItemByCode(Category.AGREEMENT_STATUS), "Code", "Name");
            ViewBag.DocumentTypes = new SelectList(itemService.GetItemByCode(Category.DOCUMENT_TYPE), "Code", "Name");
            ViewBag.PaymentTerms = new SelectList(itemService.GetItemByCode(Category.PAYMENT_TERM), "Code", "Name");
            ViewBag.AgreementTypes = new SelectList(itemService.GetItemByCode(Category.AGREEMENT_TYPE), "Code", "Name");

            var ownerList = service.GetOwnerList();
            ViewBag.Owners = new SelectList(ownerList, "Code", "Name");

            if (ModelState.IsValid)
            try
            {
                // TODO: Add insert logic here
                if(service.Save(model))
                    return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("serice", ex.Message);
                return View(model);
            }
            return View(model);
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

        public JsonResult FindCustomer(string pbCode="", string pbName = "", string pbAddress = "", string pbGroup = "", string pbType = "")
        {
            var customers = service.FindCustomers(pbCode, pbName, pbAddress, pbGroup, pbType);
            return Json(customers.Take(50).ToArray(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadContactPersons(string cardCode = "")
        {
            var contacts = service.LoadContactPersons(cardCode);
            return Json(contacts.Take(50).ToArray(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadBusinessPartner(string cardCode = "")
        {
            var contacts = service.LoadPartner(cardCode);
            return Json(contacts, JsonRequestBehavior.AllowGet);
        }
    }
}
