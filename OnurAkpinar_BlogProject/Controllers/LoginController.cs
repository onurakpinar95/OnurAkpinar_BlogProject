using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Microsoft.Win32;
using OnurAkpinar_BlogProject.DAL;
using OnurAkpinar_BlogProject.Models.Entities;
using OnurAkpinar_BlogProject.Models.ViewModels;
using OnurAkpinar_BlogProject.Services;
using System.Text.Encodings.Web;

namespace OnurAkpinar_BlogProject.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<Member> _signInManager;
        private readonly UserManager<Member> _userManager;
        private readonly BlogDbContext _dbContext;

        private readonly IEmailSender _emailSender;

        public LoginController(SignInManager<Member> signInManager, UserManager<Member> userManager, BlogDbContext dbContext, IEmailSender emailSender)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _dbContext = dbContext;
            _emailSender=emailSender;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login)
        {
            
            var member =  _userManager.Users.FirstOrDefault(x=>x.Email==login.Email);

            if (member == null || !await _userManager.CheckPasswordAsync(member, login.Password))
            {
                ModelState.AddModelError("Error", "Username or Password is incorrect!");
                return View(login);
            }
            else if(!member.EmailConfirmed)
            {
                ModelState.AddModelError("Error", "Email onaylanmadı lütfen linkinize gönderilen maili tıklayın");
                return View(login);
            }

            await _signInManager.SignInAsync(member, false);
            return RedirectToAction("Index", "Home");
        }

        //[HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/Login/Login");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM? model)
        {
            //DB'de kullanıcı kontrolü
            var usernames = _dbContext.Users.Select(x => x.Email).ToList();
            if (usernames.Contains(model.Email))
            {
                TempData["Error"] = " This email has been used by another user.";
                return RedirectToAction("Register", "Login");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            //User Confirmation mail
            if (ModelState.IsValid)
			{
				var user = new Member { UserName = model.Email, Email = model.Email, FirstName = model.Email.Split('@')[0] };
             


                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
                var result = await _userManager.CreateAsync(user, model.Password);
               
                if (result.Succeeded)
				{

                    await _userManager.AddToRoleAsync(user, "Member");
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Action(nameof(ConfirmEmail), "Login", new { userId = user.Id, code }, protocol: Request.Scheme);

					await _emailSender.SendEmailAsync(model.Email, "Emailinizi doğrulayın",
						$"Lütfen emailinizi doğrulamak için <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>buraya tıklayın</a>.");

					return RedirectToAction("Index", "Home");
				}
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
			}
			return View();



        }

        [HttpGet]
		public async Task<IActionResult> ConfirmEmail(string userId, string code)
		{
			if (userId == null || code == null)
			{
				return RedirectToAction("Register", "Login");
			}
			var user = await _userManager.FindByIdAsync(userId);
			if (user == null)
			{
				return NotFound($"Kullanıcı ID '{userId}' bulunamadı.");
			}
			var result = await _userManager.ConfirmEmailAsync(user, code);
			return View(result.Succeeded ? "ConfirmEmail" : "Error");
		}



    }
}
