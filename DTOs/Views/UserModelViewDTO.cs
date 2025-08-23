using System.ComponentModel.DataAnnotations;

namespace Studying.DTOs.Views
{
    public class UserModelViewDTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
