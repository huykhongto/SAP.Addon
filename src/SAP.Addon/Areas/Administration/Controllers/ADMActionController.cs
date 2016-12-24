using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.Ajax.Utilities;
using SAP.Addon.Controllers;
using SAP.Addon.Domain.Entities.Administration;
using SAP.Addon.Domain.Services.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace SAP.Addon.Areas.Administration.Controllers
{
    public class ADMActionController : BaseController
    {

        private IADMActionService actionService;
        public ADMActionController(IADMActionService service)
        {
            this.actionService = service;
        }
        // GET: Administration/ADMAction
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            List<ADMAction> actions = new List<ADMAction>();
            var controllerList = GetControllerNames();
            var areas = GetAllAreasRegistered();
            var controllers = GetAllControllers();
            foreach (string controllerName in controllerList)
            {
                var controller = controllers.Where(c => c.Name == controllerName).FirstOrDefault();
                var area = areas.Where(a => controller.FullName.Contains(a.AreaName)).FirstOrDefault();
                var actionLists = GetActionNames(controller, area);
                actions.AddRange(actionLists);
            }

            var data = actionService.Get();

            var query = from a in actions.DistinctBy(m=>m.Name)
                        join b in data on a.Name equals b.Name into prodGroup
                        from item in prodGroup.DefaultIfEmpty()
                        select new ADMAction() {
                            Id=item.Id,
                            Name = item.Name,
                            Area = item.Area,
                            Description = item.Description
                        };


            return Json(query.ToList().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, ADMAction atc)
        {
            if (atc != null)
            {
                atc.CreatedUserId = CurrentUser.Id;
                atc.CreatedDate = DateTime.Now;
                actionService.Create(atc);
                actionService.Save();
            }

            return Json(new[] { atc }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, ADMAction atc)
        {
            if (atc != null && ModelState.IsValid)
            {
                atc.ModifiedUserId = CurrentUser.Id;
                atc.ModifiedDate = DateTime.Now;
                actionService.Update(atc);
                actionService.Save();
            }

            return Json(new[] { atc }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Actions_Destroy([DataSourceRequest] DataSourceRequest request, ADMAction atc)
        {
            if (atc != null)
            {
                actionService.Delete(atc);
                actionService.Save();
            }

            return Json(new[] { atc }.ToDataSourceResult(request, ModelState));
        }

        #region methods

        private static List<Type> GetSubClasses<T>()
        {
            return Assembly.GetCallingAssembly().GetTypes().Where(
                type => type.IsSubclassOf(typeof(T))).ToList();
        }

        public List<string> GetControllerNames()
        {
            List<string> controllerNames = new List<string>();
            GetSubClasses<Controller>().ForEach(
                type => controllerNames.Add(type.Name));
            return controllerNames;
        }

        public List<string> ActionNames(string controllerName)
        {
            var types =
                from a in AppDomain.CurrentDomain.GetAssemblies()
                from t in a.GetTypes()
                where typeof(IController).IsAssignableFrom(t) &&
                        string.Equals(controllerName, t.Name, StringComparison.OrdinalIgnoreCase)
                select t;

            var controllerType = types.FirstOrDefault();

            if (controllerType == null)
            {
                return Enumerable.Empty<string>().ToList();
            }
            return new ReflectedControllerDescriptor(controllerType)
                .GetCanonicalActions().Select(x => controllerName.Replace("Controller", "") + "/" + x.ActionName)
                .ToList();
        }

        private IEnumerable<AreaRegistration> GetAllAreasRegistered()
        {
            var assembly = this.GetType().Assembly;
            var areaTypes = assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(AreaRegistration)));
            var areas = new List<AreaRegistration>();
            foreach (var type in areaTypes)
            {
                areas.Add((AreaRegistration)Activator.CreateInstance(type));
            }
            return areas;
        }

        public List<ADMAction> GetActionNames(Type controller, AreaRegistration area)
        {
            if (controller == null)
            {
                return Enumerable.Empty<ADMAction>().ToList();
            }

            var query = from a in new ReflectedControllerDescriptor(controller).GetCanonicalActions()
                        select new ADMAction()
                        {
                            Name = controller.Name.Replace("Controller", "") + "/" + a.ActionName,
                            Area = area == null ? "" : area.AreaName
                        };

            return query.ToList();

        }

        private IEnumerable<Type> GetAllControllers()
        {
            var types =
                    from a in AppDomain.CurrentDomain.GetAssemblies()
                    from t in a.GetTypes()
                    where typeof(IController).IsAssignableFrom(t)// && string.Equals(controllerName, t.Name, StringComparison.OrdinalIgnoreCase)
                    select t;

            return types;
        }
        #endregion
    }
}