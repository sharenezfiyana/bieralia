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
using Microsoft.EntityFrameworkCore;

namespace Bieralia.Services
{
    public class BookService : Controller
    {
        private BieraliaDBContext dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        public BookService(BieraliaDBContext dBContext, IWebHostEnvironment hostEnvironment)
        {
            this.dbContext = dBContext;
            webHostEnvironment = hostEnvironment;
        }

        public async Task AddBook(string BookTitle, string BookDesc, string Author, int Quantity, IFormFile Image, int Price)
        {
            string id = DateTime.Now.ToString("yyyyMMddHHmmss");
            string uniqueFileName = UploadFile(Image, id);

            await dbContext.Book.AddAsync(new BookEntity()
            {
                BookID = id,
                BookTitle = BookTitle,
                BookDesc = BookDesc,
                Author = Author,
                Quantity = Quantity,
                Image = uniqueFileName,
                Price = Price,
                Status = "A"
            });
            await dbContext.SaveChangesAsync();
        }

        public string UploadFile(IFormFile Image, string id)
        {
            string uniqueFileName = null;

            if (Image != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = id + Path.GetExtension(Image.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Image.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        public async Task<List<BookModel>> GetBooks(string Search)
        {
            if (String.IsNullOrWhiteSpace(Search))
            {
                List<BookModel> data = await dbContext.Book.
                    Where(book => book.Status == "A").
                    OrderByDescending(book => book.BookID).
                    Select(e => new BookModel()
                    {
                        BookID = e.BookID,
                        BookTitle = e.BookTitle,
                        BookDesc = e.BookDesc,
                        Author = e.Author,
                        Quantity = e.Quantity,
                        Image = e.Image,
                        Price = e.Price
                    }).ToListAsync();
                return data;
            }
            else
            {
                List<BookModel> data = await dbContext.Book.
                    Where(book => book.Status == "A" && book.BookTitle.Contains(Search)).
                    OrderByDescending(book => book.BookID).
                    Select(e => new BookModel()
                    {
                        BookID = e.BookID,
                        BookTitle = e.BookTitle,
                        BookDesc = e.BookDesc,
                        Author = e.Author,
                        Quantity = e.Quantity,
                        Image = e.Image,
                        Price = e.Price
                    }).ToListAsync();
                return data;
            }
            
        }

        public async Task<BookModel> GetBookById(string id)
        {
            BookModel data = await dbContext.Book
                .Where(e => e.BookID == id && e.Status == "A")
                .Select(e => new BookModel()
            {
                BookID = e.BookID,
                BookTitle = e.BookTitle,
                BookDesc = e.BookDesc,
                Author = e.Author,
                Quantity = e.Quantity,
                Image = e.Image,
                Price = e.Price
            }).FirstOrDefaultAsync();

            return data;
        }

        public async Task<BookModel> GetBookByIdForTransaction(string id)
        {
            BookModel data = await dbContext.Book
                .Where(e => e.BookID == id)
                .Select(e => new BookModel()
                {
                    BookID = e.BookID,
                    BookTitle = e.BookTitle,
                    BookDesc = e.BookDesc,
                    Author = e.Author,
                    Quantity = e.Quantity,
                    Image = e.Image,
                    Price = e.Price
                }).FirstOrDefaultAsync();

            return data;
        }

        public async Task DeleteBook(string bookid)
        {
            BookEntity to_del = await dbContext.Book.Where(e => e.BookID == bookid).FirstOrDefaultAsync();
            to_del.Status = "D";
            await dbContext.SaveChangesAsync();

            return;
        }

        public async Task UpdateBook(string bookid, string booktitle, string bookdesc, int qty, int price)
        {
            BookEntity upd = await dbContext.Book.Where(e => e.BookID == bookid).FirstOrDefaultAsync();
            upd.BookTitle = booktitle;
            upd.BookDesc = bookdesc;
            upd.Quantity = qty;
            upd.Price = price;

            await dbContext.SaveChangesAsync();

            return;
        }

        public async Task UpdateBookQuantity(string bookid, int quantity)
        {
            BookEntity upd = await dbContext.Book.Where(e => e.BookID == bookid).FirstOrDefaultAsync();
            upd.Quantity -= quantity;
            await dbContext.SaveChangesAsync();

            return;
        }
    }
}
