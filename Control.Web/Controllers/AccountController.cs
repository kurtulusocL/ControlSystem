﻿using Control.Data.Data;
using Control.Data.Identity;
using Control.Entities.Models.Admin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Control.Web.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private RoleManager<ApplicationRole> roleManager;

        public AccountController()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(db);
            userManager = new UserManager<ApplicationUser>(userStore);
            RoleStore<ApplicationRole> roleStore = new RoleStore<ApplicationRole>(db);
            roleManager = new RoleManager<ApplicationRole>(roleStore);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model)
        {
            ApplicationUser user = userManager.Find(model.Username, model.Password);
            if (user != null)
            {
                var username = user.UserName;
                Session["KullanıcıAdıSoyadı"] = user.NameLastname;
                Session["Kullanıcı"] = username;
                Session["adminID"] = user.Id;

                IAuthenticationManager authManager = HttpContext.GetOwinContext().Authentication;
                ClaimsIdentity identity = userManager.CreateIdentity(user, "ApplicationCookie");
                AuthenticationProperties authProps = new AuthenticationProperties();
                authProps.IsPersistent = model.RememberMe;
                authManager.SignIn(authProps, identity);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ModelState.AddModelError("Login", "Kullanıcı Adı veya Şifre Yanlış");
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            IAuthenticationManager authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();

                user.UserName = model.Username;
                user.NameLastname = model.NameLastname;
                user.Email = model.Email;
                user.Country = model.Country;
                user.City = model.City;
                user.RespondTitle = model.RespondTitle;
                user.Birthdate = model.Birthdate;
                user.HireDate = model.HireDate;
                user.Gender = model.Gender;
                user.PhoneNumber = model.PhoneNumber;

                IdentityResult iResult = userManager.Create(user, model.Password);
                if (iResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Users");
                    ModelState.AddModelError("Register", "Kullanıcı Ekleme Başarısız");
                }
                return RedirectToAction("Login", "Account");
            }
            return View(model);
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePassword model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = userManager.FindByName(HttpContext.User.Identity.Name);
                IdentityResult result = userManager.ChangePassword(user.Id, model.OldPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
                    authenticationManager.SignOut();
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Şifre değiştirilirken hata meydana geldi..");
                }
            }
            return View(model);
        }
    }
}