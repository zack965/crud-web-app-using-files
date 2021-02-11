using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pdf.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string bookName { get; set; }
        //public IFormFile bookpdf { get; set; }
        public string bookpdfurl { get; set; }
    }
}
