using EduHome.Data;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
  
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(AppDbContext context,UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager,RoleManager<IdentityRole> roleManager)
        {
           _context = context;
           _userManager = userManager;
           _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Register()
        {
   
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(VmRegister model)
        {
            if (ModelState.IsValid)
            {
                CustomUser newUser = new CustomUser() 
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    Email = model.Email, 
                    UserName = model.Email,
                    CreatedDate=DateTime.Now};
                var result = await _userManager.CreateAsync(newUser, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(newUser, false);
                    return RedirectToAction("Index", "About");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View(model);
                }
            }

            return View(model);
        }
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(VmRegister model)
        {
            if (ModelState.IsValid)
            {
               
                var result = await _signInManager.PasswordSignInAsync(model.Email,model.Password,false,false);
                if (result.Succeeded)
                {                 
                    return RedirectToAction("Index", "About");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is not coorect");
                    return View(model);
                }
            }

            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        public IActionResult Users()
        {
            List<CustomUser> users= _context.CustomUsers.ToList();
            return View(users);
        }
        public IActionResult UpdateUser(string id)
        {
            CustomUser user = _context.CustomUsers.Find(id);
            return View(user);
        }
        public IActionResult Roles()
        {
            List<IdentityRole> roles = _context.Roles.ToList();
            return View(roles);
        }
        public IActionResult RoleCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RoleCreate(IdentityRole model)
        {
            await _roleManager.CreateAsync(model);

            return RedirectToAction("Roles");
        }
    }
}

