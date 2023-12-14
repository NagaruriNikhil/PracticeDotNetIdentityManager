using IdentityManager.Models;
using IdentityManager.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityManager.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
			_userManager = userManager;
        }
        public IActionResult Register()
		{
			RegisterViewModel registerViewModel = new();
			return View(registerViewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterViewModel registerViewModel) { 
			if (ModelState.IsValid)
			{
				var user = new ApplicationUser
				{
					UserName = registerViewModel.Email,
					Email = registerViewModel.Email,
					Name = registerViewModel.Name
				};
				var results= await _userManager.CreateAsync(user, registerViewModel.Password);
				if(results.Succeeded)
				{
					await _signInManager.SignInAsync(user, isPersistent: false);
					return RedirectToAction("Index", "Home");
				}

			}
			return View(registerViewModel);
		}


	}
}
