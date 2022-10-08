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
using Bieralia.ViewModels;

namespace Bieralia.Services
{
    public class TransactionService : Controller
    {
        private BieraliaDBContext dbContext;
        private readonly BookService bookService;
        public TransactionService(BieraliaDBContext dBContext, BookService bookService)
        {
            this.dbContext = dBContext;
            this.bookService = bookService;
        }


        public async Task AddTransaction(string UserID, List<CartModel> cart)
        {
            string id = "TR" + DateTime.Now.ToString("yyyyMMddHHmmss");

            Guid UserGuid = Guid.Parse(UserID);

            await dbContext.Transaction.AddAsync(new TransactionEntity()
            {
                TransactionID = id,
                Status = "Unpaid",
                UserID = UserGuid
            });
            await dbContext.SaveChangesAsync();

            foreach (var book in cart)
            {
                await AddTransactionDetail(id, book.BookID, book.Quantity);
                await bookService.UpdateBookQuantity(book.BookID, book.Quantity);
            }

        }

        public async Task AddTransactionDetail(string TransactionID, string bookID, int Quantity)
        {
            await dbContext.TransactionDetail.AddAsync(new TransactionDetailEntity()
            {
                TransactionDetailID = Guid.NewGuid(),
                TransactionID = TransactionID,
                BookID = bookID,
                Quantity = Quantity
            });
            await dbContext.SaveChangesAsync();
        }

        public async Task<TransactionListViewModel> GetAllTransaction(string UserID)
        {
            List<TransactionViewModel> trlist = new List<TransactionViewModel>();
            List<TransactionModel> tr = await GetTransactionByUserID(UserID);
            foreach (TransactionModel trs in tr)
            {
                TransactionViewModel t = await GetTransactionByTransactionID(trs.TransactionID);
                trlist.Add(t);
            }
            TransactionListViewModel tl = new TransactionListViewModel();
            tl.TransactionList = trlist;
            return tl;
        }

        public async Task<TransactionViewModel> GetTransactionByTransactionID(string TransactionID)
        {
            TransactionViewModel tr = new TransactionViewModel();
            TransactionModel t = await dbContext.Transaction
                                .Where(e => e.TransactionID == TransactionID)
                                .Select(e => new TransactionModel()
                                {
                                    TransactionID = e.TransactionID,
                                    UserID = e.UserID,
                                    Status = e.Status
                                }).FirstOrDefaultAsync();
            List<TransactionDetailViewModel> td = await GetTransactionDetailByTransactionID(t.TransactionID);
            tr.Transaction = t;
            tr.TransactionDetailList = td;
            return tr;
        }

        public async Task<List<TransactionModel>> GetTransactionByUserID(string UserID)
        {
            List<TransactionModel> tr = new List<TransactionModel>();
            tr = await dbContext.Transaction
                .Where(x => x.UserID.ToString().Contains(UserID))
                .OrderByDescending(x => x.TransactionID)
                .Select(x => new TransactionModel()
                {
                    TransactionID = x.TransactionID,
                    UserID = x.UserID,
                    Status = x.Status
                }).ToListAsync();
            return tr;
        }

        public async Task<List<TransactionDetailViewModel>> GetTransactionDetailByTransactionID(string TransactionID)
        {
            List<TransactionDetailViewModel> tdlist = new List<TransactionDetailViewModel>();
            List<TransactionDetailModel> td = new List<TransactionDetailModel>();
            td = await dbContext.TransactionDetail
                .Where(x => x.TransactionID == TransactionID)
                .Select(x => new TransactionDetailModel()
                {
                    TransactionDetailID = x.TransactionDetailID,
                    TransactionID = TransactionID,
                    BookID = x.BookID,
                    Quantity = x.Quantity
                }).ToListAsync();
            foreach (TransactionDetailModel tds in td)
            {
                BookModel book = await bookService.GetBookByIdForTransaction(tds.BookID);
                TransactionDetailViewModel tdv = new TransactionDetailViewModel()
                {
                    Book = book,
                    TransactionDetail = tds
                };
                tdlist.Add(tdv);
            }
            return tdlist;
        }

        public async Task AcceptPayment(string TransactionID)
        {
            TransactionEntity upd = await dbContext.Transaction.Where(e => e.TransactionID == TransactionID).FirstOrDefaultAsync();
            upd.Status = "Paid";

            await dbContext.SaveChangesAsync();
        }
    }
}
