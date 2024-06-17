﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Category name is required")]
        [Display(Name ="Category Name")]
        public string CategoryName { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
