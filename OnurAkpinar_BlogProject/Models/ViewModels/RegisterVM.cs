using OnurAkpinar_BlogProject.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace OnurAkpinar_BlogProject.Models.ViewModels
{
    public class RegisterVM
    {
        public int? ID { get; set; }        

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [EmailAddress(ErrorMessage = "Email is not valid!")]
        public string Email { get; set; }

        public string? About { get; set; }   

        public IFormFile? Picture { get; set; }

        [PasswordValidation]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords should be matched!")]
        public string Repassword { get; set; }
    }
}
