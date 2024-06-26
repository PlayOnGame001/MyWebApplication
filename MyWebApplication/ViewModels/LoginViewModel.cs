using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace MyWebApplication.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "������������ Email")]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "������")]
        public string? Password { get; set; }

        [Display(Name = "���������")]
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }
        public List<AuthenticationScheme> ExternalLogins { get; set; } = new List<AuthenticationScheme>();
    }
}
