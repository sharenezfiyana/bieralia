using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Bieralia.Models
{
    public class TransactionModel
    {
        public string TransactionID { get; set; }
        public string Status { get; set; }
        public Guid UserID { get; set; }
    }

}
