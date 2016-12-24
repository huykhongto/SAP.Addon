using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using SAP.Addon.Controllers;
using SAP.Addon.Domain.Entities.Administration;
using SAP.Addon.Domain.Models.Administration;
using SAP.Addon.Domain.Services.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SAP.AddOn.Areas.Administration.Controllers
{
    public class ADMMenuController : BaseController
    {
        private IADMMenuService menuService;
        private IADMActionService actionService;

        // GET: Administration/ADMMenu
        public ADMMenuController(IADMMenuService menuService, IADMActionService actionService)
        {
            this.actionService = actionService;
            this.menuService = menuService;
        }

        public ActionResult Index()
        {
            var actions = new SelectList(actionService.Get().OrderBy(a=>a.Name), "Id", "Name");
            ViewBag.Actions = new JavaScriptSerializer().Serialize(actions);
            return View();
        }

        public ActionResult Create(int? PARENT_ID)
        {
            var menus = menuService.Get().OrderBy(m=>m.OrderId);
            ViewData["Parents"] = new SelectList(menus, "Id", "Name");

            var actions = actionService.Get().OrderBy(a => a.Name);
            var actionList = new SelectList(actions, "Id", "Name",null);
            ViewData["Actions"] = new SelectList(actions, "Id", "Name");
            ADMMenu model = new ADMMenu() { Id = 0, Name = "", OrderId = 1, Status = true, ParentId = PARENT_ID };
            return PartialView("Edit", model);
        }

        public ActionResult Edit(int ID)
        {

            ADMMenu model = menuService.Get(ID);
            if (model == null)
                return HttpNotFound();

            var menus = menuService.Get().OrderBy(m => m.OrderId);
            ViewData["Parents"] = new SelectList(menus, "Id", "Name", model.ParentId);
            ViewData["Actions"] = new SelectList(actionService.Get().OrderBy(a=>a.Name), "Id", "Name", model.ActionId);
            return PartialView("Edit", model);
        }

        [HttpPost]
        public JsonResult Edit(ADMMenu model)
        {
            if (ModelState.IsValid)
            {
                menuService.Update(model);
                if (menuService.Save() == 0)
                {
                    menuService.Create(model);
                    menuService.Save();
                }
                    
                return Json(new { succeed = 1, instance = model }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { succeed = 0, error = ModelState.SerializeErrors() }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            ADMMenu model = menuService.Get(ID);
            if (model == null)
                return HttpNotFound();
            menuService.Delete(model);
            bool res = menuService.Save() > 0;

            return Json(new { succeed = res }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(menuService.Get().OrderBy(a => a.OrderId).ToDataSourceResult(request));
        }


        public ActionResult MenuLeft(int? UserId)
        {
            var actions = actionService.Get();
            var menus = menuService.Get().Where(m => m.IsDeleted != true && m.Status == true).OrderBy(m=>m.OrderId);

            var query = from m in menus
                        join a in actions on m.ActionId equals a.Id into itemGroup
                        from item in itemGroup.DefaultIfEmpty()
                        select new MenuViewModel()
                        {
                            Id = m.Id,
                            Name = m.Name,
                            CssClass = m.CssClass,
                            ParentId = m.ParentId,
                            ActionArea = item != null ? item.Area : "",
                            ActionName = item != null ? item.Name : "#",
                        };
            return PartialView("_MenuLeft", query.ToList());
        }
    }
}