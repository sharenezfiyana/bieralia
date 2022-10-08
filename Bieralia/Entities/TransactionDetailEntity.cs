using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Bieralia.Entities
{
    public class TransactionDetailEntity
    {
        public Guid TransactionDetailID { get; set; }
        public string TransactionID { get; set; }
        public string BookID { get; set; }
        public int Quantity { get; set; }
    }

    public class TransactionDetailEntityModelBuilder : IEntityTypeConfiguration<TransactionDetailEntity>
    {
        public void Configure(EntityTypeBuilder<TransactionDetailEntity> entity)
        {
            entity.HasKey(e => e.TransactionDetailID);
        }
    }
}

