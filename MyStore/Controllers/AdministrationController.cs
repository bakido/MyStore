using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyStore.Data;
using MyStore.Models;
using MyStore.Repository;
using MyStore.ViewModel;

namespace MyStore.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> _role;
        public UserManager<IdentityUser> userManager { get; set; }

        public ApplicationDbContext Context { get; }

        public AdministrationController(RoleManager<IdentityRole> roleManager,ApplicationDbContext context,UserManager<IdentityUser> user)

        {
            _role = roleManager;
            Context = context;
            userManager = user;
        }
        [HttpGet]
        // GET: Administration
        public async Task<ActionResult> EditUsersInRoleAsync(string roleId)
        {
            ViewBag.roleId = roleId;
           var role = await _role.FindByIdAsync(roleId);
            if (role == null)
            {
                return View("Not Found");
            }
            List<UserRoleViewModel> model = new List<UserRoleViewModel>();
            foreach (var user in userManager.Users)
            {
                UserRoleViewModel userRoleViewModel = new UserRoleViewModel()
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };
                if(await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.isSelected = true;
                }
                else
                {
                    userRoleViewModel.isSelected = false;
                }
                model.Add(userRoleViewModel);
            }
            return View(model);
        }

        // GET: Administration/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        // GET: Administration/Create
        public ActionResult CreateRole()
        {
            return View();
        }

        // POST: Administration/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRole([Bind("RoleName")] CreateRoleViewModel  roleViewModel)
        {
            try
            {
                // TODO: Add insert logic here
                IdentityRole role = new IdentityRole() { Name = roleViewModel.RoleName };
              IdentityResult result= _role.CreateAsync(role).Result;

                return RedirectToAction("Index","Order");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administration/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Administration/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administration/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Administration/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("");
            }
            catch
            {
                return View();
            }
        }
    }
}