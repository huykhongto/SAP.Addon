using SAP.Addon.Controllers;
using SAP.Addon.Domain.Entities.Business;
using SAP.Addon.Domain.Models.Business;
using SAP.Addon.Domain.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAP.AddOn.Areas.Business.Controllers
{
    public class BlanketAgreementDetailController : BaseController
    {
        private BlanketAgreementItemService service;

        public BlanketAgreementDetailController(BlanketAgreementItemService service)
        {
            this.service = service;
        }


        public ActionResult AddItem()
        {
            var model = new ZOAT1TMP();
            ViewBag.Origins = new SelectList(service.GetOriginalList(),"Code","Name");
            ViewBag.UoMs = new SelectList(service.GetMeasureList(), "Code", "Name");
            return PartialView("DetailItem", model);
        }

        public JsonResult FindItems(string ItemCode = "", string ItemName = "", string ItemGroup = "", int Manufacture = 0, string Inactive = "")
        {
            var items = service.FindItems(ItemCode, ItemName, ItemGroup, Manufacture, Inactive);
            return Json(items.Take(50).ToArray(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetOriginal(string ItemCode = "", string Manufacturer = "")
        {
            string original = service.GetOriginalByItem(ItemCode);
            if (string.IsNullOrEmpty(original))
                original = service.GetOriginalByManufacture(Manufacturer);
            return Json(original, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTenderUnit(string ItemCode = "", string SaleUnit = "")
        {
            var defaultUnit = service.GetDefaultUoM(ItemCode);
            if (defaultUnit == null)
            {
                defaultUnit = new MeasureListViewModel() {
                    UoM = SaleUnit,
                    ItemsPerUoM = 1
                };
            }
            return Json(defaultUnit, JsonRequestBehavior.AllowGet);
        }
    }
}