using System.ComponentModel.DataAnnotations;

namespace P140_API.DTOs
{
    public class GroupCreateDTO
    {
        [Required(ErrorMessage = "Fill the input")]
        [Display(Name = "Group's name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Fill the input")]
        [Display(Name = "Group's profession")]
        public string Profession { get; set; }
    }
}
