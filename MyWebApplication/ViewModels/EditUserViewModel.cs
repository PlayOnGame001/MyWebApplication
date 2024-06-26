using System.ComponentModel.DataAnnotations;

namespace MyWebApplication.ViewModels
{
    public class EditUserViewModel
    {
        [Key]
        public string? Id { get; set; }

        [Required(ErrorMessage = "Введите email")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        [Display(Name = "Год рождения")]
        public int Year { get; set; }
    }
}
