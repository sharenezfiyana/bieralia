using Bieralia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Bieralia.Entities;

namespace Bieralia.Services
{
    public class AdminService : Controller
    {
        private BieraliaDBContext dbContext;
        public AdminService(BieraliaDBContext dBContext)
        {
            this.dbContext = dBContext;
        }
        public async Task<AdminModel> GetUser(string Email, string Password)
        {
            AdminModel data = await dbContext.Admin.
                    Where(e => e.Email == Email && e.Password == Password).
                    Select(e => new AdminModel()
                    {
                        UserID = e.UserID,
                        Username = e.Username,
                        DOB = (System.DateTime)e.DOB,
                        Email = e.Email,
                        Password = e.Password,
                        PhoneNumber = e.PhoneNumber,
                        Address = e.Address,
                        Status = e.Status
                    }).FirstOrDefaultAsync();
            Console.WriteLine(data);
            return data;
        }
    }
}
