using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class UserDto
    {
        [Required(ErrorMessage ="Username is required")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string? Email { get; set; }
        public HashSet<string> Roles { get; set; } = new HashSet<string>();
    }
}
