using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Bieralia.Entities
{
    public class TransactionEntity
    {
        public string TransactionID { get; set; }
        public string Status { get; set; }
        public Guid UserID { get; set; }
    }

    public class TransactionEntityModelBuilder : IEntityTypeConfiguration<TransactionEntity>
    {
        public void Configure(EntityTypeBuilder<TransactionEntity> entity)
        {
            entity.HasKey(e => e.TransactionID);
        }
    }
}
