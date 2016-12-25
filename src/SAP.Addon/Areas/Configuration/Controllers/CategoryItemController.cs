using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using SAP.Addon.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCore.Domain.Entities.Configuration;
using WebCore.Domain.Services.Configuration;

namespace SAP.AddOn.Areas.Configuration.Controllers
{
    public class CategoryItemController : BaseController
    {
        private ICategoryItemService service;

        public CategoryItemController(ICategoryItemService service)
        {
            this.service = service;
        }

        // GET: Configuration/CategoryItem
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Read([DataSourceRequest] DataSourceRequest request, int? Id)
        {
            IEnumerable<CategoryItem> dt = service.Get().Where(m=>m.CategoryId == Id);
            return Json(dt.ToTreeDataSourceResult(request));
        }


        public JsonResult Create([DataSourceRequest] DataSourceRequest request, CategoryItem Item, int? ParentID)
        {
            Item.CreatedUserId = CurrentUser.Id;
            Item.CreatedDate = DateTime.Now;
            Item.CategoryId = ParentID;
            if (Item != null && ModelState.IsValid)
            {
                service.Create(Item);
                service.Save();
            }

            return Json(new[] { Item }.ToTreeDataSourceResult(request, ModelState));
        }


        public JsonResult Update([DataSourceRequest] DataSourceRequest request, CategoryItem Item)
        {
            Item.ModifiedUserId = CurrentUser.Id;
            Item.ModifiedDate = DateTime.Now;
            if (Item != null && ModelState.IsValid)
            {
                service.Update(Item);
                service.Save();
            }
            return Json(new[] { Item }.ToTreeDataSourceResult(request, ModelState));
        }
        [HttpPost]
        public ActionResult Destroy(int Id, string uiddelete)
        {
            var model = service.Get(Id);

            if (model != null)
            {
                service.Delete(model);
                service.Save();
            }
            else { uiddelete = ""; }

            return Json(new { uiddelete }, JsonRequestBehavior.AllowGet);
        }
    }
}