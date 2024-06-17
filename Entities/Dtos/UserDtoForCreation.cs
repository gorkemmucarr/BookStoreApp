using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class UserDtoForCreation : UserDto
    {
        [Required(ErrorMessage ="Password is required")]
        public string? Password { get; set; }
    }
}
