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
    public class UserService : Controller
    {
        private BieraliaDBContext dbContext;
        public UserService(BieraliaDBContext dBContext)
        {
            this.dbContext = dBContext;
        }
        public async Task<UserModel> GetUser(string Email, string Password)
        {
            UserModel data = await dbContext.User.
                    Where(e => e.Email == Email && e.Password == Password).
                    Select(e => new UserModel()
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
            return data;
        }

        public async Task<Boolean> AddUser(string Username, DateTime DOB, string PhoneNumber, string Email, string Password, string Address)
        {
            UserModel data = await dbContext.User.
                    Where(e => e.Email == Email || e.Username == Username).
                    Select(e => new UserModel()
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
            if(data != null)
            {
                return false;
            }
            else
            {
                await dbContext.User.AddAsync(new UserEntity()
                {
                    UserID = Guid.NewGuid(),
                    Username = Username,
                    DOB = DOB,
                    Password = Password,
                    Email = Email,
                    PhoneNumber = PhoneNumber,
                    Address = Address,
                    Status = "U"
                });
                await dbContext.SaveChangesAsync();
                return true;
            }
        }
    }
}
