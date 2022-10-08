using Bieralia.Entities;
using Bieralia.Models;
using Bieralia.Services;
using Bieralia.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Bieralia.Controllers
{
    
    public class UserController : Controller
    {
        private readonly UserService userService;
        private readonly BookService bookService;
        private readonly TransactionService transactionService;
        public UserController(UserService userService, BookService bookService, TransactionService transactionService) //constructor
        {
            this.userService = userService;
            this.bookService = bookService;
            this.transactionService = transactionService;
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

        public IActionResult Register()
        {
            var username = HttpContext.Session.GetString("Username");
            if (username != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("Register");
        }

        public async Task<IActionResult> LogUserAsync(string email, string password)
        {
            UserModel user = await userService.GetUser(email, password);

            if (user != null)
            {
                List<CartModel> cart = new List<CartModel>();
                HttpContext.Session.SetString("Username", user.Username);
                HttpContext.Session.SetString("Email", user.Email);
                HttpContext.Session.SetString("UserID", user.UserID.ToString());
                HttpContext.Session.SetString("Status", "User");
                HttpContext.Session.SetObject("cart", cart);
                //ViewData["Username"] = user.Username;
                return Json(new
                {
                    Status = true,
                    User = "User"
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

        public async Task<IActionResult> RegisterUser(string Username, DateTime DOB, string PhoneNumber, string Email, string Password, string Address)
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(DOB.ToString()) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(PhoneNumber))
            {
                return Json(new
                {
                    Status = false,
                    Message = "Wrong Inputs"
                });
            }
            else
            {
                Boolean addUser =  await userService.AddUser(Username, DOB, PhoneNumber, Email, Password, Address);
                if (addUser)
                {
                    return Json(new
                    {
                        Status = true
                    });
                }
                else
                {
                    return Json(new
                    {
                        Status = false,
                        Message = "Username or Email Already Exist"
                    });
                }
            }
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> AddToCart(string BookID, string BookTitle, string BookDesc, string Author, int Quantity, string Image, int Price)
        {
            var username = HttpContext.Session.GetString("Username");
            if (username == null)
            {
                return Json(new
                {
                    Status = false,
                    Message = "Please Login"
                });
            }
            else
            {
                CartModel cartModel = new CartModel
                {
                    BookID = BookID,
                    BookDesc = BookDesc,
                    Author = Author,
                    BookTitle = BookTitle,
                    Price = Price,
                    Image = Image,
                    Quantity = Quantity
                };
                List<CartModel> cart = HttpContext.Session.GetObject<List<CartModel>>("cart");
                if (cart.Where(e => e.BookID == BookID).Count() != 0)
                {
                    foreach (var item in cart.Where(e => e.BookID == BookID))
                    {
                        BookModel BModel = await bookService.GetBookById(BookID);
                        if(item.Quantity + Quantity > BModel.Quantity || BModel.Quantity == 0)
                        {
                            return Json(new
                            {
                                Status = false,
                                Message = "Not enough quantity"
                            });
                        } 
                        else
                        {
                            item.Quantity += Quantity;
                        }
                    }
                }
                else
                {
                    cart.Add(cartModel);
                }
                HttpContext.Session.SetObject("cart", cart);
                return Json(new
                {
                    Status = true,
                    Message = "Added to cart"
                });
            }
        }

        public IActionResult Cart()
        {
            return View();
        }
        public async Task<IActionResult> History()
        {
            var UserID = HttpContext.Session.GetString("UserID");
            TransactionListViewModel transactionListVM = await transactionService.GetAllTransaction(UserID);

            return View(transactionListVM);
        }
        public async Task<IActionResult> Checkout()
        {
            List<CartModel> cart = HttpContext.Session.GetObject<List<CartModel>>("cart");
            string userID = HttpContext.Session.GetString("UserID");

            await transactionService.AddTransaction(userID, cart);
            List<CartModel> cart2 = new List<CartModel>();
            HttpContext.Session.SetObject("cart", cart2);
            return Json(new
            {
                Status = true,
                Message = "Transaction is being proceed"
            });
        }
    }
}
