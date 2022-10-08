using Bieralia.Entities;
using Bieralia.Models;
using Bieralia.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Bieralia.ViewModels;

namespace Bieralia.Controllers
{
    public class AdminController : Controller
    {
        private readonly AdminService adminService;
        private readonly BookService bookService;
        private readonly TransactionService transactionService;
        public AdminController(AdminService adminService, BookService bookService, TransactionService transactionService) //constructor
        {
            this.adminService = adminService;
            this.bookService = bookService;
            this.transactionService = transactionService;
        }
        public async Task<IActionResult> Index(string Search)
        {
            var username = HttpContext.Session.GetString("Username");
            var status = HttpContext.Session.GetString("Status");
            if(username == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            if(status != "Admin")
            {
                return RedirectToAction("Index", "Home");
            }

            BookViewModel BVModel = new BookViewModel();
            BVModel.BookList = await bookService.GetBooks(Search);

            return View("Index", BVModel);
        }
        public async Task<IActionResult> GetAllBook()
        {
            BookViewModel BVModel = new BookViewModel();
            // HttpContext.Session.GetString("UserPassword");
            BVModel.BookList = await bookService.GetBooks("");
            return View("BookList", BVModel);
        }

        public async Task<IActionResult> GetBookByBookId(string bookId)
        {
            BookModel BModel = new BookModel();
            BModel = await bookService.GetBookById(bookId);
            if(BModel == null)
            {
                return Json(new
                {
                    status = false,
                    message = "Invalid Id"
                });
            }
            else
            {
                return Json(new
                {
                    status = true,
                    bookid = BModel.BookID,
                    booktitle = BModel.BookTitle,
                    bookdesc = BModel.BookDesc,
                    bookqty = BModel.Quantity,
                    bookprice = BModel.Price
                });
            }
        }

        public async Task<IActionResult> UpdateBook(string bookid, string title, string desc, int qty, int price)
        {
            await bookService.UpdateBook(bookid, title, desc, qty, price);

            return Json(new
            {
                Status = true,
                Message = "Updated"
            });
        }

        public async Task<IActionResult> Cataloging()
        {
            var username = HttpContext.Session.GetString("Username");
            var status = HttpContext.Session.GetString("Status");
            if (username == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            if (status != "Admin")
            {
                return RedirectToAction("Index", "Home");
            }
            BookViewModel BVModel = new BookViewModel();
            BVModel.BookList = await bookService.GetBooks("");
            return View(BVModel);
        }
        public async Task<IActionResult> RemoveBook(string bookId)
        {
            await bookService.DeleteBook(bookId);

            //annonymous object
            JsonResult Ret = Json(new
            {
                Status = true,
                Message = "Sucessfully Deleted"
            });

            return Ret;
        }
       
        public async Task<IActionResult> ReportAdmin()
        {
            var username = HttpContext.Session.GetString("Username");
            var status = HttpContext.Session.GetString("Status");
            if (username == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            if (status != "Admin")
            {
                return RedirectToAction("Index", "Home");
            }

            TransactionListViewModel VM = await transactionService.GetAllTransaction("");

            return View(VM);
        }
        public IActionResult Login()
        {
            var username = HttpContext.Session.GetString("Username");
            if (username != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("Login");
        }

        public async Task<IActionResult> LogUserAsync(string email, string password)
        {
            AdminModel admin = await adminService.GetUser(email, password);

            if (admin != null)
            {
                HttpContext.Session.SetString("Username", admin.Username);
                HttpContext.Session.SetString("Email", admin.Email);
                //HttpContext.Session.SetString("Password", HashPassword(user.Password));
                HttpContext.Session.SetString("UserID", admin.UserID.ToString());
                HttpContext.Session.SetString("Status", "Admin");
                
                //ViewData["Username"] = user.Username;
                var a = HttpContext.Session.GetString("Username");
                return Json(new
                {
                    Status = true,
                    User = "Admin"
                });
            }
            else
            {
                return Json(new
                {
                    Status = false,
                    Message = "Wrong Credentials"
                });
            }
        }

        public async Task<IActionResult> AddBook(string BookTitle, string BookDesc, string Author, int Quantity, IFormFile Image, int Price)
        {
            if(string.IsNullOrWhiteSpace(BookTitle) || string.IsNullOrWhiteSpace(BookDesc) || string.IsNullOrWhiteSpace(Author) || Quantity < 0 || Price <= 0)
            {
                return Json(new
                {
                    Status = false,
                    User = "Wrong Input"
                });
            }
            else
            {
                await bookService.AddBook(BookTitle, BookDesc, Author, Quantity, Image, Price);
                return Json(new
                {
                    Status = true,
                    Message = "Book Inserted"
                });
            }
        }

        public async Task<IActionResult> AcceptPayment(string TransactionID)
        {
            await transactionService.AcceptPayment(TransactionID);
            return Json(new
            {
                Status = true
            });
        }
    }
}
