using Bieralia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Bieralia.Entities;
using Bieralia.Services;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Bieralia.ViewModels;
using System.Collections;

namespace Bieralia.Controllers
{
    public class BookController : Controller
    {

        private readonly BookService bookService;
        public BookController(BookService bookService) //constructor
        {
            this.bookService = bookService;
        }
        public async Task<IActionResult> IndexAsync(string Search)
        {
            BookViewModel BVModel = new BookViewModel();
            BVModel.BookList = await bookService.GetBooks(Search);

            return View("Index", BVModel);
        }

        public async Task<IActionResult> BookDetail(string ID)
        {
            BookModel BModel = new BookModel();
            BModel = await bookService.GetBookById(ID);

            return View("BookDetail", BModel);
        }

        
    }
}
