using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pdf.Models;
using pdf.Models.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace pdf.Controllers
{
    public class BookController : Controller
    {
        private readonly IOperations<Book> books;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BookController(IOperations<Book> _book, IWebHostEnvironment webHostEnvironment)
        {
            this.books = _book;
            _webHostEnvironment = webHostEnvironment;
        }
        // GET: BookController
        public ActionResult List()
        {
            var aurh = books.List();
            return View(aurh);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var book = books.Find(id);

            return View(book);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(file fi)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string filename = string.Empty;

                    if (fi.bookpdf != null)
                    {
                        string uploads = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                        filename = fi.bookpdf.FileName;
                        string fullPath = Path.Combine(uploads, filename);
                        fi.bookpdf.CopyTo(new FileStream(fullPath, FileMode.Create));
                        ViewBag.type = fi.bookpdf.ContentType;

                    }
                    Book book = new Book
                    {
                        BookId = fi.BookId,
                        bookName = fi.bookName,
                        bookpdfurl = filename

                    };
                    books.Add(book);
                    
                }
                return RedirectToAction(nameof(List));

            }
            catch
            {
                return View();
            }
        }
        /*
        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            var book = books.Find(id);

            return View(book);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, file fi)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string filename = string.Empty;

                    if (fi.bookpdf != null)
                    {
                        string uploads = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                        filename = fi.bookpdf.FileName;
                        string fullPath = Path.Combine(uploads, filename);
                        //delete old file 
                        string oldfilename = books.Find(fi.BookId).bookpdfurl;
                        string fulloldpath = Path.Combine(uploads, oldfilename);
                        if(fulloldpath != fullPath)
                        {
                            System.IO.File.Delete(fulloldpath);
                            fi.bookpdf.CopyTo(new FileStream(fullPath, FileMode.Create));
                        }
                        // save the new file 
                        

                    }
                    Book book = new Book
                    {
                        BookId = fi.BookId,
                        bookName = fi.bookName,
                        bookpdfurl = filename

                    };
                    //books.Update(book.BookId,book);
                }
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }

        */
        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            var book = books.Find(id);

            return View(book);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Book book)
        {
            try
            {
                books.Delete(book);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }
    }
}
/*
 
 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pdf.Models;
using pdf.Models.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace pdf.Controllers
{
    public class BookController : Controller
    {
        private readonly IOperations<Book> books;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BookController(IOperations<Book> _book, IWebHostEnvironment webHostEnvironment)
        {
            this.books = _book;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult List()
        {
            var aurh = books.List();
            return View(aurh);
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(file fi)
        {
            try
            {
                string filename = string.Empty;
                
                if(fi.bookpdf != null)
                {
                    string uploads = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    filename = fi.bookpdf.FileName;
                    string fullPath = Path.Combine(uploads, filename);
                    fi.bookpdf.CopyTo(new FileStream(fullPath, FileMode.Create));
                    ViewBag.type = fi.bookpdf.ContentType;                   

                }
                Book book = new Book
                {
                    BookId = fi.BookId,
                    bookName = fi.bookName,
                    bookpdfurl = filename
                    
                };
                books.Add(book);

                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }
        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }
    }
}

 */
