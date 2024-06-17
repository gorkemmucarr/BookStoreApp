using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ResetPasswordDto
    {
        [Required(ErrorMessage ="Username is required")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Username is required")]
        [Compare("Password")]
        public string? ConfirmPassword { get; set; }
    }
}
