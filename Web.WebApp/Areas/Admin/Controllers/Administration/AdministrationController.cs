using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Data.Entities;
using Web.WebApp.Areas.Admin.ViewModel.Administration;

namespace Web.WebApp.Areas.Admin.Controllers.Administration
{
    [Area("Admin")]
    [Route("admin/role")]
    [Authorize(Roles = "Admin")]
    public class AdministrationController : Controller
    {
        private readonly RoleManager<AppRole> roleManager;

        private readonly UserManager<AppUser> userManager;

        public AdministrationController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        [HttpGet]
        [Route("createrole")]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        [Route("createrole")]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppRole appRole = new AppRole
                {
                    Name = model.RoleName,

                    Description = model.Description
                };

                IdentityResult result = await roleManager.CreateAsync(appRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRole");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }
        [HttpGet]
        [Route("listrole")]
        public IActionResult ListRole()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }
        [HttpGet]
        [Route("editrole")]
        public async Task<IActionResult> EditRole(Guid id)
        {
            // Find the role by Role ID
            var role = await roleManager.FindByIdAsync(id.ToString());

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("NotFound");
            }

            var model = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name
            };

            foreach (var user in userManager.Users)
            {

                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }

            return View(model);
        }

        [HttpPost]
        [Route("editrole")]

        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.Id.ToString());
            if (role == null)
            {
                ViewBag.ErrorMessage =
                    $"Role with Id: {model.Id} could not be found";
                return View("NotFound");
            }

            role.Name = model.RoleName;

            var result = await roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction("ListRole");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }
        [HttpGet]
        [Route("edituserinrole")]

        public async Task<IActionResult> EditUsersInRole(Guid roleId)
        {
            ViewBag.roleId = roleId;

            var role = await roleManager.FindByIdAsync(roleId.ToString());

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View();
            }

            var model = new List<UserRoleViewModel>();

            foreach (var user in userManager.Users)
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }
                else
                {
                    userRoleViewModel.IsSelected = false;
                }

                model.Add(userRoleViewModel);
            }

            return View(model);
        }


        [HttpPost]
        [Route("edituserinrole")]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model, Guid roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId.ToString());

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View();
            }

            for (int i = 0; i < model.Count; i++)
            {
                var user = await userManager.FindByIdAsync(model[i].UserId.ToString());

                IdentityResult result = null;

                if (model[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!model[i].IsSelected && await userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                        continue;
                    else
                        return RedirectToAction("EditRole", new { Id = roleId });
                }
            }

            return RedirectToAction("EditRole", new { Id = roleId });
        }
        [HttpGet]
        [Route("edituser")]
        public async Task<IActionResult> EditUser(Guid id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }

            // GetClaimsAsync retunrs the list of user Claims
            var userClaims = await userManager.GetClaimsAsync(user);
            // GetRolesAsync returns the list of user Roles
            var userRoles = await userManager.GetRolesAsync(user);

            var model = new EditUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                LockoutEnd = user.LockoutEnd,
                Claims = userClaims.Select(c => c.Value).ToList(),
                Roles = userRoles
            };

            return View(model);
        }

        [HttpPost]
        [Route("edituser")]

        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.Id.ToString());

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                user.Email = model.Email;
                user.UserName = model.UserName;
                user.Lock = model.Lock;

                var result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            var role = await roleManager.FindByIdAsync(id.ToString());

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                var result = await roleManager.DeleteAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRole");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("ListRole");
            }
        }

        [HttpGet]
        [Route("listuser")]
        public IActionResult ListUsers()
        {
            var users = userManager.Users;
            return View(users);
        }



    }
}

    