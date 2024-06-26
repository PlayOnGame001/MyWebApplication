using System.ComponentModel.DataAnnotations;

namespace MyWebApplication.ViewModels
{
    public class NoteViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Не указано название заметки")]
        public string Title { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}
