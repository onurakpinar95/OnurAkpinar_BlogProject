namespace OnurAkpinar_BlogProject.Models.DTOs
{
    public class User_DTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public IFormFile? Picture { get; set; }
        public string? About { get; set; }
        public string? Email { get; set; }
    }
}
