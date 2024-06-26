using System.ComponentModel.DataAnnotations;

namespace MyWebApplication.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Key]
        public string? Id { get; set; }

        [Required(ErrorMessage = "Введите email")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Введите старый пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Старый пароль")]
        public string? OldPassword { get; set; }

        [Required(ErrorMessage = "Введите новый пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Новый пароль")]
        public string? NewPassword { get; set; }

        [MinLength(5, ErrorMessage = "Пароль должен быть не менее 5 символов.")]
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Повторите пароль")]
        public string? ConfirmNewPassword { get; set; }
    }
}
