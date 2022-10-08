using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Bieralia.Models
{
    public class TransactionDetailModel
    {
        public Guid TransactionDetailID { get; set; }
        public string TransactionID { get; set; }
        public string BookID { get; set; }
        public int Quantity { get; set; }
    }
}

