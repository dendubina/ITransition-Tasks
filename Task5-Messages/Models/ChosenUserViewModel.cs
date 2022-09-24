using System.ComponentModel.DataAnnotations;

namespace Task5_Messages.Models
{
    public class ChosenUserViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
