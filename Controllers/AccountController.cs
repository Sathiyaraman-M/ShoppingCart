using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models.ViewModels;

namespace ShoppingCart.Controllers
{
    public class AccountController : Controller 
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> uManager, SignInManager<IdentityUser> sManager)
        {
            userManager = uManager;
            signInManager = sManager;
        }
        public ViewResult Login(string returnUrl)
        {
            return View(new LoginModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if(ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByNameAsync(loginModel.Name);
                if(User != null)
                {
                    await signInManager.SignOutAsync();
                    if((await signInManager.PasswordSignInAsync(user,loginModel.Password,false,false)).Succeeded)
                    {
                        return Redirect(loginModel?.ReturnUrl ?? "/admin");
                    }
                }
            }
            ModelState.AddModelError("","Invalid Username or Password");
            return View(loginModel);
        }

        [Authorize]
        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}