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
    public class CategoryController : BaseController
    {
        private ICategoryService service;
        public CategoryController(ICategoryService service)
        {
            this.service = service;
        }

        // GET: Configuration/Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            IEnumerable<Category> dt = service.Get();
            return Json(dt.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, Category model)
        {
            model.CreatedUserId = CurrentUser.Id;
            model.CreatedDate = DateTime.Now;
            if (model != null && ModelState.IsValid)
            {
                service.Create(model);
                service.Save();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, Category model)
        {
            if (model != null)
            {
                service.Delete(model);
                service.Save();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, Category model)
        {
            model.ModifiedUserId = CurrentUser.Id;
            model.ModifiedDate = DateTime.Now;
            if (model != null && ModelState.IsValid)
            {
                service.Update(model);
                service.Save();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}