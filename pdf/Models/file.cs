using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pdf.Models
{
    public class file
    {
        public int BookId { get; set; }
        public string bookName { get; set; }
        public IFormFile bookpdf { get; set; }
        public string bookpdfurl { get; set; }
    }
}
