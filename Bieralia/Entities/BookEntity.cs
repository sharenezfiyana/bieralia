using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bieralia.Entities
{
    public class BookEntity
    {
        public string BookID { get; set; }
        public string BookTitle { get; set; }
        public string BookDesc { get; set; }
        public string Author { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }
    }

    public class BookEntityModelBuilder : IEntityTypeConfiguration<BookEntity>
    {
        public void Configure(EntityTypeBuilder<BookEntity> entity)
        {
            entity.HasKey(e => e.BookID);
        }
    }
}
