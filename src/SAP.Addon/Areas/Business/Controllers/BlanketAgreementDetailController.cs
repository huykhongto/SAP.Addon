using SAP.Addon.Controllers;
using SAP.Addon.Domain.Entities.Business;
using SAP.Addon.Domain.Models.Business;
using SAP.Addon.Domain.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCore.Domain.Services.Configuration;

namespace SAP.AddOn.Areas.Business.Controllers
{
    public class BlanketAgreementDetailController : BaseController
    {
        private BlanketAgreementItemService service;
        private ICategoryService categoryService;
        private ICategoryItemService itemService;

        public BlanketAgreementDetailController(BlanketAgreementItemService service, ICategoryService ts, ICategoryItemService itemService)
        {
            this.service = service;
            this.categoryService = ts;
            this.itemService = itemService;
        }


        public ActionResult AddItem()
        {
            var model = new ZOAT1TMP() {
                U_Start = DateTime.Now,
                U_End = DateTime.Now,
                LineStatus = "O",
                U_Notify = "N",
                U_TenderType = "TT01",
            };

            ViewBag.Origins = new SelectList(service.GetOriginalList(),"Code","Name");
            ViewBag.UoMs = new SelectList(service.GetMeasureList(), "Code", "Name");

            ViewBag.LineStatus = new SelectList(itemService.GetItemByCode("LINE_STATUS"), "Code", "Name",model.LineStatus);
            ViewBag.NotifyQty = new SelectList(itemService.GetItemByCode("NOTIFY_QTY"), "Code", "Name", model.U_Notify);
            ViewBag.TenderTypes = new SelectList(itemService.GetItemByCode("TENDER_TYPE"), "Code", "Name", model.U_TenderType);

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