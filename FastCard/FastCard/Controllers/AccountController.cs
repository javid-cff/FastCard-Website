using FastCard.Interfaces;
using FastCard.Models;
using FastCard.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FastCard.Controllers
{
    public class AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IEmailService emailService) : Controller
    {
        public IActionResult Index()
        {
            return Ok("Salam Aleykum!");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var user = new AppUser
            {
                FullName = vm.FullName,
                UserName = vm.UserName,
                Email = vm.Email
            };

            var result = await userManager.CreateAsync(user, vm.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);

                return View(vm);
            }

            return RedirectToAction("Index", "Home");

            /*var token = await userManager.GenerateChangeEmailTokenAsync(user);

            var link = Url.Action(
                "ConfirmEmail",
                "Account",
                new { userId = user.Id, token = token },
                Request.Scheme
            );

            var body = $@"
                <h2>FastCard Email Verification</h2>
                <p>Zəhmət olmasa email-i təsdiqlə:</p>
                <a href='{link}'>Email-i təsdiqlə</a>
            ";

            await emailService.SendEmailAsync(user.Email, "Email Verification", body);

            return RedirectToAction("EmailSent");*/
        }

        public IActionResult EmailSent()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var user = await userManager.FindByNameAsync(vm.UserName);

            if (user == null)
            {
                ModelState.AddModelError("", "username ve ya sifre yanlisdir!");
                return View(vm);
            }

            var result = await userManager.CheckPasswordAsync(user, vm.Password);

            if (!result)
            {
                ModelState.AddModelError("", "username ve ya sifre yanlisdir!");
                return View(vm);
            }

            await signInManager.SignInAsync(user, vm.IsRemember);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        
    }
}
