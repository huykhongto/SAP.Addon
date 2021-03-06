﻿using Newtonsoft.Json;
using SAP.Addon.Domain.Models;
using SAP.Addon.Domain.Models.Administration;
using SAP.Addon.Domain.Services.Administration;
using Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebCore.Domain.Entities.Configuration;
using WebCore.Domain.Services.Configuration;

namespace SAP.Addon.Controllers
{
    public class AccountController : BaseController
    {
        private ZUSRService service;
        private ICategoryService categoryService;
        private ICategoryItemService itemService;

        public AccountController(ZUSRService us, ICategoryService categoryService, ICategoryItemService itemService)
        {
            this.service = us;
            this.categoryService = categoryService;
            this.itemService = itemService;
        }

        // GET: Account
        [AllowAnonymous]
        public ActionResult Login(string returnUrl = "")
        {
            ViewBag.returnUrl = returnUrl;
           ViewBag.FunctionList = new SelectList(itemService.GetItemByCode(Category.FUNCTIONS), "Code","Name");
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                ZUSR user = service.IntegrationAuthentication(model.UserName, model.Password, model.Functional);

                if (user != null)
                {
                    WebCorePrincipalSerializeModel serializeModel = new WebCorePrincipalSerializeModel();
                    serializeModel.UserId = user.UserID;
                    serializeModel.UserName = user.UserName;
                    serializeModel.FullName = user.UserName;
                    serializeModel.IsSysAdmin = false;

                    string userData = JsonConvert.SerializeObject(serializeModel);
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                                1,
                                user.UserName,
                                DateTime.Now,
                                DateTime.Now.AddMinutes(60),
                                model.Remember,
                                userData);

                    string encTicket = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                    Response.Cookies.Add(faCookie);

                    if (string.IsNullOrEmpty(returnUrl))
                        return RedirectToAction("Index", "Home");
                    else
                        return Redirect(returnUrl);
                }
            }
            ViewBag.FunctionList = new SelectList(itemService.GetItemByCode(Category.FUNCTIONS), "Code", "Name");
            ModelState.AddModelError("", "UserId or Password is incorrect.");
            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}