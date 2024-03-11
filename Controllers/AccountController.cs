using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeManagement.Controllers
{
	public class AccountController : Controller
	{
        private readonly ILogger<AccountController> _logger;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(ILogger<AccountController> logger,UserManager<IdentityUser> userManager
            ,SignInManager<IdentityUser> signInManager) 
        { 
        _logger = logger;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        [HttpPost]
        public async Task<IActionResult> Logout() { 
            await signInManager.SignOutAsync();
            return RedirectToAction("Index","home");
}
		[HttpGet]
		public IActionResult Register()
		{ 
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
          if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
              var result=await  userManager.CreateAsync(user,model.Password);
                if (result.Succeeded)
                {
                   await signInManager.SignInAsync(user,isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty,error.Description);

                }

            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                var result = await signInManager.PasswordSignInAsync(model.Email,model.Password,model.RememberMe,false);
                if (result.Succeeded)
                {
                   
                    return RedirectToAction("Index", "Home");
                }
                
                
                    ModelState.AddModelError(string.Empty, "Invalid Login Attemp");

                

            }
            return View(model);
        }

















        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            _logger.LogError($"The path{exceptionDetails.Path} threw an exception {exceptionDetails.Error}");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
