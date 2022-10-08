using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;

namespace Bieralia.Models
{
    public class AdminModel
    {
        public Guid UserID { get; set; }
        public string Username { get; set; }
        public DateTime? DOB { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
    }
}
