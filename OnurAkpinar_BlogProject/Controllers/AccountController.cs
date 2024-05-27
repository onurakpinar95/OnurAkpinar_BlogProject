using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnurAkpinar_BlogProject.DAL;
using OnurAkpinar_BlogProject.Models.DTOs;
using OnurAkpinar_BlogProject.Models.Entities;

namespace OnurAkpinar_BlogProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly BlogDbContext _context;
        private readonly UserManager<Member> _userManager;
        private readonly SignInManager<Member> _signInManager;

        public AccountController(BlogDbContext context, UserManager<Member> userManager, SignInManager<Member> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Account()
        {
            var member = _context.Users.FirstOrDefault(x => x.Id == GetUserID());
            return View(member);
        }

        public IActionResult Edit()
        {
            User_DTO editUser = new User_DTO();
            var member = _context.Users.FirstOrDefault(x => x.Id == GetUserID());
            editUser.FirstName = member.FirstName;
            editUser.LastName=member.LastName;
            editUser.Email = member.Email;
            editUser.About = member.About;


            return View(editUser);
        }
        [HttpPost]
        public IActionResult Edit(User_DTO updatedUser)
        {
            if (ModelState.IsValid)
            {
                var member = _context.Users.FirstOrDefault(x => x.Id == GetUserID());
                member.FirstName = updatedUser.FirstName;
                member.LastName = updatedUser.LastName;
                member.Email = updatedUser.Email;
                member.About = updatedUser.About;

                //Resim Güncelleme
                if(updatedUser.Picture!=null)
                {
                    Guid guid = Guid.NewGuid();
                    string fileName = guid.ToString();
                    fileName += updatedUser.Picture.FileName;
                    string filePath = "wwwroot/images/";
                    member.PictureFilePath = fileName;

                    FileStream fs = new FileStream(filePath + fileName, FileMode.Create);
                    updatedUser.Picture.CopyTo(fs);
                    fs.Close();
                }

                _context.Users.Update(member);
                _context.SaveChanges();
                return RedirectToAction("Account");

            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            Member member = _context.Users.FirstOrDefault(x => x.Id == id);
            return View(member);
        }

    
        
        public IActionResult DeleteConfirm(int id)
        {
            var member = _context.Users.Find(id);

            if (member != null)
            {
                _context.Users.Remove(member);
                _context.SaveChanges();

            }
            _signInManager.SignOutAsync();
            TempData["Info"] = "Hesabınız Silinmiştir";
            return RedirectToAction("Index", "Home");
        }






        public int GetUserID()
        {
            if (User != null)
            {
                return int.Parse(_userManager.GetUserId(User));
            }
            return 0;
        }
    }
}
