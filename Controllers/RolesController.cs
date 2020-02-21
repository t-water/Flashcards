using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flashcards.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;

        public RolesController(RoleManager<IdentityRole> roleManager,
                                        UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = roleManager.Roles;
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateRoleViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole { Name = model.RoleName.Trim() };
                var result = await roleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("index");
                }

                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditUsers(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if(role == null)
            {
                return NotFound();
            }

            ViewBag.RoleName = role.Name;
            ViewBag.RoleId = role.Id;

            var usersInRole = await userManager.GetUsersInRoleAsync(role.Name);
            var model = new List<UserRoleViewModel>();

            foreach (var u in userManager.Users)
            {
                var userRole = new UserRoleViewModel()
                {
                    UserId = u.Id,
                    UserName = u.UserName
                };

                if (usersInRole.Contains(u))
                {
                    userRole.IsSelected = true;
                }

                model.Add(userRole);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUsers(string id, List<UserRoleViewModel> model)
        {
            var role = await roleManager.FindByIdAsync(id);
            
            if(role == null)
            {
                return NotFound();
            }

            var usersInRole = await userManager.GetUsersInRoleAsync(role.Name);

            for(int i=0; i<model.Count; i++)
            {
                var user = await userManager.FindByIdAsync(model[i].UserId);
                IdentityResult result = null;

                if (model[i].IsSelected && !usersInRole.Contains(user))
                {
                    result = await userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!model[i].IsSelected && usersInRole.Contains(user))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < model.Count - 1)
                    {
                        continue;
                    }
                    else
                    {
                        return RedirectToAction("index");
                    }
                }
            }

            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<IActionResult> ListUsers(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            
            if(role == null)
            {
                return NotFound();
            }

            ViewBag.RoleName = role.Name;
            ViewBag.RoleId = role.Id;

            var usersInRole = await userManager.GetUsersInRoleAsync(role.Name);
            var model = usersInRole.OrderBy(u => u.UserName).Select(u => u.UserName);

            return View(model);
        }
    }
}