using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Book
    {
        public int BookId { get; set; }
        [Required(ErrorMessage ="Book Name is required")]
        [Display(Name ="Book Name")]
        public string BookName { get; set; }
        [Required(ErrorMessage = "Writer is required")]
        public string Writer { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
